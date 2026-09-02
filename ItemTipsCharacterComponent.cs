using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x0200199C RID: 6556
public class ItemTipsCharacterComponent : TipsBaseSubComponent
{
	// Token: 0x0600BC45 RID: 48197 RVA: 0x0031F828 File Offset: 0x0031DA28
	[NullableContext(1)]
	public ItemTipsCharacterComponent(UUIItem rootUiItem) : base(rootUiItem)
	{
		base.CreateThenShowByResourceIdAsync("UiItem_TipsRole", rootUiItem, false);
	}

	// Token: 0x0600BC46 RID: 48198 RVA: 0x0031F840 File Offset: 0x0031DA40
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BC47 RID: 48199 RVA: 0x0031F8EB File Offset: 0x0031DAEB
	protected override void OnStart()
	{
		base.GetItem(3).SetUIActive(false);
	}

	// Token: 0x0600BC48 RID: 48200 RVA: 0x0031F8FA File Offset: 0x0031DAFA
	protected override void OnBeforeDestroy()
	{
		if (this.Data != null)
		{
			this.Data = null;
			ModelBase<ItemTipsModel>.Instance.SetCurrentItemTipsData(null);
		}
	}

	// Token: 0x0600BC49 RID: 48201 RVA: 0x0031F918 File Offset: 0x0031DB18
	[NullableContext(1)]
	public override void Refresh(ItemTipsData data)
	{
		TipsCharacterData tipsCharacterData = (TipsCharacterData)data;
		Action action = delegate()
		{
			this.Data = tipsCharacterData;
			ModelBase<ItemTipsModel>.Instance.SetCurrentItemTipsData(tipsCharacterData);
			ElementInfo elementConfig = tipsCharacterData.GetElementConfig();
			UUITexture texture = this.GetTexture(1);
			this.SetElementIcon(elementConfig.Icon, texture, elementConfig.Id, null);
			texture.SetColor(FColor.FromHex(elementConfig.ElementColor));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.GetText(0), elementConfig.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.GetText(2), tipsCharacterData.GetRoleIntroduction(), Array.Empty<object>());
		};
		if (base.InAsyncLoading())
		{
			this.OperationMap["Refresh"] = action;
			return;
		}
		action();
	}

	// Token: 0x0400591F RID: 22815
	[Nullable(2)]
	private TipsCharacterData Data;

	// Token: 0x02007C9E RID: 31902
	private class EChildType
	{
		// Token: 0x0402A8CF RID: 174287
		public const int ElementText = 0;

		// Token: 0x0402A8D0 RID: 174288
		public const int ElementTexture = 1;

		// Token: 0x0402A8D1 RID: 174289
		public const int BackgroundText = 2;

		// Token: 0x0402A8D2 RID: 174290
		public const int GetWayItem = 3;
	}
}
