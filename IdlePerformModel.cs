using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001FD6 RID: 8150
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class IdlePerformModel : ModelBase<IdlePerformModel>
{
	// Token: 0x0600F5FC RID: 62972 RVA: 0x00435C9F File Offset: 0x00433E9F
	public void AccumulateIdleTime(float delta)
	{
		if (delta <= 0f)
		{
			return;
		}
		this.IdleTimeInternal += delta;
	}

	// Token: 0x0600F5FD RID: 62973 RVA: 0x00435CB8 File Offset: 0x00433EB8
	public void ResetIdleTime()
	{
		this.IdleTimeInternal = 0f;
	}

	// Token: 0x0600F5FE RID: 62974 RVA: 0x00435CC5 File Offset: 0x00433EC5
	public float GetIdleTime()
	{
		return this.IdleTimeInternal;
	}

	// Token: 0x0600F5FF RID: 62975 RVA: 0x00435CCD File Offset: 0x00433ECD
	public bool IsIdle()
	{
		return this.IdleTimeInternal > 0f;
	}

	// Token: 0x0600F600 RID: 62976 RVA: 0x00435CDC File Offset: 0x00433EDC
	protected override bool OnInit()
	{
		this.IdleTimeInternal = 0f;
		this.GazeAwarenessDataMap.Clear();
		this.AiNoMoveDataMap.Clear();
		this.AiSearchWanderPointDataMap.Clear();
		return true;
	}

	// Token: 0x0600F601 RID: 62977 RVA: 0x00435D0B File Offset: 0x00433F0B
	protected override bool OnClear()
	{
		this.IdleTimeInternal = 0f;
		this.GazeAwarenessDataMap.Clear();
		this.AiNoMoveDataMap.Clear();
		this.AiSearchWanderPointDataMap.Clear();
		return true;
	}

	// Token: 0x0600F602 RID: 62978 RVA: 0x00435D3A File Offset: 0x00433F3A
	public void OnTick(float delta)
	{
		if (delta <= 0f)
		{
			return;
		}
		this.AccumulateIdleTime(delta);
		this.AccumulatePlayerGazeTime(delta);
		this.TickAiNoMoveData();
		this.TickAiSearchWanderPointData();
	}

	// Token: 0x0600F603 RID: 62979 RVA: 0x00435D60 File Offset: 0x00433F60
	public void StartGazeAwarenessCheckByEntityId(int entityId, float awarenessAngle, float awarenessDistance, float awarenessHeight, float playerGazeAngle, bool enableDebugDraw = false)
	{
		if (this.GazeAwarenessDataMap.ContainsKey(entityId))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.ZJL;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(43, 1);
			defaultInterpolatedStringHandler.AppendLiteral("[IdlePerform] 已经存在 EntityId=");
			defaultInterpolatedStringHandler.AppendFormatted<int>(entityId);
			defaultInterpolatedStringHandler.AppendLiteral(" 的注视感知数据，无法重复添加");
			instance.Warn(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		IdleGazeAwarenessData value = new IdleGazeAwarenessData(entityId, awarenessAngle, awarenessDistance, awarenessHeight, playerGazeAngle, enableDebugDraw);
		this.GazeAwarenessDataMap[entityId] = value;
	}

	// Token: 0x0600F604 RID: 62980 RVA: 0x00435DE0 File Offset: 0x00433FE0
	public void StopGazeAwarenessCheckByEntityId(int entityId)
	{
		if (!this.GazeAwarenessDataMap.ContainsKey(entityId))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.ZJL;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 1);
			defaultInterpolatedStringHandler.AppendLiteral("[IdlePerform] 不存在 EntityId=");
			defaultInterpolatedStringHandler.AppendFormatted<int>(entityId);
			defaultInterpolatedStringHandler.AppendLiteral(" 的注视感知数据，无法移除");
			instance.Warn(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.GazeAwarenessDataMap.Remove(entityId);
	}

	// Token: 0x0600F605 RID: 62981 RVA: 0x00435E54 File Offset: 0x00434054
	public bool CheckGazeAwarenessByEntityId(int entityId, float time)
	{
		IdleGazeAwarenessData idleGazeAwarenessData;
		if (!this.GazeAwarenessDataMap.TryGetValue(entityId, out idleGazeAwarenessData))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.ZJL;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 1);
			defaultInterpolatedStringHandler.AppendLiteral("[IdlePerform] 不存在 EntityId=");
			defaultInterpolatedStringHandler.AppendFormatted<int>(entityId);
			defaultInterpolatedStringHandler.AppendLiteral(" 的注视感知数据，无法检查");
			instance.Warn(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		return idleGazeAwarenessData.CheckPlayerGazeTime(time);
	}

	// Token: 0x0600F606 RID: 62982 RVA: 0x00435EC4 File Offset: 0x004340C4
	public void AccumulatePlayerGazeTime(float delta)
	{
		if (delta <= 0f)
		{
			return;
		}
		foreach (IdleGazeAwarenessData idleGazeAwarenessData in this.GazeAwarenessDataMap.Values)
		{
			idleGazeAwarenessData.Tick(delta);
		}
	}

	// Token: 0x0600F607 RID: 62983 RVA: 0x00435F24 File Offset: 0x00434124
	public void TickAiNoMoveData()
	{
		List<int> list = null;
		foreach (AiNoMoveData aiNoMoveData in this.AiNoMoveDataMap.Values)
		{
			if (!aiNoMoveData.Tick())
			{
				if (list == null)
				{
					list = new List<int>();
				}
				list.Add(aiNoMoveData.EntityId);
			}
		}
		if (list != null)
		{
			foreach (int key in list)
			{
				this.AiNoMoveDataMap.Remove(key);
			}
		}
	}

	// Token: 0x0600F608 RID: 62984 RVA: 0x00435FDC File Offset: 0x004341DC
	internal AiNoMoveData GetOrCreateAiNoMoveData(int entityId)
	{
		AiNoMoveData aiNoMoveData;
		if (!this.AiNoMoveDataMap.TryGetValue(entityId, out aiNoMoveData))
		{
			aiNoMoveData = new AiNoMoveData(entityId);
			this.AiNoMoveDataMap[entityId] = aiNoMoveData;
			aiNoMoveData.Tick();
		}
		return aiNoMoveData;
	}

	// Token: 0x0600F609 RID: 62985 RVA: 0x00436018 File Offset: 0x00434218
	public void ResetAiNoMoveTime(int entityId)
	{
		AiNoMoveData aiNoMoveData;
		if (!this.AiNoMoveDataMap.TryGetValue(entityId, out aiNoMoveData))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[IdlePerform] AI无移动数据，无法重置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", entityId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		aiNoMoveData.ResetTime();
	}

	// Token: 0x0600F60A RID: 62986 RVA: 0x00436068 File Offset: 0x00434268
	public bool CheckAiNoMoveTime(int entityId, float timeMs)
	{
		return this.GetOrCreateAiNoMoveData(entityId).GetNoMoveTime() >= (double)timeMs;
	}

	// Token: 0x0600F60B RID: 62987 RVA: 0x00436080 File Offset: 0x00434280
	public void TickAiSearchWanderPointData()
	{
		List<int> list = null;
		foreach (int num in this.AiSearchWanderPointDataMap.Keys)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(num);
			if (entity == null || !entity.Valid)
			{
				if (list == null)
				{
					list = new List<int>();
				}
				list.Add(num);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.AI;
				ELogAuthor author = ELogAuthor.ZJL;
				string message = "[IdlePerform] AI搜索漫游点数据，实体已失效，移除数据";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", num);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
		if (list != null)
		{
			foreach (int key in list)
			{
				this.AiSearchWanderPointDataMap.Remove(key);
			}
		}
	}

	// Token: 0x0600F60C RID: 62988 RVA: 0x00436174 File Offset: 0x00434374
	public void AddAiSearchedWanderPointId(int entityId, int wanderPointId)
	{
		AiSearchWanderPointData aiSearchWanderPointData;
		if (!this.AiSearchWanderPointDataMap.TryGetValue(entityId, out aiSearchWanderPointData))
		{
			aiSearchWanderPointData = new AiSearchWanderPointData();
			this.AiSearchWanderPointDataMap[entityId] = aiSearchWanderPointData;
		}
		aiSearchWanderPointData.AddSearchedWanderPointId(wanderPointId);
	}

	// Token: 0x0600F60D RID: 62989 RVA: 0x004361AC File Offset: 0x004343AC
	public void ClearAiSearchedWanderPointIdSet(int entityId)
	{
		AiSearchWanderPointData aiSearchWanderPointData;
		if (!this.AiSearchWanderPointDataMap.TryGetValue(entityId, out aiSearchWanderPointData))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[IdlePerform] AI搜索漫游点数据，实体不存在，无法清空数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", entityId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		aiSearchWanderPointData.ClearSearchedWanderPointIdSet();
	}

	// Token: 0x0600F60E RID: 62990 RVA: 0x004361FC File Offset: 0x004343FC
	public bool HasAiSearchedWanderPointId(int entityId, int wanderPointId)
	{
		AiSearchWanderPointData aiSearchWanderPointData;
		return this.AiSearchWanderPointDataMap.TryGetValue(entityId, out aiSearchWanderPointData) && aiSearchWanderPointData.HasSearchedWanderPointId(wanderPointId);
	}

	// Token: 0x040076F8 RID: 30456
	private float IdleTimeInternal;

	// Token: 0x040076F9 RID: 30457
	private Dictionary<int, IdleGazeAwarenessData> GazeAwarenessDataMap = new Dictionary<int, IdleGazeAwarenessData>();

	// Token: 0x040076FA RID: 30458
	private Dictionary<int, AiNoMoveData> AiNoMoveDataMap = new Dictionary<int, AiNoMoveData>();

	// Token: 0x040076FB RID: 30459
	private Dictionary<int, AiSearchWanderPointData> AiSearchWanderPointDataMap = new Dictionary<int, AiSearchWanderPointData>();
}
