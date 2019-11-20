using System;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    class Document
    {
        public Guid FileId { get; set; }
        public string Title { get; set; }
        public bool IsDraft { get; set; }
        public int? OrganisationClusterId { get; set; }
        public int? TemplateId { get; set; }
        public string InternalNote { get; set; }
        public string ExternalSignerNote { get; set; }
        public string ExternalNote { get; set; }
        public IEnumerable<DocumentSigner> Signers { get; set; }
        public IEnumerable<DocumentAttachment> Attachments { get; set; }


        //Extended fields only used when using POST documents/create

        public DocumentType DocumentType { get; set; }
        public int? DefaultSignatureTextId { get; set; }
        public bool RequiresEid { get; set; }
        public bool SendByPost { get; set; }
        public int ReminderDays { get; set; }
        public int LanguageId { get; set; }
        public int SignaturePageType { get; set; }
        public bool ShouldBrand { get; set; }
        public bool ShouldScale { get; set; }
        public bool DeliverWithRrn { get; set; }
        public bool AllowReceipt { get; set; }
        public bool OpenedCheckEnabled { get; set; }
        public int OpenedCheckDays { get; set; }
        public IEnumerable<DocumentReceiver> Receivers { get; set; }

        public Document()
        {
            Signers = new List<DocumentSigner>();
            Attachments = new List<DocumentAttachment>();
            Receivers = new List<DocumentReceiver>();
        }
    }
}