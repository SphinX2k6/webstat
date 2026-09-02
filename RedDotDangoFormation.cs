using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200331C RID: 13084
public class RedDotDangoFormation : RedDotBase
{
	// Token: 0x0601B5FB RID: 112123 RVA: 0x00835949 File Offset: 0x00833B49
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B5FC RID: 112124 RVA: 0x0083594C File Offset: 0x00833B4C
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshAbyssDangoRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B5FD RID: 112125 RVA: 0x0083596A File Offset: 0x00833B6A
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshAbyssDangoRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B5FE RID: 112126 RVA: 0x00835988 File Offset: 0x00833B88
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<DangoAbyssModel>.Instance.GetDangoFormationNewRedDot();
	}
}
