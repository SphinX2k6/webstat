using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.GameBudgetAllocator;
using CSharpScript.Game.Common.Event;
using CSharpScript.Typing;
using UnrealEngine;

// Token: 0x02000BC3 RID: 3011
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GameBudgetInterfaceController : Singleton<GameBudgetInterfaceController>
{
	// Token: 0x170000AF RID: 175
	// (get) Token: 0x0600310C RID: 12556 RVA: 0x0001B24A File Offset: 0x0001944A
	[Nullable(2)]
	public AActor CenterRole
	{
		[NullableContext(2)]
		get
		{
			return this.CenterRoleInternal;
		}
	}

	// Token: 0x170000B0 RID: 176
	// (get) Token: 0x0600310D RID: 12557 RVA: 0x0001B252 File Offset: 0x00019452
	public EGameBudgetAllocatorGlobalMode CurrentGlobalMode
	{
		get
		{
			return this.CurrentGlobalModeInternal;
		}
	}

	// Token: 0x0600310E RID: 12558 RVA: 0x0001B25C File Offset: 0x0001945C
	protected override bool OnInit()
	{
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnBattleStateChanged, new Action<bool>(this.BattleStateChanged));
		this.NoneMode = new GameBudgetModeBase("EGameBudgetMode.None", EGameBudgetMode.None);
		this.CurrentModel = this.NoneMode;
		this.EnterGameBudgetMode(this.CurrentModel);
		return base.OnInit();
	}

	// Token: 0x0600310F RID: 12559 RVA: 0x0001B2B4 File Offset: 0x000194B4
	private void EnterGameBudgetMode(GameBudgetModeBase model)
	{
		if (Singleton<PerfSight>.Instance.IsEnable)
		{
			FKuroPerfSightHelper.BeginExtTag(model.GameBudgetModeName);
		}
		model.OnEnterMode();
	}

	// Token: 0x06003110 RID: 12560 RVA: 0x0001B2D3 File Offset: 0x000194D3
	private void ExitGameBudgetMode(GameBudgetModeBase model)
	{
		if (Singleton<PerfSight>.Instance.IsEnable)
		{
			FKuroPerfSightHelper.EndExtTag(model.GameBudgetModeName);
		}
		model.OnExitMode();
	}

	// Token: 0x06003111 RID: 12561 RVA: 0x0001B2F2 File Offset: 0x000194F2
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnBattleStateChanged, new Action<bool>(this.BattleStateChanged));
		this.SequenceCamera = null;
		this.ExitGameBudgetMode(this.CurrentModel);
		return base.OnClear();
	}

	// Token: 0x06003112 RID: 12562 RVA: 0x0001B329 File Offset: 0x00019529
	public void InitializeEnvironment(UWorld world)
	{
		UKuroGameBudgetAllocatorCSharpInterface.InitializeEnvironment(world, true);
		UKuroGameBudgetAllocatorCSharpInterface.SetUpdateCompensateEnable(false);
		if (this.CacheUpdateMinUpdateFifoBudgetTime != null)
		{
			UKuroGameBudgetAllocatorCSharpInterface.UpdateMinUpdateFIFOBudgetTime(this.CacheUpdateMinUpdateFifoBudgetTime.Value);
		}
		this.GameBudgetTimeEstimation.Initialize();
	}

	// Token: 0x06003113 RID: 12563 RVA: 0x0001B360 File Offset: 0x00019560
	public static bool IsEnvironmentValid()
	{
		return UKuroGameBudgetAllocatorCSharpInterface.IsEnvironmentValid();
	}

	// Token: 0x06003114 RID: 12564 RVA: 0x0001B367 File Offset: 0x00019567
	public void SetMaximumFrameRate(int fps)
	{
		UKuroGameBudgetAllocatorCSharpInterface.SetMaximumFrameRate((uint)((fps > 0) ? fps : 0));
		this.GameBudgetTimeEstimation.SetMaximumFrameRate(fps);
	}

	// Token: 0x170000B1 RID: 177
	// (get) Token: 0x06003115 RID: 12565 RVA: 0x0001B382 File Offset: 0x00019582
	public float? MinUpdateFifoBudgetTime
	{
		get
		{
			return this.CacheUpdateMinUpdateFifoBudgetTime;
		}
	}

	// Token: 0x06003116 RID: 12566 RVA: 0x0001B38A File Offset: 0x0001958A
	public static void UpdateMinUpdateFifoBudgetTime(float time)
	{
		Singleton<GameBudgetInterfaceController>.Instance.CacheUpdateMinUpdateFifoBudgetTime = new float?(time);
		if (GameBudgetInterfaceController.IsEnvironmentValid())
		{
			UKuroGameBudgetAllocatorCSharpInterface.UpdateMinUpdateFIFOBudgetTime(time);
		}
	}

	// Token: 0x06003117 RID: 12567 RVA: 0x0001B3A9 File Offset: 0x000195A9
	public static void UpdateBudgetTime(float delta)
	{
		Singleton<GameBudgetInterfaceController>.Instance.GameBudgetTimeEstimation.UpdateBudgetTime(delta);
	}

	// Token: 0x06003118 RID: 12568 RVA: 0x0001B3BC File Offset: 0x000195BC
	public uint RegisterTick(FName groupTag, ESignificanceGroup significanceGroup, IGameBudgetManagedObject obj, [Nullable(2)] AActor actor, bool afterTick = true, bool onEnabledChange = true, bool wasRecentlyRenderedOnScreenChange = true, bool locationProxyFunction = true)
	{
		uint result;
		if (this.ObjectTokenDic.TryGetValue(obj, out result))
		{
			Singleton<Log>.Instance.Warn(ELogModule.Game, ELogAuthor.WY, "Object has already added!", default(ReadOnlySpan<ValueTuple<string, object>>));
			return result;
		}
		GCHandle gchandle = obj.GetGCHandle();
		if (!gchandle.IsAllocated)
		{
			return 0U;
		}
		IntPtr actorPtr = IntPtr.Zero;
		if (actor != null)
		{
			actorPtr = actor.NativePtr;
		}
		uint num = FKuroGameBudgetAllocatorCSharpInterface.RegisterFunction(GCHandle.ToIntPtr(gchandle), groupTag, significanceGroup, actorPtr, afterTick && obj.HasScheduledAfterTick, onEnabledChange && obj.HasOnEnabledChange, wasRecentlyRenderedOnScreenChange && obj.HasOnWasRecentlyRenderedOnScreenChange, locationProxyFunction && obj.HasLocationProxyFunction);
		this.ObjectTokenDic[obj] = num;
		return num;
	}

	// Token: 0x06003119 RID: 12569 RVA: 0x0001B470 File Offset: 0x00019670
	public void UnregisterTick(IGameBudgetManagedObject obj)
	{
		uint token;
		if (this.ObjectTokenDic.TryGetValue(obj, out token))
		{
			this.ObjectTokenDic.Remove(obj);
			UKuroGameBudgetAllocatorCSharpInterface.UnregisterFunction(token);
			return;
		}
		Singleton<Log>.Instance.Warn(ELogModule.Game, ELogAuthor.WY, "Not found error!", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0600311A RID: 12570 RVA: 0x0001B4BD File Offset: 0x000196BD
	public void UpdateRegisterActor(FName groupName, uint token, AActor actor)
	{
		UKuroGameBudgetAllocatorCSharpInterface.UpdateActor(groupName, token, actor);
	}

	// Token: 0x0600311B RID: 12571 RVA: 0x0001B4C8 File Offset: 0x000196C8
	public void RegisterOnceTaskDefaultGroup(FName groupId, int priority, int maxWaitFrame)
	{
		UKuroGameBudgetAllocatorCSharpInterface.RegisterOnceTaskDefaultGroup(groupId, priority, maxWaitFrame);
	}

	// Token: 0x0600311C RID: 12572 RVA: 0x0001B4D4 File Offset: 0x000196D4
	public void RegisterOnceTaskCustomGroup(IGameBudgetOnceTaskGroup groupObject)
	{
		this.OnceTaskGroupDic.Add(groupObject.GroupId, groupObject);
		FName groupId = groupObject.GroupId;
		UKuroGameBudgetAllocatorCSharpInterface.RegisterOnceTaskCustomGroup(groupId, groupObject.Priority);
	}

	// Token: 0x0600311D RID: 12573 RVA: 0x0001B508 File Offset: 0x00019708
	[NullableContext(2)]
	public IGameBudgetOnceTaskGroup GetOnceTaskGroupById(FName GroupId)
	{
		IGameBudgetOnceTaskGroup result;
		if (this.OnceTaskGroupDic.TryGetValue(GroupId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600311E RID: 12574 RVA: 0x0001B528 File Offset: 0x00019728
	[NullableContext(2)]
	public Vector GetCenterOffset()
	{
		return this.CenterOffsetInternal;
	}

	// Token: 0x0600311F RID: 12575 RVA: 0x0001B530 File Offset: 0x00019730
	public void SetUseBoundsCalculateDistance(FName groupName, uint token, bool useBoundsCalculateDistance)
	{
		UKuroGameBudgetAllocatorCSharpInterface.SetUseBoundsCalculateDistance(groupName, token, useBoundsCalculateDistance);
	}

	// Token: 0x06003120 RID: 12576 RVA: 0x0001B53B File Offset: 0x0001973B
	public void SetUsePerformanceActorCalculateBounds(FName groupName, uint token, bool usePerformanceActorCalculateBounds)
	{
		UKuroGameBudgetAllocatorCSharpInterface.SetUsePerformanceActorCalculateBounds(groupName, token, usePerformanceActorCalculateBounds);
	}

	// Token: 0x06003121 RID: 12577 RVA: 0x0001B546 File Offset: 0x00019746
	public void SetPerformanceLimitMode(bool isPerformanceLimitMode)
	{
		this.IsPerformanceLimitMode = isPerformanceLimitMode;
		this.RefreshGlobalMode();
	}

	// Token: 0x06003122 RID: 12578 RVA: 0x0001B555 File Offset: 0x00019755
	public void SetPlotMode(bool isInPlot)
	{
		this.IsInPlot = isInPlot;
		this.RefreshGlobalMode();
	}

	// Token: 0x06003123 RID: 12579 RVA: 0x0001B564 File Offset: 0x00019764
	public void TryUpdateCenterRoleOffset(Entity entity)
	{
		CharacterMorphComponent component = entity.GetComponent<CharacterMorphComponent>();
		FVectorDouble? fvectorDouble = (component != null) ? component.GetCenterActorLocationOffset() : null;
		if (fvectorDouble != null)
		{
			this.SetCenterActorLocationOffset(fvectorDouble.Value);
		}
	}

	// Token: 0x06003124 RID: 12580 RVA: 0x0001B5A4 File Offset: 0x000197A4
	private void BattleStateChanged(bool isInFight)
	{
		this.IsInFight = isInFight;
		if (this.IsInFight && this.IsInPlot)
		{
			this.IsInPlot = false;
			Singleton<Log>.Instance.Error(ELogModule.Game, ELogAuthor.WLJ, "[GameBudget]进入战斗时时间预算管理仍然处于剧情模式", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.RefreshGlobalMode();
	}

	// Token: 0x06003125 RID: 12581 RVA: 0x0001B5F4 File Offset: 0x000197F4
	private unsafe void RefreshGlobalMode()
	{
		EGameBudgetAllocatorGlobalMode egameBudgetAllocatorGlobalMode = this.IsInPlot ? EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene : ((this.IsInFight && !this.IsPerformanceLimitMode) ? EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting : EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal);
		this.CurrentGlobalModeInternal = egameBudgetAllocatorGlobalMode;
		UKuroGameBudgetAllocatorCSharpInterface.SetGlobalMode(egameBudgetAllocatorGlobalMode);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Game;
		ELogAuthor author = ELogAuthor.WLJ;
		string message = "[GameBudget]RefreshGlobalMode";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IsInPlot", this.IsInPlot);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsInFight", this.IsInFight);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("IsPerformanceLimitMode", this.IsPerformanceLimitMode);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x170000B2 RID: 178
	// (get) Token: 0x06003126 RID: 12582 RVA: 0x0001B6B7 File Offset: 0x000198B7
	public EGameBudgetMode BudgetMode
	{
		get
		{
			return this.CurrentModel.Mode;
		}
	}

	// Token: 0x06003127 RID: 12583 RVA: 0x0001B6C4 File Offset: 0x000198C4
	private unsafe void SetModel(GameBudgetModeBase model)
	{
		if (this.CurrentModel != model)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Game;
			ELogAuthor author = ELogAuthor.WLJ;
			string message = "[GameBudget]时间预算管理模式更改";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("NewModel", model);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("OldModel", this.CurrentModel);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.ExitGameBudgetMode(this.CurrentModel);
			this.CurrentModel = model;
			this.EnterGameBudgetMode(model);
		}
	}

	// Token: 0x06003128 RID: 12584 RVA: 0x0001B74C File Offset: 0x0001994C
	public void OnBudgetModelChange(GameBudgetModeBase newModel)
	{
		this.SetModel(newModel);
	}

	// Token: 0x06003129 RID: 12585 RVA: 0x0001B755 File Offset: 0x00019955
	[NullableContext(2)]
	public void OnChangeCenterRole(AActor centerActor, FVectorDouble? offset)
	{
		if (centerActor != null)
		{
			this.SetCenterRole(centerActor);
		}
		if (offset != null)
		{
			this.SetCenterActorLocationOffset(offset.Value);
		}
	}

	// Token: 0x0600312A RID: 12586 RVA: 0x0001B777 File Offset: 0x00019977
	public void SetCenterActorLocationOffset(FVectorDouble offset)
	{
		this.CenterOffsetInternal = Vector.Create(offset);
		UKuroGameBudgetAllocatorCSharpInterface.SetCenterActorLocationOffset(offset);
	}

	// Token: 0x0600312B RID: 12587 RVA: 0x0001B791 File Offset: 0x00019991
	[NullableContext(2)]
	public void SetCenterRole(AActor roleActor)
	{
		if (roleActor == null)
		{
			return;
		}
		if (this.CenterRoleInternal != roleActor)
		{
			UKuroGameBudgetAllocatorCSharpInterface.SetCenterActor(roleActor);
			this.CenterRoleInternal = roleActor;
			this.SetCenterActorLocationOffset(Vector.ZeroVectorDouble);
		}
	}

	// Token: 0x0400043A RID: 1082
	[StaticVariableRuleIgnore]
	public static readonly bool IsOpen = true;

	// Token: 0x0400043B RID: 1083
	private readonly Dictionary<IGameBudgetManagedObject, uint> ObjectTokenDic = new Dictionary<IGameBudgetManagedObject, uint>();

	// Token: 0x0400043C RID: 1084
	private readonly Dictionary<FName, IGameBudgetOnceTaskGroup> OnceTaskGroupDic = new Dictionary<FName, IGameBudgetOnceTaskGroup>();

	// Token: 0x0400043D RID: 1085
	public readonly FName TsGlobalFifoTaskGroupName = new FName("TsGlobalFifoTaskGroup");

	// Token: 0x0400043E RID: 1086
	public readonly ESignificanceGroup TsGlobalFifoTaskSignificanceGroup = ESignificanceGroup.Middle;

	// Token: 0x0400043F RID: 1087
	[Nullable(2)]
	private AActor CenterRoleInternal;

	// Token: 0x04000440 RID: 1088
	private float? CacheUpdateMinUpdateFifoBudgetTime;

	// Token: 0x04000441 RID: 1089
	public bool IsInPlot;

	// Token: 0x04000442 RID: 1090
	public bool IsInFight;

	// Token: 0x04000443 RID: 1091
	private bool IsPerformanceLimitMode;

	// Token: 0x04000444 RID: 1092
	private EGameBudgetAllocatorGlobalMode CurrentGlobalModeInternal;

	// Token: 0x04000445 RID: 1093
	private IGameBudgetTimeEstimation GameBudgetTimeEstimation = new GameBudgetTimeEstimationFramesOffset();

	// Token: 0x04000446 RID: 1094
	[Nullable(2)]
	private Vector CenterOffsetInternal;

	// Token: 0x04000447 RID: 1095
	private GameBudgetModeBase CurrentModel;

	// Token: 0x04000448 RID: 1096
	[Nullable(2)]
	public AActor SequenceCamera;

	// Token: 0x04000449 RID: 1097
	private GameBudgetModeBase NoneMode;
}
