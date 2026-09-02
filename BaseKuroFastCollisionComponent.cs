using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x0200310D RID: 12557
[NullableContext(1)]
[Nullable(0)]
public class BaseKuroFastCollisionComponent : EntityComponent
{
	// Token: 0x06019F79 RID: 106361 RVA: 0x00799EE8 File Offset: 0x007980E8
	protected override bool OnStart()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.BulletPatternEnvironmentChanged, new Action<bool>(this.OnEnvironmentChanged));
		if (BulletPatternComponent.GetKuroFastCollisionAlgorithm() != null)
		{
			this.StartKuroFastCollision();
		}
		return true;
	}

	// Token: 0x06019F7A RID: 106362 RVA: 0x00799F14 File Offset: 0x00798114
	protected override bool OnEnd()
	{
		this.StopKuroFastCollision();
		Singleton<EventSystem>.Instance.Remove(EEventName.BulletPatternEnvironmentChanged, new Action<bool>(this.OnEnvironmentChanged));
		return true;
	}

	// Token: 0x06019F7B RID: 106363 RVA: 0x00799F39 File Offset: 0x00798139
	protected virtual void OnStartKuroFastCollision()
	{
	}

	// Token: 0x06019F7C RID: 106364 RVA: 0x00799F3B File Offset: 0x0079813B
	protected virtual void OnStopKuroFastCollision()
	{
	}

	// Token: 0x06019F7D RID: 106365 RVA: 0x00799F3D File Offset: 0x0079813D
	private void StartKuroFastCollision()
	{
		this.RegisterAllShapes();
		this.OnStartKuroFastCollision();
	}

	// Token: 0x06019F7E RID: 106366 RVA: 0x00799F4B File Offset: 0x0079814B
	private void StopKuroFastCollision()
	{
		this.UnregisterAllShapes();
		this.OnStopKuroFastCollision();
	}

	// Token: 0x06019F7F RID: 106367 RVA: 0x00799F5C File Offset: 0x0079815C
	private void RegisterAllShapes()
	{
		this.UnregisterAllShapes();
		UKuroFastCollisionAlgorithm kuroFastCollisionAlgorithm = BulletPatternComponent.GetKuroFastCollisionAlgorithm();
		if (kuroFastCollisionAlgorithm == null)
		{
			return;
		}
		BaseCharacterComponent component = base.Entity.GetComponent<BaseCharacterComponent>();
		TsBaseCharacter tsBaseCharacter = (component != null) ? component.Actor : null;
		TArray<UActorComponent> tarray = (tsBaseCharacter != null) ? tsBaseCharacter.K2_GetComponentsByClass(UShapeComponent.StaticClass()) : null;
		int num = (tarray != null) ? tarray.Num() : 0;
		for (int i = 0; i < num; i++)
		{
			UShapeComponent ushapeComponent = tarray.Get(i) as UShapeComponent;
			if (ushapeComponent != null)
			{
				kuroFastCollisionAlgorithm.Add(ushapeComponent);
				this.RegisteredShapes.Add(ushapeComponent);
			}
		}
	}

	// Token: 0x06019F80 RID: 106368 RVA: 0x00799FE8 File Offset: 0x007981E8
	private void UnregisterAllShapes()
	{
		UKuroFastCollisionAlgorithm kuroFastCollisionAlgorithm = BulletPatternComponent.GetKuroFastCollisionAlgorithm();
		if (kuroFastCollisionAlgorithm == null)
		{
			this.RegisteredShapes.Clear();
			return;
		}
		foreach (UShapeComponent agent in this.RegisteredShapes)
		{
			kuroFastCollisionAlgorithm.Remove(agent);
		}
		this.RegisteredShapes.Clear();
	}

	// Token: 0x06019F81 RID: 106369 RVA: 0x0079A05C File Offset: 0x0079825C
	private void OnEnvironmentChanged(bool isStart)
	{
		if (isStart)
		{
			this.StartKuroFastCollision();
			return;
		}
		this.StopKuroFastCollision();
	}

	// Token: 0x06019F82 RID: 106370 RVA: 0x0079A070 File Offset: 0x00798270
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BaseKuroFastCollisionComponent baseKuroFastCollisionComponent = (BaseKuroFastCollisionComponent)componentTemplate;
		return !base.CanResetComponentProperty("RegisteredShapes") || baseKuroFastCollisionComponent.RegisteredShapes == null || base.CheckClearObject(EntityComponentSystem.ClearObject<List<UShapeComponent>>(this.RegisteredShapes), "RegisteredShapes");
	}

	// Token: 0x0400D044 RID: 53316
	private readonly List<UShapeComponent> RegisteredShapes = new List<UShapeComponent>();
}
