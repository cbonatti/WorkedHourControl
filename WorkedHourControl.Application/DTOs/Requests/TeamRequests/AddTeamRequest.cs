namespace WorkedHourControl.Application.DTOs.Requests.TeamRequests
{
    public class AddTeamRequest
    {
        public string Name { get; set; }
        public int[] Employees { get; set; }
    }
}
