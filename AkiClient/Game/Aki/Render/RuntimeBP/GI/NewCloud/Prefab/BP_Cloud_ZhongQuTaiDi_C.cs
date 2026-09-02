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
	// Token: 0x02003CBD RID: 15549
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_ZhongQuTaiDi.BP_Cloud_ZhongQuTaiDi_C")]
	[UnrealStructLayout(1808, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1808)]
	public class BP_Cloud_ZhongQuTaiDi_C : BP_CloudPrefab_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024C87 RID: 150663 RVA: 0x009A7EE4 File Offset: 0x009A60E4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Cloud_ZhongQuTaiDi_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_ZhongQuTaiDi.BP_Cloud_ZhongQuTaiDi_C");
			}
			return BP_Cloud_ZhongQuTaiDi_C._ClassPtr;
		}

		// Token: 0x06024C88 RID: 150664 RVA: 0x009A7F08 File Offset: 0x009A6108
		public BP_Cloud_ZhongQuTaiDi_C() : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_ZhongQuTaiDi_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024C89 RID: 150665 RVA: 0x009A7F30 File Offset: 0x009A6130
		[NullableContext(1)]
		public BP_Cloud_ZhongQuTaiDi_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_ZhongQuTaiDi_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004DE3 RID: 19939
		// (get) Token: 0x06024C8A RID: 150666 RVA: 0x009A7F64 File Offset: 0x009A6164
		// (set) Token: 0x06024C8B RID: 150667 RVA: 0x009A7F9D File Offset: 0x009A619D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Cloud_ZhongQuTaiDi_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Cloud_ZhongQuTaiDi_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06024C8C RID: 150668 RVA: 0x009A7FBE File Offset: 0x009A61BE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_ZhongQuTaiDi_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024C8D RID: 150669 RVA: 0x009A7FD2 File Offset: 0x009A61D2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_ZhongQuTaiDi_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024C8E RID: 150670 RVA: 0x009A7FE8 File Offset: 0x009A61E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Cloud_ZhongQuTaiDi_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_ZhongQuTaiDi_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_ZhongQuTaiDi_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_ZhongQuTaiDi_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_ZhongQuTaiDi_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C8F RID: 150671 RVA: 0x009A8030 File Offset: 0x009A6230
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_ZhongQuTaiDi_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_ZhongQuTaiDi_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_ZhongQuTaiDi_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_ZhongQuTaiDi_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_ZhongQuTaiDi_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C90 RID: 150672 RVA: 0x009A8078 File Offset: 0x009A6278
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Cloud_ZhongQuTaiDi_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_ZhongQuTaiDi_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_ZhongQuTaiDi_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_ZhongQuTaiDi_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_ZhongQuTaiDi_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C91 RID: 150673 RVA: 0x009A80C0 File Offset: 0x009A62C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_ZhongQuTaiDi_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_ZhongQuTaiDi_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_ZhongQuTaiDi_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_ZhongQuTaiDi_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_ZhongQuTaiDi_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C92 RID: 150674 RVA: 0x009A8108 File Offset: 0x009A6308
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Cloud_ZhongQuTaiDi(int EntryPoint)
		{
			BP_Cloud_ZhongQuTaiDi_C.__ExecuteUbergraph_BP_Cloud_ZhongQuTaiDi_FunctionParams* ptr = stackalloc BP_Cloud_ZhongQuTaiDi_C.__ExecuteUbergraph_BP_Cloud_ZhongQuTaiDi_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_Cloud_ZhongQuTaiDi_C.__ExecuteUbergraph_BP_Cloud_ZhongQuTaiDi_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_ZhongQuTaiDi_C.__ExecuteUbergraph_BP_Cloud_ZhongQuTaiDi_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_ZhongQuTaiDi_C.__ExecuteUbergraph_BP_Cloud_ZhongQuTaiDi_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C93 RID: 150675 RVA: 0x009A814F File Offset: 0x009A634F
		protected BP_Cloud_ZhongQuTaiDi_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012DEB RID: 77291
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_ZhongQuTaiDi.BP_Cloud_ZhongQuTaiDi_C";

		// Token: 0x04012DEC RID: 77292
		private static IntPtr _ClassPtr;

		// Token: 0x04012DED RID: 77293
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012DEE RID: 77294
		internal new static int __PropertyOffset_0;

		// Token: 0x04012DEF RID: 77295
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012DF0 RID: 77296
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012DF1 RID: 77297
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012DF2 RID: 77298
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012DF3 RID: 77299
		private static IntPtr __ExecuteUbergraph_BP_Cloud_ZhongQuTaiDi_NativeFunctionPtr;

		// Token: 0x02009E69 RID: 40553
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040328BC RID: 207036
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E6A RID: 40554
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040328BD RID: 207037
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E6B RID: 40555
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_Cloud_ZhongQuTaiDi_FunctionParams
		{
			// Token: 0x040328BE RID: 207038
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
