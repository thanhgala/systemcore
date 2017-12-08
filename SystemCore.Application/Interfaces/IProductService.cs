using System;
using System.Collections.Generic;
using System.Text;
using SystemCore.Application.ViewModels.Product;
using SystemCore.Utilities.DTO;

namespace SystemCore.Application.Interfaces
{
    public interface IProductService : IDisposable
    {
        void Add(ProductViewModel productCategoryVm);

        void Update(ProductViewModel productCategoryVm);

        void Delete(int id);

        void Save();

        List<ProductViewModel> GetAll();

        PageResult<ProductViewModel> GetAllPaging(int? categoryId, string keyworld, int page, int pageSize);
    }
}
