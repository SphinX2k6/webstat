using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DAD RID: 3501
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBounce.TsAnimNotifyBounce_C")]
public class TsAnimNotifyBounce : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004EF RID: 1263
	// (get) Token: 0x06004EDE RID: 20190 RVA: 0x000B4853 File Offset: 0x000B2A53
	// (set) Token: 0x06004EDF RID: 20191 RVA: 0x000B4863 File Offset: 0x000B2A63
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Time
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyBounce.__PropertyOffset_Time);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyBounce.__PropertyOffset_Time) = value;
		}
	}

	// Token: 0x170004F0 RID: 1264
	// (get) Token: 0x06004EE0 RID: 20192 RVA: 0x000B4874 File Offset: 0x000B2A74
	// (set) Token: 0x06004EE1 RID: 20193 RVA: 0x000B4884 File Offset: 0x000B2A84
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Height
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyBounce.__PropertyOffset_Height);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyBounce.__PropertyOffset_Height) = value;
		}
	}

	// Token: 0x170004F1 RID: 1265
	// (get) Token: 0x06004EE2 RID: 20194 RVA: 0x000B4898 File Offset: 0x000B2A98
	// (set) Token: 0x06004EE3 RID: 20195 RVA: 0x000B48D1 File Offset: 0x000B2AD1
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UCurveFloat> MotionCurve
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UCurveFloat> result;
			if ((result = this._MotionCurve) == null)
			{
				result = (this._MotionCurve = new TSoftObjectPtr<UCurveFloat>(base.NativePtr + (IntPtr)TsAnimNotifyBounce.__PropertyOffset_MotionCurve, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsAnimNotifyBounce.__PropertyOffset_MotionCurve, 1);
		}
	}

	// Token: 0x06004EE4 RID: 20196 RVA: 0x000B48F8 File Offset: 0x000B2AF8
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

	// Token: 0x06004EE5 RID: 20197 RVA: 0x000B4998 File Offset: 0x000B2B98
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return true;
		}
		CharacterActorComponent characterActorComponent = (owner as TsBaseCharacter).CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		CharacterActionComponent characterActionComponent = (entity != null) ? entity.GetComponent<CharacterActionComponent>() : null;
		CharacterCatapultComponent characterCatapultComponent = (entity != null) ? entity.GetComponent<CharacterCatapultComponent>() : null;
		if (characterActionComponent == null || characterCatapultComponent == null)
		{
			return true;
		}
		TSoftObjectPtr<UCurveFloat> motionCurve = this.MotionCurve;
		string curvePath = ((motionCurve != null) ? motionCurve.ToAssetPathName() : null) ?? "";
		characterActionComponent.StartBounceFromAns(this.Time, this.Height, curvePath);
		characterCatapultComponent.StartCatapult();
		return true;
	}

	// Token: 0x06004EE6 RID: 20198 RVA: 0x000B4A28 File Offset: 0x000B2C28
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

	// Token: 0x06004EE7 RID: 20199 RVA: 0x000B4AA3 File Offset: 0x000B2CA3
	protected override string GetNotifyName_Implementation()
	{
		return "弹射运动";
	}

	// Token: 0x06004EE8 RID: 20200 RVA: 0x000B4AAA File Offset: 0x000B2CAA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyBounce._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBounce.TsAnimNotifyBounce_C");
		}
		return TsAnimNotifyBounce._ClassPtr;
	}

	// Token: 0x06004EE9 RID: 20201 RVA: 0x000B4AD0 File Offset: 0x000B2CD0
	public TsAnimNotifyBounce() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBounce.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004EEA RID: 20202 RVA: 0x000B4AF8 File Offset: 0x000B2CF8
	public TsAnimNotifyBounce(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBounce.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004EEB RID: 20203 RVA: 0x000B4B2B File Offset: 0x000B2D2B
	protected TsAnimNotifyBounce(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004EEC RID: 20204 RVA: 0x000B4B34 File Offset: 0x000B2D34
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004EED RID: 20205 RVA: 0x000B4B67 File Offset: 0x000B2D67
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040016E9 RID: 5865
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBounce.TsAnimNotifyBounce_C";

	// Token: 0x040016EA RID: 5866
	private static IntPtr _ClassPtr;

	// Token: 0x040016EB RID: 5867
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040016EC RID: 5868
	private static int __PropertyOffset_Time;

	// Token: 0x040016ED RID: 5869
	private static int __PropertyOffset_Height;

	// Token: 0x040016EE RID: 5870
	private static int __PropertyOffset_MotionCurve;

	// Token: 0x040016EF RID: 5871
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UCurveFloat> _MotionCurve;
}
