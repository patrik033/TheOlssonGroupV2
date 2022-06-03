using Microsoft.AspNetCore.Components;
using TheOlssonGroup.Client.Features;
using TheOlssonGroup.Entities.Paging;

namespace TheOlssonGroup.Client.PagingComponents
{
    public partial class Pagination
    {
        [Parameter]
        public MetaData MetaData { get; set; }//metadata för att ja...hålla metadatan
        [Parameter]
        public int Spread { get; set; }//för att ha koll på hur många knappar vi ska visa upp före och efter den nuvarande sidan vi står på
        [Parameter]
        public EventCallback<int> SelectedPage { get; set; } //event som triggas varje gång vi väljer en ny sida att stå på
        private List<PagingLink> _links; //variabel för att hålla alla våra länkar till våran pagination komponent
        //så fort alla våra parametrar har fått sitt värded så triggas OnparametersSet
        protected override void OnParametersSet()
        {
            CreatePaginationLinks(); //metoden triggas och skapar våra länkar, dena metod riggas så fort vi trycker på knapparna i våran pagination komponent
        }
        private void CreatePaginationLinks()
        {
            _links = new List<PagingLink>();
            _links.Add(new PagingLink(MetaData.CurrentPage - 1, MetaData.HasPrevious, "Previous"));
            for (int i = 1; i < MetaData.TotalPages; i++)
            {
                if (i >= MetaData.CurrentPage - Spread && i <= MetaData.CurrentPage + Spread)
                {
                    _links.Add(new PagingLink(i, true, i.ToString()) { Active = MetaData.CurrentPage == i });
                }
            }
            _links.Add(new PagingLink(MetaData.CurrentPage + 1, MetaData.HasNext, "Next"));
        }
        public async Task OnselectedPage(PagingLink link)
        {
            if (link.Page == MetaData.CurrentPage || !link.Enabled)
            {
                return;
            }
            MetaData.CurrentPage = link.Page;
            await SelectedPage.InvokeAsync(link.Page); //current page blir här selected page för att trigga vårat eventcallback
        }
    }
}
