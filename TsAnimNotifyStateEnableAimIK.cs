using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Monster.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D44 RID: 3396
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateEnableAimIK.TsAnimNotifyStateEnableAimIK_C")]
public class TsAnimNotifyStateEnableAimIK : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170003D2 RID: 978
	// (get) Token: 0x060047A0 RID: 18336 RVA: 0x00095457 File Offset: 0x00093657
	// (set) Token: 0x060047A1 RID: 18337 RVA: 0x00095467 File Offset: 0x00093667
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool SkeletonChange
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateEnableAimIK.__PropertyOffset_SkeletonChange) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateEnableAimIK.__PropertyOffset_SkeletonChange) = (value ? 1 : 0);
		}
	}

	// Token: 0x170003D3 RID: 979
	// (get) Token: 0x060047A2 RID: 18338 RVA: 0x00095478 File Offset: 0x00093678
	// (set) Token: 0x060047A3 RID: 18339 RVA: 0x0009548C File Offset: 0x0009368C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName SightBoneName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateEnableAimIK.__PropertyOffset_SightBoneName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateEnableAimIK.__PropertyOffset_SightBoneName) = value;
		}
	}

	// Token: 0x170003D4 RID: 980
	// (get) Token: 0x060047A4 RID: 18340 RVA: 0x000954A1 File Offset: 0x000936A1
	// (set) Token: 0x060047A5 RID: 18341 RVA: 0x000954B5 File Offset: 0x000936B5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName BeginBoneName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateEnableAimIK.__PropertyOffset_BeginBoneName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateEnableAimIK.__PropertyOffset_BeginBoneName) = value;
		}
	}

	// Token: 0x170003D5 RID: 981
	// (get) Token: 0x060047A6 RID: 18342 RVA: 0x000954CA File Offset: 0x000936CA
	// (set) Token: 0x060047A7 RID: 18343 RVA: 0x000954DE File Offset: 0x000936DE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName EndBoneName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateEnableAimIK.__PropertyOffset_EndBoneName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateEnableAimIK.__PropertyOffset_EndBoneName) = value;
		}
	}

	// Token: 0x170003D6 RID: 982
	// (get) Token: 0x060047A8 RID: 18344 RVA: 0x000954F3 File Offset: 0x000936F3
	// (set) Token: 0x060047A9 RID: 18345 RVA: 0x00095503 File Offset: 0x00093703
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float AssistLimit
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateEnableAimIK.__PropertyOffset_AssistLimit);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateEnableAimIK.__PropertyOffset_AssistLimit) = value;
		}
	}

	// Token: 0x060047AA RID: 18346 RVA: 0x00095514 File Offset: 0x00093714
	[NullableContext(2)]
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

	// Token: 0x060047AB RID: 18347 RVA: 0x000955BC File Offset: 0x000937BC
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
			Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
			if (entity != null)
			{
				UAnimInstance mainAnimInstance = entity.GetComponent<CharacterAnimationComponent>().MainAnimInstance;
				if (UKuroStaticLibrary.IsObjectClassByName(mainAnimInstance, Singleton<CharacterNameDefines>.Instance.ABP_MONSTERCOMMON))
				{
					ABP_MonsterCommon_C abp_MonsterCommon_C = mainAnimInstance as ABP_MonsterCommon_C;
					this.OldSightBoneName = new FName?(abp_MonsterCommon_C.Sight_Bone_Name);
					this.OldBeginBoneName = new FName?(abp_MonsterCommon_C.Begin_Bone_Name);
					this.OldEndBoneName = new FName?(abp_MonsterCommon_C.End_Bone_Name);
					this.OldCameraMode = abp_MonsterCommon_C.SightLockMode;
					this.OldAssistLimit = abp_MonsterCommon_C.Assist_Limit;
					abp_MonsterCommon_C.Sight_Bone_Name = this.SightBoneName;
					abp_MonsterCommon_C.Begin_Bone_Name = this.BeginBoneName;
					abp_MonsterCommon_C.End_Bone_Name = this.EndBoneName;
					abp_MonsterCommon_C.SightLockMode = SightLockMode.Shooting;
					abp_MonsterCommon_C.Assist_Limit = this.AssistLimit;
					if (this.SkeletonChange)
					{
						abp_MonsterCommon_C.Increment++;
					}
					return true;
				}
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Test;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "No Entity for TsBaseCharacter ";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", owner);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("location", owner.D_K2_GetActorLocation());
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
		return false;
	}

	// Token: 0x060047AC RID: 18348 RVA: 0x00095728 File Offset: 0x00093928
	[NullableContext(2)]
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

	// Token: 0x060047AD RID: 18349 RVA: 0x000957C8 File Offset: 0x000939C8
	[NullableContext(2)]
	protected unsafe virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
			Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
			if (entity != null)
			{
				UAnimInstance mainAnimInstance = entity.GetComponent<CharacterAnimationComponent>().MainAnimInstance;
				if (UKuroStaticLibrary.IsObjectClassByName(mainAnimInstance, Singleton<CharacterNameDefines>.Instance.ABP_MONSTERCOMMON))
				{
					ABP_MonsterCommon_C abp_MonsterCommon_C = mainAnimInstance as ABP_MonsterCommon_C;
					abp_MonsterCommon_C.Sight_Bone_Name = this.OldSightBoneName.Value;
					abp_MonsterCommon_C.Begin_Bone_Name = this.OldBeginBoneName.Value;
					abp_MonsterCommon_C.End_Bone_Name = this.OldEndBoneName.Value;
					abp_MonsterCommon_C.SightLockMode = this.OldCameraMode;
					abp_MonsterCommon_C.Assist_Limit = this.OldAssistLimit;
					return true;
				}
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Test;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "No Entity for TsBaseCharacter";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", owner);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("location", owner.D_K2_GetActorLocation());
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
		return false;
	}

	// Token: 0x060047AE RID: 18350 RVA: 0x000958D4 File Offset: 0x00093AD4
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

	// Token: 0x060047AF RID: 18351 RVA: 0x0009594F File Offset: 0x00093B4F
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "瞄准动作IK";
	}

	// Token: 0x060047B0 RID: 18352 RVA: 0x00095956 File Offset: 0x00093B56
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateEnableAimIK._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateEnableAimIK.TsAnimNotifyStateEnableAimIK_C");
		}
		return TsAnimNotifyStateEnableAimIK._ClassPtr;
	}

	// Token: 0x060047B1 RID: 18353 RVA: 0x0009597C File Offset: 0x00093B7C
	public TsAnimNotifyStateEnableAimIK() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateEnableAimIK.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060047B2 RID: 18354 RVA: 0x000959A4 File Offset: 0x00093BA4
	[NullableContext(1)]
	public TsAnimNotifyStateEnableAimIK(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateEnableAimIK.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060047B3 RID: 18355 RVA: 0x000959D7 File Offset: 0x00093BD7
	protected TsAnimNotifyStateEnableAimIK(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060047B4 RID: 18356 RVA: 0x000959E0 File Offset: 0x00093BE0
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x060047B5 RID: 18357 RVA: 0x00095A1C File Offset: 0x00093C1C
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060047B6 RID: 18358 RVA: 0x00095A4F File Offset: 0x00093C4F
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040013C6 RID: 5062
	private FName? OldSightBoneName;

	// Token: 0x040013C7 RID: 5063
	private FName? OldBeginBoneName;

	// Token: 0x040013C8 RID: 5064
	private FName? OldEndBoneName;

	// Token: 0x040013C9 RID: 5065
	private SightLockMode OldCameraMode;

	// Token: 0x040013CA RID: 5066
	private float OldAssistLimit;

	// Token: 0x040013CB RID: 5067
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateEnableAimIK.TsAnimNotifyStateEnableAimIK_C";

	// Token: 0x040013CC RID: 5068
	private static IntPtr _ClassPtr;

	// Token: 0x040013CD RID: 5069
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040013CE RID: 5070
	private static int __PropertyOffset_SkeletonChange;

	// Token: 0x040013CF RID: 5071
	private static int __PropertyOffset_SightBoneName;

	// Token: 0x040013D0 RID: 5072
	private static int __PropertyOffset_BeginBoneName;

	// Token: 0x040013D1 RID: 5073
	private static int __PropertyOffset_EndBoneName;

	// Token: 0x040013D2 RID: 5074
	private static int __PropertyOffset_AssistLimit;
}
