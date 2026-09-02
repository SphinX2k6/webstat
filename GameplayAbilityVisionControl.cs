using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.Protocol.Summon;
using AkiClient.Game.Aki.Character.Vision;

// Token: 0x0200315D RID: 12637
public class GameplayAbilityVisionControl : GameplayAbilityVisionBase, IStaticVariableResetter
{
	// Token: 0x0601A2FA RID: 107258 RVA: 0x007B0D12 File Offset: 0x007AEF12
	static GameplayAbilityVisionControl()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(GameplayAbilityVisionControl.CreateStaticDefaultValue), new Action(GameplayAbilityVisionControl.ResetStaticDefaultValue));
	}

	// Token: 0x0601A2FB RID: 107259 RVA: 0x007B0D31 File Offset: 0x007AEF31
	[NullableContext(1)]
	public GameplayAbilityVisionControl(CharacterVisionComponent visionComponent) : base(visionComponent)
	{
	}

	// Token: 0x0601A2FC RID: 107260 RVA: 0x007B0D3C File Offset: 0x007AEF3C
	protected override void OnCreate()
	{
		if (base.CreatureDataComponent.SummonType == ESummonType.ConcomitantPhantomRole)
		{
			Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.HXY, "GameplayAbilityVisionControl.OnCreate", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.SetSummonerVisionControlCreatureDataId(new long?(base.CreatureDataComponent.GetCreatureDataId()));
			base.AttributeComponent.AddListener(GameplayAbilityVisionMisc.controlVisionEnergy, new Action<EAttributeType, float, float>(this.OnAttributeChanged), null);
			int valueOrDefault = ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault();
			CreatureDataComponent component = base.EntityHandle.Entity.GetComponent<CreatureDataComponent>();
			int roleId = component.GetRoleId();
			SceneTeamRole sceneTeamRole = new SceneTeamRole
			{
				CreatureDataId = component.GetCreatureDataId(),
				RoleId = roleId
			};
			ModelBase<SceneTeamModel>.Instance.UpdateGroupData(valueOrDefault, new UpdateGroupParams
			{
				GroupType = ETeamGroupType.VisionControl,
				GroupRoleList = new SceneTeamRole[]
				{
					sceneTeamRole
				},
				CurrentRoleId = roleId
			});
		}
	}

	// Token: 0x0601A2FD RID: 107261 RVA: 0x007B0E24 File Offset: 0x007AF024
	protected override void OnDestroy()
	{
		if (base.CreatureDataComponent.SummonType == ESummonType.ConcomitantPhantomRole)
		{
			Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.HXY, "GameplayAbilityVisionControl.OnDestroy", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.SetSummonerVisionControlCreatureDataId(null);
			base.AttributeComponent.RemoveListener(GameplayAbilityVisionMisc.controlVisionEnergy, new Action<EAttributeType, float, float>(this.OnAttributeChanged));
			this.EndSummonerVisionControl();
			int valueOrDefault = ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault();
			ModelBase<SceneTeamModel>.Instance.UpdateGroupData(valueOrDefault, new UpdateGroupParams
			{
				GroupType = ETeamGroupType.VisionControl,
				GroupRoleList = Array.Empty<SceneTeamRole>(),
				CurrentRoleId = 0
			});
		}
		if (this.WaitDisableHideActorTagRemoveTask != null)
		{
			this.WaitDisableHideActorTagRemoveTask.EndTask();
			this.WaitDisableHideActorTagRemoveTask = null;
		}
	}

	// Token: 0x0601A2FE RID: 107262 RVA: 0x007B0EE8 File Offset: 0x007AF0E8
	protected override bool OnActivateAbility()
	{
		Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.HXY, "GameplayAbilityVisionControl.OnActivateAbility", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (GameplayAbilityVisionControl.VisionControlHandle != null)
		{
			return false;
		}
		EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(base.Entity, ESummonType.ConcomitantPhantomRole, 1);
		if (summonedEntity == null)
		{
			return false;
		}
		RoleTeamComponent roleTeamComponent = summonedEntity.Entity.CheckGetComponent<RoleTeamComponent>();
		if (roleTeamComponent != null)
		{
			roleTeamComponent.SetTeamTag(ETeamState.UnderStage);
		}
		GameplayAbilityVisionControl.VisionControlHandle = summonedEntity;
		this.Recover(summonedEntity);
		this.LastGroupType = ModelBase<SceneTeamModel>.Instance.CurrentGroupType;
		int valueOrDefault = ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault();
		ModelBase<SceneTeamModel>.Instance.SwitchGroup(valueOrDefault, ETeamGroupType.VisionControl, true, false);
		return true;
	}

	// Token: 0x0601A2FF RID: 107263 RVA: 0x007B0F84 File Offset: 0x007AF184
	protected override bool OnEndAbility()
	{
		Singleton<Log>.Instance.Info(ELogModule.Battle, ELogAuthor.HXY, "GameplayAbilityVisionControl.OnEndAbility", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (GameplayAbilityVisionControl.VisionControlHandle == null || this.IsEnding)
		{
			return false;
		}
		this.IsEnding = true;
		this.PlayEndEffect();
		return true;
	}

	// Token: 0x0601A300 RID: 107264 RVA: 0x007B0FCC File Offset: 0x007AF1CC
	private void SetSummonerVisionControlCreatureDataId(long? id)
	{
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(base.CreatureDataComponent.GetSummonerId());
		if (entity != null)
		{
			entity.Entity.GetComponent<CreatureDataComponent>().VisionControlCreatureDataId = id;
		}
	}

	// Token: 0x0601A301 RID: 107265 RVA: 0x007B1004 File Offset: 0x007AF204
	private void OnAttributeChanged(EAttributeType attributeId, float newValue, float oldValue)
	{
		if (newValue < 1E-45f)
		{
			RoleTeamComponent teamComponent = base.TeamComponent;
			if (teamComponent != null)
			{
				teamComponent.SetTeamTag(ETeamState.OnStageWithoutControl);
			}
			if (base.GameplayTagComponent.HasTag(GameplayAbilityVisionMisc.skillTag))
			{
				if (this.WaitDisableHideActorTagRemoveTask == null)
				{
					this.WaitDisableHideActorTagRemoveTask = base.GameplayTagComponent.ListenForTagAddOrRemove(new int?(GameplayAbilityVisionMisc.skillTag), delegate(int tagId, bool tagExist)
					{
						if (!tagExist)
						{
							ITagTask waitDisableHideActorTagRemoveTask = this.WaitDisableHideActorTagRemoveTask;
							if (waitDisableHideActorTagRemoveTask != null)
							{
								waitDisableHideActorTagRemoveTask.EndTask();
							}
							this.WaitDisableHideActorTagRemoveTask = null;
							this.EndSummonerVisionControl();
						}
					}, null);
					return;
				}
			}
			else
			{
				this.EndSummonerVisionControl();
			}
		}
	}

	// Token: 0x0601A302 RID: 107266 RVA: 0x007B1074 File Offset: 0x007AF274
	private void EndSummonerVisionControl()
	{
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(base.CreatureDataComponent.GetSummonerId());
		if (entity != null && entity.Valid)
		{
			entity.Entity.GetComponent<CharacterVisionComponent>().EndAbilityVision(EVisionType.操控);
			return;
		}
		GameplayAbilityVisionControl.VisionControlHandle = null;
	}

	// Token: 0x0601A303 RID: 107267 RVA: 0x007B10BC File Offset: 0x007AF2BC
	[NullableContext(1)]
	private void Recover(EntityHandle handle)
	{
		if (handle.Valid)
		{
			CharacterBuffComponent component = handle.Entity.GetComponent<CharacterBuffComponent>();
			component.AddBuff(9100000020002L, new AddBuffParam
			{
				InstigatorId = component.CreatureDataId,
				Reason = "操控幻象回满能量"
			});
		}
	}

	// Token: 0x0601A304 RID: 107268 RVA: 0x007B1108 File Offset: 0x007AF308
	private void PlayEndEffect()
	{
		TimerHandle capturedVisionHiddenTimer = null;
		capturedVisionHiddenTimer = TimerSystem.Instance.Delay(delegate(float _)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Battle, ELogAuthor.HXY, "幻象消失材质没有正常结束，被保底", default(ReadOnlySpan<ValueTuple<string, object>>));
			capturedVisionHiddenTimer = null;
			this.SwitchBackToRole();
		}, 1000f, null, null, true, 1f);
		CharacterGameplayCueComponent component = GameplayAbilityVisionControl.VisionControlHandle.Entity.GetComponent<CharacterGameplayCueComponent>();
		if (component != null)
		{
			component.AddCue(19000000182L, new GameplayCueParam?(new GameplayCueParam
			{
				Sync = new bool?(true),
				Instant = true
			}));
		}
		this.CueHandle = component.AddCue(19000000181L, new GameplayCueParam?(new GameplayCueParam
		{
			EndCallback = delegate()
			{
				if (capturedVisionHiddenTimer != null && TimerSystem.Instance.Has(capturedVisionHiddenTimer))
				{
					TimerSystem.Instance.Remove(capturedVisionHiddenTimer);
					capturedVisionHiddenTimer = null;
					this.SwitchBackToRole();
				}
			},
			Sync = new bool?(true)
		}));
	}

	// Token: 0x0601A305 RID: 107269 RVA: 0x007B11DC File Offset: 0x007AF3DC
	private void SwitchBackToRole()
	{
		this.IsEnding = false;
		base.CueComponent.AddCue(19000000201L, new GameplayCueParam?(new GameplayCueParam
		{
			Sync = new bool?(true),
			Instant = true
		}));
		int valueOrDefault = ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault();
		ModelBase<SceneTeamModel>.Instance.SwitchGroup(valueOrDefault, this.LastGroupType.GetValueOrDefault(ETeamGroupType.Battle), false, false);
		this.LastGroupType = null;
		EntityHandle visionControlHandle = GameplayAbilityVisionControl.VisionControlHandle;
		object obj;
		if (visionControlHandle == null)
		{
			obj = null;
		}
		else
		{
			WorldEntity entity = visionControlHandle.Entity;
			obj = ((entity != null) ? entity.GetComponent<CharacterGameplayCueComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 != null)
		{
			obj2.RemoveCueByHandle((long)this.CueHandle);
		}
		GameplayAbilityVisionControl.VisionControlHandle = null;
	}

	// Token: 0x0601A306 RID: 107270 RVA: 0x007B1295 File Offset: 0x007AF495
	public static void CreateStaticDefaultValue()
	{
		GameplayAbilityVisionControl.VisionControlHandle = null;
	}

	// Token: 0x0601A307 RID: 107271 RVA: 0x007B129D File Offset: 0x007AF49D
	public static void ResetStaticDefaultValue()
	{
		GameplayAbilityVisionControl.VisionControlHandle = null;
	}

	// Token: 0x0400D285 RID: 53893
	[Nullable(2)]
	private ITagTask WaitDisableHideActorTagRemoveTask;

	// Token: 0x0400D286 RID: 53894
	private ETeamGroupType? LastGroupType;

	// Token: 0x0400D287 RID: 53895
	[Nullable(2)]
	public static EntityHandle VisionControlHandle;

	// Token: 0x0400D288 RID: 53896
	private int CueHandle;

	// Token: 0x0400D289 RID: 53897
	private bool IsEnding;
}
