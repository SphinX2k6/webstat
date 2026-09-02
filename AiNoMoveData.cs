using System;
using System.Runtime.CompilerServices;

// Token: 0x02001FD4 RID: 8148
[NullableContext(1)]
[Nullable(0)]
internal sealed class AiNoMoveData
{
	// Token: 0x0600F5F3 RID: 62963 RVA: 0x00435B30 File Offset: 0x00433D30
	public AiNoMoveData(int entityId)
	{
		this.EntityId = entityId;
		this.LastMoveTime = (ModelBase<GameModeModel>.Instance.IsMulti ? Singleton<TimeUtil>.Instance.GetServerTimeStamp() : Singleton<Time>.Instance.WorldTime);
	}

	// Token: 0x0600F5F4 RID: 62964 RVA: 0x00435B88 File Offset: 0x00433D88
	public bool Tick()
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(this.EntityId);
		BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
		if (baseActorComponent == null || !baseActorComponent.Valid)
		{
			return false;
		}
		if (!baseActorComponent.ActorLocationProxy.Equals(this.LastLocation, 9.999999747378752E-05) || !baseActorComponent.ActorRotationProxy.Equals(this.LastRotation, 0.0001f))
		{
			this.LastMoveTime = this.GetWorldTime();
		}
		this.LastLocation.DeepCopy(baseActorComponent.ActorLocationProxy);
		this.LastRotation.DeepCopy(baseActorComponent.ActorRotationProxy);
		return true;
	}

	// Token: 0x0600F5F5 RID: 62965 RVA: 0x00435C22 File Offset: 0x00433E22
	public void ResetTime()
	{
		this.LastMoveTime = this.GetWorldTime();
	}

	// Token: 0x0600F5F6 RID: 62966 RVA: 0x00435C30 File Offset: 0x00433E30
	private double GetWorldTime()
	{
		if (!ModelBase<GameModeModel>.Instance.IsMulti)
		{
			return Singleton<Time>.Instance.WorldTime;
		}
		return Singleton<TimeUtil>.Instance.GetServerTimeStamp();
	}

	// Token: 0x0600F5F7 RID: 62967 RVA: 0x00435C53 File Offset: 0x00433E53
	public double GetNoMoveTime()
	{
		return this.GetWorldTime() - this.LastMoveTime;
	}

	// Token: 0x040076F3 RID: 30451
	public int EntityId;

	// Token: 0x040076F4 RID: 30452
	private Vector LastLocation = Vector.Create();

	// Token: 0x040076F5 RID: 30453
	private Rotator LastRotation = Rotator.Create();

	// Token: 0x040076F6 RID: 30454
	private double LastMoveTime;
}
