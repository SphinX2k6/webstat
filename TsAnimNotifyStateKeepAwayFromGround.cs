using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D58 RID: 3416
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateKeepAwayFromGround.TsAnimNotifyStateKeepAwayFromGround_C")]
public class TsAnimNotifyStateKeepAwayFromGround : TsAnimNotifyStateBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x060048AA RID: 18602 RVA: 0x0009A935 File Offset: 0x00098B35
	static TsAnimNotifyStateKeepAwayFromGround()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsAnimNotifyStateKeepAwayFromGround.CreateStaticDefaultValue), new Action(TsAnimNotifyStateKeepAwayFromGround.ResetStaticDefaultValue));
	}

	// Token: 0x060048AB RID: 18603 RVA: 0x0009A954 File Offset: 0x00098B54
	public static void CreateStaticDefaultValue()
	{
		TsAnimNotifyStateKeepAwayFromGround.paramsMap = new Dictionary<int, KeepAwayFromGroundParam>();
	}

	// Token: 0x060048AC RID: 18604 RVA: 0x0009A960 File Offset: 0x00098B60
	public static void ResetStaticDefaultValue()
	{
		TsAnimNotifyStateKeepAwayFromGround.paramsMap = null;
	}

	// Token: 0x170003EE RID: 1006
	// (get) Token: 0x060048AD RID: 18605 RVA: 0x0009A968 File Offset: 0x00098B68
	// (set) Token: 0x060048AE RID: 18606 RVA: 0x0009A978 File Offset: 0x00098B78
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 距离水平面最小高度
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepAwayFromGround.__PropertyOffset_距离水平面最小高度);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepAwayFromGround.__PropertyOffset_距离水平面最小高度) = value;
		}
	}

	// Token: 0x170003EF RID: 1007
	// (get) Token: 0x060048AF RID: 18607 RVA: 0x0009A989 File Offset: 0x00098B89
	// (set) Token: 0x060048B0 RID: 18608 RVA: 0x0009A999 File Offset: 0x00098B99
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 距离水平面最大高度
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepAwayFromGround.__PropertyOffset_距离水平面最大高度);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepAwayFromGround.__PropertyOffset_距离水平面最大高度) = value;
		}
	}

	// Token: 0x170003F0 RID: 1008
	// (get) Token: 0x060048B1 RID: 18609 RVA: 0x0009A9AA File Offset: 0x00098BAA
	// (set) Token: 0x060048B2 RID: 18610 RVA: 0x0009A9BE File Offset: 0x00098BBE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UCurveFloat MoveCurve
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateKeepAwayFromGround.__PropertyOffset_MoveCurve);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateKeepAwayFromGround.__PropertyOffset_MoveCurve, value);
		}
	}

	// Token: 0x170003F1 RID: 1009
	// (get) Token: 0x060048B3 RID: 18611 RVA: 0x0009A9D3 File Offset: 0x00098BD3
	// (set) Token: 0x060048B4 RID: 18612 RVA: 0x0009A9E3 File Offset: 0x00098BE3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepAwayFromGround.__PropertyOffset_MaxSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepAwayFromGround.__PropertyOffset_MaxSpeed) = value;
		}
	}

	// Token: 0x170003F2 RID: 1010
	// (get) Token: 0x060048B5 RID: 18613 RVA: 0x0009A9F4 File Offset: 0x00098BF4
	// (set) Token: 0x060048B6 RID: 18614 RVA: 0x0009AA04 File Offset: 0x00098C04
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 不使用默认插值曲线
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepAwayFromGround.__PropertyOffset_不使用默认插值曲线) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateKeepAwayFromGround.__PropertyOffset_不使用默认插值曲线) = (value ? 1 : 0);
		}
	}

	// Token: 0x060048B7 RID: 18615 RVA: 0x0009AA18 File Offset: 0x00098C18
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x060048B8 RID: 18616 RVA: 0x0009AAC0 File Offset: 0x00098CC0
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		this.TsMinHeight = this.距离水平面最小高度;
		this.TsMaxHeight = this.距离水平面最大高度;
		this.TsIgnoreInterpolation = this.不使用默认插值曲线;
		this.TsMaxSpeed = this.MaxSpeed;
		this.TsTmpVector = Vector.Create();
		if (this.TsMaxHeight > 0f && this.TsMaxHeight < this.TsMinHeight)
		{
			Singleton<Log>.Instance.Error(ELogModule.Test, ELogAuthor.HXY, "Z轴帧事件参数错误", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		if (this.TsMaxSpeed <= 0f)
		{
			return false;
		}
		int id = ((TsBaseCharacter)owner).CharacterActorComponent.Entity.Id;
		KeepAwayFromGroundParam keepAwayFromGroundParam = null;
		if (!TsAnimNotifyStateKeepAwayFromGround.paramsMap.TryGetValue(id, out keepAwayFromGroundParam))
		{
			keepAwayFromGroundParam = new KeepAwayFromGroundParam();
			TsAnimNotifyStateKeepAwayFromGround.paramsMap[id] = keepAwayFromGroundParam;
		}
		keepAwayFromGroundParam.NowTime = 0f;
		keepAwayFromGroundParam.TotalTime = totalDuration;
		return true;
	}

	// Token: 0x060048B9 RID: 18617 RVA: 0x0009ABB0 File Offset: 0x00098DB0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->FrameDeltaTime = frameDeltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x060048BA RID: 18618 RVA: 0x0009AC58 File Offset: 0x00098E58
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		if ((double)frameDeltaTime < 0.0001)
		{
			return false;
		}
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		int id = characterActorComponent.Entity.Id;
		KeepAwayFromGroundParam keepAwayFromGroundParam = null;
		if (!TsAnimNotifyStateKeepAwayFromGround.paramsMap.TryGetValue(id, out keepAwayFromGroundParam))
		{
			return false;
		}
		this.MoveToTarget(frameDeltaTime, keepAwayFromGroundParam, characterActorComponent);
		keepAwayFromGroundParam.NowTime += frameDeltaTime;
		return true;
	}

	// Token: 0x060048BB RID: 18619 RVA: 0x0009ACC4 File Offset: 0x00098EC4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x060048BC RID: 18620 RVA: 0x0009AD64 File Offset: 0x00098F64
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		int id = ((TsBaseCharacter)owner).CharacterActorComponent.Entity.Id;
		TsAnimNotifyStateKeepAwayFromGround.paramsMap.Remove(id);
		return true;
	}

	// Token: 0x060048BD RID: 18621 RVA: 0x0009ADA8 File Offset: 0x00098FA8
	[NullableContext(1)]
	private float GetRate(float delta, KeepAwayFromGroundParam param)
	{
		double num = 1.0;
		float num2 = param.NowTime + delta;
		if (param.TotalTime <= num2)
		{
			return 1f;
		}
		if (this.MoveCurve != null)
		{
			float floatValue = this.MoveCurve.GetFloatValue(param.NowTime / param.TotalTime);
			float floatValue2 = this.MoveCurve.GetFloatValue(num2 / param.TotalTime);
			if (floatValue >= 1f)
			{
				return 0f;
			}
			num = (double)((floatValue2 - floatValue) / (1f - floatValue));
		}
		else if (!this.TsIgnoreInterpolation)
		{
			double cubicValue = Singleton<MathUtils>.Instance.GetCubicValue((double)(param.NowTime / param.TotalTime));
			double cubicValue2 = Singleton<MathUtils>.Instance.GetCubicValue((double)(num2 / param.TotalTime));
			if (cubicValue >= 1.0)
			{
				return 0f;
			}
			num = (cubicValue2 - cubicValue) / (1.0 - cubicValue);
		}
		return (float)num;
	}

	// Token: 0x060048BE RID: 18622 RVA: 0x0009AE88 File Offset: 0x00099088
	[NullableContext(1)]
	private void MoveToTarget(float frameDeltaTime, KeepAwayFromGroundParam param, CharacterActorComponent actorComp)
	{
		BaseMoveComponent component = actorComp.Entity.GetComponent<CharacterMoveComponent>();
		float heightDetect = (this.TsMaxHeight <= 0f) ? this.TsMinHeight : this.TsMaxHeight;
		float heightAboveGround = component.GetHeightAboveGround(heightDetect);
		if (heightAboveGround < this.TsMinHeight)
		{
			this.TsTmpVector.Set(0.0, 0.0, (double)(this.TsMinHeight - heightAboveGround));
			float rate = this.GetRate(frameDeltaTime, param);
			if (rate <= 0f)
			{
				return;
			}
			this.TsTmpVector.Z = Math.Min(this.TsTmpVector.Z * (double)rate, (double)(this.TsMaxSpeed * frameDeltaTime));
		}
		else
		{
			if (this.TsMaxHeight <= 0f || heightAboveGround < this.TsMaxHeight || actorComp.ActorLocationProxy.Z <= actorComp.LastActorLocation.Z)
			{
				return;
			}
			this.TsTmpVector.Set(0.0, 0.0, actorComp.LastActorLocation.Z - actorComp.ActorLocationProxy.Z);
		}
		actorComp.AddActorWorldOffset(this.TsTmpVector.ToUeVector(false), "TsAnimNotifyStateKeepAwayFromGround.AddActorWorldOffset", true);
	}

	// Token: 0x060048BF RID: 18623 RVA: 0x0009AFAC File Offset: 0x000991AC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x060048C0 RID: 18624 RVA: 0x0009B027 File Offset: 0x00099227
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "角色和地面保持一定距离";
	}

	// Token: 0x060048C1 RID: 18625 RVA: 0x0009B02E File Offset: 0x0009922E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateKeepAwayFromGround._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateKeepAwayFromGround.TsAnimNotifyStateKeepAwayFromGround_C");
		}
		return TsAnimNotifyStateKeepAwayFromGround._ClassPtr;
	}

	// Token: 0x060048C2 RID: 18626 RVA: 0x0009B054 File Offset: 0x00099254
	public TsAnimNotifyStateKeepAwayFromGround() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateKeepAwayFromGround.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060048C3 RID: 18627 RVA: 0x0009B07C File Offset: 0x0009927C
	[NullableContext(1)]
	public TsAnimNotifyStateKeepAwayFromGround(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateKeepAwayFromGround.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060048C4 RID: 18628 RVA: 0x0009B0AF File Offset: 0x000992AF
	protected TsAnimNotifyStateKeepAwayFromGround(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060048C5 RID: 18629 RVA: 0x0009B0B8 File Offset: 0x000992B8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x060048C6 RID: 18630 RVA: 0x0009B0F4 File Offset: 0x000992F4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x060048C7 RID: 18631 RVA: 0x0009B130 File Offset: 0x00099330
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060048C8 RID: 18632 RVA: 0x0009B163 File Offset: 0x00099363
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001448 RID: 5192
	[Nullable(1)]
	private static Dictionary<int, KeepAwayFromGroundParam> paramsMap;

	// Token: 0x04001449 RID: 5193
	private float TsMinHeight;

	// Token: 0x0400144A RID: 5194
	private float TsMaxHeight;

	// Token: 0x0400144B RID: 5195
	private float TsMaxSpeed;

	// Token: 0x0400144C RID: 5196
	[Nullable(1)]
	private Vector TsTmpVector;

	// Token: 0x0400144D RID: 5197
	private bool TsIgnoreInterpolation;

	// Token: 0x0400144E RID: 5198
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateKeepAwayFromGround.TsAnimNotifyStateKeepAwayFromGround_C";

	// Token: 0x0400144F RID: 5199
	private static IntPtr _ClassPtr;

	// Token: 0x04001450 RID: 5200
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001451 RID: 5201
	private static int __PropertyOffset_距离水平面最小高度;

	// Token: 0x04001452 RID: 5202
	private static int __PropertyOffset_距离水平面最大高度;

	// Token: 0x04001453 RID: 5203
	private static int __PropertyOffset_MoveCurve;

	// Token: 0x04001454 RID: 5204
	private static int __PropertyOffset_MaxSpeed;

	// Token: 0x04001455 RID: 5205
	private static int __PropertyOffset_不使用默认插值曲线;
}
