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
	// Token: 0x02003CBB RID: 15547
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_XuanWo.BP_Cloud_XuanWo_C")]
	[UnrealStructLayout(1808, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1808)]
	public class BP_Cloud_XuanWo_C : BP_CloudPrefab_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024C6B RID: 150635 RVA: 0x009A796C File Offset: 0x009A5B6C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Cloud_XuanWo_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_XuanWo.BP_Cloud_XuanWo_C");
			}
			return BP_Cloud_XuanWo_C._ClassPtr;
		}

		// Token: 0x06024C6C RID: 150636 RVA: 0x009A7990 File Offset: 0x009A5B90
		public BP_Cloud_XuanWo_C() : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_XuanWo_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024C6D RID: 150637 RVA: 0x009A79B8 File Offset: 0x009A5BB8
		[NullableContext(1)]
		public BP_Cloud_XuanWo_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_XuanWo_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004DE1 RID: 19937
		// (get) Token: 0x06024C6E RID: 150638 RVA: 0x009A79EC File Offset: 0x009A5BEC
		// (set) Token: 0x06024C6F RID: 150639 RVA: 0x009A7A25 File Offset: 0x009A5C25
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Cloud_XuanWo_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Cloud_XuanWo_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06024C70 RID: 150640 RVA: 0x009A7A48 File Offset: 0x009A5C48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Hidden(bool InstantHide)
		{
			BP_Cloud_XuanWo_C.__Hidden_FunctionParams* ptr = stackalloc BP_Cloud_XuanWo_C.__Hidden_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Cloud_XuanWo_C.__Hidden_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_XuanWo_C.__Hidden_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InstantHide = InstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_XuanWo_C.__Hidden_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C71 RID: 150641 RVA: 0x009A7A90 File Offset: 0x009A5C90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Active(bool bInstantHide)
		{
			BP_Cloud_XuanWo_C.__Active_FunctionParams* ptr = stackalloc BP_Cloud_XuanWo_C.__Active_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Cloud_XuanWo_C.__Active_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_XuanWo_C.__Active_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bInstantHide = bInstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_XuanWo_C.__Active_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C72 RID: 150642 RVA: 0x009A7AD6 File Offset: 0x009A5CD6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_XuanWo_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024C73 RID: 150643 RVA: 0x009A7AEA File Offset: 0x009A5CEA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_XuanWo_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024C74 RID: 150644 RVA: 0x009A7B00 File Offset: 0x009A5D00
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Cloud_XuanWo_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_XuanWo_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_XuanWo_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_XuanWo_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_XuanWo_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C75 RID: 150645 RVA: 0x009A7B48 File Offset: 0x009A5D48
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_XuanWo_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_XuanWo_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_XuanWo_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_XuanWo_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_XuanWo_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C76 RID: 150646 RVA: 0x009A7B90 File Offset: 0x009A5D90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Cloud_XuanWo_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_XuanWo_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_XuanWo_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_XuanWo_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_XuanWo_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C77 RID: 150647 RVA: 0x009A7BD8 File Offset: 0x009A5DD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_XuanWo_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_XuanWo_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_XuanWo_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_XuanWo_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_XuanWo_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C78 RID: 150648 RVA: 0x009A7C20 File Offset: 0x009A5E20
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Cloud_XuanWo(int EntryPoint)
		{
			BP_Cloud_XuanWo_C.__ExecuteUbergraph_BP_Cloud_XuanWo_FunctionParams* ptr = stackalloc BP_Cloud_XuanWo_C.__ExecuteUbergraph_BP_Cloud_XuanWo_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_Cloud_XuanWo_C.__ExecuteUbergraph_BP_Cloud_XuanWo_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_XuanWo_C.__ExecuteUbergraph_BP_Cloud_XuanWo_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_XuanWo_C.__ExecuteUbergraph_BP_Cloud_XuanWo_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C79 RID: 150649 RVA: 0x009A7C67 File Offset: 0x009A5E67
		protected BP_Cloud_XuanWo_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012DD7 RID: 77271
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_XuanWo.BP_Cloud_XuanWo_C";

		// Token: 0x04012DD8 RID: 77272
		private static IntPtr _ClassPtr;

		// Token: 0x04012DD9 RID: 77273
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012DDA RID: 77274
		internal new static int __PropertyOffset_0;

		// Token: 0x04012DDB RID: 77275
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012DDC RID: 77276
		private static IntPtr __Hidden_NativeFunctionPtr;

		// Token: 0x04012DDD RID: 77277
		private static IntPtr __Active_NativeFunctionPtr;

		// Token: 0x04012DDE RID: 77278
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012DDF RID: 77279
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012DE0 RID: 77280
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012DE1 RID: 77281
		private static IntPtr __ExecuteUbergraph_BP_Cloud_XuanWo_NativeFunctionPtr;

		// Token: 0x02009E61 RID: 40545
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __Hidden_FunctionParams
		{
			// Token: 0x040328B4 RID: 207028
			[FieldOffset(0)]
			public bool InstantHide;
		}

		// Token: 0x02009E62 RID: 40546
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __Active_FunctionParams
		{
			// Token: 0x040328B5 RID: 207029
			[FieldOffset(0)]
			public bool bInstantHide;
		}

		// Token: 0x02009E63 RID: 40547
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040328B6 RID: 207030
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E64 RID: 40548
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040328B7 RID: 207031
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E65 RID: 40549
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_Cloud_XuanWo_FunctionParams
		{
			// Token: 0x040328B8 RID: 207032
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
