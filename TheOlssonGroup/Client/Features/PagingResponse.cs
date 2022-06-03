﻿using TheOlssonGroup.Entities.Paging;


namespace TheOlssonGroup.Client.Features
{
    public class PagingResponse<T> where T : class
    {
        public List<T> Items { get; set; }
        public MetaData MetaData { get; set; }
    }
}
