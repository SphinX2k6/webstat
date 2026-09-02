using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Launcher.Update
{
	// Token: 0x020044C1 RID: 17601
	[NullableContext(2)]
	[Nullable(0)]
	public class LanguageUpdateUiEvent : IDiffUpdateUiEvent
	{
		// Token: 0x17008031 RID: 32817
		// (get) Token: 0x0602E745 RID: 190277 RVA: 0x00AFF340 File Offset: 0x00AFD540
		// (set) Token: 0x0602E746 RID: 190278 RVA: 0x00AFF348 File Offset: 0x00AFD548
		public Action<long, string> TryShowNoticeWindowOnce { get; set; }

		// Token: 0x0602E747 RID: 190279 RVA: 0x00AFF351 File Offset: 0x00AFD551
		public bool IsCompatible()
		{
			return true;
		}

		// Token: 0x0602E748 RID: 190280 RVA: 0x00AFF354 File Offset: 0x00AFD554
		[NullableContext(0)]
		public UniTask<bool> ShowNotEnoughSpaceConfirmation(long totalSize)
		{
			LanguageUpdateUiEvent.<ShowNotEnoughSpaceConfirmation>d__6 <ShowNotEnoughSpaceConfirmation>d__;
			<ShowNotEnoughSpaceConfirmation>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ShowNotEnoughSpaceConfirmation>d__.<>4__this = this;
			<ShowNotEnoughSpaceConfirmation>d__.totalSize = totalSize;
			<ShowNotEnoughSpaceConfirmation>d__.<>1__state = -1;
			<ShowNotEnoughSpaceConfirmation>d__.<>t__builder.Start<LanguageUpdateUiEvent.<ShowNotEnoughSpaceConfirmation>d__6>(ref <ShowNotEnoughSpaceConfirmation>d__);
			return <ShowNotEnoughSpaceConfirmation>d__.<>t__builder.Task;
		}

		// Token: 0x0602E749 RID: 190281 RVA: 0x00AFF39F File Offset: 0x00AFD59F
		public void UpdatePatchProgress(long receiveSize, long curProgress, long totalProgress, long downloadSpeed)
		{
			LanguageUpdateViewAgent uiAgent = this.UiAgent;
			if (uiAgent == null)
			{
				return;
			}
			uiAgent.UpdatePatchProgress(receiveSize, curProgress, totalProgress, downloadSpeed);
		}

		// Token: 0x0602E74A RID: 190282 RVA: 0x00AFF3B6 File Offset: 0x00AFD5B6
		[NullableContext(1)]
		public void InitEvent(LanguageUpdateViewAgent uiAgent)
		{
			this.UiAgent = uiAgent;
		}

		// Token: 0x0602E74B RID: 190283 RVA: 0x00AFF3BF File Offset: 0x00AFD5BF
		public UniTask WaitFrame(int? num = null)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0602E74C RID: 190284 RVA: 0x00AFF3C6 File Offset: 0x00AFD5C6
		public UniTask ShowInfo(bool bWithProgress, string textId, bool bUseTag = false)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0602E74D RID: 190285 RVA: 0x00AFF3CD File Offset: 0x00AFD5CD
		[NullableContext(1)]
		public UniTask UpdateProgress(bool bNeedWait, float rate, string textId, params string[] args)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0602E74E RID: 190286 RVA: 0x00AFF3D4 File Offset: 0x00AFD5D4
		[NullableContext(1)]
		public UniTask UpdatePatchDownProgress(bool bNeedWait, float rate, string fileName, string speedText, string sizeCurrent, string sizeTotal)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0602E74F RID: 190287 RVA: 0x00AFF3DB File Offset: 0x00AFD5DB
		[NullableContext(1)]
		[return: Nullable(0)]
		public UniTask<bool> ShowDialog(bool bSelect, string titleId, string contentId, [Nullable(2)] string leftId, [Nullable(2)] string rightId, [Nullable(2)] string middleId, params string[] contentArgs)
		{
			throw new Exception("语言下载不实现，弹对话框。需要弹对话框，即失败！");
		}

		// Token: 0x17008032 RID: 32818
		// (get) Token: 0x0602E750 RID: 190288 RVA: 0x00AFF3E7 File Offset: 0x00AFD5E7
		// (set) Token: 0x0602E751 RID: 190289 RVA: 0x00AFF3EF File Offset: 0x00AFD5EF
		public bool? ShouldShowNoticeWindow { get; set; }

		// Token: 0x0401A60B RID: 108043
		private LanguageUpdateViewAgent UiAgent;
	}
}
