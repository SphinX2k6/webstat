using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DAB RID: 3499
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBattleState.TsAnimNotifyBattleState_C")]
public class TsAnimNotifyBattleState : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004EC RID: 1260
	// (get) Token: 0x06004EC4 RID: 20164 RVA: 0x000B4367 File Offset: 0x000B2567
	// (set) Token: 0x06004EC5 RID: 20165 RVA: 0x000B4377 File Offset: 0x000B2577
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool 取消无敌
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyBattleState.__PropertyOffset_取消无敌) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyBattleState.__PropertyOffset_取消无敌) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004EC6 RID: 20166 RVA: 0x000B4388 File Offset: 0x000B2588
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

	// Token: 0x06004EC7 RID: 20167 RVA: 0x000B4428 File Offset: 0x000B2628
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			BaseTagComponent component = ((characterActorComponent != null) ? characterActorComponent.Entity : null).GetComponent<BaseTagComponent>();
			if (this.取消无敌 && component != null)
			{
				component.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["功能.逻辑状态标识.无敌.通用无敌"]));
			}
		}
		return true;
	}

	// Token: 0x06004EC8 RID: 20168 RVA: 0x000B4484 File Offset: 0x000B2684
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

	// Token: 0x06004EC9 RID: 20169 RVA: 0x000B44FF File Offset: 0x000B26FF
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "设置战斗状态";
	}

	// Token: 0x06004ECA RID: 20170 RVA: 0x000B4506 File Offset: 0x000B2706
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyBattleState._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBattleState.TsAnimNotifyBattleState_C");
		}
		return TsAnimNotifyBattleState._ClassPtr;
	}

	// Token: 0x06004ECB RID: 20171 RVA: 0x000B452C File Offset: 0x000B272C
	public TsAnimNotifyBattleState() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBattleState.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004ECC RID: 20172 RVA: 0x000B4554 File Offset: 0x000B2754
	[NullableContext(1)]
	public TsAnimNotifyBattleState(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBattleState.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004ECD RID: 20173 RVA: 0x000B4587 File Offset: 0x000B2787
	protected TsAnimNotifyBattleState(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004ECE RID: 20174 RVA: 0x000B4590 File Offset: 0x000B2790
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004ECF RID: 20175 RVA: 0x000B45C3 File Offset: 0x000B27C3
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040016E0 RID: 5856
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBattleState.TsAnimNotifyBattleState_C";

	// Token: 0x040016E1 RID: 5857
	private static IntPtr _ClassPtr;

	// Token: 0x040016E2 RID: 5858
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040016E3 RID: 5859
	private static int __PropertyOffset_取消无敌;
}
