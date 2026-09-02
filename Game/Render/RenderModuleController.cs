using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Battle;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Manager;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200477F RID: 18303
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class RenderModuleController : ControllerBase<RenderModuleController>
	{
		// Token: 0x170081AA RID: 33194
		// (get) Token: 0x0602F778 RID: 194424 RVA: 0x00B485C1 File Offset: 0x00B467C1
		protected override bool IsTickEvenPausedInternal
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0602F779 RID: 194425 RVA: 0x00B485C4 File Offset: 0x00B467C4
		public FTransformDouble? GetKuroCurrentUiSceneTransform()
		{
			return this.UiSceneOffsetTransform;
		}

		// Token: 0x0602F77A RID: 194426 RVA: 0x00B485CC File Offset: 0x00B467CC
		public FVectorDouble GetKuroUiSceneLoadOffset()
		{
			if (this.IsDynamicOffset)
			{
				AActor myRoleTriggerOrUndefined = ControllerBase<RoleTriggerController>.Instance.GetMyRoleTriggerOrUndefined();
				if (myRoleTriggerOrUndefined != null && myRoleTriggerOrUndefined.IsValid())
				{
					FVectorDouble result = myRoleTriggerOrUndefined.D_K2_GetActorLocation();
					result.Z += 50000.0;
					return result;
				}
			}
			return this.KuroUiSceneLoadOffset;
		}

		// Token: 0x0602F77B RID: 194427 RVA: 0x00B4861A File Offset: 0x00B4681A
		public void SetKuroUiSceneLoadOffset(FVectorDouble offset)
		{
			this.KuroUiSceneLoadOffset = offset;
		}

		// Token: 0x0602F77C RID: 194428 RVA: 0x00B48623 File Offset: 0x00B46823
		public void ResetKuroUiSceneLoadOffset()
		{
			this.KuroUiSceneLoadOffset = new FVectorDouble(150000.0, 150000.0, 150000.0);
		}

		// Token: 0x0602F77D RID: 194429 RVA: 0x00B4864C File Offset: 0x00B4684C
		private bool CheckDataLayerDependenciesMatch(string dataLayerName)
		{
			HashSet<string> hashSet;
			this.hardCodeDataLayerDependencies.TryGetValue(dataLayerName, out hashSet);
			bool flag = true;
			if (hashSet != null && hashSet.Count > 0)
			{
				foreach (string key in hashSet)
				{
					flag = (flag && UKuroRenderingRuntimeBPPluginBPLibrary.IsWorldPartitionDataLayerEnable(GlobalData.World, FNameUtil.GetDynamicFName(key) ?? FName.NAME_None));
					if (!flag)
					{
						break;
					}
				}
			}
			return flag;
		}

		// Token: 0x0602F77E RID: 194430 RVA: 0x00B486E8 File Offset: 0x00B468E8
		public unsafe void SetWorldPartitionDataLayerState(string dataLayerName, bool isEnable, bool bKeepLoadIfDisable = false)
		{
			if (isEnable && !this.CheckDataLayerDependenciesMatch(dataLayerName))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.World;
				ELogAuthor author = ELogAuthor.ZYL;
				string message = "[SetWorldPartitionDataLayerState]激活DataLayer前，发现依赖不满足，停止激活DataLayer，并加进DependenciesNotMatchDataLayerSet中";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("dataLayerName", dataLayerName);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				ModelBase<RenderModuleModel>.Instance.AddDependenciesNotMatchDataLayer(dataLayerName);
				return;
			}
			if (ModelManagerBase<ModelManager>.Instance.IsInit && ModelBase<RenderModuleModel>.Instance.IsDependenciesNotMatchDataLayer(dataLayerName))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.World;
				ELogAuthor author2 = ELogAuthor.ZYL;
				string message2 = "[SetWorldPartitionDataLayerState]激活/停用DataLayer时，发现其在DependenciesNotMatchDataLayerSet中，移除";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("dataLayerName", dataLayerName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("isEnable", isEnable);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				ModelBase<RenderModuleModel>.Instance.RemoveDependenciesNotMatchDataLayer(dataLayerName);
			}
			EDataLayerState newState = isEnable ? EDataLayerState.Activated : (bKeepLoadIfDisable ? EDataLayerState.Loaded : EDataLayerState.Unloaded);
			UKuroRenderingRuntimeBPPluginBPLibrary.SetWorldPartitionDataLayerState2(GlobalData.World, FNameUtil.GetDynamicFName(dataLayerName) ?? FName.NAME_None, newState);
			this.AfterSetWorldPartitionDataLayerState(dataLayerName, isEnable, bKeepLoadIfDisable);
		}

		// Token: 0x0602F77F RID: 194431 RVA: 0x00B487F0 File Offset: 0x00B469F0
		private unsafe void AfterSetWorldPartitionDataLayerState(string dataLayerName, bool isEnable, bool bKeepLoadIfDisable)
		{
			EDataLayerState newState = isEnable ? EDataLayerState.Activated : (bKeepLoadIfDisable ? EDataLayerState.Loaded : EDataLayerState.Unloaded);
			HashSet<string> hashSet;
			this.hardCodeReversedDataLayerDependencies.TryGetValue(dataLayerName, out hashSet);
			if (isEnable)
			{
				if (hashSet == null || hashSet.Count == 0)
				{
					return;
				}
				foreach (string text in hashSet)
				{
					if (ModelManagerBase<ModelManager>.Instance.IsInit && ModelBase<RenderModuleModel>.Instance.IsDependenciesNotMatchDataLayer(text) && this.CheckDataLayerDependenciesMatch(text))
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.World;
						ELogAuthor author = ELogAuthor.ZYL;
						string message = "[SetWorldPartitionDataLayerState]激活DataLayer后，发现有本该激活的RelatedDataLayer依赖都已满足，激活relatedDataLayer";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("dataLayerName", dataLayerName);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("relatedDataLayer", text);
						instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						ModelBase<RenderModuleModel>.Instance.RemoveDependenciesNotMatchDataLayer(text);
						UKuroRenderingRuntimeBPPluginBPLibrary.SetWorldPartitionDataLayerState2(GlobalData.World, FNameUtil.GetDynamicFName(text) ?? FName.NAME_None, newState);
					}
				}
				return;
			}
			else
			{
				if (hashSet == null || hashSet.Count == 0)
				{
					return;
				}
				foreach (string text2 in hashSet)
				{
					if (UKuroRenderingRuntimeBPPluginBPLibrary.IsWorldPartitionDataLayerEnable(GlobalData.World, FNameUtil.GetDynamicFName(text2) ?? FName.NAME_None))
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.World;
						ELogAuthor author2 = ELogAuthor.ZYL;
						string message2 = "[SetWorldPartitionDataLayerState]停用DataLayer后，发现有已激活的RelatedDataLayer依赖当前DataLayer，停用RelatedDataLayer";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("dataLayerName", dataLayerName);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("relatedDataLayer", text2);
						instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
						if (ModelManagerBase<ModelManager>.Instance.IsInit)
						{
							ModelBase<RenderModuleModel>.Instance.AddDependenciesNotMatchDataLayer(text2);
						}
						UKuroRenderingRuntimeBPPluginBPLibrary.SetWorldPartitionDataLayerState2(GlobalData.World, FNameUtil.GetDynamicFName(text2) ?? FName.NAME_None, newState);
					}
				}
				return;
			}
		}

		// Token: 0x0602F780 RID: 194432 RVA: 0x00B48A38 File Offset: 0x00B46C38
		public bool IsWorldPartitionDataLayerEnable(string dataLayerName)
		{
			return UKuroRenderingRuntimeBPPluginBPLibrary.IsWorldPartitionDataLayerEnable(GlobalData.World, FNameUtil.GetDynamicFName(dataLayerName) ?? FName.NAME_None) || (ModelManagerBase<ModelManager>.Instance.IsInit && ModelBase<RenderModuleModel>.Instance.IsDependenciesNotMatchDataLayer(dataLayerName));
		}

		// Token: 0x0602F781 RID: 194433 RVA: 0x00B48A8A File Offset: 0x00B46C8A
		public void AddBattleReference(FVectorDouble location)
		{
			ModelBase<RenderModuleModel>.Instance.AddBattleReference(location);
		}

		// Token: 0x0602F782 RID: 194434 RVA: 0x00B48A97 File Offset: 0x00B46C97
		public void DecBattleReference()
		{
			ModelBase<RenderModuleModel>.Instance.DecBattleReference();
		}

		// Token: 0x0602F783 RID: 194435 RVA: 0x00B48AA3 File Offset: 0x00B46CA3
		public EWuYinQuState GetCurrentKeyState(string actorKey)
		{
			return ModelBase<RenderModuleModel>.Instance.GetCurrentKeyState(actorKey);
		}

		// Token: 0x0602F784 RID: 194436 RVA: 0x00B48AB0 File Offset: 0x00B46CB0
		public bool GetIdleClearAtmosphere(string actorKey)
		{
			return ModelBase<RenderModuleModel>.Instance.GetIdleClearAtmosphere(actorKey);
		}

		// Token: 0x0602F785 RID: 194437 RVA: 0x00B48ABD File Offset: 0x00B46CBD
		public void SetBattleState(string key, EWuYinQuState state, bool instantTransition = false)
		{
			if (ModelManagerBase<ModelManager>.Instance.IsInit)
			{
				ModelBase<RenderModuleModel>.Instance.SetBattleState(key, state, instantTransition);
			}
		}

		// Token: 0x0602F786 RID: 194438 RVA: 0x00B48AD8 File Offset: 0x00B46CD8
		public TArray<string> GetWuYinQuBattleDebugInfo()
		{
			return ModelBase<RenderModuleModel>.Instance.GetWuYinQuBattleDebugInfo();
		}

		// Token: 0x0602F787 RID: 194439 RVA: 0x00B48AE4 File Offset: 0x00B46CE4
		public EWuYinQuState GetBattleState(string key)
		{
			return ModelBase<RenderModuleModel>.Instance.GetBattleState(key);
		}

		// Token: 0x0602F788 RID: 194440 RVA: 0x00B48AF1 File Offset: 0x00B46CF1
		[NullableContext(2)]
		public string GetCurrentBattleKey()
		{
			return ModelBase<RenderModuleModel>.Instance.GetCurrentBattleKey();
		}

		// Token: 0x0602F789 RID: 194441 RVA: 0x00B48AFD File Offset: 0x00B46CFD
		public void AddWuYinQuBattleActorWaiting(WuYinQuBattleActor actor)
		{
			if (this.WaitingForAddWuYinQuBattleActors == null)
			{
				this.WaitingForAddWuYinQuBattleActors = new List<WuYinQuBattleActor>();
			}
			this.WaitingForAddWuYinQuBattleActors.Add(actor);
		}

		// Token: 0x0602F78A RID: 194442 RVA: 0x00B48B1E File Offset: 0x00B46D1E
		public bool AddWuYinQuBattleActor(WuYinQuBattleActor actor)
		{
			return ModelManagerBase<ModelManager>.Instance.IsInit && ModelBase<RenderModuleModel>.Instance.AddWuYinQuBattleActor(actor);
		}

		// Token: 0x0602F78B RID: 194443 RVA: 0x00B48B39 File Offset: 0x00B46D39
		public bool RemoveWuYinQuBattleActor(WuYinQuBattleActor actor)
		{
			return ModelManagerBase<ModelManager>.Instance.IsInit && ModelBase<RenderModuleModel>.Instance.RemoveWuYinQuBattleActor(actor);
		}

		// Token: 0x0602F78C RID: 194444 RVA: 0x00B48B54 File Offset: 0x00B46D54
		public void AddTickableObject(IRenderModuleTickableObject obj)
		{
			ModelBase<RenderModuleModel>.Instance.AddTickableObject(obj);
		}

		// Token: 0x0602F78D RID: 194445 RVA: 0x00B48B61 File Offset: 0x00B46D61
		public void RemoveTickableObject(IRenderModuleTickableObject obj)
		{
			if (ModelManagerBase<ModelManager>.Instance.IsInit)
			{
				ModelBase<RenderModuleModel>.Instance.RemoveTickableObject(obj);
			}
		}

		// Token: 0x0602F78E RID: 194446 RVA: 0x00B48B7A File Offset: 0x00B46D7A
		public void AddCharRenderShell(CharRenderingComponent charRenderingComponent)
		{
			ModelBase<RenderModuleModel>.Instance.AddCharRenderShell(charRenderingComponent);
		}

		// Token: 0x0602F78F RID: 194447 RVA: 0x00B48B87 File Offset: 0x00B46D87
		public bool RemoveCharRenderShell(CharRenderingComponent charRenderingComponent)
		{
			return ModelManagerBase<ModelManager>.Instance.IsInit && ModelBase<RenderModuleModel>.Instance.RemoveCharRenderShell(charRenderingComponent);
		}

		// Token: 0x0602F790 RID: 194448 RVA: 0x00B48BA2 File Offset: 0x00B46DA2
		public int GetRainIntensity()
		{
			return (int)ModelBase<RenderModuleModel>.Instance.GetRainIntensity();
		}

		// Token: 0x0602F791 RID: 194449 RVA: 0x00B48BAF File Offset: 0x00B46DAF
		public int GetSnowIntensity()
		{
			return (int)ModelBase<RenderModuleModel>.Instance.GetSnowIntensity();
		}

		// Token: 0x0602F792 RID: 194450 RVA: 0x00B48BBC File Offset: 0x00B46DBC
		public bool IsRuntime()
		{
			return this.Inited;
		}

		// Token: 0x0602F793 RID: 194451 RVA: 0x00B48BC4 File Offset: 0x00B46DC4
		protected override bool OnInit()
		{
			RenderStats.Init();
			this.DebugUiSceneLoadOffset = new FVectorDouble?(new FVectorDouble());
			this.UiSceneOffsetTransform = new FTransformDouble?(new FTransformDouble());
			this.Inited = true;
			Singleton<EventSystem>.Instance.Add<int>(EEventName.OnBossFight, new Action<int>(this.OnBossFight));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnBattleStateChanged, new Action<bool>(this.BattleStateChanged));
			Singleton<TickSystem>.Instance.Add(new Action<float>(this.DoTick), "RenderModuleController", ETickingGroup.TG_EndPhysics, true, 0, false);
			if (UKuroStaticLibrary.IsLowMemoryDevice())
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "wp.Runtime.UseUnloadCache false", null);
			}
			return true;
		}

		// Token: 0x0602F794 RID: 194452 RVA: 0x00B48C6D File Offset: 0x00B46E6D
		private void OnBossFight(int entityId)
		{
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.GlobalGIRenderQuality 1", null);
		}

		// Token: 0x0602F795 RID: 194453 RVA: 0x00B48C7F File Offset: 0x00B46E7F
		private void BattleStateChanged(bool isGameInBattle)
		{
			if (!isGameInBattle)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.GlobalGIRenderQuality 0", null);
			}
		}

		// Token: 0x0602F796 RID: 194454 RVA: 0x00B48C94 File Offset: 0x00B46E94
		protected override bool OnClear()
		{
			this.Inited = false;
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnBossFight, new Action<int>(this.OnBossFight));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnBattleStateChanged, new Action<bool>(this.BattleStateChanged));
			return true;
		}

		// Token: 0x0602F797 RID: 194455 RVA: 0x00B48CE1 File Offset: 0x00B46EE1
		protected override void OnTick(float delta)
		{
		}

		// Token: 0x0602F798 RID: 194456 RVA: 0x00B48CE4 File Offset: 0x00B46EE4
		private void DoTick(float delta)
		{
			if (!this.Inited)
			{
				return;
			}
			this.IsGamePaused = Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.GlobalTimeDilation, 0.0, null);
			if (this.WaitingForAddWuYinQuBattleActors != null && this.WaitingForAddWuYinQuBattleActors.Count != 0)
			{
				foreach (WuYinQuBattleActor actor in this.WaitingForAddWuYinQuBattleActors)
				{
					this.AddWuYinQuBattleActor(actor);
				}
				this.WaitingForAddWuYinQuBattleActors = new List<WuYinQuBattleActor>();
			}
			ModelBase<RenderModuleModel>.Instance.Tick(delta);
		}

		// Token: 0x0401B1E1 RID: 111073
		private readonly Dictionary<string, HashSet<string>> hardCodeDataLayerDependencies = new Dictionary<string, HashSet<string>>
		{
			{
				"DataLayerRuntime_DLTask_30FGL03",
				new HashSet<string>
				{
					"DataLayerRuntime_DLTask_30FGL02"
				}
			},
			{
				"DataLayerRuntime_DLTask_30FGL04",
				new HashSet<string>
				{
					"DataLayerRuntime_DLTask_30FGL02"
				}
			},
			{
				"DataLayerRuntime_DLTask_30FGL05",
				new HashSet<string>
				{
					"DataLayerRuntime_DLTask_30FGL02"
				}
			}
		};

		// Token: 0x0401B1E2 RID: 111074
		private readonly Dictionary<string, HashSet<string>> hardCodeReversedDataLayerDependencies = new Dictionary<string, HashSet<string>>
		{
			{
				"DataLayerRuntime_DLTask_30FGL02",
				new HashSet<string>
				{
					"DataLayerRuntime_DLTask_30FGL03",
					"DataLayerRuntime_DLTask_30FGL04",
					"DataLayerRuntime_DLTask_30FGL05"
				}
			}
		};

		// Token: 0x0401B1E3 RID: 111075
		private bool Inited;

		// Token: 0x0401B1E4 RID: 111076
		private const bool TickInPrePhysics = false;

		// Token: 0x0401B1E5 RID: 111077
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<WuYinQuBattleActor> WaitingForAddWuYinQuBattleActors;

		// Token: 0x0401B1E6 RID: 111078
		public bool IsGamePaused;

		// Token: 0x0401B1E7 RID: 111079
		public float GlobalTimeDilation = 1f;

		// Token: 0x0401B1E8 RID: 111080
		public bool DebugNewUiSceneWorkflow = true;

		// Token: 0x0401B1E9 RID: 111081
		public FVectorDouble? DebugUiSceneLoadOffset;

		// Token: 0x0401B1EA RID: 111082
		public FTransformDouble? UiSceneOffsetTransform;

		// Token: 0x0401B1EB RID: 111083
		public bool DebugStartShowingUiSceneRendering;

		// Token: 0x0401B1EC RID: 111084
		public bool DebugInUiSceneRendering;

		// Token: 0x0401B1ED RID: 111085
		public bool IsDynamicOffset;

		// Token: 0x0401B1EE RID: 111086
		private FVectorDouble KuroUiSceneLoadOffset = new FVectorDouble(150000.0, 150000.0, 150000.0);
	}
}
