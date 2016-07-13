using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public int LikeNumber { get; set; }
        public List<string> Comment { get; set; }
        public DateTime Time { get; set; }
        public byte[] Image { get; set; }

        public int? ProfileId { get; set; }
        public Profile Profile { get; set; }
        
    }
}
