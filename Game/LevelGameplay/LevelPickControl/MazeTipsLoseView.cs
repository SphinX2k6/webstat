using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.LevelPickControl
{
	// Token: 0x02006B4D RID: 27469
	[NullableContext(1)]
	[Nullable(0)]
	public class MazeTipsLoseView : UiViewBase
	{
		// Token: 0x06043DF9 RID: 278009 RVA: 0x0118C9E1 File Offset: 0x0118ABE1
		public MazeTipsLoseView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06043DFA RID: 278010 RVA: 0x0118C9EA File Offset: 0x0118ABEA
		protected override void OnStart()
		{
			this.UiViewSequence.AddSequenceFinishEvent(this.UiViewSequence.StartSequenceName, new Action<string>(this.OnStartSequenceEnd), false);
		}

		// Token: 0x06043DFB RID: 278011 RVA: 0x0118CA0F File Offset: 0x0118AC0F
		private void OnStartSequenceEnd(string _)
		{
			this.UiViewSequence.RemoveSequenceFinishEvent(this.UiViewSequence.StartSequenceName, new Action<string>(this.OnStartSequenceEnd));
			base.CloseMe(null);
		}
	}
}
