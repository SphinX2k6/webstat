using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02002FB9 RID: 12217
public class GameplayCueSkillTargetBeam : GameplayCueBase
{
	// Token: 0x06018EA5 RID: 102053 RVA: 0x0070EF78 File Offset: 0x0070D178
	protected override void OnInit()
	{
		this.Socket = FNameUtil.GetDynamicFName(this.CueConfig.Socket);
		Aki.Config.Vector value = this.CueConfig.Location.Value;
		this.MyOffset = new FVectorDouble((double)value.X, (double)value.Y, (double)value.Z);
		Aki.Config.Vector value2 = this.CueConfig.Rotation.Value;
		this.TargetOffset = new FVectorDouble((double)value2.X, (double)value2.Y, (double)value2.Z);
		this.TargetPoint = this.ActorInternal.D_GetTransform().TransformPositionNoScale(this.MyOffset);
	}

	// Token: 0x06018EA6 RID: 102054 RVA: 0x0070F028 File Offset: 0x0070D228
	protected override void OnTick(float delta)
	{
		FVectorDouble fvectorDouble = (this.Socket != null) ? this.ActorInternal.Mesh.D_GetSocketLocation(this.Socket.Value) : this.ActorInternal.D_K2_GetActorLocation();
		ValueTuple<EntityHandle, string> targetAndSocket = this.GetTargetAndSocket();
		EntityHandle item = targetAndSocket.Item1;
		string item2 = targetAndSocket.Item2;
		if (item != null)
		{
			if (!string.IsNullOrEmpty(item2))
			{
				WorldEntity entity = item.Entity;
				CharacterActorComponent characterActorComponent = (entity != null) ? entity.GetComponent<CharacterActorComponent>() : null;
				if (characterActorComponent != null)
				{
					FVectorDouble fvectorDouble2 = characterActorComponent.Actor.Mesh.D_GetSocketLocation(FNameUtil.GetDynamicFName(item2).Value);
					FQuat actorQuat = characterActorComponent.ActorQuat;
					FVectorDouble actorScale = characterActorComponent.ActorScale;
					FTransformDouble targetTransform = this.TargetTransform;
					this.TargetTransform.SetLocation(fvectorDouble2);
					this.TargetTransform.SetRotation(actorQuat);
					this.TargetTransform.SetScale3D(actorScale);
					this.TargetPoint = this.TargetTransform.TransformPositionNoScale(this.TargetOffset);
				}
			}
			else
			{
				WorldEntity entity2 = item.Entity;
				BaseActorComponent baseActorComponent = (entity2 != null) ? entity2.GetComponent<BaseActorComponent>() : null;
				if (baseActorComponent != null)
				{
					this.TargetPoint = baseActorComponent.ActorTransform.TransformPositionNoScale(this.TargetOffset);
				}
			}
		}
		this.BeamItem.Tick(new FVectorDouble[]
		{
			fvectorDouble,
			this.TargetPoint
		}, delta);
	}

	// Token: 0x06018EA7 RID: 102055 RVA: 0x0070F17B File Offset: 0x0070D37B
	[return: TupleElementNames(new string[]
	{
		"Target",
		"TargetSocket"
	})]
	[return: Nullable(new byte[]
	{
		0,
		2,
		1
	})]
	private ValueTuple<EntityHandle, string> GetTargetAndSocket()
	{
		if (GameplayCueController.GetTargetSourceType(this.CueConfig) == ETargetSourceType.Skill)
		{
			return this.GetSkillTargetAndSocket();
		}
		return this.GetLockOnTargetAndSocket();
	}

	// Token: 0x06018EA8 RID: 102056 RVA: 0x0070F198 File Offset: 0x0070D398
	[return: TupleElementNames(new string[]
	{
		"Target",
		"TargetSocket"
	})]
	[return: Nullable(new byte[]
	{
		0,
		2,
		1
	})]
	private ValueTuple<EntityHandle, string> GetLockOnTargetAndSocket()
	{
		EntityHandle item = null;
		string item2 = string.Empty;
		WorldEntity entity = this.EntityHandle.Entity;
		CharacterLockOnComponent characterLockOnComponent = (entity != null) ? entity.GetComponent<CharacterLockOnComponent>() : null;
		WorldEntity entity2 = this.EntityHandle.Entity;
		CharacterActorComponent characterActorComponent = (entity2 != null) ? entity2.GetComponent<CharacterActorComponent>() : null;
		if (characterLockOnComponent != null && characterActorComponent != null && characterActorComponent.IsAutonomousProxy)
		{
			item = characterLockOnComponent.GetCurrentTarget();
			item2 = characterLockOnComponent.GetCurrentTargetSocketName();
		}
		else
		{
			WorldEntity entity3 = this.EntityHandle.Entity;
			CharacterSkillComponent characterSkillComponent = (entity3 != null) ? entity3.GetComponent<CharacterSkillComponent>() : null;
			if (characterSkillComponent != null)
			{
				item = characterSkillComponent.SkillTarget;
				item2 = characterSkillComponent.SkillTargetSocket;
			}
		}
		return new ValueTuple<EntityHandle, string>(item, item2);
	}

	// Token: 0x06018EA9 RID: 102057 RVA: 0x0070F230 File Offset: 0x0070D430
	[return: TupleElementNames(new string[]
	{
		"Target",
		"TargetSocket"
	})]
	[return: Nullable(new byte[]
	{
		0,
		2,
		1
	})]
	private ValueTuple<EntityHandle, string> GetSkillTargetAndSocket()
	{
		EntityHandle item = null;
		string item2 = string.Empty;
		WorldEntity entity = this.EntityHandle.Entity;
		CharacterSkillComponent characterSkillComponent = (entity != null) ? entity.GetComponent<CharacterSkillComponent>() : null;
		if (characterSkillComponent != null)
		{
			item = characterSkillComponent.SkillTarget;
			item2 = characterSkillComponent.SkillTargetSocket;
		}
		return new ValueTuple<EntityHandle, string>(item, item2);
	}

	// Token: 0x06018EAA RID: 102058 RVA: 0x0070F275 File Offset: 0x0070D475
	protected override void OnCreate()
	{
		this.BeamItem = GameplayCueBeamCommonItem.Spawn(this.ActorInternal, this.CueConfig.Path, null);
	}

	// Token: 0x06018EAB RID: 102059 RVA: 0x0070F294 File Offset: 0x0070D494
	protected override void OnDestroy()
	{
		this.BeamItem.Destroy();
	}

	// Token: 0x06018EAC RID: 102060 RVA: 0x0070F2A1 File Offset: 0x0070D4A1
	public override void OnEnable()
	{
		this.BeamItem.GetOwner().SetActorHiddenInGame(false);
	}

	// Token: 0x06018EAD RID: 102061 RVA: 0x0070F2B4 File Offset: 0x0070D4B4
	public override void OnDisable()
	{
		this.BeamItem.GetOwner().SetActorHiddenInGame(true);
	}

	// Token: 0x0400C2B8 RID: 49848
	private FName? Socket;

	// Token: 0x0400C2B9 RID: 49849
	[Nullable(2)]
	private GameplayCueBeamCommonItem BeamItem;

	// Token: 0x0400C2BA RID: 49850
	private FVectorDouble MyOffset;

	// Token: 0x0400C2BB RID: 49851
	private FVectorDouble TargetOffset;

	// Token: 0x0400C2BC RID: 49852
	private FVectorDouble TargetPoint;

	// Token: 0x0400C2BD RID: 49853
	private FTransformDouble TargetTransform;
}
