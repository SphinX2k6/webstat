using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.Data;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050C3 RID: 20675
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopProjectWeaponDevItem : UiPanelBase
	{
		// Token: 0x06035448 RID: 218184 RVA: 0x00D5C034 File Offset: 0x00D5A234
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickSwitch));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnClickCall));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035449 RID: 218185 RVA: 0x00D5C270 File Offset: 0x00D5A470
		protected override UniTask OnBeforeStartAsync()
		{
			RoleDevelopProjectWeaponDevItem.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevelopProjectWeaponDevItem.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603544A RID: 218186 RVA: 0x00D5C2B4 File Offset: 0x00D5A4B4
		private void InitWeaponItemGrid()
		{
			this.WeaponItemGrid = new SmallItemGrid();
			this.WeaponItemGrid.Initialize(base.GetItem(4).GetOwner());
			this.WeaponItemGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClickWeaponItemGrid));
			this.WeaponItemGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.OnCanExecuteWeaponItemGridChange));
		}

		// Token: 0x0603544B RID: 218187 RVA: 0x00D5C314 File Offset: 0x00D5A514
		private UniTask InitButtonItem()
		{
			RoleDevelopProjectWeaponDevItem.<InitButtonItem>d__11 <InitButtonItem>d__;
			<InitButtonItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitButtonItem>d__.<>4__this = this;
			<InitButtonItem>d__.<>1__state = -1;
			<InitButtonItem>d__.<>t__builder.Start<RoleDevelopProjectWeaponDevItem.<InitButtonItem>d__11>(ref <InitButtonItem>d__);
			return <InitButtonItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603544C RID: 218188 RVA: 0x00D5C357 File Offset: 0x00D5A557
		private void InitLayout()
		{
			this.ItemLayout = new GenericLayout<RoleDevelopProjectMaterialItem, RoleDevelopProjectMaterialItemData>(base.GetVerticalLayout(9), new Func<RoleDevelopProjectMaterialItem>(this.CreateItem), null, false, true);
		}

		// Token: 0x0603544D RID: 218189 RVA: 0x00D5C37B File Offset: 0x00D5A57B
		public void RefreshByData(RoleDevelopData data)
		{
			this.Data = data;
			this.RefreshWeaponView();
			this.RefreshLayout();
		}

		// Token: 0x0603544E RID: 218190 RVA: 0x00D5C390 File Offset: 0x00D5A590
		public void RefreshWeaponView()
		{
			if (this.Data == null)
			{
				return;
			}
			RoleDevelopRoleBaseData developRoleData = this.Data.GetDevelopRoleData();
			RoleDevelopProjectBaseData projectData = this.Data.GetProjectData();
			WeaponInstance weaponInstance = developRoleData.GetWeaponInstance();
			SmallItemGrid weaponItemGrid = this.WeaponItemGrid;
			int weaponLevel = developRoleData.GetWeaponLevel();
			UUIText text = base.GetText(6);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), developRoleData.GetWeaponName(), Array.Empty<object>());
			weaponItemGrid.SetToggleInteractive(weaponInstance != null);
			base.GetItem(12).SetUIActive(weaponInstance != null);
			if (weaponInstance != null)
			{
				PropSmallItemGrid parameters = new PropSmallItemGrid
				{
					ItemConfigId = new int?(weaponInstance.GetItemId()),
					BottomTextId = "Text_LevelShow_Text",
					BottomTextParameter = new object[]
					{
						weaponLevel
					},
					Data = this.Data
				};
				weaponItemGrid.Apply<PropSmallItemGrid>(parameters);
				bool uiactive = ModelBase<WeaponModel>.Instance.IsWeaponHighQuality(weaponInstance);
				base.GetItem(0).SetUIActive(uiactive);
				List<int> hotWeaponGachaIds = RoleDevelopUtil.GetHotWeaponGachaIds(weaponInstance.GetItemId(), true);
				base.GetButton(11).RootUIComp.Get().SetUIActive(hotWeaponGachaIds.Count > 0);
				bool flag = weaponLevel >= developRoleData.GetWeaponTargetLevel();
				bool flag2 = weaponLevel >= weaponInstance.GetMaxLevel();
				string textId = (flag || flag2) ? "RoleProject_Button02" : "RoleProject_Button01";
				this.NormalButtonItem.SetLocalTextNew(textId, Array.Empty<object>());
				this.HighLightButtonItem.SetLocalTextNew(textId, Array.Empty<object>());
				if (flag || flag2)
				{
					this.NormalButtonItem.SetUiActive(true);
					this.HighLightButtonItem.SetUiActive(false);
				}
				else
				{
					List<RoleDevelopNeedItem> weaponUpgradeNeedItems = projectData.GetWeaponUpgradeNeedItems();
					List<RoleDevelopNeedItem> weaponBreachNeedItems = projectData.GetWeaponBreachNeedItems();
					bool flag3 = RoleDevelopUtil.CheckIsAllNeedItemsEnoughOrCanBeFilled(weaponUpgradeNeedItems) && RoleDevelopUtil.CheckIsAllNeedItemsEnoughOrCanBeFilled(weaponBreachNeedItems);
					this.NormalButtonItem.SetUiActive(!flag3);
					this.HighLightButtonItem.SetUiActive(flag3);
				}
				if (flag && !flag2)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoleProject_Tips04", Array.Empty<object>());
				}
				else
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoleProject_TargetLevel", new int[]
					{
						developRoleData.GetWeaponTargetLevel()
					});
				}
				text.SetUIActive(!flag2);
				return;
			}
			int weaponType = this.Data.GetProjectData().GetWeaponType();
			weaponItemGrid.SetIconByPath(ConfigBase<RoleDevConfig>.Instance.GetRoleDevWeaponItemConfig(weaponType).Value.WeaponTypeIcon);
			weaponItemGrid.SetBottomTextVisible(false);
			weaponItemGrid.SetQuality(null);
			text.SetUIActive(false);
			bool flag4 = RoleDevelopUtil.IsAnyProspectRole(this.Data.GetId());
			base.GetItem(0).SetUIActive(!flag4);
		}

		// Token: 0x0603544F RID: 218191 RVA: 0x00D5C638 File Offset: 0x00D5A838
		public void RefreshLayout()
		{
			if (this.Data == null)
			{
				return;
			}
			int id = this.Data.GetId();
			List<RoleDevelopProjectMaterialItemData> weaponDevelopProjectViewItems = this.Data.GetProjectData().GetWeaponDevelopProjectViewItems();
			foreach (RoleDevelopProjectMaterialItemData roleDevelopProjectMaterialItemData in weaponDevelopProjectViewItems)
			{
				ERoleDevelopLogSubPage value;
				if (this.WeaponDevelopMaterialTypeToLogSubPageMap.TryGetValue(roleDevelopProjectMaterialItemData.GroupItem.Type, out value))
				{
					roleDevelopProjectMaterialItemData.LogSubPage = new ERoleDevelopLogSubPage?(value);
					roleDevelopProjectMaterialItemData.LogRoleId = new int?(id);
					roleDevelopProjectMaterialItemData.LogMainPage = new ERoleDevelopCategoryType?(ERoleDevelopCategoryType.Weapon);
				}
			}
			this.ItemLayout.RefreshByData(weaponDevelopProjectViewItems, null, false);
		}

		// Token: 0x06035450 RID: 218192 RVA: 0x00D5C6F4 File Offset: 0x00D5A8F4
		public void OnCommonItemCountAnyChange(int configId)
		{
			this.RefreshWeaponView();
			this.ItemLayout.RefreshWithoutDataSync();
		}

		// Token: 0x06035451 RID: 218193 RVA: 0x00D5C707 File Offset: 0x00D5A907
		public void SetClickSwitchCallback(Action callback)
		{
			this.OnClickSwitchCallback = callback;
		}

		// Token: 0x06035452 RID: 218194 RVA: 0x00D5C710 File Offset: 0x00D5A910
		private void OnClickSwitch()
		{
			Action onClickSwitchCallback = this.OnClickSwitchCallback;
			if (onClickSwitchCallback != null)
			{
				onClickSwitchCallback();
			}
			if (this.Data != null)
			{
				ControllerBase<RoleController>.Instance.LogRoleDevelopClick(this.Data.GetId(), ERoleDevelopCategoryType.Weapon, ERoleDevelopLogSubPage.WeaponDevelopViewRecommendedWeapons, null);
			}
		}

		// Token: 0x06035453 RID: 218195 RVA: 0x00D5C758 File Offset: 0x00D5A958
		private void OnClickCall()
		{
			if (this.Data == null)
			{
				return;
			}
			WeaponInstance weaponInstance = this.Data.GetDevelopRoleData().GetWeaponInstance();
			if (weaponInstance == null)
			{
				return;
			}
			List<int> hotWeaponGachaIds = RoleDevelopUtil.GetHotWeaponGachaIds(weaponInstance.GetItemId(), true);
			if (hotWeaponGachaIds.Count > 0)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaMainView, hotWeaponGachaIds[0], null);
			}
		}

		// Token: 0x06035454 RID: 218196 RVA: 0x00D5C7B5 File Offset: 0x00D5A9B5
		private RoleDevelopProjectMaterialItem CreateItem()
		{
			return new RoleDevelopProjectMaterialItem();
		}

		// Token: 0x06035455 RID: 218197 RVA: 0x00D5C7BC File Offset: 0x00D5A9BC
		[NullableContext(2)]
		private bool OnCanExecuteWeaponItemGridChange(object data, bool isForceSelected, EToggleState state)
		{
			return false;
		}

		// Token: 0x06035456 RID: 218198 RVA: 0x00D5C7C0 File Offset: 0x00D5A9C0
		private void OnClickWeaponItemGrid(MediumItemGridExtendCallback callbackParameter)
		{
			if (this.Data == null)
			{
				return;
			}
			WeaponInstance weaponInstance = this.Data.GetDevelopRoleData().GetWeaponInstance();
			if (weaponInstance != null)
			{
				int valueOrDefault = weaponInstance.GetIncId().GetValueOrDefault();
				int itemId = weaponInstance.GetItemId();
				if (valueOrDefault > 0)
				{
					ControllerBase<ItemController>.Instance.OpenItemTipsByItemUid(valueOrDefault, itemId, true, null);
					return;
				}
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemId, true, null);
			}
		}

		// Token: 0x06035457 RID: 218199 RVA: 0x00D5C820 File Offset: 0x00D5AA20
		private void OnClickWeaponJump(int value)
		{
			if (this.Data == null)
			{
				return;
			}
			WeaponInstance weaponInstance = this.Data.GetDevelopRoleData().GetWeaponInstance();
			if (weaponInstance == null)
			{
				return;
			}
			int skinIdByRoleId = ModelBase<WeaponSkinModel>.Instance.GetSkinIdByRoleId(weaponInstance.GetRoleId());
			WeaponRootViewParam param = new WeaponRootViewParam
			{
				WeaponIncId = weaponInstance.GetIncId().GetValueOrDefault(),
				WeaponSkinId = skinIdByRoleId,
				IsFromRoleRootView = false
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponRootView, param, null);
			RoleDevelopRoleBaseData developRoleData = this.Data.GetDevelopRoleData();
			ERoleDevelopLogSubPage subPage = (developRoleData.IsWeaponMaxLevel() && !developRoleData.IsWeaponNeedBreakUp()) ? ERoleDevelopLogSubPage.WeaponDevelopPerfectJump : ERoleDevelopLogSubPage.WeaponDevelopJump;
			ControllerBase<RoleController>.Instance.LogRoleDevelopClick(this.Data.GetId(), ERoleDevelopCategoryType.Weapon, subPage, null);
		}

		// Token: 0x0401EA51 RID: 125521
		private readonly Dictionary<EItemMaterialType, ERoleDevelopLogSubPage> WeaponDevelopMaterialTypeToLogSubPageMap = new Dictionary<EItemMaterialType, ERoleDevelopLogSubPage>
		{
			{
				EItemMaterialType.WeaponExp,
				ERoleDevelopLogSubPage.WeaponDevelopExpMaterial
			},
			{
				EItemMaterialType.WeaponSkill,
				ERoleDevelopLogSubPage.WeaponDevelopWeaponAndSkillMaterial1
			},
			{
				EItemMaterialType.Drop,
				ERoleDevelopLogSubPage.WeaponDevelopWeaponAndSkillMaterial2
			}
		};

		// Token: 0x0401EA52 RID: 125522
		[Nullable(2)]
		private RoleDevelopData Data;

		// Token: 0x0401EA53 RID: 125523
		[Nullable(2)]
		private Action OnClickSwitchCallback;

		// Token: 0x0401EA54 RID: 125524
		private SmallItemGrid WeaponItemGrid;

		// Token: 0x0401EA55 RID: 125525
		private GenericLayout<RoleDevelopProjectMaterialItem, RoleDevelopProjectMaterialItemData> ItemLayout;

		// Token: 0x0401EA56 RID: 125526
		private ButtonItem NormalButtonItem;

		// Token: 0x0401EA57 RID: 125527
		private ButtonItem HighLightButtonItem;

		// Token: 0x0200B057 RID: 45143
		[NullableContext(0)]
		public static class EComponentType
		{
			// Token: 0x04036B60 RID: 224096
			public const int PanelSwitch = 0;

			// Token: 0x04036B61 RID: 224097
			public const int BtnSwitch = 1;

			// Token: 0x04036B62 RID: 224098
			public const int PanelWeaponType = 2;

			// Token: 0x04036B63 RID: 224099
			public const int IconWeaponType = 3;

			// Token: 0x04036B64 RID: 224100
			public const int WeaponItem = 4;

			// Token: 0x04036B65 RID: 224101
			public const int TxtWeaponName = 5;

			// Token: 0x04036B66 RID: 224102
			public const int TxtGoalLevel = 6;

			// Token: 0x04036B67 RID: 224103
			public const int BtnJump = 7;

			// Token: 0x04036B68 RID: 224104
			public const int BtnPerfectJump = 8;

			// Token: 0x04036B69 RID: 224105
			public const int PanelDetailLayout = 9;

			// Token: 0x04036B6A RID: 224106
			public const int PanelDetailItem = 10;

			// Token: 0x04036B6B RID: 224107
			public const int BtnCall = 11;

			// Token: 0x04036B6C RID: 224108
			public const int RightItem = 12;
		}
	}
}
