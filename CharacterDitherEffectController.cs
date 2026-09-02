using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using UnrealEngine;

// Token: 0x02003081 RID: 12417
[NullableContext(2)]
[Nullable(0)]
public class CharacterDitherEffectController
{
	// Token: 0x17002271 RID: 8817
	// (get) Token: 0x06019999 RID: 104857 RVA: 0x007703D7 File Offset: 0x0076E5D7
	private bool IsHiddenInGame
	{
		get
		{
			return this.Actor == null || !this.Actor.IsValid() || this.Actor.bHidden;
		}
	}

	// Token: 0x17002272 RID: 8818
	// (get) Token: 0x0601999A RID: 104858 RVA: 0x007703FB File Offset: 0x0076E5FB
	public double CurrentDitherValue
	{
		get
		{
			return (double)this.CurrentDither;
		}
	}

	// Token: 0x17002273 RID: 8819
	// (get) Token: 0x0601999B RID: 104859 RVA: 0x00770404 File Offset: 0x0076E604
	public bool IsInAutoAnimationValue
	{
		get
		{
			return this.IsInAutoAnimation;
		}
	}

	// Token: 0x17002274 RID: 8820
	// (get) Token: 0x0601999C RID: 104860 RVA: 0x0077040C File Offset: 0x0076E60C
	public float DitherSpeedRateValue
	{
		get
		{
			return this.DitherSpeedRate;
		}
	}

	// Token: 0x17002275 RID: 8821
	// (get) Token: 0x0601999D RID: 104861 RVA: 0x00770414 File Offset: 0x0076E614
	public bool IsDisableValue
	{
		get
		{
			return this.IsDisable;
		}
	}

