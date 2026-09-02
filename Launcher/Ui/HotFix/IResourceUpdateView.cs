using System;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x0200451A RID: 17690
	public interface IResourceUpdateView
	{
		// Token: 0x0602E9CB RID: 190923
		UniTask<bool> ShowNotEnoughSpaceConfirmation(long totalSize);

		// Token: 0x0602E9CC RID: 190924
		void UpdatePatchProgress(long receiveSize, long curProgress, long totalProgress, long downloadSpeed);
	}
}
