using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PhotoDTO
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public int LikeNumber { get; set; }
        public List<string> Comment { get; set; }
        public byte[] Image { get; set; }

        public int? ProfileDTOId { get; set; }
        public ProfileDTO ProfileDTO { get; set; }
    }
}
