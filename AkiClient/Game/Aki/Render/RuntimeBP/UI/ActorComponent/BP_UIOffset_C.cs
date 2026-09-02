using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UI.ActorComponent
{
	// Token: 0x02003A24 RID: 14884
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/UI/ActorComponent/BP_UIOffset.BP_UIOffset_C")]
	[UnrealStructLayout(288, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 284)]
	public class BP_UIOffset_C : UActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E9B2 RID: 125362 RVA: 0x008F9443 File Offset: 0x008F7643
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_UIOffset_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/UI/ActorComponent/BP_UIOffset.BP_UIOffset_C");
			}
			return BP_UIOffset_C._ClassPtr;
		}

		// Token: 0x0601E9B3 RID: 125363 RVA: 0x008F9468 File Offset: 0x008F7668
		public BP_UIOffset_C() : this(BuiltinUtils.AllocNativeUObject(BP_UIOffset_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E9B4 RID: 125364 RVA: 0x008F9490 File Offset: 0x008F7690
		public BP_UIOffset_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_UIOffset_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002B7B RID: 11131
		// (get) Token: 0x0601E9B5 RID: 125365 RVA: 0x008F94C4 File Offset: 0x008F76C4
		// (set) Token: 0x0601E9B6 RID: 125366 RVA: 0x008F94FD File Offset: 0x008F76FD
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_UIOffset_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_UIOffset_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002B7C RID: 11132
		// (get) Token: 0x0601E9B7 RID: 125367 RVA: 0x008F9520 File Offset: 0x008F7720
		// (set) Token: 0x0601E9B8 RID: 125368 RVA: 0x008F9559 File Offset: 0x008F7759
		public TArray<S_UIitemOffset> ActorDistances
		{
			get
			{
				base.FastCheckIsValid();
				TArray<S_UIitemOffset> result;
				if ((result = this._ActorDistances) == null)
				{
					result = (this._ActorDistances = new TArray<S_UIitemOffset>(base.NativePtr + (IntPtr)BP_UIOffset_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.ActorDistances.CopyAssign(value);
			}
		}

		// Token: 0x17002B7D RID: 11133
		// (get) Token: 0x0601E9B9 RID: 125369 RVA: 0x008F9568 File Offset: 0x008F7768
		// (set) Token: 0x0601E9BA RID: 125370 RVA: 0x008F95A1 File Offset: 0x008F77A1
		public TArray<FVector2D> InitPosRecord
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector2D> result;
				if ((result = this._InitPosRecord) == null)
				{
					result = (this._InitPosRecord = new TArray<FVector2D>(base.NativePtr + (IntPtr)BP_UIOffset_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.InitPosRecord.CopyAssign(value);
			}
		}

		// Token: 0x17002B7E RID: 11134
		// (get) Token: 0x0601E9BB RID: 125371 RVA: 0x008F95AF File Offset: 0x008F77AF
		// (set) Token: 0x0601E9BC RID: 125372 RVA: 0x008F95C3 File Offset: 0x008F77C3
		public unsafe FVector2D ScaleXY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIOffset_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIOffset_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002B7F RID: 11135
		// (get) Token: 0x0601E9BD RID: 125373 RVA: 0x008F95D8 File Offset: 0x008F77D8
		// (set) Token: 0x0601E9BE RID: 125374 RVA: 0x008F95E8 File Offset: 0x008F77E8
		public unsafe float LerpSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIOffset_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIOffset_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17002B80 RID: 11136
		// (get) Token: 0x0601E9BF RID: 125375 RVA: 0x008F95F9 File Offset: 0x008F77F9
		// (set) Token: 0x0601E9C0 RID: 125376 RVA: 0x008F9609 File Offset: 0x008F7809
		public unsafe float IdleLerpSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIOffset_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIOffset_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002B81 RID: 11137
		// (get) Token: 0x0601E9C1 RID: 125377 RVA: 0x008F961A File Offset: 0x008F781A
		// (set) Token: 0x0601E9C2 RID: 125378 RVA: 0x008F962E File Offset: 0x008F782E
		public unsafe FVector2D VittualMousePos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIOffset_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIOffset_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002B82 RID: 11138
		// (get) Token: 0x0601E9C3 RID: 125379 RVA: 0x008F9643 File Offset: 0x008F7843
		// (set) Token: 0x0601E9C4 RID: 125380 RVA: 0x008F9653 File Offset: 0x008F7853
		public unsafe bool MobilePlatform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIOffset_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIOffset_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B83 RID: 11139
		// (get) Token: 0x0601E9C5 RID: 125381 RVA: 0x008F9664 File Offset: 0x008F7864
		// (set) Token: 0x0601E9C6 RID: 125382 RVA: 0x008F9674 File Offset: 0x008F7874
		public unsafe float MobileSmoothLerp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIOffset_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIOffset_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002B84 RID: 11140
		// (get) Token: 0x0601E9C7 RID: 125383 RVA: 0x008F9685 File Offset: 0x008F7885
		// (set) Token: 0x0601E9C8 RID: 125384 RVA: 0x008F9695 File Offset: 0x008F7895
		public unsafe float MobileOffsetFactor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIOffset_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIOffset_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x0601E9C9 RID: 125385 RVA: 0x008F96A8 File Offset: 0x008F78A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void LrepVirtualMousePos(FVector2D NewPos, float DeltaSecond, ref FVector2D Output_Get)
		{
			BP_UIOffset_C.__LrepVirtualMousePos_FunctionParams* ptr = stackalloc BP_UIOffset_C.__LrepVirtualMousePos_FunctionParams[(UIntPtr)67] + 15L / (long)sizeof(BP_UIOffset_C.__LrepVirtualMousePos_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UIOffset_C.__LrepVirtualMousePos_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NewPos = NewPos;
			ptr->DeltaSecond = DeltaSecond;
			ptr->Output_Get = Output_Get;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UIOffset_C.__LrepVirtualMousePos_NativeFunctionPtr, (void*)ptr);
			Output_Get = ptr->Output_Get;
		}

		// Token: 0x0601E9CA RID: 125386 RVA: 0x008F970D File Offset: 0x008F790D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdatePlatform()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UIOffset_C.__UpdatePlatform_NativeFunctionPtr, null);
		}

		// Token: 0x0601E9CB RID: 125387 RVA: 0x008F9724 File Offset: 0x008F7924
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetOffset(float DeltaSecond, ref FVector2D NewParam)
		{
			BP_UIOffset_C.__GetOffset_FunctionParams* ptr = stackalloc BP_UIOffset_C.__GetOffset_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_UIOffset_C.__GetOffset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UIOffset_C.__GetOffset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSecond = DeltaSecond;
			ptr->NewParam = NewParam;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UIOffset_C.__GetOffset_NativeFunctionPtr, (void*)ptr);
			NewParam = ptr->NewParam;
		}

		// Token: 0x0601E9CC RID: 125388 RVA: 0x008F9788 File Offset: 0x008F7988
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetMouseViewportPos(ref FVector2D NewParam)
		{
			BP_UIOffset_C.__GetMouseViewportPos_FunctionParams* ptr = stackalloc BP_UIOffset_C.__GetMouseViewportPos_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(BP_UIOffset_C.__GetMouseViewportPos_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UIOffset_C.__GetMouseViewportPos_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NewParam = NewParam;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UIOffset_C.__GetMouseViewportPos_NativeFunctionPtr, (void*)ptr);
			NewParam = ptr->NewParam;
		}

		// Token: 0x0601E9CD RID: 125389 RVA: 0x008F97E2 File Offset: 0x008F79E2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UIOffset_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E9CE RID: 125390 RVA: 0x008F97F6 File Offset: 0x008F79F6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_UIOffset_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E9CF RID: 125391 RVA: 0x008F980C File Offset: 0x008F7A0C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_UIOffset_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_UIOffset_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_UIOffset_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UIOffset_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UIOffset_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E9D0 RID: 125392 RVA: 0x008F9854 File Offset: 0x008F7A54
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_UIOffset_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_UIOffset_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_UIOffset_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UIOffset_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_UIOffset_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E9D1 RID: 125393 RVA: 0x008F989C File Offset: 0x008F7A9C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_UIOffset(int EntryPoint)
		{
			BP_UIOffset_C.__ExecuteUbergraph_BP_UIOffset_FunctionParams* ptr = stackalloc BP_UIOffset_C.__ExecuteUbergraph_BP_UIOffset_FunctionParams[(UIntPtr)167] + 15L / (long)sizeof(BP_UIOffset_C.__ExecuteUbergraph_BP_UIOffset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UIOffset_C.__ExecuteUbergraph_BP_UIOffset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_UIOffset_C.__ExecuteUbergraph_BP_UIOffset_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E9D2 RID: 125394 RVA: 0x008F98E6 File Offset: 0x008F7AE6
		protected BP_UIOffset_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F168 RID: 61800
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/UI/ActorComponent/BP_UIOffset.BP_UIOffset_C";

		// Token: 0x0400F169 RID: 61801
		private static IntPtr _ClassPtr;

		// Token: 0x0400F16A RID: 61802
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F16B RID: 61803
		internal static int __PropertyOffset_0;

		// Token: 0x0400F16C RID: 61804
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F16D RID: 61805
		internal static int __PropertyOffset_1;

		// Token: 0x0400F16E RID: 61806
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<S_UIitemOffset> _ActorDistances;

		// Token: 0x0400F16F RID: 61807
		internal static int __PropertyOffset_2;

		// Token: 0x0400F170 RID: 61808
		[Nullable(2)]
		private TArray<FVector2D> _InitPosRecord;

		// Token: 0x0400F171 RID: 61809
		internal static int __PropertyOffset_3;

		// Token: 0x0400F172 RID: 61810
		internal static int __PropertyOffset_4;

		// Token: 0x0400F173 RID: 61811
		internal static int __PropertyOffset_5;

		// Token: 0x0400F174 RID: 61812
		internal static int __PropertyOffset_6;

		// Token: 0x0400F175 RID: 61813
		internal static int __PropertyOffset_7;

		// Token: 0x0400F176 RID: 61814
		internal static int __PropertyOffset_8;

		// Token: 0x0400F177 RID: 61815
		internal static int __PropertyOffset_9;

		// Token: 0x0400F178 RID: 61816
		private static IntPtr __LrepVirtualMousePos_NativeFunctionPtr;

		// Token: 0x0400F179 RID: 61817
		private static IntPtr __UpdatePlatform_NativeFunctionPtr;

		// Token: 0x0400F17A RID: 61818
		private static IntPtr __GetOffset_NativeFunctionPtr;

		// Token: 0x0400F17B RID: 61819
		private static IntPtr __GetMouseViewportPos_NativeFunctionPtr;

		// Token: 0x0400F17C RID: 61820
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F17D RID: 61821
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F17E RID: 61822
		private static IntPtr __ExecuteUbergraph_BP_UIOffset_NativeFunctionPtr;

		// Token: 0x020097CC RID: 38860
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 52)]
		protected ref struct __LrepVirtualMousePos_FunctionParams
		{
			// Token: 0x04031DB2 RID: 204210
			[FieldOffset(0)]
			public FVector2D NewPos;

			// Token: 0x04031DB3 RID: 204211
			[FieldOffset(8)]
			public float DeltaSecond;

			// Token: 0x04031DB4 RID: 204212
			[FieldOffset(12)]
			public FVector2D Output_Get;
		}

		// Token: 0x020097CD RID: 38861
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __GetOffset_FunctionParams
		{
			// Token: 0x04031DB5 RID: 204213
			[FieldOffset(0)]
			public float DeltaSecond;

			// Token: 0x04031DB6 RID: 204214
			[FieldOffset(4)]
			public FVector2D NewParam;
		}

		// Token: 0x020097CE RID: 38862
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __GetMouseViewportPos_FunctionParams
		{
			// Token: 0x04031DB7 RID: 204215
			[FieldOffset(0)]
			public FVector2D NewParam;
		}

		// Token: 0x020097CF RID: 38863
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031DB8 RID: 204216
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097D0 RID: 38864
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 152)]
		protected ref struct __ExecuteUbergraph_BP_UIOffset_FunctionParams
		{
			// Token: 0x04031DB9 RID: 204217
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
