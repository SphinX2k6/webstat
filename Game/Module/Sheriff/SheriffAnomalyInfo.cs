using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Map;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FAC RID: 20396
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffAnomalyInfo
	{
		// Token: 0x06034A27 RID: 215591 RVA: 0x00D3443C File Offset: 0x00D3263C
		public void UpdateByProto(SheriffAnomalyInfo proto, int? zoneId = null)
		{
			if (zoneId != null)
			{
				this.ZoneId = zoneId.Value;
			}
			this.AnomalyId = proto.AnomalyId;
			this.ClueIds = ((proto.ClueIds != null) ? new List<int>(proto.ClueIds) : this.ClueIds);
			if (proto.ProgressIds != null)
			{
				this.DoProgressIdLogic(proto.ProgressIds.ToList<int>());
			}
			this.Progress = this.CalAnomalyProgress();
			this.EndingId = proto.EndingId;
			long num = proto.CompleteTime / 1000L;
			SheriffAnomaly? anomalyConfigById = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigById(this.AnomalyId);
			bool flag = anomalyConfigById == null || anomalyConfigById.GetValueOrDefault().MarkId != 0;
			this.NeedOpenReport = (this.HasInit && this.EndingTime == 0L && num != 0L && flag);
			this.HasInit = true;
			this.EndingTime = num;
			this.IsActivated = proto.IsActivated;
			SheriffAnomaly? anomalyConfigById2 = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigById(this.AnomalyId);
			this.CriminalId = ((anomalyConfigById2 != null) ? anomalyConfigById2.GetValueOrDefault().CriminalId : 0);
			this.MarkId = ((anomalyConfigById2 != null) ? anomalyConfigById2.GetValueOrDefault().MarkId : 0);
			this.IsUnlocked = proto.IsUnlocked;
			this.State = this.CalAnomalyState();
		}

		// Token: 0x06034A28 RID: 215592 RVA: 0x00D345A4 File Offset: 0x00D327A4
		protected void DoProgressIdLogic(List<int> progressIds)
		{
			this.ProgressIds.Clear();
			Dictionary<int, ValueTuple<int, int>> dictionary = new Dictionary<int, ValueTuple<int, int>>();
			HashSet<int> hashSet = new HashSet<int>();
			foreach (int num in progressIds)
			{
				SheriffProgress value = ConfigBase<SheriffConfig>.Instance.GetProgressConfigById(num).Value;
				if (value.GroupId != 0)
				{
					if (dictionary.ContainsKey(value.GroupId))
					{
						if (dictionary[value.GroupId].Item2 < value.GroupPriority)
						{
							dictionary[value.GroupId] = new ValueTuple<int, int>(num, value.GroupPriority);
						}
					}
					else
					{
						dictionary[value.GroupId] = new ValueTuple<int, int>(num, value.GroupPriority);
					}
				}
				else
				{
					hashSet.Add(num);
				}
			}
			foreach (KeyValuePair<int, ValueTuple<int, int>> keyValuePair in dictionary)
			{
				hashSet.Add(keyValuePair.Value.Item1);
			}
			foreach (int item in progressIds)
			{
				if (hashSet.Contains(item))
				{
					this.ProgressIds.Add(item);
				}
			}
		}

		// Token: 0x06034A29 RID: 215593 RVA: 0x00D3472C File Offset: 0x00D3292C
		private int CalAnomalyProgress()
		{
			int num = 0;
			foreach (int id in this.ProgressIds)
			{
				SheriffProgress? progressConfigById = ConfigBase<SheriffConfig>.Instance.GetProgressConfigById(id);
				if (progressConfigById != null)
				{
					num = Math.Max(num, progressConfigById.Value.Percent);
				}
			}
			return num;
		}

		// Token: 0x06034A2A RID: 215594 RVA: 0x00D347A8 File Offset: 0x00D329A8
		public ESheriffAnomalyState CalAnomalyState()
		{
			SheriffAnomaly? anomalyConfigById = ConfigBase<SheriffConfig>.Instance.GetAnomalyConfigById(this.AnomalyId);
			if (anomalyConfigById == null)
			{
				return ESheriffAnomalyState.Lock;
			}
			if (!this.IsUnlocked)
			{
				return ESheriffAnomalyState.Lock;
			}
			if (this.EndingTime > 0L)
			{
				return ESheriffAnomalyState.Completed;
			}
			bool flag = false;
			foreach (int markId in anomalyConfigById.Value.UnlockMarkIdsIter())
			{
				if (ModelBase<MapModel>.Instance.IsTeleportLocked(markId))
				{
					flag = true;
					break;
				}
			}
			if (!this.IsActivated && flag)
			{
				return ESheriffAnomalyState.UnActivated;
			}
			if (this.Progress == 0)
			{
				return ESheriffAnomalyState.UnOpened;
			}
			return ESheriffAnomalyState.Opened;
		}

		// Token: 0x0401E575 RID: 124277
		public int ZoneId;

		// Token: 0x0401E576 RID: 124278
		public int AnomalyId;

		// Token: 0x0401E577 RID: 124279
		public List<int> ClueIds = new List<int>();

		// Token: 0x0401E578 RID: 124280
		public List<int> ProgressIds = new List<int>();

		// Token: 0x0401E579 RID: 124281
		public int EndingId;

		// Token: 0x0401E57A RID: 124282
		public long EndingTime;

		// Token: 0x0401E57B RID: 124283
		public int Progress;

		// Token: 0x0401E57C RID: 124284
		public ESheriffAnomalyState State;

		// Token: 0x0401E57D RID: 124285
		public bool IsActivated;

		// Token: 0x0401E57E RID: 124286
		public int CriminalId;

		// Token: 0x0401E57F RID: 124287
		public bool IsUnlocked;

		// Token: 0x0401E580 RID: 124288
		public int MarkId;

		// Token: 0x0401E581 RID: 124289
		protected bool HasInit;

		// Token: 0x0401E582 RID: 124290
		public bool NeedOpenReport;
	}
}
