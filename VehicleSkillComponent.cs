using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game;
using UnrealEngine;

// Token: 0x0200327D RID: 12925
[NullableContext(1)]
[Nullable(0)]
public class VehicleSkillComponent : BaseSkillComponent, IComponentDependency
{
	// Token: 0x170024D6 RID: 9430
	// (get) Token: 0x0601B0A2 RID: 110754 RVA: 0x00816C13 File Offset: 0x00814E13
	public static Type[] Dependencies
	{
		get
		{
			return new Type[]
			{
				typeof(VehicleActorComponent)
			};
		}
	}

	// Token: 0x0601B0A3 RID: 110755 RVA: 0x00816C28 File Offset: 0x00814E28
	protected override bool OnInit()
	{
		if (!base.OnInit())
		{
			return false;
		}
		this.AnimComp = base.Entity.GetComponent<VehicleAnimationComponent>();
		this.MoveComp = base.Entity.GetComponent<VehicleMoveComponent>();
		this.VehicleActorComp = (this.ActorComp as VehicleActorComponent);
		return true;
	}

	// Token: 0x0601B0A4 RID: 110756 RVA: 0x00816C68 File Offset: 0x00814E68
	[NullableContext(2)]
	public override UAnimInstance GetMainAnimInstance()
	{
		return this.AnimComp.MainAnimInstance;
	}

