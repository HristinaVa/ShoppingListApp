using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShoppingList.Contracts;
using ShoppingList.Data;
using ShoppingList.Data.Models;
using ShoppingList.Models;

namespace ShoppingList.Services
{
    public class ProductService : IProductService
    {

        private readonly ShoppingListDbContext context;
        public ProductService(ShoppingListDbContext _context)
        {
            context = _context;
        }

        public async Task AddProductAsync(ProductViewModel model)
        {
            var entity = new Product()
            {
                Name = model.Name
            };
            await context.Products.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var entity = await context.Products.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentException("Invalid Product");
            }
            context.Products.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            return await context.Products.AsNoTracking().Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name
            }).ToListAsync();
        }

        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            var entity = await context.Products.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentException("Invalid Products"); 
            }
            return new ProductViewModel()
            {
                Id = id,
                Name = entity.Name
            };
        }

        public async Task UpdateProductAsync(ProductViewModel model)
        {
            var entyti = await context.Products.FindAsync(model.Id);
            if (entyti == null)
            {
                throw new ArgumentException("Invalid Product");
            }
            entyti.Name = model.Name;
            await context.SaveChangesAsync();
        }
    }
}
