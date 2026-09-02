using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x020025CD RID: 9677
public class FightPhotoTabPanelBase : UiPanelBase
{
	// Token: 0x06012EAF RID: 77487 RVA: 0x0053BF07 File Offset: 0x0053A107
	public void PlaySwitchAnim()
	{
		this.PlaySequence("Switch");
	}

	// Token: 0x06012EB0 RID: 77488 RVA: 0x0053BF14 File Offset: 0x0053A114
	[NullableContext(1)]
	protected void PlaySequence(string sequenceName)
	{
		if (this.SequencePlayer == null)
		{
			this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		}
		this.SequencePlayer.StopCurrentSequence(false, true);
		this.SequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
	}

	// Token: 0x06012EB1 RID: 77489 RVA: 0x0053BF5E File Offset: 0x0053A15E
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.Clear();
		}
		this.SequencePlayer = null;
	}

	// Token: 0x040093C1 RID: 37825
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;
}
