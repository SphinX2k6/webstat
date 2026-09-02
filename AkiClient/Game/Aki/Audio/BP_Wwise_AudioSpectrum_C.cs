using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Audio
{
	// Token: 0x0200437E RID: 17278
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Audio/BP_Wwise_AudioSpectrum.BP_Wwise_AudioSpectrum_C")]
	[UnrealStructLayout(1112, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1112)]
	public class BP_Wwise_AudioSpectrum_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DCB5 RID: 187573 RVA: 0x00ACC24C File Offset: 0x00ACA44C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Wwise_AudioSpectrum_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Audio/BP_Wwise_AudioSpectrum.BP_Wwise_AudioSpectrum_C");
			}
			return BP_Wwise_AudioSpectrum_C._ClassPtr;
		}

		// Token: 0x0602DCB6 RID: 187574 RVA: 0x00ACC270 File Offset: 0x00ACA470
		public BP_Wwise_AudioSpectrum_C() : this(BuiltinUtils.AllocNativeUObject(BP_Wwise_AudioSpectrum_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DCB7 RID: 187575 RVA: 0x00ACC298 File Offset: 0x00ACA498
		[NullableContext(1)]
		public BP_Wwise_AudioSpectrum_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Wwise_AudioSpectrum_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007D77 RID: 32119
		// (get) Token: 0x0602DCB8 RID: 187576 RVA: 0x00ACC2CC File Offset: 0x00ACA4CC
		// (set) Token: 0x0602DCB9 RID: 187577 RVA: 0x00ACC305 File Offset: 0x00ACA505
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_Wwise_AudioSpectrum_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_Wwise_AudioSpectrum_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007D78 RID: 32120
		// (get) Token: 0x0602DCBA RID: 187578 RVA: 0x00ACC326 File Offset: 0x00ACA526
		// (set) Token: 0x0602DCBB RID: 187579 RVA: 0x00ACC33A File Offset: 0x00ACA53A
		public unsafe UAkComponent Ak
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wwise_AudioSpectrum_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wwise_AudioSpectrum_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007D79 RID: 32121
		// (get) Token: 0x0602DCBC RID: 187580 RVA: 0x00ACC34F File Offset: 0x00ACA54F
		// (set) Token: 0x0602DCBD RID: 187581 RVA: 0x00ACC363 File Offset: 0x00ACA563
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wwise_AudioSpectrum_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wwise_AudioSpectrum_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007D7A RID: 32122
		// (get) Token: 0x0602DCBE RID: 187582 RVA: 0x00ACC378 File Offset: 0x00ACA578
		// (set) Token: 0x0602DCBF RID: 187583 RVA: 0x00ACC38C File Offset: 0x00ACA58C
		public unsafe UConstantQNRT Synesthesia_Analysis
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UConstantQNRT>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wwise_AudioSpectrum_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wwise_AudioSpectrum_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17007D7B RID: 32123
		// (get) Token: 0x0602DCC0 RID: 187584 RVA: 0x00ACC3A4 File Offset: 0x00ACA5A4
		// (set) Token: 0x0602DCC1 RID: 187585 RVA: 0x00ACC3DD File Offset: 0x00ACA5DD
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
					result = (this._Frequency_Band_Strengths = new TArray<float>(base.NativePtr + (IntPtr)BP_Wwise_AudioSpectrum_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Frequency_Band_Strengths.CopyAssign(value);
			}
		}

		// Token: 0x17007D7C RID: 32124
		// (get) Token: 0x0602DCC2 RID: 187586 RVA: 0x00ACC3EC File Offset: 0x00ACA5EC
		// (set) Token: 0x0602DCC3 RID: 187587 RVA: 0x00ACC425 File Offset: 0x00ACA625
		[Nullable(1)]
		public TArray<float> OutputArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._OutputArray) == null)
				{
					result = (this._OutputArray = new TArray<float>(base.NativePtr + (IntPtr)BP_Wwise_AudioSpectrum_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.OutputArray.CopyAssign(value);
			}
		}

		// Token: 0x17007D7D RID: 32125
		// (get) Token: 0x0602DCC4 RID: 187588 RVA: 0x00ACC433 File Offset: 0x00ACA633
		// (set) Token: 0x0602DCC5 RID: 187589 RVA: 0x00ACC447 File Offset: 0x00ACA647
		public unsafe UAkAudioEvent AkResource
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wwise_AudioSpectrum_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wwise_AudioSpectrum_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17007D7E RID: 32126
		// (get) Token: 0x0602DCC6 RID: 187590 RVA: 0x00ACC45C File Offset: 0x00ACA65C
		// (set) Token: 0x0602DCC7 RID: 187591 RVA: 0x00ACC470 File Offset: 0x00ACA670
		public unsafe UAkAudioEvent Ak_Event
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wwise_AudioSpectrum_C.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wwise_AudioSpectrum_C.__PropertyOffset_7, value);
			}
		}

		// Token: 0x0602DCC8 RID: 187592 RVA: 0x00ACC488 File Offset: 0x00ACA688
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void NotifyAnalyser(UAkComponent Ak, UAkAudioEvent akEvent)
		{
			BP_Wwise_AudioSpectrum_C.__NotifyAnalyser_FunctionParams* ptr = stackalloc BP_Wwise_AudioSpectrum_C.__NotifyAnalyser_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_Wwise_AudioSpectrum_C.__NotifyAnalyser_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Wwise_AudioSpectrum_C.__NotifyAnalyser_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Ak = ((Ak != null) ? Ak.NativePtr : IntPtr.Zero);
			ptr->akEvent = ((akEvent != null) ? akEvent.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Wwise_AudioSpectrum_C.__NotifyAnalyser_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DCC9 RID: 187593 RVA: 0x00ACC4F4 File Offset: 0x00ACA6F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_Wwise_AudioSpectrum_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Wwise_AudioSpectrum_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Wwise_AudioSpectrum_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Wwise_AudioSpectrum_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Wwise_AudioSpectrum_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DCCA RID: 187594 RVA: 0x00ACC53C File Offset: 0x00ACA73C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_Wwise_AudioSpectrum_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_Wwise_AudioSpectrum_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_Wwise_AudioSpectrum_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Wwise_AudioSpectrum_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Wwise_AudioSpectrum_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DCCB RID: 187595 RVA: 0x00ACC584 File Offset: 0x00ACA784
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AkCall(UAkComponent Ak, UAkAudioEvent AkEvent)
		{
			BP_Wwise_AudioSpectrum_C.__AkCall_FunctionParams* ptr = stackalloc BP_Wwise_AudioSpectrum_C.__AkCall_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_Wwise_AudioSpectrum_C.__AkCall_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Wwise_AudioSpectrum_C.__AkCall_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Ak = ((Ak != null) ? Ak.NativePtr : IntPtr.Zero);
			ptr->AkEvent = ((AkEvent != null) ? AkEvent.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Wwise_AudioSpectrum_C.__AkCall_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DCCC RID: 187596 RVA: 0x00ACC5F0 File Offset: 0x00ACA7F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_Wwise_AudioSpectrum(int EntryPoint)
		{
			BP_Wwise_AudioSpectrum_C.__ExecuteUbergraph_BP_Wwise_AudioSpectrum_FunctionParams* ptr = stackalloc BP_Wwise_AudioSpectrum_C.__ExecuteUbergraph_BP_Wwise_AudioSpectrum_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(BP_Wwise_AudioSpectrum_C.__ExecuteUbergraph_BP_Wwise_AudioSpectrum_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_Wwise_AudioSpectrum_C.__ExecuteUbergraph_BP_Wwise_AudioSpectrum_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Wwise_AudioSpectrum_C.__ExecuteUbergraph_BP_Wwise_AudioSpectrum_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DCCD RID: 187597 RVA: 0x00ACC63A File Offset: 0x00ACA83A
		protected BP_Wwise_AudioSpectrum_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019D8F RID: 105871
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Audio/BP_Wwise_AudioSpectrum.BP_Wwise_AudioSpectrum_C";

		// Token: 0x04019D90 RID: 105872
		private static IntPtr _ClassPtr;

		// Token: 0x04019D91 RID: 105873
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019D92 RID: 105874
		internal static int __PropertyOffset_0;

		// Token: 0x04019D93 RID: 105875
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04019D94 RID: 105876
		internal static int __PropertyOffset_1;

		// Token: 0x04019D95 RID: 105877
		internal static int __PropertyOffset_2;

		// Token: 0x04019D96 RID: 105878
		internal static int __PropertyOffset_3;

		// Token: 0x04019D97 RID: 105879
		internal static int __PropertyOffset_4;

		// Token: 0x04019D98 RID: 105880
		private TArray<float> _Frequency_Band_Strengths;

		// Token: 0x04019D99 RID: 105881
		internal static int __PropertyOffset_5;

		// Token: 0x04019D9A RID: 105882
		private TArray<float> _OutputArray;

		// Token: 0x04019D9B RID: 105883
		internal static int __PropertyOffset_6;

		// Token: 0x04019D9C RID: 105884
		internal static int __PropertyOffset_7;

		// Token: 0x04019D9D RID: 105885
		private static IntPtr __NotifyAnalyser_NativeFunctionPtr;

		// Token: 0x04019D9E RID: 105886
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04019D9F RID: 105887
		private static IntPtr __AkCall_NativeFunctionPtr;

		// Token: 0x04019DA0 RID: 105888
		private static IntPtr __ExecuteUbergraph_BP_Wwise_AudioSpectrum_NativeFunctionPtr;

		// Token: 0x0200A5A7 RID: 42407
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __NotifyAnalyser_FunctionParams
		{
			// Token: 0x04033505 RID: 210181
			[FieldOffset(0)]
			public IntPtr Ak;

			// Token: 0x04033506 RID: 210182
			[FieldOffset(8)]
			public IntPtr akEvent;
		}

		// Token: 0x0200A5A8 RID: 42408
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04033507 RID: 210183
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A5A9 RID: 42409
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __AkCall_FunctionParams
		{
			// Token: 0x04033508 RID: 210184
			[FieldOffset(0)]
			public IntPtr Ak;

			// Token: 0x04033509 RID: 210185
			[FieldOffset(8)]
			public IntPtr AkEvent;
		}

		// Token: 0x0200A5AA RID: 42410
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected ref struct __ExecuteUbergraph_BP_Wwise_AudioSpectrum_FunctionParams
		{
			// Token: 0x0403350A RID: 210186
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
