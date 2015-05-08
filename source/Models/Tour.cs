using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Tours.Models
{
    public class Tour
    {
        [Newtonsoft.Json.JsonIgnore]
        public string Id { get; set; }
        
        [Required]
        [Newtonsoft.Json.JsonIgnore]
        public string Title { get; set; }

        [Required]
        [Newtonsoft.Json.JsonIgnore]
        public string Screen { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [Raven.Imports.Newtonsoft.Json.JsonIgnore]
        public Step AddedStep { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public List<string> SeenBy { get; set; }

        public List<Step> Steps { get; set; }
    }
}