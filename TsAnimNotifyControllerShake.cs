using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Module.Gamepad;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DC0 RID: 3520
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyControllerShake.TsAnimNotifyControllerShake_C")]
public class TsAnimNotifyControllerShake : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000515 RID: 1301
	// (get) Token: 0x06004FE4 RID: 20452 RVA: 0x000B7DC3 File Offset: 0x000B5FC3
	// (set) Token: 0x06004FE5 RID: 20453 RVA: 0x000B7DD7 File Offset: 0x000B5FD7
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UKuroForceFeedbackEffect Effect
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UKuroForceFeedbackEffect>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyControllerShake.__PropertyOffset_Effect);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyControllerShake.__PropertyOffset_Effect, value);
		}
	}

	// Token: 0x17000516 RID: 1302
	// (get) Token: 0x06004FE6 RID: 20454 RVA: 0x000B7DEC File Offset: 0x000B5FEC
	// (set) Token: 0x06004FE7 RID: 20455 RVA: 0x000B7E00 File Offset: 0x000B6000
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName Name
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyControllerShake.__PropertyOffset_Name);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyControllerShake.__PropertyOffset_Name) = value;
		}
	}

	// Token: 0x17000517 RID: 1303
	// (get) Token: 0x06004FE8 RID: 20456 RVA: 0x000B7E15 File Offset: 0x000B6015
	// (set) Token: 0x06004FE9 RID: 20457 RVA: 0x000B7E25 File Offset: 0x000B6025
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsLooping
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyControllerShake.__PropertyOffset_IsLooping) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyControllerShake.__PropertyOffset_IsLooping) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000518 RID: 1304
	// (get) Token: 0x06004FEA RID: 20458 RVA: 0x000B7E36 File Offset: 0x000B6036
	// (set) Token: 0x06004FEB RID: 20459 RVA: 0x000B7E46 File Offset: 0x000B6046
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsIgnoreTimeDilation
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyControllerShake.__PropertyOffset_IsIgnoreTimeDilation) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyControllerShake.__PropertyOffset_IsIgnoreTimeDilation) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000519 RID: 1305
	// (get) Token: 0x06004FEC RID: 20460 RVA: 0x000B7E57 File Offset: 0x000B6057
	// (set) Token: 0x06004FED RID: 20461 RVA: 0x000B7E67 File Offset: 0x000B6067
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsPlayWhilePaused
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyControllerShake.__PropertyOffset_IsPlayWhilePaused) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyControllerShake.__PropertyOffset_IsPlayWhilePaused) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004FEE RID: 20462 RVA: 0x000B7E78 File Offset: 0x000B6078
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

	// Token: 0x06004FEF RID: 20463 RVA: 0x000B7F18 File Offset: 0x000B6118
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (!Singleton<Info>.Instance.IsInGamepad())
		{
			return true;
		}
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			if (characterActorComponent != null && characterActorComponent.IsAutonomousProxy && Global.CharacterController != null)
			{
				EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(tsBaseCharacter.GetEntityIdNoBlueprint());
				if (entityById == null || !entityById.Valid)
				{
					return false;
				}
				if (!CharacterUtils.CanCharacterMonsterOrSummonedDisplayEffect(entityById))
				{
					return false;
				}
				ControllerBase<GamepadController>.Instance.PlayKuroForceFeedback(this.Effect, new FName?(this.Name), this.IsLooping, this.IsIgnoreTimeDilation, this.IsPlayWhilePaused, "TsAnimNotifyControllerShake");
			}
		}
		return true;
	}

	// Token: 0x06004FF0 RID: 20464 RVA: 0x000B7FC0 File Offset: 0x000B61C0
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

	// Token: 0x06004FF1 RID: 20465 RVA: 0x000B803B File Offset: 0x000B623B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "手柄震动";
	}

	// Token: 0x06004FF2 RID: 20466 RVA: 0x000B8042 File Offset: 0x000B6242
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyControllerShake._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyControllerShake.TsAnimNotifyControllerShake_C");
		}
		return TsAnimNotifyControllerShake._ClassPtr;
	}

	// Token: 0x06004FF3 RID: 20467 RVA: 0x000B8068 File Offset: 0x000B6268
	public TsAnimNotifyControllerShake() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyControllerShake.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004FF4 RID: 20468 RVA: 0x000B8090 File Offset: 0x000B6290
	[NullableContext(1)]
	public TsAnimNotifyControllerShake(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyControllerShake.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004FF5 RID: 20469 RVA: 0x000B80C3 File Offset: 0x000B62C3
	protected TsAnimNotifyControllerShake(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004FF6 RID: 20470 RVA: 0x000B80CC File Offset: 0x000B62CC
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004FF7 RID: 20471 RVA: 0x000B80FF File Offset: 0x000B62FF
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001750 RID: 5968
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyControllerShake.TsAnimNotifyControllerShake_C";

	// Token: 0x04001751 RID: 5969
	private static IntPtr _ClassPtr;

	// Token: 0x04001752 RID: 5970
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001753 RID: 5971
	private static int __PropertyOffset_Effect;

	// Token: 0x04001754 RID: 5972
	private static int __PropertyOffset_Name;

	// Token: 0x04001755 RID: 5973
	private static int __PropertyOffset_IsLooping;

	// Token: 0x04001756 RID: 5974
	private static int __PropertyOffset_IsIgnoreTimeDilation;

	// Token: 0x04001757 RID: 5975
	private static int __PropertyOffset_IsPlayWhilePaused;
}
