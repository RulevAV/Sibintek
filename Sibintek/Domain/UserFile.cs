using System;
using System.Collections.Generic;

#nullable disable

namespace Sibintek.Domain
{
    public partial class UserFile
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public byte[] File { get; set; }
        public string Name { get; set; }
        public string Sender { get; set; }
        public DateTime DateAdd { get; set; }
    }
}
