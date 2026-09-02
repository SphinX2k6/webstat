using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Updater
{
	// Token: 0x020044DE RID: 17630
	[NullableContext(2)]
	[Nullable(0)]
	public class ResourceDiffUpdateUiEvent : IDiffUpdateUiEvent
	{
		// Token: 0x1700803C RID: 32828
		// (get) Token: 0x0602E7EB RID: 190443 RVA: 0x00B02CC0 File Offset: 0x00B00EC0
		// (set) Token: 0x0602E7EC RID: 190444 RVA: 0x00B02CC8 File Offset: 0x00B00EC8
		public Action<long, string> TryShowNoticeWindowOnce { get; set; }

		// Token: 0x0602E7ED RID: 190445 RVA: 0x00B02CD1 File Offset: 0x00B00ED1
		public bool IsCompatible()
		{
			return true;
		}

		// Token: 0x0602E7EE RID: 190446 RVA: 0x00B02CD4 File Offset: 0x00B00ED4
		[NullableContext(0)]
		public UniTask<bool> ShowNotEnoughSpaceConfirmation(long totalSize)
		{
			ResourceDiffUpdateUiEvent.<ShowNotEnoughSpaceConfirmation>d__6 <ShowNotEnoughSpaceConfirmation>d__;
			<ShowNotEnoughSpaceConfirmation>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ShowNotEnoughSpaceConfirmation>d__.<>4__this = this;
			<ShowNotEnoughSpaceConfirmation>d__.totalSize = totalSize;
			<ShowNotEnoughSpaceConfirmation>d__.<>1__state = -1;
			<ShowNotEnoughSpaceConfirmation>d__.<>t__builder.Start<ResourceDiffUpdateUiEvent.<ShowNotEnoughSpaceConfirmation>d__6>(ref <ShowNotEnoughSpaceConfirmation>d__);
			return <ShowNotEnoughSpaceConfirmation>d__.<>t__builder.Task;
		}

		// Token: 0x0602E7EF RID: 190447 RVA: 0x00B02D1F File Offset: 0x00B00F1F
		public void UpdatePatchProgress(long receiveSize, long curProgress, long totalProgress, long downloadSpeed)
		{
			ResourceUpdateViewAgent uiAgent = this.UiAgent;
			if (uiAgent == null)
			{
				return;
			}
			uiAgent.UpdatePatchProgress(receiveSize, curProgress, totalProgress, downloadSpeed);
		}

		// Token: 0x0602E7F0 RID: 190448 RVA: 0x00B02D36 File Offset: 0x00B00F36
		[NullableContext(1)]
		public void InitEvent(ResourceUpdateViewAgent uiAgent)
		{
			this.UiAgent = uiAgent;
		}

		// Token: 0x0602E7F1 RID: 190449 RVA: 0x00B02D3F File Offset: 0x00B00F3F
		public UniTask WaitFrame(int? num = null)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0602E7F2 RID: 190450 RVA: 0x00B02D46 File Offset: 0x00B00F46
		public UniTask ShowInfo(bool bWithProgress, string textId, bool bUseTag = false)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0602E7F3 RID: 190451 RVA: 0x00B02D4D File Offset: 0x00B00F4D
		[NullableContext(1)]
		public UniTask UpdateProgress(bool bNeedWait, float rate, string textId, params string[] args)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0602E7F4 RID: 190452 RVA: 0x00B02D54 File Offset: 0x00B00F54
		[NullableContext(1)]
		public UniTask UpdatePatchDownProgress(bool bNeedWait, float rate, string fileName, string speedText, string sizeCurrent, string sizeTotal)
		{
			if (this.UiAgent != null)
			{
				this.UiAgent.FileName = fileName;
			}
			return UniTask.CompletedTask;
		}

		// Token: 0x0602E7F5 RID: 190453 RVA: 0x00B02D6F File Offset: 0x00B00F6F
		[NullableContext(1)]
		[return: Nullable(0)]
		public virtual UniTask<bool> ShowDialog(bool bSelect, string titleId, string contentId, [Nullable(2)] string leftId, [Nullable(2)] string rightId, [Nullable(2)] string middleId, params string[] contentArgs)
		{
			return UniTask.FromResult<bool>(true);
		}

		// Token: 0x1700803D RID: 32829
		// (get) Token: 0x0602E7F6 RID: 190454 RVA: 0x00B02D77 File Offset: 0x00B00F77
		// (set) Token: 0x0602E7F7 RID: 190455 RVA: 0x00B02D7F File Offset: 0x00B00F7F
		public bool? ShouldShowNoticeWindow { get; set; }

		// Token: 0x0401A6B9 RID: 108217
		private ResourceUpdateViewAgent UiAgent;
	}
}
