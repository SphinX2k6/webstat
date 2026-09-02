using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001C21 RID: 7201
public class FloroRanchGameStartState : FloroRanchStateBase
{
	// Token: 0x0600D168 RID: 53608 RVA: 0x00379327 File Offset: 0x00377527
	[NullableContext(1)]
	public FloroRanchGameStartState(FloroRanchStageFsm stageFsm) : base(stageFsm)
	{
	}

	// Token: 0x0600D169 RID: 53609 RVA: 0x00379330 File Offset: 0x00377530
	protected override void OnEnter()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchGamePlayView, null, delegate(bool _, int _)
		{
			if (ModelBase<FloroRanchGamePlayModel>.Instance.IsOver)
			{
				this.StageFsm.ChangeState(EFloroRanchStageStateType.StageSuccess);
				return;
			}
			this.StageFsm.ChangeState(EFloroRanchStageStateType.DailyInStage);
		});
	}
}
