using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x020033D7 RID: 13271
public class TowerDefenseRewardRedDot : RedDotBase
{
	// Token: 0x0601B969 RID: 113001 RVA: 0x0083CBDA File Offset: 0x0083ADDA
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, new Action<IActivityRewardViewData>(this.OnRefreshCommonActivityRewardPopUpView));
	}

	// Token: 0x0601B96A RID: 113002 RVA: 0x0083CBF8 File Offset: 0x0083ADF8
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, new Action<IActivityRewardViewData>(this.OnRefreshCommonActivityRewardPopUpView));
	}

	// Token: 0x0601B96B RID: 113003 RVA: 0x0083CC16 File Offset: 0x0083AE16
	protected override bool OnCheck(int uId = 0)
	{
		return ControllerBase<TowerDefenseController>.Instance.CheckHasReward();
	}

	// Token: 0x0601B96C RID: 113004 RVA: 0x0083CC22 File Offset: 0x0083AE22
	[NullableContext(1)]
	private void OnRefreshCommonActivityRewardPopUpView(IActivityRewardViewData data)
	{
		base.EventCheck();
	}
}
