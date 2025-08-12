//using Organic.Domain.Interface.ProductInterface;
//using Organic.Domain.Model.Product;
//using Organic.Infrastructure.Context;
//using Organic.Infrastructure.Repositories.GenericRepository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Organic.Infrastructure.Repositories.ProductRepository
//{
//    public class GetProductQueryRepository : GenricQueryRepository<ProductModel>, IGetProductQueryRepository
//    {
//        private readonly DataBaseContext _context;
//        public GetProductQueryRepository(DataBaseContext dataBaseContext) : base(dataBaseContext)
//        {
//            _context = dataBaseContext;
//        }

//        public async Task<ProductModel?> GetBYID(Guid Id)
//        {
//        throw new NotImplementedException();
//        } 
//    }
//}
