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
	// Token: 0x02003CBA RID: 15546
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_WYQ.BP_Cloud_WYQ_C")]
	[UnrealStructLayout(1808, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1808)]
	public class BP_Cloud_WYQ_C : BP_CloudPrefab_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024C5C RID: 150620 RVA: 0x009A7668 File Offset: 0x009A5868
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Cloud_WYQ_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_WYQ.BP_Cloud_WYQ_C");
			}
			return BP_Cloud_WYQ_C._ClassPtr;
		}

		// Token: 0x06024C5D RID: 150621 RVA: 0x009A768C File Offset: 0x009A588C
		public BP_Cloud_WYQ_C() : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_WYQ_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024C5E RID: 150622 RVA: 0x009A76B4 File Offset: 0x009A58B4
		[NullableContext(1)]
		public BP_Cloud_WYQ_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_WYQ_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004DE0 RID: 19936
		// (get) Token: 0x06024C5F RID: 150623 RVA: 0x009A76E8 File Offset: 0x009A58E8
		// (set) Token: 0x06024C60 RID: 150624 RVA: 0x009A7721 File Offset: 0x009A5921
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Cloud_WYQ_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Cloud_WYQ_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06024C61 RID: 150625 RVA: 0x009A7744 File Offset: 0x009A5944
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Hidden(bool InstantHide)
		{
			BP_Cloud_WYQ_C.__Hidden_FunctionParams* ptr = stackalloc BP_Cloud_WYQ_C.__Hidden_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Cloud_WYQ_C.__Hidden_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_WYQ_C.__Hidden_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InstantHide = InstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_WYQ_C.__Hidden_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C62 RID: 150626 RVA: 0x009A778C File Offset: 0x009A598C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Active(bool bInstantHide)
		{
			BP_Cloud_WYQ_C.__Active_FunctionParams* ptr = stackalloc BP_Cloud_WYQ_C.__Active_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Cloud_WYQ_C.__Active_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_WYQ_C.__Active_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bInstantHide = bInstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_WYQ_C.__Active_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C63 RID: 150627 RVA: 0x009A77D2 File Offset: 0x009A59D2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_WYQ_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024C64 RID: 150628 RVA: 0x009A77E6 File Offset: 0x009A59E6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_WYQ_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024C65 RID: 150629 RVA: 0x009A77FC File Offset: 0x009A59FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Cloud_WYQ_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_WYQ_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_WYQ_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_WYQ_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_WYQ_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C66 RID: 150630 RVA: 0x009A7844 File Offset: 0x009A5A44
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_WYQ_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_WYQ_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_WYQ_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_WYQ_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_WYQ_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C67 RID: 150631 RVA: 0x009A788C File Offset: 0x009A5A8C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Cloud_WYQ_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_WYQ_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_WYQ_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_WYQ_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_WYQ_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C68 RID: 150632 RVA: 0x009A78D4 File Offset: 0x009A5AD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_WYQ_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_WYQ_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_WYQ_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_WYQ_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_WYQ_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C69 RID: 150633 RVA: 0x009A791C File Offset: 0x009A5B1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Cloud_WYQ(int EntryPoint)
		{
			BP_Cloud_WYQ_C.__ExecuteUbergraph_BP_Cloud_WYQ_FunctionParams* ptr = stackalloc BP_Cloud_WYQ_C.__ExecuteUbergraph_BP_Cloud_WYQ_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_Cloud_WYQ_C.__ExecuteUbergraph_BP_Cloud_WYQ_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_WYQ_C.__ExecuteUbergraph_BP_Cloud_WYQ_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_WYQ_C.__ExecuteUbergraph_BP_Cloud_WYQ_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C6A RID: 150634 RVA: 0x009A7963 File Offset: 0x009A5B63
		protected BP_Cloud_WYQ_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012DCC RID: 77260
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_WYQ.BP_Cloud_WYQ_C";

		// Token: 0x04012DCD RID: 77261
		private static IntPtr _ClassPtr;

		// Token: 0x04012DCE RID: 77262
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012DCF RID: 77263
		internal new static int __PropertyOffset_0;

		// Token: 0x04012DD0 RID: 77264
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012DD1 RID: 77265
		private static IntPtr __Hidden_NativeFunctionPtr;

		// Token: 0x04012DD2 RID: 77266
		private static IntPtr __Active_NativeFunctionPtr;

		// Token: 0x04012DD3 RID: 77267
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012DD4 RID: 77268
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012DD5 RID: 77269
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012DD6 RID: 77270
		private static IntPtr __ExecuteUbergraph_BP_Cloud_WYQ_NativeFunctionPtr;

		// Token: 0x02009E5C RID: 40540
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __Hidden_FunctionParams
		{
			// Token: 0x040328AF RID: 207023
			[FieldOffset(0)]
			public bool InstantHide;
		}

		// Token: 0x02009E5D RID: 40541
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __Active_FunctionParams
		{
			// Token: 0x040328B0 RID: 207024
			[FieldOffset(0)]
			public bool bInstantHide;
		}

		// Token: 0x02009E5E RID: 40542
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040328B1 RID: 207025
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E5F RID: 40543
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040328B2 RID: 207026
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E60 RID: 40544
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_Cloud_WYQ_FunctionParams
		{
			// Token: 0x040328B3 RID: 207027
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
