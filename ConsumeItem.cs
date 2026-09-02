using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020018C1 RID: 6337
[NullableContext(2)]
[Nullable(0)]
public class ConsumeItem : GridProxyAbstract<TCommonMultipleConsumeData>
{
	// Token: 0x0600B61A RID: 46618 RVA: 0x003069B5 File Offset: 0x00304BB5
	public ConsumeItem(UUIItem uiItem = null, EUiViewName? belongView = null)
	{
		this.BelongView = belongView;
		if (uiItem != null)
		{
			this.CreateThenShowByActor(uiItem.GetOwner());
		}
	}

	// Token: 0x0600B61B RID: 46619 RVA: 0x003069D4 File Offset: 0x00304BD4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.ButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B61C RID: 46620 RVA: 0x00306B88 File Offset: 0x00304D88
	private void ButtonClick()
	{
		if (this.ButtonFunction != null)
		{
			TConsumeItemFunction buttonFunction = this.ButtonFunction;
			ConsumeItemData data = this.Data;
			int? incId = (data != null) ? new int?(data.IncId) : null;
			ConsumeItemData data2 = this.Data;
			buttonFunction(incId, (data2 != null) ? new int?(data2.ItemId) : null);
		}
	}

	// Token: 0x0600B61D RID: 46621 RVA: 0x00306BE8 File Offset: 0x00304DE8
	protected void SetIconState()
	{
		InventoryDefine.GetItemData getItemData = new InventoryDefine.GetItemData(this.Data.ItemId, this.Data.IncId);
		ItemDataBase itemDataBase = ModelBase<InventoryModel>.Instance.GetItemDataBase(getItemData)[0];
		UUITexture texture = base.GetTexture(4);
		base.SetItemIcon(texture, itemDataBase.GetConfigId(), this.BelongView, null);
		UUISprite sprite = base.GetSprite(5);
		base.SetItemQualityIcon(sprite, itemDataBase.GetConfigId(), this.BelongView, CommonDefine.EQualityIconType.BackgroundSprite, null);
		UUIText text = base.GetText(6);
		UUIItem item = base.GetItem(7);
		if (this.Data.ResonanceLevel != 0)
		{
			item.SetUIActive(true);
			text.SetText(this.Data.ResonanceLevel.ToString(), true);
		}
		else
		{
			item.SetUIActive(false);
		}
		UUISprite sprite2 = base.GetSprite(3);
		if (!string.IsNullOrEmpty(this.Data.ChipPath))
		{
			sprite2.SetUIActive(true);
			this.SetSpriteByPath(this.Data.ChipPath, sprite2, false, null, null);
			return;
		}
		sprite2.SetUIActive(false);
	}

	// Token: 0x0600B61E RID: 46622 RVA: 0x00306CF0 File Offset: 0x00304EF0
	public override void Refresh(TCommonMultipleConsumeData data, bool isSelected, int gridIndex)
	{
		ConsumeItemData data2 = null;
		if (data.ItemData != null)
		{
			data2 = ConsumeItemUtil.GetConsumeItemData(data.ItemData, data.Count);
		}
		this.UpdateItem(data2);
	}

	// Token: 0x0600B61F RID: 46623 RVA: 0x00306D24 File Offset: 0x00304F24
	public void UpdateItem(ConsumeItemData data)
	{
		UUIItem item = base.GetItem(1);
		UUIItem item2 = base.GetItem(2);
		if (data == null)
		{
			this.Data = data;
			item.SetUIActive(true);
			item2.SetUIActive(false);
			return;
		}
		this.Data = data;
		this.SetIconState();
		item.SetUIActive(false);
		item2.SetUIActive(true);
		base.GetText(8).SetText(this.Data.BottomText, true);
	}

	// Token: 0x0600B620 RID: 46624 RVA: 0x00306D8D File Offset: 0x00304F8D
	[NullableContext(1)]
	public void SetButtonFunction(TConsumeItemFunction buttonFunction)
	{
		this.ButtonFunction = buttonFunction;
	}

	// Token: 0x040055BF RID: 21951
	protected ConsumeItemData Data;

	// Token: 0x040055C0 RID: 21952
	protected TConsumeItemFunction ButtonFunction;

	// Token: 0x040055C1 RID: 21953
	public EUiViewName? BelongView;

	// Token: 0x02007C3E RID: 31806
	[NullableContext(0)]
	private class EConsumeItem
	{
		// Token: 0x0402A6E4 RID: 173796
		public const int SelectedSprite = 0;

		// Token: 0x0402A6E5 RID: 173797
		public const int EmptyItem = 1;

		// Token: 0x0402A6E6 RID: 173798
		public const int MaterialItem = 2;

		// Token: 0x0402A6E7 RID: 173799
		public const int ChipSprite = 3;

		// Token: 0x0402A6E8 RID: 173800
		public const int IconTexture = 4;

		// Token: 0x0402A6E9 RID: 173801
		public const int QualitySprite = 5;

		// Token: 0x0402A6EA RID: 173802
		public const int ResonanceText = 6;

		// Token: 0x0402A6EB RID: 173803
		public const int ResonanceItem = 7;

		// Token: 0x0402A6EC RID: 173804
		public const int BottomText = 8;

		// Token: 0x0402A6ED RID: 173805
		public const int Button = 9;
	}
}
