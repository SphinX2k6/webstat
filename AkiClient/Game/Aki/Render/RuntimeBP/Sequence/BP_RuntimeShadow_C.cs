using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Sequence
{
	// Token: 0x02003A5D RID: 14941
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Sequence/BP_RuntimeShadow.BP_RuntimeShadow_C")]
	[UnrealStructLayout(1048, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1048)]
	public class BP_RuntimeShadow_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F0D7 RID: 127191 RVA: 0x00906294 File Offset: 0x00904494
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_RuntimeShadow_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Sequence/BP_RuntimeShadow.BP_RuntimeShadow_C");
			}
			return BP_RuntimeShadow_C._ClassPtr;
		}

		// Token: 0x0601F0D8 RID: 127192 RVA: 0x009062B8 File Offset: 0x009044B8
		public BP_RuntimeShadow_C() : this(BuiltinUtils.AllocNativeUObject(BP_RuntimeShadow_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F0D9 RID: 127193 RVA: 0x009062E0 File Offset: 0x009044E0
		[NullableContext(1)]
		public BP_RuntimeShadow_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_RuntimeShadow_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002DD2 RID: 11730
		// (get) Token: 0x0601F0DA RID: 127194 RVA: 0x00906314 File Offset: 0x00904514
		// (set) Token: 0x0601F0DB RID: 127195 RVA: 0x0090634D File Offset: 0x0090454D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_RuntimeShadow_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_RuntimeShadow_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002DD3 RID: 11731
		// (get) Token: 0x0601F0DC RID: 127196 RVA: 0x0090636E File Offset: 0x0090456E
		// (set) Token: 0x0601F0DD RID: 127197 RVA: 0x00906382 File Offset: 0x00904582
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RuntimeShadow_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RuntimeShadow_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0601F0DE RID: 127198 RVA: 0x00906397 File Offset: 0x00904597
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RuntimeShadow_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601F0DF RID: 127199 RVA: 0x009063AB File Offset: 0x009045AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RuntimeShadow_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601F0E0 RID: 127200 RVA: 0x009063C0 File Offset: 0x009045C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_RuntimeShadow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_RuntimeShadow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RuntimeShadow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RuntimeShadow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RuntimeShadow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F0E1 RID: 127201 RVA: 0x00906408 File Offset: 0x00904608
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_RuntimeShadow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_RuntimeShadow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_RuntimeShadow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RuntimeShadow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RuntimeShadow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F0E2 RID: 127202 RVA: 0x00906450 File Offset: 0x00904650
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			BP_RuntimeShadow_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_RuntimeShadow_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_RuntimeShadow_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RuntimeShadow_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_RuntimeShadow_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F0E3 RID: 127203 RVA: 0x0090649C File Offset: 0x0090469C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			BP_RuntimeShadow_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc BP_RuntimeShadow_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_RuntimeShadow_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RuntimeShadow_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RuntimeShadow_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F0E4 RID: 127204 RVA: 0x009064E8 File Offset: 0x009046E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_RuntimeShadow(int EntryPoint)
		{
			BP_RuntimeShadow_C.__ExecuteUbergraph_BP_RuntimeShadow_FunctionParams* ptr = stackalloc BP_RuntimeShadow_C.__ExecuteUbergraph_BP_RuntimeShadow_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_RuntimeShadow_C.__ExecuteUbergraph_BP_RuntimeShadow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_RuntimeShadow_C.__ExecuteUbergraph_BP_RuntimeShadow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_RuntimeShadow_C.__ExecuteUbergraph_BP_RuntimeShadow_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F0E5 RID: 127205 RVA: 0x0090652F File Offset: 0x0090472F
		protected BP_RuntimeShadow_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F5E1 RID: 62945
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Sequence/BP_RuntimeShadow.BP_RuntimeShadow_C";

		// Token: 0x0400F5E2 RID: 62946
		private static IntPtr _ClassPtr;

		// Token: 0x0400F5E3 RID: 62947
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F5E4 RID: 62948
		internal static int __PropertyOffset_0;

		// Token: 0x0400F5E5 RID: 62949
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F5E6 RID: 62950
		internal static int __PropertyOffset_1;

		// Token: 0x0400F5E7 RID: 62951
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F5E8 RID: 62952
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F5E9 RID: 62953
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0400F5EA RID: 62954
		private static IntPtr __ExecuteUbergraph_BP_RuntimeShadow_NativeFunctionPtr;

		// Token: 0x0200984D RID: 38989
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E80 RID: 204416
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200984E RID: 38990
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04031E81 RID: 204417
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x0200984F RID: 38991
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_RuntimeShadow_FunctionParams
		{
			// Token: 0x04031E82 RID: 204418
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
