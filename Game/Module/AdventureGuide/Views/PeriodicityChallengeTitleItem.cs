using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.RoleDevelop;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi.RoleDevelop;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.AdventureGuide.Views
{
	// Token: 0x020061B6 RID: 25014
	[NullableContext(2)]
	[Nullable(0)]
	public class PeriodicityChallengeTitleItem : UiPanelBase
	{
		// Token: 0x0603F252 RID: 258642 RVA: 0x01033870 File Offset: 0x01031A70
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F253 RID: 258643 RVA: 0x010339E4 File Offset: 0x01031BE4
		protected override void OnStart()
		{
			this.RewardScroll = new GenericScrollViewNew<NewSoundDetectRewardItem, INewSoundDetectRewardItemData>(base.GetScrollViewWithScrollbar(6), new Func<NewSoundDetectRewardItem>(this.OnRewardLayoutUpdater), null, false, null);
			UUIItem item = base.GetItem(9);
			if (item != null)
			{
				this.RoleBadge = new RoleDevelopItemRoleBadge();
				this.RoleBadge.CreateByActor(item.GetOwner(), null);
			}
		}

		// Token: 0x0603F254 RID: 258644 RVA: 0x01033A3B File Offset: 0x01031C3B
		[NullableContext(1)]
		public void RefreshItem(SoundAreaDetectionRecord data)
		{
			this.Data = data;
			this.Type = (EPeriodicityChallengeType)this.Data.PeriodicityChallengeType;
			this.RefreshTitleItem();
			this.RefreshTimeItem();
			this.RefreshReward();
			this.RefreshRoleBadge();
		}

		// Token: 0x0603F255 RID: 258645 RVA: 0x01033A70 File Offset: 0x01031C70
		private void RefreshRoleBadge()
		{
			if (this.RoleBadge == null)
			{
				return;
			}
			RoleDevelopModel instance = ModelBase<RoleDevelopModel>.Instance;
			SoundAreaDetectionRecord data = this.Data;
			OneOf<DungeonDetection, SilentAreaDetection>? oneOf = (data != null) ? data.Conf : null;
			if (instance == null || oneOf == null)
			{
				this.RoleBadge.SetUiActive(false);
				return;
			}
			int item = oneOf.Value.IsT1 ? oneOf.Value.AsT1.Id : oneOf.Value.AsT2.Id;
			bool flag = instance.DevTargetRoleId != 0 && instance.GetDevelopRoleDeficitDetectionIdSet().Contains(item);
			this.RoleBadge.SetUiActive(flag);
			if (flag)
			{
				this.RoleBadge.SetRoleHeadIconPath(instance.GetDevelopRoleIconPath());
			}
		}

		// Token: 0x0603F256 RID: 258646 RVA: 0x01033B40 File Offset: 0x01031D40
		private void RefreshTitleItem()
		{
			DetectionTitlePanel? detectionTitlePanelConfig = ConfigBase<AdventureGuideConfig>.Instance.GetDetectionTitlePanelConfig(this.Data.DetectionTitlePanel);
			if (detectionTitlePanelConfig == null)
			{
				base.SetUiActive(false);
				return;
			}
			base.SetUiActive(true);
			base.SetTextureByPath(detectionTitlePanelConfig.Value.BgTexture, base.GetTexture(0), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), detectionTitlePanelConfig.Value.TitleText, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(5), detectionTitlePanelConfig.Value.SubTitleText, Array.Empty<object>());
		}

		// Token: 0x0603F257 RID: 258647 RVA: 0x01033BEC File Offset: 0x01031DEC
		private void RefreshTimeItem()
		{
			SecondaryGuideData? secondaryGuideDataConf = ConfigBase<AdventureGuideConfig>.Instance.GetSecondaryGuideDataConf(this.Data.Secondary);
			if (secondaryGuideDataConf.Value.TimeOutDay <= 0 || !this.IsTimeOutType())
			{
				base.GetItem(2).SetUIActive(false);
				return;
			}
			CommonDefine.ICountDown countDown = null;
			double num = 0.0;
			if (this.Type == EPeriodicityChallengeType.TowerVariation)
			{
				countDown = ModelBase<TowerModel>.Instance.GetSeasonCountDownData();
				num = (double)Singleton<MathUtils>.Instance.LongToNumber(ModelBase<TowerModel>.Instance.TowerEndTime.Value) - Singleton<TimeUtil>.Instance.GetServerTime();
			}
			if (this.Type == EPeriodicityChallengeType.ShipTowerPeriodicity)
			{
				countDown = ModelBase<ShipTowerModel>.Instance.GetSeasonCountDownData();
				num = ModelBase<ShipTowerModel>.Instance.GetRemainTime();
			}
			if (this.Type == EPeriodicityChallengeType.WeeklyRogue)
			{
				countDown = ModelBase<WeeklyRogueModel>.Instance.ActivityDataNew.GetCycleCountDownData();
				num = (double)ModelBase<WeeklyRogueModel>.Instance.ActivityDataNew.EndShowTime - Singleton<TimeUtil>.Instance.GetServerTime();
			}
			if (ModelBase<AdventureGuideModel>.Instance.IsWheelTowerType(this.Type))
			{
				countDown = ModelBase<WheelTowerModel>.Instance.ActivityData.GetCycleCountDownData();
				num = (double)ModelBase<WheelTowerModel>.Instance.ActivityData.EndShowTime - Singleton<TimeUtil>.Instance.GetServerTime();
			}
			if (countDown == null)
			{
				base.GetItem(2).SetUIActive(false);
				return;
			}
			bool uiactive = num <= (double)(secondaryGuideDataConf.Value.TimeOutDay * Singleton<TimeUtil>.Instance.OneDaySeconds);
			base.GetItem(2).SetUIActive(true);
			base.GetItem(3).SetUIActive(uiactive);
			base.GetText(4).SetText(countDown.CountDownText, true);
		}

		// Token: 0x0603F258 RID: 258648 RVA: 0x01033D78 File Offset: 0x01031F78
		private void RefreshReward()
		{
			List<INewSoundDetectRewardItemData> list = new List<INewSoundDetectRewardItemData>();
			Dictionary<int, int> showReward = ConfigBase<AdventureGuideConfig>.Instance.GetShowReward(this.Data.ShowRewardMap, null);
			if (showReward == null || this.IsRewardMapEqual(this.LastRefreshReward, showReward))
			{
				return;
			}
			this.LastRefreshReward = showReward;
			foreach (int num in showReward.Keys)
			{
				TItem itemData = new TItem(new InventoryDefine.GetItemData(num, 0), showReward[num]);
				NewSoundDetectRewardItemData item = new NewSoundDetectRewardItemData
				{
					ItemData = itemData,
					HaveFinish = false
				};
				list.Add(item);
			}
			this.RewardScroll.RefreshByData(list, delegate
			{
				GenericScrollViewNew<NewSoundDetectRewardItem, INewSoundDetectRewardItemData> rewardScroll = this.RewardScroll;
				TWeakObjectPtr<UUIItem>? tweakObjectPtr;
				if (((rewardScroll != null) ? ((rewardScroll.ContentItem != null) ? tweakObjectPtr.GetValueOrDefault().Get() : null) : null) != null)
				{
					GenericScrollViewNew<NewSoundDetectRewardItem, INewSoundDetectRewardItemData> rewardScroll2 = this.RewardScroll;
					if (rewardScroll2 == null)
					{
						return;
					}
					rewardScroll2.ScrollToLeft(0);
				}
			}, false);
		}

		// Token: 0x0603F259 RID: 258649 RVA: 0x01033E54 File Offset: 0x01032054
		private bool IsRewardMapEqual(Dictionary<int, int> map1, Dictionary<int, int> map2)
		{
			if (map1 == null || map2 == null)
			{
				return map1 == map2;
			}
			if (map1.Count != map2.Count)
			{
				return false;
			}
			foreach (KeyValuePair<int, int> keyValuePair in map1)
			{
				if (!map2.ContainsKey(keyValuePair.Key) || map2[keyValuePair.Key] != keyValuePair.Value)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603F25A RID: 258650 RVA: 0x01033EE4 File Offset: 0x010320E4
		[NullableContext(1)]
		private NewSoundDetectRewardItem OnRewardLayoutUpdater()
		{
			return new NewSoundDetectRewardItem();
		}

		// Token: 0x0603F25B RID: 258651 RVA: 0x01033EEB File Offset: 0x010320EB
		private bool IsTimeOutType()
		{
			return this.Type == EPeriodicityChallengeType.TowerVariation || this.Type == EPeriodicityChallengeType.ShipTowerPeriodicity || this.Type == EPeriodicityChallengeType.WeeklyRogue || this.Type == EPeriodicityChallengeType.WheelTowerNormal || this.Type == EPeriodicityChallengeType.WheelTowerEndless;
		}

		// Token: 0x0402374D RID: 145229
		private SoundAreaDetectionRecord Data;

		// Token: 0x0402374E RID: 145230
		private EPeriodicityChallengeType Type;

		// Token: 0x0402374F RID: 145231
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<NewSoundDetectRewardItem, INewSoundDetectRewardItemData> RewardScroll;

		// Token: 0x04023750 RID: 145232
		private RoleDevelopItemRoleBadge RoleBadge;

		// Token: 0x04023751 RID: 145233
		private Dictionary<int, int> LastRefreshReward;
	}
}
