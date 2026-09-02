using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Roverlike;
using CSharpScript.Game.Module.DeadRevive;
using CSharpScript.Game.Module.Teleport;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020031EA RID: 12778
[NullableContext(2)]
[Nullable(0)]
public class RoleDeathComponent : BaseDeathComponent
{
	// Token: 0x0601A818 RID: 108568 RVA: 0x007D5678 File Offset: 0x007D3878
	protected override bool OnInit()
	{
		this.ActorComponent = base.Entity.GetComponent<CharacterActorComponent>();
		this.CreatureDataComponent = base.Entity.CheckGetComponent<CreatureDataComponent>();
		this.TagComponent = base.Entity.GetComponent<BaseTagComponent>();
		this.SkillComponent = base.Entity.GetComponent<CharacterSkillComponent>();
		this.BuffComponent = base.Entity.GetComponent<CharacterBuffComponent>();
		this.UnifiedStateComponent = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
		this.AttributeComponent = base.Entity.GetComponent<BaseAttributeComponent>();
		this.MorphComponent = base.Entity.GetComponent<CharacterMorphComponent>();
		return true;
	}

	// Token: 0x0601A819 RID: 108569 RVA: 0x007D5710 File Offset: 0x007D3910
	protected override bool OnStart()
	{
		if (!base.OnStart())
		{
			return false;
		}
		CreatureDataComponent creatureDataComponent = this.CreatureDataComponent;
		if (creatureDataComponent != null && creatureDataComponent.GetLivingStatus().GetValueOrDefault() == LivingStatus.Dead)
		{
			this.ExecuteDeath(null);
		}
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.TeleportChangeLocation, new Action(this.ResetDrowning));
		return true;
	}

	// Token: 0x0601A81A RID: 108570 RVA: 0x007D5779 File Offset: 0x007D3979
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.TeleportChangeLocation, new Action(this.ResetDrowning));
		return true;
	}

	// Token: 0x0601A81B RID: 108571 RVA: 0x007D579E File Offset: 0x007D399E
	protected override bool OnClear()
	{
		this.MaterialHandles.Clear();
		this.CanResetDrowning = false;
		return true;
	}

	// Token: 0x0601A81C RID: 108572 RVA: 0x007D57B4 File Offset: 0x007D39B4
	public override bool ExecuteDeath(long? preMessageId)
	{
		if (!base.ExecuteDeath(preMessageId))
		{
			return false;
		}
		ControllerBase<SceneTeamController>.Instance.EmitEvent(base.Entity, EEventName.CharOnRoleDeadBefore);
		CharacterBuffComponent buffComponent = this.BuffComponent;
		if (buffComponent != null)
		{
			buffComponent.RemoveBuffByEffectType(EExtraEffectId.Frozen, "实体死亡移除冰冻buff");
		}
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent != null)
		{
			tagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"]));
		}
		CharacterSkillComponent skillComponent = this.SkillComponent;
		if (skillComponent != null)
		{
			skillComponent.StopAllSkills("RoleDeathComponent.ExecuteDeath");
		}
		CharacterUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		if (unifiedStateComponent != null && unifiedStateComponent.Valid && base.Entity.IsInit)
		{
			this.UnifiedStateComponent.ResetCharState();
			global::ECharPositionState positionState = this.UnifiedStateComponent.PositionState;
			if (positionState != global::ECharPositionState.Climb)
			{
				if (positionState == global::ECharPositionState.Air)
				{
					global::ECharMoveState moveState = this.UnifiedStateComponent.MoveState;
					if (moveState == global::ECharMoveState.Glide)
					{
						CharacterGlideComponent component = base.Entity.GetComponent<CharacterGlideComponent>();
						if (component != null)
						{
							component.ExitGlideState("Death");
						}
					}
					else if (moveState == global::ECharMoveState.Soar)
					{
						CharacterGlideComponent component2 = base.Entity.GetComponent<CharacterGlideComponent>();
						if (component2 != null)
						{
							component2.ExitSoarState(EMovementMode.MOVE_Falling, "Death");
						}
					}
				}
			}
			else
			{
				CharacterActorComponent component3 = base.Entity.GetComponent<CharacterActorComponent>();
				if (component3 != null)
				{
					component3.Actor.KuroSetMovementMode(new SetMovementModeInfo
					{
						Mode = EMovementMode.MOVE_Falling,
						CustomMode = 0,
						Context = "[RoleDeathComponent.ExecuteDeath]"
					});
				}
			}
			this.UnifiedStateComponent.ExitHitState("角色死亡");
		}
		CharacterBuffComponent buffComponent2 = this.BuffComponent;
		if (buffComponent2 != null)
		{
			buffComponent2.RemoveAllDurationBuffs("实体死亡清理持续型buff");
		}
		BaseAttributeComponent attributeComponent = this.AttributeComponent;
		if (attributeComponent != null)
		{
			attributeComponent.ClearSpecialEnergy();
		}
		this.PlayDeathAnimation(preMessageId);
		this.PlayDeathAudio();
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.CharOnRoleDead, base.Entity.Id);
		Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.CharOnRoleDeadTargetSelf);
		return true;
	}

	// Token: 0x0601A81D RID: 108573 RVA: 0x007D597D File Offset: 0x007D3B7D
	protected void PlayDeathAudio()
	{
		if (base.Entity == null)
		{
			return;
		}
		ControllerBase<RoleAudioController>.Instance.OnPlayerDies(base.Entity);
	}

	// Token: 0x0601A81E RID: 108574 RVA: 0x007D5998 File Offset: 0x007D3B98
	protected void PlayDeathAnimation(long? preMessageId)
	{
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.溺水"]))
		{
			return;
		}
		if (!ModelBase<DeadReviveModel>.Instance.SkipDeathAnim)
		{
			BaseTagComponent tagComponent2 = this.TagComponent;
			if (tagComponent2 == null || !tagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.不播放死亡动画"]))
			{
				BaseMontageComponent montageComponent = this.MontageComponent;
				if (montageComponent != null && montageComponent.Valid && base.Entity.IsInit && base.Entity.Active)
				{
					CharacterUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
					if (!(((unifiedStateComponent != null) ? new global::ECharPositionState?(unifiedStateComponent.PositionState) : null) != global::ECharPositionState.Water))
					{
						base.PlayDeathMontageWithType(ECharacterDeathMontageType.DieInWater, new Action<bool>(this.OnDeathEnded), preMessageId, null);
					}
					else
					{
						base.PlayDeathMontageWithType(ECharacterDeathMontageType.Die, new Action<bool>(this.OnDeathEnded), preMessageId, null);
					}
					if (ControllerBase<RoverlikeController>.Instance.CheckInRoverlike())
					{
						ControllerBase<RoverlikeController>.Instance.RoleDeathStart(base.Entity);
					}
					return;
				}
			}
		}
		this.OnDeathEnded();
	}

	// Token: 0x0601A81F RID: 108575 RVA: 0x007D5ABC File Offset: 0x007D3CBC
	protected override UAnimMontage GetDeathMontage(ECharacterDeathMontageType montageType)
	{
		UAnimMontage uanimMontage = null;
		if (this.MorphComponent != null && this.MorphComponent.IsMorphing())
		{
			string deathMontageName = base.GetDeathMontageName(montageType);
			if (deathMontageName != null)
			{
				uanimMontage = this.MorphComponent.GetMontageByName(deathMontageName);
			}
		}
		if (uanimMontage == null)
		{
			uanimMontage = base.GetDeathMontage(montageType);
		}
		return uanimMontage;
	}

	// Token: 0x0601A820 RID: 108576 RVA: 0x007D5B04 File Offset: 0x007D3D04
	public void OnDeathEnded(bool isInterrupted)
	{
		this.OnDeathEnded();
	}

	// Token: 0x0601A821 RID: 108577 RVA: 0x007D5B0C File Offset: 0x007D3D0C
	public void OnDeathEnded()
	{
		List<EntityHandle> teamEntities = ModelBase<SceneTeamModel>.Instance.GetTeamEntities(true);
		if (this.BuffComponent != null && this.BuffComponent.HasBuffAuthority())
		{
			this.BuffComponent.TriggerEvents(EBuffTriggerType.WhenOwnerDie, this.BuffComponent, new Partial_RequirementPayload());
			foreach (EntityHandle entityHandle in teamEntities)
			{
				if (base.Entity.Id != entityHandle.Id && entityHandle.Valid)
				{
					WorldEntity entity = entityHandle.Entity;
					RoleDeathComponent roleDeathComponent = (entity != null) ? entity.GetComponent<RoleDeathComponent>() : null;
					if (roleDeathComponent != null && !roleDeathComponent.IsDead())
					{
						CharacterBuffComponent buffComponent = roleDeathComponent.BuffComponent;
						if (buffComponent != null)
						{
							buffComponent.TriggerEvents(EBuffTriggerType.WhenCompanionDie, this.BuffComponent, new Partial_RequirementPayload());
						}
					}
				}
			}
		}
		Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.CharOnRoleDeadEnd);
		if (ControllerBase<RoverlikeController>.Instance.CheckInRoverlike())
		{
			ControllerBase<RoverlikeController>.Instance.RoleDeathEnded(base.Entity);
			return;
		}
		if (!base.IsDead())
		{
			return;
		}
		ModelBase<SceneTeamModel>.Instance.RoleDeathEnded(base.Entity.Id);
	}

	// Token: 0x0601A822 RID: 108578 RVA: 0x007D5C3C File Offset: 0x007D3E3C
	public unsafe void ExecuteRevive()
	{
		if (!this.IsDeadInternal)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "实体重复复活";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", base.Entity.Id);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Battle;
		ELogAuthor author2 = ELogAuthor.ZQR;
		string message2 = "[DeathComponent]执行角色复活逻辑";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Entity", base.Entity.ToString());
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item = "PbDataId";
		Entity entity = base.Entity;
		int? num;
		if (entity == null)
		{
			num = null;
		}
		else
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			num = ((component != null) ? new int?(component.GetPbDataId()) : null);
		}
		ptr = new ValueTuple<string, object>(item, num);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.IsDeadInternal = false;
		BaseTagComponent tagComponent = this.TagComponent;
		if (tagComponent != null)
		{
			tagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.濒死"]));
		}
		this.RemoveMaterials();
		CharacterActorComponent actorComponent = this.ActorComponent;
		if (actorComponent != null && actorComponent.IsAutonomousProxy)
		{
			Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.CharOnRevive);
			Singleton<EventSystem>.Instance.Emit<Entity>(EEventName.OnRevive, base.Entity);
			CharacterUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
			if (unifiedStateComponent != null)
			{
				unifiedStateComponent.TryClearInFightTags();
			}
			CharacterUnifiedStateComponent unifiedStateComponent2 = this.UnifiedStateComponent;
			if (unifiedStateComponent2 != null)
			{
				unifiedStateComponent2.RefreshFightState(new bool?(ControllerBase<FormationDataController>.Instance.GlobalIsInFight));
			}
		}
		CharacterActorComponent actorComponent2 = this.ActorComponent;
		TsBaseCharacter 角色 = ((actorComponent2 != null) ? actorComponent2.Owner : null) as TsBaseCharacter;
		GlobalData.BpEventManager.当有角色复活时.Broadcast(角色);
	}

	// Token: 0x0601A823 RID: 108579 RVA: 0x007D5DE9 File Offset: 0x007D3FE9
	public void AddMaterialHandle(int handle)
	{
		this.MaterialHandles.Add(handle);
	}

	// Token: 0x0601A824 RID: 108580 RVA: 0x007D5DF8 File Offset: 0x007D3FF8
	public void RemoveMaterials()
	{
		CharacterActorComponent actorComponent = this.ActorComponent;
		CharRenderingComponent charRenderingComponent = (actorComponent != null) ? actorComponent.Actor.CharRenderingComponent : null;
		if (charRenderingComponent != null)
		{
			foreach (int handle in this.MaterialHandles)
			{
				charRenderingComponent.RemoveMaterialControllerData(handle);
			}
		}
	}

	// Token: 0x0601A825 RID: 108581 RVA: 0x007D5E68 File Offset: 0x007D4068
	[CombatListen(ENotifyMessageId.DrownNotify, true, false)]
	public static void DrownNotify(Entity entity, [Nullable(1)] DrownNotify data, CombatCommon combatCommon = null)
	{
		RoleDeathComponent roleDeathComponent = (entity != null) ? entity.CheckGetComponent<RoleDeathComponent>() : null;
		if (roleDeathComponent != null)
		{
			roleDeathComponent.PlayDeathMontageWithType(ECharacterDeathMontageType.DieInWater, null, null, null);
			CharacterBuffComponent buffComponent = roleDeathComponent.BuffComponent;
			if (buffComponent != null && buffComponent.HasBuffAuthority())
			{
				roleDeathComponent.BuffComponent.RemoveBuffByEffectType(EExtraEffectId.Frozen, "溺水移除冰冻buff");
			}
		}
	}

	// Token: 0x0601A826 RID: 108582 RVA: 0x007D5EC8 File Offset: 0x007D40C8
	public void Drowning()
	{
		if (!this.IsDrowning())
		{
			base.Entity.CheckGetComponent<BaseTagComponent>().AddTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.溺水"]));
			BaseAttributeComponent baseAttributeComponent = base.Entity.CheckGetComponent<BaseAttributeComponent>();
			float currentValue = baseAttributeComponent.GetCurrentValue(EAttributeType.Life);
			this.BuffComponent.AddBuff(1208L, new AddBuffParam
			{
				InstigatorId = this.BuffComponent.CreatureDataId,
				Reason = "溺水流程添加"
			});
			float currentValue2 = baseAttributeComponent.GetCurrentValue(EAttributeType.Life);
			base.PlayDeathMontageWithType(ECharacterDeathMontageType.DieInWater, new Action<bool>(this.DrowningPunishment), null, null);
			CharacterBuffComponent buffComponent = this.BuffComponent;
			if (buffComponent != null && buffComponent.HasBuffAuthority())
			{
				this.BuffComponent.RemoveBuffByEffectType(EExtraEffectId.Frozen, "溺水移除冰冻buff");
			}
			Singleton<EventSystem>.Instance.EmitWithTarget<bool>(base.Entity, EEventName.CharOnRoleDrownInjure, currentValue > 0f && currentValue2 <= 0f);
		}
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.CharOnRoleDrown, true);
		Singleton<CombatNet>.Instance.Send(EPushMessageId.DrownPush, base.Entity, new DrownPush(), null, null, null);
	}

	// Token: 0x0601A827 RID: 108583 RVA: 0x007D600E File Offset: 0x007D420E
	public bool IsDrowning()
	{
		BaseTagComponent tagComponent = this.TagComponent;
		return tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.溺水"]);
	}

	// Token: 0x0601A828 RID: 108584 RVA: 0x007D6030 File Offset: 0x007D4230
	public void ResetDrowning()
	{
		if (this.CanResetDrowning)
		{
			this.RemoveDrowningEffect();
			this.CanResetDrowning = false;
		}
	}

	// Token: 0x0601A829 RID: 108585 RVA: 0x007D6047 File Offset: 0x007D4247
	private void RemoveDrowningEffect()
	{
		if (!base.IsDead())
		{
			this.RemoveMaterials();
		}
	}

	// Token: 0x0601A82A RID: 108586 RVA: 0x007D6058 File Offset: 0x007D4258
	public void DrowningPunishment(bool _)
	{
		this.BuffComponent.AddBuff(1105L, new AddBuffParam
		{
			InstigatorId = this.BuffComponent.CreatureDataId,
			Reason = "溺水蒙太奇后添加"
		});
		this.TagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.溺水"]));
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.CharOnRoleDrown, false);
		Singleton<EventSystem>.Instance.EmitWithTarget<bool>(base.Entity, EEventName.CharOnRoleDrown, false);
		if (!ModelBase<SceneTeamModel>.Instance.IsAllDid())
		{
			global::Vector lastPositionOnLand = ModelBase<FormationDataModel>.Instance.GetLastPositionOnLand();
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				this.CanResetDrowning = true;
				DrownEndTeleportPush drownEndTeleportPush = new DrownEndTeleportPush();
				if (lastPositionOnLand != null)
				{
					drownEndTeleportPush.TeleportPos = new Aki.Protocol.Vector
					{
						X = (float)lastPositionOnLand.X,
						Y = (float)lastPositionOnLand.Y,
						Z = (float)lastPositionOnLand.Z
					};
				}
				Singleton<CombatNet>.Instance.Send(EPushMessageId.DrownEndTeleportPush, base.Entity, drownEndTeleportPush, null, null, null);
			}
			else if (lastPositionOnLand != null)
			{
				ControllerBase<TeleportController>.Instance.TeleportToPositionNoLoading(lastPositionOnLand.ToUeVector(false), null, "DrowningPunishment", true).ContinueWith(delegate(bool _)
				{
					this.RemoveDrowningEffect();
				});
			}
		}
		CharacterUnifiedStateComponent unifiedStateComponent = this.UnifiedStateComponent;
		if (unifiedStateComponent != null)
		{
			unifiedStateComponent.ResetCharState();
		}
		RoleDeathComponent roleDeathComponent = base.Entity.CheckGetComponent<RoleDeathComponent>();
		if (roleDeathComponent.IsDead())
		{
			roleDeathComponent.OnDeathEnded();
		}
	}

	// Token: 0x0601A82B RID: 108587 RVA: 0x007D61E4 File Offset: 0x007D43E4
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		RoleDeathComponent roleDeathComponent = (RoleDeathComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComponent"))
		{
			if (roleDeathComponent.ActorComponent == null)
			{
				this.ActorComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComponent), "ActorComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CreatureDataComponent"))
		{
			if (roleDeathComponent.CreatureDataComponent == null)
			{
				this.CreatureDataComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComponent), "CreatureDataComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComponent"))
		{
			if (roleDeathComponent.TagComponent == null)
			{
				this.TagComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComponent), "TagComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SkillComponent"))
		{
			if (roleDeathComponent.SkillComponent == null)
			{
				this.SkillComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterSkillComponent>(this.SkillComponent), "SkillComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("BuffComponent"))
		{
			if (roleDeathComponent.BuffComponent == null)
			{
				this.BuffComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterBuffComponent>(this.BuffComponent), "BuffComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("UnifiedStateComponent"))
		{
			if (roleDeathComponent.UnifiedStateComponent == null)
			{
				this.UnifiedStateComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.UnifiedStateComponent), "UnifiedStateComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AttributeComponent"))
		{
			if (roleDeathComponent.AttributeComponent == null)
			{
				this.AttributeComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseAttributeComponent>(this.AttributeComponent), "AttributeComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MorphComponent"))
		{
			if (roleDeathComponent.MorphComponent == null)
			{
				this.MorphComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMorphComponent>(this.MorphComponent), "MorphComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CanResetDrowning"))
		{
			this.CanResetDrowning = roleDeathComponent.CanResetDrowning;
		}
		return !base.CanResetComponentProperty("MaterialHandles") || roleDeathComponent.MaterialHandles == null || base.CheckClearObject(EntityComponentSystem.ClearObject<List<int>>(this.MaterialHandles), "MaterialHandles");
	}

	// Token: 0x0400D643 RID: 54851
	private CharacterActorComponent ActorComponent;

	// Token: 0x0400D644 RID: 54852
	private CreatureDataComponent CreatureDataComponent;

	// Token: 0x0400D645 RID: 54853
	private BaseTagComponent TagComponent;

	// Token: 0x0400D646 RID: 54854
	private CharacterSkillComponent SkillComponent;

	// Token: 0x0400D647 RID: 54855
	private CharacterBuffComponent BuffComponent;

	// Token: 0x0400D648 RID: 54856
	private CharacterUnifiedStateComponent UnifiedStateComponent;

	// Token: 0x0400D649 RID: 54857
	private BaseAttributeComponent AttributeComponent;

	// Token: 0x0400D64A RID: 54858
	private CharacterMorphComponent MorphComponent;

	// Token: 0x0400D64B RID: 54859
	private bool CanResetDrowning;

	// Token: 0x0400D64C RID: 54860
	[Nullable(1)]
	private readonly List<int> MaterialHandles = new List<int>();
}
