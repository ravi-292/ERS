using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERS.Services.ViewModels
{
    public class BookViewModel
    {
        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

    }
}