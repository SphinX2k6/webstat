using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using UnrealEngine;

// Token: 0x020019A6 RID: 6566
[NullableContext(1)]
[Nullable(0)]
public class TipsWeaponComponent : TipsBaseSubComponent
{
	// Token: 0x0600BC9F RID: 48287 RVA: 0x003215AC File Offset: 0x0031F7AC
	public TipsWeaponComponent(UUIItem rootUiItem) : base(rootUiItem)
	{
		base.CreateThenShowByResourceIdAsync("UiItem_TipsWeapon", rootUiItem, false);
	}

	// Token: 0x0600BCA0 RID: 48288 RVA: 0x003215C4 File Offset: 0x0031F7C4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 18;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BCA1 RID: 48289 RVA: 0x00321848 File Offset: 0x0031FA48
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(5);
		this.TipsLockButton = new TipsLockButton(item);
		this.TipsAttributePanel = new GenericLayoutNew<TipsAttributeItem>(base.GetVerticalLayout(6), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<TipsAttributeItem>(this.CreateAttributeItem), null);
		UUIItem item2 = base.GetItem(12);
		this.TipsGetWayPanel = new TipsGetWayPanel(item2);
		this.StarLayout = new GenericLayout<CSharpScript.Game.Module.RoleUi.StarItem, IStarItemData>(base.GetHorizontalLayout(3), new Func<CSharpScript.Game.Module.RoleUi.StarItem>(this.InitStarItem), null, false, true);
	}

	// Token: 0x0600BCA2 RID: 48290 RVA: 0x003218BE File Offset: 0x0031FABE
	protected override void OnBeforeDestroy()
	{
		if (this.Data != null)
		{
			this.Data = null;
			ModelBase<ItemTipsModel>.Instance.SetCurrentItemTipsData(null);
		}
	}

	// Token: 0x0600BCA3 RID: 48291 RVA: 0x003218DC File Offset: 0x0031FADC
	public override void Refresh(ItemTipsData data)
	{
		TipsWeaponData tipsWeaponData = (TipsWeaponData)data;
		Action action = delegate()
		{
			TipsWeaponData data2 = this.Data;
			base.GetText(0).SetText(data2.WeaponType, true);
			base.GetText(1).SetText(data2.WeaponLevel.ToString() + "/", true);
			base.GetText(2).SetText(data2.WeaponLimitLevel.ToString(), true);
			this.UpdateStar(data2.BreachLevel, data2.BreachMaxLevel);
			if (data2.IncId > 0)
			{
				this.TipsLockButton.Refresh(data2.IncId, data2.CanClickLockButton);
				this.TipsLockButton.SetDeprecateToggleVisible(data2.CanDeprecate());
			}
			this.TipsLockButton.SetUiActive(data2.IncId > 0);
			this.TipsAttributePanel.RebuildLayoutByDataNew<ITipsAttributeItemData>(data2.AttributeData, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "Text_WeaponResonanceItemLevelText_Text", new <>z__ReadOnlySingleElementList<object>(data2.WeaponStage));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), data2.WeaponSkillName, Array.Empty<object>());
			int num = data2.WeaponEffectParam.Length;
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = data2.WeaponEffectParam[i];
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), data2.WeaponEffect, array);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), data2.WeaponDescription, Array.Empty<object>());
			this.RefreshGetWayPanel(data2.GetWayData);
			this.RefreshLimitTimePanel(data2.LimitTimeTxt);
			this.RefreshEquipPanel(data2.IsEquip, data2.EquippedId);
		};
		this.Data = tipsWeaponData;
		ModelBase<ItemTipsModel>.Instance.SetCurrentItemTipsData(tipsWeaponData);
		if (base.InAsyncLoading())
		{
			this.OperationMap["Refresh"] = action;
			return;
		}
		action();
	}

	// Token: 0x0600BCA4 RID: 48292 RVA: 0x00321930 File Offset: 0x0031FB30
	private ILayoutItem<TipsAttributeItem> CreateAttributeItem(object data, UUIItem uiItem, int index)
	{
		TipsAttributeItem value = new TipsAttributeItem(uiItem, (ITipsAttributeItemData)data);
		return new LayoutItem<TipsAttributeItem>
		{
			Key = index,
			Value = value
		};
	}

	// Token: 0x0600BCA5 RID: 48293 RVA: 0x00321962 File Offset: 0x0031FB62
	private CSharpScript.Game.Module.RoleUi.StarItem InitStarItem()
	{
		return new CSharpScript.Game.Module.RoleUi.StarItem();
	}

	// Token: 0x0600BCA6 RID: 48294 RVA: 0x0032196C File Offset: 0x0031FB6C
	private void UpdateStar(int breachLevel, int maxLevel)
	{
		IStarItemData[] array = new IStarItemData[maxLevel];
		for (int i = 0; i < maxLevel; i++)
		{
			StarItemData starItemData = new StarItemData
			{
				StarOnActive = (i < breachLevel),
				StarOffActive = (i >= breachLevel),
				StarNextActive = false,
				StarLoopActive = false,
				PlayLoopSequence = false,
				PlayActivateSequence = false
			};
			array[i] = starItemData;
		}
		this.StarLayout.RefreshByData(array.ToList<IStarItemData>(), null, false);
	}

	// Token: 0x0600BCA7 RID: 48295 RVA: 0x003219DC File Offset: 0x0031FBDC
	private void RefreshGetWayPanel(IGetWayItemData[] getWayData)
	{
		base.GetItem(12).SetUIActive(getWayData.Length != 0);
		if (getWayData != null)
		{
			this.TipsGetWayPanel.Refresh(getWayData);
		}
	}

	// Token: 0x0600BCA8 RID: 48296 RVA: 0x003219FF File Offset: 0x0031FBFF
	private void RefreshLimitTimePanel(string limitTimeTxt)
	{
		base.GetItem(13).SetUIActive(limitTimeTxt != null);
		if (!string.IsNullOrEmpty(limitTimeTxt))
		{
			base.GetText(14).ShowTextNew(limitTimeTxt);
		}
	}

	// Token: 0x0600BCA9 RID: 48297 RVA: 0x00321A28 File Offset: 0x0031FC28
	private void RefreshEquipPanel(bool isEquipped, int? equippedId = null)
	{
		base.GetItem(15).SetUIActive(isEquipped);
		if (isEquipped && equippedId != null)
		{
			RoleSkinData roleSkinDataByRoleId = ModelBase<RoleSkinModel>.Instance.GetRoleSkinDataByRoleId(equippedId.Value);
			if (roleSkinDataByRoleId != null)
			{
				base.SetRoleSkinIcon(roleSkinDataByRoleId.GetRoleSkinConfig().RoleHeadIcon, base.GetTexture(16), roleSkinDataByRoleId.GetItemId(), null, null);
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew(roleSkinDataByRoleId.GetName(), null);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(17), "VisionEquipping", new <>z__ReadOnlySingleElementList<object>(localTextNew));
			}
		}
	}

	// Token: 0x0600BCAA RID: 48298 RVA: 0x00321ABC File Offset: 0x0031FCBC
	public override void SetLockButtonShow(bool isShow)
	{
		Action action = delegate()
		{
			this.GetItem(5).SetUIActive(isShow);
		};
		if (base.InAsyncLoading())
		{
			this.OperationMap["SetLockButtonShow"] = action;
			return;
		}
		action();
	}

	// Token: 0x04005938 RID: 22840
	[Nullable(2)]
	private TipsWeaponData Data;

	// Token: 0x04005939 RID: 22841
	[Nullable(2)]
	private TipsLockButton TipsLockButton;

	// Token: 0x0400593A RID: 22842
	[Nullable(2)]
	private TipsGetWayPanel TipsGetWayPanel;

	// Token: 0x0400593B RID: 22843
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<TipsAttributeItem> TipsAttributePanel;

	// Token: 0x0400593C RID: 22844
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<CSharpScript.Game.Module.RoleUi.StarItem, IStarItemData> StarLayout;

	// Token: 0x02007CAF RID: 31919
	[NullableContext(0)]
	private class ETipsWeaponNode
	{
		// Token: 0x0402A923 RID: 174371
		public const int TxtWeaponType = 0;

		// Token: 0x0402A924 RID: 174372
		public const int TxtLevel = 1;

		// Token: 0x0402A925 RID: 174373
		public const int TxtLevelLimit = 2;

		// Token: 0x0402A926 RID: 174374
		public const int PanelStar = 3;

		// Token: 0x0402A927 RID: 174375
		public const int ItemStar = 4;

		// Token: 0x0402A928 RID: 174376
		public const int LockButton = 5;

		// Token: 0x0402A929 RID: 174377
		public const int PanelAttribute = 6;

		// Token: 0x0402A92A RID: 174378
		public const int ItemAttribute = 7;

		// Token: 0x0402A92B RID: 174379
		public const int TxtWeaponStage = 8;

		// Token: 0x0402A92C RID: 174380
		public const int TxtSkillName = 9;

		// Token: 0x0402A92D RID: 174381
		public const int TxtWeaponEffect = 10;

		// Token: 0x0402A92E RID: 174382
		public const int TxtDescription = 11;

		// Token: 0x0402A92F RID: 174383
		public const int PanelPath = 12;

		// Token: 0x0402A930 RID: 174384
		public const int PanelLimitTime = 13;

		// Token: 0x0402A931 RID: 174385
		public const int TxtLimitTime = 14;

		// Token: 0x0402A932 RID: 174386
		public const int PanelEquip = 15;

		// Token: 0x0402A933 RID: 174387
		public const int TextureEquipIcon = 16;

		// Token: 0x0402A934 RID: 174388
		public const int TxtEquip = 17;
	}
}
