using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using AkiClient.Game.Aki.Data.Gameplay.PilotThrow;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.Character.Custom.Components;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x020025EB RID: 9707
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
[TickController(0)]
public class PilotThrowController : ControllerBase<PilotThrowController>
{
	// Token: 0x0601304B RID: 77899 RVA: 0x00544A60 File Offset: 0x00542C60
	[NullableContext(1)]
	public unsafe void EnterInteractHookPoint(int hookPointPbDataId, int titanEntityId, List<IPilotThrowTarget> pilotThrowTarget)
	{
		this.NeedKeepCameraAndUi = true;
		ModelBase<PilotThrowModel>.Instance.InitInteractInfo(hookPointPbDataId, titanEntityId, pilotThrowTarget);
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(hookPointPbDataId);
		WorldEntity worldEntity = (entityByPbDataId != null) ? entityByPbDataId.Entity : null;
		if (worldEntity != null)
		{
			GrapplingHookPointComponent component = worldEntity.GetComponent<GrapplingHookPointComponent>();
			IPilotThrow pilotThrow = ((component != null) ? component.GetHookInteractConfig() : null) as IPilotThrow;
			if (pilotThrow != null)
			{
				EPilotThrowAutoThrowType? autoThrowType = pilotThrow.AutoThrowType;
				List<IPilotThrowTarget> targetList = pilotThrow.TargetList;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PilotThrow;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[PilotThrowController] EnterInteractHookPoint ";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("autoLaunchType", autoThrowType);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("targetList.length", targetList.Count);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				if (autoThrowType != null && targetList.Count == 1)
				{
					global::Vector vector = global::Vector.Create((double)targetList[0].Position.X.GetValueOrDefault(), (double)targetList[0].Position.Y.GetValueOrDefault(), (double)targetList[0].Position.Z.GetValueOrDefault());
					BaseActorComponent component2 = worldEntity.GetComponent<BaseActorComponent>();
					global::Vector vector2 = global::Vector.Create((component2 != null) ? component2.ActorLocationProxy : null);
					float flySpeed = pilotThrow.FlySpeed;
					float num = pilotThrow.Gravity ?? ModelBase<PilotThrowModel>.Instance.Setting.重力加速度;
					global::Vector vector3 = this.CalculateLaunchAngle(vector2, vector, num, flySpeed, autoThrowType.Value);
					if (vector3 != null)
					{
						ModelBase<PilotThrowModel>.Instance.LaunchDirection.DeepCopy(vector3);
						ModelBase<PilotThrowModel>.Instance.LaunchSpeed = flySpeed;
						ModelBase<PilotThrowModel>.Instance.LaunchGravity = num;
						ModelBase<PilotThrowModel>.Instance.NeedMotorRide = pilotThrow.IsAutoRide.GetValueOrDefault();
						ModelBase<PilotThrowModel>.Instance.DisableInterrupt = pilotThrow.DisableInterrupt.GetValueOrDefault();
						global::Vector vector4 = global::Vector.Create();
						vector4.DeepCopy(vector);
						vector4.SubtractionEqual(vector2);
						vector4.Normalize(9.99999993922529E-09);
						ModelBase<PilotThrowModel>.Instance.ForceLookDir = vector4;
						EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
						if (getCurrentEntity == null || getCurrentEntity.Entity == null)
						{
							Singleton<Log>.Instance.Error(ELogModule.PilotThrow, ELogAuthor.CH, "PilotThrowController.EnterInteractHookPoint:当前编队实体为空", default(ReadOnlySpan<ValueTuple<string, object>>));
							return;
						}
						getCurrentEntity.Entity.GetComponent<CharacterSkillComponent>().BeginSkillAsync(210043, null).Forget<bool>();
						TimerSystem.Instance.Delay(delegate(float _)
						{
							this.RequestChangePilotState(true);
						}, ModelBase<PilotThrowModel>.Instance.Setting.自动投掷转状态延迟 * (float)Singleton<TimeUtil>.Instance.InverseMillisecond, null, null, true, 1f);
						this.NeedKeepCameraAndUi = false;
					}
					else
					{
						Singleton<Log>.Instance.Error(ELogModule.PilotThrow, ELogAuthor.CH, "[PilotThrowController] EnterInteractHookPoint CalculateLaunchAngle result is null", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
				}
			}
		}
		else
		{
			Singleton<Log>.Instance.Error(ELogModule.PilotThrow, ELogAuthor.CH, "[PilotThrowController] EnterInteractHookPoint hookPointConfig is null", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		ModelBase<PilotThrowModel>.Instance.CurrentInRangePoint = null;
		if (this.NeedKeepCameraAndUi)
		{
			TimerSystem.Instance.Delay(delegate(float _)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PilotThrowView, null, null);
			}, 1000f, null, null, true, 1f);
		}
	}

	// Token: 0x170017CE RID: 6094
	// (get) Token: 0x0601304C RID: 77900 RVA: 0x00544DCA File Offset: 0x00542FCA
	public USplineComponent ProjectileSpline
	{
		get
		{
			return this.CacheProjectileSplineComp;
		}
	}

	// Token: 0x0601304D RID: 77901 RVA: 0x00544DD4 File Offset: 0x00542FD4
	public void GenerateProjectilePoints()
	{
		if (this.PathPositions == null)
		{
			this.PathPositions = new TArray<FVectorDouble>();
		}
		BP_PilotThrowGameplaySetting_C setting = ModelBase<PilotThrowModel>.Instance.Setting;
		if (setting == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.PilotThrow, ELogAuthor.CH, "[PilotThrowController] GenerateProjectilePoints setting is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		IGuideEffectSpline guideEffectSpline = GameSplineUtils.GenerateGuideEffect(ControllerBase<CameraController>.Instance.MainModel.CameraLocation, this.PathPositions, setting.样条特效.ToAssetPathName());
		if (guideEffectSpline == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.PilotThrow, ELogAuthor.CH, "[PilotThrowController] GenerateProjectilePoints projectileSpine is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null || getCurrentEntity.Entity == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.PilotThrow, ELogAuthor.CH, "[PilotThrowController] GenerateProjectilePoints currentEntity is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.CacheProjectileEffectHandle = new int?(guideEffectSpline.EffectHandle);
		this.CacheProjectileActor = guideEffectSpline.SplineActor;
		this.CacheProjectileSplineComp = guideEffectSpline.SplineComp;
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		FTransformDouble? ftransformDouble = new FTransformDouble?(Singleton<MathUtils>.Instance.DefaultTransformDouble);
		this.FinalDestinationEffectHandle = new int?(instance.SpawnEffect(world, ftransformDouble, setting.终点特效.ToAssetPathName(), "[PilotThrowController] FinalDestinationEffectHandle", new EffectContext(new int?(getCurrentEntity.Entity.Id), null, false), EEffectType.Scene, null, null, null, false, false));
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(ModelBase<PilotThrowModel>.Instance.GetCurrentInteractHookPoint());
		object obj;
		if (entityByPbDataId == null)
		{
			obj = null;
		}
		else
		{
			WorldEntity entity = entityByPbDataId.Entity;
			if (entity == null)
			{
				obj = null;
			}
			else
			{
				GrapplingHookPointComponent component = entity.GetComponent<GrapplingHookPointComponent>();
				obj = ((component != null) ? component.GetHookInteractConfig() : null);
			}
		}
		IPilotThrow pilotThrow = obj as IPilotThrow;
		ModelBase<PilotThrowModel>.Instance.LaunchSpeed = ((pilotThrow != null) ? pilotThrow.FlySpeed : setting.初速度);
		ModelBase<PilotThrowModel>.Instance.LaunchGravity = (((pilotThrow != null) ? pilotThrow.Gravity : null) ?? setting.重力加速度);
		ModelBase<PilotThrowModel>.Instance.NeedMotorRide = ((pilotThrow != null) ? pilotThrow.IsAutoRide : null).GetValueOrDefault();
		ModelBase<PilotThrowModel>.Instance.DisableInterrupt = ((pilotThrow != null) ? pilotThrow.DisableInterrupt : null).GetValueOrDefault();
		base.ResumeTick();
	}

	// Token: 0x0601304E RID: 77902 RVA: 0x00545010 File Offset: 0x00543210
	public void ClearProjectilePoints()
	{
		if (this.CacheProjectileEffectHandle != null && Singleton<EffectSystem>.Instance.IsValid(this.CacheProjectileEffectHandle.Value))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.CacheProjectileEffectHandle.Value, "[PortalController] ClearProjectilePoints", true, null);
			this.CacheProjectileEffectHandle = null;
		}
		if (this.FinalDestinationEffectHandle != null && Singleton<EffectSystem>.Instance.IsValid(this.FinalDestinationEffectHandle.Value))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.FinalDestinationEffectHandle.Value, "[PortalController] ClearProjectilePoints", true, null);
			this.FinalDestinationEffectHandle = null;
		}
		if (this.CacheProjectileActor != null && this.CacheProjectileActor.IsValid())
		{
			Singleton<ActorSystem>.Instance.Put("PilotThrowController.ClearProjectilePoints", this.CacheProjectileActor, null);
			this.CacheProjectileActor = null;
			this.CacheProjectileSplineComp = null;
		}
		base.PauseTick();
	}

