using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062E9 RID: 25321
	public class TetrisTipsLoseView : TetrisTipsBaseView
	{
		// Token: 0x0603FAAA RID: 260778 RVA: 0x01052A3E File Offset: 0x01050C3E
		[NullableContext(1)]
		public TetrisTipsLoseView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FAAB RID: 260779 RVA: 0x01052A48 File Offset: 0x01050C48
		protected override void OnClose()
		{
			base.OnClose();
			TetrisPlayView tetrisPlayView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.TetrisPlayView) as TetrisPlayView;
			if (tetrisPlayView != null)
			{
				tetrisPlayView.OpenLoseConfirm();
			}
		}
	}
}
