using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x0200625D RID: 25181
	[NullableContext(1)]
	[Nullable(0)]
	public class TotalTopUpData : ActivityBaseData
	{
		// Token: 0x0603F768 RID: 259944 RVA: 0x01044B08 File Offset: 0x01042D08
		protected unsafe override void PhraseEx(ActivityData data)
		{
			TotalTopUpActivityInfo totalTopUpActivityInfo = (data != null) ? data.TotalTopUpActivityInfo : null;
			if (totalTopUpActivityInfo == null)
			{
				return;
			}
			string message = "活动数据Phrase";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Score", totalTopUpActivityInfo.Score);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Json", JsonSerializer.Serialize<TotalTopUpActivityInfo>(totalTopUpActivityInfo, null));
			TotalTopUpUtil.Debug(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.ProgressData.SetScore(totalTopUpActivityInfo.Score);
			this.UpdateReward(totalTopUpActivityInfo.TotalTopUpRewardInfos.ToList<TotalTopUpRewardInfo>());
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, base.Id);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603F769 RID: 259945 RVA: 0x01044BD0 File Offset: 0x01042DD0
		public void InitData(TotalTopUpActivityInfo info, int activityId)
		{
			RepeatedField<TotalTopUpRewardInfo> repeatedField = (info != null) ? info.TotalTopUpRewardInfos : null;
			this.ProgressData.Reset();
			this.RewardDataMap.Clear();
			this.RewardDataList.Clear();
			for (int i = 0; i < repeatedField.Count; i++)
			{
				TotalTopUpRewardInfo totalTopUpRewardInfo = repeatedField[i];
				TotalTopUpRewardData totalTopUpRewardData = new TotalTopUpRewardData();
				TotalTopUpReward? rewardConfigById = ConfigBase<TotalTopUpConfig>.Instance.GetRewardConfigById(totalTopUpRewardInfo.Id);
				totalTopUpRewardData.Id = totalTopUpRewardInfo.Id;
				totalTopUpRewardData.Score = totalTopUpRewardInfo.Score;
				totalTopUpRewardData.State = (ETotalTopUpRewardState)totalTopUpRewardInfo.Status;
				MapField<int, int> rewardContent = totalTopUpRewardInfo.RewardContent;
				if (rewardContent != null)
				{
					foreach (KeyValuePair<int, int> keyValuePair in rewardContent)
					{
						int key = keyValuePair.Key;
						int value = keyValuePair.Value;
						if (totalTopUpRewardData.FirstItemId == 0)
						{
							totalTopUpRewardData.FirstItemId = key;
							totalTopUpRewardData.FirstItemCount = value;
						}
						totalTopUpRewardData.ItemIdList.Add(key);
						totalTopUpRewardData.ItemMap[key] = value;
					}
				}
				ETotalTopUpPreviewFunction etotalTopUpPreviewFunction = (ETotalTopUpPreviewFunction)((rewardConfigById != null) ? rewardConfigById.Value.PreviewFunction : 0);
				if (etotalTopUpPreviewFunction != ETotalTopUpPreviewFunction.RolePreview)
				{
					if (etotalTopUpPreviewFunction == ETotalTopUpPreviewFunction.WeaponPreview)
					{
						totalTopUpRewardData.TotalTopUpWeaponPackageData = TotalTopUpWeaponPackageData.TryParseWeaponPackageData(totalTopUpRewardData.FirstItemId);
					}
				}
				else
				{
					totalTopUpRewardData.TotalTopUpRolePackageData = TotalTopUpRolePackageData.TryParsePackageData(totalTopUpRewardData.FirstItemId);
				}
				int[] collection = ((rewardConfigById != null) ? rewardConfigById.GetValueOrDefault().GetPreviewButtonRegistryArray() : null) ?? Array.Empty<int>();
				totalTopUpRewardData.PreviewButtonRegistry = new List<int>(collection);
				this.RewardDataList.Add(totalTopUpRewardData);
				this.RewardDataMap[totalTopUpRewardData.Id] = totalTopUpRewardData;
			}
			this.RewardDataList.Sort((TotalTopUpRewardData a, TotalTopUpRewardData b) => a.Score - b.Score);
			TotalTopUpRewardData totalTopUpRewardData2 = (this.RewardDataList.Count > 0) ? this.RewardDataList[0] : null;
			if (totalTopUpRewardData2 == null || totalTopUpRewardData2.Score != 0)
			{
				TotalTopUpUtil.Error("First reward is not appropriate", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			for (int j = 1; j < this.RewardDataList.Count; j++)
			{
				int score = this.RewardDataList[j].Score;
				this.ProgressData.PushLevel(score);
			}
			this.ProgressData.SortLevel();
			this.ProgressData.SetScore(info.Score);
			this.PageViewModel.InitData(this);
			this.ViewConfig = ConfigBase<TotalTopUpConfig>.Instance.GetViewConfigByActivityId(activityId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603F76A RID: 259946 RVA: 0x01044E98 File Offset: 0x01043098
		public void UpdateReward(List<TotalTopUpRewardInfo> rewardInfoList)
		{
			TotalTopUpUtil.Debug("更新奖励状态", default(ReadOnlySpan<ValueTuple<string, object>>));
			foreach (TotalTopUpRewardInfo totalTopUpRewardInfo in rewardInfoList)
			{
				TotalTopUpRewardData totalTopUpRewardData;
				if (!this.RewardDataMap.TryGetValue(totalTopUpRewardInfo.Id, out totalTopUpRewardData))
				{
					string message = "更新领奖时，奖励数据不存在";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RewardId", totalTopUpRewardInfo.Id);
					TotalTopUpUtil.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					totalTopUpRewardData.State = (ETotalTopUpRewardState)totalTopUpRewardInfo.Status;
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603F76B RID: 259947 RVA: 0x01044F54 File Offset: 0x01043154
		public void UpdateGoodsScore(List<TotalTopUpScoreInfo> infoList)
		{
			this.GoodsScoreMap.Clear();
			this.RechargeItemMap.Clear();
			foreach (TotalTopUpScoreInfo totalTopUpScoreInfo in infoList)
			{
				if (totalTopUpScoreInfo.Type == 0)
				{
					this.RechargeItemMap[totalTopUpScoreInfo.GoodsId] = totalTopUpScoreInfo.Score;
				}
				else
				{
					this.GoodsScoreMap[totalTopUpScoreInfo.GoodsId] = totalTopUpScoreInfo.Score;
				}
			}
			List<string> list = new List<string>();
			foreach (int key in this.GoodsScoreMap.Keys)
			{
				int num;
				this.GoodsScoreMap.TryGetValue(key, out num);
				list.Add(string.Concat(new string[]
				{
					"[",
					key.ToString(),
					":",
					num.ToString(),
					"]"
				}));
			}
			string message = "更新GoodsScoreMap";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Content", string.Join(",", list));
			TotalTopUpUtil.Debug(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			List<string> list2 = new List<string>();
			foreach (int key2 in this.RechargeItemMap.Keys)
			{
				int num2;
				this.RechargeItemMap.TryGetValue(key2, out num2);
				list2.Add(string.Concat(new string[]
				{
					"[",
					key2.ToString(),
					":",
					num2.ToString(),
					"]"
				}));
			}
			string message2 = "更新RechargeItemMap";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Content", string.Join(",", list2));
			TotalTopUpUtil.Debug(message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}

		// Token: 0x17009C2F RID: 39983
		// (get) Token: 0x0603F76C RID: 259948 RVA: 0x0104516C File Offset: 0x0104336C
		public override bool RedPointShowState
		{
			get
			{
				using (List<TotalTopUpRewardData>.Enumerator enumerator = this.RewardDataList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.State == ETotalTopUpRewardState.CanClaim)
						{
							return true;
						}
					}
				}
				return false;
			}
		}

		// Token: 0x040239D5 RID: 145877
		public readonly List<TotalTopUpRewardData> RewardDataList = new List<TotalTopUpRewardData>();

		// Token: 0x040239D6 RID: 145878
		public readonly Dictionary<int, TotalTopUpRewardData> RewardDataMap = new Dictionary<int, TotalTopUpRewardData>();

		// Token: 0x040239D7 RID: 145879
		public readonly TotalTopUpProgressData ProgressData = new TotalTopUpProgressData();

		// Token: 0x040239D8 RID: 145880
		public readonly Dictionary<int, int> GoodsScoreMap = new Dictionary<int, int>();

		// Token: 0x040239D9 RID: 145881
		public readonly Dictionary<int, int> RechargeItemMap = new Dictionary<int, int>();

		// Token: 0x040239DA RID: 145882
		public TotalTopUpPageViewModel PageViewModel = new TotalTopUpPageViewModel();

		// Token: 0x040239DB RID: 145883
		public TotalTopUpViewConfig? ViewConfig;

		// Token: 0x040239DC RID: 145884
		public bool HasRequestedScoreInfo;
	}
}
