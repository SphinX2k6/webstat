using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleDev;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200282C RID: 10284
[NullableContext(1)]
[Nullable(0)]
public class RoleDevRootView : UiViewBase
{
	// Token: 0x0601459E RID: 83358 RVA: 0x005A90CA File Offset: 0x005A72CA
	public RoleDevRootView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601459F RID: 83359 RVA: 0x005A90F0 File Offset: 0x005A72F0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 23;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIGridLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIGridLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIExtendToggle));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(22, new Action<EToggleState>(this.OnClickToggleRoleMark));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060145A0 RID: 83360 RVA: 0x005A945C File Offset: 0x005A765C
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RoleDevTargetRoleIdChange, new Action(this.OnRoleDevTargetRoleIdChange));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleSystemChangeRole, new Action<int>(this.OnRoleSelect));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<IProto_NormalItem>>(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
	}

	// Token: 0x060145A1 RID: 83361 RVA: 0x005A94C0 File Offset: 0x005A76C0
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RoleSystemChangeRole, new Action<int>(this.OnRoleSelect));
		Singleton<EventSystem>.Instance.Remove(EEventName.RoleDevTargetRoleIdChange, new Action(this.OnRoleDevTargetRoleIdChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddCommonItemList, new Action<IReadOnlyList<IProto_NormalItem>>(this.OnAddCommonItemList));
	}

	// Token: 0x060145A2 RID: 83362 RVA: 0x005A9524 File Offset: 0x005A7724
	protected override UniTask OnBeforeStartAsync()
	{
		RoleDevRootView.<OnBeforeStartAsync>d__25 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevRootView.<OnBeforeStartAsync>d__25>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060145A3 RID: 83363 RVA: 0x005A9567 File Offset: 0x005A7767
	protected override void OnStart()
	{
		this.HideRoleUiModel();
	}

	// Token: 0x060145A4 RID: 83364 RVA: 0x005A9570 File Offset: 0x005A7770
	protected override UniTask OnBeforeShowAsyncImplementImplement()
	{
		RoleDevRootView.<OnBeforeShowAsyncImplementImplement>d__27 <OnBeforeShowAsyncImplementImplement>d__;
		<OnBeforeShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplementImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplementImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Start<RoleDevRootView.<OnBeforeShowAsyncImplementImplement>d__27>(ref <OnBeforeShowAsyncImplementImplement>d__);
		return <OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Task;
	}

	// Token: 0x060145A5 RID: 83365 RVA: 0x005A95B4 File Offset: 0x005A77B4
	private void ShowRoleUiModel()
	{
		TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
		if (roleSystemRoleActor == null)
		{
			return;
		}
		Singleton<UiModelUtil>.Instance.SetVisible(roleSystemRoleActor.Model, true);
		Singleton<UiModelUtil>.Instance.ModelFadeOut(roleSystemRoleActor.Model, new ERoleFadeCurveDefine?(ERoleFadeCurveDefine.TerminalSkinRoleFadeOutCurve), null);
	}

	// Token: 0x060145A6 RID: 83366 RVA: 0x005A9600 File Offset: 0x005A7800
	private void HideRoleUiModel()
	{
		TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
		if (roleSystemRoleActor == null)
		{
			return;
		}
		Singleton<UiModelUtil>.Instance.SetDitherEffect(roleSystemRoleActor.Model, 0f);
		Singleton<UiModelUtil>.Instance.SetVisible(roleSystemRoleActor.Model, false);
	}

	// Token: 0x060145A7 RID: 83367 RVA: 0x005A9644 File Offset: 0x005A7844
	private UniTask InitializeDevelopTagItem()
	{
		RoleDevRootView.<InitializeDevelopTagItem>d__30 <InitializeDevelopTagItem>d__;
		<InitializeDevelopTagItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeDevelopTagItem>d__.<>4__this = this;
		<InitializeDevelopTagItem>d__.<>1__state = -1;
		<InitializeDevelopTagItem>d__.<>t__builder.Start<RoleDevRootView.<InitializeDevelopTagItem>d__30>(ref <InitializeDevelopTagItem>d__);
		return <InitializeDevelopTagItem>d__.<>t__builder.Task;
	}

	// Token: 0x060145A8 RID: 83368 RVA: 0x005A9688 File Offset: 0x005A7888
	private UniTask InitializeElementSuitItem()
	{
		RoleDevRootView.<InitializeElementSuitItem>d__31 <InitializeElementSuitItem>d__;
		<InitializeElementSuitItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeElementSuitItem>d__.<>4__this = this;
		<InitializeElementSuitItem>d__.<>1__state = -1;
		<InitializeElementSuitItem>d__.<>t__builder.Start<RoleDevRootView.<InitializeElementSuitItem>d__31>(ref <InitializeElementSuitItem>d__);
		return <InitializeElementSuitItem>d__.<>t__builder.Task;
	}

	// Token: 0x060145A9 RID: 83369 RVA: 0x005A96CC File Offset: 0x005A78CC
	private void OnRoleDevTargetRoleIdChange()
	{
		int devTargetRoleId = ModelBase<RoleDevModel>.Instance.DevTargetRoleId;
		int tempRoleMarkRoleId = this.TempRoleMarkRoleId;
		if (devTargetRoleId != 0 && tempRoleMarkRoleId != devTargetRoleId)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RoleProject_Tips11", Array.Empty<object>());
		}
		else if (devTargetRoleId == 0 && tempRoleMarkRoleId != 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RoleProject_Tips13", Array.Empty<object>());
		}
		this.SetTempRoleMarkRoleId(devTargetRoleId);
		this.RefreshRoleMarkToggle(this.CurSelectRoleId);
		this.ConfigRoleLayout.RefreshWithoutDataSync();
	}

	// Token: 0x060145AA RID: 83370 RVA: 0x005A9740 File Offset: 0x005A7940
	protected void OnRoleSelect(int i)
	{
		this.RefreshCurrentTabView();
	}

	// Token: 0x060145AB RID: 83371 RVA: 0x005A9748 File Offset: 0x005A7948
	private void OnAddCommonItemList(IReadOnlyList<IProto_NormalItem> _)
	{
		this.UpdateTabList();
		this.RefreshCurrentTabView();
	}

	// Token: 0x060145AC RID: 83372 RVA: 0x005A9756 File Offset: 0x005A7956
	private RoleDevMediumItemGrid OnGridProxyCreate()
	{
		RoleDevMediumItemGrid roleDevMediumItemGrid = new RoleDevMediumItemGrid();
		roleDevMediumItemGrid.BindOnExtendToggleStateChanged(delegate(MediumItemGridExtendCallback callbackParameter)
		{
			EToggleState state = callbackParameter.State;
			RoleDataBase data = callbackParameter.Data as RoleDataBase;
			this.OnRoleItemToggleChanged(state, data);
		});
		roleDevMediumItemGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanExecuteChangeFunctionForOwn));
		return roleDevMediumItemGrid;
	}

	// Token: 0x060145AD RID: 83373 RVA: 0x005A9784 File Offset: 0x005A7984
	private UniTask InitializeCaption()
	{
		RoleDevRootView.<InitializeCaption>d__36 <InitializeCaption>d__;
		<InitializeCaption>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeCaption>d__.<>4__this = this;
		<InitializeCaption>d__.<>1__state = -1;
		<InitializeCaption>d__.<>t__builder.Start<RoleDevRootView.<InitializeCaption>d__36>(ref <InitializeCaption>d__);
		return <InitializeCaption>d__.<>t__builder.Task;
	}

	// Token: 0x060145AE RID: 83374 RVA: 0x005A97C7 File Offset: 0x005A79C7
	private void OnBackButtonClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x060145AF RID: 83375 RVA: 0x005A97D0 File Offset: 0x005A79D0
	private UniTask InitializeLayouts()
	{
		RoleDevRootView.<InitializeLayouts>d__38 <InitializeLayouts>d__;
		<InitializeLayouts>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitializeLayouts>d__.<>4__this = this;
		<InitializeLayouts>d__.<>1__state = -1;
		<InitializeLayouts>d__.<>t__builder.Start<RoleDevRootView.<InitializeLayouts>d__38>(ref <InitializeLayouts>d__);
		return <InitializeLayouts>d__.<>t__builder.Task;
	}

	// Token: 0x060145B0 RID: 83376 RVA: 0x005A9813 File Offset: 0x005A7A13
	private void OnChangeFetterGroupSuccessCallBack(int roleId, int fetterGroupId)
	{
		RoleDevPhantomViewItemDataBase roleDevPhantomViewItemData = this.RoleDevViewModelInstance.RoleDevPhantomViewItemData;
		if (roleDevPhantomViewItemData != null)
		{
			roleDevPhantomViewItemData.RefreshSuitDataList();
		}
		this.RefreshCurrentTabView();
	}

	// Token: 0x060145B1 RID: 83377 RVA: 0x005A9834 File Offset: 0x005A7A34
	private UniTask InitTabListAsync()
	{
		RoleDevRootView.<InitTabListAsync>d__40 <InitTabListAsync>d__;
		<InitTabListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitTabListAsync>d__.<>4__this = this;
		<InitTabListAsync>d__.<>1__state = -1;
		<InitTabListAsync>d__.<>t__builder.Start<RoleDevRootView.<InitTabListAsync>d__40>(ref <InitTabListAsync>d__);
		return <InitTabListAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060145B2 RID: 83378 RVA: 0x005A9878 File Offset: 0x005A7A78
	private void UpdateTabList()
	{
		RoleDevRoleViewItemDataBase roleDevRoleViewItemData = this.RoleDevViewModelInstance.RoleDevRoleViewItemData;
		RoleDevWeaponViewItemDataBase roleDevWeaponViewItemData = this.RoleDevViewModelInstance.RoleDevWeaponViewItemData;
		RoleDevSkillViewItemDataBase roleDevSkillViewItemData = this.RoleDevViewModelInstance.RoleDevSkillViewItemData;
		bool flag = RoleDevUtils.GetRoleTypeTagByRoleId(this.CurSelectRoleId) == global::ERoleTypeTag.Forecast;
		bool flag2 = ModelBase<RoleModel>.Instance.IsRoleOwned(this.CurSelectRoleId);
		bool flag3 = flag || !flag2;
		foreach (global::IRoleDevRootTabData roleDevRootTabData in this.TabDataList)
		{
			switch (roleDevRootTabData.TabIndex)
			{
			case global::ERoleDevTabType.Role:
				roleDevRootTabData.TabIsUpgrade = (!flag3 && roleDevRoleViewItemData.IsAllMaterialEnough);
				roleDevRootTabData.TabIsFinish = (!flag3 && roleDevRoleViewItemData.IsFinish);
				break;
			case global::ERoleDevTabType.Weapon:
				roleDevRootTabData.TabIsUpgrade = (!flag3 && roleDevWeaponViewItemData.DevItemData.IsAllMaterialEnough && roleDevWeaponViewItemData.IsWeaponHighQuality);
				roleDevRootTabData.TabIsFinish = (!flag3 && roleDevWeaponViewItemData.DevItemData.IsFinish);
				break;
			case global::ERoleDevTabType.Phantom:
				roleDevRootTabData.TabIsUpgrade = false;
				roleDevRootTabData.TabIsFinish = false;
				break;
			case global::ERoleDevTabType.Skill:
				roleDevRootTabData.TabIsUpgrade = (!flag3 && roleDevSkillViewItemData.IsCurrentPlanAllMaterialEnough);
				roleDevRootTabData.TabIsFinish = (!flag3 && roleDevSkillViewItemData.IsPerfectPlanFinished);
				break;
			}
		}
		this.TabItemLayout.RefreshWithoutDataSync();
	}

	// Token: 0x060145B3 RID: 83379 RVA: 0x005A99EC File Offset: 0x005A7BEC
	private RoleDevSelectionMediumItemGrid InitNewRoleItem()
	{
		RoleDevSelectionMediumItemGrid roleDevSelectionMediumItemGrid = new RoleDevSelectionMediumItemGrid();
		roleDevSelectionMediumItemGrid.BindOnExtendToggleStateChanged(delegate(MediumItemGridExtendCallback callbackParameter)
		{
			EToggleState state = callbackParameter.State;
			RoleDisplayModelBase data = callbackParameter.Data as RoleDisplayModelBase;
			this.OnNewRoleItemToggleChanged(state, data);
		});
		roleDevSelectionMediumItemGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanExecuteChangeFunctionForNew));
		return roleDevSelectionMediumItemGrid;
	}

	// Token: 0x060145B4 RID: 83380 RVA: 0x005A9A17 File Offset: 0x005A7C17
	private void OnPlanChangeCallback(RoleDevSkillViewItemDataBase data)
	{
		this.UpdateTabList();
	}

	// Token: 0x060145B5 RID: 83381 RVA: 0x005A9A20 File Offset: 0x005A7C20
	private void UpdateList(List<RoleDataBase> list, bool isOutSideChange, EFilterSortType operationType)
	{
		List<RoleDataBase> list2 = this.SortPinnedRolesToFront(list);
		this.RoleDevViewModelInstance.SetRoleDataList(list2);
		this.RestoreOwnListSelection(list2, isOutSideChange, operationType);
	}

	// Token: 0x060145B6 RID: 83382 RVA: 0x005A9A4C File Offset: 0x005A7C4C
	private List<RoleDataBase> SortPinnedRolesToFront(List<RoleDataBase> roleList)
	{
		int devTargetRoleId = ModelBase<RoleDevModel>.Instance.DevTargetRoleId;
		if (devTargetRoleId == 0)
		{
			return roleList;
		}
		List<RoleDataBase> list = new List<RoleDataBase>();
		List<RoleDataBase> list2 = new List<RoleDataBase>();
		foreach (RoleDataBase roleDataBase in roleList)
		{
			if (roleDataBase.GetRoleId() == devTargetRoleId)
			{
				list.Add(roleDataBase);
			}
			else
			{
				list2.Add(roleDataBase);
			}
		}
		List<RoleDataBase> list3 = new List<RoleDataBase>();
		list3.AddRange(list);
		list3.AddRange(list2);
		return list3;
	}

	// Token: 0x060145B7 RID: 83383 RVA: 0x005A9AE4 File Offset: 0x005A7CE4
	private void RestoreOwnListSelection(List<RoleDataBase> roleList, bool isOutSideChange, EFilterSortType operationType)
	{
		if (this.FilterSortEntranceRefreshLock)
		{
			return;
		}
		this.ConfigRoleLayout.RefreshByData(roleList, delegate
		{
			if (this.CurSelectRoleListType == global::ERoleListType.OwnList)
			{
				this.ConfigRoleLayout.SelectGridProxyByKey(this.CurSelectRoleId, false);
			}
		}, true);
	}

	// Token: 0x060145B8 RID: 83384 RVA: 0x005A9B08 File Offset: 0x005A7D08
	private global::ERoleDevTabType GetTargetTabType()
	{
		if (!ModelBase<RoleModel>.Instance.IsRoleOwned(this.CurSelectRoleId))
		{
			return global::ERoleDevTabType.Role;
		}
		if (this.RoleDevViewModelInstance.RoleDevRoleViewItemData == null || !this.RoleDevViewModelInstance.RoleDevRoleViewItemData.RoleLevelIsMax)
		{
			return global::ERoleDevTabType.Role;
		}
		if (this.RoleDevViewModelInstance.RoleDevWeaponViewItemData == null || !this.RoleDevViewModelInstance.RoleDevWeaponViewItemData.DevItemData.WeaponIsMaxLevel)
		{
			return global::ERoleDevTabType.Weapon;
		}
		return global::ERoleDevTabType.Phantom;
	}

	// Token: 0x060145B9 RID: 83385 RVA: 0x005A9B74 File Offset: 0x005A7D74
	private void UpdatePropertyText(int roleId)
	{
		UUIText text = base.GetText(9);
		if (RoleDevUtils.GetRoleTypeTagByRoleId(roleId) == global::ERoleTypeTag.Forecast)
		{
			if (text != null)
			{
				text.SetUIActive(false);
			}
			return;
		}
		RoleDevProject? roleDevProjectConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProjectConfig(roleId);
		if (roleDevProjectConfig == null || roleDevProjectConfig.Value.KeyProperty == 0)
		{
			if (text != null)
			{
				text.SetUIActive(false);
			}
			return;
		}
		PropertyIndex? propertyIndexConfigByIndex = ConfigBase<RoleDevConfig>.Instance.GetPropertyIndexConfigByIndex(roleDevProjectConfig.Value.KeyProperty);
		if (text != null)
		{
			text.SetUIActive(true);
		}
		string text2;
		if (roleDevProjectConfig.Value.PropertyValue(0) != 1)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<double>((double)roleDevProjectConfig.Value.PropertyValue(1) / 100.0, "F1");
			defaultInterpolatedStringHandler.AppendLiteral("%");
			text2 = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		else
		{
			text2 = roleDevProjectConfig.Value.PropertyValue(1).ToString();
		}
		string str = text2;
		string text3 = ConfigMultiTextLang.GetLocalTextNew(propertyIndexConfigByIndex.Value.Name, null) + " " + str;
		string newText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("RoleProject_TargetProperty", null), new string[]
		{
			text3
		});
		if (text != null)
		{
			text.SetText(newText, true);
		}
	}

	// Token: 0x060145BA RID: 83386 RVA: 0x005A9CB8 File Offset: 0x005A7EB8
	private void SelectRoleByRoleDataBase(RoleDataBase roleData)
	{
		this.SelectRole(roleData.GetRoleConfig().Id, global::ERoleListType.OwnList);
	}

	// Token: 0x060145BB RID: 83387 RVA: 0x005A9CDA File Offset: 0x005A7EDA
	private void SelectRoleByDisplayModelData(RoleDisplayModelBase roleData)
	{
		this.SelectRole(roleData.Id, global::ERoleListType.NewList);
	}

	// Token: 0x060145BC RID: 83388 RVA: 0x005A9CEC File Offset: 0x005A7EEC
	private void SelectRole(int roleId, global::ERoleListType listType)
	{
		if (listType == global::ERoleListType.OwnList)
		{
			this.ConfigRoleLayout.SelectGridProxyByKey(roleId, false);
		}
		else if (this.RoleDevViewModelInstance.HotRoleDataList.FindIndex((RoleDisplayModelBase data) => data.Id == roleId) != -1)
		{
			this.NewRoleLayout.SelectGridProxyByKey(roleId, false);
		}
		this.UpdateRoleViewAfterSelect(roleId, listType);
		this.UpdateTabList();
		this.UpdateTabStates(this.CurSelectTab);
		this.SelectTabByTabType(this.CurSelectTab);
	}

	// Token: 0x060145BD RID: 83389 RVA: 0x005A9D84 File Offset: 0x005A7F84
	private void SetDevelopTag(int roleId, global::ERoleListType listType)
	{
		if (this.DevelopTagItem == null)
		{
			return;
		}
		global::ERoleTypeTag data;
		if (listType == global::ERoleListType.OwnList)
		{
			data = RoleDevUtils.GetRoleTypeTagByRoleId(roleId);
		}
		else
		{
			RoleDisplayModelBase roleDisplayModelBase = this.RoleDevViewModelInstance.HotRoleDataList.Find((RoleDisplayModelBase model) => model.Id == roleId);
			data = ((roleDisplayModelBase != null) ? roleDisplayModelBase.TypeTag : global::ERoleTypeTag.None);
		}
		this.DevelopTagItem.SetData(data);
	}

	// Token: 0x060145BE RID: 83390 RVA: 0x005A9DEF File Offset: 0x005A7FEF
	private void UpdateRoleViewAfterSelect(int roleId, global::ERoleListType listType)
	{
		this.SetRoleData(roleId, listType);
		this.RefreshRoleName(roleId);
		this.RefreshRoleTexture(roleId);
		this.RefreshElementIcon(roleId);
		this.SetDevelopTag(roleId, listType);
		this.UpdatePropertyText(roleId);
		this.RefreshRoleMarkToggle(roleId);
		this.RefreshCurrentTabView();
	}

	// Token: 0x060145BF RID: 83391 RVA: 0x005A9E2C File Offset: 0x005A802C
	private void RefreshRoleMarkToggle(int roleId)
	{
		this.RefreshRoleMarkToggleActive(roleId);
		this.RefreshRoleMarkToggleByTempData(null);
	}

	// Token: 0x060145C0 RID: 83392 RVA: 0x005A9E50 File Offset: 0x005A8050
	private void RefreshCurrentTabView()
	{
		switch (this.CurSelectTab)
		{
		case global::ERoleDevTabType.Role:
		{
			RoleDevRoleViewItemDataBase roleDevRoleViewItemData = this.RoleDevViewModelInstance.RoleDevRoleViewItemData;
			if (roleDevRoleViewItemData != null)
			{
				RoleDevRoleViewItem roleViewItem = this.RoleViewItem;
				if (roleViewItem == null)
				{
					return;
				}
				roleViewItem.Refresh(roleDevRoleViewItemData);
				return;
			}
			break;
		}
		case global::ERoleDevTabType.Weapon:
		{
			RoleDevWeaponViewItemDataBase roleDevWeaponViewItemData = this.RoleDevViewModelInstance.RoleDevWeaponViewItemData;
			if (roleDevWeaponViewItemData != null)
			{
				RoleDevWeaponViewItem weaponViewItem = this.WeaponViewItem;
				if (weaponViewItem == null)
				{
					return;
				}
				weaponViewItem.RefreshByData(roleDevWeaponViewItemData);
				return;
			}
			break;
		}
		case global::ERoleDevTabType.Phantom:
		{
			RoleDevPhantomViewItemDataBase roleDevPhantomViewItemData = this.RoleDevViewModelInstance.RoleDevPhantomViewItemData;
			if (roleDevPhantomViewItemData != null)
			{
				RoleDevPhantomViewItem phantomViewItem = this.PhantomViewItem;
				if (phantomViewItem == null)
				{
					return;
				}
				phantomViewItem.Refresh(roleDevPhantomViewItemData);
				return;
			}
			break;
		}
		case global::ERoleDevTabType.Skill:
		{
			RoleDevSkillViewItemDataBase roleDevSkillViewItemData = this.RoleDevViewModelInstance.RoleDevSkillViewItemData;
			if (roleDevSkillViewItemData != null)
			{
				RoleDevSkillViewItem skillViewItem = this.SkillViewItem;
				if (skillViewItem == null)
				{
					return;
				}
				skillViewItem.Refresh(roleDevSkillViewItemData);
			}
			break;
		}
		default:
			return;
		}
	}

	// Token: 0x060145C1 RID: 83393 RVA: 0x005A9F01 File Offset: 0x005A8101
	private void SetRoleData(int roleId, global::ERoleListType type)
	{
		this.SetCurSelectRoleId(roleId);
		this.RoleDevViewModelInstance.InitAllDevItemDataByRoleId(roleId);
	}

	// Token: 0x060145C2 RID: 83394 RVA: 0x005A9F18 File Offset: 0x005A8118
	private void OnRoleItemToggleChanged(EToggleState state, RoleDataBase data)
	{
		if (state == EToggleState.ETT_Checked)
		{
			int id = data.GetRoleConfig().Id;
			GenericLayout<RoleDevSelectionMediumItemGrid, RoleDisplayModelBase> newRoleLayout = this.NewRoleLayout;
			if (newRoleLayout != null)
			{
				newRoleLayout.DeselectCurrentGridProxy();
			}
			GenericLayout<RoleDevMediumItemGrid, RoleDataBase> configRoleLayout = this.ConfigRoleLayout;
			if (configRoleLayout != null)
			{
				configRoleLayout.DeselectCurrentGridProxy();
			}
			this.SelectRoleInLayout(id, global::ERoleListType.OwnList);
			this.PlayTabItemAnimation(this.CurSelectTab);
			this.UiViewSequence.PlayOrReplaySequenceByName("Switch", false, null);
		}
	}

	// Token: 0x060145C3 RID: 83395 RVA: 0x005A9F88 File Offset: 0x005A8188
	private void OnNewRoleItemToggleChanged(EToggleState state, RoleDisplayModelBase data)
	{
		if (state == EToggleState.ETT_Checked)
		{
			int id = data.Id;
			GenericLayout<RoleDevSelectionMediumItemGrid, RoleDisplayModelBase> newRoleLayout = this.NewRoleLayout;
			if (newRoleLayout != null)
			{
				newRoleLayout.DeselectCurrentGridProxy();
			}
			GenericLayout<RoleDevMediumItemGrid, RoleDataBase> configRoleLayout = this.ConfigRoleLayout;
			if (configRoleLayout != null)
			{
				configRoleLayout.DeselectCurrentGridProxy();
			}
			this.SelectRoleInLayout(id, global::ERoleListType.NewList);
			this.PlayTabItemAnimation(this.CurSelectTab);
			this.UiViewSequence.PlayOrReplaySequenceByName("Switch", false, null);
		}
	}

	// Token: 0x060145C4 RID: 83396 RVA: 0x005A9FF0 File Offset: 0x005A81F0
	private void SelectRoleInLayout(int roleId, global::ERoleListType fromListType)
	{
		this.SetCurSelectRoleId(roleId);
		this.SetCurSelectRoleListType(fromListType);
		if (fromListType == global::ERoleListType.OwnList)
		{
			RoleDataBase roleDataBase = this.RoleDevViewModelInstance.RoleDataList.Find((RoleDataBase data) => data.GetRoleConfig().Id == roleId);
			if (roleDataBase != null)
			{
				this.SelectRoleByRoleDataBase(roleDataBase);
				return;
			}
		}
		else
		{
			RoleDisplayModelBase roleDisplayModelBase = this.RoleDevViewModelInstance.HotRoleDataList.Find((RoleDisplayModelBase model) => model.Id == roleId);
			if (roleDisplayModelBase != null)
			{
				this.SelectRoleByDisplayModelData(roleDisplayModelBase);
			}
		}
	}

	// Token: 0x060145C5 RID: 83397 RVA: 0x005AA070 File Offset: 0x005A8270
	private bool CanExecuteChangeFunctionForOwn(object data, bool isForceSelected, EToggleState state)
	{
		int id = (data as RoleDataBase).GetRoleConfig().Id;
		return state != EToggleState.ETT_Checked || this.CurSelectRoleListType != global::ERoleListType.OwnList || this.CurSelectRoleId != id;
	}

	// Token: 0x060145C6 RID: 83398 RVA: 0x005AA0AC File Offset: 0x005A82AC
	private bool CanExecuteChangeFunctionForNew(object data, bool isForceSelected, EToggleState state)
	{
		int id = (data as RoleDisplayModelBase).Id;
		return state != EToggleState.ETT_Checked || this.CurSelectRoleListType != global::ERoleListType.NewList || this.CurSelectRoleId != id;
	}

	// Token: 0x060145C7 RID: 83399 RVA: 0x005AA0E0 File Offset: 0x005A82E0
	private RoleDevRootTabItem InitTabItem()
	{
		RoleDevRootTabItem roleDevRootTabItem = new RoleDevRootTabItem();
		roleDevRootTabItem.OnClickToggleCallBack = new Action<int>(this.OnClickTabItem);
		roleDevRootTabItem.CanClickCallBack = new Func<int, EToggleState, bool>(this.CanClickTabItem);
		this.TabItems.Add(roleDevRootTabItem);
		return roleDevRootTabItem;
	}

	// Token: 0x060145C8 RID: 83400 RVA: 0x005AA124 File Offset: 0x005A8324
	private void OnClickTabItem(int tabType)
	{
		this.SelectTabByTabType((global::ERoleDevTabType)tabType);
		this.PlayTabItemAnimation((global::ERoleDevTabType)tabType);
	}

	// Token: 0x060145C9 RID: 83401 RVA: 0x005AA134 File Offset: 0x005A8334
	private bool CanClickTabItem(int tabType, EToggleState toggleState)
	{
		return this.CurSelectTabInternal == null || tabType != (int)this.CurSelectTabInternal.Value || toggleState != EToggleState.ETT_Checked;
	}

	// Token: 0x060145CA RID: 83402 RVA: 0x005AA15C File Offset: 0x005A835C
	private void SelectTabByTabType(global::ERoleDevTabType tabType)
	{
		this.SetCurSelectTab((int)tabType);
		this.RefreshTabPanel(tabType);
		ERoleDevMainPage mainPage = RoleDevDefine.tabTypeToMainPageMap[(CSharpScript.Game.Module.RoleDev.ERoleDevTabType)tabType];
		ControllerBase<RoleDevController>.Instance.LogRoleDevPageClick(this.CurSelectRoleId, mainPage);
	}

	// Token: 0x060145CB RID: 83403 RVA: 0x005AA194 File Offset: 0x005A8394
	private void PlayTabItemAnimation(global::ERoleDevTabType tabType)
	{
		switch (tabType)
		{
		case global::ERoleDevTabType.Role:
			this.PlayRoleViewAnimation();
			return;
		case global::ERoleDevTabType.Weapon:
			this.PlayWeaponViewAnimation();
			return;
		case global::ERoleDevTabType.Phantom:
			this.PlayPhantomViewAnimation();
			return;
		case global::ERoleDevTabType.Skill:
			this.PlaySkillViewAnimation();
			return;
		default:
			return;
		}
	}

	// Token: 0x060145CC RID: 83404 RVA: 0x005AA1C8 File Offset: 0x005A83C8
	private void PlayRoleViewAnimation()
	{
		RoleDevRoleViewItem roleViewItem = this.RoleViewItem;
		if (roleViewItem == null)
		{
			return;
		}
		UiBehaviorLevelSequence uiViewSequence = roleViewItem.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlayOrReplaySequenceByName("Start", false, null);
	}

	// Token: 0x060145CD RID: 83405 RVA: 0x005AA200 File Offset: 0x005A8400
	private void PlayWeaponViewAnimation()
	{
		RoleDevWeaponViewItem weaponViewItem = this.WeaponViewItem;
		if (weaponViewItem == null)
		{
			return;
		}
		UiBehaviorLevelSequence uiViewSequence = weaponViewItem.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlayOrReplaySequenceByName("Start", false, null);
	}

	// Token: 0x060145CE RID: 83406 RVA: 0x005AA238 File Offset: 0x005A8438
	private void PlayPhantomViewAnimation()
	{
		RoleDevPhantomViewItem phantomViewItem = this.PhantomViewItem;
		if (phantomViewItem == null)
		{
			return;
		}
		UiBehaviorLevelSequence uiViewSequence = phantomViewItem.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlayOrReplaySequenceByName("Start", false, null);
	}

	// Token: 0x060145CF RID: 83407 RVA: 0x005AA270 File Offset: 0x005A8470
	private void PlaySkillViewAnimation()
	{
		RoleDevSkillViewItem skillViewItem = this.SkillViewItem;
		if (skillViewItem == null)
		{
			return;
		}
		UiBehaviorLevelSequence uiViewSequence = skillViewItem.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlayOrReplaySequenceByName("Start", false, null);
	}

	// Token: 0x060145D0 RID: 83408 RVA: 0x005AA2A6 File Offset: 0x005A84A6
	private void RefreshTabPanel(global::ERoleDevTabType index)
	{
		this.UpdateTabStates(index);
		this.RefreshContentByTab();
	}

	// Token: 0x060145D1 RID: 83409 RVA: 0x005AA2B5 File Offset: 0x005A84B5
	private void UpdateTabStates(global::ERoleDevTabType activeIndex)
	{
		GenericLayout<RoleDevRootTabItem, global::IRoleDevRootTabData> tabItemLayout = this.TabItemLayout;
		if (tabItemLayout == null)
		{
			return;
		}
		tabItemLayout.SelectGridProxy((int)activeIndex, false);
	}

	// Token: 0x060145D2 RID: 83410 RVA: 0x005AA2CC File Offset: 0x005A84CC
	private void RefreshContentByTab()
	{
		bool flag = RoleDevUtils.GetRoleTypeTagByRoleId(this.CurSelectRoleId) == global::ERoleTypeTag.Forecast;
		base.GetItem(21).SetUIActive(!flag);
		global::ERoleDevTabType curSelectTab = this.CurSelectTab;
		bool flag2 = curSelectTab == global::ERoleDevTabType.Role;
		base.GetItem(13).SetUIActive(flag2);
		base.GetItem(14).SetUIActive(flag2);
		RoleDevRoleViewItem roleViewItem = this.RoleViewItem;
		if (roleViewItem != null)
		{
			roleViewItem.SetUiActive(flag2);
		}
		bool flag3 = curSelectTab == global::ERoleDevTabType.Weapon;
		base.GetItem(17).SetUIActive(flag3);
		base.GetItem(18).SetUIActive(flag3);
		RoleDevWeaponViewItem weaponViewItem = this.WeaponViewItem;
		if (weaponViewItem != null)
		{
			weaponViewItem.SetUiActive(flag3);
		}
		bool flag4 = curSelectTab == global::ERoleDevTabType.Phantom;
		if (flag && flag4)
		{
			base.GetItem(19).SetUIActive(false);
			base.GetItem(20).SetUIActive(false);
			RoleDevPhantomViewItem phantomViewItem = this.PhantomViewItem;
			if (phantomViewItem != null)
			{
				phantomViewItem.SetUiActive(false);
			}
			base.GetItem(21).SetUIActive(true);
		}
		else
		{
			base.GetItem(19).SetUIActive(flag4);
			base.GetItem(20).SetUIActive(flag4);
			RoleDevPhantomViewItem phantomViewItem2 = this.PhantomViewItem;
			if (phantomViewItem2 != null)
			{
				phantomViewItem2.SetUiActive(flag4);
			}
			base.GetItem(21).SetUIActive(false);
		}
		bool flag5 = curSelectTab == global::ERoleDevTabType.Skill;
		base.GetItem(15).SetUIActive(flag5);
		base.GetItem(16).SetUIActive(flag5);
		RoleDevSkillViewItem skillViewItem = this.SkillViewItem;
		if (skillViewItem != null)
		{
			skillViewItem.SetUiActive(flag5);
		}
		this.RefreshCurrentTabView();
	}

	// Token: 0x060145D3 RID: 83411 RVA: 0x005AA428 File Offset: 0x005A8628
	private void RefreshRoleName(int roleId)
	{
		if (RoleDevUtils.GetRoleTypeTagByRoleId(roleId) == global::ERoleTypeTag.Forecast)
		{
			IRoleDevProsProjectConfig roleDevProsProjectConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(roleId);
			base.GetText(6).SetText(roleDevProsProjectConfig.RoleName, true);
			return;
		}
		RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), value.Name, Array.Empty<object>());
	}

	// Token: 0x060145D4 RID: 83412 RVA: 0x005AA494 File Offset: 0x005A8694
	private void RefreshRoleTexture(int roleId)
	{
		UUITexture texture = base.GetTexture(5);
		if (RoleDevUtils.GetRoleTypeTagByRoleId(roleId) == global::ERoleTypeTag.Forecast)
		{
			string roleHeadIconSmall = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(roleId).RoleHeadIconSmall;
			base.SetTextureByPath(roleHeadIconSmall, texture, null, null);
			return;
		}
		RoleInfo value = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value;
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId);
		int value2 = (roleInstanceById != null) ? roleInstanceById.GetRoleSkinId() : 0;
		base.SetRoleIconByRoleIdOrSkinId(value.RoleHeadIcon, texture, roleId, new int?(value2), null, null);
	}

	// Token: 0x060145D5 RID: 83413 RVA: 0x005AA528 File Offset: 0x005A8728
	private void RefreshRoleMarkToggleActive(int roleId)
	{
		bool uiactive = ModelBase<RoleModel>.Instance.IsRoleOwned(roleId);
		base.GetExtendToggle(22).RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x060145D6 RID: 83414 RVA: 0x005AA55C File Offset: 0x005A875C
	private void OnClickToggleRoleMark(EToggleState toggleState)
	{
		int curSelectRoleId = this.CurSelectRoleId;
		if (ModelBase<RoleModel>.Instance.IsRoleOwned(curSelectRoleId))
		{
			int num;
			if (this.TempRoleMarkRoleId == curSelectRoleId)
			{
				num = 0;
			}
			else
			{
				num = curSelectRoleId;
			}
			ControllerBase<RoleDevController>.Instance.RequestRecordRoleMarkOperation(num);
			this.RefreshRoleMarkToggleByTempData(new int?(num));
		}
	}

	// Token: 0x060145D7 RID: 83415 RVA: 0x005AA5A5 File Offset: 0x005A87A5
	private void SetTempRoleMarkRoleId(int roleId)
	{
		this.TempRoleMarkRoleIdInternal = roleId;
	}

	// Token: 0x060145D8 RID: 83416 RVA: 0x005AA5B0 File Offset: 0x005A87B0
	private void RefreshRoleMarkToggleByTempData(int? expectedMarkRoleId = null)
	{
		int curSelectRoleId = this.CurSelectRoleId;
		this.SetRoleMarkToggleState(((expectedMarkRoleId ?? this.TempRoleMarkRoleId) == curSelectRoleId) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked);
	}

	// Token: 0x060145D9 RID: 83417 RVA: 0x005AA5EF File Offset: 0x005A87EF
	private void SetRoleMarkToggleState(EToggleState state)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(22);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(state, false, false, false);
	}

	// Token: 0x060145DA RID: 83418 RVA: 0x005AA608 File Offset: 0x005A8808
	private void RefreshElementIcon(int roleId)
	{
		if (RoleDevUtils.GetRoleTypeTagByRoleId(roleId) != global::ERoleTypeTag.Forecast)
		{
			int elementId = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId).Value.ElementId;
			CommonElementItem elementSuitItem = this.ElementSuitItem;
			if (elementSuitItem == null)
			{
				return;
			}
			elementSuitItem.Refresh(elementId, false, 0);
			return;
		}
		else
		{
			int elementId2 = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProsProjectConfig(roleId).ElementId;
			CommonElementItem elementSuitItem2 = this.ElementSuitItem;
			if (elementSuitItem2 == null)
			{
				return;
			}
			elementSuitItem2.Refresh(elementId2, false, 0);
			return;
		}
	}

	// Token: 0x060145DB RID: 83419 RVA: 0x005AA674 File Offset: 0x005A8874
	public void SetCurSelectRoleId(int roleId)
	{
		this.CurSelectRoleIdInternal = roleId;
	}

	// Token: 0x060145DC RID: 83420 RVA: 0x005AA67D File Offset: 0x005A887D
	public void SetCurSelectTab(int value)
	{
		this.CurSelectTabInternal = new global::ERoleDevTabType?((global::ERoleDevTabType)value);
	}

	// Token: 0x060145DD RID: 83421 RVA: 0x005AA68B File Offset: 0x005A888B
	public void SetCurSelectRoleListType(global::ERoleListType value)
	{
		this.CurSelectRoleListTypeInternal = value;
	}

	// Token: 0x060145DE RID: 83422 RVA: 0x005AA694 File Offset: 0x005A8894
	public void SetIsFirstEnter(bool value)
	{
		this.IsFirstEnterInternal = value;
	}

	// Token: 0x17001A59 RID: 6745
	// (get) Token: 0x060145DF RID: 83423 RVA: 0x005AA69D File Offset: 0x005A889D
	public global::ERoleDevTabType CurSelectTab
	{
		get
		{
			return this.CurSelectTabInternal.Value;
		}
	}

	// Token: 0x17001A5A RID: 6746
	// (get) Token: 0x060145E0 RID: 83424 RVA: 0x005AA6AA File Offset: 0x005A88AA
	public int CurSelectRoleId
	{
		get
		{
			return this.CurSelectRoleIdInternal;
		}
	}

	// Token: 0x17001A5B RID: 6747
	// (get) Token: 0x060145E1 RID: 83425 RVA: 0x005AA6B2 File Offset: 0x005A88B2
	public global::ERoleListType CurSelectRoleListType
	{
		get
		{
			return this.CurSelectRoleListTypeInternal;
		}
	}

	// Token: 0x17001A5C RID: 6748
	// (get) Token: 0x060145E2 RID: 83426 RVA: 0x005AA6BA File Offset: 0x005A88BA
	public bool IsFirstEnter
	{
		get
		{
			return this.IsFirstEnterInternal;
		}
	}

	// Token: 0x17001A5D RID: 6749
	// (get) Token: 0x060145E3 RID: 83427 RVA: 0x005AA6C2 File Offset: 0x005A88C2
	public int TempRoleMarkRoleId
	{
		get
		{
			return this.TempRoleMarkRoleIdInternal;
		}
	}

	// Token: 0x060145E4 RID: 83428 RVA: 0x005AA6CA File Offset: 0x005A88CA
	public void ClearCache()
	{
		this.CurSelectRoleIdInternal = 0;
		this.CurSelectTabInternal = null;
		this.TempRoleMarkRoleIdInternal = 0;
	}

	// Token: 0x060145E5 RID: 83429 RVA: 0x005AA6E6 File Offset: 0x005A88E6
	protected override void OnBeforeDestroy()
	{
		this.ShowRoleUiModel();
		this.ClearCache();
	}

	// Token: 0x04009DD5 RID: 40405
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RoleDevMediumItemGrid, RoleDataBase> ConfigRoleLayout;

	// Token: 0x04009DD6 RID: 40406
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RoleDevSelectionMediumItemGrid, RoleDisplayModelBase> NewRoleLayout;

	// Token: 0x04009DD7 RID: 40407
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RoleDevRootTabItem, global::IRoleDevRootTabData> TabItemLayout;

	// Token: 0x04009DD8 RID: 40408
	[Nullable(2)]
	private RoleDevRoleViewItem RoleViewItem;

	// Token: 0x04009DD9 RID: 40409
	[Nullable(2)]
	private RoleDevWeaponViewItem WeaponViewItem;

	// Token: 0x04009DDA RID: 40410
	[Nullable(2)]
	private RoleDevPhantomViewItem PhantomViewItem;

	// Token: 0x04009DDB RID: 40411
	[Nullable(2)]
	private RoleDevSkillViewItem SkillViewItem;

	// Token: 0x04009DDC RID: 40412
	[Nullable(2)]
	private PopupCaptionItem ItemCaption;

	// Token: 0x04009DDD RID: 40413
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterSortEntrance<RoleDataBase> FilterSortEntranceInstance;

	// Token: 0x04009DDE RID: 40414
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<global::IRoleDevRootTabData> TabDataList;

	// Token: 0x04009DDF RID: 40415
	private readonly List<RoleDevRootTabItem> TabItems = new List<RoleDevRootTabItem>();

	// Token: 0x04009DE0 RID: 40416
	private readonly RoleDevViewModel RoleDevViewModelInstance = new RoleDevViewModel();

	// Token: 0x04009DE1 RID: 40417
	[Nullable(2)]
	private RoleDevTagItem DevelopTagItem;

	// Token: 0x04009DE2 RID: 40418
	[Nullable(2)]
	private CommonElementItem ElementSuitItem;

	// Token: 0x04009DE3 RID: 40419
	private int CurSelectRoleIdInternal;

	// Token: 0x04009DE4 RID: 40420
	private global::ERoleDevTabType? CurSelectTabInternal;

	// Token: 0x04009DE5 RID: 40421
	private global::ERoleListType CurSelectRoleListTypeInternal;

	// Token: 0x04009DE6 RID: 40422
	private bool IsFirstEnterInternal = true;

	// Token: 0x04009DE7 RID: 40423
	private int TempRoleMarkRoleIdInternal;

	// Token: 0x04009DE8 RID: 40424
	private bool FilterSortEntranceRefreshLock;

	// Token: 0x02008BB8 RID: 35768
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F14A RID: 192842
		Caption,
		// Token: 0x0402F14B RID: 192843
		GridNewRole,
		// Token: 0x0402F14C RID: 192844
		GridOwnRole,
		// Token: 0x0402F14D RID: 192845
		RoleItem,
		// Token: 0x0402F14E RID: 192846
		FilterSortItem,
		// Token: 0x0402F14F RID: 192847
		TextureRole,
		// Token: 0x0402F150 RID: 192848
		TxtRoleName,
		// Token: 0x0402F151 RID: 192849
		Tag,
		// Token: 0x0402F152 RID: 192850
		DevelopTag,
		// Token: 0x0402F153 RID: 192851
		TxtProperty,
		// Token: 0x0402F154 RID: 192852
		ElementIcon,
		// Token: 0x0402F155 RID: 192853
		ToggleLayout,
		// Token: 0x0402F156 RID: 192854
		DevelopToggle,
		// Token: 0x0402F157 RID: 192855
		SubRoleViewLayout,
		// Token: 0x0402F158 RID: 192856
		SubRoleViewScrollView,
		// Token: 0x0402F159 RID: 192857
		SubSkillViewLayout,
		// Token: 0x0402F15A RID: 192858
		SubSkillViewScrollView,
		// Token: 0x0402F15B RID: 192859
		SubWeaponViewLayout,
		// Token: 0x0402F15C RID: 192860
		SubWeaponViewScrollView,
		// Token: 0x0402F15D RID: 192861
		SubPhantomViewLayout,
		// Token: 0x0402F15E RID: 192862
		SubPhantomViewScrollView,
		// Token: 0x0402F15F RID: 192863
		EmptyPanel,
		// Token: 0x0402F160 RID: 192864
		ToggleRoleMark
	}
}
