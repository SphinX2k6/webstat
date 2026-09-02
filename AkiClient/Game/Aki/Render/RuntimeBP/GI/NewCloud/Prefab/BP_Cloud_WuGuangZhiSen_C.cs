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
	// Token: 0x02003CB9 RID: 15545
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_WuGuangZhiSen.BP_Cloud_WuGuangZhiSen_C")]
	[UnrealStructLayout(1808, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1808)]
	public class BP_Cloud_WuGuangZhiSen_C : BP_CloudPrefab_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024C4D RID: 150605 RVA: 0x009A7364 File Offset: 0x009A5564
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Cloud_WuGuangZhiSen_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_WuGuangZhiSen.BP_Cloud_WuGuangZhiSen_C");
			}
			return BP_Cloud_WuGuangZhiSen_C._ClassPtr;
		}

		// Token: 0x06024C4E RID: 150606 RVA: 0x009A7388 File Offset: 0x009A5588
		public BP_Cloud_WuGuangZhiSen_C() : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_WuGuangZhiSen_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024C4F RID: 150607 RVA: 0x009A73B0 File Offset: 0x009A55B0
		[NullableContext(1)]
		public BP_Cloud_WuGuangZhiSen_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_WuGuangZhiSen_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004DDF RID: 19935
		// (get) Token: 0x06024C50 RID: 150608 RVA: 0x009A73E4 File Offset: 0x009A55E4
		// (set) Token: 0x06024C51 RID: 150609 RVA: 0x009A741D File Offset: 0x009A561D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Cloud_WuGuangZhiSen_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Cloud_WuGuangZhiSen_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06024C52 RID: 150610 RVA: 0x009A7440 File Offset: 0x009A5640
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Hidden(bool InstantHide)
		{
			BP_Cloud_WuGuangZhiSen_C.__Hidden_FunctionParams* ptr = stackalloc BP_Cloud_WuGuangZhiSen_C.__Hidden_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Cloud_WuGuangZhiSen_C.__Hidden_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_WuGuangZhiSen_C.__Hidden_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InstantHide = InstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_WuGuangZhiSen_C.__Hidden_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C53 RID: 150611 RVA: 0x009A7488 File Offset: 0x009A5688
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Active(bool bInstantHide)
		{
			BP_Cloud_WuGuangZhiSen_C.__Active_FunctionParams* ptr = stackalloc BP_Cloud_WuGuangZhiSen_C.__Active_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Cloud_WuGuangZhiSen_C.__Active_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_WuGuangZhiSen_C.__Active_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bInstantHide = bInstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_WuGuangZhiSen_C.__Active_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C54 RID: 150612 RVA: 0x009A74CE File Offset: 0x009A56CE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_WuGuangZhiSen_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024C55 RID: 150613 RVA: 0x009A74E2 File Offset: 0x009A56E2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_WuGuangZhiSen_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024C56 RID: 150614 RVA: 0x009A74F8 File Offset: 0x009A56F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Cloud_WuGuangZhiSen_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_WuGuangZhiSen_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_WuGuangZhiSen_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_WuGuangZhiSen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_WuGuangZhiSen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C57 RID: 150615 RVA: 0x009A7540 File Offset: 0x009A5740
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_WuGuangZhiSen_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_WuGuangZhiSen_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_WuGuangZhiSen_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_WuGuangZhiSen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_WuGuangZhiSen_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C58 RID: 150616 RVA: 0x009A7588 File Offset: 0x009A5788
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Cloud_WuGuangZhiSen_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_WuGuangZhiSen_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_WuGuangZhiSen_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_WuGuangZhiSen_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_WuGuangZhiSen_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C59 RID: 150617 RVA: 0x009A75D0 File Offset: 0x009A57D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_WuGuangZhiSen_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_WuGuangZhiSen_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_WuGuangZhiSen_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_WuGuangZhiSen_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_WuGuangZhiSen_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C5A RID: 150618 RVA: 0x009A7618 File Offset: 0x009A5818
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Cloud_WuGuangZhiSen(int EntryPoint)
		{
			BP_Cloud_WuGuangZhiSen_C.__ExecuteUbergraph_BP_Cloud_WuGuangZhiSen_FunctionParams* ptr = stackalloc BP_Cloud_WuGuangZhiSen_C.__ExecuteUbergraph_BP_Cloud_WuGuangZhiSen_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_Cloud_WuGuangZhiSen_C.__ExecuteUbergraph_BP_Cloud_WuGuangZhiSen_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_WuGuangZhiSen_C.__ExecuteUbergraph_BP_Cloud_WuGuangZhiSen_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_WuGuangZhiSen_C.__ExecuteUbergraph_BP_Cloud_WuGuangZhiSen_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C5B RID: 150619 RVA: 0x009A765F File Offset: 0x009A585F
		protected BP_Cloud_WuGuangZhiSen_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012DC1 RID: 77249
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_WuGuangZhiSen.BP_Cloud_WuGuangZhiSen_C";

		// Token: 0x04012DC2 RID: 77250
		private static IntPtr _ClassPtr;

		// Token: 0x04012DC3 RID: 77251
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012DC4 RID: 77252
		internal new static int __PropertyOffset_0;

		// Token: 0x04012DC5 RID: 77253
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012DC6 RID: 77254
		private static IntPtr __Hidden_NativeFunctionPtr;

		// Token: 0x04012DC7 RID: 77255
		private static IntPtr __Active_NativeFunctionPtr;

		// Token: 0x04012DC8 RID: 77256
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012DC9 RID: 77257
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012DCA RID: 77258
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012DCB RID: 77259
		private static IntPtr __ExecuteUbergraph_BP_Cloud_WuGuangZhiSen_NativeFunctionPtr;

		// Token: 0x02009E57 RID: 40535
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __Hidden_FunctionParams
		{
			// Token: 0x040328AA RID: 207018
			[FieldOffset(0)]
			public bool InstantHide;
		}

		// Token: 0x02009E58 RID: 40536
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __Active_FunctionParams
		{
			// Token: 0x040328AB RID: 207019
			[FieldOffset(0)]
			public bool bInstantHide;
		}

		// Token: 0x02009E59 RID: 40537
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040328AC RID: 207020
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E5A RID: 40538
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040328AD RID: 207021
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E5B RID: 40539
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_Cloud_WuGuangZhiSen_FunctionParams
		{
			// Token: 0x040328AE RID: 207022
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
