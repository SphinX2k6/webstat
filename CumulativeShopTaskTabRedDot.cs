using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003319 RID: 13081
public class CumulativeShopTaskTabRedDot : RedDotBase
{
	// Token: 0x0601B5ED RID: 112109 RVA: 0x00835718 File Offset: 0x00833918
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.CumulativeShopTaskRefresh, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B5EE RID: 112110 RVA: 0x00835736 File Offset: 0x00833936
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.CumulativeShopTaskRefresh, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B5EF RID: 112111 RVA: 0x00835754 File Offset: 0x00833954
	protected override bool OnCheck(int uId = 0)
	{
		CumulativeShopData cumulativeShopData = ControllerBase<CumulativeShopController>.Instance.GetCumulativeShopData();
		return cumulativeShopData != null && cumulativeShopData.GetTaskTabRedDot(uId);
	}
}
