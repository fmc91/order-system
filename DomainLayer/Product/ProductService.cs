using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DataLayer;
using DomainLayer.ProductModel;
using EntityModel = DataLayer.Model;

namespace DomainLayer
{
    public class ProductService : IProductService
    {
        private readonly OrderSystemContext _db;

        private readonly IMapper _mapper;

        public ProductService(OrderSystemContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IList<Product>> GetAllProductsAsync(int page, int itemsPerPage)
        {
            var productEntities = await _db.Product
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<Product>>(productEntities);
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var productEntity = await _db.Product.FindAsync(productId) ??
                throw new EntityNotFoundException("Product", productId);

            return _mapper.Map<Product>(productEntity);
        }

        public async Task<IList<Product>> GetProductsByNameSearchAsync(string query, int page, int itemsPerPage)
        {
            var productEntities = await _db.Product
                .Where(x => x.Name.Contains(query))
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<Product>>(productEntities);
        }

        public async Task<IList<Product>> GetProductsByCategoryAsync(int categoryId, int page, int itemsPerPage)
        {
            var productEntities = await _db.Product
                .Where(x => x.CategoryId == categoryId)
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<Product>>(productEntities);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            if (product.ProductId != 0)
                throw new InvalidOperationException("Entity primary key must be equal to zero to create a new entity.");

            var productEntity = _mapper.Map<EntityModel.Product>(product);

            _db.Product.Update(productEntity);
            await _db.SaveChangesAsync();

            return _mapper.Map<Product>(productEntity);
        }

        public async Task UpdateProductAsync(Product product)
        {
            if (product.ProductId == 0)
                throw new InvalidOperationException("Entity primary key must be non-zero to update an entity.");

            var productEntity = _db.Product.Find(product.ProductId) ??
                throw new EntityNotFoundException("Product", product.ProductId);

            _mapper.Map(product, productEntity);

            await _db.SaveChangesAsync();
        }

        public async Task RemoveProductAsync(int productId)
        {
            var productEntity = _db.Product.Find(productId) ??
                throw new EntityNotFoundException("Product", productId);

            _db.Product.Remove(productEntity);

            await _db.SaveChangesAsync();
        }

        public async Task<IList<Category>> GetAllCategoriesAsync(int page, int itemsPerPage)
        {
            var categoryEntities = await _db.Category
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<Category>>(categoryEntities);
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            var categoryEntity = await _db.Category.FindAsync(categoryId) ??
                throw new EntityNotFoundException("Category", categoryId);

            return _mapper.Map<Category>(categoryEntity);
        }

        public async Task<IList<Category>> GetCategoriesByNameSearchAsync(string query, int page, int itemsPerPage)
        {
            var categoryEntities = await _db.Category
                .Where(x => x.Name.Contains(query))
                .Skip(page * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();

            return _mapper.Map<List<Category>>(categoryEntities);
        }

        public async Task<Category> CreateCategory(Category category)
        {
            if (category.CategoryId != 0)
                throw new InvalidOperationException("Entity primary key must be equal to zero to create a new entity.");

            var categoryEntity = _mapper.Map<EntityModel.Category>(category);

            _db.Category.Update(categoryEntity);
            await _db.SaveChangesAsync();

            return _mapper.Map<Category>(categoryEntity);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            if (category.CategoryId == 0)
                throw new InvalidOperationException("Entity primary key must be non-zero to update an entity.");

            var categoryEntity = _db.Category.Find(category.CategoryId) ??
                throw new EntityNotFoundException("Category", category.CategoryId);

            _mapper.Map(category, categoryEntity);

            await _db.SaveChangesAsync();
        }

        public async Task RemoveCategoryAsync(int categoryId)
        {
            var categoryEntity = _db.Category.Find(categoryId) ??
                throw new EntityNotFoundException("Category", categoryId);

            _db.Category.Remove(categoryEntity);

            await _db.SaveChangesAsync();
        }
    }
}
