using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D49 RID: 3401
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateEnterVehicleFixOffset.TsAnimNotifyStateEnterVehicleFixOffset_C")]
public class TsAnimNotifyStateEnterVehicleFixOffset : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x060047D2 RID: 18386 RVA: 0x0009616C File Offset: 0x0009436C
	static TsAnimNotifyStateEnterVehicleFixOffset()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyStateEnterVehicleFixOffset.CreateStaticDefaultValue), new Action(TsAnimNotifyStateEnterVehicleFixOffset.ResetStaticDefaultValue));
	}

	// Token: 0x060047D3 RID: 18387 RVA: 0x00096206 File Offset: 0x00094406
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyStateEnterVehicleFixOffset.IsInit = false;
		TsAnimNotifyStateEnterVehicleFixOffset.CachedMap = new Dictionary<AActor, FixOffsetParams>();
	}

	// Token: 0x060047D4 RID: 18388 RVA: 0x00096218 File Offset: 0x00094418
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyStateEnterVehicleFixOffset.IsInit = false;
		TsAnimNotifyStateEnterVehicleFixOffset.CachedMap = null;
	}

	// Token: 0x060047D5 RID: 18389 RVA: 0x00096228 File Offset: 0x00094428
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor aactor = (meshComp != null) ? meshComp.GetOwner() : null;
		if (!(aactor is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (aactor as TsBaseCharacter).CharacterActorComponent;
		if (characterActorComponent == null || !characterActorComponent.Valid)
		{
			return false;
		}
		Entity entity = characterActorComponent.Entity;
		CommonNpcPerformComponent.EEnterVehicleDirection? enterVehicleDirection = ControllerBase<NpcVehicleRiderController>.Instance.GetEnterVehicleDirection(entity.Id);
		if (enterVehicleDirection == null)
		{
			return false;
		}
		CommonNpcPerformComponent component = entity.GetComponent<CommonNpcPerformComponent>();
		CommonNpcPerformComponent.EnterVehiclePerformMontage enterVehiclePerformMontage = (component != null) ? component.EnterVehiclePerformMap.GetValueOrDefault(enterVehicleDirection.Value) : null;
		if (enterVehiclePerformMontage == null)
		{
			return false;
		}
		CharacterDriveVehicleComponent component2 = entity.GetComponent<CharacterDriveVehicleComponent>();
		CharacterActorComponent characterActorComponent2;
		if (component2 == null)
		{
			characterActorComponent2 = null;
		}
		else
		{
			Entity vehicleEntity = component2.VehicleEntity;
			characterActorComponent2 = ((vehicleEntity != null) ? vehicleEntity.GetComponent<CharacterActorComponent>() : null);
		}
		CharacterActorComponent characterActorComponent3 = characterActorComponent2;
		if (characterActorComponent3 == null || !characterActorComponent3.Valid)
		{
			return false;
		}
		TsAnimNotifyStateEnterVehicleFixOffset.Initialize();
		Quat actorQuatProxy = characterActorComponent3.ActorQuatProxy;
		Vector tmpVector = TsAnimNotifyStateEnterVehicleFixOffset.TmpVector2;
		Vector vector = tmpVector;
		FVectorDouble socketLocation = characterActorComponent3.GetSocketLocation(Singleton<CharacterNameDefines>.Instance.ROOT);
		vector.FromUeVector(socketLocation);
		Vector tmpVector2 = TsAnimNotifyStateEnterVehicleFixOffset.TmpVector1;
		actorQuatProxy.RotateVector(enterVehiclePerformMontage.Offset, tmpVector2);
		tmpVector2.AdditionEqual(tmpVector);
		Quat inQ = enterVehiclePerformMontage.IdealRotationOffset.Quaternion(TsAnimNotifyStateEnterVehicleFixOffset.TmpQuat1);
		Quat tmpQuat = TsAnimNotifyStateEnterVehicleFixOffset.TmpQuat2;
		actorQuatProxy.Multiply(inQ, tmpQuat);
		FixOffsetParams fixOffsetParams = new FixOffsetParams();
		fixOffsetParams.TotalDuration = totalDuration;
		float currentTimeLength = base.GetCurrentTimeLength();
		EnterVehicleStartTransform enterVehicleStartTransform = (currentTimeLength <= 0.05f) ? ControllerBase<NpcVehicleRiderController>.Instance.GetEnterVehicleStartTransform(entity.Id) : null;
		Vector tmpVector3 = TsAnimNotifyStateEnterVehicleFixOffset.TmpVector3;
		if (enterVehicleStartTransform != null)
		{
			tmpVector3.DeepCopy(enterVehicleStartTransform.RootPos);
		}
		else
		{
			Vector vector2 = tmpVector3;
			socketLocation = characterActorComponent.GetSocketLocation(Singleton<CharacterNameDefines>.Instance.ROOT);
			vector2.FromUeVector(socketLocation);
		}
		tmpVector2.Subtraction(tmpVector3, fixOffsetParams.DeltaPos);
		float yaw = tmpQuat.Rotator(TsAnimNotifyStateEnterVehicleFixOffset.TmpRotator1).Yaw;
		float num = (enterVehicleStartTransform != null) ? enterVehicleStartTransform.Yaw : characterActorComponent.ActorRotationProxy.Yaw;
		fixOffsetParams.DeltaYaw = Singleton<MathUtils>.Instance.WrapAngle(yaw - num);
		CharacterAnimationComponent component3 = entity.GetComponent<CharacterAnimationComponent>();
		UAnimInstance uanimInstance = (component3 != null) ? component3.MainAnimInstance : null;
		if (uanimInstance != null)
		{
			float endDelta = totalDuration - currentTimeLength;
			TsAnimNotifyStateEnterVehicleFixOffset.InitChannel(fixOffsetParams.ChX, uanimInstance, Singleton<CharacterNameDefines>.Instance.ROOT_X, endDelta, (float)fixOffsetParams.DeltaPos.X);
			TsAnimNotifyStateEnterVehicleFixOffset.InitChannel(fixOffsetParams.ChY, uanimInstance, Singleton<CharacterNameDefines>.Instance.ROOT_Y, endDelta, (float)fixOffsetParams.DeltaPos.Y);
			TsAnimNotifyStateEnterVehicleFixOffset.InitChannel(fixOffsetParams.ChZ, uanimInstance, Singleton<CharacterNameDefines>.Instance.ROOT_Z, endDelta, (float)fixOffsetParams.DeltaPos.Z);
			TsAnimNotifyStateEnterVehicleFixOffset.InitChannel(fixOffsetParams.ChLook, uanimInstance, Singleton<CharacterNameDefines>.Instance.ROOT_LOOK, endDelta, fixOffsetParams.DeltaYaw);
		}
		TsAnimNotifyStateEnterVehicleFixOffset.CachedMap.Add(aactor, fixOffsetParams);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.NPC;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "[EnterVehicleFixOffset] Begin";
		<>y__InlineArray8<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray8<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", entity.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Direction", enterVehicleDirection);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("TotalDuration", TsAnimNotifyStateEnterVehicleFixOffset.FmtNum((double)totalDuration));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("载具Pos", TsAnimNotifyStateEnterVehicleFixOffset.FmtVec(tmpVector));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("载具Rot", TsAnimNotifyStateEnterVehicleFixOffset.FmtRot(characterActorComponent3.ActorRotationProxy));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("配置Offset", TsAnimNotifyStateEnterVehicleFixOffset.FmtVec(enterVehiclePerformMontage.Offset));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("配置IdealRot", TsAnimNotifyStateEnterVehicleFixOffset.FmtRot(enterVehiclePerformMontage.IdealRotationOffset));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 7) = new ValueTuple<string, object>("理想起点Pos", TsAnimNotifyStateEnterVehicleFixOffset.FmtVec(tmpVector2));
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 8));
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.NPC;
		ELogAuthor author2 = ELogAuthor.LJM;
		string message2 = "[EnterVehicleFixOffset] Begin";
		<>y__InlineArray13<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray13<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray13<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", entity.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray13<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("运行时Pos", TsAnimNotifyStateEnterVehicleFixOffset.FmtVec(characterActorComponent.ActorLocationProxy));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray13<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("基线RootPos", TsAnimNotifyStateEnterVehicleFixOffset.FmtVec(tmpVector3));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray13<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("用缓存", (enterVehicleStartTransform != null) ? 1 : 0);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray13<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("startTime", TsAnimNotifyStateEnterVehicleFixOffset.FmtNum((double)currentTimeLength));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray13<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 5) = new ValueTuple<string, object>("载具RootPos", TsAnimNotifyStateEnterVehicleFixOffset.FmtVec(tmpVector));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray13<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 6) = new ValueTuple<string, object>("运行时Rot", TsAnimNotifyStateEnterVehicleFixOffset.FmtRot(characterActorComponent.ActorRotationProxy));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray13<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 7) = new ValueTuple<string, object>("位置偏差DeltaPos", TsAnimNotifyStateEnterVehicleFixOffset.FmtVec(fixOffsetParams.DeltaPos));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray13<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 8) = new ValueTuple<string, object>("旋转偏差DeltaYaw", TsAnimNotifyStateEnterVehicleFixOffset.FmtNum((double)fixOffsetParams.DeltaYaw));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray13<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 9) = new ValueTuple<string, object>("通道X.Range", TsAnimNotifyStateEnterVehicleFixOffset.FmtNum((double)fixOffsetParams.ChX.Range));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray13<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 10) = new ValueTuple<string, object>("通道Y.Range", TsAnimNotifyStateEnterVehicleFixOffset.FmtNum((double)fixOffsetParams.ChY.Range));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray13<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 11) = new ValueTuple<string, object>("通道Z.Range", TsAnimNotifyStateEnterVehicleFixOffset.FmtNum((double)fixOffsetParams.ChZ.Range));
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray13<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 12) = new ValueTuple<string, object>("通道Look.Range", TsAnimNotifyStateEnterVehicleFixOffset.FmtNum((double)fixOffsetParams.ChLook.Range));
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray13<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 13));
		return true;
	}

	// Token: 0x060047D6 RID: 18390 RVA: 0x00096800 File Offset: 0x00094A00
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		AActor aactor = (meshComp != null) ? meshComp.GetOwner() : null;
		if (!(aactor is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (aactor as TsBaseCharacter).CharacterActorComponent;
		if (characterActorComponent == null || !characterActorComponent.Valid)
		{
			return false;
		}
		Dictionary<AActor, FixOffsetParams> cachedMap = TsAnimNotifyStateEnterVehicleFixOffset.CachedMap;
		FixOffsetParams @params;
		if (cachedMap == null || !cachedMap.TryGetValue(aactor, out @params))
		{
			return false;
		}
		TsAnimNotifyStateEnterVehicleFixOffset.ApplyIncrement(characterActorComponent, @params, base.GetCurrentTimeLength(), false);
		return true;
	}

	// Token: 0x060047D7 RID: 18391 RVA: 0x00096870 File Offset: 0x00094A70
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor aactor = (meshComp != null) ? meshComp.GetOwner() : null;
		if (!(aactor is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (aactor as TsBaseCharacter).CharacterActorComponent;
		if (characterActorComponent != null && characterActorComponent.Valid)
		{
			Dictionary<AActor, FixOffsetParams> cachedMap = TsAnimNotifyStateEnterVehicleFixOffset.CachedMap;
			FixOffsetParams fixOffsetParams;
			if (cachedMap != null && cachedMap.TryGetValue(aactor, out fixOffsetParams))
			{
				TsAnimNotifyStateEnterVehicleFixOffset.ApplyIncrement(characterActorComponent, fixOffsetParams, base.GetCurrentTimeLength(), true);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.NPC;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[EnterVehicleFixOffset] 累加校验";
				<>y__InlineArray10<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray10<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", characterActorComponent.Entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("累加位移X", TsAnimNotifyStateEnterVehicleFixOffset.FmtNum((double)fixOffsetParams.AppliedX));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("预期偏差X", TsAnimNotifyStateEnterVehicleFixOffset.FmtNum(fixOffsetParams.DeltaPos.X));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("误差X", TsAnimNotifyStateEnterVehicleFixOffset.FmtNum((double)fixOffsetParams.AppliedX - fixOffsetParams.DeltaPos.X));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("累加位移Y", TsAnimNotifyStateEnterVehicleFixOffset.FmtNum((double)fixOffsetParams.AppliedY));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("预期偏差Y", TsAnimNotifyStateEnterVehicleFixOffset.FmtNum(fixOffsetParams.DeltaPos.Y));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("误差Y", TsAnimNotifyStateEnterVehicleFixOffset.FmtNum((double)fixOffsetParams.AppliedY - fixOffsetParams.DeltaPos.Y));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 7) = new ValueTuple<string, object>("累加位移Z", TsAnimNotifyStateEnterVehicleFixOffset.FmtNum((double)fixOffsetParams.AppliedZ));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 8) = new ValueTuple<string, object>("预期偏差Z", TsAnimNotifyStateEnterVehicleFixOffset.FmtNum(fixOffsetParams.DeltaPos.Z));
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 9) = new ValueTuple<string, object>("误差Z", TsAnimNotifyStateEnterVehicleFixOffset.FmtNum((double)fixOffsetParams.AppliedZ - fixOffsetParams.DeltaPos.Z));
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 10));
			}
		}
		Dictionary<AActor, FixOffsetParams> cachedMap2 = TsAnimNotifyStateEnterVehicleFixOffset.CachedMap;
		if (cachedMap2 != null)
		{
			cachedMap2.Remove(aactor);
		}
		if (characterActorComponent != null && characterActorComponent.Valid)
		{
			ControllerBase<NpcVehicleRiderController>.Instance.ClearEnterVehicleStartTransform(characterActorComponent.Entity.Id);
		}
		return true;
	}

	// Token: 0x060047D8 RID: 18392 RVA: 0x00096AC5 File Offset: 0x00094CC5
	[UFunction(EFunctionFlags.FUNC_None)]
	public override string GetNotifyName()
	{
		return "进入载具修正初始位置旋转偏差";
	}

	// Token: 0x060047D9 RID: 18393 RVA: 0x00096ACC File Offset: 0x00094CCC
	private static void InitChannel(CurveChannel channel, UAnimInstance mainAnim, FName curveName, float endDelta, float target)
	{
		float mainAnimsCurveValueWithDelta = mainAnim.GetMainAnimsCurveValueWithDelta(curveName, 0f, false, false);
		channel.Range = mainAnim.GetMainAnimsCurveValueWithDelta(curveName, endDelta, false, false) - mainAnimsCurveValueWithDelta;
		channel.PrevValue = mainAnimsCurveValueWithDelta;
		channel.Acc = 0f;
		channel.AddRate = (Singleton<MathUtils>.Instance.IsNearlyZero((double)channel.Range, null) ? 0f : (target / channel.Range));
	}

	// Token: 0x060047DA RID: 18394 RVA: 0x00096B40 File Offset: 0x00094D40
	private static float StepApplied(CurveChannel channel, [Nullable(2)] UAnimInstance mainAnim, FName curveName, float target, float currentTime, float totalDuration, bool forceFull)
	{
		if (forceFull)
		{
			float result = target - channel.Acc;
			channel.Acc = target;
			return result;
		}
		float num;
		if (mainAnim != null && !Singleton<MathUtils>.Instance.IsNearlyZero((double)channel.Range, null))
		{
			float mainAnimsCurveValueWithDelta = mainAnim.GetMainAnimsCurveValueWithDelta(curveName, 0f, false, false);
			num = channel.AddRate * (mainAnimsCurveValueWithDelta - channel.PrevValue);
			channel.PrevValue = mainAnimsCurveValueWithDelta;
		}
		else
		{
			num = ((totalDuration > 0f) ? (target * Singleton<MathUtils>.Instance.Clamp(currentTime / totalDuration, 0f, 1f)) : target) - channel.Acc;
		}
		channel.Acc += num;
		return num;
	}

	// Token: 0x060047DB RID: 18395 RVA: 0x00096BEC File Offset: 0x00094DEC
	private static void ApplyIncrement(CharacterActorComponent actorComp, FixOffsetParams @params, float currentTime, bool forceFull)
	{
		CharacterAnimationComponent component = actorComp.Entity.GetComponent<CharacterAnimationComponent>();
		UAnimInstance mainAnim = (component != null) ? component.MainAnimInstance : null;
		float num = TsAnimNotifyStateEnterVehicleFixOffset.StepApplied(@params.ChX, mainAnim, Singleton<CharacterNameDefines>.Instance.ROOT_X, (float)@params.DeltaPos.X, currentTime, @params.TotalDuration, forceFull);
		float num2 = TsAnimNotifyStateEnterVehicleFixOffset.StepApplied(@params.ChY, mainAnim, Singleton<CharacterNameDefines>.Instance.ROOT_Y, (float)@params.DeltaPos.Y, currentTime, @params.TotalDuration, forceFull);
		float num3 = TsAnimNotifyStateEnterVehicleFixOffset.StepApplied(@params.ChZ, mainAnim, Singleton<CharacterNameDefines>.Instance.ROOT_Z, (float)@params.DeltaPos.Z, currentTime, @params.TotalDuration, forceFull);
		float num4 = TsAnimNotifyStateEnterVehicleFixOffset.StepApplied(@params.ChLook, mainAnim, Singleton<CharacterNameDefines>.Instance.ROOT_LOOK, @params.DeltaYaw, currentTime, @params.TotalDuration, forceFull);
		if (Singleton<MathUtils>.Instance.IsNearlyZero((double)num, null) && Singleton<MathUtils>.Instance.IsNearlyZero((double)num2, null) && Singleton<MathUtils>.Instance.IsNearlyZero((double)num3, null) && Singleton<MathUtils>.Instance.IsNearlyZero((double)num4, null))
		{
			return;
		}
		actorComp.SetForbidSettingLocAndRot(false, EForbidSettingLocAndRotReason.RideVehicle);
		if (!Singleton<MathUtils>.Instance.IsNearlyZero((double)num, null) || !Singleton<MathUtils>.Instance.IsNearlyZero((double)num2, null) || !Singleton<MathUtils>.Instance.IsNearlyZero((double)num3, null))
		{
			Vector tmpVector = TsAnimNotifyStateEnterVehicleFixOffset.TmpVector1;
			tmpVector.Set((double)num, (double)num2, (double)num3);
			actorComp.AddActorWorldOffset(tmpVector.ToUeVector(false), "TsAnimNotifyStateEnterVehicleFixOffset", false);
			@params.AppliedX += num;
			@params.AppliedY += num2;
			@params.AppliedZ += num3;
		}
		if (!Singleton<MathUtils>.Instance.IsNearlyZero((double)num4, null))
		{
			Rotator tmpRotator = TsAnimNotifyStateEnterVehicleFixOffset.TmpRotator1;
			tmpRotator.Set(0f, num4, 0f);
			actorComp.AddActorLocalRotation(tmpRotator.ToUeRotator(), "TsAnimNotifyStateEnterVehicleFixOffset", false);
		}
		actorComp.SetForbidSettingLocAndRot(true, EForbidSettingLocAndRotReason.RideVehicle);
	}

	// Token: 0x060047DC RID: 18396 RVA: 0x00096E0A File Offset: 0x0009500A
	private static string FmtNum(double value)
	{
		return value.ToString("F2");
	}

	// Token: 0x060047DD RID: 18397 RVA: 0x00096E18 File Offset: 0x00095018
	private static string FmtVec(Vector v)
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 3);
		defaultInterpolatedStringHandler.AppendLiteral("(");
		defaultInterpolatedStringHandler.AppendFormatted<double>(v.X, "F2");
		defaultInterpolatedStringHandler.AppendLiteral(", ");
		defaultInterpolatedStringHandler.AppendFormatted<double>(v.Y, "F2");
		defaultInterpolatedStringHandler.AppendLiteral(", ");
		defaultInterpolatedStringHandler.AppendFormatted<double>(v.Z, "F2");
		defaultInterpolatedStringHandler.AppendLiteral(")");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060047DE RID: 18398 RVA: 0x00096E9C File Offset: 0x0009509C
	private static string FmtRot(Rotator r)
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 3);
		defaultInterpolatedStringHandler.AppendLiteral("(P:");
		defaultInterpolatedStringHandler.AppendFormatted<float>(r.Pitch, "F2");
		defaultInterpolatedStringHandler.AppendLiteral(", Y:");
		defaultInterpolatedStringHandler.AppendFormatted<float>(r.Yaw, "F2");
		defaultInterpolatedStringHandler.AppendLiteral(", R:");
		defaultInterpolatedStringHandler.AppendFormatted<float>(r.Roll, "F2");
		defaultInterpolatedStringHandler.AppendLiteral(")");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060047DF RID: 18399 RVA: 0x00096F20 File Offset: 0x00095120
	private static void Initialize()
	{
		if (TsAnimNotifyStateEnterVehicleFixOffset.IsInit)
		{
			return;
		}
		TsAnimNotifyStateEnterVehicleFixOffset.CachedMap = new Dictionary<AActor, FixOffsetParams>();
		TsAnimNotifyStateEnterVehicleFixOffset.IsInit = true;
	}

	// Token: 0x060047E0 RID: 18400 RVA: 0x00096F3A File Offset: 0x0009513A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateEnterVehicleFixOffset._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateEnterVehicleFixOffset.TsAnimNotifyStateEnterVehicleFixOffset_C");
		}
		return TsAnimNotifyStateEnterVehicleFixOffset._ClassPtr;
	}

	// Token: 0x060047E1 RID: 18401 RVA: 0x00096F60 File Offset: 0x00095160
	public TsAnimNotifyStateEnterVehicleFixOffset() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateEnterVehicleFixOffset.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060047E2 RID: 18402 RVA: 0x00096F88 File Offset: 0x00095188
	public TsAnimNotifyStateEnterVehicleFixOffset(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateEnterVehicleFixOffset.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060047E3 RID: 18403 RVA: 0x00096FBB File Offset: 0x000951BB
	protected TsAnimNotifyStateEnterVehicleFixOffset(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060047E4 RID: 18404 RVA: 0x00096FC4 File Offset: 0x000951C4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x060047E5 RID: 18405 RVA: 0x00097000 File Offset: 0x00095200
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x060047E6 RID: 18406 RVA: 0x0009703C File Offset: 0x0009523C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060047E7 RID: 18407 RVA: 0x0009706F File Offset: 0x0009526F
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName());
	}

	// Token: 0x040013E8 RID: 5096
	private const bool EnableDebugLog = false;

	// Token: 0x040013E9 RID: 5097
	private const float START_FRAME_EPSILON = 0.05f;

	// Token: 0x040013EA RID: 5098
	private static bool IsInit = false;

	// Token: 0x040013EB RID: 5099
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<AActor, FixOffsetParams> CachedMap = null;

	// Token: 0x040013EC RID: 5100
	[StaticVariableRuleIgnore]
	private static readonly Quat TmpQuat1 = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x040013ED RID: 5101
	[StaticVariableRuleIgnore]
	private static readonly Quat TmpQuat2 = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x040013EE RID: 5102
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector1 = Vector.Create();

	// Token: 0x040013EF RID: 5103
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector2 = Vector.Create();

	// Token: 0x040013F0 RID: 5104
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector3 = Vector.Create();

	// Token: 0x040013F1 RID: 5105
	[StaticVariableRuleIgnore]
	private static readonly Rotator TmpRotator1 = Rotator.Create();

	// Token: 0x040013F2 RID: 5106
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateEnterVehicleFixOffset.TsAnimNotifyStateEnterVehicleFixOffset_C";

	// Token: 0x040013F3 RID: 5107
	private static IntPtr _ClassPtr;

	// Token: 0x040013F4 RID: 5108
	private static IntPtr _ClassDefaultObjectPtr;
}
