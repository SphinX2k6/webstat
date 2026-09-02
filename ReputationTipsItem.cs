using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001FF0 RID: 8176
internal class ReputationTipsItem : UiPanelBase
{
	// Token: 0x0600F6D1 RID: 63185 RVA: 0x00439335 File Offset: 0x00437535
	[NullableContext(1)]
	public ReputationTipsItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600F6D2 RID: 63186 RVA: 0x0043934C File Offset: 0x0043754C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F6D3 RID: 63187 RVA: 0x004393B8 File Offset: 0x004375B8
	public void UpdateItem(int itemId, int max)
	{
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemId, 0);
		float fillAmount = (float)itemCountByConfigId / (float)max;
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "ReputationValue", new <>z__ReadOnlyArray<object>(new object[]
		{
			itemCountByConfigId,
			max
		}));
		base.GetSprite(1).SetFillAmount(fillAmount);
	}

	// Token: 0x0200836E RID: 33646
	private enum EReputationTipsItem
	{
		// Token: 0x0402C943 RID: 182595
		Value,
		// Token: 0x0402C944 RID: 182596
		Sprite
	}
}
