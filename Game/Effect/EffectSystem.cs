using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Common.Struct;
using CSharpScript.Core.Common;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

namespace CSharpScript.Game.Effect
{
	// Token: 0x02007047 RID: 28743
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class EffectSystem : Singleton<EffectSystem>, ITickable
	{
		// Token: 0x060458EB RID: 284907 RVA: 0x0122DB88 File Offset: 0x0122BD88
		public bool Initialize()
		{
			UKuroEffectSystemFunctionLibrary.SetUseDebugDrawNew(true);
			return this.KuroEffectSystemInstance.Initialize();
		}

		// Token: 0x060458EC RID: 284908 RVA: 0x0122DB9B File Offset: 0x0122BD9B
		public bool Clear()
		{
			return this.KuroEffectSystemInstance.Clear();
		}

		// Token: 0x060458ED RID: 284909 RVA: 0x0122DBA8 File Offset: 0x0122BDA8
		public void InitializeWithPreview(bool refresh)
		{
			if (Singleton<Info>.Instance.IsGameRunning())
			{
				return;
			}
			if (!this.KuroEffectSystemInstance.PreviewInitState)
			{
				this.KuroEffectSystemInstance.InitializeWithPreview(refresh);
			}
		}

		// Token: 0x060458EE RID: 284910 RVA: 0x0122DBD1 File Offset: 0x0122BDD1
		public void Tick(float delta)
		{
			this.KuroEffectSystemInstance.Tick(delta);
		}

		// Token: 0x060458EF RID: 284911 RVA: 0x0122DBDF File Offset: 0x0122BDDF
		public void AfterTick(float delta)
		{
		}

		// Token: 0x060458F0 RID: 284912 RVA: 0x0122DBE1 File Offset: 0x0122BDE1
		public void ClearPool()
		{
			this.KuroEffectSystemInstance.ClearPool();
		}

		// Token: 0x060458F1 RID: 284913 RVA: 0x0122DBF0 File Offset: 0x0122BDF0
		public int SpawnEffectWithActor(UObject worldContext, [Nullable(2)] AActor actor, string path, string reason, bool autoPlay = true, [Nullable(2)] EffectContext context = null, bool isExternalActor = true, EEffectType effectType = EEffectType.Scene)
		{
			return this.KuroEffectSystemInstance.SpawnEffectWithActor(worldContext, actor, path, reason, autoPlay, context, isExternalActor, effectType);
		}

		// Token: 0x060458F2 RID: 284914 RVA: 0x0122DC15 File Offset: 0x0122BE15
		public void RemoveKuroEffectHandle(int effectId)
		{
			this.KuroEffectSystemInstance.RemoveKuroEffectHandle(effectId);
		}

		// Token: 0x060458F3 RID: 284915 RVA: 0x0122DC23 File Offset: 0x0122BE23
		public int GetEffectLruCount(string path)
		{
			return this.KuroEffectSystemInstance.GetEffectLruCount(path);
		}

		// Token: 0x060458F4 RID: 284916 RVA: 0x0122DC31 File Offset: 0x0122BE31
		public int GetEffectLruCapacity()
		{
			return this.KuroEffectSystemInstance.GetEffectLruCapacity();
		}

		// Token: 0x060458F5 RID: 284917 RVA: 0x0122DC3E File Offset: 0x0122BE3E
		public void SetEffectLruCapacity(int capacity)
		{
			this.KuroEffectSystemInstance.SetEffectLruCapacity(capacity);
		}

		// Token: 0x060458F6 RID: 284918 RVA: 0x0122DC4C File Offset: 0x0122BE4C
		public int GetEffectLruSize()
		{
			return this.KuroEffectSystemInstance.GetEffectLruSize();
		}

		// Token: 0x060458F7 RID: 284919 RVA: 0x0122DC5C File Offset: 0x0122BE5C
		[NullableContext(2)]
		public int SpawnUnloopedEffect(UObject worldContext, in FTransformDouble? transform, string path, [Nullable(1)] string reason, EffectContext context = null, EEffectType effectType = EEffectType.Scene, Action<int> beforeInitCallback = null, Action<ELoadEffectResult, int> callback = null, Action<int> beforePlayCallback = null, bool prepare = false, bool forceCreateActor = false)
		{
			if (path != null && EffectSystem.EFFECT_BLACK_LIST.Contains(path))
			{
				return 0;
			}
			return this.KuroEffectSystemInstance.SpawnUnloopedEffect(worldContext, transform, path, reason, context, effectType, beforeInitCallback, callback, beforePlayCallback, prepare, forceCreateActor);
		}

		// Token: 0x060458F8 RID: 284920 RVA: 0x0122DC9C File Offset: 0x0122BE9C
		[NullableContext(2)]
		public int SpawnEffect(UObject worldContext, in FTransformDouble? transform, string path, [Nullable(1)] string reason, EffectContext context = null, EEffectType effectType = EEffectType.Scene, Action<int> beforeInitCallback = null, Action<ELoadEffectResult, int> callback = null, Action<int> beforePlayCallback = null, bool prepare = false, bool forceCreateActor = false)
		{
			if (path != null && EffectSystem.EFFECT_BLACK_LIST.Contains(path))
			{
				return 0;
			}
			return this.KuroEffectSystemInstance.SpawnEffect(worldContext, transform, path, reason, context, effectType, beforeInitCallback, callback, beforePlayCallback, prepare, forceCreateActor);
		}

		// Token: 0x060458F9 RID: 284921 RVA: 0x0122DCD9 File Offset: 0x0122BED9
		public void DynamicRegisterSpawnCallback(int effectId, Action<ELoadEffectResult, int> callback)
		{
			this.KuroEffectSystemInstance.DynamicRegisterSpawnCallback(effectId, callback);
		}

		// Token: 0x060458FA RID: 284922 RVA: 0x0122DCE8 File Offset: 0x0122BEE8
		public void ForceCheckPendingInit(int handle)
		{
			this.KuroEffectSystemInstance.ForceCheckPendingInit(handle);
		}

		// Token: 0x060458FB RID: 284923 RVA: 0x0122DCF6 File Offset: 0x0122BEF6
		[NullableContext(2)]
		public void SetEffectHidden(int handle, bool bHidden, string reason = null, bool isLogic = false)
		{
			this.KuroEffectSystemInstance.SetEffectHidden(handle, bHidden, reason, isLogic);
		}

		// Token: 0x060458FC RID: 284924 RVA: 0x0122DD08 File Offset: 0x0122BF08
		public bool StopEffectById(int handle, string reason, bool immediately, bool? destroyActor = null)
		{
			return this.KuroEffectSystemInstance.StopEffectById(handle, reason, immediately, destroyActor);
		}

		// Token: 0x060458FD RID: 284925 RVA: 0x0122DD1A File Offset: 0x0122BF1A
		public bool IsValid(int id)
		{
			return this.KuroEffectSystemInstance.IsValid(id);
		}

		// Token: 0x060458FE RID: 284926 RVA: 0x0122DD28 File Offset: 0x0122BF28
		public void AddFinishCallback(int id, Action<int> callback)
		{
			this.KuroEffectSystemInstance.AddFinishCallback(id, callback);
		}

		// Token: 0x060458FF RID: 284927 RVA: 0x0122DD37 File Offset: 0x0122BF37
		public void RemoveFinishCallback(int id, Action<int> callback)
		{
			this.KuroEffectSystemInstance.RemoveFinishCallback(id, callback);
		}

		// Token: 0x06045900 RID: 284928 RVA: 0x0122DD46 File Offset: 0x0122BF46
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public OneOf<KuroEffectActorHandle, AActor> GetEffectActor(int id)
		{
			return this.KuroEffectSystemInstance.GetEffectActor(id);
		}

		// Token: 0x06045901 RID: 284929 RVA: 0x0122DD54 File Offset: 0x0122BF54
		[NullableContext(2)]
		public AActor GetSureEffectActor(int id)
		{
			return this.KuroEffectSystemInstance.GetSureEffectActor(id);
		}

		// Token: 0x06045902 RID: 284930 RVA: 0x0122DD62 File Offset: 0x0122BF62
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public OneOf<KuroEffectNiagaraComponentHandle, UNiagaraComponent> GetNiagaraComponent(int id)
		{
			return this.KuroEffectSystemInstance.GetNiagaraComponent(id);
		}

		// Token: 0x06045903 RID: 284931 RVA: 0x0122DD70 File Offset: 0x0122BF70
		[NullableContext(2)]
		public UNiagaraComponent GetSureNiagaraComponent(int id)
		{
			return this.KuroEffectSystemInstance.GetSureNiagaraComponent(id);
		}

		// Token: 0x06045904 RID: 284932 RVA: 0x0122DD7E File Offset: 0x0122BF7E
		public void ReplayEffect(int id, string reason, in FTransformDouble? transform = null)
		{
			this.KuroEffectSystemInstance.ReplayEffect(id, reason, transform);
		}

		// Token: 0x06045905 RID: 284933 RVA: 0x0122DD8E File Offset: 0x0122BF8E
		public bool IsPlaying(int id)
		{
			return this.KuroEffectSystemInstance.IsPlaying(id);
		}

		// Token: 0x06045906 RID: 284934 RVA: 0x0122DD9C File Offset: 0x0122BF9C
		public void SetHandleLifeCycle(int id, float time)
		{
			this.KuroEffectSystemInstance.SetHandleLifeCycle(id, time);
		}

		// Token: 0x06045907 RID: 284935 RVA: 0x0122DDAB File Offset: 0x0122BFAB
		public void SetTimeScale(int id, float timeScale, bool ignoreGlobalTimeScale = false)
		{
			this.KuroEffectSystemInstance.SetTimeScale(id, timeScale, ignoreGlobalTimeScale);
		}

		// Token: 0x06045908 RID: 284936 RVA: 0x0122DDBB File Offset: 0x0122BFBB
		public void SetAdditionTimeScale(ETimeScaleSourceType sourceType, int id, float timeScale)
		{
			this.KuroEffectSystemInstance.SetAdditionTimeScale((int)sourceType, id, timeScale);
		}

		// Token: 0x06045909 RID: 284937 RVA: 0x0122DDCB File Offset: 0x0122BFCB
		public void SetAdditionTimeScaleEnable(ETimeScaleSourceType sourceType, bool enable)
		{
			this.KuroEffectSystemInstance.SetAdditionTimeScaleEnable((int)sourceType, enable);
		}

		// Token: 0x0604590A RID: 284938 RVA: 0x0122DDDA File Offset: 0x0122BFDA
		public bool GetAdditionTimeScaleEnable(ETimeScaleSourceType sourceType)
		{
			return this.KuroEffectSystemInstance.GetAdditionTimeScaleEnable((int)sourceType);
		}

		// Token: 0x0604590B RID: 284939 RVA: 0x0122DDE8 File Offset: 0x0122BFE8
		public void FreezeHandle(int id, bool freeze, bool force = false)
		{
			this.KuroEffectSystemInstance.FreezeHandle(id, freeze, force);
		}

		// Token: 0x0604590C RID: 284940 RVA: 0x0122DDF8 File Offset: 0x0122BFF8
		public bool IsHandleFreeze(int id)
		{
			return this.KuroEffectSystemInstance.IsHandleFreeze(id);
		}

		// Token: 0x0604590D RID: 284941 RVA: 0x0122DE06 File Offset: 0x0122C006
		public bool HandleSeekToTime(int id, float time, bool autoLoop, bool force = false)
		{
			return this.KuroEffectSystemInstance.HandleSeekToTime(id, time, autoLoop, force);
		}

		// Token: 0x0604590E RID: 284942 RVA: 0x0122DE18 File Offset: 0x0122C018
		public void HandleSeekToTimeWithProcess(int id, float time, bool seekContinue = false, float delta = -1f)
		{
			this.KuroEffectSystemInstance.HandleSeekToTimeWithProcess(id, time, seekContinue, delta);
		}

		// Token: 0x0604590F RID: 284943 RVA: 0x0122DE2A File Offset: 0x0122C02A
		public float GetSeekToTargetTime(int id)
		{
			return this.KuroEffectSystemInstance.GetSeekToTargetTime(id);
		}

		// Token: 0x06045910 RID: 284944 RVA: 0x0122DE38 File Offset: 0x0122C038
		public void SetEffectNotRecord(int id, bool notRecord = true)
		{
			this.KuroEffectSystemInstance.SetEffectNotRecord(id, notRecord);
		}

		// Token: 0x06045911 RID: 284945 RVA: 0x0122DE47 File Offset: 0x0122C047
		public string GetPath(int id)
		{
			return this.KuroEffectSystemInstance.GetPath(id);
		}

		// Token: 0x06045912 RID: 284946 RVA: 0x0122DE55 File Offset: 0x0122C055
		public void SetEffectDataByNiagaraParam(int id, SNiagaraParam niagaraParam, bool resetPassTime)
		{
			this.KuroEffectSystemInstance.SetEffectDataByNiagaraParam(id, niagaraParam, resetPassTime);
		}

		// Token: 0x06045913 RID: 284947 RVA: 0x0122DE65 File Offset: 0x0122C065
		[NullableContext(2)]
		public void SetEffectParameterNiagara(int id, EffectParameterNiagara parameter)
		{
			this.KuroEffectSystemInstance.SetEffectParameterNiagara(id, parameter);
		}

		// Token: 0x06045914 RID: 284948 RVA: 0x0122DE74 File Offset: 0x0122C074
		public void SetEffectDataFloatConstParam(int id, in FName paramName, float value)
		{
			this.KuroEffectSystemInstance.SetEffectDataFloatConstParam(id, paramName, value);
		}

		// Token: 0x06045915 RID: 284949 RVA: 0x0122DE84 File Offset: 0x0122C084
		public void SetEffectExtraState(int effectId, int extraState)
		{
			this.KuroEffectSystemInstance.SetEffectExtraState(effectId, extraState);
		}

		// Token: 0x06045916 RID: 284950 RVA: 0x0122DE93 File Offset: 0x0122C093
		public void SetEffectIgnoreVisibilityOptimize(int effectId, bool ignore)
		{
			this.KuroEffectSystemInstance.SetEffectIgnoreVisibilityOptimize(effectId, ignore);
		}

		// Token: 0x06045917 RID: 284951 RVA: 0x0122DEA2 File Offset: 0x0122C0A2
		public void SetEffectStoppingTime(int effectId, bool stoppingTime)
		{
			this.KuroEffectSystemInstance.SetEffectStoppingTime(effectId, stoppingTime);
		}

		// Token: 0x1700A523 RID: 42275
		// (get) Token: 0x06045918 RID: 284952 RVA: 0x0122DEB1 File Offset: 0x0122C0B1
		public float GlobalStoppingPlayTime
		{
			get
			{
				return this.KuroEffectSystemInstance.GlobalStoppingPlayTime();
			}
		}

		// Token: 0x1700A524 RID: 42276
		// (get) Token: 0x06045919 RID: 284953 RVA: 0x0122DEBE File Offset: 0x0122C0BE
		public bool GlobalStoppingTime
		{
			get
			{
				return this.KuroEffectSystemInstance.GlobalStoppingTime();
			}
		}

		// Token: 0x0604591A RID: 284954 RVA: 0x0122DECB File Offset: 0x0122C0CB
		public void SetGlobalStoppingTime(bool stoppingTime, float playTime)
		{
			this.KuroEffectSystemInstance.SetGlobalStoppingTime(stoppingTime, playTime);
		}

		// Token: 0x0604591B RID: 284955 RVA: 0x0122DEDA File Offset: 0x0122C0DA
		public void AttachToEffectSkeletalMesh(int id, AActor attachActor, in FName? socketName, EAttachmentRule transformRule)
		{
			this.KuroEffectSystemInstance.AttachToEffectSkeletalMesh(id, attachActor, socketName, transformRule);
		}

		// Token: 0x0604591C RID: 284956 RVA: 0x0122DEEC File Offset: 0x0122C0EC
		public void AttachSkeletalMesh(int id, SkeletalMeshEffectContext context)
		{
			this.KuroEffectSystemInstance.AttachSkeletalMesh(id, context);
		}

		// Token: 0x0604591D RID: 284957 RVA: 0x0122DEFB File Offset: 0x0122C0FB
		public void CollectMaterialFloatCurve(int id, in FName key, FKuroCurveFloat value)
		{
			this.KuroEffectSystemInstance.CollectMaterialFloatCurve(id, key, value);
		}

		// Token: 0x0604591E RID: 284958 RVA: 0x0122DF0B File Offset: 0x0122C10B
		public void CollectMaterialVectorCurve(int id, in FName key, FKuroCurveVector value)
		{
			this.KuroEffectSystemInstance.CollectMaterialVectorCurve(id, key, value);
		}

		// Token: 0x0604591F RID: 284959 RVA: 0x0122DF1B File Offset: 0x0122C11B
		public void CollectMaterialLinearColorCurve(int id, in FName key, FKuroCurveLinearColor value)
		{
			this.KuroEffectSystemInstance.CollectMaterialLinearColorCurve(id, key, value);
		}

		// Token: 0x06045920 RID: 284960 RVA: 0x0122DF2B File Offset: 0x0122C12B
		[NullableContext(2)]
		public UEffectModelBase GetEffectModel(int id)
		{
			return this.KuroEffectSystemInstance.GetEffectModel(id);
		}

		// Token: 0x06045921 RID: 284961 RVA: 0x0122DF39 File Offset: 0x0122C139
		public float GetTotalPassTime(int id)
		{
			return this.KuroEffectSystemInstance.GetTotalPassTime(id);
		}

		// Token: 0x06045922 RID: 284962 RVA: 0x0122DF47 File Offset: 0x0122C147
		public float GetPassTime(int id)
		{
			return this.KuroEffectSystemInstance.GetPassTime(id);
		}

		// Token: 0x06045923 RID: 284963 RVA: 0x0122DF55 File Offset: 0x0122C155
		public bool GetHideOnBurstSkill(int id)
		{
			return this.KuroEffectSystemInstance.GetHideOnBurstSkill(id);
		}

		// Token: 0x06045924 RID: 284964 RVA: 0x0122DF63 File Offset: 0x0122C163
		public void RegisterCustomCheckOwnerFunc(int id, Func<int, bool> func)
		{
			this.KuroEffectSystemInstance.RegisterCustomCheckOwnerFunc(id, func);
		}

		// Token: 0x06045925 RID: 284965 RVA: 0x0122DF74 File Offset: 0x0122C174
		public void EnableNiagaraDownSampling()
		{
			Singleton<Log>.Instance.Info(ELogModule.RenderEffect, ELogAuthor.WLJ, "Enable Niagara Down Sampling", default(ReadOnlySpan<ValueTuple<string, object>>));
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Kuro.Niagara.SystemSimulation.TickOptimizeEnable 1", null);
		}

		// Token: 0x06045926 RID: 284966 RVA: 0x0122DFB0 File Offset: 0x0122C1B0
		public void DisableNiagaraDownSampling()
		{
			Singleton<Log>.Instance.Info(ELogModule.RenderEffect, ELogAuthor.WLJ, "Disable Niagara Down Sampling", default(ReadOnlySpan<ValueTuple<string, object>>));
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "Kuro.Niagara.SystemSimulation.TickOptimizeEnable 0", null);
		}

