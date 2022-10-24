using JobService.Data;
using JobService.Models;

namespace JobService.Services.VacancyService
{
    public interface IVacancyService
    {
        void AddVacancy(string username, string title, int salary, string description);

        void DeleteVacancy(int id);

        List<JobVacancy> userJobVacancies(string username);

        List<JobVacancy> searchJobVacancies(string searchInput);
    }
}
