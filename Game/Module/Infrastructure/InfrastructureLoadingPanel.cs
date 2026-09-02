using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C5B RID: 23643
	[NullableContext(1)]
	[Nullable(0)]
	public class InfrastructureLoadingPanel : UiPanelBase
	{
		// Token: 0x0603BBB7 RID: 244663 RVA: 0x00F22030 File Offset: 0x00F20230
		protected override void OnStart()
		{
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
			this.SeqPlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
			this.SeqPlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x0603BBB8 RID: 244664 RVA: 0x00F22084 File Offset: 0x00F20284
		public void CloseSelf()
		{
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer == null)
			{
				return;
			}
			seqPlayer.PlayLevelSequenceByName("Close", false, null, false);
		}

		// Token: 0x0603BBB9 RID: 244665 RVA: 0x00F220B1 File Offset: 0x00F202B1
		private void OnSequenceClose(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				ModelBase<InfrastructureModel>.Instance.DestroyLoadingPanel();
			}
		}

		// Token: 0x0402193B RID: 137531
		private LevelSequencePlayer SeqPlayer;
	}
}
