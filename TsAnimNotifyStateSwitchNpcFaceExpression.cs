using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D92 RID: 3474
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSwitchNpcFaceExpression.TsAnimNotifyStateSwitchNpcFaceExpression_C")]
public class TsAnimNotifyStateSwitchNpcFaceExpression : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004A9 RID: 1193
	// (get) Token: 0x06004D15 RID: 19733 RVA: 0x000ACF2F File Offset: 0x000AB12F
	// (set) Token: 0x06004D16 RID: 19734 RVA: 0x000ACF3F File Offset: 0x000AB13F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int FaceExpressionId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSwitchNpcFaceExpression.__PropertyOffset_FaceExpressionId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSwitchNpcFaceExpression.__PropertyOffset_FaceExpressionId) = value;
		}
	}

	// Token: 0x06004D17 RID: 19735 RVA: 0x000ACF50 File Offset: 0x000AB150
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

	// Token: 0x06004D18 RID: 19736 RVA: 0x000ACFF8 File Offset: 0x000AB1F8
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		CommonNpcPerformComponent commonNpcPerformComponent = (characterActorComponent != null) ? characterActorComponent.Entity.GetComponent<CommonNpcPerformComponent>() : null;
		if (commonNpcPerformComponent == null)
		{
			return false;
		}
		if (this.PlayExpressionHandle == 0)
		{
			this.PlayExpressionHandle = commonNpcPerformComponent.ExpressionController.ChangeFaceForExpressionFromAnimNotify(new int?(this.FaceExpressionId));
		}
		return true;
	}

	// Token: 0x06004D19 RID: 19737 RVA: 0x000AD060 File Offset: 0x000AB260
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

	// Token: 0x06004D1A RID: 19738 RVA: 0x000AD100 File Offset: 0x000AB300
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		CommonNpcPerformComponent commonNpcPerformComponent = (characterActorComponent != null) ? characterActorComponent.Entity.GetComponent<CommonNpcPerformComponent>() : null;
		if (commonNpcPerformComponent == null)
		{
			return false;
		}
		if (this.PlayExpressionHandle != 0)
		{
			commonNpcPerformComponent.ExpressionController.ResetFaceForExpressionFromAnimNotify(this.PlayExpressionHandle);
			this.PlayExpressionHandle = 0;
		}
		return true;
	}

	// Token: 0x06004D1B RID: 19739 RVA: 0x000AD164 File Offset: 0x000AB364
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

	// Token: 0x06004D1C RID: 19740 RVA: 0x000AD1DF File Offset: 0x000AB3DF
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "切换Npc表情";
	}

	// Token: 0x06004D1D RID: 19741 RVA: 0x000AD1E6 File Offset: 0x000AB3E6
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateSwitchNpcFaceExpression._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSwitchNpcFaceExpression.TsAnimNotifyStateSwitchNpcFaceExpression_C");
		}
		return TsAnimNotifyStateSwitchNpcFaceExpression._ClassPtr;
	}

	// Token: 0x06004D1E RID: 19742 RVA: 0x000AD20C File Offset: 0x000AB40C
	public TsAnimNotifyStateSwitchNpcFaceExpression() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSwitchNpcFaceExpression.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004D1F RID: 19743 RVA: 0x000AD234 File Offset: 0x000AB434
	[NullableContext(1)]
	public TsAnimNotifyStateSwitchNpcFaceExpression(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSwitchNpcFaceExpression.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004D20 RID: 19744 RVA: 0x000AD267 File Offset: 0x000AB467
	protected TsAnimNotifyStateSwitchNpcFaceExpression(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004D21 RID: 19745 RVA: 0x000AD270 File Offset: 0x000AB470
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004D22 RID: 19746 RVA: 0x000AD2AC File Offset: 0x000AB4AC
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004D23 RID: 19747 RVA: 0x000AD2DF File Offset: 0x000AB4DF
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001628 RID: 5672
	private int PlayExpressionHandle;

	// Token: 0x04001629 RID: 5673
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSwitchNpcFaceExpression.TsAnimNotifyStateSwitchNpcFaceExpression_C";

	// Token: 0x0400162A RID: 5674
	private static IntPtr _ClassPtr;

	// Token: 0x0400162B RID: 5675
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400162C RID: 5676
	private static int __PropertyOffset_FaceExpressionId;
}
