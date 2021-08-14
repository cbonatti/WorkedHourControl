﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Requests.TeamRequests;
using WorkedHourControl.Application.DTOs.Responses.ProjectResponses;

namespace WorkedHourControl.Application.Services.ProjectServices
{
    public interface IProjectService
    {
        Task<IList<ProjectResponse>> Get();
        Task<ProjectResponse> Add(AddProjectRequest request);
        Task<ProjectResponse> Update(UpdateProjectRequest request);
    }
}