		// Token: 0x06045927 RID: 284967 RVA: 0x0122DFE9 File Offset: 0x0122C1E9
		public void SetEffectQualityLevel(int id, int qualityLevel)
		{
			this.KuroEffectSystemInstance.SetEffectQualityLevel(id, qualityLevel);
		}

		// Token: 0x06045928 RID: 284968 RVA: 0x0122DFF8 File Offset: 0x0122C1F8
		public void TickHandleInEditor(int id, float delta)
		{
			this.KuroEffectSystemInstance.TickHandleInEditor(id, delta);
		}

		// Token: 0x06045929 RID: 284969 RVA: 0x0122E007 File Offset: 0x0122C207
		public float GetLastPlayTime(int id)
		{
			return this.KuroEffectSystemInstance.GetLastPlayTime(id);
		}

		// Token: 0x0604592A RID: 284970 RVA: 0x0122E015 File Offset: 0x0122C215
		public float GetLastStopTime(int id)
		{
			return this.KuroEffectSystemInstance.GetLastStopTime(id);
		}

		// Token: 0x0604592B RID: 284971 RVA: 0x0122E023 File Offset: 0x0122C223
		public void UpdateBodyEffect(int id, float opacity, bool visible, bool castShadow)
		{
			this.KuroEffectSystemInstance.UpdateBodyEffect(id, opacity, visible, castShadow);
		}

