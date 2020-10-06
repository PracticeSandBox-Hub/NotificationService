using System;

namespace Data.Common
{
    public class BaseObject
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}


//SchoolNote - pascal casing

//schoolNote - camel casing

//School-Note - snake upper casing

//school-note - snake lower casing