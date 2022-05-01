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
                throw new InvalidOperationException($"No record found in the Product table with id {productId}.");

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
            var productEntity = _mapper.Map<EntityModel.Product>(product);

            _db.Product.Update(productEntity);
            await _db.SaveChangesAsync();

            return _mapper.Map<Product>(productEntity);
        }

        public async Task UpdateProductAsync(Product product)
        {
            var productEntity = _db.Product.Find(product.ProductId) ??
                throw new InvalidOperationException($"No record found in the Product table with id {product.ProductId}.");

            _mapper.Map(product, productEntity);

            await _db.SaveChangesAsync();
        }

        public async Task RemoveProductAsync(int id)
        {
            var productEntity = _db.Product.Find(id) ??
                throw new InvalidOperationException($"No record found in the Product table with id {id}.");

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
                throw new InvalidOperationException($"No record found in the Category table with id {categoryId}.");

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
            var categoryEntity = _mapper.Map<EntityModel.Category>(category);

            _db.Category.Update(categoryEntity);
            await _db.SaveChangesAsync();

            return _mapper.Map<Category>(categoryEntity);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var categoryEntity = _db.Category.Find(category.CategoryId) ??
                throw new InvalidOperationException($"No record found in the Category table with id {category.CategoryId}.");

            _mapper.Map(category, categoryEntity);

            await _db.SaveChangesAsync();
        }

        public async Task RemoveCategoryAsync(int id)
        {
            var categoryEntity = _db.Category.Find(id) ??
                throw new InvalidOperationException($"No record found in the Category table with id {id}.");

            _db.Category.Remove(categoryEntity);

            await _db.SaveChangesAsync();
        }
    }
}
