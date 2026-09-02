using System;
using CSharpScript.Launcher.Ui.HotFix;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002673 RID: 9843
public class QuestResourceUpdateProxy : IResourceUpdateView
{
	// Token: 0x0601365D RID: 79453 RVA: 0x00568708 File Offset: 0x00566908
	public UniTask<bool> ShowNotEnoughSpaceConfirmation(long totalSize)
	{
		QuestResourceUpdateProxy.<ShowNotEnoughSpaceConfirmation>d__0 <ShowNotEnoughSpaceConfirmation>d__;
		<ShowNotEnoughSpaceConfirmation>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<ShowNotEnoughSpaceConfirmation>d__.totalSize = totalSize;
		<ShowNotEnoughSpaceConfirmation>d__.<>1__state = -1;
		<ShowNotEnoughSpaceConfirmation>d__.<>t__builder.Start<QuestResourceUpdateProxy.<ShowNotEnoughSpaceConfirmation>d__0>(ref <ShowNotEnoughSpaceConfirmation>d__);
		return <ShowNotEnoughSpaceConfirmation>d__.<>t__builder.Task;
	}

	// Token: 0x0601365E RID: 79454 RVA: 0x0056874B File Offset: 0x0056694B
	public void UpdatePatchProgress(long receiveSize, long curProgress, long totalProgress, long downloadSpeed)
	{
	}
}
