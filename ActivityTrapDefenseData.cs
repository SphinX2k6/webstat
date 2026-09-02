using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.TrapDefense;

// Token: 0x020015E3 RID: 5603
public class ActivityTrapDefenseData : ActivityBaseData
{
	// Token: 0x06009DB7 RID: 40375 RVA: 0x00294568 File Offset: 0x00292768
	public override bool GetExDataRedPointShowState()
	{
		RedDotBase redDot = ModelBase<RedDotModel>.Instance.GetRedDot(ERedDotName.TrapDefense);
		return (redDot != null && redDot.IsRedDotActive()) || ModelBase<TrapDefenseModel>.Instance.RougeModeData.IsShowRougeModeTipsToActivity();
	}

	// Token: 0x06009DB8 RID: 40376 RVA: 0x002945A4 File Offset: 0x002927A4
	[NullableContext(1)]
	protected override void PhraseEx(ActivityData data)
	{
		TrapDefenseActivityInfo trapDefenseActivityInfo = data.TrapDefenseActivityInfo;
		if (trapDefenseActivityInfo == null)
		{
			return;
		}
		TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
		if (instance != null)
		{
			instance.InitData(new int?(base.Id));
		}
		TrapDefenseModel instance2 = ModelBase<TrapDefenseModel>.Instance;
		if (instance2 != null)
		{
			instance2.UpdateActivityData(trapDefenseActivityInfo);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateTrapDefenseRougeModeOpen);
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateTrapDefenseLevelModeLevelReachOpenTime);
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateTrapDefenseRougeModeLevelReachOpenTime);
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateTrapDefenseBdBuffNewUnlock);
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateTrapDefenseTalentTree);
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateTrapDefenseLimitReward);
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateTrapDefenseFixedReward);
		ControllerBase<TrapDefenseController>.Instance.IsActivityInited = true;
		TrapDefenseChallengeResultNotify resultNotifyCache = ControllerBase<TrapDefenseController>.Instance.ResultNotifyCache;
		if (resultNotifyCache != null)
		{
			ControllerBase<TrapDefenseController>.Instance.OpenDefenseChallengeResultView(resultNotifyCache, true);
			ControllerBase<TrapDefenseController>.Instance.ResultNotifyCache = null;
		}
	}

	// Token: 0x06009DB9 RID: 40377 RVA: 0x00294688 File Offset: 0x00292888
	protected override bool GetExDataFinishShowState()
	{
		return ModelBase<TrapDefenseModel>.Instance.RewardData.IsFixedRewardAllClaimed();
	}
}
