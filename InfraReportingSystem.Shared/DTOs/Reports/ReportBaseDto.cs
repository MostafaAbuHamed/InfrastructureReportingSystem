using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraReportingSystem.Shared.DTOs.Reports
{
    public class ReportBaseDto
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public List<string> PhotoUrls { get; set; } = new();
    }
}
