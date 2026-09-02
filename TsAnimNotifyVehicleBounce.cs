using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Vehicle.Common;
using Cysharp.Threading.Tasks;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DF6 RID: 3574
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyVehicleBounce.TsAnimNotifyVehicleBounce_C")]
public class TsAnimNotifyVehicleBounce : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700058F RID: 1423
	// (get) Token: 0x060052EA RID: 21226 RVA: 0x000C271B File Offset: 0x000C091B
	// (set) Token: 0x060052EB RID: 21227 RVA: 0x000C272B File Offset: 0x000C092B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Time
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyVehicleBounce.__PropertyOffset_Time);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyVehicleBounce.__PropertyOffset_Time) = value;
		}
	}

	// Token: 0x17000590 RID: 1424
	// (get) Token: 0x060052EC RID: 21228 RVA: 0x000C273C File Offset: 0x000C093C
	// (set) Token: 0x060052ED RID: 21229 RVA: 0x000C274C File Offset: 0x000C094C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Height
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyVehicleBounce.__PropertyOffset_Height);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyVehicleBounce.__PropertyOffset_Height) = value;
		}
	}

	// Token: 0x17000591 RID: 1425
	// (get) Token: 0x060052EE RID: 21230 RVA: 0x000C275D File Offset: 0x000C095D
	// (set) Token: 0x060052EF RID: 21231 RVA: 0x000C276D File Offset: 0x000C096D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseLocalUp
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyVehicleBounce.__PropertyOffset_UseLocalUp) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyVehicleBounce.__PropertyOffset_UseLocalUp) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000592 RID: 1426
	// (get) Token: 0x060052F0 RID: 21232 RVA: 0x000C277E File Offset: 0x000C097E
	// (set) Token: 0x060052F1 RID: 21233 RVA: 0x000C278E File Offset: 0x000C098E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool NotClearDownVelocity
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyVehicleBounce.__PropertyOffset_NotClearDownVelocity) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyVehicleBounce.__PropertyOffset_NotClearDownVelocity) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000593 RID: 1427
	// (get) Token: 0x060052F2 RID: 21234 RVA: 0x000C27A0 File Offset: 0x000C09A0
	// (set) Token: 0x060052F3 RID: 21235 RVA: 0x000C27D9 File Offset: 0x000C09D9
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UCurveFloat> MotionCurve
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UCurveFloat> result;
			if ((result = this._MotionCurve) == null)
			{
				result = (this._MotionCurve = new TSoftObjectPtr<UCurveFloat>(base.NativePtr + (IntPtr)TsAnimNotifyVehicleBounce.__PropertyOffset_MotionCurve, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsAnimNotifyVehicleBounce.__PropertyOffset_MotionCurve, 1);
		}
	}

	// Token: 0x060052F4 RID: 21236 RVA: 0x000C2800 File Offset: 0x000C0A00
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

	// Token: 0x060052F5 RID: 21237 RVA: 0x000C28A0 File Offset: 0x000C0AA0
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseVehicle))
		{
			return false;
		}
		Entity entityNoBlueprint = (owner as TsBaseVehicle).GetEntityNoBlueprint();
		VehicleActionComponent vehicleActionComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<VehicleActionComponent>() : null;
		if (vehicleActionComponent == null)
		{
			return false;
		}
		VehicleActionComponent vehicleActionComponent2 = vehicleActionComponent;
		BounceParam bounceParam = new BounceParam();
		bounceParam.Time = new float?(this.Time);
		bounceParam.Height = new float?(this.Height);
		TSoftObjectPtr<UCurveFloat> motionCurve = this.MotionCurve;
		bounceParam.CurvePath = (((motionCurve != null) ? motionCurve.ToAssetPathName() : null) ?? "");
		bounceParam.UseLocalUp = new bool?(this.UseLocalUp);
		bounceParam.NotClearDownVelocity = new bool?(this.NotClearDownVelocity);
		vehicleActionComponent2.StartBounce(bounceParam).Forget<bool>();
		return true;
	}

	// Token: 0x060052F6 RID: 21238 RVA: 0x000C2954 File Offset: 0x000C0B54
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

	// Token: 0x060052F7 RID: 21239 RVA: 0x000C29CF File Offset: 0x000C0BCF
	protected override string GetNotifyName_Implementation()
	{
		return "载具弹射运动";
	}

	// Token: 0x060052F8 RID: 21240 RVA: 0x000C29D6 File Offset: 0x000C0BD6
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyVehicleBounce._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyVehicleBounce.TsAnimNotifyVehicleBounce_C");
		}
		return TsAnimNotifyVehicleBounce._ClassPtr;
	}

	// Token: 0x060052F9 RID: 21241 RVA: 0x000C29FC File Offset: 0x000C0BFC
	public TsAnimNotifyVehicleBounce() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyVehicleBounce.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060052FA RID: 21242 RVA: 0x000C2A24 File Offset: 0x000C0C24
	public TsAnimNotifyVehicleBounce(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyVehicleBounce.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060052FB RID: 21243 RVA: 0x000C2A57 File Offset: 0x000C0C57
	protected TsAnimNotifyVehicleBounce(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060052FC RID: 21244 RVA: 0x000C2A60 File Offset: 0x000C0C60
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060052FD RID: 21245 RVA: 0x000C2A93 File Offset: 0x000C0C93
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001882 RID: 6274
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyVehicleBounce.TsAnimNotifyVehicleBounce_C";

	// Token: 0x04001883 RID: 6275
	private static IntPtr _ClassPtr;

	// Token: 0x04001884 RID: 6276
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001885 RID: 6277
	private static int __PropertyOffset_Time;

	// Token: 0x04001886 RID: 6278
	private static int __PropertyOffset_Height;

	// Token: 0x04001887 RID: 6279
	private static int __PropertyOffset_UseLocalUp;

	// Token: 0x04001888 RID: 6280
	private static int __PropertyOffset_NotClearDownVelocity;

	// Token: 0x04001889 RID: 6281
	private static int __PropertyOffset_MotionCurve;

	// Token: 0x0400188A RID: 6282
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UCurveFloat> _MotionCurve;
}
