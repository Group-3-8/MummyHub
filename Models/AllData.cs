using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FagElGamousExcavation.Models
{
    public partial class AllData
    {
        [Key]
        public int UniqId2 { get; set; }
        public string UniqId { get; set; }
        public string BurialId { get; set; }
        public string BurialLocSummary { get; set; }
        //[Required]
        public string BurialLocationNs { get; set; }
        //[Required]
        public string BurialLocationEw { get; set; }
        //[Required]
        public string LowPairNs { get; set; }
        //[Required]
        public string HighPairNs { get; set; }
        //[Required]
        public string LowPairEw { get; set; }
        //[Required]
        public string HighPairEw { get; set; }
        //[Required]
        public string BurialSubplot { get; set; }
        public string AreaHillBurials { get; set; }
        //[Required]
        public string TombBurial { get; set; }
        //[Required]
        public string BurialDepth { get; set; }
        //[Required]
        public string SouthToHead { get; set; }
        //[Required]
        public string SouthToFeet { get; set; }
        //[Required]
        public string WestToHead { get; set; }
        //[Required]
        public string WestToFeet { get; set; }
        public string BurialSituation { get; set; }
        //[Required]
        public string LengthOfBurialCm { get; set; }
        //[Required]
        public string BurialNumber { get; set; }
        public string SampleNumber { get; set; }
        public string GenderCode { get; set; }
        public string BurialGenderMethod { get; set; }
        public string GenderGe { get; set; }
        public string GeFunctionTotal { get; set; }
        public string GenderBodyCol { get; set; }
        public string BasilarSuture { get; set; }
        public string VentralArc { get; set; }
        public string SubpubicAngle { get; set; }
        public string SciaticNotch { get; set; }
        public string PubicBone { get; set; }
        public string PreaurSulcus { get; set; }
        public string MedialIpRamus { get; set; }
        public string DorsalPitting { get; set; }
        public string ForemanMagnum { get; set; }
        public string FemurHead { get; set; }
        public string HumerusHead { get; set; }
        public string Osteophytosis { get; set; }
        public string PubicSymphysis { get; set; }
        public string FemurLength { get; set; }
        public string HumerusLength { get; set; }
        public string TibiaLength { get; set; }
        public string Robust { get; set; }
        public string SupraorbitalRidges { get; set; }
        public string OrbitEdge { get; set; }
        public string ParietalBossing { get; set; }
        public string Gonian { get; set; }
        public string NuchalCrest { get; set; }
        public string ZygomaticCrest { get; set; }
        public string CranialSuture { get; set; }
        public string MaximumCranialLength { get; set; }
        public string MaximumCranialBreadth { get; set; }
        public string BasionBregmaHeight { get; set; }
        public string BasionNasion { get; set; }
        public string BasionProsthionLength { get; set; }
        public string BizygomaticDiameter { get; set; }
        public string NasionProsthion { get; set; }
        public string MaximumNasalBreadth { get; set; }
        public string InterorbitalBreadth { get; set; }
        public string ArtifactsDescription { get; set; }
        //[Required]
        public string Goods { get; set; }
        public string HairColor { get; set; }
        public string HairColorCode { get; set; }
        public string PreservationIndex { get; set; }
        public string BurialPreservation { get; set; }
        public string HairTaken { get; set; }
        public string SoftTissueTaken { get; set; }
        public string BoneTaken { get; set; }
        public string ToothTaken { get; set; }
        public string TextileTaken { get; set; }
        public string BurialSampleTaken { get; set; }
        public string PreviouslySampled { get; set; }
        public string DescriptionOfTaken { get; set; }
        public string ArtifactFound { get; set; }
        public string EstimateAgeGroup { get; set; }
        public string EstimateAgeSingle { get; set; }
        public string BurialAgeMethod { get; set; }
        public string EstimateAge { get; set; }
        public string EstimateLivingStature { get; set; }
        public string ToothAttrition { get; set; }
        public string ToothEruption { get; set; }
        public string PathologyAnomalies { get; set; }
        public string EpiphysealUnion { get; set; }
        public string YearFound { get; set; }
        public string MonthFound { get; set; }
        public string DayFound { get; set; }
        public string HeadDirection { get; set; }
        public string BurialDirection { get; set; }
        public string FaceBundle { get; set; }
        public string Questions { get; set; }
        public string Calibrated95CalendarDateAvg { get; set; }
        public string Category { get; set; }
        public string BiologicalNotes { get; set; }
        public string BiologicalInitials { get; set; }
        public string OsteologyNotes { get; set; }
        public string Notes { get; set; }
        public string BagNum { get; set; }
        public string Cluster { get; set; }
        public string FieldBook1 { get; set; }
        public string FieldBook2 { get; set; }
        public string FieldBook3 { get; set; }
        public string FieldBook32 { get; set; }
        public string FieldBook4 { get; set; }
        public string FieldBook5 { get; set; }
        public string FieldBook6 { get; set; }
        public string FieldBook7 { get; set; }
        public string FieldBook8 { get; set; }
        public string UnknownColSorted { get; set; }
        public string YearOnSkull { get; set; }
        public string MonthOnSkull { get; set; }
        public string DateOnSkull { get; set; }
        public string FieldBook { get; set; }
        public string FieldBookPageNumber { get; set; }
        public string InitialsOfDataEntryExpert { get; set; }
        public string InitialsOfDataEntryChecker { get; set; }
        public string ByuSample { get; set; }
        public string BodyAnalysis { get; set; }
        public string SkullAtMagazine { get; set; }
        public string PostcraniaAtMagazine { get; set; }
        public string SexSkull2018 { get; set; }
        public string AgeSkull2018 { get; set; }
        public string RackAndShelf { get; set; }
        public string ToBeConfirmed { get; set; }
        public string SkullTrauma { get; set; }
        public string PostcraniaTrauma { get; set; }
        public string CribraOrbitala { get; set; }
        public string PoroticHyperostosis { get; set; }
        public string PoroticHyperostosisLocations { get; set; }
        public string MetopicSuture { get; set; }
        public string ButtonOsteoma { get; set; }
        public string PostcraniaTrauma2 { get; set; }
        public string OsteologyUnknownComment { get; set; }
        public string TemporalMandibularJointOsteoarthritisTmjOa { get; set; }
        public string LinearHypoplasiaEnamel { get; set; }
    }
}
