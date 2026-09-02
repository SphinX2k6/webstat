using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x0200314A RID: 12618
[NullableContext(1)]
[Nullable(0)]
public class SpecialSkillKatixiya : SpecialSkillMorphBase
{
	// Token: 0x17002379 RID: 9081
	// (get) Token: 0x0601A208 RID: 107016 RVA: 0x007AAE02 File Offset: 0x007A9002
	protected override string MorphBuffsConfigKey
	{
		get
		{
			return "KatixiyaMorphBuffs";
		}
	}

	// Token: 0x1700237A RID: 9082
	// (get) Token: 0x0601A209 RID: 107017 RVA: 0x007AAE09 File Offset: 0x007A9009
	protected override string MorphCueIdConfigKey
	{
		get
		{
			return "KatixiyaMorphCues";
		}
	}

	// Token: 0x1700237B RID: 9083
	// (get) Token: 0x0601A20A RID: 107018 RVA: 0x007AAE10 File Offset: 0x007A9010
	protected override string ResetMorphSkillsConfigKey
	{
		get
		{
			return "KatixiyaResetMorphSkills";
		}
	}

	// Token: 0x1700237C RID: 9084
	// (get) Token: 0x0601A20B RID: 107019 RVA: 0x007AAE17 File Offset: 0x007A9017
	protected override string NotResetMorphSkillsConfigKey
	{
		get
		{
			return "KatixiyaNotResetMorphSkills";
		}
	}

	// Token: 0x1700237D RID: 9085
	// (get) Token: 0x0601A20C RID: 107020 RVA: 0x007AAE1E File Offset: 0x007A901E
	protected override string ChangeRoleResetMorphTagsConfigKey
	{
		get
		{
			return "KatixiyaChangeRoleResetMorphTags";
		}
	}

	// Token: 0x1700237E RID: 9086
	// (get) Token: 0x0601A20D RID: 107021 RVA: 0x007AAE25 File Offset: 0x007A9025
	protected override string Morph0SubMeshConfigKey
	{
		get
		{
			return "KatixiyaMorph0SubMeshList";
		}
	}

	// Token: 0x1700237F RID: 9087
	// (get) Token: 0x0601A20E RID: 107022 RVA: 0x007AAE2C File Offset: 0x007A902C
	protected override string Morph1SubMeshConfigKey
	{
		get
		{
			return "KatixiyaMorph1SubMeshList";
		}
	}

	// Token: 0x0601A20F RID: 107023 RVA: 0x007AAE33 File Offset: 0x007A9033
	public SpecialSkillKatixiya(CharacterSpecialSkillComponent specialSkillComponent) : base(specialSkillComponent)
	{
	}

	// Token: 0x0601A210 RID: 107024 RVA: 0x007AAE3C File Offset: 0x007A903C
	public override void OnStart()
	{
		base.OnStart();
		Entity entity = this.SpecialSkillComponent.Entity;
		this.RoleEnergyComp = entity.GetComponent<RoleEnergyComponent>();
		Singleton<EventSystem>.Instance.AddWithTarget<Entity, EMorphType, EMorphType>(entity, EEventName.OnBeforeCharacterMorphTypeChanged, new Action<Entity, EMorphType, EMorphType>(this.OnBeforeCharacterMorphTypeChanged));
	}

	// Token: 0x0601A211 RID: 107025 RVA: 0x007AAE84 File Offset: 0x007A9084
	public override void OnEnd()
	{
		base.OnEnd();
		Entity entity = this.SpecialSkillComponent.Entity;
		Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, EMorphType, EMorphType>(entity, EEventName.OnBeforeCharacterMorphTypeChanged, new Action<Entity, EMorphType, EMorphType>(this.OnBeforeCharacterMorphTypeChanged));
		this.ClearTimer();
	}

	// Token: 0x0601A212 RID: 107026 RVA: 0x007AAEC6 File Offset: 0x007A90C6
	private void ClearTimer()
	{
		if (this.UpdateMaterialTimer != null)
		{
			TimerSystem.Instance.Remove(this.UpdateMaterialTimer);
			this.UpdateMaterialTimer = null;
		}
	}

	// Token: 0x0601A213 RID: 107027 RVA: 0x007AAEE8 File Offset: 0x007A90E8
	private void CheckCurrentSkill()
	{
		BaseSkillComponent skillComp = this.SkillComp;
		Skill skill = (skillComp != null) ? skillComp.CurrentSkill : null;
		if (skill == null)
		{
			return;
		}
		UAnimMontage[] loadedMontages = skill.GetLoadedMontages();
		if (loadedMontages == null)
		{
			return;
		}
		BaseAnimationComponent animComp = this.AnimComp;
		UAnimInstance uanimInstance = (animComp != null) ? animComp.MainAnimInstance : null;
		if (uanimInstance == null)
		{
			return;
		}
		UAnimMontage[] array = loadedMontages;
		int i = 0;
		while (i < array.Length)
		{
			UAnimMontage montage = array[i];
			if (uanimInstance.Montage_IsPlaying(montage))
			{
				BaseSkillComponent skillComp2 = this.SkillComp;
				if (skillComp2 == null)
				{
					return;
				}
				skillComp2.StopGroup1Skill("形态变化时存在正在播放的技能动画");
				return;
			}
			else
			{
				i++;
			}
		}
	}

	// Token: 0x0601A214 RID: 107028 RVA: 0x007AAF68 File Offset: 0x007A9168
	protected override void OnCharacterMorphTypeChanged(Entity entity, EMorphType newMorphType, EMorphType oldMorphType)
	{
		if (newMorphType == EMorphType.默认形态)
		{
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null && actorComp.IsRoleAndCtrlByMe)
			{
				this.ClearTimer();
				this.UpdateMaterialTimer = TimerSystem.Instance.Delay(delegate(float _)
				{
					RoleEnergyComponent roleEnergyComp = this.RoleEnergyComp;
					if (roleEnergyComp != null)
					{
						roleEnergyComp.RefreshStarScarMaterial();
					}
					this.UpdateMaterialTimer = null;
				}, 500f, null, null, true, 1f);
			}
		}
		base.RefreshNoUpdateMeshes(newMorphType);
	}

	// Token: 0x0601A215 RID: 107029 RVA: 0x007AAFC4 File Offset: 0x007A91C4
	private void OnBeforeCharacterMorphTypeChanged(Entity entity, EMorphType newMorphType, EMorphType oldMorphType)
	{
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null && actorComp.IsRoleAndCtrlByMe)
		{
			this.CheckCurrentSkill();
			CharacterDitherEffectController ditherEffectController = this.ActorComp.Actor.DitherEffectController;
			if (ditherEffectController == null || ditherEffectController.CurrentDitherValue != (double)1)
			{
				CharRenderingComponent charRenderingComponent = this.ActorComp.Actor.CharRenderingComponent;
				if (charRenderingComponent == null)
				{
					return;
				}
				charRenderingComponent.SetDitherEffect(1f, ECharacterDitherType.Fight);
			}
		}
	}

	// Token: 0x0400D1C4 RID: 53700
	private const int UPDATE_MATERIAL_DELAY = 500;

	// Token: 0x0400D1C5 RID: 53701
	[Nullable(2)]
	private RoleEnergyComponent RoleEnergyComp;

	// Token: 0x0400D1C6 RID: 53702
	[Nullable(2)]
	private TimerHandle UpdateMaterialTimer;
}
