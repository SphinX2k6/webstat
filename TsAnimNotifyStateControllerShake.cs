using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Module.Gamepad;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D38 RID: 3384
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateControllerShake.TsAnimNotifyStateControllerShake_C")]
public class TsAnimNotifyStateControllerShake : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700038B RID: 907
	// (get) Token: 0x06004677 RID: 18039 RVA: 0x0008E8EF File Offset: 0x0008CAEF
	// (set) Token: 0x06004678 RID: 18040 RVA: 0x0008E903 File Offset: 0x0008CB03
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UKuroForceFeedbackEffect Effect
	{
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UKuroForceFeedbackEffect>(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateControllerShake.__PropertyOffset_Effect);
		}
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAnimNotifyStateControllerShake.__PropertyOffset_Effect, value);
		}
	}

	// Token: 0x1700038C RID: 908
	// (get) Token: 0x06004679 RID: 18041 RVA: 0x0008E918 File Offset: 0x0008CB18
	// (set) Token: 0x0600467A RID: 18042 RVA: 0x0008E92C File Offset: 0x0008CB2C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName Name
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateControllerShake.__PropertyOffset_Name);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateControllerShake.__PropertyOffset_Name) = value;
		}
	}

	// Token: 0x1700038D RID: 909
	// (get) Token: 0x0600467B RID: 18043 RVA: 0x0008E941 File Offset: 0x0008CB41
	// (set) Token: 0x0600467C RID: 18044 RVA: 0x0008E951 File Offset: 0x0008CB51
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsLooping
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateControllerShake.__PropertyOffset_IsLooping) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateControllerShake.__PropertyOffset_IsLooping) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700038E RID: 910
	// (get) Token: 0x0600467D RID: 18045 RVA: 0x0008E962 File Offset: 0x0008CB62
	// (set) Token: 0x0600467E RID: 18046 RVA: 0x0008E972 File Offset: 0x0008CB72
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsIgnoreTimeDilation
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateControllerShake.__PropertyOffset_IsIgnoreTimeDilation) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateControllerShake.__PropertyOffset_IsIgnoreTimeDilation) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700038F RID: 911
	// (get) Token: 0x0600467F RID: 18047 RVA: 0x0008E983 File Offset: 0x0008CB83
	// (set) Token: 0x06004680 RID: 18048 RVA: 0x0008E993 File Offset: 0x0008CB93
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsPlayWhilePaused
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateControllerShake.__PropertyOffset_IsPlayWhilePaused) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateControllerShake.__PropertyOffset_IsPlayWhilePaused) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004681 RID: 18049 RVA: 0x0008E9A4 File Offset: 0x0008CBA4
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

	// Token: 0x06004682 RID: 18050 RVA: 0x0008EA4C File Offset: 0x0008CC4C
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (!Singleton<Info>.Instance.IsInGamepad())
		{
			return true;
		}
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
			if (characterActorComponent != null && characterActorComponent.IsAutonomousProxy && Global.CharacterController != null)
			{
				EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById((owner as TsBaseCharacter).GetEntityIdNoBlueprint());
				if (entityById == null || !entityById.Valid)
				{
					return false;
				}
				if (!CharacterUtils.CanCharacterMonsterOrSummonedDisplayEffect(entityById))
				{
					return false;
				}
				ControllerBase<GamepadController>.Instance.PlayKuroForceFeedback(this.Effect, new FName?(this.Name), this.IsLooping, this.IsIgnoreTimeDilation, this.IsPlayWhilePaused, "TsAnimNotifyStateControllerShake");
				if (this.ActiveSet == null)
				{
					this.ActiveSet = new HashSet<USkeletalMeshComponent>();
				}
				this.ActiveSet.Add(meshComp);
			}
		}
		return true;
	}

	// Token: 0x06004683 RID: 18051 RVA: 0x0008EB28 File Offset: 0x0008CD28
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

	// Token: 0x06004684 RID: 18052 RVA: 0x0008EBC7 File Offset: 0x0008CDC7
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (this.ActiveSet.Remove(meshComp))
		{
			GamepadController.StopKuroForceFeedback(this.Effect, this.Name);
		}
		return true;
	}

	// Token: 0x06004685 RID: 18053 RVA: 0x0008EBEC File Offset: 0x0008CDEC
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

	// Token: 0x06004686 RID: 18054 RVA: 0x0008EC67 File Offset: 0x0008CE67
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "手柄震动";
	}

	// Token: 0x06004687 RID: 18055 RVA: 0x0008EC6E File Offset: 0x0008CE6E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateControllerShake._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateControllerShake.TsAnimNotifyStateControllerShake_C");
		}
		return TsAnimNotifyStateControllerShake._ClassPtr;
	}

	// Token: 0x06004688 RID: 18056 RVA: 0x0008EC94 File Offset: 0x0008CE94
	public TsAnimNotifyStateControllerShake() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateControllerShake.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004689 RID: 18057 RVA: 0x0008ECBC File Offset: 0x0008CEBC
	[NullableContext(1)]
	public TsAnimNotifyStateControllerShake(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateControllerShake.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600468A RID: 18058 RVA: 0x0008ECEF File Offset: 0x0008CEEF
	protected TsAnimNotifyStateControllerShake(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600468B RID: 18059 RVA: 0x0008ED04 File Offset: 0x0008CF04
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0600468C RID: 18060 RVA: 0x0008ED40 File Offset: 0x0008CF40
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600468D RID: 18061 RVA: 0x0008ED73 File Offset: 0x0008CF73
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400130C RID: 4876
	[Nullable(1)]
	private HashSet<USkeletalMeshComponent> ActiveSet = new HashSet<USkeletalMeshComponent>();

	// Token: 0x0400130D RID: 4877
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateControllerShake.TsAnimNotifyStateControllerShake_C";

	// Token: 0x0400130E RID: 4878
	private static IntPtr _ClassPtr;

	// Token: 0x0400130F RID: 4879
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001310 RID: 4880
	private static int __PropertyOffset_Effect;

	// Token: 0x04001311 RID: 4881
	private static int __PropertyOffset_Name;

	// Token: 0x04001312 RID: 4882
	private static int __PropertyOffset_IsLooping;

	// Token: 0x04001313 RID: 4883
	private static int __PropertyOffset_IsIgnoreTimeDilation;

	// Token: 0x04001314 RID: 4884
	private static int __PropertyOffset_IsPlayWhilePaused;
}
