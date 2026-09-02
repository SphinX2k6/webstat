using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DB7 RID: 3511
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyChangeAcceleration.TsAnimNotifyChangeAcceleration_C")]
public class TsAnimNotifyChangeAcceleration : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000509 RID: 1289
	// (get) Token: 0x06004F74 RID: 20340 RVA: 0x000B6665 File Offset: 0x000B4865
	// (set) Token: 0x06004F75 RID: 20341 RVA: 0x000B6675 File Offset: 0x000B4875
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Time
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyChangeAcceleration.__PropertyOffset_Time);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyChangeAcceleration.__PropertyOffset_Time) = value;
		}
	}

	// Token: 0x1700050A RID: 1290
	// (get) Token: 0x06004F76 RID: 20342 RVA: 0x000B6686 File Offset: 0x000B4886
	// (set) Token: 0x06004F77 RID: 20343 RVA: 0x000B6696 File Offset: 0x000B4896
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECharState MoveState
	{
		get
		{
			return (ECharState)(*(base.NativePtr + (IntPtr)TsAnimNotifyChangeAcceleration.__PropertyOffset_MoveState));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyChangeAcceleration.__PropertyOffset_MoveState) = (byte)value;
		}
	}

	// Token: 0x06004F78 RID: 20344 RVA: 0x000B66A8 File Offset: 0x000B48A8
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
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

	// Token: 0x06004F79 RID: 20345 RVA: 0x000B6748 File Offset: 0x000B4948
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			Entity entity = tsBaseCharacter.CharacterActorComponent.Entity;
			CharacterMoveComponent characterMoveComponent = (entity != null) ? entity.GetComponent<CharacterMoveComponent>() : null;
			if (characterMoveComponent != null)
			{
				characterMoveComponent.AccelerationLerpTime = this.Time;
				characterMoveComponent.AccelerationChangeMoveState = new ECharMoveState?((ECharMoveState)this.MoveState);
			}
		}
		return true;
	}

	// Token: 0x06004F7A RID: 20346 RVA: 0x000B67A0 File Offset: 0x000B49A0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotify.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotify.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotify.__GetNotifyName_FunctionParams) & -16L);
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

	// Token: 0x06004F7B RID: 20347 RVA: 0x000B681B File Offset: 0x000B4A1B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "修改角色位移最大加速度";
	}

	// Token: 0x06004F7C RID: 20348 RVA: 0x000B6822 File Offset: 0x000B4A22
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyChangeAcceleration._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyChangeAcceleration.TsAnimNotifyChangeAcceleration_C");
		}
		return TsAnimNotifyChangeAcceleration._ClassPtr;
	}

	// Token: 0x06004F7D RID: 20349 RVA: 0x000B6848 File Offset: 0x000B4A48
	public TsAnimNotifyChangeAcceleration() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyChangeAcceleration.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004F7E RID: 20350 RVA: 0x000B6870 File Offset: 0x000B4A70
	[NullableContext(1)]
	public TsAnimNotifyChangeAcceleration(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyChangeAcceleration.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004F7F RID: 20351 RVA: 0x000B68A3 File Offset: 0x000B4AA3
	protected TsAnimNotifyChangeAcceleration(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004F80 RID: 20352 RVA: 0x000B68AC File Offset: 0x000B4AAC
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004F81 RID: 20353 RVA: 0x000B68DF File Offset: 0x000B4ADF
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001729 RID: 5929
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyChangeAcceleration.TsAnimNotifyChangeAcceleration_C";

	// Token: 0x0400172A RID: 5930
	private static IntPtr _ClassPtr;

	// Token: 0x0400172B RID: 5931
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400172C RID: 5932
	private static int __PropertyOffset_Time;

	// Token: 0x0400172D RID: 5933
	private static int __PropertyOffset_MoveState;
}
