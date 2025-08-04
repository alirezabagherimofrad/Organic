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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IGenricCommandRepository<ProductImageModel> _productImageRepository;

        private readonly IGenricQueryRepository<ProductImageModel> _getProductImageRepository;

        private readonly IGenricCommandRepository<ProductModel> _productRepository;

        private readonly IGenricQueryRepository<ProductModel> _getProductRepository;

        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IGenricCommandRepository<ProductImageModel> productImageRepository, IGenricQueryRepository<ProductImageModel> getProductImageRepository, IGenricCommandRepository<ProductModel> productRepository, IGenricQueryRepository<ProductModel> getProductRepository, IUnitOfWork unitOfWork)
        {
            _productImageRepository = productImageRepository;
            _getProductImageRepository = getProductImageRepository;
            _productRepository = productRepository;
            _getProductRepository = getProductRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _getProductRepository.GetByIdAsync(command.ProductId);

            if (product == null)
                throw new Exception("Product Not Found");

            product.Update(command.Name, command.Price, command.Description, command.Stock);

            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "products");

            var existingImages = await _getProductImageRepository.GetAllAsync(p => p.ProductId == command.ProductId);

            if (command.DeletedImageIds is not null && command.DeletedImageIds.Any())
            {
                var imagesToDelete = await _getProductImageRepository.GetAllAsync(p => command.DeletedImageIds.Contains(p.Id));

                foreach (var img in imagesToDelete)
                {
                    if (File.Exists(img.FilePath))
                        File.Delete(img.FilePath);

                    await _productImageRepository.Delete(img);
                }
            }

            foreach (var file in command.ProductImages)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    var filePath = Path.Combine(directoryPath, fileName);

                    var imageUrl = $"/images/products/{fileName}";

                    using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

                    await file.CopyToAsync(stream);

                    var image = new ProductImageModel(filePath, imageUrl, product.Id);

                    await _unitOfWork.CommandRepository<ProductImageModel>().Add(image);
                }
            }

            await _unitOfWork.SaveChangeAsync();

            return true;
        }
    }
}
