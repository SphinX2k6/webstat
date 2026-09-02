using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Capability
{
	// Token: 0x02007076 RID: 28790
	[NullableContext(1)]
	[Nullable(0)]
	public class CapabilityDebugger
	{
		// Token: 0x06045C5C RID: 285788 RVA: 0x01241662 File Offset: 0x0123F862
		public void SetEnabled(bool enabled)
		{
			this.Enabled = enabled;
		}

		// Token: 0x06045C5D RID: 285789 RVA: 0x0124166B File Offset: 0x0123F86B
		public bool IsEnabled()
		{
			return this.Enabled;
		}

		// Token: 0x06045C5E RID: 285790 RVA: 0x01241673 File Offset: 0x0123F873
		public void SetMaxRecords(int n)
		{
			if (n > 0)
			{
				this.MaxRecords = n;
			}
		}

		// Token: 0x06045C5F RID: 285791 RVA: 0x01241680 File Offset: 0x0123F880
		public void Clear()
		{
			this.Records.Clear();
			this.ClosedSpans.Clear();
			this.OpenSpans.Clear();
			this.NextSeq = 1;
		}

		// Token: 0x06045C60 RID: 285792 RVA: 0x012416AC File Offset: 0x0123F8AC
		public void LogEvent(double time, Capability cap, CapabilityCommonDefine.ECapabilityDebugEvent @event, [Nullable(2)] string detail = null, double? durationMs = null)
		{
			if (!this.Enabled)
			{
				return;
			}
			CapabilityDebugRecord capabilityDebugRecord = new CapabilityDebugRecord();
			int nextSeq = this.NextSeq;
			this.NextSeq = nextSeq + 1;
			capabilityDebugRecord.Seq = nextSeq;
			capabilityDebugRecord.Time = time;
			capabilityDebugRecord.Event = @event;
			capabilityDebugRecord.CapabilityId = cap.GetCapabilityId();
			ICapabilityGameObject ownerGameObject = cap.OwnerGameObject;
			capabilityDebugRecord.GameObjectId = (((ownerGameObject != null) ? ownerGameObject.GetId() : null) ?? "");
			capabilityDebugRecord.ClassName = cap.GetType().Name;
			capabilityDebugRecord.Detail = detail;
			capabilityDebugRecord.DurationMs = durationMs;
			CapabilityDebugRecord item = capabilityDebugRecord;
			this.Records.Add(item);
			if (this.Records.Count > this.MaxRecords)
			{
				this.Records.RemoveAt(0);
			}
		}

		// Token: 0x06045C61 RID: 285793 RVA: 0x01241768 File Offset: 0x0123F968
		public void BeginActiveSpan(double time, Capability cap)
		{
			if (!this.Enabled)
			{
				return;
			}
			string capabilityId = cap.GetCapabilityId();
			if (this.OpenSpans.ContainsKey(capabilityId))
			{
				return;
			}
			CapabilityDebugActiveSpan capabilityDebugActiveSpan = new CapabilityDebugActiveSpan();
			capabilityDebugActiveSpan.CapabilityId = capabilityId;
			ICapabilityGameObject ownerGameObject = cap.OwnerGameObject;
			capabilityDebugActiveSpan.GameObjectId = (((ownerGameObject != null) ? ownerGameObject.GetId() : null) ?? "");
			capabilityDebugActiveSpan.ClassName = cap.GetType().Name;
			capabilityDebugActiveSpan.StartTime = time;
			capabilityDebugActiveSpan.EndTime = -1.0;
			CapabilityDebugActiveSpan value = capabilityDebugActiveSpan;
			this.OpenSpans[capabilityId] = value;
		}

		// Token: 0x06045C62 RID: 285794 RVA: 0x012417F8 File Offset: 0x0123F9F8
		public void EndActiveSpan(double time, Capability cap)
		{
			if (!this.Enabled)
			{
				return;
			}
			string capabilityId = cap.GetCapabilityId();
			ICapabilityDebugActiveSpan capabilityDebugActiveSpan;
			if (!this.OpenSpans.TryGetValue(capabilityId, out capabilityDebugActiveSpan))
			{
				return;
			}
			capabilityDebugActiveSpan.EndTime = time;
			this.ClosedSpans.Add(capabilityDebugActiveSpan);
			this.OpenSpans.Remove(capabilityId);
			if (this.ClosedSpans.Count > this.MaxRecords)
			{
				this.ClosedSpans.RemoveAt(0);
			}
		}

		// Token: 0x06045C63 RID: 285795 RVA: 0x01241865 File Offset: 0x0123FA65
		public IReadOnlyList<ICapabilityDebugRecord> GetRecords()
		{
			return this.Records;
		}

		// Token: 0x06045C64 RID: 285796 RVA: 0x0124186D File Offset: 0x0123FA6D
		public IReadOnlyList<ICapabilityDebugActiveSpan> GetClosedSpans()
		{
			return this.ClosedSpans;
		}

		// Token: 0x06045C65 RID: 285797 RVA: 0x01241875 File Offset: 0x0123FA75
		public IEnumerable<ICapabilityDebugActiveSpan> GetOpenSpans()
		{
			return this.OpenSpans.Values;
		}

		// Token: 0x06045C66 RID: 285798 RVA: 0x01241884 File Offset: 0x0123FA84
		public List<ICapabilityDebugActiveSpan> QuerySpansInRange(float startTime, float endTime)
		{
			List<ICapabilityDebugActiveSpan> list = new List<ICapabilityDebugActiveSpan>();
			foreach (ICapabilityDebugActiveSpan capabilityDebugActiveSpan in this.ClosedSpans)
			{
				if (capabilityDebugActiveSpan.EndTime >= (double)startTime && capabilityDebugActiveSpan.StartTime <= (double)endTime)
				{
					list.Add(capabilityDebugActiveSpan);
				}
			}
			foreach (ICapabilityDebugActiveSpan capabilityDebugActiveSpan2 in this.OpenSpans.Values)
			{
				if (capabilityDebugActiveSpan2.StartTime <= (double)endTime)
				{
					list.Add(capabilityDebugActiveSpan2);
				}
			}
			return list;
		}

		// Token: 0x06045C67 RID: 285799 RVA: 0x01241948 File Offset: 0x0123FB48
		public List<ICapabilityDebugRecord> QueryRecordsInRange(float startTime, float endTime)
		{
			List<ICapabilityDebugRecord> list = new List<ICapabilityDebugRecord>();
			foreach (ICapabilityDebugRecord capabilityDebugRecord in this.Records)
			{
				if (capabilityDebugRecord.Time >= (double)startTime && capabilityDebugRecord.Time <= (double)endTime)
				{
					list.Add(capabilityDebugRecord);
				}
			}
			return list;
		}

		// Token: 0x06045C68 RID: 285800 RVA: 0x012419B8 File Offset: 0x0123FBB8
		public List<string> CollectAllCapabilityIds()
		{
			HashSet<string> hashSet = new HashSet<string>();
			List<string> list = new List<string>();
			foreach (ICapabilityDebugActiveSpan capabilityDebugActiveSpan in this.ClosedSpans)
			{
				if (!hashSet.Contains(capabilityDebugActiveSpan.CapabilityId))
				{
					hashSet.Add(capabilityDebugActiveSpan.CapabilityId);
					list.Add(capabilityDebugActiveSpan.CapabilityId);
				}
			}
			foreach (ICapabilityDebugActiveSpan capabilityDebugActiveSpan2 in this.OpenSpans.Values)
			{
				if (!hashSet.Contains(capabilityDebugActiveSpan2.CapabilityId))
				{
					hashSet.Add(capabilityDebugActiveSpan2.CapabilityId);
					list.Add(capabilityDebugActiveSpan2.CapabilityId);
				}
			}
			foreach (ICapabilityDebugRecord capabilityDebugRecord in this.Records)
			{
				if (!hashSet.Contains(capabilityDebugRecord.CapabilityId))
				{
					hashSet.Add(capabilityDebugRecord.CapabilityId);
					list.Add(capabilityDebugRecord.CapabilityId);
				}
			}
			return list;
		}

		// Token: 0x0402708E RID: 159886
		private bool Enabled = true;

		// Token: 0x0402708F RID: 159887
		private readonly List<ICapabilityDebugRecord> Records = new List<ICapabilityDebugRecord>();

		// Token: 0x04027090 RID: 159888
		private int MaxRecords = 5000;

		// Token: 0x04027091 RID: 159889
		private readonly Dictionary<string, ICapabilityDebugActiveSpan> OpenSpans = new Dictionary<string, ICapabilityDebugActiveSpan>();

		// Token: 0x04027092 RID: 159890
		private readonly List<ICapabilityDebugActiveSpan> ClosedSpans = new List<ICapabilityDebugActiveSpan>();

		// Token: 0x04027093 RID: 159891
		private int NextSeq = 1;
	}
}
