using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Role.Common;
using UnrealEngine;

// Token: 0x020031F0 RID: 12784
[NullableContext(1)]
[Nullable(0)]
public class RoleFrozenComponent : BaseFrozenComponent
{
	// Token: 0x0601A866 RID: 108646 RVA: 0x007D7E58 File Offset: 0x007D6058
	public override bool IsFrozen()
	{
		return this.IsFrozenInternal;
	}

	// Token: 0x0601A867 RID: 108647 RVA: 0x007D7E60 File Offset: 0x007D6060
	protected override void SetFrozen(bool bFrozen)
	{
		if (this.IsFrozenInternal == bFrozen)
		{
			return;
		}
		this.IsFrozenInternal = bFrozen;
		CharacterMoveComponent component = base.Entity.GetComponent<CharacterMoveComponent>();
		UeSkeletalTickManageComponent component2 = base.Entity.GetComponent<UeSkeletalTickManageComponent>();
		CharacterAbilityComponent component3 = base.Entity.GetComponent<CharacterAbilityComponent>();
		CharacterSkillComponent component4 = base.Entity.GetComponent<CharacterSkillComponent>();
		CharacterGameplayCueComponent cueComponent = base.Entity.GetComponent<CharacterGameplayCueComponent>();
		BaseTagComponent component5 = base.Entity.GetComponent<BaseTagComponent>();
		TagContainer tagContainer = (component5 != null) ? component5.TagContainer : null;
		UeMovementTickManageComponent component6 = base.Entity.GetComponent<UeMovementTickManageComponent>();
		if (component6 != null)
		{
			component6.Frozen = bFrozen;
		}
		if (bFrozen)
		{
			int? num = this.MoveForbidHandle;
			if (num == null)
			{
				this.MoveForbidHandle = ((component != null) ? new int?(component.Disable("RoleFrozen")) : null);
			}
			num = this.AnimForbidHandle;
			if (num == null)
			{
				this.AnimForbidHandle = ((component2 != null) ? new int?(component2.Disable("RoleFrozen")) : null);
			}
			num = this.AbilityForbidHandle;
			if (num == null)
			{
				this.AbilityForbidHandle = ((component3 != null) ? new int?(component3.Disable("RoleFrozen")) : null);
			}
			num = this.SkillForbidHandle;
			if (num == null)
			{
				this.SkillForbidHandle = ((component4 != null) ? new int?(component4.Disable("RoleFrozen")) : null);
			}
			if (this.FrozenCueHandle == 0)
			{
				CharacterGameplayCueComponent cueComponent5 = cueComponent;
				this.FrozenCueHandle = ((cueComponent5 != null) ? cueComponent5.AddCue(1003L, null) : 0);
			}
			if (tagContainer != null)
			{
				tagContainer.AddExactTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["Damage.Frozen"]);
				tagContainer.AddExactTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.快速攀爬禁止"]);
				tagContainer.AddExactTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.滑翔禁止"]);
				tagContainer.AddExactTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止交互.冰冻"]);
				tagContainer.AddExactTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止冲刺"]);
				tagContainer.AddExactTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止攀爬"]);
				tagContainer.AddExactTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止行走"]);
				tagContainer.AddExactTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止跳跃"]);
			}
			this.ChangeMovementModeInFrozen(component);
			if (this.ActorComponent != null)
			{
				RoleFrozenComponent.TmpVector.DeepCopy(this.ActorComponent.ActorVelocityProxy);
				if (RoleFrozenComponent.TmpVector.Z > 0.0)
				{
					RoleFrozenComponent.TmpVector.Z = 0.0;
					if (component != null)
					{
						component.SetForceSpeed(RoleFrozenComponent.TmpVector);
						return;
					}
				}
			}
		}
		else
		{
			if (this.MoveForbidHandle != null)
			{
				if (component != null)
				{
					component.Enable(new int?(this.MoveForbidHandle.Value), "[RoleFrozenComponent.SetFrozen] this.MoveForbidHandle !== undefined");
				}
				this.MoveForbidHandle = null;
			}
			if (this.AnimForbidHandle != null)
			{
				if (component2 != null)
				{
					component2.Enable(new int?(this.AnimForbidHandle.Value), "[RoleFrozenComponent.SetFrozen] this.AnimForbidHandle !== undefined");
				}
				this.AnimForbidHandle = null;
			}
			if (this.AbilityForbidHandle != null)
			{
				if (component3 != null)
				{
					component3.Enable(new int?(this.AbilityForbidHandle.Value), "[RoleFrozenComponent.SetFrozen] this.AbilityForbidHandle !== undefined");
				}
				this.AbilityForbidHandle = null;
			}
			if (this.SkillForbidHandle != null)
			{
				if (component4 != null)
				{
					component4.Enable(new int?(this.SkillForbidHandle.Value), "[RoleFrozenComponent.SetFrozen] this.SkillForbidHandle !== undefined");
				}
				this.SkillForbidHandle = null;
			}
			CharacterGameplayCueComponent cueComponent2 = cueComponent;
			if (cueComponent2 != null)
			{
				cueComponent2.RemoveCueByHandle((long)this.FrozenCueHandle);
			}
			CharacterGameplayCueComponent cueComponent3 = cueComponent;
			this.FrozenCueHandle = ((cueComponent3 != null) ? cueComponent3.AddCue(100302L, new GameplayCueParam?(new GameplayCueParam
			{
				EndCallback = delegate()
				{
					CharacterGameplayCueComponent cueComponent4 = cueComponent;
					if (cueComponent4 != null)
					{
						cueComponent4.RemoveCueByHandle((long)this.FrozenCueHandle);
					}
					this.FrozenCueHandle = 0;
				}
			})) : 0);
			if (tagContainer != null)
			{
				tagContainer.RemoveTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["Damage.Frozen"]);
				tagContainer.RemoveTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.快速攀爬禁止"]);
				tagContainer.RemoveTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.滑翔禁止"]);
				tagContainer.RemoveTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止交互.冰冻"]);
				tagContainer.RemoveTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止冲刺"]);
				tagContainer.RemoveTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止攀爬"]);
				tagContainer.RemoveTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止行走"]);
				tagContainer.RemoveTag(ETagChannel.Frozen, GameplayTagDefine.EGameplayTagId["战斗状态.行为限制.禁止跳跃"]);
			}
			CharacterAnimationComponent component7 = base.Entity.GetComponent<CharacterAnimationComponent>();
			if (component7 != null)
			{
				UAnimInstance mainAnimInstance = component7.MainAnimInstance;
				if (UKuroStaticLibrary.IsObjectClassByName(mainAnimInstance, Singleton<CharacterNameDefines>.Instance.ABP_BASEROLE))
				{
					ABP_BaseRole_C abp_BaseRole_C = mainAnimInstance as ABP_BaseRole_C;
					if (abp_BaseRole_C == null)
					{
						return;
					}
					abp_BaseRole_C.冰冻结束事件();
				}
			}
		}
	}

	// Token: 0x0601A868 RID: 108648 RVA: 0x007D836C File Offset: 0x007D656C
	[NullableContext(2)]
	protected void ChangeMovementModeInFrozen(CharacterMoveComponent moveComp)
	{
		if (((moveComp != null) ? moveComp.CharacterMovement : null) == null)
		{
			return;
		}
		TEnumAsByte<EMovementMode> movementMode = moveComp.CharacterMovement.MovementMode;
		byte customMovementMode = moveComp.CharacterMovement.CustomMovementMode;
		if (movementMode != EMovementMode.MOVE_Walking && movementMode != EMovementMode.MOVE_Falling && (!(movementMode == EMovementMode.MOVE_Custom) || customMovementMode != 1) && (!(movementMode == EMovementMode.MOVE_Custom) || customMovementMode != 11))
		{
			CharacterActorComponent actorComp = moveComp.ActorComp;
			if (actorComp == null)
			{
				return;
			}
			actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
			{
				Mode = EMovementMode.MOVE_Falling,
				Context = "[RoleFrozenComponent.ChangeMovementModeInFrozen]"
			});
		}
	}

	// Token: 0x0601A869 RID: 108649 RVA: 0x007D8410 File Offset: 0x007D6610
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		RoleFrozenComponent roleFrozenComponent = (RoleFrozenComponent)componentTemplate;
		if (base.CanResetComponentProperty("MoveForbidHandle"))
		{
			this.MoveForbidHandle = roleFrozenComponent.MoveForbidHandle;
		}
		if (base.CanResetComponentProperty("AnimForbidHandle"))
		{
			this.AnimForbidHandle = roleFrozenComponent.AnimForbidHandle;
		}
		if (base.CanResetComponentProperty("AbilityForbidHandle"))
		{
			this.AbilityForbidHandle = roleFrozenComponent.AbilityForbidHandle;
		}
		if (base.CanResetComponentProperty("SkillForbidHandle"))
		{
			this.SkillForbidHandle = roleFrozenComponent.SkillForbidHandle;
		}
		if (base.CanResetComponentProperty("FrozenCueHandle"))
		{
			this.FrozenCueHandle = roleFrozenComponent.FrozenCueHandle;
		}
		if (base.CanResetComponentProperty("IsFrozenInternal"))
		{
			this.IsFrozenInternal = roleFrozenComponent.IsFrozenInternal;
		}
		return true;
	}

	// Token: 0x0400D661 RID: 54881
	[StaticVariableRuleIgnore]
	protected static readonly Vector TmpVector = Vector.Create();

	// Token: 0x0400D662 RID: 54882
	protected int? MoveForbidHandle;

	// Token: 0x0400D663 RID: 54883
	protected int? AnimForbidHandle;

	// Token: 0x0400D664 RID: 54884
	protected int? AbilityForbidHandle;

	// Token: 0x0400D665 RID: 54885
	protected int? SkillForbidHandle;

	// Token: 0x0400D666 RID: 54886
	protected int FrozenCueHandle;

	// Token: 0x0400D667 RID: 54887
	protected bool IsFrozenInternal;
}
