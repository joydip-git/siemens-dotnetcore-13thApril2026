using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Siemns.DotNet.PmsApp.APIs.Models.Dao.Abstractions;
using Siemns.DotNet.PmsApp.APIs.Models.DTOs;
using Siemns.DotNet.PmsApp.APIs.Models.Entities;
using Siemns.DotNet.PmsApp.APIs.Models.Repository;

namespace Siemns.DotNet.PmsApp.APIs.Models.Dao.Implementations
{
    public class ProductDaoService(SiemensDbContext context, IMapper mapper, ILogger<ProductDaoService> daoLogger) : IDbService<ProductDTO, int>
    {
        private readonly SiemensDbContext context = context;
        private readonly IMapper mapper = mapper;
        private readonly ILogger<ProductDaoService> daoLogger = daoLogger;

        public async Task<ProductDTO?> Fetch(int pkeyValue)
        {
            try
            {
                var all = context.Products;
                if (all.Any(p => p.ProductId == pkeyValue))
                {
                    var p = all.Where(p => p.ProductId == pkeyValue).First();
                    return mapper.Map<ProductDTO>(p);
                }
                else
                    throw new Exception($"no product with id {pkeyValue} found");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<ProductDTO>> FetchAll()
        {
            try
            {
                DbSet<Product> all = context.Products;
                if (all.Any())
                {
                    List<DTOs.ProductDTO> products = [];
                    var list = await all.ToListAsync();
                    list.ForEach(
                    p =>
                    {
                        ProductDTO dto = mapper.Map<ProductDTO>(p);
                        products.Add(dto);
                    }
                    );
                    return products;
                }
                else
                    return [];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductDTO> Insert(ProductDTO data)
        {
            try
            {
                Product p = mapper.Map<Product>(data);
                var all = context.Products;
                EntityEntry<Product> tracker = await all.AddAsync(p);
                //entry.State == EntityState.Added;
                daoLogger.LogInformation(tracker.State.ToString());
                int result = await context.SaveChangesAsync();
                data.ProductId = tracker.Entity.ProductId;
                return result > 0 ? data : throw new Exception("product was not added...");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductDTO> Modify(int pkeyValue, ProductDTO data)
        {
            try
            {
                var all = context.Products;
                if (await all.AnyAsync(p => p.ProductId == pkeyValue))
                {
                    data.ProductId = pkeyValue;
                    var product = mapper.Map<Product>(data);
                    all.Update(product);
                    int result = await context.SaveChangesAsync();
                    return result > 0 ? data : throw new Exception("product update unsuccessful");
                }
                else
                    throw new Exception($"no product with id {pkeyValue} found to update..");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProductDTO> Remove(int pkeyValue)
        {
            try
            {
                var all = context.Products;
                var p = await all.FindAsync(pkeyValue);
                if (p != null)
                {
                    all.Remove(p);
                    int result = await context.SaveChangesAsync();
                    return result > 0 ? mapper.Map<ProductDTO>(p) : throw new Exception("product deletion unsuccessful");
                }
                else
                    throw new Exception($"no product with id {pkeyValue} found to delete..");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
