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
	// Token: 0x02003CBC RID: 15548
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_YiLuoYuanXiang.BP_Cloud_YiLuoYuanXiang_C")]
	[UnrealStructLayout(1808, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1808)]
	public class BP_Cloud_YiLuoYuanXiang_C : BP_CloudPrefab_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024C7A RID: 150650 RVA: 0x009A7C70 File Offset: 0x009A5E70
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Cloud_YiLuoYuanXiang_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_YiLuoYuanXiang.BP_Cloud_YiLuoYuanXiang_C");
			}
			return BP_Cloud_YiLuoYuanXiang_C._ClassPtr;
		}

		// Token: 0x06024C7B RID: 150651 RVA: 0x009A7C94 File Offset: 0x009A5E94
		public BP_Cloud_YiLuoYuanXiang_C() : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_YiLuoYuanXiang_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024C7C RID: 150652 RVA: 0x009A7CBC File Offset: 0x009A5EBC
		[NullableContext(1)]
		public BP_Cloud_YiLuoYuanXiang_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_YiLuoYuanXiang_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004DE2 RID: 19938
		// (get) Token: 0x06024C7D RID: 150653 RVA: 0x009A7CF0 File Offset: 0x009A5EF0
		// (set) Token: 0x06024C7E RID: 150654 RVA: 0x009A7D29 File Offset: 0x009A5F29
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Cloud_YiLuoYuanXiang_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Cloud_YiLuoYuanXiang_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06024C7F RID: 150655 RVA: 0x009A7D4A File Offset: 0x009A5F4A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_YiLuoYuanXiang_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024C80 RID: 150656 RVA: 0x009A7D5E File Offset: 0x009A5F5E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_YiLuoYuanXiang_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024C81 RID: 150657 RVA: 0x009A7D74 File Offset: 0x009A5F74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Cloud_YiLuoYuanXiang_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_YiLuoYuanXiang_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_YiLuoYuanXiang_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_YiLuoYuanXiang_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_YiLuoYuanXiang_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C82 RID: 150658 RVA: 0x009A7DBC File Offset: 0x009A5FBC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_YiLuoYuanXiang_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_YiLuoYuanXiang_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_YiLuoYuanXiang_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_YiLuoYuanXiang_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_YiLuoYuanXiang_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C83 RID: 150659 RVA: 0x009A7E04 File Offset: 0x009A6004
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Cloud_YiLuoYuanXiang_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_YiLuoYuanXiang_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_YiLuoYuanXiang_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_YiLuoYuanXiang_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_YiLuoYuanXiang_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C84 RID: 150660 RVA: 0x009A7E4C File Offset: 0x009A604C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_YiLuoYuanXiang_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_YiLuoYuanXiang_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_YiLuoYuanXiang_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_YiLuoYuanXiang_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_YiLuoYuanXiang_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C85 RID: 150661 RVA: 0x009A7E94 File Offset: 0x009A6094
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Cloud_YiLuoYuanXiang(int EntryPoint)
		{
			BP_Cloud_YiLuoYuanXiang_C.__ExecuteUbergraph_BP_Cloud_YiLuoYuanXiang_FunctionParams* ptr = stackalloc BP_Cloud_YiLuoYuanXiang_C.__ExecuteUbergraph_BP_Cloud_YiLuoYuanXiang_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_Cloud_YiLuoYuanXiang_C.__ExecuteUbergraph_BP_Cloud_YiLuoYuanXiang_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_YiLuoYuanXiang_C.__ExecuteUbergraph_BP_Cloud_YiLuoYuanXiang_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_YiLuoYuanXiang_C.__ExecuteUbergraph_BP_Cloud_YiLuoYuanXiang_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C86 RID: 150662 RVA: 0x009A7EDB File Offset: 0x009A60DB
		protected BP_Cloud_YiLuoYuanXiang_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012DE2 RID: 77282
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_YiLuoYuanXiang.BP_Cloud_YiLuoYuanXiang_C";

		// Token: 0x04012DE3 RID: 77283
		private static IntPtr _ClassPtr;

		// Token: 0x04012DE4 RID: 77284
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012DE5 RID: 77285
		internal new static int __PropertyOffset_0;

		// Token: 0x04012DE6 RID: 77286
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012DE7 RID: 77287
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012DE8 RID: 77288
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012DE9 RID: 77289
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012DEA RID: 77290
		private static IntPtr __ExecuteUbergraph_BP_Cloud_YiLuoYuanXiang_NativeFunctionPtr;

		// Token: 0x02009E66 RID: 40550
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040328B9 RID: 207033
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E67 RID: 40551
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040328BA RID: 207034
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E68 RID: 40552
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_Cloud_YiLuoYuanXiang_FunctionParams
		{
			// Token: 0x040328BB RID: 207035
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
