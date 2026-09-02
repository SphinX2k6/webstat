using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002844 RID: 10308
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleDevWeaponRecommendItem : GridProxyAbstract<RoleDevWeaponRecommendItemDataBase>
{
	// Token: 0x06014732 RID: 83762 RVA: 0x005ADCB0 File Offset: 0x005ABEB0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickSwitch)),
			new ValueTuple<int, Delegate>(12, new Action(this.OnClickCall))
		};
	}

	// Token: 0x06014733 RID: 83763 RVA: 0x005ADE28 File Offset: 0x005AC028
	protected override UniTask OnBeforeStartAsync()
	{
		RoleDevWeaponRecommendItem.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevWeaponRecommendItem.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014734 RID: 83764 RVA: 0x005ADE6C File Offset: 0x005AC06C
	private void OnClickedGrid(MediumItemGridExtendCallback _)
	{
		if (this.Data == null)
		{
			return;
		}
		WeaponInstance weaponInstanceByRoleId = ModelBase<WeaponModel>.Instance.GetWeaponInstanceByRoleId(this.Data.RoleId);
		int valueOrDefault = ((weaponInstanceByRoleId != null) ? weaponInstanceByRoleId.GetIncId() : null).GetValueOrDefault();
		RoleDevWeaponRecommendItemDataBase data = this.Data;
		int? num = (data != null) ? new int?(data.WeaponConfigId) : null;
		if (valueOrDefault > 0)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemUid(valueOrDefault, num.Value, true, null);
			return;
		}
		int? num2 = num;
		int num3 = 0;
		if (num2.GetValueOrDefault() > num3 & num2 != null)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(num.Value, true, null);
		}
	}

	// Token: 0x06014735 RID: 83765 RVA: 0x005ADF18 File Offset: 0x005AC118
	public override void Refresh(RoleDevWeaponRecommendItemDataBase data, bool isSelected, int gridIndex)
	{
		this.Refresh(data);
	}

	// Token: 0x06014736 RID: 83766 RVA: 0x005ADF21 File Offset: 0x005AC121
	public void Refresh(RoleDevWeaponRecommendItemDataBase data)
	{
		this.Data = data;
		this.RefreshSwitchBtnState(data);
		this.RefreshWeaponViewItem(data);
		this.DetailVerticalLayout.RefreshByData(data.SubRecommendItems, null, false);
	}

	// Token: 0x06014737 RID: 83767 RVA: 0x005ADF4C File Offset: 0x005AC14C
	private void RefreshSwitchBtnState(RoleDevWeaponRecommendItemDataBase data)
	{
		bool uiactive = !data.IsRoleObtained || data.IsWeaponHighQuality;
		base.GetItem(11).SetUIActive(uiactive);
	}

	// Token: 0x06014738 RID: 83768 RVA: 0x005ADF7C File Offset: 0x005AC17C
	public void RefreshWeaponViewItem(RoleDevWeaponRecommendItemDataBase data)
	{
		if (!data.IsRoleObtained)
		{
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
			this.ItemGrid.SetIconByPath(roleDevWeaponItemConfig.Value.WeaponTypeIcon);
			this.ItemGrid.SetBottomTextVisible(false);
			this.ItemGrid.SetQuality(null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), roleDevWeaponItemConfig.Value.WeaponTypeDescribe, Array.Empty<object>());
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			base.GetItem(6).SetUIActive(false);
			base.GetButton(12).RootUIComp.Get().SetUIActive(false);
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), data.WeaponName, Array.Empty<object>());
			if (data.IsWeaponHighQuality)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "RoleProject_Tips01", Array.Empty<object>());
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "RoleProject_Tips08", Array.Empty<object>());
			}
			WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(data.WeaponConfigId);
			if (weaponConfigByItemId == null)
			{
				return;
			}
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				ItemConfigId = new int?(weaponConfigByItemId.Value.ItemId),
				BottomTextId = "Text_LevelShow_Text",
				BottomTextParameter = new object[]
				{
					data.WeaponLevel
				},
				Data = data
			};
			this.ItemGrid.Apply<PropSmallItemGrid>(parameters);
			base.GetItem(6).SetUIActive(true);
			base.GetButton(12).RootUIComp.Get().SetUIActive(data.IsCall);
		}
		this.BtnJumpItem.SetUiActive(true);
		this.BtnPerfectJumpItem.SetUiActive(false);
	}

	// Token: 0x06014739 RID: 83769 RVA: 0x005AE195 File Offset: 0x005AC395
	public void SetSwitchBtnVisible(bool visible)
	{
		UUIItem item = base.GetItem(11);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(visible);
	}

	// Token: 0x0601473A RID: 83770 RVA: 0x005AE1AA File Offset: 0x005AC3AA
	private RoleDevRecommendItem CreateDetailItem()
	{
		return new RoleDevRecommendItem();
	}

	// Token: 0x0601473B RID: 83771 RVA: 0x005AE1B1 File Offset: 0x005AC3B1
	private void OnClickSwitch()
	{
		Action onClickBtnSwitch = this.OnClickBtnSwitch;
		if (onClickBtnSwitch == null)
		{
			return;
		}
		onClickBtnSwitch();
	}

	// Token: 0x0601473C RID: 83772 RVA: 0x005AE1C4 File Offset: 0x005AC3C4
	private void OnClickJump(int _)
	{
		WeaponInstance weaponInstanceByRoleId = ModelBase<WeaponModel>.Instance.GetWeaponInstanceByRoleId(this.Data.RoleId);
		if (weaponInstanceByRoleId == null)
		{
			return;
		}
		int value = weaponInstanceByRoleId.GetIncId().Value;
		RoleDevUtils.OpenWeaponReplaceView(this.Data.RoleId, value);
		ControllerBase<RoleDevController>.Instance.LogRoleDevSubPageClick(this.Data.RoleId, ERoleDevMainPage.Weapon, ERoleDevSubPageButton.GoToReplace);
	}

	// Token: 0x0601473D RID: 83773 RVA: 0x005AE222 File Offset: 0x005AC422
	private void OnClickCall()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaMainView, this.Data.GachaId, null);
	}

	// Token: 0x04009E1B RID: 40475
	[Nullable(2)]
	private SmallItemGrid ItemGrid;

	// Token: 0x04009E1C RID: 40476
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RoleDevRecommendItem, RoleDevWeaponSubRecommendItemDataBase> DetailVerticalLayout;

	// Token: 0x04009E1D RID: 40477
	[Nullable(2)]
	private ButtonItem BtnJumpItem;

	// Token: 0x04009E1E RID: 40478
	[Nullable(2)]
	private ButtonItem BtnPerfectJumpItem;

	// Token: 0x04009E1F RID: 40479
	[Nullable(2)]
	public Action OnClickBtnSwitch;

	// Token: 0x04009E20 RID: 40480
	[Nullable(2)]
	private RoleDevWeaponRecommendItemDataBase Data;

	// Token: 0x02008BCD RID: 35789
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F1AB RID: 192939
		BtnSwitch,
		// Token: 0x0402F1AC RID: 192940
		PanelWeaponType,
		// Token: 0x0402F1AD RID: 192941
		IconWeaponType,
		// Token: 0x0402F1AE RID: 192942
		WeaponItem,
		// Token: 0x0402F1AF RID: 192943
		TxtWeaponName,
		// Token: 0x0402F1B0 RID: 192944
		TxtGoalLevel,
		// Token: 0x0402F1B1 RID: 192945
		PanelRight,
		// Token: 0x0402F1B2 RID: 192946
		BtnJump,
		// Token: 0x0402F1B3 RID: 192947
		BtnPerfectJump,
		// Token: 0x0402F1B4 RID: 192948
		PanelSubLayout,
		// Token: 0x0402F1B5 RID: 192949
		PanelSubItem,
		// Token: 0x0402F1B6 RID: 192950
		PanelRecommendSwitch,
		// Token: 0x0402F1B7 RID: 192951
		BtnCall
	}
}
