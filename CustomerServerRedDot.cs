using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033C7 RID: 13255
public class CustomerServerRedDot : RedDotBase
{
	// Token: 0x0601B915 RID: 112917 RVA: 0x0083BE09 File Offset: 0x0083A009
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.SdkCustomerRedPointRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B916 RID: 112918 RVA: 0x0083BE27 File Offset: 0x0083A027
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.SdkCustomerRedPointRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B917 RID: 112919 RVA: 0x0083BE45 File Offset: 0x0083A045
	protected override bool OnCheck(int uId = 0)
	{
		return ControllerBase<KuroSdkController>.Instance.GetCustomerServiceRedPointState();
	}
}
