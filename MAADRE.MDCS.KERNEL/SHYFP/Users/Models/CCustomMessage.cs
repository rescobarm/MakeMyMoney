using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAADRE.MDCSI.KERNEL.SHYFP.Users.Models
{
    public class CCustomMessage
    {
        public int Id { get; set; }
        public string? IdFrom { get; set; }
        public string? IdTo { get; set; }
        public bool Status { get; set; }
        public string? CodeStatus { get; set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? MessageBackGround { get; set; }
    }
}