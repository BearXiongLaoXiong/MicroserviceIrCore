using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceCodeTable.Model
{
    public class SysvComboboxItems
    {
        public SysvComboboxItems(string id, string text)
        {
            Id = id;
            Text = text;
        }

        public string Id { get; set; }
        public string Text { get; set; }
    }
}
