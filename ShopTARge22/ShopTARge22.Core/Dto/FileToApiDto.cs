using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.Core.Dto
{
    public class FileToApiDto
    {
        public Guid Id { get; set; }
        public string ExistingFilePath { get; set; }
        public Guid? SpaceshipId { get; set; }
    }
}
