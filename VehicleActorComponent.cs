using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Data.Entity.Struct;
using AkiClient.Game.Aki.Data.Fight.Struct;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02003266 RID: 12902
[NullableContext(1)]
[Nullable(0)]
public class VehicleActorComponent : BaseActorComponent
{
	// Token: 0x170024C0 RID: 9408
	// (get) Token: 0x0601AF1F RID: 110367 RVA: 0x0080AA3D File Offset: 0x00808C3D
	[Nullable(2)]
	public AController DefaultController
	{
		[NullableContext(2)]
		get
		{
			return this.DefaultControllerInternal;
		}
	}

	// Token: 0x170024C1 RID: 9409
	// (get) Token: 0x0601AF20 RID: 110368 RVA: 0x0080AA45 File Offset: 0x00808C45
	public TsBaseVehicle Actor
	{
		get
		{
			return this.ActorInternal as TsBaseVehicle;
		}
	}

	// Token: 0x170024C2 RID: 9410
	// (get) Token: 0x0601AF21 RID: 110369 RVA: 0x0080AA52 File Offset: 0x00808C52
	[Nullable(2)]
	public TsBaseVehicle VehicleOwner
	{
		[NullableContext(2)]
		get
		{
			return this.ActorInternal as TsBaseVehicle;
		}
	}

	// Token: 0x170024C3 RID: 9411
	// (get) Token: 0x0601AF22 RID: 110370 RVA: 0x0080AA5F File Offset: 0x00808C5F
	[Nullable(2)]
	public override USkeletalMeshComponent SkeletalMesh
	{
		[NullableContext(2)]
		get
		{
			return this.Actor.Mesh;
		}
	}

	// Token: 0x0601AF23 RID: 110371 RVA: 0x0080AA6C File Offset: 0x00808C6C
	public UPrimitiveComponent GetPrimitiveComponent()
	{
		return this.SkeletalMesh;
	}

	// Token: 0x170024C4 RID: 9412
	// (get) Token: 0x0601AF24 RID: 110372 RVA: 0x0080AA74 File Offset: 0x00808C74
	public global::Vector InputDirectProxy
	{
		get
		{
			return this.InputDirectInternal;
		}
	}

	// Token: 0x170024C5 RID: 9413
	// (get) Token: 0x0601AF25 RID: 110373 RVA: 0x0080AA7C File Offset: 0x00808C7C
	public FVector InputDirect
	{
		get
		{
			return this.InputDirectInternal.ToUeVectorOld();
		}
	}

