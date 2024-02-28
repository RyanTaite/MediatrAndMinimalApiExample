namespace MediatR.ServiceLayer.MemberAttendance.UpdateAttendance;

public class UpdateAttendanceResult
{
    /// <summary>
    /// New attendance status
    /// </summary>
    public bool IsAttending { get; set; }
}