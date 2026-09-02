using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;

// Token: 0x02001C22 RID: 7202
public class FloroRanchStageFailState : FloroRanchStateBase
{
	// Token: 0x0600D16B RID: 53611 RVA: 0x00379375 File Offset: 0x00377575
	[NullableContext(1)]
	public FloroRanchStageFailState(FloroRanchStageFsm stageFsm) : base(stageFsm)
	{
	}

	// Token: 0x0600D16C RID: 53612 RVA: 0x00379380 File Offset: 0x00377580
	protected override void OnEnter()
	{
		FloroRanchGamePlayModel instance = ModelBase<FloroRanchGamePlayModel>.Instance;
		int activityId = instance.ActivityId;
		int subInstanceId = instance.SubInstanceId;
		ControllerBase<FloroRanchController>.Instance.SendFloroRanchSettleDataRequest(activityId, subInstanceId, delegate(FloroRanchSettleDataResponse response)
		{
			if (response == null || !response.ShowMvp)
			{
				ModelBase<FloroRanchGamePlayModel>.Instance.ExitGame(true);
				return;
			}
			ModelBase<FloroRanchGamePlayModel>.Instance.OpenAndRecordView(EUiViewName.FloroRanchDungeonFailSettleView, response, null);
		});
	}
}
