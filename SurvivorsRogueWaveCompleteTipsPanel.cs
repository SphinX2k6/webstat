using System;

// Token: 0x02001D8A RID: 7562
public class SurvivorsRogueWaveCompleteTipsPanel : SurvivorsRogueTipsPanelBase
{
	// Token: 0x0600DECB RID: 57035 RVA: 0x003BF060 File Offset: 0x003BD260
	protected override void OnStart()
	{
		this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		this.SequencePlayer.BindSequenceCloseEvent(delegate(string sequenceName)
		{
			if (sequenceName == "Start")
			{
				this.SequencePlayer.PlayOrReplaySequenceByName("Close", false, null);
				return;
			}
			if (sequenceName == "Close")
			{
				base.Hide(null);
				ControllerBase<SurvivorsRogueController>.Instance.RequestEnterStep(ESurvivorsStepType.End);
			}
		}, false);
	}
}
