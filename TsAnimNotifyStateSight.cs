using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D87 RID: 3463
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSight.TsAnimNotifyStateSight_C")]
public class TsAnimNotifyStateSight : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700048A RID: 1162
	// (get) Token: 0x06004C4D RID: 19533 RVA: 0x000AA093 File Offset: 0x000A8293
	// (set) Token: 0x06004C4E RID: 19534 RVA: 0x000AA0A7 File Offset: 0x000A82A7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector2D 距离区间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSight.__PropertyOffset_距离区间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSight.__PropertyOffset_距离区间) = value;
		}
	}

	// Token: 0x1700048B RID: 1163
	// (get) Token: 0x06004C4F RID: 19535 RVA: 0x000AA0BC File Offset: 0x000A82BC
	// (set) Token: 0x06004C50 RID: 19536 RVA: 0x000AA0D0 File Offset: 0x000A82D0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector2D 水平区间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSight.__PropertyOffset_水平区间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSight.__PropertyOffset_水平区间) = value;
		}
	}

	// Token: 0x1700048C RID: 1164
	// (get) Token: 0x06004C51 RID: 19537 RVA: 0x000AA0E5 File Offset: 0x000A82E5
	// (set) Token: 0x06004C52 RID: 19538 RVA: 0x000AA0F9 File Offset: 0x000A82F9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector2D 垂直区间
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSight.__PropertyOffset_垂直区间);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSight.__PropertyOffset_垂直区间) = value;
		}
	}

	// Token: 0x06004C53 RID: 19539 RVA: 0x000AA110 File Offset: 0x000A8310
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

	// Token: 0x06004C54 RID: 19540 RVA: 0x000AA1B8 File Offset: 0x000A83B8
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		CharacterAnimationComponent characterAnimationComponent = (characterActorComponent != null) ? characterActorComponent.Entity.GetComponent<CharacterAnimationComponent>() : null;
		if (characterAnimationComponent == null)
		{
			return false;
		}
		if (characterAnimationComponent.GetSightCameraData() == null)
		{
			characterAnimationComponent.SetSightCameraData(new SightCameraData
			{
				SightMinDistance = this.距离区间.X,
				SightMaxDistance = this.距离区间.Y,
				SightHorizontalAngleL = (float)Singleton<MathUtils>.Instance.NormalizeDeg180((double)this.水平区间.X),
				SightHorizontalAngleR = (float)Singleton<MathUtils>.Instance.NormalizeDeg180((double)this.水平区间.Y),
				SightVerticalAngleB = (float)Singleton<MathUtils>.Instance.NormalizeDeg180((double)this.垂直区间.X),
				SightVerticalAngleT = (float)Singleton<MathUtils>.Instance.NormalizeDeg180((double)this.垂直区间.Y)
			});
			this.EnableSight = true;
		}
		return true;
	}

	// Token: 0x06004C55 RID: 19541 RVA: 0x000AA2B0 File Offset: 0x000A84B0
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

	// Token: 0x06004C56 RID: 19542 RVA: 0x000AA350 File Offset: 0x000A8550
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		CharacterAnimationComponent characterAnimationComponent = (characterActorComponent != null) ? characterActorComponent.Entity.GetComponent<CharacterAnimationComponent>() : null;
		if (characterAnimationComponent == null)
		{
			return false;
		}
		if (this.EnableSight)
		{
			characterAnimationComponent.SetSightCameraData(null);
			this.EnableSight = false;
		}
		return true;
	}

	// Token: 0x06004C57 RID: 19543 RVA: 0x000AA3A7 File Offset: 0x000A85A7
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateSight._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSight.TsAnimNotifyStateSight_C");
		}
		return TsAnimNotifyStateSight._ClassPtr;
	}

	// Token: 0x06004C58 RID: 19544 RVA: 0x000AA3CC File Offset: 0x000A85CC
	public TsAnimNotifyStateSight() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSight.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004C59 RID: 19545 RVA: 0x000AA3F4 File Offset: 0x000A85F4
	[NullableContext(1)]
	public TsAnimNotifyStateSight(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSight.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004C5A RID: 19546 RVA: 0x000AA427 File Offset: 0x000A8627
	protected TsAnimNotifyStateSight(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004C5B RID: 19547 RVA: 0x000AA430 File Offset: 0x000A8630
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004C5C RID: 19548 RVA: 0x000AA46C File Offset: 0x000A866C
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040015D9 RID: 5593
	private bool EnableSight;

	// Token: 0x040015DA RID: 5594
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSight.TsAnimNotifyStateSight_C";

	// Token: 0x040015DB RID: 5595
	private static IntPtr _ClassPtr;

	// Token: 0x040015DC RID: 5596
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040015DD RID: 5597
	private static int __PropertyOffset_距离区间;

	// Token: 0x040015DE RID: 5598
	private static int __PropertyOffset_水平区间;

	// Token: 0x040015DF RID: 5599
	private static int __PropertyOffset_垂直区间;
}
