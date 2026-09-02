using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.LevelPickControl
{
	// Token: 0x02006B4E RID: 27470
	[NullableContext(1)]
	[Nullable(0)]
	public class MazeTipsWinView : UiViewBase
	{
		// Token: 0x06043DFC RID: 278012 RVA: 0x0118CA3A File Offset: 0x0118AC3A
		public MazeTipsWinView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06043DFD RID: 278013 RVA: 0x0118CA43 File Offset: 0x0118AC43
		protected override void OnStart()
		{
			this.UiViewSequence.AddSequenceFinishEvent(this.UiViewSequence.StartSequenceName, new Action<string>(this.OnStartSequenceEnd), false);
		}

		// Token: 0x06043DFE RID: 278014 RVA: 0x0118CA68 File Offset: 0x0118AC68
		private void OnStartSequenceEnd(string _)
		{
			this.UiViewSequence.RemoveSequenceFinishEvent(this.UiViewSequence.StartSequenceName, new Action<string>(this.OnStartSequenceEnd));
			base.CloseMe(null);
		}
	}
}
