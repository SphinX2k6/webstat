using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;

// Token: 0x02002C12 RID: 11282
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class TrackModel : ModelBase<TrackModel>
{
	// Token: 0x17001DA3 RID: 7587
	// (get) Token: 0x0601684E RID: 92238 RVA: 0x00641B63 File Offset: 0x0063FD63
	// (set) Token: 0x0601684F RID: 92239 RVA: 0x00641B6B File Offset: 0x0063FD6B
	public int DefaultTrackHideDis { get; private set; }

	// Token: 0x06016850 RID: 92240 RVA: 0x00641B74 File Offset: 0x0063FD74
	protected override bool OnInit()
	{
		this.TrackInfos = new Dictionary<int, Dictionary<int, ITrackData>>();
		this.ShowGroup = new Dictionary<int, Dictionary<int, ITrackData>>();
		this.GroupMinDistance = new Dictionary<int, double>();
		this.DefaultTrackHideDis = int.Parse(ConfigBase<QuestNewConfig>.Instance.GetGlobalConfig("TrackMarkHideDis"));
		return true;
	}

	// Token: 0x06016851 RID: 92241 RVA: 0x00641BB4 File Offset: 0x0063FDB4
	protected override bool OnClear()
	{
		if (this.TrackInfos != null)
		{
			this.TrackInfos.Clear();
			this.TrackInfos = null;
		}
		if (this.ShowGroup != null)
		{
			this.ShowGroup.Clear();
			this.ShowGroup = null;
		}
		if (this.GroupMinDistance != null)
		{
			this.GroupMinDistance.Clear();
			this.GroupMinDistance = null;
		}
		return true;
	}

	// Token: 0x06016852 RID: 92242 RVA: 0x00641C10 File Offset: 0x0063FE10
	protected override bool OnLeaveLevel()
	{
		return true;
	}

	// Token: 0x06016853 RID: 92243 RVA: 0x00641C14 File Offset: 0x0063FE14
	public void AddTrackData(ITrackData data)
	{
		Dictionary<int, ITrackData> dictionary = this.GetTracksByType(data.TrackSource);
		if (dictionary == null)
		{
			dictionary = new Dictionary<int, ITrackData>();
			this.TrackInfos[(int)data.TrackSource] = dictionary;
		}
		float? trackHideDis = data.TrackHideDis;
		float num = 0f;
		if (trackHideDis.GetValueOrDefault() == num & trackHideDis != null)
		{
			data.TrackHideDis = new float?((float)this.DefaultTrackHideDis);
		}
		dictionary[data.Id] = data;
		this.AddTrackToGroup(data);
	}

	// Token: 0x06016854 RID: 92244 RVA: 0x00641C90 File Offset: 0x0063FE90
	public void RemoveTrackData(ETrackSource type, int id)
	{
		Dictionary<int, ITrackData> tracksByType = this.GetTracksByType(type);
		if (tracksByType == null)
		{
			return;
		}
		ITrackData data;
		if (tracksByType.TryGetValue(id, out data))
		{
			tracksByType.Remove(id);
			this.RemoveTrackFromGroup(data);
		}
	}

	// Token: 0x06016855 RID: 92245 RVA: 0x00641CC3 File Offset: 0x0063FEC3
	public void ClearTrackData()
	{
		this.TrackInfos.Clear();
		this.ShowGroup.Clear();
		Singleton<EventSystem>.Instance.Emit(EEventName.ClearTrackMark);
	}

	// Token: 0x06016856 RID: 92246 RVA: 0x00641CEC File Offset: 0x0063FEEC
	private void AddTrackToGroup(ITrackData data)
	{
		int? showGroupId = data.ShowGroupId;
		int num = 0;
		if (showGroupId.GetValueOrDefault() == num & showGroupId != null)
		{
			return;
		}
		Dictionary<int, ITrackData> dictionary;
		if (!this.ShowGroup.TryGetValue(data.ShowGroupId.GetValueOrDefault(), out dictionary))
		{
			dictionary = new Dictionary<int, ITrackData>();
			this.ShowGroup[data.ShowGroupId.GetValueOrDefault()] = dictionary;
		}
		dictionary[data.Id] = data;
	}

	// Token: 0x06016857 RID: 92247 RVA: 0x00641D64 File Offset: 0x0063FF64
	private void RemoveTrackFromGroup(ITrackData data)
	{
		int? showGroupId = data.ShowGroupId;
		int num = 0;
		if (showGroupId.GetValueOrDefault() == num & showGroupId != null)
		{
			return;
		}
		Dictionary<int, ITrackData> dictionary;
		if (this.ShowGroup.TryGetValue(data.ShowGroupId.GetValueOrDefault(), out dictionary))
		{
			dictionary.Remove(data.Id);
		}
	}

	// Token: 0x06016858 RID: 92248 RVA: 0x00641DBC File Offset: 0x0063FFBC
	[return: Nullable(2)]
	public ITrackData IsTargetTracking(TTrackTarget target)
	{
		ETrackSource? etrackSource = null;
		ITrackData result = null;
		foreach (KeyValuePair<int, Dictionary<int, ITrackData>> keyValuePair in this.TrackInfos)
		{
			foreach (KeyValuePair<int, ITrackData> keyValuePair2 in keyValuePair.Value)
			{
				ITrackData value = keyValuePair2.Value;
				if (object.Equals(value.TrackTarget, target))
				{
					if (etrackSource == null)
					{
						etrackSource = new ETrackSource?((ETrackSource)keyValuePair.Key);
						result = value;
					}
					else if (keyValuePair.Key > (int)etrackSource.Value)
					{
						result = value;
						etrackSource = new ETrackSource?((ETrackSource)keyValuePair.Key);
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06016859 RID: 92249 RVA: 0x00641EAC File Offset: 0x006400AC
	[NullableContext(2)]
	public ITrackData GetTrackData(ETrackSource type, int id)
	{
		Dictionary<int, ITrackData> tracksByType = this.GetTracksByType(type);
		if (tracksByType == null)
		{
			return null;
		}
		return tracksByType.GetValueOrDefault(id);
	}

	// Token: 0x0601685A RID: 92250 RVA: 0x00641ED0 File Offset: 0x006400D0
	public void UpdateTrackData(ETrackSource type, int id, TTrackTarget newTrackTarget)
	{
		ITrackData trackData = this.GetTrackData(type, id);
		if (trackData == null)
		{
			return;
		}
		trackData.TrackTarget = newTrackTarget;
		Singleton<EventSystem>.Instance.Emit<ETrackSource, int, TTrackTarget>(EEventName.UpdateTrackTarget, type, id, newTrackTarget);
	}

	// Token: 0x0601685B RID: 92251 RVA: 0x00641F04 File Offset: 0x00640104
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, ITrackData> GetTracksByType(ETrackSource type)
	{
		Dictionary<int, Dictionary<int, ITrackData>> trackInfos = this.TrackInfos;
		if (trackInfos == null)
		{
			return null;
		}
		return trackInfos.GetValueOrDefault((int)type);
	}

	// Token: 0x0601685C RID: 92252 RVA: 0x00641F18 File Offset: 0x00640118
	public bool IsTracking(ETrackSource type, int id)
	{
		if (type == ETrackSource.None || id == 0)
		{
			return false;
		}
		Dictionary<int, ITrackData> tracksByType = this.GetTracksByType(type);
		return tracksByType != null && tracksByType.ContainsKey(id);
	}

	// Token: 0x0601685D RID: 92253 RVA: 0x00641F44 File Offset: 0x00640144
	public void UpdateGroupMinDistance(int groupId, double trackDistance)
	{
		if (this.GroupMinDistance == null || groupId == 0)
		{
			return;
		}
		double num;
		if (this.GroupMinDistance.TryGetValue(groupId, out num))
		{
			if (trackDistance <= num)
			{
				this.GroupMinDistance[groupId] = trackDistance;
				return;
			}
		}
		else
		{
			this.GroupMinDistance[groupId] = trackDistance;
		}
	}

	// Token: 0x0601685E RID: 92254 RVA: 0x00641F8C File Offset: 0x0064018C
	public bool CanShowInGroup(int groupId, double trackDistance)
	{
		double num;
		return this.GroupMinDistance == null || groupId == 0 || !this.GroupMinDistance.TryGetValue(groupId, out num) || trackDistance <= num;
	}

	// Token: 0x0601685F RID: 92255 RVA: 0x00641FBF File Offset: 0x006401BF
	public void ClearGroupMinDistance()
	{
		Dictionary<int, double> groupMinDistance = this.GroupMinDistance;
		if (groupMinDistance == null)
		{
			return;
		}
		groupMinDistance.Clear();
	}

	// Token: 0x06016860 RID: 92256 RVA: 0x00641FD1 File Offset: 0x006401D1
	public bool IsForceCloseTracked()
	{
		return this.ForceCloseTracked;
	}

	// Token: 0x06016861 RID: 92257 RVA: 0x00641FD9 File Offset: 0x006401D9
	public void SetForceCloseTracked(bool close)
	{
		this.ForceCloseTracked = close;
	}

	// Token: 0x0400AE30 RID: 44592
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<int, Dictionary<int, ITrackData>> TrackInfos;

	// Token: 0x0400AE31 RID: 44593
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<int, Dictionary<int, ITrackData>> ShowGroup;

	// Token: 0x0400AE32 RID: 44594
	[Nullable(2)]
	private Dictionary<int, double> GroupMinDistance;

	// Token: 0x0400AE34 RID: 44596
	private bool ForceCloseTracked;
}
