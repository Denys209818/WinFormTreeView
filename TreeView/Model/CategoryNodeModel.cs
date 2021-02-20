using System;
using System.Collections.Generic;
using System.Text;
using TreeView.DAL.Entities;

namespace TreeView.Model
{
    public class CategoryNodeModel
    {
        public Category Category { get; set; }
        public ICollection<Category> Categories { get; set; }
        public int Id { get; set; }
    }
}
