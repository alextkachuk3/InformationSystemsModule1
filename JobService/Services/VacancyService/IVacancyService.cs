using JobService.Data;
using JobService.Models;

namespace JobService.Services.VacancyService
{
    public interface IVacancyService
    {
        void AddVacancy(string username, string title, int? settlementId, int salary, string description);

        JobVacancy? GetVacancy(int vacancyId);

        void DeleteVacancy(int vacancyId, string username);

        List<JobVacancy> UserJobVacancies(string username);

        List<JobVacancy> SearchJobVacancies(string? searchInput, int? settlementId);
    }
}
