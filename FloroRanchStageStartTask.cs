using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001C1C RID: 7196
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchStageStartTask : FloroRanchDailyTaskBase
{
	// Token: 0x0600D13D RID: 53565 RVA: 0x00378B97 File Offset: 0x00376D97
	public FloroRanchStageStartTask(FloroRanchStageStart data)
	{
		this.StageStartData = data;
	}

	// Token: 0x0600D13E RID: 53566 RVA: 0x00378BA8 File Offset: 0x00376DA8
	protected override void OnExecute()
	{
		ModelBase<FloroRanchGamePlayModel>.Instance.OnStageStart(this.StageStartData);
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnFloroRanchStageStartTaskBeforeFinish, false);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FloroRanchPhaseTargetView, new FloroRanchPhaseTargetViewParam
		{
			StageStartData = this.StageStartData,
			CloseCallback = delegate()
			{
				FloroRanchStageStartTask.<<OnExecute>b__2_0>d <<OnExecute>b__2_0>d;
				<<OnExecute>b__2_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<OnExecute>b__2_0>d.<>4__this = this;
				<<OnExecute>b__2_0>d.<>1__state = -1;
				<<OnExecute>b__2_0>d.<>t__builder.Start<FloroRanchStageStartTask.<<OnExecute>b__2_0>d>(ref <<OnExecute>b__2_0>d);
				return <<OnExecute>b__2_0>d.<>t__builder.Task;
			}
		}, null);
	}

	// Token: 0x040063EE RID: 25582
	private readonly FloroRanchStageStart StageStartData;
}
