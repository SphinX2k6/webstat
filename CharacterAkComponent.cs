using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game;
using CSharpScript.Game.Module.Audio;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x02003027 RID: 12327
[NullableContext(1)]
[Nullable(0)]
public class CharacterAkComponent : EntityComponent, IComponentDependency
{
	// Token: 0x170021F4 RID: 8692
	// (get) Token: 0x060192C4 RID: 103108 RVA: 0x0072D899 File Offset: 0x0072BA99
	public static Type[] Dependencies
	{
		get
		{
			return new Type[]
			{
				typeof(CharacterActorComponent),
				typeof(CreatureDataComponent)
			};
		}
	}

	// Token: 0x060192C5 RID: 103109 RVA: 0x0072D8BB File Offset: 0x0072BABB
	[NullableContext(2)]
	protected override bool OnInitData(IEntityArgs args = null)
	{
		this.DynamicConditionProxy = new AkComponentDynamicConditionProxy();
		this.AudioResult = new PlayResult();
		return true;
	}

	// Token: 0x060192C6 RID: 103110 RVA: 0x0072D8D4 File Offset: 0x0072BAD4
	protected override bool OnStart()
	{
		this.CreatureData = base.Entity.GetComponent<CreatureDataComponent>();
		if (this.CreatureData == null)
		{
			return false;
		}
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		CharacterActorComponent actorComp = this.ActorComp;
		if (((actorComp != null) ? actorComp.Actor : null) == null)
		{
			return false;
		}
		this.MoveComp = base.Entity.GetComponent<BaseMoveComponent>();
		if (this.MoveComp == null)
		{
			return false;
		}
		this.Debug = false;
		this.IsFirstGet = true;
		AkComponentStatic.Load();
		this.DynamicConditionProxy.Init(this.ActorComp, this.AkComponentConfig.Value);
		return true;
	}

	// Token: 0x060192C7 RID: 103111 RVA: 0x0072D96F File Offset: 0x0072BB6F
	protected override void OnTick(float delta)
	{
		if (this.Debug)
		{
			this.DebugText();
		}
		if (this.IsRole && this.IsP1)
		{
			this.UpdateMoveState();
			this.UpdateAudioEnvironment();
			if (this.FoleySynthController != null)
			{
				this.FoleySynthController.Tick(delta);
			}
		}
	}

