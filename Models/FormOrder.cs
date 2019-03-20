using System.ComponentModel.DataAnnotations;

namespace mariospizzamongo
{
    public class FormOrder
    {

        [Display(Name="Select pizza")]
        [Required]
        public string OrderCSV { get; set; }
        [Required]
        public string CustomerName { get; set; }
    }
}