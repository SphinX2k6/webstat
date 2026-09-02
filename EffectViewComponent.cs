using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003420 RID: 13344
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/EffectViewComponent.EffectViewComponent_C")]
public class EffectViewComponent : USceneComponent, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601BDA8 RID: 114088 RVA: 0x0084E0BC File Offset: 0x0084C2BC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void EditorTick(float deltaSecond)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("EditorTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		EffectViewComponent.__EditorTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((EffectViewComponent.__EditorTick_FunctionParams*)ptr + 15L / (long)sizeof(EffectViewComponent.__EditorTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->deltaSecond = deltaSecond;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BDA9 RID: 114089 RVA: 0x0084E132 File Offset: 0x0084C332
	protected void EditorTick_Implementation(float deltaSecond)
	{
	}

	// Token: 0x0601BDAA RID: 114090 RVA: 0x0084E134 File Offset: 0x0084C334
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetAutoPlay(bool autoPlay)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetAutoPlay"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		EffectViewComponent.__SetAutoPlay_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((EffectViewComponent.__SetAutoPlay_FunctionParams*)ptr + 15L / (long)sizeof(EffectViewComponent.__SetAutoPlay_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->autoPlay = autoPlay;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BDAB RID: 114091 RVA: 0x0084E1AA File Offset: 0x0084C3AA
	protected void SetAutoPlay_Implementation(bool autoPlay)
	{
	}

	// Token: 0x0601BDAC RID: 114092 RVA: 0x0084E1AC File Offset: 0x0084C3AC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void Play()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("Play"), out num);
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

	// Token: 0x0601BDAD RID: 114093 RVA: 0x0084E21C File Offset: 0x0084C41C
	protected void Play_Implementation()
	{
	}

	// Token: 0x0601BDAE RID: 114094 RVA: 0x0084E220 File Offset: 0x0084C420
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void Stop(bool immediately = false)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("Stop"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		EffectViewComponent.__Stop_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((EffectViewComponent.__Stop_FunctionParams*)ptr + 15L / (long)sizeof(EffectViewComponent.__Stop_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->immediately = immediately;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601BDAF RID: 114095 RVA: 0x0084E296 File Offset: 0x0084C496
	protected void Stop_Implementation(bool immediately = false)
	{
	}

	// Token: 0x0601BDB0 RID: 114096 RVA: 0x0084E298 File Offset: 0x0084C498
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (EffectViewComponent._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/EffectViewComponent.EffectViewComponent_C");
		}
		return EffectViewComponent._ClassPtr;
	}

	// Token: 0x0601BDB1 RID: 114097 RVA: 0x0084E2BC File Offset: 0x0084C4BC
	public EffectViewComponent() : this(BuiltinUtils.AllocNativeUObject(EffectViewComponent.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BDB2 RID: 114098 RVA: 0x0084E2E4 File Offset: 0x0084C4E4
	[NullableContext(1)]
	public EffectViewComponent(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectViewComponent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BDB3 RID: 114099 RVA: 0x0084E317 File Offset: 0x0084C517
	protected EffectViewComponent(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601BDB4 RID: 114100 RVA: 0x0084E320 File Offset: 0x0084C520
	protected unsafe virtual void __CPPCALL_EditorTick_Implementation(EffectViewComponent.__EditorTick_FunctionParams* __Params)
	{
		this.EditorTick_Implementation(__Params->deltaSecond);
	}

	// Token: 0x0601BDB5 RID: 114101 RVA: 0x0084E32E File Offset: 0x0084C52E
	protected unsafe virtual void __CPPCALL_SetAutoPlay_Implementation(EffectViewComponent.__SetAutoPlay_FunctionParams* __Params)
	{
		this.SetAutoPlay_Implementation(__Params->autoPlay);
	}

	// Token: 0x0601BDB6 RID: 114102 RVA: 0x0084E33C File Offset: 0x0084C53C
	protected virtual void __CPPCALL_Play_Implementation()
	{
		this.Play_Implementation();
	}

	// Token: 0x0601BDB7 RID: 114103 RVA: 0x0084E344 File Offset: 0x0084C544
	protected unsafe virtual void __CPPCALL_Stop_Implementation(EffectViewComponent.__Stop_FunctionParams* __Params)
	{
		this.Stop_Implementation(__Params->immediately);
	}

	// Token: 0x0400E0ED RID: 57581
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/EffectViewComponent.EffectViewComponent_C";

	// Token: 0x0400E0EE RID: 57582
	private static IntPtr _ClassPtr;

	// Token: 0x0400E0EF RID: 57583
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x020094E9 RID: 38121
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __EditorTick_FunctionParams
	{
		// Token: 0x040314ED RID: 201965
		[FieldOffset(0)]
		public float deltaSecond;
	}

	// Token: 0x020094EA RID: 38122
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __SetAutoPlay_FunctionParams
	{
		// Token: 0x040314EE RID: 201966
		[FieldOffset(0)]
		public bool autoPlay;
	}

	// Token: 0x020094EB RID: 38123
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __Stop_FunctionParams
	{
		// Token: 0x040314EF RID: 201967
		[FieldOffset(0)]
		public bool immediately;
	}
}
