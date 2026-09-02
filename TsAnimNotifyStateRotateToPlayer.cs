using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D75 RID: 3445
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRotateToPlayer.TsAnimNotifyStateRotateToPlayer_C")]
public class TsAnimNotifyStateRotateToPlayer : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000459 RID: 1113
	// (get) Token: 0x06004AFE RID: 19198 RVA: 0x000A4DA9 File Offset: 0x000A2FA9
	// (set) Token: 0x06004AFF RID: 19199 RVA: 0x000A4DB9 File Offset: 0x000A2FB9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float 旋转速度
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateToPlayer.__PropertyOffset_旋转速度);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateToPlayer.__PropertyOffset_旋转速度) = value;
		}
	}

	// Token: 0x1700045A RID: 1114
	// (get) Token: 0x06004B00 RID: 19200 RVA: 0x000A4DCA File Offset: 0x000A2FCA
	// (set) Token: 0x06004B01 RID: 19201 RVA: 0x000A4DDE File Offset: 0x000A2FDE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UCurveFloat Curve
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateRotateToPlayer.__PropertyOffset_Curve);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateRotateToPlayer.__PropertyOffset_Curve, value);
		}
	}

	// Token: 0x1700045B RID: 1115
	// (get) Token: 0x06004B02 RID: 19202 RVA: 0x000A4DF4 File Offset: 0x000A2FF4
	// (set) Token: 0x06004B03 RID: 19203 RVA: 0x000A4E2D File Offset: 0x000A302D
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public FGameplayTagContainer 屏蔽标签列表
	{
		[NullableContext(1)]
		get
		{
			base.FastCheckIsValid();
			FGameplayTagContainer result;
			if ((result = this._屏蔽标签列表) == null)
			{
				result = (this._屏蔽标签列表 = new FGameplayTagContainer(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateToPlayer.__PropertyOffset_屏蔽标签列表, this));
			}
			return result;
		}
		[NullableContext(1)]
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)TsAnimNotifyStateRotateToPlayer.__PropertyOffset_屏蔽标签列表, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x06004B04 RID: 19204 RVA: 0x000A4E58 File Offset: 0x000A3058
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

	// Token: 0x06004B05 RID: 19205 RVA: 0x000A4F00 File Offset: 0x000A3100
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		this.Initialize();
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		UBaseAbilitySystemComponent abilitySystemComponent = (owner as TsBaseCharacter).AbilitySystemComponent;
		bool flag;
		if (abilitySystemComponent == null)
		{
			flag = false;
		}
		else
		{
			FGameplayTagContainer 屏蔽标签列表 = this.屏蔽标签列表;
			flag = abilitySystemComponent.HasAnyGameplayTag(屏蔽标签列表);
		}
		if (flag)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		if (entity == null || !entity.Valid)
		{
			return false;
		}
		if (!this.ParamsMap.ContainsKey(entity.Id))
		{
			this.ParamsMap[entity.Id] = new RotateToPlayerParam(totalDuration);
		}
		else
		{
			this.ParamsMap[entity.Id].Update(0f, totalDuration);
		}
		return true;
	}

	// Token: 0x06004B06 RID: 19206 RVA: 0x000A4FBC File Offset: 0x000A31BC
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

	// Token: 0x06004B07 RID: 19207 RVA: 0x000A5064 File Offset: 0x000A3264
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		return entity != null && entity.Valid && this.UpdateRotationRole(tsBaseCharacter.CharacterActorComponent, frameDeltaTime);
	}

	// Token: 0x06004B08 RID: 19208 RVA: 0x000A50B4 File Offset: 0x000A32B4
	[NullableContext(1)]
	private bool UpdateRotationRole(CharacterActorComponent actorComp, float frameDeltaTime)
	{
		RotateToPlayerParam rotateToPlayerParam;
		if (!this.ParamsMap.TryGetValue(actorComp.Entity.Id, out rotateToPlayerParam))
		{
			return false;
		}
		float nowTime = rotateToPlayerParam.NowTime;
		rotateToPlayerParam.NowTime += frameDeltaTime;
		float inYaw = this.旋转速度 * frameDeltaTime;
		float num = nowTime * rotateToPlayerParam.TotalDurationReciprocal;
		float num2 = rotateToPlayerParam.NowTime * rotateToPlayerParam.TotalDurationReciprocal;
		if (this.Curve != null)
		{
			num = this.Curve.GetFloatValue(Singleton<MathUtils>.Instance.Clamp(num, 0f, 1f));
			num2 = this.Curve.GetFloatValue(Singleton<MathUtils>.Instance.Clamp(num2, 0f, 1f));
		}
		float rotationRoleAngle = this.GetRotationRoleAngle(actorComp);
		float num3 = Singleton<MathUtils>.Instance.Clamp((num2 - num) / (1f - num), 0f, 1f);
		float value = rotationRoleAngle * num3 / frameDeltaTime;
		inYaw = (float)Math.Sign(value) * Singleton<MathUtils>.Instance.Clamp(Math.Abs(value), 0f, this.旋转速度) * frameDeltaTime;
		Singleton<MathUtils>.Instance.CommonTempQuat.DeepCopy(actorComp.ActorQuatProxy);
		Singleton<MathUtils>.Instance.CommonTempRotator.Set(0f, inYaw, 0f);
		Singleton<MathUtils>.Instance.CommonTempQuat.Multiply(Singleton<MathUtils>.Instance.CommonTempRotator.Quaternion(null), this.TmpQuat);
		this.TmpQuat.Rotator(Singleton<MathUtils>.Instance.CommonTempRotator);
		actorComp.SetActorRotation(Singleton<MathUtils>.Instance.CommonTempRotator.ToUeRotator(), "TsAnimNotifyStateRotate", false);
		actorComp.SetInputRotator(Singleton<MathUtils>.Instance.CommonTempRotator);
		return true;
	}

	// Token: 0x06004B09 RID: 19209 RVA: 0x000A5248 File Offset: 0x000A3448
	[NullableContext(1)]
	private float GetRotationRoleAngle(CharacterActorComponent actorComp)
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter == null || !baseCharacter.IsValid())
		{
			return 0f;
		}
		Vector actorForwardProxy = actorComp.ActorForwardProxy;
		Vector tmpVector = this.TmpVector;
		CharacterActorComponent characterActorComponent = Global.BaseCharacter.CharacterActorComponent;
		tmpVector.DeepCopy(characterActorComponent.ActorLocationProxy);
		tmpVector.SubtractionEqual(actorComp.ActorLocationProxy);
		tmpVector.Normalize(9.99999993922529E-09);
		return Singleton<GravityUtils>.Instance.GetAngleOffsetInGravityForActor(actorComp, actorForwardProxy, tmpVector);
	}

	// Token: 0x06004B0A RID: 19210 RVA: 0x000A52C0 File Offset: 0x000A34C0
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

	// Token: 0x06004B0B RID: 19211 RVA: 0x000A5360 File Offset: 0x000A3560
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			Dictionary<int, RotateToPlayerParam> paramsMap = this.ParamsMap;
			if (paramsMap != null)
			{
				CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
				paramsMap.Remove((characterActorComponent != null) ? characterActorComponent.Entity.Id : 0);
			}
		}
		return false;
	}

	// Token: 0x06004B0C RID: 19212 RVA: 0x000A53AC File Offset: 0x000A35AC
	private void Initialize()
	{
		if (this.IsInitialize)
		{
			return;
		}
		this.IsInitialize = true;
		this.ParamsMap = new Dictionary<int, RotateToPlayerParam>();
		this.TmpVector = Vector.Create();
		this.TmpQuat = Quat.Create(0f, 0f, 0f, 1f);
	}

	// Token: 0x06004B0D RID: 19213 RVA: 0x000A5400 File Offset: 0x000A3600
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

	// Token: 0x06004B0E RID: 19214 RVA: 0x000A547B File Offset: 0x000A367B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "旋转朝向玩家";
	}

	// Token: 0x06004B0F RID: 19215 RVA: 0x000A5482 File Offset: 0x000A3682
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateRotateToPlayer._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRotateToPlayer.TsAnimNotifyStateRotateToPlayer_C");
		}
		return TsAnimNotifyStateRotateToPlayer._ClassPtr;
	}

	// Token: 0x06004B10 RID: 19216 RVA: 0x000A54A8 File Offset: 0x000A36A8
	public TsAnimNotifyStateRotateToPlayer() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateRotateToPlayer.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004B11 RID: 19217 RVA: 0x000A54D0 File Offset: 0x000A36D0
	[NullableContext(1)]
	public TsAnimNotifyStateRotateToPlayer(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateRotateToPlayer.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004B12 RID: 19218 RVA: 0x000A5503 File Offset: 0x000A3703
	protected TsAnimNotifyStateRotateToPlayer(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004B13 RID: 19219 RVA: 0x000A550C File Offset: 0x000A370C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004B14 RID: 19220 RVA: 0x000A5548 File Offset: 0x000A3748
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004B15 RID: 19221 RVA: 0x000A5584 File Offset: 0x000A3784
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004B16 RID: 19222 RVA: 0x000A55B7 File Offset: 0x000A37B7
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001562 RID: 5474
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, RotateToPlayerParam> ParamsMap;

	// Token: 0x04001563 RID: 5475
	private bool IsInitialize;

	// Token: 0x04001564 RID: 5476
	private Vector TmpVector;

	// Token: 0x04001565 RID: 5477
	private Quat TmpQuat;

	// Token: 0x04001566 RID: 5478
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRotateToPlayer.TsAnimNotifyStateRotateToPlayer_C";

	// Token: 0x04001567 RID: 5479
	private static IntPtr _ClassPtr;

	// Token: 0x04001568 RID: 5480
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001569 RID: 5481
	private static int __PropertyOffset_旋转速度;

	// Token: 0x0400156A RID: 5482
	private static int __PropertyOffset_Curve;

	// Token: 0x0400156B RID: 5483
	private static int __PropertyOffset_屏蔽标签列表;

	// Token: 0x0400156C RID: 5484
	private FGameplayTagContainer _屏蔽标签列表;
}
