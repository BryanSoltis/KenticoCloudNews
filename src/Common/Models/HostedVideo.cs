using KenticoCloud.Delivery;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class HostedVideo
    {

        public string VideoId { get; set; }
        public IEnumerable<MultipleChoiceOption> Video { get; set; }
    }
}
