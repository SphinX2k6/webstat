using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D06 RID: 15622
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaRelativeVelocityOffsetComponent.NinjaRelativeVelocityOffsetComponent_C")]
	[UnrealStructLayout(264, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 262)]
	public class NinjaRelativeVelocityOffsetComponent_C : UActorComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06025B95 RID: 154517 RVA: 0x009C308C File Offset: 0x009C128C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NinjaRelativeVelocityOffsetComponent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaRelativeVelocityOffsetComponent.NinjaRelativeVelocityOffsetComponent_C");
			}
			return NinjaRelativeVelocityOffsetComponent_C._ClassPtr;
		}

		// Token: 0x06025B96 RID: 154518 RVA: 0x009C30B0 File Offset: 0x009C12B0
		public NinjaRelativeVelocityOffsetComponent_C() : this(BuiltinUtils.AllocNativeUObject(NinjaRelativeVelocityOffsetComponent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06025B97 RID: 154519 RVA: 0x009C30D8 File Offset: 0x009C12D8
		[NullableContext(1)]
		public NinjaRelativeVelocityOffsetComponent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NinjaRelativeVelocityOffsetComponent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005378 RID: 21368
		// (get) Token: 0x06025B98 RID: 154520 RVA: 0x009C310C File Offset: 0x009C130C
		// (set) Token: 0x06025B99 RID: 154521 RVA: 0x009C3145 File Offset: 0x009C1345
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005379 RID: 21369
		// (get) Token: 0x06025B9A RID: 154522 RVA: 0x009C3166 File Offset: 0x009C1366
		// (set) Token: 0x06025B9B RID: 154523 RVA: 0x009C317A File Offset: 0x009C137A
		[Nullable(2)]
		public unsafe NinjaLiveComponent_C NinjaLiveComponent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<NinjaLiveComponent_C>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700537A RID: 21370
		// (get) Token: 0x06025B9C RID: 154524 RVA: 0x009C318F File Offset: 0x009C138F
		// (set) Token: 0x06025B9D RID: 154525 RVA: 0x009C319F File Offset: 0x009C139F
		public unsafe float ScaleX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700537B RID: 21371
		// (get) Token: 0x06025B9E RID: 154526 RVA: 0x009C31B0 File Offset: 0x009C13B0
		// (set) Token: 0x06025B9F RID: 154527 RVA: 0x009C31C0 File Offset: 0x009C13C0
		public unsafe float ScaleY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700537C RID: 21372
		// (get) Token: 0x06025BA0 RID: 154528 RVA: 0x009C31D1 File Offset: 0x009C13D1
		// (set) Token: 0x06025BA1 RID: 154529 RVA: 0x009C31E5 File Offset: 0x009C13E5
		public unsafe FVector WorldOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700537D RID: 21373
		// (get) Token: 0x06025BA2 RID: 154530 RVA: 0x009C31FA File Offset: 0x009C13FA
		// (set) Token: 0x06025BA3 RID: 154531 RVA: 0x009C320A File Offset: 0x009C140A
		public unsafe bool UseWorldOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700537E RID: 21374
		// (get) Token: 0x06025BA4 RID: 154532 RVA: 0x009C321B File Offset: 0x009C141B
		// (set) Token: 0x06025BA5 RID: 154533 RVA: 0x009C322F File Offset: 0x009C142F
		public unsafe FVector2D HorizontalFacing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700537F RID: 21375
		// (get) Token: 0x06025BA6 RID: 154534 RVA: 0x009C3244 File Offset: 0x009C1444
		// (set) Token: 0x06025BA7 RID: 154535 RVA: 0x009C3254 File Offset: 0x009C1454
		public unsafe float ClampDotProdct
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005380 RID: 21376
		// (get) Token: 0x06025BA8 RID: 154536 RVA: 0x009C3265 File Offset: 0x009C1465
		// (set) Token: 0x06025BA9 RID: 154537 RVA: 0x009C3275 File Offset: 0x009C1475
		public unsafe bool UseViewProjectionMatrix
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005381 RID: 21377
		// (get) Token: 0x06025BAA RID: 154538 RVA: 0x009C3286 File Offset: 0x009C1486
		// (set) Token: 0x06025BAB RID: 154539 RVA: 0x009C3296 File Offset: 0x009C1496
		public unsafe bool DebugMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaRelativeVelocityOffsetComponent_C.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x06025BAC RID: 154540 RVA: 0x009C32A7 File Offset: 0x009C14A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void LocateNinjaLiveComponent()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaRelativeVelocityOffsetComponent_C.__LocateNinjaLiveComponent_NativeFunctionPtr, null);
		}

		// Token: 0x06025BAD RID: 154541 RVA: 0x009C32BC File Offset: 0x009C14BC
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetOffsets(NinjaLiveComponent_C NinjaLiveComponent, FVector2D Velocity)
		{
			NinjaRelativeVelocityOffsetComponent_C.__SetOffsets_FunctionParams* ptr = stackalloc NinjaRelativeVelocityOffsetComponent_C.__SetOffsets_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaRelativeVelocityOffsetComponent_C.__SetOffsets_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaRelativeVelocityOffsetComponent_C.__SetOffsets_NativeFunctionPtr, (void*)ptr, 1);
			ptr->NinjaLiveComponent = ((NinjaLiveComponent != null) ? NinjaLiveComponent.NativePtr : IntPtr.Zero);
			ptr->Velocity = Velocity;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaRelativeVelocityOffsetComponent_C.__SetOffsets_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025BAE RID: 154542 RVA: 0x009C3318 File Offset: 0x009C1518
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CompareIndividualOffsets(ref FVector2D Velocity)
		{
			NinjaRelativeVelocityOffsetComponent_C.__CompareIndividualOffsets_FunctionParams* ptr = stackalloc NinjaRelativeVelocityOffsetComponent_C.__CompareIndividualOffsets_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(NinjaRelativeVelocityOffsetComponent_C.__CompareIndividualOffsets_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaRelativeVelocityOffsetComponent_C.__CompareIndividualOffsets_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Velocity = Velocity;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaRelativeVelocityOffsetComponent_C.__CompareIndividualOffsets_NativeFunctionPtr, (void*)ptr);
			Velocity = ptr->Velocity;
		}

		// Token: 0x06025BAF RID: 154543 RVA: 0x009C3370 File Offset: 0x009C1570
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ViewProjectionTransform(ref FVector2D Velocity)
		{
			NinjaRelativeVelocityOffsetComponent_C.__ViewProjectionTransform_FunctionParams* ptr = stackalloc NinjaRelativeVelocityOffsetComponent_C.__ViewProjectionTransform_FunctionParams[(UIntPtr)2943] + 15L / (long)sizeof(NinjaRelativeVelocityOffsetComponent_C.__ViewProjectionTransform_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaRelativeVelocityOffsetComponent_C.__ViewProjectionTransform_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Velocity = Velocity;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaRelativeVelocityOffsetComponent_C.__ViewProjectionTransform_NativeFunctionPtr, (void*)ptr);
			Velocity = ptr->Velocity;
		}

		// Token: 0x06025BB0 RID: 154544 RVA: 0x009C33CC File Offset: 0x009C15CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ProjectOffsetToScreen(bool PlayerViewportRelative, ref FVector2D Velocity, ref bool IsValid)
		{
			NinjaRelativeVelocityOffsetComponent_C.__ProjectOffsetToScreen_FunctionParams* ptr = stackalloc NinjaRelativeVelocityOffsetComponent_C.__ProjectOffsetToScreen_FunctionParams[(UIntPtr)215] + 15L / (long)sizeof(NinjaRelativeVelocityOffsetComponent_C.__ProjectOffsetToScreen_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaRelativeVelocityOffsetComponent_C.__ProjectOffsetToScreen_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PlayerViewportRelative = PlayerViewportRelative;
			ptr->Velocity = Velocity;
			ptr->IsValid = IsValid;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaRelativeVelocityOffsetComponent_C.__ProjectOffsetToScreen_NativeFunctionPtr, (void*)ptr);
			Velocity = ptr->Velocity;
			IsValid = ptr->IsValid;
		}

		// Token: 0x06025BB1 RID: 154545 RVA: 0x009C3440 File Offset: 0x009C1640
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void DrawDebug2D(FVector2D Direction, float Scale, float ArrowSize, FLinearColor Color, float Duration, float Thickness)
		{
			NinjaRelativeVelocityOffsetComponent_C.__DrawDebug2D_FunctionParams* ptr = stackalloc NinjaRelativeVelocityOffsetComponent_C.__DrawDebug2D_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(NinjaRelativeVelocityOffsetComponent_C.__DrawDebug2D_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaRelativeVelocityOffsetComponent_C.__DrawDebug2D_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Direction = Direction;
			ptr->Scale = Scale;
			ptr->ArrowSize = ArrowSize;
			ptr->Color = Color;
			ptr->Duration = Duration;
			ptr->Thickness = Thickness;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaRelativeVelocityOffsetComponent_C.__DrawDebug2D_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025BB2 RID: 154546 RVA: 0x009C34AF File Offset: 0x009C16AF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetRelativeVelocityOffset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaRelativeVelocityOffsetComponent_C.__SetRelativeVelocityOffset_NativeFunctionPtr, null);
		}

		// Token: 0x06025BB3 RID: 154547 RVA: 0x009C34C4 File Offset: 0x009C16C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			NinjaRelativeVelocityOffsetComponent_C.__ReceiveTick_FunctionParams* ptr = stackalloc NinjaRelativeVelocityOffsetComponent_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaRelativeVelocityOffsetComponent_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaRelativeVelocityOffsetComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaRelativeVelocityOffsetComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025BB4 RID: 154548 RVA: 0x009C350C File Offset: 0x009C170C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			NinjaRelativeVelocityOffsetComponent_C.__ReceiveTick_FunctionParams* ptr = stackalloc NinjaRelativeVelocityOffsetComponent_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaRelativeVelocityOffsetComponent_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaRelativeVelocityOffsetComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaRelativeVelocityOffsetComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025BB5 RID: 154549 RVA: 0x009C3553 File Offset: 0x009C1753
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaRelativeVelocityOffsetComponent_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06025BB6 RID: 154550 RVA: 0x009C3567 File Offset: 0x009C1767
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaRelativeVelocityOffsetComponent_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025BB7 RID: 154551 RVA: 0x009C357C File Offset: 0x009C177C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_NinjaRelativeVelocityOffsetComponent(int EntryPoint)
		{
			NinjaRelativeVelocityOffsetComponent_C.__ExecuteUbergraph_NinjaRelativeVelocityOffsetComponent_FunctionParams* ptr = stackalloc NinjaRelativeVelocityOffsetComponent_C.__ExecuteUbergraph_NinjaRelativeVelocityOffsetComponent_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaRelativeVelocityOffsetComponent_C.__ExecuteUbergraph_NinjaRelativeVelocityOffsetComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaRelativeVelocityOffsetComponent_C.__ExecuteUbergraph_NinjaRelativeVelocityOffsetComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaRelativeVelocityOffsetComponent_C.__ExecuteUbergraph_NinjaRelativeVelocityOffsetComponent_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025BB8 RID: 154552 RVA: 0x009C35C3 File Offset: 0x009C17C3
		protected NinjaRelativeVelocityOffsetComponent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040137A9 RID: 79785
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/NinjaRelativeVelocityOffsetComponent.NinjaRelativeVelocityOffsetComponent_C";

		// Token: 0x040137AA RID: 79786
		private static IntPtr _ClassPtr;

		// Token: 0x040137AB RID: 79787
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040137AC RID: 79788
		internal static int __PropertyOffset_0;

		// Token: 0x040137AD RID: 79789
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040137AE RID: 79790
		internal static int __PropertyOffset_1;

		// Token: 0x040137AF RID: 79791
		internal static int __PropertyOffset_2;

		// Token: 0x040137B0 RID: 79792
		internal static int __PropertyOffset_3;

		// Token: 0x040137B1 RID: 79793
		internal static int __PropertyOffset_4;

		// Token: 0x040137B2 RID: 79794
		internal static int __PropertyOffset_5;

		// Token: 0x040137B3 RID: 79795
		internal static int __PropertyOffset_6;

		// Token: 0x040137B4 RID: 79796
		internal static int __PropertyOffset_7;

		// Token: 0x040137B5 RID: 79797
		internal static int __PropertyOffset_8;

		// Token: 0x040137B6 RID: 79798
		internal static int __PropertyOffset_9;

		// Token: 0x040137B7 RID: 79799
		private static IntPtr __LocateNinjaLiveComponent_NativeFunctionPtr;

		// Token: 0x040137B8 RID: 79800
		private static IntPtr __SetOffsets_NativeFunctionPtr;

		// Token: 0x040137B9 RID: 79801
		private static IntPtr __CompareIndividualOffsets_NativeFunctionPtr;

		// Token: 0x040137BA RID: 79802
		private static IntPtr __ViewProjectionTransform_NativeFunctionPtr;

		// Token: 0x040137BB RID: 79803
		private static IntPtr __ProjectOffsetToScreen_NativeFunctionPtr;

		// Token: 0x040137BC RID: 79804
		private static IntPtr __DrawDebug2D_NativeFunctionPtr;

		// Token: 0x040137BD RID: 79805
		private static IntPtr __SetRelativeVelocityOffset_NativeFunctionPtr;

		// Token: 0x040137BE RID: 79806
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040137BF RID: 79807
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040137C0 RID: 79808
		private static IntPtr __ExecuteUbergraph_NinjaRelativeVelocityOffsetComponent_NativeFunctionPtr;

		// Token: 0x02009F8F RID: 40847
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __SetOffsets_FunctionParams
		{
			// Token: 0x04032B30 RID: 207664
			[FieldOffset(0)]
			public IntPtr NinjaLiveComponent;

			// Token: 0x04032B31 RID: 207665
			[FieldOffset(8)]
			public FVector2D Velocity;
		}

		// Token: 0x02009F90 RID: 40848
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __CompareIndividualOffsets_FunctionParams
		{
			// Token: 0x04032B32 RID: 207666
			[FieldOffset(0)]
			public FVector2D Velocity;
		}

		// Token: 0x02009F91 RID: 40849
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 2928)]
		protected ref struct __ViewProjectionTransform_FunctionParams
		{
			// Token: 0x04032B33 RID: 207667
			[FieldOffset(0)]
			public FVector2D Velocity;
		}

		// Token: 0x02009F92 RID: 40850
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 200)]
		protected ref struct __ProjectOffsetToScreen_FunctionParams
		{
			// Token: 0x04032B34 RID: 207668
			[FieldOffset(0)]
			public bool PlayerViewportRelative;

			// Token: 0x04032B35 RID: 207669
			[FieldOffset(4)]
			public FVector2D Velocity;

			// Token: 0x04032B36 RID: 207670
			[FieldOffset(12)]
			public bool IsValid;
		}

		// Token: 0x02009F93 RID: 40851
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __DrawDebug2D_FunctionParams
		{
			// Token: 0x04032B37 RID: 207671
			[FieldOffset(0)]
			public FVector2D Direction;

			// Token: 0x04032B38 RID: 207672
			[FieldOffset(8)]
			public float Scale;

			// Token: 0x04032B39 RID: 207673
			[FieldOffset(12)]
			public float ArrowSize;

			// Token: 0x04032B3A RID: 207674
			[FieldOffset(16)]
			public FLinearColor Color;

			// Token: 0x04032B3B RID: 207675
			[FieldOffset(32)]
			public float Duration;

			// Token: 0x04032B3C RID: 207676
			[FieldOffset(36)]
			public float Thickness;
		}

		// Token: 0x02009F94 RID: 40852
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032B3D RID: 207677
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009F95 RID: 40853
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_NinjaRelativeVelocityOffsetComponent_FunctionParams
		{
			// Token: 0x04032B3E RID: 207678
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
