using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Audio;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Audio;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

// Token: 0x020031E5 RID: 12773
[NullableContext(1)]
[Nullable(0)]
public class RoleAudioComponent : CharacterAudioComponent, IStaticVariableResetter
{
	// Token: 0x0601A7A6 RID: 108454 RVA: 0x007D2377 File Offset: 0x007D0577
	static RoleAudioComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(RoleAudioComponent.CreateStaticDefaultValue), new Action(RoleAudioComponent.ResetStaticDefaultValue));
	}

	// Token: 0x0601A7A7 RID: 108455 RVA: 0x007D2398 File Offset: 0x007D0598
	public static void CreateStaticDefaultValue()
	{
		RoleAudioComponent.FootstepVariantMap = new Dictionary<E_FootstepVariant, string>
		{
			{
				E_FootstepVariant.land,
				"land"
			},
			{
				E_FootstepVariant.run,
				"run"
			},
			{
				E_FootstepVariant.runstop,
				"runstop"
			},
			{
				E_FootstepVariant.sprint,
				"sprint"
			},
			{
				E_FootstepVariant.sprintstop,
				"sprintstop"
			},
			{
				E_FootstepVariant.walk,
				"walk"
			},
			{
				E_FootstepVariant.walkstop,
				"walkstop"
			},
			{
				E_FootstepVariant.turnback,
				"turnback"
			}
		};
		RoleAudioComponent.FoleyVariantMap = new Dictionary<E_FoleyVariant, string>
		{
			{
				E_FoleyVariant.bodyfall,
				"bodyfall"
			},
			{
				E_FoleyVariant.fly,
				"fly"
			},
			{
				E_FoleyVariant.run,
				"run"
			},
			{
				E_FoleyVariant.sprint,
				"sprint"
			},
			{
				E_FoleyVariant.hard,
				"hard"
			},
			{
				E_FoleyVariant.hardfast,
				"hardfast"
			},
			{
				E_FoleyVariant.weak,
				"weak"
			},
			{
				E_FoleyVariant.weakfast,
				"weakfast"
			}
		};
		RoleAudioComponent.LastTickTime = 0.0;
		RoleAudioComponent.LocationCache = global::Vector.Create();
	}

	// Token: 0x0601A7A8 RID: 108456 RVA: 0x007D2491 File Offset: 0x007D0691
	public static void ResetStaticDefaultValue()
	{
		RoleAudioComponent.FootstepVariantMap = null;
		RoleAudioComponent.FoleyVariantMap = null;
		RoleAudioComponent.LastTickTime = 0.0;
		RoleAudioComponent.LocationCache = null;
	}

	// Token: 0x0601A7A9 RID: 108457 RVA: 0x007D24B4 File Offset: 0x007D06B4
	protected override bool OnInit()
	{
		base.OnInit();
		this.LoadConfig();
		this.StateComp = base.Entity.CheckGetComponent<CharacterUnifiedStateComponent>();
		this.AttributeComponent = base.Entity.CheckGetComponent<BaseAttributeComponent>();
		if (this.Config != null)
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnRoleSkinChange, new Action<int>(this.OnRoleSkinChanged));
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnBeDamage));
			Singleton<EventSystem>.Instance.AddWithTarget<int, int, bool>(base.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnUseSkill));
			Singleton<EventSystem>.Instance.AddWithTarget<int, int>(base.Entity, EEventName.CharUseSkillRemote, new Action<int, int>(this.OnUseSkillRemote));
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnRoleGoDownFinish, new Action(this.OnGoDownFinish));
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharPossessed, new Action<Entity, AController>(this.OnCharPossessed));
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharUnpossessed, new Action<Entity, AController>(this.OnCharUnpossessed));
			Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.OnInteractionWaterTypeChange, new Action<EInteractionWaterType>(this.OnInteractionWaterTypeChange));
			Singleton<EventSystem>.Instance.AddWithTarget<int, EMovementMode, EMovementMode, byte, byte>(base.Entity, EEventName.CharMovementModeChanged, new Action<int, EMovementMode, EMovementMode, byte, byte>(this.OnCharacterMovementModeChanged));
		}
		return true;
	}

	// Token: 0x0601A7AA RID: 108458 RVA: 0x007D2624 File Offset: 0x007D0824
	protected override bool OnEnd()
	{
		base.OnEnd();
		this.PostGoDownFinishEvent();
		return true;
	}

	// Token: 0x0601A7AB RID: 108459 RVA: 0x007D2634 File Offset: 0x007D0834
	protected override bool OnClear()
	{
		base.OnClear();
		if (this.Config != null)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRoleSkinChange, new Action<int>(this.OnRoleSkinChanged));
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnBeDamage));
			Singleton<EventSystem>.Instance.RemoveWithTarget<int, int, bool>(base.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnUseSkill));
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharUseSkillRemote, new Action<int, int>(this.OnUseSkillRemote));
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnRoleGoDownFinish, new Action(this.OnGoDownFinish));
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharPossessed, new Action<Entity, AController>(this.OnCharPossessed));
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharUnpossessed, new Action<Entity, AController>(this.OnCharUnpossessed));
			Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.OnInteractionWaterTypeChange, new Action<EInteractionWaterType>(this.OnInteractionWaterTypeChange));
			Singleton<EventSystem>.Instance.RemoveWithTarget<int, EMovementMode, EMovementMode, byte, byte>(base.Entity, EEventName.CharMovementModeChanged, new Action<int, EMovementMode, EMovementMode, byte, byte>(this.OnCharacterMovementModeChanged));
		}
		return true;
	}

	// Token: 0x0601A7AC RID: 108460 RVA: 0x007D277C File Offset: 0x007D097C
	protected override bool OnStart()
	{
		base.OnStart();
		this.ChangeRoleName((((this.Config != null) ? this.Config.GetValueOrDefault().Name : null) != null) ? this.Config.Value.Name : "chixia");
		this.SetAudioMoveState(EMoveState.None);
		return true;
	}

	// Token: 0x0601A7AD RID: 108461 RVA: 0x007D27E0 File Offset: 0x007D09E0
	protected override void OnTick(float delta)
	{
		int id = base.Entity.Id;
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		int? num = (baseCharacter != null) ? new int?(baseCharacter.EntityId) : null;
		if ((id == num.GetValueOrDefault() & num != null) && Singleton<Time>.Instance.Now - RoleAudioComponent.LastTickTime > 250.0)
		{
			RoleAudioComponent.LastTickTime = Singleton<Time>.Instance.Now;
			this.UpdateEnvironment();
		}
	}

	// Token: 0x0601A7AE RID: 108462 RVA: 0x007D285C File Offset: 0x007D0A5C
	protected override void OnAkComponentCreated()
	{
		base.OnAkComponentCreated();
		CharacterActorComponent actorComp = base.ActorComp;
		if (((actorComp != null) ? actorComp.Owner : null) == null)
		{
			return;
		}
		Singleton<AudioSystem>.Instance.SetSwitch("role_name", this.CurrentRoleName, base.ActorComp.Owner);
		Singleton<AudioSystem>.Instance.SetSwitch("footstep_texture", this.CurrentFootstepTexture, base.ActorComp.Owner);
		Singleton<AudioSystem>.Instance.SetSwitch("footstep_variant", this.CurrentFootstepVariant, base.ActorComp.Owner);
		Singleton<AudioSystem>.Instance.SetSwitch("foley_variant", this.CurrentFoleyVariant, base.ActorComp.Owner);
		Singleton<AudioSystem>.Instance.SetSwitch("role_interact_water", this.CurrentWaterType, base.ActorComp.Owner);
	}

	// Token: 0x0601A7AF RID: 108463 RVA: 0x007D2924 File Offset: 0x007D0B24
	public void ChangeRoleName(string name)
	{
		CharacterActorComponent actorComp = base.ActorComp;
		if (((actorComp != null) ? actorComp.Owner : null) == null)
		{
			return;
		}
		this.CurrentRoleName = name;
		Singleton<AudioSystem>.Instance.SetSwitch("role_name", this.CurrentRoleName, base.ActorComp.Owner);
	}

	// Token: 0x0601A7B0 RID: 108464 RVA: 0x007D2964 File Offset: 0x007D0B64
	public void ChangeFootstepTexture(CharacterFootEffectComponent.EFootstepTexture texture)
	{
		CharacterActorComponent actorComp = base.ActorComp;
		if (((actorComp != null) ? actorComp.Owner : null) == null)
		{
			return;
		}
		this.CurrentFootstepTexture = texture.ToEnumString();
		Singleton<AudioSystem>.Instance.SetSwitch("footstep_texture", this.CurrentFootstepTexture, base.ActorComp.Owner);
	}

	// Token: 0x0601A7B1 RID: 108465 RVA: 0x007D29B4 File Offset: 0x007D0BB4
	public void ChangeFootstepVariant(E_FootstepVariant variant)
	{
		CharacterActorComponent actorComp = base.ActorComp;
		if (((actorComp != null) ? actorComp.Owner : null) == null)
		{
			return;
		}
		string currentFootstepVariant;
		if (!RoleAudioComponent.FootstepVariantMap.TryGetValue(variant, out currentFootstepVariant))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[ChangeFootstepVariant] Map里不含指定枚举类型E_FootstepVariant项,需要更新Map";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Variant", variant);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.CurrentFootstepVariant = currentFootstepVariant;
		Singleton<AudioSystem>.Instance.SetSwitch("footstep_variant", this.CurrentFootstepVariant, base.ActorComp.Owner);
	}

	// Token: 0x0601A7B2 RID: 108466 RVA: 0x007D2A3C File Offset: 0x007D0C3C
	public void ChangeFoleyVariant(E_FoleyVariant variant)
	{
		CharacterActorComponent actorComp = base.ActorComp;
		if (((actorComp != null) ? actorComp.Owner : null) == null)
		{
			return;
		}
		string currentFoleyVariant;
		if (!RoleAudioComponent.FoleyVariantMap.TryGetValue(variant, out currentFoleyVariant))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[ChangeFoleyVariant] Map里不含指定枚举类型E_FoleyVariant项,需要更新Map";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Variant", variant);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.CurrentFoleyVariant = currentFoleyVariant;
		Singleton<AudioSystem>.Instance.SetSwitch("foley_variant", this.CurrentFoleyVariant, base.ActorComp.Owner);
	}

	// Token: 0x0601A7B3 RID: 108467 RVA: 0x007D2AC4 File Offset: 0x007D0CC4
	private void LoadConfig()
	{
		CreatureDataComponent creatureData = this.CreatureData;
		if (creatureData == null || !creatureData.Valid || ModelBase<RoleModel>.Instance == null)
		{
			return;
		}
		int pbDataId = this.CreatureData.GetPbDataId();
		int id = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(pbDataId);
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(id);
		if (roleConfig != null && roleConfig.Value.RoleType != 1 && roleConfig.Value.ParentId != 0)
		{
			id = roleConfig.Value.ParentId;
			roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(id);
		}
		if (roleConfig == null || roleConfig.Value.RoleType != 1)
		{
			return;
		}
		int skinId = this.CreatureData.GetSkinId();
		if (skinId == 0)
		{
			skinId = roleConfig.Value.SkinId;
		}
		this.Config = ConfigRoleSkinAudioById.GetConfig(skinId, true);
		this.InitFoleyEvent();
		this.InitFootstepEvent();
	}

	// Token: 0x0601A7B4 RID: 108468 RVA: 0x007D2BB8 File Offset: 0x007D0DB8
	private void OnRoleSkinChanged(int roleId)
	{
		CreatureDataComponent creatureData = this.CreatureData;
		int? num = (creatureData != null) ? new int?(creatureData.GetPbDataId()) : null;
		if (roleId == num.GetValueOrDefault() & num != null)
		{
			this.LoadConfig();
		}
	}

	// Token: 0x0601A7B5 RID: 108469 RVA: 0x007D2C00 File Offset: 0x007D0E00
	private void UpdateEnvironment()
	{
		CharacterActorComponent actorComp = base.ActorComp;
		if (actorComp == null || !actorComp.Valid)
		{
			return;
		}
		global::Vector actorLocationProxy = base.ActorComp.ActorLocationProxy;
		if (!actorLocationProxy.Equals(RoleAudioComponent.LocationCache, 32.0))
		{
			RoleAudioComponent.LocationCache.DeepCopy(actorLocationProxy);
			ControllerBase<GameAudioController>.Instance.UpdatePlayerLocation(actorLocationProxy);
			FVectorDouble actorLocation = base.ActorComp.ActorLocation;
			if (this.GetInAudioShr())
			{
				FName audioShrubTag = this.GetAudioShrubTag();
				if (audioShrubTag != FNameUtil.NONE)
				{
					Singleton<AudioSystem>.Instance.PostEvent(audioShrubTag.ToString(), new FTransformDouble?(new FTransformDouble(ref actorLocation)), null);
					return;
				}
				Singleton<AudioSystem>.Instance.PostEvent("play_amb_role_interact_shr", new FTransformDouble?(new FTransformDouble(ref actorLocation)), null);
			}
		}
	}

	// Token: 0x0601A7B6 RID: 108470 RVA: 0x007D2CDC File Offset: 0x007D0EDC
	private void OnCharPossessed(Entity entity, [Nullable(2)] AController oldController)
	{
		CharacterActorComponent actorComp = base.ActorComp;
		if (((actorComp != null) ? actorComp.Owner : null) != null)
		{
			ControllerBase<GameAudioController>.Instance.SetRolePriority(ERoleAudioPriorityType.PlayerControl, base.ActorComp.Owner);
			ControllerBase<GameAudioController>.Instance.RoleChangeController(base.Entity.Id, true);
		}
	}

	// Token: 0x0601A7B7 RID: 108471 RVA: 0x007D2D2C File Offset: 0x007D0F2C
	private void OnCharUnpossessed(Entity entity, [Nullable(2)] AController oldController)
	{
		CharacterActorComponent actorComp = base.ActorComp;
		if (((actorComp != null) ? actorComp.Owner : null) != null)
		{
			ControllerBase<GameAudioController>.Instance.SetRolePriority(ERoleAudioPriorityType.PlayerBackstage, base.ActorComp.Owner);
			ControllerBase<GameAudioController>.Instance.RoleChangeController(base.Entity.Id, false);
		}
		this.SetAudioMoveState(EMoveState.None);
	}

	// Token: 0x0601A7B8 RID: 108472 RVA: 0x007D2D84 File Offset: 0x007D0F84
	private void OnInteractionWaterTypeChange(EInteractionWaterType type)
	{
		CharacterActorComponent actorComp = base.ActorComp;
		if (((actorComp != null) ? actorComp.Owner : null) == null)
		{
			return;
		}
		if (type == EInteractionWaterType.CloudSea)
		{
			this.CurrentWaterType = "cloud";
		}
		else
		{
			this.CurrentWaterType = "default";
		}
		Singleton<AudioSystem>.Instance.SetSwitch("role_interact_water", this.CurrentWaterType, base.ActorComp.Owner);
	}

	// Token: 0x0601A7B9 RID: 108473 RVA: 0x007D2DE4 File Offset: 0x007D0FE4
	private void OnCharacterMovementModeChanged(int charId, EMovementMode prevMovementMode, EMovementMode newMovementMode, byte prevCustomMode, byte newCustomMode)
	{
		int id = base.Entity.Id;
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		int? num = (baseCharacter != null) ? new int?(baseCharacter.EntityId) : null;
		if (!(id == num.GetValueOrDefault() & num != null) || this.StateComp == null)
		{
			return;
		}
		EMoveState audioMoveState = EMoveState.None;
		switch (newMovementMode)
		{
		case EMovementMode.MOVE_Falling:
			if (this.StateComp.MoveState != global::ECharMoveState.KnockUp && this.StateComp.MoveState != global::ECharMoveState.Captured)
			{
				audioMoveState = EMoveState.Fall;
			}
			break;
		case EMovementMode.MOVE_Flying:
			if (this.StateComp.MoveState != global::ECharMoveState.Captured)
			{
				audioMoveState = EMoveState.Hook;
			}
			break;
		case EMovementMode.MOVE_Custom:
			switch (newCustomMode)
			{
			case 0:
			case 1:
			case 5:
			case 6:
			case 7:
			case 9:
				goto IL_104;
			case 2:
				audioMoveState = EMoveState.Fly;
				goto IL_104;
			case 4:
			case 12:
				audioMoveState = EMoveState.Slide;
				goto IL_104;
			case 8:
				audioMoveState = EMoveState.Ski;
				goto IL_104;
			}
			audioMoveState = EMoveState.Fall;
			break;
		}
		IL_104:
		this.SetAudioMoveState(audioMoveState);
	}

	// Token: 0x0601A7BA RID: 108474 RVA: 0x007D2EFC File Offset: 0x007D10FC
	private void SetAudioMoveState(EMoveState moveState)
	{
		if (this.LastMoveState == moveState)
		{
			return;
		}
		this.LastMoveState = moveState;
		Singleton<AudioSystem>.Instance.SetState("role_move", moveState.Value, true);
	}

	// Token: 0x0601A7BB RID: 108475 RVA: 0x007D2F2C File Offset: 0x007D112C
	private void OnBeDamage(Entity attacker, Entity victim, RequirementPayload requirements, DamageResult damageResult, FVectorDouble damagePosition)
	{
		if (attacker != victim && damageResult.ChangeLife > 0f && this.AttributeComponent != null)
		{
			int id = victim.Id;
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			int? num = (baseCharacter != null) ? new int?(baseCharacter.EntityId) : null;
			if (id == num.GetValueOrDefault() & num != null)
			{
				CharacterActorComponent actorComp = base.ActorComp;
				AActor aactor = (actorComp != null) ? actorComp.Owner : null;
				float currentValue = this.AttributeComponent.GetCurrentValue(EAttributeType.LifeMax);
				float currentValue2 = this.AttributeComponent.GetCurrentValue(EAttributeType.Life);
				if (aactor != null && this.Config != null && currentValue != 0f)
				{
					float num2 = 100f * (currentValue2 / currentValue);
					float num3 = 100f * ((currentValue2 + damageResult.ChangeLife) / currentValue);
					int num4 = 100;
					string text = "";
					for (int i = 0; i < this.Config.Value.LostHealthEventMapLength; i++)
					{
						DicIntString? dicIntString = this.Config.Value.LostHealthEventMap(i);
						int key = dicIntString.Value.Key;
						string value = dicIntString.Value.Value;
						if (num2 <= (float)key && num3 >= (float)key && num4 > key)
						{
							num4 = key;
							text = value;
						}
					}
					if (text != "")
					{
						Singleton<AudioSystem>.Instance.PostEvent(text, aactor, null);
					}
				}
				return;
			}
		}
	}

	// Token: 0x0601A7BC RID: 108476 RVA: 0x007D30A8 File Offset: 0x007D12A8
	private void OnUseSkillRemote(int entityId, int skillId)
	{
		if (entityId != base.Entity.Id || !ControllerBase<RoleAudioController>.Instance.CheckSkillAudioId((long)skillId))
		{
			return;
		}
		SkillAudioEvent? config = ConfigSkillAudioEventById.GetConfig(skillId, true);
		if (config != null && (config != null && config.GetValueOrDefault().Remote))
		{
			this.PlayUseSkillEvent(config);
		}
	}

	// Token: 0x0601A7BD RID: 108477 RVA: 0x007D3108 File Offset: 0x007D1308
	private void OnUseSkill(int entityId, int skillId, bool _)
	{
		if (entityId != base.Entity.Id || !ControllerBase<RoleAudioController>.Instance.CheckSkillAudioId((long)skillId))
		{
			return;
		}
		SkillAudioEvent? config = ConfigSkillAudioEventById.GetConfig(skillId, true);
		if (config != null)
		{
			this.PlayUseSkillEvent(config);
		}
	}

	// Token: 0x0601A7BE RID: 108478 RVA: 0x007D314C File Offset: 0x007D134C
	private void PlayUseSkillEvent(SkillAudioEvent? skillAudioEvent)
	{
		if (skillAudioEvent == null)
		{
			return;
		}
		CharacterActorComponent actorComp = base.ActorComp;
		AActor aactor = (actorComp != null) ? actorComp.Owner : null;
		string eventName = skillAudioEvent.Value.EventName;
		if (aactor == null || !aactor.IsValid() || eventName == null || eventName == "")
		{
			return;
		}
		if (ModelBase<GameAudioModel>.Instance.CheckAudioProbabilityInfo(base.Entity.Id, eventName, new AudioCoolDownWithTagInfo
		{
			DefaultCooldownTime = skillAudioEvent.Value.ActorColdTime,
			DefaultProbability = (double)skillAudioEvent.Value.PostProbability
		}, true, true, false))
		{
			Singleton<AudioSystem>.Instance.PostEvent(eventName, aactor, null);
		}
	}

	// Token: 0x0601A7BF RID: 108479 RVA: 0x007D320E File Offset: 0x007D140E
	private void OnGoDownFinish()
	{
		this.PostGoDownFinishEvent();
	}

	// Token: 0x0601A7C0 RID: 108480 RVA: 0x007D3218 File Offset: 0x007D1418
	private void PostGoDownFinishEvent()
	{
		CharacterActorComponent actorComp = base.ActorComp;
		AActor aactor = (actorComp != null) ? actorComp.Owner : null;
		BaseDeathComponent component = base.Entity.GetComponent<BaseDeathComponent>();
		if (((component != null) ? new bool?(component.IsDead()) : null).GetValueOrDefault())
		{
			return;
		}
		if (aactor != null && aactor.IsValid())
		{
			Singleton<AudioSystem>.Instance.PostEvent("scene_role_switched_behind", aactor, null);
		}
	}

	// Token: 0x0601A7C1 RID: 108481 RVA: 0x007D328C File Offset: 0x007D148C
	public void PostFootstepAudio(CharacterFootEffectComponent.EFootstepTexture texture)
	{
		this.ChangeFootstepTexture(texture);
		UAkComponent akComponent = base.GetAkComponent(null);
		string footstepEvent = this.GetFootstepEvent();
		if (akComponent != null && !string.IsNullOrEmpty(footstepEvent))
		{
			Singleton<AudioSystem>.Instance.PostEvent(footstepEvent, akComponent, null);
		}
	}

	// Token: 0x0601A7C2 RID: 108482 RVA: 0x007D32D8 File Offset: 0x007D14D8
	public bool IsConfig()
	{
		return this.Config != null;
	}

	// Token: 0x0601A7C3 RID: 108483 RVA: 0x007D32E5 File Offset: 0x007D14E5
	public RoleSkinAudio? GetConfig()
	{
		return this.Config;
	}

	// Token: 0x0601A7C4 RID: 108484 RVA: 0x007D32F0 File Offset: 0x007D14F0
	[NullableContext(2)]
	public string GetConfigName()
	{
		if (this.Config == null)
		{
			return null;
		}
		return this.Config.GetValueOrDefault().Name;
	}

	// Token: 0x0601A7C5 RID: 108485 RVA: 0x007D331C File Offset: 0x007D151C
	[NullableContext(2)]
	public string GetLowStrengthEvent()
	{
		if (this.Config == null)
		{
			return null;
		}
		return this.Config.GetValueOrDefault().LowStrengthEvent;
	}

	// Token: 0x0601A7C6 RID: 108486 RVA: 0x007D3348 File Offset: 0x007D1548
	[NullableContext(2)]
	public string GetDeathEvent()
	{
		if (this.Config == null)
		{
			return null;
		}
		return this.Config.GetValueOrDefault().DeathEvent;
	}

	// Token: 0x0601A7C7 RID: 108487 RVA: 0x007D3374 File Offset: 0x007D1574
	private void InitFootstepEvent()
	{
		this.FootstepEvent = ((this.Config != null) ? this.Config.GetValueOrDefault().FootstepEvent : null);
		CreatureDataComponent creatureData = this.CreatureData;
		int id = (creatureData != null) ? creatureData.GetPbDataId() : 0;
		int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(id);
		AudioConfig instance = ConfigBase<AudioConfig>.Instance;
		RoleInfoAudio? roleInfoAudio;
		string text = (instance != null) ? ((instance.GetRoleInfoConfig(baseRoleId) != null) ? roleInfoAudio.GetValueOrDefault().FootstepEvent : null) : null;
		if (text != null)
		{
			this.FootstepEvent = text;
		}
	}

	// Token: 0x0601A7C8 RID: 108488 RVA: 0x007D3400 File Offset: 0x007D1600
	[NullableContext(2)]
	public string GetFootstepEvent()
	{
		return this.FootstepEvent;
	}

	// Token: 0x0601A7C9 RID: 108489 RVA: 0x007D3408 File Offset: 0x007D1608
	private void InitFoleyEvent()
	{
		this.FoleyEvent = ((this.Config != null) ? this.Config.GetValueOrDefault().FoleyEvent : null);
		CreatureDataComponent creatureData = this.CreatureData;
		int id = (creatureData != null) ? creatureData.GetPbDataId() : 0;
		int baseRoleId = ConfigBase<RoleConfig>.Instance.GetBaseRoleId(id);
		AudioConfig instance = ConfigBase<AudioConfig>.Instance;
		RoleInfoAudio? roleInfoAudio;
		string text = (instance != null) ? ((instance.GetRoleInfoConfig(baseRoleId) != null) ? roleInfoAudio.GetValueOrDefault().FoleyEvent : null) : null;
		if (text != null)
		{
			this.FoleyEvent = text;
		}
	}

	// Token: 0x0601A7CA RID: 108490 RVA: 0x007D3494 File Offset: 0x007D1694
	[NullableContext(2)]
	public string GetFoleyEvent()
	{
		return this.FoleyEvent;
	}

	// Token: 0x0601A7CB RID: 108491 RVA: 0x007D349C File Offset: 0x007D169C
	public void UpdateIsInAudioShrubEvent(bool bIsInAudioShrub, FName audioShrubTag)
	{
		this.IsInAudioShrubOverride = bIsInAudioShrub;
		this.AudioShrubTagNameOverride = new FName?(audioShrubTag);
	}

	// Token: 0x0601A7CC RID: 108492 RVA: 0x007D34B4 File Offset: 0x007D16B4
	public bool GetInAudioShr()
	{
		bool flag = this.IsInAudioShrubOverride;
		CharacterActorComponent actorComp = base.ActorComp;
		TsBaseCharacter tsBaseCharacter = (actorComp != null) ? actorComp.Actor : null;
		CharRenderingComponent charRenderingComponent = (tsBaseCharacter != null) ? tsBaseCharacter.CharRenderingComponent : null;
		if (charRenderingComponent != null)
		{
			flag = (flag || charRenderingComponent.GetInAudioShr());
		}
		return flag;
	}

	// Token: 0x0601A7CD RID: 108493 RVA: 0x007D34F8 File Offset: 0x007D16F8
	public FName GetAudioShrubTag()
	{
		FName? audioShrubTagNameOverride = this.AudioShrubTagNameOverride;
		CharacterActorComponent actorComp = base.ActorComp;
		TsBaseCharacter tsBaseCharacter = (actorComp != null) ? actorComp.Actor : null;
		CharRenderingComponent charRenderingComponent = (tsBaseCharacter != null) ? tsBaseCharacter.CharRenderingComponent : null;
		if (((charRenderingComponent != null) ? new FName?(charRenderingComponent.GetAudioShrTag()) : null) != FNameUtil.NONE)
		{
			audioShrubTagNameOverride = new FName?(charRenderingComponent.GetAudioShrTag());
		}
		if (audioShrubTagNameOverride == null)
		{
			return FNameUtil.NONE;
		}
		return audioShrubTagNameOverride.Value;
	}

	// Token: 0x0601A7CE RID: 108494 RVA: 0x007D358C File Offset: 0x007D178C
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		RoleAudioComponent roleAudioComponent = (RoleAudioComponent)componentTemplate;
		if (base.CanResetComponentProperty("LastMoveState"))
		{
			this.LastMoveState = roleAudioComponent.LastMoveState;
		}
		if (base.CanResetComponentProperty("Config"))
		{
			this.Config = roleAudioComponent.Config;
		}
		if (base.CanResetComponentProperty("CurrentRoleName"))
		{
			this.CurrentRoleName = roleAudioComponent.CurrentRoleName;
		}
		if (base.CanResetComponentProperty("CurrentFootstepTexture"))
		{
			this.CurrentFootstepTexture = roleAudioComponent.CurrentFootstepTexture;
		}
		if (base.CanResetComponentProperty("CurrentFootstepVariant"))
		{
			this.CurrentFootstepVariant = roleAudioComponent.CurrentFootstepVariant;
		}
		if (base.CanResetComponentProperty("CurrentFoleyVariant"))
		{
			this.CurrentFoleyVariant = roleAudioComponent.CurrentFoleyVariant;
		}
		if (base.CanResetComponentProperty("CurrentWaterType"))
		{
			this.CurrentWaterType = roleAudioComponent.CurrentWaterType;
		}
		if (base.CanResetComponentProperty("StateComp"))
		{
			if (roleAudioComponent.StateComp == null)
			{
				this.StateComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.StateComp), "StateComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AttributeComponent"))
		{
			if (roleAudioComponent.AttributeComponent == null)
			{
				this.AttributeComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseAttributeComponent>(this.AttributeComponent), "AttributeComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsInAudioShrubOverride"))
		{
			this.IsInAudioShrubOverride = roleAudioComponent.IsInAudioShrubOverride;
		}
		if (base.CanResetComponentProperty("AudioShrubTagNameOverride"))
		{
			this.AudioShrubTagNameOverride = roleAudioComponent.AudioShrubTagNameOverride;
		}
		if (base.CanResetComponentProperty("FootstepEvent"))
		{
			this.FootstepEvent = roleAudioComponent.FootstepEvent;
		}
		if (base.CanResetComponentProperty("FoleyEvent"))
		{
			this.FoleyEvent = roleAudioComponent.FoleyEvent;
		}
		return true;
	}

	// Token: 0x0400D613 RID: 54803
	private static Dictionary<E_FootstepVariant, string> FootstepVariantMap;

	// Token: 0x0400D614 RID: 54804
	private static Dictionary<E_FoleyVariant, string> FoleyVariantMap;

	// Token: 0x0400D615 RID: 54805
	private const string ROLE_GO_DOWN_FINISH_EVENT = "scene_role_switched_behind";

	// Token: 0x0400D616 RID: 54806
	private const string ROLE_INTERACT_SHR = "play_amb_role_interact_shr";

	// Token: 0x0400D617 RID: 54807
	private const string ROLE_MOVE = "role_move";

	// Token: 0x0400D618 RID: 54808
	private const int TICK_INTERVAL = 250;

	// Token: 0x0400D619 RID: 54809
	private const int LOCATION_TOLERANCE = 32;

	// Token: 0x0400D61A RID: 54810
	private EMoveState LastMoveState = EMoveState.None;

	// Token: 0x0400D61B RID: 54811
	private RoleSkinAudio? Config;

	// Token: 0x0400D61C RID: 54812
	private string CurrentRoleName = "chixia";

	// Token: 0x0400D61D RID: 54813
	private string CurrentFootstepTexture = "DirtSurface";

	// Token: 0x0400D61E RID: 54814
	private string CurrentFootstepVariant = "walk";

	// Token: 0x0400D61F RID: 54815
	private string CurrentFoleyVariant = "weak";

	// Token: 0x0400D620 RID: 54816
	private string CurrentWaterType = "default";

	// Token: 0x0400D621 RID: 54817
	private static double LastTickTime;

	// Token: 0x0400D622 RID: 54818
	private static global::Vector LocationCache;

	// Token: 0x0400D623 RID: 54819
	[Nullable(2)]
	private CharacterUnifiedStateComponent StateComp;

	// Token: 0x0400D624 RID: 54820
	[Nullable(2)]
	private BaseAttributeComponent AttributeComponent;

	// Token: 0x0400D625 RID: 54821
	protected bool IsInAudioShrubOverride;

	// Token: 0x0400D626 RID: 54822
	protected FName? AudioShrubTagNameOverride;

	// Token: 0x0400D627 RID: 54823
	[Nullable(2)]
	private string FootstepEvent;

	// Token: 0x0400D628 RID: 54824
	[Nullable(2)]
	private string FoleyEvent;
}
