using JobApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApi.Services
{
    public class JobServices
    {
        private DBContext _context;

        public JobServices(DBContext context)
        {
            _context = context;
        }

        // Create job into table
        public void CreateJob(Job job)
        {
            var _job = new Job()
            {
                EmployeeName = job.EmployeeName,
                EmployeeDepartment = job.EmployeeDepartment,
                JobContent = job.JobContent,
                DueDate = job.DueDate,
                Status = job.Status
            };
            _context.Jobs.Add(_job);
            _context.SaveChanges();
        }

        //Read all the jobs data from the database table
        public List<Job> ReadAllJobs() => _context.Jobs.ToList();
        /*
        List<Job> ReadAllJobs()
        {
            var _data = _context.Jobs
                .GroupBy(p => p.EmployeeName)
                .ToList();
            return _data;
        }
        */

        // Read job data by content
        /*
        public List<Job> CountJobByEmployee()
        {
            var _data = _context.Jobs
                .GroupBy(p => p.EmployeeName)
                .Select(g => new { EmployeeName = g.Key, Count = g.Count() })
                .OrderBy(d => d.EmployeeName)
                .ToList();

            return _data;
        }
        */

        // Update Job
        public Job UpdateJobById(Job job)
        {
            var _job = _context.Jobs.FirstOrDefault(n => n.JobId == job.JobId);
            if (_job != null)
            {
                _job.EmployeeName = job.EmployeeName;
                _job.EmployeeDepartment = job.EmployeeDepartment;
                _job.JobContent = job.JobContent;
                _job.DueDate = job.DueDate;
                _job.Status = job.Status;

                _context.SaveChanges();
            }
            return _job;
        }

        // Delete Job
        public void DeleteJobById(int jobId)
        {
            var _job = _context.Jobs.FirstOrDefault(n => n.JobId == jobId);
            if (_job != null)
            {
                _context.Jobs.Remove(_job);
                _context.SaveChanges();
            }
        }
    }
}
