using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FarmGold
{
	// Token: 0x02006852 RID: 26706
	[NullableContext(1)]
	[Nullable(0)]
	public class FarmGoldLevelData
	{
		// Token: 0x060428E7 RID: 272615 RVA: 0x01115DFE File Offset: 0x01113FFE
		public int GetInstId()
		{
			return this.InstId;
		}

		// Token: 0x060428E8 RID: 272616 RVA: 0x01115E06 File Offset: 0x01114006
		public int GetStartTime()
		{
			return this.StartTime;
		}

		// Token: 0x060428E9 RID: 272617 RVA: 0x01115E10 File Offset: 0x01114010
		public bool GetIsOpen()
		{
			int preLevel = this.GetConfig().PreLevel;
			bool flag = true;
			if (preLevel > 0)
			{
				FarmGoldData farmGoldData = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as FarmGoldData;
				FarmGoldLevelData farmGoldLevelData = (farmGoldData != null) ? farmGoldData.GetLevelInfoByInstId(preLevel) : null;
				if (farmGoldLevelData != null)
				{
					flag = farmGoldLevelData.GetIfPassLevel();
				}
			}
			return Singleton<TimeUtil>.Instance.GetServerTime() >= (double)this.StartTime && flag;
		}

		// Token: 0x060428EA RID: 272618 RVA: 0x01115E78 File Offset: 0x01114078
		public bool GetIfPassLevel()
		{
			return this.Point >= this.GetConfig().PassScore;
		}

		// Token: 0x060428EB RID: 272619 RVA: 0x01115E9E File Offset: 0x0111409E
		public int GetPoint()
		{
			return this.Point;
		}

		// Token: 0x060428EC RID: 272620 RVA: 0x01115EA6 File Offset: 0x011140A6
		public bool GetHasGetLevelReward()
		{
			return this.HasGetLevelReward;
		}

		// Token: 0x060428ED RID: 272621 RVA: 0x01115EAE File Offset: 0x011140AE
		public FarmGoldActivity GetConfig()
		{
			return ConfigBase<FarmGoldConfig>.Instance.GetFarmGoldConfigByActivityIdAndInstId(this.ActivityId, this.InstId);
		}

		// Token: 0x060428EE RID: 272622 RVA: 0x01115EC8 File Offset: 0x011140C8
		public int GetRecommendLevel()
		{
			return this.GetDifficultConfig().RecommendedLevel;
		}

		// Token: 0x060428EF RID: 272623 RVA: 0x01115EE3 File Offset: 0x011140E3
		public bool GetFinishState()
		{
			return this.GetIfPassLevel();
		}

		// Token: 0x060428F0 RID: 272624 RVA: 0x01115EEB File Offset: 0x011140EB
		public bool GetRedDotState()
		{
			return this.GetNewOpenState();
		}

		// Token: 0x060428F1 RID: 272625 RVA: 0x01115EF4 File Offset: 0x011140F4
		public int GetSelectDifficultIndex()
		{
			if (this.CurrentSelectDifficult != null)
			{
				IReadOnlyList<FarmGoldDifficulty> farmGoldAllDifficult = ConfigBase<FarmGoldConfig>.Instance.GetFarmGoldAllDifficult();
				for (int i = 0; i < farmGoldAllDifficult.Count; i++)
				{
					if (farmGoldAllDifficult[i].Id == this.CurrentSelectDifficult.Value)
					{
						return i;
					}
				}
				return 0;
			}
			if (this.Index > 0)
			{
				FarmGoldData farmGoldData = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as FarmGoldData;
				FarmGoldLevelData farmGoldLevelData = (farmGoldData != null) ? farmGoldData.GetLevelDataByIndex(this.Index - 1) : null;
				if (farmGoldLevelData != null)
				{
					return farmGoldLevelData.GetSelectDifficultIndex();
				}
			}
			return 0;
		}

		// Token: 0x060428F2 RID: 272626 RVA: 0x01115F88 File Offset: 0x01114188
		public void SaveDifficultyState()
		{
			ModelBase<ActivityModel>.Instance.SaveActivityData(this.ActivityId, this.ActivityId, 101, this.InstId, this.CurrentSelectDifficult.GetValueOrDefault(1));
		}

		// Token: 0x060428F3 RID: 272627 RVA: 0x01115FB4 File Offset: 0x011141B4
		private void LoadDifficultyState()
		{
			int activityCacheData = ModelBase<ActivityModel>.Instance.GetActivityCacheData(this.ActivityId, 0, this.ActivityId, 101, this.InstId);
			if (activityCacheData != 0)
			{
				this.CurrentSelectDifficult = new int?(activityCacheData);
			}
		}

		// Token: 0x060428F4 RID: 272628 RVA: 0x01115FF0 File Offset: 0x011141F0
		public string GetInstanceBg()
		{
			return this.GetInstanceConfig().BannerPath;
		}

		// Token: 0x1700A193 RID: 41363
		// (get) Token: 0x060428F5 RID: 272629 RVA: 0x0111600B File Offset: 0x0111420B
		public bool HasSelectDifficult
		{
			get
			{
				return this.CurrentSelectDifficult != null;
			}
		}

		// Token: 0x060428F6 RID: 272630 RVA: 0x01116018 File Offset: 0x01114218
		public int GetSelectDifficult()
		{
			if (this.CurrentSelectDifficult != null)
			{
				return this.CurrentSelectDifficult.Value;
			}
			if (this.Index > 0)
			{
				FarmGoldData farmGoldData = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as FarmGoldData;
				FarmGoldLevelData farmGoldLevelData = (farmGoldData != null) ? farmGoldData.GetLevelDataByIndex(this.Index - 1) : null;
				if (farmGoldLevelData != null)
				{
					return farmGoldLevelData.GetSelectDifficult();
				}
			}
			return 1;
		}

		// Token: 0x060428F7 RID: 272631 RVA: 0x0111607C File Offset: 0x0111427C
		public FarmGoldDifficulty GetDifficultConfig()
		{
			return ConfigBase<FarmGoldConfig>.Instance.GetFarmGoldDifficultById(this.GetSelectDifficult());
		}

		// Token: 0x060428F8 RID: 272632 RVA: 0x0111608E File Offset: 0x0111428E
		public void SetDifficult(int difficult)
		{
			this.CurrentSelectDifficult = new int?(difficult);
			this.SaveDifficultyState();
		}

		// Token: 0x060428F9 RID: 272633 RVA: 0x011160A2 File Offset: 0x011142A2
		public bool GetNewOpenState()
		{
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(this.ActivityId, 0, this.ActivityId, 100, this.InstId) == 0 && this.GetIsOpen();
		}

		// Token: 0x060428FA RID: 272634 RVA: 0x011160D0 File Offset: 0x011142D0
		public string GetUnlockTimeText()
		{
			if (Singleton<TimeUtil>.Instance.GetServerTime() < (double)this.StartTime)
			{
				CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3((double)this.StartTime - Singleton<TimeUtil>.Instance.GetServerTime());
				return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("FarmGoldUnLockTime", null), new string[]
				{
					remainTimeDataFormat.CountDownText
				});
			}
			return ConfigMultiTextLang.GetLocalTextNew("FarmGoldUnlockCondition", null);
		}

		// Token: 0x060428FB RID: 272635 RVA: 0x01116138 File Offset: 0x01114338
		public void SaveOpenState()
		{
			if (this.GetIsOpen())
			{
				ModelBase<ActivityModel>.Instance.SaveActivityData(this.ActivityId, this.ActivityId, 100, this.InstId, 1);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
			}
		}

		// Token: 0x060428FC RID: 272636 RVA: 0x01116178 File Offset: 0x01114378
		public string GetNameText()
		{
			return ConfigMultiTextLang.GetLocalTextNew(this.GetInstanceConfig().MapName, null);
		}

		// Token: 0x060428FD RID: 272637 RVA: 0x0111619C File Offset: 0x0111439C
		public string GetDescText()
		{
			return ConfigMultiTextLang.GetLocalTextNew(this.GetInstanceConfig().DungeonDesc, null);
		}

		// Token: 0x060428FE RID: 272638 RVA: 0x011161BD File Offset: 0x011143BD
		public string GetSubTitleText()
		{
			return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("FarmGoldHighestPoint", null), new string[]
			{
				this.Point.ToString()
			});
		}

		// Token: 0x060428FF RID: 272639 RVA: 0x011161E4 File Offset: 0x011143E4
		public List<int> GetRecommendElement()
		{
			InstanceDungeon instanceConfig = this.GetInstanceConfig();
			List<int> list = new List<int>();
			for (int i = 0; i < instanceConfig.RecommendElementLength; i++)
			{
				list.Add(instanceConfig.RecommendElement(i));
			}
			return list;
		}

		// Token: 0x06042900 RID: 272640 RVA: 0x01116220 File Offset: 0x01114420
		public InstanceDungeon GetInstanceConfig()
		{
			return ConfigInstanceDungeonById.GetConfig(this.InstId, true).Value;
		}

		// Token: 0x06042901 RID: 272641 RVA: 0x01116244 File Offset: 0x01114444
		public int GetInstanceEntranceId()
		{
			return this.GetConfig().EntranceId;
		}

		// Token: 0x06042902 RID: 272642 RVA: 0x0111625F File Offset: 0x0111445F
		public void FinishLevelReward()
		{
			this.HasGetLevelReward = true;
		}

		// Token: 0x06042903 RID: 272643 RVA: 0x01116268 File Offset: 0x01114468
		public string GetMonsterTips()
		{
			return ConfigMultiTextLang.GetLocalTextNew(this.GetInstanceConfig().MonsterTips, null);
		}

		// Token: 0x06042904 RID: 272644 RVA: 0x0111628C File Offset: 0x0111448C
		public bool GetMonsterPreviewState()
		{
			return this.GetInstanceConfig().MonsterPreviewLength > 0;
		}

		// Token: 0x06042905 RID: 272645 RVA: 0x011162AC File Offset: 0x011144AC
		public void Phrase(int activityId, FarmGoldLevelPlayInfo data, int index)
		{
			this.Index = index;
			this.ActivityId = activityId;
			this.InstId = data.InstId;
			this.StartTime = data.StartTime;
			this.IsOpen = data.IsOpen;
			this.Point = data.Point;
			this.HasGetLevelReward = data.LevelRewardGet;
			this.LoadDifficultyState();
		}

		// Token: 0x040250E3 RID: 151779
		private int ActivityId;

		// Token: 0x040250E4 RID: 151780
		private int InstId;

		// Token: 0x040250E5 RID: 151781
		private int StartTime;

		// Token: 0x040250E6 RID: 151782
		protected bool IsOpen;

		// Token: 0x040250E7 RID: 151783
		private int Point;

		// Token: 0x040250E8 RID: 151784
		private bool HasGetLevelReward;

		// Token: 0x040250E9 RID: 151785
		private int? CurrentSelectDifficult;

		// Token: 0x040250EA RID: 151786
		private int Index;
	}
}
