using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002842 RID: 10306
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleDevRecommendItem : GridProxyAbstract<RoleDevWeaponSubRecommendItemDataBase>
{
	// Token: 0x06014705 RID: 83717 RVA: 0x005ACADC File Offset: 0x005AACDC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickCall))
		};
	}

	// Token: 0x06014706 RID: 83718 RVA: 0x005ACBC8 File Offset: 0x005AADC8
	protected override UniTask OnBeforeStartAsync()
	{
		RoleDevRecommendItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevRecommendItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014707 RID: 83719 RVA: 0x005ACC0C File Offset: 0x005AAE0C
	private void OnClickedGrid(MediumItemGridExtendCallback _)
	{
		RoleDevWeaponSubRecommendItemDataBase data = this.Data;
		int? num = (data != null) ? new int?(data.WeaponId) : null;
		if (num != null)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(num.Value, true, null);
		}
	}

	// Token: 0x06014708 RID: 83720 RVA: 0x005ACC55 File Offset: 0x005AAE55
	protected override void OnStart()
	{
		this.InitUiVisibility();
		this.InitButton();
	}

	// Token: 0x06014709 RID: 83721 RVA: 0x005ACC63 File Offset: 0x005AAE63
	private void InitUiVisibility()
	{
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(7);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x0601470A RID: 83722 RVA: 0x005ACC8C File Offset: 0x005AAE8C
	private void InitButton()
	{
		this.ButtonJump.SetFunction(new Action<int>(this.OnClickJump));
		this.ButtonJump.SetLocalTextNew("RoleProject_Tips02", Array.Empty<object>());
		this.ButtonMoonCard.SetFunction(new Action<int>(this.OnClickMoonCard));
		this.ButtonMoonCard.SetLocalTextNew("RoleProject_Button04", Array.Empty<object>());
		this.ButtonMoonCard.SetRedDotVisible(false);
	}

	// Token: 0x0601470B RID: 83723 RVA: 0x005ACCFD File Offset: 0x005AAEFD
	public override void Refresh(RoleDevWeaponSubRecommendItemDataBase data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.ItemIndexInternal = gridIndex;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.WeaponName, Array.Empty<object>());
		this.RefreshPanel(data);
	}

	// Token: 0x17001A9B RID: 6811
	// (get) Token: 0x0601470C RID: 83724 RVA: 0x005ACD30 File Offset: 0x005AAF30
	public int ItemIndex
	{
		get
		{
			return this.ItemIndexInternal;
		}
	}

	// Token: 0x0601470D RID: 83725 RVA: 0x005ACD38 File Offset: 0x005AAF38
	private void RefreshPanel(RoleDevWeaponSubRecommendItemDataBase data)
	{
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(data.IsEquipped);
		}
		base.GetButton(2).RootUIComp.Get().SetUIActive(!data.IsEquipped && data.IsCall);
		this.RefreshJumpButton(data);
		this.RefreshPathButton(data);
		this.RefreshItemGrid(data);
	}

	// Token: 0x0601470E RID: 83726 RVA: 0x005ACD9C File Offset: 0x005AAF9C
	private void RefreshItemGrid(RoleDevWeaponSubRecommendItemDataBase data)
	{
		WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(data.WeaponId);
		if (weaponConfigByItemId == null)
		{
			return;
		}
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			ItemConfigId = new int?(weaponConfigByItemId.Value.ItemId),
			Data = data
		};
		this.ItemGrid.Apply<PropSmallItemGrid>(parameters);
	}

	// Token: 0x0601470F RID: 83727 RVA: 0x005ACDF8 File Offset: 0x005AAFF8
	private void RefreshJumpButton(RoleDevWeaponSubRecommendItemDataBase data)
	{
		if (this.ButtonJump == null)
		{
			return;
		}
		if (data.IsObtained && !data.IsEquipped)
		{
			string textId = data.HasRole ? "RoleProject_Button05" : "RoleProject_Button06";
			this.ButtonJump.SetLocalTextNew(textId, Array.Empty<object>());
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.Data.WeaponId, 0);
			this.ButtonJump.SetUiActive(itemCountByConfigId > 0);
			return;
		}
		this.ButtonJump.SetUiActive(false);
	}

	// Token: 0x06014710 RID: 83728 RVA: 0x005ACE78 File Offset: 0x005AB078
	private void RefreshPathButton(RoleDevWeaponSubRecommendItemDataBase data)
	{
		UUIItem item = base.GetItem(4);
		if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(data.WeaponId, 0) > 0)
		{
			this.ButtonMoonCard.SetUiActive(false);
			item.SetUIActive(false);
			return;
		}
		RoleDevWeaponJumpGroup? weaponJumpGroupConfig = data.WeaponJumpGroupConfig;
		if (weaponJumpGroupConfig != null)
		{
			weaponJumpGroupConfig = data.WeaponJumpGroupConfig;
			if (weaponJumpGroupConfig.Value.JumpPath != 0)
			{
				ButtonItem buttonMoonCard = this.ButtonMoonCard;
				weaponJumpGroupConfig = data.WeaponJumpGroupConfig;
				buttonMoonCard.SetLocalTextNew(weaponJumpGroupConfig.Value.PathDescribe, Array.Empty<object>());
				this.ButtonMoonCard.SetUiActive(true);
				item.SetUIActive(false);
				return;
			}
		}
		this.ButtonMoonCard.SetUiActive(false);
		item.SetUIActive(true);
		weaponJumpGroupConfig = data.WeaponJumpGroupConfig;
		if (weaponJumpGroupConfig != null && !data.IsCall)
		{
			weaponJumpGroupConfig = data.WeaponJumpGroupConfig;
			if (weaponJumpGroupConfig.Value.JumpType == 1)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "RoleProject_Access_None", Array.Empty<object>());
				return;
			}
		}
		weaponJumpGroupConfig = data.WeaponJumpGroupConfig;
		string textStringId = ((weaponJumpGroupConfig != null) ? weaponJumpGroupConfig.GetValueOrDefault().PathDescribe : null) ?? "";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), textStringId, Array.Empty<object>());
	}

	// Token: 0x06014711 RID: 83729 RVA: 0x005ACFBA File Offset: 0x005AB1BA
	private void OnClickCall()
	{
		RoleDevWeaponSubRecommendItemDataBase data = this.Data;
		if (data != null && data.GachaId > 0)
		{
			this.JumpToGachaInterface();
		}
	}

	// Token: 0x06014712 RID: 83730 RVA: 0x005ACFDC File Offset: 0x005AB1DC
	private void OnClickJump(int _)
	{
		if (this.Data == null)
		{
			return;
		}
		if (this.Data.HasRole)
		{
			this.JumpToWeaponReplaceInterface();
		}
		else
		{
			this.JumpToBackpackInterface();
		}
		ERoleDevSubPageButton subPage;
		switch (this.ItemIndex)
		{
		case 0:
			subPage = ERoleDevSubPageButton.GoToEquip1;
			break;
		case 1:
			subPage = ERoleDevSubPageButton.GoToEquip2;
			break;
		case 2:
			subPage = ERoleDevSubPageButton.GoToEquip3;
			break;
		default:
			subPage = ERoleDevSubPageButton.GoToEquip1;
			break;
		}
		ControllerBase<RoleDevController>.Instance.LogRoleDevSubPageClick(this.Data.RoleId, ERoleDevMainPage.Weapon, subPage);
	}

	// Token: 0x06014713 RID: 83731 RVA: 0x005AD050 File Offset: 0x005AB250
	private void JumpToWeaponReplaceInterface()
	{
		WeaponInstance weaponInstanceByRoleId = ModelBase<WeaponModel>.Instance.GetWeaponInstanceByRoleId(this.Data.RoleId);
		if (weaponInstanceByRoleId == null)
		{
			return;
		}
		List<WeaponItemData> weaponListFromReplace = ModelBase<WeaponModel>.Instance.GetWeaponListFromReplace(weaponInstanceByRoleId.GetWeaponConfig().Value.WeaponType);
		int sortId = ConfigBase<SortConfig>.Instance.GetSortId(EFilterSortGroupId.UseWayWeaponResonanceAndReplace);
		Sort? sortConfig = ConfigBase<SortConfig>.Instance.GetSortConfig(sortId);
		if (sortConfig == null)
		{
			return;
		}
		SortResultData sortResultData = new SortResultData();
		sortResultData.SetConfigId(sortConfig.Value.Id);
		sortResultData.SetIsAscending(false);
		int ruleId = sortConfig.Value.BaseSortList()[0];
		string sortRuleName = ConfigBase<SortConfig>.Instance.GetSortRuleName(ruleId, (ESortDataType)sortConfig.Value.DataId);
		sortResultData.SetSelectBaseSort(new SortViewBaseSort(ruleId, sortRuleName));
		ModelBase<SortModel>.Instance.SortDataList<WeaponItemData>(weaponListFromReplace, sortConfig.Value.Id, sortResultData, Array.Empty<object>());
		int num = -1;
		int num2 = -1;
		foreach (WeaponItemData weaponItemData in weaponListFromReplace)
		{
			if (weaponItemData.GetConfigId() == this.Data.WeaponId)
			{
				WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(weaponItemData.GetUniqueId());
				if (weaponDataByIncId != null)
				{
					if (weaponDataByIncId.GetRoleId() == 0)
					{
						num2 = weaponItemData.GetUniqueId();
						break;
					}
					if (num < 0)
					{
						num = weaponItemData.GetUniqueId();
					}
				}
			}
		}
		if (num2 < 0)
		{
			num2 = num;
		}
		RoleDevUtils.OpenWeaponReplaceView(this.Data.RoleId, num2);
	}

	// Token: 0x06014714 RID: 83732 RVA: 0x005AD1F4 File Offset: 0x005AB3F4
	private void JumpToBackpackInterface()
	{
		WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(this.Data.WeaponId);
		if (weaponConfigByItemId == null)
		{
			return;
		}
		List<WeaponItemData> weaponListFromReplace = ModelBase<WeaponModel>.Instance.GetWeaponListFromReplace(weaponConfigByItemId.Value.WeaponType);
		int sortId = ConfigBase<SortConfig>.Instance.GetSortId(EFilterSortGroupId.UseWayWeaponResonanceAndReplace);
		Sort? sortConfig = ConfigBase<SortConfig>.Instance.GetSortConfig(sortId);
		if (sortConfig == null)
		{
			return;
		}
		SortResultData sortResultData = new SortResultData();
		sortResultData.SetConfigId(sortConfig.Value.Id);
		sortResultData.SetIsAscending(false);
		int ruleId = sortConfig.Value.BaseSortList()[0];
		string sortRuleName = ConfigBase<SortConfig>.Instance.GetSortRuleName(ruleId, (ESortDataType)sortConfig.Value.DataId);
		sortResultData.SetSelectBaseSort(new SortViewBaseSort(ruleId, sortRuleName));
		ModelBase<SortModel>.Instance.SortDataList<WeaponItemData>(weaponListFromReplace, sortConfig.Value.Id, sortResultData, Array.Empty<object>());
		int? num = null;
		foreach (WeaponItemData weaponItemData in weaponListFromReplace)
		{
			if (weaponItemData.GetConfigId() == this.Data.WeaponId)
			{
				num = new int?(weaponItemData.GetUniqueId());
				break;
			}
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.InventoryView, num, null);
	}

	// Token: 0x06014715 RID: 83733 RVA: 0x005AD368 File Offset: 0x005AB568
	private void OnClickMoonCard(int _)
	{
		RoleDevWeaponSubRecommendItemDataBase data = this.Data;
		if (data == null || data.WeaponJumpGroupConfig == null)
		{
			return;
		}
		if (this.Data.WeaponJumpGroupConfig.Value.JumpType == 3)
		{
			this.JumpToConfiguredPath(this.Data.WeaponJumpGroupConfig.Value.JumpPath);
		}
	}

	// Token: 0x06014716 RID: 83734 RVA: 0x005AD3D4 File Offset: 0x005AB5D4
	private void JumpToConfiguredPath(int jumpPath)
	{
		this.RunByConfigId(jumpPath, null);
	}

	// Token: 0x06014717 RID: 83735 RVA: 0x005AD3DE File Offset: 0x005AB5DE
	[NullableContext(2)]
	private void RunByConfigId(int id, object @params = null)
	{
		SkipTaskManager.RunByConfigId(id, @params);
	}

	// Token: 0x06014718 RID: 83736 RVA: 0x005AD3E7 File Offset: 0x005AB5E7
	private void JumpToGachaInterface()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaMainView, this.Data.GachaId, null);
	}

	// Token: 0x04009E0F RID: 40463
	[Nullable(2)]
	private ButtonItem ButtonJump;

	// Token: 0x04009E10 RID: 40464
	[Nullable(2)]
	private ButtonItem ButtonMoonCard;

	// Token: 0x04009E11 RID: 40465
	[Nullable(2)]
	private SmallItemGrid ItemGrid;

	// Token: 0x04009E12 RID: 40466
	[Nullable(2)]
	private RoleDevWeaponSubRecommendItemDataBase Data;

	// Token: 0x04009E13 RID: 40467
	private int ItemIndexInternal;

	// Token: 0x02008BC9 RID: 35785
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F18C RID: 192908
		WeaponItem,
		// Token: 0x0402F18D RID: 192909
		WeaponName,
		// Token: 0x0402F18E RID: 192910
		BtnCall,
		// Token: 0x0402F18F RID: 192911
		BtnJump,
		// Token: 0x0402F190 RID: 192912
		PanelNotObtained,
		// Token: 0x0402F191 RID: 192913
		TxtNotObtained,
		// Token: 0x0402F192 RID: 192914
		BtnMoonCard,
		// Token: 0x0402F193 RID: 192915
		PanelStateGreen
	}
}
