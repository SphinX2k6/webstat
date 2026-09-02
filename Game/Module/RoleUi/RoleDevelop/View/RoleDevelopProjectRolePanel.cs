using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.Data;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050C0 RID: 20672
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopProjectRolePanel : RoleDevelopProjectBasePanel
	{
		// Token: 0x06035424 RID: 218148 RVA: 0x00D5AAFC File Offset: 0x00D58CFC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickCallJumpButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035425 RID: 218149 RVA: 0x00D5ACCE File Offset: 0x00D58ECE
		protected override void OnStart()
		{
			this.InitRoleItemGrid();
			this.InitButtonItem();
			this.InitLayout();
		}

		// Token: 0x06035426 RID: 218150 RVA: 0x00D5ACE4 File Offset: 0x00D58EE4
		private void InitRoleItemGrid()
		{
			this.RoleItemGrid = new SmallItemGrid();
			this.RoleItemGrid.Initialize(base.GetItem(0).GetOwner());
			this.RoleItemGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanRoleItemGridExecuteChange));
			this.RoleItemGrid.SetExtendToggleEnable(false, false);
			this.RoleItemGrid.SetToggleInteractive(false);
		}

		// Token: 0x06035427 RID: 218151 RVA: 0x00D5AD44 File Offset: 0x00D58F44
		private void InitButtonItem()
		{
			this.NormalButtonItem = new ButtonItem(base.GetItem(4));
			this.NormalButtonItem.SetLocalTextNew("RoleProject_Button01", Array.Empty<object>());
			this.NormalButtonItem.SetFunction(new Action<int>(this.OnClickJumpButton));
			this.HighLightButtonItem = new ButtonItem(base.GetItem(5));
			this.HighLightButtonItem.SetLocalTextNew("RoleProject_Button01", Array.Empty<object>());
			this.HighLightButtonItem.SetFunction(new Action<int>(this.OnClickJumpButton));
		}

		// Token: 0x06035428 RID: 218152 RVA: 0x00D5ADCD File Offset: 0x00D58FCD
		private void InitLayout()
		{
			this.ItemLayout = new GenericLayout<RoleDevelopProjectMaterialItem, RoleDevelopProjectMaterialItemData>(base.GetVerticalLayout(8), new Func<RoleDevelopProjectMaterialItem>(this.CreateItem), null, false, true);
		}

		// Token: 0x06035429 RID: 218153 RVA: 0x00D5ADF0 File Offset: 0x00D58FF0
		public override void OnCommonItemCountAnyChange(int configId)
		{
			this.RefreshButtonItem();
			this.ItemLayout.RefreshWithoutDataSync();
		}

		// Token: 0x0603542A RID: 218154 RVA: 0x00D5AE03 File Offset: 0x00D59003
		protected override void OnRefreshView(bool forceRefresh)
		{
			if (RoleDevelopUtil.IsProspectRole(this.Data.GetId()))
			{
				this.RefreshProspectProjectView();
				return;
			}
			this.RefreshProjectView();
		}

		// Token: 0x0603542B RID: 218155 RVA: 0x00D5AE24 File Offset: 0x00D59024
		private void RefreshProspectProjectView()
		{
			int id = this.Data.GetId();
			RoleDevelopRoleBaseData developRoleData = this.Data.GetDevelopRoleData();
			RoleDevelopProjectBaseData projectData = this.Data.GetProjectData();
			ForecastCharacterSmallItemGrid parameters = new ForecastCharacterSmallItemGrid
			{
				Data = this.Data,
				RoleId = new int?(id)
			};
			this.RoleItemGrid.Apply<ForecastCharacterSmallItemGrid>(parameters);
			base.GetText(1).SetText(developRoleData.GetName(), true);
			base.GetItem(3).SetUIActive(false);
			base.GetText(2).SetUIActive(true);
			List<int> hotRoleGachaIds = RoleDevelopUtil.GetHotRoleGachaIds(id, true);
			base.GetButton(6).RootUIComp.Get().SetUIActive(hotRoleGachaIds.Count > 0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "RoleProject_TargetLevel", new <>z__ReadOnlySingleElementList<object>(projectData.GetRoleTargetLevel()));
			List<RoleDevelopProjectMaterialItemData> roleDevelopProjectViewItems = projectData.GetRoleDevelopProjectViewItems();
			this.ItemLayout.RefreshByData(roleDevelopProjectViewItems, null, false);
		}

		// Token: 0x0603542C RID: 218156 RVA: 0x00D5AF18 File Offset: 0x00D59118
		private void RefreshProjectView()
		{
			int id = this.Data.GetId();
			RoleDevelopProjectBaseData projectData = this.Data.GetProjectData();
			int roleTargetLevel = projectData.GetRoleTargetLevel();
			bool flag = ModelBase<RoleModel>.Instance.IsRoleOwned(id);
			UUIText text = base.GetText(2);
			UUIText text2 = base.GetText(10);
			UUIItem item = base.GetItem(4);
			UUIItem item2 = base.GetItem(5);
			UUIItem item3 = base.GetItem(7);
			base.GetText(1).SetText(this.Data.GetDevelopRoleData().GetName(), true);
			base.GetItem(3).SetUIActive(true);
			List<int> hotRoleGachaIds = RoleDevelopUtil.GetHotRoleGachaIds(id, true);
			base.GetButton(6).RootUIComp.Get().SetUIActive(hotRoleGachaIds.Count > 0);
			List<RoleDevelopProjectMaterialItemData> roleDevelopProjectViewItems = projectData.GetRoleDevelopProjectViewItems();
			foreach (RoleDevelopProjectMaterialItemData roleDevelopProjectMaterialItemData in roleDevelopProjectViewItems)
			{
				ERoleDevelopLogSubPage value;
				if (this.RoleDevelopMaterialTypeToLogSubPageMap.TryGetValue(roleDevelopProjectMaterialItemData.GroupItem.Type, out value))
				{
					roleDevelopProjectMaterialItemData.LogSubPage = new ERoleDevelopLogSubPage?(value);
					roleDevelopProjectMaterialItemData.LogRoleId = new int?(id);
					roleDevelopProjectMaterialItemData.LogMainPage = new ERoleDevelopCategoryType?(ERoleDevelopCategoryType.Role);
				}
			}
			this.ItemLayout.RefreshByData(roleDevelopProjectViewItems, null, false);
			if (!flag)
			{
				text.SetUIActive(true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoleProject_TargetLevel", new <>z__ReadOnlySingleElementList<object>(roleTargetLevel));
				item.SetUIActive(false);
				item2.SetUIActive(false);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "RoleProject_Tips07", Array.Empty<object>());
				bool flag2 = RoleDevelopUtil.IsCurrentVersionProspectRoleInProspect(id);
				item3.SetUIActive(!flag2);
				if (flag2)
				{
					ForecastCharacterSmallItemGrid parameters = new ForecastCharacterSmallItemGrid
					{
						Data = this.Data,
						RoleId = new int?(id)
					};
					this.RoleItemGrid.Apply<ForecastCharacterSmallItemGrid>(parameters);
					return;
				}
				RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(id);
				CharacterSmallItemGrid parameters2 = new CharacterSmallItemGrid
				{
					ItemConfigId = new int?(id),
					Data = this.Data,
					ElementId = new int?(roleConfig.Value.ElementId)
				};
				this.RoleItemGrid.Apply<CharacterSmallItemGrid>(parameters2);
				return;
			}
			else
			{
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(id, true);
				RoleLevelData levelData = roleDataById.GetLevelData();
				int level = levelData.GetLevel();
				CharacterSmallItemGrid parameters3 = new CharacterSmallItemGrid
				{
					ItemConfigId = new int?(roleDataById.GetDataId()),
					SkinId = new int?(roleDataById.GetRoleSkinId()),
					BottomTextId = "Text_LevelShow_Text",
					BottomTextParameter = new object[]
					{
						level
					},
					Data = this.Data,
					ElementId = new int?(roleDataById.GetElementInfo().Value.Id)
				};
				this.RoleItemGrid.Apply<CharacterSmallItemGrid>(parameters3);
				bool flag3 = level >= roleTargetLevel;
				bool roleIsMaxLevel = levelData.GetRoleIsMaxLevel();
				if (flag3 && roleIsMaxLevel)
				{
					text.SetUIActive(false);
					item.SetUIActive(false);
					item2.SetUIActive(false);
					item3.SetUIActive(true);
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "RoleProject_Tips06", Array.Empty<object>());
					return;
				}
				text.SetUIActive(true);
				item3.SetUIActive(false);
				if (flag3)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoleProject_Tips04", Array.Empty<object>());
				}
				else
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoleProject_TargetLevel", new <>z__ReadOnlySingleElementList<object>(roleTargetLevel));
				}
				this.RefreshButtonItem();
				return;
			}
		}

		// Token: 0x0603542D RID: 218157 RVA: 0x00D5B2A0 File Offset: 0x00D594A0
		private void RefreshButtonItem()
		{
			int id = this.Data.GetId();
			RoleDevelopRoleBaseData developRoleData = this.Data.GetDevelopRoleData();
			RoleDevelopProjectBaseData projectData = this.Data.GetProjectData();
			if (developRoleData.IsRoleNeedBreakUp() && ModelBase<RoleModel>.Instance.GetRoleBreachState(id) == ERoleBreachState.NoEnoughCondition)
			{
				this.SetButtonState(false, "RoleProject_Button02");
				return;
			}
			bool isHighLight = RoleDevelopUtil.CheckIsAllNeedItemsEnoughOrCanBeFilled(projectData.GetRoleDevelopNeedItems());
			this.SetButtonState(isHighLight, "RoleProject_Button01");
		}

		// Token: 0x0603542E RID: 218158 RVA: 0x00D5B30A File Offset: 0x00D5950A
		private void SetButtonState(bool isHighLight, string textKey)
		{
			this.NormalButtonItem.SetUiActive(!isHighLight);
			this.HighLightButtonItem.SetUiActive(isHighLight);
			(isHighLight ? this.HighLightButtonItem : this.NormalButtonItem).SetLocalTextNew(textKey, Array.Empty<object>());
		}

		// Token: 0x0603542F RID: 218159 RVA: 0x00D5B344 File Offset: 0x00D59544
		private void OnClickCallJumpButton()
		{
			List<int> hotRoleGachaIds = RoleDevelopUtil.GetHotRoleGachaIds(this.Data.GetId(), true);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaMainView, hotRoleGachaIds[0], null);
		}

		// Token: 0x06035430 RID: 218160 RVA: 0x00D5B380 File Offset: 0x00D59580
		private void OnClickJumpButton(int value)
		{
			int id = this.Data.GetId();
			if (!ModelBase<RoleModel>.Instance.IsRoleOwned(id))
			{
				return;
			}
			bool flag = this.Data.GetDevelopRoleData().IsRoleNeedBreakUp();
			RoleViewViewModel roleViewViewModel = new RoleViewViewModel(id, !Singleton<UiSceneManager>.Instance.HasRoleSystemRoleActor(), ERoleViewSource.Normal);
			roleViewViewModel.FadeInCurveId = ERoleFadeCurveDefine.RoleFadeInCurve;
			roleViewViewModel.FadeOutCurveId = ERoleFadeCurveDefine.RoleFadeOutCurve;
			roleViewViewModel.NeedShowOnViewPlayingStartSequence = true;
			roleViewViewModel.NeedHideOnViewPlayingCloseSequence = true;
			roleViewViewModel.RoleStatePlayContextOnShow = null;
			roleViewViewModel.RoleStatePlayContextOnHide = null;
			if (flag)
			{
				ControllerBase<RoleController>.Instance.OpenRoleViewByViewModel(EUiViewName.RoleBreachView, roleViewViewModel);
			}
			else
			{
				ControllerBase<RoleController>.Instance.OpenRoleViewByViewModel(EUiViewName.RoleLevelUpView, roleViewViewModel);
			}
			ControllerBase<RoleController>.Instance.LogRoleDevelopClick(id, ERoleDevelopCategoryType.Role, ERoleDevelopLogSubPage.RoleDevelopJump, new ERoleDevelopLogItemState?(ERoleDevelopLogItemState.Normal));
		}

		// Token: 0x06035431 RID: 218161 RVA: 0x00D5B435 File Offset: 0x00D59635
		private bool CanRoleItemGridExecuteChange(object parameters, bool _, EToggleState state)
		{
			return false;
		}

		// Token: 0x06035432 RID: 218162 RVA: 0x00D5B438 File Offset: 0x00D59638
		private RoleDevelopProjectMaterialItem CreateItem()
		{
			return new RoleDevelopProjectMaterialItem();
		}

		// Token: 0x0401EA46 RID: 125510
		private readonly Dictionary<EItemMaterialType, ERoleDevelopLogSubPage> RoleDevelopMaterialTypeToLogSubPageMap = new Dictionary<EItemMaterialType, ERoleDevelopLogSubPage>
		{
			{
				EItemMaterialType.RoleExp,
				ERoleDevelopLogSubPage.RoleDevelopExpMaterial
			},
			{
				EItemMaterialType.RoleBreak,
				ERoleDevelopLogSubPage.RoleDevelopBreakMaterial
			},
			{
				EItemMaterialType.WeaponSkill,
				ERoleDevelopLogSubPage.RoleDevelopWeaponAndSkillMaterial
			},
			{
				EItemMaterialType.Map,
				ERoleDevelopLogSubPage.RoleDevelopMapMaterial
			},
			{
				EItemMaterialType.Drop,
				ERoleDevelopLogSubPage.RoleDevelopWeaponAndSkillMaterial
			}
		};

		// Token: 0x0401EA47 RID: 125511
		private SmallItemGrid RoleItemGrid;

		// Token: 0x0401EA48 RID: 125512
		private ButtonItem NormalButtonItem;

		// Token: 0x0401EA49 RID: 125513
		private ButtonItem HighLightButtonItem;

		// Token: 0x0401EA4A RID: 125514
		private GenericLayout<RoleDevelopProjectMaterialItem, RoleDevelopProjectMaterialItemData> ItemLayout;

		// Token: 0x0200B050 RID: 45136
		[NullableContext(0)]
		public static class EComponentType
		{
			// Token: 0x04036B30 RID: 224048
			public const int SmallRoleItem = 0;

			// Token: 0x04036B31 RID: 224049
			public const int TxtRoleName = 1;

			// Token: 0x04036B32 RID: 224050
			public const int TxtGoalLevel = 2;

			// Token: 0x04036B33 RID: 224051
			public const int PanelItemRight = 3;

			// Token: 0x04036B34 RID: 224052
			public const int NormalButtonItem = 4;

			// Token: 0x04036B35 RID: 224053
			public const int HighLightButtonItem = 5;

			// Token: 0x04036B36 RID: 224054
			public const int BtnCallJump = 6;

			// Token: 0x04036B37 RID: 224055
			public const int PanelItemNotObtained = 7;

			// Token: 0x04036B38 RID: 224056
			public const int PanelItemDetailLayout = 8;

			// Token: 0x04036B39 RID: 224057
			public const int PanelItemList = 9;

			// Token: 0x04036B3A RID: 224058
			public const int TxtNotObtained = 10;
		}
	}
}
