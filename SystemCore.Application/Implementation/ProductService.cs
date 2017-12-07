using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using SystemCore.Application.Interfaces;
using SystemCore.Application.ViewModels.Product;
using SystemCore.Data.Entities;
using SystemCore.Data.IRepositories;
using SystemCore.Infrastructure.Interfaces;

namespace SystemCore.Application.Implementation
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(ProductViewModel productVm)
        {
            var product = Mapper.Map<ProductViewModel, Product>(productVm);
            _productRepository.Add(product);
        }

        public void Update(ProductViewModel productVm)
        {
            _productRepository.Update(Mapper.Map<ProductViewModel, Product>(productVm));
        }

        public void Delete(int id)
        {
            _productRepository.Remove(id);
        }

        public List<ProductViewModel> GetAll()
        {
            return _productRepository.FindAll(x => x.ProductCategory).ProjectTo<ProductViewModel>().ToList();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}