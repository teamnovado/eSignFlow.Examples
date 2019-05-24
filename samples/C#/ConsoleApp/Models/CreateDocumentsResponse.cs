using System;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    class CreateDocumentsResponse
    {
        public IEnumerable<CreatedDocument> Documents { get; set; }

        public class CreatedDocument
        {
            public int Id { get; set; }
            public Guid FileId { get; set; }
            public string Code { get; set; }
            public bool CurrentUserShouldSign { get; set; }
            public bool CurrentUserShouldApprove { get; set; }
            public IEnumerable<CreatedDocument> Attachments { get; set; }
            public string DocumentDetailUrl { get; set; }
            public string SignUrl { get; set; }
        }
    }
}