using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02003352 RID: 13138
public class RedDotInventoryPhantom : RedDotBase
{
	// Token: 0x0601B6E6 RID: 112358 RVA: 0x008377A4 File Offset: 0x008359A4
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<PhantomItem>, bool>(EEventName.OnAddPhantomItemList, new Action<IReadOnlyList<PhantomItem>, bool>(this.OnAddPhantomItemList));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRemoveItemRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B6E7 RID: 112359 RVA: 0x008377DE File Offset: 0x008359DE
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<PhantomItem>, bool>(EEventName.OnAddPhantomItemList, new Action<IReadOnlyList<PhantomItem>, bool>(this.OnAddPhantomItemList));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRemoveItemRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B6E8 RID: 112360 RVA: 0x00837818 File Offset: 0x00835A18
	protected override bool OnCheck(int uId = 0)
	{
		global::ItemMainTypeMapping itemMainTypeMapping = ModelBase<InventoryModel>.Instance.GetItemMainTypeMapping(InventoryDefine.EItemMainTypeId.Phantom);
		return itemMainTypeMapping != null && itemMainTypeMapping.HasRedDot();
	}

	// Token: 0x0601B6E9 RID: 112361 RVA: 0x0083783C File Offset: 0x00835A3C
	[NullableContext(1)]
	private void OnAddPhantomItemList(IReadOnlyList<PhantomItem> weaponItem, bool isCatch)
	{
		base.EventCheck();
	}
}
