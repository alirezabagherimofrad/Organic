using MediatR;
using Organic.Application.Command.Product;
using Organic.Domain.Interface.UnitOfWorkInterface;
using Organic.Domain.Model.Product;


namespace Organic.Application.CommandHandler.ProductHandler
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
    {

        private readonly IUnitOfWork _unitOfWork;


        public AddProductCommandHandler(IUnitOfWork unitOfWork)
        {


            _unitOfWork = unitOfWork;


        }
        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            {
                var productCategory = await _unitOfWork.QueryRepository<ProductCategoryModel>().GetByIdAsync(request.CatrgoryId);

                if (productCategory == null)
                    throw new ArgumentException("Category Not Found");

                var product = new ProductModel(request.Name, request.Price, request.Stock, request.Description, request.CatrgoryId);

                //await _unitOfWork.SaveChangeAsync();

                //var product = command.Adapt<ProductModel>();

                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "products");

                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);


                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                await _unitOfWork.CommandRepository<ProductModel>().Add(product);

                foreach (var file in request.ProductImages)
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
}
