using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.UiCamera;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002A63 RID: 10851
[NullableContext(1)]
[Nullable(0)]
public class RoleOrnamentTabView : UiTabViewBase
{
	// Token: 0x06015BD2 RID: 89042 RVA: 0x00608310 File Offset: 0x00606510
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIDraggableComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnClickHideViewToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06015BD3 RID: 89043 RVA: 0x006084E4 File Offset: 0x006066E4
	protected override UniTask OnBeforeStartAsync()
	{
		RoleOrnamentTabView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleOrnamentTabView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015BD4 RID: 89044 RVA: 0x00608528 File Offset: 0x00606728
	protected override void OnBeforeShow()
	{
		EModelStateInSkinView? modelState = this.RootViewModel.GetModelState();
		if (modelState.GetValueOrDefault() == EModelStateInSkinView.ShowGlider || modelState.GetValueOrDefault() == EModelStateInSkinView.ShowCalabash)
		{
			this.SkipCameraBlend = true;
		}
		ISkinViewData viewData = this.RootViewModel.ViewData;
		if (viewData.SkipOrnamentCameraBlend.GetValueOrDefault())
		{
			this.SkipCameraBlend = true;
			viewData.SkipOrnamentCameraBlend = new bool?(false);
		}
		this.RootViewModel.SetModelState(EModelStateInSkinView.ShowRole, false);
		ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Attribute_Perform, false, false, false);
		this.RefreshDefaultSelect();
		this.RefreshContentLayout();
		this.RefreshUiSceneRoleActor();
	}

	// Token: 0x06015BD5 RID: 89045 RVA: 0x006085B8 File Offset: 0x006067B8
	protected override void OnBeforeHide()
	{
		this.RootViewModel.EndCameraInput();
	}

	// Token: 0x06015BD6 RID: 89046 RVA: 0x006085C5 File Offset: 0x006067C5
	protected override void OnBeforeDestroy()
	{
		this.RootViewModel.UnBind(new Action<ESkinRootViewData>(this.OnRootViewModelUpdate));
		this.ViewModel.UnBind(new Action<ERoleOrnamentTabViewData>(this.OnViewModelUpdate));
	}

