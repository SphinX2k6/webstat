using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DAC RID: 3500
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBonesShowControl.TsAnimNotifyBonesShowControl_C")]
public class TsAnimNotifyBonesShowControl : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004ED RID: 1261
	// (get) Token: 0x06004ED0 RID: 20176 RVA: 0x000B45D7 File Offset: 0x000B27D7
	// (set) Token: 0x06004ED1 RID: 20177 RVA: 0x000B45EB File Offset: 0x000B27EB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName BoneName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyBonesShowControl.__PropertyOffset_BoneName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyBonesShowControl.__PropertyOffset_BoneName) = value;
		}
	}

	// Token: 0x170004EE RID: 1262
	// (get) Token: 0x06004ED2 RID: 20178 RVA: 0x000B4600 File Offset: 0x000B2800
	// (set) Token: 0x06004ED3 RID: 20179 RVA: 0x000B4610 File Offset: 0x000B2810
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Show
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyBonesShowControl.__PropertyOffset_Show) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyBonesShowControl.__PropertyOffset_Show) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004ED4 RID: 20180 RVA: 0x000B4624 File Offset: 0x000B2824
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

	// Token: 0x06004ED5 RID: 20181 RVA: 0x000B46C3 File Offset: 0x000B28C3
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (meshComp.IsBoneHiddenByName(this.BoneName) == this.Show)
		{
			if (this.Show)
			{
				meshComp.UnHideBoneByName(this.BoneName);
			}
			else
			{
				meshComp.HideBoneByName(this.BoneName, EPhysBodyOp.PBO_None);
			}
		}
		return true;
	}

	// Token: 0x06004ED6 RID: 20182 RVA: 0x000B4700 File Offset: 0x000B2900
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

	// Token: 0x06004ED7 RID: 20183 RVA: 0x000B477B File Offset: 0x000B297B
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "控制骨骼显隐";
	}

	// Token: 0x06004ED8 RID: 20184 RVA: 0x000B4782 File Offset: 0x000B2982
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyBonesShowControl._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBonesShowControl.TsAnimNotifyBonesShowControl_C");
		}
		return TsAnimNotifyBonesShowControl._ClassPtr;
	}

	// Token: 0x06004ED9 RID: 20185 RVA: 0x000B47A8 File Offset: 0x000B29A8
	public TsAnimNotifyBonesShowControl() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBonesShowControl.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004EDA RID: 20186 RVA: 0x000B47D0 File Offset: 0x000B29D0
	[NullableContext(1)]
	public TsAnimNotifyBonesShowControl(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBonesShowControl.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004EDB RID: 20187 RVA: 0x000B4803 File Offset: 0x000B2A03
	protected TsAnimNotifyBonesShowControl(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004EDC RID: 20188 RVA: 0x000B480C File Offset: 0x000B2A0C
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004EDD RID: 20189 RVA: 0x000B483F File Offset: 0x000B2A3F
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040016E4 RID: 5860
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyBonesShowControl.TsAnimNotifyBonesShowControl_C";

	// Token: 0x040016E5 RID: 5861
	private static IntPtr _ClassPtr;

	// Token: 0x040016E6 RID: 5862
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040016E7 RID: 5863
	private static int __PropertyOffset_BoneName;

	// Token: 0x040016E8 RID: 5864
	private static int __PropertyOffset_Show;
}
