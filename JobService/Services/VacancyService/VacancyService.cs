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

        public void DeleteVacancy(int vacancyId, string username)
        {
            User? user = _dbContext.Users!.FirstOrDefault(u => u.Username == username);
            var jobVacancy = _dbContext.JobVacancies!.Where(v => v.Id.Equals(vacancyId)).FirstOrDefault();
            if (user is null)
                throw new InvalidOperationException("User with username: " + username + " not exists.");
            else if(jobVacancy == null)
                throw new InvalidOperationException("Job vacancy with id: " + vacancyId + " not exists.");
            else if(jobVacancy.User != user)
                throw new InvalidOperationException("User with username: " + username + " is not owner of vacancy with id " + vacancyId + ".");
            try
            {                    
                _dbContext.JobVacancies!.Remove(jobVacancy);
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

        public List<JobVacancy> jobVacancies(string searchInput)
        {
            HashSet<JobVacancy> result = new HashSet<JobVacancy>();
            //result.Add(_dbContext.JobVacancies.Where())

            return result.ToList();
        }

        public List<JobVacancy> searchJobVacancies(string searchInput)
        {
            throw new NotImplementedException();
        }

        public List<JobVacancy> userJobVacancies(string username)
        {
            User? user = _dbContext.Users!.FirstOrDefault(u => u.Username == username);
            if (user is null)
                throw new InvalidOperationException("User with username: " + username + " not exists.");
            return _dbContext.JobVacancies!.Where(v => v.User!.Equals(user)).ToList();
        }
    }
}
