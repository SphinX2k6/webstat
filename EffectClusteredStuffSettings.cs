using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200340A RID: 13322
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/ClusteredStuff/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/ClusteredStuff/EffectClusteredStuffSettings.EffectClusteredStuffSettings_C")]
public class EffectClusteredStuffSettings : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
{
	// Token: 0x170025A9 RID: 9641
	// (get) Token: 0x0601BD19 RID: 113945 RVA: 0x0084C9F4 File Offset: 0x0084ABF4
	// (set) Token: 0x0601BD1A RID: 113946 RVA: 0x0084CA2D File Offset: 0x0084AC2D
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UEffectModelBase> EffectDataRef
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UEffectModelBase> result;
			if ((result = this._EffectDataRef) == null)
			{
				result = (this._EffectDataRef = new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)EffectClusteredStuffSettings.__PropertyOffset_EffectDataRef, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)EffectClusteredStuffSettings.__PropertyOffset_EffectDataRef, 1);
		}
	}

	// Token: 0x170025AA RID: 9642
	// (get) Token: 0x0601BD1B RID: 113947 RVA: 0x0084CA52 File Offset: 0x0084AC52
	// (set) Token: 0x0601BD1C RID: 113948 RVA: 0x0084CA62 File Offset: 0x0084AC62
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float DensityChangeSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)EffectClusteredStuffSettings.__PropertyOffset_DensityChangeSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)EffectClusteredStuffSettings.__PropertyOffset_DensityChangeSpeed) = value;
		}
	}

	// Token: 0x170025AB RID: 9643
	// (get) Token: 0x0601BD1D RID: 113949 RVA: 0x0084CA73 File Offset: 0x0084AC73
	// (set) Token: 0x0601BD1E RID: 113950 RVA: 0x0084CA83 File Offset: 0x0084AC83
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool AttachToActor
	{
		get
		{
			return *(base.NativePtr + (IntPtr)EffectClusteredStuffSettings.__PropertyOffset_AttachToActor) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)EffectClusteredStuffSettings.__PropertyOffset_AttachToActor) = (value ? 1 : 0);
		}
	}

	// Token: 0x170025AC RID: 9644
	// (get) Token: 0x0601BD1F RID: 113951 RVA: 0x0084CA94 File Offset: 0x0084AC94
	// (set) Token: 0x0601BD20 RID: 113952 RVA: 0x0084CAA8 File Offset: 0x0084ACA8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector AbsoluteWorldPosition
	{
		get
		{
			return *(base.NativePtr + (IntPtr)EffectClusteredStuffSettings.__PropertyOffset_AbsoluteWorldPosition);
		}
		set
		{
			*(base.NativePtr + (IntPtr)EffectClusteredStuffSettings.__PropertyOffset_AbsoluteWorldPosition) = value;
		}
	}

	// Token: 0x0601BD21 RID: 113953 RVA: 0x0084CABD File Offset: 0x0084ACBD
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectClusteredStuffSettings._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/ClusteredStuff/EffectClusteredStuffSettings.EffectClusteredStuffSettings_C");
		}
		return EffectClusteredStuffSettings._ClassPtr;
	}

	// Token: 0x0601BD22 RID: 113954 RVA: 0x0084CAE4 File Offset: 0x0084ACE4
	public EffectClusteredStuffSettings() : this(BuiltinUtils.AllocNativeUObject(EffectClusteredStuffSettings.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BD23 RID: 113955 RVA: 0x0084CB0C File Offset: 0x0084AD0C
	public EffectClusteredStuffSettings(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectClusteredStuffSettings.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BD24 RID: 113956 RVA: 0x0084CB3F File Offset: 0x0084AD3F
	protected EffectClusteredStuffSettings(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400E09E RID: 57502
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/ClusteredStuff/EffectClusteredStuffSettings.EffectClusteredStuffSettings_C";

	// Token: 0x0400E09F RID: 57503
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0A0 RID: 57504
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E0A1 RID: 57505
	private static int __PropertyOffset_EffectDataRef;

	// Token: 0x0400E0A2 RID: 57506
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UEffectModelBase> _EffectDataRef;

	// Token: 0x0400E0A3 RID: 57507
	private static int __PropertyOffset_DensityChangeSpeed;

	// Token: 0x0400E0A4 RID: 57508
	private static int __PropertyOffset_AttachToActor;

	// Token: 0x0400E0A5 RID: 57509
	private static int __PropertyOffset_AbsoluteWorldPosition;
}
