using Cysharp.Threading.Tasks;

namespace Laphed.PinkBunny.UI
{
    public interface IUiModeSwitch
    {
        UniTask Switch();
    }
}