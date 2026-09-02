using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033BA RID: 13242
public class RedDotRoleSelectionList : RedDotBase
{
	// Token: 0x0601B8D1 RID: 112849 RVA: 0x0083B126 File Offset: 0x00839326
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RoleSelectionListUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B8D2 RID: 112850 RVA: 0x0083B144 File Offset: 0x00839344
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RoleSelectionListUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B8D3 RID: 112851 RVA: 0x0083B162 File Offset: 0x00839362
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<RoleModel>.Instance.RedDotRoleSelectionListCondition();
	}
}
