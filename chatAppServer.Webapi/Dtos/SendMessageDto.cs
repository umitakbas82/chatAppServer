namespace chatAppServer.Webapi.Dtos
{
    public sealed record SendMessageDto(
        Guid UserID,
        Guid ToUserId,
        string Message
   
        );
}  
