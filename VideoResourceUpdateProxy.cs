using System;
using CSharpScript.Launcher.Ui.HotFix;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x0200276A RID: 10090
public class VideoResourceUpdateProxy : IResourceUpdateView
{
	// Token: 0x06013E98 RID: 81560 RVA: 0x0058C578 File Offset: 0x0058A778
	public UniTask<bool> ShowNotEnoughSpaceConfirmation(long totalSize)
	{
		VideoResourceUpdateProxy.<ShowNotEnoughSpaceConfirmation>d__0 <ShowNotEnoughSpaceConfirmation>d__;
		<ShowNotEnoughSpaceConfirmation>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<ShowNotEnoughSpaceConfirmation>d__.totalSize = totalSize;
		<ShowNotEnoughSpaceConfirmation>d__.<>1__state = -1;
		<ShowNotEnoughSpaceConfirmation>d__.<>t__builder.Start<VideoResourceUpdateProxy.<ShowNotEnoughSpaceConfirmation>d__0>(ref <ShowNotEnoughSpaceConfirmation>d__);
		return <ShowNotEnoughSpaceConfirmation>d__.<>t__builder.Task;
	}

	// Token: 0x06013E99 RID: 81561 RVA: 0x0058C5BB File Offset: 0x0058A7BB
	public void UpdatePatchProgress(long receiveSize, long curProgress, long totalProgress, long downloadSpeed)
	{
	}
}
