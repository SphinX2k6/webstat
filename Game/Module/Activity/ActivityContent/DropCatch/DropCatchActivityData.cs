using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x02006886 RID: 26758
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchActivityData : ActivityBaseData
	{
		// Token: 0x06042AB9 RID: 273081 RVA: 0x0111D3DC File Offset: 0x0111B5DC
		protected override void PhraseEx(ActivityData data)
		{
			if (data == null)
			{
				return;
			}
			DropCatchActivityInfo dropCatchActivityInfo = data.DropCatchActivityInfo;
			if (dropCatchActivityInfo == null)
			{
				return;
			}
			this.PreferredOpenLevelId = 0;
			this.OnLevelRewardUpdateNotify(dropCatchActivityInfo.DropCatchLevelInfos);
		}

		// Token: 0x06042ABA RID: 273082 RVA: 0x0111D40C File Offset: 0x0111B60C
		[NullableContext(2)]
		public DropCatchLevelData GetLevelData(int configId)
		{
			DropCatchLevelData result;
			this.LevelInfoMap.TryGetValue(configId, out result);
			return result;
		}

		// Token: 0x06042ABB RID: 273083 RVA: 0x0111D42C File Offset: 0x0111B62C
		[NullableContext(2)]
		public DropCatchLevelData GetLastLevelData(int configId)
		{
			IReadOnlyList<DropCatchGameplay> dropCatchGameplayByActivityId = ConfigBase<DropCatchConfig>.Instance.GetDropCatchGameplayByActivityId(base.Id);
			if (dropCatchGameplayByActivityId == null)
			{
				return null;
			}
			DropCatchLevelData result = null;
			foreach (DropCatchGameplay dropCatchGameplay in dropCatchGameplayByActivityId)
			{
				if (dropCatchGameplay.NextGameplayId == configId)
				{
					result = this.GetLevelData(dropCatchGameplay.Id);
					break;
				}
			}
			return result;
		}

		// Token: 0x06042ABC RID: 273084 RVA: 0x0111D4A0 File Offset: 0x0111B6A0
		public EDropCatchLevelState? GetLevelStarStatus(int configId, int starIndex)
		{
			if (this.GetLevelData(configId) != null)
			{
				DropCatchLevelData dropCatchLevelData;
				this.LevelInfoMap.TryGetValue(configId, out dropCatchLevelData);
				List<EDropCatchLevelState> list = (dropCatchLevelData != null) ? dropCatchLevelData.RewardStates : null;
				if (list != null && list.Count > starIndex)
				{
					return new EDropCatchLevelState?(list[starIndex]);
				}
			}
			return new EDropCatchLevelState?(EDropCatchLevelState.Lock);
		}

		// Token: 0x06042ABD RID: 273085 RVA: 0x0111D4F4 File Offset: 0x0111B6F4
		public int GetDefaultOpenCfgId()
		{
			IReadOnlyList<DropCatchGameplay> dropCatchGameplayByActivityId = ConfigBase<DropCatchConfig>.Instance.GetDropCatchGameplayByActivityId(base.Id);
			if (dropCatchGameplayByActivityId == null || dropCatchGameplayByActivityId.Count == 0)
			{
				return 0;
			}
			if (this.PreferredOpenLevelId != 0)
			{
				int preferredOpenLevelId = this.PreferredOpenLevelId;
				this.PreferredOpenLevelId = 0;
				return preferredOpenLevelId;
			}
			int count = dropCatchGameplayByActivityId.Count;
			int id = dropCatchGameplayByActivityId[count - 1].Id;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			bool flag = true;
			bool flag2 = true;
			for (int i = 0; i < count; i++)
			{
				int id2 = dropCatchGameplayByActivityId[i].Id;
				DropCatchLevelData levelData = this.GetLevelData(id2);
				if (levelData == null || !levelData.IsUnlock)
				{
					flag = false;
				}
				else
				{
					if (i > 0)
					{
						int id3 = dropCatchGameplayByActivityId[i - 1].Id;
						DropCatchLevelData levelData2 = this.GetLevelData(id3);
						if (levelData2 != null)
						{
							EDropCatchLevelState? targetStarState = levelData2.GetTargetStarState(0);
							EDropCatchLevelState edropCatchLevelState = EDropCatchLevelState.Lock;
							if (targetStarState.GetValueOrDefault() == edropCatchLevelState & targetStarState != null)
							{
								flag = false;
								goto IL_109;
							}
						}
					}
					num3 = id2;
					if (levelData.CanReceiveReward && num == 0)
					{
						num = id2;
					}
					if (!levelData.IsAllStar)
					{
						flag2 = false;
						if (num2 == 0)
						{
							num2 = id2;
						}
					}
				}
				IL_109:;
			}
			if (num != 0)
			{
				return num;
			}
			if (flag)
			{
				if (!flag2 && num2 != 0)
				{
					return num2;
				}
				return id;
			}
			else
			{
				if (num3 != 0)
				{
					return num3;
				}
				return dropCatchGameplayByActivityId[0].Id;
			}
		}

		// Token: 0x06042ABE RID: 273086 RVA: 0x0111D645 File Offset: 0x0111B845
		public void SetPreferredOpenLevel(int levelId)
		{
			this.PreferredOpenLevelId = levelId;
		}

		// Token: 0x06042ABF RID: 273087 RVA: 0x0111D650 File Offset: 0x0111B850
		public bool GetCanReceive()
		{
			foreach (DropCatchLevelData dropCatchLevelData in this.LevelInfoMap.Values)
			{
				if (dropCatchLevelData.RewardStates != null)
				{
					using (List<EDropCatchLevelState>.Enumerator enumerator2 = dropCatchLevelData.RewardStates.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							if (enumerator2.Current == EDropCatchLevelState.Unlock)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06042AC0 RID: 273088 RVA: 0x0111D6F0 File Offset: 0x0111B8F0
		public int GetFinishLevelCount()
		{
			int num = 0;
			using (Dictionary<int, DropCatchLevelData>.ValueCollection.Enumerator enumerator = this.LevelInfoMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsAllRewarded)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06042AC1 RID: 273089 RVA: 0x0111D750 File Offset: 0x0111B950
		public void OnLevelRewardUpdateNotify(IList<DropCatchLevelInfo> levelInfos)
		{
			if (levelInfos == null || levelInfos.Count == 0)
			{
				return;
			}
			foreach (DropCatchLevelInfo info in levelInfos)
			{
				this.UpdateTargetLevelData(info);
			}
		}

		// Token: 0x06042AC2 RID: 273090 RVA: 0x0111D7A4 File Offset: 0x0111B9A4
		public void UpdateTargetLevelData(DropCatchLevelInfo info)
		{
			if (info == null)
			{
				return;
			}
			int dropCatchId = info.DropCatchId;
			DropCatchLevelData dropCatchLevelData;
			if (!this.LevelInfoMap.TryGetValue(dropCatchId, out dropCatchLevelData))
			{
				dropCatchLevelData = new DropCatchLevelData();
			}
			if (dropCatchLevelData != null)
			{
				dropCatchLevelData.ConfigId = dropCatchId;
				dropCatchLevelData.RewardStates = new List<EDropCatchLevelState>();
				foreach (int item in info.RewardStates)
				{
					dropCatchLevelData.RewardStates.Add((EDropCatchLevelState)item);
				}
				dropCatchLevelData.UnlockTime = (double)Singleton<MathUtils>.Instance.LongToNumber(info.UnlockTime);
				dropCatchLevelData.HighestScore = info.Score;
				if (this.LevelInfoMap.ContainsKey(dropCatchId))
				{
					this.LevelInfoMap[dropCatchId] = dropCatchLevelData;
					return;
				}
				this.LevelInfoMap.Add(dropCatchId, dropCatchLevelData);
			}
		}

		// Token: 0x06042AC3 RID: 273091 RVA: 0x0111D87C File Offset: 0x0111BA7C
		public override bool GetExDataRedPointShowState()
		{
			return this.GetCanReceive();
		}

		// Token: 0x06042AC4 RID: 273092 RVA: 0x0111D884 File Offset: 0x0111BA84
		protected override bool GetExDataFinishShowState()
		{
			if (this.LevelInfoMap == null || this.LevelInfoMap.Count == 0)
			{
				return false;
			}
			foreach (KeyValuePair<int, DropCatchLevelData> keyValuePair in this.LevelInfoMap)
			{
				if (!keyValuePair.Value.IsAllRewarded)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06042AC5 RID: 273093 RVA: 0x0111D8FC File Offset: 0x0111BAFC
		public bool CheckLevelCompleted(int levelId)
		{
			DropCatchLevelData levelData = this.GetLevelData(levelId);
			if (levelData == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DropCatch;
				ELogAuthor author = ELogAuthor.CB;
				string message = "找不到对应关卡信息";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("levelId", levelId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			EDropCatchLevelState? targetStarState = levelData.GetTargetStarState(0);
			EDropCatchLevelState edropCatchLevelState = EDropCatchLevelState.Lock;
			return !(targetStarState.GetValueOrDefault() == edropCatchLevelState & targetStarState != null);
		}

		// Token: 0x06042AC6 RID: 273094 RVA: 0x0111D964 File Offset: 0x0111BB64
		[NullableContext(2)]
		public string GetLevelUnlockHintText(int configId)
		{
			DropCatchLevelData levelData = this.GetLevelData(configId);
			if (levelData == null)
			{
				return null;
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			double unlockTime = levelData.UnlockTime;
			if (unlockTime > serverTime)
			{
				CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(unlockTime - serverTime);
				if (remainTimeDataFormat.CountDownText != null)
				{
					string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("CoinCatch_LevelUnlockTimer_1");
					if (multiTextByKey != null)
					{
						return StringUtils.Format(multiTextByKey, new string[]
						{
							remainTimeDataFormat.CountDownText
						});
					}
				}
				return null;
			}
			DropCatchGameplay? dropCatchGameplayById = ConfigBase<DropCatchConfig>.Instance.GetDropCatchGameplayById(configId);
			if (dropCatchGameplayById != null)
			{
				string multiTextByKey2 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("CoinCatch_UnlockLevelCondition_1");
				if (multiTextByKey2 != null)
				{
					return StringUtils.Format(multiTextByKey2, new string[]
					{
						dropCatchGameplayById.Value.OpenDay.ToString()
					});
				}
			}
			return null;
		}

		// Token: 0x040251D2 RID: 152018
		private readonly Dictionary<int, DropCatchLevelData> LevelInfoMap = new Dictionary<int, DropCatchLevelData>();

		// Token: 0x040251D3 RID: 152019
		private int PreferredOpenLevelId;
	}
}
