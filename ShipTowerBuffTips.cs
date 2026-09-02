using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029A7 RID: 10663
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerBuffTips : UiPanelBase
{
	// Token: 0x06015428 RID: 87080 RVA: 0x005E4504 File Offset: 0x005E2704
	public UniTask Init(UUIItem item)
	{
		ShipTowerBuffTips.<Init>d__3 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.item = item;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<ShipTowerBuffTips.<Init>d__3>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06015429 RID: 87081 RVA: 0x005E4550 File Offset: 0x005E2750
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerBuffTips.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerBuffTips.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601542A RID: 87082 RVA: 0x005E4594 File Offset: 0x005E2794
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUISprite)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent))
		};
	}

	// Token: 0x0601542B RID: 87083 RVA: 0x005E46B7 File Offset: 0x005E28B7
	protected override void OnStart()
	{
	}

	// Token: 0x0601542C RID: 87084 RVA: 0x005E46B9 File Offset: 0x005E28B9
	protected override void OnBeforeShow()
	{
	}

	// Token: 0x0601542D RID: 87085 RVA: 0x005E46BB File Offset: 0x005E28BB
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x0601542E RID: 87086 RVA: 0x005E46C0 File Offset: 0x005E28C0
	public void UpdateData(ShipTowerBuffData data)
	{
		this.Data = data;
		ItemTipsData tipsDataById = ItemTipsComponentUtilTool.GetTipsDataById(this.Data.ItemId, null, null);
		ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(this.Data.ItemId);
		base.GetText(2).ShowTextNew(tipsDataById.Title);
		base.GetText(3).ShowTextNew(((itemConfig != null) ? itemConfig.GetValueOrDefault().BgDescription : null) ?? "");
		base.SetTextureByPath(((itemConfig != null) ? itemConfig.GetValueOrDefault().IconMiddle : null) ?? "", base.GetTexture(4), null, null);
		bool flag = tipsDataById.GetWayData != null && tipsDataById.GetWayData.Length != 0;
		base.GetVerticalLayout(9).RootUIComp.Get().SetUIActive(flag);
		if (flag)
		{
			GenericLayout<ShipTowerBuffWayItem, IGetWayItemData> itemLayout = this.ItemLayout;
			if (itemLayout == null)
			{
				return;
			}
			itemLayout.RefreshByDataAsync(tipsDataById.GetWayData, false, null);
		}
	}

	// Token: 0x0601542F RID: 87087 RVA: 0x005E47DB File Offset: 0x005E29DB
	private ShipTowerBuffWayItem CreateWayItem()
	{
		return new ShipTowerBuffWayItem();
	}

	// Token: 0x0400A3F2 RID: 41970
	private ShipTowerBuffData Data;

	// Token: 0x0400A3F3 RID: 41971
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<ShipTowerBuffWayItem, IGetWayItemData> ItemLayout;

	// Token: 0x02008CF1 RID: 36081
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F699 RID: 194201
		public const int TextureQualityBg = 0;

		// Token: 0x0402F69A RID: 194202
		public const int TxtUseTimes = 1;

		// Token: 0x0402F69B RID: 194203
		public const int TxtName = 2;

		// Token: 0x0402F69C RID: 194204
		public const int TxtDesc = 3;

		// Token: 0x0402F69D RID: 194205
		public const int TextureIcon = 4;

		// Token: 0x0402F69E RID: 194206
		public const int ItemQualityEffectBlue = 5;

		// Token: 0x0402F69F RID: 194207
		public const int SpriteQualityBgPurple = 6;

		// Token: 0x0402F6A0 RID: 194208
		public const int ItemQualityEffectPurple = 7;

		// Token: 0x0402F6A1 RID: 194209
		public const int ItemQualityEffectGold = 8;

		// Token: 0x0402F6A2 RID: 194210
		public const int VerticalLayoutWay = 9;

		// Token: 0x0402F6A3 RID: 194211
		public const int ItemWay = 10;

		// Token: 0x0402F6A4 RID: 194212
		public const int BtnWay = 11;
	}
}
