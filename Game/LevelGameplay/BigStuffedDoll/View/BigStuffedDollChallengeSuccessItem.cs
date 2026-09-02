using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll.View
{
	// Token: 0x02006F60 RID: 28512
	public class BigStuffedDollChallengeSuccessItem : UiPanelBase
	{
		// Token: 0x06045036 RID: 282678 RVA: 0x011F7260 File Offset: 0x011F5460
		protected override void OnStart()
		{
			base.OnStart();
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
		}

		// Token: 0x06045037 RID: 282679 RVA: 0x011F7291 File Offset: 0x011F5491
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
		}

		// Token: 0x06045038 RID: 282680 RVA: 0x011F72AC File Offset: 0x011F54AC
		public void ShowTip()
		{
			base.ShowAsync();
			this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x06045039 RID: 282681 RVA: 0x011F72DC File Offset: 0x011F54DC
		[NullableContext(1)]
		private void OnSequenceClose(string sequenceName)
		{
			if (sequenceName == "Start")
			{
				this.LevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
				return;
			}
			if (sequenceName == "Close")
			{
				base.HideAsync();
				ModelBase<BigStuffedDollModel>.Instance.EnterNextGameStage();
			}
		}

		// Token: 0x040267DF RID: 157663
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;
	}
}
