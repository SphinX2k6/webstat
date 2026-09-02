using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001D20 RID: 7456
public class KurotatoEliteWaveTipsPanel : UiPanelBase
{
	// Token: 0x0600DB1B RID: 56091 RVA: 0x003AD813 File Offset: 0x003ABA13
	protected override void OnStart()
	{
		this.SeqPlayer = new LevelSequencePlayer(base.GetRootItem());
	}

	// Token: 0x0600DB1C RID: 56092 RVA: 0x003AD828 File Offset: 0x003ABA28
	public void PlayEliteWave()
	{
		base.SetUiActive(true);
		this.SeqPlayer.PlayOrReplaySequenceByName("Start", false, null);
	}

	// Token: 0x040068A5 RID: 26789
	[Nullable(1)]
	private LevelSequencePlayer SeqPlayer;
}
