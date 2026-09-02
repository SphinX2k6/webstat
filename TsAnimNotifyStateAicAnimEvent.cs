using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.AI.AIFunctionCommon;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D21 RID: 3361
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAicAnimEvent.TsAnimNotifyStateAicAnimEvent_C")]
public class TsAnimNotifyStateAicAnimEvent : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700033D RID: 829
	// (get) Token: 0x060044A5 RID: 17573 RVA: 0x00086B4B File Offset: 0x00084D4B
	// (set) Token: 0x060044A6 RID: 17574 RVA: 0x00086B5B File Offset: 0x00084D5B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool bCallBegin
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAicAnimEvent.__PropertyOffset_bCallBegin) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAicAnimEvent.__PropertyOffset_bCallBegin) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700033E RID: 830
	// (get) Token: 0x060044A7 RID: 17575 RVA: 0x00086B6C File Offset: 0x00084D6C
	// (set) Token: 0x060044A8 RID: 17576 RVA: 0x00086B7C File Offset: 0x00084D7C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool bCallEnd
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAicAnimEvent.__PropertyOffset_bCallEnd) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAicAnimEvent.__PropertyOffset_bCallEnd) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700033F RID: 831
	// (get) Token: 0x060044A9 RID: 17577 RVA: 0x00086B8D File Offset: 0x00084D8D
	// (set) Token: 0x060044AA RID: 17578 RVA: 0x00086BA1 File Offset: 0x00084DA1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName Name
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateAicAnimEvent.__PropertyOffset_Name);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateAicAnimEvent.__PropertyOffset_Name) = value;
		}
	}

	// Token: 0x060044AB RID: 17579 RVA: 0x00086BB8 File Offset: 0x00084DB8
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

	// Token: 0x060044AC RID: 17580 RVA: 0x00086C60 File Offset: 0x00084E60
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (this.bCallBegin && owner is TsBaseCharacter)
		{
			AController controller = (owner as TsBaseCharacter).GetController();
			if (controller is AIC_AICommon_C)
			{
				(controller as AIC_AICommon_C).AicTriggerEvent(this.Name);
			}
		}
		return true;
	}

	// Token: 0x060044AD RID: 17581 RVA: 0x00086CAC File Offset: 0x00084EAC
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

	// Token: 0x060044AE RID: 17582 RVA: 0x00086D4C File Offset: 0x00084F4C
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (this.bCallEnd && owner is TsBaseCharacter)
		{
			AController controller = (owner as TsBaseCharacter).GetController();
			if (controller is AIC_AICommon_C)
			{
				(controller as AIC_AICommon_C).AicTriggerEvent(this.Name);
			}
		}
		return true;
	}

	// Token: 0x060044AF RID: 17583 RVA: 0x00086D98 File Offset: 0x00084F98
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

	// Token: 0x060044B0 RID: 17584 RVA: 0x00086E13 File Offset: 0x00085013
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "AIC动画通知事件";
	}

	// Token: 0x060044B1 RID: 17585 RVA: 0x00086E1A File Offset: 0x0008501A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateAicAnimEvent._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAicAnimEvent.TsAnimNotifyStateAicAnimEvent_C");
		}
		return TsAnimNotifyStateAicAnimEvent._ClassPtr;
	}

	// Token: 0x060044B2 RID: 17586 RVA: 0x00086E40 File Offset: 0x00085040
	public TsAnimNotifyStateAicAnimEvent() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAicAnimEvent.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060044B3 RID: 17587 RVA: 0x00086E68 File Offset: 0x00085068
	[NullableContext(1)]
	public TsAnimNotifyStateAicAnimEvent(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateAicAnimEvent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060044B4 RID: 17588 RVA: 0x00086E9B File Offset: 0x0008509B
	protected TsAnimNotifyStateAicAnimEvent(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060044B5 RID: 17589 RVA: 0x00086EA4 File Offset: 0x000850A4
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x060044B6 RID: 17590 RVA: 0x00086EE0 File Offset: 0x000850E0
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060044B7 RID: 17591 RVA: 0x00086F13 File Offset: 0x00085113
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001234 RID: 4660
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateAicAnimEvent.TsAnimNotifyStateAicAnimEvent_C";

	// Token: 0x04001235 RID: 4661
	private static IntPtr _ClassPtr;

	// Token: 0x04001236 RID: 4662
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001237 RID: 4663
	private static int __PropertyOffset_bCallBegin;

	// Token: 0x04001238 RID: 4664
	private static int __PropertyOffset_bCallEnd;

	// Token: 0x04001239 RID: 4665
	private static int __PropertyOffset_Name;
}
