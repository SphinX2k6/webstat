using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

// Token: 0x020034C3 RID: 13507
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WorldModel : ModelBase<WorldModel>
{
	// Token: 0x170026BC RID: 9916
	// (get) Token: 0x0601C8C2 RID: 116930 RVA: 0x0088F5F1 File Offset: 0x0088D7F1
	// (set) Token: 0x0601C8C3 RID: 116931 RVA: 0x0088F5FD File Offset: 0x0088D7FD
	public FVector? ControlPlayerLastLocation
	{
		get
		{
			return ModelBase<WorldModel>.Instance.ControlPlayerLastLocationInternal;
		}
		set
		{
			this.ControlPlayerLastLocationInternal = value;
		}
	}

	// Token: 0x0601C8C4 RID: 116932 RVA: 0x0088F608 File Offset: 0x0088D808
	public void UpdateWorldState(IDictionary<string, VarDefinePb> infos)
	{
		foreach (string key in infos.Keys)
		{
			VarDefinePb value = infos[key];
			this.WorldStateMapInternal[key] = value;
		}
	}

	// Token: 0x0601C8C5 RID: 116933 RVA: 0x0088F664 File Offset: 0x0088D864
	[return: Nullable(2)]
	public string GetWorldStateString(string key)
	{
		VarDefinePb varDefinePb;
		if (!this.WorldStateMapInternal.TryGetValue(key, out varDefinePb))
		{
			return null;
		}
		if (varDefinePb.VarType != 2)
		{
			return null;
		}
		return varDefinePb.String;
	}

	// Token: 0x0601C8C6 RID: 116934 RVA: 0x0088F694 File Offset: 0x0088D894
	public bool GetWorldStateBool(string key)
	{
		VarDefinePb varDefinePb;
		return this.WorldStateMapInternal.TryGetValue(key, out varDefinePb) && varDefinePb.VarType == 0 && varDefinePb.Boolean;
	}

	// Token: 0x0601C8C7 RID: 116935 RVA: 0x0088F6C4 File Offset: 0x0088D8C4
	public float? GetWorldStateFloat(string key)
	{
		VarDefinePb varDefinePb;
		if (!this.WorldStateMapInternal.TryGetValue(key, out varDefinePb))
		{
			return null;
		}
		if (varDefinePb.VarType != 3)
		{
			return null;
		}
		return new float?(varDefinePb.Float);
	}

	// Token: 0x0601C8C8 RID: 116936 RVA: 0x0088F70C File Offset: 0x0088D90C
	public long? GetWorldStateLong(string key)
	{
		VarDefinePb varDefinePb;
		if (!this.WorldStateMapInternal.TryGetValue(key, out varDefinePb))
		{
			return null;
		}
		if (varDefinePb.VarType != 1)
		{
			return null;
		}
		return new long?(varDefinePb.Int);
	}

	// Token: 0x0601C8C9 RID: 116937 RVA: 0x0088F754 File Offset: 0x0088D954
	[NullableContext(2)]
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public OneOf<bool, string, double> GetWorldState(string key)
	{
		if (string.IsNullOrEmpty(key))
		{
			return default(OneOf<bool, string, double>);
		}
		VarDefinePb varDefinePb;
		if (!this.WorldStateMapInternal.TryGetValue(key, out varDefinePb))
		{
			return default(OneOf<bool, string, double>);
		}
		switch (varDefinePb.VarType)
		{
		case 0:
			return varDefinePb.Boolean;
		case 1:
			return (double)varDefinePb.Int;
		case 2:
			return varDefinePb.String;
		case 3:
			return (double)varDefinePb.Float;
		default:
			return default(OneOf<bool, string, double>);
		}
	}

	// Token: 0x0601C8CA RID: 116938 RVA: 0x0088F7E7 File Offset: 0x0088D9E7
	public bool GetMapDone()
	{
		return this.MapDone;
	}

	// Token: 0x0601C8CB RID: 116939 RVA: 0x0088F7EF File Offset: 0x0088D9EF
	public void SetMapDone(bool value)
	{
		this.MapDone = value;
	}

	// Token: 0x0601C8CC RID: 116940 RVA: 0x0088F7F8 File Offset: 0x0088D9F8
	public void AddTsSimpleInteractItem(TsSimpleInteractBase item)
	{
		HashSet<TsSimpleInteractBase> hashSet;
		if (this.InteractMap.TryGetValue((long)item.TypeId, out hashSet))
		{
			hashSet.Add(item);
			return;
		}
		hashSet = new HashSet<TsSimpleInteractBase>();
		hashSet.Add(item);
		this.InteractMap[(long)item.TypeId] = hashSet;
	}

	// Token: 0x0601C8CD RID: 116941 RVA: 0x0088F848 File Offset: 0x0088DA48
	public void RemoveTsSimpleInteractItem(TsSimpleInteractBase item)
	{
		HashSet<TsSimpleInteractBase> hashSet;
		if (this.InteractMap.TryGetValue((long)item.TypeId, out hashSet))
		{
			hashSet.Remove(item);
		}
	}

	// Token: 0x0601C8CE RID: 116942 RVA: 0x0088F873 File Offset: 0x0088DA73
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public HashSet<TsSimpleInteractBase> GetTsSimpleInteractItemById(long typeId)
	{
		return this.InteractMap.GetValueOrDefault(typeId);
	}

	// Token: 0x0601C8CF RID: 116943 RVA: 0x0088F881 File Offset: 0x0088DA81
	[NullableContext(2)]
	public void AddDestroyActor(long creatureDataId, int entityId, AActor actor)
	{
		if (actor == null || !actor.IsValid())
		{
			return;
		}
		this.DestroyActorQueue.Push(new ValueTuple<long, int, AActor>(creatureDataId, entityId, actor));
	}

	// Token: 0x0601C8D0 RID: 116944 RVA: 0x0088F8A8 File Offset: 0x0088DAA8
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<long, int, AActor>? PopDestroyActor()
	{
		if (this.DestroyActorQueue.Size == 0)
		{
			return null;
		}
		return new ValueTuple<long, int, AActor>?(this.DestroyActorQueue.Pop());
	}

	// Token: 0x0601C8D1 RID: 116945 RVA: 0x0088F8DC File Offset: 0x0088DADC
	public void AddIgnore(AActor actor)
	{
		if (actor == null || !actor.IsValid())
		{
			return;
		}
		if (this.ActorsToIgnoreSet.Contains(actor))
		{
			return;
		}
		this.ActorsToIgnoreSet.Add(actor);
	}

	// Token: 0x0601C8D2 RID: 116946 RVA: 0x0088F90C File Offset: 0x0088DB0C
	[NullableContext(2)]
	public bool RemoveIgnore(AActor actor)
	{
		return actor != null && actor.IsValid() && this.ActorsToIgnoreSet.Remove(actor);
	}

	// Token: 0x0601C8D3 RID: 116947 RVA: 0x0088F92D File Offset: 0x0088DB2D
	public void ClearIgnore()
	{
		this.ActorsToIgnoreSet.Clear();
	}

	// Token: 0x0601C8D4 RID: 116948 RVA: 0x0088F93C File Offset: 0x0088DB3C
	public bool HandleEnvironmentUpdate(FKuroVoxelInfo info)
	{
		FKuroVoxelInfo cachedVoxelInfo = this.CachedVoxelInfo;
		this.CachedVoxelInfo = info;
		if (cachedVoxelInfo == null)
		{
			return true;
		}
		if (this.CachedVoxelInfo.EnvType != cachedVoxelInfo.EnvType)
		{
			this.CurEnvironmentTolerance = 0L;
		}
		else
		{
			this.CurEnvironmentTolerance += 1L;
		}
		return this.CurEnvironmentTolerance > 5L;
	}

	// Token: 0x0601C8D5 RID: 116949 RVA: 0x0088F998 File Offset: 0x0088DB98
	[NullableContext(2)]
	public FKuroVoxelInfo GetCachedVoxelInfo()
	{
		return this.CachedVoxelInfo;
	}

	// Token: 0x0601C8D6 RID: 116950 RVA: 0x0088F9A0 File Offset: 0x0088DBA0
	public EStreamingHandleType ApplyEnvironmentUpdate()
	{
		EStreamingHandleType result = EStreamingHandleType.DoNothing;
		if (this.CachedVoxelInfo == null || this.CurEnvironmentInfo.IsEqual((long)((ulong)this.CachedVoxelInfo.EnvType)))
		{
			return result;
		}
		int envType = this.CurEnvironmentInfo.EnvType;
		if (envType > 1)
		{
			if (envType != 2)
			{
				if (envType == 255)
				{
					if (this.CachedVoxelInfo.EnvType == 2)
					{
						result = EStreamingHandleType.EnterEncloseSpace;
					}
					if (this.CachedVoxelInfo.EnvType == 0 || this.CachedVoxelInfo.EnvType == 1)
					{
						result = EStreamingHandleType.ImmediateEnter;
					}
				}
			}
			else
			{
				if (this.CachedVoxelInfo.EnvType == 255)
				{
					result = EStreamingHandleType.FinishExitEncloseSpace;
				}
				if (this.CachedVoxelInfo.EnvType == 0 || this.CachedVoxelInfo.EnvType == 1)
				{
					result = EStreamingHandleType.FinishEnterEncloseSpace;
				}
			}
		}
		else
		{
			if (this.CachedVoxelInfo.EnvType == 255)
			{
				result = EStreamingHandleType.ImmediateExit;
			}
			if (this.CachedVoxelInfo.EnvType == 2)
			{
				result = EStreamingHandleType.ExitEncloseSpace;
			}
		}
		this.CurEnvironmentInfo.SetInfo(this.CachedVoxelInfo);
		return result;
	}

	// Token: 0x0400E5EC RID: 58860
	public const int VOXEL_ENV_REQUEST_INTERVAL = 1000;

	// Token: 0x0400E5ED RID: 58861
	public const int DEFAULT_ENVIRONMENTTYPE = 255;

	// Token: 0x0400E5EE RID: 58862
	public const int ENVIRONMENT_TOLERANCE = 5;

	// Token: 0x0400E5EF RID: 58863
	public const int MOBILE_CSM_DISTANCE_INCAVE = 20000;

	// Token: 0x0400E5F0 RID: 58864
	public const int MOBILE_CSM_DISTANCE_OUTCAVE = 8000;

	// Token: 0x0400E5F1 RID: 58865
	public bool IsStandalone;

	// Token: 0x0400E5F2 RID: 58866
	public List<TickIntervalSchedulerBase> TickIntervalSchedulers = new List<TickIntervalSchedulerBase>();

	// Token: 0x0400E5F3 RID: 58867
	private FVector? ControlPlayerLastLocationInternal;

	// Token: 0x0400E5F4 RID: 58868
	private bool MapDone;

	// Token: 0x0400E5F5 RID: 58869
	private Dictionary<long, HashSet<TsSimpleInteractBase>> InteractMap = new Dictionary<long, HashSet<TsSimpleInteractBase>>();

	// Token: 0x0400E5F6 RID: 58870
	public long ChangeSchedulerLastType;

	// Token: 0x0400E5F7 RID: 58871
	public long ChangeSchedulerDeltaFrameCount;

	// Token: 0x0400E5F8 RID: 58872
	public double CurrentSchedulerDelta;

	// Token: 0x0400E5F9 RID: 58873
	private readonly Dictionary<string, VarDefinePb> WorldStateMapInternal = new Dictionary<string, VarDefinePb>();

	// Token: 0x0400E5FA RID: 58874
	[Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	public readonly Queue<ValueTuple<long, int, AActor>> DestroyActorQueue = new Queue<ValueTuple<long, int, AActor>>(4);

	// Token: 0x0400E5FB RID: 58875
	public readonly HashSet<AActor> ActorsToIgnoreSet = new HashSet<AActor>();

	// Token: 0x0400E5FC RID: 58876
	public readonly WorldEnvironmentInfo CurEnvironmentInfo = new WorldEnvironmentInfo();

	// Token: 0x0400E5FD RID: 58877
	[Nullable(2)]
	private FKuroVoxelInfo CachedVoxelInfo;

	// Token: 0x0400E5FE RID: 58878
	private long CurEnvironmentTolerance;

	// Token: 0x0400E5FF RID: 58879
	public bool IsEnableEnvironmentDetecting = true;
}
