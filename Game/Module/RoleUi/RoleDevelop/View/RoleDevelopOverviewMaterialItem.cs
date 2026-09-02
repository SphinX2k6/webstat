using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050B4 RID: 20660
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleDevelopOverviewMaterialItem : GridProxyAbstract<RoleDevelopOverviewMaterialItemData>
	{
		// Token: 0x060353AC RID: 218028 RVA: 0x00D57BD4 File Offset: 0x00D55DD4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060353AD RID: 218029 RVA: 0x00D57D28 File Offset: 0x00D55F28
		protected override UniTask OnBeforeStartAsync()
		{
			RoleDevelopOverviewMaterialItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevelopOverviewMaterialItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060353AE RID: 218030 RVA: 0x00D57D6B File Offset: 0x00D55F6B
		public override void Refresh(RoleDevelopOverviewMaterialItemData data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			this.RefreshContent();
		}

		// Token: 0x060353AF RID: 218031 RVA: 0x00D57D7C File Offset: 0x00D55F7C
		private void RefreshContent()
		{
			RoleDevelopOverviewMaterialItemData itemData = this.ItemData;
			RoleDevelopItemGroup groupItem = itemData.GroupItem;
			RoleDevTypeManage? typeManageConfig = ConfigBase<RoleDevConfig>.Instance.GetTypeManageConfig((int)groupItem.Type);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), typeManageConfig.Value.TypeDescribe, Array.Empty<object>());
			List<RoleDevelopNeedItem> data = RoleDevelopUtil.SortItemsByQuality(new List<RoleDevelopNeedItem>(groupItem.Items));
			this.MaterialItemLayout.RefreshByData(data, null, false);
			this.RefreshWeeklyMaterialText(itemData);
			bool flag = RoleDevelopUtil.CheckIsItemsHaveUnknownMaterial(groupItem.Items);
			this.ButtonConfirm.SetUiActive(!flag);
			this.ButtonConfirm.SetLocalTextNew(flag ? "RoleProject_Access_None" : "RoleProject_Button03", Array.Empty<object>());
			this.ButtonConfirm.SetEnableClick(!flag);
			base.GetItem(7).SetUIActive(flag);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "RoleProject_Access_None", Array.Empty<object>());
			base.GetItem(6).SetUIActive(ModelBase<RoleDevelopModel>.Instance.IsItemGroupCanBeSupplemented(groupItem));
			this.RefreshDoubleIcon();
		}

		// Token: 0x060353B0 RID: 218032 RVA: 0x00D57E88 File Offset: 0x00D56088
		private void RefreshWeeklyMaterialText(RoleDevelopOverviewMaterialItemData data)
		{
			RoleDevelopItemGroup groupItem = data.GroupItem;
			RoleDevCulProjectConfig? roleDevCulProjectConfig;
			int? num = (ConfigBase<RoleDevConfig>.Instance.GetRoleDevStaticConfig() != null) ? new int?(roleDevCulProjectConfig.GetValueOrDefault().UnknownItemId) : null;
			bool flag = false;
			foreach (RoleDevelopNeedItem roleDevelopNeedItem in groupItem.Items)
			{
				int itemId = roleDevelopNeedItem.ItemId;
				int? num2 = num;
				if (!(itemId == num2.GetValueOrDefault() & num2 != null))
				{
					RoleDevItemJumpGroup? itemJumpGroupConfig = ConfigBase<RoleDevConfig>.Instance.GetItemJumpGroupConfig(roleDevelopNeedItem.ItemId);
					if (itemJumpGroupConfig != null && itemJumpGroupConfig.GetValueOrDefault().ItemType == 5)
					{
						flag = true;
						break;
					}
				}
			}
			UUIText text = base.GetText(1);
			if (flag)
			{
				text.SetUIActive(true);
				int num3 = 1;
				ExchangeShared? exchangeShareConfig = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeShareConfig(new int?(num3));
				int exchangeRewardShareCount = ModelBase<ExchangeRewardModel>.Instance.GetExchangeRewardShareCount(num3);
				int maxCount = exchangeShareConfig.Value.MaxCount;
				int value = maxCount - exchangeRewardShareCount;
				LguiUtil instance = Singleton<LguiUtil>.Instance;
				UUIText uiText = text;
				string textTableId = "ReceivedCount";
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(maxCount);
				instance.SetLocalText(uiText, textTableId, new <>z__ReadOnlySingleElementList<object>(defaultInterpolatedStringHandler.ToStringAndClear()));
				return;
			}
			text.SetUIActive(false);
		}

		// Token: 0x060353B1 RID: 218033 RVA: 0x00D58008 File Offset: 0x00D56208
		private void RefreshDoubleIcon()
		{
			RoleDevelopItemGroup groupItem = this.ItemData.GroupItem;
			if (groupItem.Items.TrueForAll((RoleDevelopNeedItem item) => RoleDevelopUtil.IsUnknownItem(item.ItemId)))
			{
				base.GetItem(5).SetUIActive(false);
				return;
			}
			List<EDungeonType> dungeonTypesByItemDetection = RoleDevelopUtil.GetDungeonTypesByItemDetection(groupItem.Items);
			bool uiactive = false;
			using (List<EDungeonType>.Enumerator enumerator = dungeonTypesByItemDetection.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (RoleDevelopUtil.IsDungeonShowDouble(enumerator.Current))
					{
						uiactive = true;
						break;
					}
				}
			}
			base.GetItem(5).SetUIActive(uiactive);
		}

		// Token: 0x060353B2 RID: 218034 RVA: 0x00D580B8 File Offset: 0x00D562B8
		public bool HasItem(int configId)
		{
			return this.ItemData != null && this.ItemData.GroupItem.Items.Exists((RoleDevelopNeedItem item) => item.ItemId == configId);
		}

		// Token: 0x060353B3 RID: 218035 RVA: 0x00D580FD File Offset: 0x00D562FD
		public void RefreshSelf()
		{
			if (this.ItemData == null)
			{
				return;
			}
			this.RefreshContent();
		}

		// Token: 0x060353B4 RID: 218036 RVA: 0x00D5810E File Offset: 0x00D5630E
		private RoleDevelopProjectMaterialListItem CreateMaterialItem()
		{
			return new RoleDevelopProjectMaterialListItem();
		}

		// Token: 0x060353B5 RID: 218037 RVA: 0x00D58118 File Offset: 0x00D56318
		private void OnClickJump(int value)
		{
			RoleDevelopOverviewMaterialItemData itemData = this.ItemData;
			if (itemData == null)
			{
				return;
			}
			RoleDevelopItemGroup groupItem = itemData.GroupItem;
			itemData.JumpCallback(groupItem);
		}

		// Token: 0x0401EA22 RID: 125474
		private RoleDevelopOverviewMaterialItemData ItemData;

		// Token: 0x0401EA23 RID: 125475
		private ButtonItem ButtonConfirm;

		// Token: 0x0401EA24 RID: 125476
		private GenericLayout<RoleDevelopProjectMaterialListItem, RoleDevelopNeedItem> MaterialItemLayout;

		// Token: 0x0200B039 RID: 45113
		[NullableContext(0)]
		public static class EComponentType
		{
			// Token: 0x04036AB4 RID: 223924
			public const int TxtTitle = 0;

			// Token: 0x04036AB5 RID: 223925
			public const int TxtMatLimit = 1;

			// Token: 0x04036AB6 RID: 223926
			public const int HorizontalLayoutContent = 2;

			// Token: 0x04036AB7 RID: 223927
			public const int ItemBaseB = 3;

			// Token: 0x04036AB8 RID: 223928
			public const int ItemBtnConfirm = 4;

			// Token: 0x04036AB9 RID: 223929
			public const int ItemDouble = 5;

			// Token: 0x04036ABA RID: 223930
			public const int ItemSupplement = 6;

			// Token: 0x04036ABB RID: 223931
			public const int ItemPanelNotObtained = 7;

			// Token: 0x04036ABC RID: 223932
			public const int TxtNotObtained = 8;
		}
	}
}
