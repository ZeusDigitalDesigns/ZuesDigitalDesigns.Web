using System.Collections.Generic;
using System.Threading.Tasks;
using ZuesDigitalDesigns.Models;

namespace ZuesDigitalDesigns.Services;

public interface ITechnicalWritingService
{
    Task<List<TechnicalWritingService>> GetAllServicesAsync();
    Task<TechnicalWritingService?> GetServiceByIdAsync(int id);
}