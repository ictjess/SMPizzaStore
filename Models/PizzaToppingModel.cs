using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMPizzaStore.Models
{
    public class PizzaToppingModel
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int ToppingId { get; set; }
        public bool IsActive { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyDate { get; set; }
        public PizzaToppingModel()
        {
            PizzaId = -1;
            ToppingId = -1;
            IsActive = true;
            CreateBy = "";
            CreateDate = "";
            ModifyBy = "";
            ModifyDate = "";
        }
    }
}