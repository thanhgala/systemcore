using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using SystemCore.Application.Interfaces;
using SystemCore.Application.ViewModels.Product;
using SystemCore.Data.Entities;
using SystemCore.Data.Enums;
using SystemCore.Data.IRepositories;
using SystemCore.Infrastructure.Interfaces;
using SystemCore.Utilities.DTO;

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

        public PageResult<ProductViewModel> GetAllPaging(int? categoryId, string keyworld, int page, int pageSize)
        {
            var query = _productRepository.FindAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyworld))
                query = query.Where(x => x.Name.Contains(keyworld));
            if (categoryId.HasValue)
                query = query.Where(x => x.CategoryId == categoryId.Value);
            int totalRow = query.Count();

            query = query.OrderByDescending(x => x.DateCreated)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ProjectTo<ProductViewModel>().ToList();

            var paginationSet = new PageResult<ProductViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }
    }
}