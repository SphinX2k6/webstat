using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonPet;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA015
{
	// Token: 0x02004177 RID: 16759
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA015/BP_NA015_Swimming.BP_NA015_Swimming_C")]
	[UnrealStructLayout(2288, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2280)]
	public class BP_NA015_Swimming_C : BP_CommonPet_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C713 RID: 182035 RVA: 0x00AA183C File Offset: 0x00A9FA3C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA015_Swimming_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA015/BP_NA015_Swimming.BP_NA015_Swimming_C");
			}
			return BP_NA015_Swimming_C._ClassPtr;
		}

		// Token: 0x0602C714 RID: 182036 RVA: 0x00AA1860 File Offset: 0x00A9FA60
		public BP_NA015_Swimming_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA015_Swimming_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C715 RID: 182037 RVA: 0x00AA1888 File Offset: 0x00A9FA88
		[NullableContext(1)]
		public BP_NA015_Swimming_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA015_Swimming_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007777 RID: 30583
		// (get) Token: 0x0602C716 RID: 182038 RVA: 0x00AA18BC File Offset: 0x00A9FABC
		// (set) Token: 0x0602C717 RID: 182039 RVA: 0x00AA18F5 File Offset: 0x00A9FAF5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_NA015_Swimming_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_NA015_Swimming_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007778 RID: 30584
		// (get) Token: 0x0602C718 RID: 182040 RVA: 0x00AA1916 File Offset: 0x00A9FB16
		// (set) Token: 0x0602C719 RID: 182041 RVA: 0x00AA192A File Offset: 0x00A9FB2A
		public unsafe FVectorDouble CurrentVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_NA015_Swimming_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_NA015_Swimming_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602C71A RID: 182042 RVA: 0x00AA1940 File Offset: 0x00A9FB40
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_NA015_Swimming_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_NA015_Swimming_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NA015_Swimming_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NA015_Swimming_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_NA015_Swimming_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C71B RID: 182043 RVA: 0x00AA1988 File Offset: 0x00A9FB88
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_NA015_Swimming_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_NA015_Swimming_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_NA015_Swimming_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NA015_Swimming_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA015_Swimming_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C71C RID: 182044 RVA: 0x00AA19D0 File Offset: 0x00A9FBD0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_NA015_Swimming(int EntryPoint)
		{
			BP_NA015_Swimming_C.__ExecuteUbergraph_BP_NA015_Swimming_FunctionParams* ptr = stackalloc BP_NA015_Swimming_C.__ExecuteUbergraph_BP_NA015_Swimming_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_NA015_Swimming_C.__ExecuteUbergraph_BP_NA015_Swimming_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_NA015_Swimming_C.__ExecuteUbergraph_BP_NA015_Swimming_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_NA015_Swimming_C.__ExecuteUbergraph_BP_NA015_Swimming_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C71D RID: 182045 RVA: 0x00AA1A17 File Offset: 0x00A9FC17
		protected BP_NA015_Swimming_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AE8 RID: 101096
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA015/BP_NA015_Swimming.BP_NA015_Swimming_C";

		// Token: 0x04018AE9 RID: 101097
		private static IntPtr _ClassPtr;

		// Token: 0x04018AEA RID: 101098
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018AEB RID: 101099
		internal new static int __PropertyOffset_0;

		// Token: 0x04018AEC RID: 101100
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018AED RID: 101101
		internal static int __PropertyOffset_1;

		// Token: 0x04018AEE RID: 101102
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04018AEF RID: 101103
		private static IntPtr __ExecuteUbergraph_BP_NA015_Swimming_NativeFunctionPtr;

		// Token: 0x0200A44B RID: 42059
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403324D RID: 209485
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A44C RID: 42060
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_BP_NA015_Swimming_FunctionParams
		{
			// Token: 0x0403324E RID: 209486
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
