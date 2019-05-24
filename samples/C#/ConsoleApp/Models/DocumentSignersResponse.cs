using System;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    class DocumentSignersResponse
    {
        public IEnumerable<DocumentSigner> List { get; set; }

        public class DocumentSigner
        {
            public int UserId { get; set; }
            public int OrganisationGroupId { get; set; }
            public string DisplayName { get; set; }
            public SignerType Type { get; set; }
            public bool Absent { get; set; }
            public DateTime From { get; set; }
            public DateTime Until { get; set; }
            public int ReplacerUserId { get; set; }
            public string ReplacerDisplayName { get; set; }
            public string DisplayWarning { get; set; }
        }

        public enum SignerType
        {
            Person = 1,
            Certificate = 2,
            ExternalApp = 3,
            FunctionGroup = 4,
            OrganisationCluster = 5,
            SignGroup = 6,
            External = 7
        }
    }
}