	// Token: 0x0601999E RID: 104862 RVA: 0x0077041C File Offset: 0x0076E61C
	[NullableContext(1)]
	public CharacterDitherEffectController(AActor actor, CharRenderingComponent charRenderingComponent)
	{
		this.Actor = actor;
		TsBaseCharacter tsBaseCharacter = actor as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			this.Entity = tsBaseCharacter.GetEntityNoBlueprint();
		}
		else
		{
			TsBaseVehicle tsBaseVehicle = actor as TsBaseVehicle;
			if (tsBaseVehicle != null)
			{
				this.Entity = tsBaseVehicle.GetEntityNoBlueprint();
			}
		}
		this.CharRenderingComponent = charRenderingComponent;
		if (!ObjectUtils.IsValid(this.CharRenderingComponent))
		{
			this.IsDisable = false;
		}
	}

	// Token: 0x0601999F RID: 104863 RVA: 0x00770498 File Offset: 0x0076E698
	public void SetIsDisable(bool isDisable, ECharacterDitherType ditherType = ECharacterDitherType.Temporary)
	{
		if (this.IsDisable == isDisable)
		{
			return;
		}
		this.IsDisable = isDisable;
		if (isDisable)
		{
			this.SetHiddenInGame(true, false);
			return;
		}
		if (!this.IsInAutoAnimation && Singleton<MathUtils>.Instance.IsNearlyZero((double)this.CurrentDither, new double?(0.0001)))
		{
			this.SetHiddenInGame(true, false);
		}
		else
		{
			this.SetHiddenInGame(false, false);
		}
		if (this.CurrentDitherType != ECharacterDitherType.UnDefined)
		{
			CharRenderingComponent charRenderingComponent = this.CharRenderingComponent;
			if (charRenderingComponent == null)
			{
				return;
			}
			charRenderingComponent.SetDitherEffect(this.CurrentDither, this.CurrentDitherType);
		}
	}

	// Token: 0x060199A0 RID: 104864 RVA: 0x00770524 File Offset: 0x0076E724
	public void EnterAppearEffect(float ditherSpeedRate = 1f, ECharacterDitherType ditherType = ECharacterDitherType.Temporary, bool replay = true)
	{
		if (this.IsHiddenInGame)
		{
			this.SetHiddenInGame(false, true);
		}
		this.HasForceUpdated = false;
		this.IsInAutoAnimation = true;
		this.CurrentDitherType = ditherType;
		this.DitherSpeedRate = ditherSpeedRate;
		if (replay)
		{
			this.CurrentDither = 0f;
			CharRenderingComponent charRenderingComponent = this.CharRenderingComponent;
			if (charRenderingComponent == null)
			{
				return;
			}
			charRenderingComponent.SetDitherEffect(this.CurrentDither, this.CurrentDitherType);
		}
	}

	// Token: 0x060199A1 RID: 104865 RVA: 0x00770588 File Offset: 0x0076E788
	public void EnterDisappearEffect(float ditherSpeedRate = 1f, ECharacterDitherType ditherType = ECharacterDitherType.Temporary, bool replay = true)
	{
		if (this.IsHiddenInGame)
		{
			this.CurrentDither = 0f;
			this.CurrentDitherType = ditherType;
			this.ForceUpdate();
			return;
		}
		this.IsInAutoAnimation = true;
		this.CurrentDitherType = ditherType;
		this.DitherSpeedRate = -ditherSpeedRate;
		if (replay)
		{
			this.CurrentDither = 1f;
			CharRenderingComponent charRenderingComponent = this.CharRenderingComponent;
			if (charRenderingComponent == null)
			{
				return;
			}
			charRenderingComponent.SetDitherEffect(this.CurrentDither, this.CurrentDitherType);
		}
	}

	// Token: 0x060199A2 RID: 104866 RVA: 0x007705F8 File Offset: 0x0076E7F8
	public void SetDitherEffect(double dither, ECharacterDitherType ditherType = ECharacterDitherType.Temporary, bool clearAnimationState = true)
	{
		if (this.IsInAutoAnimation && ditherType < this.CurrentDitherType)
		{
			return;
		}
		this.CurrentDither = (float)Singleton<MathUtils>.Instance.Clamp(dither, 0.0, 1.0);
		this.CurrentDitherType = ditherType;
		if (this.IsDisable)
		{
			return;
		}
		this.SetHiddenInGame(Singleton<MathUtils>.Instance.IsNearlyZero((double)this.CurrentDither, new double?(0.0001)), clearAnimationState);
		CharRenderingComponent charRenderingComponent = this.CharRenderingComponent;
		if (charRenderingComponent == null)
		{
			return;
		}
		charRenderingComponent.SetDitherEffect(this.CurrentDither, ditherType);
	}

	// Token: 0x060199A3 RID: 104867 RVA: 0x00770688 File Offset: 0x0076E888
	public void SetHiddenInGame(bool isHiddenInGame, bool clearAnimationState)
	{
		if (this.Actor == null)
		{
			return;
		}
		if (this.Entity != null)
		{
			BaseActorComponent component = this.Entity.GetComponent<BaseActorComponent>();
			if (component == null)
			{
				return;
			}
			if (isHiddenInGame)
			{
				if (this.DisableActorHandle != null)
				{
					return;
				}
				this.DisableActorHandle = new int?(component.DisableActor("[CharacterDitherEffectController.SetHiddenInGame]"));
				NpcPerformComponent component2 = this.Entity.GetComponent<NpcPerformComponent>();
				if (component2 == null || !component2.IsNpcOutShowRange)
				{
					this.DisableCollisionHandle = new int?(component.DisableCollision("[CharacterDitherEffectController.SetHiddenInGame]"));
				}
			}
			else
			{
				if (this.DisableActorHandle != null)
				{
					component.EnableActor(this.DisableActorHandle.Value);
					this.DisableActorHandle = null;
				}
				if (this.DisableCollisionHandle != null)
				{
					component.EnableCollision(this.DisableCollisionHandle.Value);
					this.DisableCollisionHandle = null;
				}
			}
		}
		else if (this.Actor.IsValid())
		{
			if (this.IsHiddenInGame == isHiddenInGame)
			{
				return;
			}
			this.Actor.SetActorHiddenInGame(isHiddenInGame);
			this.Actor.SetActorEnableCollision(!isHiddenInGame);
		}
		if (isHiddenInGame && clearAnimationState && this.IsInAutoAnimation)
		{
			this.IsInAutoAnimation = false;
			this.CurrentDither = 0f;
		}
	}

	// Token: 0x060199A4 RID: 104868 RVA: 0x007707C4 File Offset: 0x0076E9C4
	public void Update(float deltaTime)
	{
		if (!this.IsDisable && this.IsInAutoAnimation)
		{
			float ditherDelta = deltaTime * 0.001f * this.DitherSpeedRate;
			this.AddDitherEffectInternal(ditherDelta, this.CurrentDitherType);
		}
	}

	// Token: 0x060199A5 RID: 104869 RVA: 0x00770800 File Offset: 0x0076EA00
	private void ForceUpdate()
	{
		if (this.HasForceUpdated)
		{
			return;
		}
		this.HasForceUpdated = true;
		this.SetHiddenInGame(Singleton<MathUtils>.Instance.IsNearlyZero((double)this.CurrentDither, new double?(0.0001)), true);
		CharRenderingComponent charRenderingComponent = this.CharRenderingComponent;
		if (charRenderingComponent != null)
		{
			charRenderingComponent.SetDitherEffect(this.CurrentDither, this.CurrentDitherType);
		}
		CharRenderingComponent charRenderingComponent2 = this.CharRenderingComponent;
		if (charRenderingComponent2 == null)
		{
			return;
		}
		charRenderingComponent2.UpdateMaterialEffectsOnly();
	}

	// Token: 0x060199A6 RID: 104870 RVA: 0x00770870 File Offset: 0x0076EA70
	public void ForceResetDither()
	{
		this.CurrentDither = 0f;
		this.CurrentDitherType = ECharacterDitherType.Fight;
		this.ForceUpdate();
	}

	// Token: 0x060199A7 RID: 104871 RVA: 0x0077088C File Offset: 0x0076EA8C
	private void AddDitherEffectInternal(float ditherDelta, ECharacterDitherType ditherType)
	{
		this.CurrentDither = Singleton<MathUtils>.Instance.Clamp(this.CurrentDither + ditherDelta, 0f, 1f);
		if (this.CurrentDither == 0f && ditherDelta < 0f)
		{
			this.IsInAutoAnimation = false;
			this.SetHiddenInGame(true, true);
		}
		else if (this.CurrentDither == 1f && ditherDelta > 0f)
		{
			this.IsInAutoAnimation = false;
		}
		CharRenderingComponent charRenderingComponent = this.CharRenderingComponent;
		if (charRenderingComponent == null)
		{
			return;
		}
		charRenderingComponent.SetDitherEffect(this.CurrentDither, ditherType);
	}

	// Token: 0x060199A8 RID: 104872 RVA: 0x00770914 File Offset: 0x0076EB14
	public void Clear()
	{
		this.Actor = null;
		if (this.CharRenderingComponent != null)
		{
			this.CharRenderingComponent.ResetAllRenderingState();
		}
		this.CharRenderingComponent = null;
		this.DisableActorHandle = null;
		this.DisableCollisionHandle = null;
	}

	// Token: 0x0400CBA7 RID: 52135
	private const float MILLISECOND_TO_SECOND = 0.001f;

	// Token: 0x0400CBA8 RID: 52136
	private AActor Actor;

	// Token: 0x0400CBA9 RID: 52137
	private Entity Entity;

	// Token: 0x0400CBAA RID: 52138
	private CharRenderingComponent CharRenderingComponent;

	// Token: 0x0400CBAB RID: 52139
	private bool IsInAutoAnimation;

	// Token: 0x0400CBAC RID: 52140
	private float CurrentDither = 1f;

	// Token: 0x0400CBAD RID: 52141
	private ECharacterDitherType CurrentDitherType;

	// Token: 0x0400CBAE RID: 52142
	private float DitherSpeedRate = 1f;

	// Token: 0x0400CBAF RID: 52143
	private bool IsDisable;

	// Token: 0x0400CBB0 RID: 52144
	private int? DisableActorHandle;

	// Token: 0x0400CBB1 RID: 52145
	private int? DisableCollisionHandle;

	// Token: 0x0400CBB2 RID: 52146
	private bool HasForceUpdated;
}
