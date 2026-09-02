using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001F0B RID: 7947
public class HonamiStoryDragItemFrameItem : UiPanelBase
{
	// Token: 0x0600ED33 RID: 60723 RVA: 0x0040AC7C File Offset: 0x00408E7C
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600ED34 RID: 60724 RVA: 0x0040AC90 File Offset: 0x00408E90
	protected override void OnBeforeShow()
	{
		if (!this.LevelSequencePlayer.IsPlayingSequence("Loop"))
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Loop", false, null, false);
		}
	}

	// Token: 0x040071EE RID: 29166
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;
}
