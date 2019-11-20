using System.Collections.Generic;

namespace ConsoleApp.Models
{
    class DocumentTemplatesResponse
    {
        public IEnumerable<DocumentTemplate> List { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalCount { get; set; }
    }

    class DocumentTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TemplateType Type { get; set; }
        public bool ForceDraft { get; set; }
        public bool Eid { get; set; }
        public int Language { get; set; }
        public ICollection<OrganisationGroupModelInfo> PermittedOrganisationGroups { get; set; }

        public enum TemplateType
        {
            Manual = 0,
            GovFlow = 1,
            Api = 2
        }
    }
}