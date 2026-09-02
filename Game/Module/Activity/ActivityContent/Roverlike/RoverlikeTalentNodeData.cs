using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063A7 RID: 25511
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeTalentNodeData
	{
		// Token: 0x060400EA RID: 262378 RVA: 0x0106B439 File Offset: 0x01069639
		public RoverlikeTalentNodeData(List<RoverRogueTalentTree> levelConfigs)
		{
			this.LevelConfigsInternal = levelConfigs;
		}

		// Token: 0x17009D6E RID: 40302
		// (get) Token: 0x060400EB RID: 262379 RVA: 0x0106B45A File Offset: 0x0106965A
		public IReadOnlyList<RoverRogueTalentTree> LevelConfigs
		{
			get
			{
				return this.LevelConfigsInternal;
			}
		}

		// Token: 0x17009D6F RID: 40303
		// (get) Token: 0x060400EC RID: 262380 RVA: 0x0106B462 File Offset: 0x01069662
		public RoverRogueTalentTree HeadConfig
		{
			get
			{
				return this.LevelConfigsInternal[0];
			}
		}

		// Token: 0x17009D70 RID: 40304
		// (get) Token: 0x060400ED RID: 262381 RVA: 0x0106B470 File Offset: 0x01069670
		public int MaxLevel
		{
			get
			{
				return this.LevelConfigsInternal.Count;
			}
		}

		// Token: 0x17009D71 RID: 40305
		// (get) Token: 0x060400EE RID: 262382 RVA: 0x0106B47D File Offset: 0x0106967D
		// (set) Token: 0x060400EF RID: 262383 RVA: 0x0106B485 File Offset: 0x01069685
		public int CurLevel
		{
			get
			{
				return this.CurLevelInternal;
			}
			set
			{
				if (value < 0)
				{
					this.CurLevelInternal = 0;
					return;
				}
				if (value > this.MaxLevel)
				{
					this.CurLevelInternal = this.MaxLevel;
					return;
				}
				this.CurLevelInternal = value;
			}
		}

		// Token: 0x17009D72 RID: 40306
		// (get) Token: 0x060400F0 RID: 262384 RVA: 0x0106B4B0 File Offset: 0x010696B0
		public bool IsUnLock
		{
			get
			{
				return this.IsServerUnlockedInternal;
			}
		}

		// Token: 0x17009D73 RID: 40307
		// (get) Token: 0x060400F1 RID: 262385 RVA: 0x0106B4B8 File Offset: 0x010696B8
		// (set) Token: 0x060400F2 RID: 262386 RVA: 0x0106B4C0 File Offset: 0x010696C0
		public bool IsServerUnlocked
		{
			get
			{
				return this.IsServerUnlockedInternal;
			}
			set
			{
				this.IsServerUnlockedInternal = value;
			}
		}

		// Token: 0x17009D74 RID: 40308
		// (get) Token: 0x060400F3 RID: 262387 RVA: 0x0106B4C9 File Offset: 0x010696C9
		// (set) Token: 0x060400F4 RID: 262388 RVA: 0x0106B4D1 File Offset: 0x010696D1
		public int ActiveLevel
		{
			get
			{
				return this.ActiveLevelInternal;
			}
			set
			{
				this.ActiveLevelInternal = Math.Max(0, value);
			}
		}

		// Token: 0x17009D75 RID: 40309
		// (get) Token: 0x060400F5 RID: 262389 RVA: 0x0106B4E0 File Offset: 0x010696E0
		public int Row
		{
			get
			{
				return this.HeadConfig.Row;
			}
		}

		// Token: 0x17009D76 RID: 40310
		// (get) Token: 0x060400F6 RID: 262390 RVA: 0x0106B4FC File Offset: 0x010696FC
		public int Index
		{
			get
			{
				return this.HeadConfig.Column - 1;
			}
		}

		// Token: 0x17009D77 RID: 40311
		// (get) Token: 0x060400F7 RID: 262391 RVA: 0x0106B519 File Offset: 0x01069719
		public ERoverlikeTalentNodeState State
		{
			get
			{
				if (!this.IsUnLock)
				{
					return ERoverlikeTalentNodeState.Lock;
				}
				if (this.IsMaxLevel)
				{
					return ERoverlikeTalentNodeState.Full;
				}
				return ERoverlikeTalentNodeState.Unlock;
			}
		}

		// Token: 0x17009D78 RID: 40312
		// (get) Token: 0x060400F8 RID: 262392 RVA: 0x0106B530 File Offset: 0x01069730
		public bool IsMaxLevel
		{
			get
			{
				return this.CurLevelInternal >= this.MaxLevel;
			}
		}

		// Token: 0x17009D79 RID: 40313
		// (get) Token: 0x060400F9 RID: 262393 RVA: 0x0106B543 File Offset: 0x01069743
		// (set) Token: 0x060400FA RID: 262394 RVA: 0x0106B54B File Offset: 0x0106974B
		public bool IsFinishPreCondition
		{
			get
			{
				return this.IsFinishPreConditionInternal;
			}
			set
			{
				this.IsFinishPreConditionInternal = value;
			}
		}

		// Token: 0x17009D7A RID: 40314
		// (get) Token: 0x060400FB RID: 262395 RVA: 0x0106B554 File Offset: 0x01069754
		public RoverRogueTalentTree? CurrentLevelConfig
		{
			get
			{
				if (!this.IsUnLock)
				{
					return null;
				}
				int num = this.CurLevelInternal - 1;
				if (num < 0 || num >= this.LevelConfigsInternal.Count)
				{
					return null;
				}
				return new RoverRogueTalentTree?(this.LevelConfigsInternal[num]);
			}
		}

		// Token: 0x17009D7B RID: 40315
		// (get) Token: 0x060400FC RID: 262396 RVA: 0x0106B5AC File Offset: 0x010697AC
		public RoverRogueTalentTree? NextLevelConfig
		{
			get
			{
				if (this.IsMaxLevel)
				{
					return null;
				}
				return new RoverRogueTalentTree?(this.LevelConfigsInternal[this.CurLevelInternal]);
			}
		}

		// Token: 0x17009D7C RID: 40316
		// (get) Token: 0x060400FD RID: 262397 RVA: 0x0106B5E4 File Offset: 0x010697E4
		public int NextLevelCost
		{
			get
			{
				if (this.NextLevelConfig == null)
				{
					return 0;
				}
				RoverRogueTalentTree? roverRogueTalentTree;
				return roverRogueTalentTree.GetValueOrDefault().Consule;
			}
		}

		// Token: 0x17009D7D RID: 40317
		// (get) Token: 0x060400FE RID: 262398 RVA: 0x0106B614 File Offset: 0x01069814
		public int NextLevelId
		{
			get
			{
				if (this.NextLevelConfig == null)
				{
					return 0;
				}
				RoverRogueTalentTree? roverRogueTalentTree;
				return roverRogueTalentTree.GetValueOrDefault().Id;
			}
		}

		// Token: 0x17009D7E RID: 40318
		// (get) Token: 0x060400FF RID: 262399 RVA: 0x0106B644 File Offset: 0x01069844
		public string CurrentDescTextId
		{
			get
			{
				return (this.CurrentLevelConfig ?? this.HeadConfig).Desc;
			}
		}

		// Token: 0x17009D7F RID: 40319
		// (get) Token: 0x06040100 RID: 262400 RVA: 0x0106B678 File Offset: 0x01069878
		public List<string> CurrentDescParams
		{
			get
			{
				return RoverlikeTalentNodeData.GetConfigParams(this.CurrentLevelConfig ?? this.HeadConfig);
			}
		}

		// Token: 0x17009D80 RID: 40320
		// (get) Token: 0x06040101 RID: 262401 RVA: 0x0106B6AC File Offset: 0x010698AC
		public string NextLevelDescTextId
		{
			get
			{
				RoverRogueTalentTree? roverRogueTalentTree;
				return ((this.NextLevelConfig != null) ? roverRogueTalentTree.GetValueOrDefault().Desc : null) ?? "";
			}
		}

		// Token: 0x17009D81 RID: 40321
		// (get) Token: 0x06040102 RID: 262402 RVA: 0x0106B6E4 File Offset: 0x010698E4
		public List<string> NextLevelDescParams
		{
			get
			{
				RoverRogueTalentTree? nextLevelConfig = this.NextLevelConfig;
				if (nextLevelConfig == null)
				{
					return new List<string>();
				}
				return RoverlikeTalentNodeData.GetConfigParams(nextLevelConfig.Value);
			}
		}

		// Token: 0x06040103 RID: 262403 RVA: 0x0106B714 File Offset: 0x01069914
		private static List<string> GetConfigParams(RoverRogueTalentTree config)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < config.ParamsLength; i++)
			{
				list.Add(config.Params(i));
			}
			return list;
		}

		// Token: 0x04023F6C RID: 147308
		private readonly List<RoverRogueTalentTree> LevelConfigsInternal = new List<RoverRogueTalentTree>();

		// Token: 0x04023F6D RID: 147309
		private bool IsFinishPreConditionInternal = true;

		// Token: 0x04023F6E RID: 147310
		private int CurLevelInternal;

		// Token: 0x04023F6F RID: 147311
		private bool IsServerUnlockedInternal;

		// Token: 0x04023F70 RID: 147312
		private int ActiveLevelInternal;

		// Token: 0x04023F71 RID: 147313
		[Nullable(2)]
		public Action<bool, bool> SetNodeToggleState;
	}
}
