﻿using Wallet.Core.ViewModels.Asset;
using Wallet.Core.ViewModels.Category;
using Wallet.Infrastructure.Data.Models;

namespace Wallet.Core.Contracts
{
    public interface ICategoryService
    {
        Category? GetCategoryById(Guid categoryId);
        (bool added, string error) Create(CreateCategoryFormModel model);
         List<AllCategoryViewModel> GetAllCategories();
         bool Delete(Guid categoryId);
         string GetCategoryName(Guid categoryId);
         CreateAssetModel AssetCreateFormModel (Guid categoryId);
         EditCategoryModel GetDetailsOfCategory(Guid categoryId);
         (bool isEdit,string error) Edit(EditCategoryModel model);
    }
}
