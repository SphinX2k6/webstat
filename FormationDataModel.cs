using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000FC9 RID: 4041
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FormationDataModel : ModelBase<FormationDataModel>
{
	// Token: 0x060067AE RID: 26542 RVA: 0x001B0C11 File Offset: 0x001AEE11
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x060067AF RID: 26543 RVA: 0x001B0C14 File Offset: 0x001AEE14
	protected override bool OnClear()
	{
		this.PlayerAggroSet.Clear();
		this.OnLandPositionQueue.Clear();
		return true;
	}

	// Token: 0x060067B0 RID: 26544 RVA: 0x001B0C2D File Offset: 0x001AEE2D
	protected override bool OnLeaveLevel()
	{
		this.OnLandPositionQueue.Clear();
		return true;
	}

	// Token: 0x060067B1 RID: 26545 RVA: 0x001B0C3C File Offset: 0x001AEE3C
	public void RefreshOnLandPosition()
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
		if (worldEntity == null)
		{
			return;
		}
		CharacterUnifiedStateComponent component = worldEntity.GetComponent<CharacterUnifiedStateComponent>();
		ECharPositionState? echarPositionState = (component != null) ? new ECharPositionState?(component.PositionState) : null;
		ECharPositionSubState? echarPositionSubState = (component != null) ? new ECharPositionSubState?(component.PositionSubState) : null;
		ECharPositionState? echarPositionState2 = echarPositionState;
		ECharPositionState echarPositionState3 = ECharPositionState.Ground;
		if (!(echarPositionState2.GetValueOrDefault() == echarPositionState3 & echarPositionState2 != null))
		{
			return;
		}
		if (echarPositionSubState.GetValueOrDefault() == ECharPositionSubState.WaterSurface || echarPositionSubState.GetValueOrDefault() == ECharPositionSubState.WalkOnAir)
		{
			return;
		}
		BaseActorComponent component2 = worldEntity.GetComponent<BaseActorComponent>();
		AActor aactor = (component2 != null) ? component2.Owner : null;
		if (aactor == null || aactor.bHidden)
		{
			return;
		}
		Vector actorLocationProxy = component2.ActorLocationProxy;
		if (actorLocationProxy == null)
		{
			return;
		}
		Vector vector = null;
		if (this.OnLandPositionQueue.Size >= 15)
		{
			vector = this.OnLandPositionQueue.Pop();
		}
		if (vector == null)
		{
			vector = Vector.Create();
		}
		if (vector != null)
		{
			vector.DeepCopy(actorLocationProxy);
		}
		this.OnLandPositionQueue.Push(vector);
	}

	// Token: 0x060067B2 RID: 26546 RVA: 0x001B0D46 File Offset: 0x001AEF46
	[NullableContext(2)]
	public Vector GetLastPositionOnLand()
	{
		return this.OnLandPositionQueue.Front;
	}

	// Token: 0x0400317E RID: 12670
	private const int CACHE_ON_LAND_SIZE = 15;

	// Token: 0x0400317F RID: 12671
	public readonly HashSet<int> PlayerAggroSet = new HashSet<int>();

	// Token: 0x04003180 RID: 12672
	public Queue<Vector> OnLandPositionQueue = new Queue<Vector>(15);

	// Token: 0x04003181 RID: 12673
	public ELockEnemyMode KeyboardLockEnemyMode;

	// Token: 0x04003182 RID: 12674
	public ELockEnemyMode GamepadLockEnemyMode;
}
