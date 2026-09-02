using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062E6 RID: 25318
	public class TetrisTipsWinView : TetrisTipsBaseView
	{
		// Token: 0x0603FA9D RID: 260765 RVA: 0x01052825 File Offset: 0x01050A25
		[NullableContext(1)]
		public TetrisTipsWinView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FA9E RID: 260766 RVA: 0x0105282E File Offset: 0x01050A2E
		protected override void OnStart()
		{
			base.OnStart();
			this.OnWinCallback = (this.OpenParam as Action);
		}

		// Token: 0x0603FA9F RID: 260767 RVA: 0x01052847 File Offset: 0x01050A47
		protected override void OnClose()
		{
			base.CloseMe(delegate(bool _)
			{
				Action onWinCallback = this.OnWinCallback;
				if (onWinCallback == null)
				{
					return;
				}
				onWinCallback();
			});
		}

		// Token: 0x04023C00 RID: 146432
		[Nullable(2)]
		private Action OnWinCallback;
	}
}
