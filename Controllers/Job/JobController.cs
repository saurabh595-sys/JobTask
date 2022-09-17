using JobPortal.Service.Jobs;
using JobPortal.Service.Roles;
using Jobportel.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobportel.Data.Model;

namespace JobPortal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : BaseController
    {
        private readonly IJobService _jobService;
        public JobController(IJobService job)
        {
            _jobService = job;
        }

        [HttpGet("Jobs")]
        public async Task<IActionResult> GetJob()
        {
            var Jobs = await _jobService.GetAll();
            return OkResponse("Success", Jobs);
        }

        [HttpPost("Job/{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            Job job  = await _jobService.GetById(Id);
            return OkResponse("Sucess", job);
        }

        [HttpPost("Add/Job")]
        public async Task<IActionResult> Add(Job job)
        {
            job.CreatedBy = UserId;
            await _jobService.Add(job);
            return OkResponse("Sucess", job);
        }

        [HttpPut("UpdateRole")]
        public async Task<IActionResult> Update(Job job)
        {
            await _jobService.Update(job);
            return OkResponse("Sucess", job);
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _jobService.Delete(Id);
            return OkResponse("Sucess", Id);
        }

    }
}
