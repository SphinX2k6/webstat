using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033F1 RID: 13297
public class RedDotWeaponResonanceTab : RedDotBase
{
	// Token: 0x0601B9D2 RID: 113106 RVA: 0x0083D5F4 File Offset: 0x0083B7F4
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B9D3 RID: 113107 RVA: 0x0083D5F7 File Offset: 0x0083B7F7
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.WeaponResonanceSuccess, new Action<int, int>(this.OnWeaponResonanceSuccess));
	}

	// Token: 0x0601B9D4 RID: 113108 RVA: 0x0083D631 File Offset: 0x0083B831
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.WeaponResonanceSuccess, new Action<int, int>(this.OnWeaponResonanceSuccess));
	}

	// Token: 0x0601B9D5 RID: 113109 RVA: 0x0083D66B File Offset: 0x0083B86B
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<WeaponModel>.Instance.RedDotWeaponResonanceCondition(uId);
	}

	// Token: 0x0601B9D6 RID: 113110 RVA: 0x0083D678 File Offset: 0x0083B878
	private void OnWeaponResonanceSuccess(int roleId, int weaponId)
	{
		base.EventCheckWithUid(roleId);
	}
}
