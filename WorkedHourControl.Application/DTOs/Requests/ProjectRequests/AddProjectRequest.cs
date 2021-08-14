namespace WorkedHourControl.Application.DTOs.Requests.TeamRequests
{
    public class AddProjectRequest
    {
        public string Name { get; set; }
        public int[] Teams { get; set; }
    }
}
