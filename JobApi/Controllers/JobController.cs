using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApi.Models;
using JobApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController : ControllerBase
    {
        public JobServices _jobservice;
        public JobController(JobServices jobservice)
        {
            _jobservice = jobservice;
        }

        [HttpPost("create-job")]
        public IActionResult CreateJob(Job job)
        {
            _jobservice.CreateJob(job);
            return Ok();
        }

        [HttpGet("read-all-jobs")]
        public IActionResult GetAllJobs()
        {
            var allJobs = _jobservice.ReadAllJobs();
            return Ok(allJobs);
        }

        /*
        [HttpGet("read-job/{employee}")]
        public IActionResult ReadJobByEmployee(string employee)
        {
            var job = _jobservice.ReadJobByJobEmployee(employee);
            return Ok(job);
        }
        */

        [HttpPut("update-job-by-id")]
        public IActionResult UpdateJobById(Job job)
        {
            var updateJob = _jobservice.UpdateJobById(job);
            return Ok(updateJob);
        }

        [HttpDelete("delete-job-by-id/{id}")]
        public IActionResult DeleteJobById(int id)
        {
            _jobservice.DeleteJobById(id);
            return Ok();
        }
    }
}