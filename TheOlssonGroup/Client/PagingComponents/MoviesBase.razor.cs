using Microsoft.AspNetCore.Components;
using TheOlssonGroup.Entities.DTOs;
using TheOlssonGroup.Entities.Paging;

namespace TheOlssonGroup.Client.PagingComponents
{
    public  class MovieBase : ComponentBase
    {
        public string searchString1 = "";
        public bool bordered = true;
        public bool dense = false;
        public bool hover = true;
        public bool striped = true;
        public List<MovieDtoRecord> MovieLister { get; set; } = new List<MovieDtoRecord>();
        public MetaData MetaData { get; set; } = new MetaData();
        private MovieParameters _movieParameters = new MovieParameters();
        [Inject]
        public IMovieServiceClient MovieServiceClient { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetMoviesPaged();
        }
        public async Task SelectedPage(int page)
        {
            _movieParameters.PageNumber = page;
            await GetMoviesPaged();
        }
        public async Task GetMoviesPaged()
        {
            var pagingResponse = await MovieServiceClient.GetPagingResponse(_movieParameters);
            MovieLister = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }
        public async Task SearchChanged(string searchTerm)
        {
            Console.WriteLine(searchTerm);
            _movieParameters.PageNumber = 1;
            _movieParameters.SearchTerm = searchTerm;
            await GetMoviesPaged();
        }
    }
}
