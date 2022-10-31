using JobService.Data;
using JobService.Models;

namespace JobService.Services.VacancyService
{
    public interface IVacancyService
    {
        void AddVacancy(string username, string title, int? settlementId, int salary, string description);

        void DeleteVacancy(int vacancyId, string username);

        List<JobVacancy> userJobVacancies(string username);

        List<JobVacancy> searchJobVacancies(string searchInput);
    }
}
