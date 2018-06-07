

namespace DTO
{
    using System;
    using System.Collections.Generic;

    public partial class Picture
    {
        public int IdPicture { get; set; }
        public string Url { get; set; }
        public int IdRoom { get; set; }

        public virtual Room Room { get; set; }
    }
}
