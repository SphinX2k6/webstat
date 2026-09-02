using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.AdvanceNotice
{
	// Token: 0x020069E9 RID: 27113
	public class AdvanceNoticeItemView : UiPanelBase
	{
		// Token: 0x0604331B RID: 275227 RVA: 0x011446B4 File Offset: 0x011428B4
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}

		// Token: 0x0604331C RID: 275228 RVA: 0x011446C8 File Offset: 0x011428C8
		protected override void OnAfterShow()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
		}

		// Token: 0x0604331D RID: 275229 RVA: 0x011446F4 File Offset: 0x011428F4
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.Clear();
		}

		// Token: 0x04025717 RID: 153367
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;
	}
}
