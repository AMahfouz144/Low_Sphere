
namespace Domain.Common
{
    public enum FilterInvitationType
    {
        Inbox = 1,//Inbox
        Sent = 2,
        Archive = 3
    }

    public enum EnInvitationsType
    {
        OnGoing = 1,
        Expired = 2
    }

    public enum EnUserFilter
    {
        Pending = 1,
        Registered = 2
    }

    public enum EnUserSort
    {
        CreationDate = 1,
        Statuse = 2
    }

    public enum SortType
    {
        Ascending = 1,
        descending = 2
    }
    public enum QRForWaht
    {
        T4Identity = 1,
        OTInvitation = 2,
        OccupantResident = 3,
        FamilyResident = 4
    }

    public enum EntityStatus
    {
        New = 1,
        Modified = 2,
        Deleted = 3,
        NoChanges = 4
    }
    public enum AssignmentStatus
    {
        Inprogress = 1,//once 
        Scheduled = 2,//once Assignment added
        Suspended = 3,//Not used Now
        Cancelled = 4, //call by revoke from front , and update EndDate
        Closed = 5, // once Mission itself Closed , will update all related Mission Assignment to be closed , and updatee EndDate 
        Expired = 6 // update atumatically from backend service , when To time < now
    }

    public enum SortBy
    {
        Name = 1,
        Contact = 2
    }

    public enum AssignmentsSortBy
    {
        MissionName = 1,
        From = 3,
        To = 4,
        Statuse = 5
    }

    public enum MissionsSortBy
    {
        Name = 1,
        Type = 2,
        Target = 3,
        Status = 4
    }

    public enum StaffSortBy
    {
        Name = 1,
        Creation = 2

    }

    public enum IOTDeviceTrackingSortBy
    {
        Name = 1,
        Creation = 2

    }
    public enum StaffServiceSortBy
    {

        StaffName = 1,
        OwnerName = 2,
        From = 3,
        To = 4,
        Creation = 5

    }

    public enum GateSortBy
    {
        Name = 1,
        //Mission=2,
        //Assignment=3
    }

    public enum GetGateMissionSortBy
    {
        Mission = 1,
        Status = 2
    }

    public enum GateMissionSortBy
    {
        Mission = 1,
        Assignments = 2,
        Status = 3
    }

    public enum Memberstatus
    {
        Pending = 1,
        verified = 2
    }

    public enum DeviceStatus
    {
        Available = 1,
        Paired = 2,
        Deactivated = 3
    }


    public enum BarrierType
    {
        Entrance = 1,
        Exit = 2,
        Both = 3
    }

    public enum Mode
    {
        Single = 1,
        Multiple = 2
    }

    public enum BarrierStatus
    {
        Add = 1,
        Delete = 2,
        Edit = 3,
        NoChange = 4
    }

}