	// Token: 0x06015BD7 RID: 89047 RVA: 0x006085F8 File Offset: 0x006067F8
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnSkinRootViewDestroy, new Action(this.OnSkinRootViewDestroy));
		Singleton<EventSystem>.Instance.Add(EEventName.OnOrnamentChange, new Action(this.OnOrnamentChange));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnOrnamentUnlock, new Action<int>(this.OnOrnamentUnlock));
	}

	// Token: 0x06015BD8 RID: 89048 RVA: 0x0060865C File Offset: 0x0060685C
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSkinRootViewDestroy, new Action(this.OnSkinRootViewDestroy));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnOrnamentChange, new Action(this.OnOrnamentChange));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnOrnamentUnlock, new Action<int>(this.OnOrnamentUnlock));
	}

	// Token: 0x06015BD9 RID: 89049 RVA: 0x006086C0 File Offset: 0x006068C0
	private void RefreshDefaultSelect()
	{
		int? num = null;
		int? num2 = null;
		SkinTabViewParam tabViewParam = this.RootViewModel.GetTabViewParam();
		if (tabViewParam != null && tabViewParam.SkinId != null)
		{
			num = tabViewParam.SkinId;
			num2 = new int?(tabViewParam.OrnamentId ?? this.ViewModel.GetDefaultOrnamentId(num.Value));
		}
		if (num == null)
		{
			num = new int?(this.ViewModel.GetDefaultSkinId(this.RootViewModel.RoleId));
			if (num.Value != this.ViewModel.GetSelectedSkinId())
			{
				num2 = new int?(this.ViewModel.GetDefaultOrnamentId(num.Value));
			}
		}
		int value = num2.GetValueOrDefault();
		if (num2 == null)
		{
			value = this.ViewModel.GetDefaultOrnamentId(num.Value);
			num2 = new int?(value);
		}
		this.ViewModel.SetSelectedSkinId(num.Value, false);
		this.ViewModel.SetSelectedOrnamentId(num2.Value, false);
	}

	// Token: 0x06015BDA RID: 89050 RVA: 0x006087DC File Offset: 0x006069DC
	private void RefreshOrnamentView(bool playAnim = true)
	{
		RoleOrnamentModel instance = ModelBase<RoleOrnamentModel>.Instance;
		int selectedOrnamentId = this.ViewModel.GetSelectedOrnamentId();
		RoleOrnamentData roleOrnamentData = instance.GetRoleOrnamentData(selectedOrnamentId);
		this.RefreshText(roleOrnamentData.GetName(), roleOrnamentData.GetBgDescription());
		int selectedSkinId = this.ViewModel.GetSelectedSkinId();
		bool flag = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(selectedSkinId).IsLocked();
		bool flag2 = instance.IsOwnOrnament(selectedOrnamentId);
		bool flag3 = flag && flag2;
		if (flag3)
		{
			this.HintItem.SetShowText("OrnamentUiText_04");
		}
		bool flag4 = flag2 && !flag;
		bool flag5 = ModelBase<RoleOrnamentModel>.Instance.IsSkinWearingOrnament(selectedOrnamentId, selectedSkinId, true);
		if (flag4)
		{
			this.ConfirmButton.SetShowText(flag5 ? "OrnamentUiText_02" : "OrnamentUiText_01");
		}
		bool flag6 = !flag2;
		this.ObtainLayout.SetActive(flag6);
		if (flag6)
		{
			this.RefreshObtainLayout(selectedOrnamentId);
		}
		List<int> conflictOrnamentsOnSkin = instance.GetConflictOrnamentsOnSkin(selectedOrnamentId, selectedSkinId, false);
		bool flag7 = !flag5 && conflictOrnamentsOnSkin.Count > 0;
		if (flag7)
		{
			Ornament value = ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(conflictOrnamentsOnSkin[0]).Value;
			this.HintItem.SetLocalText("OrnamentUiText_03", new object[]
			{
				ConfigMultiTextLang.GetLocalTextNew(value.Name, null)
			});
			if (playAnim)
			{
				this.UiViewSequence.StopSequenceByKey("RedTips", false, false);
				this.UiViewSequence.PlaySequence("RedTips", true, null);
			}
		}
		this.HintItem.SetUiActive(flag3 || flag7);
		bool flag8 = flag2 && flag;
		if (flag8)
		{
			this.ConfirmButton.SetShowText("OrnamentUiText_07");
		}
		this.ConfirmButton.SetUiActive(flag4 || flag8);
		if (playAnim)
		{
			this.UiViewSequence.StopSequenceByKey("Switch", false, false);
			this.UiViewSequence.PlaySequence("Switch", true, null);
		}
	}

	// Token: 0x06015BDB RID: 89051 RVA: 0x006089AC File Offset: 0x00606BAC
	private void RefreshOrnamentModel()
	{
		int selectedOrnamentId = this.ViewModel.GetSelectedOrnamentId();
		int selectedSkinId = this.ViewModel.GetSelectedSkinId();
		List<int> wearPreviewOrnamentResult = ModelBase<RoleOrnamentModel>.Instance.GetWearPreviewOrnamentResult(selectedOrnamentId, selectedSkinId);
		List<OrnamentModelContext> list = new List<OrnamentModelContext>();
		for (int i = 0; i < wearPreviewOrnamentResult.Count; i++)
		{
			int ornamentId = wearPreviewOrnamentResult[i];
			list.Add(UiModelUtil.BuildOrnamentModelContext(selectedSkinId, ornamentId));
		}
		UiModelUtil.RefreshRoleOrnaments(this.RootViewModel.TsUiSceneRoleActor.Model, list.ToArray(), false);
	}

	// Token: 0x06015BDC RID: 89052 RVA: 0x00608A2D File Offset: 0x00606C2D
	private void RefreshText(string name, string desc)
	{
		base.GetText(6).ShowTextNew(name);
		base.GetText(7).ShowTextNew(desc);
	}

	// Token: 0x06015BDD RID: 89053 RVA: 0x00608A4C File Offset: 0x00606C4C
	private void RefreshContentLayout()
	{
		int roleId = this.RootViewModel.RoleId;
		List<RoleSkinData> roleSkinDataList = ModelBase<RoleSkinModel>.Instance.GetRoleSkinDataList(roleId);
		roleSkinDataList.Sort(delegate(RoleSkinData a, RoleSkinData b)
		{
			bool flag = a.IsWear();
			bool flag2 = b.IsWear();
			if (flag == flag2)
			{
				return 0;
			}
			if (!flag)
			{
				return 1;
			}
			return -1;
		});
		this.ContentLayout.RefreshByData(roleSkinDataList, null, false);
	}

	// Token: 0x06015BDE RID: 89054 RVA: 0x00608AA4 File Offset: 0x00606CA4
	private void RefreshObtainLayout(int itemId)
	{
		List<IGetWayItemData> getWayDataList = ModelBase<InventoryModel>.Instance.GetGetWayDataList(itemId);
		this.ObtainLayout.RefreshByData(getWayDataList, null, false);
	}

	// Token: 0x06015BDF RID: 89055 RVA: 0x00608ACB File Offset: 0x00606CCB
	private void RefreshUiSceneRoleActor()
	{
		ControllerBase<RoleController>.Instance.RefreshUiSceneRoleActor(this.RootViewModel.TsUiSceneRoleActor, this.RootViewModel.RoleId, this.ViewModel.GetSelectedSkinId(), null);
	}

	// Token: 0x06015BE0 RID: 89056 RVA: 0x00608AFC File Offset: 0x00606CFC
	private void RefreshContentGridSelected()
	{
		List<RoleSkinOrnamentItem> layoutItemList = this.ContentLayout.GetLayoutItemList();
		for (int i = 0; i < layoutItemList.Count; i++)
		{
			RoleSkinOrnamentItem roleSkinOrnamentItem = layoutItemList[i];
			if (roleSkinOrnamentItem != null)
			{
				roleSkinOrnamentItem.RefreshGridSelected();
			}
		}
	}

	// Token: 0x06015BE1 RID: 89057 RVA: 0x00608B38 File Offset: 0x00606D38
	private void RefreshContentItems()
	{
		List<RoleSkinOrnamentItem> layoutItemList = this.ContentLayout.GetLayoutItemList();
		for (int i = 0; i < layoutItemList.Count; i++)
		{
			RoleSkinOrnamentItem roleSkinOrnamentItem = layoutItemList[i];
			if (roleSkinOrnamentItem != null)
			{
				roleSkinOrnamentItem.RefreshOrnamentItems();
			}
		}
	}

	// Token: 0x06015BE2 RID: 89058 RVA: 0x00608B74 File Offset: 0x00606D74
	private void RevertRoleSkin()
	{
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RootViewModel.RoleId);
		if (roleInstanceById == null || this.RootViewModel.TsUiSceneRoleActor == null)
		{
			return;
		}
		ControllerBase<RoleController>.Instance.RefreshUiSceneRoleActor(this.RootViewModel.TsUiSceneRoleActor, this.RootViewModel.RoleId, roleInstanceById.GetRoleSkinId(), null);
	}

	// Token: 0x06015BE3 RID: 89059 RVA: 0x00608BD0 File Offset: 0x00606DD0
	private void RevertOrnamentModel(bool useSelectedSkinId = false)
	{
		TsUiSceneRoleActor tsUiSceneRoleActor = this.RootViewModel.TsUiSceneRoleActor;
		if (((tsUiSceneRoleActor != null) ? tsUiSceneRoleActor.Model : null) == null)
		{
			return;
		}
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RootViewModel.RoleId);
		int num = useSelectedSkinId ? this.ViewModel.GetSelectedSkinId() : roleInstanceById.GetRoleSkinId();
		List<int> skinAllWearingOrnaments = ModelBase<RoleOrnamentModel>.Instance.GetSkinAllWearingOrnaments(num, true);
		List<OrnamentModelContext> list = new List<OrnamentModelContext>();
		for (int i = 0; i < skinAllWearingOrnaments.Count; i++)
		{
			int ornamentId = skinAllWearingOrnaments[i];
			list.Add(UiModelUtil.BuildOrnamentModelContext(num, ornamentId));
		}
		UiModelUtil.RefreshRoleOrnaments(this.RootViewModel.TsUiSceneRoleActor.Model, list.ToArray(), false);
	}

	// Token: 0x06015BE4 RID: 89060 RVA: 0x00608C80 File Offset: 0x00606E80
	private void TryPlayRoleMontage()
	{
		int selectedOrnamentId = this.ViewModel.GetSelectedOrnamentId();
		if (ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(selectedOrnamentId).Value.UiRoleState == 0)
		{
			return;
		}
		ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Favor, false, false, false);
	}

	// Token: 0x06015BE5 RID: 89061 RVA: 0x00608CC6 File Offset: 0x00606EC6
	private RoleSkinOrnamentItem CreateSkinOrnamentItem()
	{
		RoleSkinOrnamentItem roleSkinOrnamentItem = new RoleSkinOrnamentItem();
		roleSkinOrnamentItem.SetClickOrnamentCallback(new Action<int, int>(this.OnClickOrnamentCallback));
		roleSkinOrnamentItem.SetGetPreviewSkinIdFunc(new Func<int>(this.GetPreviewSkinIdFunc));
		roleSkinOrnamentItem.SetGetPreviewOrnamentIdFunc(new Func<int>(this.GetPreviewOrnamentIdFunc));
		return roleSkinOrnamentItem;
	}

	// Token: 0x06015BE6 RID: 89062 RVA: 0x00608D03 File Offset: 0x00606F03
	private RoleOrnamentObtainItem CreateObtainItem()
	{
		return new RoleOrnamentObtainItem();
	}

	// Token: 0x06015BE7 RID: 89063 RVA: 0x00608D0A File Offset: 0x00606F0A
	private void OnUiOutSequenceFinish()
	{
		base.GetItem(0).SetUIActive(false);
	}

	// Token: 0x06015BE8 RID: 89064 RVA: 0x00608D19 File Offset: 0x00606F19
	private void OnRootViewModelUpdate(ESkinRootViewData data)
	{
		if (data == ESkinRootViewData.CurSelectTabViewName && base.IsShowOrShowing)
		{
			this.RevertRoleSkin();
			this.RevertOrnamentModel(false);
		}
	}

	// Token: 0x06015BE9 RID: 89065 RVA: 0x00608D33 File Offset: 0x00606F33
	private void OnViewModelUpdate(ERoleOrnamentTabViewData data)
	{
		if (data == ERoleOrnamentTabViewData.SelectedOrnamentId)
		{
			this.RefreshOrnamentView(true);
			this.RefreshContentGridSelected();
			this.RefreshOrnamentModel();
			this.UpdateCamera(new bool?(true));
			this.TryPlayRoleMontage();
			return;
		}
		if (data == ERoleOrnamentTabViewData.SelectedSkinId)
		{
			this.RefreshUiSceneRoleActor();
		}
	}

	// Token: 0x06015BEA RID: 89066 RVA: 0x00608D68 File Offset: 0x00606F68
	private void OnClickHideViewToggle(EToggleState state)
	{
		UUIItem item = base.GetItem(0);
		if (state == EToggleState.ETT_Checked)
		{
			this.RootViewModel.SetCaptionItemActive(true);
			item.SetUIActive(true);
			this.UiViewSequence.PlaySequence("UiIn", true, null);
		}
		else
		{
			this.RootViewModel.SetCaptionItemActive(false);
			this.UiViewSequence.PlaySequence("UiOut", true, null);
		}
		this.UpdateCamera(null);
		this.TryPlayRoleMontage();
	}

	// Token: 0x06015BEB RID: 89067 RVA: 0x00608DEC File Offset: 0x00606FEC
	private void OnClickConfirmButton()
	{
		int selectedSkinId = this.ViewModel.GetSelectedSkinId();
		if (ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(selectedSkinId).IsLocked())
		{
			this.RootViewModel.SetTabViewParam(new SkinTabViewParam
			{
				SkinId = new int?(selectedSkinId)
			});
			this.RootViewModel.SetSelectTabViewName(EUiTabViewName.RoleSkinTabView, false);
			return;
		}
		if (!ControllerBase<RoleController>.Instance.CheckCanWearOrnamentAndShowTip())
		{
			return;
		}
		int selectedOrnamentId = this.ViewModel.GetSelectedOrnamentId();
		if (!ModelBase<RoleOrnamentModel>.Instance.IsOwnOrnament(selectedOrnamentId))
		{
			return;
		}
		bool flag = ModelBase<RoleOrnamentModel>.Instance.IsSkinWearingOrnament(selectedOrnamentId, selectedSkinId, true);
		ControllerBase<RoleController>.Instance.RequestChangeOrnamentRequest(selectedSkinId, selectedOrnamentId, !flag);
	}

	// Token: 0x06015BEC RID: 89068 RVA: 0x00608E8C File Offset: 0x0060708C
	private void OnClickOrnamentCallback(int skinId, int ornamentId)
	{
		int selectedOrnamentId = this.ViewModel.GetSelectedOrnamentId();
		this.ViewModel.SetPreSelectedOrnamentId(selectedOrnamentId, false);
		this.ViewModel.SetSelectedSkinId(skinId, false);
		this.ViewModel.SetSelectedOrnamentId(ornamentId, false);
	}

	// Token: 0x06015BED RID: 89069 RVA: 0x00608ECC File Offset: 0x006070CC
	private void OnSkinRootViewDestroy()
	{
		this.RevertRoleSkin();
		this.RevertOrnamentModel(false);
		this.RootViewModel.EndCameraInput();
	}

	// Token: 0x06015BEE RID: 89070 RVA: 0x00608EE6 File Offset: 0x006070E6
	private void OnOrnamentChange()
	{
		this.RevertOrnamentModel(true);
		this.RefreshOrnamentView(false);
		this.RefreshContentItems();
	}

	// Token: 0x06015BEF RID: 89071 RVA: 0x00608EFC File Offset: 0x006070FC
	private void OnOrnamentUnlock(int ornamentId)
	{
		this.RefreshDefaultSelect();
		this.RefreshContentLayout();
	}

	// Token: 0x06015BF0 RID: 89072 RVA: 0x00608F0A File Offset: 0x0060710A
	private int GetPreviewSkinIdFunc()
	{
		return this.ViewModel.GetSelectedSkinId();
	}

	// Token: 0x06015BF1 RID: 89073 RVA: 0x00608F17 File Offset: 0x00607117
	private int GetPreviewOrnamentIdFunc()
	{
		return this.ViewModel.GetSelectedOrnamentId();
	}

	// Token: 0x06015BF2 RID: 89074 RVA: 0x00608F24 File Offset: 0x00607124
	private IUiCameraInputComponentData GetCameraInputData()
	{
		return this.ViewModel.GetOrnamentTabCameraInputData(this.RootViewModel.GetDragItem(), this.RootViewModel.TsUiSceneRoleActor, this.IsHidingUi());
	}

	// Token: 0x06015BF3 RID: 89075 RVA: 0x00608F50 File Offset: 0x00607150
	private bool IsAllowCameraRotate()
	{
		int selectedOrnamentId = this.ViewModel.GetSelectedOrnamentId();
		Ornament value = ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(selectedOrnamentId).Value;
		if (!this.IsHidingUi())
		{
			return value.AllowUiCameraRotate;
		}
		return value.AllowHideUiCameraRotate;
	}

	// Token: 0x06015BF4 RID: 89076 RVA: 0x00608F94 File Offset: 0x00607194
	private bool IsHidingUi()
	{
		return base.GetExtendToggle(2).GetToggleState() == EToggleState.ETT_UnChecked;
	}

	// Token: 0x06015BF5 RID: 89077 RVA: 0x00608FA5 File Offset: 0x006071A5
	private void UpdateCamera(bool? isFromOrnament = null)
	{
		this.TryPushOrnamentCamera(isFromOrnament, null);
		this.RootViewModel.StartCameraInput(this.GetCameraInputData(), new bool?(this.IsAllowCameraRotate()), false);
	}

	// Token: 0x06015BF6 RID: 89078 RVA: 0x00608FCC File Offset: 0x006071CC
	[NullableContext(2)]
	private void TryPushOrnamentCamera(bool? isFromOrnament = null, Action callback = null)
	{
		int selectedOrnamentId = this.ViewModel.GetSelectedOrnamentId();
		int selectedSkinId = this.ViewModel.GetSelectedSkinId();
		bool flag = this.IsHidingUi();
		bool skipCameraBlend = this.SkipCameraBlend;
		ISkinViewData viewData = this.RootViewModel.ViewData;
		if (viewData.SkipOrnamentCameraBlend.GetValueOrDefault())
		{
			viewData.SkipOrnamentCameraBlend = new bool?(false);
		}
		string blendName = flag ? "1001" : this.GetOrnamentCameraBlendName(selectedOrnamentId, isFromOrnament);
		string ornamentCameraHandleName = this.GetOrnamentCameraHandleName(selectedOrnamentId, selectedSkinId, flag);
		UiCameraHandleData uiCameraHandleData = UiCameraHandleData.NewByHandleName(ornamentCameraHandleName, null);
		uiCameraHandleData.ViewName = ornamentCameraHandleName;
		uiCameraHandleData.OwnerViewName = base.GetViewName();
		Singleton<UiCameraAnimationManager>.Instance.PushCameraHandle(uiCameraHandleData, !skipCameraBlend, !skipCameraBlend, blendName, false, delegate(UiCameraAnimationDefine.IFinishData _)
		{
			Action callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2();
		});
	}

	// Token: 0x06015BF7 RID: 89079 RVA: 0x006090A8 File Offset: 0x006072A8
	private string GetOrnamentCameraBlendName(int targetOrnament, bool? isFromOrnament = null)
	{
		if (!isFromOrnament.GetValueOrDefault())
		{
			return "1001";
		}
		int preSelectedOrnamentId = this.ViewModel.GetPreSelectedOrnamentId();
		if (preSelectedOrnamentId == 0)
		{
			return "1001";
		}
		Ornament? ornamentConfig = ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(preSelectedOrnamentId);
		if (ornamentConfig == null)
		{
			return "1001";
		}
		Ornament value = ornamentConfig.Value;
		for (int i = 0; i < value.UiCameraBlendLength; i++)
		{
			DicIntString? dicIntString = value.UiCameraBlend(i);
			if (dicIntString != null)
			{
				DicIntString value2 = dicIntString.Value;
				if (value2.Key == targetOrnament)
				{
					return value2.Value ?? "1001";
				}
			}
		}
		return "1001";
	}

	// Token: 0x06015BF8 RID: 89080 RVA: 0x0060914C File Offset: 0x0060734C
	private string GetOrnamentCameraHandleName(int ornamentId, int skinId, bool isHidingUi)
	{
		Ornament value = ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(ornamentId).Value;
		RoleSkin value2 = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(skinId).Value;
		if (isHidingUi)
		{
			if (value.HideUiCameraLength <= 0)
			{
				return string.Empty;
			}
			if (!ModelBase<RoleModel>.Instance.IsMainRole(value2.RoleId))
			{
				return value.HideUiCamera(0) ?? string.Empty;
			}
			string result;
			if (ConfigBase<RoleConfig>.Instance.GetMainRoleById(value2.RoleId).Value.Gender != 1)
			{
				if ((result = value.HideUiCamera(1)) == null)
				{
					return string.Empty;
				}
			}
			else
			{
				result = (value.HideUiCamera(0) ?? string.Empty);
			}
			return result;
		}
		else
		{
			if (value.UiCameraLength <= 0)
			{
				return string.Empty;
			}
			if (!ModelBase<RoleModel>.Instance.IsMainRole(value2.RoleId))
			{
				return value.UiCamera(0) ?? string.Empty;
			}
			string result2;
			if (ConfigBase<RoleConfig>.Instance.GetMainRoleById(value2.RoleId).Value.Gender != 1)
			{
				if ((result2 = value.UiCamera(1)) == null)
				{
					return string.Empty;
				}
			}
			else
			{
				result2 = (value.UiCamera(0) ?? string.Empty);
			}
			return result2;
		}
	}

	// Token: 0x0400A6CC RID: 42700
	private SkinRootViewModel RootViewModel;

	// Token: 0x0400A6CD RID: 42701
	private RoleOrnamentViewModel ViewModel;

	// Token: 0x0400A6CE RID: 42702
	private GenericLayout<RoleSkinOrnamentItem, RoleSkinData> ContentLayout;

	// Token: 0x0400A6CF RID: 42703
	private GenericLayout<RoleOrnamentObtainItem, IGetWayItemData> ObtainLayout;

	// Token: 0x0400A6D0 RID: 42704
	private RoleOrnamentTabView.RoleOrnamentHintItem HintItem;

	// Token: 0x0400A6D1 RID: 42705
	private ButtonItem ConfirmButton;

	// Token: 0x0400A6D2 RID: 42706
	private bool SkipCameraBlend;

	// Token: 0x02008DE7 RID: 36327
	[NullableContext(0)]
	private enum EComponentType
	{
		// Token: 0x0402FBFA RID: 195578
		RootItem,
		// Token: 0x0402FBFB RID: 195579
		ContentLayout,
		// Token: 0x0402FBFC RID: 195580
		HideViewToggle,
		// Token: 0x0402FBFD RID: 195581
		ConfirmButton,
		// Token: 0x0402FBFE RID: 195582
		ObtainLayout,
		// Token: 0x0402FBFF RID: 195583
		ObtainItem,
		// Token: 0x0402FC00 RID: 195584
		TitleText,
		// Token: 0x0402FC01 RID: 195585
		ContentText,
		// Token: 0x0402FC02 RID: 195586
		Draggable,
		// Token: 0x0402FC03 RID: 195587
		HintItem,
		// Token: 0x0402FC04 RID: 195588
		SkinOrnamentItem
	}

	// Token: 0x02008DE8 RID: 36328
	[Nullable(0)]
	private class RoleOrnamentHintItem : UiPanelBase
	{
		// Token: 0x06049A31 RID: 301617 RVA: 0x013ED580 File Offset: 0x013EB780
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06049A32 RID: 301618 RVA: 0x013ED60A File Offset: 0x013EB80A
		public void SetLocalText(string text, params object[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), text, args);
		}

		// Token: 0x06049A33 RID: 301619 RVA: 0x013ED61F File Offset: 0x013EB81F
		public void SetShowText(string text)
		{
			base.GetText(1).ShowTextNew(text);
		}

		// Token: 0x06049A34 RID: 301620 RVA: 0x013ED630 File Offset: 0x013EB830
		public void SetSprite(string resourcePath, bool setSize = false)
		{
			this.SetSpriteByPath(resourcePath, base.GetSprite(0), setSize, null, null);
		}

		// Token: 0x0200CDFA RID: 52730
		[NullableContext(0)]
		private enum EChildComponentType
		{
			// Token: 0x0403F819 RID: 260121
			Sprite,
			// Token: 0x0403F81A RID: 260122
			Text,
			// Token: 0x0403F81B RID: 260123
			Button
		}
	}
}
