using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.LiquidContainer
{
	// Token: 0x02003BD9 RID: 15321
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/LiquidContainer/BP_LiquidContainer_Cylinder.BP_LiquidContainer_Cylinder_C")]
	[UnrealStructLayout(1704, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1704)]
	public class BP_LiquidContainer_Cylinder_C : AKuroLiquidContainerActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060225F7 RID: 140791 RVA: 0x00963B3D File Offset: 0x00961D3D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LiquidContainer_Cylinder_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/LiquidContainer/BP_LiquidContainer_Cylinder.BP_LiquidContainer_Cylinder_C");
			}
			return BP_LiquidContainer_Cylinder_C._ClassPtr;
		}

		// Token: 0x060225F8 RID: 140792 RVA: 0x00963B64 File Offset: 0x00961D64
		public BP_LiquidContainer_Cylinder_C() : this(BuiltinUtils.AllocNativeUObject(BP_LiquidContainer_Cylinder_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060225F9 RID: 140793 RVA: 0x00963B8C File Offset: 0x00961D8C
		[NullableContext(1)]
		public BP_LiquidContainer_Cylinder_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LiquidContainer_Cylinder_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004072 RID: 16498
		// (get) Token: 0x060225FA RID: 140794 RVA: 0x00963BC0 File Offset: 0x00961DC0
		// (set) Token: 0x060225FB RID: 140795 RVA: 0x00963BF9 File Offset: 0x00961DF9
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LiquidContainer_Cylinder_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LiquidContainer_Cylinder_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x060225FC RID: 140796 RVA: 0x00963C1A File Offset: 0x00961E1A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LiquidContainer_Cylinder_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060225FD RID: 140797 RVA: 0x00963C2E File Offset: 0x00961E2E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LiquidContainer_Cylinder_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060225FE RID: 140798 RVA: 0x00963C43 File Offset: 0x00961E43
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LiquidContainer_Cylinder_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x060225FF RID: 140799 RVA: 0x00963C57 File Offset: 0x00961E57
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LiquidContainer_Cylinder_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022600 RID: 140800 RVA: 0x00963C6C File Offset: 0x00961E6C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LiquidContainer_Cylinder_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LiquidContainer_Cylinder_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LiquidContainer_Cylinder_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LiquidContainer_Cylinder_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LiquidContainer_Cylinder_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022601 RID: 140801 RVA: 0x00963CB4 File Offset: 0x00961EB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LiquidContainer_Cylinder_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LiquidContainer_Cylinder_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LiquidContainer_Cylinder_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LiquidContainer_Cylinder_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LiquidContainer_Cylinder_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022602 RID: 140802 RVA: 0x00963CFC File Offset: 0x00961EFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_LiquidContainer_Cylinder_C.__EditorTick_FunctionParams* ptr = stackalloc BP_LiquidContainer_Cylinder_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LiquidContainer_Cylinder_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LiquidContainer_Cylinder_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LiquidContainer_Cylinder_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06022603 RID: 140803 RVA: 0x00963D44 File Offset: 0x00961F44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_LiquidContainer_Cylinder_C.__EditorTick_FunctionParams* ptr = stackalloc BP_LiquidContainer_Cylinder_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LiquidContainer_Cylinder_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LiquidContainer_Cylinder_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LiquidContainer_Cylinder_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022604 RID: 140804 RVA: 0x00963D8B File Offset: 0x00961F8B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicEnable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LiquidContainer_Cylinder_C.__OnLogicEnable_NativeFunctionPtr, null);
		}

		// Token: 0x06022605 RID: 140805 RVA: 0x00963D9F File Offset: 0x00961F9F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicEnable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LiquidContainer_Cylinder_C.__OnLogicEnable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022606 RID: 140806 RVA: 0x00963DB4 File Offset: 0x00961FB4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnLogicDisable()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LiquidContainer_Cylinder_C.__OnLogicDisable_NativeFunctionPtr, null);
		}

		// Token: 0x06022607 RID: 140807 RVA: 0x00963DC8 File Offset: 0x00961FC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnLogicDisable_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LiquidContainer_Cylinder_C.__OnLogicDisable_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06022608 RID: 140808 RVA: 0x00963DE0 File Offset: 0x00961FE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LiquidContainer_Cylinder(int EntryPoint)
		{
			BP_LiquidContainer_Cylinder_C.__ExecuteUbergraph_BP_LiquidContainer_Cylinder_FunctionParams* ptr = stackalloc BP_LiquidContainer_Cylinder_C.__ExecuteUbergraph_BP_LiquidContainer_Cylinder_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_LiquidContainer_Cylinder_C.__ExecuteUbergraph_BP_LiquidContainer_Cylinder_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LiquidContainer_Cylinder_C.__ExecuteUbergraph_BP_LiquidContainer_Cylinder_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LiquidContainer_Cylinder_C.__ExecuteUbergraph_BP_LiquidContainer_Cylinder_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06022609 RID: 140809 RVA: 0x00963E27 File Offset: 0x00962027
		protected BP_LiquidContainer_Cylinder_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011654 RID: 71252
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/LiquidContainer/BP_LiquidContainer_Cylinder.BP_LiquidContainer_Cylinder_C";

		// Token: 0x04011655 RID: 71253
		private static IntPtr _ClassPtr;

		// Token: 0x04011656 RID: 71254
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011657 RID: 71255
		internal static int __PropertyOffset_0;

		// Token: 0x04011658 RID: 71256
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04011659 RID: 71257
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x0401165A RID: 71258
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401165B RID: 71259
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0401165C RID: 71260
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x0401165D RID: 71261
		private static IntPtr __OnLogicEnable_NativeFunctionPtr;

		// Token: 0x0401165E RID: 71262
		private static IntPtr __OnLogicDisable_NativeFunctionPtr;

		// Token: 0x0401165F RID: 71263
		private static IntPtr __ExecuteUbergraph_BP_LiquidContainer_Cylinder_NativeFunctionPtr;

		// Token: 0x02009BCF RID: 39887
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032415 RID: 205845
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BD0 RID: 39888
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032416 RID: 205846
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009BD1 RID: 39889
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_LiquidContainer_Cylinder_FunctionParams
		{
			// Token: 0x04032417 RID: 205847
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
