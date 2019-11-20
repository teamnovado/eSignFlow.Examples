namespace ConsoleApp.Models
{
    class DocumentSigner
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }

        public int? Order { get; set; }
        public int? OrganisationGroupId { get; set; }
        public int? SignatureTextId { get; set; }

        private DocumentSigner(int userId, string userEmail, int? order = null, int? organisationGroupId = null, int? signatureTextId = null)
        {
            UserId = userId;
            UserEmail = userEmail;
            Order = order;
            OrganisationGroupId = organisationGroupId;
            SignatureTextId = signatureTextId;
        }

        public DocumentSigner(int userId, int? order = null, int? organisationGroupId = null, int? signatureTextId = null)
            : this(userId, null, order, organisationGroupId, signatureTextId) {}

        public DocumentSigner(string userEmail, int? order = null, int? organisationGroupId = null, int? signatureTextId = null)
            : this(0, userEmail, order, organisationGroupId, signatureTextId) {}
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