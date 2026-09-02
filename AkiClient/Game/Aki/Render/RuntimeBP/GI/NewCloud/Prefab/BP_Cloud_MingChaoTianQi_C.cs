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
	// Token: 0x02003CB6 RID: 15542
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_MingChaoTianQi.BP_Cloud_MingChaoTianQi_C")]
	[UnrealStructLayout(1808, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1808)]
	public class BP_Cloud_MingChaoTianQi_C : BP_CloudPrefab_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024C20 RID: 150560 RVA: 0x009A6A58 File Offset: 0x009A4C58
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Cloud_MingChaoTianQi_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_MingChaoTianQi.BP_Cloud_MingChaoTianQi_C");
			}
			return BP_Cloud_MingChaoTianQi_C._ClassPtr;
		}

		// Token: 0x06024C21 RID: 150561 RVA: 0x009A6A7C File Offset: 0x009A4C7C
		public BP_Cloud_MingChaoTianQi_C() : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_MingChaoTianQi_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024C22 RID: 150562 RVA: 0x009A6AA4 File Offset: 0x009A4CA4
		[NullableContext(1)]
		public BP_Cloud_MingChaoTianQi_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_MingChaoTianQi_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004DDC RID: 19932
		// (get) Token: 0x06024C23 RID: 150563 RVA: 0x009A6AD8 File Offset: 0x009A4CD8
		// (set) Token: 0x06024C24 RID: 150564 RVA: 0x009A6B11 File Offset: 0x009A4D11
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Cloud_MingChaoTianQi_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Cloud_MingChaoTianQi_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06024C25 RID: 150565 RVA: 0x009A6B34 File Offset: 0x009A4D34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Hidden(bool InstantHide)
		{
			BP_Cloud_MingChaoTianQi_C.__Hidden_FunctionParams* ptr = stackalloc BP_Cloud_MingChaoTianQi_C.__Hidden_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Cloud_MingChaoTianQi_C.__Hidden_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_MingChaoTianQi_C.__Hidden_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InstantHide = InstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_MingChaoTianQi_C.__Hidden_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C26 RID: 150566 RVA: 0x009A6B7C File Offset: 0x009A4D7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Active(bool bInstantHide)
		{
			BP_Cloud_MingChaoTianQi_C.__Active_FunctionParams* ptr = stackalloc BP_Cloud_MingChaoTianQi_C.__Active_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Cloud_MingChaoTianQi_C.__Active_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_MingChaoTianQi_C.__Active_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bInstantHide = bInstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_MingChaoTianQi_C.__Active_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C27 RID: 150567 RVA: 0x009A6BC2 File Offset: 0x009A4DC2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_MingChaoTianQi_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024C28 RID: 150568 RVA: 0x009A6BD6 File Offset: 0x009A4DD6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_MingChaoTianQi_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024C29 RID: 150569 RVA: 0x009A6BEC File Offset: 0x009A4DEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Cloud_MingChaoTianQi_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_MingChaoTianQi_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_MingChaoTianQi_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_MingChaoTianQi_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_MingChaoTianQi_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C2A RID: 150570 RVA: 0x009A6C34 File Offset: 0x009A4E34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_MingChaoTianQi_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_MingChaoTianQi_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_MingChaoTianQi_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_MingChaoTianQi_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_MingChaoTianQi_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C2B RID: 150571 RVA: 0x009A6C7C File Offset: 0x009A4E7C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Cloud_MingChaoTianQi_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_MingChaoTianQi_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_MingChaoTianQi_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_MingChaoTianQi_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_MingChaoTianQi_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C2C RID: 150572 RVA: 0x009A6CC4 File Offset: 0x009A4EC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_MingChaoTianQi_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_MingChaoTianQi_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_MingChaoTianQi_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_MingChaoTianQi_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_MingChaoTianQi_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C2D RID: 150573 RVA: 0x009A6D0C File Offset: 0x009A4F0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Cloud_MingChaoTianQi(int EntryPoint)
		{
			BP_Cloud_MingChaoTianQi_C.__ExecuteUbergraph_BP_Cloud_MingChaoTianQi_FunctionParams* ptr = stackalloc BP_Cloud_MingChaoTianQi_C.__ExecuteUbergraph_BP_Cloud_MingChaoTianQi_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_Cloud_MingChaoTianQi_C.__ExecuteUbergraph_BP_Cloud_MingChaoTianQi_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_MingChaoTianQi_C.__ExecuteUbergraph_BP_Cloud_MingChaoTianQi_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_MingChaoTianQi_C.__ExecuteUbergraph_BP_Cloud_MingChaoTianQi_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C2E RID: 150574 RVA: 0x009A6D53 File Offset: 0x009A4F53
		protected BP_Cloud_MingChaoTianQi_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012DA0 RID: 77216
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_MingChaoTianQi.BP_Cloud_MingChaoTianQi_C";

		// Token: 0x04012DA1 RID: 77217
		private static IntPtr _ClassPtr;

		// Token: 0x04012DA2 RID: 77218
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012DA3 RID: 77219
		internal new static int __PropertyOffset_0;

		// Token: 0x04012DA4 RID: 77220
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012DA5 RID: 77221
		private static IntPtr __Hidden_NativeFunctionPtr;

		// Token: 0x04012DA6 RID: 77222
		private static IntPtr __Active_NativeFunctionPtr;

		// Token: 0x04012DA7 RID: 77223
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012DA8 RID: 77224
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012DA9 RID: 77225
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012DAA RID: 77226
		private static IntPtr __ExecuteUbergraph_BP_Cloud_MingChaoTianQi_NativeFunctionPtr;

		// Token: 0x02009E48 RID: 40520
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __Hidden_FunctionParams
		{
			// Token: 0x0403289B RID: 207003
			[FieldOffset(0)]
			public bool InstantHide;
		}

		// Token: 0x02009E49 RID: 40521
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __Active_FunctionParams
		{
			// Token: 0x0403289C RID: 207004
			[FieldOffset(0)]
			public bool bInstantHide;
		}

		// Token: 0x02009E4A RID: 40522
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403289D RID: 207005
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E4B RID: 40523
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x0403289E RID: 207006
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E4C RID: 40524
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_Cloud_MingChaoTianQi_FunctionParams
		{
			// Token: 0x0403289F RID: 207007
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
