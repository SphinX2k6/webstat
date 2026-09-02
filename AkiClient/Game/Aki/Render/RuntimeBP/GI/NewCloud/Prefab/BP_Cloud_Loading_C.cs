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
	// Token: 0x02003CB5 RID: 15541
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_Loading.BP_Cloud_Loading_C")]
	[UnrealStructLayout(1808, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1808)]
	public class BP_Cloud_Loading_C : BP_CloudPrefab_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024C11 RID: 150545 RVA: 0x009A6754 File Offset: 0x009A4954
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Cloud_Loading_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_Loading.BP_Cloud_Loading_C");
			}
			return BP_Cloud_Loading_C._ClassPtr;
		}

		// Token: 0x06024C12 RID: 150546 RVA: 0x009A6778 File Offset: 0x009A4978
		public BP_Cloud_Loading_C() : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_Loading_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024C13 RID: 150547 RVA: 0x009A67A0 File Offset: 0x009A49A0
		[NullableContext(1)]
		public BP_Cloud_Loading_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_Loading_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004DDB RID: 19931
		// (get) Token: 0x06024C14 RID: 150548 RVA: 0x009A67D4 File Offset: 0x009A49D4
		// (set) Token: 0x06024C15 RID: 150549 RVA: 0x009A680D File Offset: 0x009A4A0D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Cloud_Loading_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Cloud_Loading_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06024C16 RID: 150550 RVA: 0x009A6830 File Offset: 0x009A4A30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Hidden(bool InstantHide)
		{
			BP_Cloud_Loading_C.__Hidden_FunctionParams* ptr = stackalloc BP_Cloud_Loading_C.__Hidden_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Cloud_Loading_C.__Hidden_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_Loading_C.__Hidden_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InstantHide = InstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_Loading_C.__Hidden_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C17 RID: 150551 RVA: 0x009A6878 File Offset: 0x009A4A78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Active(bool bInstantHide)
		{
			BP_Cloud_Loading_C.__Active_FunctionParams* ptr = stackalloc BP_Cloud_Loading_C.__Active_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Cloud_Loading_C.__Active_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_Loading_C.__Active_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bInstantHide = bInstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_Loading_C.__Active_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C18 RID: 150552 RVA: 0x009A68BE File Offset: 0x009A4ABE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_Loading_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024C19 RID: 150553 RVA: 0x009A68D2 File Offset: 0x009A4AD2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_Loading_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024C1A RID: 150554 RVA: 0x009A68E8 File Offset: 0x009A4AE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Cloud_Loading_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_Loading_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_Loading_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_Loading_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_Loading_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C1B RID: 150555 RVA: 0x009A6930 File Offset: 0x009A4B30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_Loading_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_Loading_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_Loading_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_Loading_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_Loading_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C1C RID: 150556 RVA: 0x009A6978 File Offset: 0x009A4B78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Cloud_Loading_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_Loading_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_Loading_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_Loading_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_Loading_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C1D RID: 150557 RVA: 0x009A69C0 File Offset: 0x009A4BC0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_Loading_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_Loading_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_Loading_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_Loading_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_Loading_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C1E RID: 150558 RVA: 0x009A6A08 File Offset: 0x009A4C08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Cloud_Loading(int EntryPoint)
		{
			BP_Cloud_Loading_C.__ExecuteUbergraph_BP_Cloud_Loading_FunctionParams* ptr = stackalloc BP_Cloud_Loading_C.__ExecuteUbergraph_BP_Cloud_Loading_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_Cloud_Loading_C.__ExecuteUbergraph_BP_Cloud_Loading_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_Loading_C.__ExecuteUbergraph_BP_Cloud_Loading_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_Loading_C.__ExecuteUbergraph_BP_Cloud_Loading_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C1F RID: 150559 RVA: 0x009A6A4F File Offset: 0x009A4C4F
		protected BP_Cloud_Loading_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012D95 RID: 77205
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_Loading.BP_Cloud_Loading_C";

		// Token: 0x04012D96 RID: 77206
		private static IntPtr _ClassPtr;

		// Token: 0x04012D97 RID: 77207
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012D98 RID: 77208
		internal new static int __PropertyOffset_0;

		// Token: 0x04012D99 RID: 77209
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012D9A RID: 77210
		private static IntPtr __Hidden_NativeFunctionPtr;

		// Token: 0x04012D9B RID: 77211
		private static IntPtr __Active_NativeFunctionPtr;

		// Token: 0x04012D9C RID: 77212
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012D9D RID: 77213
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012D9E RID: 77214
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012D9F RID: 77215
		private static IntPtr __ExecuteUbergraph_BP_Cloud_Loading_NativeFunctionPtr;

		// Token: 0x02009E43 RID: 40515
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __Hidden_FunctionParams
		{
			// Token: 0x04032896 RID: 206998
			[FieldOffset(0)]
			public bool InstantHide;
		}

		// Token: 0x02009E44 RID: 40516
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __Active_FunctionParams
		{
			// Token: 0x04032897 RID: 206999
			[FieldOffset(0)]
			public bool bInstantHide;
		}

		// Token: 0x02009E45 RID: 40517
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032898 RID: 207000
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E46 RID: 40518
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032899 RID: 207001
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E47 RID: 40519
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_Cloud_Loading_FunctionParams
		{
			// Token: 0x0403289A RID: 207002
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
