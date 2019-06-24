using System;

namespace AspNetCoreAngular.DTO
{
    public class PhotoDTO
    {
        public long PhotoID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Url { get; private set; }
        public DateTime? CreateDate { get; private set; }
        public DateTime? DeleteDate { get; private set; }

    }
}