using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.KuroSimpleCombat;
using CSharpScript.Game.KuroSimpleCombat.PB;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;
using KuroSimpleCombat.KscAction;
using UnrealEngine;

// Token: 0x02000F32 RID: 3890
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class KuroSimpleCombatController : ControllerBase<KuroSimpleCombatController>
{
	// Token: 0x17000721 RID: 1825
	// (get) Token: 0x06006122 RID: 24866 RVA: 0x00184CD7 File Offset: 0x00182ED7
	public bool MapInit
	{
		get
		{
			return this.IsMapInit;
		}
	}

	// Token: 0x17000722 RID: 1826
	// (get) Token: 0x06006123 RID: 24867 RVA: 0x00184CDF File Offset: 0x00182EDF
	public bool WorldInit
	{
		get
		{
			return this.IsWorldInit;
		}
	}

	// Token: 0x06006124 RID: 24868 RVA: 0x00184CE7 File Offset: 0x00182EE7
	public void RegisterPendingAdd(long creatureId, KscActionEntityAdd action)
	{
		this.PendingAdds[creatureId] = action;
	}

	// Token: 0x06006125 RID: 24869 RVA: 0x00184CF8 File Offset: 0x00182EF8
	public void UnregisterPendingAdd(long creatureId, KscActionEntityAdd action)
	{
		KscActionEntityAdd kscActionEntityAdd;
		if (this.PendingAdds.TryGetValue(creatureId, out kscActionEntityAdd) && kscActionEntityAdd == action)
		{
			this.PendingAdds.Remove(creatureId);
		}
	}

	// Token: 0x06006126 RID: 24870 RVA: 0x00184D28 File Offset: 0x00182F28
	private bool CancelPendingAddIfAny(long creatureId)
	{
		KscActionEntityAdd kscActionEntityAdd;
		if (!this.PendingAdds.TryGetValue(creatureId, out kscActionEntityAdd))
		{
			return false;
		}
		this.PendingAdds.Remove(creatureId);
		kscActionEntityAdd.Task.Cancel();
		return true;
	}

	// Token: 0x06006127 RID: 24871 RVA: 0x00184D60 File Offset: 0x00182F60
	private void CancelPendingActionsForEntity(long creatureId)
	{
		KscSubModelBase curSubModel = this.CurSubModel;
		if (curSubModel == null)
		{
			return;
		}
		UiAsyncTaskManager entityProcessMgr = curSubModel.EntityProcessMgr;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
		defaultInterpolatedStringHandler.AppendLiteral("KscAction_[");
		defaultInterpolatedStringHandler.AppendFormatted<long>(creatureId);
		defaultInterpolatedStringHandler.AppendLiteral("]");
		entityProcessMgr.CancelPendingByName(defaultInterpolatedStringHandler.ToStringAndClear());
	}

	// Token: 0x17000723 RID: 1827
	// (get) Token: 0x06006128 RID: 24872 RVA: 0x00184DB3 File Offset: 0x00182FB3
	[Nullable(2)]
	public KscSubModelBase CurSubModel
	{
		[NullableContext(2)]
		get
		{
			KscSubControllerBase curSubController = this.CurSubController;
			if (curSubController == null)
			{
				return null;
			}
			return curSubController.Model;
		}
	}

	// Token: 0x06006129 RID: 24873 RVA: 0x00184DC8 File Offset: 0x00182FC8
	[NullableContext(2)]
	public KscSubControllerBase GetSubController(EKscGameplayType kscGameplayType)
	{
		KscSubControllerBase result;
		if (!this.SubControllerMap.TryGetValue(kscGameplayType, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0600612A RID: 24874 RVA: 0x00184DE8 File Offset: 0x00182FE8
	[NullableContext(2)]
	public KscSubModelBase GetSubModel(EKscGameplayType kscGameplayType)
	{
		KscSubControllerBase subController = this.GetSubController(kscGameplayType);
		if (subController == null)
		{
			return null;
		}
		return subController.Model;
	}

	// Token: 0x0600612B RID: 24875 RVA: 0x00184DFC File Offset: 0x00182FFC
	protected override bool OnInit()
	{
		base.PauseTick();
		foreach (KeyValuePair<EKscGameplayType, KscSubControllerBase> keyValuePair in this.SubControllerMap)
		{
			keyValuePair.Value.Init(keyValuePair.Key);
		}
		Singleton<EventSystem>.Instance.Add(EEventName.OnSetGameModeDataDone, new Action(this.OnGameModeDataChange));
		Singleton<EventSystem>.Instance.Add(EEventName.AfterLoadMap, new Action(this.OnAfterLoadMap));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add(EEventName.ClearWorld, new Action(this.OnWorldReset));
		Singleton<Net>.Instance.Register<SimpleCombatEntityBuffUpdateNotify>(ENotifyMessageId.SimpleCombatEntityBuffUpdateNotify, new Action<SimpleCombatEntityBuffUpdateNotify, Net.CallbackStatus>(this.SimpleCombatEntityBuffUpdateNotify));
		Singleton<Net>.Instance.Register<SimpleCombatEntityBuffLayerCountNotify>(ENotifyMessageId.SimpleCombatEntityBuffLayerCountNotify, new Action<SimpleCombatEntityBuffLayerCountNotify, Net.CallbackStatus>(this.SimpleCombatEntityBuffLayerCountNotify));
		Singleton<Net>.Instance.Register<SimpleCombatEntitySubTypeChangeNotify>(ENotifyMessageId.SimpleCombatEntitySubTypeChangeNotify, new Action<SimpleCombatEntitySubTypeChangeNotify, Net.CallbackStatus>(this.SimpleCombatEntitySubTypeChangeNotify));
		Singleton<Net>.Instance.Register<SimpleCombatEntityAttributeUpdateNotify>(ENotifyMessageId.SimpleCombatEntityAttributeUpdateNotify, new Action<SimpleCombatEntityAttributeUpdateNotify, Net.CallbackStatus>(this.SimpleCombatEntityAttributeUpdateNotify));
		Singleton<Net>.Instance.Register<SimpleCombatBeginNotify>(ENotifyMessageId.SimpleCombatBeginNotify, new Action<SimpleCombatBeginNotify, Net.CallbackStatus>(this.SimpleCombatBeginNotify));
		Singleton<Net>.Instance.Register<SimpleCombatEndNotify>(ENotifyMessageId.SimpleCombatEndNotify, new Action<SimpleCombatEndNotify, Net.CallbackStatus>(this.SimpleCombatEndNotify));
		return true;
	}

	// Token: 0x0600612C RID: 24876 RVA: 0x00184F7C File Offset: 0x0018317C
	protected override bool OnClear()
	{
		foreach (KscSubControllerBase kscSubControllerBase in this.SubControllerMap.Values)
		{
			kscSubControllerBase.Clear();
		}
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSetGameModeDataDone, new Action(this.OnGameModeDataChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.AfterLoadMap, new Action(this.OnAfterLoadMap));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.ClearWorld, new Action(this.OnWorldReset));
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SimpleCombatEntityBuffUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SimpleCombatEntityBuffLayerCountNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SimpleCombatEntityAttributeUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SimpleCombatBeginNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SimpleCombatEndNotify);
		this.StopKscHeadStateManager();
		this.ResetObservedLifecycleStage();
		return true;
	}

	// Token: 0x0600612D RID: 24877 RVA: 0x001850A0 File Offset: 0x001832A0
	protected override bool OnLeaveLevel()
	{
		this.StopKscHeadStateManager();
		return true;
	}

	// Token: 0x0600612E RID: 24878 RVA: 0x001850AC File Offset: 0x001832AC
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	protected override ValueTuple<string, CustomPromise<bool>>? OnPreload()
	{
		this.ObserveLifecycleStage(EKscObservedLifecycleStage.Preload, "OnPreload");
		KscSubControllerBase curSubController = this.CurSubController;
		if (curSubController == null)
		{
			return null;
		}
		return curSubController.OnPreload();
	}

	// Token: 0x0600612F RID: 24879 RVA: 0x001850E0 File Offset: 0x001832E0
	private unsafe void ObserveLifecycleStage(EKscObservedLifecycleStage stage, string source)
	{
		this.ObservedLifecycleStages.Add(stage);
		KscLog.EModule flag = KscLog.EModule.Common;
		ELogAuthor author = ELogAuthor.TZQ;
		UObject obj = null;
		string log = "KSC记录观测生命周期阶段";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("source", source);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("observedStage", stage);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("observedStages", this.ObservedLifecycleStages);
		KscLog.Debug(flag, author, obj, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x06006130 RID: 24880 RVA: 0x00185169 File Offset: 0x00183369
	private void ResetObservedLifecycleStage()
	{
		this.ObservedLifecycleStages.Clear();
	}

	// Token: 0x06006131 RID: 24881 RVA: 0x00185176 File Offset: 0x00183376
	private bool HasObservedLifecycleStage(EKscObservedLifecycleStage stage)
	{
		return this.ObservedLifecycleStages.Contains(stage);
	}

	// Token: 0x06006132 RID: 24882 RVA: 0x00185184 File Offset: 0x00183384
	[NullableContext(2)]
	private KscSubControllerBase FindSubControllerByInstSubType(int instSubType)
	{
		foreach (KscSubControllerBase kscSubControllerBase in this.SubControllerMap.Values)
		{
			if (kscSubControllerBase.IsTargetMap(instSubType))
			{
				return kscSubControllerBase;
			}
		}
		return null;
	}

	// Token: 0x06006133 RID: 24883 RVA: 0x001851E8 File Offset: 0x001833E8
	[NullableContext(2)]
	private KscSubControllerBase ResolveSubControllerForLifecycle()
	{
		GameModeModel instance = ModelBase<GameModeModel>.Instance;
		InstanceDungeon? instanceDungeon;
		int? num = (instance != null) ? ((instance.InstanceDungeon != null) ? new int?(instanceDungeon.GetValueOrDefault().InstSubType) : null) : null;
		KscSubControllerBase kscSubControllerBase = (ControllerBase<GameModeController>.Instance.IsInInstance() && num != null) ? this.FindSubControllerByInstSubType(num.Value) : null;
		if (kscSubControllerBase != null)
		{
			this.CurSubController = kscSubControllerBase;
			return kscSubControllerBase;
		}
		return this.CurSubController;
	}

	// Token: 0x06006134 RID: 24884 RVA: 0x00185274 File Offset: 0x00183474
	private bool TryInitMap(string source)
	{
		KscSubControllerBase kscSubControllerBase = this.ResolveSubControllerForLifecycle();
		if (kscSubControllerBase == null)
		{
			return false;
		}
		kscSubControllerBase.InitMap();
		this.IsMapInit = true;
		return true;
	}

	// Token: 0x06006135 RID: 24885 RVA: 0x0018529C File Offset: 0x0018349C
	private bool TryMapLoaded(string source)
	{
		if (this.CurSubController == null)
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.TZQ;
			UObject obj = null;
			string log = "KSC缺少子控制器,忽略MapLoaded";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("source", source);
			KscLog.Debug(flag, author, obj, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		this.CurSubController.MapLoaded();
		this.IsWorldInit = true;
		return true;
	}

	// Token: 0x06006136 RID: 24886 RVA: 0x001852E8 File Offset: 0x001834E8
	private bool TryWorldDone(string source)
	{
		if (this.CurSubController == null)
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.TZQ;
			UObject obj = null;
			string log = "KSC缺少子控制器,忽略WorldDone";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("source", source);
			KscLog.Debug(flag, author, obj, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		this.CurSubController.WorldDone();
		base.ResumeTick();
		return true;
	}

	// Token: 0x06006137 RID: 24887 RVA: 0x00185334 File Offset: 0x00183534
	private UniTask CatchUpObservedLifecycleAfterOpenAsync(string source, [Nullable(2)] KscSubControllerBase expectedSubController = null)
	{
		KuroSimpleCombatController.<CatchUpObservedLifecycleAfterOpenAsync>d__31 <CatchUpObservedLifecycleAfterOpenAsync>d__;
		<CatchUpObservedLifecycleAfterOpenAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CatchUpObservedLifecycleAfterOpenAsync>d__.<>4__this = this;
		<CatchUpObservedLifecycleAfterOpenAsync>d__.source = source;
		<CatchUpObservedLifecycleAfterOpenAsync>d__.expectedSubController = expectedSubController;
		<CatchUpObservedLifecycleAfterOpenAsync>d__.<>1__state = -1;
		<CatchUpObservedLifecycleAfterOpenAsync>d__.<>t__builder.Start<KuroSimpleCombatController.<CatchUpObservedLifecycleAfterOpenAsync>d__31>(ref <CatchUpObservedLifecycleAfterOpenAsync>d__);
		return <CatchUpObservedLifecycleAfterOpenAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006138 RID: 24888 RVA: 0x00185388 File Offset: 0x00183588
	private void TryCatchUpObservedLifecycleAfterOpen(string source)
	{
		if (this.ObservedLifecycleStages.Count == 0)
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.TZQ;
			UObject obj = null;
			string log = "KSC打开玩法后等待后续生命周期事件";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("source", source);
			KscLog.Debug(flag, author, obj, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.CatchUpObservedLifecycleAfterOpenAsync(source, this.CurSubController).Forget();
	}

	// Token: 0x06006139 RID: 24889 RVA: 0x001853D7 File Offset: 0x001835D7
	private void OnGameModeDataChange()
	{
		this.ObserveLifecycleStage(EKscObservedLifecycleStage.InitMap, "OnSetGameModeDataDone");
		this.TryInitMap("OnSetGameModeDataDone");
	}

	// Token: 0x0600613A RID: 24890 RVA: 0x001853F1 File Offset: 0x001835F1
	private void OnAfterLoadMap()
	{
		this.ObserveLifecycleStage(EKscObservedLifecycleStage.MapLoad, "AfterLoadMap");
		this.TryMapLoaded("AfterLoadMap");
	}

	// Token: 0x0600613B RID: 24891 RVA: 0x0018540B File Offset: 0x0018360B
	private void OnWorldDone()
	{
		this.ObserveLifecycleStage(EKscObservedLifecycleStage.WorldDone, "WorldDoneAndCloseLoading");
		this.TryWorldDone("WorldDoneAndCloseLoading");
	}

	// Token: 0x0600613C RID: 24892 RVA: 0x00185428 File Offset: 0x00183628
	private void OpenWorldByGameplayType(EKscGameplayType gamePlayType)
	{
		if (this.CurSubController != null)
		{
			KscLog.Debug(KscLog.EModule.Common, ELogAuthor.TZQ, null, "当前已经在KSC玩法中", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		KscSubControllerBase curSubController;
		if (!this.SubControllerMap.TryGetValue(gamePlayType, out curSubController))
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.TZQ;
			UObject obj = null;
			string log = "GamePlayType 不合法";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("gamePlayType", gamePlayType);
			KscLog.Debug(flag, author, obj, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		KscLog.EModule flag2 = KscLog.EModule.Common;
		ELogAuthor author2 = ELogAuthor.TZQ;
		UObject obj2 = null;
		string log2 = "打开KSCWorld";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("gamePlayType", gamePlayType);
		KscLog.Info(flag2, author2, obj2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		this.CurSubController = curSubController;
		this.TryCatchUpObservedLifecycleAfterOpen("OpenWorldByGameplayType");
	}

	// Token: 0x0600613D RID: 24893 RVA: 0x001854C8 File Offset: 0x001836C8
	[NullableContext(2)]
	private void CloseCurrentWorld(KscSubControllerBase expectedSubController = null)
	{
		if (this.CurSubController == null)
		{
			KscLog.Error(KscLog.EModule.Common, ELogAuthor.TZQ, null, "当前不在KSC玩法中", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (expectedSubController != null && this.CurSubController != expectedSubController)
		{
			KscLog.Error(KscLog.EModule.Common, ELogAuthor.TZQ, null, "当前不是目标KSC玩法", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		KscLog.Info(KscLog.EModule.Common, ELogAuthor.TZQ, null, "关闭KSCWorld", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.OnWorldReset();
	}

	// Token: 0x0600613E RID: 24894 RVA: 0x00185538 File Offset: 0x00183738
	private void OnWorldReset()
	{
		if (this.IsWorldInit)
		{
			this.IsWorldInit = false;
			KscSubModelBase curSubModel = this.CurSubModel;
			if (curSubModel != null)
			{
				curSubModel.EntityProcessMgr.LogInfo("CancelAllTask Before");
			}
			KscSubModelBase curSubModel2 = this.CurSubModel;
			if (curSubModel2 != null)
			{
				curSubModel2.EntityProcessMgr.CancelAllTask();
			}
			this.PendingAdds.Clear();
			KscSubControllerBase curSubController = this.CurSubController;
			if (curSubController != null)
			{
				curSubController.WorldReset();
			}
		}
		if (this.IsMapInit)
		{
			this.IsMapInit = false;
			KscSubControllerBase curSubController2 = this.CurSubController;
			if (curSubController2 != null)
			{
				curSubController2.ClearMap();
			}
		}
		this.ResetObservedLifecycleStage();
		this.EntityPositions.Empty(true);
		this.CurSubController = null;
		base.PauseTick();
	}

	// Token: 0x0600613F RID: 24895 RVA: 0x001855E0 File Offset: 0x001837E0
	protected override void OnTick(float delta)
	{
		UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		if (kscWorld == null)
		{
			return;
		}
		KscSubControllerBase curSubController = this.CurSubController;
		if (curSubController != null)
		{
			curSubController.Tick(delta);
		}
		kscWorld.GetEntityPositionsEx(ref this.EntityPositions);
		TowerDefensePlayerController.SyncMainLocations(delta);
	}

	// Token: 0x06006140 RID: 24896 RVA: 0x00185620 File Offset: 0x00183820
	[NullableContext(2)]
	public string GetSkillPathDt(int id)
	{
		ValueTuple<FKSCSkillTableRow, string> valueTuple;
		if (!this.CurSubModel.SkillDataDt.TryGetValue(id, out valueTuple))
		{
			return null;
		}
		return valueTuple.Item2;
	}

	// Token: 0x06006141 RID: 24897 RVA: 0x0018564C File Offset: 0x0018384C
	[NullableContext(2)]
	public FKSCSkillTableRow GetSkillRowDt(int id)
	{
		ValueTuple<FKSCSkillTableRow, string> valueTuple;
		if (!this.CurSubModel.SkillDataDt.TryGetValue(id, out valueTuple))
		{
			return null;
		}
		return valueTuple.Item1;
	}

	// Token: 0x06006142 RID: 24898 RVA: 0x00185678 File Offset: 0x00183878
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public ValueTuple<FKSCSkillTableRow, string>? GetSkillDataDt(int id)
	{
		ValueTuple<FKSCSkillTableRow, string> value;
		if (!this.CurSubModel.SkillDataDt.TryGetValue(id, out value))
		{
			return null;
		}
		return new ValueTuple<FKSCSkillTableRow, string>?(value);
	}

	// Token: 0x06006143 RID: 24899 RVA: 0x001856AA File Offset: 0x001838AA
	[return: Nullable(new byte[]
	{
		1,
		0,
		1,
		1
	})]
	public Dictionary<int, ValueTuple<FKSCSkillTableRow, string>> GetAllSkillDataDt()
	{
		return this.CurSubModel.SkillDataDt;
	}

	// Token: 0x06006144 RID: 24900 RVA: 0x001856B8 File Offset: 0x001838B8
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public UniTask<Dictionary<int, UKSC_DA_Buff>> LoadBuffAssets(int[] buffKeys)
	{
		KuroSimpleCombatController.<LoadBuffAssets>d__45 <LoadBuffAssets>d__;
		<LoadBuffAssets>d__.<>t__builder = AsyncUniTaskMethodBuilder<Dictionary<int, UKSC_DA_Buff>>.Create();
		<LoadBuffAssets>d__.buffKeys = buffKeys;
		<LoadBuffAssets>d__.<>1__state = -1;
		<LoadBuffAssets>d__.<>t__builder.Start<KuroSimpleCombatController.<LoadBuffAssets>d__45>(ref <LoadBuffAssets>d__);
		return <LoadBuffAssets>d__.<>t__builder.Task;
	}

	// Token: 0x06006145 RID: 24901 RVA: 0x001856FC File Offset: 0x001838FC
	[return: Nullable(2)]
	public unsafe AKSC_Entity AddEntityImpl(UKSC_DA_Entity asset, IKscEntityParam params_)
	{
		UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		AKSC_Entity aksc_Entity;
		if (kscWorld == null)
		{
			aksc_Entity = null;
		}
		else
		{
			FTransformDouble transform = params_.Transform;
			aksc_Entity = kscWorld.D_AddDaEntity(asset, transform, params_.IsPreview.GetValueOrDefault(), (int)params_.CreatureId);
		}
		AKSC_Entity aksc_Entity2 = aksc_Entity;
		if (aksc_Entity2 != null)
		{
			if (params_.Faction != null)
			{
				KscLog.EModule flag = KscLog.EModule.Common;
				ELogAuthor author = ELogAuthor.PZ;
				UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
				string log = "Ksc设置战斗派系";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ksc entity", aksc_Entity2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("faction", params_.Faction);
				KscLog.Debug(flag, author, kscWorld2, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				aksc_Entity2.SetFaction(params_.Faction.Value);
			}
			if (asset is UKSC_DA_Entity_Enemy && params_.Spline != null)
			{
				KscLog.EModule flag2 = KscLog.EModule.Common;
				ELogAuthor author2 = ELogAuthor.PZ;
				UObject kscWorld3 = Singleton<KscEnv>.Instance.KscWorld;
				string log2 = "Ksc设置样条";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("ksc entity", aksc_Entity2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("spline", params_.Spline);
				KscLog.Debug(flag2, author2, kscWorld3, log2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				UKSC_Move_Spline uksc_Move_Spline = aksc_Entity2.GetMoveComponent() as UKSC_Move_Spline;
				if (uksc_Move_Spline != null)
				{
					uksc_Move_Spline.SetSpline(params_.Spline);
				}
			}
			if (asset is UKSC_DA_Entity_Tower && params_.RenderActor != null)
			{
				KscLog.EModule flag3 = KscLog.EModule.Common;
				ELogAuthor author3 = ELogAuthor.PZ;
				UObject kscWorld4 = Singleton<KscEnv>.Instance.KscWorld;
				string log3 = "Ksc设置渲染对象";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("ksc entity", aksc_Entity2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("renderActor", params_.RenderActor);
				KscLog.Debug(flag3, author3, kscWorld4, log3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
				aksc_Entity2.SetRenderActor(params_.RenderActor);
			}
			KscEntityHandle value = new KscEntityHandle(aksc_Entity2, params_.CreatureId);
			KscLog.EModule flag4 = KscLog.EModule.Common;
			ELogAuthor author4 = ELogAuthor.PZ;
			UObject kscWorld5 = Singleton<KscEnv>.Instance.KscWorld;
			string log4 = "Ksc加入战斗实体";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("creature", params_.CreatureId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("EntityId", aksc_Entity2.EntityId_);
			KscLog.Debug(flag4, author4, kscWorld5, log4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
			this.CurSubModel.KscEntities[aksc_Entity2.EntityId_] = value;
			this.CurSubController.SetAttrs(aksc_Entity2, params_.PropertyId, params_.AttributeMap);
			this.CurSubModel.SetLogicProxy(params_.CreatureId, aksc_Entity2.EntityId_);
			return aksc_Entity2;
		}
		KscLog.EModule flag5 = KscLog.EModule.Common;
		ELogAuthor author5 = ELogAuthor.PZ;
		UObject kscWorld6 = Singleton<KscEnv>.Instance.KscWorld;
		string log5 = "加入战斗实体失败";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("asset", asset);
		KscLog.Warn(flag5, author5, kscWorld6, log5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x06006146 RID: 24902 RVA: 0x001859C8 File Offset: 0x00183BC8
	public void AsyncAddEntity(IKscEntityParam params_)
	{
		KscActionEntityAdd kscActionEntityAdd = new KscActionEntityAdd(params_);
		KscSubModelBase curSubModel = this.CurSubModel;
		if (curSubModel == null)
		{
			return;
		}
		curSubModel.EntityProcessMgr.RunTask(kscActionEntityAdd.Task);
	}

	// Token: 0x06006147 RID: 24903 RVA: 0x001859F8 File Offset: 0x00183BF8
	public unsafe void RemoveEntityImpl(int kscEntityId, FName removeReason)
	{
		KscEntityHandle kscEntityHandle;
		if (!this.CurSubModel.KscEntities.TryGetValue(kscEntityId, out kscEntityHandle) || !kscEntityHandle.Valid)
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.PZ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "移除战斗实体失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", kscEntityId);
			KscLog.Warn(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		KscLog.EModule flag2 = KscLog.EModule.Common;
		ELogAuthor author2 = ELogAuthor.PZ;
		UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
		string log2 = "移除战斗实体";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", kscEntityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("removeReason", removeReason);
		KscLog.Debug(flag2, author2, kscWorld2, log2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (this.CurSubModel.KscPlayerEntity == kscEntityHandle.KscEntity)
		{
			this.CurSubModel.SetKscPlayerEntity(null, 0L);
		}
		long creatureDataId = kscEntityHandle.CreatureDataId;
		UKSC_World kscWorld3 = Singleton<KscEnv>.Instance.KscWorld;
		if (kscWorld3 != null)
		{
			kscWorld3.RemoveEntityReason(kscEntityHandle.KscEntity, removeReason);
		}
		this.CurSubModel.KscEntities.Remove(kscEntityId);
		this.CurSubModel.RemoveLogicProxy(creatureDataId);
	}

	// Token: 0x06006148 RID: 24904 RVA: 0x00185B18 File Offset: 0x00183D18
	public void RemoveEntity(long creatureId, FName removeReason)
	{
		if (this.CancelPendingAddIfAny(creatureId))
		{
			this.CancelPendingActionsForEntity(creatureId);
			return;
		}
		this.CancelPendingActionsForEntity(creatureId);
		KscActionEntityRemove kscActionEntityRemove = new KscActionEntityRemove(creatureId, new FName?(removeReason), EKscEntityRemoveReasonType.None);
		KscSubModelBase curSubModel = this.CurSubModel;
		if (curSubModel == null)
		{
			return;
		}
		curSubModel.EntityProcessMgr.RunTask(kscActionEntityRemove.Task);
	}

	// Token: 0x06006149 RID: 24905 RVA: 0x00185B68 File Offset: 0x00183D68
	public unsafe void RemoveEntityImplByReasonType(int kscEntityId, EKscEntityRemoveReasonType removeReasonType)
	{
		KscEntityHandle kscEntityHandle;
		if (!this.CurSubModel.KscEntities.TryGetValue(kscEntityId, out kscEntityHandle) || !kscEntityHandle.Valid)
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.PZ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "移除战斗实体失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", kscEntityId);
			KscLog.Warn(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		FName fname = KscData.kscEntityRemoveReasonList[(int)removeReasonType];
		KscLog.EModule flag2 = KscLog.EModule.Common;
		ELogAuthor author2 = ELogAuthor.PZ;
		UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
		string log2 = "移除战斗实体";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", kscEntityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("removeReason", fname);
		KscLog.Debug(flag2, author2, kscWorld2, log2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (this.CurSubModel.KscPlayerEntity == kscEntityHandle.KscEntity)
		{
			this.CurSubModel.SetKscPlayerEntity(null, 0L);
		}
		long creatureDataId = kscEntityHandle.CreatureDataId;
		if (removeReasonType == EKscEntityRemoveReasonType.Dead)
		{
			if (kscEntityHandle.KscEntity != null)
			{
				kscEntityHandle.KscEntity.Dead(0);
			}
		}
		else
		{
			UKSC_World kscWorld3 = Singleton<KscEnv>.Instance.KscWorld;
			if (kscWorld3 != null)
			{
				kscWorld3.RemoveEntityReason(kscEntityHandle.KscEntity, fname);
			}
		}
		this.CurSubModel.KscEntities.Remove(kscEntityId);
		this.CurSubModel.RemoveLogicProxy(creatureDataId);
	}

	// Token: 0x0600614A RID: 24906 RVA: 0x00185CAC File Offset: 0x00183EAC
	public void RemoveEntityByReasonType(long creatureId, EKscEntityRemoveReasonType removeReasonType)
	{
		if (this.CancelPendingAddIfAny(creatureId))
		{
			this.CancelPendingActionsForEntity(creatureId);
			return;
		}
		this.CancelPendingActionsForEntity(creatureId);
		KscActionEntityRemove kscActionEntityRemove = new KscActionEntityRemove(creatureId, null, removeReasonType);
		KscSubModelBase curSubModel = this.CurSubModel;
		if (curSubModel == null)
		{
			return;
		}
		curSubModel.EntityProcessMgr.RunTask(kscActionEntityRemove.Task);
	}

	// Token: 0x0600614B RID: 24907 RVA: 0x00185D00 File Offset: 0x00183F00
	public unsafe void AddEntityDt(long creatureId, int key, int? propertyId, FTransformDouble transform, Action<AKSC_Entity> callback)
	{
		KscLog.EModule flag = KscLog.EModule.Common;
		ELogAuthor author = ELogAuthor.PZ;
		UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		string log = "加入Dt战斗实体加载中";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("creatureId", creatureId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("dt key", key);
		KscLog.Info(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		ValueTuple<FKSCEntityTableRow, string> valueTuple;
		if (!this.CurSubModel.EntityDataDt.TryGetValue(key, out valueTuple))
		{
			return;
		}
		string assetPath = valueTuple.Item2;
		if (string.IsNullOrEmpty(assetPath))
		{
			return;
		}
		LoadAssetParams<UKSC_DA_Entity> loadAssetParams = new LoadAssetParams<UKSC_DA_Entity>();
		loadAssetParams.Context = Singleton<KscEnv>.Instance.KscWorld;
		loadAssetParams.Id = key;
		loadAssetParams.Path = assetPath;
		UKSC_World kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
		loadAssetParams.NativeContainer = ((kscWorld2 != null) ? kscWorld2.LoadedEntityDa : null);
		loadAssetParams.Callback = delegate(UKSC_DA_Entity resultAsset)
		{
			if (!this.IsWorldInit)
			{
				KscLog.Warn(KscLog.EModule.Load, ELogAuthor.PZ, Singleton<KscEnv>.Instance.KscWorld, "战斗实体加载失败，KSC世界已清理", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (resultAsset == null || !resultAsset.IsValid())
			{
				KscLog.EModule flag2 = KscLog.EModule.Load;
				ELogAuthor author2 = ELogAuthor.PZ;
				UObject kscWorld3 = Singleton<KscEnv>.Instance.KscWorld;
				string log2 = "从Dt加入战斗实体时加载失败";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Path", assetPath);
				KscLog.Warn(flag2, author2, kscWorld3, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			KscLog.EModule flag3 = KscLog.EModule.Load;
			ELogAuthor author3 = ELogAuthor.PZ;
			UObject kscWorld4 = Singleton<KscEnv>.Instance.KscWorld;
			string log3 = "从Dt加入战斗实体时加载成功";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Path", assetPath);
			KscLog.Info(flag3, author3, kscWorld4, log3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			AKSC_Entity aksc_Entity = this.AddEntityImpl(resultAsset, new KscEntityParam
			{
				CreatureId = creatureId,
				PropertyId = propertyId.GetValueOrDefault(),
				Transform = transform
			});
			if (aksc_Entity != null && callback != null)
			{
				callback(aksc_Entity);
			}
		};
		loadAssetParams.FailCallback = null;
		loadAssetParams.KscWorldHandle = Singleton<KscEnv>.Instance.KscWorldHandle;
		KscUtil.AsyncLoadKscAsset<UKSC_DA_Entity>(loadAssetParams);
	}

	// Token: 0x0600614C RID: 24908 RVA: 0x00185E40 File Offset: 0x00184040
	public int GetLogicProxy(int creatureId)
	{
		return this.CurSubModel.GetLogicProxy((long)creatureId).GetValueOrDefault();
	}

	// Token: 0x0600614D RID: 24909 RVA: 0x00185E64 File Offset: 0x00184064
	private unsafe void ReqSimpleCombatEntityDie(Dictionary<long, SimpleCombatEntityDieContext> requestInfos)
	{
		SimpleCombatEntityDieRequest simpleCombatEntityDieRequest = SimpleCombatEntityDieRequest.Create();
		simpleCombatEntityDieRequest.EntityDieCtxMap.Add(requestInfos);
		KscLog.EModule flag = KscLog.EModule.Common;
		ELogAuthor author = ELogAuthor.PZ;
		UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		string log = "请求实体死亡";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("requestInfos", requestInfos);
		KscLog.Debug(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<Net>.Instance.Call<SimpleCombatEntityDieResponse>(ERequestMessageId.SimpleCombatEntityDieRequest, simpleCombatEntityDieRequest, delegate(SimpleCombatEntityDieResponse response, Net.CallbackStatus _)
		{
			if (response == null || response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				KscLog.EModule flag2 = KscLog.EModule.Common;
				ELogAuthor author2 = ELogAuthor.PZ;
				UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
				string log2 = "请求实体死亡异常";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("requestInfos", requestInfos);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", (response != null) ? new Aki.Protocol.ErrorCode?(response.ErrorCode) : null);
				KscLog.Warn(flag2, author2, kscWorld2, log2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}, 0);
	}

	// Token: 0x0600614E RID: 24910 RVA: 0x00185EE4 File Offset: 0x001840E4
	public void BatchRemove(TArray<FKSC_RemoveContext> contexts)
	{
		int num = contexts.Num();
		if (num == 0)
		{
			return;
		}
		Dictionary<long, SimpleCombatEntityDieContext> dictionary = new Dictionary<long, SimpleCombatEntityDieContext>();
		for (int i = 0; i < num; i++)
		{
			this.RemoveContext.InitFromRemoveContext(contexts.Get(i), this.CurSubModel.KscEntities);
			this.TryReqRemove(this.RemoveContext, dictionary, true);
		}
		if (dictionary.Count > 0)
		{
			this.ReqSimpleCombatEntityDie(dictionary);
		}
	}

	// Token: 0x0600614F RID: 24911 RVA: 0x00185F4C File Offset: 0x0018414C
	public void LandFireSpawn(TArray<FKSC_LandFireContext> contexts)
	{
		int num = contexts.Num();
		if (num == 0)
		{
			return;
		}
		Dictionary<long, SimpleCombatEntityDieContext> dictionary = new Dictionary<long, SimpleCombatEntityDieContext>();
		for (int i = 0; i < num; i++)
		{
			this.RemoveContext.InitFromLandFireContext(contexts.Get(i), this.CurSubModel.KscEntities);
			this.TryReqRemove(this.RemoveContext, dictionary, false);
		}
		if (dictionary.Count > 0)
		{
			this.ReqSimpleCombatEntityDie(dictionary);
		}
	}

	// Token: 0x06006150 RID: 24912 RVA: 0x00185FB4 File Offset: 0x001841B4
	private unsafe void TryReqRemove(KscRemoveContext context, Dictionary<long, SimpleCombatEntityDieContext> request, bool isKscEntityRemoved = false)
	{
		KscLog.EModule flag = KscLog.EModule.Common;
		ELogAuthor author = ELogAuthor.PZ;
		UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
		string log = "Ksc原生实体失效,准备上行移除";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("reason", context.ReasonName);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("creatureDataId", context.CreatureDataId);
		KscLog.Debug(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (this.IsDebugOn())
		{
			UKismetSystemLibrary.D_DrawDebugSphere(Singleton<KscEnv>.Instance.KscWorld, context.Location.ToUeVector(false), 16f, 16, new FLinearColor?(new FLinearColor(1f, 0f, 0f, 1f)), 16f, 0f);
		}
		if (context.CreatureDataId == 0L)
		{
			KscLog.Debug(KscLog.EModule.Common, ELogAuthor.PZ, Singleton<KscEnv>.Instance.KscWorld, "Ksc对应普通实体已经失效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.CurSubController != null)
		{
			this.CurSubController.OnEntityRemoved(context, request);
		}
		else
		{
			KscLog.Warn(KscLog.EModule.Common, ELogAuthor.XY, Singleton<KscEnv>.Instance.KscWorld, "没有注册OnEntityRemoved回调, 无法批量移除实体", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		if (!isKscEntityRemoved)
		{
			this.RemoveEntity(context.CreatureDataId, context.ReasonName);
			return;
		}
		if (this.CancelPendingAddIfAny(context.CreatureDataId))
		{
			this.CancelPendingActionsForEntity(context.CreatureDataId);
			return;
		}
		this.CancelPendingActionsForEntity(context.CreatureDataId);
		KscActionEntityForget kscActionEntityForget = new KscActionEntityForget(context.CreatureDataId);
		KscSubModelBase curSubModel = this.CurSubModel;
		if (curSubModel == null)
		{
			return;
		}
		curSubModel.EntityProcessMgr.RunTask(kscActionEntityForget.Task);
	}

	// Token: 0x06006151 RID: 24913 RVA: 0x00186144 File Offset: 0x00184344
	private void SimpleCombatEntityBuffUpdateNotify(SimpleCombatEntityBuffUpdateNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		int buffId = data.BuffId;
		long entityId = data.EntityId;
		KscActionBuffUpdate kscActionBuffUpdate = new KscActionBuffUpdate(data);
		KscSubModelBase curSubModel = this.CurSubModel;
		if (curSubModel == null)
		{
			return;
		}
		curSubModel.EntityProcessMgr.RunTask(kscActionBuffUpdate.Task);
	}

	// Token: 0x06006152 RID: 24914 RVA: 0x00186184 File Offset: 0x00184384
	private void SimpleCombatEntityBuffLayerCountNotify(SimpleCombatEntityBuffLayerCountNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		int buffId = data.BuffId;
		long entityId = data.EntityId;
		KscActionBuffLayoutUpdate kscActionBuffLayoutUpdate = new KscActionBuffLayoutUpdate(data);
		KscSubModelBase curSubModel = this.CurSubModel;
		if (curSubModel == null)
		{
			return;
		}
		curSubModel.EntityProcessMgr.RunTask(kscActionBuffLayoutUpdate.Task);
	}

	// Token: 0x06006153 RID: 24915 RVA: 0x001861C4 File Offset: 0x001843C4
	private void SimpleCombatEntitySubTypeChangeNotify(SimpleCombatEntitySubTypeChangeNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		long entityId = data.EntityId;
		SimpleCombatComponentPb newComponentData = data.NewComponentData;
		MapField<int, int> mapField = (newComponentData != null) ? newComponentData.BuffLayers : null;
		if (mapField == null || mapField.Count <= 0)
		{
			KscLog.Debug(KscLog.EModule.Skill, ELogAuthor.CX, Singleton<KscEnv>.Instance.KscWorld, "实体子类型变更时 BuffLayers 为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		KscActionBuffsAdd kscActionBuffsAdd = new KscActionBuffsAdd(data);
		KscSubModelBase curSubModel = this.CurSubModel;
		if (curSubModel == null)
		{
			return;
		}
		curSubModel.EntityProcessMgr.RunTask(kscActionBuffsAdd.Task);
	}

	// Token: 0x06006154 RID: 24916 RVA: 0x0018623C File Offset: 0x0018443C
	private void SimpleCombatEntityAttributeUpdateNotify(SimpleCombatEntityAttributeUpdateNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		long entityId = data.EntityId;
		KscActionAttrUpdate kscActionAttrUpdate = new KscActionAttrUpdate(Singleton<MathUtils>.Instance.LongToNumber(data.EntityId), data);
		KscSubModelBase curSubModel = this.CurSubModel;
		if (curSubModel == null)
		{
			return;
		}
		curSubModel.EntityProcessMgr.RunTask(kscActionAttrUpdate.Task);
	}

	// Token: 0x06006155 RID: 24917 RVA: 0x00186284 File Offset: 0x00184484
	public void ModifyBuffAsync(int kscEntityId, bool isAdd, int buffId)
	{
		KscEntityHandle kscEntityHandle;
		if (!this.CurSubModel.KscEntities.TryGetValue(kscEntityId, out kscEntityHandle) || !kscEntityHandle.Valid)
		{
			KscLog.EModule flag = KscLog.EModule.Skill;
			ELogAuthor author = ELogAuthor.CFT;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "刷新buff时失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", kscEntityId);
			KscLog.Warn(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		KscActionBuffModifyLocal kscActionBuffModifyLocal = new KscActionBuffModifyLocal(kscEntityHandle.CreatureDataId, kscEntityId, isAdd, buffId);
		KscSubModelBase curSubModel = this.CurSubModel;
		if (curSubModel == null)
		{
			return;
		}
		curSubModel.EntityProcessMgr.RunTask(kscActionBuffModifyLocal.Task);
	}

	// Token: 0x06006156 RID: 24918 RVA: 0x0018630C File Offset: 0x0018450C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public FKSC_MiniMapContext[] GetEntityPositions()
	{
		if (Singleton<KscEnv>.Instance.KscWorld == null)
		{
			return null;
		}
		List<FKSC_MiniMapContext> list = new List<FKSC_MiniMapContext>();
		int num = this.EntityPositions.Num();
		for (int i = 0; i < num; i++)
		{
			list.Add(this.EntityPositions.Get(i));
		}
		return list.ToArray();
	}

	// Token: 0x06006157 RID: 24919 RVA: 0x00186360 File Offset: 0x00184560
	public void PushSimpleCombatEntityHp(long creatureDataId, float hp, float hpMax)
	{
		SimpleCombatEntitySyncAttributePush simpleCombatEntitySyncAttributePush = SimpleCombatEntitySyncAttributePush.Create();
		Dictionary<long, SimpleCombatEntityAttributePbInfo> dictionary = new Dictionary<long, SimpleCombatEntityAttributePbInfo>();
		SimpleCombatEntityAttributePbInfo simpleCombatEntityAttributePbInfo = SimpleCombatEntityAttributePbInfo.Create();
		Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
		dictionary2[3] = (int)hp;
		dictionary2[2] = (int)hpMax;
		simpleCombatEntityAttributePbInfo.AttributeMap.Add(dictionary2);
		dictionary[creatureDataId] = simpleCombatEntityAttributePbInfo;
		simpleCombatEntitySyncAttributePush.EntityAttributeMap.Add(dictionary);
		Singleton<Net>.Instance.Send(EPushMessageId.SimpleCombatEntitySyncAttributePush, simpleCombatEntitySyncAttributePush);
	}

	// Token: 0x06006158 RID: 24920 RVA: 0x001863C7 File Offset: 0x001845C7
	public void SetDebugOn(bool value)
	{
		this.IsDebug = value;
	}

	// Token: 0x06006159 RID: 24921 RVA: 0x001863D0 File Offset: 0x001845D0
	public bool IsDebugOn()
	{
		return this.IsDebug;
	}

	// Token: 0x0600615A RID: 24922 RVA: 0x001863D8 File Offset: 0x001845D8
	public void ToggleDebug()
	{
		this.IsDebug = !this.IsDebug;
	}

	// Token: 0x17000724 RID: 1828
	// (get) Token: 0x0600615B RID: 24923 RVA: 0x001863E9 File Offset: 0x001845E9
	[Nullable(2)]
	public UKSC_HeadStateManager KscHeadStateManager
	{
		[NullableContext(2)]
		get
		{
			return this.KscHeadStateManagerInternal;
		}
	}

	// Token: 0x0600615C RID: 24924 RVA: 0x001863F1 File Offset: 0x001845F1
	public void StartKscHeadStateManager()
	{
		if (this.KscHeadStateManagerInternal != null)
		{
			return;
		}
		this.KscHeadStateManagerInternal = UKSC_HeadStateManager.CreateInstance(GlobalData.World);
	}

	// Token: 0x0600615D RID: 24925 RVA: 0x0018640C File Offset: 0x0018460C
	public void StopKscHeadStateManager()
	{
		if (this.KscHeadStateManagerInternal != null)
		{
			UKSC_HeadStateManager.DestroyInstance();
			this.KscHeadStateManagerInternal = null;
		}
	}

	// Token: 0x0600615E RID: 24926 RVA: 0x00186422 File Offset: 0x00184622
	private void SimpleCombatBeginNotify(SimpleCombatBeginNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		this.OpenWorldByGameplayType(EKscGameplayType.FinalBattle);
	}

	// Token: 0x0600615F RID: 24927 RVA: 0x0018642C File Offset: 0x0018462C
	private void SimpleCombatEndNotify(SimpleCombatEndNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		KscSubControllerBase kscSubControllerBase;
		this.CloseCurrentWorld(this.SubControllerMap.TryGetValue(EKscGameplayType.FinalBattle, out kscSubControllerBase) ? kscSubControllerBase : null);
	}

	// Token: 0x06006160 RID: 24928 RVA: 0x00186454 File Offset: 0x00184654
	[NullableContext(2)]
	public AKSC_Entity GetKscEntityHandle(long creatureId)
	{
		KscSubModelBase curSubModel = this.CurSubModel;
		KscEntityHandle kscEntityHandle = (curSubModel != null) ? curSubModel.GetKscEntityHandle(creatureId) : null;
		if (kscEntityHandle != null && kscEntityHandle.Valid && kscEntityHandle.KscEntity != null)
		{
			return kscEntityHandle.KscEntity;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null || getCurrentEntity.Entity == null)
		{
			return null;
		}
		if (getCurrentEntity.CreatureDataId != creatureId)
		{
			return null;
		}
		KscSubModelBase curSubModel2 = this.CurSubModel;
		if (curSubModel2 == null)
		{
			return null;
		}
		return curSubModel2.KscPlayerEntity;
	}

	// Token: 0x06006161 RID: 24929 RVA: 0x001864C4 File Offset: 0x001846C4
	public void GmCreateEntity(int simpleCombatId, float distance)
	{
		string entityPathById = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel.GetEntityPathById(simpleCombatId);
		if (string.IsNullOrEmpty(entityPathById))
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.TZQ;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "[摩托战斗]实体资产路径不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("simpleCombatId", simpleCombatId);
			KscLog.Error(flag, author, kscWorld, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		WorldEntity worldEntity = (getCurrentEntity != null) ? getCurrentEntity.Entity : null;
		if (worldEntity == null)
		{
			KscLog.Error(KscLog.EModule.Common, ELogAuthor.TZQ, Singleton<KscEnv>.Instance.KscWorld, "[摩托战斗]playerEntity为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		BaseActorComponent component = worldEntity.GetComponent<BaseActorComponent>();
		if (component == null)
		{
			KscLog.Error(KscLog.EModule.Common, ELogAuthor.TZQ, Singleton<KscEnv>.Instance.KscWorld, "[摩托战斗]baseActorComponent为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		global::Vector vector = component.ActorLocationProxy.Addition(component.ActorForwardProxy.Multiply((double)distance, Singleton<MathUtils>.Instance.CommonTempVector), Singleton<MathUtils>.Instance.CommonTempVector);
		FVectorDouble fvectorDouble = vector.ToUeVector(false);
		FVector fvector = global::Vector.OneVectorDouble;
		FTransformDouble transform = new FTransformDouble(ref global::Rotator.ZeroRotator, ref fvectorDouble, ref fvector);
		ControllerBase<KuroSimpleCombatController>.Instance.AsyncAddEntity(new KscEntityParam
		{
			CreatureId = -1L,
			SimpleCombatId = simpleCombatId,
			AssetPath = entityPathById,
			PropertyId = 0,
			Transform = transform
		});
	}

	// Token: 0x06006162 RID: 24930 RVA: 0x0018660C File Offset: 0x0018480C
	public void GmAddBuff(int kscEntityId, int buffId)
	{
		if (kscEntityId == 0)
		{
			MotorcycleArrowSubController motorcycleArrowSubController = this.CurSubController as MotorcycleArrowSubController;
			if (motorcycleArrowSubController != null)
			{
				motorcycleArrowSubController.EffectManager.AddBuffEffect(buffId, null, true);
				return;
			}
		}
		int num = (kscEntityId == 0) ? this.GmGetPlayerEntityId() : kscEntityId;
		if (num != 0)
		{
			this.ModifyBuffAsync(num, true, buffId);
		}
	}

	// Token: 0x06006163 RID: 24931 RVA: 0x0018665C File Offset: 0x0018485C
	public void GmRemoveBuff(int kscEntityId, int buffId)
	{
		if (kscEntityId == 0)
		{
			MotorcycleArrowSubController motorcycleArrowSubController = this.CurSubController as MotorcycleArrowSubController;
			if (motorcycleArrowSubController != null)
			{
				motorcycleArrowSubController.EffectManager.RemovePlayerBuff(buffId);
				return;
			}
		}
		int num = (kscEntityId == 0) ? this.GmGetPlayerEntityId() : kscEntityId;
		if (num != 0)
		{
			this.ModifyBuffAsync(num, false, buffId);
		}
	}

	// Token: 0x06006164 RID: 24932 RVA: 0x001866A4 File Offset: 0x001848A4
	public int GmGetPlayerEntityId()
	{
		KscSubModelBase curSubModel = this.CurSubModel;
		int? num;
		if (curSubModel == null)
		{
			num = null;
		}
		else
		{
			AKSC_Entity kscPlayerEntity = curSubModel.KscPlayerEntity;
			num = ((kscPlayerEntity != null) ? new int?(kscPlayerEntity.EntityId_) : null);
		}
		int? num2 = num;
		return num2.GetValueOrDefault();
	}

	// Token: 0x06006165 RID: 24933 RVA: 0x001866EC File Offset: 0x001848EC
	public unsafe void GmAddPlayerEntity(IKscGmPlayerEntityParam param)
	{
		if (this.CurSubController == null)
		{
			KscLog.EModule flag = KscLog.EModule.Common;
			ELogAuthor author = ELogAuthor.CFT;
			UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			string log = "Ksc尝试添加玩家角色,当前子控制器非法";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SimpleCombatId", param.SimpleCombatId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SubTypeId", param.SubTypeId);
			KscLog.Warn(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		KscLog.EModule flag2 = KscLog.EModule.Common;
		ELogAuthor author2 = ELogAuthor.CFT;
		UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
		string log2 = "Ksc转发添加玩家角色请求";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("SimpleCombatId", param.SimpleCombatId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("SubTypeId", param.SubTypeId);
		KscLog.Info(flag2, author2, kscWorld2, log2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		this.CurSubController.GmAddPlayerEntity(param);
	}

	// Token: 0x06006166 RID: 24934 RVA: 0x001867E4 File Offset: 0x001849E4
	public void GmPrintInfo()
	{
		if (this.CurSubController != null)
		{
			this.CurSubController.GmPrintInfo();
			return;
		}
		KscLog.Debug(KscLog.EModule.Common, ELogAuthor.CFT, null, "当前不在KSC玩法中", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06006167 RID: 24935 RVA: 0x0018681C File Offset: 0x00184A1C
	public void GmCreateKSCWorld(int GamePlayType)
	{
		this.OpenWorldByGameplayType((EKscGameplayType)GamePlayType);
	}

	// Token: 0x04002E8E RID: 11918
	private readonly Dictionary<EKscGameplayType, KscSubControllerBase> SubControllerMap = new Dictionary<EKscGameplayType, KscSubControllerBase>
	{
		{
			EKscGameplayType.TowerDefense,
			new TowerDefenseSubController()
		},
		{
			EKscGameplayType.SurvivorsRogue,
			new SurvivorsRogueSubController()
		},
		{
			EKscGameplayType.FinalBattle,
			new FinalBattleSubController()
		},
		{
			EKscGameplayType.MotorcycleArrow,
			new MotorcycleArrowSubController()
		},
		{
			EKscGameplayType.PinballBattle,
			new PinballBattleSubController()
		},
		{
			EKscGameplayType.Potato,
			new PotatoSubController()
		}
	};

	// Token: 0x04002E8F RID: 11919
	[Nullable(2)]
	public KscSubControllerBase CurSubController;

	// Token: 0x04002E90 RID: 11920
	private TArray<FKSC_MiniMapContext> EntityPositions = new TArray<FKSC_MiniMapContext>();

	// Token: 0x04002E91 RID: 11921
	private bool IsMapInit;

	// Token: 0x04002E92 RID: 11922
	private bool IsWorldInit;

	// Token: 0x04002E93 RID: 11923
	private List<EKscObservedLifecycleStage> ObservedLifecycleStages = new List<EKscObservedLifecycleStage>();

	// Token: 0x04002E94 RID: 11924
	private readonly Dictionary<long, KscActionEntityAdd> PendingAdds = new Dictionary<long, KscActionEntityAdd>();

	// Token: 0x04002E95 RID: 11925
	private readonly KscRemoveContext RemoveContext = new KscRemoveContext();

	// Token: 0x04002E96 RID: 11926
	public bool IsDebug;

	// Token: 0x04002E97 RID: 11927
	[Nullable(2)]
	private UKSC_HeadStateManager KscHeadStateManagerInternal;
}