	// Token: 0x060192C8 RID: 103112 RVA: 0x0072D9B0 File Offset: 0x0072BBB0
	protected override void OnActivate()
	{
		CreatureDataComponent creatureData = this.CreatureData;
		this.IsRole = (creatureData != null && creatureData.GetEntityType() == EEntityType.Player);
		this.IsP1 = false;
		if (this.IsRole)
		{
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null && actorComp.IsAutonomousProxy)
			{
				this.IsP1 = true;
				goto IL_93;
			}
		}
		CreatureDataComponent creatureData2 = this.CreatureData;
		if (creatureData2 != null && creatureData2.IsConcomitantEntity)
		{
			long summonerId = this.CreatureData.GetSummonerId();
			int entityId = ModelBase<CreatureModel>.Instance.GetEntityId(summonerId);
			CharacterAkComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAkComponent>(entityId);
			if (component != null && component.IsP1)
			{
				this.IsP1 = true;
			}
		}
		IL_93:
		if (this.IsRole)
		{
			this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
			if (this.IsP1)
			{
				this.FoleySynthController = new FoleySynthController(this.ActorComp, this, this.TagComp);
				this.FoleySynthController.Init(this.FoleySynthAllConfig);
			}
		}
		this.UpdateSwitch();
	}

	// Token: 0x060192C9 RID: 103113 RVA: 0x0072DAA0 File Offset: 0x0072BCA0
	private void UpdateSwitch()
	{
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp == null || !actorComp.Valid)
		{
			return;
		}
		ControllerBase<GameAudioController>.Instance.SetRolePriority(this.IsP1 ? ERoleAudioPriorityType.PlayerControl : ERoleAudioPriorityType.OtherControl, this.ActorComp.Actor);
	}

	// Token: 0x060192CA RID: 103114 RVA: 0x0072DADC File Offset: 0x0072BCDC
	private void UpdateMoveState()
	{
		if (AkComponentStatic.AkMoveState == EAkMoveState.Normal)
		{
			using (Dictionary<EAkMoveState, int>.Enumerator enumerator = AkComponentStatic.AkMoveStateMap.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<EAkMoveState, int> keyValuePair = enumerator.Current;
					EAkMoveState key = keyValuePair.Key;
					int value = keyValuePair.Value;
					BaseTagComponent tagComp = this.TagComp;
					if (tagComp != null && tagComp.HasTag(value))
					{
						AkComponentStatic.AkMoveState = key;
						Singleton<AudioSystem>.Instance.SetState("role_move", key.ToString(), true);
						break;
					}
				}
				return;
			}
		}
		int valueOrDefault = AkComponentStatic.AkMoveStateMap.GetValueOrDefault(AkComponentStatic.AkMoveState, 0);
		BaseTagComponent tagComp2 = this.TagComp;
		if (tagComp2 != null && tagComp2.HasTag(valueOrDefault))
		{
			return;
		}
		foreach (KeyValuePair<EAkMoveState, int> keyValuePair2 in AkComponentStatic.AkMoveStateMap)
		{
			EAkMoveState key2 = keyValuePair2.Key;
			int value2 = keyValuePair2.Value;
			BaseTagComponent tagComp3 = this.TagComp;
			if (tagComp3 != null && tagComp3.HasTag(value2))
			{
				AkComponentStatic.AkMoveState = key2;
				Singleton<AudioSystem>.Instance.SetState("role_move", key2.ToString(), true);
				return;
			}
		}
		AkComponentStatic.AkMoveState = EAkMoveState.Normal;
		Singleton<AudioSystem>.Instance.SetState("role_move", "Normal", true);
	}

	// Token: 0x060192CB RID: 103115 RVA: 0x0072DC4C File Offset: 0x0072BE4C
	private void RefreshEntityTypesVolumeControl()
	{
		CreatureDataComponent creatureData = this.CreatureData;
		EEntityType? eentityType = (creatureData != null) ? new EEntityType?(creatureData.GetEntityType()) : null;
		CharacterActorComponent actorComp = this.ActorComp;
		TsBaseCharacter tsBaseCharacter = (actorComp != null) ? actorComp.Actor : null;
		if (eentityType != null && tsBaseCharacter != null)
		{
			foreach (KeyValuePair<EEntityType, string> keyValuePair in CharacterAkComponent.AUDIO_ENTITY_TYPE_VOLUME_CONTROL)
			{
				EEntityType key = keyValuePair.Key;
				string value = keyValuePair.Value;
				EEntityType? eentityType2 = eentityType;
				EEntityType eentityType3 = key;
				if (eentityType2.GetValueOrDefault() == eentityType3 & eentityType2 != null)
				{
					Singleton<AudioSystem>.Instance.SetRtpcValue(value, 1f, new SetRtpcValueArgs?(new SetRtpcValueArgs
					{
						Actor = tsBaseCharacter
					}));
				}
				else
				{
					Singleton<AudioSystem>.Instance.SetRtpcValue(value, 0f, new SetRtpcValueArgs?(new SetRtpcValueArgs
					{
						Actor = tsBaseCharacter
					}));
				}
			}
			return;
		}
		if (eentityType == null)
		{
			throw new Exception("实体类型设置音量控制: 无法获取实体类型");
		}
		if (tsBaseCharacter == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Audio, ELogAuthor.YJY, "实体类型设置音量控制: 无法获取角色Actor", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x060192CC RID: 103116 RVA: 0x0072DD90 File Offset: 0x0072BF90
	protected override bool OnEnd()
	{
		this.DynamicConditionProxy.Clear();
		if (this.FoleySynthController != null)
		{
			this.FoleySynthController.Clear();
		}
		this.IsFirstGet = true;
		return true;
	}

	// Token: 0x060192CD RID: 103117 RVA: 0x0072DDB8 File Offset: 0x0072BFB8
	public void PostAudioEvent(string action)
	{
		int roleId = base.Entity.GetComponent<CreatureDataComponent>().GetRoleId();
		RoleAnimAudioData audioPathByName = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true).GetAudioData().GetAudioPathByName(action);
		if (audioPathByName == null)
		{
			return;
		}
		if (!string.IsNullOrEmpty(this.AudioResult.EventPath) && !audioPathByName.CanInterrupt)
		{
			return;
		}
		string audioPath = audioPathByName.AudioPath;
		if (this.AudioResult.EventPath == audioPath)
		{
			return;
		}
		Singleton<AudioController>.Instance.StopEvent(this.AudioResult, true, null);
		if (!string.IsNullOrEmpty(audioPath))
		{
			Singleton<AudioController>.Instance.PostEvent(audioPath, this.ActorComp.Actor, this.AudioResult, null, null, null, true, "");
		}
	}

	// Token: 0x060192CE RID: 103118 RVA: 0x0072DE80 File Offset: 0x0072C080
	public unsafe void SetSwitchByData(UAkComponent charAkComponent, string[] switchData)
	{
		for (int i = 0; i < switchData.Length; i++)
		{
			string[] array = switchData[i].Split('.', StringSplitOptions.None);
			if (array.Length == 2)
			{
				charAkComponent.SetSwitch(null, array[0], array[1]);
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Audio;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[PostAkEvent] switchData配置无效";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActorName:", this.ActorComp.Actor.GetName());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("switchArray:", array);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
	}

	// Token: 0x060192CF RID: 103119 RVA: 0x0072DF28 File Offset: 0x0072C128
	public unsafe void SetSwitchByUeData(UAkComponent charAkComponent, TArray<string> switchData)
	{
		for (int i = 0; i < switchData.Num(); i++)
		{
			string[] array = switchData.Get(i).Split('.', StringSplitOptions.None);
			if (array.Length == 2)
			{
				charAkComponent.SetSwitch(null, array[0], array[1]);
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Audio;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[PostAkEvent] switchData配置无效";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActorName:", this.ActorComp.Actor.GetName());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("switchArray:", array);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
	}

	// Token: 0x060192D0 RID: 103120 RVA: 0x0072DFD4 File Offset: 0x0072C1D4
	public int PostAkEvent(UAkComponent charAkComponent, [Nullable(2)] UAkAudioEvent eventPtr, string attachName, TArray<string> switchData, bool bFollow)
	{
		if (eventPtr == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[PostAkEvent] eventPtr无效";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActorName:", this.ActorComp.Actor.GetName());
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return -1;
		}
		this.SetSwitchByUeData(charAkComponent, switchData);
		this.DynamicConditionProxy.Do(this.ActorComp);
		if (bFollow)
		{
			int callbackMask = 0;
			FOnAkPostEventCallback fonAkPostEventCallback = null;
			return charAkComponent.PostAkEvent(eventPtr, callbackMask, fonAkPostEventCallback, eventPtr.GetName());
		}
		return UAkGameplayStatics.D_PostEventAtLocation(eventPtr, this.ActorComp.ActorLocation, global::Rotator.ZeroRotator, eventPtr.GetName(), this.ActorComp.Actor);
	}

	// Token: 0x060192D1 RID: 103121 RVA: 0x0072E074 File Offset: 0x0072C274
	public void SetDebug(bool bDebug)
	{
		this.Debug = bDebug;
	}

	// Token: 0x060192D2 RID: 103122 RVA: 0x0072E07D File Offset: 0x0072C27D
	public bool GetDebug()
	{
		return this.Debug;
	}

	// Token: 0x060192D3 RID: 103123 RVA: 0x0072E088 File Offset: 0x0072C288
	private unsafe void DebugText()
	{
		TsBaseCharacter actor = this.ActorComp.Actor;
		string name = actor.GetName();
		TArray<UActorComponent> tarray = actor.K2_GetComponentsByClass(UAkComponent.StaticClass());
		Singleton<Log>.Instance.Info(ELogModule.Audio, ELogAuthor.LJM, "---------------------------------------------", default(ReadOnlySpan<ValueTuple<string, object>>));
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Audio;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "CharacterAkComponent Tick Debug;";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor:", name);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		for (int i = 0; i < tarray.Num(); i++)
		{
			UAkComponent uakComponent = tarray.Get(i) as UAkComponent;
			if (uakComponent != null)
			{
				FVectorDouble center = uakComponent.D_K2_GetComponentLocation();
				UKismetSystemLibrary.D_DrawDebugSphere(actor, center, 15f, 12, new FLinearColor?(ColorUtils.LinearRed), 0f, 0f);
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Audio;
				ELogAuthor author2 = ELogAuthor.LJM;
				string message2 = "-----------AkComponent信息:";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Comp:", uakComponent);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AttachSocketName:", uakComponent.AttachSocketName);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.Audio;
		ELogAuthor author3 = ELogAuthor.LJM;
		string message3 = "-----------AkStatic信息:";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("State:", AkComponentStatic.AkMoveState);
		instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
	}

	// Token: 0x060192D4 RID: 103124 RVA: 0x0072E1EC File Offset: 0x0072C3EC
	public UAkComponent GetAkComponentBySocketName(FName socketName)
	{
		FName fname = socketName;
		if (FNameUtil.IsEmpty(new FName?(fname)))
		{
			fname = Singleton<CharacterNameDefines>.Instance.HIT_CASE_NAME;
		}
		TsBaseCharacter actor = this.ActorComp.Actor;
		UAkComponent uakComponent;
		if (this.IsFirstGet)
		{
			uakComponent = (actor.GetComponentByClass(UAkComponent.StaticClass()) as UAkComponent);
			this.IsFirstGet = false;
			if (uakComponent == null)
			{
				uakComponent = (actor.AddComponentByClass(UAkComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as UAkComponent);
			}
		}
		else
		{
			uakComponent = (actor.AddComponentByClass(UAkComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as UAkComponent);
		}
		uakComponent.K2_AttachToComponent(this.ActorComp.Actor.Mesh, fname, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.KeepWorld, true, true);
		CreatureDataComponent creatureData = this.CreatureData;
		EEntityType? eentityType = (creatureData != null) ? new EEntityType?(creatureData.GetEntityType()) : null;
		if (eentityType.GetValueOrDefault() == EEntityType.Npc || eentityType.GetValueOrDefault() == EEntityType.Monster)
		{
			uakComponent.bEnableOcclusion = true;
		}
		this.UpdateSwitch();
		this.DynamicConditionProxy.Init(this.ActorComp, this.AkComponentConfig.Value);
		this.RefreshEntityTypesVolumeControl();
		return uakComponent;
	}

	// Token: 0x060192D5 RID: 103125 RVA: 0x0072E324 File Offset: 0x0072C524
	private void UpdateAudioEnvironment()
	{
		if (Singleton<Time>.Instance.Now - this.LastUpdateEnvironmentAudioTime > 500.0)
		{
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp == null || !actorComp.Valid)
			{
				this.LastUpdateEnvironmentAudioTime = Singleton<Time>.Instance.Now;
				return;
			}
			if (global::Vector.DistSquared(this.LastUpdateEnvironmentAudioLocation, this.ActorComp.ActorLocationProxy) > 4.0)
			{
				this.LastUpdateEnvironmentAudioLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
				this.LastUpdateEnvironmentAudioTime = Singleton<Time>.Instance.Now;
			}
		}
	}

	// Token: 0x060192D6 RID: 103126 RVA: 0x0072E3BC File Offset: 0x0072C5BC
	public void SetFoleySynthFileDebug(bool debug, int[] models)
	{
		FoleySynthController foleySynthController = this.FoleySynthController;
		if (foleySynthController == null)
		{
			return;
		}
		foleySynthController.SetDebug(debug, models);
	}

	// Token: 0x060192D7 RID: 103127 RVA: 0x0072E3D0 File Offset: 0x0072C5D0
	public static void SetGlobalCharacterFoleySynthFileDebug(bool debug, int[] models)
	{
		if (Global.BaseCharacter == null)
		{
			return;
		}
		CharacterAkComponent component = Global.BaseCharacter.CharacterActorComponent.Entity.GetComponent<CharacterAkComponent>();
		if (component == null)
		{
			return;
		}
		if (models.Length != 0)
		{
			component.SetFoleySynthFileDebug(debug, models);
			return;
		}
		component.SetDebug(debug);
	}

	// Token: 0x060192D8 RID: 103128 RVA: 0x0072E414 File Offset: 0x0072C614
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterAkComponent characterAkComponent = (CharacterAkComponent)componentTemplate;
		if (base.CanResetComponentProperty("CreatureData"))
		{
			if (characterAkComponent.CreatureData == null)
			{
				this.CreatureData = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureData), "CreatureData"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterAkComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (characterAkComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (characterAkComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsFirstGet"))
		{
			this.IsFirstGet = characterAkComponent.IsFirstGet;
		}
		if (base.CanResetComponentProperty("IsRole"))
		{
			this.IsRole = characterAkComponent.IsRole;
		}
		if (base.CanResetComponentProperty("IsP1"))
		{
			this.IsP1 = characterAkComponent.IsP1;
		}
		if (base.CanResetComponentProperty("AkComponentConfig"))
		{
			this.AkComponentConfig = characterAkComponent.AkComponentConfig;
		}
		if (base.CanResetComponentProperty("FoleySynthAllConfig") && characterAkComponent.FoleySynthAllConfig != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<FoleySynthAllConfig>(this.FoleySynthAllConfig), "FoleySynthAllConfig"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("Debug"))
		{
			this.Debug = characterAkComponent.Debug;
		}
		if (base.CanResetComponentProperty("WaterDepth"))
		{
			this.WaterDepth = characterAkComponent.WaterDepth;
		}
		if (base.CanResetComponentProperty("FoleySynthController"))
		{
			if (characterAkComponent.FoleySynthController == null)
			{
				this.FoleySynthController = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<FoleySynthController>(this.FoleySynthController), "FoleySynthController"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DynamicConditionProxy"))
		{
			if (characterAkComponent.DynamicConditionProxy == null)
			{
				this.DynamicConditionProxy = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AkComponentDynamicConditionProxy>(this.DynamicConditionProxy), "DynamicConditionProxy"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("FootSwitch"))
		{
			this.FootSwitch = characterAkComponent.FootSwitch;
		}
		if (base.CanResetComponentProperty("LastUpdateEnvironmentAudioTime"))
		{
			this.LastUpdateEnvironmentAudioTime = characterAkComponent.LastUpdateEnvironmentAudioTime;
		}
		if (base.CanResetComponentProperty("LastUpdateEnvironmentAudioLocation") && characterAkComponent.LastUpdateEnvironmentAudioLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.LastUpdateEnvironmentAudioLocation), "LastUpdateEnvironmentAudioLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("AudioResult"))
		{
			if (characterAkComponent.AudioResult == null)
			{
				this.AudioResult = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PlayResult>(this.AudioResult), "AudioResult"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060192DA RID: 103130 RVA: 0x0072E700 File Offset: 0x0072C900
	// Note: this type is marked as 'beforefieldinit'.
	static CharacterAkComponent()
	{
		Dictionary<EEntityType, string> dictionary = new Dictionary<EEntityType, string>();
		dictionary[EEntityType.Animal] = "entity_type_volume_control_animal";
		dictionary[EEntityType.Custom] = "entity_type_volume_control_custom_other";
		dictionary[EEntityType.Monster] = "entity_type_volume_control_monster";
		dictionary[EEntityType.Npc] = "entity_type_volume_control_npc";
		dictionary[EEntityType.Player] = "entity_type_volume_control_player_role";
		dictionary[EEntityType.SceneItem] = "entity_type_volume_control_scene_item";
		dictionary[EEntityType.Vision] = "entity_type_volume_control_vision";
		CharacterAkComponent.AUDIO_ENTITY_TYPE_VOLUME_CONTROL = dictionary;
	}

	// Token: 0x0400C5A1 RID: 50593
	private const int DEBUG_RADIUS = 15;

	// Token: 0x0400C5A2 RID: 50594
	private const int DEBUG_SEG = 12;

	// Token: 0x0400C5A3 RID: 50595
	public const string ROLE_MOVE_GROUP = "role_move";

	// Token: 0x0400C5A4 RID: 50596
	private const int ENVIRONMENT_AUDIO_UPDATE_INTERVAL = 500;

	// Token: 0x0400C5A5 RID: 50597
	private const int ENVIRONMENT_AUDIO_UPDATE_DIST_SQUARED = 4;

	// Token: 0x0400C5A6 RID: 50598
	[StaticVariableRuleIgnore]
	private static readonly Dictionary<EEntityType, string> AUDIO_ENTITY_TYPE_VOLUME_CONTROL;

	// Token: 0x0400C5A7 RID: 50599
	[Nullable(2)]
	private CreatureDataComponent CreatureData;

	// Token: 0x0400C5A8 RID: 50600
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400C5A9 RID: 50601
	[Nullable(2)]
	private BaseMoveComponent MoveComp;

	// Token: 0x0400C5AA RID: 50602
	[Nullable(2)]
	private BaseTagComponent TagComp;

	// Token: 0x0400C5AB RID: 50603
	private bool IsFirstGet;

	// Token: 0x0400C5AC RID: 50604
	public bool IsRole;

	// Token: 0x0400C5AD RID: 50605
	public bool IsP1;

	// Token: 0x0400C5AE RID: 50606
	public EntityAudioConfig? AkComponentConfig;

	// Token: 0x0400C5AF RID: 50607
	[Nullable(2)]
	private readonly FoleySynthAllConfig FoleySynthAllConfig;

	// Token: 0x0400C5B0 RID: 50608
	private bool Debug;

	// Token: 0x0400C5B1 RID: 50609
	public double WaterDepth;

	// Token: 0x0400C5B2 RID: 50610
	[Nullable(2)]
	private FoleySynthController FoleySynthController;

	// Token: 0x0400C5B3 RID: 50611
	public AkComponentDynamicConditionProxy DynamicConditionProxy;

	// Token: 0x0400C5B4 RID: 50612
	public string FootSwitch = "";

	// Token: 0x0400C5B5 RID: 50613
	private double LastUpdateEnvironmentAudioTime;

	// Token: 0x0400C5B6 RID: 50614
	private readonly global::Vector LastUpdateEnvironmentAudioLocation = global::Vector.Create();

	// Token: 0x0400C5B7 RID: 50615
	private PlayResult AudioResult;
}
