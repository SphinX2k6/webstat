using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.MonsterGroup;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x020030C6 RID: 12486
[NullableContext(1)]
[Nullable(0)]
public class BaseMoveCharacter
{
	// Token: 0x170022B4 RID: 8884
	// (get) Token: 0x06019BF3 RID: 105459 RVA: 0x0077F268 File Offset: 0x0077D468
	public global::Vector CurrentToLocation
	{
		get
		{
			return this.PointsLogic.TargetPoint.Position;
		}
	}

	// Token: 0x06019BF4 RID: 105460 RVA: 0x0077F27C File Offset: 0x0077D47C
	public void Init(Entity entity)
	{
		this.Entity = entity;
		this.ActorComp = this.Entity.GetComponent<CharacterActorComponent>();
		this.UnifiedComp = this.Entity.GetComponent<BaseUnifiedStateComponent>();
		this.AiComp = this.Entity.GetComponent<CharacterAiComponent>();
		this.PbDataId = this.ActorComp.CreatureData.GetPbDataId();
		this.CachePath = new List<global::Vector>();
		this.Moving = false;
		this.PointsLogic.Init(this.ActorComp);
		this.MoveLogic.Init(this.Entity);
		if (!Singleton<EventSystem>.Instance.HasWithTarget<global::ECharPositionState, global::ECharPositionState>(this.Entity, EEventName.CharOnPositionStateChanged, new Action<global::ECharPositionState, global::ECharPositionState>(this.OnPositionStateChange)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget<global::ECharPositionState, global::ECharPositionState>(this.Entity, EEventName.CharOnPositionStateChanged, new Action<global::ECharPositionState, global::ECharPositionState>(this.OnPositionStateChange));
		}
	}

	// Token: 0x06019BF5 RID: 105461 RVA: 0x0077F354 File Offset: 0x0077D554
	public void UpdateMove(float deltaSeconds)
	{
		if (!this.IsRunning)
		{
			return;
		}
		if (this.PointsLogic.TargetPoint == null)
		{
			this.MoveEnd(ELevelEventState.Failure);
			return;
		}
		this.DeltaTime += (double)deltaSeconds;
		if (this.DeltaTime > 1.0)
		{
			this.DeltaTime = 0.0;
			this.UpdateMoveStateAndSpeed();
		}
		if (GlobalData.IsPlayInEditor && MoveToLocationController.DebugDraw)
		{
			this.DrawDebug();
		}
		this.UpdateMoveInternal(deltaSeconds);
		if (this.AiComp != null && this.PointsLogic.FindNearestPointOnPath(this.CacheVector))
		{
			this.AiComp.HatredInitLocation.DeepCopy(this.CacheVector);
			foreach (CharacterAiComponent characterAiComponent in this.FollowerAiComps)
			{
				characterAiComponent.HatredInitLocation.DeepCopy(this.CacheVector);
			}
		}
	}

	// Token: 0x06019BF6 RID: 105462 RVA: 0x0077F450 File Offset: 0x0077D650
	private unsafe void UpdateMoveInternal(float deltaSeconds)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3;
		if (!this.IsFly)
		{
			BaseUnifiedStateComponent unifiedComp = this.UnifiedComp;
			flag3 = (unifiedComp != null && unifiedComp.PositionState == global::ECharPositionState.Climb);
		}
		else
		{
			flag3 = true;
		}
		bool flag4 = flag3;
		bool flag5 = this.MoveLogic.UpdateMove(deltaSeconds);
		int num = 0;
		while (!flag5 && this.IsRunning && num < 2)
		{
			num++;
			flag2 = (flag2 || this.PointsLogic.TargetPoint.Index >= 0);
			this.OnArriveMovePoint();
			if (this.HandleArriveLastPoint(flag4, deltaSeconds))
			{
				return;
			}
			flag = true;
			if (!this.ChangeNextPoint())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.AI;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "未能正常获取下个移动点，巡逻失败结束";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", this.Entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", this.PbDataId);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.MoveEnd(ELevelEventState.Failure);
				return;
			}
			MoveCharacterConfig moveConfig = this.MoveConfig;
			if (moveConfig != null && moveConfig.ResetAllPoints.GetValueOrDefault())
			{
				break;
			}
			flag5 = this.MoveLogic.UpdateMove(deltaSeconds);
		}
		if (!flag4 && this.MoveLogic.ResetLastPointCondition() && this.CheckResetCondition())
		{
			this.ResetLastPatrolPoint(deltaSeconds);
		}
		if (flag && flag2)
		{
			this.SyncToController();
		}
		if (this.ReturnTimeoutFailed && deltaSeconds > 0.0001f)
		{
			this.CheckTimeout(deltaSeconds, flag);
		}
	}

	// Token: 0x06019BF7 RID: 105463 RVA: 0x0077F5C4 File Offset: 0x0077D7C4
	private bool HandleArriveLastPoint(bool climbOrFly, float deltaSeconds)
	{
		if (!this.PointsLogic.CheckMoveLastPoint())
		{
			return false;
		}
		bool flag = this.MoveLogic.ResetLastPointCondition();
		if (!climbOrFly && flag)
		{
			this.ResetLastPatrolPoint(deltaSeconds);
		}
		MoveCharacterConfig moveConfig = this.MoveConfig;
		if (moveConfig != null && moveConfig.EnablePlayerAccurateMoveToTarget.GetValueOrDefault())
		{
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.ClearInput(false, true);
			}
			this.MoveLogic.ForceSetToLastPatrolPoint(this.CurrentToLocation, deltaSeconds);
			if (this.UnifiedComp.Valid && CharacterUnifiedStateTypes.LegalMoveStates.GetValueOrDefault(this.UnifiedComp.PositionState).Contains(global::ECharMoveState.Stand))
			{
				this.UnifiedComp.SetMoveState(global::ECharMoveState.Stand);
			}
		}
		MoveCharacterConfig moveConfig2 = this.MoveConfig;
		if (moveConfig2 == null || !moveConfig2.NoAsyncPoint.GetValueOrDefault())
		{
			this.SyncToController();
		}
		this.MoveEnd(ELevelEventState.Success);
		return true;
	}

	// Token: 0x06019BF8 RID: 105464 RVA: 0x0077F69C File Offset: 0x0077D89C
	private void ResetLastPatrolPoint(float deltaSeconds)
	{
		this.MoveLogic.ResetLastPatrolPoint(deltaSeconds);
		this.CacheVector.DeepCopy(this.CurrentToLocation);
		this.CacheVector.SubtractionEqual(this.ActorComp.ActorLocationProxy);
		if (!this.IsFly)
		{
			this.CacheVector.Z = 0.0;
		}
		this.CacheVector.Normalize(9.99999993922529E-09);
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp != null)
		{
			actorComp.ClearInput(false, true);
		}
		CharacterActorComponent actorComp2 = this.ActorComp;
		if (actorComp2 != null)
		{
			actorComp2.SetInputDirect(this.CacheVector, false);
		}
		double inB = this.ActorComp.ActorVelocityProxy.Size();
		this.CacheVector.MultiplyEqual(inB);
		this.ActorComp.ActorVelocityProxy.Set(this.CacheVector.X, this.CacheVector.Y, this.CacheVector.Z);
		MoveCharacterConfig moveConfig = this.MoveConfig;
		if (moveConfig == null)
		{
			return;
		}
		Action onResetLocationCallback = moveConfig.OnResetLocationCallback;
		if (onResetLocationCallback == null)
		{
			return;
		}
		onResetLocationCallback();
	}

	// Token: 0x06019BF9 RID: 105465 RVA: 0x0077F7A8 File Offset: 0x0077D9A8
	private unsafe void CheckTimeout(float deltaSeconds, bool changePoint)
	{
		double num = global::Vector.Dist(this.ActorComp.ActorLocationProxy, this.CurrentToLocation);
		if (Math.Abs(this.LastFrameDistance - num) / (double)deltaSeconds > 30.0 || this.LastFrameDistance == 0.0 || changePoint)
		{
			this.CurTimeoutTime = this.TimeoutTime;
		}
		else
		{
			this.CurTimeoutTime -= (double)deltaSeconds;
			if (this.CurTimeoutTime <= 0.0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.AI;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "检测到移动行为不符合预期,持续卡住超时,返回移动失败";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", this.Entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", this.PbDataId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("超时时限", this.TimeoutTime);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				this.MoveEnd(ELevelEventState.Failure);
				return;
			}
		}
		this.LastFrameDistance = num;
	}

	// Token: 0x06019BFA RID: 105466 RVA: 0x0077F8D0 File Offset: 0x0077DAD0
	private bool ChangeNextPoint()
	{
		if (this.UsePreLocation)
		{
			this.UsePreLocation = false;
		}
		return this.PointsLogic.ChangeToNextPoint() && this.GenerateMovePoint(this.PointsLogic.GetPreviousLocation(), this.PointsLogic.TargetPoint.Position, this.Navigation, false);
	}

	// Token: 0x06019BFB RID: 105467 RVA: 0x0077F924 File Offset: 0x0077DB24
	private bool CheckResetCondition()
	{
		MoveCharacterConfig moveConfig = this.MoveConfig;
		if (moveConfig != null && moveConfig.ResetAllPoints.GetValueOrDefault())
		{
			return true;
		}
		global::Vector previousLocation = this.PointsLogic.GetPreviousLocation();
		if (previousLocation == null)
		{
			return false;
		}
		this.CacheVector.DeepCopy(this.ActorComp.ActorLocationProxy);
		this.CacheVector.SubtractionEqual(previousLocation);
		if (!this.IsFly)
		{
			this.CacheVector.Z = 0.0;
		}
		double num = this.CacheVector.Size();
		this.CacheVector2.DeepCopy(this.CurrentToLocation);
		this.CacheVector2.SubtractionEqual(previousLocation);
		if (!this.IsFly)
		{
			this.CacheVector2.Z = 0.0;
		}
		double num2 = this.CacheVector2.Size();
		if (num == 0.0 || num2 == 0.0)
		{
			return false;
		}
		double d = this.CacheVector.DotProduct(this.CacheVector2) / (num * num2);
		double num3 = 57.295780181884766 * Math.Acos(d);
		this.CacheVector.CrossProduct(this.CacheVector2, this.CacheVector);
		double num4 = this.CacheVector.Size() / num2;
		return num3 <= 0.0 || num3 >= 20.0 || num4 >= 50.0;
	}

	// Token: 0x06019BFC RID: 105468 RVA: 0x0077FA80 File Offset: 0x0077DC80
	public void StopMove()
	{
		if (!this.IsRunning)
		{
			return;
		}
		this.ActorComp.ClearInput(false, true);
		this.PointsLogic.UpdatePreIndex();
		this.StopMoveInternal();
	}

	// Token: 0x06019BFD RID: 105469 RVA: 0x0077FAAA File Offset: 0x0077DCAA
	public void Dispose()
	{
		this.StopMoveInternal();
	}

	// Token: 0x06019BFE RID: 105470 RVA: 0x0077FAB4 File Offset: 0x0077DCB4
	private void StopMoveInternal()
	{
		this.MoveLogic.StopMove();
		this.CachePath = new List<global::Vector>();
		this.Moving = false;
		this.UsePreLocation = true;
		this.PreLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		if (this.Entity != null && Singleton<EventSystem>.Instance.HasWithTarget<global::ECharPositionState, global::ECharPositionState>(this.Entity, EEventName.CharOnPositionStateChanged, new Action<global::ECharPositionState, global::ECharPositionState>(this.OnPositionStateChange)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<global::ECharPositionState, global::ECharPositionState>(this.Entity, EEventName.CharOnPositionStateChanged, new Action<global::ECharPositionState, global::ECharPositionState>(this.OnPositionStateChange));
		}
	}

	// Token: 0x06019BFF RID: 105471 RVA: 0x0077FB48 File Offset: 0x0077DD48
	public unsafe void MoveAlongPath(MoveCharacterConfig config)
	{
		if (this.ActorComp == null)
		{
			Entity entity = this.Entity;
			CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "[BaseMoveCharacter.MoveAlongPath]获取ActorComp失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataId", (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPbDataId()) : null);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.Moving = true;
		this.MoveConfig = config;
		this.TurnSpeed = config.TurnSpeed.GetValueOrDefault(360f);
		this.Navigation = (config.Navigation && !config.IsFly);
		this.Distance = config.Distance.GetValueOrDefault(30f);
		this.OnMoveEndCallback = config.Callback;
		if (config.ReturnTimeoutFailed != null && config.ReturnTimeoutFailed.Value != 0f)
		{
			this.ReturnTimeoutFailed = true;
			this.TimeoutTime = (double)config.ReturnTimeoutFailed.Value;
			this.CurTimeoutTime = (double)config.ReturnTimeoutFailed.Value;
		}
		else
		{
			this.ReturnTimeoutFailed = false;
		}
		this.PointsLogic.UpdateMovePoints(config);
		CharacterAiComponent aiComp = this.AiComp;
		if (aiComp != null)
		{
			aiComp.InitPathMovePoints(config);
		}
		MonsterPatrolInfo monsterInfoByEntityId = ModelBase<MonsterGroupPatrolModel>.Instance.GetMonsterInfoByEntityId(this.Entity.Id);
		this.FollowerAiComps.Clear();
		if (((monsterInfoByEntityId != null) ? monsterInfoByEntityId.Group : null) != null && monsterInfoByEntityId.Group.GroupInfo.Count > 0)
		{
			foreach (MonsterPatrolInfo monsterPatrolInfo in monsterInfoByEntityId.Group.GroupInfo.Values)
			{
				if (!monsterPatrolInfo.IsCaptain)
				{
					CharacterAiComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterAiComponent>(monsterPatrolInfo.EntityId);
					if (component != null)
					{
						component.InitPathMovePoints(config);
						this.FollowerAiComps.Add(component);
					}
				}
			}
		}
		MoveCharacterPoint targetPoint = this.PointsLogic.TargetPoint;
		this.IsFly = ((targetPoint != null && targetPoint.PosState.GetValueOrDefault() == global::ECharPositionState.Air) || config.IsFly);
		this.UpdateMoveStateAndSpeed();
		double num = global::Vector.Dist2D(this.PreLocation, this.ActorComp.ActorLocationProxy);
		bool flag;
		if (config.UsePreviousIndex.GetValueOrDefault() && this.UsePreLocation && num > (double)this.Distance)
		{
			flag = this.GenerateMovePoint(this.PreLocation, this.PointsLogic.TargetPoint.Position, num > 200.0 || this.Navigation, true);
		}
		else
		{
			this.UsePreLocation = false;
			flag = this.GenerateMovePoint(null, this.PointsLogic.TargetPoint.Position, this.Navigation || config.NavigateToStartPos.GetValueOrDefault(), true);
		}
		if (!flag)
		{
			this.MoveEnd(ELevelEventState.Failure);
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.AI;
			ELogAuthor author2 = ELogAuthor.CWZ;
			string message2 = "未正常生成寻路路径，巡逻失败结束";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", this.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", this.PbDataId);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x06019C00 RID: 105472 RVA: 0x0077FEA0 File Offset: 0x0077E0A0
	public void MoveEnd(ELevelEventState endState)
	{
		this.UsePreLocation = false;
		this.StopMove();
		this.PointsLogic.Reset();
		this.OnMoveActionEnd(endState);
		if (this.PlayerWalkState)
		{
			this.SetPlayerWalkOrRun(global::ECharMoveState.Run);
			this.PlayerWalkState = false;
		}
	}

	// Token: 0x06019C01 RID: 105473 RVA: 0x0077FEE4 File Offset: 0x0077E0E4
	private bool GenerateMovePoint([Nullable(2)] global::Vector start, global::Vector end, bool navigation, bool selfPos)
	{
		this.MovePath = new List<global::Vector>();
		if (selfPos || start == null)
		{
			this.CacheMovePoint.DeepCopy(this.ActorComp.LastActorLocation);
			if (!this.IsFly)
			{
				this.CacheMovePoint.Z -= (double)this.ActorComp.HalfHeight;
			}
			this.MovePath.Add(this.CacheMovePoint);
		}
		if (start != null)
		{
			this.MovePath.Add(start);
		}
		this.MovePath.Add(end);
		if (!navigation)
		{
			this.MoveLogic.UpdateMovePath(this.MovePath, this.IsFly, this.TurnSpeed, this.Distance);
			return true;
		}
		this.NavigationPath = new List<global::Vector>();
		this.NavigationPath.Add(this.MovePath[0]);
		for (int i = 0; i < this.MovePath.Count - 1; i++)
		{
			this.CachePath = new List<global::Vector>();
			if (global::Vector.Dist2D(this.MovePath[i], this.MovePath[i + 1]) < (double)this.Distance)
			{
				this.NavigationPath.Add(this.MovePath[i + 1]);
			}
			else if (this.AddNavigationPath(this.MovePath[i], this.MovePath[i + 1], this.CachePath))
			{
				for (int j = 1; j < this.CachePath.Count; j++)
				{
					this.NavigationPath.Add(this.CachePath[j]);
				}
			}
			else
			{
				MoveCharacterConfig moveConfig = this.MoveConfig;
				if (moveConfig != null && moveConfig.ReturnFalseWhenNavigationFailed)
				{
					return false;
				}
				this.NavigationPath.Add(this.MovePath[i + 1]);
			}
		}
		this.MoveLogic.UpdateMovePath(this.NavigationPath, this.IsFly, this.TurnSpeed, this.Distance);
		return true;
	}

	// Token: 0x06019C02 RID: 105474 RVA: 0x007800D0 File Offset: 0x0077E2D0
	private bool AddNavigationPath(global::Vector start, global::Vector end, List<global::Vector> outPath)
	{
		UObject world = this.ActorComp.Owner.GetWorld();
		FVectorDouble from = start.ToUeVector(false);
		FVectorDouble to = end.ToUeVector(false);
		bool? ignoreZ = new bool?(false);
		MoveCharacterConfig moveConfig = this.MoveConfig;
		return AiControllerLibrary.NavigationFindPath(world, from, to, outPath, ignoreZ, (moveConfig != null) ? moveConfig.StrictNavigation : null) && outPath.Count > 0;
	}

	// Token: 0x06019C03 RID: 105475 RVA: 0x0078012E File Offset: 0x0077E32E
	private void OnMoveActionEnd(ELevelEventState result)
	{
		if (this.OnMoveEndCallback != null)
		{
			this.OnMoveEndCallback(result);
		}
	}

	// Token: 0x06019C04 RID: 105476 RVA: 0x00780144 File Offset: 0x0077E344
	public void PushMoveInfo()
	{
		EntitySimplyMoveInfoPackagePush entitySimplyMoveInfoPackagePush = EntitySimplyMoveInfoPackagePush.Create();
		EntitySimplyMoveInfo entitySimplyMoveInfo = EntitySimplyMoveInfo.Create();
		entitySimplyMoveInfo.EntityId = Singleton<MathUtils>.Instance.NumberToLong(this.ActorComp.CreatureData.GetCreatureDataId());
		entitySimplyMoveInfo.Location = Aki.Protocol.Vector.Create();
		entitySimplyMoveInfo.Location.X = (float)this.ActorComp.ActorLocationProxy.X;
		entitySimplyMoveInfo.Location.Y = (float)this.ActorComp.ActorLocationProxy.Y;
		entitySimplyMoveInfo.Location.Z = (float)this.ActorComp.ActorLocationProxy.Z;
		entitySimplyMoveInfo.Rotation = null;
		entitySimplyMoveInfoPackagePush.MoveInfos.Add(entitySimplyMoveInfo);
		Singleton<Net>.Instance.Send(EPushMessageId.EntitySimplyMoveInfoPackagePush, entitySimplyMoveInfoPackagePush);
	}

	// Token: 0x06019C05 RID: 105477 RVA: 0x00780200 File Offset: 0x0077E400
	private void OnArriveMovePoint()
	{
		this.UpdateMoveStateAndSpeed();
		this.PointsLogic.OnArriveMovePoint();
		MoveCharacterPoint targetPoint = this.PointsLogic.TargetPoint;
		if (targetPoint != null && targetPoint.PosState != null)
		{
			MoveCharacterPoint targetPoint2 = this.PointsLogic.TargetPoint;
			this.IsFly = (targetPoint2 != null && targetPoint2.PosState.GetValueOrDefault() == global::ECharPositionState.Air);
		}
	}

	// Token: 0x06019C06 RID: 105478 RVA: 0x00780261 File Offset: 0x0077E461
	private void SyncToController()
	{
		MoveCharacterConfig moveConfig = this.MoveConfig;
		if (moveConfig != null && moveConfig.NoAsyncPoint.GetValueOrDefault())
		{
			return;
		}
		BaseMoveComponent component = this.Entity.GetComponent<BaseMoveComponent>();
		if (component == null)
		{
			return;
		}
		component.MoveController.PushMoveInfo();
	}

	// Token: 0x06019C07 RID: 105479 RVA: 0x00780298 File Offset: 0x0077E498
	private void OnPositionStateChange(global::ECharPositionState oldPositionState, global::ECharPositionState newPositionState)
	{
		if (this.PointsLogic.TargetPoint == null)
		{
			return;
		}
		global::ECharMoveState? moveState = this.GetMoveState(this.PointsLogic.TargetPoint.MoveState);
		if (moveState != null && CharacterUnifiedStateTypes.LegalMoveStates.GetValueOrDefault(newPositionState).Contains(moveState.Value))
		{
			this.UnifiedComp.SetMoveState(moveState.Value);
		}
	}

	// Token: 0x06019C08 RID: 105480 RVA: 0x00780300 File Offset: 0x0077E500
	private void UpdateMoveStateAndSpeed()
	{
		if (this.PointsLogic.TargetPoint == null)
		{
			return;
		}
		BaseMoveComponent component = this.Entity.GetComponent<BaseMoveComponent>();
		if (component == null)
		{
			return;
		}
		float? moveSpeed = this.PointsLogic.TargetPoint.MoveSpeed;
		if (this.IsFly)
		{
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
				{
					Mode = EMovementMode.MOVE_Flying,
					Context = "[BaseMoveCharacter.UpdateMoveStateAndSpeed]"
				});
			}
			if (moveSpeed != null && moveSpeed.Value != 0f)
			{
				component.SetMaxSpeed(moveSpeed.Value);
			}
			return;
		}
		if (moveSpeed != null && moveSpeed.Value != 0f)
		{
			component.SetMaxSpeed(moveSpeed.Value);
		}
		global::ECharMoveState? moveState = this.GetMoveState(this.PointsLogic.TargetPoint.MoveState);
		if (moveState != null && CharacterUnifiedStateTypes.LegalMoveStates.GetValueOrDefault(this.UnifiedComp.PositionState).Contains(moveState.Value))
		{
			if (moveState.Value == global::ECharMoveState.Walk || moveState.Value == global::ECharMoveState.Run)
			{
				this.SetPlayerWalkOrRun(moveState.Value);
			}
			this.UnifiedComp.SetMoveState(moveState.Value);
		}
	}

	// Token: 0x06019C09 RID: 105481 RVA: 0x00780430 File Offset: 0x0077E630
	private void SetPlayerWalkOrRun(global::ECharMoveState state)
	{
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp == null || !actorComp.IsRoleAndCtrlByMe)
		{
			return;
		}
		if (this.UnifiedComp is CharacterUnifiedStateComponent)
		{
			(this.UnifiedComp as CharacterUnifiedStateComponent).MarkWalkOrRun(state == global::ECharMoveState.Walk, true, null);
			this.PlayerWalkState = (state == global::ECharMoveState.Walk);
		}
	}

	// Token: 0x06019C0A RID: 105482 RVA: 0x0078048C File Offset: 0x0077E68C
	private global::ECharMoveState? GetMoveState(EPatrolMoveState? state)
	{
		if (state != null)
		{
			BaseUnifiedStateComponent unifiedComp = this.UnifiedComp;
			if (unifiedComp != null && unifiedComp.Valid)
			{
				switch (state.Value)
				{
				case EPatrolMoveState.Walk:
					if (this.UnifiedComp.PositionState == global::ECharPositionState.Water)
					{
						return new global::ECharMoveState?(global::ECharMoveState.NormalSwim);
					}
					if (this.UnifiedComp.PositionState == global::ECharPositionState.Climb)
					{
						return new global::ECharMoveState?(global::ECharMoveState.NormalClimb);
					}
					return new global::ECharMoveState?(global::ECharMoveState.Walk);
				case EPatrolMoveState.Run:
					if (this.UnifiedComp.PositionState == global::ECharPositionState.Water)
					{
						return new global::ECharMoveState?(global::ECharMoveState.FastSwim);
					}
					if (this.UnifiedComp.PositionState == global::ECharPositionState.Climb)
					{
						return new global::ECharMoveState?(global::ECharMoveState.FastClimb);
					}
					return new global::ECharMoveState?(global::ECharMoveState.Run);
				case EPatrolMoveState.Sprint:
					if (this.UnifiedComp.PositionState == global::ECharPositionState.Water)
					{
						return new global::ECharMoveState?(global::ECharMoveState.FastSwim);
					}
					if (this.UnifiedComp.PositionState == global::ECharPositionState.Climb)
					{
						return new global::ECharMoveState?(global::ECharMoveState.FastClimb);
					}
					return new global::ECharMoveState?(global::ECharMoveState.Sprint);
				}
			}
		}
		return null;
	}

	// Token: 0x06019C0B RID: 105483 RVA: 0x00780580 File Offset: 0x0077E780
	private void DrawDebug()
	{
		if (this.PointsLogic.MovePoint.Count == 0 || !GlobalData.IsPlayInEditor)
		{
			return;
		}
		int segments = 10;
		int num = 30;
		for (int i = this.PointsLogic.MovePoint.Count - 1; i > -1; i--)
		{
			global::Vector position = this.PointsLogic.MovePoint[i].Position;
			UKismetSystemLibrary.D_DrawDebugSphere(GlobalData.World, position.ToUeVector(false), (float)num, segments, new FLinearColor?((i == this.PointsLogic.TargetIndex) ? ColorUtils.LinearYellow : ColorUtils.LinearWhite), 1f, 0f);
		}
	}

	// Token: 0x170022B5 RID: 8885
	// (get) Token: 0x06019C0C RID: 105484 RVA: 0x0078061E File Offset: 0x0077E81E
	public bool IsRunning
	{
		get
		{
			return this.Moving;
		}
	}

	// Token: 0x0400CD2B RID: 52523
	private const int DEFAULT_TURN_SPEED = 360;

	// Token: 0x0400CD2C RID: 52524
	private const int END_DISTANCE = 30;

	// Token: 0x0400CD2D RID: 52525
	private const int NAV_DISTANCE = 200;

	// Token: 0x0400CD2E RID: 52526
	private const int NO_RESET_ANGLE = 20;

	// Token: 0x0400CD2F RID: 52527
	private const int NO_RESET_DISTANCE = 50;

	// Token: 0x0400CD30 RID: 52528
	private const int PER_TICK_MIN_MOVE_SPEED = 30;

	// Token: 0x0400CD31 RID: 52529
	private const int WHILE_UPDATE_MOVE_POINT_COUNT = 2;

	// Token: 0x0400CD32 RID: 52530
	private int PbDataId;

	// Token: 0x0400CD33 RID: 52531
	[Nullable(2)]
	private Entity Entity;

	// Token: 0x0400CD34 RID: 52532
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400CD35 RID: 52533
	[Nullable(2)]
	private BaseUnifiedStateComponent UnifiedComp;

	// Token: 0x0400CD36 RID: 52534
	[Nullable(2)]
	private CharacterAiComponent AiComp;

	// Token: 0x0400CD37 RID: 52535
	private List<CharacterAiComponent> FollowerAiComps = new List<CharacterAiComponent>();

	// Token: 0x0400CD38 RID: 52536
	[Nullable(2)]
	private MoveCharacterConfig MoveConfig;

	// Token: 0x0400CD39 RID: 52537
	private float Distance;

	// Token: 0x0400CD3A RID: 52538
	private bool IsFly;

	// Token: 0x0400CD3B RID: 52539
	private bool Navigation;

	// Token: 0x0400CD3C RID: 52540
	private float TurnSpeed;

	// Token: 0x0400CD3D RID: 52541
	private bool UsePreLocation;

	// Token: 0x0400CD3E RID: 52542
	private readonly global::Vector PreLocation = global::Vector.Create();

	// Token: 0x0400CD3F RID: 52543
	private bool ReturnTimeoutFailed;

	// Token: 0x0400CD40 RID: 52544
	private double TimeoutTime;

	// Token: 0x0400CD41 RID: 52545
	private double CurTimeoutTime;

	// Token: 0x0400CD42 RID: 52546
	private double LastFrameDistance;

	// Token: 0x0400CD43 RID: 52547
	private readonly global::Vector CacheVector = global::Vector.Create();

	// Token: 0x0400CD44 RID: 52548
	private readonly global::Vector CacheVector2 = global::Vector.Create();

	// Token: 0x0400CD45 RID: 52549
	private readonly global::Vector CacheMovePoint = global::Vector.Create();

	// Token: 0x0400CD46 RID: 52550
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<global::Vector> CachePath;

	// Token: 0x0400CD47 RID: 52551
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<global::Vector> MovePath;

	// Token: 0x0400CD48 RID: 52552
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<global::Vector> NavigationPath;

	// Token: 0x0400CD49 RID: 52553
	private double DeltaTime;

	// Token: 0x0400CD4A RID: 52554
	private bool Moving;

	// Token: 0x0400CD4B RID: 52555
	[Nullable(2)]
	private Action<ELevelEventState> OnMoveEndCallback;

	// Token: 0x0400CD4C RID: 52556
	private readonly PatrolMovePointsLogic PointsLogic = new PatrolMovePointsLogic();

	// Token: 0x0400CD4D RID: 52557
	private readonly PatrolMoveLogic MoveLogic = new PatrolMoveLogic();

	// Token: 0x0400CD4E RID: 52558
	private bool PlayerWalkState;
}
