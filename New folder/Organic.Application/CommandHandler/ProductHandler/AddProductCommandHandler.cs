using MediatR;
using Organic.Application.Command.Product;
using Organic.Domain.Interface;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Model.Product;
using System.Security.Claims;


namespace Organic.Application.CommandHandler.ProductHandler
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
    {

        private readonly IGenricCommandRepository<ProductImageModel> _productImageRepository;

        private readonly IGenricCommandRepository<ProductModel> _productRepository;

        private readonly IGenricQueryRepository<ProductCategoryModel> _getProductRepository;

        private readonly IUnitOfWork _unitOfWork;

        public AddProductCommandHandler(IGenricCommandRepository<ProductImageModel> productImageRepository, IGenricCommandRepository<ProductModel> productRepository, IGenricQueryRepository<ProductCategoryModel> getProductRepository, IUnitOfWork unitOfWork)
        {
            _productImageRepository = productImageRepository;
            _productRepository = productRepository;
            _getProductRepository = getProductRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            {
                var productCategory = await _getProductRepository.GetByIdAsync(command.CatrgoryId);

                if (productCategory == null)
                    throw new ArgumentException("Category Not Found");

                var product = new ProductModel(command.Name, command.Price, command.Stock, command.Description, command.CatrgoryId);

                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "products");

                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                await _productRepository.Add(product);

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
                        await _productImageRepository.Add(image);
                    }
                }
                try
                {
                    var saveResult = await _unitOfWork.SaveChangeAsync();
                    //if (saveResult <= 0)
                    //    throw new Exception("هیچ داده‌ای ذخیره نشد!");
                }
                catch (Exception ex)
                {
                    throw new Exception("خطا هنگام ذخیره داده‌ها در دیتابیس: " + ex.Message, ex);
                }
                return product.Id;
            }
        }
    }
}
