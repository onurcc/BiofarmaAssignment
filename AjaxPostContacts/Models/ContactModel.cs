using System;
using System.ComponentModel.DataAnnotations;

namespace AjaxPostContacts.Models
{
    public class ContactModel
    {
        public string? Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RecordDate { get; set; }
        public int? Age { get; set; }
        public string? City { get; set; }

    }

    public enum Cities
    {
        İstanbul,
        Ankara,
        İzmir,
        Bursa,
        Adana
    }
}
