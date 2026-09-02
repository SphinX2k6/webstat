using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F40 RID: 24384
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class BattleScoreModel : ModelBase<BattleScoreModel>
	{
		// Token: 0x0603D433 RID: 250931 RVA: 0x00F94AE5 File Offset: 0x00F92CE5
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x0603D434 RID: 250932 RVA: 0x00F94AE8 File Offset: 0x00F92CE8
		protected override bool OnLeaveLevel()
		{
			this.ScoreMap.Clear();
			this.ScoreEnableMap.Clear();
			this.CurScoreId = 0;
			this.RougeScoreMusicState.State = "none";
			return true;
		}

		// Token: 0x0603D435 RID: 250933 RVA: 0x00F94B18 File Offset: 0x00F92D18
		public void HandleBattleScoreNotify(BattleScoreNotify notify)
		{
			this.UpdateScore(notify.BattleScoreConfId, notify.ScoreTotal);
		}

		// Token: 0x0603D436 RID: 250934 RVA: 0x00F94B2C File Offset: 0x00F92D2C
		public void HandleBattleScoreEnableNotify(BattleScoreEnableNotify notify)
		{
			this.UpdateScoreEnable(notify.BattleScoreConfId, notify.Enable);
		}

		// Token: 0x0603D437 RID: 250935 RVA: 0x00F94B40 File Offset: 0x00F92D40
		public void CacheScoreConfig(int scoreId)
		{
			if (!this.ScoreConfigMap.ContainsKey(scoreId))
			{
				BattleScoreConf? battleScoreConfig = ConfigBase<BattleScoreConfig>.Instance.GetBattleScoreConfig(scoreId);
				if (battleScoreConfig != null)
				{
					this.ScoreConfigMap[scoreId] = battleScoreConfig.Value;
				}
			}
		}

		// Token: 0x0603D438 RID: 250936 RVA: 0x00F94B83 File Offset: 0x00F92D83
		public void UpdateScore(int scoreId, int score)
		{
			this.ScoreMap[scoreId] = score;
			if (this.CurScoreId != scoreId)
			{
				this.CurScoreId = scoreId;
				this.CacheScoreConfig(scoreId);
			}
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.BattleScoreChanged, scoreId, score);
		}

		// Token: 0x0603D439 RID: 250937 RVA: 0x00F94BBB File Offset: 0x00F92DBB
		public void UpdateScoreEnable(int scoreId, bool enable)
		{
			this.ScoreEnableMap[scoreId] = enable;
			if (!enable)
			{
				this.ScoreMap[scoreId] = 0;
			}
			this.CacheScoreConfig(scoreId);
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.BattleScoreEnableChanged, scoreId, enable);
		}

		// Token: 0x0603D43A RID: 250938 RVA: 0x00F94BF4 File Offset: 0x00F92DF4
		public BattleScoreConf? GetScoreConfig(int scoreId, bool cache = false)
		{
			BattleScoreConf? valueOrNull = this.ScoreConfigMap.GetValueOrNull(scoreId);
			if (valueOrNull == null && cache)
			{
				this.CacheScoreConfig(scoreId);
				valueOrNull = this.ScoreConfigMap.GetValueOrNull(scoreId);
			}
			return valueOrNull;
		}

		// Token: 0x0603D43B RID: 250939 RVA: 0x00F94C31 File Offset: 0x00F92E31
		public int GetScore(int scoreId)
		{
			return this.ScoreMap.GetValueOrDefault(scoreId, 0);
		}

		// Token: 0x0603D43C RID: 250940 RVA: 0x00F94C40 File Offset: 0x00F92E40
		public IReadOnlyDictionary<int, int> GetScoreMap()
		{
			return this.ScoreMap;
		}

		// Token: 0x0603D43D RID: 250941 RVA: 0x00F94C48 File Offset: 0x00F92E48
		public IReadOnlyDictionary<int, bool> GetScoreEnableMap()
		{
			return this.ScoreEnableMap;
		}

		// Token: 0x0603D43E RID: 250942 RVA: 0x00F94C50 File Offset: 0x00F92E50
		public int GetCurScoreId()
		{
			return this.CurScoreId;
		}

		// Token: 0x0603D43F RID: 250943 RVA: 0x00F94C58 File Offset: 0x00F92E58
		public int GetCurScore()
		{
			return this.GetScore(this.CurScoreId);
		}

		// Token: 0x040225CA RID: 140746
		private readonly Dictionary<int, int> ScoreMap = new Dictionary<int, int>();

		// Token: 0x040225CB RID: 140747
		private readonly Dictionary<int, bool> ScoreEnableMap = new Dictionary<int, bool>();

		// Token: 0x040225CC RID: 140748
		private readonly Dictionary<int, BattleScoreConf> ScoreConfigMap = new Dictionary<int, BattleScoreConf>();

		// Token: 0x040225CD RID: 140749
		private int CurScoreId;

		// Token: 0x040225CE RID: 140750
		public StateRef RougeScoreMusicState = new StateRef("game_rogue_combat_combo_rank", "none");
	}
}
