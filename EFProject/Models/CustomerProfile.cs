using System;
using System.Collections.Generic;

namespace EFProject.Models
{
    public partial class CustomerProfile
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? State { get; set; }
        public int? AgentId { get; set; }
    }
}
