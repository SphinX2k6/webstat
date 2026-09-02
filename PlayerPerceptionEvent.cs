using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Perception;
using UnrealEngine;

// Token: 0x02003235 RID: 12853
[NullableContext(2)]
[Nullable(0)]
public class PlayerPerceptionEvent
{
	// Token: 0x0601ABE5 RID: 109541 RVA: 0x007F81F7 File Offset: 0x007F63F7
	public bool IsValid()
	{
		return this.EventTokenInternal > 0U;
	}

	// Token: 0x1700244A RID: 9290
	// (get) Token: 0x0601ABE6 RID: 109542 RVA: 0x007F8202 File Offset: 0x007F6402
	public uint EventToken
	{
		get
		{
			return this.EventTokenInternal;
		}
	}

	// Token: 0x0601ABE7 RID: 109543 RVA: 0x007F820C File Offset: 0x007F640C
	public void Init(float enterDistance, uint entityToken, Action onEnter = null, Action onLeave = null, Action onDestroy = null, Func<bool> enterCondition = null, float leaveDistance = -1f, Vector locationOffset = null)
	{
		if (this.EventTokenInternal != 0U)
		{
			Singleton<Log>.Instance.Error(ELogModule.Perception, ELogAuthor.WLJ, "重复初始化主角感知事件", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (onEnter == null && onLeave == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Perception, ELogAuthor.WLJ, "初始化的主角感知事件没有意义", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (entityToken == 0U)
		{
			Singleton<Log>.Instance.Error(ELogModule.Perception, ELogAuthor.WLJ, "初始化的主角感知事件时传入的时间预算管理Token非法", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!this.EventGCHandle.IsAllocated)
		{
			this.EventGCHandle = GCHandle.Alloc(this, GCHandleType.Normal);
		}
		this.EnterDistance = enterDistance;
		this.LeaveDistance = leaveDistance;
		this.EntityToken = entityToken;
		this.LocationOffset = locationOffset;
		this.OnEnter = onEnter;
		this.OnLeave = onLeave;
		this.OnDestroy = onDestroy;
		this.EnterCondition = enterCondition;
		uint entityToken2 = this.EntityToken;
		FVectorDouble fvectorDouble;
		if (locationOffset == null || locationOffset.Equals(Vector.ZeroVectorProxy, 9.999999747378752E-05))
		{
			fvectorDouble = FVectorDouble.ZeroVector;
		}
		else
		{
			FVector fvector = locationOffset.ToUeVectorOld();
			fvectorDouble = fvector;
		}
		FVectorDouble fvectorDouble2 = fvectorDouble;
		this.EventTokenInternal = FKuroPerceptionCSharpInterface.RegisterPlayerPerceptionEvent(enterDistance, leaveDistance, entityToken2, fvectorDouble2, GCHandle.ToIntPtr(this.EventGCHandle), this.OnEnter != null, this.OnLeave != null, this.EnterCondition != null, true);
		if (this.EventTokenInternal == 0U)
		{
			Singleton<Log>.Instance.Error(ELogModule.Perception, ELogAuthor.WLJ, "初始化感知事件失败", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x0601ABE8 RID: 109544 RVA: 0x007F8378 File Offset: 0x007F6578
	public void Register(uint entityToken)
	{
		if (this.EventTokenInternal != 0U)
		{
			Singleton<Log>.Instance.Info(ELogModule.Perception, ELogAuthor.WLJ, "重新注册时，仍然还存在感知事件", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.EntityToken = entityToken;
		if (!this.EventGCHandle.IsAllocated)
		{
			this.EventGCHandle = GCHandle.Alloc(this, GCHandleType.Normal);
		}
		float enterDistance = this.EnterDistance;
		float leaveDistance = this.LeaveDistance;
		uint entityToken2 = this.EntityToken;
		FVectorDouble fvectorDouble;
		if (this.LocationOffset == null || this.LocationOffset.Equals(Vector.ZeroVectorProxy, 9.999999747378752E-05))
		{
			fvectorDouble = FVectorDouble.ZeroVector;
		}
		else
		{
			FVector fvector = this.LocationOffset.ToUeVectorOld();
			fvectorDouble = fvector;
		}
		FVectorDouble fvectorDouble2 = fvectorDouble;
		this.EventTokenInternal = FKuroPerceptionCSharpInterface.RegisterPlayerPerceptionEvent(enterDistance, leaveDistance, entityToken2, fvectorDouble2, GCHandle.ToIntPtr(this.EventGCHandle), this.OnEnter != null, this.OnLeave != null, this.EnterCondition != null, true);
		if (this.EventTokenInternal == 0U)
		{
			Singleton<Log>.Instance.Error(ELogModule.Perception, ELogAuthor.WLJ, "重新注册感知事件失败", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x0601ABE9 RID: 109545 RVA: 0x007F847C File Offset: 0x007F667C
	public void Unregister()
	{
		if (this.EventTokenInternal == 0U)
		{
			Singleton<Log>.Instance.Info(ELogModule.Perception, ELogAuthor.WLJ, "临时注销感知事件时，感知事件不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		UKuroPerceptionInterface.UnregisterPlayerPerceptionEvent(this.EventTokenInternal);
		this.EventTokenInternal = 0U;
	}

	// Token: 0x0601ABEA RID: 109546 RVA: 0x007F84C4 File Offset: 0x007F66C4
	public void Clear()
	{
		this.OnEnter = null;
		this.OnLeave = null;
		this.OnDestroy = null;
		this.EnterCondition = null;
		this.EnterDistance = -1f;
		this.LeaveDistance = -1f;
		this.EntityToken = 0U;
		this.LocationOffset = null;
		if (this.EventGCHandle.IsAllocated)
		{
			this.EventGCHandle.Free();
		}
		if (this.EventTokenInternal == 0U)
		{
			return;
		}
		UKuroPerceptionInterface.UnregisterPlayerPerceptionEvent(this.EventTokenInternal);
		this.EventTokenInternal = 0U;
	}

	// Token: 0x0601ABEB RID: 109547 RVA: 0x007F8544 File Offset: 0x007F6744
	public void UpdateDistance(float enterDistance, float leaveDistance = -1f)
	{
		this.EnterDistance = enterDistance;
		this.LeaveDistance = leaveDistance;
		if (this.EventTokenInternal == 0U)
		{
			return;
		}
		UKuroPerceptionInterface.UpdatePerceptionEventDistance(this.EventTokenInternal, enterDistance, leaveDistance);
	}

	// Token: 0x0601ABEC RID: 109548 RVA: 0x007F856A File Offset: 0x007F676A
	public void ExecuteOnEnter()
	{
		if (this.OnEnter == null)
		{
			return;
		}
		this.OnEnter();
	}

	// Token: 0x0601ABED RID: 109549 RVA: 0x007F8580 File Offset: 0x007F6780
	public void ExecuteOnLeave()
	{
		if (this.OnLeave == null)
		{
			return;
		}
		this.OnLeave();
	}

	// Token: 0x0601ABEE RID: 109550 RVA: 0x007F8596 File Offset: 0x007F6796
	public bool ExecuteEnterCondition()
	{
		return this.EnterCondition == null || this.EnterCondition();
	}

	// Token: 0x0601ABEF RID: 109551 RVA: 0x007F85AD File Offset: 0x007F67AD
	public void ExecuteOnDestroy()
	{
		this.EventTokenInternal = 0U;
		this.EntityToken = 0U;
		if (this.OnDestroy == null)
		{
			return;
		}
		this.OnDestroy();
		this.OnDestroy = null;
	}

	// Token: 0x0400D8EB RID: 55531
	private Action OnEnter;

	// Token: 0x0400D8EC RID: 55532
	private Action OnLeave;

	// Token: 0x0400D8ED RID: 55533
	private Action OnDestroy;

	// Token: 0x0400D8EE RID: 55534
	private Func<bool> EnterCondition;

	// Token: 0x0400D8EF RID: 55535
	public uint EventTokenInternal;

	// Token: 0x0400D8F0 RID: 55536
	private float EnterDistance = -1f;

	// Token: 0x0400D8F1 RID: 55537
	private float LeaveDistance = -1f;

	// Token: 0x0400D8F2 RID: 55538
	private uint EntityToken;

	// Token: 0x0400D8F3 RID: 55539
	private Vector LocationOffset;

	// Token: 0x0400D8F4 RID: 55540
	private GCHandle EventGCHandle;
}
