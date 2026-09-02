using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.FlagChallenge;
using CSharpScript.Game.Module.TrainingDegree;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F18 RID: 24344
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class FlagChallengeBattleModel : ModelBase<FlagChallengeBattleModel>
	{
		// Token: 0x0603D227 RID: 250407 RVA: 0x00F88AA5 File Offset: 0x00F86CA5
		protected override bool OnInit()
		{
			this.ResetLevelInfo();
			return true;
		}

		// Token: 0x17009A2A RID: 39466
		// (get) Token: 0x0603D228 RID: 250408 RVA: 0x00F88AAE File Offset: 0x00F86CAE
		public int ActivityId
		{
			get
			{
				return this.ActivityIdIntl;
			}
		}

		// Token: 0x17009A2B RID: 39467
		// (get) Token: 0x0603D229 RID: 250409 RVA: 0x00F88AB6 File Offset: 0x00F86CB6
		public int LevelId
		{
			get
			{
				return this.LevelIdIntl;
			}
		}

		// Token: 0x17009A2C RID: 39468
		// (get) Token: 0x0603D22A RID: 250410 RVA: 0x00F88ABE File Offset: 0x00F86CBE
		public int InstanceId
		{
			get
			{
				return this.InstanceIdIntl;
			}
		}

		// Token: 0x17009A2D RID: 39469
		// (get) Token: 0x0603D22B RID: 250411 RVA: 0x00F88AC6 File Offset: 0x00F86CC6
		public bool IsInFlagChallengeDungeon
		{
			get
			{
				return this.InstanceIdIntl > 0;
			}
		}

		// Token: 0x17009A2E RID: 39470
		// (get) Token: 0x0603D22C RID: 250412 RVA: 0x00F88AD1 File Offset: 0x00F86CD1
		// (set) Token: 0x0603D22D RID: 250413 RVA: 0x00F88AD9 File Offset: 0x00F86CD9
		public int StrongholdId
		{
			get
			{
				return this.StrongholdIdIntl;
			}
			set
			{
				this.StrongholdIdIntl = value;
			}
		}

		// Token: 0x17009A2F RID: 39471
		// (get) Token: 0x0603D22E RID: 250414 RVA: 0x00F88AE2 File Offset: 0x00F86CE2
		// (set) Token: 0x0603D22F RID: 250415 RVA: 0x00F88AEA File Offset: 0x00F86CEA
		public int AreaId
		{
			get
			{
				return this.AreaIdIntl;
			}
			set
			{
				this.AreaIdIntl = value;
			}
		}

		// Token: 0x17009A30 RID: 39472
		// (get) Token: 0x0603D230 RID: 250416 RVA: 0x00F88AF3 File Offset: 0x00F86CF3
		// (set) Token: 0x0603D231 RID: 250417 RVA: 0x00F88AFB File Offset: 0x00F86CFB
		public bool IsNeedShowMainView
		{
			get
			{
				return this.IsNeedShowMainViewIntl;
			}
			set
			{
				this.IsNeedShowMainViewIntl = value;
			}
		}

		// Token: 0x17009A31 RID: 39473
		// (get) Token: 0x0603D232 RID: 250418 RVA: 0x00F88B04 File Offset: 0x00F86D04
		public FlagChallengeSettleInfo SettleInfo
		{
			get
			{
				return this.SettleInfoIntl;
			}
		}

		// Token: 0x0603D233 RID: 250419 RVA: 0x00F88B0C File Offset: 0x00F86D0C
		public void HandleInstNotify(FlagChallengeInstNotify notify)
		{
			int challengeLevelId = notify.ChallengeLevelId;
			FlagChallengeLevel? levelConfig = ConfigBase<FlagChallengeConfig>.Instance.GetLevelConfig(challengeLevelId);
			this.LevelIdIntl = challengeLevelId;
			this.ActivityIdIntl = levelConfig.Value.ActivityId;
			this.InstanceIdIntl = levelConfig.Value.InstId;
			Aki.Protocol.FlagChallengeRoleLevelInfo flagChallengePerRoleLevelInfo = notify.FlagChallengePerRoleLevelInfo;
			if (flagChallengePerRoleLevelInfo != null)
			{
				this.FixedLevelInfo.Level = flagChallengePerRoleLevelInfo.PerLevel;
				this.FixedLevelInfo.Exp = flagChallengePerRoleLevelInfo.PerExp;
				this.CacheLevelInfo.Level = flagChallengePerRoleLevelInfo.PerLevel;
				this.CacheLevelInfo.Exp = flagChallengePerRoleLevelInfo.PerExp;
			}
			Aki.Protocol.FlagChallengeRoleLevelInfo flagChallengeTempRoleLevelInfo = notify.FlagChallengeTempRoleLevelInfo;
			if (flagChallengeTempRoleLevelInfo != null)
			{
				this.TempLevelInfo.Level = flagChallengeTempRoleLevelInfo.PerLevel;
				this.TempLevelInfo.Exp = flagChallengeTempRoleLevelInfo.PerExp;
			}
			this.BoxExp = notify.BoxExp;
			this.UpdateCalculatedLevelInfo();
			this.UpdatePreCalculatedLevelInfo(this.GetCalculatedLevel(), this.GetCalculatedLevelExp());
			this.UpdatePreFixedLevelInfo(this.GetFixedLevel(), this.GetFixedLevelExp());
			this.UpdatePreTempLevelData(this.GetTempLevel(), this.GetTempLevelExp());
			this.OnEnterInstance();
		}

		// Token: 0x0603D234 RID: 250420 RVA: 0x00F88C27 File Offset: 0x00F86E27
		public void OnEnterInstance()
		{
			this.SetFlagChallengeBattleActive(true);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnFlagChallengeDungeonActiveChanged, true);
		}

		// Token: 0x0603D235 RID: 250421 RVA: 0x00F88C41 File Offset: 0x00F86E41
		public void HandleSettleNotify(int levelId)
		{
			this.SettleInfoIntl = new FlagChallengeSettleInfo
			{
				Level = this.GetFixedLevel(),
				CacheLevel = this.GetCacheLevel(),
				BoxLevel = this.GetBoxLevel()
			};
			this.UpdateRoleTempLevelData(0, 0);
			this.UpdateBoxExp(0);
		}

		// Token: 0x0603D236 RID: 250422 RVA: 0x00F88C81 File Offset: 0x00F86E81
		public void OnLeaveInstance()
		{
			this.BoxExp = 0;
			this.TempLevelExpRangeCache.Clear();
			this.TempExpConfigListInternal = null;
			this.LevelIdIntl = 0;
			this.ActivityIdIntl = 0;
			this.InstanceIdIntl = 0;
			this.SetFlagChallengeBattleActive(false);
		}

		// Token: 0x0603D237 RID: 250423 RVA: 0x00F88CB8 File Offset: 0x00F86EB8
		public bool IsFlagChallengeBattleActive()
		{
			return this.IsFlagChallengeBattleActiveIntl;
		}

		// Token: 0x0603D238 RID: 250424 RVA: 0x00F88CC0 File Offset: 0x00F86EC0
		public void SetFlagChallengeBattleActive(bool active)
		{
			if (active == this.IsFlagChallengeBattleActiveIntl)
			{
				return;
			}
			this.IsFlagChallengeBattleActiveIntl = active;
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnFlagChallengeDungeonActiveChanged, active);
		}

		// Token: 0x0603D239 RID: 250425 RVA: 0x00F88CE4 File Offset: 0x00F86EE4
		public int GetTempFlagChallengeMaxLevel()
		{
			IReadOnlyList<BattleScoreLevelConf> tempExpConfigList = this.GetTempExpConfigList();
			if (tempExpConfigList != null)
			{
				return tempExpConfigList.Count;
			}
			return 1;
		}

		// Token: 0x0603D23A RID: 250426 RVA: 0x00F88D04 File Offset: 0x00F86F04
		[NullableContext(2)]
		private IReadOnlyList<BattleScoreLevelConf> GetTempExpConfigList()
		{
			if (this.TempExpConfigListInternal == null)
			{
				FlagChallengeActivity? activityConfig = ConfigBase<FlagChallengeConfig>.Instance.GetActivityConfig(this.ActivityId);
				int id = (activityConfig != null) ? activityConfig.GetValueOrDefault().BattleScoreId : 0;
				BattleScoreConf? battleScoreConfig = ConfigBase<BattleScoreConfig>.Instance.GetBattleScoreConfig(id);
				if (battleScoreConfig != null)
				{
					BattleScoreConf valueOrDefault = battleScoreConfig.GetValueOrDefault();
					this.TempExpConfigListInternal = ConfigBase<BattleScoreConfig>.Instance.GetBattleScoreActionConfigByGroupId(valueOrDefault.LevelGroupId);
				}
			}
			return this.TempExpConfigListInternal;
		}

		// Token: 0x0603D23B RID: 250427 RVA: 0x00F88D84 File Offset: 0x00F86F84
		private void ResetLevelInfo()
		{
			this.CacheLevelInfo = new CSharpScript.Game.Module.FlagChallenge.FlagChallengeRoleLevelInfo
			{
				Level = 0,
				Exp = 0
			};
			this.FixedLevelInfo = new CSharpScript.Game.Module.FlagChallenge.FlagChallengeRoleLevelInfo
			{
				Level = 0,
				Exp = 0
			};
			this.TempLevelInfo = new CSharpScript.Game.Module.FlagChallenge.FlagChallengeRoleLevelInfo
			{
				Level = 0,
				Exp = 0
			};
			this.CalculatedLevelInfo = new CSharpScript.Game.Module.FlagChallenge.FlagChallengeRoleLevelInfo
			{
				Level = 0,
				Exp = 0
			};
			this.PreCalculatedLevelInfo = new CSharpScript.Game.Module.FlagChallenge.FlagChallengeRoleLevelInfo
			{
				Level = 0,
				Exp = 0
			};
			this.PreFixedLevelInfo = new CSharpScript.Game.Module.FlagChallenge.FlagChallengeRoleLevelInfo
			{
				Level = 0,
				Exp = 0
			};
			this.PreTempLevelInfo = new CSharpScript.Game.Module.FlagChallenge.FlagChallengeRoleLevelInfo
			{
				Level = 0,
				Exp = 0
			};
			this.BoxExp = 0;
		}

		// Token: 0x0603D23C RID: 250428 RVA: 0x00F88E48 File Offset: 0x00F87048
		public IReadOnlyList<TrainingData> GetTrainingDataList()
		{
			TrainingData trainingData = new TrainingData();
			TrainingData trainingData2 = new TrainingData();
			trainingData.Icon = "SP_IconDeathKillEnemy";
			trainingData.NameId = "Morale_32_Fail_ElimatePath";
			trainingData2.Icon = "SP_IconDeathCapturePoint";
			trainingData2.NameId = "Morale_32_Fail_OccupyPath";
			return new <>z__ReadOnlyArray<TrainingData>(new TrainingData[]
			{
				trainingData2,
				trainingData
			});
		}

		// Token: 0x0603D23D RID: 250429 RVA: 0x00F88EA0 File Offset: 0x00F870A0
		public void UpdateRoleLevelData(int level, int exp)
		{
			this.UpdatePreFixedLevelInfo(this.GetFixedLevel(), this.GetFixedLevelExp());
			this.FixedLevelInfo.Level = level;
			this.FixedLevelInfo.Exp = exp;
			this.UpdateCalculatedLevelInfo();
			int preCalculatedLevelExp = this.GetPreCalculatedLevelExp();
			int calculatedLevelExp = this.GetCalculatedLevelExp();
			int preCalculatedLevel = this.GetPreCalculatedLevel();
			int calculatedLevel = this.GetCalculatedLevel();
			if (preCalculatedLevelExp != calculatedLevelExp || preCalculatedLevel != calculatedLevel)
			{
				Singleton<EventSystem>.Instance.Emit<int, int, int, int>(EEventName.OnFlagChallengeExpChanged, preCalculatedLevelExp, calculatedLevelExp, preCalculatedLevel, calculatedLevel);
			}
			this.CheckIsTotalLevelChanged();
		}

		// Token: 0x0603D23E RID: 250430 RVA: 0x00F88F1C File Offset: 0x00F8711C
		public void UpdateRoleTempLevelData(int level, int exp)
		{
			this.UpdatePreTempLevelData(this.GetTempLevel(), this.GetTempLevelExp());
			this.TempLevelInfo.Level = level;
			this.TempLevelInfo.Exp = exp;
			int preTempLevelExp = this.GetPreTempLevelExp();
			int tempLevelExp = this.GetTempLevelExp();
			if (preTempLevelExp != tempLevelExp)
			{
				Singleton<EventSystem>.Instance.Emit<int, int, int, int>(EEventName.OnFlagChallengeTempExpChanged, preTempLevelExp, tempLevelExp, this.GetPreTempLevel(), this.GetTempLevel());
			}
			this.CheckIsTotalLevelChanged();
		}

		// Token: 0x0603D23F RID: 250431 RVA: 0x00F88F8C File Offset: 0x00F8718C
		public void UpdateBoxExp(int exp)
		{
			this.BoxExp = exp;
			this.UpdateCalculatedLevelInfo();
			int preCalculatedLevelExp = this.GetPreCalculatedLevelExp();
			int calculatedLevelExp = this.GetCalculatedLevelExp();
			int preCalculatedLevel = this.GetPreCalculatedLevel();
			int calculatedLevel = this.GetCalculatedLevel();
			if (preCalculatedLevelExp != calculatedLevelExp || preCalculatedLevel != calculatedLevel)
			{
				Singleton<EventSystem>.Instance.Emit<int, int, int, int>(EEventName.OnFlagChallengeExpChanged, preCalculatedLevelExp, calculatedLevelExp, preCalculatedLevel, calculatedLevel);
			}
			this.CheckIsTotalLevelChanged();
		}

		// Token: 0x0603D240 RID: 250432 RVA: 0x00F88FE4 File Offset: 0x00F871E4
		private void CheckIsTotalLevelChanged()
		{
			int preTotalLevel = this.GetPreTotalLevel();
			int totalLevel = this.GetTotalLevel();
			if (preTotalLevel != totalLevel)
			{
				Singleton<EventSystem>.Instance.Emit<int, int, int, int>(EEventName.OnFlagChallengeTotalLevelChanged, this.GetPreCalculatedLevel(), this.GetCalculatedLevel(), this.GetPreTempLevel(), this.GetTempLevel());
			}
		}

		// Token: 0x0603D241 RID: 250433 RVA: 0x00F89029 File Offset: 0x00F87229
		private void UpdatePreCalculatedLevelInfo(int level, int exp)
		{
			this.PreCalculatedLevelInfo.Level = level;
			this.PreCalculatedLevelInfo.Exp = exp;
		}

		// Token: 0x0603D242 RID: 250434 RVA: 0x00F89043 File Offset: 0x00F87243
		private void UpdatePreFixedLevelInfo(int level, int exp)
		{
			this.PreFixedLevelInfo.Level = level;
			this.PreFixedLevelInfo.Exp = exp;
		}

		// Token: 0x0603D243 RID: 250435 RVA: 0x00F8905D File Offset: 0x00F8725D
		private void UpdatePreTempLevelData(int level, int exp)
		{
			this.PreTempLevelInfo.Level = level;
			this.PreTempLevelInfo.Exp = exp;
		}

		// Token: 0x0603D244 RID: 250436 RVA: 0x00F89077 File Offset: 0x00F87277
		public int GetFixedLevel()
		{
			return this.FixedLevelInfo.Level;
		}

		// Token: 0x0603D245 RID: 250437 RVA: 0x00F89084 File Offset: 0x00F87284
		public int GetFixedLevelExp()
		{
			return this.FixedLevelInfo.Exp;
		}

		// Token: 0x0603D246 RID: 250438 RVA: 0x00F89091 File Offset: 0x00F87291
		public int GetTempLevel()
		{
			return this.TempLevelInfo.Level;
		}

		// Token: 0x0603D247 RID: 250439 RVA: 0x00F8909E File Offset: 0x00F8729E
		public int GetTempLevelExp()
		{
			return this.TempLevelInfo.Exp;
		}

		// Token: 0x0603D248 RID: 250440 RVA: 0x00F890AB File Offset: 0x00F872AB
		public int GetBoxLevel()
		{
			return this.GetCalculatedLevel() - this.GetFixedLevel();
		}

		// Token: 0x0603D249 RID: 250441 RVA: 0x00F890BA File Offset: 0x00F872BA
		public int GetBoxExp()
		{
			return this.BoxExp;
		}

		// Token: 0x0603D24A RID: 250442 RVA: 0x00F890C2 File Offset: 0x00F872C2
		public int GetCalculatedLevel()
		{
			return this.CalculatedLevelInfo.Level;
		}

		// Token: 0x0603D24B RID: 250443 RVA: 0x00F890CF File Offset: 0x00F872CF
		public int GetCalculatedLevelExp()
		{
			return this.CalculatedLevelInfo.Exp;
		}

		// Token: 0x0603D24C RID: 250444 RVA: 0x00F890DC File Offset: 0x00F872DC
		public int GetPreCalculatedLevel()
		{
			return this.PreCalculatedLevelInfo.Level;
		}

		// Token: 0x0603D24D RID: 250445 RVA: 0x00F890E9 File Offset: 0x00F872E9
		public int GetPreCalculatedLevelExp()
		{
			return this.PreCalculatedLevelInfo.Exp;
		}

		// Token: 0x0603D24E RID: 250446 RVA: 0x00F890F8 File Offset: 0x00F872F8
		private void UpdateCalculatedLevelInfo()
		{
			this.UpdatePreCalculatedLevelInfo(this.GetCalculatedLevel(), this.GetCalculatedLevelExp());
			int i = this.GetFixedLevel();
			int num = this.GetFixedLevelExp() + this.GetBoxExp();
			int maxLevel = ModelBase<FlagChallengeModel>.Instance.GetMaxLevel(this.ActivityId);
			while (i < maxLevel)
			{
				int levelExp = ModelBase<FlagChallengeModel>.Instance.GetLevelExp(this.ActivityId, i + 1);
				if (num < levelExp)
				{
					break;
				}
				i++;
			}
			this.CalculatedLevelInfo.Level = i;
			this.CalculatedLevelInfo.Exp = num;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnFlagChallengeCalculatedLevelUpdate, this.GetCalculatedLevel());
		}

		// Token: 0x0603D24F RID: 250447 RVA: 0x00F8918D File Offset: 0x00F8738D
		public int GetTotalLevel()
		{
			return this.GetCalculatedLevel() + this.GetTempLevel();
		}

		// Token: 0x0603D250 RID: 250448 RVA: 0x00F8919C File Offset: 0x00F8739C
		public int GetTotalLevelExp()
		{
			return this.GetCalculatedLevelExp();
		}

		// Token: 0x0603D251 RID: 250449 RVA: 0x00F891A4 File Offset: 0x00F873A4
		public int GetPreFixedLevel()
		{
			return this.PreFixedLevelInfo.Level;
		}

		// Token: 0x0603D252 RID: 250450 RVA: 0x00F891B1 File Offset: 0x00F873B1
		public int GetPreFixedLevelExp()
		{
			return this.PreFixedLevelInfo.Exp;
		}

		// Token: 0x0603D253 RID: 250451 RVA: 0x00F891BE File Offset: 0x00F873BE
		public int GetPreTempLevel()
		{
			return this.PreTempLevelInfo.Level;
		}

		// Token: 0x0603D254 RID: 250452 RVA: 0x00F891CB File Offset: 0x00F873CB
		public int GetPreTempLevelExp()
		{
			return this.PreTempLevelInfo.Exp;
		}

		// Token: 0x0603D255 RID: 250453 RVA: 0x00F891D8 File Offset: 0x00F873D8
		public int GetPreTotalLevel()
		{
			return this.GetPreCalculatedLevel() + this.GetPreTempLevel();
		}

		// Token: 0x0603D256 RID: 250454 RVA: 0x00F891E7 File Offset: 0x00F873E7
		public int GetPreTotalLevelExp()
		{
			return this.GetPreCalculatedLevelExp();
		}

		// Token: 0x0603D257 RID: 250455 RVA: 0x00F891EF File Offset: 0x00F873EF
		public int GetCacheLevel()
		{
			return this.CacheLevelInfo.Level;
		}

		// Token: 0x0603D258 RID: 250456 RVA: 0x00F891FC File Offset: 0x00F873FC
		public int GetCacheLevelExp()
		{
			return this.CacheLevelInfo.Exp;
		}

		// Token: 0x0603D259 RID: 250457 RVA: 0x00F8920C File Offset: 0x00F8740C
		public int GetTempLevelUpExp(int? targetLevel = null)
		{
			int level = targetLevel ?? this.GetTempLevel();
			ValueTuple<int, int> tempLevelExpRange = this.GetTempLevelExpRange(level);
			return Math.Max(0, tempLevelExpRange.Item2 - tempLevelExpRange.Item1);
		}

		// Token: 0x0603D25A RID: 250458 RVA: 0x00F89250 File Offset: 0x00F87450
		public float GetTempExpProgress()
		{
			ValueTuple<int, int> tempLevelExpRange = this.GetTempLevelExpRange(this.GetTempLevel());
			int num = Math.Max(0, this.GetTempLevelExp() - tempLevelExpRange.Item1);
			int tempLevelUpExp = this.GetTempLevelUpExp(null);
			if (tempLevelUpExp != 0)
			{
				return Math.Min(1f, (float)num / (float)tempLevelUpExp);
			}
			return 0f;
		}

		// Token: 0x0603D25B RID: 250459 RVA: 0x00F892A8 File Offset: 0x00F874A8
		[NullableContext(0)]
		public ValueTuple<int, int> GetTempLevelExpRange(int level)
		{
			ValueTuple<int, int> result;
			if (this.TempLevelExpRangeCache.TryGetValue(level, out result))
			{
				return result;
			}
			foreach (BattleScoreLevelConf battleScoreLevelConf in this.GetTempExpConfigList())
			{
				if (battleScoreLevelConf.Level == level || (battleScoreLevelConf.Level == 1 && level == 0))
				{
					ValueTuple<int, int> valueTuple = new ValueTuple<int, int>(battleScoreLevelConf.LowerUpperLimits(0), battleScoreLevelConf.LowerUpperLimits(1));
					if (level == 0)
					{
						valueTuple.Item1 = 0;
						valueTuple.Item2 = battleScoreLevelConf.LowerUpperLimits(0);
					}
					this.TempLevelExpRangeCache[level] = valueTuple;
					return valueTuple;
				}
			}
			return new ValueTuple<int, int>(0, 0);
		}

		// Token: 0x0603D25C RID: 250460 RVA: 0x00F89364 File Offset: 0x00F87564
		public unsafe IBattleUiHoverTipsC GetInTheBattleBuffInfo()
		{
			BattleUiHoverTipsC battleUiHoverTipsC = new BattleUiHoverTipsC();
			battleUiHoverTipsC.TitleKey = "Morale_title_15";
			int num = 1;
			List<IBattleUiHoverTipsDescInfoC> list = new List<IBattleUiHoverTipsDescInfoC>(num);
			CollectionsMarshal.SetCount<IBattleUiHoverTipsDescInfoC>(list, num);
			Span<IBattleUiHoverTipsDescInfoC> span = CollectionsMarshal.AsSpan<IBattleUiHoverTipsDescInfoC>(list);
			int index = 0;
			*span[index] = new BattleUiHoverTipsDescInfoC
			{
				DescKey = "Morale_title_23"
			};
			battleUiHoverTipsC.DescInfoList = list;
			return battleUiHoverTipsC;
		}

		// Token: 0x04022482 RID: 140418
		private int ActivityIdIntl;

		// Token: 0x04022483 RID: 140419
		private int LevelIdIntl;

		// Token: 0x04022484 RID: 140420
		private int InstanceIdIntl;

		// Token: 0x04022485 RID: 140421
		private int AreaIdIntl;

		// Token: 0x04022486 RID: 140422
		private int StrongholdIdIntl;

		// Token: 0x04022487 RID: 140423
		private bool IsNeedShowMainViewIntl;

		// Token: 0x04022488 RID: 140424
		private FlagChallengeSettleInfo SettleInfoIntl;

		// Token: 0x04022489 RID: 140425
		private CSharpScript.Game.Module.FlagChallenge.FlagChallengeRoleLevelInfo CacheLevelInfo;

		// Token: 0x0402248A RID: 140426
		private CSharpScript.Game.Module.FlagChallenge.FlagChallengeRoleLevelInfo FixedLevelInfo;

		// Token: 0x0402248B RID: 140427
		private CSharpScript.Game.Module.FlagChallenge.FlagChallengeRoleLevelInfo TempLevelInfo;

		// Token: 0x0402248C RID: 140428
		private int BoxExp;

		// Token: 0x0402248D RID: 140429
		private CSharpScript.Game.Module.FlagChallenge.FlagChallengeRoleLevelInfo CalculatedLevelInfo;

		// Token: 0x0402248E RID: 140430
		private CSharpScript.Game.Module.FlagChallenge.FlagChallengeRoleLevelInfo PreCalculatedLevelInfo;

		// Token: 0x0402248F RID: 140431
		private CSharpScript.Game.Module.FlagChallenge.FlagChallengeRoleLevelInfo PreFixedLevelInfo;

		// Token: 0x04022490 RID: 140432
		private CSharpScript.Game.Module.FlagChallenge.FlagChallengeRoleLevelInfo PreTempLevelInfo;

		// Token: 0x04022491 RID: 140433
		[Nullable(new byte[]
		{
			1,
			0
		})]
		private readonly Dictionary<int, ValueTuple<int, int>> TempLevelExpRangeCache = new Dictionary<int, ValueTuple<int, int>>();

		// Token: 0x04022492 RID: 140434
		private bool IsFlagChallengeBattleActiveIntl;

		// Token: 0x04022493 RID: 140435
		[Nullable(2)]
		private IReadOnlyList<BattleScoreLevelConf> TempExpConfigListInternal;
	}
}
