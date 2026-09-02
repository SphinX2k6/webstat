using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SnowCoverInteraction.BluePrints
{
	// Token: 0x02003A51 RID: 14929
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_MotorObjTrailActor.BP_MotorObjTrailActor_C")]
	[UnrealStructLayout(800, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 785)]
	public class BP_MotorObjTrailActor_C : BP_SnowTrailComponent_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EF14 RID: 126740 RVA: 0x00902CCB File Offset: 0x00900ECB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MotorObjTrailActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_MotorObjTrailActor.BP_MotorObjTrailActor_C");
			}
			return BP_MotorObjTrailActor_C._ClassPtr;
		}

		// Token: 0x0601EF15 RID: 126741 RVA: 0x00902CF0 File Offset: 0x00900EF0
		public BP_MotorObjTrailActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_MotorObjTrailActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EF16 RID: 126742 RVA: 0x00902D18 File Offset: 0x00900F18
		[NullableContext(1)]
		public BP_MotorObjTrailActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MotorObjTrailActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002D3F RID: 11583
		// (get) Token: 0x0601EF17 RID: 126743 RVA: 0x00902D4C File Offset: 0x00900F4C
		// (set) Token: 0x0601EF18 RID: 126744 RVA: 0x00902D85 File Offset: 0x00900F85
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_MotorObjTrailActor_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_MotorObjTrailActor_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002D40 RID: 11584
		// (get) Token: 0x0601EF19 RID: 126745 RVA: 0x00902DA6 File Offset: 0x00900FA6
		// (set) Token: 0x0601EF1A RID: 126746 RVA: 0x00902DB6 File Offset: 0x00900FB6
		public unsafe bool IsMoto
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_MotorObjTrailActor_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_MotorObjTrailActor_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601EF1B RID: 126747 RVA: 0x00902DC8 File Offset: 0x00900FC8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_MotorObjTrailActor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MotorObjTrailActor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MotorObjTrailActor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MotorObjTrailActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_MotorObjTrailActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EF1C RID: 126748 RVA: 0x00902E10 File Offset: 0x00901010
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_MotorObjTrailActor_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_MotorObjTrailActor_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_MotorObjTrailActor_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MotorObjTrailActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MotorObjTrailActor_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EF1D RID: 126749 RVA: 0x00902E58 File Offset: 0x00901058
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_MotorObjTrailActor(int EntryPoint)
		{
			BP_MotorObjTrailActor_C.__ExecuteUbergraph_BP_MotorObjTrailActor_FunctionParams* ptr = stackalloc BP_MotorObjTrailActor_C.__ExecuteUbergraph_BP_MotorObjTrailActor_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(BP_MotorObjTrailActor_C.__ExecuteUbergraph_BP_MotorObjTrailActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_MotorObjTrailActor_C.__ExecuteUbergraph_BP_MotorObjTrailActor_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_MotorObjTrailActor_C.__ExecuteUbergraph_BP_MotorObjTrailActor_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EF1E RID: 126750 RVA: 0x00902E9F File Offset: 0x0090109F
		protected BP_MotorObjTrailActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F4C8 RID: 62664
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_MotorObjTrailActor.BP_MotorObjTrailActor_C";

		// Token: 0x0400F4C9 RID: 62665
		private static IntPtr _ClassPtr;

		// Token: 0x0400F4CA RID: 62666
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F4CB RID: 62667
		internal new static int __PropertyOffset_0;

		// Token: 0x0400F4CC RID: 62668
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F4CD RID: 62669
		internal new static int __PropertyOffset_1;

		// Token: 0x0400F4CE RID: 62670
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F4CF RID: 62671
		private static IntPtr __ExecuteUbergraph_BP_MotorObjTrailActor_NativeFunctionPtr;

		// Token: 0x02009822 RID: 38946
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E41 RID: 204353
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009823 RID: 38947
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __ExecuteUbergraph_BP_MotorObjTrailActor_FunctionParams
		{
			// Token: 0x04031E42 RID: 204354
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
