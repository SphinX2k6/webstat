using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050C8 RID: 20680
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleDevelopProjectWeaponRecommendListItem : GridProxyAbstract<RoleDevelopProjectWeaponRecommendListItemData>
	{
		// Token: 0x06035487 RID: 218247 RVA: 0x00D5D390 File Offset: 0x00D5B590
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickCall));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035488 RID: 218248 RVA: 0x00D5D4FC File Offset: 0x00D5B6FC
		protected override UniTask OnBeforeStartAsync()
		{
			RoleDevelopProjectWeaponRecommendListItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevelopProjectWeaponRecommendListItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035489 RID: 218249 RVA: 0x00D5D540 File Offset: 0x00D5B740
		public override void Refresh(RoleDevelopProjectWeaponRecommendListItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			int recommendWeaponId = data.RecommendWeaponId;
			WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(recommendWeaponId);
			int developRoleId = data.DevelopRoleId;
			bool flag = ModelBase<RoleModel>.Instance.IsRoleOwned(developRoleId);
			WeaponInstance weaponInstanceByRoleId = ModelBase<WeaponModel>.Instance.GetWeaponInstanceByRoleId(developRoleId);
			bool flag2 = flag && weaponInstanceByRoleId != null && weaponInstanceByRoleId.GetItemId() == recommendWeaponId;
			List<int> weaponGachaIds = this.GetWeaponGachaIds(recommendWeaponId);
			bool flag3 = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(recommendWeaponId, 0) > 0;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), weaponConfigByItemId.Value.WeaponName, Array.Empty<object>());
			base.GetItem(7).SetUIActive(flag2);
			base.GetButton(2).RootUIComp.Get().SetUIActive(!flag2 && weaponGachaIds.Count > 0);
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				ItemConfigId = new int?(recommendWeaponId),
				Data = data
			};
			this.WeaponItemGrid.Apply<PropSmallItemGrid>(parameters);
			if (flag3 && !flag2)
			{
				string textId = flag ? "RoleProject_Button05" : "RoleProject_Button06";
				this.ButtonJump.SetLocalTextNew(textId, Array.Empty<object>());
				this.ButtonJump.SetUiActive(flag3);
			}
			else
			{
				this.ButtonJump.SetUiActive(false);
			}
			UUIItem item = base.GetItem(4);
			if (flag3)
			{
				this.ButtonItemAccess.SetUiActive(false);
				item.SetUIActive(false);
				return;
			}
			RoleDevWeaponJumpGroup? weaponJumpGroupConfigByWeaponId = ConfigBase<RoleDevConfig>.Instance.GetWeaponJumpGroupConfigByWeaponId(recommendWeaponId);
			if (weaponJumpGroupConfigByWeaponId.Value.JumpPath != 0)
			{
				this.ButtonItemAccess.SetLocalTextNew(weaponJumpGroupConfigByWeaponId.Value.PathDescribe, Array.Empty<object>());
				this.ButtonItemAccess.SetUiActive(true);
				item.SetUIActive(false);
				return;
			}
			this.ButtonItemAccess.SetUiActive(false);
			item.SetUIActive(true);
			if (weaponGachaIds.Count > 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), weaponJumpGroupConfigByWeaponId.Value.PathDescribe, Array.Empty<object>());
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "RoleProject_Access_None", Array.Empty<object>());
		}

		// Token: 0x0603548A RID: 218250 RVA: 0x00D5D75C File Offset: 0x00D5B95C
		private List<int> GetWeaponGachaIds(int weaponId)
		{
			RoleDevWeaponJumpGroup? weaponJumpGroupConfigByWeaponId = ConfigBase<RoleDevConfig>.Instance.GetWeaponJumpGroupConfigByWeaponId(weaponId);
			if (weaponJumpGroupConfigByWeaponId == null)
			{
				return new List<int>();
			}
			int jumpType = weaponJumpGroupConfigByWeaponId.Value.JumpType;
			if (jumpType != 1 && jumpType != 2)
			{
				return new List<int>();
			}
			return RoleDevelopUtil.GetHotWeaponGachaIds(weaponId, true);
		}

		// Token: 0x0603548B RID: 218251 RVA: 0x00D5D7AC File Offset: 0x00D5B9AC
		private unsafe void OpenWeaponReplaceView()
		{
			int developRoleId = this.Data.DevelopRoleId;
			int recommendWeaponId = this.Data.RecommendWeaponId;
			WeaponInstance weaponInstanceByRoleId = ModelBase<WeaponModel>.Instance.GetWeaponInstanceByRoleId(developRoleId);
			List<WeaponItemData> weaponListFromReplace = ModelBase<WeaponModel>.Instance.GetWeaponListFromReplace(weaponInstanceByRoleId.GetWeaponConfig().Value.WeaponType);
			int sortId = ConfigBase<SortConfig>.Instance.GetSortId(EFilterSortGroupId.UseWayWeaponResonanceAndReplace);
			Sort value = ConfigBase<SortConfig>.Instance.GetSortConfig(sortId).Value;
			SortResultData sortResultData = new SortResultData();
			sortResultData.SetConfigId(value.Id);
			sortResultData.SetIsAscending(false);
			int ruleId = *value.GetBaseSortListBytes()[0];
			string sortRuleName = ConfigBase<SortConfig>.Instance.GetSortRuleName(ruleId, (ESortDataType)value.DataId);
			sortResultData.SetSelectBaseSort(new SortViewBaseSort(ruleId, sortRuleName));
			ModelBase<SortModel>.Instance.SortDataList<WeaponItemData>(weaponListFromReplace, value.Id, sortResultData, Array.Empty<object>());
			int num = -1;
			int num2 = -1;
			foreach (WeaponItemData weaponItemData in weaponListFromReplace)
			{
				if (weaponItemData.GetConfigId() == recommendWeaponId)
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
			RoleDevelopUtil.OpenWeaponReplaceView(developRoleId, num2);
		}

		// Token: 0x0603548C RID: 218252 RVA: 0x00D5D92C File Offset: 0x00D5BB2C
		private unsafe void OpenInventoryView()
		{
			int recommendWeaponId = this.Data.RecommendWeaponId;
			WeaponConf value = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(recommendWeaponId).Value;
			List<WeaponItemData> weaponListFromReplace = ModelBase<WeaponModel>.Instance.GetWeaponListFromReplace(value.WeaponType);
			int sortId = ConfigBase<SortConfig>.Instance.GetSortId(EFilterSortGroupId.UseWayWeaponResonanceAndReplace);
			Sort value2 = ConfigBase<SortConfig>.Instance.GetSortConfig(sortId).Value;
			SortResultData sortResultData = new SortResultData();
			sortResultData.SetConfigId(value2.Id);
			sortResultData.SetIsAscending(false);
			int ruleId = *value2.GetBaseSortListBytes()[0];
			string sortRuleName = ConfigBase<SortConfig>.Instance.GetSortRuleName(ruleId, (ESortDataType)value2.DataId);
			sortResultData.SetSelectBaseSort(new SortViewBaseSort(ruleId, sortRuleName));
			ModelBase<SortModel>.Instance.SortDataList<WeaponItemData>(weaponListFromReplace, value2.Id, sortResultData, Array.Empty<object>());
			int? num = null;
			foreach (WeaponItemData weaponItemData in weaponListFromReplace)
			{
				if (weaponItemData.GetConfigId() == recommendWeaponId)
				{
					num = new int?(weaponItemData.GetUniqueId());
					break;
				}
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InventoryView, num, null);
		}

		// Token: 0x0603548D RID: 218253 RVA: 0x00D5DA74 File Offset: 0x00D5BC74
		private void OnClickCall()
		{
			if (this.Data == null)
			{
				return;
			}
			List<int> weaponGachaIds = this.GetWeaponGachaIds(this.Data.RecommendWeaponId);
			if (weaponGachaIds.Count > 0)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaMainView, weaponGachaIds[0], null);
			}
		}

		// Token: 0x0603548E RID: 218254 RVA: 0x00D5DAC1 File Offset: 0x00D5BCC1
		private bool OnWeaponGridCanExecuteChange(object data, bool isForceSelected, EToggleState state)
		{
			return false;
		}

		// Token: 0x0603548F RID: 218255 RVA: 0x00D5DAC4 File Offset: 0x00D5BCC4
		private void OnClickWeaponGrid(MediumItemGridExtendCallback callback)
		{
			if (this.Data == null)
			{
				return;
			}
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.Data.RecommendWeaponId, true, null);
		}

		// Token: 0x06035490 RID: 218256 RVA: 0x00D5DAE8 File Offset: 0x00D5BCE8
		private void OnClickJump(int value)
		{
			if (this.Data == null)
			{
				return;
			}
			RoleDevelopProjectWeaponRecommendListItemData data = this.Data;
			if (ModelBase<RoleModel>.Instance.IsRoleOwned(this.Data.DevelopRoleId))
			{
				this.OpenWeaponReplaceView();
			}
			else
			{
				this.OpenInventoryView();
			}
			if (data.LogRoleId != null && data.LogMainPage != null && data.LogSubPage != null)
			{
				ControllerBase<RoleController>.Instance.LogRoleDevelopClick(data.LogRoleId.Value, data.LogMainPage.Value, data.LogSubPage.Value, null);
			}
		}

		// Token: 0x06035491 RID: 218257 RVA: 0x00D5DB98 File Offset: 0x00D5BD98
		private void OnClickItemAccess(int value)
		{
			if (this.Data == null)
			{
				return;
			}
			RoleDevWeaponJumpGroup? weaponJumpGroupConfigByWeaponId = ConfigBase<RoleDevConfig>.Instance.GetWeaponJumpGroupConfigByWeaponId(this.Data.RecommendWeaponId);
			if (weaponJumpGroupConfigByWeaponId == null || weaponJumpGroupConfigByWeaponId.Value.JumpType != 3)
			{
				return;
			}
			SkipTaskManager.RunByConfigId(weaponJumpGroupConfigByWeaponId.Value.JumpPath, null);
		}

		// Token: 0x0401EA67 RID: 125543
		[Nullable(2)]
		private RoleDevelopProjectWeaponRecommendListItemData Data;

		// Token: 0x0401EA68 RID: 125544
		private SmallItemGrid WeaponItemGrid;

		// Token: 0x0401EA69 RID: 125545
		private ButtonItem ButtonJump;

		// Token: 0x0401EA6A RID: 125546
		private ButtonItem ButtonItemAccess;

		// Token: 0x0200B05F RID: 45151
		[NullableContext(0)]
		public static class EComponentType
		{
			// Token: 0x04036B90 RID: 224144
			public const int WeaponItem = 0;

			// Token: 0x04036B91 RID: 224145
			public const int WeaponName = 1;

			// Token: 0x04036B92 RID: 224146
			public const int BtnCall = 2;

			// Token: 0x04036B93 RID: 224147
			public const int BtnJump = 3;

			// Token: 0x04036B94 RID: 224148
			public const int PanelNotObtained = 4;

			// Token: 0x04036B95 RID: 224149
			public const int TxtNotObtained = 5;

			// Token: 0x04036B96 RID: 224150
			public const int BtnItemAccess = 6;

			// Token: 0x04036B97 RID: 224151
			public const int PanelStateGreen = 7;
		}
	}
}
