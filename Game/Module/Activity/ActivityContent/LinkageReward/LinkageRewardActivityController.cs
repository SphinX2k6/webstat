using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Reward;

namespace CSharpScript.Game.Module.Activity.ActivityContent.LinkageReward
{
	// Token: 0x02006754 RID: 26452
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LinkageRewardActivityController : ActivityControllerBase<LinkageRewardActivityController>
	{
		// Token: 0x06041F1E RID: 270110 RVA: 0x010EABFE File Offset: 0x010E8DFE
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06041F1F RID: 270111 RVA: 0x010EAC00 File Offset: 0x010E8E00
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_ActivityCyberWelfare";
		}

		// Token: 0x06041F20 RID: 270112 RVA: 0x010EAC07 File Offset: 0x010E8E07
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new LinkageRewardActivitySubView();
		}

		// Token: 0x06041F21 RID: 270113 RVA: 0x010EAC0E File Offset: 0x010E8E0E
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			return new LinkageRewardActivityData();
		}

		// Token: 0x06041F22 RID: 270114 RVA: 0x010EAC15 File Offset: 0x010E8E15
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x06041F23 RID: 270115 RVA: 0x010EAC18 File Offset: 0x010E8E18
		[NullableContext(2)]
		public static void ClaimAllRewardsByController(int activityId, int fallbackId, LinkageCheckInType fallbackType, Action onFinished = null)
		{
			LinkageRewardActivityData activityData = LinkageRewardActivityController.GetActivityData(activityId);
			if (activityData == null)
			{
				LinkageRewardActivityController.GetRewardById(activityId, fallbackId, fallbackType, new int[]
				{
					fallbackId
				}, delegate(bool _)
				{
					Action onFinished2 = onFinished;
					if (onFinished2 == null)
					{
						return;
					}
					onFinished2();
				});
				return;
			}
			LinkageCheckInType linkageCheckInType = LinkageCheckInType.KeepCheckIn;
			LinkageCheckInType normalType = LinkageCheckInType.NormalCheckIn;
			int[] unlockUnclaimedRewardIds = activityData.GetUnlockUnclaimedRewardIds(linkageCheckInType);
			int[] normalIds = activityData.GetUnlockUnclaimedRewardIds(normalType);
			List<RewardItemData> keepPreviewRewards = LinkageRewardActivityController.BuildPreviewRewardItems(unlockUnclaimedRewardIds, linkageCheckInType);
			List<RewardItemData> normalPreviewRewards = LinkageRewardActivityController.BuildPreviewRewardItems(normalIds, normalType);
			if (unlockUnclaimedRewardIds.Length != 0 && normalIds.Length != 0)
			{
				List<RewardItemData> mergedRewards = new List<RewardItemData>();
				Action<bool> <>9__5;
				LinkageRewardActivityController.GetRewardById(activityId, unlockUnclaimedRewardIds[0], linkageCheckInType, unlockUnclaimedRewardIds, delegate(bool isKeepSuccess)
				{
					if (isKeepSuccess)
					{
						mergedRewards.AddRange(keepPreviewRewards);
						int activityId2 = activityId;
						int[] normalIds;
						int id = normalIds[0];
						LinkageCheckInType normalType = normalType;
						normalIds = normalIds;
						Action<bool> onResponse;
						if ((onResponse = <>9__5) == null)
						{
							onResponse = (<>9__5 = delegate(bool isNormalSuccess)
							{
								if (isNormalSuccess)
								{
									mergedRewards.AddRange(normalPreviewRewards);
								}
								LinkageRewardActivityController.OpenMergedRewardView(LinkageRewardActivityController.MergeRewardItems(mergedRewards));
								Action onFinished3 = onFinished;
								if (onFinished3 == null)
								{
									return;
								}
								onFinished3();
							});
						}
						LinkageRewardActivityController.GetRewardById(activityId2, id, normalType, normalIds, onResponse);
						return;
					}
					Action onFinished2 = onFinished;
					if (onFinished2 == null)
					{
						return;
					}
					onFinished2();
				});
				return;
			}
			if (unlockUnclaimedRewardIds.Length != 0)
			{
				LinkageRewardActivityController.GetRewardById(activityId, unlockUnclaimedRewardIds[0], linkageCheckInType, unlockUnclaimedRewardIds, delegate(bool isSuccess)
				{
					if (isSuccess)
					{
						LinkageRewardActivityController.OpenMergedRewardView(keepPreviewRewards);
					}
					Action onFinished2 = onFinished;
					if (onFinished2 == null)
					{
						return;
					}
					onFinished2();
				});
				return;
			}
			if (normalIds.Length != 0)
			{
				LinkageRewardActivityController.GetRewardById(activityId, normalIds[0], normalType, normalIds, delegate(bool isSuccess)
				{
					if (isSuccess)
					{
						LinkageRewardActivityController.OpenMergedRewardView(normalPreviewRewards);
					}
					Action onFinished2 = onFinished;
					if (onFinished2 == null)
					{
						return;
					}
					onFinished2();
				});
				return;
			}
			LinkageRewardActivityController.GetRewardById(activityId, fallbackId, fallbackType, new int[]
			{
				fallbackId
			}, delegate(bool _)
			{
				Action onFinished2 = onFinished;
				if (onFinished2 == null)
				{
					return;
				}
				onFinished2();
			});
		}

		// Token: 0x06041F24 RID: 270116 RVA: 0x010EAD78 File Offset: 0x010E8F78
		[NullableContext(2)]
		public static void GetRewardById(int activityId, int id, LinkageCheckInType linkageCheckInType, int[] rewardIds = null, Action<bool> onResponse = null)
		{
			LinkageRewardActivityController.<>c__DisplayClass6_0 CS$<>8__locals1 = new LinkageRewardActivityController.<>c__DisplayClass6_0();
			CS$<>8__locals1.linkageCheckInType = linkageCheckInType;
			CS$<>8__locals1.onResponse = onResponse;
			LinkageCheckInRewardRequest linkageCheckInRewardRequest = LinkageCheckInRewardRequest.Create();
			LinkageRewardActivityController.<>c__DisplayClass6_0 CS$<>8__locals2 = CS$<>8__locals1;
			int[] taskIds;
			if (rewardIds == null || rewardIds.Length == 0)
			{
				(taskIds = new int[1])[0] = id;
			}
			else
			{
				taskIds = rewardIds;
			}
			CS$<>8__locals2.taskIds = taskIds;
			linkageCheckInRewardRequest.TaskIds.AddRange(CS$<>8__locals1.taskIds);
			linkageCheckInRewardRequest.Type = CS$<>8__locals1.linkageCheckInType;
			CS$<>8__locals1.activityData = (ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LinkageRewardActivityData);
			LinkageRewardActivityData activityData = CS$<>8__locals1.activityData;
			if (activityData != null)
			{
				activityData.SetRewardsToGotState(CS$<>8__locals1.taskIds, CS$<>8__locals1.linkageCheckInType);
			}
			Singleton<Net>.Instance.Call<LinkageCheckInRewardResponse>(ERequestMessageId.LinkageCheckInRewardRequest, linkageCheckInRewardRequest, delegate(LinkageCheckInRewardResponse response, Net.CallbackStatus _)
			{
				bool flag = response != null && response.ErrorCode == Aki.Protocol.ErrorCode.Success;
				if (!flag)
				{
					LinkageRewardActivityData activityData2 = CS$<>8__locals1.activityData;
					if (activityData2 != null)
					{
						activityData2.RevertOptimisticClaimReward(CS$<>8__locals1.taskIds, CS$<>8__locals1.linkageCheckInType);
					}
					if (response != null)
					{
						ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 16648, null, true, true);
					}
				}
				Action<bool> onResponse2 = CS$<>8__locals1.onResponse;
				if (onResponse2 == null)
				{
					return;
				}
				onResponse2(flag);
			}, 0);
		}

		// Token: 0x06041F25 RID: 270117 RVA: 0x010EAE27 File Offset: 0x010E9027
		[NullableContext(2)]
		private static LinkageRewardActivityData GetActivityData(int activityId)
		{
			return ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as LinkageRewardActivityData;
		}

		// Token: 0x06041F26 RID: 270118 RVA: 0x010EAE3C File Offset: 0x010E903C
		private static List<RewardItemData> BuildPreviewRewardItems(IReadOnlyList<int> rewardIds, LinkageCheckInType linkageType)
		{
			Dictionary<string, RewardItemData> dictionary = new Dictionary<string, RewardItemData>();
			foreach (int id in rewardIds)
			{
				LinkageReward? byId = ConfigBase<LinkageRewardActivityConfig>.Instance.GetById(id);
				if (byId != null)
				{
					int num = (linkageType == LinkageCheckInType.KeepCheckIn) ? ((byId.Value.KeepDropId > 0) ? byId.Value.KeepDropId : byId.Value.DropId) : byId.Value.DropId;
					if (num > 0)
					{
						foreach (TItem titem in ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(num))
						{
							int itemId = titem.ItemData.ItemId;
							int incId = titem.ItemData.IncId;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
							defaultInterpolatedStringHandler.AppendFormatted<int>(itemId);
							string key = defaultInterpolatedStringHandler.ToStringAndClear();
							RewardItemData rewardItemData;
							if (dictionary.TryGetValue(key, out rewardItemData))
							{
								rewardItemData.Count += titem.Count;
							}
							else
							{
								dictionary[key] = new RewardItemData(itemId, titem.Count, new int?(incId), EDropItemType.Normal);
							}
						}
					}
				}
			}
			return dictionary.Values.ToList<RewardItemData>();
		}

		// Token: 0x06041F27 RID: 270119 RVA: 0x010EAFDC File Offset: 0x010E91DC
		private static void OpenMergedRewardView(List<RewardItemData> rewardItems)
		{
			if (rewardItems.Count <= 0)
			{
				return;
			}
			ControllerBase<ItemRewardController>.Instance.OpenCommonRewardView(1009, rewardItems, null);
		}

		// Token: 0x06041F28 RID: 270120 RVA: 0x010EAFFC File Offset: 0x010E91FC
		private static List<RewardItemData> MergeRewardItems(IReadOnlyList<RewardItemData> rewardItems)
		{
			Dictionary<int, RewardItemData> dictionary = new Dictionary<int, RewardItemData>();
			foreach (RewardItemData rewardItemData in rewardItems)
			{
				int configId = rewardItemData.ConfigId;
				RewardItemData rewardItemData2;
				if (dictionary.TryGetValue(configId, out rewardItemData2))
				{
					rewardItemData2.Count += rewardItemData.Count;
				}
				else
				{
					dictionary[configId] = new RewardItemData(configId, rewardItemData.Count, new int?(rewardItemData.UniqueId), EDropItemType.Normal);
				}
			}
			return dictionary.Values.ToList<RewardItemData>();
		}
	}
}
