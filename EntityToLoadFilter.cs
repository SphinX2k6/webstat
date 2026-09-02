using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02003456 RID: 13398
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class EntityToLoadFilter : Filter<EntityHandle>, IEntityToLoadParam
{
	// Token: 0x17002653 RID: 9811
	// (get) Token: 0x0601C194 RID: 115092 RVA: 0x0086219C File Offset: 0x0086039C
	public override string DebugName
	{
		get
		{
			return "EntityToLoadFilter";
		}
	}

	// Token: 0x17002654 RID: 9812
	// (get) Token: 0x0601C195 RID: 115093 RVA: 0x008621A3 File Offset: 0x008603A3
	public string MaxLoadingDebugName
	{
		get
		{
			return this.DebugName;
		}
	}

	// Token: 0x17002655 RID: 9813
	// (get) Token: 0x0601C196 RID: 115094 RVA: 0x008621AB File Offset: 0x008603AB
	public string LoadingIntervalDebugName
	{
		get
		{
			return this.DebugName;
		}
	}

	// Token: 0x17002656 RID: 9814
	// (get) Token: 0x0601C197 RID: 115095 RVA: 0x008621B3 File Offset: 0x008603B3
	// (set) Token: 0x0601C198 RID: 115096 RVA: 0x008621BB File Offset: 0x008603BB
	public long MaxLoadingCount
	{
		get
		{
			return this.MaxLoadingCountInternal;
		}
		set
		{
			if (this.MaxLoadingCountInternal != value)
			{
				this.MaxLoadingCountInternal = value;
				Singleton<EventSystem>.Instance.Emit<IEntityToLoadParam>(EEventName.EntityToLoadParamUpdated, this);
			}
		}
	}

	// Token: 0x17002657 RID: 9815
	// (get) Token: 0x0601C199 RID: 115097 RVA: 0x008621DE File Offset: 0x008603DE
	// (set) Token: 0x0601C19A RID: 115098 RVA: 0x008621E6 File Offset: 0x008603E6
	public long LoadingInterval
	{
		get
		{
			return this.LoadingIntervalInternal;
		}
		set
		{
			if (this.LoadingIntervalInternal != value)
			{
				this.LoadingIntervalInternal = value;
				Singleton<EventSystem>.Instance.Emit<IEntityToLoadParam>(EEventName.EntityToLoadParamUpdated, this);
			}
		}
	}

	// Token: 0x0601C19B RID: 115099 RVA: 0x00862209 File Offset: 0x00860409
	protected override bool OnInit()
	{
		Singleton<EventSystem>.Instance.Emit<EntityToLoadFilter>(EEventName.EntityToLoadFilterCreated, this);
		return true;
	}

	// Token: 0x0601C19C RID: 115100 RVA: 0x0086221D File Offset: 0x0086041D
	protected override bool OnCleanup()
	{
		Singleton<EventSystem>.Instance.Emit<EntityToLoadFilter>(EEventName.EntityToLoadFilterDestroyed, this);
		return true;
	}

	// Token: 0x0601C19D RID: 115101 RVA: 0x00862231 File Offset: 0x00860431
	public static EntityToLoadFilter Create()
	{
		EntityToLoadFilter entityToLoadFilter = new EntityToLoadFilter();
		entityToLoadFilter.Init();
		return entityToLoadFilter;
	}

	// Token: 0x0400E2EB RID: 58091
	public const long MAX_LOADING_ENTITY_COUNT = 4L;

	// Token: 0x0400E2EC RID: 58092
	public const long LOADING_INTERVAL = 0L;

	// Token: 0x0400E2ED RID: 58093
	private long MaxLoadingCountInternal = 4L;

	// Token: 0x0400E2EE RID: 58094
	private long LoadingIntervalInternal;
}
