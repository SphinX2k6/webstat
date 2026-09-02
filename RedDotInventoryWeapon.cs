using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02003355 RID: 13141
public class RedDotInventoryWeapon : RedDotBase
{
	// Token: 0x0601B6F5 RID: 112373 RVA: 0x00837A44 File Offset: 0x00835C44
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<WeaponItem, bool, bool>(EEventName.OnAddWeaponItem, new Action<WeaponItem, bool, bool>(this.OnAddWeaponItem));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRemoveItemRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B6F6 RID: 112374 RVA: 0x00837A7E File Offset: 0x00835C7E
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<WeaponItem, bool, bool>(EEventName.OnAddWeaponItem, new Action<WeaponItem, bool, bool>(this.OnAddWeaponItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRemoveItemRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B6F7 RID: 112375 RVA: 0x00837AB8 File Offset: 0x00835CB8
	protected override bool OnCheck(int uId = 0)
	{
		global::ItemMainTypeMapping itemMainTypeMapping = ModelBase<InventoryModel>.Instance.GetItemMainTypeMapping(InventoryDefine.EItemMainTypeId.Weapon);
		return itemMainTypeMapping != null && itemMainTypeMapping.HasRedDot();
	}

	// Token: 0x0601B6F8 RID: 112376 RVA: 0x00837ADC File Offset: 0x00835CDC
	[NullableContext(1)]
	private void OnAddWeaponItem(WeaponItem weaponItem, bool bAddFromRole, bool bShowNewTips)
	{
		base.EventCheck();
	}
}
