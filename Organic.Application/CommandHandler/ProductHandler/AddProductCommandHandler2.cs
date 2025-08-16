using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Interface;
using Organic.Domain.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organic.Application.Interface;
using Organic.Domain.Model.User;
using MediatR;
using Organic.Application.Command.Product;
using Mapster;

namespace Organic.Application.CommandHandler.ProductHandler
{
    public class AddProductCommandHandler2 : IRequestHandler<AddProductCommand2, Guid>
    {
        private readonly IGenricCommandRepository<ProductImageModel> _productImageRepository;

        private readonly IGenricCommandRepository<ProductModel> _productRepository;

        private readonly IGenricQueryRepository<ProductCategoryModel> _getProductRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IFileStorageService _fileStorageService;

        private readonly IGenricCommandRepository<miniomodel> _minioRepository;

        public AddProductCommandHandler2(IGenricCommandRepository<ProductImageModel> productImageRepository, IGenricCommandRepository<ProductModel> productRepository, IGenricQueryRepository<ProductCategoryModel> getProductRepository, IUnitOfWork unitOfWork, IFileStorageService fileStorageService, IGenricCommandRepository<miniomodel> minioRepository)
        {
            _productImageRepository = productImageRepository;

            _productRepository = productRepository;

            _getProductRepository = getProductRepository;

            _unitOfWork = unitOfWork;

            _fileStorageService = fileStorageService;

            _minioRepository = minioRepository;
        }

        public async Task<Guid> Handle(AddProductCommand2 command, CancellationToken cancellationToken)
        {
            var productCategory = await _getProductRepository.GetByIdAsync(command.CatrgoryId);

            if (productCategory == null)
                throw new Exception("Product Category Not Found");

            var product = new ProductModel(command.Name, command.Price, command.Stock, command.Description, command.CatrgoryId);

            await _productRepository.Add(product);

            foreach (var file in command.ProductImages)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    using var stream = file.OpenReadStream();

                    var fileUrl = await _fileStorageService.UploadFileAsync(stream, fileName);

                    var image = new ProductImageModel(fileName, fileUrl, product.Id);

                    var minio = new miniomodel(fileUrl);

                    await _minioRepository.Add(minio);
                }
            }

            await _unitOfWork.SaveChangeAsync();

            return product.Id;
        }
    }
}
