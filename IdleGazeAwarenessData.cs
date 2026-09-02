using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001FD3 RID: 8147
[NullableContext(1)]
[Nullable(0)]
internal sealed class IdleGazeAwarenessData
{
	// Token: 0x0600F5EB RID: 62955 RVA: 0x00435848 File Offset: 0x00433A48
	public IdleGazeAwarenessData(int entityId, float awarenessAngle, float awarenessDistance, float awarenessHeight, float playerGazeAngle, bool enableDebugDraw)
	{
		this.EntityId = entityId;
		this.AwarenessAngle = awarenessAngle;
		this.AwarenessDistance = awarenessDistance;
		this.AwarenessHeight = awarenessHeight;
		this.PlayerGazeAngle = playerGazeAngle;
		this.EnableDebugDraw = enableDebugDraw;
		this.TotalPlayerGazeTime = 0f;
	}

	// Token: 0x0600F5EC RID: 62956 RVA: 0x004358B4 File Offset: 0x00433AB4
	public void Reset()
	{
		this.TotalPlayerGazeTime = 0f;
	}

	// Token: 0x0600F5ED RID: 62957 RVA: 0x004358C4 File Offset: 0x00433AC4
	public bool GazeAwarenessCheck()
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(this.EntityId);
		BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
		if (baseActorComponent == null || !baseActorComponent.Valid)
		{
			return false;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
		CharacterActorComponent characterActorComponent = (worldEntity != null) ? worldEntity.GetComponent<CharacterActorComponent>() : null;
		if (characterActorComponent == null || !characterActorComponent.Valid)
		{
			return false;
		}
		this.TempVector1.DeepCopy(baseActorComponent.ActorLocationProxy);
		this.TempVector2.DeepCopy(characterActorComponent.ActorLocationProxy);
		this.TempVector1.Subtraction(this.TempVector2, this.TempVector3);
		if (this.TempVector3.SizeSquared2D() > (double)(this.AwarenessDistance * this.AwarenessDistance))
		{
			return false;
		}
		if (Math.Abs(this.TempVector3.Z) > (double)this.AwarenessHeight)
		{
			return false;
		}
		this.TempVector1.DeepCopy(baseActorComponent.ActorForwardProxy);
		if (Math.Abs(this.GetYawAngleDelta(this.TempVector1, this.TempVector3)) > this.AwarenessAngle * 0.5f)
		{
			return false;
		}
		this.TempVector2.DeepCopy(characterActorComponent.ActorForwardProxy);
		return Math.Abs(this.GetYawAngleDelta(this.TempVector2, this.TempVector3)) <= this.PlayerGazeAngle * 0.5f;
	}

	// Token: 0x0600F5EE RID: 62958 RVA: 0x00435A10 File Offset: 0x00433C10
	public void DebugDraw()
	{
	}

	// Token: 0x0600F5EF RID: 62959 RVA: 0x00435A20 File Offset: 0x00433C20
	private void DrawDebugFan(Vector origin, Vector direction, float length, float angle, FLinearColor color)
	{
		if (length <= 0f || angle <= 0f)
		{
			return;
		}
		UKismetSystemLibrary.D_DrawDebugCone(GlobalData.World, origin.ToUeVector(false), direction.ToUeVector(false), length, angle * 0.017453292f / 2f, 0f, 24, color, 0f, 2f);
	}

	// Token: 0x0600F5F0 RID: 62960 RVA: 0x00435A7C File Offset: 0x00433C7C
	public float GetYawAngleDelta(Vector forward, Vector target)
	{
		double num = Math.Atan2(forward.Y, forward.X);
		double num2 = Math.Atan2(target.Y, target.X) - num;
		if (num2 > 3.141592653589793)
		{
			num2 -= 6.283185307179586;
		}
		else if (num2 < -3.141592653589793)
		{
			num2 += 6.283185307179586;
		}
		return (float)(num2 * 57.295780181884766);
	}

	// Token: 0x0600F5F1 RID: 62961 RVA: 0x00435AED File Offset: 0x00433CED
	public bool CheckPlayerGazeTime(float time)
	{
		return this.TotalPlayerGazeTime >= time;
	}

	// Token: 0x0600F5F2 RID: 62962 RVA: 0x00435AFB File Offset: 0x00433CFB
	public void Tick(float delta)
	{
		if (this.EnableDebugDraw)
		{
			this.DebugDraw();
		}
		if (this.GazeAwarenessCheck())
		{
			this.TotalPlayerGazeTime += delta;
			return;
		}
		this.TotalPlayerGazeTime = 0f;
	}

	// Token: 0x040076E9 RID: 30441
	public int EntityId;

	// Token: 0x040076EA RID: 30442
	public float AwarenessAngle;

	// Token: 0x040076EB RID: 30443
	public float AwarenessDistance;

	// Token: 0x040076EC RID: 30444
	public float AwarenessHeight;

	// Token: 0x040076ED RID: 30445
	public float PlayerGazeAngle;

	// Token: 0x040076EE RID: 30446
	public bool EnableDebugDraw;

	// Token: 0x040076EF RID: 30447
	public float TotalPlayerGazeTime;

	// Token: 0x040076F0 RID: 30448
	public Vector TempVector1 = Vector.Create();

	// Token: 0x040076F1 RID: 30449
	public Vector TempVector2 = Vector.Create();

	// Token: 0x040076F2 RID: 30450
	public Vector TempVector3 = Vector.Create();
}