	// Token: 0x0601304F RID: 77903 RVA: 0x00545108 File Offset: 0x00543308
	private void UpdateProjectileSpline()
	{
		if (this.CacheProjectileSplineComp == null)
		{
			return;
		}
		BP_PilotThrowGameplaySetting_C setting = ModelBase<PilotThrowModel>.Instance.Setting;
		if (setting == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.PilotThrow, ELogAuthor.CH, "[PilotThrowController] UpdateProjectileSpline setting is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null || getCurrentEntity.Entity == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.PilotThrow, ELogAuthor.CH, "[PilotThrowController] UpdateProjectileSpline curEntity is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		CharacterActorComponent component = getCurrentEntity.Entity.GetComponent<CharacterActorComponent>();
		if (component == null || component.Owner == null || !component.Owner.IsValid())
		{
			Singleton<Log>.Instance.Error(ELogModule.PilotThrow, ELogAuthor.CH, "[PilotThrowController] UpdateProjectileSpline actorComp is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		int currentInteractHookPoint = ModelBase<PilotThrowModel>.Instance.GetCurrentInteractHookPoint();
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(currentInteractHookPoint);
		WorldEntity worldEntity = (entityByPbDataId != null) ? entityByPbDataId.Entity : null;
		object obj;
		if (worldEntity == null)
		{
			obj = null;
		}
		else
		{
			GrapplingHookPointComponent component2 = worldEntity.GetComponent<GrapplingHookPointComponent>();
			obj = ((component2 != null) ? component2.GetHookInteractConfig() : null);
		}
		IPilotThrow pilotThrow = obj as IPilotThrow;
		if (pilotThrow == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.PilotThrow, ELogAuthor.CH, "[PilotThrowController] UpdateProjectileSpline hookPointConfig is null", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		float overrideGravityZ = pilotThrow.Gravity ?? setting.重力加速度;
		float flySpeed = pilotThrow.FlySpeed;
		global::Vector vector = global::Vector.Create(ControllerBase<CameraController>.Instance.MainModel.CameraLocation);
		global::Vector vector2 = global::Vector.Create();
		global::Rotator rotator = global::Rotator.Create(ControllerBase<CameraController>.Instance.MainModel.CameraRotator.Pitch, ControllerBase<CameraController>.Instance.MainModel.CameraRotator.Yaw, 0f);
		FTransformDouble ftransformDouble = new FTransformDouble();
		FVectorDouble fvectorDouble = vector.ToUeVector(false);
		ftransformDouble.SetLocation(fvectorDouble);
		FQuat fquat = rotator.ToUeRotator().Quaternion();
		ftransformDouble.SetRotation(fquat);
		global::Vector vector3 = vector2;
		fvectorDouble = setting.抛物线起点偏移;
		FVectorDouble fvectorDouble2 = ftransformDouble.TransformVector(fvectorDouble);
		vector3.FromUeVector(fvectorDouble2);
		vector.AdditionEqual(vector2);
		this.LauncherVelocity.Set(0.0, 0.0, 0.0);
		this.CameraRot.DeepCopy(ControllerBase<CameraController>.Instance.MainModel.CameraRotator);
		if (this.OffsetRot == null)
		{
			this.OffsetRot = global::Rotator.Create(setting.初速度仰角, 0f, 0f);
		}
		Singleton<MathUtils>.Instance.ComposeRotator(this.OffsetRot, this.CameraRot, Singleton<MathUtils>.Instance.CommonTempRotator);
		Singleton<MathUtils>.Instance.CommonTempRotator.Vector(this.LauncherVelocity);
		this.LauncherVelocity.Normalize(9.99999993922529E-09);
		ModelBase<PilotThrowModel>.Instance.LaunchDirection.DeepCopy(this.LauncherVelocity);
		this.LauncherVelocity.MultiplyEqual((double)flySpeed);
		if (this.TraceObjectTypes == null)
		{
			this.TraceObjectTypes = new TArray<TEnumAsByte<EObjectTypeQuery>>();
			this.TraceObjectTypes.Add(KuroObjectTypeQuery.WorldStatic);
			this.TraceObjectTypes.Add(KuroObjectTypeQuery.Destructible);
			this.TraceObjectTypes.Add(KuroObjectTypeQuery.WorldStaticIgnoreBullet);
		}
		if (this.ProjectilePathParams == null)
		{
			this.ProjectilePathParams = new FPredictProjectilePathParams();
		}
		FVector startLocation = UKismetMathLibrary.WD_WorldToLocal(GlobalData.World, vector.ToUeVector(false));
		this.ProjectilePathParams.StartLocation = startLocation;
		this.ProjectilePathParams.LaunchVelocity = this.LauncherVelocity.ToUeVectorOld();
		this.ProjectilePathParams.bTraceWithCollision = true;
		this.ProjectilePathParams.ProjectileRadius = setting.射线检测半径;
		this.ProjectilePathParams.ObjectTypes = this.TraceObjectTypes;
		this.ProjectilePathParams.bTraceComplex = false;
		this.ProjectilePathParams.DrawDebugType = (setting.DebugMode ? EDrawDebugTrace.ForDuration : EDrawDebugTrace.None);
		this.ProjectilePathParams.DrawDebugTime = 0.1f;
		this.ProjectilePathParams.MaxSimTime = 40f;
		this.ProjectilePathParams.SimFrequency = 3f;
		this.ProjectilePathParams.OverrideGravityZ = overrideGravityZ;
		TArray<AActor> tarray = new TArray<AActor>();
		tarray.Add(component.Owner);
		this.ProjectilePathParams.ActorsToIgnore = tarray;
		FPredictProjectilePathResult projectilePathResult = new FPredictProjectilePathResult();
		bool flag = UGameplayStatics.Blueprint_PredictProjectilePath_Advanced(GlobalData.World, this.ProjectilePathParams, ref projectilePathResult);
		this.ProjectilePathResult = projectilePathResult;
		TArray<FPredictProjectilePathPointData> pathData = this.ProjectilePathResult.PathData;
		if (this.PathPositions == null)
		{
			this.PathPositions = new TArray<FVectorDouble>();
		}
		else
		{
			this.PathPositions.Empty(true);
		}
		FVectorDouble fvectorDouble3 = new FVectorDouble(ref startLocation);
		for (int i = 0; i < pathData.Num(); i++)
		{
			FVector location = pathData[i].Location;
			FVectorDouble value = new FVectorDouble(ref location);
			value = value - fvectorDouble3;
			this.PathPositions.Add(value);
		}
		this.CacheProjectileSplineComp.D_SetSplinePoints(this.PathPositions, ESplineCoordinateSpace.Local, true);
		FHitResult fhitResult = new FHitResult();
		this.CacheProjectileActor.D_K2_SetActorLocation(vector.ToUeVector(false), false, ref fhitResult, true);
		global::Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
		fvectorDouble = this.PathPositions[this.PathPositions.Num() - 1];
		commonTempVector.FromUeVector(fvectorDouble);
		Singleton<MathUtils>.Instance.CommonTempVector.AdditionEqual(vector);
		ModelBase<PilotThrowModel>.Instance.ProjectileSplineLastPoint.DeepCopy(Singleton<MathUtils>.Instance.CommonTempVector);
		if (!flag)
		{
			if (this.FinalDestinationEffectHandle != null && Singleton<EffectSystem>.Instance.IsValid(this.FinalDestinationEffectHandle.Value))
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.FinalDestinationEffectHandle.Value, "[PortalController] ClearProjectilePoints", true, null);
				this.FinalDestinationEffectHandle = null;
			}
			return;
		}
		if (this.FinalDestinationEffectHandle != null && Singleton<EffectSystem>.Instance.IsValid(this.FinalDestinationEffectHandle.Value))
		{
			FHitResult fhitResult2 = new FHitResult();
			OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(this.FinalDestinationEffectHandle.Value);
			fvectorDouble = Singleton<MathUtils>.Instance.CommonTempVector.ToUeVector(false);
			effectActor.D_K2_SetActorLocation(fvectorDouble, false, ref fhitResult2, true);
			return;
		}
		EntityHandle getCurrentEntity2 = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		FTransformDouble? ftransformDouble2 = new FTransformDouble?(Singleton<MathUtils>.Instance.DefaultTransformDouble);
		this.FinalDestinationEffectHandle = new int?(instance.SpawnEffect(world, ftransformDouble2, setting.终点特效.ToAssetPathName(), "[PilotThrowController] FinalDestinationEffectHandle", new EffectContext(new int?(getCurrentEntity2.Entity.Id), null, false), EEffectType.Scene, null, null, null, false, false));
	}

	// Token: 0x06013050 RID: 77904 RVA: 0x0054577F File Offset: 0x0054397F
	protected override void OnTick(float delta)
	{
		this.UpdateProjectileSpline();
	}

	// Token: 0x06013051 RID: 77905 RVA: 0x00545787 File Offset: 0x00543987
	protected override bool OnInit()
	{
		base.PauseTick();
		return true;
	}

	// Token: 0x06013052 RID: 77906 RVA: 0x00545790 File Offset: 0x00543990
	[NullableContext(1)]
	[return: Nullable(2)]
	private unsafe global::Vector CalculateLaunchAngle(global::Vector startPos, global::Vector targetPos, float gravity, float v0, EPilotThrowAutoThrowType launchType)
	{
		global::Vector vector = global::Vector.Create();
		vector.DeepCopy(targetPos);
		vector.SubtractionEqual(startPos);
		float num = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
		double z = vector.Z;
		if (num < 0.001f)
		{
			if (z > 0.0 && (double)(v0 * v0) >= (double)(2f * Math.Abs(gravity)) * z)
			{
				return global::Vector.Create(0.0, 0.0, 1.0);
			}
			return null;
		}
		else
		{
			float num2 = num;
			double num3 = z;
			float num4 = Math.Abs(gravity);
			float num5 = v0 * v0;
			double num6 = (double)(num5 * num5) - (double)num4 * ((double)(num4 * num2 * num2) + (double)(2f * num5) * num3);
			if (num6 < 0.0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PilotThrow;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[PilotThrowController] CalculateLaunchAngle 初速度不足或参数设置错误";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("距离", num2);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("高度差", num3);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("初速度", v0);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("重力", num4);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				return null;
			}
			float num7 = (float)Math.Sqrt(num6);
			float num8 = (num5 + num7) / (num4 * num2);
			float num9 = (num5 - num7) / (num4 * num2);
			Func<float, float, float> func;
			if (launchType != EPilotThrowAutoThrowType.HighAngle)
			{
				if ((func = PilotThrowController.<>O.<1>__Min) == null)
				{
					func = (PilotThrowController.<>O.<1>__Min = new Func<float, float, float>(Math.Min));
				}
			}
			else if ((func = PilotThrowController.<>O.<0>__Max) == null)
			{
				func = (PilotThrowController.<>O.<0>__Max = new Func<float, float, float>(Math.Max));
			}
			float num10 = (float)Math.Atan((double)((func(Math.Abs(num8), Math.Abs(num9)) == Math.Abs(num8)) ? num8 : num9));
			float num11 = (float)Math.Atan2(vector.Y, vector.X);
			global::Rotator rotator = global::Rotator.Create(num10, num11, 0f);
			global::Vector outV = global::Vector.Create();
			rotator.Vector(outV);
			global::Vector vector2 = global::Vector.Create();
			vector2.X = (double)((float)(Math.Cos((double)num10) * Math.Cos((double)num11)));
			vector2.Y = (double)((float)(Math.Cos((double)num10) * Math.Sin((double)num11)));
			vector2.Z = (double)((float)Math.Sin((double)num10));
			vector2.Normalize(9.99999993922529E-09);
			return vector2;
		}
	}

	// Token: 0x06013053 RID: 77907 RVA: 0x00545A20 File Offset: 0x00543C20
	public void RequestChangePilotState(bool isLaunch)
	{
		PilotThrowOperationRequest pilotThrowOperationRequest = PilotThrowOperationRequest.Create();
		pilotThrowOperationRequest.OpType = (isLaunch ? PilotThrowOperationType.Ptothrow : PilotThrowOperationType.Ptocancel);
		Singleton<Net>.Instance.Call<PilotThrowOperationResponse>(ERequestMessageId.PilotThrowOperationRequest, pilotThrowOperationRequest, delegate(PilotThrowOperationResponse response, Net.CallbackStatus _)
		{
		}, 0);
	}

	// Token: 0x0400944C RID: 37964
	public bool NeedKeepCameraAndUi = true;

	// Token: 0x0400944D RID: 37965
	private TArray<FVectorDouble> PathPositions;

	// Token: 0x0400944E RID: 37966
	private int? CacheProjectileEffectHandle;

	// Token: 0x0400944F RID: 37967
	private AActor CacheProjectileActor;

	// Token: 0x04009450 RID: 37968
	private USplineComponent CacheProjectileSplineComp;

	// Token: 0x04009451 RID: 37969
	private int? FinalDestinationEffectHandle;

	// Token: 0x04009452 RID: 37970
	[Nullable(new byte[]
	{
		2,
		0
	})]
	private TArray<TEnumAsByte<EObjectTypeQuery>> TraceObjectTypes;

	// Token: 0x04009453 RID: 37971
	private FPredictProjectilePathParams ProjectilePathParams;

	// Token: 0x04009454 RID: 37972
	private FPredictProjectilePathResult ProjectilePathResult;

	// Token: 0x04009455 RID: 37973
	[Nullable(1)]
	private readonly global::Vector LauncherVelocity = global::Vector.Create();

	// Token: 0x04009456 RID: 37974
	[Nullable(1)]
	private readonly global::Rotator CameraRot = global::Rotator.Create();

	// Token: 0x04009457 RID: 37975
	private global::Rotator OffsetRot;

	// Token: 0x04009458 RID: 37976
	private const int PILOT_AUTO_THROW_SKILL_ID = 210043;

	// Token: 0x0200897D RID: 35197
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402E645 RID: 190021
		[Nullable(0)]
		public static Func<float, float, float> <0>__Max;

		// Token: 0x0402E646 RID: 190022
		[Nullable(0)]
		public static Func<float, float, float> <1>__Min;
	}
}
