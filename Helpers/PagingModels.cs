
namespace XTL.Helper;

public class PagingModels
{
    public int currentPage {get; set;}
    public int countPage {get; set;}
    // Giúp phát sinh ra địa chỉ url khi ta bấm vào trang đó
    public Func<int?, string> generateUrl {get; set;}
}