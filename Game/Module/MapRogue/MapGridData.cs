using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005900 RID: 22784
	[NullableContext(1)]
	[Nullable(0)]
	public class MapGridData : IPathNode
	{
		// Token: 0x170093CC RID: 37836
		// (get) Token: 0x06039D21 RID: 236833 RVA: 0x00EA48D5 File Offset: 0x00EA2AD5
		// (set) Token: 0x06039D22 RID: 236834 RVA: 0x00EA48DD File Offset: 0x00EA2ADD
		public int GridIndex { get; set; }

		// Token: 0x170093CD RID: 37837
		// (get) Token: 0x06039D23 RID: 236835 RVA: 0x00EA48E6 File Offset: 0x00EA2AE6
		// (set) Token: 0x06039D24 RID: 236836 RVA: 0x00EA48EE File Offset: 0x00EA2AEE
		public int Cost { get; set; }

		// Token: 0x170093CE RID: 37838
		// (get) Token: 0x06039D25 RID: 236837 RVA: 0x00EA48F7 File Offset: 0x00EA2AF7
		// (set) Token: 0x06039D26 RID: 236838 RVA: 0x00EA48FF File Offset: 0x00EA2AFF
		public bool Walkable { get; set; }

		// Token: 0x06039D27 RID: 236839 RVA: 0x00EA4908 File Offset: 0x00EA2B08
		public void RefreshByServer(RogueResGridData data)
		{
			this.GridId = data.ConfigId;
			this.WalkCost = data.Cost;
			this.EventCost = data.EventCost;
			this.IsExplore = data.IsExplore;
			this.HasVision = data.HasVision;
			this.IsBlock = data.IsBlock;
			this.Walkable = (data.HasVision && !data.IsBlock);
			this.GridTypeId = data.MapType;
			this.GridEventId = data.EventId;
			this.Lv = data.RecommondLevel;
			this.OccupiedEffectIdList.Clear();
			this.OccupiedEffectIdList.AddRange(data.CaptureEffects);
			this.RewardItemIdList.Clear();
			this.RewardItemIdList.AddRange(data.PreAward);
			this.ConditionInfo = data.CondInfo;
			this.ToleranceLv = data.RecommondLevelRange;
			this.SkipBattleLv = data.SkipBattleLv;
			this.CanSkipBattle = data.CanSkipBattle;
			RogueResGridEvent? gridEventConfigById = ConfigBase<MapRogueConfig>.Instance.GetGridEventConfigById(this.GridEventId);
			this.EventType = ((gridEventConfigById != null) ? gridEventConfigById.GetValueOrDefault().EventType : -1);
			this.GridEventType = (EGridEventType)((gridEventConfigById != null) ? gridEventConfigById.Value.ShowType : 0);
			this.Cost = (this.HasEvent(null) ? 1000000 : 1);
		}

		// Token: 0x06039D28 RID: 236840 RVA: 0x00EA4A78 File Offset: 0x00EA2C78
		public bool HasEvent(bool? hasVision = null)
		{
			return (hasVision ?? this.HasVision) && !this.IsExplore && this.GridEventId != 0;
		}

		// Token: 0x06039D29 RID: 236841 RVA: 0x00EA4AB6 File Offset: 0x00EA2CB6
		public bool IsValid()
		{
			return this.GridId != 0;
		}

		// Token: 0x06039D2A RID: 236842 RVA: 0x00EA4AC1 File Offset: 0x00EA2CC1
		public bool NeedTriggerEvent()
		{
			return !this.IsExplore && this.GridEventId != 0;
		}

		// Token: 0x06039D2B RID: 236843 RVA: 0x00EA4AD6 File Offset: 0x00EA2CD6
		public bool IsUnlock()
		{
			return this.ConditionInfo == null || this.ConditionInfo.Id == 0 || this.ConditionInfo.Current >= this.ConditionInfo.Target;
		}

		// Token: 0x04020C3B RID: 134203
		public int GridId;

		// Token: 0x04020C3D RID: 134205
		public int GridTypeId;

		// Token: 0x04020C3E RID: 134206
		public int GroundPathIndex;

		// Token: 0x04020C3F RID: 134207
		public int ExtraPathIndex = -1;

		// Token: 0x04020C40 RID: 134208
		public int GridEventId;

		// Token: 0x04020C41 RID: 134209
		public EGridEventType GridEventType;

		// Token: 0x04020C42 RID: 134210
		public int EventType = -1;

		// Token: 0x04020C44 RID: 134212
		public int WalkCost;

		// Token: 0x04020C45 RID: 134213
		public int EventCost;

		// Token: 0x04020C46 RID: 134214
		public bool IsExplore;

		// Token: 0x04020C47 RID: 134215
		public bool HasVision;

		// Token: 0x04020C48 RID: 134216
		public bool IsBlock;

		// Token: 0x04020C4A RID: 134218
		public int Lv;

		// Token: 0x04020C4B RID: 134219
		public int ToleranceLv;

		// Token: 0x04020C4C RID: 134220
		public int SkipBattleLv;

		// Token: 0x04020C4D RID: 134221
		public bool CanSkipBattle;

		// Token: 0x04020C4E RID: 134222
		public List<int> OccupiedEffectIdList = new List<int>();

		// Token: 0x04020C4F RID: 134223
		public List<int> RewardItemIdList = new List<int>();

		// Token: 0x04020C50 RID: 134224
		[Nullable(2)]
		public CondInfo ConditionInfo;
	}
}
