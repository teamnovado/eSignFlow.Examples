using System.Collections.Generic;

namespace ConsoleApp.Models
{
    class CreateDocumentsRequest
    {
        public List<Document> Documents { get; set; }

        public CreateDocumentsRequest()
        {
            Documents = new List<Document>();
        }
    }
}