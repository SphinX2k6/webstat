using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Skin.Skip;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Skin.Tab.Weapon
{
	// Token: 0x02004F64 RID: 20324
	[NullableContext(1)]
	[Nullable(0)]
	public class WeaponSkinTabView : UiTabViewBase
	{
		// Token: 0x0603469F RID: 214687 RVA: 0x00D1CFD4 File Offset: 0x00D1B1D4
		protected override void OnRegisterComponent()
		{
			this.RootViewModel = (SkinRootViewModel)this.ExtraParams;
			this.ViewModel = new WeaponSkinViewModel();
			this.ViewModel.Init(this.RootViewModel.ViewData);
			this.ViewModel.Bind(new Action<EWeaponSkinTabViewData>(this.OnViewModelUpdate));
			this.InitWeaponModel(this.RootViewModel.WeaponIncId, this.ViewModel.GetSelectedSkinId());
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(4, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.WeaponHideUiClick)),
				new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.WeaponSwitchShowClick)),
				new ValueTuple<int, Delegate>(5, new Action(this.WeaponConfirmClick))
			};
		}

		// Token: 0x060346A0 RID: 214688 RVA: 0x00D1D184 File Offset: 0x00D1B384
		private UniTask InitGrid()
		{
			WeaponSkinTabView.<InitGrid>d__9 <InitGrid>d__;
			<InitGrid>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitGrid>d__.<>4__this = this;
			<InitGrid>d__.<>1__state = -1;
			<InitGrid>d__.<>t__builder.Start<WeaponSkinTabView.<InitGrid>d__9>(ref <InitGrid>d__);
			return <InitGrid>d__.<>t__builder.Task;
		}

		// Token: 0x060346A1 RID: 214689 RVA: 0x00D1D1C8 File Offset: 0x00D1B3C8
		protected override UniTask OnBeforeStartAsync()
		{
			WeaponSkinTabView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<WeaponSkinTabView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060346A2 RID: 214690 RVA: 0x00D1D20C File Offset: 0x00D1B40C
		protected override void OnStart()
		{
			this.ObtainLayout = new GenericLayout<SkinObtainItem, ISkinSkipData>(base.GetLayoutBase(6), new Func<SkinObtainItem>(this.InitObtainItem), base.GetItem(7).GetOwner() as AUIBaseActor, false, true);
			UUIExtendToggle extendToggle = base.GetExtendToggle(3);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			}
			EToggleState state = this.ViewModel.GetIsInShowWeapon() ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(4);
			if (extendToggle2 == null)
			{
				return;
			}
			extendToggle2.SetToggleState(state, false, false, false);
		}

		// Token: 0x060346A3 RID: 214691 RVA: 0x00D1D289 File Offset: 0x00D1B489
		protected override void AddEventListener()
		{
			WeaponSkinViewModel viewModel = this.ViewModel;
			if (viewModel == null)
			{
				return;
			}
			viewModel.AddEventListener();
		}

		// Token: 0x060346A4 RID: 214692 RVA: 0x00D1D29B File Offset: 0x00D1B49B
		protected override void RemoveEventListener()
		{
			WeaponSkinViewModel viewModel = this.ViewModel;
			if (viewModel == null)
			{
				return;
			}
			viewModel.RemoveEventListener();
		}

		// Token: 0x060346A5 RID: 214693 RVA: 0x00D1D2B0 File Offset: 0x00D1B4B0
		protected override void OnBeforeShow()
		{
			this.ViewModel.RefreshEquipSkinId();
			if (this.IsFirstRefresh)
			{
				this.IsFirstRefresh = false;
			}
			else
			{
				this.GridLayout.RefreshByData(this.ViewModel.GetSkinDataList(), null, false);
			}
			this.UpdateGridSelected();
			ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Weapon, false, false, false);
			this.SwitchWeaponSkinModel(this.RootViewModel.WeaponIncId, this.ViewModel.GetSelectedSkinId(), this.ViewModel.GetIsInShowWeapon());
			if (this.ViewModel.GetIsInShowWeapon())
			{
				ModelBase<WeaponModel>.Instance.SetCurSelectViewName(EWeaponViewName.WeaponLevelUpView);
				this.RootViewModel.SetModelState(EModelStateInSkinView.ShowWeapon, false);
				return;
			}
			ModelBase<WeaponModel>.Instance.SetCurSelectViewName(EWeaponViewName.RoleWeaponTabView);
			this.RootViewModel.SetModelState(EModelStateInSkinView.ShowRole, false);
		}

		// Token: 0x060346A6 RID: 214694 RVA: 0x00D1D36C File Offset: 0x00D1B56C
		protected override void OnBeforeHide()
		{
			if (this.ViewModel.GetIsInShowWeapon())
			{
				this.ViewModel.SetIsInShowWeapon(false, true);
				EToggleState state = this.ViewModel.GetIsInShowWeapon() ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
				UUIExtendToggle extendToggle = base.GetExtendToggle(4);
				if (extendToggle != null)
				{
					extendToggle.SetToggleState(state, false, false, false);
				}
				this.RecoverySceneRoleActor();
				this.HideWeaponObserver();
				ModelBase<WeaponModel>.Instance.SetCurSelectViewName(EWeaponViewName.RoleWeaponTabView);
			}
		}

		// Token: 0x060346A7 RID: 214695 RVA: 0x00D1D3D4 File Offset: 0x00D1B5D4
		protected override void OnBeforeDestroy()
		{
			this.ViewModel.UnBind(new Action<EWeaponSkinTabViewData>(this.OnViewModelUpdate));
			Singleton<UiLayer>.Instance.SetShowMaskLayer("WeaponSkinCamera", false);
			this.ReleaseWeaponObserver();
			WeaponInstance weaponInstanceByRoleId = ModelBase<WeaponModel>.Instance.GetWeaponInstanceByRoleId(this.RootViewModel.RoleId);
			if (weaponInstanceByRoleId != null)
			{
				this.RecoverySceneRoleActorBySkin(weaponInstanceByRoleId.GetIncId().Value, this.ViewModel.GetEquipSkinId());
			}
		}

		// Token: 0x060346A8 RID: 214696 RVA: 0x00D1D448 File Offset: 0x00D1B648
		private void UpdateGridSelected()
		{
			int selectedSkinId = this.ViewModel.GetSelectedSkinId();
			int dataIndexBySkinId = this.ViewModel.GetDataIndexBySkinId(selectedSkinId);
			WeaponSkinData weaponSkinData = this.ViewModel.GetSkinDataList()[dataIndexBySkinId];
			this.RefreshBottom(weaponSkinData, this.ViewModel.GetEquipSkinId() == selectedSkinId);
			this.RefreshText(weaponSkinData.Name, weaponSkinData.Description);
			this.SelectedGrid(dataIndexBySkinId);
		}

		// Token: 0x060346A9 RID: 214697 RVA: 0x00D1D4AE File Offset: 0x00D1B6AE
		private void WeaponHideUiClick(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.ViewModel.SetWeaponUiVisible(true, false);
				this.RootViewModel.SetRootUiVisible(true, false);
				return;
			}
			this.ViewModel.SetWeaponUiVisible(false, false);
			this.RootViewModel.SetRootUiVisible(false, false);
		}

		// Token: 0x060346AA RID: 214698 RVA: 0x00D1D4E9 File Offset: 0x00D1B6E9
		private void WeaponSwitchShowClick(EToggleState state)
		{
			this.ViewModel.SetIsInShowWeapon(state == EToggleState.ETT_Checked, false);
		}

		// Token: 0x060346AB RID: 214699 RVA: 0x00D1D4FB File Offset: 0x00D1B6FB
		public void WeaponConfirmClick()
		{
			this.TrySendPbEquipTakeOnRequest(this.RootViewModel.RoleId, this.ViewModel.GetSelectedSkinId());
		}

		// Token: 0x060346AC RID: 214700 RVA: 0x00D1D51C File Offset: 0x00D1B71C
		private void OnViewModelUpdate(EWeaponSkinTabViewData data)
		{
			switch (data)
			{
			case EWeaponSkinTabViewData.IsInShowWeapon:
			{
				bool isInShowWeapon = this.ViewModel.GetIsInShowWeapon();
				int selectedSkinId = this.ViewModel.GetSelectedSkinId();
				if (isInShowWeapon)
				{
					this.SwitchWeaponShow(this.RootViewModel.WeaponIncId, selectedSkinId);
					return;
				}
				this.SwitchRoleWeaponShow(selectedSkinId);
				return;
			}
			case EWeaponSkinTabViewData.SkinDataList:
				break;
			case EWeaponSkinTabViewData.EquipSkinId:
			{
				int dataIndexBySkinId = this.ViewModel.GetDataIndexBySkinId(this.ViewModel.PrevEquipSkinId);
				int dataIndexBySkinId2 = this.ViewModel.GetDataIndexBySkinId(this.ViewModel.GetEquipSkinId());
				this.RefreshGridSelect(dataIndexBySkinId, dataIndexBySkinId2);
				this.RefreshConfirmBox(true);
				this.ShowEquipTips();
				return;
			}
			case EWeaponSkinTabViewData.SelectedSkinId:
			{
				int selectedSkinId2 = this.ViewModel.GetSelectedSkinId();
				this.UpdateGridSelected();
				this.SwitchWeaponSkinModel(this.RootViewModel.WeaponIncId, selectedSkinId2, this.ViewModel.GetIsInShowWeapon());
				break;
			}
			case EWeaponSkinTabViewData.WeaponUiVisible:
				if (this.ViewModel.GetWeaponUiVisible())
				{
					this.ShowView();
					return;
				}
				this.HideView();
				return;
			default:
				return;
			}
		}

		// Token: 0x060346AD RID: 214701 RVA: 0x00D1D606 File Offset: 0x00D1B806
		private WeaponSkinGridItem InitGridItem()
		{
			WeaponSkinGridItem weaponSkinGridItem = new WeaponSkinGridItem();
			weaponSkinGridItem.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.GridItemClick));
			weaponSkinGridItem.BindOnCanExecuteChange((object state, bool toggleState, EToggleState result) => this.ViewModel.GridItemCanExecuteChange(state));
			return weaponSkinGridItem;
		}

		// Token: 0x060346AE RID: 214702 RVA: 0x00D1D634 File Offset: 0x00D1B834
		private void GridItemClick(MediumItemGridExtendCallback parameters)
		{
			int skinId = ((WeaponSkinData)parameters.Data).SkinId;
			this.ViewModel.SetSelectedSkinId(skinId, false);
		}

		// Token: 0x060346AF RID: 214703 RVA: 0x00D1D65F File Offset: 0x00D1B85F
		private void HideWeaponObserver()
		{
			if (this.WeaponObserver != null)
			{
				Singleton<UiSceneManager>.Instance.HideObserver(this.WeaponObserver, "ShowHideWeaponEffect");
			}
			if (this.WeaponScabbardObserver != null)
			{
				Singleton<UiSceneManager>.Instance.HideObserver(this.WeaponScabbardObserver, "ShowHideWeaponEffect");
			}
		}

		// Token: 0x060346B0 RID: 214704 RVA: 0x00D1D69B File Offset: 0x00D1B89B
		private void ShowWeaponObserver(int weaponIncId, int skinId)
		{
			ControllerBase<WeaponController>.Instance.SelectedWeaponSkinChange(weaponIncId, skinId, this.WeaponObserver, this.WeaponScabbardObserver, false);
		}

		// Token: 0x060346B1 RID: 214705 RVA: 0x00D1D6B6 File Offset: 0x00D1B8B6
		private SkinObtainItem InitObtainItem()
		{
			return new SkinObtainItem();
		}

		// Token: 0x060346B2 RID: 214706 RVA: 0x00D1D6C0 File Offset: 0x00D1B8C0
		public void ReleaseWeaponObserver()
		{
			if (this.WeaponObserver != null)
			{
				Singleton<UiSceneManager>.Instance.HideObserverWithCallback(this.WeaponObserver, "ShowHideWeaponEffect", delegate(SkeletalObserverHandle observer)
				{
					Singleton<UiSceneManager>.Instance.DestroyWeaponObserver(observer);
				});
			}
			if (this.WeaponScabbardObserver != null)
			{
				Singleton<UiSceneManager>.Instance.HideObserverWithCallback(this.WeaponScabbardObserver, "ShowHideWeaponEffect", delegate(SkeletalObserverHandle observer)
				{
					Singleton<UiSceneManager>.Instance.DestroyWeaponScabbardObserver(observer);
				});
			}
		}

		// Token: 0x060346B3 RID: 214707 RVA: 0x00D1D748 File Offset: 0x00D1B948
		public void RecoverySceneRoleActor()
		{
			if (this.ViewModel.GetIsInShowWeapon())
			{
				this.RootViewModel.SetModelState(EModelStateInSkinView.ShowRole, false);
			}
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
			uiRoleWeaponComponent.Refresh();
		}

		// Token: 0x060346B4 RID: 214708 RVA: 0x00D1D798 File Offset: 0x00D1B998
		public void RecoverySceneRoleActorBySkin(int weaponIncId, int skinId)
		{
			if (this.ViewModel.GetIsInShowWeapon())
			{
				this.RootViewModel.SetModelState(EModelStateInSkinView.ShowRole, false);
			}
			WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(weaponIncId);
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
			uiRoleWeaponComponent.SetWeaponByWeaponData(weaponDataByIncId, skinId);
		}

		// Token: 0x060346B5 RID: 214709 RVA: 0x00D1D7F6 File Offset: 0x00D1B9F6
		public void SelectedGrid(int index)
		{
			this.GridLayout.DeselectCurrentGridProxy();
			this.GridLayout.SelectGridProxy(index, true);
		}

		// Token: 0x060346B6 RID: 214710 RVA: 0x00D1D810 File Offset: 0x00D1BA10
		public void RefreshText(string name, string bgDescription)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), bgDescription, Array.Empty<object>());
		}

		// Token: 0x060346B7 RID: 214711 RVA: 0x00D1D841 File Offset: 0x00D1BA41
		public void RefreshConfirmBox(bool isSame)
		{
			UUIButtonComponent button = base.GetButton(5);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(!isSame);
		}

		// Token: 0x060346B8 RID: 214712 RVA: 0x00D1D858 File Offset: 0x00D1BA58
		public void RefreshGridSelect(int lastIndex, int nowIndex)
		{
			WeaponSkinGridItem layoutItemByIndex = this.GridLayout.GetLayoutItemByIndex(lastIndex);
			if (layoutItemByIndex != null)
			{
				layoutItemByIndex.RefreshVisible();
			}
			WeaponSkinGridItem layoutItemByIndex2 = this.GridLayout.GetLayoutItemByIndex(nowIndex);
			if (layoutItemByIndex2 == null)
			{
				return;
			}
			layoutItemByIndex2.RefreshVisible();
		}

		// Token: 0x060346B9 RID: 214713 RVA: 0x00D1D888 File Offset: 0x00D1BA88
		public void RefreshBottom(WeaponSkinData data, bool isSame)
		{
			bool isLock = data.GetIsLock();
			UUIButtonComponent button = base.GetButton(5);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(!isLock);
			}
			this.ObtainLayout.SetActive(isLock);
			if (isLock)
			{
				WeaponSkin weaponSkinConfig = ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfig(data.SkinId);
				List<ISkinSkipData> skinSkipDataList = this.RootViewModel.GetSkinSkipDataList(data.SkinId, weaponSkinConfig.ItemAccess());
				this.ObtainLayout.SetActive(skinSkipDataList.Count != 0);
				if (skinSkipDataList.Count > 0)
				{
					this.ObtainLayout.RefreshByData(skinSkipDataList, null, false);
					return;
				}
			}
			else
			{
				UUIButtonComponent button2 = base.GetButton(5);
				if (button2 == null)
				{
					return;
				}
				button2.SetSelfInteractive(!isSame);
			}
		}

		// Token: 0x060346BA RID: 214714 RVA: 0x00D1D93C File Offset: 0x00D1BB3C
		public void HideView()
		{
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(4);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x060346BB RID: 214715 RVA: 0x00D1D97C File Offset: 0x00D1BB7C
		public void ShowView()
		{
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(4);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.RootUIComp.Get().SetUIActive(true);
		}

		// Token: 0x060346BC RID: 214716 RVA: 0x00D1D9BC File Offset: 0x00D1BBBC
		public void SwitchRoleWeaponShow(int skinId)
		{
			if (skinId == -1)
			{
				TsUiSceneRoleActor tsUiSceneRoleActor = this.RootViewModel.TsUiSceneRoleActor;
				if (tsUiSceneRoleActor != null)
				{
					UiModelBase model = tsUiSceneRoleActor.Model;
					if (model != null)
					{
						UiRoleWeaponComponent uiRoleWeaponComponent = model.CheckGetComponent<UiRoleWeaponComponent>();
						if (uiRoleWeaponComponent != null)
						{
							uiRoleWeaponComponent.Refresh();
						}
					}
				}
			}
			else
			{
				WeaponSkin weaponSkinConfig = ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfig(skinId);
				TsUiSceneRoleActor tsUiSceneRoleActor2 = this.RootViewModel.TsUiSceneRoleActor;
				if (tsUiSceneRoleActor2 != null)
				{
					UiModelBase model2 = tsUiSceneRoleActor2.Model;
					if (model2 != null)
					{
						UiRoleWeaponComponent uiRoleWeaponComponent2 = model2.CheckGetComponent<UiRoleWeaponComponent>();
						if (uiRoleWeaponComponent2 != null)
						{
							uiRoleWeaponComponent2.ReplaceWeaponModel(weaponSkinConfig.Models(), null);
						}
					}
				}
			}
			this.RootViewModel.SetModelState(EModelStateInSkinView.ShowRole, false);
			this.HideWeaponObserver();
			UiCameraHandleData newHandleData = UiCameraHandleData.NewByView(EUiTabViewName.WeaponSkinTabView, null, null);
			Singleton<UiLayer>.Instance.SetShowMaskLayer("WeaponSkinCamera", true);
			Singleton<UiCameraAnimationManager>.Instance.PushCameraHandle(newHandleData, true, true, "1001", true, delegate(UiCameraAnimationDefine.IFinishData _)
			{
				Singleton<UiLayer>.Instance.SetShowMaskLayer("WeaponSkinCamera", false);
			});
			ModelBase<WeaponModel>.Instance.SetCurSelectViewName(EWeaponViewName.RoleWeaponTabView);
		}

		// Token: 0x060346BD RID: 214717 RVA: 0x00D1DAC0 File Offset: 0x00D1BCC0
		public void SwitchWeaponShow(int weaponIncId, int skinId)
		{
			this.RootViewModel.SetModelState(EModelStateInSkinView.ShowWeapon, false);
			Singleton<UiLayer>.Instance.SetShowMaskLayer("WeaponSkinCamera", true);
			Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName("1072", true, true, "1001", true, delegate(UiCameraAnimationDefine.IFinishData _)
			{
				Singleton<UiLayer>.Instance.SetShowMaskLayer("WeaponSkinCamera", false);
				ModelBase<WeaponModel>.Instance.SetCurSelectViewName(EWeaponViewName.WeaponLevelUpView);
				this.ShowWeaponObserver(weaponIncId, skinId);
			}, null);
		}

		// Token: 0x060346BE RID: 214718 RVA: 0x00D1DB34 File Offset: 0x00D1BD34
		private void InitWeaponObserver(int weaponIncId)
		{
			WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(weaponIncId);
			this.WeaponObserver = Singleton<UiSceneManager>.Instance.InitWeaponObserver(false);
			UiModelBase model = this.WeaponObserver.Model;
			UiWeaponDataComponent uiWeaponDataComponent = model.CheckGetComponent<UiWeaponDataComponent>();
			if (uiWeaponDataComponent != null)
			{
				uiWeaponDataComponent.SetWeaponData(weaponDataByIncId);
			}
			UiModelDataComponent uiModelDataComponent = model.CheckGetComponent<UiModelDataComponent>();
			if (uiModelDataComponent == null)
			{
				return;
			}
			uiModelDataComponent.SetLoadingIconFollowState(false);
		}

		// Token: 0x060346BF RID: 214719 RVA: 0x00D1DB8C File Offset: 0x00D1BD8C
		private void InitWeaponScabbardObserver(int weaponIncId)
		{
			WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(weaponIncId);
			this.WeaponScabbardObserver = Singleton<UiSceneManager>.Instance.InitWeaponScabbardObserver();
			this.WeaponScabbardObserver.Model.CheckGetComponent<UiWeaponDataComponent>().SetWeaponData(weaponDataByIncId);
		}

		// Token: 0x060346C0 RID: 214720 RVA: 0x00D1DBCB File Offset: 0x00D1BDCB
		public void InitWeaponModel(int weaponIncId, int skinId)
		{
			this.InitWeaponObserver(weaponIncId);
			this.InitWeaponScabbardObserver(weaponIncId);
		}

		// Token: 0x060346C1 RID: 214721 RVA: 0x00D1DBDC File Offset: 0x00D1BDDC
		public void SwitchWeaponSkinModel(int weaponIncId, int skinId, bool isInShowWeapon)
		{
			if (isInShowWeapon)
			{
				ControllerBase<WeaponController>.Instance.SelectedWeaponSkinChange(weaponIncId, skinId, this.WeaponObserver, this.WeaponScabbardObserver, false);
				return;
			}
			if (skinId == -1)
			{
				WeaponConf value = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(weaponIncId).GetWeaponConfig().Value;
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
				uiRoleWeaponComponent.ReplaceWeaponModel(value.Models(), null);
				return;
			}
			else
			{
				WeaponSkin weaponSkinConfig = ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfig(skinId);
				TsUiSceneRoleActor tsUiSceneRoleActor2 = this.RootViewModel.TsUiSceneRoleActor;
				if (tsUiSceneRoleActor2 == null)
				{
					return;
				}
				UiModelBase model2 = tsUiSceneRoleActor2.Model;
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
				return;
			}
		}

		// Token: 0x060346C2 RID: 214722 RVA: 0x00D1DC92 File Offset: 0x00D1BE92
		public void ShowEquipTips()
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("WeaponSkinReplaceTip", Array.Empty<object>());
		}

		// Token: 0x060346C3 RID: 214723 RVA: 0x00D1DCA8 File Offset: 0x00D1BEA8
		public void TrySendPbEquipTakeOnRequest(int roleId, int skinId)
		{
			int? roleIdBySkinId = ModelBase<WeaponSkinModel>.Instance.GetRoleIdBySkinId(skinId);
			Action action = delegate()
			{
				ControllerBase<WeaponSkinController>.Instance.SendEquipSkinRequest(roleId, skinId);
			};
			if (roleIdBySkinId != null)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.WeaponSkinReplace);
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfig(skinId).Name, null);
				string name = ModelBase<RoleModel>.Instance.GetRoleDataById(roleIdBySkinId.Value, true).GetName(null);
				confirmBoxDataNew.SetTextArgs(new string[]
				{
					localTextNew,
					name
				});
				confirmBoxDataNew.FunctionMap.Add(2, action);
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			action();
		}

		// Token: 0x0401E33B RID: 123707
		private SkinRootViewModel RootViewModel;

		// Token: 0x0401E33C RID: 123708
		private WeaponSkinViewModel ViewModel;

		// Token: 0x0401E33D RID: 123709
		protected GenericLayout<WeaponSkinGridItem, WeaponSkinData> GridLayout;

		// Token: 0x0401E33E RID: 123710
		protected GenericLayout<SkinObtainItem, ISkinSkipData> ObtainLayout;

		// Token: 0x0401E33F RID: 123711
		[Nullable(2)]
		private SkeletalObserverHandle WeaponObserver;

		// Token: 0x0401E340 RID: 123712
		[Nullable(2)]
		private SkeletalObserverHandle WeaponScabbardObserver;

		// Token: 0x0401E341 RID: 123713
		private bool IsFirstRefresh = true;

		// Token: 0x0200AF78 RID: 44920
		[NullableContext(0)]
		private enum EComponentDefine
		{
			// Token: 0x04036733 RID: 223027
			TopAndRightItem,
			// Token: 0x04036734 RID: 223028
			GridLayout,
			// Token: 0x04036735 RID: 223029
			GridItem,
			// Token: 0x04036736 RID: 223030
			HideUiToggle,
			// Token: 0x04036737 RID: 223031
			SwitchShowToggle,
			// Token: 0x04036738 RID: 223032
			ConfirmBtn,
			// Token: 0x04036739 RID: 223033
			ObtainLayout,
			// Token: 0x0403673A RID: 223034
			ObtainItem,
			// Token: 0x0403673B RID: 223035
			WeaponName,
			// Token: 0x0403673C RID: 223036
			WeaponDesc
		}
	}
}
