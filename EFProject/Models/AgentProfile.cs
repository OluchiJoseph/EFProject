using System;
using System.Collections.Generic;

namespace EFProject.Models
{
    public partial class AgentProfile
    {
        public string? AgentName { get; set; }
        public string? WorkingArea { get; set; }
        public int AgentId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
    }
}
