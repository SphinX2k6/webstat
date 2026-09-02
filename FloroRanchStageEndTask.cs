using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;

// Token: 0x02001C1A RID: 7194
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchStageEndTask : FloroRanchDailyTaskBase
{
	// Token: 0x0600D13A RID: 53562 RVA: 0x00378B06 File Offset: 0x00376D06
	public FloroRanchStageEndTask(FloroRanchStageEnd data)
	{
		this.StageEndData = data;
	}

	// Token: 0x0600D13B RID: 53563 RVA: 0x00378B18 File Offset: 0x00376D18
	protected override void OnExecute()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchPhaseSettleView, new FloroRanchPhaseSettleViewParam
		{
			StageEndData = this.StageEndData,
			CloseCallback = delegate(bool isSettle)
			{
				base.Complete(delegate
				{
					if (isSettle)
					{
						if (this.StageEndData.Win || this.StageEndData.IsUnlimitedMode)
						{
							ModelBase<FloroRanchGamePlayModel>.Instance.ChangeState(EFloroRanchStageStateType.StageSuccess);
							return;
						}
						ModelBase<FloroRanchGamePlayModel>.Instance.ChangeState(EFloroRanchStageStateType.StageFail);
					}
				});
			}
		}, null);
	}

	// Token: 0x040063EB RID: 25579
	private readonly FloroRanchStageEnd StageEndData;
}
