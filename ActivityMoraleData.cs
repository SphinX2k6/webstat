using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02001420 RID: 5152
[NullableContext(1)]
[Nullable(0)]
public class ActivityMoraleData : ActivityBaseData
{
	// Token: 0x06008ED9 RID: 36569 RVA: 0x002581A4 File Offset: 0x002563A4
	protected override bool GetExDataFinishShowState()
	{
		MoraleModel instance = ModelBase<MoraleModel>.Instance;
		return instance.IsAllScoreBoxRewardReceived() && instance.IsAllAreaFlagRewardReceived();
	}

	// Token: 0x06008EDA RID: 36570 RVA: 0x002581CC File Offset: 0x002563CC
	public override bool GetExDataRedPointShowState()
	{
		MoraleModel instance = ModelBase<MoraleModel>.Instance;
		return instance.RedDotScoreBox() || instance.RedDotAreaBuff() || instance.RedDotFlagBox();
	}

	// Token: 0x06008EDB RID: 36571 RVA: 0x002581F9 File Offset: 0x002563F9
	public override ERedDotName? GetExternalButtonRedPointName()
	{
		return new ERedDotName?(ERedDotName.Morale);
	}

	// Token: 0x06008EDC RID: 36572 RVA: 0x00258208 File Offset: 0x00256408
	protected override void PhraseEx(ActivityData data)
	{
		MoraleActivityData moraleActivityData = data.MoraleActivityData;
		if (moraleActivityData == null)
		{
			return;
		}
		ModelBase<MoraleModel>.Instance.InitActivityData(moraleActivityData);
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateMoraleScoreBox);
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateMoraleFlagBox);
	}

	// Token: 0x06008EDD RID: 36573 RVA: 0x0025824B File Offset: 0x0025644B
	public ActivityMoraleController GetController()
	{
		return (ActivityMoraleController)ActivityManager.GetActivityController(base.Type);
	}
}
