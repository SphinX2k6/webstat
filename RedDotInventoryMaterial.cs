using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02003350 RID: 13136
public class RedDotInventoryMaterial : RedDotBase
{
	// Token: 0x0601B6DC RID: 112348 RVA: 0x008375AC File Offset: 0x008357AC
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRemoveItemRedDot, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnResponseCommonItemFinished, new Action(base.EventCheck));
	}

	// Token: 0x0601B6DD RID: 112349 RVA: 0x00837610 File Offset: 0x00835810
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRemoveItemRedDot, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnResponseCommonItemFinished, new Action(base.EventCheck));
	}

	// Token: 0x0601B6DE RID: 112350 RVA: 0x00837674 File Offset: 0x00835874
	protected override bool OnCheck(int uId = 0)
	{
		global::ItemMainTypeMapping itemMainTypeMapping = ModelBase<InventoryModel>.Instance.GetItemMainTypeMapping(InventoryDefine.EItemMainTypeId.Material);
		return itemMainTypeMapping != null && itemMainTypeMapping.HasRedDot();
	}

	// Token: 0x0601B6DF RID: 112351 RVA: 0x00837698 File Offset: 0x00835898
	[NullableContext(1)]
	private void OnAddCommonItemList(IReadOnlyList<IProto_NormalItem> normalItemList)
	{
		base.EventCheck();
	}
}
