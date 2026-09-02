using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02003354 RID: 13140
public class RedDotInventoryVirtual : RedDotBase
{
	// Token: 0x0601B6F0 RID: 112368 RVA: 0x00837948 File Offset: 0x00835B48
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRemoveItemRedDot, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnResponseCommonItemFinished, new Action(base.EventCheck));
	}

	// Token: 0x0601B6F1 RID: 112369 RVA: 0x008379AC File Offset: 0x00835BAC
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRemoveItemRedDot, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnResponseCommonItemFinished, new Action(base.EventCheck));
	}

	// Token: 0x0601B6F2 RID: 112370 RVA: 0x00837A10 File Offset: 0x00835C10
	protected override bool OnCheck(int uId = 0)
	{
		global::ItemMainTypeMapping itemMainTypeMapping = ModelBase<InventoryModel>.Instance.GetItemMainTypeMapping(InventoryDefine.EItemMainTypeId.Virtual);
		return itemMainTypeMapping != null && itemMainTypeMapping.HasRedDot();
	}

	// Token: 0x0601B6F3 RID: 112371 RVA: 0x00837A34 File Offset: 0x00835C34
	[NullableContext(1)]
	private void OnAddCommonItemList(IReadOnlyList<IProto_NormalItem> normalItemList)
	{
		base.EventCheck();
	}
}
