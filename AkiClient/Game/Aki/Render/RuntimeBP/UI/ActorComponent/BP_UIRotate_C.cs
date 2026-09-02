using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UI.ActorComponent
{
	// Token: 0x02003A25 RID: 14885
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/UI/ActorComponent/BP_UIRotate.BP_UIRotate_C")]
	[UnrealStructLayout(272, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 272)]
	public class BP_UIRotate_C : UActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E9D3 RID: 125395 RVA: 0x008F98EF File Offset: 0x008F7AEF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_UIRotate_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/UI/ActorComponent/BP_UIRotate.BP_UIRotate_C");
			}
			return BP_UIRotate_C._ClassPtr;
		}

		// Token: 0x0601E9D4 RID: 125396 RVA: 0x008F9914 File Offset: 0x008F7B14
		public BP_UIRotate_C() : this(BuiltinUtils.AllocNativeUObject(BP_UIRotate_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E9D5 RID: 125397 RVA: 0x008F993C File Offset: 0x008F7B3C
		[NullableContext(1)]
		public BP_UIRotate_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_UIRotate_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002B85 RID: 11141
		// (get) Token: 0x0601E9D6 RID: 125398 RVA: 0x008F9970 File Offset: 0x008F7B70
		// (set) Token: 0x0601E9D7 RID: 125399 RVA: 0x008F99A9 File Offset: 0x008F7BA9
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_UIRotate_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_UIRotate_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002B86 RID: 11142
		// (get) Token: 0x0601E9D8 RID: 125400 RVA: 0x008F99CA File Offset: 0x008F7BCA
		// (set) Token: 0x0601E9D9 RID: 125401 RVA: 0x008F99DE File Offset: 0x008F7BDE
		public unsafe FVector2D ScaleXY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIRotate_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIRotate_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17002B87 RID: 11143
		// (get) Token: 0x0601E9DA RID: 125402 RVA: 0x008F99F3 File Offset: 0x008F7BF3
		// (set) Token: 0x0601E9DB RID: 125403 RVA: 0x008F9A03 File Offset: 0x008F7C03
		public unsafe float LerpSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIRotate_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIRotate_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17002B88 RID: 11144
		// (get) Token: 0x0601E9DC RID: 125404 RVA: 0x008F9A14 File Offset: 0x008F7C14
		// (set) Token: 0x0601E9DD RID: 125405 RVA: 0x008F9A24 File Offset: 0x008F7C24
		public unsafe float IdleLerpSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIRotate_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIRotate_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002B89 RID: 11145
		// (get) Token: 0x0601E9DE RID: 125406 RVA: 0x008F9A35 File Offset: 0x008F7C35
		// (set) Token: 0x0601E9DF RID: 125407 RVA: 0x008F9A49 File Offset: 0x008F7C49
		public unsafe FVector2D VittualMousePos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIRotate_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIRotate_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17002B8A RID: 11146
		// (get) Token: 0x0601E9E0 RID: 125408 RVA: 0x008F9A5E File Offset: 0x008F7C5E
		// (set) Token: 0x0601E9E1 RID: 125409 RVA: 0x008F9A6E File Offset: 0x008F7C6E
		public unsafe bool MobilePlatform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIRotate_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIRotate_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002B8B RID: 11147
		// (get) Token: 0x0601E9E2 RID: 125410 RVA: 0x008F9A7F File Offset: 0x008F7C7F
		// (set) Token: 0x0601E9E3 RID: 125411 RVA: 0x008F9A8F File Offset: 0x008F7C8F
		public unsafe float MobileSmoothLerp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIRotate_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIRotate_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17002B8C RID: 11148
		// (get) Token: 0x0601E9E4 RID: 125412 RVA: 0x008F9AA0 File Offset: 0x008F7CA0
		// (set) Token: 0x0601E9E5 RID: 125413 RVA: 0x008F9AB0 File Offset: 0x008F7CB0
		public unsafe float MobileOffsetFactor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIRotate_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIRotate_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17002B8D RID: 11149
		// (get) Token: 0x0601E9E6 RID: 125414 RVA: 0x008F9AC1 File Offset: 0x008F7CC1
		// (set) Token: 0x0601E9E7 RID: 125415 RVA: 0x008F9AD5 File Offset: 0x008F7CD5
		public unsafe FRotator InitRotateRecord
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIRotate_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIRotate_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17002B8E RID: 11150
		// (get) Token: 0x0601E9E8 RID: 125416 RVA: 0x008F9AEA File Offset: 0x008F7CEA
		// (set) Token: 0x0601E9E9 RID: 125417 RVA: 0x008F9AFE File Offset: 0x008F7CFE
		[Nullable(2)]
		public unsafe UUIItem UIItemCache
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UUIItem>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIRotate_C.__PropertyOffset_9);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIRotate_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x0601E9EA RID: 125418 RVA: 0x008F9B14 File Offset: 0x008F7D14
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void LrepVirtualMousePos(FVector2D NewPos, float DeltaSecond, ref FVector2D Output_Get)
		{
			BP_UIRotate_C.__LrepVirtualMousePos_FunctionParams* ptr = stackalloc BP_UIRotate_C.__LrepVirtualMousePos_FunctionParams[(UIntPtr)67] + 15L / (long)sizeof(BP_UIRotate_C.__LrepVirtualMousePos_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UIRotate_C.__LrepVirtualMousePos_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NewPos = NewPos;
			ptr->DeltaSecond = DeltaSecond;
			ptr->Output_Get = Output_Get;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UIRotate_C.__LrepVirtualMousePos_NativeFunctionPtr, (void*)ptr);
			Output_Get = ptr->Output_Get;
		}

		// Token: 0x0601E9EB RID: 125419 RVA: 0x008F9B79 File Offset: 0x008F7D79
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdatePlatform()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UIRotate_C.__UpdatePlatform_NativeFunctionPtr, null);
		}

		// Token: 0x0601E9EC RID: 125420 RVA: 0x008F9B90 File Offset: 0x008F7D90
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetOffset(float DeltaSecond, ref FVector2D NewParam)
		{
			BP_UIRotate_C.__GetOffset_FunctionParams* ptr = stackalloc BP_UIRotate_C.__GetOffset_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_UIRotate_C.__GetOffset_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UIRotate_C.__GetOffset_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSecond = DeltaSecond;
			ptr->NewParam = NewParam;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UIRotate_C.__GetOffset_NativeFunctionPtr, (void*)ptr);
			NewParam = ptr->NewParam;
		}

		// Token: 0x0601E9ED RID: 125421 RVA: 0x008F9BF4 File Offset: 0x008F7DF4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetMouseViewportPos(ref FVector2D NewParam)
		{
			BP_UIRotate_C.__GetMouseViewportPos_FunctionParams* ptr = stackalloc BP_UIRotate_C.__GetMouseViewportPos_FunctionParams[(UIntPtr)143] + 15L / (long)sizeof(BP_UIRotate_C.__GetMouseViewportPos_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UIRotate_C.__GetMouseViewportPos_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NewParam = NewParam;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UIRotate_C.__GetMouseViewportPos_NativeFunctionPtr, (void*)ptr);
			NewParam = ptr->NewParam;
		}

		// Token: 0x0601E9EE RID: 125422 RVA: 0x008F9C50 File Offset: 0x008F7E50
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_UIRotate_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_UIRotate_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_UIRotate_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UIRotate_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UIRotate_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601E9EF RID: 125423 RVA: 0x008F9C98 File Offset: 0x008F7E98
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_UIRotate_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_UIRotate_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_UIRotate_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UIRotate_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_UIRotate_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E9F0 RID: 125424 RVA: 0x008F9CDF File Offset: 0x008F7EDF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UIRotate_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601E9F1 RID: 125425 RVA: 0x008F9CF3 File Offset: 0x008F7EF3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_UIRotate_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E9F2 RID: 125426 RVA: 0x008F9D08 File Offset: 0x008F7F08
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_UIRotate(int EntryPoint)
		{
			BP_UIRotate_C.__ExecuteUbergraph_BP_UIRotate_FunctionParams* ptr = stackalloc BP_UIRotate_C.__ExecuteUbergraph_BP_UIRotate_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(BP_UIRotate_C.__ExecuteUbergraph_BP_UIRotate_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_UIRotate_C.__ExecuteUbergraph_BP_UIRotate_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_UIRotate_C.__ExecuteUbergraph_BP_UIRotate_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601E9F3 RID: 125427 RVA: 0x008F9D4F File Offset: 0x008F7F4F
		protected BP_UIRotate_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F17F RID: 61823
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/UI/ActorComponent/BP_UIRotate.BP_UIRotate_C";

		// Token: 0x0400F180 RID: 61824
		private static IntPtr _ClassPtr;

		// Token: 0x0400F181 RID: 61825
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F182 RID: 61826
		internal static int __PropertyOffset_0;

		// Token: 0x0400F183 RID: 61827
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F184 RID: 61828
		internal static int __PropertyOffset_1;

		// Token: 0x0400F185 RID: 61829
		internal static int __PropertyOffset_2;

		// Token: 0x0400F186 RID: 61830
		internal static int __PropertyOffset_3;

		// Token: 0x0400F187 RID: 61831
		internal static int __PropertyOffset_4;

		// Token: 0x0400F188 RID: 61832
		internal static int __PropertyOffset_5;

		// Token: 0x0400F189 RID: 61833
		internal static int __PropertyOffset_6;

		// Token: 0x0400F18A RID: 61834
		internal static int __PropertyOffset_7;

		// Token: 0x0400F18B RID: 61835
		internal static int __PropertyOffset_8;

		// Token: 0x0400F18C RID: 61836
		internal static int __PropertyOffset_9;

		// Token: 0x0400F18D RID: 61837
		private static IntPtr __LrepVirtualMousePos_NativeFunctionPtr;

		// Token: 0x0400F18E RID: 61838
		private static IntPtr __UpdatePlatform_NativeFunctionPtr;

		// Token: 0x0400F18F RID: 61839
		private static IntPtr __GetOffset_NativeFunctionPtr;

		// Token: 0x0400F190 RID: 61840
		private static IntPtr __GetMouseViewportPos_NativeFunctionPtr;

		// Token: 0x0400F191 RID: 61841
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F192 RID: 61842
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F193 RID: 61843
		private static IntPtr __ExecuteUbergraph_BP_UIRotate_NativeFunctionPtr;

		// Token: 0x020097D1 RID: 38865
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 52)]
		protected ref struct __LrepVirtualMousePos_FunctionParams
		{
			// Token: 0x04031DBA RID: 204218
			[FieldOffset(0)]
			public FVector2D NewPos;

			// Token: 0x04031DBB RID: 204219
			[FieldOffset(8)]
			public float DeltaSecond;

			// Token: 0x04031DBC RID: 204220
			[FieldOffset(12)]
			public FVector2D Output_Get;
		}

		// Token: 0x020097D2 RID: 38866
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __GetOffset_FunctionParams
		{
			// Token: 0x04031DBD RID: 204221
			[FieldOffset(0)]
			public float DeltaSecond;

			// Token: 0x04031DBE RID: 204222
			[FieldOffset(4)]
			public FVector2D NewParam;
		}

		// Token: 0x020097D3 RID: 38867
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 128)]
		protected ref struct __GetMouseViewportPos_FunctionParams
		{
			// Token: 0x04031DBF RID: 204223
			[FieldOffset(0)]
			public FVector2D NewParam;
		}

		// Token: 0x020097D4 RID: 38868
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031DC0 RID: 204224
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x020097D5 RID: 38869
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected ref struct __ExecuteUbergraph_BP_UIRotate_FunctionParams
		{
			// Token: 0x04031DC1 RID: 204225
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
