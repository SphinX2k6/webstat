using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.FilterSort.Sort.SortEntrance;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002CFB RID: 11515
[NullableContext(1)]
[Nullable(0)]
public class WeaponReplaceView : UiViewBase
{
	// Token: 0x060173CD RID: 95181 RVA: 0x006716AC File Offset: 0x0066F8AC
	public WeaponReplaceView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060173CE RID: 95182 RVA: 0x006716B8 File Offset: 0x0066F8B8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.BackClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.ContrastClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060173CF RID: 95183 RVA: 0x00671828 File Offset: 0x0066FA28
	protected override UniTask OnBeforeStartAsync()
	{
		WeaponReplaceView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeaponReplaceView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060173D0 RID: 95184 RVA: 0x0067186C File Offset: 0x0066FA6C
	protected override void OnStart()
	{
		AUIBaseActor gridActor = base.GetItem(6).GetOwner() as AUIBaseActor;
		this.LoopScrollView = new LoopScrollView<WeaponReplaceMediumItemGrid, SelectablePropData>(base.GetLoopScrollViewComponent(0), gridActor, new Func<WeaponReplaceMediumItemGrid>(this.InitSelectableItem), false);
		this.SelectWeaponTipsView.SetReplaceFunction(new TWeaponDetailsTipsFunctionWithNumber(this.ReplaceWeapon));
		this.SelectWeaponTipsView.SetCultureFunction(new TWeaponDetailsTipsFunctionWithNumber(this.OpenWeaponRootView));
		this.SelectWeaponTipsView.SetCanShowEquip(true);
		this.CurrentWeaponTipsView.SetCanShowEquip(true);
		this.CurrentWeaponTipsView.SetCanShowLock(false);
		this.SortComponent = new SortEntrance<WeaponItemData>(base.GetItem(5), new TUpdateDataListFunction<WeaponItemData>(this.UpdateList));
	}

	// Token: 0x060173D1 RID: 95185 RVA: 0x0067191B File Offset: 0x0066FB1B
	private SelectablePropData UpdateSelectableItemData(int gridIndex)
	{
		return SelectablePropDataUtil.GetSelectablePropData(this.ItemDataList[gridIndex]);
	}

	// Token: 0x060173D2 RID: 95186 RVA: 0x00671930 File Offset: 0x0066FB30
	private WeaponReplaceMediumItemGrid InitSelectableItem()
	{
		WeaponReplaceMediumItemGrid weaponReplaceMediumItemGrid = new WeaponReplaceMediumItemGrid();
		weaponReplaceMediumItemGrid.Source = this.Source;
		weaponReplaceMediumItemGrid.RoleId = this.RoleDataId;
		weaponReplaceMediumItemGrid.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.ToggleFunction));
		weaponReplaceMediumItemGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanExecuteChange));
		return weaponReplaceMediumItemGrid;
	}

	// Token: 0x060173D3 RID: 95187 RVA: 0x00671980 File Offset: 0x0066FB80
	private void ToggleFunction(MediumItemGridExtendCallback parameters)
	{
		int incId = (parameters.Data as SelectablePropData).IncId;
		this.SelectedWeaponHandle(incId, false);
	}

	// Token: 0x060173D4 RID: 95188 RVA: 0x006719A8 File Offset: 0x0066FBA8
	private bool CanExecuteChange(object data, bool isForceSelected, EToggleState _)
	{
		SelectablePropData selectablePropData = data as SelectablePropData;
		return this.SelectedIncId != selectablePropData.IncId;
	}

	// Token: 0x060173D5 RID: 95189 RVA: 0x006719D0 File Offset: 0x0066FBD0
	protected void UpdateList(List<WeaponItemData> list, bool _1, EFilterSortType _2)
	{
		this.LoopScrollView.DeselectCurrentGridProxy(true);
		this.LoopScrollView.ReloadProxyData(new Func<int, SelectablePropData>(this.UpdateSelectableItemData), list.Count, false, false);
		if (list.Count <= 0)
		{
			return;
		}
		if (base.IsShow)
		{
			return;
		}
		this.LoopScrollView.ScrollToGridIndex(0, true);
		this.LoopScrollView.SelectGridProxy(0, true);
		WeaponItemData weaponItemData = list[0];
		this.SelectedWeaponHandle(weaponItemData.GetUniqueId(), false);
	}

	// Token: 0x060173D6 RID: 95190 RVA: 0x00671A4C File Offset: 0x0066FC4C
	private void OpenWeaponRootView(int incId)
	{
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(incId);
		int skinIdByRoleId = ModelBase<WeaponSkinModel>.Instance.GetSkinIdByRoleId(weaponDataByIncId.GetRoleId());
		WeaponRootViewParam param = new WeaponRootViewParam
		{
			WeaponIncId = incId,
			WeaponSkinId = skinIdByRoleId,
			IsFromRoleRootView = true
		};
		ControllerBase<WeaponController>.Instance.RoleFadeIn(Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor(), "RoleFadeInCurve");
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponRootView, param, null);
	}

	// Token: 0x060173D7 RID: 95191 RVA: 0x00671ABC File Offset: 0x0066FCBC
	private void ReplaceWeapon(int incId)
	{
		WeaponDataBase weaponDataByRoleDataId = ModelBase<WeaponModel>.Instance.GetWeaponDataByRoleDataId(this.RoleDataId, true);
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(incId);
		int roleId = weaponDataByRoleDataId.GetRoleId();
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		BaseTagComponent baseTagComponent;
		if (getCurrentEntity == null)
		{
			baseTagComponent = null;
		}
		else
		{
			WorldEntity entity = getCurrentEntity.Entity;
			baseTagComponent = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
		}
		BaseTagComponent baseTagComponent2 = baseTagComponent;
		SceneTeamItem getCurrentTeamItem = ModelBase<SceneTeamModel>.Instance.GetCurrentTeamItem;
		int? num = (getCurrentTeamItem != null) ? new int?(getCurrentTeamItem.GetConfigId) : null;
		int roleId2 = roleId;
		if ((num.GetValueOrDefault() == roleId2 & num != null) && baseTagComponent2 != null && baseTagComponent2.Valid && baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["功能.系统状态标识.tag禁止数值武器切换"]))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TagCantSwitchWeapon", Array.Empty<object>());
			return;
		}
		if (weaponDataByIncId.HasRole())
		{
			string weaponName = ConfigBase<WeaponConfig>.Instance.GetWeaponName(weaponDataByIncId.GetWeaponConfig().Value.WeaponName);
			string name = ModelBase<RoleModel>.Instance.GetRoleDataById(weaponDataByIncId.GetRoleId(), true).GetName(null);
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.WeaponEquipmentTip);
			Action value = delegate()
			{
				ControllerBase<WeaponController>.Instance.SendPbEquipTakeOnRequest(roleId, EquipPos.Weapon, incId);
			};
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				weaponName,
				name
			});
			confirmBoxDataNew.FunctionMap.Add(2, value);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		ControllerBase<WeaponController>.Instance.SendPbEquipTakeOnRequest(roleId, EquipPos.Weapon, incId);
	}

	// Token: 0x060173D8 RID: 95192 RVA: 0x00671C58 File Offset: 0x0066FE58
	protected void SetContrast()
	{
		this.InContrast = !this.InContrast;
		if (this.CurrentWeaponTipsView != null)
		{
			bool inContrast = this.InContrast;
			this.SetWeaponTipsRootItemState(inContrast);
			if (inContrast)
			{
				this.UpdateCurrentTips();
			}
		}
	}

	// Token: 0x060173D9 RID: 95193 RVA: 0x00671C94 File Offset: 0x0066FE94
	protected override void OnBeforeShow()
	{
		ModelBase<WeaponModel>.Instance.SetCurSelectViewName(EWeaponViewName.WeaponReplaceView);
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(this.SelectedIncId);
		if (weaponDataByIncId == null)
		{
			return;
		}
		WeaponConf? weaponConfig = weaponDataByIncId.GetWeaponConfig();
		this.ItemDataList = ModelBase<WeaponModel>.Instance.GetWeaponListFromReplace(weaponConfig.Value.WeaponType);
		this.SortComponent.UpdateData(EFilterSortGroupId.UseWayWeaponResonanceAndReplace, this.ItemDataList, Array.Empty<object>());
		this.SelectedIncId = 0;
		this.SelectedWeaponHandle(weaponDataByIncId.GetIncId().Value, true);
	}

	// Token: 0x060173DA RID: 95194 RVA: 0x00671D1C File Offset: 0x0066FF1C
	protected override UniTask OnPlayingStartSequenceAsync()
	{
		WeaponReplaceView.<OnPlayingStartSequenceAsync>d__24 <OnPlayingStartSequenceAsync>d__;
		<OnPlayingStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingStartSequenceAsync>d__.<>4__this = this;
		<OnPlayingStartSequenceAsync>d__.<>1__state = -1;
		<OnPlayingStartSequenceAsync>d__.<>t__builder.Start<WeaponReplaceView.<OnPlayingStartSequenceAsync>d__24>(ref <OnPlayingStartSequenceAsync>d__);
		return <OnPlayingStartSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060173DB RID: 95195 RVA: 0x00671D60 File Offset: 0x0066FF60
	protected override UniTask OnPlayingCloseSequenceAsync()
	{
		WeaponReplaceView.<OnPlayingCloseSequenceAsync>d__25 <OnPlayingCloseSequenceAsync>d__;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingCloseSequenceAsync>d__.<>4__this = this;
		<OnPlayingCloseSequenceAsync>d__.<>1__state = -1;
		<OnPlayingCloseSequenceAsync>d__.<>t__builder.Start<WeaponReplaceView.<OnPlayingCloseSequenceAsync>d__25>(ref <OnPlayingCloseSequenceAsync>d__);
		return <OnPlayingCloseSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060173DC RID: 95196 RVA: 0x00671DA3 File Offset: 0x0066FFA3
	protected override void OnBeforeDestroy()
	{
		this.RestoreOriginalWeapon();
		this.SelectWeaponTipsView.Destroy(null);
		this.CurrentWeaponTipsView.Destroy(null);
		this.SortComponent.Destroy(null);
	}

	// Token: 0x060173DD RID: 95197 RVA: 0x00671DCF File Offset: 0x0066FFCF
	protected override void OnHandleLoadScene()
	{
		this.ViewModel.HandleLoadScene(delegate
		{
			ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Weapon, true, false, false);
		});
	}

	// Token: 0x060173DE RID: 95198 RVA: 0x00671DFB File Offset: 0x0066FFFB
	protected override void OnHandleReleaseScene()
	{
		this.ViewModel.HandleReleaseScene();
	}

	// Token: 0x060173DF RID: 95199 RVA: 0x00671E08 File Offset: 0x00670008
	private void RestoreOriginalWeapon()
	{
		try
		{
			int roleId = ModelBase<RoleModel>.Instance.GetRoleDataById(this.RoleDataId, true).GetRoleId();
			WeaponDataBase weaponDataByRoleDataId = ModelBase<WeaponModel>.Instance.GetWeaponDataByRoleDataId(roleId, true);
			int skinIdByRoleId = ModelBase<WeaponSkinModel>.Instance.GetSkinIdByRoleId(roleId);
			RoleViewViewModel viewModel = this.ViewModel;
			UiModelBase uiModelBase;
			if (viewModel == null)
			{
				uiModelBase = null;
			}
			else
			{
				TsUiSceneRoleActor tsUiSceneRoleActor = viewModel.TsUiSceneRoleActor;
				uiModelBase = ((tsUiSceneRoleActor != null) ? tsUiSceneRoleActor.Model : null);
			}
			UiModelBase uiModelBase2 = uiModelBase;
			if (uiModelBase2 != null)
			{
				UiRoleWeaponComponent uiRoleWeaponComponent = uiModelBase2.CheckGetComponent<UiRoleWeaponComponent>();
				if (uiRoleWeaponComponent != null)
				{
					uiRoleWeaponComponent.SetWeaponByWeaponData(weaponDataByRoleDataId, skinIdByRoleId);
				}
			}
		}
		catch (Exception ex)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.WMQ;
			string message = "还原角色武器失败";
			Exception error = ex;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("error", ex.Message);
			instance.ErrorWithStack(module, author, message, error, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
	}

	// Token: 0x060173E0 RID: 95200 RVA: 0x00671EC8 File Offset: 0x006700C8
	protected override void OnAfterHide()
	{
		if (this.InContrast)
		{
			this.SetContrast();
		}
	}

	// Token: 0x060173E1 RID: 95201 RVA: 0x00671ED8 File Offset: 0x006700D8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.EquipWeapon, new Action(this.EquipWeaponEvent));
		Singleton<EventSystem>.Instance.Add(EEventName.OnItemLock, new Action<int, bool>(this.WeaponTipsLockEvent));
	}

	// Token: 0x060173E2 RID: 95202 RVA: 0x00671F12 File Offset: 0x00670112
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.EquipWeapon, new Action(this.EquipWeaponEvent));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnItemLock, new Action<int, bool>(this.WeaponTipsLockEvent));
	}

	// Token: 0x060173E3 RID: 95203 RVA: 0x00671F4C File Offset: 0x0067014C
	private void EquipWeaponEvent()
	{
		this.UpdateCurrentTips();
		this.UpdateSelectedTips(this.SelectedIncId);
		this.RefreshPropItem();
	}

	// Token: 0x060173E4 RID: 95204 RVA: 0x00671F66 File Offset: 0x00670166
	private void WeaponTipsLockEvent(int incId, bool isLock)
	{
		if (this.CurrentWeaponTipsView.GetWeaponIncId() == incId)
		{
			this.CurrentWeaponTipsView.UpdateWeaponLock(isLock);
		}
		if (this.SelectWeaponTipsView.GetWeaponIncId() == incId)
		{
			this.SelectWeaponTipsView.UpdateWeaponLock(isLock);
		}
		this.RefreshPropItem();
	}

	// Token: 0x060173E5 RID: 95205 RVA: 0x00671FA2 File Offset: 0x006701A2
	protected void RefreshPropItem()
	{
		this.LoopScrollView.RefreshAllGridProxies();
	}

	// Token: 0x060173E6 RID: 95206 RVA: 0x00671FB0 File Offset: 0x006701B0
	protected void SetWeaponTipsRootItemState(bool state)
	{
		this.UiViewSequence.StopSequenceByKey("TipStart", false, false);
		this.UiViewSequence.StopSequenceByKey("TipClose", false, false);
		string sequenceName = state ? "TipStart" : "TipClose";
		this.UiViewSequence.PlaySequence(sequenceName, false, null);
	}

	// Token: 0x060173E7 RID: 95207 RVA: 0x00672008 File Offset: 0x00670208
	protected void SelectedWeaponHandle(int incId, bool bFireEvent = false)
	{
		if (this.SelectedIncId == incId)
		{
			return;
		}
		if (ModelBase<InventoryModel>.Instance.GetWeaponItemData(incId) == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.BB;
			string message = "选中武器失败，背包不存在该武器";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("incId", incId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.UpdateSelectedTips(incId);
		int weaponItemIndex = this.GetWeaponItemIndex(incId);
		if (weaponItemIndex < 0)
		{
			return;
		}
		this.LoopScrollView.SelectGridProxy(weaponItemIndex, bFireEvent);
		this.SelectedIncId = incId;
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(incId);
		int weaponSkinId = -1;
		if (weaponDataByIncId.GetRoleId() == this.RoleDataId)
		{
			weaponSkinId = ModelBase<WeaponSkinModel>.Instance.GetSkinIdByRoleId(this.RoleDataId);
		}
		UiModelBase model = this.ViewModel.TsUiSceneRoleActor.Model;
		if (model == null)
		{
			return;
		}
		UiRoleWeaponComponent uiRoleWeaponComponent = model.CheckGetComponent<UiRoleWeaponComponent>();
		if (uiRoleWeaponComponent == null)
		{
			return;
		}
		uiRoleWeaponComponent.SetWeaponByWeaponData(weaponDataByIncId, weaponSkinId);
	}

	// Token: 0x060173E8 RID: 95208 RVA: 0x006720D4 File Offset: 0x006702D4
	protected void UpdateSelectedTips(int incId)
	{
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(incId);
		this.SelectWeaponTipsView.UpdateComponent(weaponDataByIncId);
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(this.RoleDataId, true);
		this.SelectWeaponTipsView.UpdateEquip(roleDataById.GetRoleId());
	}

	// Token: 0x060173E9 RID: 95209 RVA: 0x0067211C File Offset: 0x0067031C
	protected void UpdateCurrentTips()
	{
		WeaponInstance weaponData = ModelBase<WeaponModel>.Instance.GetWeaponDataByRoleDataId(this.RoleDataId, true) as WeaponInstance;
		this.CurrentWeaponTipsView.UpdateComponent(weaponData);
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(this.RoleDataId, true);
		this.CurrentWeaponTipsView.UpdateEquip(roleDataById.GetRoleId());
	}

	// Token: 0x060173EA RID: 95210 RVA: 0x00672170 File Offset: 0x00670370
	protected int GetWeaponItemIndex(int incId)
	{
		for (int i = 0; i < this.ItemDataList.Count; i++)
		{
			if (this.ItemDataList[i].GetUniqueId() == incId)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x060173EB RID: 95211 RVA: 0x006721AC File Offset: 0x006703AC
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		int num;
		if (configParams.Length != 1 || !int.TryParse(configParams[0], out num))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.TL;
			string message = "武器替换界面聚焦引导ExtraParam参数配置错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		int? num2 = null;
		for (int i = 0; i < this.ItemDataList.Count; i++)
		{
			SelectablePropData selectablePropData = SelectablePropDataUtil.GetSelectablePropData(this.ItemDataList[i]);
			if (selectablePropData.ItemId == num)
			{
				num2 = new int?(i);
				if (selectablePropData.RoleId != this.RoleDataId)
				{
					break;
				}
			}
		}
		if (this.LoopScrollView.StartGridIndex != -1)
		{
			this.LoopScrollView.ScrollToGridIndex(num2.Value, true);
		}
		UUIItem grid = this.LoopScrollView.GetGrid(num2.Value);
		if (grid == null || num2 == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Guide;
			ELogAuthor author2 = ELogAuthor.TL;
			string message2 = "武器替换界面聚焦引导ExtraParam参数配置错误, 找不到道具";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("itemId", num);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		return new UUIItem[]
		{
			grid,
			grid
		};
	}

	// Token: 0x060173EC RID: 95212 RVA: 0x006722C8 File Offset: 0x006704C8
	private void BackClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x060173ED RID: 95213 RVA: 0x006722D1 File Offset: 0x006704D1
	private void ContrastClick()
	{
		this.SetContrast();
	}

	// Token: 0x0400B2AD RID: 45741
	protected int SelectedIncId;

	// Token: 0x0400B2AE RID: 45742
	protected int RoleDataId;

	// Token: 0x0400B2AF RID: 45743
	protected ERoleViewSource Source;

	// Token: 0x0400B2B0 RID: 45744
	[Nullable(2)]
	private WeaponDetailTipsComponent SelectWeaponTipsView;

	// Token: 0x0400B2B1 RID: 45745
	[Nullable(2)]
	private WeaponDetailTipsComponent CurrentWeaponTipsView;

	// Token: 0x0400B2B2 RID: 45746
	private bool InContrast;

	// Token: 0x0400B2B3 RID: 45747
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected SortEntrance<WeaponItemData> SortComponent;

	// Token: 0x0400B2B4 RID: 45748
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected LoopScrollView<WeaponReplaceMediumItemGrid, SelectablePropData> LoopScrollView;

	// Token: 0x0400B2B5 RID: 45749
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected List<WeaponItemData> ItemDataList;

	// Token: 0x0400B2B6 RID: 45750
	[Nullable(2)]
	private RoleViewViewModel ViewModel;

	// Token: 0x02008FC9 RID: 36809
	[NullableContext(0)]
	private enum EWeaponReplaceViewDefine
	{
		// Token: 0x04030425 RID: 197669
		Scrollbar,
		// Token: 0x04030426 RID: 197670
		BackButton,
		// Token: 0x04030427 RID: 197671
		WeaponTipsItem,
		// Token: 0x04030428 RID: 197672
		CurrentTipsItem,
		// Token: 0x04030429 RID: 197673
		ContrastButton,
		// Token: 0x0403042A RID: 197674
		SortItem,
		// Token: 0x0403042B RID: 197675
		SelectableItem
	}
}
