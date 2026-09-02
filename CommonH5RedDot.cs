using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.CommonH5;

// Token: 0x02003318 RID: 13080
public class CommonH5RedDot : RedDotBase
{
	// Token: 0x0601B5E9 RID: 112105 RVA: 0x008356C8 File Offset: 0x008338C8
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshCommonH5ActivityRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B5EA RID: 112106 RVA: 0x008356E6 File Offset: 0x008338E6
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonH5ActivityRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B5EB RID: 112107 RVA: 0x00835704 File Offset: 0x00833904
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<CommonH5Model>.Instance.GetRedDotState();
	}
}
