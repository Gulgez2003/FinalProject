﻿namespace Entities.Concrete
{
    public class Blog:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public string DateTime { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageName { get; set; }
    }
}
