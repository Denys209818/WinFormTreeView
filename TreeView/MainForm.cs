using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeView.DAL;
using TreeView.DAL.Entities;
using TreeView.DAL.Service;
using TreeView.Model;

namespace TreeView
{
    public partial class MainForm : Form
    {
        private EFContext _context { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this._context = new EFContext();
            DbSeeder.SeedAll(_context);
            var elements = this._context.Categories.Where(x => x.IsCore);
            List<CategoryNodeModel> models = RecursAddTree(elements.ToList());
            foreach (var item in ShowAllInTreeView(models)) 
            {
                this.tvMain.Nodes.Add(item);
            }
        }

        private List<CategoryNodeModel> RecursAddTree(ICollection<Category> categories) 
        {
            int current = 0;
            List<CategoryNodeModel> models = new List<CategoryNodeModel>();
            foreach (var item in categories) 
            {
                models.Add(new CategoryNodeModel { Category = item });
                item.Categories = this._context.Categories.Where(x => x.CategoryId == item.Id).ToList();
                if (item.Categories.Count() > 0) 
                {
                    models[current].Categories = item.Categories.ToList();
                    models[current].Id = item.Id;
                    RecursAddTree(item.Categories.ToList());
                }
                current++;
            }
            return models;
        }
        private List<TreeNode> ShowAllInTreeView(List<CategoryNodeModel> models) 
        {
            List<TreeNode> tree = new List<TreeNode>();
            foreach (var model in models) 
            {

                Category cat = this._context.Categories.Where(x => x.Id == model.Id).Select(x => new Category
                {
                    Name = x.Name,
                    Description = x.Description,
                    IsCore = x.IsCore,
                    Level = x.Level,
                    Categories = this._context.Categories.Where(y => y.CategoryId == model.Id).ToArray()
                }).FirstOrDefault();



                
                    TreeNode node = new TreeNode(cat.Name);
                    tree.Add(node);
                    if (cat.Categories.Count() > 0)
                    {
                        var arr = ShowAllInTreeView(
                          model.Categories.Select(x => new CategoryNodeModel
                          {
                              Id = x.Id,
                              Categories = x.Categories,
                          }).ToList());

                        node.Nodes.AddRange(arr.ToArray());
                    }
                
                
            }
            return tree;
        }
    }
}