	// Token: 0x0601B0A5 RID: 110757 RVA: 0x00816C78 File Offset: 0x00814E78
	protected override void DoSkillBeginMoveAction(Skill skill, SSkillInfo info)
	{
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp != null && tagComp.HasTag(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止移动"]))
		{
			VehicleMoveComponent moveComp = this.MoveComp;
			if (moveComp != null)
			{
				moveComp.SetForceSpeed(Vector.ZeroVectorProxy);
			}
		}
		this.SetSkillTargetDirection(info.SkillDirection, info.SkillTarget.SkillTargetPriority);
		VehicleAnimationComponent animComp = this.AnimComp;
		if (animComp == null)
		{
			return;
		}
		animComp.StartForceDisableAnimOptimization(EForceDisableAnimOptimization.Skill, false);
	}

	// Token: 0x0601B0A6 RID: 110758 RVA: 0x00816CF4 File Offset: 0x00814EF4
	public void SetSkillTargetDirection(ESkillTargetDirection direction, ESkillTargetPriority priority = ESkillTargetPriority.摇杆方向优先)
	{
		BaseLockOnComponent lockOnComp = this.LockOnComp;
		if (lockOnComp != null && lockOnComp.Valid)
		{
			switch (direction)
			{
			case ESkillTargetDirection.技能目标方向:
			{
				EntityHandle skillTarget = this.SkillTarget;
				if (skillTarget != null && skillTarget.Valid)
				{
					this.TurnToSkillTarget();
					return;
				}
				if (priority == ESkillTargetPriority.镜头方向优先_精准模式_)
				{
					this.TurnToCameraDir();
					return;
				}
				this.TurnToInputDir();
				return;
			}
			case ESkillTargetDirection.摇杆方向:
				this.TurnToInputDir();
				return;
			case ESkillTargetDirection.角色方向:
				break;
			case ESkillTargetDirection.相机方向:
				this.TurnToCameraDir();
				break;
			case ESkillTargetDirection.技能目标方向_载具专用_:
			{
				EntityHandle skillTarget2 = this.SkillTarget;
				if (skillTarget2 != null && skillTarget2.Valid)
				{
					this.TurnToSkillTarget();
					return;
				}
				if (priority == ESkillTargetPriority.镜头方向优先_精准模式_)
				{
					this.TurnToCameraDir();
					return;
				}
				break;
			}
			default:
				return;
			}
		}
	}

	// Token: 0x0601B0A7 RID: 110759 RVA: 0x00816D90 File Offset: 0x00814F90
	private void TurnToInputDir()
	{
		if (!this.VehicleActorComp.IsAutonomousProxy)
		{
			return;
		}
		if (!this.IsHasInputDir())
		{
			return;
		}
		Singleton<MathUtils>.Instance.LookRotationUpFirst(this.VehicleActorComp.InputDirectProxy, this.MoveComp.GravityUp, this.TmpRotator);
		this.TmpTransform.Set(this.VehicleActorComp.ActorLocationProxy, this.TmpRotator.Quaternion(null), this.VehicleActorComp.ActorScaleProxy);
		this.VehicleActorComp.SetActorTransform(this.TmpTransform.ToUeTransform(), "载具.释放技能.转向输入方向", false, new ESetRotationPriority?(ESetRotationPriority.Skill));
	}

	// Token: 0x0601B0A8 RID: 110760 RVA: 0x00816E2C File Offset: 0x0081502C
	public bool IsHasInputDir()
	{
		if (!base.CheckIsLoaded())
		{
			return false;
		}
		Vector inputDirectProxy = this.VehicleActorComp.InputDirectProxy;
		return 0.0 < Math.Abs(inputDirectProxy.X) || 0.0 < Math.Abs(inputDirectProxy.Y);
	}

	// Token: 0x0601B0A9 RID: 110761 RVA: 0x00816E80 File Offset: 0x00815080
	private void TurnToCameraDir()
	{
		Rotator tmpRotator = this.TmpRotator;
		FRotator cameraRotation = Global.CharacterCameraManager.GetCameraRotation();
		tmpRotator.FromUeRotator(cameraRotation);
		this.TmpRotator.Vector(this.TmpVector);
		MathUtils instance = Singleton<MathUtils>.Instance;
		Vector tmpVector = this.TmpVector;
		VehicleActorComponent vehicleActorComp = this.VehicleActorComp;
		Vector vector;
		if (vehicleActorComp == null)
		{
			vector = null;
		}
		else
		{
			BaseMoveComponent moveComp = vehicleActorComp.MoveComp;
			vector = ((moveComp != null) ? moveComp.GravityUp : null);
		}
		instance.LookRotationUpFirst(tmpVector, vector ?? Vector.UpVectorProxy, this.TmpRotator);
		this.TmpTransform.Set(this.VehicleActorComp.ActorLocationProxy, this.TmpRotator.Quaternion(null), this.VehicleActorComp.ActorScaleProxy);
		this.VehicleActorComp.SetActorTransform(this.TmpTransform.ToUeTransform(), "载具.释放技能.转向摄像机方向", false, new ESetRotationPriority?(ESetRotationPriority.Skill));
	}

	// Token: 0x0601B0AA RID: 110762 RVA: 0x00816F44 File Offset: 0x00815144
	private void TurnToSkillTarget()
	{
		if (this.SkillTarget == null)
		{
			return;
		}
		Vector tmpVector = this.TmpVector;
		FVectorDouble location = base.GetTargetTransform().GetLocation();
		tmpVector.FromUeVector(location);
		this.TmpVector.SubtractionEqual(this.VehicleActorComp.ActorLocationProxy);
		MathUtils instance = Singleton<MathUtils>.Instance;
		Vector tmpVector2 = this.TmpVector;
		VehicleActorComponent vehicleActorComp = this.VehicleActorComp;
		Vector vector;
		if (vehicleActorComp == null)
		{
			vector = null;
		}
		else
		{
			BaseMoveComponent moveComp = vehicleActorComp.MoveComp;
			vector = ((moveComp != null) ? moveComp.GravityUp : null);
		}
		instance.LookRotationUpFirst(tmpVector2, vector ?? Vector.UpVectorProxy, this.TmpRotator);
		this.VehicleActorComp.SetActorRotation(this.TmpRotator.ToUeRotator(), "载具.释放技能.转向技能目标", false);
	}

	// Token: 0x0601B0AB RID: 110763 RVA: 0x00816FE7 File Offset: 0x008151E7
	protected override void DoSkillEndMoveAction(SSkillInfo info)
	{
		VehicleAnimationComponent animComp = this.AnimComp;
		if (animComp == null)
		{
			return;
		}
		animComp.CancelForceDisableAnimOptimization(EForceDisableAnimOptimization.Skill);
	}

	// Token: 0x0601B0AC RID: 110764 RVA: 0x00816FFC File Offset: 0x008151FC
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		VehicleSkillComponent vehicleSkillComponent = (VehicleSkillComponent)componentTemplate;
		if (base.CanResetComponentProperty("AnimComp"))
		{
			if (vehicleSkillComponent.AnimComp == null)
			{
				this.AnimComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleAnimationComponent>(this.AnimComp), "AnimComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (vehicleSkillComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("VehicleActorComp"))
		{
			if (vehicleSkillComponent.VehicleActorComp == null)
			{
				this.VehicleActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleActorComponent>(this.VehicleActorComp), "VehicleActorComp"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400DBD3 RID: 56275
	[StaticVariableRuleIgnore]
	private static readonly Stat StatDoSkillBegin6 = Stat.Create("Vehicle DoSkillBegin Target&Rotation", "", "");

	// Token: 0x0400DBD4 RID: 56276
	[Nullable(2)]
	private VehicleAnimationComponent AnimComp;

	// Token: 0x0400DBD5 RID: 56277
	[Nullable(2)]
	private VehicleMoveComponent MoveComp;

	// Token: 0x0400DBD6 RID: 56278
	[Nullable(2)]
	private VehicleActorComponent VehicleActorComp;
}
