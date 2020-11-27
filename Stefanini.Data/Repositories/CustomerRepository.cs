using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Stefanini.Data.Context;
using Stefanini.Data.Repositories.Base;
using Stefanini.Domain.Dto.Request.Filter;
using Stefanini.Domain.Dto.Response;
using Stefanini.Domain.Entities;
using Stefanini.Domain.Interfaces.Repository;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Stefanini.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly IMapper mapper;
        public CustomerRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
            this.mapper = mapper;
        }

        public async Task<IQueryable<CustomerResponseModel>> Filter(CustomerFilter filter)
        {
            var query = from customer in DbSet
                        join city in Context.Set<City>() on customer.CityId equals city.Id into cityNullable
                        from city in cityNullable
                        join region in Context.Set<Region>() on customer.RegionId equals region.Id into regionNullable
                        from region in regionNullable
                        join classification in Context.Set<Classification>() on customer.ClassificationId equals classification.Id into classificationNullable
                        from classification in classificationNullable
                        join gender in Context.Set<Gender>() on customer.GenderId equals gender.Id into genderNullable
                        from gender in genderNullable
                        join user in Context.Set<User>() on customer.UserId equals user.Id into userNullable
                        from user in userNullable
                        where (!filter.CityId.HasValue || city.Id.Equals(filter.CityId.Value)) &&
                        (!filter.ClassificationId.HasValue || classification.Id.Equals(filter.ClassificationId.Value)) &&
                        (!filter.GenderId.HasValue || gender.Id.Equals(filter.GenderId.Value)) &&
                        (!filter.LastPurchaseInitial.HasValue || customer.LastPurchase >= filter.LastPurchaseInitial.Value) &&
                        (!filter.LastPurchaseFinal.HasValue || customer.LastPurchase <= filter.LastPurchaseFinal.Value) &&
                        (string.IsNullOrEmpty(filter.Name) || customer.Name.Contains(filter.Name)) &&
                        (!filter.RegionId.HasValue || region.Id.Equals(filter.RegionId.Value)) &&
                        (!filter.SellerId.HasValue || user.Id.Equals(filter.SellerId))
                        select new CustomerResponseModel
                        {
                            Id = customer.Id,
                            Classification = classification.Name,
                            Name = customer.Name,
                            Gender = gender.Name,
                            City = city.Name,
                            Region = region.Name,
                            LastPurchase = customer.LastPurchase,
                            Seller = user.Login
                        };
                
                return await Task.FromResult(query);
        }
    }

   
}
