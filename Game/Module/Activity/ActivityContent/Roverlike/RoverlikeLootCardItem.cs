using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200642A RID: 25642
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeLootCardItem : UiPanelBase
	{
		// Token: 0x060405FF RID: 263679 RVA: 0x01080848 File Offset: 0x0107EA48
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040600 RID: 263680 RVA: 0x010809FF File Offset: 0x0107EBFF
		protected override void OnStart()
		{
			this.StarLayout = new GenericLayout<RoverlikeLootStarItem, bool>(base.GetHorizontalLayout(4), new Func<RoverlikeLootStarItem>(this.CreateStarItem), base.GetItem(5).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x06040601 RID: 263681 RVA: 0x01080A34 File Offset: 0x0107EC34
		public void Refresh(RoverlikeLootGainEntry entry)
		{
			RoverRogueLoot? lootConfig = ConfigBase<RoverlikeConfig>.Instance.GetLootConfig(entry.ConfigId);
			if (lootConfig == null)
			{
				return;
			}
			base.SetTextureByPath(lootConfig.Value.Icon, base.GetTexture(2), null, null);
			RoverlikeActivityData activityData = this.ActivityData;
			bool unlocked = activityData != null && activityData.IsLootUnlocked(entry.ConfigId);
			this.RefreshTips(unlocked);
			if (entry.Unlock)
			{
				this.RefreshUnlocked(entry, lootConfig.Value);
				return;
			}
			this.RefreshLocked(entry, lootConfig.Value);
		}

		// Token: 0x06040602 RID: 263682 RVA: 0x01080AC8 File Offset: 0x0107ECC8
		public void ResetView()
		{
			GenericLayout<RoverlikeLootStarItem, bool> starLayout = this.StarLayout;
			if (starLayout != null)
			{
				starLayout.RefreshByData(new List<bool>(), null, false);
			}
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(11);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIText text = base.GetText(7);
			if (text == null)
			{
				return;
			}
			text.SetUIActive(false);
		}

		// Token: 0x17009DF3 RID: 40435
		// (get) Token: 0x06040603 RID: 263683 RVA: 0x01080B26 File Offset: 0x0107ED26
		[Nullable(2)]
		private RoverlikeActivityData ActivityData
		{
			[NullableContext(2)]
			get
			{
				RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
				if (instance == null)
				{
					return null;
				}
				return instance.GetCurrentActivityData();
			}
		}

		// Token: 0x06040604 RID: 263684 RVA: 0x01080B38 File Offset: 0x0107ED38
		private void RefreshTips(bool unlocked)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), unlocked ? "RoverRogue_LootUpgradeText" : "RoverRogue_LootUnlockText", Array.Empty<object>());
		}

		// Token: 0x06040605 RID: 263685 RVA: 0x01080B60 File Offset: 0x0107ED60
		private void RefreshUnlocked(RoverlikeLootGainEntry entry, RoverRogueLoot config)
		{
			UUITexture texture = base.GetTexture(3);
			if (texture != null)
			{
				texture.SetUIActive(false);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), config.Name, Array.Empty<object>());
			ValueTuple<string, int[]> levelDesc = this.GetLevelDesc(config, entry.LootLv);
			string item = levelDesc.Item1;
			int[] item2 = levelDesc.Item2;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), item, item2);
			UUIText text = base.GetText(7);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			this.RefreshStars(entry.LootLv, config.MaxLevel);
			bool flag = entry.LootLv >= config.MaxLevel;
			UUIItem item3 = base.GetItem(8);
			if (item3 != null)
			{
				item3.SetUIActive(!flag);
			}
			UUIItem item4 = base.GetItem(11);
			if (item4 != null)
			{
				item4.SetUIActive(flag);
			}
			if (!flag)
			{
				int num = entry.LootLv - 1;
				int num2 = (num >= 0 && num < config.RoomPassedRequiredLength) ? config.RoomPassedRequired(num) : 0;
				int num3 = Math.Max(0, num2 - entry.LootRoomPassedCounter);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(10), "RoverRogue_LootUpGradeCondition", new <>z__ReadOnlySingleElementList<object>(num3));
			}
		}

		// Token: 0x06040606 RID: 263686 RVA: 0x01080C88 File Offset: 0x0107EE88
		private void RefreshLocked(RoverlikeLootGainEntry entry, RoverRogueLoot config)
		{
			UUITexture texture = base.GetTexture(3);
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), config.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "RoverRogue_LootUnlockDesc", Array.Empty<object>());
			int outGameUnlockConditionId = config.OutGameUnlockConditionId;
			UUIText text = base.GetText(10);
			if (outGameUnlockConditionId > 0)
			{
				string str = ConfigMultiTextLang.GetLocalTextNew(LevelGeneralCommons.GetConditionGroupHintText(outGameUnlockConditionId) ?? "", null) ?? "";
				string str2 = (entry.Target > 0) ? StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("RoverRogueLoot_UnlockProgressShow", null) ?? "", new string[]
				{
					entry.Progress.ToString(),
					entry.Target.ToString()
				}) : "";
				if (text != null)
				{
					text.SetText(str + str2, true);
				}
			}
			this.RefreshStars(0, config.MaxLevel);
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(true);
			}
			UUIItem item2 = base.GetItem(11);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x06040607 RID: 263687 RVA: 0x01080DA8 File Offset: 0x0107EFA8
		private void RefreshStars(int level, int maxLevel)
		{
			List<bool> list = new List<bool>();
			for (int i = 0; i < maxLevel; i++)
			{
				list.Add(i < level);
			}
			this.StarLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06040608 RID: 263688 RVA: 0x01080DE0 File Offset: 0x0107EFE0
		[return: TupleElementNames(new string[]
		{
			"desc",
			"descParams"
		})]
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		private ValueTuple<string, int[]> GetLevelDesc(RoverRogueLoot config, int lootLv)
		{
			int num = (lootLv - 1 > 0) ? (lootLv - 1) : 0;
			string item = (num < config.LevelDescLength) ? config.LevelDesc(num) : "";
			int[] item2;
			if (num < config.LevelDescParamsLength)
			{
				IntArray? intArray = config.LevelDescParams(num);
				item2 = (((intArray != null) ? intArray.GetValueOrDefault().GetArrayIntArray() : null) ?? Array.Empty<int>());
			}
			else
			{
				item2 = Array.Empty<int>();
			}
			return new ValueTuple<string, int[]>(item, item2);
		}

		// Token: 0x06040609 RID: 263689 RVA: 0x01080E59 File Offset: 0x0107F059
		private RoverlikeLootStarItem CreateStarItem()
		{
			return new RoverlikeLootStarItem();
		}

		// Token: 0x04024100 RID: 147712
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RoverlikeLootStarItem, bool> StarLayout;

		// Token: 0x0200C499 RID: 50329
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C834 RID: 247860
			public const int TxtName = 0;

			// Token: 0x0403C835 RID: 247861
			public const int TxtStarLabel = 1;

			// Token: 0x0403C836 RID: 247862
			public const int TexIcon = 2;

			// Token: 0x0403C837 RID: 247863
			public const int TexIconMask = 3;

			// Token: 0x0403C838 RID: 247864
			public const int StarLayout = 4;

			// Token: 0x0403C839 RID: 247865
			public const int StarItem = 5;

			// Token: 0x0403C83A RID: 247866
			public const int TxtEffect = 6;

			// Token: 0x0403C83B RID: 247867
			public const int TxtLockInfo = 7;

			// Token: 0x0403C83C RID: 247868
			public const int PnlUpgrade = 8;

			// Token: 0x0403C83D RID: 247869
			public const int TxtTips = 9;

			// Token: 0x0403C83E RID: 247870
			public const int TxtUpgradeCond = 10;

			// Token: 0x0403C83F RID: 247871
			public const int PnlMax = 11;
		}
	}
}
