using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.NewbieMain
{
	// Token: 0x02006642 RID: 26178
	[NullableContext(1)]
	[Nullable(0)]
	public class NewbieMainData : ActivityBaseData
	{
		// Token: 0x17009F7B RID: 40827
		// (get) Token: 0x0604161C RID: 267804 RVA: 0x010C58C2 File Offset: 0x010C3AC2
		public int ProgressScore
		{
			get
			{
				return this.ProgressScoreInternal;
			}
		}

		// Token: 0x0604161D RID: 267805 RVA: 0x010C58CC File Offset: 0x010C3ACC
		protected override void PhraseEx(ActivityData data)
		{
			NewbieMainActivityPb newbieMainActivityPb = data.NewbieMainActivityPb;
			if (newbieMainActivityPb == null)
			{
				return;
			}
			this.ParseTabs(newbieMainActivityPb.NewbieMainTabs);
			this.ParseTakenRewards(newbieMainActivityPb.TakenScoreRewardIds);
			this.ProgressScoreInternal = newbieMainActivityPb.ProgressScore;
		}

		// Token: 0x0604161E RID: 267806 RVA: 0x010C5908 File Offset: 0x010C3B08
		private void ParseTabs(IList<NewbieMainTabPb> tabs)
		{
			this.TabDataMap.Clear();
			if (tabs == null)
			{
				return;
			}
			foreach (NewbieMainTabPb newbieMainTabPb in tabs)
			{
				NewbieMainTabData newbieMainTabData = new NewbieMainTabData(newbieMainTabPb.TabId);
				newbieMainTabData.SetCompletedTaskIds(newbieMainTabPb.CompletedTaskIds);
				this.TabDataMap[newbieMainTabPb.TabId] = newbieMainTabData;
			}
		}

		// Token: 0x0604161F RID: 267807 RVA: 0x010C5984 File Offset: 0x010C3B84
		private void ParseTakenRewards(IList<int> ids)
		{
			this.TakenScoreRewardIds = new HashSet<int>(ids ?? new List<int>());
		}

		// Token: 0x06041620 RID: 267808 RVA: 0x010C599C File Offset: 0x010C3B9C
		public void UpdateTabs(IList<NewbieMainTabPb> tabs)
		{
			if (tabs == null)
			{
				return;
			}
			foreach (NewbieMainTabPb newbieMainTabPb in tabs)
			{
				NewbieMainTabData newbieMainTabData;
				if (!this.TabDataMap.TryGetValue(newbieMainTabPb.TabId, out newbieMainTabData))
				{
					newbieMainTabData = new NewbieMainTabData(newbieMainTabPb.TabId);
					this.TabDataMap[newbieMainTabPb.TabId] = newbieMainTabData;
				}
				newbieMainTabData.SetCompletedTaskIds(newbieMainTabPb.CompletedTaskIds);
			}
		}

		// Token: 0x06041621 RID: 267809 RVA: 0x010C5A20 File Offset: 0x010C3C20
		public void UpdateProgressScore(int score)
		{
			this.ProgressScoreInternal = score;
		}

		// Token: 0x06041622 RID: 267810 RVA: 0x010C5A2C File Offset: 0x010C3C2C
		public void AddTakenScoreRewardIds(IList<int> ids)
		{
			foreach (int item in ids)
			{
				this.TakenScoreRewardIds.Add(item);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x06041623 RID: 267811 RVA: 0x010C5A90 File Offset: 0x010C3C90
		public bool IsScoreRewardTaken(int rewardId)
		{
			return this.TakenScoreRewardIds.Contains(rewardId);
		}

		// Token: 0x06041624 RID: 267812 RVA: 0x010C5A9E File Offset: 0x010C3C9E
		public HashSet<int> GetTakenScoreRewardIds()
		{
			return this.TakenScoreRewardIds;
		}

		// Token: 0x06041625 RID: 267813 RVA: 0x010C5AA8 File Offset: 0x010C3CA8
		[NullableContext(2)]
		public NewbieMainTabData GetTabData(int tabId)
		{
			NewbieMainTabData result;
			if (!this.TabDataMap.TryGetValue(tabId, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x06041626 RID: 267814 RVA: 0x010C5AC8 File Offset: 0x010C3CC8
		public Dictionary<int, NewbieMainTabData> GetAllTabData()
		{
			return this.TabDataMap;
		}

		// Token: 0x06041627 RID: 267815 RVA: 0x010C5AD0 File Offset: 0x010C3CD0
		public override bool GetExDataRedPointShowState()
		{
			IReadOnlyList<NewbieMainActReward> rewardListByActivityId = ConfigBase<NewbieMainConfig>.Instance.GetRewardListByActivityId(base.Id);
			if (rewardListByActivityId == null)
			{
				return false;
			}
			foreach (NewbieMainActReward newbieMainActReward in rewardListByActivityId)
			{
				if (!this.TakenScoreRewardIds.Contains(newbieMainActReward.Id) && this.ProgressScoreInternal >= newbieMainActReward.Score)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06041628 RID: 267816 RVA: 0x010C5B54 File Offset: 0x010C3D54
		protected override bool GetExDataFinishShowState()
		{
			IReadOnlyList<NewbieMainActReward> rewardListByActivityId = ConfigBase<NewbieMainConfig>.Instance.GetRewardListByActivityId(base.Id);
			if (rewardListByActivityId == null || rewardListByActivityId.Count == 0)
			{
				return false;
			}
			foreach (NewbieMainActReward newbieMainActReward in rewardListByActivityId)
			{
				if (!this.TakenScoreRewardIds.Contains(newbieMainActReward.Id))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x040248F9 RID: 149753
		private readonly Dictionary<int, NewbieMainTabData> TabDataMap = new Dictionary<int, NewbieMainTabData>();

		// Token: 0x040248FA RID: 149754
		private HashSet<int> TakenScoreRewardIds = new HashSet<int>();

		// Token: 0x040248FB RID: 149755
		private int ProgressScoreInternal;
	}
}
