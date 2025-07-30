public class DailyLog{
    public int Id {get;set;}
    public int FoodId{get; set;}
    public int UserId{get; set;}
    public Mealtype MealType{get;set;}
    public DateTime Date{get; set;}
    public double QuantityInGrams{get; set;}
    public Food? Food{get; set;}
}