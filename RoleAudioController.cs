using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Core.Framework;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02003209 RID: 12809
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class RoleAudioController : ControllerBase<RoleAudioController>
{
	// Token: 0x0601A922 RID: 108834 RVA: 0x007E03D0 File Offset: 0x007DE5D0
	private void InitCoolDownMap()
	{
		foreach (ERoleAudioType eroleAudioType in new ERoleAudioType[]
		{
			ERoleAudioType.Global,
			ERoleAudioType.FastClimb,
			ERoleAudioType.Glide,
			ERoleAudioType.ClimbLeap,
			ERoleAudioType.StrengthChangeTired,
			ERoleAudioType.StrengthChangeTiredLow,
			ERoleAudioType.UseHookSkill,
			ERoleAudioType.ScanTreasureBox,
			ERoleAudioType.OpenTreasureBox,
			ERoleAudioType.VisionMorph,
			ERoleAudioType.VisionSummon,
			ERoleAudioType.Dodge,
			ERoleAudioType.Parry,
			ERoleAudioType.EnterBattle,
			ERoleAudioType.UnderAttack,
			ERoleAudioType.KnockUp,
			ERoleAudioType.Accelerate
		})
		{
			this.IntervalCoolDownTimeMap[eroleAudioType] = new RoleAudioCoolDownTime(eroleAudioType);
		}
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("FixHookSkillList");
		if (intArrayConfig != null)
		{
			this.FixHookSkillList = new List<int>();
			this.FixHookSkillList.AddRange(intArrayConfig);
		}
		IReadOnlyList<int> intArrayConfig2 = ConfigCommonParamById.GetIntArrayConfig("SuperSprintStartSkillList");
		if (intArrayConfig2 != null)
		{
			this.SuperSprintStartSkillList = new List<int>();
			this.SuperSprintStartSkillList.AddRange(intArrayConfig2);
		}
		IReadOnlyList<int> intArrayConfig3 = ConfigCommonParamById.GetIntArrayConfig("SuperSprintEndSkillList");
		if (intArrayConfig3 != null)
		{
			this.SuperSprintEndSkillList = new List<int>();
			this.SuperSprintEndSkillList.AddRange(intArrayConfig3);
		}
		IReadOnlyList<SkillAudioEvent> configList = ConfigSkillAudioEventAll.GetConfigList(true);
		if (configList != null && configList.Count > 0)
		{
			foreach (SkillAudioEvent skillAudioEvent in configList)
			{
				this.SkillAudioId.Add(skillAudioEvent.Id);
			}
		}
	}

	// Token: 0x0601A923 RID: 108835 RVA: 0x007E04F0 File Offset: 0x007DE6F0
	protected override bool OnInit()
	{
		this.InitCoolDownMap();
		this.InitDodgeProgressionParams();
		this.LowStrengthPercentage = (double)ConfigCommonParamById.GetIntConfig("LowEndurancePercent").GetValueOrDefault() / 10000.0;
		Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnUseSkill));
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OpenTreasureBox, new Action<int>(this.OnOpenTreasureBox));
		Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
		ControllerBase<FormationAttributeController>.Instance.AddValueListener(EFormationAttributeId.Strength, new TValueListener(this.OnStrengthChanged), null);
		Singleton<Net>.Instance.Register<RoleSceneVoiceSwitchNotify>(ENotifyMessageId.RoleSceneVoiceSwitchNotify, new Action<RoleSceneVoiceSwitchNotify, Net.CallbackStatus>(this.OnUpdateAudioIgnoreNotify));
		return true;
	}

	// Token: 0x0601A924 RID: 108836 RVA: 0x007E05D0 File Offset: 0x007DE7D0
	protected override void OnTick(float delta)
	{
		if (this.UpdateDynamicTrace)
		{
			this.UpdateAudioDynamicTrace();
			this.LastTime = Singleton<Time>.Instance.Now;
			return;
		}
		if (Global.BaseCharacter == null || this.ActorComponent == null || !ModelBase<GameModeModel>.Instance.WorldDone || ModelBase<GameModeModel>.Instance.IsTeleport)
		{
			return;
		}
		BaseMoveComponent moveComp = this.ActorComponent.MoveComp;
		if (moveComp != null && moveComp.IsMoving)
		{
			this.IntervalTime = 50;
		}
		else
		{
			this.IntervalTime = 500;
		}
		if (Singleton<Time>.Instance.Now - this.LastTime < (double)this.IntervalTime)
		{
			return;
		}
		this.LastTime = Singleton<Time>.Instance.Now;
		this.SetUpdateAudioDynamicTrace(false);
	}

	// Token: 0x0601A925 RID: 108837 RVA: 0x007E0684 File Offset: 0x007DE884
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnUseSkill));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		Singleton<EventSystem>.Instance.Remove(EEventName.OpenTreasureBox, new Action<int>(this.OnOpenTreasureBox));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnUpdateSceneTeam));
		ControllerBase<FormationAttributeController>.Instance.RemoveValueListener(EFormationAttributeId.Strength, new TValueListener(this.OnStrengthChanged));
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleSceneVoiceSwitchNotify);
		return true;
	}

	// Token: 0x0601A926 RID: 108838 RVA: 0x007E0726 File Offset: 0x007DE926
	public void SetUpdateAudioDynamicTrace(bool force = false)
	{
		this.ForceUpdateDynamicTrace = force;
		if (this.UpdateDynamicTrace)
		{
			return;
		}
		this.UpdateDynamicTrace = true;
		this.LastSetDynamicTrace = false;
	}

	// Token: 0x0601A927 RID: 108839 RVA: 0x007E0748 File Offset: 0x007DE948
	private void UpdateAudioDynamicTrace()
	{
		UKuroAudioEnvironmentSubsystem audioEnvironmentSubsystem = UKuroAudioStatics.GetAudioEnvironmentSubsystem(Singleton<Info>.Instance.World);
		if (audioEnvironmentSubsystem == null)
		{
			this.LastSetDynamicTrace = false;
			this.UpdateDynamicTrace = false;
			return;
		}
		if (this.LastSetDynamicTrace)
		{
			audioEnvironmentSubsystem.DynamicReverbApply();
			this.LastSetDynamicTrace = false;
			this.UpdateDynamicTrace = false;
			if (this.ForceUpdateDynamicTrace)
			{
				this.SetUpdateAudioDynamicTrace(true);
			}
			return;
		}
		if (this.ActorComponent != null)
		{
			UKuroAudioEnvironmentSubsystem ukuroAudioEnvironmentSubsystem = audioEnvironmentSubsystem;
			FVectorDouble actorLocation = this.ActorComponent.ActorLocation;
			ukuroAudioEnvironmentSubsystem.D_DynamicReverbTrace(actorLocation, this.ForceUpdateDynamicTrace);
			this.ForceUpdateDynamicTrace = false;
			this.LastSetDynamicTrace = true;
			return;
		}
		this.UpdateDynamicTrace = false;
	}

	// Token: 0x0601A928 RID: 108840 RVA: 0x007E07DC File Offset: 0x007DE9DC
	public int PlayRoleAudio(Entity entity, ERoleAudioType type, [Nullable(2)] Action<EAkCallbackType, UAkCallbackInfo> callback = null)
	{
		CharacterActorComponent characterActorComponent = (entity != null) ? entity.GetComponent<CharacterActorComponent>() : null;
		RoleAudioComponent roleAudioComponent = (entity != null) ? entity.GetComponent<RoleAudioComponent>() : null;
		UAkComponent uakComponent = (roleAudioComponent != null) ? roleAudioComponent.GetAkComponent(null) : null;
		if (entity == null || characterActorComponent == null || roleAudioComponent == null || uakComponent == null || !roleAudioComponent.IsConfig())
		{
			return 0;
		}
		if (type == ERoleAudioType.Dodge)
		{
			this.UpdateDodgeAudioEvent(entity);
		}
		if (type == ERoleAudioType.VisionMorph || type == ERoleAudioType.VisionSummon)
		{
			BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
			if (component != null && component.HasTag(GameplayTagDefine.EGameplayTagId["幻象.Common.禁止播放语音"]))
			{
				return 0;
			}
		}
		return this.OnPlayRoleAudio(characterActorComponent.CreatureData.GetPbDataId(), entity.Id, uakComponent, type, this.GetRoleAudioConfig(type, roleAudioComponent.GetConfig()), callback);
	}

	// Token: 0x0601A929 RID: 108841 RVA: 0x007E089C File Offset: 0x007DEA9C
	private unsafe int OnPlayRoleAudio(int roleId, int entityId, UAkComponent akComponent, ERoleAudioType type, string eventName, [Nullable(2)] Action<EAkCallbackType, UAkCallbackInfo> callback = null)
	{
		RoleAudioCoolDownTime roleAudioCoolDownTime;
		if (!this.IntervalCoolDownTimeMap.TryGetValue(ERoleAudioType.Global, out roleAudioCoolDownTime) || !roleAudioCoolDownTime.CheckCoolDownTime(roleId, entityId, false, false))
		{
			return 0;
		}
		CharacterActorComponent actorComponent = this.ActorComponent;
		bool flag;
		if (actorComponent == null)
		{
			flag = false;
		}
		else
		{
			BaseMoveComponent component = actorComponent.Entity.GetComponent<BaseMoveComponent>();
			flag = ((component != null) ? new bool?(component.IsInRoll()) : null).GetValueOrDefault();
		}
		if (flag)
		{
			return 0;
		}
		RoleAudioCoolDownTime roleAudioCoolDownTime2;
		if (!this.IntervalCoolDownTimeMap.TryGetValue(type, out roleAudioCoolDownTime2))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[RoleAudio] IntervalCoolDownTimeMap没注册音频配置数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AudioType", this.GetRoleAudioTypeDesc(type));
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return 0;
		}
		if ((roleAudioCoolDownTime2.GroupId & this.RoleAudioIgnoreType) != 0)
		{
			return 0;
		}
		if (string.IsNullOrEmpty(eventName))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Audio;
			ELogAuthor author2 = ELogAuthor.CWZ;
			string message2 = "[RoleAudio] event为空 在尝试播放角色未配置的语音";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RoleId", roleId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Event", eventName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Owner", akComponent.GetOwner());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("AudioType", this.GetRoleAudioTypeDesc(type));
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			return 0;
		}
		if (!roleAudioCoolDownTime2.CheckCoolDownTime(roleId, entityId, true, true))
		{
			return 0;
		}
		roleAudioCoolDownTime.RefreshCoolDownTime(entityId, true);
		if (callback != null)
		{
			return Singleton<AudioSystem>.Instance.PostEvent(eventName, akComponent, new PostEventArgs?(new PostEventArgs
			{
				CallbackMask = new ECallbackMask?(ECallbackMask.EndOfEvent),
				CallbackHandler = delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
				{
					callback(callbackType, callbackInfo);
				}
			}));
		}
		return Singleton<AudioSystem>.Instance.PostEvent(eventName, akComponent, null);
	}

	// Token: 0x0601A92A RID: 108842 RVA: 0x007E0A7C File Offset: 0x007DEC7C
	public void RefreshPlayAudioCooldownTime(ERoleAudioType type, int entityId)
	{
		RoleAudioCoolDownTime roleAudioCoolDownTime;
		if (!this.IntervalCoolDownTimeMap.TryGetValue(type, out roleAudioCoolDownTime))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "[RoleAudio] IntervalCoolDownTimeMap没注册音频配置数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AudioType", this.GetRoleAudioTypeDesc(type));
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		roleAudioCoolDownTime.RefreshCoolDownTime(entityId, true);
	}

	// Token: 0x0601A92B RID: 108843 RVA: 0x007E0ACF File Offset: 0x007DECCF
	[NullableContext(2)]
	private void OnUpdateAudioIgnoreNotify(RoleSceneVoiceSwitchNotify notify, Net.CallbackStatus _)
	{
		this.RoleAudioIgnoreType = notify.VoiceGroupData;
	}

	// Token: 0x0601A92C RID: 108844 RVA: 0x007E0AE0 File Offset: 0x007DECE0
	private void OnUseSkill(int charId, int skillId, bool isAutonomousProxy)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(charId);
		if (entity == null)
		{
			return;
		}
		List<int> fixHookSkillList = this.FixHookSkillList;
		if ((fixHookSkillList != null && fixHookSkillList.Contains(skillId)) || skillId == 210001)
		{
			this.PlayRoleAudio(entity, ERoleAudioType.UseHookSkill, null);
		}
		List<int> superSprintStartSkillList = this.SuperSprintStartSkillList;
		if (superSprintStartSkillList != null && superSprintStartSkillList.Contains(skillId))
		{
			this.OnPlayAccelerateAudio(entity, global::ECharMoveState.Sprint, global::ECharPositionState.Ground, null, null);
		}
		List<int> superSprintEndSkillList = this.SuperSprintEndSkillList;
		if (superSprintEndSkillList != null && superSprintEndSkillList.Contains(skillId))
		{
			this.RefreshPlayAudioCooldownTime(ERoleAudioType.Global, entity.Id);
		}
	}

	// Token: 0x0601A92D RID: 108845 RVA: 0x007E0B7C File Offset: 0x007DED7C
	private void OnUpdateSceneTeam()
	{
		this.CacheList.Clear();
		this.CacheList.AddRange(this.LastAudioEvents);
		this.LastAudioEvents.Clear();
		foreach (EntityHandle entityHandle in ModelBase<SceneTeamModel>.Instance.GetTeamEntities(false))
		{
			WorldEntity entity = entityHandle.Entity;
			RoleAudioComponent roleAudioComponent = (entity != null) ? entity.CheckGetComponent<RoleAudioComponent>() : null;
			if (roleAudioComponent != null && roleAudioComponent.IsConfig())
			{
				string text = (roleAudioComponent != null) ? roleAudioComponent.GetFootstepEvent() : null;
				if (text != null && !this.LastAudioEvents.Contains(text))
				{
					this.LastAudioEvents.Add(text);
				}
				string text2 = (roleAudioComponent != null) ? roleAudioComponent.GetFoleyEvent() : null;
				if (text2 != null && !this.LastAudioEvents.Contains(text2))
				{
					this.LastAudioEvents.Add(text2);
				}
			}
		}
		foreach (string text3 in this.CacheList)
		{
			if (!this.LastAudioEvents.Contains(text3))
			{
				Singleton<AudioSystem>.Instance.ReleaseAudioEvent(text3);
			}
		}
		foreach (string text4 in this.LastAudioEvents)
		{
			if (!this.CacheList.Contains(text4))
			{
				Singleton<AudioSystem>.Instance.PreloadAudioEvent(text4);
			}
		}
	}

	// Token: 0x0601A92E RID: 108846 RVA: 0x007E0D20 File Offset: 0x007DEF20
	private void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		WorldEntity entity = newEntity.Entity;
		this.ActorComponent = ((entity != null) ? entity.CheckGetComponent<CharacterActorComponent>() : null);
		WorldEntity entity2 = newEntity.Entity;
		this.AudioComponent = ((entity2 != null) ? entity2.CheckGetComponent<RoleAudioComponent>() : null);
		RoleAudioComponent audioComponent = this.AudioComponent;
		if (audioComponent != null && audioComponent.IsConfig())
		{
			Singleton<AudioSystem>.Instance.SetState("role_name", this.AudioComponent.GetConfigName(), true);
		}
		RoleAudioComponent audioComponent2 = this.AudioComponent;
		UAkComponent uakComponent = (audioComponent2 != null) ? audioComponent2.GetAkComponent(null) : null;
		if (uakComponent != null)
		{
			Singleton<AudioSystem>.Instance.PostEvent("scene_role_switched_front", uakComponent, null);
		}
	}

	// Token: 0x0601A92F RID: 108847 RVA: 0x007E0DC5 File Offset: 0x007DEFC5
	private void OnOpenTreasureBox(int entityId)
	{
		if (this.ActorComponent == null)
		{
			return;
		}
		this.PlayRoleAudio(this.ActorComponent.Entity, ERoleAudioType.OpenTreasureBox, null);
	}

	// Token: 0x0601A930 RID: 108848 RVA: 0x007E0DE8 File Offset: 0x007DEFE8
	private void OnStrengthChanged(EFormationAttributeId attrId, float newValue, float oldValue)
	{
		if (attrId != EFormationAttributeId.Strength || newValue > oldValue)
		{
			return;
		}
		SceneTeamModel instance = ModelBase<SceneTeamModel>.Instance;
		if (instance != null && instance.ChangingRole)
		{
			return;
		}
		double num = (double)ControllerBase<FormationAttributeController>.Instance.GetMax(EFormationAttributeId.Strength);
		if ((double)newValue / num > this.LowStrengthPercentage)
		{
			return;
		}
		RoleAudioComponent audioComponent = this.AudioComponent;
		UAkComponent uakComponent = (audioComponent != null) ? audioComponent.GetAkComponent(null) : null;
		RoleAudioComponent audioComponent2 = this.AudioComponent;
		string text = (audioComponent2 != null) ? audioComponent2.GetLowStrengthEvent() : null;
		if (this.ActorComponent == null || uakComponent == null || text == null)
		{
			return;
		}
		RoleAudioCoolDownTime roleAudioCoolDownTime;
		RoleAudioCoolDownTime roleAudioCoolDownTime2;
		if (!this.IntervalCoolDownTimeMap.TryGetValue(ERoleAudioType.StrengthChangeTired, out roleAudioCoolDownTime) || !this.IntervalCoolDownTimeMap.TryGetValue(ERoleAudioType.StrengthChangeTiredLow, out roleAudioCoolDownTime2))
		{
			return;
		}
		int pbDataId = this.ActorComponent.CreatureData.GetPbDataId();
		int id = this.ActorComponent.Entity.Id;
		if (!roleAudioCoolDownTime.CheckCoolDownTime(pbDataId, id, false, false) || !roleAudioCoolDownTime2.CheckCoolDownTime(pbDataId, id, false, false))
		{
			return;
		}
		bool flag;
		if ((double)oldValue / num > this.LowStrengthPercentage)
		{
			flag = roleAudioCoolDownTime.CheckCoolDownTime(pbDataId, id, true, true);
		}
		else
		{
			flag = roleAudioCoolDownTime2.CheckCoolDownTime(pbDataId, id, true, true);
		}
		if (!flag)
		{
			return;
		}
		this.OnPlayRoleAudio(this.ActorComponent.CreatureData.GetPbDataId(), id, uakComponent, ERoleAudioType.StrengthChangeTired, text, null);
	}

	// Token: 0x0601A931 RID: 108849 RVA: 0x007E0F2C File Offset: 0x007DF12C
	public void OnPlayerIsHit(Entity entity)
	{
		this.ResetDodgeAudioLevel();
		TimerSystem.Instance.Next(delegate(float _)
		{
			this.PlayRoleAudio(entity, ERoleAudioType.UnderAttack, null);
		}, null, null);
	}

	// Token: 0x0601A932 RID: 108850 RVA: 0x007E0F6C File Offset: 0x007DF16C
	public void OnPlayerEnterFight(Entity entity, double distance)
	{
		if (distance >= 1000.0)
		{
			int id = entity.Id;
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			int? num = (baseCharacter != null) ? new int?(baseCharacter.EntityId) : null;
			if (id == num.GetValueOrDefault() & num != null)
			{
				this.PlayRoleAudio(entity, ERoleAudioType.EnterBattle, null);
				return;
			}
		}
	}

	// Token: 0x0601A933 RID: 108851 RVA: 0x007E0FCC File Offset: 0x007DF1CC
	public void OnMoveStateChange(global::ECharMoveState state, Entity entity)
	{
		switch (state)
		{
		case global::ECharMoveState.FastClimb:
			TimerSystem.Instance.Next(delegate(float _)
			{
				this.PlayRoleAudio(entity, ERoleAudioType.FastClimb, null);
			}, null, null);
			break;
		case global::ECharMoveState.Glide:
			this.PlayRoleAudio(entity, ERoleAudioType.Glide, null);
			break;
		case global::ECharMoveState.KnockUp:
			this.PlayRoleAudio(entity, ERoleAudioType.KnockUp, null);
			break;
		}
		this.InterruptAccelerateAudio(state, entity);
	}

	// Token: 0x0601A934 RID: 108852 RVA: 0x007E1054 File Offset: 0x007DF254
	public void OnPlayerDies(Entity entity)
	{
		CharacterActorComponent characterActorComponent = (entity != null) ? entity.GetComponent<CharacterActorComponent>() : null;
		RoleAudioComponent roleAudioComponent = (entity != null) ? entity.GetComponent<RoleAudioComponent>() : null;
		UAkComponent uakComponent = (roleAudioComponent != null) ? roleAudioComponent.GetAkComponent(null) : null;
		if (entity != null && characterActorComponent != null && roleAudioComponent != null && uakComponent != null && roleAudioComponent.IsConfig())
		{
			int id = entity.Id;
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			int? num = (baseCharacter != null) ? new int?(baseCharacter.EntityId) : null;
			if (id == num.GetValueOrDefault() & num != null)
			{
				Singleton<AudioSystem>.Instance.PostEvent(roleAudioComponent.GetDeathEvent(), uakComponent, null);
				return;
			}
		}
	}

	// Token: 0x0601A935 RID: 108853 RVA: 0x007E10FC File Offset: 0x007DF2FC
	public void OnPlayAccelerateAudio(Entity entity, global::ECharMoveState moveState, global::ECharPositionState positionState, int? movementMode = null, int? customMode = null)
	{
		if (!ControllerBase<FormationDataController>.Instance.GlobalIsInFight && moveState == global::ECharMoveState.Sprint)
		{
			this.AccelerateAudioHandle = this.PlayRoleAudio(entity, ERoleAudioType.Accelerate, delegate(EAkCallbackType callbackType, UAkCallbackInfo callbackInfo)
			{
				this.AccelerateAudioHandle = 0;
			});
		}
	}

	// Token: 0x0601A936 RID: 108854 RVA: 0x007E112C File Offset: 0x007DF32C
	private void InterruptAccelerateAudio(global::ECharMoveState state, Entity entity)
	{
		if (this.AccelerateAudioHandle == 0 || this.AccelerateAudioHandle != 0)
		{
			return;
		}
		global::ECharPositionState positionState = entity.GetComponent<BaseUnifiedStateComponent>().PositionState;
		if (state == global::ECharMoveState.Sprint)
		{
			return;
		}
		Singleton<AudioSystem>.Instance.ExecuteAction(this.AccelerateAudioHandle, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
		{
			TransitionDuration = new int?(1000)
		}));
		this.AccelerateAudioHandle = 0;
	}

	// Token: 0x0601A937 RID: 108855 RVA: 0x007E1194 File Offset: 0x007DF394
	private void InitDodgeProgressionParams()
	{
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("DodgeProgressionAudioResetList");
		IReadOnlyList<string> stringArrayConfig = ConfigCommonParamById.GetStringArrayConfig("DodgeProgressionAudioEventList");
		IReadOnlyList<int> intArrayConfig2 = ConfigCommonParamById.GetIntArrayConfig("DodgeProgressionAudioTimesList");
		if (stringArrayConfig != null && intArrayConfig2 != null && intArrayConfig != null)
		{
			this.DodgeProgressionAudioResetList = new List<int>();
			this.DodgeProgressionAudioEventList = new List<string>();
			this.DodgeProgressionAudioTimesList = new List<int>();
			this.DodgeProgressionAudioResetList.AddRange(intArrayConfig);
			this.DodgeProgressionAudioEventList.AddRange(stringArrayConfig);
			this.DodgeProgressionAudioTimesList.AddRange(intArrayConfig2);
		}
	}

	// Token: 0x0601A938 RID: 108856 RVA: 0x007E1210 File Offset: 0x007DF410
	private void UpdateDodgeAudioEvent(Entity entity)
	{
		if (this.DodgeProgressionAudioResetList == null || this.DodgeProgressionAudioResetList.Count == 0 || this.DodgeProgressionAudioEventList == null || this.DodgeProgressionAudioEventList.Count == 0 || this.DodgeProgressionAudioTimesList == null || this.DodgeProgressionAudioTimesList.Count == 0)
		{
			return;
		}
		RoleAudioComponent roleAudioComponent = (entity != null) ? entity.GetComponent<RoleAudioComponent>() : null;
		UAkComponent uakComponent = (roleAudioComponent != null) ? roleAudioComponent.GetAkComponent(null) : null;
		if (entity == null || roleAudioComponent == null || uakComponent == null)
		{
			return;
		}
		double now = Singleton<Time>.Instance.Now;
		double num = now - this.LastDodgeTime;
		int num2 = (this.LastDodgeLevelIndex < this.DodgeProgressionAudioResetList.Count) ? this.DodgeProgressionAudioResetList[this.LastDodgeLevelIndex] : this.DodgeProgressionAudioResetList[0];
		if (this.LastDodgeTime > 0.0 && num >= (double)num2)
		{
			this.CurrentDodgeTimes = 0;
		}
		int num3 = 0;
		for (int i = this.DodgeProgressionAudioTimesList.Count - 1; i >= 0; i--)
		{
			if (this.CurrentDodgeTimes >= this.DodgeProgressionAudioTimesList[i])
			{
				num3 = i;
				break;
			}
		}
		string @event = this.DodgeProgressionAudioEventList[num3];
		Singleton<AudioSystem>.Instance.PostEvent(@event, uakComponent, null);
		this.CurrentDodgeTimes++;
		this.LastDodgeLevelIndex = num3;
		this.LastDodgeTime = now;
	}

	// Token: 0x0601A939 RID: 108857 RVA: 0x007E136F File Offset: 0x007DF56F
	public void ResetDodgeAudioLevel()
	{
		this.CurrentDodgeTimes = 0;
	}

	// Token: 0x0601A93A RID: 108858 RVA: 0x007E1378 File Offset: 0x007DF578
	public bool CheckSkillAudioId(long id)
	{
		return this.SkillAudioId.Contains((int)id);
	}

	// Token: 0x0601A93B RID: 108859 RVA: 0x007E1388 File Offset: 0x007DF588
	public string GetRoleAudioConfig(ERoleAudioType type, RoleSkinAudio? config)
	{
		if (config == null)
		{
			return "";
		}
		switch (type)
		{
		case ERoleAudioType.FastClimb:
			return config.Value.FastClimbEvent;
		case ERoleAudioType.Glide:
			return config.Value.EnterGlideEvent;
		case ERoleAudioType.ClimbLeap:
			return config.Value.ClimbLeapEvent;
		case (ERoleAudioType)1004:
			break;
		case ERoleAudioType.UseHookSkill:
			return config.Value.UseExploreHookEvent;
		case ERoleAudioType.ScanTreasureBox:
			return config.Value.ScanTreasureBoxEvent;
		case ERoleAudioType.OpenTreasureBox:
			return config.Value.OpenTreasureBoxEvent;
		case ERoleAudioType.Accelerate:
			return config.Value.AccelerateEvent;
		default:
			switch (type)
			{
			case ERoleAudioType.VisionMorph:
				return config.Value.VisionMorphEvent;
			case ERoleAudioType.VisionSummon:
				return config.Value.VisionSummonEvent;
			case ERoleAudioType.Dodge:
				return config.Value.ExtremeDodgeEvent;
			case ERoleAudioType.Parry:
				return config.Value.ParryEvent;
			case ERoleAudioType.EnterBattle:
				return config.Value.EnterBattleEvent;
			case ERoleAudioType.UnderAttack:
				return config.Value.UnderAttackEvent;
			case ERoleAudioType.KnockUp:
				return config.Value.KnockUpEvent;
			}
			break;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Audio;
		ELogAuthor author = ELogAuthor.CWZ;
		string message = "[RoleAudio] 错误的类型";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", type);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return "";
	}

	// Token: 0x0601A93C RID: 108860 RVA: 0x007E1514 File Offset: 0x007DF714
	public string GetRoleAudioTypeDesc(ERoleAudioType type)
	{
		if (type <= ERoleAudioType.Accelerate)
		{
			if (type == ERoleAudioType.Global)
			{
				return "全局";
			}
			switch (type)
			{
			case ERoleAudioType.FastClimb:
				return "快速攀爬";
			case ERoleAudioType.Glide:
				return "滑翔";
			case ERoleAudioType.ClimbLeap:
				return "跨越";
			case ERoleAudioType.UseHookSkill:
				return "使用钩锁技能";
			case ERoleAudioType.ScanTreasureBox:
				return "扫描到宝箱";
			case ERoleAudioType.OpenTreasureBox:
				return "开宝箱";
			case ERoleAudioType.Accelerate:
				return "加速";
			}
		}
		else
		{
			switch (type)
			{
			case ERoleAudioType.VisionMorph:
				return "幻象变身";
			case ERoleAudioType.VisionSummon:
				return "幻象召唤";
			case (ERoleAudioType)2003:
				break;
			case ERoleAudioType.Dodge:
				return "闪避";
			case ERoleAudioType.Parry:
				return "弹反";
			case ERoleAudioType.EnterBattle:
				return "进战";
			case ERoleAudioType.UnderAttack:
				return "受击";
			case ERoleAudioType.KnockUp:
				return "被击飞";
			default:
				if (type - ERoleAudioType.StrengthChangeTired <= 1)
				{
					return "体力变化";
				}
				break;
			}
		}
		return "未定义";
	}

	// Token: 0x0400D721 RID: 55073
	[Nullable(2)]
	private List<int> FixHookSkillList;

	// Token: 0x0400D722 RID: 55074
	[Nullable(2)]
	private List<int> SuperSprintStartSkillList;

	// Token: 0x0400D723 RID: 55075
	[Nullable(2)]
	private List<int> SuperSprintEndSkillList;

	// Token: 0x0400D724 RID: 55076
	[Nullable(2)]
	private CharacterActorComponent ActorComponent;

	// Token: 0x0400D725 RID: 55077
	[Nullable(2)]
	private RoleAudioComponent AudioComponent;

	// Token: 0x0400D726 RID: 55078
	private double LowStrengthPercentage;

	// Token: 0x0400D727 RID: 55079
	private readonly HashSet<int> SkillAudioId = new HashSet<int>();

	// Token: 0x0400D728 RID: 55080
	private readonly Dictionary<ERoleAudioType, RoleAudioCoolDownTime> IntervalCoolDownTimeMap = new Dictionary<ERoleAudioType, RoleAudioCoolDownTime>();

	// Token: 0x0400D729 RID: 55081
	private int IntervalTime = 500;

	// Token: 0x0400D72A RID: 55082
	private double LastTime;

	// Token: 0x0400D72B RID: 55083
	private bool LastSetDynamicTrace;

	// Token: 0x0400D72C RID: 55084
	private bool UpdateDynamicTrace;

	// Token: 0x0400D72D RID: 55085
	private bool ForceUpdateDynamicTrace;

	// Token: 0x0400D72E RID: 55086
	private int RoleAudioIgnoreType;

	// Token: 0x0400D72F RID: 55087
	private readonly List<string> LastAudioEvents = new List<string>();

	// Token: 0x0400D730 RID: 55088
	private readonly List<string> CacheList = new List<string>();

	// Token: 0x0400D731 RID: 55089
	private int AccelerateAudioHandle;

	// Token: 0x0400D732 RID: 55090
	[Nullable(2)]
	private List<int> DodgeProgressionAudioResetList;

	// Token: 0x0400D733 RID: 55091
	[Nullable(2)]
	private List<int> DodgeProgressionAudioTimesList;

	// Token: 0x0400D734 RID: 55092
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<string> DodgeProgressionAudioEventList;

	// Token: 0x0400D735 RID: 55093
	private double LastDodgeTime;

	// Token: 0x0400D736 RID: 55094
	private int LastDodgeLevelIndex;

	// Token: 0x0400D737 RID: 55095
	private int CurrentDodgeTimes;
}
