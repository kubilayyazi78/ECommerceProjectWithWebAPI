﻿namespace Entities.Dtos.Pages
{
    public class PageDeleteDto
    {
        public int Id { get; set; }
        public string PageURL { get; set; }
        public int? ParentID { get; set; }
        public int PageTypeID { get; set; }
        public int DisplayOrder { get; set; }
    }
}
