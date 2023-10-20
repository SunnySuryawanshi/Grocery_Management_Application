namespace Grocery_Management_Application.ViewModel.Grocery
{
    public class GroceryDetailViewModelcs
    {
        public int Id {  get; set; }
        public string ItemName {get; set;}  
        public string ItemDescription {get; set;}
        public string ItemType {get; set;}
        public string CategoryName {  get; set;}
        public DateTime CretedDate { get; set; }
        public double ItemPrice { get; set; }
        public string CreatedBy { get; set; }
    }
}
