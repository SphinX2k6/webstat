using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063A3 RID: 25507
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeLevelSelectData
	{
		// Token: 0x060400C8 RID: 262344 RVA: 0x0106AC6C File Offset: 0x01068E6C
		public int GetSelectedRoleTypeId(int instId)
		{
			int result;
			if (!this.SelectedRoleTypeByInst.TryGetValue(instId, out result))
			{
				return 0;
			}
			return result;
		}

		// Token: 0x060400C9 RID: 262345 RVA: 0x0106AC8C File Offset: 0x01068E8C
		public void SetSelectedRoleTypeId(int instId, int roleTypeId)
		{
			if (instId > 0)
			{
				this.SelectedRoleTypeByInst[instId] = roleTypeId;
			}
		}

		// Token: 0x060400CA RID: 262346 RVA: 0x0106AC9F File Offset: 0x01068E9F
		public void Reset()
		{
			this.LastSelectedInstId = 0;
			this.EntryById.Clear();
			this.SelectedRoleTypeByInst.Clear();
		}

		// Token: 0x060400CB RID: 262347 RVA: 0x0106ACC0 File Offset: 0x01068EC0
		public void PhraseEx(int activityId, RoverRogueActivityData roverData)
		{
			this.ActivityId = activityId;
			RoverRogueHistoryInsInfo historyInsInfo = roverData.HistoryInsInfo;
			this.LastSelectedInstId = ((historyInsInfo != null) ? historyInsInfo.CurInsId : 0);
			this.UpdateEntries(roverData.InsInfoList);
		}

		// Token: 0x060400CC RID: 262348 RVA: 0x0106ACFC File Offset: 0x01068EFC
		public void UpdateEntries(IReadOnlyList<RoverRogueInsEntry> entries)
		{
			if (entries.Count <= 0)
			{
				return;
			}
			foreach (RoverRogueInsEntry roverRogueInsEntry in entries)
			{
				this.EntryById[roverRogueInsEntry.InstId] = roverRogueInsEntry;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.RoverlikeLevelInfoUpdate);
		}

		// Token: 0x060400CD RID: 262349 RVA: 0x0106AD6C File Offset: 0x01068F6C
		public bool IsUnlocked(int instId)
		{
			RoverRogueInsEntry roverRogueInsEntry;
			return this.EntryById.TryGetValue(instId, out roverRogueInsEntry) && roverRogueInsEntry.Unlocked;
		}

		// Token: 0x060400CE RID: 262350 RVA: 0x0106AD94 File Offset: 0x01068F94
		public List<int> GetUnlockedInsIdList()
		{
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, RoverRogueInsEntry> keyValuePair in this.EntryById)
			{
				if (keyValuePair.Value.Unlocked)
				{
					list.Add(keyValuePair.Key);
				}
			}
			return list;
		}

		// Token: 0x060400CF RID: 262351 RVA: 0x0106AE04 File Offset: 0x01069004
		public bool IsPassed(int instId)
		{
			RoverRogueInsEntry roverRogueInsEntry;
			if (this.EntryById.TryGetValue(instId, out roverRogueInsEntry))
			{
				return this.IsGradePassed(new RoverRogueGrade?(roverRogueInsEntry.BestGrade));
			}
			return this.IsGradePassed(null);
		}

		// Token: 0x060400D0 RID: 262352 RVA: 0x0106AE42 File Offset: 0x01069042
		public List<RoverlikeLevelSelectItemData> GetItemDataList()
		{
			return (from cfg in this.GetSortedConfigs()
			select this.BuildItemData(cfg.InstId)).ToList<RoverlikeLevelSelectItemData>();
		}

		// Token: 0x060400D1 RID: 262353 RVA: 0x0106AE60 File Offset: 0x01069060
		[NullableContext(2)]
		public RoverlikeLevelSelectItemData GetItemData(int instId)
		{
			if (ConfigBase<RoverlikeConfig>.Instance.GetInsConfig(instId) == null)
			{
				return null;
			}
			return this.BuildItemData(instId);
		}

		// Token: 0x060400D2 RID: 262354 RVA: 0x0106AE8C File Offset: 0x0106908C
		public int GetDefaultSelectInstId()
		{
			List<RoverRogueIns> sortedConfigs = this.GetSortedConfigs();
			if (sortedConfigs.Count == 0)
			{
				return 0;
			}
			if (!this.LastEnterPassed && this.LastSelectedInstId > 0 && this.IsUnlocked(this.LastSelectedInstId))
			{
				return this.LastSelectedInstId;
			}
			int num = 0;
			foreach (RoverRogueIns roverRogueIns in sortedConfigs)
			{
				if (this.IsUnlocked(roverRogueIns.InstId))
				{
					num = roverRogueIns.InstId;
				}
			}
			if (num <= 0)
			{
				return sortedConfigs[0].InstId;
			}
			return num;
		}

		// Token: 0x060400D3 RID: 262355 RVA: 0x0106AF3C File Offset: 0x0106913C
		public int GetMaxLevelSortId()
		{
			List<RoverRogueIns> sortedConfigs = this.GetSortedConfigs();
			if (sortedConfigs.Count == 0)
			{
				return 0;
			}
			return sortedConfigs[sortedConfigs.Count - 1].SortId;
		}

		// Token: 0x060400D4 RID: 262356 RVA: 0x0106AF70 File Offset: 0x01069170
		private RoverlikeLevelSelectItemData BuildItemData(int instId)
		{
			RoverRogueInsEntry roverRogueInsEntry;
			bool flag = this.EntryById.TryGetValue(instId, out roverRogueInsEntry);
			return new RoverlikeLevelSelectItemData
			{
				InstId = instId,
				Unlocked = (flag && roverRogueInsEntry.Unlocked),
				Passed = this.IsGradePassed(flag ? new RoverRogueGrade?(roverRogueInsEntry.BestGrade) : null)
			};
		}

		// Token: 0x060400D5 RID: 262357 RVA: 0x0106AFD0 File Offset: 0x010691D0
		private List<RoverRogueIns> GetSortedConfigs()
		{
			List<RoverRogueIns> list = (from cfg in ConfigBase<RoverlikeConfig>.Instance.GetInsConfigList() ?? new List<RoverRogueIns>()
			where this.ActivityId <= 0 || cfg.ActivityId == this.ActivityId
			select cfg).ToList<RoverRogueIns>();
			list.Sort((RoverRogueIns a, RoverRogueIns b) => a.SortId - b.SortId);
			return list;
		}

		// Token: 0x060400D6 RID: 262358 RVA: 0x0106B02B File Offset: 0x0106922B
		private bool IsGradePassed(RoverRogueGrade? grade)
		{
			return grade != null && grade.Value > RoverRogueGrade.B;
		}

		// Token: 0x04023F5B RID: 147291
		public int ActivityId;

		// Token: 0x04023F5C RID: 147292
		public int LastSelectedInstId;

		// Token: 0x04023F5D RID: 147293
		public bool LastEnterPassed = true;

		// Token: 0x04023F5E RID: 147294
		public int SelectedLootId;

		// Token: 0x04023F5F RID: 147295
		public int SelectedLootLv;

		// Token: 0x04023F60 RID: 147296
		private readonly Dictionary<int, RoverRogueInsEntry> EntryById = new Dictionary<int, RoverRogueInsEntry>();

		// Token: 0x04023F61 RID: 147297
		private readonly Dictionary<int, int> SelectedRoleTypeByInst = new Dictionary<int, int>();
	}
}
