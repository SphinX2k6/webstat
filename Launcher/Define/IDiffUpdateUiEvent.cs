using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Launcher.Define
{
	// Token: 0x02004667 RID: 18023
	[NullableContext(2)]
	public interface IDiffUpdateUiEvent
	{
		// Token: 0x0602EFF5 RID: 192501
		UniTask WaitFrame(int? num = null);

		// Token: 0x0602EFF6 RID: 192502
		UniTask ShowInfo(bool bWithProgress, string textId, bool bUseTag = false);

		// Token: 0x0602EFF7 RID: 192503
		[NullableContext(1)]
		UniTask UpdateProgress(bool bNeedWait, float rate, string textId, params string[] args);

		// Token: 0x0602EFF8 RID: 192504
		[NullableContext(1)]
		UniTask UpdatePatchDownProgress(bool bNeedWait, float rate, string fileName, string speedText, string sizeCurrent, string sizeTotal);

		// Token: 0x0602EFF9 RID: 192505
		[NullableContext(1)]
		[return: Nullable(0)]
		UniTask<bool> ShowDialog(bool bSelect, string titleId, string contentId, [Nullable(2)] string leftId, [Nullable(2)] string rightId, [Nullable(2)] string middleId, params string[] contentArgs);

		// Token: 0x170080B7 RID: 32951
		// (get) Token: 0x0602EFFA RID: 192506
		// (set) Token: 0x0602EFFB RID: 192507
		bool? ShouldShowNoticeWindow { get; set; }

		// Token: 0x170080B8 RID: 32952
		// (get) Token: 0x0602EFFC RID: 192508
		// (set) Token: 0x0602EFFD RID: 192509
		Action<long, string> TryShowNoticeWindowOnce { get; set; }

		// Token: 0x0602EFFE RID: 192510
		bool IsCompatible();

		// Token: 0x0602EFFF RID: 192511
		[NullableContext(0)]
		UniTask<bool> ShowNotEnoughSpaceConfirmation(long totalSize);

		// Token: 0x0602F000 RID: 192512
		void UpdatePatchProgress(long receiveSize, long curProgress, long totalProgress, long downloadSpeed);
	}
}
