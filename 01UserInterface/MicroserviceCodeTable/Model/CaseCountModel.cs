using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceCodeTable.Model
{
    public class CaseCountModel
    {
        //public string FlagId { get; set; }
        //public string FlagName { get; set; }
        public string ENTT_ID { get; set; } = "";
        public string States { get; set; } = "";
        //public int CountsText { get; set; }
        public int Counts { get; set; }

        public string CreateDate { get; set; }
    }
}
