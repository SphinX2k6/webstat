using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.Data;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050B5 RID: 20661
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopOverviewPanel : UiPanelBase
	{
		// Token: 0x060353B7 RID: 218039 RVA: 0x00D5814C File Offset: 0x00D5634C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 17;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 4;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickJumpBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickRecommendBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickPhantomJumpBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(11, new Action(this.OnClickChooseBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060353B8 RID: 218040 RVA: 0x00D58454 File Offset: 0x00D56654
		protected override UniTask OnBeforeStartAsync()
		{
			RoleDevelopOverviewPanel.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevelopOverviewPanel.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060353B9 RID: 218041 RVA: 0x00D58490 File Offset: 0x00D56690
		protected override void OnStart()
		{
			this.MaterialItemLayout = new GenericLayout<RoleDevelopOverviewMaterialItem, RoleDevelopOverviewMaterialItemData>(base.GetVerticalLayout(6), new Func<RoleDevelopOverviewMaterialItem>(this.CreateMaterialItem), null, false, true);
			this.PhantomSuitLayout = new GenericLayout<RoleDevelopProjectPhantomSuitItem, RoleDevelopPhantomSuitData>(base.GetVerticalLayout(9), new Func<RoleDevelopProjectPhantomSuitItem>(this.CreatePhantomSuitItem), null, false, true);
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		}

		// Token: 0x060353BA RID: 218042 RVA: 0x00D584FC File Offset: 0x00D566FC
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		}

		// Token: 0x060353BB RID: 218043 RVA: 0x00D5851C File Offset: 0x00D5671C
		public void RefreshView(bool forceRefresh = false)
		{
			int devTargetRoleId = ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId;
			bool flag = devTargetRoleId > 0;
			base.GetItem(0).SetUIActive(!flag);
			base.GetItem(1).SetUIActive(flag);
			if (!flag)
			{
				return;
			}
			bool flag2 = ModelBase<RoleModel>.Instance.IsRoleOwned(devTargetRoleId);
			bool flag3 = RoleDevelopUtil.GetHotRoleGachaIds(devTargetRoleId, true).Count > 0;
			base.GetItem(16).SetUIActive(flag2 || flag3);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), (flag3 && !flag2) ? "RoleProject_GuideBookTitle02" : "RoleProject_GuideBookTitle01", Array.Empty<object>());
			RoleDevelopData roleDevelopData = ModelBase<RoleDevelopModel>.Instance.GetRoleDevelopData(devTargetRoleId);
			if (roleDevelopData == null)
			{
				return;
			}
			RoleDevelopProjectBaseData projectData = roleDevelopData.GetProjectData();
			RoleDevelopRoleBaseData developRoleData = roleDevelopData.GetDevelopRoleData();
			if (this.FetterInitRoleId != devTargetRoleId)
			{
				this.SelectPlanId = developRoleData.GetRecommendPlanId();
				this.SelectFirstVisionMonsterId = new int?(developRoleData.GetRecommendFirstVisionMonsterId());
				this.FetterInitRoleId = devTargetRoleId;
			}
			bool flag4 = flag2 && this.IsWeaponQualityLow(devTargetRoleId);
			List<RoleDevelopNeedItem> skillPlanNeedItems = projectData.GetSkillPlanNeedItems();
			List<RoleDevelopNeedItem> list = this.CollectNeedItems(devTargetRoleId);
			if (list == null)
			{
				return;
			}
			List<RoleDevelopItemGroup> list2 = RoleDevelopUtil.BuildGroupItemDataByNeedItems(list, true, true, true);
			List<RoleDevelopOverviewMaterialItemData> list3 = new List<RoleDevelopOverviewMaterialItemData>();
			foreach (RoleDevelopItemGroup groupItem in list2)
			{
				list3.Add(new RoleDevelopOverviewMaterialItemData
				{
					GroupItem = groupItem,
					JumpCallback = new Action<RoleDevelopItemGroup>(this.OnMaterialJump)
				});
			}
			this.MaterialItemLayout.RefreshByData(list3, null, false);
			bool flag5 = this.CheckMaterialsSufficient(list);
			bool flag6 = developRoleData.GetRoleLevel() >= projectData.GetRoleTargetLevel();
			bool flag7 = skillPlanNeedItems.Count == 0;
			bool flag8 = developRoleData.GetWeaponLevel() >= projectData.GetWeaponTargetLevel();
			bool flag9 = flag6 && flag7 && !flag4 && flag8;
			UUIText text = base.GetText(12);
			if (flag9)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoleProject_ChoseRole_FinishTips", Array.Empty<object>());
			}
			else if (flag5)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoleProject_ChoseRole_ItemTips02", Array.Empty<object>());
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RoleProject_GuideBookTitle00", Array.Empty<object>());
			}
			base.GetSprite(2).SetUIActive(flag5);
			base.GetItem(4).SetUIActive(flag4);
			if (flag4)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), "RoleProject_GuideBookTips01", Array.Empty<object>());
			}
			if (RoleDevelopUtil.IsAnyProspectRole(devTargetRoleId))
			{
				base.GetItem(15).SetUIActive(false);
				return;
			}
			base.GetItem(15).SetUIActive(true);
			this.RefreshPhantomSuitList(forceRefresh);
		}

		// Token: 0x060353BC RID: 218044 RVA: 0x00D587B8 File Offset: 0x00D569B8
		private bool CheckMaterialsSufficient(List<RoleDevelopNeedItem> needItems)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (RoleDevelopNeedItem roleDevelopNeedItem in needItems)
			{
				if (!RoleDevelopUtil.IsUnknownItem(roleDevelopNeedItem.ItemId))
				{
					int num;
					dictionary.TryGetValue(roleDevelopNeedItem.ItemId, out num);
					dictionary[roleDevelopNeedItem.ItemId] = num + roleDevelopNeedItem.Count;
				}
			}
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(keyValuePair.Key, 0) < keyValuePair.Value)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060353BD RID: 218045 RVA: 0x00D58894 File Offset: 0x00D56A94
		private bool IsWeaponQualityLow(int roleId)
		{
			WeaponInstance weaponInstance = ModelBase<WeaponModel>.Instance.GetWeaponDataByRoleDataId(roleId, true) as WeaponInstance;
			if (weaponInstance == null)
			{
				return true;
			}
			int weaponQualityThreshold = ConfigBase<RoleDevConfig>.Instance.GetRoleDevStaticConfig().Value.WeaponQualityThreshold;
			return weaponInstance.GetItemConfig().QualityId < weaponQualityThreshold;
		}

		// Token: 0x060353BE RID: 218046 RVA: 0x00D588E8 File Offset: 0x00D56AE8
		private void OnClickJumpBtn()
		{
			int devTargetRoleId = ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId;
			if (devTargetRoleId <= 0)
			{
				return;
			}
			if (ModelBase<RoleModel>.Instance.IsRoleOwned(devTargetRoleId))
			{
				ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Normal, devTargetRoleId, null, null, null);
				return;
			}
			List<int> hotRoleGachaIds = RoleDevelopUtil.GetHotRoleGachaIds(devTargetRoleId, true);
			if (hotRoleGachaIds.Count > 0)
			{
				ControllerBase<GachaController>.Instance.OpenGachaView(hotRoleGachaIds[0]);
			}
		}

		// Token: 0x060353BF RID: 218047 RVA: 0x00D5894C File Offset: 0x00D56B4C
		private void OnClickRecommendBtn()
		{
			int developRoleId = ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId;
			if (developRoleId <= 0 || !ModelBase<RoleModel>.Instance.IsRoleOwned(developRoleId))
			{
				return;
			}
			if (!this.IsWeaponQualityLow(developRoleId))
			{
				return;
			}
			OpenRoleMainViewData param = new OpenRoleMainViewData
			{
				AgentType = ERoleAgentType.Normal,
				FinishCallback = delegate(bool success, int viewId)
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleDevelopRootView, new RoleDevelopRootViewData
					{
						RoleId = new int?(developRoleId),
						CategoryType = new ERoleDevelopCategoryType?(ERoleDevelopCategoryType.Weapon)
					}, null);
				}
			};
			ControllerBase<RoleController>.Instance.OpenRoleMainViewByParam(param);
		}

		// Token: 0x060353C0 RID: 218048 RVA: 0x00D589C4 File Offset: 0x00D56BC4
		private RoleDevelopOverviewMaterialItem CreateMaterialItem()
		{
			return new RoleDevelopOverviewMaterialItem();
		}

		// Token: 0x060353C1 RID: 218049 RVA: 0x00D589CB File Offset: 0x00D56BCB
		private RoleDevelopProjectPhantomSuitItem CreatePhantomSuitItem()
		{
			return new RoleDevelopProjectPhantomSuitItem();
		}

		// Token: 0x060353C2 RID: 218050 RVA: 0x00D589D4 File Offset: 0x00D56BD4
		private void OnMaterialJump(RoleDevelopItemGroup groupItem)
		{
			int devTargetRoleId = ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId;
			if (devTargetRoleId > 0)
			{
				RoleDevelopUtil.HandleItemJump(devTargetRoleId, groupItem);
			}
		}

		// Token: 0x060353C3 RID: 218051 RVA: 0x00D589F8 File Offset: 0x00D56BF8
		private void RefreshPhantomSuitList(bool forceRefresh)
		{
			int devTargetRoleId = ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId;
			RoleDevelopData roleDevelopData = ModelBase<RoleDevelopModel>.Instance.GetRoleDevelopData(devTargetRoleId);
			if (roleDevelopData == null)
			{
				return;
			}
			if (!forceRefresh && this.PhantomSuitLayout.GetDisplayGridNum() > 0)
			{
				this.PhantomSuitLayout.RefreshWithoutDataSync();
				return;
			}
			List<RoleDevelopPhantomSuitData> recommendPhantomSuits = roleDevelopData.GetDevelopRoleData().GetRecommendPhantomSuits(new int?(this.SelectPlanId), this.SelectFirstVisionMonsterId);
			if (recommendPhantomSuits.Count > 0)
			{
				recommendPhantomSuits[0].IsNeedFetterButton = new bool?(true);
			}
			this.PhantomSuitLayout.RefreshByData(recommendPhantomSuits, null, false);
		}

		// Token: 0x060353C4 RID: 218052 RVA: 0x00D58A84 File Offset: 0x00D56C84
		private void OnClickPhantomJumpBtn()
		{
			int devTargetRoleId = ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId;
			if (devTargetRoleId <= 0)
			{
				return;
			}
			VisionRecommendViewOpenParam param = new VisionRecommendViewOpenParam
			{
				RoleId = devTargetRoleId,
				IsFromRoleDev = true,
				SuccessCallBack = new Action<int, int, int?>(this.OnChangeFetterGroupSuccessCallBack),
				GetSelectedPlanIdCallBack = new Func<int, int>(this.OnGetSelectedPlanIdCallBack),
				GetSelectedFirstVisionMonsterIdCallBack = new Func<int, int>(this.OnGetSelectedFirstVisionMonsterIdCallBack)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionNewRecommendView, param, null);
		}

		// Token: 0x060353C5 RID: 218053 RVA: 0x00D58AFC File Offset: 0x00D56CFC
		private void OnCommonItemCountAnyChange(int configId, int count)
		{
			GenericLayout<RoleDevelopOverviewMaterialItem, RoleDevelopOverviewMaterialItemData> materialItemLayout = this.MaterialItemLayout;
			List<RoleDevelopOverviewMaterialItem> list = (materialItemLayout != null) ? materialItemLayout.GetLayoutItemList() : null;
			if (list == null)
			{
				return;
			}
			if (this.GetCurrentMaterialGroupCount() != list.Count)
			{
				this.RefreshView(false);
				return;
			}
			GenericLayout<RoleDevelopOverviewMaterialItem, RoleDevelopOverviewMaterialItemData> materialItemLayout2 = this.MaterialItemLayout;
			if (materialItemLayout2 == null)
			{
				return;
			}
			materialItemLayout2.RefreshWithoutDataSync();
		}

		// Token: 0x060353C6 RID: 218054 RVA: 0x00D58B48 File Offset: 0x00D56D48
		private int GetCurrentMaterialGroupCount()
		{
			int devTargetRoleId = ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId;
			if (devTargetRoleId <= 0)
			{
				return 0;
			}
			List<RoleDevelopNeedItem> list = this.CollectNeedItems(devTargetRoleId);
			if (list == null)
			{
				return 0;
			}
			return RoleDevelopUtil.BuildGroupItemDataByNeedItems(list, true, true, true).Count;
		}

		// Token: 0x060353C7 RID: 218055 RVA: 0x00D58B84 File Offset: 0x00D56D84
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private List<RoleDevelopNeedItem> CollectNeedItems(int developRoleId)
		{
			RoleDevelopData roleDevelopData = ModelBase<RoleDevelopModel>.Instance.GetRoleDevelopData(developRoleId);
			if (roleDevelopData == null)
			{
				return null;
			}
			RoleDevelopProjectBaseData projectData = roleDevelopData.GetProjectData();
			bool flag = ModelBase<RoleModel>.Instance.IsRoleOwned(developRoleId) && this.IsWeaponQualityLow(developRoleId);
			List<RoleDevelopNeedItem> list = new List<RoleDevelopNeedItem>();
			list.AddRange(projectData.GetRoleUpgradeNeedItems());
			list.AddRange(projectData.GetRoleBreachNeedItems());
			list.AddRange(projectData.GetSkillPlanNeedItems());
			if (!flag)
			{
				list.AddRange(projectData.GetWeaponUpgradeNeedItems());
				list.AddRange(projectData.GetWeaponBreachNeedItems());
			}
			return list;
		}

		// Token: 0x060353C8 RID: 218056 RVA: 0x00D58C08 File Offset: 0x00D56E08
		private void OnClickChooseBtn()
		{
			RoleController.OpenRoleDevelopSelectTargetView(ERoleDevelopUpdateTargetSource.Detection, null);
		}

		// Token: 0x060353C9 RID: 218057 RVA: 0x00D58C24 File Offset: 0x00D56E24
		private void OnChangeFetterGroupSuccessCallBack(int roleId, int planId, int? firstVisionMonsterId)
		{
			this.SelectPlanId = planId;
			this.SelectFirstVisionMonsterId = firstVisionMonsterId;
			this.RefreshPhantomSuitList(true);
			ControllerBase<RoleController>.Instance.RequestUpdateDevelopTarget(roleId, ERoleDevelopUpdateTargetSource.Detection, new int?(planId), firstVisionMonsterId);
		}

		// Token: 0x060353CA RID: 218058 RVA: 0x00D58C4E File Offset: 0x00D56E4E
		private int OnGetSelectedPlanIdCallBack(int roleId)
		{
			return this.SelectPlanId;
		}

		// Token: 0x060353CB RID: 218059 RVA: 0x00D58C56 File Offset: 0x00D56E56
		private int OnGetSelectedFirstVisionMonsterIdCallBack(int roleId)
		{
			return this.SelectFirstVisionMonsterId.GetValueOrDefault();
		}

		// Token: 0x0401EA25 RID: 125477
		private GenericLayout<RoleDevelopOverviewMaterialItem, RoleDevelopOverviewMaterialItemData> MaterialItemLayout;

		// Token: 0x0401EA26 RID: 125478
		private GenericLayout<RoleDevelopProjectPhantomSuitItem, RoleDevelopPhantomSuitData> PhantomSuitLayout;

		// Token: 0x0401EA27 RID: 125479
		private int SelectPlanId;

		// Token: 0x0401EA28 RID: 125480
		private int? SelectFirstVisionMonsterId = new int?(0);

		// Token: 0x0401EA29 RID: 125481
		private int FetterInitRoleId;

		// Token: 0x0200B03D RID: 45117
		[NullableContext(0)]
		public static class EComponentType
		{
			// Token: 0x04036AC4 RID: 223940
			public const int EmptyItem = 0;

			// Token: 0x04036AC5 RID: 223941
			public const int ContentItem = 1;

			// Token: 0x04036AC6 RID: 223942
			public const int FinishSprite = 2;

			// Token: 0x04036AC7 RID: 223943
			public const int JumpButton = 3;

			// Token: 0x04036AC8 RID: 223944
			public const int RecommendRootItem = 4;

			// Token: 0x04036AC9 RID: 223945
			public const int RecommendButton = 5;

			// Token: 0x04036ACA RID: 223946
			public const int MaterialVerticalLayout = 6;

			// Token: 0x04036ACB RID: 223947
			public const int MaterialItem = 7;

			// Token: 0x04036ACC RID: 223948
			public const int PhantomJumpButton = 8;

			// Token: 0x04036ACD RID: 223949
			public const int PhantomVerticalLayout = 9;

			// Token: 0x04036ACE RID: 223950
			public const int PhantomItem = 10;

			// Token: 0x04036ACF RID: 223951
			public const int ChooseButton = 11;

			// Token: 0x04036AD0 RID: 223952
			public const int MaterialTitleText = 12;

			// Token: 0x04036AD1 RID: 223953
			public const int JumpButtonText = 13;

			// Token: 0x04036AD2 RID: 223954
			public const int RecommendHintText = 14;

			// Token: 0x04036AD3 RID: 223955
			public const int PhantomRootItem = 15;

			// Token: 0x04036AD4 RID: 223956
			public const int JumpRootItem = 16;
		}
	}
}
