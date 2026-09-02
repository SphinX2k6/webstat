using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.UiCamera;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Skin.Role.Item;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Skin.Role.View
{
	// Token: 0x02004F71 RID: 20337
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleSkinTabView : UiTabViewBase
	{
		// Token: 0x0603472E RID: 214830 RVA: 0x00D1F680 File Offset: 0x00D1D880
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(11, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(12, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUINiagara)),
				new ValueTuple<int, Type>(17, typeof(UUIItem)),
				new ValueTuple<int, Type>(18, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(19, typeof(UUIGridLayout)),
				new ValueTuple<int, Type>(20, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnClickHideViewToggle)),
				new ValueTuple<int, Delegate>(3, new Action(this.OnClickSkinDetailButton)),
				new ValueTuple<int, Delegate>(4, new Action(this.OnClickLeftArrowButton)),
				new ValueTuple<int, Delegate>(5, new Action(this.OnClickRightArrowButton)),
				new ValueTuple<int, Delegate>(10, new Action<EToggleState>(this.OnClickWearWeaponToggle)),
				new ValueTuple<int, Delegate>(11, new Action(this.OnClickWearWeaponTipButton)),
				new ValueTuple<int, Delegate>(14, new Action(this.OnClickWearButton)),
				new ValueTuple<int, Delegate>(18, new Action(this.OnClickOrnamentButton))
			};
		}

		// Token: 0x0603472F RID: 214831 RVA: 0x00D1F944 File Offset: 0x00D1DB44
		protected override UniTask OnBeforeStartAsync()
		{
			RoleSkinTabView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleSkinTabView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034730 RID: 214832 RVA: 0x00D1F987 File Offset: 0x00D1DB87
		private void OnRootViewModelUpdate(ESkinRootViewData data)
		{
			if (data == ESkinRootViewData.CurSelectTabViewName && base.IsShowOrShowing)
			{
				this.RevertRoleSkin();
			}
		}

		// Token: 0x06034731 RID: 214833 RVA: 0x00D1F99C File Offset: 0x00D1DB9C
		private void OnViewModelUpdate(ERoleSkinTabViewData data)
		{
			if (data == ERoleSkinTabViewData.SelectRoleSkinId)
			{
				RoleSkinData roleSkinData = this.RoleSkinList[this.CurSelectSkinIndex];
				this.RefreshUi(roleSkinData);
				this.RefreshSkinOrnament(roleSkinData);
				return;
			}
			if (data == ERoleSkinTabViewData.IsWearWeaponSkin)
			{
				RoleSkinData roleSkinData2 = this.RoleSkinList[this.CurSelectSkinIndex];
				this.RefreshUi(roleSkinData2);
			}
		}

		// Token: 0x06034732 RID: 214834 RVA: 0x00D1F9EC File Offset: 0x00D1DBEC
		private UniTask LoadCurveResource()
		{
			RoleSkinTabView.<LoadCurveResource>d__15 <LoadCurveResource>d__;
			<LoadCurveResource>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadCurveResource>d__.<>1__state = -1;
			<LoadCurveResource>d__.<>t__builder.Start<RoleSkinTabView.<LoadCurveResource>d__15>(ref <LoadCurveResource>d__);
			return <LoadCurveResource>d__.<>t__builder.Task;
		}

		// Token: 0x06034733 RID: 214835 RVA: 0x00D1FA27 File Offset: 0x00D1DC27
		private RoleSkinItem InitSkinItem(AActor actor, int _1, int _2)
		{
			RoleSkinItem roleSkinItem = new RoleSkinItem();
			roleSkinItem.CreateThenShowByActor(actor, null);
			roleSkinItem.ButtonFunction = new Action<int>(this.OnMoveSkinItem);
			return roleSkinItem;
		}

		// Token: 0x06034734 RID: 214836 RVA: 0x00D1FA48 File Offset: 0x00D1DC48
		private void InitSkinLayout()
		{
			this.RoleSkinList = ModelBase<RoleSkinModel>.Instance.GetRoleSkinDataList(this.RootViewModel.RoleId);
			this.SkinLayout.ReloadView(this.RoleSkinList.Count, this.RoleSkinList.ToArray(), 0);
		}

		// Token: 0x06034735 RID: 214837 RVA: 0x00D1FA88 File Offset: 0x00D1DC88
		private void SwitchSelectRoleSkin(RoleSkinData roleSkinData)
		{
			bool isWearWeaponSkin = roleSkinData.IsWearWeaponSkin();
			this.ViewModel.SetIsWearWeaponSkin(isWearWeaponSkin, false);
			this.ViewModel.SetSelectRoleSkinId(roleSkinData.GetItemId(), false);
		}

		// Token: 0x06034736 RID: 214838 RVA: 0x00D1FABC File Offset: 0x00D1DCBC
		private void RefreshUi(RoleSkinData roleSkinData)
		{
			bool isWearWeaponSkin = this.ViewModel.GetIsWearWeaponSkin();
			RoleSkin roleSkinConfig = roleSkinData.GetRoleSkinConfig();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), roleSkinConfig.TitleName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), roleSkinConfig.SubDecName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), roleSkinConfig.BgDescription, Array.Empty<object>());
			this.ObtainLayout.SetActive(roleSkinData.IsLocked() && roleSkinConfig.ItemAccess().Length != 0);
			this.RefreshWearButton(roleSkinData, isWearWeaponSkin);
			this.RefreshObtainLayout(roleSkinConfig.Id);
			base.GetButton(4).RootUIComp.Get().SetUIActive(this.CurSelectSkinIndex > 0);
			base.GetButton(5).RootUIComp.Get().SetUIActive(this.CurSelectSkinIndex < this.RoleSkinList.Count - 1);
			this.CurrentSelectSkinIsOrigin = roleSkinData.IsOriginalSkin();
			base.GetButton(3).RootUIComp.Get().SetUIActive(!this.CurrentSelectSkinIsOrigin);
			base.GetItem(9).SetUIActive(roleSkinConfig.SuitWeaponSkinId > 0);
			bool flag = ModelBase<RoleSkinModel>.Instance.CheckSuitWeaponFirstWear(roleSkinConfig.SuitWeaponSkinId);
			if (flag && isWearWeaponSkin)
			{
				flag = false;
				RoleSkinModel instance = ModelBase<RoleSkinModel>.Instance;
				if (instance != null)
				{
					instance.RecordSuitWeaponFirstWear(roleSkinConfig.SuitWeaponSkinId, false);
				}
			}
			base.GetUiNiagara(16).SetUIActive(flag);
			ControllerBase<RoleController>.Instance.RefreshUiSceneRoleActor(this.RootViewModel.TsUiSceneRoleActor, this.RootViewModel.RoleId, roleSkinData.ItemId, null);
			bool flag2 = isWearWeaponSkin && roleSkinConfig.SuitWeaponSkinId > 0;
			if (flag2)
			{
				this.RefreshWeaponSkin(roleSkinData);
			}
			this.RefreshWearWeaponButton(roleSkinData, isWearWeaponSkin);
			this.RefreshRoleMontage(flag2);
			this.RefreshRoleSkinRedDot(roleSkinData);
		}

		// Token: 0x06034737 RID: 214839 RVA: 0x00D1FC98 File Offset: 0x00D1DE98
		private void RefreshWearWeaponButton(RoleSkinData roleSkinData, bool isWearWeaponSkin)
		{
			EToggleState state = isWearWeaponSkin ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(10).SetToggleStateForce(state, false, false, false);
			UiCameraHandleData lastHandleData = Singleton<UiCameraAnimationManager>.Instance.GetLastHandleData();
			if (lastHandleData != null)
			{
				Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(lastHandleData.HandleName, true, true, "1001", false, null, null);
			}
			this.ActiveRoleTabCameraInput();
		}

		// Token: 0x06034738 RID: 214840 RVA: 0x00D1FCF8 File Offset: 0x00D1DEF8
		private void RefreshWearButton(RoleSkinData roleSkinData, bool isWearWeaponSkin)
		{
			UUIButtonComponent button = base.GetButton(14);
			button.RootUIComp.Get().SetUIActive(!roleSkinData.IsLocked());
			button.SetSelfInteractive(this.CanWearSkin(roleSkinData, isWearWeaponSkin));
		}

		// Token: 0x06034739 RID: 214841 RVA: 0x00D1FD38 File Offset: 0x00D1DF38
		private void RefreshRoleSkinRedDot(RoleSkinData skinData)
		{
			if (skinData.IsLocked())
			{
				return;
			}
			ModelBase<NewFlagModel>.Instance.RemoveNewFlag(ELocalStoragePlayerKey.RoleSkinRedDot, skinData.GetItemId());
			ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.RoleSkinRedDot);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RoleSkinRedDotRefresh, skinData.GetRoleId());
			Singleton<EventSystem>.Instance.Emit(EEventName.MainViewRoleButtonRefreshByRoleSkin);
		}

		// Token: 0x0603473A RID: 214842 RVA: 0x00D1FD94 File Offset: 0x00D1DF94
		public bool CanWearSkin(RoleSkinData roleSkinData, bool isWearWeaponSkin)
		{
			if (roleSkinData.IsLocked())
			{
				return false;
			}
			if (!roleSkinData.IsWear())
			{
				return true;
			}
			int suitWeaponSkinId = roleSkinData.GetRoleSkinConfig().SuitWeaponSkinId;
			if (suitWeaponSkinId <= 0)
			{
				return false;
			}
			bool flag = ModelBase<WeaponSkinModel>.Instance.GetSkinIdByRoleId(roleSkinData.GetRoleId()) == suitWeaponSkinId;
			return (!flag || !isWearWeaponSkin) && (flag || isWearWeaponSkin);
		}

		// Token: 0x0603473B RID: 214843 RVA: 0x00D1FDEC File Offset: 0x00D1DFEC
		private void RefreshWeaponSkin(RoleSkinData roleSkinData)
		{
			if (roleSkinData.GetRoleSkinConfig().SuitWeaponSkinId <= 0)
			{
				this.RefreshRoleWeaponSkin();
				return;
			}
			WeaponSkin weaponSkinConfig = ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfig(roleSkinData.GetRoleSkinConfig().SuitWeaponSkinId);
			TsUiSceneRoleActor tsUiSceneRoleActor = this.RootViewModel.TsUiSceneRoleActor;
			if (tsUiSceneRoleActor == null)
			{
				return;
			}
			UiModelBase model = tsUiSceneRoleActor.Model;
			if (model == null)
			{
				return;
			}
			UiRoleWeaponComponent uiRoleWeaponComponent = model.CheckGetComponent<UiRoleWeaponComponent>();
			if (uiRoleWeaponComponent == null)
			{
				return;
			}
			uiRoleWeaponComponent.ReplaceWeaponModel(weaponSkinConfig.Models(), null);
		}

		// Token: 0x0603473C RID: 214844 RVA: 0x00D1FE5C File Offset: 0x00D1E05C
		private void RefreshRoleWeaponSkin()
		{
			int skinIdByRoleId = ModelBase<WeaponSkinModel>.Instance.GetSkinIdByRoleId(this.RootViewModel.RoleId);
			TsUiSceneRoleActor tsUiSceneRoleActor = this.RootViewModel.TsUiSceneRoleActor;
			if (skinIdByRoleId == -1)
			{
				WeaponConf value = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(this.RootViewModel.WeaponIncId).GetWeaponConfig().Value;
				if (tsUiSceneRoleActor != null)
				{
					UiModelBase model = tsUiSceneRoleActor.Model;
					if (model == null)
					{
						return;
					}
					UiRoleWeaponComponent uiRoleWeaponComponent = model.CheckGetComponent<UiRoleWeaponComponent>();
					if (uiRoleWeaponComponent == null)
					{
						return;
					}
					uiRoleWeaponComponent.ReplaceWeaponModel(value.Models(), null);
					return;
				}
			}
			else
			{
				WeaponSkin weaponSkinConfig = ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfig(skinIdByRoleId);
				if (tsUiSceneRoleActor != null)
				{
					UiModelBase model2 = tsUiSceneRoleActor.Model;
					if (model2 == null)
					{
						return;
					}
					UiRoleWeaponComponent uiRoleWeaponComponent2 = model2.CheckGetComponent<UiRoleWeaponComponent>();
					if (uiRoleWeaponComponent2 == null)
					{
						return;
					}
					uiRoleWeaponComponent2.ReplaceWeaponModel(weaponSkinConfig.Models(), null);
				}
			}
		}

		// Token: 0x0603473D RID: 214845 RVA: 0x00D1FF0A File Offset: 0x00D1E10A
		private void RefreshRoleMontage(bool showWeapon)
		{
			if (showWeapon)
			{
				ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Weapon, false, false, false);
				return;
			}
			ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Attribute_Perform, false, false, false);
		}

		// Token: 0x0603473E RID: 214846 RVA: 0x00D1FF2C File Offset: 0x00D1E12C
		protected override void OnBeforeShow()
		{
			SkinTabViewParam tabViewParam = this.RootViewModel.GetTabViewParam();
			if (tabViewParam != null && tabViewParam.SkinId != null)
			{
				this.ViewModel.SetSelectRoleSkinId(tabViewParam.SkinId.Value, true);
			}
			int num = this.RoleSkinList.FindIndex((RoleSkinData data) => data.ItemId == this.ViewModel.GetSelectRoleSkinId());
			this.SkinLayout.AttachToIndex(num, true);
			this.CurSelectSkinIndex = num;
			RoleSkinData roleSkinData = this.RoleSkinList[this.CurSelectSkinIndex];
			this.SkinLayout.RefreshItems();
			this.SwitchSelectRoleSkin(roleSkinData);
			this.RootViewModel.SetModelState(EModelStateInSkinView.ShowRole, false);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnRoleSkinSubViewShow, this.CurSelectSkinIndex == 0 && this.RoleSkinList.Count > 1);
		}

		// Token: 0x0603473F RID: 214847 RVA: 0x00D1FFF4 File Offset: 0x00D1E1F4
		private void RefreshObtainLayout(int itemId)
		{
			List<IGetWayItemData> getWayDataList = ModelBase<InventoryModel>.Instance.GetGetWayDataList(itemId);
			this.ObtainLayout.RefreshByData(getWayDataList, null, false);
		}

		// Token: 0x06034740 RID: 214848 RVA: 0x00D2001B File Offset: 0x00D1E21B
		private RoleSkinObtainItem InitObtainItem()
		{
			return new RoleSkinObtainItem();
		}

		// Token: 0x06034741 RID: 214849 RVA: 0x00D20022 File Offset: 0x00D1E222
		protected override void OnBeforeHide()
		{
			this.RevertWeaponSkin();
			this.RootViewModel.EndCameraInput();
		}

		// Token: 0x06034742 RID: 214850 RVA: 0x00D20035 File Offset: 0x00D1E235
		protected override void OnBeforeDestroy()
		{
			this.RootViewModel.UnBind(new Action<ESkinRootViewData>(this.OnRootViewModelUpdate));
			this.ViewModel.UnBind(new Action<ERoleSkinTabViewData>(this.OnViewModelUpdate));
		}

		// Token: 0x06034743 RID: 214851 RVA: 0x00D20065 File Offset: 0x00D1E265
		private void OnSkinRootViewDestroy()
		{
			this.RevertWeaponSkin();
			this.RevertRoleSkin();
			this.RootViewModel.EndCameraInput();
		}

		// Token: 0x06034744 RID: 214852 RVA: 0x00D2007E File Offset: 0x00D1E27E
		private void RevertWeaponSkin()
		{
			this.RefreshRoleWeaponSkin();
		}

		// Token: 0x06034745 RID: 214853 RVA: 0x00D20088 File Offset: 0x00D1E288
		private void RevertRoleSkin()
		{
			RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(this.RootViewModel.RoleId);
			if (roleInstanceById == null || this.RootViewModel.TsUiSceneRoleActor == null)
			{
				return;
			}
			ControllerBase<RoleController>.Instance.RefreshUiSceneRoleActor(this.RootViewModel.TsUiSceneRoleActor, this.RootViewModel.RoleId, roleInstanceById.GetRoleSkinId(), null);
		}

		// Token: 0x06034746 RID: 214854 RVA: 0x00D200E3 File Offset: 0x00D1E2E3
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnSkinRootViewDestroy, new Action(this.OnSkinRootViewDestroy));
		}

		// Token: 0x06034747 RID: 214855 RVA: 0x00D20101 File Offset: 0x00D1E301
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnSkinRootViewDestroy, new Action(this.OnSkinRootViewDestroy));
		}

		// Token: 0x06034748 RID: 214856 RVA: 0x00D2011F File Offset: 0x00D1E31F
		private bool CanChangeSkin()
		{
			if (this.LastChangeSkinTime != 0.0 && Singleton<Time>.Instance.Now - this.LastChangeSkinTime <= (double)this.ChangeSkinInternal)
			{
				return false;
			}
			this.LastChangeSkinTime = Singleton<Time>.Instance.Now;
			return true;
		}

		// Token: 0x06034749 RID: 214857 RVA: 0x00D20160 File Offset: 0x00D1E360
		private void OnMoveSkinItem(int showIndex)
		{
			if (this.CurSelectSkinIndex == showIndex)
			{
				return;
			}
			this.CurSelectSkinIndex = showIndex;
			if (this.SkinLayout.GetCurrentSelectIndex() != showIndex)
			{
				this.SkinLayout.AttachToIndex(showIndex, false);
			}
			RoleSkinData roleSkinData = this.RoleSkinList[this.CurSelectSkinIndex];
			this.SwitchSelectRoleSkin(roleSkinData);
			ControllerBase<GuideController>.Instance.TryFinishRunningGuides();
		}

		// Token: 0x0603474A RID: 214858 RVA: 0x00D201BC File Offset: 0x00D1E3BC
		private void OnClickHideViewToggle(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
				if (uiViewSequence != null)
				{
					uiViewSequence.PlaySequence("UiIn", false, null);
				}
				this.RootViewModel.SetCaptionItemActive(true);
				base.GetButton(3).RootUIComp.Get().SetUIActive(!this.CurrentSelectSkinIsOrigin);
			}
			else
			{
				UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
				if (uiViewSequence2 != null)
				{
					uiViewSequence2.PlaySequence("UiOut", false, null);
				}
				this.RootViewModel.SetCaptionItemActive(false);
				base.GetButton(3).RootUIComp.Get().SetUIActive(false);
			}
			ControllerBase<GuideController>.Instance.TryFinishRunningGuides();
		}

		// Token: 0x0603474B RID: 214859 RVA: 0x00D20270 File Offset: 0x00D1E470
		private void OnClickSkinDetailButton()
		{
			RoleSkinData roleSkinData = this.RoleSkinList[this.CurSelectSkinIndex];
			ControllerBase<SkinController>.Instance.OpenSkinShowView(roleSkinData.GetItemId());
		}

		// Token: 0x0603474C RID: 214860 RVA: 0x00D202A0 File Offset: 0x00D1E4A0
		private void OnClickLeftArrowButton()
		{
			if (!this.CanChangeSkin())
			{
				return;
			}
			this.CurSelectSkinIndex--;
			this.SwitchSelectRoleSkin(this.RoleSkinList[this.CurSelectSkinIndex]);
			this.SkinLayout.AttachToIndex(this.CurSelectSkinIndex, false);
		}

		// Token: 0x0603474D RID: 214861 RVA: 0x00D202F0 File Offset: 0x00D1E4F0
		private void OnClickRightArrowButton()
		{
			if (!this.CanChangeSkin())
			{
				return;
			}
			this.CurSelectSkinIndex++;
			this.SwitchSelectRoleSkin(this.RoleSkinList[this.CurSelectSkinIndex]);
			this.SkinLayout.AttachToIndex(this.CurSelectSkinIndex, false);
		}

		// Token: 0x0603474E RID: 214862 RVA: 0x00D20340 File Offset: 0x00D1E540
		private void OnClickWearWeaponToggle(EToggleState state)
		{
			bool flag = state == EToggleState.ETT_Checked;
			this.ViewModel.SetIsWearWeaponSkin(flag, false);
			RoleSkinData roleSkinData = this.RoleSkinList[this.CurSelectSkinIndex];
			int suitWeaponSkinId = roleSkinData.GetRoleSkinConfig().SuitWeaponSkinId;
			if (ModelBase<RoleSkinModel>.Instance.CheckSuitWeaponFirstWear(suitWeaponSkinId))
			{
				base.GetUiNiagara(16).SetUIActive(false);
				ModelBase<RoleSkinModel>.Instance.RecordSuitWeaponFirstWear(suitWeaponSkinId, false);
			}
			if (flag)
			{
				WeaponSkin weaponSkinConfig = ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfig(roleSkinData.GetRoleSkinConfig().SuitWeaponSkinId);
				TsUiSceneRoleActor tsUiSceneRoleActor = this.RootViewModel.TsUiSceneRoleActor;
				if (tsUiSceneRoleActor != null)
				{
					UiModelBase model = tsUiSceneRoleActor.Model;
					if (model != null)
					{
						UiRoleWeaponComponent uiRoleWeaponComponent = model.CheckGetComponent<UiRoleWeaponComponent>();
						if (uiRoleWeaponComponent != null)
						{
							uiRoleWeaponComponent.ReplaceWeaponModel(weaponSkinConfig.Models(), null);
						}
					}
				}
			}
			this.RefreshWearWeaponButton(roleSkinData, flag);
			this.RefreshWearButton(roleSkinData, flag);
			this.RefreshRoleMontage(flag);
		}

		// Token: 0x0603474F RID: 214863 RVA: 0x00D2040F File Offset: 0x00D1E60F
		private bool OnCanExecuteChange()
		{
			return this.CanChangeSkin();
		}

		// Token: 0x06034750 RID: 214864 RVA: 0x00D20418 File Offset: 0x00D1E618
		private void OnClickWearWeaponTipButton()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoleSkinTip);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06034751 RID: 214865 RVA: 0x00D2043C File Offset: 0x00D1E63C
		private void OnClickWearButton()
		{
			if (!ControllerBase<SkinController>.Instance.CheckCanWearSkinAndShowTip())
			{
				return;
			}
			RoleSkinData roleSkinData = this.RoleSkinList[this.CurSelectSkinIndex];
			ControllerBase<RoleController>.Instance.RoleSkinChangeRequest(this.RootViewModel.RoleId, roleSkinData.ItemId, this.ViewModel.GetIsWearWeaponSkin(), new Action<int, bool>(this.OnRoleSkinChange));
		}

		// Token: 0x06034752 RID: 214866 RVA: 0x00D2049C File Offset: 0x00D1E69C
		private void OnRoleSkinChange(int skinId, bool isWearWeaponSkin)
		{
			RoleSkinData roleSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(skinId);
			this.RefreshWearButton(roleSkinData, isWearWeaponSkin);
			this.SkinLayout.RefreshItems();
		}

		// Token: 0x06034753 RID: 214867 RVA: 0x00D204C8 File Offset: 0x00D1E6C8
		private void ActiveRoleTabCameraInput()
		{
			IUiCameraInputComponentData roleTabCameraInputData = this.ViewModel.GetRoleTabCameraInputData(this.RootViewModel.GetDragItem(), this.RootViewModel.TsUiSceneRoleActor);
			this.RootViewModel.StartCameraInput(roleTabCameraInputData, new bool?(true), false);
		}

		// Token: 0x06034754 RID: 214868 RVA: 0x00D2050A File Offset: 0x00D1E70A
		private void OnClickOrnamentButton()
		{
			this.RootViewModel.SetTabViewParam(new SkinTabViewParam
			{
				SkinId = new int?(this.ViewModel.GetSelectRoleSkinId())
			});
			this.RootViewModel.SetSelectTabViewName(EUiTabViewName.RoleOrnamentTabView, false);
		}

		// Token: 0x06034755 RID: 214869 RVA: 0x00D20544 File Offset: 0x00D1E744
		private void RefreshSkinOrnament(RoleSkinData roleSkinData)
		{
			List<int> skinAllOrnaments = ModelBase<RoleOrnamentModel>.Instance.GetSkinAllOrnaments(roleSkinData.GetItemId(), new bool?(true));
			UUIItem item = base.GetItem(17);
			if (skinAllOrnaments.Count == 0)
			{
				item.SetUIActive(false);
				return;
			}
			item.SetUIActive(true);
			if (this.OrnamentLayout == null)
			{
				this.OrnamentLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetGridLayout(19), new Func<CommonItemSmallItemGrid>(this.CreateOrnamentItem), base.GetItem(20).GetOwner() as AUIBaseActor, false, true);
			}
			List<TItem> dataList = new List<TItem>();
			foreach (int itemId in skinAllOrnaments)
			{
				dataList.Add(new TItem
				{
					ItemData = new InventoryDefine.GetItemData(itemId, 0),
					Count = 0
				});
			}
			this.OrnamentLayout.RefreshByData(dataList, delegate
			{
				for (int i = 0; i < dataList.Count; i++)
				{
					CommonItemSmallItemGrid layoutItemByIndex = this.OrnamentLayout.GetLayoutItemByIndex(i);
					if (layoutItemByIndex != null)
					{
						int itemId2 = dataList[i].ItemData.ItemId;
						bool selectVisible = ModelBase<RoleOrnamentModel>.Instance.IsSkinWearingOrnament(itemId2, roleSkinData.GetItemId(), true);
						layoutItemByIndex.SetSelectVisible(selectVisible);
						layoutItemByIndex.SetLockBlackVisible(!ModelBase<RoleOrnamentModel>.Instance.IsOwnOrnament(itemId2));
					}
				}
			}, false);
		}

		// Token: 0x06034756 RID: 214870 RVA: 0x00D2066C File Offset: 0x00D1E86C
		private CommonItemSmallItemGrid CreateOrnamentItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x0401E362 RID: 123746
		private NoCircleAttachView<RoleSkinData, RoleSkinItem> SkinLayout;

		// Token: 0x0401E363 RID: 123747
		protected GenericLayout<RoleSkinObtainItem, IGetWayItemData> ObtainLayout;

		// Token: 0x0401E364 RID: 123748
		private SkinRootViewModel RootViewModel;

		// Token: 0x0401E365 RID: 123749
		private RoleSkinViewModel ViewModel;

		// Token: 0x0401E366 RID: 123750
		private List<RoleSkinData> RoleSkinList;

		// Token: 0x0401E367 RID: 123751
		private GenericLayout<CommonItemSmallItemGrid, TItem> OrnamentLayout;

		// Token: 0x0401E368 RID: 123752
		private int CurSelectSkinIndex;

		// Token: 0x0401E369 RID: 123753
		private int ChangeSkinInternal;

		// Token: 0x0401E36A RID: 123754
		private double LastChangeSkinTime;

		// Token: 0x0401E36B RID: 123755
		private bool CurrentSelectSkinIsOrigin = true;

		// Token: 0x0200AF8C RID: 44940
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x04036793 RID: 223123
			DragRoot,
			// Token: 0x04036794 RID: 223124
			DragItem,
			// Token: 0x04036795 RID: 223125
			HideViewToggle,
			// Token: 0x04036796 RID: 223126
			SkinDetailButton,
			// Token: 0x04036797 RID: 223127
			LeftArrowButton,
			// Token: 0x04036798 RID: 223128
			RightArrowButton,
			// Token: 0x04036799 RID: 223129
			SkinName,
			// Token: 0x0403679A RID: 223130
			SkinSubName,
			// Token: 0x0403679B RID: 223131
			SkinDesc,
			// Token: 0x0403679C RID: 223132
			WearWeaponTipItem,
			// Token: 0x0403679D RID: 223133
			WearWeaponToggle,
			// Token: 0x0403679E RID: 223134
			WearWeaponTipButton,
			// Token: 0x0403679F RID: 223135
			GetWayLayout,
			// Token: 0x040367A0 RID: 223136
			GetWayItem,
			// Token: 0x040367A1 RID: 223137
			WearButton,
			// Token: 0x040367A2 RID: 223138
			TopAndRightItem,
			// Token: 0x040367A3 RID: 223139
			WeaponSkinGuideNiagara,
			// Token: 0x040367A4 RID: 223140
			OrnamentRoot,
			// Token: 0x040367A5 RID: 223141
			OrnamentButton,
			// Token: 0x040367A6 RID: 223142
			OrnamentItemLayout,
			// Token: 0x040367A7 RID: 223143
			OrnamentItem
		}
	}
}
