namespace ConsoleApp.Models
{
    class OrganisationGroupModelInfo
    {
        public int Id { get; set; }
        public int OrganisationId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public OrganisationGroupType Type { get; set; }

        public enum OrganisationGroupType : byte
        {
            None = 0,
            Default = 1,
            SignGroup = 2,
            FunctionGroup = 3,
            OrganisationCluster = 4
        }
    }
}