		// Token: 0x0604592C RID: 284972 RVA: 0x0122E035 File Offset: 0x0122C235
		public void DebugUpdate(int id, bool dDebugUpdate)
		{
			this.KuroEffectSystemInstance.DebugUpdate(id, dDebugUpdate);
		}

		// Token: 0x0604592D RID: 284973 RVA: 0x0122E044 File Offset: 0x0122C244
		public int GetEffectCount()
		{
			return this.KuroEffectSystemInstance.GetEffectCount();
		}

		// Token: 0x0604592E RID: 284974 RVA: 0x0122E051 File Offset: 0x0122C251
		public int GetActiveEffectCount()
		{
			return this.KuroEffectSystemInstance.GetActiveEffectCount();
		}

		// Token: 0x0604592F RID: 284975 RVA: 0x0122E05E File Offset: 0x0122C25E
		public void DebugPrintAllErrorEffects()
		{
			this.KuroEffectSystemInstance.DebugPrintAllErrorEffects();
		}

		// Token: 0x06045930 RID: 284976 RVA: 0x0122E06B File Offset: 0x0122C26B
		public void DebugPrintCurrentImportanceEffects()
		{
			this.KuroEffectSystemInstance.DebugPrintCurrentImportanceEffects();
		}

		// Token: 0x06045931 RID: 284977 RVA: 0x0122E078 File Offset: 0x0122C278
		public void DebugPrintEffect()
		{
			this.KuroEffectSystemInstance.DebugPrintEffect();
		}

