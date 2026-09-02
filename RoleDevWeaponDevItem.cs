using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002843 RID: 10307
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleDevWeaponDevItem : GridProxyAbstract<RoleDevWeaponDevItemDataBase>
{
	// Token: 0x0601471A RID: 83738 RVA: 0x005AD414 File Offset: 0x005AB614
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickSwitch)),
			new ValueTuple<int, Delegate>(11, new Action(this.OnClickCall))
		};
	}

	// Token: 0x0601471B RID: 83739 RVA: 0x005AD58C File Offset: 0x005AB78C
	protected override UniTask OnBeforeStartAsync()
	{
		RoleDevWeaponDevItem.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevWeaponDevItem.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601471C RID: 83740 RVA: 0x005AD5D0 File Offset: 0x005AB7D0
	private void OnClickedGrid(MediumItemGridExtendCallback _)
	{
		if (this.Data == null)
		{
			return;
		}
		WeaponInstance weaponInstanceByRoleId = ModelBase<WeaponModel>.Instance.GetWeaponInstanceByRoleId(this.RoleId.Value);
		int valueOrDefault = ((weaponInstanceByRoleId != null) ? weaponInstanceByRoleId.GetIncId() : null).GetValueOrDefault();
		RoleDevWeaponDevItemDataBase data = this.Data;
		int? num = (data != null) ? new int?(data.WeaponConfigId) : null;
		if (valueOrDefault > 0)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemUid(valueOrDefault, num.Value, true, null);
			return;
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(num.GetValueOrDefault(), true, null);
	}

	// Token: 0x0601471D RID: 83741 RVA: 0x005AD664 File Offset: 0x005AB864
	public override void Refresh(RoleDevWeaponDevItemDataBase data, bool isSelected, int gridIndex)
	{
		this.Refresh(data);
	}

	// Token: 0x0601471E RID: 83742 RVA: 0x005AD66D File Offset: 0x005AB86D
	public void Refresh(RoleDevWeaponDevItemDataBase data)
	{
		this.Data = data;
		this.RoleId = new int?(data.RoleId);
		this.RefreshItemGrid(data);
		this.RefreshWeaponViewItem(data);
	}

	// Token: 0x0601471F RID: 83743 RVA: 0x005AD698 File Offset: 0x005AB898
	public void RefreshItemGrid(RoleDevWeaponDevItemDataBase data)
	{
		int weaponConfigId = data.WeaponConfigId;
		SmallItemGrid itemGrid = this.ItemGrid;
		if (itemGrid != null)
		{
			itemGrid.SetExtendToggleEnable(weaponConfigId > 0, false);
		}
		SmallItemGrid itemGrid2 = this.ItemGrid;
		if (itemGrid2 != null)
		{
			itemGrid2.SetToggleInteractive(weaponConfigId > 0);
		}
		if (weaponConfigId > 0)
		{
			SmallItemGrid itemGrid3 = this.ItemGrid;
			if (itemGrid3 == null)
			{
				return;
			}
			itemGrid3.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClickedGrid));
		}
	}

	// Token: 0x06014720 RID: 83744 RVA: 0x005AD6F7 File Offset: 0x005AB8F7
	public void RefreshWeaponViewItem(RoleDevWeaponDevItemDataBase data)
	{
		this.RefreshWeaponDisplay(data);
		this.RefreshGoalLevelText(data);
		this.DetailVerticalLayout.RefreshByData(data.DetailItems, null, false);
	}

	// Token: 0x06014721 RID: 83745 RVA: 0x005AD71C File Offset: 0x005AB91C
	private void RefreshWeaponDisplay(RoleDevWeaponDevItemDataBase data)
	{
		switch (data.RoleType)
		{
		case ERoleDevDataType.Obtained:
			this.RefreshObtainedWeapon(data);
			return;
		case ERoleDevDataType.NotObtained:
			this.RefreshNotObtainedWeapon(data);
			return;
		case ERoleDevDataType.Forecast:
			this.RefreshForecastWeapon(data);
			return;
		default:
			return;
		}
	}

	// Token: 0x06014722 RID: 83746 RVA: 0x005AD75C File Offset: 0x005AB95C
	private void RefreshNotObtainedWeapon(RoleDevWeaponDevItemDataBase data)
	{
		base.GetItem(12).SetUIActive(false);
		RoleDevProject? roleDevProjectConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProjectConfig(data.RoleId);
		if (roleDevProjectConfig == null)
		{
			return;
		}
		RoleDevWeaponItem? roleDevWeaponItemConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevWeaponItemConfig(roleDevProjectConfig.Value.WeaponType);
		if (roleDevWeaponItemConfig == null)
		{
			return;
		}
		this.SetWeaponIconAndName(roleDevWeaponItemConfig.Value.WeaponTypeIcon, roleDevWeaponItemConfig.Value.WeaponTypeDescribe);
		this.SetNotObtainedButtonStates(data);
	}

	// Token: 0x06014723 RID: 83747 RVA: 0x005AD7E4 File Offset: 0x005AB9E4
	private void RefreshObtainedWeapon(RoleDevWeaponDevItemDataBase data)
	{
		base.GetItem(12).SetUIActive(true);
		WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(data.WeaponConfigId);
		if (weaponConfigByItemId == null)
		{
			return;
		}
		this.ApplyWeaponItemGrid(weaponConfigByItemId.Value, data);
		this.SetWeaponName(data.WeaponName);
		this.SetObtainedButtonStates(data);
	}

	// Token: 0x06014724 RID: 83748 RVA: 0x005AD83C File Offset: 0x005ABA3C
	private void RefreshForecastWeapon(RoleDevWeaponDevItemDataBase data)
	{
		base.GetItem(12).SetUIActive(false);
		IRoleDevProsProjectConfig roleDevProsProjectConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(data.RoleId);
		if (roleDevProsProjectConfig == null)
		{
			return;
		}
		RoleDevWeaponItem? roleDevWeaponItemConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevWeaponItemConfig(roleDevProsProjectConfig.WeaponType);
		if (roleDevWeaponItemConfig == null)
		{
			return;
		}
		this.SetWeaponIconAndName(roleDevWeaponItemConfig.Value.WeaponTypeIcon, roleDevWeaponItemConfig.Value.WeaponTypeDescribe);
		this.SetNotObtainedButtonStates(data);
	}

	// Token: 0x06014725 RID: 83749 RVA: 0x005AD8B4 File Offset: 0x005ABAB4
	private void SetWeaponIconAndName(string iconPath, string weaponName)
	{
		this.ItemGrid.SetIconByPath(iconPath);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), weaponName, Array.Empty<object>());
		this.ItemGrid.SetBottomTextVisible(false);
		this.ItemGrid.SetQuality(null);
	}

	// Token: 0x06014726 RID: 83750 RVA: 0x005AD904 File Offset: 0x005ABB04
	private void SetNotObtainedButtonStates(RoleDevWeaponDevItemDataBase data)
	{
		bool flag = data.RoleType == ERoleDevDataType.Forecast;
		base.GetButton(11).RootUIComp.Get().SetUIActive(false);
		base.GetItem(0).SetUIActive(!flag);
		base.GetItem(7).SetUIActive(false);
		base.GetItem(8).SetUIActive(false);
	}

	// Token: 0x06014727 RID: 83751 RVA: 0x005AD960 File Offset: 0x005ABB60
	private void ApplyWeaponItemGrid(WeaponConf weaponConfig, RoleDevWeaponDevItemDataBase data)
	{
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			ItemConfigId = new int?(weaponConfig.ItemId),
			BottomTextId = "Text_LevelShow_Text",
			BottomTextParameter = new object[]
			{
				data.WeaponLevel
			},
			Data = data
		};
		this.ItemGrid.Apply<PropSmallItemGrid>(parameters);
	}

	// Token: 0x06014728 RID: 83752 RVA: 0x005AD9BF File Offset: 0x005ABBBF
	private void SetWeaponName(string weaponName)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), weaponName, Array.Empty<object>());
	}

	// Token: 0x06014729 RID: 83753 RVA: 0x005AD9D8 File Offset: 0x005ABBD8
	private void SetObtainedButtonStates(RoleDevWeaponDevItemDataBase data)
	{
		base.GetButton(11).RootUIComp.Get().SetUIActive(data.IsCall);
		this.RefreshButtonTexts(data);
		bool isHighQuality = data.IsHighQuality;
		base.GetItem(0).SetUIActive(isHighQuality);
	}

	// Token: 0x0601472A RID: 83754 RVA: 0x005ADA20 File Offset: 0x005ABC20
	private void RefreshGoalLevelText(RoleDevWeaponDevItemDataBase data)
	{
		UUIText text = base.GetText(6);
		if (data.WeaponLevel == data.WeaponGoalUpgradeLevel && !data.WeaponIsMaxLevel)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoleProject_Tips04", Array.Empty<object>());
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoleProject_TargetLevel", new object[]
			{
				data.WeaponGoalUpgradeLevel
			});
		}
		text.SetUIActive(!data.WeaponIsMaxLevel);
	}

	// Token: 0x0601472B RID: 83755 RVA: 0x005ADA98 File Offset: 0x005ABC98
	private void RefreshButtonTexts(RoleDevWeaponDevItemDataBase data)
	{
		bool flag = (data.WeaponLevel == data.WeaponGoalUpgradeLevel && !data.WeaponIsMaxLevel) || data.WeaponIsMaxLevel;
		string textId = flag ? "RoleProject_Button02" : "RoleProject_Button01";
		ButtonItem normalButtonItem = this.NormalButtonItem;
		if (normalButtonItem != null)
		{
			normalButtonItem.SetLocalTextNew(textId, Array.Empty<object>());
		}
		ButtonItem highLightButtonItem = this.HighLightButtonItem;
		if (highLightButtonItem != null)
		{
			highLightButtonItem.SetLocalTextNew(textId, Array.Empty<object>());
		}
		if (flag)
		{
			ButtonItem normalButtonItem2 = this.NormalButtonItem;
			if (normalButtonItem2 != null)
			{
				normalButtonItem2.SetUiActive(true);
			}
			ButtonItem highLightButtonItem2 = this.HighLightButtonItem;
			if (highLightButtonItem2 != null)
			{
				highLightButtonItem2.SetUiActive(false);
			}
		}
		else
		{
			ButtonItem normalButtonItem3 = this.NormalButtonItem;
			if (normalButtonItem3 != null)
			{
				normalButtonItem3.SetUiActive(!data.IsAllMaterialEnough);
			}
			ButtonItem highLightButtonItem3 = this.HighLightButtonItem;
			if (highLightButtonItem3 != null)
			{
				highLightButtonItem3.SetUiActive(data.IsAllMaterialEnough);
			}
		}
		ButtonItem normalButtonItem4 = this.NormalButtonItem;
		if (normalButtonItem4 != null)
		{
			normalButtonItem4.SetFunction(new Action<int>(this.OnClickDevJump));
		}
		ButtonItem highLightButtonItem4 = this.HighLightButtonItem;
		if (highLightButtonItem4 == null)
		{
			return;
		}
		highLightButtonItem4.SetFunction(new Action<int>(this.OnClickDevJump));
	}

	// Token: 0x0601472C RID: 83756 RVA: 0x005ADB94 File Offset: 0x005ABD94
	private RoleDevDetailItem CreateDetailItem()
	{
		return new RoleDevDetailItem();
	}

	// Token: 0x0601472D RID: 83757 RVA: 0x005ADB9C File Offset: 0x005ABD9C
	private void OpenWeaponRootView()
	{
		WeaponInstance weaponInstanceByRoleId = ModelBase<WeaponModel>.Instance.GetWeaponInstanceByRoleId(this.RoleId.Value);
		if (weaponInstanceByRoleId == null)
		{
			return;
		}
		int skinIdByRoleId = ModelBase<WeaponSkinModel>.Instance.GetSkinIdByRoleId(weaponInstanceByRoleId.GetRoleId());
		WeaponRootViewParam param = new WeaponRootViewParam
		{
			WeaponIncId = weaponInstanceByRoleId.GetIncId().Value,
			WeaponSkinId = skinIdByRoleId,
			IsFromRoleRootView = false
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponRootView, param, null);
	}

	// Token: 0x0601472E RID: 83758 RVA: 0x005ADC0D File Offset: 0x005ABE0D
	private void OnClickSwitch()
	{
		Action onClickBtnSwitch = this.OnClickBtnSwitch;
		if (onClickBtnSwitch == null)
		{
			return;
		}
		onClickBtnSwitch();
	}

	// Token: 0x0601472F RID: 83759 RVA: 0x005ADC20 File Offset: 0x005ABE20
	private void OnClickDevJump(int _)
	{
		bool flag = (this.Data.WeaponLevel == this.Data.WeaponGoalUpgradeLevel && !this.Data.WeaponIsMaxLevel) || this.Data.WeaponIsMaxLevel;
		ControllerBase<RoleDevController>.Instance.LogRoleDevSubPageClick(this.RoleId.Value, ERoleDevMainPage.Weapon, flag ? ERoleDevSubPageButton.WeaponGoToView : ERoleDevSubPageButton.WeaponGoToCultivation);
		this.OpenWeaponRootView();
	}

	// Token: 0x06014730 RID: 83760 RVA: 0x005ADC86 File Offset: 0x005ABE86
	private void OnClickCall()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaMainView, this.Data.GachaId, null);
	}

	// Token: 0x04009E14 RID: 40468
	[Nullable(2)]
	private SmallItemGrid ItemGrid;

	// Token: 0x04009E15 RID: 40469
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RoleDevDetailItem, global::IRoleDevDetailItemData> DetailVerticalLayout;

	// Token: 0x04009E16 RID: 40470
	private int? RoleId;

	// Token: 0x04009E17 RID: 40471
	[Nullable(2)]
	private RoleDevWeaponDevItemDataBase Data;

	// Token: 0x04009E18 RID: 40472
	[Nullable(2)]
	private ButtonItem NormalButtonItem;

	// Token: 0x04009E19 RID: 40473
	[Nullable(2)]
	private ButtonItem HighLightButtonItem;

	// Token: 0x04009E1A RID: 40474
	[Nullable(2)]
	public Action OnClickBtnSwitch;

	// Token: 0x02008BCB RID: 35787
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F199 RID: 192921
		PanelSwitch,
		// Token: 0x0402F19A RID: 192922
		BtnSwitch,
		// Token: 0x0402F19B RID: 192923
		PanelWeaponType,
		// Token: 0x0402F19C RID: 192924
		IconWeaponType,
		// Token: 0x0402F19D RID: 192925
		WeaponItem,
		// Token: 0x0402F19E RID: 192926
		TxtWeaponName,
		// Token: 0x0402F19F RID: 192927
		TxtGoalLevel,
		// Token: 0x0402F1A0 RID: 192928
		BtnJump,
		// Token: 0x0402F1A1 RID: 192929
		BtnPerfectJump,
		// Token: 0x0402F1A2 RID: 192930
		PanelDetailLayout,
		// Token: 0x0402F1A3 RID: 192931
		PanelDetailItem,
		// Token: 0x0402F1A4 RID: 192932
		BtnCall,
		// Token: 0x0402F1A5 RID: 192933
		RightItem
	}
}
