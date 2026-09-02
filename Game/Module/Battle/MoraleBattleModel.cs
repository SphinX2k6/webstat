using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F34 RID: 24372
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class MoraleBattleModel : ModelBase<MoraleBattleModel>
	{
		// Token: 0x0603D38B RID: 250763 RVA: 0x00F9154A File Offset: 0x00F8F74A
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x0603D38C RID: 250764 RVA: 0x00F9154D File Offset: 0x00F8F74D
		protected override bool OnLeaveLevel()
		{
			this.ExpConfigListInternal = null;
			this.TempExpConfigListInternal = null;
			this.LevelExpCache = null;
			this.TempLevelExpRangeCache = null;
			this.IsCheckTempMoraleMaxLevelBuff = false;
			return true;
		}

		// Token: 0x0603D38D RID: 250765 RVA: 0x00F91573 File Offset: 0x00F8F773
		public bool IsMoraleActive()
		{
			return this.IsMoraleActiveInternal;
		}

		// Token: 0x0603D38E RID: 250766 RVA: 0x00F9157B File Offset: 0x00F8F77B
		public void SetMoraleActive(bool active)
		{
			this.IsMoraleActiveInternal = active;
		}

		// Token: 0x0603D38F RID: 250767 RVA: 0x00F91584 File Offset: 0x00F8F784
		public int GetMoraleLevel()
		{
			return this.MoraleLevel;
		}

		// Token: 0x0603D390 RID: 250768 RVA: 0x00F9158C File Offset: 0x00F8F78C
		public int GetMoraleMaxLevel()
		{
			IReadOnlyList<MoraleKeepLevel> expConfigList = this.GetExpConfigList();
			if (expConfigList != null)
			{
				return expConfigList.Count - 1;
			}
			return 1;
		}

		// Token: 0x0603D391 RID: 250769 RVA: 0x00F915AD File Offset: 0x00F8F7AD
		public int GetLastMoraleLevel()
		{
			return this.LastMoraleLevel;
		}

		// Token: 0x0603D392 RID: 250770 RVA: 0x00F915B5 File Offset: 0x00F8F7B5
		public int GetMoraleIndomitableLevel()
		{
			return this.MoraleIndomitableLevel;
		}

		// Token: 0x0603D393 RID: 250771 RVA: 0x00F915BD File Offset: 0x00F8F7BD
		public int GetTempMoraleLevel()
		{
			return this.TempMoraleLevel;
		}

		// Token: 0x0603D394 RID: 250772 RVA: 0x00F915C5 File Offset: 0x00F8F7C5
		public int GetTempMoraleExp()
		{
			return this.TempMoraleExp;
		}

		// Token: 0x0603D395 RID: 250773 RVA: 0x00F915CD File Offset: 0x00F8F7CD
		public int GetExpRatio()
		{
			return this.ExpRatio;
		}

		// Token: 0x0603D396 RID: 250774 RVA: 0x00F915D8 File Offset: 0x00F8F7D8
		public int GetTempMoraleMaxLevel()
		{
			IReadOnlyList<BattleScoreLevelConf> tempExpConfigList = this.GetTempExpConfigList();
			if (tempExpConfigList == null)
			{
				return 1;
			}
			if (!this.IsCheckTempMoraleMaxLevelBuff)
			{
				this.IsCheckTempMoraleMaxLevelBuff = true;
				EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
				WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
				CharacterBuffComponent characterBuffComponent = (worldEntity != null) ? worldEntity.GetComponent<CharacterBuffComponent>() : null;
				if (characterBuffComponent != null && characterBuffComponent.HasBuff(632400018L, false))
				{
					this.IsUnlockTempMoraleMaxLevel = true;
				}
				else
				{
					this.IsUnlockTempMoraleMaxLevel = false;
				}
			}
			if (this.IsUnlockTempMoraleMaxLevel)
			{
				return tempExpConfigList.Count;
			}
			return Math.Max(1, tempExpConfigList.Count - 100);
		}

		// Token: 0x0603D397 RID: 250775 RVA: 0x00F91665 File Offset: 0x00F8F865
		public int GetMoraleMaxExp()
		{
			if (this.MoraleMaxExp == 0)
			{
				this.MoraleMaxExp = this.GetLevelExp(this.GetMoraleMaxLevel());
			}
			return this.MoraleMaxExp;
		}

		// Token: 0x0603D398 RID: 250776 RVA: 0x00F91687 File Offset: 0x00F8F887
		public void SetIsUnlockTempMoraleMaxLevel(bool isUnlock)
		{
			this.IsUnlockTempMoraleMaxLevel = isUnlock;
		}

		// Token: 0x0603D399 RID: 250777 RVA: 0x00F91690 File Offset: 0x00F8F890
		private IReadOnlyList<MoraleKeepLevel> GetExpConfigList()
		{
			if (this.ExpConfigListInternal == null)
			{
				this.ExpConfigListInternal = (ConfigBase<MoraleBattleConfig>.Instance.GetAllExpConfig() ?? Array.Empty<MoraleKeepLevel>());
			}
			return this.ExpConfigListInternal;
		}

		// Token: 0x0603D39A RID: 250778 RVA: 0x00F916BC File Offset: 0x00F8F8BC
		private IReadOnlyList<BattleScoreLevelConf> GetTempExpConfigList()
		{
			if (this.TempExpConfigListInternal == null)
			{
				MoralePlay? moraleConfig = ConfigBase<MoraleBattleConfig>.Instance.GetMoraleConfig(this.MoraleConfigId);
				int id = (moraleConfig != null) ? moraleConfig.GetValueOrDefault().BattleScoreId : 0;
				BattleScoreConf? battleScoreConfig = ConfigBase<BattleScoreConfig>.Instance.GetBattleScoreConfig(id);
				if (battleScoreConfig != null)
				{
					this.TempExpConfigListInternal = ConfigBase<BattleScoreConfig>.Instance.GetBattleScoreActionConfigByGroupId(battleScoreConfig.Value.LevelGroupId);
				}
			}
			return this.TempExpConfigListInternal;
		}

		// Token: 0x0603D39B RID: 250779 RVA: 0x00F9173C File Offset: 0x00F8F93C
		public int GetLevelExp(int level)
		{
			Dictionary<int, int> levelExpCache = this.LevelExpCache;
			int result;
			if (levelExpCache != null && levelExpCache.TryGetValue(level, out result))
			{
				return result;
			}
			IReadOnlyList<MoraleKeepLevel> expConfigList = this.GetExpConfigList();
			if (level >= 0 && level < expConfigList.Count)
			{
				MoraleKeepLevel? expConfig = ConfigBase<MoraleBattleConfig>.Instance.GetExpConfig(level);
				if (expConfig != null)
				{
					if (this.LevelExpCache == null)
					{
						this.LevelExpCache = new Dictionary<int, int>();
					}
					this.LevelExpCache[level] = expConfig.Value.Experience;
					return expConfig.Value.Experience;
				}
			}
			return 0;
		}

		// Token: 0x0603D39C RID: 250780 RVA: 0x00F917CC File Offset: 0x00F8F9CC
		[NullableContext(0)]
		public ValueTuple<int, int> GetTempLevelExpRange(int level)
		{
			Dictionary<int, ValueTuple<int, int>> tempLevelExpRangeCache = this.TempLevelExpRangeCache;
			ValueTuple<int, int> result;
			if (tempLevelExpRangeCache != null && tempLevelExpRangeCache.TryGetValue(level, out result))
			{
				return result;
			}
			foreach (BattleScoreLevelConf battleScoreLevelConf in this.GetTempExpConfigList())
			{
				if (battleScoreLevelConf.Level == level || (battleScoreLevelConf.Level == 1 && level == 0))
				{
					if (this.TempLevelExpRangeCache == null)
					{
						this.TempLevelExpRangeCache = new Dictionary<int, ValueTuple<int, int>>();
					}
					ValueTuple<int, int> valueTuple;
					if (level == 0)
					{
						valueTuple.Item1 = 0;
						valueTuple.Item2 = battleScoreLevelConf.LowerUpperLimits(0);
					}
					else
					{
						valueTuple.Item1 = battleScoreLevelConf.LowerUpperLimits(0);
						valueTuple.Item2 = battleScoreLevelConf.LowerUpperLimits(1);
					}
					this.TempLevelExpRangeCache[level] = valueTuple;
					return valueTuple;
				}
			}
			return new ValueTuple<int, int>(0, 0);
		}

		// Token: 0x0603D39D RID: 250781 RVA: 0x00F918B0 File Offset: 0x00F8FAB0
		public int GetMoraleLevelUpExp(int? targetLevel = null)
		{
			int num = targetLevel ?? this.MoraleLevel;
			int moraleMaxLevel = this.GetMoraleMaxLevel();
			if (num >= moraleMaxLevel)
			{
				num = moraleMaxLevel - 1;
			}
			int levelExp = this.GetLevelExp(num);
			int levelExp2 = this.GetLevelExp(num + 1);
			return Math.Max(0, levelExp2 - levelExp);
		}

		// Token: 0x0603D39E RID: 250782 RVA: 0x00F91904 File Offset: 0x00F8FB04
		public int GetMoraleCurrentLevelExp()
		{
			if (this.MoraleLevel == 1)
			{
				return this.MoraleExp;
			}
			if (this.MoraleLevel == this.GetMoraleMaxLevel())
			{
				return this.GetMoraleLevelUpExp(new int?(this.MoraleLevel - 1));
			}
			int levelExp = this.GetLevelExp(this.MoraleLevel - 1);
			return Math.Max(0, this.MoraleExp - levelExp);
		}

		// Token: 0x0603D39F RID: 250783 RVA: 0x00F91960 File Offset: 0x00F8FB60
		public float GetMoraleCurrentExpProgress()
		{
			if (this.MoraleLevel == this.GetMoraleMaxLevel())
			{
				return 1f;
			}
			int moraleCurrentLevelExp = this.GetMoraleCurrentLevelExp();
			int moraleLevelUpExp = this.GetMoraleLevelUpExp(null);
			if (moraleLevelUpExp != 0)
			{
				return (float)moraleCurrentLevelExp / (float)moraleLevelUpExp;
			}
			return 0f;
		}

		// Token: 0x0603D3A0 RID: 250784 RVA: 0x00F919A8 File Offset: 0x00F8FBA8
		public int GetTempMoraleLevelUpExp(int? targetLevel = null)
		{
			int level = targetLevel ?? this.TempMoraleLevel;
			ValueTuple<int, int> tempLevelExpRange = this.GetTempLevelExpRange(level);
			return Math.Max(0, tempLevelExpRange.Item2 - tempLevelExpRange.Item1);
		}

		// Token: 0x0603D3A1 RID: 250785 RVA: 0x00F919EC File Offset: 0x00F8FBEC
		public int GetTempMoraleLevelExp()
		{
			ValueTuple<int, int> tempLevelExpRange = this.GetTempLevelExpRange(this.TempMoraleLevel);
			return Math.Max(0, this.TempMoraleExp - tempLevelExpRange.Item1);
		}

		// Token: 0x0603D3A2 RID: 250786 RVA: 0x00F91A1C File Offset: 0x00F8FC1C
		public float GetTempMoraleExpProgress()
		{
			int tempMoraleLevelExp = this.GetTempMoraleLevelExp();
			int tempMoraleLevelUpExp = this.GetTempMoraleLevelUpExp(null);
			if (tempMoraleLevelUpExp != 0)
			{
				return Math.Min(1f, (float)tempMoraleLevelExp / (float)tempMoraleLevelUpExp);
			}
			return 0f;
		}

		// Token: 0x0603D3A3 RID: 250787 RVA: 0x00F91A58 File Offset: 0x00F8FC58
		[NullableContext(1)]
		public void HandleMoraleInfoNotify(MoraleInfoNotify notify)
		{
			this.MoraleConfigId = notify.MoraleConfigId;
			this.ExpRatio = notify.ExpRatio;
			bool isStart = notify.IsStart;
			if (!this.IsMoraleInited)
			{
				this.GetExpConfigList();
				this.GetMoraleMaxExp();
				this.SetMoraleInfoByNotify(notify);
				this.IsMoraleInited = true;
			}
			if (this.IsMoraleActive() != isStart)
			{
				this.SetMoraleActive(isStart);
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnMoraleActiveChanged, isStart);
			}
			if (isStart)
			{
				int moraleLevel = this.MoraleLevel;
				int tempMoraleLevel = this.TempMoraleLevel;
				int num = moraleLevel + tempMoraleLevel;
				int num2 = notify.KeepMoraleLevel + notify.TempMoraleLevel;
				bool flag = num != num2;
				int num3 = Math.Min(this.MoraleMaxExp, notify.KeepMoraleExp);
				if (this.MoraleExp != num3)
				{
					int moraleExp = this.MoraleExp;
					this.MoraleExp = num3;
					this.MoraleLevel = notify.KeepMoraleLevel;
					Singleton<EventSystem>.Instance.Emit<int, int, int, int>(EEventName.OnMoraleExpChanged, moraleExp, this.MoraleExp, moraleLevel, this.MoraleLevel);
				}
				if (this.TempMoraleExp != notify.TempMoraleExp)
				{
					int tempMoraleExp = this.TempMoraleExp;
					this.TempMoraleExp = notify.TempMoraleExp;
					this.TempMoraleLevel = notify.TempMoraleLevel;
					Singleton<EventSystem>.Instance.Emit<int, int, int, int>(EEventName.OnMoraleTempExpChanged, tempMoraleExp, this.TempMoraleExp, tempMoraleLevel, this.TempMoraleLevel);
				}
				if (flag)
				{
					Singleton<EventSystem>.Instance.Emit<int, int, int, int>(EEventName.OnMoraleSumLevelChanged, moraleLevel, this.MoraleLevel, tempMoraleLevel, this.TempMoraleLevel);
				}
				if (this.MoraleIndomitableLevel != notify.IndomitableLevel)
				{
					int moraleIndomitableLevel = this.MoraleIndomitableLevel;
					this.MoraleIndomitableLevel = notify.IndomitableLevel;
					Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnMoraleIndomitableLevelChanged, moraleIndomitableLevel, this.MoraleIndomitableLevel);
				}
				if (notify.Reason == 1)
				{
					this.LastMoraleLevel = moraleLevel;
					Singleton<EventSystem>.Instance.Emit(EEventName.OnMoraleBattleFail);
					return;
				}
			}
			else
			{
				this.SetMoraleInfoByNotify(notify);
			}
		}

		// Token: 0x0603D3A4 RID: 250788 RVA: 0x00F91C1C File Offset: 0x00F8FE1C
		[NullableContext(1)]
		private void SetMoraleInfoByNotify(MoraleInfoNotify notify)
		{
			this.MoraleExp = Math.Min(this.MoraleMaxExp, notify.KeepMoraleExp);
			this.MoraleLevel = notify.KeepMoraleLevel;
			this.MoraleIndomitableLevel = notify.IndomitableLevel;
			this.TempMoraleLevel = notify.TempMoraleLevel;
			this.TempMoraleExp = notify.TempMoraleExp;
		}

		// Token: 0x0603D3A5 RID: 250789 RVA: 0x00F91C70 File Offset: 0x00F8FE70
		public EMoraleLevelDiffType GetMoraleLevelDiffType(int compareLevel, int? playerLevel = null)
		{
			int num = (playerLevel ?? (this.GetMoraleLevel() + this.GetTempMoraleLevel())) - compareLevel;
			IReadOnlyList<MoraleLevelDiffShow> allLevelDiffShowConfig = ConfigBase<MoraleBattleConfig>.Instance.GetAllLevelDiffShowConfig();
			EMoraleLevelDiffType emoraleLevelDiffType = EMoraleLevelDiffType.Easy;
			if (allLevelDiffShowConfig == null)
			{
				return emoraleLevelDiffType;
			}
			foreach (MoraleLevelDiffShow moraleLevelDiffShow in allLevelDiffShowConfig)
			{
				if (num >= moraleLevelDiffShow.LevelDiffLower && num < moraleLevelDiffShow.LevelDiffUpper)
				{
					emoraleLevelDiffType = (EMoraleLevelDiffType)moraleLevelDiffShow.MonsterLevelPattern;
					if (emoraleLevelDiffType > EMoraleLevelDiffType.Hard)
					{
						emoraleLevelDiffType = EMoraleLevelDiffType.Hard;
						break;
					}
					if (emoraleLevelDiffType < EMoraleLevelDiffType.Easy)
					{
						emoraleLevelDiffType = EMoraleLevelDiffType.Easy;
						break;
					}
					break;
				}
			}
			return emoraleLevelDiffType;
		}

		// Token: 0x04022554 RID: 140628
		private const int EXTRA_TEMP_MORALE_MAX_LEVEL_BUFF_ID = 632400018;

		// Token: 0x04022555 RID: 140629
		private const int EXTRA_TEMP_MORALE_MAX_LEVEL = 100;

		// Token: 0x04022556 RID: 140630
		private int MoraleConfigId;

		// Token: 0x04022557 RID: 140631
		private int MoraleExp;

		// Token: 0x04022558 RID: 140632
		private int MoraleMaxExp;

		// Token: 0x04022559 RID: 140633
		private int MoraleLevel = 1;

		// Token: 0x0402255A RID: 140634
		private int TempMoraleLevel;

		// Token: 0x0402255B RID: 140635
		private int TempMoraleExp;

		// Token: 0x0402255C RID: 140636
		private int MoraleIndomitableLevel = 1;

		// Token: 0x0402255D RID: 140637
		private bool IsMoraleActiveInternal;

		// Token: 0x0402255E RID: 140638
		private bool IsMoraleInited;

		// Token: 0x0402255F RID: 140639
		private IReadOnlyList<MoraleKeepLevel> ExpConfigListInternal;

		// Token: 0x04022560 RID: 140640
		private IReadOnlyList<BattleScoreLevelConf> TempExpConfigListInternal;

		// Token: 0x04022561 RID: 140641
		private Dictionary<int, int> LevelExpCache;

		// Token: 0x04022562 RID: 140642
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private Dictionary<int, ValueTuple<int, int>> TempLevelExpRangeCache;

		// Token: 0x04022563 RID: 140643
		private int ExpRatio;

		// Token: 0x04022564 RID: 140644
		private int LastMoraleLevel = 1;

		// Token: 0x04022565 RID: 140645
		private bool IsCheckTempMoraleMaxLevelBuff;

		// Token: 0x04022566 RID: 140646
		private bool IsUnlockTempMoraleMaxLevel;
	}
}
