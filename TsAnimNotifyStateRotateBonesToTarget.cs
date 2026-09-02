using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D72 RID: 3442
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRotateBonesToTarget.TsAnimNotifyStateRotateBonesToTarget_C")]
public class TsAnimNotifyStateRotateBonesToTarget : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700044E RID: 1102
	// (get) Token: 0x06004AC7 RID: 19143 RVA: 0x000A3FC4 File Offset: 0x000A21C4
	// (set) Token: 0x06004AC8 RID: 19144 RVA: 0x000A3FFD File Offset: 0x000A21FD
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<string> BoneNames
	{
		get
		{
			base.FastCheckIsValid();
			TArray<string> result;
			if ((result = this._BoneNames) == null)
			{
				result = (this._BoneNames = new TArray<string>(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateBonesToTarget.__PropertyOffset_BoneNames, this));
			}
			return result;
		}
		set
		{
			this.BoneNames.CopyAssign(value);
		}
	}

	// Token: 0x1700044F RID: 1103
	// (get) Token: 0x06004AC9 RID: 19145 RVA: 0x000A400B File Offset: 0x000A220B
	// (set) Token: 0x06004ACA RID: 19146 RVA: 0x000A401B File Offset: 0x000A221B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float StartLerpTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateBonesToTarget.__PropertyOffset_StartLerpTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateBonesToTarget.__PropertyOffset_StartLerpTime) = value;
		}
	}

	// Token: 0x17000450 RID: 1104
	// (get) Token: 0x06004ACB RID: 19147 RVA: 0x000A402C File Offset: 0x000A222C
	// (set) Token: 0x06004ACC RID: 19148 RVA: 0x000A403C File Offset: 0x000A223C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float EndLerpTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateBonesToTarget.__PropertyOffset_EndLerpTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateBonesToTarget.__PropertyOffset_EndLerpTime) = value;
		}
	}

	// Token: 0x17000451 RID: 1105
	// (get) Token: 0x06004ACD RID: 19149 RVA: 0x000A404D File Offset: 0x000A224D
	// (set) Token: 0x06004ACE RID: 19150 RVA: 0x000A4061 File Offset: 0x000A2261
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector DefaultOffset
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateBonesToTarget.__PropertyOffset_DefaultOffset);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateBonesToTarget.__PropertyOffset_DefaultOffset) = value;
		}
	}

	// Token: 0x17000452 RID: 1106
	// (get) Token: 0x06004ACF RID: 19151 RVA: 0x000A4076 File Offset: 0x000A2276
	// (set) Token: 0x06004AD0 RID: 19152 RVA: 0x000A4086 File Offset: 0x000A2286
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float LerpSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateBonesToTarget.__PropertyOffset_LerpSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateBonesToTarget.__PropertyOffset_LerpSpeed) = value;
		}
	}

	// Token: 0x17000453 RID: 1107
	// (get) Token: 0x06004AD1 RID: 19153 RVA: 0x000A4097 File Offset: 0x000A2297
	// (set) Token: 0x06004AD2 RID: 19154 RVA: 0x000A40A7 File Offset: 0x000A22A7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TargetUpdateThreshold
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateBonesToTarget.__PropertyOffset_TargetUpdateThreshold);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateBonesToTarget.__PropertyOffset_TargetUpdateThreshold) = value;
		}
	}

	// Token: 0x17000454 RID: 1108
	// (get) Token: 0x06004AD3 RID: 19155 RVA: 0x000A40B8 File Offset: 0x000A22B8
	// (set) Token: 0x06004AD4 RID: 19156 RVA: 0x000A40C8 File Offset: 0x000A22C8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool PauseRotate
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateBonesToTarget.__PropertyOffset_PauseRotate) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateRotateBonesToTarget.__PropertyOffset_PauseRotate) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004AD5 RID: 19157 RVA: 0x000A40D9 File Offset: 0x000A22D9
	private void Init()
	{
		if (this.HandleMap != null)
		{
			return;
		}
		this.HandleMap = new Dictionary<TsBaseCharacter, long>();
		this.PauseHandleMap = new Dictionary<TsBaseCharacter, long>();
	}

	// Token: 0x06004AD6 RID: 19158 RVA: 0x000A40FC File Offset: 0x000A22FC
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

	// Token: 0x06004AD7 RID: 19159 RVA: 0x000A41A4 File Offset: 0x000A23A4
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		this.Init();
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (((tsBaseCharacter != null) ? tsBaseCharacter.CharacterActorComponent : null) == null)
		{
			return false;
		}
		Entity entityNoBlueprint = tsBaseCharacter.GetEntityNoBlueprint();
		RotateBonesToTargetManager rotateBonesToTargetManager;
		if (entityNoBlueprint == null)
		{
			rotateBonesToTargetManager = null;
		}
		else
		{
			CharacterAnimationComponent component = entityNoBlueprint.GetComponent<CharacterAnimationComponent>();
			rotateBonesToTargetManager = ((component != null) ? component.RotateBonesToTargetMgr : null);
		}
		RotateBonesToTargetManager rotateBonesToTargetManager2 = rotateBonesToTargetManager;
		if (rotateBonesToTargetManager2 == null)
		{
			return false;
		}
		if (this.PauseRotate)
		{
			long handle;
			if (this.PauseHandleMap.TryGetValue(tsBaseCharacter, out handle))
			{
				rotateBonesToTargetManager2.ClearPause(handle, 0.1f);
			}
			this.PauseHandleMap[tsBaseCharacter] = rotateBonesToTargetManager2.PauseByNames(this.BoneNames, this.StartLerpTime);
		}
		else
		{
			long handle2;
			if (this.HandleMap.TryGetValue(tsBaseCharacter, out handle2))
			{
				rotateBonesToTargetManager2.StopBoneToTarget(handle2, 0.1f);
			}
			TsAnimNotifyStateRotateBonesToTarget.tmpVector = this.DefaultOffset;
			TsAnimNotifyStateRotateBonesToTarget.tmpVector.Z = TsAnimNotifyStateRotateBonesToTarget.tmpVector.Z + tsBaseCharacter.CharacterActorComponent.DefaultHalfHeight;
			rotateBonesToTargetManager2.SetDefaultTarget(TsAnimNotifyStateRotateBonesToTarget.tmpVector, this.LerpSpeed, this.TargetUpdateThreshold);
			this.HandleMap[tsBaseCharacter] = rotateBonesToTargetManager2.SetBoneToTarget(this.BoneNames, this.StartLerpTime);
		}
		return true;
	}

	// Token: 0x06004AD8 RID: 19160 RVA: 0x000A42B4 File Offset: 0x000A24B4
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

	// Token: 0x06004AD9 RID: 19161 RVA: 0x000A4354 File Offset: 0x000A2554
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (((tsBaseCharacter != null) ? tsBaseCharacter.CharacterActorComponent : null) == null)
		{
			return false;
		}
		Entity entityNoBlueprint = tsBaseCharacter.GetEntityNoBlueprint();
		RotateBonesToTargetManager rotateBonesToTargetManager;
		if (entityNoBlueprint == null)
		{
			rotateBonesToTargetManager = null;
		}
		else
		{
			CharacterAnimationComponent component = entityNoBlueprint.GetComponent<CharacterAnimationComponent>();
			rotateBonesToTargetManager = ((component != null) ? component.RotateBonesToTargetMgr : null);
		}
		RotateBonesToTargetManager rotateBonesToTargetManager2 = rotateBonesToTargetManager;
		if (rotateBonesToTargetManager2 == null)
		{
			return false;
		}
		long handle;
		if (this.HandleMap.TryGetValue(tsBaseCharacter, out handle))
		{
			rotateBonesToTargetManager2.StopBoneToTarget(handle, this.EndLerpTime);
			this.HandleMap.Remove(tsBaseCharacter);
		}
		long handle2;
		if (this.PauseHandleMap.TryGetValue(tsBaseCharacter, out handle2))
		{
			rotateBonesToTargetManager2.ClearPause(handle2, this.EndLerpTime);
			this.PauseHandleMap.Remove(tsBaseCharacter);
		}
		return true;
	}

	// Token: 0x06004ADA RID: 19162 RVA: 0x000A43F8 File Offset: 0x000A25F8
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

	// Token: 0x06004ADB RID: 19163 RVA: 0x000A4473 File Offset: 0x000A2673
	protected override string GetNotifyName_Implementation()
	{
		return "控制多根骨骼朝向目标";
	}

	// Token: 0x06004ADC RID: 19164 RVA: 0x000A447A File Offset: 0x000A267A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateRotateBonesToTarget._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRotateBonesToTarget.TsAnimNotifyStateRotateBonesToTarget_C");
		}
		return TsAnimNotifyStateRotateBonesToTarget._ClassPtr;
	}

	// Token: 0x06004ADD RID: 19165 RVA: 0x000A44A0 File Offset: 0x000A26A0
	public TsAnimNotifyStateRotateBonesToTarget() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateRotateBonesToTarget.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004ADE RID: 19166 RVA: 0x000A44C8 File Offset: 0x000A26C8
	public TsAnimNotifyStateRotateBonesToTarget(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateRotateBonesToTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004ADF RID: 19167 RVA: 0x000A44FB File Offset: 0x000A26FB
	protected TsAnimNotifyStateRotateBonesToTarget(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004AE0 RID: 19168 RVA: 0x000A451C File Offset: 0x000A271C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004AE1 RID: 19169 RVA: 0x000A4558 File Offset: 0x000A2758
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004AE2 RID: 19170 RVA: 0x000A458B File Offset: 0x000A278B
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001547 RID: 5447
	[StaticVariableRuleIgnore]
	private static FVector tmpVector;

	// Token: 0x04001548 RID: 5448
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<TsBaseCharacter, long> HandleMap = new Dictionary<TsBaseCharacter, long>();

	// Token: 0x04001549 RID: 5449
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<TsBaseCharacter, long> PauseHandleMap = new Dictionary<TsBaseCharacter, long>();

	// Token: 0x0400154A RID: 5450
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateRotateBonesToTarget.TsAnimNotifyStateRotateBonesToTarget_C";

	// Token: 0x0400154B RID: 5451
	private static IntPtr _ClassPtr;

	// Token: 0x0400154C RID: 5452
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400154D RID: 5453
	private static int __PropertyOffset_BoneNames;

	// Token: 0x0400154E RID: 5454
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<string> _BoneNames;

	// Token: 0x0400154F RID: 5455
	private static int __PropertyOffset_StartLerpTime;

	// Token: 0x04001550 RID: 5456
	private static int __PropertyOffset_EndLerpTime;

	// Token: 0x04001551 RID: 5457
	private static int __PropertyOffset_DefaultOffset;

	// Token: 0x04001552 RID: 5458
	private static int __PropertyOffset_LerpSpeed;

	// Token: 0x04001553 RID: 5459
	private static int __PropertyOffset_TargetUpdateThreshold;

	// Token: 0x04001554 RID: 5460
	private static int __PropertyOffset_PauseRotate;
}
