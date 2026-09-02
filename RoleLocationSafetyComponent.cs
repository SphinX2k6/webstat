using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Teleport;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020031FB RID: 12795
[NullableContext(1)]
[Nullable(0)]
public class RoleLocationSafetyComponent : EntityComponent, IComponentDependency, IStaticVariableResetter
{
	// Token: 0x0601A8A1 RID: 108705 RVA: 0x007DA020 File Offset: 0x007D8220
	static RoleLocationSafetyComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(RoleLocationSafetyComponent.CreateStaticDefaultValue), new Action(RoleLocationSafetyComponent.ResetStaticDefaultValue));
	}

	// Token: 0x0601A8A2 RID: 108706 RVA: 0x007DA07A File Offset: 0x007D827A
	public static void CreateStaticDefaultValue()
	{
		RoleLocationSafetyComponent.disableTag = new int[]
		{
			GameplayTagDefine.EGameplayTagId["角色.BaseRole.状态通用标识.动作.坐下"]
		};
	}

	// Token: 0x0601A8A3 RID: 108707 RVA: 0x007DA099 File Offset: 0x007D8299
	public static void ResetStaticDefaultValue()
	{
		RoleLocationSafetyComponent.disableTag = null;
	}

	// Token: 0x170023EF RID: 9199
	// (get) Token: 0x0601A8A4 RID: 108708 RVA: 0x007DA0A1 File Offset: 0x007D82A1
	public static Type[] Dependencies
	{
		get
		{
			return new Type[]
			{
				typeof(CharacterActorComponent),
				typeof(CharacterUnifiedStateComponent)
			};
		}
	}

	// Token: 0x0601A8A5 RID: 108709 RVA: 0x007DA0C4 File Offset: 0x007D82C4
	private unsafe void OnStateInherit(Entity oldEntity, bool _)
	{
		RoleLocationSafetyComponent component = oldEntity.GetComponent<RoleLocationSafetyComponent>();
		if (component == null)
		{
			return;
		}
		if (Singleton<MathUtils>.Instance.IsValidVector(component.LastValidLocation, 100000000))
		{
			this.LastValidLocation.DeepCopy(component.LastValidLocation);
		}
		else
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "Safety Inherit: Invalid Location";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "Char";
			CharacterActorComponent component2 = oldEntity.GetComponent<CharacterActorComponent>();
			object item2;
			if (component2 == null)
			{
				item2 = null;
			}
			else
			{
				TsBaseCharacter actor = component2.Actor;
				item2 = ((actor != null) ? actor.GetName() : null);
			}
			ptr = new ValueTuple<string, object>(item, item2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Location", component.LastValidLocation);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		if (Singleton<MathUtils>.Instance.IsValidRotator(component.LastValidRotator, 100000000))
		{
			this.LastValidRotator.DeepCopy(component.LastValidRotator);
		}
		else
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Movement;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "Safety Inherit: Invalid Rotator";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0);
			string item3 = "Char";
			CharacterActorComponent component3 = oldEntity.GetComponent<CharacterActorComponent>();
			object item4;
			if (component3 == null)
			{
				item4 = null;
			}
			else
			{
				TsBaseCharacter actor2 = component3.Actor;
				item4 = ((actor2 != null) ? actor2.GetName() : null);
			}
			ptr2 = new ValueTuple<string, object>(item3, item4);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Rotator", component.LastValidRotator);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		}
		if (!this.ActorComp.IsRoleAndCtrlByMe)
		{
			return;
		}
		this.SceneSafetyLocationRecorder.SafetyLocationConfigMap.Clear();
		foreach (KeyValuePair<long, LocationSafetyComponent> keyValuePair in component.SceneSafetyLocationRecorder.SafetyLocationConfigMap)
		{
			this.SceneSafetyLocationRecorder.SafetyLocationConfigMap[keyValuePair.Key] = keyValuePair.Value;
		}
		component.SceneSafetyLocationRecorder.SafetyLocationConfigMap.Clear();
		this.UpdateSafetyTestFreq();
		this.LastSafetyLocationRecorder.IsSafety = false;
		if (!component.LastSafetyLocationRecorder.IsSafety)
		{
			return;
		}
		CharacterActorComponent component4 = oldEntity.GetComponent<CharacterActorComponent>();
		if (component4.DefaultHalfHeight == this.ActorComp.DefaultHalfHeight && component4.DefaultRadius == this.ActorComp.DefaultRadius)
		{
			this.LastSafetyLocationRecorder.IsSafety = true;
			this.LastSafetyLocationRecorder.SafetyLocation.DeepCopy(component.LastSafetyLocationRecorder.SafetyLocation);
		}
		else
		{
			Vector vector = Vector.Create(component.LastSafetyLocationRecorder.SafetyLocation);
			vector.Z += (double)(this.ActorComp.DefaultHalfHeight - component4.DefaultHalfHeight);
			this.LastSafetyLocationRecorder.IsSafety = this.SafetyPlaceTest(vector);
			if (this.LastSafetyLocationRecorder.IsSafety)
			{
				this.LastSafetyLocationRecorder.SafetyLocation.DeepCopy(vector);
			}
		}
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.Movement;
		ELogAuthor author3 = ELogAuthor.LCZ;
		string message3 = "Inherit LastSafety";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("IsSafety", this.LastSafetyLocationRecorder.IsSafety);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("OldLocation", component.LastSafetyLocationRecorder.SafetyLocation);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("NewLocation", this.LastSafetyLocationRecorder.SafetyLocation);
		instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
	}

	// Token: 0x0601A8A6 RID: 108710 RVA: 0x007DA414 File Offset: 0x007D8614
	private void OnTeleportStart(bool b)
	{
		this.InTeleport = true;
	}

	// Token: 0x0601A8A7 RID: 108711 RVA: 0x007DA41D File Offset: 0x007D861D
	[NullableContext(2)]
	private void OnTeleportComplete(TeleportContext teleportContext)
	{
		this.InTeleport = false;
		this.LastSafetyLocationRecorder.IsSafety = false;
		this.NotSafetyCount = 0;
	}

	// Token: 0x0601A8A8 RID: 108712 RVA: 0x007DA439 File Offset: 0x007D8639
	private void OnElevatorMove()
	{
		this.LastSafetyLocationRecorder.IsSafety = false;
		this.NotSafetyCount = 0;
	}

	// Token: 0x0601A8A9 RID: 108713 RVA: 0x007DA44E File Offset: 0x007D864E
	private void OnGravityDirectChanged(Vector _1, bool _2)
	{
		this.LastSafetyLocationRecorder.IsSafety = false;
		this.NotSafetyCount = 0;
	}

	// Token: 0x0601A8AA RID: 108714 RVA: 0x007DA464 File Offset: 0x007D8664
	protected override bool OnStart()
	{
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		this.UnifiedComp = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
		Singleton<EventSystem>.Instance.AddWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
		Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.ElevatorMove, new Action(this.OnElevatorMove));
		Singleton<EventSystem>.Instance.AddWithTarget<Vector, bool>(base.Entity, EEventName.CharGravityDirectChanged, new Action<Vector, bool>(this.OnGravityDirectChanged));
		this.DisableTagCount = 0;
		BaseTagComponent component = base.Entity.GetComponent<BaseTagComponent>();
		if (component != null && RoleLocationSafetyComponent.disableTag != null)
		{
			foreach (int num in RoleLocationSafetyComponent.disableTag)
			{
				if (component.HasTag(num))
				{
					this.DisableTagCount++;
				}
				this.DisableTagTasks.Add(component.ListenForTagAddOrRemove(new int?(num), new BaseTagComponent.TTagSwitchedCallback(this.OnDisableTagsChanged), null));
			}
		}
		if (Singleton<MathUtils>.Instance.IsValidVector(this.ActorComp.ActorLocationProxy, 100000000))
		{
			this.LastValidLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		}
		else
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "Safety Init: InValid Location";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "Character";
			CharacterActorComponent actorComp = this.ActorComp;
			object item2;
			if (actorComp == null)
			{
				item2 = null;
			}
			else
			{
				TsBaseCharacter actor = actorComp.Actor;
				item2 = ((actor != null) ? actor.GetName() : null);
			}
			ptr = new ValueTuple<string, object>(item, item2);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item3 = "ErrorLocation";
			CharacterActorComponent actorComp2 = this.ActorComp;
			ptr2 = new ValueTuple<string, object>(item3, (actorComp2 != null) ? actorComp2.ActorLocationProxy : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.LastValidLocation.Set(0.0, 0.0, 0.0);
		}
		if (Singleton<MathUtils>.Instance.IsValidRotator(this.ActorComp.ActorRotationProxy, 100000000))
		{
			this.LastValidRotator.DeepCopy(this.ActorComp.ActorRotationProxy);
		}
		else
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Movement;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "Safety Init: InValid Rotator";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0);
			string item4 = "Character";
			CharacterActorComponent actorComp3 = this.ActorComp;
			object item5;
			if (actorComp3 == null)
			{
				item5 = null;
			}
			else
			{
				TsBaseCharacter actor2 = actorComp3.Actor;
				item5 = ((actor2 != null) ? actor2.GetName() : null);
			}
			ptr3 = new ValueTuple<string, object>(item4, item5);
			ref ValueTuple<string, object> ptr4 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
			string item6 = "ErrorRotator";
			CharacterActorComponent actorComp4 = this.ActorComp;
			ptr4 = new ValueTuple<string, object>(item6, (actorComp4 != null) ? actorComp4.ActorRotationProxy : null);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			this.LastValidRotator.Set(0f, 0f, 0f);
		}
		return true;
	}

	// Token: 0x0601A8AB RID: 108715 RVA: 0x007DA758 File Offset: 0x007D8958
	private void OnDisableTagsChanged(int tagId, bool tagExists)
	{
		if (tagExists)
		{
			if (this.DisableTagCount == 0)
			{
				this.DisableKey = base.Disable("[RoleLocationSafetyComponent.OnDisableTagsChanged] 包含坐下Tag");
			}
			this.DisableTagCount++;
			return;
		}
		this.DisableTagCount--;
		if (this.DisableTagCount == 0)
		{
			this.LastSafetyLocationRecorder.IsSafety = false;
			base.Enable(new int?(this.DisableKey), "[RoleLocationSafetyComponent.OnDisableTagsChanged] 不含坐下Tag");
		}
	}

	// Token: 0x0601A8AC RID: 108716 RVA: 0x007DA7CC File Offset: 0x007D89CC
	protected override bool OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
		Singleton<EventSystem>.Instance.Remove(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
		Singleton<EventSystem>.Instance.Remove(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportComplete));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.ElevatorMove, new Action(this.OnElevatorMove));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharGravityDirectChanged, new Action<Vector, bool>(this.OnGravityDirectChanged));
		if (this.Timer != null)
		{
			TimerSystem.Instance.Remove(this.Timer);
			this.Timer = null;
		}
		foreach (ITagTask tagTask in this.DisableTagTasks)
		{
			tagTask.EndTask();
		}
		this.DisableTagTasks.Clear();
		return true;
	}

	// Token: 0x0601A8AD RID: 108717 RVA: 0x007DA8E8 File Offset: 0x007D8AE8
	protected override void OnActivate()
	{
		this.LastSafetyLocationRecorder.SafetyLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		this.LastSafetyLocationRecorder.IsSafety = false;
	}

	// Token: 0x0601A8AE RID: 108718 RVA: 0x007DA914 File Offset: 0x007D8B14
	protected override void OnEnable()
	{
		if (this.ActorComp == null)
		{
			return;
		}
		if (!this.LastSafetyLocationRecorder.IsSafety)
		{
			this.LastSafetyLocationRecorder.IsSafety = this.SafetyPlaceTest(this.ActorComp.ActorLocationProxy);
			if (this.LastSafetyLocationRecorder.IsSafety)
			{
				this.LastSafetyLocationRecorder.SafetyLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
			}
		}
	}

	// Token: 0x0601A8AF RID: 108719 RVA: 0x007DA97C File Offset: 0x007D8B7C
	private bool SafetyPlaceTest(Vector location)
	{
		if (!Singleton<MathUtils>.Instance.IsValidVector(location, 100000000))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.CH;
			string message = "当前角色坐标包含NaN";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("location", location);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		this.StartLocation.DeepCopy(location);
		this.ActorComp.ActorUpProxy.Multiply((double)(this.ActorComp.DefaultHalfHeight - this.ActorComp.DefaultRadius), this.TmpVector);
		location.Addition(this.TmpVector, this.StartLocation);
		location.Subtraction(this.TmpVector, this.EndLocation);
		UTraceSphereElement actorTrace = ModelBase<TraceElementModel>.Instance.GetActorTrace();
		actorTrace.WorldContextObject = this.ActorComp.Actor;
		actorTrace.Radius = this.ActorComp.DefaultRadius;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(actorTrace, this.StartLocation);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(actorTrace, this.EndLocation);
		actorTrace.ActorsToIgnore.Empty(true);
		if (!Singleton<TraceElementCommon>.Instance.ShapeTrace(this.ActorComp.Actor.CapsuleComponent, actorTrace, "SafetyTrace", "SafetyTrace"))
		{
			return true;
		}
		int hitCount = actorTrace.HitResult.GetHitCount();
		for (int i = 0; i < hitCount; i++)
		{
			if (!(actorTrace.HitResult.Actors.Get(i).Get() is TsBaseCharacter))
			{
				double num = (double)actorTrace.HitResult.TimeArray.Get(i);
				UKuroHitResult hitResult = actorTrace.HitResult;
				TWeakObjectPtr<AActor>? tweakObjectPtr = (hitResult != null) ? new TWeakObjectPtr<AActor>?(hitResult.Actors.Get(i)) : null;
				this.CacheHitActor = ((tweakObjectPtr != null) ? tweakObjectPtr.GetValueOrDefault() : null);
				UKuroHitResult hitResult2 = actorTrace.HitResult;
				TWeakObjectPtr<UPrimitiveComponent>? tweakObjectPtr2 = (hitResult2 != null) ? new TWeakObjectPtr<UPrimitiveComponent>?(hitResult2.Components.Get(i)) : null;
				this.CacheHitComponent = ((tweakObjectPtr2 != null) ? tweakObjectPtr2.GetValueOrDefault() : null);
				return num > 0.99999999;
			}
		}
		return true;
	}

	// Token: 0x0601A8B0 RID: 108720 RVA: 0x007DAB98 File Offset: 0x007D8D98
	protected override void OnTick(float delta)
	{
		if (this.NextCheckTime > Singleton<Time>.Instance.WorldTime)
		{
			return;
		}
		this.NextCheckTime = Singleton<Time>.Instance.WorldTime + (double)this.TestInterval;
		if (!base.Active || !base.Valid || this.InTeleport || ModelBase<GameModeModel>.Instance.Loading)
		{
			return;
		}
		if (!this.ActorComp.IsRoleAndCtrlByMe)
		{
			return;
		}
		if (ModelBase<PlotModel>.Instance.IsInPlot)
		{
			return;
		}
		if (!this.ActorComp.IsDefaultCapsule)
		{
			return;
		}
		if (this.UnifiedComp.MoveState == ECharMoveState.Swing)
		{
			return;
		}
		if (this.UnifiedComp.PositionState == ECharPositionState.Ride)
		{
			return;
		}
		int id = base.Entity.Id;
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		int? num = (getCurrentEntity != null) ? new int?(getCurrentEntity.Id) : null;
		if (!(id == num.GetValueOrDefault() & num != null))
		{
			return;
		}
		this.SafetyCheckAndFix();
	}

	// Token: 0x0601A8B1 RID: 108721 RVA: 0x007DAC88 File Offset: 0x007D8E88
	private void SafetyCheckAndFix()
	{
		if (this.UnifiedComp.PositionState != ECharPositionState.Ground && !this.SafetyHeightTest(this.ActorComp.ActorLocationProxy))
		{
			ControllerBase<WorldController>.Instance.RequestToNearestTeleport();
			return;
		}
		if (!this.SafetyPlaceTest(this.ActorComp.ActorLocationProxy))
		{
			int num = this.NotSafetyCount + 1;
			this.NotSafetyCount = num;
			if (num >= this.MaxNotSafetyCount)
			{
				this.NotSafetyCount = 0;
				this.BackToSafetyPlace();
			}
			return;
		}
		CharacterBuffComponent component = base.Entity.GetComponent<CharacterBuffComponent>();
		if (((component != null) ? component.GetBuffById(640003011L) : null) != null)
		{
			return;
		}
		if (this.UnifiedComp.PositionState == ECharPositionState.Ground)
		{
			this.LastSafetyLocationRecorder.IsSafety = true;
			this.LastSafetyLocationRecorder.SafetyLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		}
		this.NotSafetyCount = 0;
	}

	// Token: 0x0601A8B2 RID: 108722 RVA: 0x007DAD58 File Offset: 0x007D8F58
	protected override void OnAfterTick(float delta)
	{
		if (Singleton<MathUtils>.Instance.IsValidVector(this.ActorComp.ActorLocationProxy, 100000000))
		{
			this.LastValidLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		}
		else
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "Safety: InValid Location";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "Character";
			CharacterActorComponent actorComp = this.ActorComp;
			object item2;
			if (actorComp == null)
			{
				item2 = null;
			}
			else
			{
				TsBaseCharacter actor = actorComp.Actor;
				item2 = ((actor != null) ? actor.GetName() : null);
			}
			ptr = new ValueTuple<string, object>(item, item2);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item3 = "ErrorLocation";
			CharacterActorComponent actorComp2 = this.ActorComp;
			ptr2 = new ValueTuple<string, object>(item3, (actorComp2 != null) ? actorComp2.ActorLocationProxy : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			ControllerBase<TeleportController>.Instance.TeleportToPositionNoLoading(this.LastValidLocation.ToUeVector(false), null, "RoleLocationSafetyComponent.OnAfterTick", true).Forget<bool>();
		}
		if (Singleton<MathUtils>.Instance.IsValidRotator(this.ActorComp.ActorRotationProxy, 100000000))
		{
			this.LastValidRotator.DeepCopy(this.ActorComp.ActorRotationProxy);
			return;
		}
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Movement;
		ELogAuthor author2 = ELogAuthor.LCZ;
		string message2 = "Safety: InValid Rotator";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0);
		string item4 = "Character";
		CharacterActorComponent actorComp3 = this.ActorComp;
		object item5;
		if (actorComp3 == null)
		{
			item5 = null;
		}
		else
		{
			TsBaseCharacter actor2 = actorComp3.Actor;
			item5 = ((actor2 != null) ? actor2.GetName() : null);
		}
		ptr3 = new ValueTuple<string, object>(item4, item5);
		ref ValueTuple<string, object> ptr4 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
		string item6 = "ErrorRotator";
		CharacterActorComponent actorComp4 = this.ActorComp;
		ptr4 = new ValueTuple<string, object>(item6, (actorComp4 != null) ? actorComp4.ActorRotationProxy : null);
		instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		this.ActorComp.SetActorRotation(this.LastValidRotator.ToUeRotator(), "RoleSafetyNotValid", false);
	}

	// Token: 0x0601A8B3 RID: 108723 RVA: 0x007DAF18 File Offset: 0x007D9118
	private bool SafetyHeightTest(Vector location)
	{
		if (Math.Abs(location.X) > 3200000.0 || Math.Abs(location.Y) > 3200000.0 || location.Z < -1000000.0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.YZH;
			string message = "超过极限区间";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("location", location);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		return true;
	}

	// Token: 0x0601A8B4 RID: 108724 RVA: 0x007DAF8C File Offset: 0x007D918C
	private void UpdateSafetyTestFreq()
	{
		EDetectionFrequency key = EDetectionFrequency.Low;
		foreach (LocationSafetyComponent locationSafetyComponent in this.SceneSafetyLocationRecorder.SafetyLocationConfigMap.Values)
		{
			if (RoleLocationSafetyComponent.freqEnumToLevelNum.GetValueOrDefault(locationSafetyComponent.DetectionFrequency, 0) > RoleLocationSafetyComponent.freqEnumToLevelNum.GetValueOrDefault(key, 0))
			{
				key = locationSafetyComponent.DetectionFrequency;
			}
		}
		switch (key)
		{
		case EDetectionFrequency.Low:
			this.TestInterval = 1000;
			this.MaxNotSafetyCount = 3;
			return;
		case EDetectionFrequency.Medium:
			this.TestInterval = 1000;
			this.MaxNotSafetyCount = 2;
			return;
		case EDetectionFrequency.High:
			this.TestInterval = 500;
			this.MaxNotSafetyCount = 2;
			return;
		case EDetectionFrequency.SuperHigh:
			this.TestInterval = 250;
			this.MaxNotSafetyCount = 2;
			return;
		default:
			return;
		}
	}

	// Token: 0x0601A8B5 RID: 108725 RVA: 0x007DB06C File Offset: 0x007D926C
	public void AddSafetyLocationConfig(Entity sceneItem, LocationSafetyComponent sceneItemConfig)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Role;
		ELogAuthor author = ELogAuthor.ZYL;
		string message = "场景实体向玩家注册安全位置信息";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SceneItemId", sceneItem.Id);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.SceneSafetyLocationRecorder.SafetyLocationConfigMap[(long)sceneItem.Id] = sceneItemConfig;
		this.UpdateSafetyTestFreq();
	}

	// Token: 0x0601A8B6 RID: 108726 RVA: 0x007DB0C8 File Offset: 0x007D92C8
	public void RemoveSafetyLocationConfig(Entity sceneItem)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Role;
		ELogAuthor author = ELogAuthor.ZYL;
		string message = "场景实体向玩家注册安全位置信息";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SceneItemId", sceneItem.Id);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.SceneSafetyLocationRecorder.SafetyLocationConfigMap.Remove((long)sceneItem.Id);
		this.UpdateSafetyTestFreq();
	}

	// Token: 0x0601A8B7 RID: 108727 RVA: 0x007DB124 File Offset: 0x007D9324
	protected unsafe void BackToSafetyPlace()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Movement;
		ELogAuthor author = ELogAuthor.LCZ;
		string message = "BackToSafetyPlace";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("From", this.ActorComp.ActorLocationProxy);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item = "HitActor";
		AActor cacheHitActor = this.CacheHitActor;
		ptr = new ValueTuple<string, object>(item, (cacheHitActor != null) ? cacheHitActor.GetName() : null);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("HitComp", this.CacheHitComponent);
		ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
		string item2 = "Transform";
		AActor cacheHitActor2 = this.CacheHitActor;
		ptr2 = new ValueTuple<string, object>(item2, (cacheHitActor2 != null) ? new FTransformDouble?(cacheHitActor2.D_GetTransform()) : null);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		Vector safetyLocation;
		if ((safetyLocation = this.SceneSafetyLocationRecorder.GetSafetyLocation()) != null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Movement;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "BackToSafetyPlace Scene";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("To", safetyLocation);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ControllerBase<TeleportController>.Instance.TeleportToPositionNoLoading(safetyLocation.ToUeVector(false), null, "BackToSafetyPlace.Scene", true).Forget<bool>();
			return;
		}
		if (LocomotionUtils.FindSpaceForSafety(this.ActorComp, this.ActorComp.ScaledHalfHeight, this.ActorComp.ScaledRadius, this.TmpVector))
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Movement;
			ELogAuthor author3 = ELogAuthor.LCZ;
			string message3 = "BackToSafetyPlace Space";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("To", this.TmpVector);
			instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.ActorComp.SetActorLocation(this.TmpVector.ToUeVector(false), "BackToSafetyPlace.Space", false);
			return;
		}
		if ((safetyLocation = this.LastSafetyLocationRecorder.GetSafetyLocation()) != null)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.Movement;
			ELogAuthor author4 = ELogAuthor.LCZ;
			string message4 = "BackToSafetyPlace Last";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("To", safetyLocation);
			instance4.Info(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			if (Vector.DistSquared(this.ActorComp.ActorLocationProxy, safetyLocation) > 1000000.0)
			{
				ControllerBase<TeleportController>.Instance.TeleportToPositionNoLoading(safetyLocation.ToUeVector(false), null, "BackToSafetyPlace.Last", true).Forget<bool>();
				return;
			}
			this.ActorComp.SetActorLocation(safetyLocation.ToUeVector(false), "BackToSafetyPlace.Last", false);
		}
	}

	// Token: 0x0601A8B8 RID: 108728 RVA: 0x007DB35C File Offset: 0x007D955C
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		RoleLocationSafetyComponent roleLocationSafetyComponent = (RoleLocationSafetyComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (roleLocationSafetyComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("UnifiedComp"))
		{
			if (roleLocationSafetyComponent.UnifiedComp == null)
			{
				this.UnifiedComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.UnifiedComp), "UnifiedComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DisableTagTasks") && roleLocationSafetyComponent.DisableTagTasks != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<ITagTask>>(this.DisableTagTasks), "DisableTagTasks"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("DisableTagCount"))
		{
			this.DisableTagCount = roleLocationSafetyComponent.DisableTagCount;
		}
		if (base.CanResetComponentProperty("DisableKey"))
		{
			this.DisableKey = roleLocationSafetyComponent.DisableKey;
		}
		if (base.CanResetComponentProperty("MaxNotSafetyCount"))
		{
			this.MaxNotSafetyCount = roleLocationSafetyComponent.MaxNotSafetyCount;
		}
		if (base.CanResetComponentProperty("TestInterval"))
		{
			this.TestInterval = roleLocationSafetyComponent.TestInterval;
		}
		if (base.CanResetComponentProperty("LastSafetyLocationRecorder") && roleLocationSafetyComponent.LastSafetyLocationRecorder != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<CachedSafetyLocationRecorder>(this.LastSafetyLocationRecorder), "LastSafetyLocationRecorder"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("SceneSafetyLocationRecorder") && roleLocationSafetyComponent.SceneSafetyLocationRecorder != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<ConfigSafetyLocationRecorder>(this.SceneSafetyLocationRecorder), "SceneSafetyLocationRecorder"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("NotSafetyCount"))
		{
			this.NotSafetyCount = roleLocationSafetyComponent.NotSafetyCount;
		}
		if (base.CanResetComponentProperty("Timer"))
		{
			if (roleLocationSafetyComponent.Timer == null)
			{
				this.Timer = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TimerHandle>(this.Timer), "Timer"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("StartLocation") && roleLocationSafetyComponent.StartLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.StartLocation), "StartLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("EndLocation") && roleLocationSafetyComponent.EndLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.EndLocation), "EndLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TmpVector") && roleLocationSafetyComponent.TmpVector != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TmpVector), "TmpVector"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("InTeleport"))
		{
			this.InTeleport = roleLocationSafetyComponent.InTeleport;
		}
		if (base.CanResetComponentProperty("NextCheckTime"))
		{
			this.NextCheckTime = roleLocationSafetyComponent.NextCheckTime;
		}
		if (base.CanResetComponentProperty("LastValidLocation") && roleLocationSafetyComponent.LastValidLocation != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.LastValidLocation), "LastValidLocation"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("LastValidRotator") && roleLocationSafetyComponent.LastValidRotator != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.LastValidRotator), "LastValidRotator"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CacheHitActor"))
		{
			if (roleLocationSafetyComponent.CacheHitActor == null)
			{
				this.CacheHitActor = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AActor>(this.CacheHitActor), "CacheHitActor"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CacheHitComponent"))
		{
			if (roleLocationSafetyComponent.CacheHitComponent == null)
			{
				this.CacheHitComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UActorComponent>(this.CacheHitComponent), "CacheHitComponent"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400D68F RID: 54927
	public const string PROFILE_KEY = "SafetyTrace";

	// Token: 0x0400D690 RID: 54928
	public const float PLANAR_LIMIT = 3200000f;

	// Token: 0x0400D691 RID: 54929
	public const float HIGHT_LIMIT = -1000000f;

	// Token: 0x0400D692 RID: 54930
	public const float TELEPORT_THREHOLD = 1000f;

	// Token: 0x0400D693 RID: 54931
	public const float TELEPORT_THREHOLD_SQUARED = 1000000f;

	// Token: 0x0400D694 RID: 54932
	public const int LOW_FREQ_TEST_INTERNAL = 1000;

	// Token: 0x0400D695 RID: 54933
	public const int LOW_FREQ_MAX_NOT_SAFETY_COUNT = 3;

	// Token: 0x0400D696 RID: 54934
	public const int MID_FREQ_TEST_INTERNAL = 1000;

	// Token: 0x0400D697 RID: 54935
	public const int MID_FREQ_MAX_NOT_SAFETY_COUNT = 2;

	// Token: 0x0400D698 RID: 54936
	public const int HIGH_FREQ_TEST_INTERNAL = 500;

	// Token: 0x0400D699 RID: 54937
	public const int HIGH_FREQ_MAX_NOT_SAFETY_COUNT = 2;

	// Token: 0x0400D69A RID: 54938
	public const int SUPER_HIGH_FREQ_TEST_INTERNAL = 250;

	// Token: 0x0400D69B RID: 54939
	public const int SUPER_HIGH_FREQ_MAX_NOT_SAFETY_COUNT = 2;

	// Token: 0x0400D69C RID: 54940
	[Nullable(2)]
	public static int[] disableTag = null;

	// Token: 0x0400D69D RID: 54941
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<EDetectionFrequency, int> freqEnumToLevelNum = new Dictionary<EDetectionFrequency, int>
	{
		{
			EDetectionFrequency.Low,
			0
		},
		{
			EDetectionFrequency.Medium,
			1
		},
		{
			EDetectionFrequency.High,
			2
		},
		{
			EDetectionFrequency.SuperHigh,
			3
		}
	};

	// Token: 0x0400D69E RID: 54942
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400D69F RID: 54943
	[Nullable(2)]
	private CharacterUnifiedStateComponent UnifiedComp;

	// Token: 0x0400D6A0 RID: 54944
	private readonly List<ITagTask> DisableTagTasks = new List<ITagTask>();

	// Token: 0x0400D6A1 RID: 54945
	private int DisableTagCount;

	// Token: 0x0400D6A2 RID: 54946
	private int DisableKey;

	// Token: 0x0400D6A3 RID: 54947
	private int MaxNotSafetyCount = 3;

	// Token: 0x0400D6A4 RID: 54948
	private int TestInterval = 1000;

	// Token: 0x0400D6A5 RID: 54949
	private readonly CachedSafetyLocationRecorder LastSafetyLocationRecorder = new CachedSafetyLocationRecorder();

	// Token: 0x0400D6A6 RID: 54950
	private readonly ConfigSafetyLocationRecorder SceneSafetyLocationRecorder = new ConfigSafetyLocationRecorder();

	// Token: 0x0400D6A7 RID: 54951
	private int NotSafetyCount;

	// Token: 0x0400D6A8 RID: 54952
	[Nullable(2)]
	private TimerHandle Timer;

	// Token: 0x0400D6A9 RID: 54953
	private readonly Vector StartLocation = Vector.Create();

	// Token: 0x0400D6AA RID: 54954
	private readonly Vector EndLocation = Vector.Create();

	// Token: 0x0400D6AB RID: 54955
	private readonly Vector TmpVector = Vector.Create();

	// Token: 0x0400D6AC RID: 54956
	private bool InTeleport;

	// Token: 0x0400D6AD RID: 54957
	private double NextCheckTime;

	// Token: 0x0400D6AE RID: 54958
	private readonly Vector LastValidLocation = Vector.Create();

	// Token: 0x0400D6AF RID: 54959
	private readonly Rotator LastValidRotator = Rotator.Create();

	// Token: 0x0400D6B0 RID: 54960
	[Nullable(2)]
	private AActor CacheHitActor;

	// Token: 0x0400D6B1 RID: 54961
	[Nullable(2)]
	private UActorComponent CacheHitComponent;
}
