using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02003339 RID: 13113
[NullableContext(1)]
[Nullable(0)]
public class RedDotFunctionInventory : RedDotBase
{
	// Token: 0x0601B67A RID: 112250 RVA: 0x00836614 File Offset: 0x00834814
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<WeaponItem>, bool, bool>(EEventName.OnAddWeaponItemList, new Action<IReadOnlyList<WeaponItem>, bool, bool>(this.OnAddWeaponItemList));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<PhantomItem>, bool>(EEventName.OnAddPhantomItemList, new Action<IReadOnlyList<PhantomItem>, bool>(this.OnAddPhantomItemList));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRemoveItemRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B67B RID: 112251 RVA: 0x00836694 File Offset: 0x00834894
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddWeaponItemList, new Action<IReadOnlyList<WeaponItem>, bool, bool>(this.OnAddWeaponItemList));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddPhantomItemList, new Action<IReadOnlyList<PhantomItem>, bool>(this.OnAddPhantomItemList));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRemoveItemRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B67C RID: 112252 RVA: 0x00836711 File Offset: 0x00834911
	private void OnAddCommonItemList(IReadOnlyList<IProto_NormalItem> normalItemList)
	{
		base.EventCheck();
	}

	// Token: 0x0601B67D RID: 112253 RVA: 0x00836719 File Offset: 0x00834919
	private void OnAddWeaponItemList(IReadOnlyList<WeaponItem> weaponItem, bool bAddFromRole, bool bShowNewTips)
	{
		base.EventCheck();
	}

	// Token: 0x0601B67E RID: 112254 RVA: 0x00836721 File Offset: 0x00834921
	private void OnAddPhantomItemList(IReadOnlyList<PhantomItem> phantomItemList, bool isCatch)
	{
		base.EventCheck();
	}

	// Token: 0x0601B67F RID: 112255 RVA: 0x00836729 File Offset: 0x00834929
	protected override bool OnCheck(int id)
	{
		return ModelBase<InventoryModel>.Instance.HasRedDot();
	}
}
