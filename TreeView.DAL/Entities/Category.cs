using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TreeView.DAL.Entities
{
    [Table("tblTreeViewCategories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        [Required, StringLength(255)]
        public string Description { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public bool IsCore { get; set; } = false;
        [ForeignKey("category.Id")]
        public int CategoryId { get; set; }
        public virtual Category category { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
