using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

//[DSICSQL]
namespace PQS.Models
{
    //.[PaintRecords].[dbo]
    public class FOLOMoldCheck
    {
        [Key]
        public int ID { get; set; }

        public string? MoldBarcode { get; set; }
        public int? StyleCode { get; set; }
        public string? PartNumber { get; set; }
        public string? Pdesc { get; set; }

        public bool? FOOktoRun { get; set; }
        public bool? FOTrimSample { get; set; }
        public decimal? FOScrib { get; set; }
        public decimal? FOWeight { get; set; }
        public DateTime? FOTimeIn { get; set; }
        public DateTime? FOTimeOut { get; set; }

        public bool? LOOktoRun { get; set; }
        public bool? LOTrimSample { get; set; }
        public decimal? LOScrib { get; set; }
        public decimal? LOWeight { get; set; }
        public DateTime? LOTimeIn { get; set; }
        public DateTime? LOTimeOut { get; set; }

        public bool? FOTL { get; set; }
        public bool? FOSup { get; set; }
        public bool? FOQua { get; set; }

        public bool? LOTL { get; set; }
        public bool? LOSup { get; set; }
        public bool? LOQua { get; set; }

        public string? MoldBarcodeLO { get; set; }
        public string? UserInput { get; set; }
        public DateTime? Datetime { get; set; }
        public string? Comment { get; set; }

        public int? Cavity { get; set; }

        public decimal? FOScrib2 { get; set; }
        public decimal? FOWeight2 { get; set; }
        public DateTime? FOTimeIn2 { get; set; }
        public DateTime? FOTimeOut2 { get; set; }

        public decimal? LOScrib2 { get; set; }
        public decimal? LOWeight2 { get; set; }
        public DateTime? LOTimeIn2 { get; set; }
        public DateTime? LOTimeOut2 { get; set; }

        public decimal? FOWallStock { get; set; }
        public decimal? LOWallStock { get; set; }
        public decimal? FOWallStock2 { get; set; }
        public decimal? LOWallStock2 { get; set; }

        public bool? Acknowledge { get; set; }
        public bool? Disposition { get; set; }
        public string? Disp_By { get; set; }
        public DateTime? Disp_Time { get; set; }
        public bool? Escalation_Sent { get; set; }
        public string? Reason { get; set; }
        public string? Names_Present { get; set; }
    }

    public class FOLOChecks
    {
        public int? Style { get; set; }
        public string? CheckOpt { get; set; }
        public int? ID { get; set; } // Not a primary key in this table
        public int? ToolID { get; set; }
    }

    public class FOLOPart_Defect
    {
        public int? MoldID { get; set; }
        [Key]
        public int? ID { get; set; }
        public decimal? Loc_X { get; set; }
        public decimal? Loc_Y { get; set; }
        public string? Defect {  get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Cavity { get; set; }
    }
    
    public class FOLOPart_Defect_LO
    {
        public int? MoldID { get; set; }
        public int? ID { get; set; }
        public decimal Loc_X { get; set; }
        public decimal? Loc_Y { get; set; }
        public string? Defect { get; set; }
        public int Cavity { get; set; }
    }
    /*
    public class Molding_ImagesStyles
    {
        public byte[]? Image { get; set; }
        public string? Name { get; set; }
        public DateTime? DateInput { get; set; }
        public byte[]? ImageCav2 { get; set; }
    }
    */
    public class FOLOPartChecks
    {
        [Key]
        public int ID { get; set; }
        public int? MoldID { get; set; }
        public string? Check { get; set; }
        public bool? Result { get; set; }
        public string? CheckLO { get; set; }
        public bool? ResultLO { get; set; }
    }

    public class IMM_MoldPresets
    {
        [Key]
        public int MoldID { get; set; }

        [Required]
        public string Description { get; set; } = null!;
        public string? PartNumber1 { get; set; }
        public string? PartNumber2 { get; set; }
        [Required]
        public int QuotedCycle { get; set; }
        [Required]
        public int TeamMembers { get; set; }
        [Required]
        public int Cavities { get; set; }
        public string? MaterialNumber { get; set; }
        [Required]
        public string MaterialName { get; set; } = null!;
        [Required]
        public decimal PartWeight { get; set; }
        [Required]
        public decimal TargetCycle { get; set; }
        public int? PM_Cycles { get; set; }
        public decimal? ShotWeight { get; set; }
        public string? Program_Engineer { get; set; }
        public string? Customer { get; set; }
        public string? Program { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
        public bool? ShowInSchedule { get; set; }
        public int? UnclassifiedLimit { get; set; }
        public string? SupplierName { get; set; }
        public int? TimeUp { get; set; }
    }
}
