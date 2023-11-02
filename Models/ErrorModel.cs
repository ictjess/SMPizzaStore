using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Web;

namespace SMPizzaStore.Models
{
    public class ErrorModel
    {
        public string Page { get; set; }
        public string Activity { get; set; }
        //public string Method { get; set; }
        public string Prompt { get; set; }
        public string StackTrace { get; set; }

        public ErrorModel()
        {
            Page = "";
            Activity = "";
            Prompt = "";
            StackTrace = "";
        }
    }
}