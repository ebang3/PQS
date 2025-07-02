using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PQS.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FOLOMoldCheckController : ControllerBase
    {
        private readonly PaintRecordsDbContext _paintRecordsContext;
        private readonly ProductionDbContext _productionContext;
        public FOLOMoldCheckController(PaintRecordsDbContext paintRecordsContext, ProductionDbContext productionContext)
        {
            _paintRecordsContext = paintRecordsContext;
            _productionContext = productionContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetFOLOMoldCheck(DateTime? startDate, DateTime? endDate, string? searchType, string? searchText, bool escalation)
        {
            var today = DateTime.Today;
            startDate ??= today;
            endDate ??= today.AddDays(1).AddTicks(-1);
            var query = _paintRecordsContext.FOLOMoldCheck.AsQueryable();

            if (startDate.HasValue && endDate.HasValue)
            {
                query = query.Where(r => r.Datetime >= startDate && r.Datetime <= endDate);
            }

            if (escalation)
            {
                query = query.Where(r => r.Escalation_Sent == true);
            }

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                switch (searchType)
                {
                    case "Part Number":
                        query = query.Where(r => (r.PartNumber ?? "").Contains(searchText));
                        break;
                    case "Tool ID":
                        query = query.Where(r =>
                            _productionContext.IMM_MoldPresets.Any(p =>
                                ((p.PartNumber1 ?? "") == r.PartNumber || (p.PartNumber2 ?? "") == r.PartNumber)
                                && p.MoldID.ToString().Contains(searchText)
                            ));
                        break;
                    case "Part Description":
                        query = query.Where(r => (r.Pdesc ?? "").Contains(searchText));
                        break;
                }
            }

            var results = await query.OrderByDescending(r => r.Datetime).ToListAsync();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFOLOMoldCheck(int id)
        {
            var record = await _paintRecordsContext.FOLOMoldCheck.FindAsync(id);

            if (record == null)
                return NotFound();

            return Ok(record);
        }
    }

    [Route("api/[Controller]")]
    [ApiController]
    public class FOLOMoldPartChecksController : ControllerBase
    {
        private readonly PaintRecordsDbContext _context;

        public FOLOMoldPartChecksController(PaintRecordsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetFOLOPartChecks(int? moldID)
        {
            var query = _context.FOLOPartChecks.AsQueryable();

            if (moldID.HasValue)
            {
                query = query.Where(r => r.MoldID == moldID);
            }

            var results = await query.ToListAsync();
            return Ok(results);
        }
    }

    [Route("api/[Controller]")]
    [ApiController]
    public class FOLOChecksController : ControllerBase
    {
        private readonly PaintRecordsDbContext _paintRecordsContext;
        public FOLOChecksController(PaintRecordsDbContext context)
        {
            _paintRecordsContext = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetFOLOChecks(int? style)
        {
            var query = _paintRecordsContext.FOLOChecks.AsQueryable();

            if (style.HasValue)
            {
                query = query.Where(r => r.Style == style);
            }

            var results = await query.ToListAsync();
            return Ok(results);
        }
    }

    [Route("api/[Controller]")]
    [ApiController]
    public class FOLOPart_DefectController : ControllerBase
    {
        private readonly PaintRecordsDbContext _paintRecordsDbContext;

        public FOLOPart_DefectController(PaintRecordsDbContext context)
        {
            _paintRecordsDbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetFOLOPart_Defect(int MoldID)
        {
            var query = _paintRecordsDbContext.FOLOPart_Defect.AsQueryable();

            query = query.Where(r => r.MoldID == MoldID);

            var results = await query.ToListAsync();
            return Ok(results);
        }
    }

    [Route("api/[Controller]")]
    [ApiController]
    public class FOLOPart_Defect_LOController : ControllerBase
    {
        private readonly PaintRecordsDbContext _paintRecordsDbContext;

        public FOLOPart_Defect_LOController(PaintRecordsDbContext context)
        {
            _paintRecordsDbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetFOLOPart_Defect_LO(int MoldID)
        {
            var query = _paintRecordsDbContext.FOLOPart_Defect_LO.AsQueryable();

            query = query.Where(r => r.MoldID == MoldID);

            var results = await query.ToListAsync();
            return Ok(results);
        }
    }

    /*
    [Route("api/[Controller]")]
    [ApiController]
    public class Molding_ImagesStylesController : ControllerBase
    {
        private readonly PaintRecordsDbContext _paintRecordsDbContext;

        public Molding_ImagesStylesController(PaintRecordsDbContext context)
        {
            _paintRecordsDbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMolding_ImagesStyles(byte[] Image)
        {
            var query = _paintRecordsDbContext.Molding_ImagesStyles.AsQueryable();

            query = query.Where(r => r.Image == Image);

            var results = await query.ToListAsync();
            return Ok(results);
        }
    }
    */
}
