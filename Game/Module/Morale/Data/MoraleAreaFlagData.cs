using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.WorldMap.SubViews.CommonGamePlay;

namespace CSharpScript.Game.Module.Morale.Data
{
	// Token: 0x02005724 RID: 22308
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleAreaFlagData
	{
		// Token: 0x17009123 RID: 37155
		// (get) Token: 0x06038C59 RID: 232537 RVA: 0x00E5FEED File Offset: 0x00E5E0ED
		public bool IsGetBox
		{
			get
			{
				return this.BoxTotalCount > 0 && this.BoxReceivedCount >= this.BoxTotalCount;
			}
		}

		// Token: 0x06038C5A RID: 232538 RVA: 0x00E5FF0B File Offset: 0x00E5E10B
		public static MoraleAreaFlagData Create(FlagArea config)
		{
			MoraleAreaFlagData moraleAreaFlagData = new MoraleAreaFlagData(config);
			moraleAreaFlagData.Init();
			return moraleAreaFlagData;
		}

		// Token: 0x06038C5B RID: 232539 RVA: 0x00E5FF1C File Offset: 0x00E5E11C
		private MoraleAreaFlagData(FlagArea config)
		{
			this.Id = config.Id;
			this.AreaId = config.FlagAreaId;
			this.Config = config;
			this.TypeConfig = ConfigBase<MoraleConfig>.Instance.GetFlagTypeConfig(config.FlagType);
			this.HasBox = (config.BoxRewardId > 0);
			this.BoxTotalCount = config.TreasureBoxEntitysLength;
		}

		// Token: 0x06038C5C RID: 232540 RVA: 0x00E5FF9A File Offset: 0x00E5E19A
		private void Init()
		{
			this.InitPlotData();
		}

		// Token: 0x06038C5D RID: 232541 RVA: 0x00E5FFA4 File Offset: 0x00E5E1A4
		private void InitPlotData()
		{
			if (this.TypeConfig == null || this.TypeConfig.Value.ShowUiMap == 0)
			{
				return;
			}
			int[] flagPlotListArray = this.Config.GetFlagPlotListArray();
			if (flagPlotListArray == null)
			{
				return;
			}
			foreach (int num in flagPlotListArray)
			{
				MoraleAreaPlotData moraleAreaPlotData = new MoraleAreaPlotData
				{
					Id = num,
					FlagId = this.Id,
					AreaId = this.AreaId
				};
				this.AreaPlotDataMap[num] = moraleAreaPlotData;
				this.AreaPlotDataList.Add(moraleAreaPlotData);
			}
		}

		// Token: 0x06038C5E RID: 232542 RVA: 0x00E60037 File Offset: 0x00E5E237
		public void SetActiveState(bool isActive)
		{
			this.IsActive = isActive;
		}

		// Token: 0x06038C5F RID: 232543 RVA: 0x00E60040 File Offset: 0x00E5E240
		public void SetBoxReceivedCount(int count)
		{
			this.BoxReceivedCount = count;
		}

		// Token: 0x06038C60 RID: 232544 RVA: 0x00E60049 File Offset: 0x00E5E249
		public bool HasBoxCanGet()
		{
			return this.HasBox && this.IsActive && !this.IsGetBox && this.BoxTotalCount > 0;
		}

		// Token: 0x06038C61 RID: 232545 RVA: 0x00E60072 File Offset: 0x00E5E272
		public void SetSelectState(bool isSelect)
		{
			this.IsSelect = isSelect;
		}

		// Token: 0x06038C62 RID: 232546 RVA: 0x00E6007C File Offset: 0x00E5E27C
		public bool IsFlagType(EMoraleFlagType flagType)
		{
			return this.TypeConfig != null && this.TypeConfig.Value.TypeId == (int)flagType;
		}

		// Token: 0x06038C63 RID: 232547 RVA: 0x00E600AE File Offset: 0x00E5E2AE
		public bool IsHighDifficultyChallenge()
		{
			return this.IsFlagType(EMoraleFlagType.HighDifficulty);
		}

		// Token: 0x06038C64 RID: 232548 RVA: 0x00E600B8 File Offset: 0x00E5E2B8
		public IMapMoraleLvItemData GetMapMoraleLvItemData()
		{
			int maxMonsterLv = this.Config.MaxMonsterLv;
			EMoraleLevelDiffType moraleLevelDiffType = ModelBase<MoraleBattleModel>.Instance.GetMoraleLevelDiffType(maxMonsterLv, null);
			string lvColor = "";
			string bgColor = "";
			switch (moraleLevelDiffType)
			{
			case EMoraleLevelDiffType.Easy:
				lvColor = "#494A4AFF";
				bgColor = "#A1A0A0FF";
				break;
			case EMoraleLevelDiffType.Normal:
				lvColor = "#5C4421FF";
				bgColor = "#B09A58FF";
				break;
			case EMoraleLevelDiffType.Hard:
				lvColor = "#6A3838FF";
				bgColor = "#C38484FF";
				break;
			}
			return new MapMoraleLvItemData
			{
				TitleId = "Morale_title_13",
				Lv = maxMonsterLv,
				LvColor = lvColor,
				BgColor = bgColor
			};
		}

		// Token: 0x06038C65 RID: 232549 RVA: 0x00E60154 File Offset: 0x00E5E354
		public bool IsLowMoraleLv()
		{
			if (ModelBase<MoraleModel>.Instance.IsRichTargetMoraleLv(this.Config.MaxMonsterLv))
			{
				return false;
			}
			int moraleMaxLevel = ModelBase<MoraleBattleModel>.Instance.GetMoraleMaxLevel();
			return ModelBase<MoraleModel>.Instance.GetSumMoraleLv() < moraleMaxLevel;
		}

		// Token: 0x06038C66 RID: 232550 RVA: 0x00E60192 File Offset: 0x00E5E392
		public void SetNewUnlockState(bool isNewUnlock)
		{
			this.IsNewUnlock = isNewUnlock;
		}

		// Token: 0x0402056C RID: 132460
		public int Id;

		// Token: 0x0402056D RID: 132461
		public int AreaId;

		// Token: 0x0402056E RID: 132462
		public List<MoraleAreaPlotData> AreaPlotDataList = new List<MoraleAreaPlotData>();

		// Token: 0x0402056F RID: 132463
		public Dictionary<int, MoraleAreaPlotData> AreaPlotDataMap = new Dictionary<int, MoraleAreaPlotData>();

		// Token: 0x04020570 RID: 132464
		public bool IsActive;

		// Token: 0x04020571 RID: 132465
		public bool HasBox;

		// Token: 0x04020572 RID: 132466
		public int BoxReceivedCount;

		// Token: 0x04020573 RID: 132467
		public int BoxTotalCount;

		// Token: 0x04020574 RID: 132468
		public FlagArea Config;

		// Token: 0x04020575 RID: 132469
		public MoraleFlagType? TypeConfig;

		// Token: 0x04020576 RID: 132470
		public bool IsSelect;

		// Token: 0x04020577 RID: 132471
		public bool IsNewUnlock;
	}
}
