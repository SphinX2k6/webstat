using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonPet;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA012
{
	// Token: 0x0200417E RID: 16766
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA012/BP_NA012_Swimming.BP_NA012_Swimming_C")]
	[UnrealStructLayout(2288, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2280)]
	public class BP_NA012_Swimming_C : BP_CommonPet_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C736 RID: 182070 RVA: 0x00AA1D50 File Offset: 0x00A9FF50
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA012_Swimming_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA012/BP_NA012_Swimming.BP_NA012_Swimming_C");
			}
			return BP_NA012_Swimming_C._ClassPtr;
		}

		// Token: 0x0602C737 RID: 182071 RVA: 0x00AA1D74 File Offset: 0x00A9FF74
		public BP_NA012_Swimming_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA012_Swimming_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C738 RID: 182072 RVA: 0x00AA1D9C File Offset: 0x00A9FF9C
		[NullableContext(1)]
		public BP_NA012_Swimming_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA012_Swimming_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007779 RID: 30585
		// (get) Token: 0x0602C739 RID: 182073 RVA: 0x00AA1DD0 File Offset: 0x00A9FFD0
		// (set) Token: 0x0602C73A RID: 182074 RVA: 0x00AA1E09 File Offset: 0x00AA0009
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NA012_Swimming_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NA012_Swimming_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700777A RID: 30586
		// (get) Token: 0x0602C73B RID: 182075 RVA: 0x00AA1E2A File Offset: 0x00AA002A
		// (set) Token: 0x0602C73C RID: 182076 RVA: 0x00AA1E3E File Offset: 0x00AA003E
		public unsafe FVectorDouble CurrentVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NA012_Swimming_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NA012_Swimming_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602C73D RID: 182077 RVA: 0x00AA1E54 File Offset: 0x00AA0054
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_NA012_Swimming_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_NA012_Swimming_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NA012_Swimming_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NA012_Swimming_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NA012_Swimming_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C73E RID: 182078 RVA: 0x00AA1E9C File Offset: 0x00AA009C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_NA012_Swimming_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_NA012_Swimming_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NA012_Swimming_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NA012_Swimming_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA012_Swimming_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C73F RID: 182079 RVA: 0x00AA1EE4 File Offset: 0x00AA00E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NA012_Swimming(int EntryPoint)
		{
			BP_NA012_Swimming_C.__ExecuteUbergraph_BP_NA012_Swimming_FunctionParams* ptr = stackalloc BP_NA012_Swimming_C.__ExecuteUbergraph_BP_NA012_Swimming_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_NA012_Swimming_C.__ExecuteUbergraph_BP_NA012_Swimming_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NA012_Swimming_C.__ExecuteUbergraph_BP_NA012_Swimming_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA012_Swimming_C.__ExecuteUbergraph_BP_NA012_Swimming_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C740 RID: 182080 RVA: 0x00AA1F2B File Offset: 0x00AA012B
		protected BP_NA012_Swimming_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B02 RID: 101122
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA012/BP_NA012_Swimming.BP_NA012_Swimming_C";

		// Token: 0x04018B03 RID: 101123
		private static IntPtr _ClassPtr;

		// Token: 0x04018B04 RID: 101124
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018B05 RID: 101125
		internal new static int __PropertyOffset_0;

		// Token: 0x04018B06 RID: 101126
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018B07 RID: 101127
		internal static int __PropertyOffset_1;

		// Token: 0x04018B08 RID: 101128
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04018B09 RID: 101129
		private static IntPtr __ExecuteUbergraph_BP_NA012_Swimming_NativeFunctionPtr;

		// Token: 0x0200A44D RID: 42061
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403324F RID: 209487
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A44E RID: 42062
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_BP_NA012_Swimming_FunctionParams
		{
			// Token: 0x04033250 RID: 209488
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
