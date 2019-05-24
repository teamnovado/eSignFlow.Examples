namespace ConsoleApp.Models
{
    enum DocumentStatus
    {
        Unknown = 0,

        Unsigned = 1,
        PartiallySigned = 2,
        FullySigned = 3,
        Refused = 4,
        DisApproved = 5,
        UnApproved = 6,
        Approved = 7,
        PartiallyApproved = 8,
    }
}