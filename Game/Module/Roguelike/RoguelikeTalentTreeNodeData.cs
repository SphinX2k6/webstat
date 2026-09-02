using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005100 RID: 20736
	public class RoguelikeTalentTreeNodeData
	{
		// Token: 0x06035739 RID: 218937 RVA: 0x00D6A9C3 File Offset: 0x00D68BC3
		public RoguelikeTalentTreeNodeData(int id)
		{
			this.Id = id;
		}

		// Token: 0x17008C41 RID: 35905
		// (get) Token: 0x0603573A RID: 218938 RVA: 0x00D6A9D2 File Offset: 0x00D68BD2
		public RogueTalentTree Config
		{
			get
			{
				if (this.ConfigInternal == null)
				{
					this.ConfigInternal = ConfigBase<RoguelikeConfig>.Instance.GetRogueTalentTreeById(this.Id);
				}
				return this.ConfigInternal.Value;
			}
		}

		// Token: 0x17008C42 RID: 35906
		// (get) Token: 0x0603573B RID: 218939 RVA: 0x00D6AA04 File Offset: 0x00D68C04
		public RogueTalentTreeDesc DescConfig
		{
			get
			{
				if (this.DescConfigInternal == null)
				{
					this.DescConfigInternal = ConfigBase<RoguelikeConfig>.Instance.GetRogueTalentTreeDescConfig(this.Config.Describe);
				}
				return this.DescConfigInternal.Value;
			}
		}

		// Token: 0x17008C43 RID: 35907
		// (get) Token: 0x0603573C RID: 218940 RVA: 0x00D6AA47 File Offset: 0x00D68C47
		public int Index
		{
			get
			{
				return this.Col - 1;
			}
		}

		// Token: 0x17008C44 RID: 35908
		// (get) Token: 0x0603573D RID: 218941 RVA: 0x00D6AA54 File Offset: 0x00D68C54
		public int Row
		{
			get
			{
				return this.Config.Row;
			}
		}

		// Token: 0x17008C45 RID: 35909
		// (get) Token: 0x0603573E RID: 218942 RVA: 0x00D6AA70 File Offset: 0x00D68C70
		public int Col
		{
			get
			{
				return this.Config.Column;
			}
		}

		// Token: 0x17008C46 RID: 35910
		// (get) Token: 0x0603573F RID: 218943 RVA: 0x00D6AA8B File Offset: 0x00D68C8B
		public int CurLevel
		{
			get
			{
				return ModelBase<RoguelikeModel>.Instance.RoguelikeSkillDataMap[this.Id];
			}
		}

		// Token: 0x17008C47 RID: 35911
		// (get) Token: 0x06035740 RID: 218944 RVA: 0x00D6AAA4 File Offset: 0x00D68CA4
		public ETalentTreeNodeState State
		{
			get
			{
				int curLevel = this.CurLevel;
				if (curLevel == -1)
				{
					return ETalentTreeNodeState.Lock;
				}
				if (curLevel == 0)
				{
					return ETalentTreeNodeState.Unlock;
				}
				return ETalentTreeNodeState.Active;
			}
		}

		// Token: 0x06035741 RID: 218945 RVA: 0x00D6AAC4 File Offset: 0x00D68CC4
		[NullableContext(1)]
		public List<ICostData> GetCostData()
		{
			if (this.State == ETalentTreeNodeState.Active)
			{
				return new List<ICostData>();
			}
			int skillPoint = ModelBase<RoguelikeModel>.Instance.GetParamConfigBySeasonId(null).Value.SkillPoint;
			CostData costData = new CostData();
			costData.ItemId = skillPoint;
			InventoryModel instance = ModelBase<InventoryModel>.Instance;
			costData.Count = ((instance != null) ? instance.GetItemCountByConfigId(skillPoint, 0) : 0);
			costData.Cost = ((this.CurLevel >= 0 && this.CurLevel < this.Config.ConsuleLength) ? this.Config.Consule(this.CurLevel) : 0);
			CostData item = costData;
			return new List<ICostData>
			{
				item
			};
		}

		// Token: 0x06035742 RID: 218946 RVA: 0x00D6AB78 File Offset: 0x00D68D78
		public bool CanAfford()
		{
			List<ICostData> costData = this.GetCostData();
			return costData.Count == 0 || costData[0].Count >= costData[0].Cost;
		}

		// Token: 0x0401EB3F RID: 125759
		public int Id;

		// Token: 0x0401EB40 RID: 125760
		private RogueTalentTree? ConfigInternal;

		// Token: 0x0401EB41 RID: 125761
		private RogueTalentTreeDesc? DescConfigInternal;

		// Token: 0x0401EB42 RID: 125762
		[Nullable(2)]
		public Action<bool, bool> SetNodeToggleState;
	}
}
