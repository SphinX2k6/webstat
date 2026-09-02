using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.Prefab
{
	// Token: 0x02003CB7 RID: 15543
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_None.BP_Cloud_None_C")]
	[UnrealStructLayout(1808, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1808)]
	public class BP_Cloud_None_C : BP_CloudPrefab_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024C2F RID: 150575 RVA: 0x009A6D5C File Offset: 0x009A4F5C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Cloud_None_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_None.BP_Cloud_None_C");
			}
			return BP_Cloud_None_C._ClassPtr;
		}

		// Token: 0x06024C30 RID: 150576 RVA: 0x009A6D80 File Offset: 0x009A4F80
		public BP_Cloud_None_C() : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_None_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024C31 RID: 150577 RVA: 0x009A6DA8 File Offset: 0x009A4FA8
		[NullableContext(1)]
		public BP_Cloud_None_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_None_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004DDD RID: 19933
		// (get) Token: 0x06024C32 RID: 150578 RVA: 0x009A6DDC File Offset: 0x009A4FDC
		// (set) Token: 0x06024C33 RID: 150579 RVA: 0x009A6E15 File Offset: 0x009A5015
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Cloud_None_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Cloud_None_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06024C34 RID: 150580 RVA: 0x009A6E38 File Offset: 0x009A5038
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Hidden(bool InstantHide)
		{
			BP_Cloud_None_C.__Hidden_FunctionParams* ptr = stackalloc BP_Cloud_None_C.__Hidden_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Cloud_None_C.__Hidden_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_None_C.__Hidden_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InstantHide = InstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_None_C.__Hidden_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C35 RID: 150581 RVA: 0x009A6E80 File Offset: 0x009A5080
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Active(bool bInstantHide)
		{
			BP_Cloud_None_C.__Active_FunctionParams* ptr = stackalloc BP_Cloud_None_C.__Active_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Cloud_None_C.__Active_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_None_C.__Active_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bInstantHide = bInstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_None_C.__Active_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C36 RID: 150582 RVA: 0x009A6EC6 File Offset: 0x009A50C6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_None_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024C37 RID: 150583 RVA: 0x009A6EDA File Offset: 0x009A50DA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_None_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024C38 RID: 150584 RVA: 0x009A6EF0 File Offset: 0x009A50F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Cloud_None_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_None_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_None_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_None_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_None_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C39 RID: 150585 RVA: 0x009A6F38 File Offset: 0x009A5138
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_None_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_None_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_None_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_None_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_None_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C3A RID: 150586 RVA: 0x009A6F80 File Offset: 0x009A5180
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Cloud_None_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_None_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_None_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_None_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_None_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C3B RID: 150587 RVA: 0x009A6FC8 File Offset: 0x009A51C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_None_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_None_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_None_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_None_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_None_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C3C RID: 150588 RVA: 0x009A7010 File Offset: 0x009A5210
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Cloud_None(int EntryPoint)
		{
			BP_Cloud_None_C.__ExecuteUbergraph_BP_Cloud_None_FunctionParams* ptr = stackalloc BP_Cloud_None_C.__ExecuteUbergraph_BP_Cloud_None_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_Cloud_None_C.__ExecuteUbergraph_BP_Cloud_None_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_None_C.__ExecuteUbergraph_BP_Cloud_None_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_None_C.__ExecuteUbergraph_BP_Cloud_None_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C3D RID: 150589 RVA: 0x009A7057 File Offset: 0x009A5257
		protected BP_Cloud_None_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012DAB RID: 77227
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_None.BP_Cloud_None_C";

		// Token: 0x04012DAC RID: 77228
		private static IntPtr _ClassPtr;

		// Token: 0x04012DAD RID: 77229
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012DAE RID: 77230
		internal new static int __PropertyOffset_0;

		// Token: 0x04012DAF RID: 77231
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012DB0 RID: 77232
		private static IntPtr __Hidden_NativeFunctionPtr;

		// Token: 0x04012DB1 RID: 77233
		private static IntPtr __Active_NativeFunctionPtr;

		// Token: 0x04012DB2 RID: 77234
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012DB3 RID: 77235
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012DB4 RID: 77236
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012DB5 RID: 77237
		private static IntPtr __ExecuteUbergraph_BP_Cloud_None_NativeFunctionPtr;

		// Token: 0x02009E4D RID: 40525
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __Hidden_FunctionParams
		{
			// Token: 0x040328A0 RID: 207008
			[FieldOffset(0)]
			public bool InstantHide;
		}

		// Token: 0x02009E4E RID: 40526
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __Active_FunctionParams
		{
			// Token: 0x040328A1 RID: 207009
			[FieldOffset(0)]
			public bool bInstantHide;
		}

		// Token: 0x02009E4F RID: 40527
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040328A2 RID: 207010
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E50 RID: 40528
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040328A3 RID: 207011
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E51 RID: 40529
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_Cloud_None_FunctionParams
		{
			// Token: 0x040328A4 RID: 207012
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
