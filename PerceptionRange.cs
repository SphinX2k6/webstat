using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Perception;
using UnrealEngine;

// Token: 0x02003234 RID: 12852
[NullableContext(1)]
[Nullable(0)]
public class PerceptionRange
{
	// Token: 0x0601ABDC RID: 109532 RVA: 0x007F7DE4 File Offset: 0x007F5FE4
	public void InitStatic(Vector center, float range, byte group, bool needRecord = false, [Nullable(new byte[]
	{
		2,
		1
	})] Func<Entity, bool> enterCondition = null, [Nullable(new byte[]
	{
		2,
		1
	})] Action<Entity> onEnter = null, [Nullable(new byte[]
	{
		2,
		1
	})] Action<Entity> onLeave = null)
	{
		if (this.RangeToken != 0U)
		{
			Singleton<Log>.Instance.Error(ELogModule.Perception, ELogAuthor.WLJ, "重复初始化静态感知范围", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!needRecord && onEnter == null && onLeave == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Perception, ELogAuthor.WLJ, "初始化的静态感知范围没有意义", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (needRecord)
		{
			this.InsideEntity = new HashSet<int>();
		}
		this.EnterCondition = enterCondition;
		this.OnEnter = onEnter;
		this.OnLeave = onLeave;
		if (!this.PerceptionRangeGCHandle.IsAllocated)
		{
			this.PerceptionRangeGCHandle = GCHandle.Alloc(this, GCHandleType.Normal);
		}
		FVectorDouble fvectorDouble = center.ToUeVector(false);
		this.RangeToken = FKuroPerceptionCSharpInterface.AddStaticPerceptionRange(fvectorDouble, range, (uint)group, GCHandle.ToIntPtr(this.PerceptionRangeGCHandle), this.EnterCondition != null, this.OnEnter != null, this.OnLeave != null);
		if (this.RangeToken == 0U)
		{
			Singleton<Log>.Instance.Error(ELogModule.Perception, ELogAuthor.WLJ, "初始化静态感知范围失败", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x0601ABDD RID: 109533 RVA: 0x007F7EEC File Offset: 0x007F60EC
	public void InitDynamic(uint? entityToken, float range, byte group, [Nullable(new byte[]
	{
		2,
		1
	})] Action<Entity> onEnter = null, [Nullable(new byte[]
	{
		2,
		1
	})] Action<Entity> onLeave = null, [Nullable(new byte[]
	{
		2,
		1
	})] Func<Entity, bool> enterCondition = null, [Nullable(new byte[]
	{
		2,
		1
	})] Func<Vector> getLocationProxy = null, bool needRecord = false)
	{
		if (entityToken == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Perception, ELogAuthor.WLJ, "初始化动态感知范围绑定的实体Token非法", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (range <= 0f)
		{
			Singleton<Log>.Instance.Error(ELogModule.Perception, ELogAuthor.WLJ, "初始化动态感知范围时，感知范围大小非法", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.RangeToken != 0U)
		{
			Singleton<Log>.Instance.Error(ELogModule.Perception, ELogAuthor.WLJ, "重复初始化动态感知范围", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!needRecord && onEnter == null && onLeave == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Perception, ELogAuthor.WLJ, "初始化的动态感知范围没有意义", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.GetLocationProxy = getLocationProxy;
		this.EnterCondition = enterCondition;
		this.OnEnter = onEnter;
		this.OnLeave = onLeave;
		if (!this.PerceptionRangeGCHandle.IsAllocated)
		{
			this.PerceptionRangeGCHandle = GCHandle.Alloc(this, GCHandleType.Normal);
		}
		this.RangeToken = FKuroPerceptionCSharpInterface.AddDynamicPerceptionRange(entityToken.Value, range, (uint)group, GCHandle.ToIntPtr(this.PerceptionRangeGCHandle), true, this.EnterCondition != null, this.OnEnter != null, this.OnLeave != null);
		if (this.RangeToken == 0U)
		{
			Singleton<Log>.Instance.Error(ELogModule.Perception, ELogAuthor.WLJ, "初始化动态感知范围失败", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x0601ABDE RID: 109534 RVA: 0x007F803C File Offset: 0x007F623C
	public void Clear()
	{
		this.EnterCondition = null;
		this.OnEnter = null;
		this.OnLeave = null;
		this.GetLocationProxy = null;
		this.LocationCache.Reset();
		this.InsideEntity = null;
		if (this.RangeToken != 0U)
		{
			UKuroPerceptionInterface.RemovePerceptionRange(this.RangeToken);
			this.RangeToken = 0U;
		}
		if (this.PerceptionRangeGCHandle.IsAllocated)
		{
			this.PerceptionRangeGCHandle.Free();
		}
	}

	// Token: 0x0601ABDF RID: 109535 RVA: 0x007F80AC File Offset: 0x007F62AC
	public void UpdateRange(float range)
	{
		if (this.RangeToken == 0U)
		{
			return;
		}
		if (range <= 0f)
		{
			Singleton<Log>.Instance.Error(ELogModule.Perception, ELogAuthor.WLJ, "更新动态感知范围大小时，感知范围大小非法", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		UKuroPerceptionInterface.UpdatePerceptionRange(this.RangeToken, range);
	}

	// Token: 0x0601ABE0 RID: 109536 RVA: 0x007F80F8 File Offset: 0x007F62F8
	private bool EnterConditionInternal(object element)
	{
		if (this.EnterCondition == null)
		{
			return false;
		}
		Entity arg = element as Entity;
		return this.EnterCondition(arg);
	}

	// Token: 0x0601ABE1 RID: 109537 RVA: 0x007F8124 File Offset: 0x007F6324
	private void voidOnEnterInternal(object element)
	{
		Entity entity = element as Entity;
		if (this.InsideEntity != null)
		{
			this.InsideEntity.Add(entity.Id);
		}
		if (this.OnEnter == null)
		{
			return;
		}
		this.OnEnter(entity);
	}

	// Token: 0x0601ABE2 RID: 109538 RVA: 0x007F8168 File Offset: 0x007F6368
	private void OnLeaveInternal(object element)
	{
		Entity entity = element as Entity;
		if (this.InsideEntity != null)
		{
			this.InsideEntity.Remove(entity.Id);
		}
		if (this.OnLeave == null)
		{
			return;
		}
		this.OnLeave(entity);
	}

	// Token: 0x0601ABE3 RID: 109539 RVA: 0x007F81AB File Offset: 0x007F63AB
	private FVectorDouble GetLocationProxyInternal()
	{
		if (this.GetLocationProxy == null)
		{
			return this.LocationCache.ToUeVector(false);
		}
		this.LocationCache.DeepCopy(this.GetLocationProxy());
		return this.LocationCache.ToUeVector(false);
	}

	// Token: 0x0400D8E3 RID: 55523
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Func<Entity, bool> EnterCondition;

	// Token: 0x0400D8E4 RID: 55524
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<Entity> OnEnter;

	// Token: 0x0400D8E5 RID: 55525
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<Entity> OnLeave;

	// Token: 0x0400D8E6 RID: 55526
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Func<Vector> GetLocationProxy;

	// Token: 0x0400D8E7 RID: 55527
	private readonly Vector LocationCache = Vector.Create();

	// Token: 0x0400D8E8 RID: 55528
	private uint RangeToken;

	// Token: 0x0400D8E9 RID: 55529
	[Nullable(2)]
	private HashSet<int> InsideEntity;

	// Token: 0x0400D8EA RID: 55530
	private GCHandle PerceptionRangeGCHandle;
}
