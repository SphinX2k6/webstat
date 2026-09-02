using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Effect.BluePrint.BP_FX_Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Teleport;
using GuideLineProcess;
using UnrealEngine;

// Token: 0x0200263E RID: 9790
[NullableContext(1)]
[Nullable(0)]
public class GuideLineAssistant : ControllerAssistantBase
{
	// Token: 0x0601346C RID: 78956 RVA: 0x0055BB50 File Offset: 0x00559D50
	public GuideLineAssistant(IReadOnlyList<BtType> btTypes)
	{
		this.BtTypes = btTypes;
		this.CurBtType = ((this.BtTypes.Count > 0) ? this.BtTypes[0] : BtType.Invalid);
	}

	// Token: 0x0601346D RID: 78957 RVA: 0x0055BBDF File Offset: 0x00559DDF
	protected override void OnInit()
	{
	}

	// Token: 0x0601346E RID: 78958 RVA: 0x0055BBE1 File Offset: 0x00559DE1
	protected override void OnDestroy()
	{
		this.ProcessList.Clear();
		this.DestroyGuideSpline();
		this.QuestGuidePoints.Empty(true);
	}

	// Token: 0x0601346F RID: 78959 RVA: 0x0055BC00 File Offset: 0x00559E00
	public override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.GeneralLogicTreeWakeUp, new Action(this.SpawnQuestGuideLine));
		Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnUseSkill));
		Singleton<EventSystem>.Instance.Add<BtType, long?>(EEventName.OnLogicTreeTrackUpdate, new Action<BtType, long?>(this.OnQuestTrackUpdate));
		Singleton<EventSystem>.Instance.Add<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(EEventName.OnLogicTreeNodeStatusChange, new Action<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(this.OnNodeStatusUpdate));
		Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.RefreshSpawn));
	}

	// Token: 0x06013470 RID: 78960 RVA: 0x0055BC98 File Offset: 0x00559E98
	public override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.GeneralLogicTreeWakeUp, new Action(this.SpawnQuestGuideLine));
		Singleton<EventSystem>.Instance.Remove<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnUseSkill));
		Singleton<EventSystem>.Instance.Remove<BtType, long?>(EEventName.OnLogicTreeTrackUpdate, new Action<BtType, long?>(this.OnQuestTrackUpdate));
		Singleton<EventSystem>.Instance.Remove<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(EEventName.OnLogicTreeNodeStatusChange, new Action<GeneralContext, NodeStatus, NodeStatus, ENodeStatusUpdateReason>(this.OnNodeStatusUpdate));
		Singleton<EventSystem>.Instance.Remove<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.RefreshSpawn));
	}

	// Token: 0x06013471 RID: 78961 RVA: 0x0055BD2E File Offset: 0x00559F2E
	private void OnUseSkill(int charId, int skillId, bool isAutonomousProxy)
	{
		if (skillId == 210004)
		{
			ModelBase<GeneralLogicTreeModel>.Instance.UpdateGuideLineStartShowTime();
		}
	}

	// Token: 0x06013472 RID: 78962 RVA: 0x0055BD42 File Offset: 0x00559F42
	private void OnQuestTrackUpdate(BtType contextType, long? _ = null)
	{
		if (!this.BtTypes.Contains(contextType))
		{
			return;
		}
		this.CurBtType = contextType;
		ModelBase<GeneralLogicTreeModel>.Instance.UpdateGuideLineStartShowTime();
		if (!this.CheckCanShowGuideLine())
		{
			return;
		}
		this.RefreshSpawn(null);
	}

	// Token: 0x06013473 RID: 78963 RVA: 0x0055BD74 File Offset: 0x00559F74
	private void OnNodeStatusUpdate(GeneralContext context, NodeStatus oldStatus, NodeStatus newStatus, ENodeStatusUpdateReason reason)
	{
		if (context.Type.GetValueOrDefault() == EGeneralContextType.GeneralLogicTree)
		{
			GeneralLogicTreeContext generalLogicTreeContext = context as GeneralLogicTreeContext;
			if (generalLogicTreeContext != null)
			{
				LogicTreeContainer currentTrack = this.GetCurrentTrack(new BtType?(generalLogicTreeContext.BtType));
				if (((currentTrack != null) ? currentTrack.Id : 0) != generalLogicTreeContext.TreeConfigId || newStatus != NodeStatus.Activated)
				{
					return;
				}
				this.OnQuestTrackUpdate(generalLogicTreeContext.BtType, null);
				return;
			}
		}
	}

	// Token: 0x06013474 RID: 78964 RVA: 0x0055BDD9 File Offset: 0x00559FD9
	public void SpawnQuestGuideLine()
	{
		this.DestroyGuideSpline();
		Singleton<ResourceSystem>.Instance.LoadTypeAsync(EBpTypeName.BP_Fx_WayFinding_C.ToEnumString(), delegate
		{
			this.PersistentSpline = (Singleton<ActorSystem>.Instance.Get(BP_Fx_WayFinding_C.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true) as BP_Fx_WayFinding_C);
		}, "js_undefined");
		this.DisableQuestGuideLine();
		this.PathPointsPersistent = new TArray<FVectorDouble>();
	}

	// Token: 0x06013475 RID: 78965 RVA: 0x0055BE13 File Offset: 0x0055A013
	private void DestroyGuideSpline()
	{
		if (ObjectUtils.IsValid(this.PersistentSpline))
		{
			Singleton<ActorSystem>.Instance.Put("GuideLineAssistant.DestroyGuideSpline", this.PersistentSpline, null);
		}
		this.PersistentSpline = null;
	}

	// Token: 0x06013476 RID: 78966 RVA: 0x0055BE40 File Offset: 0x0055A040
	public void Tick(float delta)
	{
		this.UpdateCurSpawn(delta);
		this.UpdateProcess();
		if (!this.CheckCanShowGuideLine())
		{
			if (this.CurSpawn > 0f && this.TriggeredSpawn)
			{
				this.DisableQuestGuideLine();
			}
			this.TriggeredSpawn = false;
			return;
		}
		bool flag = this.UpdateMovingState();
		if (!this.TriggeredSpawn || (flag && !this.Moving))
		{
			this.RefreshSpawn(null);
		}
	}

	// Token: 0x06013477 RID: 78967 RVA: 0x0055BEA8 File Offset: 0x0055A0A8
	private void UpdateProcess()
	{
		if (this.ProcessList.Count == 0)
		{
			return;
		}
		if (this.CurProcess != null)
		{
			return;
		}
		this.CurProcess = this.ProcessList[0];
		GuideLineProcess.EProcessType processType = this.CurProcess.ProcessType;
		if (processType == GuideLineProcess.EProcessType.StartShow)
		{
			this.UpdateQuestGuideline();
			return;
		}
		if (processType != GuideLineProcess.EProcessType.EndShow)
		{
			return;
		}
		this.ChangeAnimType(EAnimType.Hide);
	}

	// Token: 0x06013478 RID: 78968 RVA: 0x0055BF00 File Offset: 0x0055A100
	[NullableContext(2)]
	private void RefreshSpawn(TeleportContext teleportContext = null)
	{
		this.CurProcess = null;
		this.ProcessList.Clear();
		if (this.CurSpawn > 0f)
		{
			this.ProcessList.Add(new GuideLineProcess.EndShowProcess());
		}
		this.ProcessList.Add(new GuideLineProcess.StartShowProcess());
		this.TriggeredSpawn = true;
	}

	// Token: 0x06013479 RID: 78969 RVA: 0x0055BF53 File Offset: 0x0055A153
	private void DisableQuestGuideLine()
	{
		this.ProcessList.Add(new GuideLineProcess.EndShowProcess());
		if (ObjectUtils.IsValid(this.PersistentSpline))
		{
			BP_Fx_WayFinding_C persistentSpline = this.PersistentSpline;
			if (persistentSpline == null)
			{
				return;
			}
			persistentSpline.StopEffect();
		}
	}

	// Token: 0x0601347A RID: 78970 RVA: 0x0055BF84 File Offset: 0x0055A184
	public bool CheckCanShowGuideLine()
	{
		if (ModelBase<PlotModel>.Instance.IsInHighLevelPlot())
		{
			return false;
		}
		LogicTreeContainer currentTrack = this.GetCurrentTrack(null);
		if (currentTrack == null || !currentTrack.CanShowGuideLine())
		{
			this.DisableQuestGuideLine();
			return false;
		}
		if (currentTrack.IsAlwaysShowGuideLine())
		{
			return true;
		}
		double guideLineStartShowTime = ModelBase<GeneralLogicTreeModel>.Instance.GetGuideLineStartShowTime();
		if (this.GuideLineShowTime == 0.0)
		{
			string globalConfig = ConfigBase<QuestNewConfig>.Instance.GetGlobalConfig("GuideLineShowTime");
			if (!string.IsNullOrEmpty(globalConfig))
			{
				double.TryParse(globalConfig, out this.GuideLineShowTime);
			}
		}
		return Singleton<TimeUtil>.Instance.GetServerTime() - guideLineStartShowTime <= this.GuideLineShowTime;
	}

	// Token: 0x0601347B RID: 78971 RVA: 0x0055C024 File Offset: 0x0055A224
	private bool UpdateMovingState()
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		BaseMoveComponent baseMoveComponent;
		if (getCurrentEntity == null)
		{
			baseMoveComponent = null;
		}
		else
		{
			WorldEntity entity = getCurrentEntity.Entity;
			baseMoveComponent = ((entity != null) ? entity.GetComponent<BaseMoveComponent>() : null);
		}
		BaseMoveComponent baseMoveComponent2 = baseMoveComponent;
		if (baseMoveComponent2 == null)
		{
			this.SetMovingState(false);
			return false;
		}
		return this.SetMovingState(baseMoveComponent2.IsMoving);
	}

	// Token: 0x0601347C RID: 78972 RVA: 0x0055C070 File Offset: 0x0055A270
	private void UpdateCurSpawn(float delta)
	{
		if (this.CurProcess == null || !ObjectUtils.IsValid(this.PersistentSpline))
		{
			return;
		}
		this.TimeElapse = Singleton<MathUtils>.Instance.Clamp(this.TimeElapse + delta / 50f, 0f, 1f);
		this.CurSpawn = Singleton<MathUtils>.Instance.Lerp(this.LerpStartSpawn, this.LerpTargetSpawn, this.TimeElapse);
		this.PersistentSpline.NS_Fx_WayFinding.SetNiagaraVariableFloat("Spawn", this.CurSpawn);
		if (this.TimeElapse >= 1f && this.LastTimeElapse < 1f)
		{
			this.FinishLerp();
		}
		this.LastTimeElapse = this.TimeElapse;
	}

	// Token: 0x0601347D RID: 78973 RVA: 0x0055C124 File Offset: 0x0055A324
	private void FinishLerp()
	{
		this.CurProcess.Finished = true;
		this.ProcessList.RemoveAt(0);
		this.CurProcess = null;
	}

	// Token: 0x0601347E RID: 78974 RVA: 0x0055C148 File Offset: 0x0055A348
	private void UpdateQuestGuideline()
	{
		if (!ObjectUtils.IsValid(this.PersistentSpline))
		{
			Singleton<Log>.Instance.Error(ELogModule.Quest, ELogAuthor.YSQ, "GuideLineAssistant:UE.BP_Fx_WayFinding_C还未加载", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		LogicTreeContainer currentTrack = this.GetCurrentTrack(null);
		if (currentTrack == null)
		{
			this.DisableQuestGuideLine();
			return;
		}
		BehaviorNodeBase showGuideLineNode = currentTrack.GetShowGuideLineNode();
		if (showGuideLineNode == null)
		{
			this.DisableQuestGuideLine();
			return;
		}
		global::Vector nodeTrackPosition = currentTrack.GetNodeTrackPosition(showGuideLineNode.NodeId);
		global::Vector playerLocation = Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation();
		if (nodeTrackPosition == null || playerLocation == null)
		{
			this.DisableQuestGuideLine();
			return;
		}
		this.StartVector.Set(playerLocation.X, playerLocation.Y, playerLocation.Z);
		UObject world = GlobalData.World;
		FVector fvector = this.StartVector.ToUeVectorOld();
		FVector fvector2 = nodeTrackPosition.ToUeVectorOld();
		URoadNetNavigationPath uroadNetNavigationPath = URoadNetNavigationSystem.RoadNet_FindPathToLocationSynchronously(world, fvector, fvector2);
		if (uroadNetNavigationPath == null || uroadNetNavigationPath.PathPoints.Num() == 0)
		{
			this.DisableQuestGuideLine();
			return;
		}
		double num = (double)uroadNetNavigationPath.Length;
		double? num2 = currentTrack.GetGuideLineHideDistance(showGuideLineNode.NodeId) * (double)100;
		if (num <= num2.GetValueOrDefault() & num2 != null)
		{
			this.DisableQuestGuideLine();
			return;
		}
		this.PathPointsPersistent.Empty(true);
		for (int i = 0; i < uroadNetNavigationPath.PathPoints.Num(); i++)
		{
			FVectorDouble value = UKismetMathLibrary.Conv_VectorToVectorDouble(uroadNetNavigationPath.PathPoints.Get(i));
			this.PathPointsPersistent.Add(value);
		}
		this.UpdatePersistentSpline(this.PersistentSpline.Spline, this.PathPointsPersistent, 4);
		this.PersistentSpline.EnsureEffect();
		BehaviorNodeBase currentActiveChildQuestNode = currentTrack.GetCurrentActiveChildQuestNode();
		if (currentActiveChildQuestNode != null)
		{
			this.PersistentSpline.NS_Fx_WayFinding.SetIntParameter(FNameUtil.GetDynamicFName("Type") ?? FNameUtil.NONE, (int)currentActiveChildQuestNode.NavigationStyle);
		}
	}

	// Token: 0x0601347F RID: 78975 RVA: 0x0055C33C File Offset: 0x0055A53C
	private void UpdatePersistentSpline(USplineComponent spline, TArray<FVectorDouble> pathPoints, int stepFactor)
	{
		spline.ClearSplinePoints(true);
		TArray<FVectorDouble> tarray = new TArray<FVectorDouble>();
		for (int i = 0; i < pathPoints.Num() - 1; i++)
		{
			FVectorDouble fvectorDouble = pathPoints.Get(i);
			FVectorDouble fvectorDouble2 = pathPoints.Get(i + 1);
			tarray.Add(fvectorDouble);
			if (Math.Abs(fvectorDouble2.Z - fvectorDouble.Z) > 2000.0)
			{
				break;
			}
			if (i + 1 == pathPoints.Num() - 1)
			{
				tarray.Add(fvectorDouble2);
			}
		}
		spline.D_SetSplinePoints(tarray, ESplineCoordinateSpace.World, true);
		this.QuestGuidePoints.Empty(true);
		float splineLength = spline.GetSplineLength();
		for (int j = 0; j < spline.GetNumberOfSplinePoints() - 1; j++)
		{
			float distanceAlongSplineAtSplinePoint = spline.GetDistanceAlongSplineAtSplinePoint(j);
			float distanceAlongSplineAtSplinePoint2 = spline.GetDistanceAlongSplineAtSplinePoint(j + 1);
			float num = (distanceAlongSplineAtSplinePoint2 - distanceAlongSplineAtSplinePoint) / (float)stepFactor;
			float num2 = distanceAlongSplineAtSplinePoint;
			while (num2 <= distanceAlongSplineAtSplinePoint2 && num2 <= splineLength)
			{
				FVectorDouble fvectorDouble3 = spline.D_GetLocationAtDistanceAlongSpline(num2, ESplineCoordinateSpace.World);
				FVectorDouble fvectorDouble4 = default(FVectorDouble);
				bool flag = UNavigationSystemV1.D_K2_ProjectPointToNavigation(GlobalData.World, fvectorDouble3, ref fvectorDouble4, null, default(TSubclassOf<UNavigationQueryFilter>), this.ProjectQueryExtVector.ToUeVector(false), -1.0);
				FVectorDouble value = fvectorDouble3;
				if (flag)
				{
					value = fvectorDouble4;
				}
				this.QuestGuidePoints.Add(value);
				num2 += num;
			}
		}
		spline.D_SetSplinePoints(this.QuestGuidePoints, ESplineCoordinateSpace.World, true);
		this.ChangeAnimType(EAnimType.Show);
	}

	// Token: 0x06013480 RID: 78976 RVA: 0x0055C498 File Offset: 0x0055A698
	private void ChangeAnimType(EAnimType type)
	{
		this.LerpStartSpawn = this.CurSpawn;
		this.TimeElapse = 0f;
		this.LastTimeElapse = 0f;
		if (type == EAnimType.Show)
		{
			this.LerpTargetSpawn = 2f;
			return;
		}
		if (type != EAnimType.Hide)
		{
			return;
		}
		this.LerpTargetSpawn = 0f;
	}

	// Token: 0x06013481 RID: 78977 RVA: 0x0055C4E7 File Offset: 0x0055A6E7
	private bool SetMovingState(bool value)
	{
		if (this.Moving != value)
		{
			this.Moving = value;
			return true;
		}
		return false;
	}

	// Token: 0x06013482 RID: 78978 RVA: 0x0055C4FC File Offset: 0x0055A6FC
	[NullableContext(2)]
	private LogicTreeContainer GetCurrentTrack(BtType? btType = null)
	{
		BtType btType2 = btType ?? this.CurBtType;
		LogicTreeContainer result = null;
		switch (btType2)
		{
		case BtType.Quest:
		case BtType.Recall:
			result = ModelBase<QuestNewModel>.Instance.GetCurTrackedQuest();
			break;
		case BtType.LevelPlay:
			result = ModelBase<LevelPlayModel>.Instance.GetTrackLevelPlayInfo();
			break;
		}
		return result;
	}

	// Token: 0x0400968C RID: 38540
	private const int QUERY_VALUE = 500;

	// Token: 0x0400968D RID: 38541
	private const int SPLIT_Z_LIMIT = 2000;

	// Token: 0x0400968E RID: 38542
	private readonly IReadOnlyList<BtType> BtTypes = Array.Empty<BtType>();

	// Token: 0x0400968F RID: 38543
	private BtType CurBtType;

	// Token: 0x04009690 RID: 38544
	[Nullable(2)]
	private BP_Fx_WayFinding_C PersistentSpline;

	// Token: 0x04009691 RID: 38545
	[Nullable(2)]
	private TArray<FVectorDouble> PathPointsPersistent;

	// Token: 0x04009692 RID: 38546
	private readonly List<GuideLineProcess.PendingProcess> ProcessList = new List<GuideLineProcess.PendingProcess>();

	// Token: 0x04009693 RID: 38547
	[Nullable(2)]
	private GuideLineProcess.PendingProcess CurProcess;

	// Token: 0x04009694 RID: 38548
	private double GuideLineShowTime;

	// Token: 0x04009695 RID: 38549
	private readonly TArray<FVectorDouble> QuestGuidePoints = new TArray<FVectorDouble>();

	// Token: 0x04009696 RID: 38550
	private readonly global::Vector StartVector = global::Vector.Create();

	// Token: 0x04009697 RID: 38551
	private readonly global::Vector ProjectQueryExtVector = global::Vector.Create(500.0, 500.0, 500.0);

	// Token: 0x04009698 RID: 38552
	private float LerpStartSpawn;

	// Token: 0x04009699 RID: 38553
	private float LerpTargetSpawn;

	// Token: 0x0400969A RID: 38554
	private float LastTimeElapse;

	// Token: 0x0400969B RID: 38555
	private float CurSpawn;

	// Token: 0x0400969C RID: 38556
	private float TimeElapse;

	// Token: 0x0400969D RID: 38557
	private bool Moving;

	// Token: 0x0400969E RID: 38558
	private bool TriggeredSpawn;
}
