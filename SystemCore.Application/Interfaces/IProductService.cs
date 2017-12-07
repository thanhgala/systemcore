using System;
using System.Collections.Generic;
using System.Text;
using SystemCore.Application.ViewModels.Product;

namespace SystemCore.Application.Interfaces
{
    public interface IProductService : IDisposable
    {
        void Add(ProductViewModel productCategoryVm);

        void Update(ProductViewModel productCategoryVm);

        void Delete(int id);

        List<ProductViewModel> GetAll();

        void Save();
    }
}
