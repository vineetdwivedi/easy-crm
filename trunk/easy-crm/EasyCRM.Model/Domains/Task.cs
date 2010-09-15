using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyCRM.Model.Domains
{
    [MetadataType(typeof(TaskMetaData))]
    public partial class Task
    {
        // Validation rules for the Task class
        public class TaskMetaData
        {
            [ScaffoldColumn(false)]
            public object Id { get; set; }

            [Required(ErrorMessage = "A Subject is required")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public object Subject { get; set; }

            [DisplayName("Start Date")]
            [Required(ErrorMessage = "A Start Date is required")]
            [DataType(DataType.DateTime, ErrorMessage = "The start date time is invalid")]
            public object StartDate { get; set; }

            [DisplayName("Limit Date")]
            [Required(ErrorMessage = "A Limit Date is required")]
            [DataType(DataType.DateTime, ErrorMessage = "The limit date time is invalid")]
            public object LimitDate { get; set; }

            [DisplayName("End Date")]
            [Required(ErrorMessage = "An End Date is required")]
            [DataType(DataType.DateTime, ErrorMessage = "The end date time is invalid")]
            public object EndDate { get; set; }

            
        }
    }

    public enum TaskPriority
    {
        Low = 1,
        Medium,
        High
    }

    public enum TaskStatus
    {
        NotStarted = 1,
        InProgress,
        Waiting,
        Finished,
        Cancelled
    }
}
