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
	// Token: 0x02003CB8 RID: 15544
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_TianCheng.BP_Cloud_TianCheng_C")]
	[UnrealStructLayout(1808, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1808)]
	public class BP_Cloud_TianCheng_C : BP_CloudPrefab_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024C3E RID: 150590 RVA: 0x009A7060 File Offset: 0x009A5260
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Cloud_TianCheng_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_TianCheng.BP_Cloud_TianCheng_C");
			}
			return BP_Cloud_TianCheng_C._ClassPtr;
		}

		// Token: 0x06024C3F RID: 150591 RVA: 0x009A7084 File Offset: 0x009A5284
		public BP_Cloud_TianCheng_C() : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_TianCheng_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024C40 RID: 150592 RVA: 0x009A70AC File Offset: 0x009A52AC
		[NullableContext(1)]
		public BP_Cloud_TianCheng_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Cloud_TianCheng_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004DDE RID: 19934
		// (get) Token: 0x06024C41 RID: 150593 RVA: 0x009A70E0 File Offset: 0x009A52E0
		// (set) Token: 0x06024C42 RID: 150594 RVA: 0x009A7119 File Offset: 0x009A5319
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Cloud_TianCheng_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Cloud_TianCheng_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06024C43 RID: 150595 RVA: 0x009A713C File Offset: 0x009A533C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Hidden(bool InstantHide)
		{
			BP_Cloud_TianCheng_C.__Hidden_FunctionParams* ptr = stackalloc BP_Cloud_TianCheng_C.__Hidden_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Cloud_TianCheng_C.__Hidden_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_TianCheng_C.__Hidden_NativeFunctionPtr, (void*)ptr, 1);
			ptr->InstantHide = InstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_TianCheng_C.__Hidden_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C44 RID: 150596 RVA: 0x009A7184 File Offset: 0x009A5384
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void Active(bool bInstantHide)
		{
			BP_Cloud_TianCheng_C.__Active_FunctionParams* ptr = stackalloc BP_Cloud_TianCheng_C.__Active_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_Cloud_TianCheng_C.__Active_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_TianCheng_C.__Active_NativeFunctionPtr, (void*)ptr, 1);
			ptr->bInstantHide = bInstantHide;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_TianCheng_C.__Active_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C45 RID: 150597 RVA: 0x009A71CA File Offset: 0x009A53CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_TianCheng_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024C46 RID: 150598 RVA: 0x009A71DE File Offset: 0x009A53DE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_TianCheng_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024C47 RID: 150599 RVA: 0x009A71F4 File Offset: 0x009A53F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Cloud_TianCheng_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_TianCheng_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_TianCheng_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_TianCheng_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_TianCheng_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C48 RID: 150600 RVA: 0x009A723C File Offset: 0x009A543C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_TianCheng_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Cloud_TianCheng_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_TianCheng_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_TianCheng_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_TianCheng_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C49 RID: 150601 RVA: 0x009A7284 File Offset: 0x009A5484
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_Cloud_TianCheng_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_TianCheng_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_TianCheng_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_TianCheng_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Cloud_TianCheng_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06024C4A RID: 150602 RVA: 0x009A72CC File Offset: 0x009A54CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_Cloud_TianCheng_C.__EditorTick_FunctionParams* ptr = stackalloc BP_Cloud_TianCheng_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Cloud_TianCheng_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_TianCheng_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_TianCheng_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C4B RID: 150603 RVA: 0x009A7314 File Offset: 0x009A5514
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Cloud_TianCheng(int EntryPoint)
		{
			BP_Cloud_TianCheng_C.__ExecuteUbergraph_BP_Cloud_TianCheng_FunctionParams* ptr = stackalloc BP_Cloud_TianCheng_C.__ExecuteUbergraph_BP_Cloud_TianCheng_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_Cloud_TianCheng_C.__ExecuteUbergraph_BP_Cloud_TianCheng_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Cloud_TianCheng_C.__ExecuteUbergraph_BP_Cloud_TianCheng_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Cloud_TianCheng_C.__ExecuteUbergraph_BP_Cloud_TianCheng_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024C4C RID: 150604 RVA: 0x009A735B File Offset: 0x009A555B
		protected BP_Cloud_TianCheng_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012DB6 RID: 77238
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/Prefab/BP_Cloud_TianCheng.BP_Cloud_TianCheng_C";

		// Token: 0x04012DB7 RID: 77239
		private static IntPtr _ClassPtr;

		// Token: 0x04012DB8 RID: 77240
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012DB9 RID: 77241
		internal new static int __PropertyOffset_0;

		// Token: 0x04012DBA RID: 77242
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012DBB RID: 77243
		private static IntPtr __Hidden_NativeFunctionPtr;

		// Token: 0x04012DBC RID: 77244
		private static IntPtr __Active_NativeFunctionPtr;

		// Token: 0x04012DBD RID: 77245
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012DBE RID: 77246
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012DBF RID: 77247
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012DC0 RID: 77248
		private static IntPtr __ExecuteUbergraph_BP_Cloud_TianCheng_NativeFunctionPtr;

		// Token: 0x02009E52 RID: 40530
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __Hidden_FunctionParams
		{
			// Token: 0x040328A5 RID: 207013
			[FieldOffset(0)]
			public bool InstantHide;
		}

		// Token: 0x02009E53 RID: 40531
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __Active_FunctionParams
		{
			// Token: 0x040328A6 RID: 207014
			[FieldOffset(0)]
			public bool bInstantHide;
		}

		// Token: 0x02009E54 RID: 40532
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040328A7 RID: 207015
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E55 RID: 40533
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x040328A8 RID: 207016
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009E56 RID: 40534
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_Cloud_TianCheng_FunctionParams
		{
			// Token: 0x040328A9 RID: 207017
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
