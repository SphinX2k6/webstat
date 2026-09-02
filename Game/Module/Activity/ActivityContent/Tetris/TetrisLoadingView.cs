using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062D0 RID: 25296
	public class TetrisLoadingView : UiViewBase
	{
		// Token: 0x0603FA1B RID: 260635 RVA: 0x0104F44C File Offset: 0x0104D64C
		[NullableContext(1)]
		public TetrisLoadingView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FA1C RID: 260636 RVA: 0x0104F455 File Offset: 0x0104D655
		protected override void OnAfterShow()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TetrisPlayView, this.ChallengeId, delegate(bool value, int viewId)
			{
				base.CloseMe(null);
			});
		}

		// Token: 0x0603FA1D RID: 260637 RVA: 0x0104F47D File Offset: 0x0104D67D
		protected override void OnStart()
		{
			this.ChallengeId = (this.OpenParam as int?);
		}

		// Token: 0x0603FA1E RID: 260638 RVA: 0x0104F498 File Offset: 0x0104D698
		protected override void OnBeforeDestroy()
		{
			TetrisPlayView tetrisPlayView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.TetrisPlayView) as TetrisPlayView;
			if (tetrisPlayView != null)
			{
				tetrisPlayView.RefreshEndlessLoading();
			}
		}

		// Token: 0x04023B8A RID: 146314
		private int? ChallengeId;
	}
}
