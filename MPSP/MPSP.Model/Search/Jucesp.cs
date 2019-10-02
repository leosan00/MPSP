using System;

namespace MPSP.Model.Search
{
    public class Jucesp 
    {
        public Jucesp()
        {

        }
        public Jucesp(string name, int code)
        {
            this.Name = name;
            this.Code = code;
        }
        public Guid JucespId { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
    }
}
