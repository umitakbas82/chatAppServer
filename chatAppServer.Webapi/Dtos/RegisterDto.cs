namespace chatAppServer.Webapi.Dtos
{
    public sealed record RegisterDto(
               
        string Name,
        IFormFile File
        );
    
    
}
