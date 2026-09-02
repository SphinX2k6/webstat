using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;

// Token: 0x02001C25 RID: 7205
public class FloroRanchStageSuccessState : FloroRanchStateBase
{
	// Token: 0x0600D171 RID: 53617 RVA: 0x0037951F File Offset: 0x0037771F
	[NullableContext(1)]
	public FloroRanchStageSuccessState(FloroRanchStageFsm stageFsm) : base(stageFsm)
	{
	}

	// Token: 0x0600D172 RID: 53618 RVA: 0x00379528 File Offset: 0x00377728
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
			if (response.SettleData.IsUnlimited)
			{
				ModelBase<FloroRanchGamePlayModel>.Instance.OpenAndRecordView(EUiViewName.FloroRanchDungeonEndlessSettleView, response, null);
				return;
			}
			ModelBase<FloroRanchGamePlayModel>.Instance.OpenAndRecordView(EUiViewName.FloroRanchDungeonSuccessSettleView, response, null);
		});
	}
}