		// Token: 0x06045932 RID: 284978 RVA: 0x0122E085 File Offset: 0x0122C285
		public int GetPlayerEffectLruSize(int pos)
		{
			return this.KuroEffectSystemInstance.GetPlayerEffectLruSize(pos);
		}

		// Token: 0x06045933 RID: 284979 RVA: 0x0122E093 File Offset: 0x0122C293
		public void SetEffectStartRecording(Vector tempVector, Vector centerLocation, float recordDistSquared, Action<int, AActor> onEffectRecorded)
		{
			this.KuroEffectSystemInstance.SetEffectStartRecording(tempVector, centerLocation, recordDistSquared, onEffectRecorded);
		}

		// Token: 0x06045934 RID: 284980 RVA: 0x0122E0A5 File Offset: 0x0122C2A5
		public static void RefreshEffectSpecData(Dictionary<string, SpecData> specDataMap)
		{
			Singleton<EffectSystem>.Instance.KuroEffectSystemInstance.RefreshEffectSpecData(specDataMap);
		}

		// Token: 0x04026D70 RID: 159088
		public const int EFFECT_REASON_LENGTH_LIMIT = 4;

		// Token: 0x04026D71 RID: 159089
		public const int EFFECT_LIFETIME_FLOAT_TO_INT = 10000;

		// Token: 0x04026D72 RID: 159090
		[StaticVariableRuleIgnore]
		private static readonly HashSet<string> EFFECT_BLACK_LIST = new HashSet<string>
		{
			"/Game/Aki/Scene/EffectDataAsset/DA_Base/DA_ClusterStuff/Dust/DA_Fx_Sc3_Cluster_Dust_PMMD.DA_Fx_Sc3_Cluster_Dust_PMMD"
		};

		// Token: 0x04026D73 RID: 159091
		private readonly KuroEffectSystem KuroEffectSystemInstance = new KuroEffectSystem();
	}
}
