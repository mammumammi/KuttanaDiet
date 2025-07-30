using System.ComponentModel.DataAnnotations.Schema;

public class Food{

    public int Id {get; set;}
    public required string Name {get; set;}
    public double CaloriesPer100g {get; set;}
    public double ProteinPer100g {get; set;}
    public double FatPer100g {get; set;}

    [Column(TypeName = "jsonb")]
    public string? vitamins {get; set;}
    public int? UserId {get; set;}
}