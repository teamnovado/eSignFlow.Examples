namespace ConsoleApp.Models
{
    class DocumentSigner
    {
        public int UserId { get; set; }
        public int? Order { get; set; }
        public int? OrganisationGroupId { get; set; }

        public DocumentSigner(int userId, int? order = null, int? organisationGroupId = null)
        {
            UserId = userId;
            Order = order;
            OrganisationGroupId = organisationGroupId;
        }
    }

    class ExternalDocumentSigner : DocumentSigner
    {
        public string SignatureEmail { get; set; }
        public string SignatureFirstName { get; set; }
        public string SignatureLastName { get; set; }

        public ExternalDocumentSigner(string emailAddress, string firstName, string lastName)
            : base(0)
        {
            SignatureEmail = emailAddress;
            SignatureFirstName = firstName;
            SignatureLastName = lastName;
        }
    }
}