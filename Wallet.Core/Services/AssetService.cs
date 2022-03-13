﻿using Wallet.Core.Constants;
using Wallet.Core.Contracts;
using Wallet.Core.ViewModels.Asset;
using Wallet.Infrastructure.Data.Models;

namespace Wallet.Core.Services
{
    public class AssetService : IAssetService
    {
        private readonly IRepository repo;
        private readonly ICategoryService categoryService;

        public AssetService(IRepository repo, ICategoryService categoryService)
        {
            this.repo = repo;
            this.categoryService = categoryService;
        }

        public (bool added, string error) Create(CreateAssetFormModel model)
        {
            bool added = false;
            string error = null;

            if (repo.All<Asset>().Any(c => c.Name == model.Name))
            {
                return (added, error = "Asset exist!");
            }

            var category = repo.All<Category>()
                                .FirstOrDefault(c => c.Name == model.CategoryName);

            if (category == null)
            {
                return (added, error = "Category is not valid!");
            }

            Asset a = new Asset()
            {
                Name = model.Name,
                Abbreviation = model.Abbreviation,
                CategoryId = category.Id,
                Category = category,
                Value = model.Value,
            };

            category.Assets.Add(a);

            try
            {
                repo.Add<Asset>(a);
                repo.SaveChanges();
                added = true;
            }
            catch (Exception)
            {
                error = "Cound not add asset!";
            }

            return (added, error);
        }

        public bool Delete(Guid assetId)
        {
            var asset = repo.All<Asset>()
                .FirstOrDefault(a => a.Id == assetId);
            var category = repo.All<Category>()
                .FirstOrDefault(c=>c.Id == asset.CategoryId);

            if (asset == null || category == null)
            {
                return false;
            }

            try
            {
                category.Assets.Remove(asset);
                repo.Remove<Asset>(asset);
                repo.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public List<AllAssetViewModel> GetAssetsInCategory(Guid categoryId)
        {
            return repo.All<Asset>()
                .Where(a=>a.Category.Id == categoryId)
                .Select(a => new AllAssetViewModel()
                {
                    AssetId = a.Id,
                    Name = a.Name,
                    Abbreviation = a.Abbreviation,
                    Price = a.Value,
                })
                .ToList(); ;
        }
    }
}
