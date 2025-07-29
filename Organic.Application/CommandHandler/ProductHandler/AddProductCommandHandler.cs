using Mapster;
using MediatR;
using Organic.Application.Command.Product;
using Organic.Domain.Interface.ProductCategory;
using Organic.Domain.Interface.ProductImageInterface;
using Organic.Domain.Interface.ProductInterface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.CommandHandler.ProductHandler
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly ICrudProductRepository _crudProductRepository;

        private readonly IGetProductQueryRepository _getProductQueryRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly ICrudProductImageRepository _crudProductImageRepository;

        private readonly IGetProductCategoryRepository _getProductCategoryRepository;

        public AddProductCommandHandler(ICrudProductRepository crudProductRepository, IGetProductQueryRepository getProductQueryRepository, IUnitOfWork unitOfWork, ICrudProductImageRepository crudProductImageRepository, IGetProductCategoryRepository getProductCategoryRepository)
        {
            _crudProductRepository = crudProductRepository;

            _getProductQueryRepository = getProductQueryRepository;

            _unitOfWork = unitOfWork;

            _crudProductImageRepository = crudProductImageRepository;

            _getProductCategoryRepository = getProductCategoryRepository;
        }
        public async Task<Guid> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            var productCategory = await _getProductCategoryRepository.GetByIdAsync(command.CatrgoryId);

            if (productCategory == null)
                throw new ArgumentException("Category Not Found");

            var product = new ProductModel(command.Name, command.Price, command.Stock, command.Description, command.CatrgoryId);

            //await _unitOfWork.SaveChangeAsync();

            //var product = command.Adapt<ProductModel>();

            var directoryPath = Path.Combine("C:\\Users\\LENOVO\\Documents\\OrganicPicture");

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            await _crudProductRepository.Add(product);

            foreach (var file in command.ProductImages)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(directoryPath, fileName);
                    var imageUrl = "/images/products/" + fileName;

                    using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    await file.CopyToAsync(stream);

                    var image = new ProductImageModel(filePath, imageUrl, product.Id);
                    await _crudProductImageRepository.Add(image);
                }
            }

            try
            {
                var saveResult = await _unitOfWork.SaveChangeAsync();

                if (saveResult <= 0)
                    throw new Exception("هیچ داده‌ای ذخیره نشد!");

            }
            catch (Exception ex)
            {
                throw new Exception("خطا هنگام ذخیره داده‌ها در دیتابیس: " + ex.Message, ex);
            }

            return product.Id;

            // عمو باقر
            ///
        }

    }
}
