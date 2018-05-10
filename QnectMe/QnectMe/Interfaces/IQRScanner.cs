using System.Threading.Tasks;

namespace QnectMe.Interfaces
{
    public interface IQRScanner
    {
        Task<string> ScanAsync();
    }
}
