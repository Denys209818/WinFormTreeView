using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreeView.DAL.Entities;

namespace TreeView.DAL.Service
{
    public static class DbSeeder
    {
        public static void SeedAll(EFContext context) 
        {
            SeedTreeViewCategory(context);
        }

        private static void SeedTreeViewCategory(EFContext context) 
        {
            if (context.Categories.Count() == 0) 
            {
                Category coreCategory = new Category
                {
                    Name = "Автомобілі",
                    Description = "Категорія про автомобілі",
                    Level = 0,
                    IsCore = true,
                    category = null
                };
                context.Categories.Add(coreCategory);
                context.SaveChanges();

                Category opelCategory = new Category 
                {
                    Name = "Opel",
                    Description = "Усе про автомобілі Opel",
                    Level = coreCategory.Level + 1,
                    category = coreCategory
                };
                Category audiCategory = new Category
                {
                    Name = "Audi",
                    Description = "Усе про автомобілі Audi",
                    Level = coreCategory.Level + 1,
                    category = coreCategory
                };
                context.Categories.AddRange(opelCategory, audiCategory);
                context.SaveChanges();

                Category firstAuto = new Category 
                { 
                    Name = "Opel Astra",
                    Description = "",
                    Level = opelCategory.Level + 1,
                    category = opelCategory
                };
                Category secondAuto = new Category 
                {
                    Name = "Opel Vivaro",
                    Description = "",
                    Level = opelCategory.Level + 1,
                    category = opelCategory
                };
                Category lastAuto = new Category 
                {
                    Name = "Audi Q8",
                    Description = "",
                    Level = audiCategory.Level + 1,
                    category = audiCategory
                };
                context.Categories.AddRange(firstAuto, secondAuto, lastAuto);
                context.SaveChanges();
            }
        }
    }
}
