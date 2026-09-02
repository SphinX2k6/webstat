using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Launcher.PreDownload
{
	// Token: 0x0200453F RID: 17727
	[NullableContext(1)]
	public interface IPreDownloadUiEvent
	{
		// Token: 0x0602EA82 RID: 191106
		UniTask UpdatePatchDownProgress(bool bNeedWait, float rate, string fileName, string speedText, string sizeCurrent, string sizeTotal);

		// Token: 0x0602EA83 RID: 191107
		UniTask BinPatchProgress(bool bNeedWait, float rate, string textId, params string[] args);

		// Token: 0x0602EA84 RID: 191108
		[return: Nullable(0)]
		UniTask<bool> ShowDialog(bool bSelect, string title, string content, [Nullable(2)] string leftBtn, [Nullable(2)] string rightBtn, [Nullable(2)] string middleBtn, params string[] contentArgs);
	}
}
