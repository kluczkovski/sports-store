using System;
namespace SportsStore.WebApp.Models.ViewModels
{
    public class PagingInfoViewModel
    {
        public int TotalItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPage =>
            (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}

