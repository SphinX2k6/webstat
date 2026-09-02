using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.PreDownload
{
	// Token: 0x02004540 RID: 17728
	[NullableContext(2)]
	[Nullable(0)]
	public class PreDownloadUiEvent : IDiffUpdateUiEvent
	{
		// Token: 0x0602EA85 RID: 191109 RVA: 0x00B0EA9B File Offset: 0x00B0CC9B
		[NullableContext(1)]
		public void SetView(IPreDownloadUiEvent uiView)
		{
			this.UiView = uiView;
		}

		// Token: 0x0602EA86 RID: 191110 RVA: 0x00B0EAA4 File Offset: 0x00B0CCA4
		public void ClearView()
		{
			this.UiView = null;
		}

		// Token: 0x0602EA87 RID: 191111 RVA: 0x00B0EAAD File Offset: 0x00B0CCAD
		public UniTask WaitFrame(int? num = null)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0602EA88 RID: 191112 RVA: 0x00B0EAB4 File Offset: 0x00B0CCB4
		public UniTask ShowInfo(bool bWithProgress, string textId, bool bUseTag = false)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0602EA89 RID: 191113 RVA: 0x00B0EABC File Offset: 0x00B0CCBC
		[NullableContext(1)]
		public UniTask UpdateProgress(bool bNeedWait, float rate, string textId, params string[] args)
		{
			PreDownloadUiEvent.<UpdateProgress>d__5 <UpdateProgress>d__;
			<UpdateProgress>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateProgress>d__.<>4__this = this;
			<UpdateProgress>d__.bNeedWait = bNeedWait;
			<UpdateProgress>d__.rate = rate;
			<UpdateProgress>d__.textId = textId;
			<UpdateProgress>d__.args = args;
			<UpdateProgress>d__.<>1__state = -1;
			<UpdateProgress>d__.<>t__builder.Start<PreDownloadUiEvent.<UpdateProgress>d__5>(ref <UpdateProgress>d__);
			return <UpdateProgress>d__.<>t__builder.Task;
		}

		// Token: 0x0602EA8A RID: 191114 RVA: 0x00B0EB20 File Offset: 0x00B0CD20
		[NullableContext(1)]
		public UniTask UpdatePatchDownProgress(bool bNeedWait, float rate, string fileName, string speedText, string sizeCurrent, string sizeTotal)
		{
			PreDownloadUiEvent.<UpdatePatchDownProgress>d__6 <UpdatePatchDownProgress>d__;
			<UpdatePatchDownProgress>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdatePatchDownProgress>d__.<>4__this = this;
			<UpdatePatchDownProgress>d__.bNeedWait = bNeedWait;
			<UpdatePatchDownProgress>d__.rate = rate;
			<UpdatePatchDownProgress>d__.speedText = speedText;
			<UpdatePatchDownProgress>d__.sizeCurrent = sizeCurrent;
			<UpdatePatchDownProgress>d__.sizeTotal = sizeTotal;
			<UpdatePatchDownProgress>d__.<>1__state = -1;
			<UpdatePatchDownProgress>d__.<>t__builder.Start<PreDownloadUiEvent.<UpdatePatchDownProgress>d__6>(ref <UpdatePatchDownProgress>d__);
			return <UpdatePatchDownProgress>d__.<>t__builder.Task;
		}

		// Token: 0x0602EA8B RID: 191115 RVA: 0x00B0EB90 File Offset: 0x00B0CD90
		[NullableContext(1)]
		[return: Nullable(0)]
		public UniTask<bool> ShowDialog(bool bSelect, string titleId, string contentId, [Nullable(2)] string leftId, [Nullable(2)] string rightId, [Nullable(2)] string middleId, params string[] contentArgs)
		{
			PreDownloadUiEvent.<ShowDialog>d__7 <ShowDialog>d__;
			<ShowDialog>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ShowDialog>d__.<>4__this = this;
			<ShowDialog>d__.bSelect = bSelect;
			<ShowDialog>d__.titleId = titleId;
			<ShowDialog>d__.contentId = contentId;
			<ShowDialog>d__.leftId = leftId;
			<ShowDialog>d__.rightId = rightId;
			<ShowDialog>d__.middleId = middleId;
			<ShowDialog>d__.contentArgs = contentArgs;
			<ShowDialog>d__.<>1__state = -1;
			<ShowDialog>d__.<>t__builder.Start<PreDownloadUiEvent.<ShowDialog>d__7>(ref <ShowDialog>d__);
			return <ShowDialog>d__.<>t__builder.Task;
		}

		// Token: 0x17008057 RID: 32855
		// (get) Token: 0x0602EA8C RID: 191116 RVA: 0x00B0EC0F File Offset: 0x00B0CE0F
		// (set) Token: 0x0602EA8D RID: 191117 RVA: 0x00B0EC17 File Offset: 0x00B0CE17
		public bool? ShouldShowNoticeWindow { get; set; }

		// Token: 0x17008058 RID: 32856
		// (get) Token: 0x0602EA8E RID: 191118 RVA: 0x00B0EC20 File Offset: 0x00B0CE20
		// (set) Token: 0x0602EA8F RID: 191119 RVA: 0x00B0EC28 File Offset: 0x00B0CE28
		public Action<long, string> TryShowNoticeWindowOnce { get; set; }

		// Token: 0x0602EA90 RID: 191120 RVA: 0x00B0EC31 File Offset: 0x00B0CE31
		public bool IsCompatible()
		{
			return false;
		}

		// Token: 0x0602EA91 RID: 191121 RVA: 0x00B0EC34 File Offset: 0x00B0CE34
		[NullableContext(0)]
		public UniTask<bool> ShowNotEnoughSpaceConfirmation(long totalSize)
		{
			return UniTask.FromResult<bool>(true);
		}

		// Token: 0x0602EA92 RID: 191122 RVA: 0x00B0EC3C File Offset: 0x00B0CE3C
		public void UpdatePatchProgress(long receiveSize, long curProgress, long totalProgress, long downloadSpeed)
		{
		}

		// Token: 0x0401A80F RID: 108559
		private IPreDownloadUiEvent UiView;
	}
}
