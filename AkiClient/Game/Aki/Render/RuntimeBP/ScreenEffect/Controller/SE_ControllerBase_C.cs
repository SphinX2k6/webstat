using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Controller
{
	// Token: 0x02003A6E RID: 14958
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/ScreenEffect/Controller/SE_ControllerBase.SE_ControllerBase_C")]
	[UnrealStructLayout(216, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 216)]
	public class SE_ControllerBase_C : UActorComponent, IUnrealUObject, IUnrealObject, ISE_ControllerInterface_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x0601F2E9 RID: 127721 RVA: 0x0090A387 File Offset: 0x00908587
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (SE_ControllerBase_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/ScreenEffect/Controller/SE_ControllerBase.SE_ControllerBase_C");
			}
			return SE_ControllerBase_C._ClassPtr;
		}

		// Token: 0x0601F2EA RID: 127722 RVA: 0x0090A3AC File Offset: 0x009085AC
		public SE_ControllerBase_C() : this(BuiltinUtils.AllocNativeUObject(SE_ControllerBase_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F2EB RID: 127723 RVA: 0x0090A3D4 File Offset: 0x009085D4
		[NullableContext(1)]
		public SE_ControllerBase_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SE_ControllerBase_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002E7E RID: 11902
		// (get) Token: 0x0601F2EC RID: 127724 RVA: 0x0090A408 File Offset: 0x00908608
		// (set) Token: 0x0601F2ED RID: 127725 RVA: 0x0090A441 File Offset: 0x00908641
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)SE_ControllerBase_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)SE_ControllerBase_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0601F2EE RID: 127726 RVA: 0x0090A464 File Offset: 0x00908664
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ApplyVisibility(bool visibility)
		{
			SE_ControllerBase_C.__ApplyVisibility_FunctionParams* ptr = stackalloc SE_ControllerBase_C.__ApplyVisibility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(SE_ControllerBase_C.__ApplyVisibility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_ControllerBase_C.__ApplyVisibility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->visibility = visibility;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_ControllerBase_C.__ApplyVisibility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F2EF RID: 127727 RVA: 0x0090A4AA File Offset: 0x009086AA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BeforeStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_ControllerBase_C.__BeforeStart_NativeFunctionPtr, null);
		}

		// Token: 0x0601F2F0 RID: 127728 RVA: 0x0090A4C0 File Offset: 0x009086C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			SE_ControllerBase_C.__ReceiveTick_FunctionParams* ptr = stackalloc SE_ControllerBase_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_ControllerBase_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_ControllerBase_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_ControllerBase_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F2F1 RID: 127729 RVA: 0x0090A508 File Offset: 0x00908708
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			SE_ControllerBase_C.__ReceiveTick_FunctionParams* ptr = stackalloc SE_ControllerBase_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_ControllerBase_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_ControllerBase_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, SE_ControllerBase_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F2F2 RID: 127730 RVA: 0x0090A550 File Offset: 0x00908750
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void End(float time)
		{
			SE_ControllerBase_C.__End_FunctionParams* ptr = stackalloc SE_ControllerBase_C.__End_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_ControllerBase_C.__End_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_ControllerBase_C.__End_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_ControllerBase_C.__End_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F2F3 RID: 127731 RVA: 0x0090A598 File Offset: 0x00908798
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Start(float time)
		{
			SE_ControllerBase_C.__Start_FunctionParams* ptr = stackalloc SE_ControllerBase_C.__Start_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_ControllerBase_C.__Start_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_ControllerBase_C.__Start_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_ControllerBase_C.__Start_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F2F4 RID: 127732 RVA: 0x0090A5E0 File Offset: 0x009087E0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void Loop(float time)
		{
			SE_ControllerBase_C.__Loop_FunctionParams* ptr = stackalloc SE_ControllerBase_C.__Loop_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_ControllerBase_C.__Loop_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_ControllerBase_C.__Loop_NativeFunctionPtr, (void*)ptr, 1);
			ptr->time = time;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_ControllerBase_C.__Loop_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F2F5 RID: 127733 RVA: 0x0090A628 File Offset: 0x00908828
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ApplyAlpha(float alpha)
		{
			SE_ControllerBase_C.__ApplyAlpha_FunctionParams* ptr = stackalloc SE_ControllerBase_C.__ApplyAlpha_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_ControllerBase_C.__ApplyAlpha_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_ControllerBase_C.__ApplyAlpha_NativeFunctionPtr, (void*)ptr, 1);
			ptr->alpha = alpha;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_ControllerBase_C.__ApplyAlpha_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F2F6 RID: 127734 RVA: 0x0090A670 File Offset: 0x00908870
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ApplyEnvironmentFactor(float EnvironmentFactor)
		{
			SE_ControllerBase_C.__ApplyEnvironmentFactor_FunctionParams* ptr = stackalloc SE_ControllerBase_C.__ApplyEnvironmentFactor_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(SE_ControllerBase_C.__ApplyEnvironmentFactor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_ControllerBase_C.__ApplyEnvironmentFactor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EnvironmentFactor = EnvironmentFactor;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_ControllerBase_C.__ApplyEnvironmentFactor_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F2F7 RID: 127735 RVA: 0x0090A6B8 File Offset: 0x009088B8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_SE_ControllerBase(int EntryPoint)
		{
			SE_ControllerBase_C.__ExecuteUbergraph_SE_ControllerBase_FunctionParams* ptr = stackalloc SE_ControllerBase_C.__ExecuteUbergraph_SE_ControllerBase_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(SE_ControllerBase_C.__ExecuteUbergraph_SE_ControllerBase_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_ControllerBase_C.__ExecuteUbergraph_SE_ControllerBase_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, SE_ControllerBase_C.__ExecuteUbergraph_SE_ControllerBase_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F2F8 RID: 127736 RVA: 0x0090A6FF File Offset: 0x009088FF
		protected SE_ControllerBase_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F749 RID: 63305
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/ScreenEffect/Controller/SE_ControllerBase.SE_ControllerBase_C";

		// Token: 0x0400F74A RID: 63306
		private static IntPtr _ClassPtr;

		// Token: 0x0400F74B RID: 63307
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F74C RID: 63308
		internal static int __PropertyOffset_0;

		// Token: 0x0400F74D RID: 63309
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F74E RID: 63310
		private static IntPtr __ApplyVisibility_NativeFunctionPtr;

		// Token: 0x0400F74F RID: 63311
		private static IntPtr __BeforeStart_NativeFunctionPtr;

		// Token: 0x0400F750 RID: 63312
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F751 RID: 63313
		private static IntPtr __End_NativeFunctionPtr;

		// Token: 0x0400F752 RID: 63314
		private static IntPtr __Start_NativeFunctionPtr;

		// Token: 0x0400F753 RID: 63315
		private static IntPtr __Loop_NativeFunctionPtr;

		// Token: 0x0400F754 RID: 63316
		private static IntPtr __ApplyAlpha_NativeFunctionPtr;

		// Token: 0x0400F755 RID: 63317
		private static IntPtr __ApplyEnvironmentFactor_NativeFunctionPtr;

		// Token: 0x0400F756 RID: 63318
		private static IntPtr __ExecuteUbergraph_SE_ControllerBase_NativeFunctionPtr;

		// Token: 0x02009883 RID: 39043
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __ApplyVisibility_FunctionParams
		{
			// Token: 0x04031EC7 RID: 204487
			[FieldOffset(0)]
			public bool visibility;
		}

		// Token: 0x02009884 RID: 39044
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031EC8 RID: 204488
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009885 RID: 39045
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __End_FunctionParams
		{
			// Token: 0x04031EC9 RID: 204489
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x02009886 RID: 39046
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Start_FunctionParams
		{
			// Token: 0x04031ECA RID: 204490
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x02009887 RID: 39047
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __Loop_FunctionParams
		{
			// Token: 0x04031ECB RID: 204491
			[FieldOffset(0)]
			public float time;
		}

		// Token: 0x02009888 RID: 39048
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ApplyAlpha_FunctionParams
		{
			// Token: 0x04031ECC RID: 204492
			[FieldOffset(0)]
			public float alpha;
		}

		// Token: 0x02009889 RID: 39049
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ApplyEnvironmentFactor_FunctionParams
		{
			// Token: 0x04031ECD RID: 204493
			[FieldOffset(0)]
			public float EnvironmentFactor;
		}

		// Token: 0x0200988A RID: 39050
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __ExecuteUbergraph_SE_ControllerBase_FunctionParams
		{
			// Token: 0x04031ECE RID: 204494
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
