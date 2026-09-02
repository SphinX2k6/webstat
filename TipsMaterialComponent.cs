using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RecallQuest.Model;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;
using UnrealEngine;

// Token: 0x020019A3 RID: 6563
[NullableContext(1)]
[Nullable(0)]
public class TipsMaterialComponent : TipsBaseSubComponent
{
	// Token: 0x0600BC76 RID: 48246 RVA: 0x00320209 File Offset: 0x0031E409
	public TipsMaterialComponent(UUIItem rootUiItem) : base(rootUiItem)
	{
		base.CreateThenShowByResourceIdAsync("UiItem_TipsMaterial", rootUiItem, false);
	}

	// Token: 0x0600BC77 RID: 48247 RVA: 0x00320220 File Offset: 0x0031E420
	protected unsafe override void OnRegisterComponent()
	{
		int num = 14;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BC78 RID: 48248 RVA: 0x0032041C File Offset: 0x0031E61C
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(6);
		this.TipsGetWayPanel = new TipsGetWayPanel(item);
	}

	// Token: 0x0600BC79 RID: 48249 RVA: 0x0032043D File Offset: 0x0031E63D
	protected override void OnBeforeDestroy()
	{
		if (this.Data != null)
		{
			this.Data = null;
			ModelBase<ItemTipsModel>.Instance.SetCurrentItemTipsData(null);
		}
	}

	// Token: 0x0600BC7A RID: 48250 RVA: 0x0032045C File Offset: 0x0031E65C
	public override void Refresh(ItemTipsData data)
	{
		TipsMaterialData tipsMaterialData = (TipsMaterialData)data;
		Action action = delegate()
		{
			TipsMaterialData data2 = this.Data;
			this.RefreshBaseInfo(data2);
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(data2.ConfigId);
			bool isHideHave = this.GetIsHideHave(new int?((int)((itemConfigData != null) ? itemConfigData.ItemType : null).Value));
			this.RefreshStockAndGetWay(data2, new int?((int)((itemConfigData != null) ? itemConfigData.ItemType : null).Value), isHideHave);
			this.RefreshRoleDevelopPanel(data2);
		};
		this.Data = tipsMaterialData;
		ModelBase<ItemTipsModel>.Instance.SetCurrentItemTipsData(tipsMaterialData);
		if (base.InAsyncLoading())
		{
			this.OperationMap["Refresh"] = action;
			return;
		}
		action();
	}

