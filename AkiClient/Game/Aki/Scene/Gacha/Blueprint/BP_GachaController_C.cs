using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Scene.Gacha.Blueprint
{
	// Token: 0x020039E9 RID: 14825
	[UnrealObjectPath("/Game/Aki/Scene/Gacha/Blueprint/BP_GachaController.BP_GachaController_C")]
	[UnrealStructLayout(2056, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2056)]
	public class BP_GachaController_C : APlayerController, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E0EE RID: 123118 RVA: 0x008EAA78 File Offset: 0x008E8C78
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GachaController_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Scene/Gacha/Blueprint/BP_GachaController.BP_GachaController_C");
			}
			return BP_GachaController_C._ClassPtr;
		}

		// Token: 0x0601E0EF RID: 123119 RVA: 0x008EAA9C File Offset: 0x008E8C9C
		public BP_GachaController_C() : this(BuiltinUtils.AllocNativeUObject(BP_GachaController_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E0F0 RID: 123120 RVA: 0x008EAAC4 File Offset: 0x008E8CC4
		[NullableContext(1)]
		public BP_GachaController_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GachaController_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002838 RID: 10296
		// (get) Token: 0x0601E0F1 RID: 123121 RVA: 0x008EAAF8 File Offset: 0x008E8CF8
		// (set) Token: 0x0601E0F2 RID: 123122 RVA: 0x008EAB31 File Offset: 0x008E8D31
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_GachaController_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_GachaController_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002839 RID: 10297
		// (get) Token: 0x0601E0F3 RID: 123123 RVA: 0x008EAB52 File Offset: 0x008E8D52
		// (set) Token: 0x0601E0F4 RID: 123124 RVA: 0x008EAB62 File Offset: 0x008E8D62
		public unsafe bool LeftMouseBottomClick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaController_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaController_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700283A RID: 10298
		// (get) Token: 0x0601E0F5 RID: 123125 RVA: 0x008EAB73 File Offset: 0x008E8D73
		// (set) Token: 0x0601E0F6 RID: 123126 RVA: 0x008EAB83 File Offset: 0x008E8D83
		public unsafe float Camera_Length
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaController_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaController_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700283B RID: 10299
		// (get) Token: 0x0601E0F7 RID: 123127 RVA: 0x008EAB94 File Offset: 0x008E8D94
		// (set) Token: 0x0601E0F8 RID: 123128 RVA: 0x008EABA8 File Offset: 0x008E8DA8
		[Nullable(2)]
		public unsafe BP_GachaArt_C CurrentWildCardsPawn
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GachaArt_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaController_C.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GachaController_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700283C RID: 10300
		// (get) Token: 0x0601E0F9 RID: 123129 RVA: 0x008EABBD File Offset: 0x008E8DBD
		// (set) Token: 0x0601E0FA RID: 123130 RVA: 0x008EABCD File Offset: 0x008E8DCD
		public unsafe float Process
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaController_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaController_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700283D RID: 10301
		// (get) Token: 0x0601E0FB RID: 123131 RVA: 0x008EABDE File Offset: 0x008E8DDE
		// (set) Token: 0x0601E0FC RID: 123132 RVA: 0x008EABEE File Offset: 0x008E8DEE
		public unsafe float GoldenProcess
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_GachaController_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_GachaController_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x0601E0FD RID: 123133 RVA: 0x008EABFF File Offset: 0x008E8DFF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateProcess()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaController_C.__UpdateProcess_NativeFunctionPtr, null);
		}

		// Token: 0x0601E0FE RID: 123134 RVA: 0x008EAC14 File Offset: 0x008E8E14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateCursor(float DistanceRatio)
		{
			BP_GachaController_C.__UpdateCursor_FunctionParams* ptr = stackalloc BP_GachaController_C.__UpdateCursor_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GachaController_C.__UpdateCursor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaController_C.__UpdateCursor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DistanceRatio = DistanceRatio;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaController_C.__UpdateCursor_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E0FF RID: 123135 RVA: 0x008EAC5C File Offset: 0x008E8E5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateCenterDisk(float DistanceRatio)
		{
			BP_GachaController_C.__UpdateCenterDisk_FunctionParams* ptr = stackalloc BP_GachaController_C.__UpdateCenterDisk_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GachaController_C.__UpdateCenterDisk_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaController_C.__UpdateCenterDisk_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DistanceRatio = DistanceRatio;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaController_C.__UpdateCenterDisk_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E100 RID: 123136 RVA: 0x008EACA2 File Offset: 0x008E8EA2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void GetCurrentPawn()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaController_C.__GetCurrentPawn_NativeFunctionPtr, null);
		}

		// Token: 0x0601E101 RID: 123137 RVA: 0x008EACB6 File Offset: 0x008E8EB6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaController_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E102 RID: 123138 RVA: 0x008EACCA File Offset: 0x008E8ECA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GachaController_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E103 RID: 123139 RVA: 0x008EACE0 File Offset: 0x008E8EE0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_GachaController_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GachaController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GachaController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GachaController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E104 RID: 123140 RVA: 0x008EAD28 File Offset: 0x008E8F28
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_GachaController_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_GachaController_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GachaController_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GachaController_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E105 RID: 123141 RVA: 0x008EAD70 File Offset: 0x008E8F70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_GachaController(int EntryPoint)
		{
			BP_GachaController_C.__ExecuteUbergraph_BP_GachaController_FunctionParams* ptr = stackalloc BP_GachaController_C.__ExecuteUbergraph_BP_GachaController_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_GachaController_C.__ExecuteUbergraph_BP_GachaController_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GachaController_C.__ExecuteUbergraph_BP_GachaController_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_GachaController_C.__ExecuteUbergraph_BP_GachaController_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E106 RID: 123142 RVA: 0x008EADB7 File Offset: 0x008E8FB7
		protected BP_GachaController_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EBD7 RID: 60375
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Scene/Gacha/Blueprint/BP_GachaController.BP_GachaController_C";

		// Token: 0x0400EBD8 RID: 60376
		private static IntPtr _ClassPtr;

		// Token: 0x0400EBD9 RID: 60377
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EBDA RID: 60378
		internal static int __PropertyOffset_0;

		// Token: 0x0400EBDB RID: 60379
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400EBDC RID: 60380
		internal static int __PropertyOffset_1;

		// Token: 0x0400EBDD RID: 60381
		internal static int __PropertyOffset_2;

		// Token: 0x0400EBDE RID: 60382
		internal static int __PropertyOffset_3;

		// Token: 0x0400EBDF RID: 60383
		internal static int __PropertyOffset_4;

		// Token: 0x0400EBE0 RID: 60384
		internal static int __PropertyOffset_5;

		// Token: 0x0400EBE1 RID: 60385
		private static IntPtr __UpdateProcess_NativeFunctionPtr;

		// Token: 0x0400EBE2 RID: 60386
		private static IntPtr __UpdateCursor_NativeFunctionPtr;

		// Token: 0x0400EBE3 RID: 60387
		private static IntPtr __UpdateCenterDisk_NativeFunctionPtr;

		// Token: 0x0400EBE4 RID: 60388
		private static IntPtr __GetCurrentPawn_NativeFunctionPtr;

		// Token: 0x0400EBE5 RID: 60389
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400EBE6 RID: 60390
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400EBE7 RID: 60391
		private static IntPtr __ExecuteUbergraph_BP_GachaController_NativeFunctionPtr;

		// Token: 0x0200974E RID: 38734
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __UpdateCursor_FunctionParams
		{
			// Token: 0x04031CC8 RID: 203976
			[FieldOffset(0)]
			public float DistanceRatio;
		}

		// Token: 0x0200974F RID: 38735
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __UpdateCenterDisk_FunctionParams
		{
			// Token: 0x04031CC9 RID: 203977
			[FieldOffset(0)]
			public float DistanceRatio;
		}

		// Token: 0x02009750 RID: 38736
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031CCA RID: 203978
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009751 RID: 38737
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_BP_GachaController_FunctionParams
		{
			// Token: 0x04031CCB RID: 203979
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
