using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062E5 RID: 25317
	public class TetrisTipsBaseView : UiViewBase
	{
		// Token: 0x0603FA9A RID: 260762 RVA: 0x0105280B File Offset: 0x01050A0B
		[NullableContext(1)]
		public TetrisTipsBaseView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FA9B RID: 260763 RVA: 0x01052814 File Offset: 0x01050A14
		protected override void OnFinishShow()
		{
			this.OnClose();
		}

		// Token: 0x0603FA9C RID: 260764 RVA: 0x0105281C File Offset: 0x01050A1C
		protected virtual void OnClose()
		{
			base.CloseMe(null);
		}
	}
}
