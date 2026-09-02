using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Audio
{
	// Token: 0x0200437D RID: 17277
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Audio/BP_SpectrumBand.BP_SpectrumBand_C")]
	[UnrealStructLayout(1072, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1072)]
	public class BP_SpectrumBand_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DC9E RID: 187550 RVA: 0x00ACBF93 File Offset: 0x00ACA193
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SpectrumBand_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Audio/BP_SpectrumBand.BP_SpectrumBand_C");
			}
			return BP_SpectrumBand_C._ClassPtr;
		}

		// Token: 0x0602DC9F RID: 187551 RVA: 0x00ACBFB8 File Offset: 0x00ACA1B8
		public BP_SpectrumBand_C() : this(BuiltinUtils.AllocNativeUObject(BP_SpectrumBand_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DCA0 RID: 187552 RVA: 0x00ACBFE0 File Offset: 0x00ACA1E0
		[NullableContext(1)]
		public BP_SpectrumBand_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SpectrumBand_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007D70 RID: 32112
		// (get) Token: 0x0602DCA1 RID: 187553 RVA: 0x00ACC014 File Offset: 0x00ACA214
		// (set) Token: 0x0602DCA2 RID: 187554 RVA: 0x00ACC04D File Offset: 0x00ACA24D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SpectrumBand_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SpectrumBand_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007D71 RID: 32113
		// (get) Token: 0x0602DCA3 RID: 187555 RVA: 0x00ACC06E File Offset: 0x00ACA26E
		// (set) Token: 0x0602DCA4 RID: 187556 RVA: 0x00ACC082 File Offset: 0x00ACA282
		public unsafe UAkComponent Ak
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpectrumBand_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpectrumBand_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007D72 RID: 32114
		// (get) Token: 0x0602DCA5 RID: 187557 RVA: 0x00ACC097 File Offset: 0x00ACA297
		// (set) Token: 0x0602DCA6 RID: 187558 RVA: 0x00ACC0AB File Offset: 0x00ACA2AB
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpectrumBand_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SpectrumBand_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007D73 RID: 32115
		// (get) Token: 0x0602DCA7 RID: 187559 RVA: 0x00ACC0C0 File Offset: 0x00ACA2C0
		// (set) Token: 0x0602DCA8 RID: 187560 RVA: 0x00ACC0D0 File Offset: 0x00ACA2D0
		public unsafe float PercussionVol
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SpectrumBand_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SpectrumBand_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007D74 RID: 32116
		// (get) Token: 0x0602DCA9 RID: 187561 RVA: 0x00ACC0E1 File Offset: 0x00ACA2E1
		// (set) Token: 0x0602DCAA RID: 187562 RVA: 0x00ACC0F1 File Offset: 0x00ACA2F1
		public unsafe float TimeOri
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SpectrumBand_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SpectrumBand_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007D75 RID: 32117
		// (get) Token: 0x0602DCAB RID: 187563 RVA: 0x00ACC102 File Offset: 0x00ACA302
		// (set) Token: 0x0602DCAC RID: 187564 RVA: 0x00ACC112 File Offset: 0x00ACA312
		public unsafe float TimeToMaterial
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SpectrumBand_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SpectrumBand_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007D76 RID: 32118
		// (get) Token: 0x0602DCAD RID: 187565 RVA: 0x00ACC123 File Offset: 0x00ACA323
		// (set) Token: 0x0602DCAE RID: 187566 RVA: 0x00ACC133 File Offset: 0x00ACA333
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SpectrumBand_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SpectrumBand_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x0602DCAF RID: 187567 RVA: 0x00ACC144 File Offset: 0x00ACA344
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SpectrumBand_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SpectrumBand_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SpectrumBand_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SpectrumBand_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SpectrumBand_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DCB0 RID: 187568 RVA: 0x00ACC18C File Offset: 0x00ACA38C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SpectrumBand_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SpectrumBand_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SpectrumBand_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SpectrumBand_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SpectrumBand_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DCB1 RID: 187569 RVA: 0x00ACC1D3 File Offset: 0x00ACA3D3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SpectrumBand_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602DCB2 RID: 187570 RVA: 0x00ACC1E7 File Offset: 0x00ACA3E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SpectrumBand_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602DCB3 RID: 187571 RVA: 0x00ACC1FC File Offset: 0x00ACA3FC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SpectrumBand(int EntryPoint)
		{
			BP_SpectrumBand_C.__ExecuteUbergraph_BP_SpectrumBand_FunctionParams* ptr = stackalloc BP_SpectrumBand_C.__ExecuteUbergraph_BP_SpectrumBand_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_SpectrumBand_C.__ExecuteUbergraph_BP_SpectrumBand_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SpectrumBand_C.__ExecuteUbergraph_BP_SpectrumBand_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SpectrumBand_C.__ExecuteUbergraph_BP_SpectrumBand_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DCB4 RID: 187572 RVA: 0x00ACC243 File Offset: 0x00ACA443
		protected BP_SpectrumBand_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019D81 RID: 105857
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Audio/BP_SpectrumBand.BP_SpectrumBand_C";

		// Token: 0x04019D82 RID: 105858
		private static IntPtr _ClassPtr;

		// Token: 0x04019D83 RID: 105859
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019D84 RID: 105860
		internal static int __PropertyOffset_0;

		// Token: 0x04019D85 RID: 105861
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04019D86 RID: 105862
		internal static int __PropertyOffset_1;

		// Token: 0x04019D87 RID: 105863
		internal static int __PropertyOffset_2;

		// Token: 0x04019D88 RID: 105864
		internal static int __PropertyOffset_3;

		// Token: 0x04019D89 RID: 105865
		internal static int __PropertyOffset_4;

		// Token: 0x04019D8A RID: 105866
		internal static int __PropertyOffset_5;

		// Token: 0x04019D8B RID: 105867
		internal static int __PropertyOffset_6;

		// Token: 0x04019D8C RID: 105868
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04019D8D RID: 105869
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04019D8E RID: 105870
		private static IntPtr __ExecuteUbergraph_BP_SpectrumBand_NativeFunctionPtr;

		// Token: 0x0200A5A5 RID: 42405
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04033503 RID: 210179
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A5A6 RID: 42406
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __ExecuteUbergraph_BP_SpectrumBand_FunctionParams
		{
			// Token: 0x04033504 RID: 210180
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
