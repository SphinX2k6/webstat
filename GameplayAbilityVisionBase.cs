using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Enum;

// Token: 0x0200315B RID: 12635
[NullableContext(1)]
[Nullable(0)]
public abstract class GameplayAbilityVisionBase
{
	// Token: 0x0601A2DC RID: 107228 RVA: 0x007B0AC3 File Offset: 0x007AECC3
	protected GameplayAbilityVisionBase(CharacterVisionComponent visionComponent)
	{
		this.VisionComponent = visionComponent;
	}

	// Token: 0x0601A2DD RID: 107229 RVA: 0x007B0AD2 File Offset: 0x007AECD2
	public static GameplayAbilityVisionBase Spawn(Func<CharacterVisionComponent, GameplayAbilityVisionBase> visionCtor, CharacterVisionComponent visionComponent)
	{
		GameplayAbilityVisionBase gameplayAbilityVisionBase = visionCtor(visionComponent);
		gameplayAbilityVisionBase.Create();
		return gameplayAbilityVisionBase;
	}

	// Token: 0x0601A2DE RID: 107230 RVA: 0x007B0AE1 File Offset: 0x007AECE1
	public void Create()
	{
		this.OnCreate();
	}

	// Token: 0x0601A2DF RID: 107231 RVA: 0x007B0AE9 File Offset: 0x007AECE9
	public void Destroy()
	{
		this.OnDestroy();
	}

	// Token: 0x0601A2E0 RID: 107232 RVA: 0x007B0AF1 File Offset: 0x007AECF1
	public void Tick(float delta)
	{
		this.OnTick(delta);
	}

	// Token: 0x0601A2E1 RID: 107233 RVA: 0x007B0AFA File Offset: 0x007AECFA
	public bool ActivateAbility()
	{
		return this.OnActivateAbility();
	}

	// Token: 0x0601A2E2 RID: 107234 RVA: 0x007B0B02 File Offset: 0x007AED02
	public bool EndAbility()
	{
		return this.OnEndAbility();
	}

	// Token: 0x0601A2E3 RID: 107235 RVA: 0x007B0B0A File Offset: 0x007AED0A
	public virtual bool HandlePress(EInputAction action, float time)
	{
		return false;
	}

	// Token: 0x0601A2E4 RID: 107236 RVA: 0x007B0B0D File Offset: 0x007AED0D
	public void TeleportStart()
	{
		this.OnTeleportStart();
	}

	// Token: 0x0601A2E5 RID: 107237 RVA: 0x007B0B15 File Offset: 0x007AED15
	protected virtual void OnCreate()
	{
	}

	// Token: 0x0601A2E6 RID: 107238 RVA: 0x007B0B17 File Offset: 0x007AED17
	protected virtual void OnDestroy()
	{
	}

	// Token: 0x0601A2E7 RID: 107239 RVA: 0x007B0B19 File Offset: 0x007AED19
	protected virtual void OnTick(float delta)
	{
	}

	// Token: 0x0601A2E8 RID: 107240 RVA: 0x007B0B1B File Offset: 0x007AED1B
	protected virtual bool OnActivateAbility()
	{
		return true;
	}

	// Token: 0x0601A2E9 RID: 107241 RVA: 0x007B0B1E File Offset: 0x007AED1E
	protected virtual bool OnEndAbility()
	{
		return true;
	}

	// Token: 0x0601A2EA RID: 107242 RVA: 0x007B0B21 File Offset: 0x007AED21
	protected virtual void OnTeleportStart()
	{
	}

	// Token: 0x1700238C RID: 9100
	// (get) Token: 0x0601A2EB RID: 107243 RVA: 0x007B0B23 File Offset: 0x007AED23
	protected Entity Entity
	{
		get
		{
			return this.VisionComponent.Entity;
		}
	}

	// Token: 0x1700238D RID: 9101
	// (get) Token: 0x0601A2EC RID: 107244 RVA: 0x007B0B30 File Offset: 0x007AED30
	[Nullable(2)]
	protected EntityHandle EntityHandle
	{
		[NullableContext(2)]
		get
		{
			return ModelBase<CreatureModel>.Instance.GetEntityById(this.VisionComponent.Entity.Id);
		}
	}

	// Token: 0x1700238E RID: 9102
	// (get) Token: 0x0601A2ED RID: 107245 RVA: 0x007B0B4C File Offset: 0x007AED4C
	protected CreatureDataComponent CreatureDataComponent
	{
		get
		{
			return this.Entity.GetComponent<CreatureDataComponent>();
		}
	}

	// Token: 0x1700238F RID: 9103
	// (get) Token: 0x0601A2EE RID: 107246 RVA: 0x007B0B59 File Offset: 0x007AED59
	protected CharacterActorComponent ActorComponent
	{
		get
		{
			return this.Entity.GetComponent<CharacterActorComponent>();
		}
	}

	// Token: 0x17002390 RID: 9104
	// (get) Token: 0x0601A2EF RID: 107247 RVA: 0x007B0B66 File Offset: 0x007AED66
	protected BaseAttributeComponent AttributeComponent
	{
		get
		{
			return this.Entity.GetComponent<BaseAttributeComponent>();
		}
	}

	// Token: 0x17002391 RID: 9105
	// (get) Token: 0x0601A2F0 RID: 107248 RVA: 0x007B0B73 File Offset: 0x007AED73
	protected BaseTagComponent GameplayTagComponent
	{
		get
		{
			return this.Entity.GetComponent<BaseTagComponent>();
		}
	}

	// Token: 0x17002392 RID: 9106
	// (get) Token: 0x0601A2F1 RID: 107249 RVA: 0x007B0B80 File Offset: 0x007AED80
	protected CharacterSkillComponent SkillComponent
	{
		get
		{
			return this.Entity.GetComponent<CharacterSkillComponent>();
		}
	}

	// Token: 0x17002393 RID: 9107
	// (get) Token: 0x0601A2F2 RID: 107250 RVA: 0x007B0B8D File Offset: 0x007AED8D
	protected CharacterBuffComponent BuffComponent
	{
		get
		{
			return this.Entity.GetComponent<CharacterBuffComponent>();
		}
	}

	// Token: 0x17002394 RID: 9108
	// (get) Token: 0x0601A2F3 RID: 107251 RVA: 0x007B0B9A File Offset: 0x007AED9A
	protected CharacterMoveComponent MoveComponent
	{
		get
		{
			return this.Entity.GetComponent<CharacterMoveComponent>();
		}
	}

	// Token: 0x17002395 RID: 9109
	// (get) Token: 0x0601A2F4 RID: 107252 RVA: 0x007B0BA7 File Offset: 0x007AEDA7
	protected CharacterAudioComponent AudioComponent
	{
		get
		{
			return this.Entity.GetComponent<CharacterAudioComponent>();
		}
	}

	// Token: 0x17002396 RID: 9110
	// (get) Token: 0x0601A2F5 RID: 107253 RVA: 0x007B0BB4 File Offset: 0x007AEDB4
	protected RoleTeamComponent TeamComponent
	{
		get
		{
			return this.Entity.GetComponent<RoleTeamComponent>();
		}
	}

	// Token: 0x17002397 RID: 9111
	// (get) Token: 0x0601A2F6 RID: 107254 RVA: 0x007B0BC1 File Offset: 0x007AEDC1
	protected CharacterGameplayCueComponent CueComponent
	{
		get
		{
			return this.Entity.GetComponent<CharacterGameplayCueComponent>();
		}
	}

	// Token: 0x0400D284 RID: 53892
	protected readonly CharacterVisionComponent VisionComponent;
}
