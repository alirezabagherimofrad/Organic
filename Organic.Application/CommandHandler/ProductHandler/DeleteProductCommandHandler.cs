using MediatR;
using Organic.Application.Command.Product;
using Organic.Domain.Interface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.CommandHandler.ProductHandler
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IGenricQueryRepository<ProductModel> _genricQueryRepository;

        private readonly IGenricCommandRepository<ProductModel> _genricCommandRepository;

        private readonly IGenricCommandRepository<ProductImageModel> genricCommandRepository1;

        private readonly IGenricQueryRepository<ProductImageModel> genricQueryRepository1;

        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IGenricQueryRepository<ProductModel> genricQueryRepository, IGenricCommandRepository<ProductModel> genricCommandRepository, IGenricCommandRepository<ProductImageModel> genricCommandRepository1, IGenricQueryRepository<ProductImageModel> genricQueryRepository1, IUnitOfWork unitOfWork)
        {
            _genricQueryRepository = genricQueryRepository;
            _genricCommandRepository = genricCommandRepository;
            this.genricCommandRepository1 = genricCommandRepository1;
            this.genricQueryRepository1 = genricQueryRepository1;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _genricQueryRepository.GetByIdAsync(command.ProductId);

            if (product == null)
                throw new Exception("Product Not Found");

            var result = await _genricCommandRepository.Delete(product);

            var productImage = await genricQueryRepository1.GetByIdAsync(command.ProductImageId);

            if (productImage == null)
                throw new Exception("ProductImage Not Found");

            var result2 =await genricCommandRepository1.Delete(productImage);

            await _unitOfWork.SaveChangeAsync();

            return result;
        }
    }
}
