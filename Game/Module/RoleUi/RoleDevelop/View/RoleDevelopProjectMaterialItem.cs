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
	// Token: 0x020050B9 RID: 20665
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleDevelopProjectMaterialItem : GridProxyAbstract<RoleDevelopProjectMaterialItemData>
	{
		// Token: 0x060353E9 RID: 218089 RVA: 0x00D58D48 File Offset: 0x00D56F48
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
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
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060353EA RID: 218090 RVA: 0x00D58EBC File Offset: 0x00D570BC
		protected override UniTask OnBeforeStartAsync()
		{
			RoleDevelopProjectMaterialItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevelopProjectMaterialItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060353EB RID: 218091 RVA: 0x00D58EFF File Offset: 0x00D570FF
		public override void Refresh(RoleDevelopProjectMaterialItemData data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			this.RefreshContent();
		}

		// Token: 0x060353EC RID: 218092 RVA: 0x00D58F10 File Offset: 0x00D57110
		private void RefreshContent()
		{
			RoleDevelopProjectMaterialItemData itemData = this.ItemData;
			RoleDevelopItemGroup groupItem = itemData.GroupItem;
			RoleDevTypeManage? typeManageConfig = ConfigBase<RoleDevConfig>.Instance.GetTypeManageConfig((int)groupItem.Type);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), typeManageConfig.Value.TypeDescribe, Array.Empty<object>());
			List<RoleDevelopNeedItem> data = RoleDevelopUtil.SortItemsByQuality(new List<RoleDevelopNeedItem>(groupItem.Items));
			this.MaterialItemLayout.RefreshByData(data, null, false);
			this.RefreshWeeklyMaterialText(itemData);
			bool flag = RoleDevelopUtil.CheckIsItemsHaveUnknownMaterial(groupItem.Items);
			bool flag2 = RoleDevelopUtil.CheckIsAllNeedItemsEnough(groupItem.Items);
			base.GetItem(6).SetUIActive(flag2 && !flag);
			this.ButtonConfirm.SetUiActive(!flag);
			this.ButtonConfirm.SetLocalTextNew(flag ? "RoleProject_Access_None" : "RoleProject_Button03", Array.Empty<object>());
			this.ButtonConfirm.SetEnableClick(!flag);
			base.GetItem(5).SetUIActive(flag);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "RoleProject_Access_None", Array.Empty<object>());
			base.GetItem(8).SetUIActive(ModelBase<RoleDevelopModel>.Instance.IsItemGroupCanBeSupplemented(groupItem));
			this.RefreshDoubleIcon();
		}

		// Token: 0x060353ED RID: 218093 RVA: 0x00D59040 File Offset: 0x00D57240
		private void RefreshWeeklyMaterialText(RoleDevelopProjectMaterialItemData data)
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

		// Token: 0x060353EE RID: 218094 RVA: 0x00D591C0 File Offset: 0x00D573C0
		private void RefreshDoubleIcon()
		{
			RoleDevelopItemGroup groupItem = this.ItemData.GroupItem;
			if (groupItem.Items.TrueForAll((RoleDevelopNeedItem item) => RoleDevelopUtil.IsUnknownItem(item.ItemId)))
			{
				base.GetItem(9).SetUIActive(false);
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
			base.GetItem(9).SetUIActive(uiactive);
		}

		// Token: 0x060353EF RID: 218095 RVA: 0x00D59274 File Offset: 0x00D57474
		public bool HasItem(int configId)
		{
			return this.ItemData != null && this.ItemData.GroupItem.Items.Exists((RoleDevelopNeedItem item) => item.ItemId == configId);
		}

		// Token: 0x060353F0 RID: 218096 RVA: 0x00D592B9 File Offset: 0x00D574B9
		public void RefreshSelf()
		{
			if (this.ItemData == null)
			{
				return;
			}
			this.RefreshContent();
		}

		// Token: 0x060353F1 RID: 218097 RVA: 0x00D592CA File Offset: 0x00D574CA
		private RoleDevelopProjectMaterialListItem CreateMaterialItem()
		{
			return new RoleDevelopProjectMaterialListItem();
		}

		// Token: 0x060353F2 RID: 218098 RVA: 0x00D592D4 File Offset: 0x00D574D4
		private void OnClickJump(int value)
		{
			RoleDevelopProjectMaterialItemData itemData = this.ItemData;
			if (itemData == null)
			{
				return;
			}
			RoleDevelopItemGroup groupItem = itemData.GroupItem;
			itemData.JumpCallback(groupItem);
			if (itemData.LogRoleId != null && itemData.LogMainPage != null && itemData.LogSubPage != null)
			{
				ERoleDevelopLogItemState value2 = ERoleDevelopLogItemState.Normal;
				if (!RoleDevelopUtil.CheckIsAllNeedItemsEnough(groupItem.Items))
				{
					value2 = (ModelBase<RoleDevelopModel>.Instance.IsItemGroupCanBeSupplemented(groupItem) ? ERoleDevelopLogItemState.CanComplement : ERoleDevelopLogItemState.NotComplement);
				}
				ControllerBase<RoleController>.Instance.LogRoleDevelopClick(itemData.LogRoleId.Value, itemData.LogMainPage.Value, itemData.LogSubPage.Value, new ERoleDevelopLogItemState?(value2));
			}
		}

		// Token: 0x0401EA31 RID: 125489
		private RoleDevelopProjectMaterialItemData ItemData;

		// Token: 0x0401EA32 RID: 125490
		private ButtonItem ButtonConfirm;

		// Token: 0x0401EA33 RID: 125491
		private GenericLayout<RoleDevelopProjectMaterialListItem, RoleDevelopNeedItem> MaterialItemLayout;

		// Token: 0x0200B040 RID: 45120
		[NullableContext(0)]
		public static class EComponentType
		{
			// Token: 0x04036AD9 RID: 223961
			public const int TxtTitle = 0;

			// Token: 0x04036ADA RID: 223962
			public const int TxtMatLimit = 1;

			// Token: 0x04036ADB RID: 223963
			public const int HorizontalLayoutContent = 2;

			// Token: 0x04036ADC RID: 223964
			public const int ItemBaseB = 3;

			// Token: 0x04036ADD RID: 223965
			public const int ItemBtnConfirm = 4;

			// Token: 0x04036ADE RID: 223966
			public const int ItemPanelNotObtained = 5;

			// Token: 0x04036ADF RID: 223967
			public const int ItemFinishTag = 6;

			// Token: 0x04036AE0 RID: 223968
			public const int TextNoMaterial = 7;

			// Token: 0x04036AE1 RID: 223969
			public const int ItemSupplement = 8;

			// Token: 0x04036AE2 RID: 223970
			public const int ItemDouble = 9;
		}
	}
}
