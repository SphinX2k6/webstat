using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;

// Token: 0x0200225B RID: 8795
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class MarqueeModel : ModelBase<MarqueeModel>
{
	// Token: 0x1700147D RID: 5245
	// (get) Token: 0x0601095A RID: 67930 RVA: 0x00488C19 File Offset: 0x00486E19
	// (set) Token: 0x0601095B RID: 67931 RVA: 0x00488C21 File Offset: 0x00486E21
	[Nullable(2)]
	public TimerHandle TimerId
	{
		[NullableContext(2)]
		get
		{
			return this.TimerIdInternal;
		}
		[NullableContext(2)]
		set
		{
			this.TimerIdInternal = value;
		}
	}

	// Token: 0x1700147E RID: 5246
	// (get) Token: 0x0601095C RID: 67932 RVA: 0x00488C2A File Offset: 0x00486E2A
	// (set) Token: 0x0601095D RID: 67933 RVA: 0x00488C32 File Offset: 0x00486E32
	[Nullable(2)]
	public MarqueeData CurMarquee
	{
		[NullableContext(2)]
		get
		{
			return this.CurMarqueeInternal;
		}
		[NullableContext(2)]
		set
		{
			this.CurMarqueeInternal = value;
		}
	}

	// Token: 0x1700147F RID: 5247
	// (get) Token: 0x0601095E RID: 67934 RVA: 0x00488C3B File Offset: 0x00486E3B
	public List<MarqueeData> MarqueeQueue
	{
		get
		{
			return this.MarqueeQueueInternal;
		}
	}

	// Token: 0x0601095F RID: 67935 RVA: 0x00488C43 File Offset: 0x00486E43
	protected override bool OnClear()
	{
		this.RemoveAllMarqueeData();
		this.SeverMarqueeStorageDataMap.Clear();
		this.ClientMarqueeStorageDataMap.Clear();
		if (this.TimerId != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerId);
			this.TimerId = null;
		}
		return true;
	}

	// Token: 0x06010960 RID: 67936 RVA: 0x00488C82 File Offset: 0x00486E82
	public void InitMarqueeStorageDataMap()
	{
		this.SeverMarqueeStorageDataMap = (LocalStorage.GetPlayer<Dictionary<string, MarqueeStorageData>>(ELocalStoragePlayerKey.MarqueeScrollingMap, null) ?? new Dictionary<string, MarqueeStorageData>());
	}

	// Token: 0x06010961 RID: 67937 RVA: 0x00488C9C File Offset: 0x00486E9C
	public void AddOrUpdateMarqueeDate(MarqueeData data)
	{
		if (!data.IsClientMarquee && !data.CheckPlatformAndChannelIfShow())
		{
			return;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		if (data.EndTime <= serverTime)
		{
			return;
		}
		if (this.GetScrollingTime(data) >= data.ScrollTimes)
		{
			return;
		}
		int num = -1;
		for (int i = 0; i < this.MarqueeQueueInternal.Count; i++)
		{
			if (this.MarqueeQueueInternal[i].Id == data.Id)
			{
				num = i;
			}
		}
		if (num >= 0)
		{
			this.MarqueeQueueInternal[num] = data;
			if (num == 0)
			{
				this.CurMarqueeInternal = data;
			}
		}
		else
		{
			this.MarqueeQueueInternal.Add(data);
		}
		this.AddOrUpdateMarqueeStorageData(data);
		this.CleanMarqueeStorageDataMap(serverTime);
		this.SaveMarqueeStorageDataMap();
	}

	// Token: 0x06010962 RID: 67938 RVA: 0x00488D58 File Offset: 0x00486F58
	public void CleanMarqueeStorageDataMap(double serverTime)
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, MarqueeStorageData> keyValuePair in this.SeverMarqueeStorageDataMap)
		{
			if (keyValuePair.Value.EndTime <= serverTime)
			{
				list.Add(keyValuePair.Key);
			}
		}
		foreach (string key in list)
		{
			this.SeverMarqueeStorageDataMap.Remove(key);
		}
		list.Clear();
		foreach (KeyValuePair<string, MarqueeStorageData> keyValuePair2 in this.ClientMarqueeStorageDataMap)
		{
			if (keyValuePair2.Value.EndTime <= serverTime)
			{
				list.Add(keyValuePair2.Key);
			}
		}
		foreach (string key2 in list)
		{
			this.ClientMarqueeStorageDataMap.Remove(key2);
		}
	}

	// Token: 0x06010963 RID: 67939 RVA: 0x00488EB0 File Offset: 0x004870B0
	public void UpdateMarqueeStorageDataByDate(MarqueeData data)
	{
		MarqueeStorageData marqueeStorageData = this.GetMarqueeStorageData(data);
		if (marqueeStorageData == null)
		{
			marqueeStorageData = this.AddOrUpdateMarqueeStorageData(data);
		}
		marqueeStorageData.ScrollingTime++;
		this.SaveMarqueeStorageDataMap();
	}

	// Token: 0x06010964 RID: 67940 RVA: 0x00488EE4 File Offset: 0x004870E4
	public int GetScrollingTime(MarqueeData data)
	{
		MarqueeStorageData marqueeStorageData = this.GetMarqueeStorageData(data);
		if (marqueeStorageData == null)
		{
			return 0;
		}
		return marqueeStorageData.ScrollingTime;
	}

	// Token: 0x06010965 RID: 67941 RVA: 0x00488EF8 File Offset: 0x004870F8
	[return: Nullable(2)]
	public MarqueeStorageData GetMarqueeStorageData(MarqueeData data)
	{
		if (!data.IsClientMarquee)
		{
			MarqueeStorageData result;
			if (!this.SeverMarqueeStorageDataMap.TryGetValue(data.Id, out result))
			{
				return null;
			}
			return result;
		}
		else
		{
			MarqueeStorageData result2;
			if (!this.ClientMarqueeStorageDataMap.TryGetValue(data.Id, out result2))
			{
				return null;
			}
			return result2;
		}
	}

	// Token: 0x06010966 RID: 67942 RVA: 0x00488F40 File Offset: 0x00487140
	private MarqueeStorageData AddOrUpdateMarqueeStorageData(MarqueeData data)
	{
		MarqueeStorageData marqueeStorageData = this.GetMarqueeStorageData(data);
		if (marqueeStorageData == null)
		{
			marqueeStorageData = new MarqueeStorageData(data.EndTime);
			if (data.IsClientMarquee)
			{
				this.ClientMarqueeStorageDataMap[data.Id] = marqueeStorageData;
			}
			else
			{
				this.SeverMarqueeStorageDataMap[data.Id] = marqueeStorageData;
			}
		}
		else
		{
			marqueeStorageData.EndTime = data.EndTime;
		}
		return marqueeStorageData;
	}

	// Token: 0x06010967 RID: 67943 RVA: 0x00488FA1 File Offset: 0x004871A1
	private void SaveMarqueeStorageDataMap()
	{
		LocalStorage.SetPlayer<Dictionary<string, MarqueeStorageData>>(ELocalStoragePlayerKey.MarqueeScrollingMap, this.SeverMarqueeStorageDataMap);
	}

	// Token: 0x06010968 RID: 67944 RVA: 0x00488FB1 File Offset: 0x004871B1
	[NullableContext(2)]
	public MarqueeData PeekMarqueeData()
	{
		if (this.MarqueeQueueInternal == null || this.MarqueeQueueInternal.Count <= 0)
		{
			return null;
		}
		return this.MarqueeQueueInternal[0];
	}

	// Token: 0x06010969 RID: 67945 RVA: 0x00488FD7 File Offset: 0x004871D7
	[NullableContext(2)]
	public MarqueeData GetNextMarquee()
	{
		if (this.MarqueeQueueInternal == null || this.MarqueeQueueInternal.Count <= 1)
		{
			return null;
		}
		return this.MarqueeQueueInternal[1];
	}

	// Token: 0x0601096A RID: 67946 RVA: 0x00489000 File Offset: 0x00487200
	[NullableContext(2)]
	public MarqueeData RemoveMarqueeData(string incId)
	{
		for (int i = 0; i < this.MarqueeQueueInternal.Count; i++)
		{
			MarqueeData marqueeData = this.MarqueeQueueInternal[i];
			if (marqueeData.Id == incId)
			{
				this.MarqueeQueueInternal.RemoveAt(i);
				return marqueeData;
			}
		}
		return null;
	}

	// Token: 0x0601096B RID: 67947 RVA: 0x0048904D File Offset: 0x0048724D
	public void RemoveAllMarqueeData()
	{
		this.CurMarqueeInternal = null;
		this.MarqueeQueueInternal = new List<MarqueeData>();
	}

	// Token: 0x0601096C RID: 67948 RVA: 0x00489064 File Offset: 0x00487264
	public void RemoveServerMarqueeData()
	{
		this.CurMarqueeInternal = null;
		List<MarqueeData> list = new List<MarqueeData>();
		foreach (MarqueeData marqueeData in this.MarqueeQueueInternal)
		{
			if (marqueeData.IsClientMarquee)
			{
				list.Add(marqueeData);
			}
		}
		this.MarqueeQueueInternal = list;
	}

	// Token: 0x0601096D RID: 67949 RVA: 0x004890D4 File Offset: 0x004872D4
	public void SortMarqueeQueue()
	{
		List<MarqueeData> marqueeQueueInternal = this.MarqueeQueueInternal;
		if (marqueeQueueInternal == null)
		{
			return;
		}
		marqueeQueueInternal.Sort((MarqueeData a, MarqueeData b) => a.BeginTime.CompareTo(b.BeginTime));
	}

	// Token: 0x0601096E RID: 67950 RVA: 0x00489108 File Offset: 0x00487308
	public double GetMarqueeDataLeftTime(MarqueeData data)
	{
		double num = data.EndTime - Singleton<TimeUtil>.Instance.GetServerTime();
		if (num <= 0.0)
		{
			num = 1.0;
		}
		return num;
	}

	// Token: 0x0400829B RID: 33435
	[Nullable(2)]
	private TimerHandle TimerIdInternal;

	// Token: 0x0400829C RID: 33436
	[Nullable(2)]
	private MarqueeData CurMarqueeInternal;

	// Token: 0x0400829D RID: 33437
	private List<MarqueeData> MarqueeQueueInternal = new List<MarqueeData>();

	// Token: 0x0400829E RID: 33438
	private Dictionary<string, MarqueeStorageData> SeverMarqueeStorageDataMap = new Dictionary<string, MarqueeStorageData>();

	// Token: 0x0400829F RID: 33439
	private readonly Dictionary<string, MarqueeStorageData> ClientMarqueeStorageDataMap = new Dictionary<string, MarqueeStorageData>();
}
