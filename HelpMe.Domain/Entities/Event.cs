using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMe.Domain.Entities
{
    public class Event
    {
        public int EventID { get; set; }
        public int CreatorID { get; set; }
        public Nullable<int> HelperID { get; set; }
        [Required(ErrorMessage = "Please fill up description field")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please fill up title field")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please fill up place field")]
        public string Place { get; set; }
        [Required(ErrorMessage = "Please fill up category field")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please fill up contact field")]
        public string Contact { get; set; }
        [Required(ErrorMessage = "Please fill up date field")]
        public DateTime Date { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public Nullable<bool> IsAcctepted { get; set; }
        public Nullable<bool> IsDone { get; set; }
        public Nullable<bool> ReviewedByCreator { get; set; }
        public Nullable<bool> ReviewedByHelper { get; set; }
    }
}
