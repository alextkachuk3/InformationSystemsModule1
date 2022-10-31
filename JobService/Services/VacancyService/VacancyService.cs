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

        public void AddVacancy(string username, string title, int? settlementId, int salary, string description)
        {
            User? user = _dbContext.Users!.FirstOrDefault(u => u.Username == username);
            if (user is null)
                throw new InvalidOperationException("User with username: " + username + " not exists.");
            try
            {
                var jobVacancy = new JobVacancy(user, title, salary, description);
                if (settlementId != null)
                {
                    jobVacancy.Settlement = _dbContext.Settlements!.Where(s => s.Id.Equals(settlementId)).FirstOrDefault();
                }
                _dbContext.JobVacancies!.Add(jobVacancy);
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
