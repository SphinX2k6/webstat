using System;
using System.Runtime.CompilerServices;
using Aki.Protocol.Summon;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Vision;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02003161 RID: 12641
[NullableContext(2)]
[Nullable(0)]
public class GameplayAbilityVisionShow : GameplayAbilityVisionBase
{
	// Token: 0x0601A329 RID: 107305 RVA: 0x007B219D File Offset: 0x007B039D
	[NullableContext(1)]
	public GameplayAbilityVisionShow(CharacterVisionComponent visionComponent) : base(visionComponent)
	{
	}

	// Token: 0x0601A32A RID: 107306 RVA: 0x007B21A6 File Offset: 0x007B03A6
	protected override void OnCreate()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.BulletDestroy, new Action<BulletInfo>(this.OnBulletDestroy));
	}

	// Token: 0x0601A32B RID: 107307 RVA: 0x007B21CA File Offset: 0x007B03CA
	protected override void OnDestroy()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.BulletDestroy, new Action<BulletInfo>(this.OnBulletDestroy));
	}

	// Token: 0x0601A32C RID: 107308 RVA: 0x007B21EE File Offset: 0x007B03EE
	protected override bool OnActivateAbility()
	{
		if (!this.PreSummon())
		{
			return false;
		}
		base.SkillComponent.PlaySkillMontage(0, "", 0f, delegate(bool _)
		{
			BaseSkillComponent skillComponent = base.SkillComponent;
			Skill currentSkill = base.SkillComponent.CurrentSkill;
			skillComponent.EndSkill((currentSkill != null) ? currentSkill.SkillId : 0, "GameplayAbilityVisionShow.OnActivateAbility");
		});
		return true;
	}

	// Token: 0x0601A32D RID: 107309 RVA: 0x007B2220 File Offset: 0x007B0420
	private bool PreSummon()
	{
		this.VisionEntity = PhantomUtil.GetSummonedEntity(this.VisionComponent.Entity, ESummonType.ConcomitantVision, 1);
		if (this.VisionEntity.Entity.Active)
		{
			return false;
		}
		this.VisionActorComponent = this.VisionEntity.Entity.GetComponent<CharacterActorComponent>();
		this.VisionSkillComponent = this.VisionEntity.Entity.GetComponent<CharacterSkillComponent>();
		return true;
	}

	// Token: 0x0601A32E RID: 107310 RVA: 0x007B2288 File Offset: 0x007B0488
	[NullableContext(1)]
	private void OnBulletDestroy(BulletInfo bulletInfo)
	{
		if (this.VisionEntity != null && bulletInfo.BulletDataMain.Execution.SendGameplayEventTagToAttackerOnEnd.TagId() == GameplayTagDefine.EGameplayTagId["幻象.展示.葫芦落地"] && !base.GameplayTagComponent.HasTag(GameplayAbilityVisionMisc.morphTag))
		{
			this.Summon(bulletInfo.MoveInfo.LastFramePosition.ToUeVector(false));
		}
	}

	// Token: 0x0601A32F RID: 107311 RVA: 0x007B22EC File Offset: 0x007B04EC
	private void Summon(FVectorDouble location)
	{
		float num = 1f;
		BP_BaseVision_C bp_BaseVision_C = this.VisionActorComponent.Actor as BP_BaseVision_C;
		if (bp_BaseVision_C != null)
		{
			num = bp_BaseVision_C.显像放大比例.Z;
		}
		FVectorDouble fvectorDouble = new FVectorDouble(0.0, 0.0, (double)(this.VisionActorComponent.ScaledHalfHeight * num));
		this.VisionActorComponent.SetActorLocationAndRotation(location + fvectorDouble, base.ActorComponent.ActorRotation, "召唤展示生成位置", false, null);
		ControllerBase<CreatureController>.Instance.SetEntityEnable(this.VisionEntity.Entity, true, "GameplayAbilityVisionShow.SetVisionEnable", true);
		this.SetCollision(false);
		this.VisionSkillComponent.BeginSkillAsync(1200000, new SkillParam
		{
			Reason = "GameplayAbilityVisionShow.PostSummon"
		});
	}

	// Token: 0x0601A330 RID: 107312 RVA: 0x007B23BC File Offset: 0x007B05BC
	private void SetCollision(bool enable)
	{
		Singleton<CollisionUtils>.Instance.SetCollisionResponseToPawn(this.VisionActorComponent.Actor.CapsuleComponent, EPawnChannel.PawnPlayer, enable ? ECollisionResponse.ECR_Block : ECollisionResponse.ECR_Ignore);
		this.VisionActorComponent.Actor.CapsuleComponent.IgnoreActorWhenMoving(base.ActorComponent.Actor, !enable);
		base.ActorComponent.Actor.CapsuleComponent.IgnoreActorWhenMoving(this.VisionActorComponent.Actor, !enable);
	}

	// Token: 0x0400D2B4 RID: 53940
	private EntityHandle VisionEntity;

	// Token: 0x0400D2B5 RID: 53941
	private CharacterActorComponent VisionActorComponent;

	// Token: 0x0400D2B6 RID: 53942
	private CharacterSkillComponent VisionSkillComponent;
}