	// Token: 0x0600BC7B RID: 48251 RVA: 0x003204B0 File Offset: 0x0031E6B0
	private void RefreshBaseInfo(TipsMaterialData data)
	{
		bool flag = !StringUtils.IsEmpty(data.MaterialType);
		if (flag)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.MaterialType, Array.Empty<object>());
		}
		base.GetText(0).SetUIActive(flag);
		base.GetSprite(1).SetUIActive(data.FunctionSpritePath != null);
		if (!string.IsNullOrEmpty(data.FunctionSpritePath))
		{
			this.SetSpriteByPath(data.FunctionSpritePath, base.GetSprite(1), false, null, null);
		}
		bool flag2 = !StringUtils.IsEmpty(data.TxtEffect);
		if (flag2)
		{
			if (data.EffectAutoLocalText)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), data.TxtEffect, data.TxtEffectArgs);
			}
			else
			{
				UUIText text = base.GetText(4);
				if (text != null)
				{
					text.SetText(data.TxtEffect, true);
				}
			}
		}
		base.GetText(4).SetUIActive(flag2);
		bool flag3 = !StringUtils.IsEmpty(data.TxtDescription);
		if (flag3)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), data.TxtDescription, Array.Empty<object>());
		}
		if (!string.IsNullOrEmpty(data.ExTxtDescription))
		{
			UUIText text2 = base.GetText(13);
			if (text2 != null)
			{
				text2.SetText(data.ExTxtDescription, true);
			}
			UUIText text3 = base.GetText(13);
			if (text3 != null)
			{
				text3.SetUIActive(true);
			}
		}
		else
		{
			UUIText text4 = base.GetText(13);
			if (text4 != null)
			{
				text4.SetUIActive(false);
			}
		}
		base.GetText(5).SetUIActive(flag3);
		this.RefreshLimitTimePanel(data.LimitTimeTxt);
	}

	// Token: 0x0600BC7C RID: 48252 RVA: 0x00320630 File Offset: 0x0031E830
	private bool GetIsHideHave(int? itemType)
	{
		bool result = false;
		if (itemType != null)
		{
			TypeInfo? itemTypeConfig = ConfigBase<InventoryConfig>.Instance.GetItemTypeConfig(itemType.Value);
			if (itemTypeConfig != null && !itemTypeConfig.Value.ShowStock)
			{
				result = true;
			}
		}
		return result;
	}

	// Token: 0x0600BC7D RID: 48253 RVA: 0x00320678 File Offset: 0x0031E878
	private void RefreshStockAndGetWay(TipsMaterialData data, int? itemType, bool isHideHave)
	{
		this.SetPanelNumVisible(!isHideHave);
		int? num = itemType;
		this.RefreshGetWayPanel(this.GetWayDataList(data, (num != null) ? new InventoryDefine.EItemType?((InventoryDefine.EItemType)num.GetValueOrDefault()) : null));
		if (!isHideHave)
		{
			int num2 = data.Num;
			base.GetText(3).SetText(num2.ToString(), true);
			base.GetText(3).useChangeColor = (num2 == 0);
		}
	}

	// Token: 0x0600BC7E RID: 48254 RVA: 0x003206EC File Offset: 0x0031E8EC
	private void RefreshRoleDevelopPanel(TipsMaterialData data)
	{
		RoleDevelopModel instance = ModelBase<RoleDevelopModel>.Instance;
		bool flag = instance != null && instance.DevTargetRoleId != 0 && instance.IsDevelopRoleNeedItem(data.ConfigId);
		int num = flag ? instance.GetDevelopRoleNeedItemCount(data.ConfigId) : 0;
		int num2 = data.Num;
		bool flag2 = flag && num > 0 && num2 < num;
		base.GetItem(9).SetUIActive(flag2);
		if (!flag2)
		{
			return;
		}
		string developRoleSmallIconPath = instance.GetDevelopRoleSmallIconPath();
		if (!StringUtils.IsEmpty(developRoleSmallIconPath))
		{
			base.SetTextureByPath(developRoleSmallIconPath, base.GetTexture(10), null, null);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "RoleProject_ItemCount", new <>z__ReadOnlySingleElementList<object>(num - num2));
		bool uiactive = instance.IsDevelopRoleNeedItemCanBeSupplemented(data.ConfigId);
		base.GetItem(12).SetUIActive(uiactive);
	}

	// Token: 0x0600BC7F RID: 48255 RVA: 0x003207C0 File Offset: 0x0031E9C0
	public IGetWayItemData[] GetWayDataList(TipsMaterialData data, InventoryDefine.EItemType? itemType)
	{
		bool flag = data.Num > 0;
		if (itemType.GetValueOrDefault() == InventoryDefine.EItemType.ShipTowerBuff && flag)
		{
			return new IGetWayItemData[0];
		}
		return data.GetWayData ?? new IGetWayItemData[0];
	}

	// Token: 0x0600BC80 RID: 48256 RVA: 0x00320800 File Offset: 0x0031EA00
	private void RefreshGetWayPanel(IGetWayItemData[] getWayData)
	{
		bool uiactive = this.NeedShowTip(getWayData);
		base.GetItem(6).SetUIActive(uiactive);
		if (getWayData != null)
		{
			this.TipsGetWayPanel.Refresh(getWayData);
		}
	}

	// Token: 0x0600BC81 RID: 48257 RVA: 0x00320831 File Offset: 0x0031EA31
	private bool NeedShowTip(IGetWayItemData[] getWayData)
	{
		return getWayData.Length != 0 && !ModelBase<RecallQuestModel>.Instance.IsInRecallInstance();
	}

	// Token: 0x0600BC82 RID: 48258 RVA: 0x00320846 File Offset: 0x0031EA46
	private void RefreshLimitTimePanel(string limitTimeTxt)
	{
		base.GetItem(7).SetUIActive(limitTimeTxt != null);
		if (!string.IsNullOrEmpty(limitTimeTxt))
		{
			base.GetText(8).SetText(limitTimeTxt, true);
		}
	}

	// Token: 0x0600BC83 RID: 48259 RVA: 0x00320870 File Offset: 0x0031EA70
	public override void SetPanelNumVisible(bool isShow)
	{
		Action action = delegate()
		{
			this.GetItem(2).SetUIActive(isShow);
		};
		if (base.InAsyncLoading())
		{
			this.OperationMap["SetPanelNumVisible"] = action;
			return;
		}
		action();
	}

	// Token: 0x0400592D RID: 22829
	[Nullable(2)]
	private TipsMaterialData Data;

	// Token: 0x0400592E RID: 22830
	[Nullable(2)]
	private TipsGetWayPanel TipsGetWayPanel;

	// Token: 0x02007CA6 RID: 31910
	[NullableContext(0)]
	private class ETipsMaterialNode
	{
		// Token: 0x0402A8E9 RID: 174313
		public const int TxtType = 0;

		// Token: 0x0402A8EA RID: 174314
		public const int SpriteIcon = 1;

		// Token: 0x0402A8EB RID: 174315
		public const int PanelNum = 2;

		// Token: 0x0402A8EC RID: 174316
		public const int TxtNum = 3;

		// Token: 0x0402A8ED RID: 174317
		public const int TxtEffect = 4;

		// Token: 0x0402A8EE RID: 174318
		public const int TxtDescription = 5;

		// Token: 0x0402A8EF RID: 174319
		public const int PanelPath = 6;

		// Token: 0x0402A8F0 RID: 174320
		public const int PanelLimitTime = 7;

		// Token: 0x0402A8F1 RID: 174321
		public const int TxtLimitTime = 8;

		// Token: 0x0402A8F2 RID: 174322
		public const int PnlRoleDevelopMat = 9;

		// Token: 0x0402A8F3 RID: 174323
		public const int TexRole = 10;

		// Token: 0x0402A8F4 RID: 174324
		public const int TxtLinkDesc = 11;

		// Token: 0x0402A8F5 RID: 174325
		public const int UiItemRoleDevelopMatFull = 12;

		// Token: 0x0402A8F6 RID: 174326
		public const int ExTxtDescription = 13;
	}
}
