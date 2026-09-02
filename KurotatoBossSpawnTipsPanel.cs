using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001D1C RID: 7452
public class KurotatoBossSpawnTipsPanel : UiPanelBase
{
	// Token: 0x0600DAF7 RID: 56055 RVA: 0x003ACCD5 File Offset: 0x003AAED5
	protected override void OnStart()
	{
		this.SeqPlayer = new LevelSequencePlayer(base.GetRootItem());
	}

	// Token: 0x0600DAF8 RID: 56056 RVA: 0x003ACCE8 File Offset: 0x003AAEE8
	public void PlayBossSpawn()
	{
		base.SetUiActive(true);
		this.SeqPlayer.PlayOrReplaySequenceByName("Start", false, null);
	}

	// Token: 0x0400687E RID: 26750
	[Nullable(1)]
	private LevelSequencePlayer SeqPlayer;
}
