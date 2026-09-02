using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.Ui.HotFix;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.DiffPatch.Update
{
	// Token: 0x0200462C RID: 17964
	[NullableContext(1)]
	[Nullable(0)]
	public class UpdateUiEvent : IDiffUpdateUiEvent
	{
		// Token: 0x0602EEDB RID: 192219 RVA: 0x00B1DF3E File Offset: 0x00B1C13E
		public UpdateUiEvent(HotFixManager uiMgr, string tag)
		{
			this.UiMgr = uiMgr;
			this.Tag = tag;
			this.TryShowNoticeWindowOnce = new Action<long, string>(this.OnTryShowNoticeWindowOnce);
		}

		// Token: 0x0602EEDC RID: 192220 RVA: 0x00B1DF68 File Offset: 0x00B1C168
		public UniTask WaitFrame(int? num = null)
		{
			UpdateUiEvent.<WaitFrame>d__3 <WaitFrame>d__;
			<WaitFrame>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitFrame>d__.<>4__this = this;
			<WaitFrame>d__.num = num;
			<WaitFrame>d__.<>1__state = -1;
			<WaitFrame>d__.<>t__builder.Start<UpdateUiEvent.<WaitFrame>d__3>(ref <WaitFrame>d__);
			return <WaitFrame>d__.<>t__builder.Task;
		}

		// Token: 0x0602EEDD RID: 192221 RVA: 0x00B1DFB4 File Offset: 0x00B1C1B4
		[NullableContext(2)]
		public UniTask ShowInfo(bool bWithProgress, string textId, bool bUseTag = false)
		{
			UpdateUiEvent.<ShowInfo>d__4 <ShowInfo>d__;
			<ShowInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowInfo>d__.<>4__this = this;
			<ShowInfo>d__.bWithProgress = bWithProgress;
			<ShowInfo>d__.textId = textId;
			<ShowInfo>d__.bUseTag = bUseTag;
			<ShowInfo>d__.<>1__state = -1;
			<ShowInfo>d__.<>t__builder.Start<UpdateUiEvent.<ShowInfo>d__4>(ref <ShowInfo>d__);
			return <ShowInfo>d__.<>t__builder.Task;
		}

		// Token: 0x0602EEDE RID: 192222 RVA: 0x00B1E010 File Offset: 0x00B1C210
		public UniTask UpdateProgress(bool bNeedWait, float rate, string textId, params string[] args)
		{
			UpdateUiEvent.<UpdateProgress>d__5 <UpdateProgress>d__;
			<UpdateProgress>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdateProgress>d__.<>4__this = this;
			<UpdateProgress>d__.bNeedWait = bNeedWait;
			<UpdateProgress>d__.rate = rate;
			<UpdateProgress>d__.textId = textId;
			<UpdateProgress>d__.args = args;
			<UpdateProgress>d__.<>1__state = -1;
			<UpdateProgress>d__.<>t__builder.Start<UpdateUiEvent.<UpdateProgress>d__5>(ref <UpdateProgress>d__);
			return <UpdateProgress>d__.<>t__builder.Task;
		}

		// Token: 0x0602EEDF RID: 192223 RVA: 0x00B1E074 File Offset: 0x00B1C274
		public UniTask UpdatePatchDownProgress(bool bNeedWait, float rate, string fileName, string speedText, string sizeCurrent, string sizeTotal)
		{
			UpdateUiEvent.<UpdatePatchDownProgress>d__6 <UpdatePatchDownProgress>d__;
			<UpdatePatchDownProgress>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<UpdatePatchDownProgress>d__.<>4__this = this;
			<UpdatePatchDownProgress>d__.bNeedWait = bNeedWait;
			<UpdatePatchDownProgress>d__.rate = rate;
			<UpdatePatchDownProgress>d__.fileName = fileName;
			<UpdatePatchDownProgress>d__.speedText = speedText;
			<UpdatePatchDownProgress>d__.sizeCurrent = sizeCurrent;
			<UpdatePatchDownProgress>d__.sizeTotal = sizeTotal;
			<UpdatePatchDownProgress>d__.<>1__state = -1;
			<UpdatePatchDownProgress>d__.<>t__builder.Start<UpdateUiEvent.<UpdatePatchDownProgress>d__6>(ref <UpdatePatchDownProgress>d__);
			return <UpdatePatchDownProgress>d__.<>t__builder.Task;
		}

		// Token: 0x0602EEE0 RID: 192224 RVA: 0x00B1E0EC File Offset: 0x00B1C2EC
		[return: Nullable(0)]
		public UniTask<bool> ShowDialog(bool bSelect, string titleId, string contentId, [Nullable(2)] string leftId, [Nullable(2)] string rightId, [Nullable(2)] string middleId, params string[] contentArgs)
		{
			UpdateUiEvent.<ShowDialog>d__7 <ShowDialog>d__;
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
			<ShowDialog>d__.<>t__builder.Start<UpdateUiEvent.<ShowDialog>d__7>(ref <ShowDialog>d__);
			return <ShowDialog>d__.<>t__builder.Task;
		}

		// Token: 0x1700809C RID: 32924
		// (get) Token: 0x0602EEE1 RID: 192225 RVA: 0x00B1E16B File Offset: 0x00B1C36B
		// (set) Token: 0x0602EEE2 RID: 192226 RVA: 0x00B1E173 File Offset: 0x00B1C373
		public bool? ShouldShowNoticeWindow { get; set; }

		// Token: 0x1700809D RID: 32925
		// (get) Token: 0x0602EEE3 RID: 192227 RVA: 0x00B1E17C File Offset: 0x00B1C37C
		// (set) Token: 0x0602EEE4 RID: 192228 RVA: 0x00B1E184 File Offset: 0x00B1C384
		[Nullable(2)]
		public Action<long, string> TryShowNoticeWindowOnce { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x0602EEE5 RID: 192229 RVA: 0x00B1E190 File Offset: 0x00B1C390
		[NullableContext(2)]
		private void OnTryShowNoticeWindowOnce(long downloadSize, string logMsg = null)
		{
			double num = (double)downloadSize / 1048576.0;
			int num2 = 500;
			if (num < (double)num2)
			{
				return;
			}
			this.UiMgr.ShowNoticeWindow(logMsg);
		}

		// Token: 0x0602EEE6 RID: 192230 RVA: 0x00B1E1C0 File Offset: 0x00B1C3C0
		public bool IsCompatible()
		{
			return false;
		}

		// Token: 0x0602EEE7 RID: 192231 RVA: 0x00B1E1C4 File Offset: 0x00B1C3C4
		[NullableContext(0)]
		public UniTask<bool> ShowNotEnoughSpaceConfirmation(long totalSize)
		{
			UpdateUiEvent.<ShowNotEnoughSpaceConfirmation>d__18 <ShowNotEnoughSpaceConfirmation>d__;
			<ShowNotEnoughSpaceConfirmation>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ShowNotEnoughSpaceConfirmation>d__.<>1__state = -1;
			<ShowNotEnoughSpaceConfirmation>d__.<>t__builder.Start<UpdateUiEvent.<ShowNotEnoughSpaceConfirmation>d__18>(ref <ShowNotEnoughSpaceConfirmation>d__);
			return <ShowNotEnoughSpaceConfirmation>d__.<>t__builder.Task;
		}

		// Token: 0x0602EEE8 RID: 192232 RVA: 0x00B1E1FF File Offset: 0x00B1C3FF
		public void UpdatePatchProgress(long receiveSize, long curProgress, long totalProgress, long downloadSpeed)
		{
		}

		// Token: 0x0401AB41 RID: 109377
		private readonly HotFixManager UiMgr;

		// Token: 0x0401AB42 RID: 109378
		private readonly string Tag;
	}
}
