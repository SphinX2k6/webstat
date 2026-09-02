using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Audio
{
	// Token: 0x02004378 RID: 17272
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Audio/BP_AudioSpectrum.BP_AudioSpectrum_C")]
	[UnrealStructLayout(1096, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1096)]
	public class BP_AudioSpectrum_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DC0F RID: 187407 RVA: 0x00ACB1E0 File Offset: 0x00AC93E0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AudioSpectrum_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Audio/BP_AudioSpectrum.BP_AudioSpectrum_C");
			}
			return BP_AudioSpectrum_C._ClassPtr;
		}

		// Token: 0x0602DC10 RID: 187408 RVA: 0x00ACB204 File Offset: 0x00AC9404
		public BP_AudioSpectrum_C() : this(BuiltinUtils.AllocNativeUObject(BP_AudioSpectrum_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DC11 RID: 187409 RVA: 0x00ACB22C File Offset: 0x00AC942C
		[NullableContext(1)]
		public BP_AudioSpectrum_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AudioSpectrum_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007D43 RID: 32067
		// (get) Token: 0x0602DC12 RID: 187410 RVA: 0x00ACB260 File Offset: 0x00AC9460
		// (set) Token: 0x0602DC13 RID: 187411 RVA: 0x00ACB299 File Offset: 0x00AC9499
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_AudioSpectrum_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_AudioSpectrum_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007D44 RID: 32068
		// (get) Token: 0x0602DC14 RID: 187412 RVA: 0x00ACB2BA File Offset: 0x00AC94BA
		// (set) Token: 0x0602DC15 RID: 187413 RVA: 0x00ACB2CE File Offset: 0x00AC94CE
		public unsafe UAkComponent Ak
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioSpectrum_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioSpectrum_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007D45 RID: 32069
		// (get) Token: 0x0602DC16 RID: 187414 RVA: 0x00ACB2E3 File Offset: 0x00AC94E3
		// (set) Token: 0x0602DC17 RID: 187415 RVA: 0x00ACB2F7 File Offset: 0x00AC94F7
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioSpectrum_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioSpectrum_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007D46 RID: 32070
		// (get) Token: 0x0602DC18 RID: 187416 RVA: 0x00ACB30C File Offset: 0x00AC950C
		// (set) Token: 0x0602DC19 RID: 187417 RVA: 0x00ACB31C File Offset: 0x00AC951C
		public unsafe float Timeline_Time_A7ECE5844EB26A560E8B94A3191248B3
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioSpectrum_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioSpectrum_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007D47 RID: 32071
		// (get) Token: 0x0602DC1A RID: 187418 RVA: 0x00ACB32D File Offset: 0x00AC952D
		// (set) Token: 0x0602DC1B RID: 187419 RVA: 0x00ACB341 File Offset: 0x00AC9541
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline__Direction_A7ECE5844EB26A560E8B94A3191248B3
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioSpectrum_C.__PropertyOffset_4);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioSpectrum_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007D48 RID: 32072
		// (get) Token: 0x0602DC1C RID: 187420 RVA: 0x00ACB356 File Offset: 0x00AC9556
		// (set) Token: 0x0602DC1D RID: 187421 RVA: 0x00ACB36A File Offset: 0x00AC956A
		public unsafe UTimelineComponent Timeline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioSpectrum_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioSpectrum_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17007D49 RID: 32073
		// (get) Token: 0x0602DC1E RID: 187422 RVA: 0x00ACB37F File Offset: 0x00AC957F
		// (set) Token: 0x0602DC1F RID: 187423 RVA: 0x00ACB393 File Offset: 0x00AC9593
		public unsafe UConstantQNRT Synesthesia_Analysis
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UConstantQNRT>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioSpectrum_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioSpectrum_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17007D4A RID: 32074
		// (get) Token: 0x0602DC20 RID: 187424 RVA: 0x00ACB3A8 File Offset: 0x00AC95A8
		// (set) Token: 0x0602DC21 RID: 187425 RVA: 0x00ACB3E1 File Offset: 0x00AC95E1
		[Nullable(1)]
		public TArray<float> Frequency_Band_Strengths
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._Frequency_Band_Strengths) == null)
				{
					result = (this._Frequency_Band_Strengths = new TArray<float>(base.NativePtr + (IntPtr)BP_AudioSpectrum_C.__PropertyOffset_7, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Frequency_Band_Strengths.CopyAssign(value);
			}
		}

		// Token: 0x0602DC22 RID: 187426 RVA: 0x00ACB3EF File Offset: 0x00AC95EF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpectrum_C.__Timeline__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC23 RID: 187427 RVA: 0x00ACB403 File Offset: 0x00AC9603
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpectrum_C.__Timeline__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC24 RID: 187428 RVA: 0x00ACB417 File Offset: 0x00AC9617
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpectrum_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC25 RID: 187429 RVA: 0x00ACB42B File Offset: 0x00AC962B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AudioSpectrum_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602DC26 RID: 187430 RVA: 0x00ACB440 File Offset: 0x00AC9640
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CallDuration(EAkCallbackType CallbackType, UAkCallbackInfo CallbackInfo)
		{
			BP_AudioSpectrum_C.__CallDuration_FunctionParams* ptr = stackalloc BP_AudioSpectrum_C.__CallDuration_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_AudioSpectrum_C.__CallDuration_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioSpectrum_C.__CallDuration_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CallbackType = CallbackType;
			ptr->CallbackInfo = ((CallbackInfo != null) ? CallbackInfo.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioSpectrum_C.__CallDuration_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DC27 RID: 187431 RVA: 0x00ACB49C File Offset: 0x00AC969C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_AudioSpectrum(int EntryPoint)
		{
			BP_AudioSpectrum_C.__ExecuteUbergraph_BP_AudioSpectrum_FunctionParams* ptr = stackalloc BP_AudioSpectrum_C.__ExecuteUbergraph_BP_AudioSpectrum_FunctionParams[(UIntPtr)95] + 15L / (long)sizeof(BP_AudioSpectrum_C.__ExecuteUbergraph_BP_AudioSpectrum_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioSpectrum_C.__ExecuteUbergraph_BP_AudioSpectrum_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AudioSpectrum_C.__ExecuteUbergraph_BP_AudioSpectrum_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DC28 RID: 187432 RVA: 0x00ACB4E3 File Offset: 0x00AC96E3
		protected BP_AudioSpectrum_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019D23 RID: 105763
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Audio/BP_AudioSpectrum.BP_AudioSpectrum_C";

		// Token: 0x04019D24 RID: 105764
		private static IntPtr _ClassPtr;

		// Token: 0x04019D25 RID: 105765
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019D26 RID: 105766
		internal static int __PropertyOffset_0;

		// Token: 0x04019D27 RID: 105767
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04019D28 RID: 105768
		internal static int __PropertyOffset_1;

		// Token: 0x04019D29 RID: 105769
		internal static int __PropertyOffset_2;

		// Token: 0x04019D2A RID: 105770
		internal static int __PropertyOffset_3;

		// Token: 0x04019D2B RID: 105771
		internal static int __PropertyOffset_4;

		// Token: 0x04019D2C RID: 105772
		internal static int __PropertyOffset_5;

		// Token: 0x04019D2D RID: 105773
		internal static int __PropertyOffset_6;

		// Token: 0x04019D2E RID: 105774
		internal static int __PropertyOffset_7;

		// Token: 0x04019D2F RID: 105775
		private TArray<float> _Frequency_Band_Strengths;

		// Token: 0x04019D30 RID: 105776
		private static IntPtr __Timeline__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04019D31 RID: 105777
		private static IntPtr __Timeline__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04019D32 RID: 105778
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04019D33 RID: 105779
		private static IntPtr __CallDuration_NativeFunctionPtr;

		// Token: 0x04019D34 RID: 105780
		private static IntPtr __ExecuteUbergraph_BP_AudioSpectrum_NativeFunctionPtr;

		// Token: 0x0200A59F RID: 42399
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __CallDuration_FunctionParams
		{
			// Token: 0x040334F8 RID: 210168
			[FieldOffset(0)]
			public EAkCallbackType CallbackType;

			// Token: 0x040334F9 RID: 210169
			[FieldOffset(8)]
			public IntPtr CallbackInfo;
		}

		// Token: 0x0200A5A0 RID: 42400
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 80)]
		protected ref struct __ExecuteUbergraph_BP_AudioSpectrum_FunctionParams
		{
			// Token: 0x040334FA RID: 210170
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
