namespace TheOlssonGroup.Client.Features
{
    public class PagingLink
    {
        public string Text { get; set; } //för varje knapptext i våran pagination komponent, Previus, next 1,2,3 osv
        public int Page { get; set; } //Håller värdet för den nuvarande sidan.... 1,2,3,[4] osv
        public bool Enabled { get; set; } //för att sätta om vi är på en aktiv knapp eller avslagen
        public bool Active { get; set; }
        public PagingLink(int page,bool enabled,string text)
        {
            Page = page;
            Enabled = enabled;
            Text = text;
        }
    }
}
