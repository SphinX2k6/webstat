using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020018BF RID: 6335
[NullableContext(1)]
[Nullable(0)]
public class CommonSingleConsumeComponent : UiPanelBase
{
	// Token: 0x0600B60B RID: 46603 RVA: 0x003066C1 File Offset: 0x003048C1
	public CommonSingleConsumeComponent(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600B60C RID: 46604 RVA: 0x003066E0 File Offset: 0x003048E0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
	}

	// Token: 0x0600B60D RID: 46605 RVA: 0x003067A8 File Offset: 0x003049A8
	protected override void OnStart()
	{
		this.StrengthItem = new ButtonItem(base.GetItem(5));
		this.ConsumeItem = new ConsumeItem(base.GetItem(4), null);
	}

	// Token: 0x0600B60E RID: 46606 RVA: 0x003067E2 File Offset: 0x003049E2
	protected override void OnBeforeDestroy()
	{
		this.StrengthItem.Destroy(null);
		this.StrengthItem = null;
	}

	// Token: 0x0600B60F RID: 46607 RVA: 0x003067F8 File Offset: 0x003049F8
	[NullableContext(2)]
	public void UpdateComponent(int moneyId, int costCount, TCommonSingleConsumeData singleConsumeData)
	{
		this.SetMaxState(false);
		ConsumeItemData data = null;
		if (singleConsumeData != null)
		{
			data = ConsumeItemUtil.GetConsumeItemData(singleConsumeData.ItemData, singleConsumeData.Count);
		}
		this.ConsumeItem.UpdateItem(data);
		UUIText text = base.GetText(1);
		UUITexture texture = base.GetTexture(0);
		UUIText text2 = base.GetText(3);
		int playerMoney = ModelBase<PlayerInfoModel>.Instance.GetPlayerMoney(moneyId);
		this.EnoughMoney = UiComponentUtil.SetMoneyState(text, text2, costCount, playerMoney);
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(moneyId);
		base.SetTextureByPath(itemConfigData.Icon, texture, null, null);
	}

	// Token: 0x0600B610 RID: 46608 RVA: 0x0030688C File Offset: 0x00304A8C
	[NullableContext(2)]
	public void UpdateComponentOnlyConsume(TCommonSingleConsumeData singleConsumeData)
	{
		this.SetMaxState(false);
		base.GetItem(6).SetUIActive(false);
		ConsumeItemData data = null;
		if (singleConsumeData != null)
		{
			data = ConsumeItemUtil.GetConsumeItemData(singleConsumeData.ItemData, singleConsumeData.Count);
		}
		this.ConsumeItem.UpdateItem(data);
	}

	// Token: 0x0600B611 RID: 46609 RVA: 0x003068D0 File Offset: 0x00304AD0
	public void SetMaxState(bool inMax)
	{
		base.GetItem(6).SetUIActive(!inMax);
		base.GetItem(7).SetUIActive(!inMax);
		this.StrengthItem.SetEnableClick(!inMax);
		if (inMax)
		{
			this.StrengthItem.SetLocalText("ReachMaxLevelStage", Array.Empty<object>());
			return;
		}
		this.StrengthItem.SetLocalText("WeaponResonanceText", Array.Empty<object>());
	}

	// Token: 0x0600B612 RID: 46610 RVA: 0x0030693C File Offset: 0x00304B3C
	public void SetStrengthFunction(TCommonSingleConsumeFunction strengthFunction)
	{
		this.StrengthItem.SetFunction(delegate(int dataId)
		{
			strengthFunction(new int?(dataId));
		});
	}

	// Token: 0x0600B613 RID: 46611 RVA: 0x0030696D File Offset: 0x00304B6D
	public void SetStrengthItemLocalText(string textId, params object[] args)
	{
		this.StrengthItem.SetLocalText(textId, args);
	}

	// Token: 0x0600B614 RID: 46612 RVA: 0x0030697C File Offset: 0x00304B7C
	public void SetConsumeFunction(TCommonSingleConsumeFunction consumeFunction)
	{
		this.ConsumeItem.SetButtonFunction(delegate(int? dataId, int? _)
		{
			consumeFunction(dataId);
		});
	}

	// Token: 0x0600B615 RID: 46613 RVA: 0x003069AD File Offset: 0x00304BAD
	public bool GetEnoughMoney()
	{
		return this.EnoughMoney;
	}

	// Token: 0x040055BC RID: 21948
	[Nullable(2)]
	protected ButtonItem StrengthItem;

	// Token: 0x040055BD RID: 21949
	[Nullable(2)]
	protected ConsumeItem ConsumeItem;

	// Token: 0x040055BE RID: 21950
	protected bool EnoughMoney = true;

	// Token: 0x02007C3B RID: 31803
	[NullableContext(0)]
	private enum ECommonSingleConsumeComponent
	{
		// Token: 0x0402A6DA RID: 173786
		ConsumeTexture,
		// Token: 0x0402A6DB RID: 173787
		ConsumeText,
		// Token: 0x0402A6DC RID: 173788
		OwnTexture,
		// Token: 0x0402A6DD RID: 173789
		OwnText,
		// Token: 0x0402A6DE RID: 173790
		MaterialItem,
		// Token: 0x0402A6DF RID: 173791
		StrengthItem,
		// Token: 0x0402A6E0 RID: 173792
		CostRootItem,
		// Token: 0x0402A6E1 RID: 173793
		MaterialRootItem
	}
}