	// Token: 0x170024C6 RID: 9414
	// (get) Token: 0x0601AF26 RID: 110374 RVA: 0x0080AA8C File Offset: 0x00808C8C
	public global::Rotator InputRotatorProxy
	{
		get
		{
			if (this.NewestInputFacingType == VehicleActorComponent.ENewestInputFacingType.Facing)
			{
				if (this.VehicleMoveComp == null || this.VehicleMoveComp.IsStandardGravity)
				{
					this.InputRotatorInternal.Set((float)(Math.Asin(this.InputFacingInternal.Z) * 57.295780181884766), (float)Singleton<MathUtils>.Instance.GetAngleByVector2D(this.InputFacingInternal), 0f);
				}
				else
				{
					VehicleActorComponent.TmpVector.Multiply(-1.0, VehicleActorComponent.TmpVector);
					Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.InputFacingInternal, VehicleActorComponent.TmpVector, VehicleActorComponent.TmpQuat);
					VehicleActorComponent.TmpQuat.Rotator(this.InputRotatorInternal);
				}
				this.NewestInputFacingType = VehicleActorComponent.ENewestInputFacingType.All;
			}
			return this.InputRotatorInternal;
		}
	}

	// Token: 0x170024C7 RID: 9415
	// (get) Token: 0x0601AF27 RID: 110375 RVA: 0x0080AB4C File Offset: 0x00808D4C
	public global::Vector InputFacingProxy
	{
		get
		{
			if (this.NewestInputFacingType == VehicleActorComponent.ENewestInputFacingType.Rotator)
			{
				if (this.VehicleMoveComp == null || this.VehicleMoveComp.IsStandardGravity)
				{
					float num = this.InputRotatorInternal.Pitch * 0.017453292f;
					this.InputFacingInternal.Z = Math.Sin((double)num);
					double num2 = Math.Cos((double)num);
					float num3 = this.InputRotatorInternal.Yaw * 0.017453292f;
					this.InputFacingInternal.X = Math.Cos((double)num3) * num2;
					this.InputFacingInternal.Y = Math.Sin((double)num3) * num2;
				}
				else
				{
					this.InputRotatorInternal.Quaternion(VehicleActorComponent.TmpQuat);
					VehicleActorComponent.TmpQuat.RotateVector(global::Vector.ForwardVectorProxy, this.InputFacingInternal);
				}
				this.NewestInputFacingType = VehicleActorComponent.ENewestInputFacingType.All;
			}
			return this.InputFacingInternal;
		}
	}

	// Token: 0x170024C8 RID: 9416
	// (get) Token: 0x0601AF28 RID: 110376 RVA: 0x0080AC18 File Offset: 0x00808E18
	public override global::Vector ActorGravityDirectProxy
	{
		get
		{
			if (this.CachedGravityDirectTime < Singleton<Time>.Instance.Frame)
			{
				this.CachedGravityDirectTime = Singleton<Time>.Instance.Frame;
				if (this.VehicleMoveComp != null)
				{
					this.CachedActorGravityDirect.DeepCopy(this.VehicleMoveComp.GravityDirect);
				}
				else
				{
					Aki.Protocol.Vector initGravityDirection = base.CreatureData.GetInitGravityDirection();
					if (initGravityDirection != null)
					{
						this.CachedActorGravityDirect.FromConfigVector(initGravityDirection);
					}
				}
			}
			return this.CachedActorGravityDirect;
		}
	}

	// Token: 0x0601AF29 RID: 110377 RVA: 0x0080AC88 File Offset: 0x00808E88
	[NullableContext(2)]
	protected override bool OnInitData(IEntityArgs args = null)
	{
		base.OnInitData(args);
		this.SetRotationRequestProxy = new FunctionRequestProxy<FunctionRequestWithPriority<ESetRotationPriority>>();
		return base.InitCreatureData();
	}

	// Token: 0x0601AF2A RID: 110378 RVA: 0x0080ACA8 File Offset: 0x00808EA8
	protected override void InitSizeInternal()
	{
		this.RadiusInternal = this.Actor.CapsuleComponent.CapsuleRadius;
		this.HalfHeightInternal = this.Actor.CapsuleComponent.CapsuleHalfHeight;
		this.DefaultRadiusInternal = this.RadiusInternal;
		this.DefaultHalfHeightInternal = this.HalfHeightInternal;
	}

	// Token: 0x0601AF2B RID: 110379 RVA: 0x0080ACFC File Offset: 0x00808EFC
	protected unsafe override bool OnInit()
	{
		base.OnInit();
		int modelId = this.CreatureDataInternal.GetModelId();
		if (modelId == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "[SceneItemActorComponent.OnInit] 加载actor失败，无法找到modelId";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", this.CreatureDataInternal.GetCreatureDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", base.CreatureData.GetPbDataId());
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		AActor actorInternal = this.InitActorNew(modelId);
		this.ActorInternal = actorInternal;
		if (this.ActorInternal == null || !this.ActorInternal.IsValid())
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Character;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "[VehicleActorComponent.OnInit] 加载actor失败。";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("CreatureDataId", this.CreatureDataInternal.GetCreatureDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("PbDataId", base.CreatureData.GetPbDataId());
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return false;
		}
		if (!this.ActorInternal.IsA(TsBaseVehicle.StaticClass()))
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Character;
			ELogAuthor author3 = ELogAuthor.LCZ;
			string message3 = "[VehicleActorComponent.OnInit] Actor不是TsBaseVehicle";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Name", this.ActorInternal.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Class", this.ActorInternal.GetClass().ToClass().GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("CreatureDataId", this.CreatureDataInternal.GetCreatureDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("ModelId", modelId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 4) = new ValueTuple<string, object>("PbDataId", base.CreatureData.GetPbDataId());
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 5));
			return false;
		}
		if (this.ActorInternal != null)
		{
			this.ActorInternal.OnDestroyed.Add(new Action<AActor>(this.OnActorDestroy));
		}
		TsBaseVehicle tsBaseVehicle = this.ActorInternal as TsBaseVehicle;
		tsBaseVehicle.VehicleActorComponent = this;
		tsBaseVehicle.SetEntityId(base.Entity.Id);
		this.InitSizeInternal();
		this.InitDefaultController(this.ActorInternal as ACharacter);
		this.SetInputFacing(base.ActorForwardProxy, false);
		base.SetActorVisible(false, "[VehicleActorComponent.OnInit] 默认隐藏");
		base.SetCollisionEnable(false, "[VehicleActorComponent.OnInit] 默认关闭碰撞");
		base.SetTickEnable(false, "[VehicleActorComponent.OnInit] 默认关闭Tick");
		this.LoadPartHitConf();
		tsBaseVehicle.CharRenderingComponent.Init(tsBaseVehicle.RenderType);
		this.ActorInternal.SetPrimitiveBlueprintTypeName(new FName(this.CreatureDataInternal.EntityPbModelConfigId));
		if (GameBudgetInterfaceController.IsOpen)
		{
			if (base.Entity.GameBudgetManagedToken != 0U)
			{
				UKuroGameBudgetAllocatorCSharpInterface.UpdateActor(base.Entity.GameBudgetConfig.GroupName, base.Entity.GameBudgetManagedToken, this.ActorInternal);
			}
			else
			{
				base.Entity.RegisterToGameBudgetController(this.ActorInternal);
			}
		}
		UKuroJsModelFunctionLibrary.UpdateEntityActor(base.Entity.Id, this.ActorInternal);
		return true;
	}

	// Token: 0x0601AF2C RID: 110380 RVA: 0x0080B03F File Offset: 0x0080923F
	protected override bool OnStart()
	{
		if (!base.OnStart())
		{
			return false;
		}
		this.InputComp = base.Entity.GetComponent<VehicleInputComponent>();
		this.VehicleMoveComp = base.Entity.GetComponent<VehicleMoveComponent>();
		this.DebugMovementComp = base.Entity.GetComponent<ActorDebugMovementComponent>();
		return true;
	}

	// Token: 0x0601AF2D RID: 110381 RVA: 0x0080B080 File Offset: 0x00809280
	protected override void OnActivate()
	{
		base.OnActivate();
		base.SetActorVisible(true, "[VehicleActorComponent.OnActivate] Visible");
		base.SetCollisionEnable(true, "[VehicleActorComponent.OnActivate] Visible");
		base.SetTickEnable(true, "[VehicleActorComponent.OnActivate] Visible");
		this.Actor.VehicleMovementComponent.InitVehicleShapes();
		ControllerBase<WorldController>.Instance.SetActorDataByCreature(this.CreatureDataInternal, this.ActorInternal);
		bool flag = this.CreatureDataInternal.GetPlayerId() == ModelBase<CreatureModel>.Instance.GetPlayerId();
		ValueTuple<int, MoveStateInfo>? entitySplineMoveInfo = ControllerBase<VehiclePathMoveController>.Instance.GetEntitySplineMoveInfo(base.Entity);
		this.SetAutonomous(flag || entitySplineMoveInfo != null, null);
	}

	// Token: 0x0601AF2E RID: 110382 RVA: 0x0080B124 File Offset: 0x00809324
	protected override bool OnClear()
	{
		AActor actorInternal = this.ActorInternal;
		if (actorInternal != null && actorInternal.IsValid())
		{
			this.ActorInternal.OnDestroyed.Remove(new Action<AActor>(this.OnActorDestroy));
			TsBaseVehicle tsBaseVehicle = this.ActorInternal as TsBaseVehicle;
			if (tsBaseVehicle != null)
			{
				CharacterDitherEffectController ditherEffectController = tsBaseVehicle.DitherEffectController;
				if (ditherEffectController != null)
				{
					ditherEffectController.Clear();
				}
				tsBaseVehicle.DitherEffectController = null;
			}
			AActor platformActor = this.Actor.PlatformActor;
			if (platformActor != null && platformActor.IsValid())
			{
				this.Actor.PlatformActor.K2_DetachFromActor(EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative);
			}
		}
		return base.OnClear();
	}

	// Token: 0x0601AF2F RID: 110383 RVA: 0x0080B1BA File Offset: 0x008093BA
	protected override void OnDisable(string reason)
	{
		this.OnSetActorActive(false, reason);
	}

	// Token: 0x0601AF30 RID: 110384 RVA: 0x0080B1C4 File Offset: 0x008093C4
	protected override void OnEnable()
	{
		this.OnSetActorActive(true, null);
		base.ResetAllCachedTime();
	}

	// Token: 0x0601AF31 RID: 110385 RVA: 0x0080B1D4 File Offset: 0x008093D4
	[NullableContext(2)]
	protected unsafe AActor InitActorNew(int modelId)
	{
		CreatureDataComponent creatureDataInternal = this.CreatureDataInternal;
		FTransformDouble transform = creatureDataInternal.D_GetTransform();
		AActor aactor = null;
		this.CreatureDataInternal.SetModelConfig(modelId);
		SModelConfig modelConfig = this.CreatureDataInternal.GetModelConfig();
		if (modelConfig == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.YZH;
			string message = "[CharacterActorComponent.OnInit] 缺少ModelConfig配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", creatureDataInternal.GetCreatureDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ModelId", modelId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return aactor;
		}
		aactor = ActorUtils.LoadActorByModelConfig(modelConfig, transform);
		if (aactor == null || !aactor.IsValid())
		{
			return null;
		}
		TsBaseVehicle tsBaseVehicle = aactor as TsBaseVehicle;
		if (tsBaseVehicle != null)
		{
			ActorUtils.LoadAndChangeMeshAnim(tsBaseVehicle.Mesh, modelConfig.网格体, modelConfig.动画蓝图);
		}
		return aactor;
	}

	// Token: 0x0601AF32 RID: 110386 RVA: 0x0080B2B8 File Offset: 0x008094B8
	protected override void OnChangeTimeDilation(float timeDilation)
	{
		PawnTimeScaleComponent component = base.Entity.GetComponent<PawnTimeScaleComponent>();
		float num = (component != null) ? component.CurrentTimeScale : 1f;
		this.ActorInternal.CustomTimeDilation = timeDilation * num;
	}

	// Token: 0x0601AF33 RID: 110387 RVA: 0x0080B2F0 File Offset: 0x008094F0
	protected override void SetMoveAutonomous(bool moveAutonomous, string reason = "")
	{
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.Control;
		Entity entity = base.Entity;
		string message = "设置移动主控";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(reason, moveAutonomous);
		instance.Info(flag, entity, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		base.SetMoveAutonomous(moveAutonomous, reason);
		VehicleAnimationComponent component = base.Entity.GetComponent<VehicleAnimationComponent>();
		if (component != null)
		{
			UAnimInstance mainAnimInstance = component.MainAnimInstance;
			if (mainAnimInstance != null)
			{
				mainAnimInstance.SetStateMachineNetMode(!moveAutonomous);
			}
			UAnimInstance specialAnimInstance = component.SpecialAnimInstance;
			if (specialAnimInstance == null)
			{
				return;
			}
			specialAnimInstance.SetStateMachineNetMode(!moveAutonomous);
		}
	}

	// Token: 0x0601AF34 RID: 110388 RVA: 0x0080B368 File Offset: 0x00809568
	[NullableContext(2)]
	protected unsafe void OnActorDestroy(AActor aActor)
	{
		if (this.CreatureDataInternal.GetRemoveState())
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Entity;
		ELogAuthor author = ELogAuthor.LFJW;
		string message = "Entity还没销毁，Actor已经被销毁了，需检查造物点是否会使生成的实体掉出边界外";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureData", this.CreatureDataInternal.GetCreatureDataId());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ConfigType", this.CreatureDataInternal.GetEntityConfigType());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("PbDataId", this.CreatureDataInternal.GetPbDataId());
		instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x0601AF35 RID: 110389 RVA: 0x0080B41C File Offset: 0x0080961C
	private void LoadPartHitConf()
	{
		UClassStackOnlyPtr @class = this.Actor.GetClass();
		TSoftClassPtr<UObject> tsoftClassPtr = UKismetSystemLibrary.Conv_ClassToSoftClassReference(@class);
		string characterResourcePath = UKismetSystemLibrary.Conv_SoftClassReferenceToString(tsoftClassPtr);
		SCharacterFightInfo characterFightInfo = ConfigBase<WorldConfig>.Instance.GetCharacterFightInfo(characterResourcePath);
		string text = (characterFightInfo != null) ? characterFightInfo.PartHitEffect.ToAssetPathName() : null;
		bool isValid = text != null && text.Length > 0 && text != "None";
		if (isValid)
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<BP_PartHitEffect_C>(text, delegate([Nullable(2)] BP_PartHitEffect_C res, string _)
			{
				TsBaseVehicle actor = this.Actor;
				if (actor == null || !actor.IsValid())
				{
					return;
				}
				this.PartHitConf = res;
				BP_PartHitEffect_C partHitConf = this.PartHitConf;
				isValid = (partHitConf != null && partHitConf.IsValid());
				if (isValid && this.Actor != null)
				{
					this.StartHideDistance = this.PartHitConf.StartHideDistance;
					this.CompleteHideDistance = this.PartHitConf.CompleteHideDistance;
					this.StartDitherValue = this.PartHitConf.StartDitherValue;
				}
			}, 100, "js_undefined");
		}
	}

	// Token: 0x0601AF36 RID: 110390 RVA: 0x0080B4B7 File Offset: 0x008096B7
	public void SetInputRotator(IRotator value)
	{
		this.SetInputRotatorByNumber(value.Pitch, value.Yaw, value.Roll);
	}

	// Token: 0x0601AF37 RID: 110391 RVA: 0x0080B4D1 File Offset: 0x008096D1
	public void SetInputRotatorByNumber(float pitch, float yaw, float roll)
	{
		this.InputRotatorInternal.Pitch = pitch;
		this.InputRotatorInternal.Yaw = yaw;
		this.InputRotatorInternal.Roll = roll;
		this.NewestInputFacingType = VehicleActorComponent.ENewestInputFacingType.Rotator;
	}

	// Token: 0x0601AF38 RID: 110392 RVA: 0x0080B500 File Offset: 0x00809700
	public unsafe void SetInputDirect(IVector value, bool clearGravityDirect = false)
	{
		if (!Singleton<MathUtils>.Instance.IsValidVector(value, 100000000))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "SetInputDirect has NaN";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("x", value.X);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("y", value.Y);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("z", value.Z);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		if (!clearGravityDirect)
		{
			this.InputDirectInternal.DeepCopy(value);
			return;
		}
		if (this.VehicleMoveComp == null || this.VehicleMoveComp.IsStandardGravity)
		{
			this.InputDirectInternal.DeepCopy(value);
			this.InputDirectInternal.Z = 0.0;
			return;
		}
		VehicleActorComponent.TmpVector.DeepCopy(value);
		global::Vector.VectorPlaneProject(VehicleActorComponent.TmpVector, this.VehicleMoveComp.GravityDirect, this.InputDirectInternal);
	}

	// Token: 0x0601AF39 RID: 110393 RVA: 0x0080B618 File Offset: 0x00809818
	public unsafe void SetInputDirectByNumber(float x, float y, float z)
	{
		if (!Singleton<MathUtils>.Instance.IsValidNumbers((double)x, (double)y, (double)z, 100000000))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "SetInputDirect has NaN";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("x", x);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("y", y);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("z", z);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return;
		}
		this.InputDirectInternal.X = (double)x;
		this.InputDirectInternal.Y = (double)y;
		this.InputDirectInternal.Z = (double)z;
	}

	// Token: 0x0601AF3A RID: 110394 RVA: 0x0080B6E0 File Offset: 0x008098E0
	public void SetInputFacing(global::Vector facing, bool clearGravityDirect = false)
	{
		this.InputFacingInternal.DeepCopy(facing);
		if (clearGravityDirect)
		{
			if (this.VehicleMoveComp == null || this.VehicleMoveComp.IsStandardGravity)
			{
				this.InputFacingInternal.Z = 0.0;
			}
			else
			{
				global::Vector.VectorPlaneProject(this.InputFacingInternal, this.VehicleMoveComp.GravityDirect, VehicleActorComponent.TmpVector);
				this.InputFacingInternal.DeepCopy(VehicleActorComponent.TmpVector);
			}
		}
		if (!this.InputFacingInternal.Normalize(9.99999993922529E-09))
		{
			this.InputFacingInternal.DeepCopy(base.ActorForwardProxy);
		}
		this.NewestInputFacingType = VehicleActorComponent.ENewestInputFacingType.Facing;
	}

	// Token: 0x0601AF3B RID: 110395 RVA: 0x0080B780 File Offset: 0x00809980
	public void SetOverrideTurnSpeed(float? value)
	{
		this.OverrideTurnSpeed = value;
	}

	// Token: 0x0601AF3C RID: 110396 RVA: 0x0080B789 File Offset: 0x00809989
	public void ClearInput()
	{
		this.SetInputDirect(global::Vector.ZeroVector, false);
		this.SetInputFacing(base.ActorForwardProxy, false);
		this.SetOverrideTurnSpeed(new float?(0f));
	}

	// Token: 0x0601AF3D RID: 110397 RVA: 0x0080B7BC File Offset: 0x008099BC
	public unsafe void InitDefaultController(ACharacter actor)
	{
		this.DefaultControllerInternal = actor.GetController();
		if (this.DefaultController == null)
		{
			this.CreateDefaultController(actor);
			return;
		}
		if (!(this.DefaultController is AAIController))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "Character初始化的默认Controller基类为非AiController";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureData", this.CreatureDataInternal.GetCreatureDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ConfigType", this.CreatureDataInternal.GetEntityConfigType());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("PbDataId", this.CreatureDataInternal.GetPbDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("DefaultController", this.DefaultController.GetName());
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		if (this.DefaultController is APlayerController)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Character;
			ELogAuthor author2 = ELogAuthor.LJM;
			string message2 = "Character初始化的默认Controller基类为PlayerController,下场的人将会导致Movement不执行";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("CreatureData", this.CreatureDataInternal.GetCreatureDataId());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ConfigType", this.CreatureDataInternal.GetEntityConfigType());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("PbDataId", this.CreatureDataInternal.GetPbDataId());
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			if (this.DefaultController.Pawn == actor)
			{
				this.DefaultController.Pawn.DetachFromControllerPendingDestroy();
			}
			this.DefaultControllerInternal = null;
			this.CreateDefaultController(actor);
		}
	}

	// Token: 0x0601AF3E RID: 110398 RVA: 0x0080B983 File Offset: 0x00809B83
	public void CreateDefaultController(ACharacter actor)
	{
		actor.AIControllerClass = AKuroAIController.StaticClass();
		actor.SpawnDefaultController();
		this.DefaultControllerInternal = actor.GetController();
	}

	// Token: 0x0601AF3F RID: 110399 RVA: 0x0080B9A8 File Offset: 0x00809BA8
	public void RestoreDefaultController()
	{
		if (this.DefaultController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[VehicleActorComponent.RestoreDefaultController] 没有DefaultController,将导致这个实体部分功能失效比如移动,查看OnStart 有无正常初始化DefaultController";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", base.Entity.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		this.DefaultController.Possess(this.Actor);
	}

	// Token: 0x0601AF40 RID: 110400 RVA: 0x0080BA08 File Offset: 0x00809C08
	public override bool SetActorRotation(FRotator value, string context, bool sweep = false)
	{
		bool result = false;
		if (!Singleton<MathUtils>.Instance.IsValidRotator(value, 100000000))
		{
			Singleton<Log>.Instance.Error(ELogModule.Entity, ELogAuthor.MZJ, "SetActorRotation NaN", default(ReadOnlySpan<ValueTuple<string, object>>));
			return result;
		}
		result = base.SetActorRotation(value, context, sweep);
		this.CachedActorRotation.DeepCopy(value);
		this.CachedRotationTime = Singleton<Time>.Instance.Frame;
		this.CachedActorRotation.Quaternion(this.CachedActorQuat);
		return result;
	}

	// Token: 0x0601AF41 RID: 110401 RVA: 0x0080BA88 File Offset: 0x00809C88
	public unsafe bool SetActorRotationWithPriority(FRotator value, string module, ESetRotationPriority priority, bool clearMeshRotationBuffer = false, bool sweep = false)
	{
		FunctionRequestWithPriority<ESetRotationPriority> functionRequestWithPriority = new FunctionRequestWithPriority<ESetRotationPriority>();
		functionRequestWithPriority.ModuleName = module;
		functionRequestWithPriority.Priority = priority;
		if (this.SetRotationRequestProxy.DecideCall(functionRequestWithPriority))
		{
			if (this.ShowDebug)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Entity;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[CharacterActorComponent.SetActorRotationWithPriority] 修改Rotation";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("module", module);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("rotation", value);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("oldRotation", base.ActorRotationProxy);
				instance.Info(module2, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
			if (clearMeshRotationBuffer)
			{
				Singleton<EventSystem>.Instance.EmitWithTarget(base.Entity, EEventName.RequestClearMeshRotationBuffer);
			}
			this.SetActorRotation(value, module, sweep);
			return true;
		}
		return false;
	}

	// Token: 0x0601AF42 RID: 110402 RVA: 0x0080BB8C File Offset: 0x00809D8C
	public override bool SetActorLocationAndRotation(FVectorDouble location, FRotator rotation, string context, bool sweep = false, ESetRotationPriority? priority = null)
	{
		if (!Singleton<MathUtils>.Instance.IsValidVector(location, 100000000) || !Singleton<MathUtils>.Instance.IsValidRotator(rotation, 100000000))
		{
			Singleton<Log>.Instance.Error(ELogModule.Entity, ELogAuthor.MZJ, "SetActorLocationAndRotation NaN", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		bool result;
		if (priority != null)
		{
			FunctionRequestWithPriority<ESetRotationPriority> functionRequestWithPriority = new FunctionRequestWithPriority<ESetRotationPriority>();
			functionRequestWithPriority.ModuleName = context;
			functionRequestWithPriority.Priority = priority.Value;
			if (!this.SetRotationRequestProxy.DecideCall(functionRequestWithPriority))
			{
				result = base.SetActorLocation(location, context, sweep);
			}
			else
			{
				result = base.SetActorLocationAndRotation(location, rotation, context, sweep, null);
			}
		}
		else
		{
			result = base.SetActorLocationAndRotation(location, rotation, context, sweep, null);
		}
		base.ResetTransformCachedTime();
		this.OnTeleport();
		return result;
	}

	// Token: 0x0601AF43 RID: 110403 RVA: 0x0080BC60 File Offset: 0x00809E60
	public override bool SetActorTransform(FTransformDouble value, string context, bool sweep = true, ESetRotationPriority? priority = null)
	{
		if (priority != null)
		{
			FunctionRequestWithPriority<ESetRotationPriority> functionRequestWithPriority = new FunctionRequestWithPriority<ESetRotationPriority>();
			functionRequestWithPriority.ModuleName = context;
			functionRequestWithPriority.Priority = priority.Value;
			if (!this.SetRotationRequestProxy.DecideCall(functionRequestWithPriority))
			{
				FQuat fquat = base.ActorRotation.Quaternion();
				value.SetRotation(fquat);
			}
		}
		return base.SetActorTransform(value, context, sweep, null);
	}

	// Token: 0x0601AF44 RID: 110404 RVA: 0x0080BCC8 File Offset: 0x00809EC8
	public virtual bool SetActorTransformExceptMesh(FTransformDouble value, string context, bool sweep = true, ESetRotationPriority? priority = null)
	{
		global::Vector cachedDesiredActorLocation = this.CachedDesiredActorLocation;
		FVectorDouble location = value.GetLocation();
		cachedDesiredActorLocation.FromUeVector(location);
		this.IsChangingLocation = true;
		bool result = this.Actor.SetActorTransformExceptSkelMesh(value, sweep, ref WorldGlobal.SweepHitResult, true, true);
		this.IsChangingLocation = false;
		base.CheckIsForbidSettingLocAndRot(true, true, true);
		if (this.DebugMovementComp != null)
		{
			this.DebugMovementComp.MarkDebugRecord(context + ".SetActorTransformExceptMesh", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
		}
		base.ResetTransformCachedTime();
		this.OnTeleport();
		return result;
	}

	// Token: 0x0601AF45 RID: 110405 RVA: 0x0080BD48 File Offset: 0x00809F48
	public virtual bool SetActorLocationAndRotationExceptMesh(FVectorDouble location, FRotator rotation, string context, bool sweep = true, ESetRotationPriority? priority = null)
	{
		this.CachedDesiredActorLocation.FromUeVector(location);
		this.IsChangingLocation = true;
		bool result = this.Actor.SetActorLocationAndRotationExceptSkelMesh(location, rotation, sweep, ref WorldGlobal.SweepHitResult, true, true);
		this.IsChangingLocation = false;
		base.CheckIsForbidSettingLocAndRot(true, true, true);
		if (this.DebugMovementComp != null)
		{
			this.DebugMovementComp.MarkDebugRecord(context + ".SetActorLocationAndRotationExceptMesh", new EKDMRecordType?(EKDMRecordType.KDM_LOCATION), false);
		}
		base.ResetTransformCachedTime();
		return result;
	}

	// Token: 0x0601AF46 RID: 110406 RVA: 0x0080BDC0 File Offset: 0x00809FC0
	public void SetActorVelocity(global::Vector v)
	{
		if (this.Actor.RootComponent == null)
		{
			return;
		}
		if (!Singleton<MathUtils>.Instance.IsValidVector(v, 100000000))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Movement;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "Set Invalid Velocity";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("v", v);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		FVector fvector = v.ToUeVectorOld();
		this.Actor.RootComponent.ComponentVelocity = fvector;
		if (this.Actor.VehicleMovementComponent != null)
		{
			this.Actor.VehicleMovementComponent.Velocity = fvector;
		}
		this.CachedActorVelocity.DeepCopy(v);
	}

	// Token: 0x0601AF47 RID: 110407 RVA: 0x0080BE56 File Offset: 0x0080A056
	public void FixBornLocation([Nullable(2)] global::Vector target = null, string context = "FixBornLocation")
	{
		BaseVehiclePerformComponent component = base.Entity.GetComponent<BaseVehiclePerformComponent>();
		if (component == null)
		{
			return;
		}
		component.FixBornLocation(target, context);
	}

	// Token: 0x0601AF48 RID: 110408 RVA: 0x0080BE6F File Offset: 0x0080A06F
	public virtual void EnterFirstPersonMode()
	{
	}

	// Token: 0x0601AF49 RID: 110409 RVA: 0x0080BE71 File Offset: 0x0080A071
	public virtual void ExitFirstPersonMode()
	{
	}

	// Token: 0x0601AF4A RID: 110410 RVA: 0x0080BE74 File Offset: 0x0080A074
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		VehicleActorComponent vehicleActorComponent = (VehicleActorComponent)componentTemplate;
		if (base.CanResetComponentProperty("InputComp"))
		{
			if (vehicleActorComponent.InputComp == null)
			{
				this.InputComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleInputComponent>(this.InputComp), "InputComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ShowDebug"))
		{
			this.ShowDebug = vehicleActorComponent.ShowDebug;
		}
		if (base.CanResetComponentProperty("SetRotationRequestProxy"))
		{
			if (vehicleActorComponent.SetRotationRequestProxy == null)
			{
				this.SetRotationRequestProxy = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<FunctionRequestProxy<FunctionRequestWithPriority<ESetRotationPriority>>>(this.SetRotationRequestProxy), "SetRotationRequestProxy"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DefaultControllerInternal"))
		{
			if (vehicleActorComponent.DefaultControllerInternal == null)
			{
				this.DefaultControllerInternal = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AController>(this.DefaultControllerInternal), "DefaultControllerInternal"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PartHitConf"))
		{
			if (vehicleActorComponent.PartHitConf == null)
			{
				this.PartHitConf = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BP_PartHitEffect_C>(this.PartHitConf), "PartHitConf"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("StartHideDistance"))
		{
			this.StartHideDistance = vehicleActorComponent.StartHideDistance;
		}
		if (base.CanResetComponentProperty("CompleteHideDistance"))
		{
			this.CompleteHideDistance = vehicleActorComponent.CompleteHideDistance;
		}
		if (base.CanResetComponentProperty("StartDitherValue"))
		{
			this.StartDitherValue = vehicleActorComponent.StartDitherValue;
		}
		if (base.CanResetComponentProperty("InputDirectInternal") && vehicleActorComponent.InputDirectInternal != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.InputDirectInternal), "InputDirectInternal"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("InputRotatorInternal") && vehicleActorComponent.InputRotatorInternal != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Rotator>(this.InputRotatorInternal), "InputRotatorInternal"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("InputFacingInternal") && vehicleActorComponent.InputFacingInternal != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.InputFacingInternal), "InputFacingInternal"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("NewestInputFacingType"))
		{
			this.NewestInputFacingType = vehicleActorComponent.NewestInputFacingType;
		}
		if (base.CanResetComponentProperty("OverrideTurnSpeed"))
		{
			this.OverrideTurnSpeed = vehicleActorComponent.OverrideTurnSpeed;
		}
		return true;
	}

	// Token: 0x0400DAB7 RID: 55991
	[Nullable(2)]
	public VehicleInputComponent InputComp;

	// Token: 0x0400DAB8 RID: 55992
	public bool ShowDebug;

	// Token: 0x0400DAB9 RID: 55993
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected FunctionRequestProxy<FunctionRequestWithPriority<ESetRotationPriority>> SetRotationRequestProxy;

	// Token: 0x0400DABA RID: 55994
	[Nullable(2)]
	protected AController DefaultControllerInternal;

	// Token: 0x0400DABB RID: 55995
	[Nullable(2)]
	private BP_PartHitEffect_C PartHitConf;

	// Token: 0x0400DABC RID: 55996
	public float StartHideDistance;

	// Token: 0x0400DABD RID: 55997
	public float CompleteHideDistance;

	// Token: 0x0400DABE RID: 55998
	public float StartDitherValue;

	// Token: 0x0400DABF RID: 55999
	[StaticVariableRuleIgnore]
	protected static global::Vector TmpVector = global::Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x0400DAC0 RID: 56000
	[StaticVariableRuleIgnore]
	protected static Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400DAC1 RID: 56001
	private readonly global::Vector InputDirectInternal = global::Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x0400DAC2 RID: 56002
	private readonly global::Rotator InputRotatorInternal = global::Rotator.Create(0f, 0f, 0f);

	// Token: 0x0400DAC3 RID: 56003
	private readonly global::Vector InputFacingInternal = global::Vector.Create(1.0, 0.0, 0.0);

	// Token: 0x0400DAC4 RID: 56004
	protected VehicleActorComponent.ENewestInputFacingType NewestInputFacingType;

	// Token: 0x0400DAC5 RID: 56005
	public float? OverrideTurnSpeed = new float?(0f);

	// Token: 0x0200944B RID: 37963
	[NullableContext(0)]
	public enum ENewestInputFacingType
	{
		// Token: 0x04031387 RID: 201607
		All,
		// Token: 0x04031388 RID: 201608
		Rotator,
		// Token: 0x04031389 RID: 201609
		Facing
	}
}
