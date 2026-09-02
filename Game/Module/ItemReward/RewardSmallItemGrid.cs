using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B63 RID: 23395
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RewardSmallItemGrid : LoopScrollSmallItemGrid<RewardItemData>
	{
		// Token: 0x0603B2D1 RID: 242385 RVA: 0x00EF93F9 File Offset: 0x00EF75F9
		protected override void OnStart()
		{
			base.SetUseFixedAsync(true);
		}

		// Token: 0x0603B2D2 RID: 242386 RVA: 0x00EF9402 File Offset: 0x00EF7602
		protected override void OnAddEvents()
		{
			base.OnAddEvents();
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.OnFuncValueChange));
		}

		// Token: 0x0603B2D3 RID: 242387 RVA: 0x00EF9426 File Offset: 0x00EF7626
		protected override void OnRemoveEvents()
		{
			base.OnRemoveEvents();
			Singleton<EventSystem>.Instance.Remove(EEventName.OnItemFuncValueChange, new Action<int>(this.OnFuncValueChange));
		}

		// Token: 0x0603B2D4 RID: 242388 RVA: 0x00EF944A File Offset: 0x00EF764A
		protected override void OnRefresh(RewardItemData data, bool isSelected, int gridIndex)
		{
			this.RefreshByData(data);
		}

		// Token: 0x0603B2D5 RID: 242389 RVA: 0x00EF9454 File Offset: 0x00EF7654
		private void RefreshByData(RewardItemData data)
		{
			this.ItemData = data;
			ItemConfig config = data.GetConfig();
			int configId = data.ConfigId;
			string topRightTextId = null;
			string topRightTextBgColor = null;
			string topRightTextColor = null;
			EDropItemType dropItemType = data.GetDropItemType();
			bool value = false;
			if (dropItemType != EDropItemType.Activity)
			{
				if (dropItemType == EDropItemType.MultiTimeExchange)
				{
					topRightTextId = "Reward_Tag_Magnification";
					topRightTextBgColor = ConfigCommonParamById.GetStringConfig("Reward_Tag_Magnification_Bg_Color");
					topRightTextColor = ConfigCommonParamById.GetStringConfig("Reward_Tag_Magnification_Text_Color");
				}
			}
			else if (!ModelBase<DailyActivityModel>.Instance.ShouldShowLivenessRewardDoubleTag(configId))
			{
				topRightTextId = "Reward_Tag_Extra";
				topRightTextBgColor = ConfigCommonParamById.GetStringConfig("Reward_Tag_Extra_Bg_Color");
				topRightTextColor = ConfigCommonParamById.GetStringConfig("Reward_Tag_Extra_Text_Color");
			}
			else
			{
				value = true;
			}
			bool flag = true;
			InventoryDefine.EItemDataType itemDataType = config.ItemDataType;
			if (itemDataType <= InventoryDefine.EItemDataType.PhantomItem)
			{
				if (itemDataType == InventoryDefine.EItemDataType.RoleItem)
				{
					RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(configId);
					CharacterSmallItemGrid parameters = new CharacterSmallItemGrid
					{
						Data = data,
						ItemConfigId = new int?(configId),
						BottomTextId = roleConfig.Value.Name,
						QualityId = new int?(roleConfig.Value.QualityId),
						TopRightTextId = topRightTextId,
						TopRightTextBgColor = topRightTextBgColor,
						TopRightTextColor = topRightTextColor,
						IsDoubleRewardVisible = new bool?(value)
					};
					base.Apply<CharacterSmallItemGrid>(parameters);
					return;
				}
				if (itemDataType == InventoryDefine.EItemDataType.PhantomItem)
				{
					if (ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(configId).Value.ParentMonsterId == 0)
					{
						PhantomItemData phantomItemData = ModelBase<InventoryModel>.Instance.GetPhantomItemData(data.UniqueId);
						PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(data.UniqueId);
						PhantomSmallItemGrid parameters2 = new PhantomSmallItemGrid
						{
							Data = data,
							ItemConfigId = new int?(configId),
							TopRightTextId = topRightTextId,
							TopRightTextBgColor = topRightTextBgColor,
							TopRightTextColor = topRightTextColor,
							FetterGroupId = new int?(phantomBattleData.GetFetterGroupId()),
							IsPhantomLock = new bool?(phantomItemData.GetIsLock()),
							IsPhantomDeprecate = new bool?(phantomItemData.GetIsDeprecated()),
							IsDoubleRewardVisible = new bool?(value)
						};
						base.Apply<PhantomSmallItemGrid>(parameters2);
						return;
					}
				}
			}
			else if (itemDataType == InventoryDefine.EItemDataType.MotorStickerItem || itemDataType - InventoryDefine.EItemDataType.MotorFrameItem <= 2)
			{
				flag = false;
			}
			PropSmallItemGrid propSmallItemGrid = new PropSmallItemGrid();
			propSmallItemGrid.Data = data;
			propSmallItemGrid.ItemConfigId = new int?(configId);
			string bottomText;
			if (!flag)
			{
				bottomText = "";
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("x");
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.Count);
				bottomText = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			propSmallItemGrid.BottomText = bottomText;
			propSmallItemGrid.TopRightTextId = topRightTextId;
			propSmallItemGrid.TopRightTextBgColor = topRightTextBgColor;
			propSmallItemGrid.TopRightTextColor = topRightTextColor;
			propSmallItemGrid.RoleDevelopStateTagType = data.GetRoleDevelopStateTagType();
			propSmallItemGrid.IsTimeFlagVisible = new bool?(data.GetShowTimeFlag());
			propSmallItemGrid.IsDoubleRewardVisible = new bool?(value);
			PropSmallItemGrid parameters3 = propSmallItemGrid;
			base.Apply<PropSmallItemGrid>(parameters3);
		}

		// Token: 0x0603B2D6 RID: 242390 RVA: 0x00EF9702 File Offset: 0x00EF7902
		private void OnFuncValueChange(int uniqueId)
		{
			if (this.ItemData == null || this.ItemData.UniqueId != uniqueId)
			{
				return;
			}
			this.RefreshByData(this.ItemData);
		}

		// Token: 0x040215AE RID: 136622
		[Nullable(2)]
		private RewardItemData ItemData;
	}
}
