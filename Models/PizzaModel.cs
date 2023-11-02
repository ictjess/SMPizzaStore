using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMPizzaStore.Models
{
    public class PizzaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyDate { get; set; }

        public PizzaModel()
        {
            Name = "";
            IsActive = true;
            CreateBy = "";
            CreateDate = "";
            ModifyBy = "";  
            ModifyDate = "";
        }
    }
}