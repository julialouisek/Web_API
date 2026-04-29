namespace Web_API.Models.DTOs
{ 
    public record GetUserResponse(int Id, string Name, string Phone);
    public record GetInterestResponse(int Id, string Name, string Description);
    public record GetLinkResponse(int Id, string URL);
    //public record CreateInterestRequest(string Name, string Description);
    public record CreateLinkRequest(string URL);

}
