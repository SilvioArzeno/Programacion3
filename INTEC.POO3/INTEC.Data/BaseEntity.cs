﻿using System;
namespace INTEC.Data
{
    public class BaseEntity
    {
        public Int32 Id { get; set; }
        public String RowId { get; set; }
        public Int32 CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 ModifyByUserId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
