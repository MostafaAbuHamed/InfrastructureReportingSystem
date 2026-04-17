using InfraReportingSystem.Domain.Entities;
using InfraReportingSystem.Shared.DTOs.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraReportingSystem.Shared.Mapping
{
    public static class ReportMappingExtensions
    {
        public static ReportBaseDto ToBaseDto(this Report report)
        {
            return new ReportBaseDto
            {
                Id = report.Id,
                Description = report.Description,
                Category = report.Category?.Name ?? string.Empty,
                Latitude = report.Latitude,
                Longitude = report.Longitude,
                PhotoUrls = report.ReportPics
                    .Select(p => p.PicUrl)
                    .ToList()
            };
        }
    }
}
