using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;

// Token: 0x0200334D RID: 13133
public class RedDotInventoryCard : RedDotBase
{
	// Token: 0x0601B6CE RID: 112334 RVA: 0x008372C0 File Offset: 0x008354C0
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRemoveItemRedDot, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnResponseCommonItemFinished, new Action(base.EventCheck));
	}

	// Token: 0x0601B6CF RID: 112335 RVA: 0x00837324 File Offset: 0x00835524
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRemoveItemRedDot, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnResponseCommonItemFinished, new Action(base.EventCheck));
	}

	// Token: 0x0601B6D0 RID: 112336 RVA: 0x00837388 File Offset: 0x00835588
	protected override bool OnCheck(int uId = 0)
	{
		global::ItemMainTypeMapping itemMainTypeMapping = ModelBase<InventoryModel>.Instance.GetItemMainTypeMapping(InventoryDefine.EItemMainTypeId.Card);
		return itemMainTypeMapping != null && itemMainTypeMapping.HasRedDot();
	}

	// Token: 0x0601B6D1 RID: 112337 RVA: 0x008373AC File Offset: 0x008355AC
	[NullableContext(1)]
	private void OnAddCommonItemList(IReadOnlyList<IProto_NormalItem> normalItemList)
	{
		base.EventCheck();
	}
}
