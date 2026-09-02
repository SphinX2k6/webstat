using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033C5 RID: 13253
public class RedDotHuluSkinTab : RedDotBase
{
	// Token: 0x0601B90C RID: 112908 RVA: 0x0083BD56 File Offset: 0x00839F56
	protected override bool IsMultiple()
	{
		return false;
	}

	// Token: 0x0601B90D RID: 112909 RVA: 0x0083BD59 File Offset: 0x00839F59
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.HuluSkinRedDotRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B90E RID: 112910 RVA: 0x0083BD77 File Offset: 0x00839F77
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.HuluSkinRedDotRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B90F RID: 112911 RVA: 0x0083BD95 File Offset: 0x00839F95
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<CalabashSkinModel>.Instance.CheckCalabashSkinHasRedDot();
	}
}
