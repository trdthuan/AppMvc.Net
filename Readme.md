## Controler
- Là một lớp kế thừa từ lớp Controller: Microsoft.AspNetCore.Mvc.Controller
- Action trong controller là một phương thức public (không được static)
- Action trả về bất kỳ kiểu dữ liệu nào, thường là IActionResult
- Các dịch vụ Inject vào controller qua hàm tạo
## View
- Là File .cshtml
- View cho Action lưu tại: /View/ControllerName/ActionName.cshtml
- Thêm thư mục lưu trữ View
```
// {0} -> Ten Action
// {1} -> Ten Controller
// {2} -> Ten Area
option.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);        
```
## Truyền dữ liệu sang View
- Model
- ViewData
- ViewBag
- TempData
## Areas
- Là tên dùng để routing
- là cấu trúc thư mục chứa MVC
- thiết lập Area cho controller bằng ```[Area(AreaName)]```
- Tạo cấu trúc thư mục
```
dotnet aspnet-codegenerator area Product
```