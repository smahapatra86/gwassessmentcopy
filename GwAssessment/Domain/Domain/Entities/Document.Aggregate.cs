namespace Domain.Entities
{
    public partial class Document
    {
        public Document() { }
        public Document(string documentName)
        {
            DocumentName = documentName;
        }
    }
}
