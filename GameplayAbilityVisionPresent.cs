using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02003160 RID: 12640
[NullableContext(1)]
[Nullable(0)]
public class GameplayAbilityVisionPresent : GameplayAbilityVisionMorph
{
	// Token: 0x0601A324 RID: 107300 RVA: 0x007B206F File Offset: 0x007B026F
	public GameplayAbilityVisionPresent(CharacterVisionComponent visionComponent) : base(visionComponent)
	{
	}

	// Token: 0x0601A325 RID: 107301 RVA: 0x007B2090 File Offset: 0x007B0290
	[NullableContext(2)]
	protected override void SetVisionEnable(bool enable, EntityHandle visionEntity = null)
	{
		if (visionEntity == null)
		{
			visionEntity = this.VisionEntity;
		}
		if (enable)
		{
			this.NeedResetLocation = true;
			this.DangoOriginalPosition.DeepCopy(this.VisionActorComponent.ActorLocationProxy);
			this.DangoOriginalRotation.DeepCopy(this.VisionActorComponent.ActorRotationProxy);
			ControllerBase<CreatureController>.Instance.SetEntityEnable(visionEntity.Entity, enable, "GameplayAbilityVisionPresent.SetVisionEnable", true);
		}
		else
		{
			this.VisionSkillComponent.StopGroup1Skill("驻场声骸技能结束");
			if (this.NeedResetLocation)
			{
				this.VisionActorComponent.SetActorLocationAndRotation(this.DangoOriginalPosition.ToUeVector(false), this.DangoOriginalRotation.ToUeRotator(), "驻场声骸消失时恢复原来的位置", false, null);
			}
			this.NeedResetLocation = true;
			this.VisionBuffComponent.AddBuff(1900000017L, new AddBuffParam
			{
				InstigatorId = this.VisionBuffComponent.CreatureDataId,
				Reason = "驻场声骸归位时的材质和粒子"
			});
		}
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPhantomEnableStateChange, enable);
	}

	// Token: 0x0601A326 RID: 107302 RVA: 0x007B218E File Offset: 0x007B038E
	protected override bool NeedNoAi()
	{
		return false;
	}

	// Token: 0x0601A327 RID: 107303 RVA: 0x007B2191 File Offset: 0x007B0391
	protected override bool NeedNoActive()
	{
		return false;
	}

	// Token: 0x0601A328 RID: 107304 RVA: 0x007B2194 File Offset: 0x007B0394
	protected override void OnTeleportStart()
	{
		this.NeedResetLocation = false;
	}

	// Token: 0x0400D2B1 RID: 53937
	private readonly Vector DangoOriginalPosition = Vector.Create();

	// Token: 0x0400D2B2 RID: 53938
	private readonly Rotator DangoOriginalRotation = Rotator.Create();

	// Token: 0x0400D2B3 RID: 53939
	private bool NeedResetLocation;
}
