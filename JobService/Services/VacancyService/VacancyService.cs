using JobService.Data;
using JobService.Models;

namespace JobService.Services.VacancyService
{
    public class VacancyService : IVacancyService
    {
        private readonly ApplicationDbContext _dbContext;

        public VacancyService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddVacancy(string username, string title, int salary, string description)
        {
            User? user = _dbContext.Users!.FirstOrDefault(u => u.Username == username);
            if (user is null)
                throw new InvalidOperationException("User with username: " + username + " not exists.");
            try
            {
                _dbContext.JobVacancies!.Add(new JobVacancy(user, title, salary, description));
            }
            catch
            {
                throw;
            }
            finally
            {
                _dbContext.SaveChanges();
            }
        }

        public void DeleteVacancy(int id)
        {
            throw new NotImplementedException();
        }

        public List<JobVacancy> jobVacancies(string searchInput)
        {
            throw new NotImplementedException();
        }

        public List<JobVacancy> searchJobVacancies(string searchInput)
        {
            throw new NotImplementedException();
        }

        public List<JobVacancy> userJobVacancies(string username)
        {
            throw new NotImplementedException();
        }
    }
}
