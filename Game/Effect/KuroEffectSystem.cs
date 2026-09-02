using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Data.Common.Struct;
using AkiClient.Game.Aki.Data.Entity.Struct;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Audio;
using CSharpScript.Game.World.Define;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.Effect
{
	// Token: 0x0200704F RID: 28751
	[NullableContext(1)]
	[Nullable(0)]
	public class KuroEffectSystem
	{
		// Token: 0x06045993 RID: 285075 RVA: 0x0122ED14 File Offset: 0x0122CF14
		public bool Initialize()
		{
			if (Singleton<Info>.Instance.IsGameRunning())
			{
				UKuroTimerSystemFunctionLibrary.Initialize(GlobalData.GameInstance);
			}
			this.EffectHandleMap.Clear();
			if (!this.InitFEffectSystem(false, false))
			{
				return false;
			}
			this.HasInitialize = true;
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.TriggerUiTimeDilation;
			Action handle;
			if ((handle = KuroEffectSystem.<>O.<0>__OnTimeScaleChange) == null)
			{
				handle = (KuroEffectSystem.<>O.<0>__OnTimeScaleChange = new Action(KuroEffectSystem.OnTimeScaleChange));
			}
			instance.Add(name, handle);
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.SetNiagaraQuality;
			Action handle2;
			if ((handle2 = KuroEffectSystem.<>O.<1>__OnSetNiagaraQuality) == null)
			{
				handle2 = (KuroEffectSystem.<>O.<1>__OnSetNiagaraQuality = new Action(KuroEffectSystem.OnSetNiagaraQuality));
			}
			instance2.Add(name2, handle2);
			EventSystem instance3 = Singleton<EventSystem>.Instance;
			EEventName name3 = EEventName.AfterGameSettingsAppliedOnOpenLoading;
			Action handle3;
			if ((handle3 = KuroEffectSystem.<>O.<1>__OnSetNiagaraQuality) == null)
			{
				handle3 = (KuroEffectSystem.<>O.<1>__OnSetNiagaraQuality = new Action(KuroEffectSystem.OnSetNiagaraQuality));
			}
			instance3.Add(name3, handle3);
			EventSystem instance4 = Singleton<EventSystem>.Instance;
			EEventName name4 = EEventName.OnGlobalUiSceneStateChanged;
			Action<EKuroUI3DState> handle4;
			if ((handle4 = KuroEffectSystem.<>O.<2>__OnGlobalUiSceneStateChanged) == null)
			{
				handle4 = (KuroEffectSystem.<>O.<2>__OnGlobalUiSceneStateChanged = new Action<EKuroUI3DState>(KuroEffectSystem.OnGlobalUiSceneStateChanged));
			}
			instance4.Add<EKuroUI3DState>(name4, handle4);
			EventSystem instance5 = Singleton<EventSystem>.Instance;
			EEventName name5 = EEventName.OnSetGamePaused;
			Action<bool> handle5;
			if ((handle5 = KuroEffectSystem.<>O.<3>__OnSetGamePaused) == null)
			{
				handle5 = (KuroEffectSystem.<>O.<3>__OnSetGamePaused = new Action<bool>(KuroEffectSystem.OnSetGamePaused));
			}
			instance5.Add<bool>(name5, handle5);
			Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnFormationLoaded));
			return true;
		}

		// Token: 0x06045994 RID: 285076 RVA: 0x0122EE48 File Offset: 0x0122D048
		private bool InitFEffectSystem(bool withEditor = false, bool refresh = false)
		{
			UKuroResourceSystemFunctionLibrary.Initialize(GlobalData.World, 1f);
			if (!withEditor)
			{
				this.CreateEffectSpecMappingWithDb();
			}
			bool flag = !withEditor || refresh || !UKuroEffectSystemFunctionLibrary.HasEffectForSpecData();
			TArray<FKuroEffectSpecData> specDataArray = new TArray<FKuroEffectSpecData>();
			TArray<FKuroEffectSpecChildData> specChildDataArray = new TArray<FKuroEffectSpecChildData>();
			if (flag)
			{
				this.CreateEffectSpecMappingWithJson(withEditor);
				this.UpdateFEffectSystemSpecConfig(specDataArray, specChildDataArray, withEditor);
			}
			this.EffectForSpecArray.Clear();
			this.EffectForSpecDbCacheArray.Clear();
			if (!UKuroEffectSystemFunctionLibrary.Initialize(GlobalData.GameInstance, specDataArray, specChildDataArray, Singleton<Info>.Instance.IsGameRunning(), 0.1f, 0.3f, 0.3f, true, BP_EffectPreview_C.StaticClass(), flag))
			{
				return false;
			}
			UKuroEffectSystemFunctionLibrary.InitStaticGlobalData(Singleton<EffectEnvironment>.Instance.UseLog, Singleton<Info>.Instance.IsInEditorTick(), Singleton<PublicUtil>.Instance.UseDbConfig());
			FSkeletalMeshSpecOnBodyEffectChangeRetVal fskeletalMeshSpecOnBodyEffectChangeRetVal = new FSkeletalMeshSpecOnBodyEffectChangeRetVal();
			FSkeletalMeshSpecOnBodyEffectChangeRetVal fskeletalMeshSpecOnBodyEffectChangeRetVal2 = fskeletalMeshSpecOnBodyEffectChangeRetVal;
			Func<float, UActorComponent, USkeletalMeshComponent, AActor, UActorComponent> callback;
			if ((callback = KuroEffectSystem.<>O.<4>__SkeletalMeshSpecOnBodyEffectChange) == null)
			{
				callback = (KuroEffectSystem.<>O.<4>__SkeletalMeshSpecOnBodyEffectChange = new Func<float, UActorComponent, USkeletalMeshComponent, AActor, UActorComponent>(KuroEffectSystem.SkeletalMeshSpecOnBodyEffectChange));
			}
			fskeletalMeshSpecOnBodyEffectChangeRetVal2.Bind(callback);
			FSkeletalMeshSpecCreateRenderCompRetVal fskeletalMeshSpecCreateRenderCompRetVal = new FSkeletalMeshSpecCreateRenderCompRetVal();
			FSkeletalMeshSpecCreateRenderCompRetVal fskeletalMeshSpecCreateRenderCompRetVal2 = fskeletalMeshSpecCreateRenderCompRetVal;
			Func<UActorComponent, USkeletalMeshComponent, AActor, UActorComponent> callback2;
			if ((callback2 = KuroEffectSystem.<>O.<5>__SkeletalMeshSpecCreateRenderingComponent) == null)
			{
				callback2 = (KuroEffectSystem.<>O.<5>__SkeletalMeshSpecCreateRenderingComponent = new Func<UActorComponent, USkeletalMeshComponent, AActor, UActorComponent>(KuroEffectSystem.SkeletalMeshSpecCreateRenderingComponent));
			}
			fskeletalMeshSpecCreateRenderCompRetVal2.Bind(callback2);
			FSkeletalMeshSpecDestroyRenderingComponent fskeletalMeshSpecDestroyRenderingComponent = new FSkeletalMeshSpecDestroyRenderingComponent();
			FSkeletalMeshSpecDestroyRenderingComponent fskeletalMeshSpecDestroyRenderingComponent2 = fskeletalMeshSpecDestroyRenderingComponent;
			Action<AActor, UActorComponent> callback3;
			if ((callback3 = KuroEffectSystem.<>O.<6>__SkeletalMeshSpecDestroyRenderingComponent) == null)
			{
				callback3 = (KuroEffectSystem.<>O.<6>__SkeletalMeshSpecDestroyRenderingComponent = new Action<AActor, UActorComponent>(KuroEffectSystem.SkeletalMeshSpecDestroyRenderingComponent));
			}
			fskeletalMeshSpecDestroyRenderingComponent2.Bind(callback3);
			FEffectHandleGetEntityOwnerActorRetVal feffectHandleGetEntityOwnerActorRetVal = new FEffectHandleGetEntityOwnerActorRetVal();
			FEffectHandleGetEntityOwnerActorRetVal feffectHandleGetEntityOwnerActorRetVal2 = feffectHandleGetEntityOwnerActorRetVal;
			Func<int, AActor> callback4;
			if ((callback4 = KuroEffectSystem.<>O.<7>__EffectHandleGetEntityOwnerActor) == null)
			{
				callback4 = (KuroEffectSystem.<>O.<7>__EffectHandleGetEntityOwnerActor = new Func<int, AActor>(KuroEffectSystem.EffectHandleGetEntityOwnerActor));
			}
			feffectHandleGetEntityOwnerActorRetVal2.Bind(callback4);
			FEffectHandleGetEntityModelConfigIdRetVal feffectHandleGetEntityModelConfigIdRetVal = new FEffectHandleGetEntityModelConfigIdRetVal();
			FEffectHandleGetEntityModelConfigIdRetVal feffectHandleGetEntityModelConfigIdRetVal2 = feffectHandleGetEntityModelConfigIdRetVal;
			Func<int, int> callback5;
			if ((callback5 = KuroEffectSystem.<>O.<8>__EffectHandleGetEntityModelConfigId) == null)
			{
				callback5 = (KuroEffectSystem.<>O.<8>__EffectHandleGetEntityModelConfigId = new Func<int, int>(KuroEffectSystem.EffectHandleGetEntityModelConfigId));
			}
			feffectHandleGetEntityModelConfigIdRetVal2.Bind(callback5);
			FEffectHandleGetOrAddEffectDynamicGroupRetVal feffectHandleGetOrAddEffectDynamicGroupRetVal = new FEffectHandleGetOrAddEffectDynamicGroupRetVal();
			FEffectHandleGetOrAddEffectDynamicGroupRetVal feffectHandleGetOrAddEffectDynamicGroupRetVal2 = feffectHandleGetOrAddEffectDynamicGroupRetVal;
			Func<float, FName> callback6;
			if ((callback6 = KuroEffectSystem.<>O.<9>__EffectHandleGetOrAddEffectDynamicGroup) == null)
			{
				callback6 = (KuroEffectSystem.<>O.<9>__EffectHandleGetOrAddEffectDynamicGroup = new Func<float, FName>(KuroEffectSystem.EffectHandleGetOrAddEffectDynamicGroup));
			}
			feffectHandleGetOrAddEffectDynamicGroupRetVal2.Bind(callback6);
			FAudioSystemGetAkComponentRetVal faudioSystemGetAkComponentRetVal = new FAudioSystemGetAkComponentRetVal();
			FAudioSystemGetAkComponentRetVal faudioSystemGetAkComponentRetVal2 = faudioSystemGetAkComponentRetVal;
			Func<bool, AActor, UAkComponent> callback7;
			if ((callback7 = KuroEffectSystem.<>O.<10>__AudioSystemGetAkComponent) == null)
			{
				callback7 = (KuroEffectSystem.<>O.<10>__AudioSystemGetAkComponent = new Func<bool, AActor, UAkComponent>(KuroEffectSystem.AudioSystemGetAkComponent));
			}
			faudioSystemGetAkComponentRetVal2.Bind(callback7);
			FAudioSystemExecuteActionStop faudioSystemExecuteActionStop = new FAudioSystemExecuteActionStop();
			FAudioSystemExecuteActionStop faudioSystemExecuteActionStop2 = faudioSystemExecuteActionStop;
			Action<int, float> callback8;
			if ((callback8 = KuroEffectSystem.<>O.<11>__AudioSystemExecuteActionStop) == null)
			{
				callback8 = (KuroEffectSystem.<>O.<11>__AudioSystemExecuteActionStop = new Action<int, float>(KuroEffectSystem.AudioSystemExecuteActionStop));
			}
			faudioSystemExecuteActionStop2.Bind(callback8);
			FAudioSystemPostEventTransformRetVal faudioSystemPostEventTransformRetVal = new FAudioSystemPostEventTransformRetVal();
			FAudioSystemPostEventTransformRetVal faudioSystemPostEventTransformRetVal2 = faudioSystemPostEventTransformRetVal;
			Func<string, FTransformDouble, int> callback9;
			if ((callback9 = KuroEffectSystem.<>O.<12>__AudioSystemPostEventTransform) == null)
			{
				callback9 = (KuroEffectSystem.<>O.<12>__AudioSystemPostEventTransform = new Func<string, FTransformDouble, int>(KuroEffectSystem.AudioSystemPostEventTransform));
			}
			faudioSystemPostEventTransformRetVal2.Bind(callback9);
			FAudioSystemPostEventAkComponentRetVal faudioSystemPostEventAkComponentRetVal = new FAudioSystemPostEventAkComponentRetVal();
			FAudioSystemPostEventAkComponentRetVal faudioSystemPostEventAkComponentRetVal2 = faudioSystemPostEventAkComponentRetVal;
			Func<string, UAkComponent, int> callback10;
			if ((callback10 = KuroEffectSystem.<>O.<13>__AudioSystemPostEventAkComponent) == null)
			{
				callback10 = (KuroEffectSystem.<>O.<13>__AudioSystemPostEventAkComponent = new Func<string, UAkComponent, int>(KuroEffectSystem.AudioSystemPostEventAkComponent));
			}
			faudioSystemPostEventAkComponentRetVal2.Bind(callback10);
			FNiagaraSpecIsNeedQualityBiasRetVal fniagaraSpecIsNeedQualityBiasRetVal = new FNiagaraSpecIsNeedQualityBiasRetVal();
			FNiagaraSpecIsNeedQualityBiasRetVal fniagaraSpecIsNeedQualityBiasRetVal2 = fniagaraSpecIsNeedQualityBiasRetVal;
			Func<int, bool> callback11;
			if ((callback11 = KuroEffectSystem.<>O.<14>__NiagaraSpecIsNeedQualityBias) == null)
			{
				callback11 = (KuroEffectSystem.<>O.<14>__NiagaraSpecIsNeedQualityBias = new Func<int, bool>(KuroEffectSystem.NiagaraSpecIsNeedQualityBias));
			}
			fniagaraSpecIsNeedQualityBiasRetVal2.Bind(callback11);
			FPostProcessSpecIsNeedPostEffectRetVal fpostProcessSpecIsNeedPostEffectRetVal = new FPostProcessSpecIsNeedPostEffectRetVal();
			FPostProcessSpecIsNeedPostEffectRetVal fpostProcessSpecIsNeedPostEffectRetVal2 = fpostProcessSpecIsNeedPostEffectRetVal;
			Func<int, bool, bool> callback12;
			if ((callback12 = KuroEffectSystem.<>O.<15>__PostProcessSpecIsNeedPostEffect) == null)
			{
				callback12 = (KuroEffectSystem.<>O.<15>__PostProcessSpecIsNeedPostEffect = new Func<int, bool, bool>(KuroEffectSystem.PostProcessSpecIsNeedPostEffect));
			}
			fpostProcessSpecIsNeedPostEffectRetVal2.Bind(callback12);
			FPostProcessSpecIsDisableInUltraSkillRetVal fpostProcessSpecIsDisableInUltraSkillRetVal = new FPostProcessSpecIsDisableInUltraSkillRetVal();
			FPostProcessSpecIsDisableInUltraSkillRetVal fpostProcessSpecIsDisableInUltraSkillRetVal2 = fpostProcessSpecIsDisableInUltraSkillRetVal;
			Func<int, bool> callback13;
			if ((callback13 = KuroEffectSystem.<>O.<16>__PostProcessSpecIsDisableInUltraSkill) == null)
			{
				callback13 = (KuroEffectSystem.<>O.<16>__PostProcessSpecIsDisableInUltraSkill = new Func<int, bool>(KuroEffectSystem.PostProcessSpecIsDisableInUltraSkill));
			}
			fpostProcessSpecIsDisableInUltraSkillRetVal2.Bind(callback13);
			FActorSystemGetRetVal factorSystemGetRetVal = new FActorSystemGetRetVal();
			FActorSystemGetRetVal factorSystemGetRetVal2 = factorSystemGetRetVal;
			FActorSystemGetRetVal.FActorSystemGetRetVal_ScriptDelegate callback14;
			if ((callback14 = KuroEffectSystem.<>O.<17>__ActorSystemGet) == null)
			{
				callback14 = (KuroEffectSystem.<>O.<17>__ActorSystemGet = new FActorSystemGetRetVal.FActorSystemGetRetVal_ScriptDelegate(KuroEffectSystem.ActorSystemGet));
			}
			factorSystemGetRetVal2.Bind(callback14);
			FActorSystemPutRetVal factorSystemPutRetVal = new FActorSystemPutRetVal();
			FActorSystemPutRetVal factorSystemPutRetVal2 = factorSystemPutRetVal;
			Func<string, AActor, bool> callback15;
			if ((callback15 = KuroEffectSystem.<>O.<18>__ActorSystemPut) == null)
			{
				callback15 = (KuroEffectSystem.<>O.<18>__ActorSystemPut = new Func<string, AActor, bool>(KuroEffectSystem.ActorSystemPut));
			}
			factorSystemPutRetVal2.Bind(callback15);
			FEffectSystemSetEffectView feffectSystemSetEffectView = new FEffectSystemSetEffectView();
			FEffectSystemSetEffectView feffectSystemSetEffectView2 = feffectSystemSetEffectView;
			Action<AActor, int> callback16;
			if ((callback16 = KuroEffectSystem.<>O.<19>__EffectSystemSetEffectView) == null)
			{
				callback16 = (KuroEffectSystem.<>O.<19>__EffectSystemSetEffectView = new Action<AActor, int>(KuroEffectSystem.EffectSystemSetEffectView));
			}
			feffectSystemSetEffectView2.Bind(callback16);
			FEffectSystemCheckIsNetPlayerRetVal feffectSystemCheckIsNetPlayerRetVal = new FEffectSystemCheckIsNetPlayerRetVal();
			FEffectSystemCheckIsNetPlayerRetVal feffectSystemCheckIsNetPlayerRetVal2 = feffectSystemCheckIsNetPlayerRetVal;
			Func<int, bool> callback17;
			if ((callback17 = KuroEffectSystem.<>O.<20>__EffectSystemCheckIsNetPlayer) == null)
			{
				callback17 = (KuroEffectSystem.<>O.<20>__EffectSystemCheckIsNetPlayer = new Func<int, bool>(KuroEffectSystem.EffectSystemCheckIsNetPlayer));
			}
			feffectSystemCheckIsNetPlayerRetVal2.Bind(callback17);
			FEffectSystemCheckMobileBlackEffectRetVal feffectSystemCheckMobileBlackEffectRetVal = new FEffectSystemCheckMobileBlackEffectRetVal();
			FEffectSystemCheckMobileBlackEffectRetVal feffectSystemCheckMobileBlackEffectRetVal2 = feffectSystemCheckMobileBlackEffectRetVal;
			Func<string, bool> callback18;
			if ((callback18 = KuroEffectSystem.<>O.<21>__EffectSystemCheckMobileBlackEffect) == null)
			{
				callback18 = (KuroEffectSystem.<>O.<21>__EffectSystemCheckMobileBlackEffect = new Func<string, bool>(KuroEffectSystem.EffectSystemCheckMobileBlackEffect));
			}
			feffectSystemCheckMobileBlackEffectRetVal2.Bind(callback18);
			FEffectSpecRegisterBodyEffect feffectSpecRegisterBodyEffect = new FEffectSpecRegisterBodyEffect();
			FEffectSpecRegisterBodyEffect feffectSpecRegisterBodyEffect2 = feffectSpecRegisterBodyEffect;
			Action<int, AActor, USkeletalMeshComponent, UObject, UEffectModelBase> callback19;
			if ((callback19 = KuroEffectSystem.<>O.<22>__EffectSpecRegisterBodyEffect) == null)
			{
				callback19 = (KuroEffectSystem.<>O.<22>__EffectSpecRegisterBodyEffect = new Action<int, AActor, USkeletalMeshComponent, UObject, UEffectModelBase>(KuroEffectSystem.EffectSpecRegisterBodyEffect));
			}
			feffectSpecRegisterBodyEffect2.Bind(callback19);
			FEffectSpecUnregisterBodyEffect feffectSpecUnregisterBodyEffect = new FEffectSpecUnregisterBodyEffect();
			FEffectSpecUnregisterBodyEffect feffectSpecUnregisterBodyEffect2 = feffectSpecUnregisterBodyEffect;
			Action<int, AActor, USkeletalMeshComponent, UObject, UEffectModelBase> callback20;
			if ((callback20 = KuroEffectSystem.<>O.<23>__EffectSpecUnregisterBodyEffect) == null)
			{
				callback20 = (KuroEffectSystem.<>O.<23>__EffectSpecUnregisterBodyEffect = new Action<int, AActor, USkeletalMeshComponent, UObject, UEffectModelBase>(KuroEffectSystem.EffectSpecUnregisterBodyEffect));
			}
			feffectSpecUnregisterBodyEffect2.Bind(callback20);
			FMaterialSpecGetRenderingComponentByContextRetVal fmaterialSpecGetRenderingComponentByContextRetVal = new FMaterialSpecGetRenderingComponentByContextRetVal();
			FMaterialSpecGetRenderingComponentByContextRetVal fmaterialSpecGetRenderingComponentByContextRetVal2 = fmaterialSpecGetRenderingComponentByContextRetVal;
			Func<int, UObject, UKuroCharRenderingComponent> callback21;
			if ((callback21 = KuroEffectSystem.<>O.<24>__MaterialSpecGetRenderingComponentByContext) == null)
			{
				callback21 = (KuroEffectSystem.<>O.<24>__MaterialSpecGetRenderingComponentByContext = new Func<int, UObject, UKuroCharRenderingComponent>(KuroEffectSystem.MaterialSpecGetRenderingComponentByContext));
			}
			fmaterialSpecGetRenderingComponentByContextRetVal2.Bind(callback21);
			FMaterialSpecGetRenderingComponentBySkeletalRetVal fmaterialSpecGetRenderingComponentBySkeletalRetVal = new FMaterialSpecGetRenderingComponentBySkeletalRetVal();
			FMaterialSpecGetRenderingComponentBySkeletalRetVal fmaterialSpecGetRenderingComponentBySkeletalRetVal2 = fmaterialSpecGetRenderingComponentBySkeletalRetVal;
			Func<USkeletalMeshComponent, UKuroCharRenderingComponent> callback22;
			if ((callback22 = KuroEffectSystem.<>O.<25>__MaterialSpecGetRenderingComponentBySkeletal) == null)
			{
				callback22 = (KuroEffectSystem.<>O.<25>__MaterialSpecGetRenderingComponentBySkeletal = new Func<USkeletalMeshComponent, UKuroCharRenderingComponent>(KuroEffectSystem.MaterialSpecGetRenderingComponentBySkeletal));
			}
			fmaterialSpecGetRenderingComponentBySkeletalRetVal2.Bind(callback22);
			FMaterialSpecSpawnRenderActorRetVal fmaterialSpecSpawnRenderActorRetVal = new FMaterialSpecSpawnRenderActorRetVal();
			FMaterialSpecSpawnRenderActorRetVal fmaterialSpecSpawnRenderActorRetVal2 = fmaterialSpecSpawnRenderActorRetVal;
			Func<USkeletalMeshComponent, AActor> callback23;
			if ((callback23 = KuroEffectSystem.<>O.<26>__MaterialSpecSpawnRenderActor) == null)
			{
				callback23 = (KuroEffectSystem.<>O.<26>__MaterialSpecSpawnRenderActor = new Func<USkeletalMeshComponent, AActor>(KuroEffectSystem.MaterialSpecSpawnRenderActor));
			}
			fmaterialSpecSpawnRenderActorRetVal2.Bind(callback23);
			FMaterialSpecGetRenderingComponentByRenderActorRetVal fmaterialSpecGetRenderingComponentByRenderActorRetVal = new FMaterialSpecGetRenderingComponentByRenderActorRetVal();
			FMaterialSpecGetRenderingComponentByRenderActorRetVal fmaterialSpecGetRenderingComponentByRenderActorRetVal2 = fmaterialSpecGetRenderingComponentByRenderActorRetVal;
			Func<AActor, USkeletalMeshComponent, UKuroCharRenderingComponent> callback24;
			if ((callback24 = KuroEffectSystem.<>O.<27>__MaterialSpecGetRenderingComponentByRenderActor) == null)
			{
				callback24 = (KuroEffectSystem.<>O.<27>__MaterialSpecGetRenderingComponentByRenderActor = new Func<AActor, USkeletalMeshComponent, UKuroCharRenderingComponent>(KuroEffectSystem.MaterialSpecGetRenderingComponentByRenderActor));
			}
			fmaterialSpecGetRenderingComponentByRenderActorRetVal2.Bind(callback24);
			FMaterialSpecAddMaterialControllerDataRetVal fmaterialSpecAddMaterialControllerDataRetVal = new FMaterialSpecAddMaterialControllerDataRetVal();
			FMaterialSpecAddMaterialControllerDataRetVal fmaterialSpecAddMaterialControllerDataRetVal2 = fmaterialSpecAddMaterialControllerDataRetVal;
			Func<UKuroCharRenderingComponent, UKuroMaterialControllerDataAsset, int> callback25;
			if ((callback25 = KuroEffectSystem.<>O.<28>__MaterialSpecAddMaterialControllerData) == null)
			{
				callback25 = (KuroEffectSystem.<>O.<28>__MaterialSpecAddMaterialControllerData = new Func<UKuroCharRenderingComponent, UKuroMaterialControllerDataAsset, int>(KuroEffectSystem.MaterialSpecAddMaterialControllerData));
			}
			fmaterialSpecAddMaterialControllerDataRetVal2.Bind(callback25);
			FMaterialSpecRemoveMaterialControllerData fmaterialSpecRemoveMaterialControllerData = new FMaterialSpecRemoveMaterialControllerData();
			FMaterialSpecRemoveMaterialControllerData fmaterialSpecRemoveMaterialControllerData2 = fmaterialSpecRemoveMaterialControllerData;
			Action<UKuroCharRenderingComponent, int> callback26;
			if ((callback26 = KuroEffectSystem.<>O.<29>__MaterialSpecRemoveMaterialControllerData) == null)
			{
				callback26 = (KuroEffectSystem.<>O.<29>__MaterialSpecRemoveMaterialControllerData = new Action<UKuroCharRenderingComponent, int>(KuroEffectSystem.MaterialSpecRemoveMaterialControllerData));
			}
			fmaterialSpecRemoveMaterialControllerData2.Bind(callback26);
			FMaterialSpecDestroyRenderingComponent fmaterialSpecDestroyRenderingComponent = new FMaterialSpecDestroyRenderingComponent();
			FMaterialSpecDestroyRenderingComponent fmaterialSpecDestroyRenderingComponent2 = fmaterialSpecDestroyRenderingComponent;
			Action<UKuroCharRenderingComponent> callback27;
			if ((callback27 = KuroEffectSystem.<>O.<30>__MaterialSpecDestroyRenderingComponent) == null)
			{
				callback27 = (KuroEffectSystem.<>O.<30>__MaterialSpecDestroyRenderingComponent = new Action<UKuroCharRenderingComponent>(KuroEffectSystem.MaterialSpecDestroyRenderingComponent));
			}
			fmaterialSpecDestroyRenderingComponent2.Bind(callback27);
			FEffectAudioControllerAddPlayEffectAudioRetVal feffectAudioControllerAddPlayEffectAudioRetVal = new FEffectAudioControllerAddPlayEffectAudioRetVal();
			FEffectAudioControllerAddPlayEffectAudioRetVal feffectAudioControllerAddPlayEffectAudioRetVal2 = feffectAudioControllerAddPlayEffectAudioRetVal;
			Func<UEffectModelAudio, AActor, int, int> callback28;
			if ((callback28 = KuroEffectSystem.<>O.<31>__EffectAudioControllerAddPlayEffectAudio) == null)
			{
				callback28 = (KuroEffectSystem.<>O.<31>__EffectAudioControllerAddPlayEffectAudio = new Func<UEffectModelAudio, AActor, int, int>(KuroEffectSystem.EffectAudioControllerAddPlayEffectAudio));
			}
			feffectAudioControllerAddPlayEffectAudioRetVal2.Bind(callback28);
			FEffectAudioControllerAddPlayEffectAudioPriorityRetVal feffectAudioControllerAddPlayEffectAudioPriorityRetVal = new FEffectAudioControllerAddPlayEffectAudioPriorityRetVal();
			FEffectAudioControllerAddPlayEffectAudioPriorityRetVal feffectAudioControllerAddPlayEffectAudioPriorityRetVal2 = feffectAudioControllerAddPlayEffectAudioPriorityRetVal;
			Func<UEffectModelAudio, AActor, int, int, int> callback29;
			if ((callback29 = KuroEffectSystem.<>O.<32>__EffectAudioControllerAddPlayEffectAudioPriority) == null)
			{
				callback29 = (KuroEffectSystem.<>O.<32>__EffectAudioControllerAddPlayEffectAudioPriority = new Func<UEffectModelAudio, AActor, int, int, int>(KuroEffectSystem.EffectAudioControllerAddPlayEffectAudioPriority));
			}
			feffectAudioControllerAddPlayEffectAudioPriorityRetVal2.Bind(callback29);
			FEffectAudioControllerOnStopEffectAudio feffectAudioControllerOnStopEffectAudio = new FEffectAudioControllerOnStopEffectAudio();
			FEffectAudioControllerOnStopEffectAudio feffectAudioControllerOnStopEffectAudio2 = feffectAudioControllerOnStopEffectAudio;
			Action<int, string> callback30;
			if ((callback30 = KuroEffectSystem.<>O.<33>__EffectAudioControllerOnStopEffectAudio) == null)
			{
				callback30 = (KuroEffectSystem.<>O.<33>__EffectAudioControllerOnStopEffectAudio = new Action<int, string>(KuroEffectSystem.EffectAudioControllerOnStopEffectAudio));
			}
			feffectAudioControllerOnStopEffectAudio2.Bind(callback30);
			UKuroEffectSystemFunctionLibrary.RegisterJsFunction(fskeletalMeshSpecOnBodyEffectChangeRetVal, fskeletalMeshSpecCreateRenderCompRetVal, fskeletalMeshSpecDestroyRenderingComponent, feffectHandleGetEntityOwnerActorRetVal, feffectHandleGetEntityModelConfigIdRetVal, feffectHandleGetOrAddEffectDynamicGroupRetVal, faudioSystemGetAkComponentRetVal, faudioSystemExecuteActionStop, faudioSystemPostEventTransformRetVal, faudioSystemPostEventAkComponentRetVal, fniagaraSpecIsNeedQualityBiasRetVal, fpostProcessSpecIsNeedPostEffectRetVal, fpostProcessSpecIsDisableInUltraSkillRetVal, factorSystemGetRetVal, factorSystemPutRetVal, feffectSystemSetEffectView, feffectSystemCheckIsNetPlayerRetVal, feffectSystemCheckMobileBlackEffectRetVal, feffectSpecRegisterBodyEffect, feffectSpecUnregisterBodyEffect, fmaterialSpecGetRenderingComponentByContextRetVal, fmaterialSpecGetRenderingComponentBySkeletalRetVal, fmaterialSpecSpawnRenderActorRetVal, fmaterialSpecGetRenderingComponentByRenderActorRetVal, fmaterialSpecAddMaterialControllerDataRetVal, fmaterialSpecRemoveMaterialControllerData, fmaterialSpecDestroyRenderingComponent, feffectAudioControllerAddPlayEffectAudioRetVal, feffectAudioControllerAddPlayEffectAudioPriorityRetVal, feffectAudioControllerOnStopEffectAudio);
			return true;
		}

		// Token: 0x06045995 RID: 285077 RVA: 0x0122F418 File Offset: 0x0122D618
		public bool Clear()
		{
			this.HasInitialize = false;
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnFormationLoaded));
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.OnSetGamePaused;
			Action<bool> handle;
			if ((handle = KuroEffectSystem.<>O.<3>__OnSetGamePaused) == null)
			{
				handle = (KuroEffectSystem.<>O.<3>__OnSetGamePaused = new Action<bool>(KuroEffectSystem.OnSetGamePaused));
			}
			instance.Remove<bool>(name, handle);
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.OnGlobalUiSceneStateChanged;
			Action<EKuroUI3DState> handle2;
			if ((handle2 = KuroEffectSystem.<>O.<2>__OnGlobalUiSceneStateChanged) == null)
			{
				handle2 = (KuroEffectSystem.<>O.<2>__OnGlobalUiSceneStateChanged = new Action<EKuroUI3DState>(KuroEffectSystem.OnGlobalUiSceneStateChanged));
			}
			instance2.Remove<EKuroUI3DState>(name2, handle2);
			EventSystem instance3 = Singleton<EventSystem>.Instance;
			EEventName name3 = EEventName.AfterGameSettingsAppliedOnOpenLoading;
			Action handle3;
			if ((handle3 = KuroEffectSystem.<>O.<1>__OnSetNiagaraQuality) == null)
			{
				handle3 = (KuroEffectSystem.<>O.<1>__OnSetNiagaraQuality = new Action(KuroEffectSystem.OnSetNiagaraQuality));
			}
			instance3.Remove(name3, handle3);
			EventSystem instance4 = Singleton<EventSystem>.Instance;
			EEventName name4 = EEventName.SetNiagaraQuality;
			Action handle4;
			if ((handle4 = KuroEffectSystem.<>O.<1>__OnSetNiagaraQuality) == null)
			{
				handle4 = (KuroEffectSystem.<>O.<1>__OnSetNiagaraQuality = new Action(KuroEffectSystem.OnSetNiagaraQuality));
			}
			instance4.Remove(name4, handle4);
			EventSystem instance5 = Singleton<EventSystem>.Instance;
			EEventName name5 = EEventName.TriggerUiTimeDilation;
			Action handle5;
			if ((handle5 = KuroEffectSystem.<>O.<0>__OnTimeScaleChange) == null)
			{
				handle5 = (KuroEffectSystem.<>O.<0>__OnTimeScaleChange = new Action(KuroEffectSystem.OnTimeScaleChange));
			}
			instance5.Remove(name5, handle5);
			this.PreviewInitState = false;
			Singleton<EffectEnvironment>.Instance.GameTimeInSeconds = 0.0;
			foreach (KuroEffectHandle kuroEffectHandle in this.EffectHandleMap.Values)
			{
				kuroEffectHandle.Clear(false);
			}
			this.EffectHandleMap.Clear();
			UKuroEffectSystemFunctionLibrary.Clear();
			if (Singleton<Info>.Instance.IsGameRunning())
			{
				UKuroTimerSystemFunctionLibrary.Clear();
				UKuroResourceSystemFunctionLibrary.Clear();
			}
			return true;
		}

		// Token: 0x06045996 RID: 285078 RVA: 0x0122F5A8 File Offset: 0x0122D7A8
		public bool ClearPool()
		{
			UKuroEffectSystemFunctionLibrary.ClearPool(false);
			return true;
		}

		// Token: 0x06045997 RID: 285079 RVA: 0x0122F5B1 File Offset: 0x0122D7B1
		private static void OnGlobalUiSceneStateChanged(EKuroUI3DState state)
		{
			UKuroEffectSystemFunctionLibrary.OnUiSceneStateChange(state);
		}

		// Token: 0x06045998 RID: 285080 RVA: 0x0122F5B9 File Offset: 0x0122D7B9
		private static void OnSetGamePaused(bool paused)
		{
			UKuroEffectSystemFunctionLibrary.OnTickSystemPausedChange(paused);
		}

		// Token: 0x06045999 RID: 285081 RVA: 0x0122F5C4 File Offset: 0x0122D7C4
		private void OnFormationLoaded()
		{
			if (this.SceneTeamItems.Num() == 0)
			{
				this.SceneTeamItems.AddZeroed(4);
			}
			List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(false);
			for (int i = 0; i < 4; i++)
			{
				if (i < teamItems.Count)
				{
					SceneTeamItem sceneTeamItem = teamItems[i];
					EntityHandle entityHandle = sceneTeamItem.EntityHandle;
					if (sceneTeamItem.IsMyRole() && entityHandle != null)
					{
						this.SceneTeamItems[i] = new FKuroSceneTeamItem
						{
							EntityId = entityHandle.Id,
							IsMyRole = true
						};
					}
					else
					{
						this.SceneTeamItems[i] = default(FKuroSceneTeamItem);
					}
				}
			}
			UKuroEffectSystemFunctionLibrary.OnPlayerEffectContainerFormationLoaded(this.SceneTeamItems);
		}

		// Token: 0x0604599A RID: 285082 RVA: 0x0122F670 File Offset: 0x0122D870
		public bool InitializeWithPreview(bool refresh)
		{
			if (Singleton<Info>.Instance.IsGameRunning())
			{
				return true;
			}
			if (!refresh && this.PreviewInitState)
			{
				return true;
			}
			if (refresh && this.PreviewInitState && UKuroEffectSystemFunctionLibrary.HasInitialize())
			{
				this.CreateEffectSpecMappingWithJson(true);
				TArray<FKuroEffectSpecData> specDataArray = new TArray<FKuroEffectSpecData>();
				TArray<FKuroEffectSpecChildData> specChildDataArray = new TArray<FKuroEffectSpecChildData>();
				this.UpdateFEffectSystemSpecConfig(specDataArray, specChildDataArray, true);
				UKuroEffectSystemFunctionLibrary.RefreshEffectForSpecData(specDataArray, specChildDataArray, false);
				return true;
			}
			if (this.HasInitialize)
			{
				Singleton<Log>.Instance.Error(ELogModule.RenderEffect, ELogAuthor.WLJ, "[特效框架]InitializeWithPreview时 FEffectSystem还未Clear,非法", default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}
			this.PreviewInitState = true;
			return this.InitFEffectSystem(true, true);
		}

		// Token: 0x0604599B RID: 285083 RVA: 0x0122F708 File Offset: 0x0122D908
		private void CreateEffectSpecMappingWithDb()
		{
			if (!Singleton<PublicUtil>.Instance.UseDbConfig())
			{
				return;
			}
			this.EffectForSpecArray.Clear();
			this.EffectForSpecDbCacheArray.Clear();
			IReadOnlyList<EffectSpecData> configList = ConfigEffectSpecDataGetAll.GetConfigList(false);
			if (configList != null)
			{
				foreach (EffectSpecData item in configList)
				{
					this.EffectForSpecDbCacheArray.Add(item);
				}
			}
		}

		// Token: 0x0604599C RID: 285084 RVA: 0x0122F784 File Offset: 0x0122D984
		private unsafe void CreateEffectSpecMappingWithJson(bool withEditor = false)
		{
			if (!Singleton<Info>.Instance.IsPlayInEditor)
			{
				return;
			}
			if (!withEditor && Singleton<PublicUtil>.Instance.UseDbConfig())
			{
				return;
			}
			this.EffectForSpecArray.Clear();
			this.EffectForSpecDbCacheArray.Clear();
			string text = UKismetSystemLibrary.GetProjectDirectory() + "../Config/Client/EffectData/";
			if (!UBlueprintPathsLibrary.DirectoryExists(text))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.World;
				ELogAuthor author = ELogAuthor.LFJW;
				string message = "不存在EffectSpec配置文件目录";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", text);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			try
			{
				foreach (string text2 in UKuroStaticLibrary.LoadFilesRecursive(text, "*.json", true, false))
				{
					if (!string.IsNullOrEmpty(text2))
					{
						SpecData specData = Json.Decode<SpecData>(text2, null);
						if (specData != null)
						{
							this.EffectForSpecArray.Add(specData);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.RenderEffect;
				ELogAuthor author2 = ELogAuthor.LFJW;
				string message2 = "读取EffectSpec.json异常";
				Exception error = ex;
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", "KuroEffectSystem");
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
				instance2.ErrorWithStack(module2, author2, message2, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x0604599D RID: 285085 RVA: 0x0122F8DC File Offset: 0x0122DADC
		private void UpdateFEffectSystemSpecConfig(TArray<FKuroEffectSpecData> specDataArray, TArray<FKuroEffectSpecChildData> specChildDataArray, bool withEditor = false)
		{
			if (withEditor || !Singleton<PublicUtil>.Instance.UseDbConfig())
			{
				foreach (SpecData specData in this.EffectForSpecArray)
				{
					FKuroEffectSpecData value = new FKuroEffectSpecData
					{
						Id = specData.Id,
						SpecType = specData.SpecType,
						EffectRegularType = (byte)specData.EffectRegularType,
						LifeTime = specData.LifeTime
					};
					specDataArray.Add(value);
					if (specData.Children.Count > 0)
					{
						FKuroEffectSpecChildData fkuroEffectSpecChildData = new FKuroEffectSpecChildData();
						fkuroEffectSpecChildData.Id = specData.Id;
						foreach (int value2 in specData.Children)
						{
							fkuroEffectSpecChildData.Children.Add(value2);
						}
						specChildDataArray.Add(fkuroEffectSpecChildData);
					}
				}
				return;
			}
			foreach (EffectSpecData effectSpecData in this.EffectForSpecDbCacheArray)
			{
				FKuroEffectSpecData value3 = new FKuroEffectSpecData
				{
					Id = effectSpecData.Id,
					SpecType = (byte)effectSpecData.SpecType,
					EffectRegularType = (byte)effectSpecData.EffectRegularType,
					LifeTime = (float)effectSpecData.LifeTime
				};
				specDataArray.Add(value3);
				if (effectSpecData.ChildrenLength > 0)
				{
					FKuroEffectSpecChildData fkuroEffectSpecChildData2 = new FKuroEffectSpecChildData();
					fkuroEffectSpecChildData2.Id = effectSpecData.Id;
					foreach (int value4 in effectSpecData.ChildrenIter())
					{
						fkuroEffectSpecChildData2.Children.Add(value4);
					}
					specChildDataArray.Add(fkuroEffectSpecChildData2);
				}
			}
		}

		// Token: 0x0604599E RID: 285086 RVA: 0x0122FAEC File Offset: 0x0122DCEC
		public void Tick(float delta)
		{
			this.CheckEffectOwnerInterval -= delta;
			if (this.CheckEffectOwnerInterval < 0f)
			{
				this.CheckEffectOwnerInterval = 60000f;
				using (PoolArray<KuroEffectHandle> poolArray = this.EffectHandleMap.Values.ToPoolArray<KuroEffectHandle>())
				{
					foreach (KuroEffectHandle kuroEffectHandle in poolArray)
					{
						if (kuroEffectHandle.IsLoop && !kuroEffectHandle.CheckOwner())
						{
							this.StopEffectById(kuroEffectHandle.Id, "CheckOwner Failed", true, null);
						}
					}
				}
			}
		}

		// Token: 0x0604599F RID: 285087 RVA: 0x0122FBAC File Offset: 0x0122DDAC
		private static void OnTimeScaleChange()
		{
			UKuroEffectSystemFunctionLibrary.OnGlobalTimeScaleChange();
		}

		// Token: 0x060459A0 RID: 285088 RVA: 0x0122FBB4 File Offset: 0x0122DDB4
		private static void OpenNiagaraDownSampling()
		{
			Singleton<Log>.Instance.Info(ELogModule.RenderEffect, ELogAuthor.WLJ, "Open Niagara Down Sampling", default(ReadOnlySpan<ValueTuple<string, object>>));
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Kuro.Niagara.SystemSimulation.TickDeltaTime 0.033", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Kuro.Niagara.SystemSimulation.SpawnAlignment 0", null);
		}

		// Token: 0x060459A1 RID: 285089 RVA: 0x0122FC00 File Offset: 0x0122DE00
		private static void CloseNiagaraDownSampling()
		{
			Singleton<Log>.Instance.Info(ELogModule.RenderEffect, ELogAuthor.WLJ, "Close Niagara Down Sampling", default(ReadOnlySpan<ValueTuple<string, object>>));
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Kuro.Niagara.SystemSimulation.TickDeltaTime -1", null);
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Kuro.Niagara.SystemSimulation.SpawnAlignment 0", null);
		}

		// Token: 0x060459A2 RID: 285090 RVA: 0x0122FC4C File Offset: 0x0122DE4C
		private static void OnSetNiagaraQuality()
		{
			int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.NIAGARAQUALITY, true, true);
			if (currentValue == null)
			{
				return;
			}
			if (!Singleton<Info>.Instance.IsPcPlatform())
			{
				int? num = currentValue;
				int num2 = 2;
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					KuroEffectSystem.OpenNiagaraDownSampling();
					return;
				}
				KuroEffectSystem.CloseNiagaraDownSampling();
				return;
			}
			else
			{
				int? num = currentValue;
				int num2 = 1;
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					KuroEffectSystem.OpenNiagaraDownSampling();
					return;
				}
				KuroEffectSystem.CloseNiagaraDownSampling();
				return;
			}
		}

		// Token: 0x060459A3 RID: 285091 RVA: 0x0122FCC8 File Offset: 0x0122DEC8
		public int SpawnEffectWithActor(UObject worldContext, [Nullable(2)] AActor actor, string path, string reason, bool autoPlay = true, [Nullable(2)] EffectContext context = null, bool isExternalActor = true, EEffectType effectType = EEffectType.Scene)
		{
			FKuroEffectContext fkuroEffectContext = KuroEffectSystem.CreateFEffectContext(context);
			FKuroEffectContext fkuroEffectContext2 = fkuroEffectContext ?? new FKuroEffectContext();
			int num = UKuroEffectSystemFunctionLibrary.SpawnEffectWithActor(worldContext, actor, path, reason, fkuroEffectContext2, autoPlay, isExternalActor, (byte)effectType);
			if (!this.IsValid(num))
			{
				return 0;
			}
			if (this.EffectHandleMap.ContainsKey(num))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderEffect;
				ELogAuthor author = ELogAuthor.WLJ;
				string message = "[特效框架]SpawnEffectWithActor 生成了一个已经存在的effectId";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", num);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return 0;
			}
			KuroEffectHandle kuroEffectHandle = new KuroEffectHandle();
			kuroEffectHandle.Init(context, null, null, null);
			this.EffectHandleMap.Add(num, kuroEffectHandle);
			kuroEffectHandle.OnAfterSpawn(num);
			return num;
		}

		// Token: 0x060459A4 RID: 285092 RVA: 0x0122FD6C File Offset: 0x0122DF6C
		public void RemoveKuroEffectHandle(int effectId)
		{
			KuroEffectHandle kuroEffectHandle;
			if (this.EffectHandleMap.Remove(effectId, out kuroEffectHandle))
			{
				kuroEffectHandle.Clear(true);
				this.EffectActorHandleMap.Remove(effectId);
				this.EffectNiagaraHandleMap.Remove(effectId);
			}
		}

		// Token: 0x060459A5 RID: 285093 RVA: 0x0122FDAA File Offset: 0x0122DFAA
		public int GetEffectLruCount(string path)
		{
			return UKuroEffectSystemFunctionLibrary.GetEffectLruCount(path);
		}

		// Token: 0x060459A6 RID: 285094 RVA: 0x0122FDB2 File Offset: 0x0122DFB2
		public int GetEffectLruCapacity()
		{
			return UKuroEffectSystemFunctionLibrary.GetEffectLruCapacity();
		}

		// Token: 0x060459A7 RID: 285095 RVA: 0x0122FDB9 File Offset: 0x0122DFB9
		public void SetEffectLruCapacity(int capacity)
		{
			UKuroEffectSystemFunctionLibrary.SetEffectLruCapacity(capacity);
		}

		// Token: 0x060459A8 RID: 285096 RVA: 0x0122FDC1 File Offset: 0x0122DFC1
		public int GetEffectLruSize()
		{
			return UKuroEffectSystemFunctionLibrary.GetEffectLruSize();
		}

		// Token: 0x060459A9 RID: 285097 RVA: 0x0122FDC8 File Offset: 0x0122DFC8
		[NullableContext(2)]
		public int SpawnUnloopedEffect(UObject worldContext, in FTransformDouble? transform, string path, [Nullable(1)] string reason, EffectContext context = null, EEffectType effectType = EEffectType.Scene, Action<int> beforeInitCallback = null, Action<ELoadEffectResult, int> callback = null, Action<int> beforePlayCallback = null, bool prepare = false, bool forceCreateActor = false)
		{
			if (!this.HasInitialize && !Singleton<Info>.Instance.IsPlayInEditor)
			{
				return 0;
			}
			if (path == null)
			{
				return 0;
			}
			KuroEffectHandle kuroEffectHandle = new KuroEffectHandle();
			kuroEffectHandle.Init(context, beforeInitCallback, callback, beforePlayCallback);
			FKuroEffectContext fkuroEffectContext = KuroEffectSystem.CreateFEffectContext(context);
			FKuroEffectBeforeInitCallback beforeInitDelegate = null;
			if (beforeInitCallback != null)
			{
				beforeInitDelegate = global::DelegateUtils.ToManualReleaseDelegate<FKuroEffectBeforeInitCallback>(new Action<int>(kuroEffectHandle.OnBeforeInitCallback));
			}
			FKuroEffectInitCallback initDelegate = null;
			if (callback != null)
			{
				initDelegate = global::DelegateUtils.ToManualReleaseDelegate<FKuroEffectInitCallback>(new Action<byte, int>(kuroEffectHandle.OnEffectInitCallback));
			}
			FKuroEffectBeforePlayCallback beforePlayDelegate = global::DelegateUtils.ToManualReleaseDelegate<FKuroEffectBeforePlayCallback>(new Action<int>(kuroEffectHandle.OnBeforePlayCallback));
			FKuroEffectOnClearCallback clearDelegate = global::DelegateUtils.ToManualReleaseDelegate<FKuroEffectOnClearCallback>(new Action(kuroEffectHandle.OnInitCallbackClear));
			kuroEffectHandle.OnSpawnDelegatesRegistered(beforeInitDelegate, initDelegate, beforePlayDelegate, clearDelegate);
			int num;
			switch (fkuroEffectContext.ContextType)
			{
			case 1:
			{
				FTransformDouble ftransformDouble = transform ?? new FTransformDouble();
				FKuroSkeletalMeshEffectContext fkuroSkeletalMeshEffectContext = (FKuroSkeletalMeshEffectContext)fkuroEffectContext;
				num = UKuroEffectSystemFunctionLibrary.SpawnUnloopedEffectFromSkeletalContext(worldContext, ftransformDouble, path, reason, fkuroSkeletalMeshEffectContext, beforeInitDelegate, initDelegate, beforePlayDelegate, clearDelegate, (byte)effectType, prepare, forceCreateActor);
				break;
			}
			case 2:
			{
				FTransformDouble ftransformDouble = transform ?? new FTransformDouble();
				FKuroEffectAudioContext fkuroEffectAudioContext = (FKuroEffectAudioContext)fkuroEffectContext;
				num = UKuroEffectSystemFunctionLibrary.SpawnUnloopedEffectFromAudioContext(worldContext, ftransformDouble, path, reason, fkuroEffectAudioContext, beforeInitDelegate, initDelegate, beforePlayDelegate, clearDelegate, (byte)effectType, prepare, forceCreateActor);
				break;
			}
			case 3:
			{
				FTransformDouble ftransformDouble = transform ?? new FTransformDouble();
				FKuroEffectRuntimeGhostEffectContext fkuroEffectRuntimeGhostEffectContext = (FKuroEffectRuntimeGhostEffectContext)fkuroEffectContext;
				num = UKuroEffectSystemFunctionLibrary.SpawnUnloopedEffectFromGhostContext(worldContext, ftransformDouble, path, reason, fkuroEffectRuntimeGhostEffectContext, beforeInitDelegate, initDelegate, beforePlayDelegate, clearDelegate, (byte)effectType, prepare, forceCreateActor);
				break;
			}
			default:
			{
				FTransformDouble ftransformDouble = transform ?? new FTransformDouble();
				num = UKuroEffectSystemFunctionLibrary.SpawnUnloopedEffect(worldContext, ftransformDouble, path, reason, fkuroEffectContext, beforeInitDelegate, initDelegate, beforePlayDelegate, clearDelegate, (byte)effectType, prepare, forceCreateActor);
				break;
			}
			}
			int num2 = num;
			if (!this.IsValid(num2))
			{
				return 0;
			}
			if (!this.EffectHandleMap.TryAdd(num2, kuroEffectHandle))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderEffect;
				ELogAuthor author = ELogAuthor.WLJ;
				string message = "[特效框架]SpawnUnloopedEffect 生成了一个已经存在的effectId";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", num2);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return 0;
			}
			kuroEffectHandle.OnAfterSpawn(num2);
			return num2;
		}

		// Token: 0x060459AA RID: 285098 RVA: 0x0123000C File Offset: 0x0122E20C
		[NullableContext(2)]
		public int SpawnEffect(UObject worldContext, in FTransformDouble? transform, string path, [Nullable(1)] string reason, EffectContext context = null, EEffectType effectType = EEffectType.Scene, Action<int> beforeInitCallback = null, Action<ELoadEffectResult, int> callback = null, Action<int> beforePlayCallback = null, bool prepare = false, bool forceCreateActor = false)
		{
			if (!this.HasInitialize && !Singleton<Info>.Instance.IsPlayInEditor)
			{
				return 0;
			}
			if (path == null)
			{
				return 0;
			}
			KuroEffectHandle kuroEffectHandle = new KuroEffectHandle();
			kuroEffectHandle.Init(context, beforeInitCallback, callback, beforePlayCallback);
			FKuroEffectContext fkuroEffectContext = KuroEffectSystem.CreateFEffectContext(context);
			FKuroEffectBeforeInitCallback beforeInitDelegate = null;
			if (beforeInitCallback != null)
			{
				beforeInitDelegate = global::DelegateUtils.ToManualReleaseDelegate<FKuroEffectBeforeInitCallback>(new Action<int>(kuroEffectHandle.OnBeforeInitCallback));
			}
			FKuroEffectInitCallback initDelegate = null;
			if (callback != null)
			{
				initDelegate = global::DelegateUtils.ToManualReleaseDelegate<FKuroEffectInitCallback>(new Action<byte, int>(kuroEffectHandle.OnEffectInitCallback));
			}
			FKuroEffectBeforePlayCallback beforePlayDelegate = global::DelegateUtils.ToManualReleaseDelegate<FKuroEffectBeforePlayCallback>(new Action<int>(kuroEffectHandle.OnBeforePlayCallback));
			FKuroEffectOnClearCallback clearDelegate = global::DelegateUtils.ToManualReleaseDelegate<FKuroEffectOnClearCallback>(new Action(kuroEffectHandle.OnInitCallbackClear));
			kuroEffectHandle.OnSpawnDelegatesRegistered(beforeInitDelegate, initDelegate, beforePlayDelegate, clearDelegate);
			int num;
			switch (fkuroEffectContext.ContextType)
			{
			case 1:
			{
				FTransformDouble ftransformDouble = transform ?? new FTransformDouble();
				FKuroSkeletalMeshEffectContext fkuroSkeletalMeshEffectContext = (FKuroSkeletalMeshEffectContext)fkuroEffectContext;
				num = UKuroEffectSystemFunctionLibrary.SpawnEffectFromSkeletalContext(worldContext, ftransformDouble, path, reason, fkuroSkeletalMeshEffectContext, beforeInitDelegate, initDelegate, beforePlayDelegate, clearDelegate, (byte)effectType, prepare, forceCreateActor);
				break;
			}
			case 2:
			{
				FTransformDouble ftransformDouble = transform ?? new FTransformDouble();
				FKuroEffectAudioContext fkuroEffectAudioContext = (FKuroEffectAudioContext)fkuroEffectContext;
				num = UKuroEffectSystemFunctionLibrary.SpawnEffectFromAudioContext(worldContext, ftransformDouble, path, reason, fkuroEffectAudioContext, beforeInitDelegate, initDelegate, beforePlayDelegate, clearDelegate, (byte)effectType, prepare, forceCreateActor);
				break;
			}
			case 3:
			{
				FTransformDouble ftransformDouble = transform ?? new FTransformDouble();
				FKuroEffectRuntimeGhostEffectContext fkuroEffectRuntimeGhostEffectContext = (FKuroEffectRuntimeGhostEffectContext)fkuroEffectContext;
				num = UKuroEffectSystemFunctionLibrary.SpawnEffectFromGhostContext(worldContext, ftransformDouble, path, reason, fkuroEffectRuntimeGhostEffectContext, beforeInitDelegate, initDelegate, beforePlayDelegate, clearDelegate, (byte)effectType, prepare, forceCreateActor);
				break;
			}
			default:
			{
				FTransformDouble ftransformDouble = transform ?? new FTransformDouble();
				num = UKuroEffectSystemFunctionLibrary.SpawnEffect(worldContext, ftransformDouble, path, reason, fkuroEffectContext, beforeInitDelegate, initDelegate, beforePlayDelegate, clearDelegate, (byte)effectType, prepare, forceCreateActor);
				break;
			}
			}
			int num2 = num;
			if (!this.IsValid(num2))
			{
				return 0;
			}
			if (!this.EffectHandleMap.TryAdd(num2, kuroEffectHandle))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderEffect;
				ELogAuthor author = ELogAuthor.WLJ;
				string message = "[特效框架]SpawnEffect 生成了一个已经存在的effectId";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", num2);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return 0;
			}
			kuroEffectHandle.OnAfterSpawn(num2);
			return num2;
		}

		// Token: 0x060459AB RID: 285099 RVA: 0x01230250 File Offset: 0x0122E450
		public void DynamicRegisterSpawnCallback(int effectId, Action<ELoadEffectResult, int> callback)
		{
			if (!this.HasInitialize && !Singleton<Info>.Instance.IsPlayInEditor)
			{
				return;
			}
			KuroEffectHandle kuroEffectHandle;
			if (this.EffectHandleMap.TryGetValue(effectId, out kuroEffectHandle))
			{
				kuroEffectHandle.RegisterDynamicEffectInitCallback(callback);
			}
		}

		// Token: 0x060459AC RID: 285100 RVA: 0x0123028C File Offset: 0x0122E48C
		public void AddFinishCallback(int effectId, Action<int> callback)
		{
			if (!this.HasInitialize && !Singleton<Info>.Instance.IsPlayInEditor)
			{
				return;
			}
			KuroEffectHandle kuroEffectHandle;
			if (this.EffectHandleMap.TryGetValue(effectId, out kuroEffectHandle))
			{
				kuroEffectHandle.AddFinishCallback(callback);
			}
		}

		// Token: 0x060459AD RID: 285101 RVA: 0x012302C8 File Offset: 0x0122E4C8
		public void RemoveFinishCallback(int effectId, Action<int> callback)
		{
			if (!this.HasInitialize && !Singleton<Info>.Instance.IsPlayInEditor)
			{
				return;
			}
			KuroEffectHandle kuroEffectHandle;
			if (this.EffectHandleMap.TryGetValue(effectId, out kuroEffectHandle))
			{
				kuroEffectHandle.RemoveFinishCallback(callback);
			}
		}

		// Token: 0x060459AE RID: 285102 RVA: 0x01230302 File Offset: 0x0122E502
		public void ForceCheckPendingInit(int handle)
		{
			UKuroEffectSystemFunctionLibrary.ForceCheckPendingInit(handle);
		}

		// Token: 0x060459AF RID: 285103 RVA: 0x0123030A File Offset: 0x0122E50A
		[NullableContext(2)]
		public void SetEffectHidden(int handle, bool bHidden, string reason = null, bool isLogic = false)
		{
			UKuroEffectSystemFunctionLibrary.SetEffectHidden(handle, bHidden, reason ?? string.Empty, isLogic);
		}

		// Token: 0x060459B0 RID: 285104 RVA: 0x0123031F File Offset: 0x0122E51F
		public bool StopEffectById(int handle, string reason, bool immediately, bool? destroyActor = null)
		{
			return UKuroEffectSystemFunctionLibrary.StopEffectById(handle, reason, immediately, destroyActor.GetValueOrDefault());
		}

		// Token: 0x060459B1 RID: 285105 RVA: 0x01230330 File Offset: 0x0122E530
		public bool IsValid(int id)
		{
			return UKuroEffectSystemFunctionLibrary.IsEffectValid(id);
		}

		// Token: 0x060459B2 RID: 285106 RVA: 0x01230338 File Offset: 0x0122E538
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public OneOf<KuroEffectActorHandle, AActor> GetEffectActor(int id)
		{
			if (id == 0)
			{
				return default(OneOf<KuroEffectActorHandle, AActor>);
			}
			if (UKuroEffectSystemFunctionLibrary.IsEffectActorValid(id))
			{
				AActor sureEffectActor = this.GetSureEffectActor(id);
				if (sureEffectActor == null)
				{
					return default(OneOf<KuroEffectActorHandle, AActor>);
				}
				return sureEffectActor;
			}
			else
			{
				KuroEffectActorHandle value;
				if (this.EffectActorHandleMap.TryGetValue(id, out value))
				{
					return value;
				}
				KuroEffectActorHandle value2 = new KuroEffectActorHandle(id);
				this.EffectActorHandleMap.Add(id, value2);
				return value2;
			}
		}

		// Token: 0x060459B3 RID: 285107 RVA: 0x012303A7 File Offset: 0x0122E5A7
		[NullableContext(2)]
		public AActor GetSureEffectActor(int id)
		{
			return UKuroEffectSystemFunctionLibrary.GetSureEffectActor(id);
		}

		// Token: 0x060459B4 RID: 285108 RVA: 0x012303B0 File Offset: 0x0122E5B0
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent> GetNiagaraComponent(int id)
		{
			if (id == 0)
			{
				return default(OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent>);
			}
			OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent> result = default(OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent>);
			if (!UKuroEffectSystemFunctionLibrary.HasNiagaraComponentHandle(id))
			{
				result = this.GetSureNiagaraComponent(id);
			}
			if (!result.HasValue)
			{
				KuroEffectNiagaraComponentHandle value;
				if (this.EffectNiagaraHandleMap.TryGetValue(id, out value))
				{
					return value;
				}
				KuroEffectNiagaraComponentHandle value2 = new KuroEffectNiagaraComponentHandle(id);
				this.EffectNiagaraHandleMap.Add(id, value2);
				result = value2;
			}
			return result;
		}

		// Token: 0x060459B5 RID: 285109 RVA: 0x01230423 File Offset: 0x0122E623
		[NullableContext(2)]
		public UNiagaraComponent GetSureNiagaraComponent(int id)
		{
			return UKuroEffectSystemFunctionLibrary.GetSureNiagaraComponent(id);
		}

		// Token: 0x060459B6 RID: 285110 RVA: 0x0123042C File Offset: 0x0122E62C
		public void ReplayEffect(int id, string reason, in FTransformDouble? transform)
		{
			FTransformDouble ftransformDouble = transform ?? new FTransformDouble();
			UKuroEffectSystemFunctionLibrary.ReplayEffect(id, reason, ftransformDouble, transform != null);
		}

		// Token: 0x060459B7 RID: 285111 RVA: 0x01230467 File Offset: 0x0122E667
		public bool IsPlaying(int id)
		{
			return UKuroEffectSystemFunctionLibrary.IsPlaying(id);
		}

		// Token: 0x060459B8 RID: 285112 RVA: 0x0123046F File Offset: 0x0122E66F
		public void SetHandleLifeCycle(int id, float time)
		{
			UKuroEffectSystemFunctionLibrary.SetHandleLifeCycle(id, time);
		}

		// Token: 0x060459B9 RID: 285113 RVA: 0x01230478 File Offset: 0x0122E678
		public void SetTimeScale(int id, float timeScale, bool ignoreGlobalTimeScale = false)
		{
			UKuroEffectSystemFunctionLibrary.SetTimeScale(id, timeScale, ignoreGlobalTimeScale);
		}

		// Token: 0x060459BA RID: 285114 RVA: 0x01230482 File Offset: 0x0122E682
		public void SetAdditionTimeScale(int sourceType, int id, float timeScale)
		{
			UKuroEffectSystemFunctionLibrary.SetAdditionTimeScale(sourceType, id, timeScale);
		}

		// Token: 0x060459BB RID: 285115 RVA: 0x0123048C File Offset: 0x0122E68C
		public void SetAdditionTimeScaleEnable(int sourceType, bool enable)
		{
			UKuroEffectSystemFunctionLibrary.SetAdditionTimeScaleEnable(sourceType, enable);
		}

		// Token: 0x060459BC RID: 285116 RVA: 0x01230495 File Offset: 0x0122E695
		public bool GetAdditionTimeScaleEnable(int sourceType)
		{
			return UKuroEffectSystemFunctionLibrary.GetAdditionTimeScaleEnable(sourceType);
		}

		// Token: 0x060459BD RID: 285117 RVA: 0x0123049D File Offset: 0x0122E69D
		public void FreezeHandle(int id, bool freeze, bool force = false)
		{
			UKuroEffectSystemFunctionLibrary.FreezeHandle(id, freeze, force);
		}

		// Token: 0x060459BE RID: 285118 RVA: 0x012304A7 File Offset: 0x0122E6A7
		public bool IsHandleFreeze(int id)
		{
			return UKuroEffectSystemFunctionLibrary.IsHandleFreeze(id);
		}

		// Token: 0x060459BF RID: 285119 RVA: 0x012304AF File Offset: 0x0122E6AF
		public bool HandleSeekToTime(int id, float time, bool autoLoop, bool force = false)
		{
			return UKuroEffectSystemFunctionLibrary.HandleSeekToTime(id, time, autoLoop, force);
		}

		// Token: 0x060459C0 RID: 285120 RVA: 0x012304BB File Offset: 0x0122E6BB
		public void HandleSeekToTimeWithProcess(int id, float time, bool seekContinue = false, float delta = -1f)
		{
			UKuroEffectSystemFunctionLibrary.HandleSeekToTimeWithProcess(id, time, seekContinue, delta);
		}

		// Token: 0x060459C1 RID: 285121 RVA: 0x012304C7 File Offset: 0x0122E6C7
		public float GetSeekToTargetTime(int id)
		{
			return UKuroEffectSystemFunctionLibrary.GetSeekToTargetTime(id);
		}

		// Token: 0x060459C2 RID: 285122 RVA: 0x012304D0 File Offset: 0x0122E6D0
		public void SetEffectNotRecord(int id, bool notRecord = true)
		{
			KuroEffectHandle kuroEffectHandle;
			if (this.EffectHandleMap.TryGetValue(id, out kuroEffectHandle))
			{
				kuroEffectHandle.SetNotRecord(notRecord);
			}
		}

		// Token: 0x060459C3 RID: 285123 RVA: 0x012304F4 File Offset: 0x0122E6F4
		public string GetPath(int id)
		{
			return UKuroEffectSystemFunctionLibrary.GetPath(id);
		}

		// Token: 0x060459C4 RID: 285124 RVA: 0x012304FC File Offset: 0x0122E6FC
		public void SetEffectDataByNiagaraParam(int id, SNiagaraParam niagaraParam, bool resetPassTime)
		{
			if (!this.IsValid(id))
			{
				return;
			}
			EffectModelNiagara effectModelNiagara = UKuroEffectSystemFunctionLibrary.GetEffectModel(id) as EffectModelNiagara;
			if (effectModelNiagara != null)
			{
				effectModelNiagara.FloatParameters = niagaraParam.FloatParameters;
				effectModelNiagara.VectorParameters = niagaraParam.VectorParameters;
				effectModelNiagara.ColorParameters = niagaraParam.ColorParameters;
			}
			UKuroEffectSystemFunctionLibrary.SetThreeStageTime(id, niagaraParam.StartTime, niagaraParam.LoopTime, niagaraParam.EndTime, resetPassTime);
		}

		// Token: 0x060459C5 RID: 285125 RVA: 0x01230560 File Offset: 0x0122E760
		[NullableContext(2)]
		public void SetEffectParameterNiagara(int id, EffectParameterNiagara parameter)
		{
			if (parameter == null)
			{
				return;
			}
			FKuroEffectNiagaraParametersStruct parameters = new FKuroEffectNiagaraParametersStruct();
			parameter.ToKuroEffectParameterNiagara(parameters);
			UKuroEffectSystemFunctionLibrary.SetEffectParameterNiagara(id, parameters);
		}

		// Token: 0x060459C6 RID: 285126 RVA: 0x01230586 File Offset: 0x0122E786
		public void SetEffectDataFloatConstParam(int id, in FName paramName, float value)
		{
			UKuroEffectSystemFunctionLibrary.SetEffectDataFloatConstParam(id, paramName, value);
		}

		// Token: 0x060459C7 RID: 285127 RVA: 0x01230595 File Offset: 0x0122E795
		public void SetEffectExtraState(int effectId, int extraState)
		{
			UKuroEffectSystemFunctionLibrary.SetEffectExtraState(effectId, extraState);
		}

		// Token: 0x060459C8 RID: 285128 RVA: 0x0123059E File Offset: 0x0122E79E
		public void SetEffectIgnoreVisibilityOptimize(int effectId, bool ignore)
		{
			UKuroEffectSystemFunctionLibrary.SetEffectIgnoreVisibilityOptimize(effectId, ignore);
		}

		// Token: 0x060459C9 RID: 285129 RVA: 0x012305A7 File Offset: 0x0122E7A7
		public void SetEffectStoppingTime(int effectId, bool stoppingTime)
		{
			UKuroEffectSystemFunctionLibrary.SetEffectStoppingTime(effectId, stoppingTime);
		}

		// Token: 0x060459CA RID: 285130 RVA: 0x012305B0 File Offset: 0x0122E7B0
		public float GlobalStoppingPlayTime()
		{
			return UKuroEffectSystemFunctionLibrary.GlobalStoppingPlayTime();
		}

		// Token: 0x060459CB RID: 285131 RVA: 0x012305B7 File Offset: 0x0122E7B7
		public bool GlobalStoppingTime()
		{
			return UKuroEffectSystemFunctionLibrary.GlobalStoppingTime();
		}

		// Token: 0x060459CC RID: 285132 RVA: 0x012305BE File Offset: 0x0122E7BE
		public void SetGlobalStoppingTime(bool stoppingTime, float playTime)
		{
			UKuroEffectSystemFunctionLibrary.SetGlobalStoppingTime(stoppingTime, playTime);
		}

		// Token: 0x060459CD RID: 285133 RVA: 0x012305C8 File Offset: 0x0122E7C8
		public void AttachToEffectSkeletalMesh(int id, AActor attachActor, in FName? socketName, EAttachmentRule transformRule)
		{
			UKuroEffectSystemFunctionLibrary.AttachToEffectSkeletalMesh(id, attachActor, socketName ?? FName.NAME_None, transformRule);
		}

		// Token: 0x060459CE RID: 285134 RVA: 0x012305FC File Offset: 0x0122E7FC
		public void AttachSkeletalMesh(int id, SkeletalMeshEffectContext context)
		{
			FKuroSkeletalMeshEffectContext fkuroSkeletalMeshEffectContext = KuroEffectSystem.CreateFEffectContext(context) as FKuroSkeletalMeshEffectContext;
			UKuroEffectSystemFunctionLibrary.AttachSkeletalMesh(id, fkuroSkeletalMeshEffectContext);
		}

		// Token: 0x060459CF RID: 285135 RVA: 0x01230620 File Offset: 0x0122E820
		private static FKuroEffectContext CreateFEffectContext([Nullable(2)] EffectContext context)
		{
			FKuroEffectContext fkuroEffectContext = null;
			if (context is EffectRuntimeGhostEffectContext)
			{
				fkuroEffectContext = new FKuroEffectRuntimeGhostEffectContext();
				fkuroEffectContext.ContextType = 3;
			}
			else if (context is EffectAudioContext)
			{
				fkuroEffectContext = new FKuroEffectAudioContext();
				fkuroEffectContext.ContextType = 2;
			}
			else if (context is SkeletalMeshEffectContext)
			{
				fkuroEffectContext = new FKuroSkeletalMeshEffectContext();
				fkuroEffectContext.ContextType = 1;
			}
			else if (context != null)
			{
				fkuroEffectContext = new FKuroEffectContext();
				fkuroEffectContext.ContextType = 0;
			}
			if (fkuroEffectContext != null)
			{
				context.ToKuroEffectContext(fkuroEffectContext);
			}
			else
			{
				fkuroEffectContext = new FKuroEffectContext();
				fkuroEffectContext.ContextType = 0;
			}
			return fkuroEffectContext;
		}

		// Token: 0x060459D0 RID: 285136 RVA: 0x012306A4 File Offset: 0x0122E8A4
		public void CollectMaterialFloatCurve(int id, in FName key, FKuroCurveFloat value)
		{
			UKuroEffectSystemFunctionLibrary.CollectMaterialFloatCurve(id, key, value);
		}

		// Token: 0x060459D1 RID: 285137 RVA: 0x012306B4 File Offset: 0x0122E8B4
		public void CollectMaterialVectorCurve(int id, in FName key, FKuroCurveVector value)
		{
			UKuroEffectSystemFunctionLibrary.CollectMaterialVectorCurve(id, key, value);
		}

		// Token: 0x060459D2 RID: 285138 RVA: 0x012306C4 File Offset: 0x0122E8C4
		public void CollectMaterialLinearColorCurve(int id, in FName key, FKuroCurveLinearColor value)
		{
			UKuroEffectSystemFunctionLibrary.CollectMaterialLinearColorCurve(id, key, value);
		}

		// Token: 0x060459D3 RID: 285139 RVA: 0x012306D4 File Offset: 0x0122E8D4
		[NullableContext(2)]
		public UEffectModelBase GetEffectModel(int id)
		{
			return UKuroEffectSystemFunctionLibrary.GetEffectModel(id);
		}

		// Token: 0x060459D4 RID: 285140 RVA: 0x012306DC File Offset: 0x0122E8DC
		public float GetTotalPassTime(int id)
		{
			return UKuroEffectSystemFunctionLibrary.GetTotalPassTime(id);
		}

		// Token: 0x060459D5 RID: 285141 RVA: 0x012306E4 File Offset: 0x0122E8E4
		public float GetPassTime(int id)
		{
			return UKuroEffectSystemFunctionLibrary.GetPassTime(id);
		}

		// Token: 0x060459D6 RID: 285142 RVA: 0x012306EC File Offset: 0x0122E8EC
		public bool GetHideOnBurstSkill(int id)
		{
			UEffectModelBase effectModel = this.GetEffectModel(id);
			return effectModel != null && effectModel.HideOnBurstSkill;
		}

		// Token: 0x060459D7 RID: 285143 RVA: 0x0123070C File Offset: 0x0122E90C
		public void RegisterCustomCheckOwnerFunc(int id, Func<int, bool> func)
		{
			KuroEffectHandle kuroEffectHandle;
			if (this.EffectHandleMap.TryGetValue(id, out kuroEffectHandle))
			{
				kuroEffectHandle.OnCustomCheckOwner = func;
			}
		}

		// Token: 0x060459D8 RID: 285144 RVA: 0x01230730 File Offset: 0x0122E930
		public void SetEffectQualityLevel(int id, int qualityLevel)
		{
			UKuroEffectSystemFunctionLibrary.SetEffectQualityLevel(id, qualityLevel);
		}

		// Token: 0x060459D9 RID: 285145 RVA: 0x0123073C File Offset: 0x0122E93C
		public void TickHandleInEditor(int id, float delta)
		{
			UKuroEffectSystemFunctionLibrary.TickHandleInEditor(id, delta);
			KuroEffectHandle kuroEffectHandle;
			if (!Singleton<Info>.Instance.IsGameRunning() && this.EffectHandleMap.TryGetValue(id, out kuroEffectHandle) && kuroEffectHandle.IsLoop && !kuroEffectHandle.CheckOwner() && this.GetSureEffectActor(kuroEffectHandle.Id) is BP_EffectPreview_C)
			{
				this.StopEffectById(kuroEffectHandle.Id, "TickInEditor CheckOwner Failed", true, null);
			}
		}

		// Token: 0x060459DA RID: 285146 RVA: 0x012307AB File Offset: 0x0122E9AB
		public float GetLastPlayTime(int id)
		{
			return UKuroEffectSystemFunctionLibrary.GetLastPlayTime(id);
		}

		// Token: 0x060459DB RID: 285147 RVA: 0x012307B3 File Offset: 0x0122E9B3
		public float GetLastStopTime(int id)
		{
			return UKuroEffectSystemFunctionLibrary.GetLastStopTime(id);
		}

		// Token: 0x060459DC RID: 285148 RVA: 0x012307BB File Offset: 0x0122E9BB
		public void UpdateBodyEffect(int id, float opacity, bool visible, bool castShadow)
		{
			UKuroEffectSystemFunctionLibrary.UpdateBodyEffect(id, opacity, visible, castShadow);
		}

		// Token: 0x060459DD RID: 285149 RVA: 0x012307C7 File Offset: 0x0122E9C7
		public void DebugUpdate(int id, bool dDebugUpdate)
		{
			UKuroEffectSystemFunctionLibrary.DebugUpdate(id, dDebugUpdate);
		}

		// Token: 0x060459DE RID: 285150 RVA: 0x012307D0 File Offset: 0x0122E9D0
		public int GetEffectCount()
		{
			return UKuroEffectSystemFunctionLibrary.GetEffectCount();
		}

		// Token: 0x060459DF RID: 285151 RVA: 0x012307D7 File Offset: 0x0122E9D7
		public int GetActiveEffectCount()
		{
			return UKuroEffectSystemFunctionLibrary.GetActiveEffectCount();
		}

		// Token: 0x060459E0 RID: 285152 RVA: 0x012307DE File Offset: 0x0122E9DE
		public void DebugPrintAllErrorEffects()
		{
			UKuroEffectSystemFunctionLibrary.DebugPrintAllErrorEffects();
		}

		// Token: 0x060459E1 RID: 285153 RVA: 0x012307E5 File Offset: 0x0122E9E5
		public void DebugPrintCurrentImportanceEffects()
		{
			UKuroEffectSystemFunctionLibrary.DebugPrintCurrentImportanceEffects();
		}

		// Token: 0x060459E2 RID: 285154 RVA: 0x012307EC File Offset: 0x0122E9EC
		public void DebugPrintEffect()
		{
			UKuroEffectSystemFunctionLibrary.DebugPrintEffect();
		}

		// Token: 0x060459E3 RID: 285155 RVA: 0x012307F3 File Offset: 0x0122E9F3
		public int GetPlayerEffectLruSize(int pos)
		{
			return UKuroEffectSystemFunctionLibrary.GetPlayerEffectLruSize(pos);
		}

		// Token: 0x060459E4 RID: 285156 RVA: 0x012307FC File Offset: 0x0122E9FC
		public void SetEffectStartRecording(global::Vector tempVector, global::Vector centerLocation, float recordDistSquared, Action<int, AActor> onEffectRecorded)
		{
			foreach (KuroEffectHandle kuroEffectHandle in this.EffectHandleMap.Values)
			{
				if (kuroEffectHandle.IsDone())
				{
					UEffectModelBase effectModel = this.GetEffectModel(kuroEffectHandle.Id);
					if (effectModel != null && effectModel.IsValid())
					{
						bool flag = false;
						if (flag)
						{
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.Test;
							ELogAuthor author = ELogAuthor.LCZ;
							string message = "Try ";
							ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("effectModel", effectModel);
							instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						}
						if (kuroEffectHandle.GetNotRecord())
						{
							if (flag)
							{
								Log instance2 = Singleton<Log>.Instance;
								ELogModule module2 = ELogModule.Test;
								ELogAuthor author2 = ELogAuthor.LCZ;
								string message2 = "Continue1  ";
								ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("handle.GetIsAnimEffect()", kuroEffectHandle.GetNotRecord());
								instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
							}
						}
						else
						{
							AActor sureEffectActor = this.GetSureEffectActor(kuroEffectHandle.Id);
							if (sureEffectActor != null)
							{
								FVectorDouble fvectorDouble = sureEffectActor.D_K2_GetActorLocation();
								tempVector.FromUeVector(fvectorDouble);
								if (global::Vector.DistSquared(tempVector, centerLocation) > (double)recordDistSquared)
								{
									if (flag)
									{
										Log instance3 = Singleton<Log>.Instance;
										ELogModule module3 = ELogModule.Test;
										ELogAuthor author3 = ELogAuthor.LCZ;
										DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 3);
										defaultInterpolatedStringHandler.AppendLiteral("Continue3 ");
										defaultInterpolatedStringHandler.AppendFormatted(tempVector.ToString());
										defaultInterpolatedStringHandler.AppendLiteral(" ");
										defaultInterpolatedStringHandler.AppendFormatted(centerLocation.ToString());
										defaultInterpolatedStringHandler.AppendLiteral(" ");
										defaultInterpolatedStringHandler.AppendFormatted<float>(recordDistSquared);
										instance3.Warn(module3, author3, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
									}
								}
								else
								{
									onEffectRecorded(kuroEffectHandle.Id, sureEffectActor);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060459E5 RID: 285157 RVA: 0x012309B4 File Offset: 0x0122EBB4
		public void RefreshEffectSpecData(Dictionary<string, SpecData> specDataMap)
		{
			TArray<FKuroEffectSpecData> tarray = new TArray<FKuroEffectSpecData>();
			TArray<FKuroEffectSpecChildData> tarray2 = new TArray<FKuroEffectSpecChildData>();
			foreach (SpecData specData in specDataMap.Values)
			{
				FKuroEffectSpecData value = new FKuroEffectSpecData
				{
					Id = specData.Id,
					SpecType = specData.SpecType,
					EffectRegularType = (byte)specData.EffectRegularType,
					LifeTime = specData.LifeTime
				};
				tarray.Add(value);
				if (specData.Children.Count > 0)
				{
					FKuroEffectSpecChildData fkuroEffectSpecChildData = new FKuroEffectSpecChildData();
					fkuroEffectSpecChildData.Id = specData.Id;
					foreach (int value2 in specData.Children)
					{
						fkuroEffectSpecChildData.Children.Add(value2);
					}
					tarray2.Add(fkuroEffectSpecChildData);
				}
			}
			UKuroEffectSystemFunctionLibrary.RefreshEffectForSpecData(tarray, tarray2, true);
		}

		// Token: 0x060459E6 RID: 285158 RVA: 0x01230AD4 File Offset: 0x0122ECD4
		[return: Nullable(2)]
		private static UActorComponent SkeletalMeshSpecOnBodyEffectChange(float opacity, [Nullable(2)] UActorComponent renderingComponent, USkeletalMeshComponent skeletalMeshComponent, AActor owner)
		{
			CharRenderingComponent charRenderingComponent = renderingComponent as CharRenderingComponent;
			if (opacity < 1f)
			{
				if (charRenderingComponent == null)
				{
					charRenderingComponent = (owner.GetComponentByClass(CharRenderingComponent.StaticClass()) as CharRenderingComponent);
				}
				if (charRenderingComponent == null)
				{
					TSubclassOf<UActorComponent> @class = CharRenderingComponent.StaticClass();
					bool bManualAttachment = false;
					FTransform ftransform = new FTransform();
					charRenderingComponent = (owner.AddComponentByClass(@class, bManualAttachment, ftransform, false, default(FName)) as CharRenderingComponent);
					charRenderingComponent.Init(GlobalData.IsUiSceneOpen ? ECharacterRenderingType.UI : ECharacterRenderingType.Default);
					charRenderingComponent.SetLogicOwner(owner);
					charRenderingComponent.AddComponentByCase(ECharacterControllerCaseType.BodyCase0, skeletalMeshComponent);
				}
				charRenderingComponent.SetDitherEffect(opacity, ECharacterDitherType.Fight);
			}
			else if (charRenderingComponent != null)
			{
				charRenderingComponent.SetDitherEffect(1f, ECharacterDitherType.Fight);
			}
			return charRenderingComponent;
		}

		// Token: 0x060459E7 RID: 285159 RVA: 0x01230B70 File Offset: 0x0122ED70
		private static UActorComponent SkeletalMeshSpecCreateRenderingComponent([Nullable(2)] UActorComponent renderingComponent, USkeletalMeshComponent skeletalMeshComponent, AActor owner)
		{
			CharRenderingComponent charRenderingComponent = renderingComponent as CharRenderingComponent;
			if (charRenderingComponent == null)
			{
				charRenderingComponent = (owner.GetComponentByClass(CharRenderingComponent.StaticClass()) as CharRenderingComponent);
			}
			if (charRenderingComponent == null)
			{
				TSubclassOf<UActorComponent> @class = CharRenderingComponent.StaticClass();
				bool bManualAttachment = false;
				FTransform ftransform = new FTransform();
				charRenderingComponent = (owner.AddComponentByClass(@class, bManualAttachment, ftransform, false, default(FName)) as CharRenderingComponent);
				charRenderingComponent.Init(GlobalData.IsUiSceneOpen ? ECharacterRenderingType.UI : ECharacterRenderingType.Default);
				charRenderingComponent.SetLogicOwner(owner);
				charRenderingComponent.AddComponentByCase(ECharacterControllerCaseType.BodyCase0, skeletalMeshComponent);
			}
			return charRenderingComponent;
		}

		// Token: 0x060459E8 RID: 285160 RVA: 0x01230BEC File Offset: 0x0122EDEC
		private static void SkeletalMeshSpecDestroyRenderingComponent(AActor effectActor, [Nullable(2)] UActorComponent renderingComponent)
		{
			CharRenderingComponent charRenderingComponent = (renderingComponent as CharRenderingComponent) ?? (effectActor.GetComponentByClass(CharRenderingComponent.StaticClass()) as CharRenderingComponent);
			if (charRenderingComponent != null)
			{
				charRenderingComponent.ResetAllRenderingState();
				charRenderingComponent.K2_DestroyComponent(charRenderingComponent);
			}
		}

		// Token: 0x060459E9 RID: 285161 RVA: 0x01230C2C File Offset: 0x0122EE2C
		[NullableContext(2)]
		private static AActor EffectHandleGetEntityOwnerActor(int entityId)
		{
			if (entityId == 0)
			{
				return null;
			}
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
			if (entity == null)
			{
				return null;
			}
			CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
			if (component == null)
			{
				return null;
			}
			return component.Owner;
		}

		// Token: 0x060459EA RID: 285162 RVA: 0x01230C60 File Offset: 0x0122EE60
		private static int EffectHandleGetEntityModelConfigId(int entityId)
		{
			if (!Singleton<Info>.Instance.IsGameRunning())
			{
				return 0;
			}
			if (entityId == 0)
			{
				return 0;
			}
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityId);
			if (entityById != null && entityById.Valid)
			{
				CreatureDataComponent component = entityById.Entity.GetComponent<CreatureDataComponent>();
				if (component != null)
				{
					SModelConfig modelConfig = component.GetModelConfig();
					if (modelConfig != null)
					{
						return modelConfig.ID;
					}
				}
			}
			return 0;
		}

		// Token: 0x060459EB RID: 285163 RVA: 0x01230CBE File Offset: 0x0122EEBE
		private static FName EffectHandleGetOrAddEffectDynamicGroup(float effectEnableRange)
		{
			return Singleton<GameBudgetAllocatorConfigCreator>.Instance.GetEffectDynamicGroup((uint)effectEnableRange).GroupName;
		}

		// Token: 0x060459EC RID: 285164 RVA: 0x01230CD4 File Offset: 0x0122EED4
		[return: Nullable(2)]
		private static UAkComponent AudioSystemGetAkComponent(bool fromPrimaryRole, AActor effectActor)
		{
			return Singleton<AudioSystem>.Instance.GetAkComponent(effectActor, new FName?(FName.NAME_None), delegate(AActor owner, UAkComponent _)
			{
				ControllerBase<GameAudioController>.Instance.SetRolePriority(fromPrimaryRole ? ERoleAudioPriorityType.PlayerControl : ERoleAudioPriorityType.OtherControl, owner);
			});
		}

		// Token: 0x060459ED RID: 285165 RVA: 0x01230D14 File Offset: 0x0122EF14
		private static void AudioSystemExecuteActionStop(int eventHandle, float fadeOutTime)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(eventHandle, EAudioActionType.Stop, new ExecuteActionArgs?(new ExecuteActionArgs
			{
				TransitionDuration = new int?((int)fadeOutTime)
			}));
		}

		// Token: 0x060459EE RID: 285166 RVA: 0x01230D4C File Offset: 0x0122EF4C
		private static int AudioSystemPostEventTransform(string eventName, FTransformDouble transform)
		{
			return Singleton<AudioSystem>.Instance.PostEvent(eventName, new FTransformDouble?(transform), null);
		}

		// Token: 0x060459EF RID: 285167 RVA: 0x01230D74 File Offset: 0x0122EF74
		private static int AudioSystemPostEventAkComponent(string eventName, [Nullable(2)] UAkComponent akComponent)
		{
			return Singleton<AudioSystem>.Instance.PostEvent(eventName, akComponent, null);
		}

		// Token: 0x060459F0 RID: 285168 RVA: 0x01230D98 File Offset: 0x0122EF98
		private static bool NiagaraSpecIsNeedQualityBias(int entityId)
		{
			if (!Singleton<Info>.Instance.IsGameRunning())
			{
				return false;
			}
			EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(entityId);
			if (handle == null || !handle.Valid)
			{
				return false;
			}
			WorldEntity entity = handle.Entity;
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			if (component.GetEntityType() == EEntityType.Player && !entity.GetComponent<CharacterActorComponent>().IsAutonomousProxy)
			{
				return true;
			}
			if (component.GetEntityType() == EEntityType.Vehicle && !entity.GetComponent<VehicleActorComponent>().IsAutonomousProxy)
			{
				return true;
			}
			int entityId2 = ModelBase<CreatureModel>.Instance.GetEntityId(component.GetSummonerId());
			Entity entity2 = Singleton<EntitySystem>.Instance.Get(entityId2);
			CreatureDataComponent creatureDataComponent = (entity2 != null) ? entity2.GetComponent<CreatureDataComponent>() : null;
			return creatureDataComponent != null && creatureDataComponent.GetEntityType() == EEntityType.Player && !entity.GetComponent<CharacterActorComponent>().IsAutonomousProxy;
		}

		// Token: 0x060459F1 RID: 285169 RVA: 0x01230E58 File Offset: 0x0122F058
		private static bool PostProcessSpecIsNeedPostEffect(int entityId, bool visibleForProtoPlayer)
		{
			if (!Singleton<Info>.Instance.IsGameRunning())
			{
				return true;
			}
			if (visibleForProtoPlayer)
			{
				return true;
			}
			EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(entityId);
			if (handle == null || !handle.Valid)
			{
				return true;
			}
			WorldEntity entity = handle.Entity;
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			if (component.GetEntityType() == EEntityType.Player && !entity.GetComponent<CharacterActorComponent>().IsAutonomousProxy)
			{
				return false;
			}
			int entityId2 = ModelBase<CreatureModel>.Instance.GetEntityId(component.GetSummonerId());
			Entity entity2 = Singleton<EntitySystem>.Instance.Get(entityId2);
			CreatureDataComponent creatureDataComponent = (entity2 != null) ? entity2.GetComponent<CreatureDataComponent>() : null;
			return creatureDataComponent == null || creatureDataComponent.GetEntityType() != EEntityType.Player || entity.GetComponent<CharacterActorComponent>().IsAutonomousProxy;
		}

		// Token: 0x060459F2 RID: 285170 RVA: 0x01230F04 File Offset: 0x0122F104
		private static bool PostProcessSpecIsDisableInUltraSkill(int entityId)
		{
			if (!Singleton<Info>.Instance.IsGameRunning())
			{
				return true;
			}
			EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(entityId);
			if (handle == null || !handle.Valid)
			{
				return true;
			}
			WorldEntity entity = handle.Entity;
			return entity.GetComponent<CreatureDataComponent>().GetEntityType() != EEntityType.Player || !entity.GetComponent<CharacterActorComponent>().IsAutonomousProxy;
		}

		// Token: 0x060459F3 RID: 285171 RVA: 0x01230F62 File Offset: 0x0122F162
		[NullableContext(2)]
		private static AActor ActorSystemGet([Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<AActor> ueClass, in FTransformDouble transform)
		{
			return Singleton<ActorSystem>.Instance.Get(ueClass, transform, null, true);
		}

		// Token: 0x060459F4 RID: 285172 RVA: 0x01230F7C File Offset: 0x0122F17C
		private static bool ActorSystemPut(string reason, AActor actor)
		{
			return Singleton<ActorSystem>.Instance.Put(reason, actor, null);
		}

		// Token: 0x060459F5 RID: 285173 RVA: 0x01230F8C File Offset: 0x0122F18C
		private static void EffectSystemSetEffectView(AActor effectActor, int effectId)
		{
			BP_EffectPreview_C bp_EffectPreview_C = effectActor as BP_EffectPreview_C;
			if (bp_EffectPreview_C != null)
			{
				bp_EffectPreview_C.EffectView = effectId;
			}
		}

		// Token: 0x060459F6 RID: 285174 RVA: 0x01230FAC File Offset: 0x0122F1AC
		private static bool EffectSystemCheckIsNetPlayer(int entityId)
		{
			if (!Singleton<Info>.Instance.IsGameRunning())
			{
				return false;
			}
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityId);
			if (entityById == null || !entityById.Valid)
			{
				return false;
			}
			CreatureDataComponent component = entityById.Entity.GetComponent<CreatureDataComponent>();
			return component.GetEntityType() == EEntityType.Player && component.GetPlayerId() != ModelBase<CreatureModel>.Instance.GetPlayerId();
		}

		// Token: 0x060459F7 RID: 285175 RVA: 0x01231011 File Offset: 0x0122F211
		private static bool EffectSystemCheckMobileBlackEffect(string path)
		{
			return Singleton<Info>.Instance.IsMobilePlatform() && KuroEffectSystem.MOBILE_EFFECT_BLACK_LIST.Contains(path);
		}

		// Token: 0x060459F8 RID: 285176 RVA: 0x01231030 File Offset: 0x0122F230
		[NullableContext(2)]
		private static CharRenderingComponent FindRenderingComponent(AActor effectActor, USkeletalMeshComponent contextMeshComponent, UObject contextSourceObject, [Nullable(1)] UEffectModelBase effectModel)
		{
			CharRenderingComponent charRenderingComponent = null;
			AActor aactor = (effectActor != null) ? effectActor.GetAttachParentActor() : null;
			if (effectModel.NeedDisableWithActor)
			{
				int num = 0;
				AEffectSystemActor aeffectSystemActor = effectActor as AEffectSystemActor;
				if (aeffectSystemActor != null)
				{
					num = aeffectSystemActor.GetOwnerEntityId();
				}
				if (num > 0)
				{
					Entity entity = Singleton<EntitySystem>.Instance.Get(num);
					object obj;
					if (entity == null)
					{
						obj = null;
					}
					else
					{
						CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
						obj = ((component != null) ? component.Owner : null);
					}
					TsBaseCharacter tsBaseCharacter = obj as TsBaseCharacter;
					if (tsBaseCharacter != null)
					{
						return tsBaseCharacter.CharRenderingComponent;
					}
				}
			}
			if (effectModel.LoopTime > 0f || effectModel.NeedDisableWithActor)
			{
				if (contextMeshComponent != null)
				{
					AActor owner = contextMeshComponent.GetOwner();
					charRenderingComponent = (((owner != null) ? owner.GetComponentByClass(CharRenderingComponent.StaticClass()) : null) as CharRenderingComponent);
				}
				if (charRenderingComponent == null)
				{
					charRenderingComponent = (((aactor != null) ? aactor.GetComponentByClass(CharRenderingComponent.StaticClass()) : null) as CharRenderingComponent);
				}
			}
			if (charRenderingComponent == null && effectModel.NeedDisableWithActor)
			{
				AActor aactor2 = contextSourceObject as AActor;
				if (aactor2 != null && aactor2 != aactor)
				{
					charRenderingComponent = (aactor2.GetComponentByClass(CharRenderingComponent.StaticClass()) as CharRenderingComponent);
				}
				if (charRenderingComponent == null)
				{
					UActorComponent uactorComponent = contextSourceObject as UActorComponent;
					AActor aactor3 = (uactorComponent != null) ? uactorComponent.GetOwner() : null;
					if (aactor3 != null && aactor3 != aactor)
					{
						charRenderingComponent = (aactor3.GetComponentByClass(CharRenderingComponent.StaticClass()) as CharRenderingComponent);
					}
				}
			}
			return charRenderingComponent;
		}

		// Token: 0x060459F9 RID: 285177 RVA: 0x01231165 File Offset: 0x0122F365
		[NullableContext(2)]
		private static void EffectSpecRegisterBodyEffect(int effectId, AActor effectActor, USkeletalMeshComponent contextMeshComponent, UObject contextSourceObject, [Nullable(1)] UEffectModelBase effectModel)
		{
			CharRenderingComponent charRenderingComponent = KuroEffectSystem.FindRenderingComponent(effectActor, contextMeshComponent, contextSourceObject, effectModel);
			if (charRenderingComponent == null)
			{
				return;
			}
			charRenderingComponent.RegisterBodyEffect(effectId);
		}

		// Token: 0x060459FA RID: 285178 RVA: 0x0123117C File Offset: 0x0122F37C
		private static void EffectSpecUnregisterBodyEffect(int effectId, [Nullable(2)] AActor effectActor, USkeletalMeshComponent contextMeshComponent, UObject contextSourceObject, UEffectModelBase effectModel)
		{
			CharRenderingComponent charRenderingComponent = KuroEffectSystem.FindRenderingComponent(effectActor, contextMeshComponent, contextSourceObject, effectModel);
			if (charRenderingComponent == null)
			{
				return;
			}
			charRenderingComponent.UnregisterBodyEffect(effectId);
		}

		// Token: 0x060459FB RID: 285179 RVA: 0x01231194 File Offset: 0x0122F394
		[NullableContext(2)]
		private static UKuroCharRenderingComponent MaterialSpecGetRenderingComponentByContext(int entityId, UObject contextSourceObject)
		{
			if (entityId != 0)
			{
				Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
				object obj;
				if (entity == null)
				{
					obj = null;
				}
				else
				{
					CharacterActorComponent component = entity.GetComponent<CharacterActorComponent>();
					obj = ((component != null) ? component.Owner : null);
				}
				TsBaseCharacter tsBaseCharacter = obj as TsBaseCharacter;
				if (tsBaseCharacter != null)
				{
					return tsBaseCharacter.CharRenderingComponent;
				}
			}
			TsBaseCharacter tsBaseCharacter2 = contextSourceObject as TsBaseCharacter;
			if (tsBaseCharacter2 != null)
			{
				return tsBaseCharacter2.CharRenderingComponent;
			}
			return null;
		}

		// Token: 0x060459FC RID: 285180 RVA: 0x012311EC File Offset: 0x0122F3EC
		[NullableContext(2)]
		private static UKuroCharRenderingComponent MaterialSpecGetRenderingComponentBySkeletal(USkeletalMeshComponent skeletalMeshComponent)
		{
			if (skeletalMeshComponent == null)
			{
				return null;
			}
			AActor owner = skeletalMeshComponent.GetOwner();
			TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
			if (tsBaseCharacter != null)
			{
				return tsBaseCharacter.CharRenderingComponent;
			}
			CharRenderingComponent charRenderingComponent = owner.GetComponentByClass(CharRenderingComponent.StaticClass()) as CharRenderingComponent;
			if (charRenderingComponent != null)
			{
				return charRenderingComponent;
			}
			return null;
		}

		// Token: 0x060459FD RID: 285181 RVA: 0x01231234 File Offset: 0x0122F434
		[NullableContext(2)]
		private static AActor MaterialSpecSpawnRenderActor(USkeletalMeshComponent skeletalMeshComponent)
		{
			TSubclassOf<AActor> actorClass = BP_MaterialControllerRenderActor_C.StaticClass();
			FTransformDouble ftransformDouble = new FTransformDouble();
			return UKuroRenderingRuntimeBPPluginBPLibrary.D_SpawnActorFromClass(skeletalMeshComponent, actorClass, ftransformDouble, ESpawnActorCollisionHandlingMethod.Undefined, null, null, true);
		}

		// Token: 0x060459FE RID: 285182 RVA: 0x01231260 File Offset: 0x0122F460
		[NullableContext(2)]
		private static UKuroCharRenderingComponent MaterialSpecGetRenderingComponentByRenderActor(AActor actor, USkeletalMeshComponent skeletalMeshComponent)
		{
			if (actor == null)
			{
				return null;
			}
			AActor logicOwner = (skeletalMeshComponent != null) ? skeletalMeshComponent.GetOwner() : null;
			CharRenderingComponent charRenderingComponent = (actor as BP_MaterialControllerRenderActor_C).CharRenderingComponent;
			charRenderingComponent.Init(GlobalData.IsUiSceneOpen ? ECharacterRenderingType.UI : ECharacterRenderingType.Default);
			charRenderingComponent.SetLogicOwner(logicOwner);
			charRenderingComponent.AddComponentByCase(ECharacterControllerCaseType.BodyCase0, skeletalMeshComponent);
			return charRenderingComponent;
		}

		// Token: 0x060459FF RID: 285183 RVA: 0x012312AC File Offset: 0x0122F4AC
		[NullableContext(2)]
		private static int MaterialSpecAddMaterialControllerData(UKuroCharRenderingComponent renderComponent, UKuroMaterialControllerDataAsset dataAsset)
		{
			if (dataAsset != null)
			{
				CharRenderingComponent charRenderingComponent = renderComponent as CharRenderingComponent;
				if (charRenderingComponent != null)
				{
					return charRenderingComponent.AddMaterialControllerData(dataAsset);
				}
			}
			return -1;
		}

		// Token: 0x06045A00 RID: 285184 RVA: 0x012312D0 File Offset: 0x0122F4D0
		[NullableContext(2)]
		private static void MaterialSpecRemoveMaterialControllerData(UKuroCharRenderingComponent renderComponent, int materialControllerHandle)
		{
			CharRenderingComponent charRenderingComponent = renderComponent as CharRenderingComponent;
			if (charRenderingComponent == null || materialControllerHandle == -1)
			{
				return;
			}
			charRenderingComponent.RemoveMaterialControllerData(materialControllerHandle);
		}

		// Token: 0x06045A01 RID: 285185 RVA: 0x012312F3 File Offset: 0x0122F4F3
		[NullableContext(2)]
		private static void MaterialSpecDestroyRenderingComponent(UKuroCharRenderingComponent renderComponent)
		{
			CharRenderingComponent charRenderingComponent = renderComponent as CharRenderingComponent;
			if (charRenderingComponent == null)
			{
				return;
			}
			charRenderingComponent.Destroy();
		}

		// Token: 0x06045A02 RID: 285186 RVA: 0x01231308 File Offset: 0x0122F508
		[NullableContext(2)]
		private static int EffectAudioControllerAddPlayEffectAudio(UEffectModelAudio effectModel, AActor effectActor, int effectType)
		{
			if (effectModel == null)
			{
				return 0;
			}
			return ControllerBase<EffectAudioController>.Instance.AddPlayEffectAudio(effectModel, effectActor, new EHitEffectType?((EHitEffectType)effectType), null, null, null);
		}

		// Token: 0x06045A03 RID: 285187 RVA: 0x0123134C File Offset: 0x0122F54C
		[NullableContext(2)]
		private static int EffectAudioControllerAddPlayEffectAudioPriority(UEffectModelAudio effectModel, AActor effectActor, int effectType, int priority)
		{
			if (effectModel == null)
			{
				return 0;
			}
			return ControllerBase<EffectAudioController>.Instance.AddPlayEffectAudio(effectModel, effectActor, new EHitEffectType?((EHitEffectType)effectType), new ERoleAudioPriorityType?((ERoleAudioPriorityType)priority), null, null);
		}

		// Token: 0x06045A04 RID: 285188 RVA: 0x0123138A File Offset: 0x0122F58A
		private static void EffectAudioControllerOnStopEffectAudio(int uid, string context)
		{
			ControllerBase<EffectAudioController>.Instance.OnStopEffectAudio(uid, context, true);
		}

		// Token: 0x04026D99 RID: 159129
		public bool PreviewInitState;

		// Token: 0x04026D9A RID: 159130
		private bool HasInitialize;

		// Token: 0x04026D9B RID: 159131
		private readonly OrderedDictionary<int, KuroEffectHandle> EffectHandleMap = new OrderedDictionary<int, KuroEffectHandle>();

		// Token: 0x04026D9C RID: 159132
		private readonly OrderedDictionary<int, KuroEffectActorHandle> EffectActorHandleMap = new OrderedDictionary<int, KuroEffectActorHandle>();

		// Token: 0x04026D9D RID: 159133
		private readonly OrderedDictionary<int, KuroEffectNiagaraComponentHandle> EffectNiagaraHandleMap = new OrderedDictionary<int, KuroEffectNiagaraComponentHandle>();

		// Token: 0x04026D9E RID: 159134
		private const string MIN_NIAGARA_SIMULATION_TICK_TIME = "0.033";

		// Token: 0x04026D9F RID: 159135
		private const int CHECK_EFFECT_OWNER_INTERVAL = 60000;

		// Token: 0x04026DA0 RID: 159136
		private const string EFFECT_SPEC_DATA_PATH = "../Config/Client/EffectData/";

		// Token: 0x04026DA1 RID: 159137
		[StaticVariableRuleIgnore]
		public static readonly HashSet<string> MOBILE_EFFECT_BLACK_LIST = new HashSet<string>
		{
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Sc2_FarCloud/DA_Fx_Sc2_FarCloud01.DA_Fx_Sc2_FarCloud01",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Sc2_FarCloud/DA_Fx_Sc2_FarCloud02.DA_Fx_Sc2_FarCloud02",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Sc2_FarCloud/DA_Fx_Sc2_FarCloud03.DA_Fx_Sc2_FarCloud03",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Sc2_FarCloud/DA_Fx_Sc2_FarCloud04.DA_Fx_Sc2_FarCloud04",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Sc2_FarCloud/DA_Fx_Sc2_FarCloud05.DA_Fx_Sc2_FarCloud05",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Sc2_FarCloud/DA_Fx_Sc2_FarCloud06.DA_Fx_Sc2_FarCloud06",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Sc2_FarCloud/DA_Fx_Sc2_FarCloud07.DA_Fx_Sc2_FarCloud07",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Sc2_FarCloud/DA_Fx_Sc2_FarCloud08.DA_Fx_Sc2_FarCloud08",
			"/Game/Aki/Scene/EffectDataAsset/DA_Base/DA_Fx_Luoye_03.DA_Fx_Luoye_03",
			"/Game/Aki/Scene/EffectDataAsset/DA_Base/DA_Fx_Sc3_luoye06.DA_Fx_Sc3_luoye06",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Luoye/DA_Fx_Luoye_06/DA_Fx_Sc3_luoye06_01.DA_Fx_Sc3_luoye06_01",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Fog/DA_Fx_Fog_001.DA_Fx_Fog_001",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Fog/DA_Fx_Fog_001_01.DA_Fx_Fog_001_01",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Fog/DA_Fx_Fog_001_02.DA_Fx_Fog_001_02",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Fog/DA_Fx_Fog_001_03.DA_Fx_Fog_001_03",
			"/Game/Aki/Scene/EffectDataAsset/DA_Base/DA_Fx_Sc2_MiddleFog.DA_Fx_Sc2_MiddleFog",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Fog/DA_Fx_Sc2_MiddleFog_01.DA_Fx_Sc2_MiddleFog_01",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Fog/DA_Fx_Sc2_MiddleFog_02.DA_Fx_Sc2_MiddleFog_02",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Fog/DA_Fx_Sc2_MiddleFog_03.DA_Fx_Sc2_MiddleFog_03",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Fog/DA_Fx_Sc2_MiddleFog_04.DA_Fx_Sc2_MiddleFog_04",
			"/Game/Aki/Effect/DataAsset/Niagara/Scene/Comnon/Smoke/DA_Fx_SC3_SmokFlow01.DA_Fx_SC3_SmokFlow01",
			"/Game/Aki/Scene/EffectDataAsset/DA_Base/DA_Fx_Luoye_01.DA_Fx_Luoye_01",
			"/Game/Aki/Scene/EffectDataAsset/DA_Base/DA_Fx_Luoye_01_bai.DA_Fx_Luoye_01_bai",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Luoye/DA_Fx_Luoye_01/DA_Fx_Luoye_01_01.DA_Fx_Luoye_01_01",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Luoye/DA_Fx_Luoye_01/DA_Fx_Luoye_01_02.DA_Fx_Luoye_01_02",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Luoye/DA_Fx_Luoye_01/DA_Fx_Luoye_01_03.DA_Fx_Luoye_01_03",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Luoye/DA_Fx_Luoye_01/DA_Fx_Luoye_01_bai_01.DA_Fx_Luoye_01_bai_01",
			"/Game/Aki/Scene/EffectDataAsset/DA_Base/DA_Fx_Luoye_02.DA_Fx_Luoye_02",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Luoye/DA_Fx_Luoye_02/DA_Fx_Luoye_02_1.DA_Fx_Luoye_02_1",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Luoye/DA_Fx_Luoye_02/DA_Fx_Luoye_02_2.DA_Fx_Luoye_02_2",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Luoye/DA_Fx_Luoye_02/DA_Fx_Luoye_02_3.DA_Fx_Luoye_02_3",
			"/Game/Aki/Scene/EffectDataAsset/DA_New/DA_Fx_Luoye/DA_Fx_Luoye_02/DA_Fx_Luoye_02_4.DA_Fx_Luoye_02_4",
			"/Game/Aki/Scene/EffectDataAsset/DA_Base/DA_Fx_Sc3_luoye05_zise.DA_Fx_Sc3_luoye05_zise",
			"/Game/Aki/Scene/EffectDataAsset/DA_Base/DA_Fx_Sc3_Chuiyan.DA_Fx_Sc3_Chuiyan",
			"/Game/Aki/Effect/DataAsset/Niagara/Scene/CXS/DA_Fx_SC2_CXS_BambooLeaf.DA_Fx_SC2_CXS_BambooLeaf",
			"/Game/Aki/Effect/DataAsset/Niagara/Scene/Cluster/Wind/DA_Fx_SC3_Cluster_WindSmoke.DA_Fx_SC3_Cluster_WindSmoke",
			"/Game/Aki/Effect/DataAsset/Niagara/Scene/CXS/DA_Fx_SC2_CXS_Steam.DA_Fx_SC2_CXS_Steam",
			"/Game/Aki/Effect/DataAsset/Niagara/Scene/Comnon/Leaf/DA_Fx_Sc2_Leaf01.DA_Fx_Sc2_Leaf01",
			"/Game/Aki/Effect/DataAsset/Niagara/Scene/Comnon/Leaf/DA_Fx_Sc2_Leaf01_1.DA_Fx_Sc2_Leaf01_1",
			"/Game/Aki/Effect/DataAsset/Niagara/Scene/Comnon/Leaf/DA_Fx_Sc2_Leaf02.DA_Fx_Sc2_Leaf02",
			"/Game/Aki/Effect/DataAsset/Niagara/Scene/Comnon/Leaf/DA_Fx_Sc2_Leaf03.DA_Fx_Sc2_Leaf03",
			"/Game/Aki/Effect/DataAsset/Niagara/Scene/Comnon/Leaf/DA_Fx_SC2_Leaf05_1.DA_Fx_SC2_Leaf05_1"
		};

		// Token: 0x04026DA2 RID: 159138
		private readonly TArray<FKuroSceneTeamItem> SceneTeamItems = new TArray<FKuroSceneTeamItem>();

		// Token: 0x04026DA3 RID: 159139
		private readonly List<SpecData> EffectForSpecArray = new List<SpecData>();

		// Token: 0x04026DA4 RID: 159140
		private readonly List<EffectSpecData> EffectForSpecDbCacheArray = new List<EffectSpecData>();

		// Token: 0x04026DA5 RID: 159141
		private float CheckEffectOwnerInterval = 60000f;

		// Token: 0x0200CC7A RID: 52346
		[NullableContext(0)]
		private enum EEffectContextType : byte
		{
			// Token: 0x0403EADF RID: 256735
			EEffectContextType_Base,
			// Token: 0x0403EAE0 RID: 256736
			EEffectContextType_Skeletal,
			// Token: 0x0403EAE1 RID: 256737
			EEffectContextType_Audio,
			// Token: 0x0403EAE2 RID: 256738
			EEffectContextType_Ghost
		}

		// Token: 0x0200CC7B RID: 52347
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403EAE3 RID: 256739
			[Nullable(0)]
			public static Action <0>__OnTimeScaleChange;

			// Token: 0x0403EAE4 RID: 256740
			[Nullable(0)]
			public static Action <1>__OnSetNiagaraQuality;

			// Token: 0x0403EAE5 RID: 256741
			[Nullable(0)]
			public static Action<EKuroUI3DState> <2>__OnGlobalUiSceneStateChanged;

			// Token: 0x0403EAE6 RID: 256742
			[Nullable(0)]
			public static Action<bool> <3>__OnSetGamePaused;

			// Token: 0x0403EAE7 RID: 256743
			[Nullable(new byte[]
			{
				0,
				2,
				2,
				2,
				2
			})]
			public static Func<float, UActorComponent, USkeletalMeshComponent, AActor, UActorComponent> <4>__SkeletalMeshSpecOnBodyEffectChange;

			// Token: 0x0403EAE8 RID: 256744
			[Nullable(new byte[]
			{
				0,
				2,
				2,
				2,
				2
			})]
			public static Func<UActorComponent, USkeletalMeshComponent, AActor, UActorComponent> <5>__SkeletalMeshSpecCreateRenderingComponent;

			// Token: 0x0403EAE9 RID: 256745
			[Nullable(new byte[]
			{
				0,
				2,
				2
			})]
			public static Action<AActor, UActorComponent> <6>__SkeletalMeshSpecDestroyRenderingComponent;

			// Token: 0x0403EAEA RID: 256746
			[Nullable(new byte[]
			{
				0,
				2
			})]
			public static Func<int, AActor> <7>__EffectHandleGetEntityOwnerActor;

			// Token: 0x0403EAEB RID: 256747
			[Nullable(0)]
			public static Func<int, int> <8>__EffectHandleGetEntityModelConfigId;

			// Token: 0x0403EAEC RID: 256748
			[Nullable(0)]
			public static Func<float, FName> <9>__EffectHandleGetOrAddEffectDynamicGroup;

			// Token: 0x0403EAED RID: 256749
			[Nullable(new byte[]
			{
				0,
				2,
				2
			})]
			public static Func<bool, AActor, UAkComponent> <10>__AudioSystemGetAkComponent;

			// Token: 0x0403EAEE RID: 256750
			[Nullable(0)]
			public static Action<int, float> <11>__AudioSystemExecuteActionStop;

			// Token: 0x0403EAEF RID: 256751
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Func<string, FTransformDouble, int> <12>__AudioSystemPostEventTransform;

			// Token: 0x0403EAF0 RID: 256752
			[Nullable(new byte[]
			{
				0,
				1,
				2
			})]
			public static Func<string, UAkComponent, int> <13>__AudioSystemPostEventAkComponent;

			// Token: 0x0403EAF1 RID: 256753
			[Nullable(0)]
			public static Func<int, bool> <14>__NiagaraSpecIsNeedQualityBias;

			// Token: 0x0403EAF2 RID: 256754
			[Nullable(0)]
			public static Func<int, bool, bool> <15>__PostProcessSpecIsNeedPostEffect;

			// Token: 0x0403EAF3 RID: 256755
			[Nullable(0)]
			public static Func<int, bool> <16>__PostProcessSpecIsDisableInUltraSkill;

			// Token: 0x0403EAF4 RID: 256756
			[Nullable(0)]
			public static FActorSystemGetRetVal.FActorSystemGetRetVal_ScriptDelegate <17>__ActorSystemGet;

			// Token: 0x0403EAF5 RID: 256757
			[Nullable(new byte[]
			{
				0,
				1,
				2
			})]
			public static Func<string, AActor, bool> <18>__ActorSystemPut;

			// Token: 0x0403EAF6 RID: 256758
			[Nullable(new byte[]
			{
				0,
				2
			})]
			public static Action<AActor, int> <19>__EffectSystemSetEffectView;

			// Token: 0x0403EAF7 RID: 256759
			[Nullable(0)]
			public static Func<int, bool> <20>__EffectSystemCheckIsNetPlayer;

			// Token: 0x0403EAF8 RID: 256760
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Func<string, bool> <21>__EffectSystemCheckMobileBlackEffect;

			// Token: 0x0403EAF9 RID: 256761
			[Nullable(new byte[]
			{
				0,
				2,
				2,
				2,
				2
			})]
			public static Action<int, AActor, USkeletalMeshComponent, UObject, UEffectModelBase> <22>__EffectSpecRegisterBodyEffect;

			// Token: 0x0403EAFA RID: 256762
			[Nullable(new byte[]
			{
				0,
				2,
				2,
				2,
				2
			})]
			public static Action<int, AActor, USkeletalMeshComponent, UObject, UEffectModelBase> <23>__EffectSpecUnregisterBodyEffect;

			// Token: 0x0403EAFB RID: 256763
			[Nullable(new byte[]
			{
				0,
				2,
				2
			})]
			public static Func<int, UObject, UKuroCharRenderingComponent> <24>__MaterialSpecGetRenderingComponentByContext;

			// Token: 0x0403EAFC RID: 256764
			[Nullable(new byte[]
			{
				0,
				2,
				2
			})]
			public static Func<USkeletalMeshComponent, UKuroCharRenderingComponent> <25>__MaterialSpecGetRenderingComponentBySkeletal;

			// Token: 0x0403EAFD RID: 256765
			[Nullable(new byte[]
			{
				0,
				2,
				2
			})]
			public static Func<USkeletalMeshComponent, AActor> <26>__MaterialSpecSpawnRenderActor;

			// Token: 0x0403EAFE RID: 256766
			[Nullable(new byte[]
			{
				0,
				2,
				2,
				2
			})]
			public static Func<AActor, USkeletalMeshComponent, UKuroCharRenderingComponent> <27>__MaterialSpecGetRenderingComponentByRenderActor;

			// Token: 0x0403EAFF RID: 256767
			[Nullable(new byte[]
			{
				0,
				2,
				2
			})]
			public static Func<UKuroCharRenderingComponent, UKuroMaterialControllerDataAsset, int> <28>__MaterialSpecAddMaterialControllerData;

			// Token: 0x0403EB00 RID: 256768
			[Nullable(new byte[]
			{
				0,
				2
			})]
			public static Action<UKuroCharRenderingComponent, int> <29>__MaterialSpecRemoveMaterialControllerData;

			// Token: 0x0403EB01 RID: 256769
			[Nullable(new byte[]
			{
				0,
				2
			})]
			public static Action<UKuroCharRenderingComponent> <30>__MaterialSpecDestroyRenderingComponent;

			// Token: 0x0403EB02 RID: 256770
			[Nullable(new byte[]
			{
				0,
				2,
				2
			})]
			public static Func<UEffectModelAudio, AActor, int, int> <31>__EffectAudioControllerAddPlayEffectAudio;

			// Token: 0x0403EB03 RID: 256771
			[Nullable(new byte[]
			{
				0,
				2,
				2
			})]
			public static Func<UEffectModelAudio, AActor, int, int, int> <32>__EffectAudioControllerAddPlayEffectAudioPriority;

			// Token: 0x0403EB04 RID: 256772
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Action<int, string> <33>__EffectAudioControllerOnStopEffectAudio;
		}
	}
}
