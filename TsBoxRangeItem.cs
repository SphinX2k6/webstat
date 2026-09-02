using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.SceneItem.Model;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200324E RID: 12878
[UClass("/Game/Aki/TypeScript/Game/NewWorld/SceneItem/RangeItem/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/SceneItem/RangeItem/TsBoxRangeItem.TsBoxRangeItem_C")]
public class TsBoxRangeItem : AKuroEffectActor, IUnrealUObject, IUnrealObject
{
	// Token: 0x17002462 RID: 9314
	// (get) Token: 0x0601ACF3 RID: 109811 RVA: 0x007FE073 File Offset: 0x007FC273
	// (set) Token: 0x0601ACF4 RID: 109812 RVA: 0x007FE087 File Offset: 0x007FC287
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string RangeId
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsBoxRangeItem.__PropertyOffset_RangeId)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsBoxRangeItem.__PropertyOffset_RangeId)), value);
		}
	}

	// Token: 0x17002463 RID: 9315
	// (get) Token: 0x0601ACF5 RID: 109813 RVA: 0x007FE09C File Offset: 0x007FC29C
	// (set) Token: 0x0601ACF6 RID: 109814 RVA: 0x007FE0B0 File Offset: 0x007FC2B0
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UBoxComponent BoxComp
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsBoxRangeItem.__PropertyOffset_BoxComp);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsBoxRangeItem.__PropertyOffset_BoxComp, value);
		}
	}

	// Token: 0x0601ACF7 RID: 109815 RVA: 0x007FE0C8 File Offset: 0x007FC2C8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveBeginPlay()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveBeginPlay"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601ACF8 RID: 109816 RVA: 0x007FE138 File Offset: 0x007FC338
	protected virtual void ReceiveBeginPlay_Implementation()
	{
		if (!string.IsNullOrEmpty(this.RangeId))
		{
			ModelBase<RangeItemModel>.Instance.AddBoxRange(this.RangeId, this);
			base.SetActorTickEnabled(false);
			return;
		}
		base.SetActorTickEnabled(true);
	}

	// Token: 0x0601ACF9 RID: 109817 RVA: 0x007FE168 File Offset: 0x007FC368
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTick(float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AActor.__ReceiveTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AActor.__ReceiveTick_FunctionParams*)ptr + 15L / (long)sizeof(AActor.__ReceiveTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601ACFA RID: 109818 RVA: 0x007FE1DE File Offset: 0x007FC3DE
	protected virtual void ReceiveTick_Implementation(float deltaSeconds)
	{
		if (!string.IsNullOrEmpty(this.RangeId))
		{
			ModelBase<RangeItemModel>.Instance.AddBoxRange(this.RangeId, this);
			base.SetActorTickEnabled(false);
		}
	}

	// Token: 0x0601ACFB RID: 109819 RVA: 0x007FE208 File Offset: 0x007FC408
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveEndPlay(EEndPlayReason endPlayReason)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveEndPlay"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AActor.__ReceiveEndPlay_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AActor.__ReceiveEndPlay_FunctionParams*)ptr + 15L / (long)sizeof(AActor.__ReceiveEndPlay_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(byte*)(&ptr2->EndPlayReason) = (byte)endPlayReason;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601ACFC RID: 109820 RVA: 0x007FE281 File Offset: 0x007FC481
	protected virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
	{
		if (!string.IsNullOrEmpty(this.RangeId))
		{
			ModelBase<RangeItemModel>.Instance.RemoveBoxRange(this.RangeId);
		}
	}

	// Token: 0x0601ACFD RID: 109821 RVA: 0x007FE2A0 File Offset: 0x007FC4A0
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsBoxRangeItem._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/SceneItem/RangeItem/TsBoxRangeItem.TsBoxRangeItem_C");
		}
		return TsBoxRangeItem._ClassPtr;
	}

	// Token: 0x0601ACFE RID: 109822 RVA: 0x007FE2C4 File Offset: 0x007FC4C4
	public TsBoxRangeItem() : this(BuiltinUtils.AllocNativeUObject(TsBoxRangeItem.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601ACFF RID: 109823 RVA: 0x007FE2EC File Offset: 0x007FC4EC
	[NullableContext(1)]
	public TsBoxRangeItem(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsBoxRangeItem.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601AD00 RID: 109824 RVA: 0x007FE31F File Offset: 0x007FC51F
	protected TsBoxRangeItem(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601AD01 RID: 109825 RVA: 0x007FE328 File Offset: 0x007FC528
	protected virtual void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		this.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601AD02 RID: 109826 RVA: 0x007FE330 File Offset: 0x007FC530
	protected unsafe virtual void __CPPCALL_ReceiveTick_Implementation(AActor.__ReceiveTick_FunctionParams* __Params)
	{
		this.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x0601AD03 RID: 109827 RVA: 0x007FE340 File Offset: 0x007FC540
	protected unsafe virtual void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		this.ReceiveEndPlay_Implementation(endPlayReason);
	}

	// Token: 0x0400D975 RID: 55669
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/SceneItem/RangeItem/TsBoxRangeItem.TsBoxRangeItem_C";

	// Token: 0x0400D976 RID: 55670
	private static IntPtr _ClassPtr;

	// Token: 0x0400D977 RID: 55671
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400D978 RID: 55672
	private static int __PropertyOffset_RangeId;

	// Token: 0x0400D979 RID: 55673
	private static int __PropertyOffset_BoxComp;
}
