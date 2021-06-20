using System.Collections.Generic;

namespace ComputerStoreAdmin.Models.Seller
{
    public class ServicesList
    {
        public class Service
        {
            public int    ID          { get; set; }
            public bool   isActive    { get; set; }
            public string Name        { get; set; }
            public string Description { get; set; }
            public double Price       { get; set; }
        }

        public int           ComplectID { get; set; }
        public List<Service> List       { get; set; }
    }
}
