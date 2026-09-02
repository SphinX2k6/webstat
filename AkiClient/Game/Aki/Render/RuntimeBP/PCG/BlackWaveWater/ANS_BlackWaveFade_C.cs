using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.BlackWaveWater
{
	// Token: 0x02003C3D RID: 15421
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/BlackWaveWater/ANS_BlackWaveFade.ANS_BlackWaveFade_C")]
	[UnrealStructLayout(392, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 392)]
	public class ANS_BlackWaveFade_C : UAnimNotifyState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023723 RID: 145187 RVA: 0x0098240B File Offset: 0x0098060B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ANS_BlackWaveFade_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/BlackWaveWater/ANS_BlackWaveFade.ANS_BlackWaveFade_C");
			}
			return ANS_BlackWaveFade_C._ClassPtr;
		}

		// Token: 0x06023724 RID: 145188 RVA: 0x00982430 File Offset: 0x00980630
		public ANS_BlackWaveFade_C() : this(BuiltinUtils.AllocNativeUObject(ANS_BlackWaveFade_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023725 RID: 145189 RVA: 0x00982458 File Offset: 0x00980658
		[NullableContext(1)]
		public ANS_BlackWaveFade_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ANS_BlackWaveFade_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004680 RID: 18048
		// (get) Token: 0x06023726 RID: 145190 RVA: 0x0098248B File Offset: 0x0098068B
		// (set) Token: 0x06023727 RID: 145191 RVA: 0x0098249B File Offset: 0x0098069B
		public unsafe float LerpTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ANS_BlackWaveFade_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ANS_BlackWaveFade_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17004681 RID: 18049
		// (get) Token: 0x06023728 RID: 145192 RVA: 0x009824AC File Offset: 0x009806AC
		// (set) Token: 0x06023729 RID: 145193 RVA: 0x009824BC File Offset: 0x009806BC
		public unsafe bool bUseMeshPositionAsFadeCenter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ANS_BlackWaveFade_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ANS_BlackWaveFade_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004682 RID: 18050
		// (get) Token: 0x0602372A RID: 145194 RVA: 0x009824CD File Offset: 0x009806CD
		// (set) Token: 0x0602372B RID: 145195 RVA: 0x009824E1 File Offset: 0x009806E1
		public unsafe FVectorDouble FadePosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ANS_BlackWaveFade_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ANS_BlackWaveFade_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17004683 RID: 18051
		// (get) Token: 0x0602372C RID: 145196 RVA: 0x009824F8 File Offset: 0x009806F8
		// (set) Token: 0x0602372D RID: 145197 RVA: 0x00982531 File Offset: 0x00980731
		[Nullable(1)]
		public FKuroCurveFloat FadeOpacityCurve
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._FadeOpacityCurve) == null)
				{
					result = (this._FadeOpacityCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)ANS_BlackWaveFade_C.__PropertyOffset_3, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ANS_BlackWaveFade_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004684 RID: 18052
		// (get) Token: 0x0602372E RID: 145198 RVA: 0x00982554 File Offset: 0x00980754
		// (set) Token: 0x0602372F RID: 145199 RVA: 0x0098258D File Offset: 0x0098078D
		[Nullable(1)]
		public FKuroCurveFloat FadeRadiusCurve
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._FadeRadiusCurve) == null)
				{
					result = (this._FadeRadiusCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)ANS_BlackWaveFade_C.__PropertyOffset_4, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)ANS_BlackWaveFade_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06023730 RID: 145200 RVA: 0x009825B0 File Offset: 0x009807B0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool Received_NotifyEnd(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation)
		{
			ANS_BlackWaveFade_C.__Received_NotifyEnd_FunctionParams* ptr = stackalloc ANS_BlackWaveFade_C.__Received_NotifyEnd_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(ANS_BlackWaveFade_C.__Received_NotifyEnd_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_BlackWaveFade_C.__Received_NotifyEnd_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ANS_BlackWaveFade_C.__Received_NotifyEnd_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x06023731 RID: 145201 RVA: 0x00982624 File Offset: 0x00980824
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool Received_NotifyEnd_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation)
		{
			ANS_BlackWaveFade_C.__Received_NotifyEnd_FunctionParams* ptr = stackalloc ANS_BlackWaveFade_C.__Received_NotifyEnd_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(ANS_BlackWaveFade_C.__Received_NotifyEnd_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_BlackWaveFade_C.__Received_NotifyEnd_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ANS_BlackWaveFade_C.__Received_NotifyEnd_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x06023732 RID: 145202 RVA: 0x00982698 File Offset: 0x00980898
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void InitParams(UObject WorldContextObject)
		{
			ANS_BlackWaveFade_C.__InitParams_FunctionParams* ptr = stackalloc ANS_BlackWaveFade_C.__InitParams_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ANS_BlackWaveFade_C.__InitParams_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_BlackWaveFade_C.__InitParams_NativeFunctionPtr, (void*)ptr, 1);
			ptr->WorldContextObject = ((WorldContextObject != null) ? WorldContextObject.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ANS_BlackWaveFade_C.__InitParams_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06023733 RID: 145203 RVA: 0x009826F0 File Offset: 0x009808F0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool Received_NotifyBegin(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float TotalDuration)
		{
			ANS_BlackWaveFade_C.__Received_NotifyBegin_FunctionParams* ptr = stackalloc ANS_BlackWaveFade_C.__Received_NotifyBegin_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(ANS_BlackWaveFade_C.__Received_NotifyBegin_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_BlackWaveFade_C.__Received_NotifyBegin_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			ptr->TotalDuration = TotalDuration;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ANS_BlackWaveFade_C.__Received_NotifyBegin_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x06023734 RID: 145204 RVA: 0x00982768 File Offset: 0x00980968
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool Received_NotifyBegin_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float TotalDuration)
		{
			ANS_BlackWaveFade_C.__Received_NotifyBegin_FunctionParams* ptr = stackalloc ANS_BlackWaveFade_C.__Received_NotifyBegin_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(ANS_BlackWaveFade_C.__Received_NotifyBegin_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_BlackWaveFade_C.__Received_NotifyBegin_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			ptr->TotalDuration = TotalDuration;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ANS_BlackWaveFade_C.__Received_NotifyBegin_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x06023735 RID: 145205 RVA: 0x009827E4 File Offset: 0x009809E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool Received_NotifyTick(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float FrameDeltaTime)
		{
			ANS_BlackWaveFade_C.__Received_NotifyTick_FunctionParams* ptr = stackalloc ANS_BlackWaveFade_C.__Received_NotifyTick_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(ANS_BlackWaveFade_C.__Received_NotifyTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_BlackWaveFade_C.__Received_NotifyTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			ptr->FrameDeltaTime = FrameDeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ANS_BlackWaveFade_C.__Received_NotifyTick_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x06023736 RID: 145206 RVA: 0x0098285C File Offset: 0x00980A5C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool Received_NotifyTick_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float FrameDeltaTime)
		{
			ANS_BlackWaveFade_C.__Received_NotifyTick_FunctionParams* ptr = stackalloc ANS_BlackWaveFade_C.__Received_NotifyTick_FunctionParams[(UIntPtr)127] + 15L / (long)sizeof(ANS_BlackWaveFade_C.__Received_NotifyTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ANS_BlackWaveFade_C.__Received_NotifyTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			ptr->FrameDeltaTime = FrameDeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ANS_BlackWaveFade_C.__Received_NotifyTick_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x06023737 RID: 145207 RVA: 0x009828D5 File Offset: 0x00980AD5
		protected ANS_BlackWaveFade_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040120B2 RID: 73906
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/BlackWaveWater/ANS_BlackWaveFade.ANS_BlackWaveFade_C";

		// Token: 0x040120B3 RID: 73907
		private static IntPtr _ClassPtr;

		// Token: 0x040120B4 RID: 73908
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040120B5 RID: 73909
		internal static int __PropertyOffset_0;

		// Token: 0x040120B6 RID: 73910
		internal static int __PropertyOffset_1;

		// Token: 0x040120B7 RID: 73911
		internal static int __PropertyOffset_2;

		// Token: 0x040120B8 RID: 73912
		internal static int __PropertyOffset_3;

		// Token: 0x040120B9 RID: 73913
		private FKuroCurveFloat _FadeOpacityCurve;

		// Token: 0x040120BA RID: 73914
		internal static int __PropertyOffset_4;

		// Token: 0x040120BB RID: 73915
		private FKuroCurveFloat _FadeRadiusCurve;

		// Token: 0x040120BC RID: 73916
		private static IntPtr __Received_NotifyEnd_NativeFunctionPtr;

		// Token: 0x040120BD RID: 73917
		private static IntPtr __InitParams_NativeFunctionPtr;

		// Token: 0x040120BE RID: 73918
		private static IntPtr __Received_NotifyBegin_NativeFunctionPtr;

		// Token: 0x040120BF RID: 73919
		private static IntPtr __Received_NotifyTick_NativeFunctionPtr;

		// Token: 0x02009CE1 RID: 40161
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected new ref struct __Received_NotifyEnd_FunctionParams
		{
			// Token: 0x04032666 RID: 206438
			[FieldOffset(0)]
			public IntPtr MeshComp;

			// Token: 0x04032667 RID: 206439
			[FieldOffset(8)]
			public IntPtr Animation;

			// Token: 0x04032668 RID: 206440
			[FieldOffset(16)]
			public bool __Result;
		}

		// Token: 0x02009CE2 RID: 40162
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __InitParams_FunctionParams
		{
			// Token: 0x04032669 RID: 206441
			[FieldOffset(0)]
			public IntPtr WorldContextObject;
		}

		// Token: 0x02009CE3 RID: 40163
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected new ref struct __Received_NotifyBegin_FunctionParams
		{
			// Token: 0x0403266A RID: 206442
			[FieldOffset(0)]
			public IntPtr MeshComp;

			// Token: 0x0403266B RID: 206443
			[FieldOffset(8)]
			public IntPtr Animation;

			// Token: 0x0403266C RID: 206444
			[FieldOffset(16)]
			public float TotalDuration;

			// Token: 0x0403266D RID: 206445
			[FieldOffset(20)]
			public bool __Result;
		}

		// Token: 0x02009CE4 RID: 40164
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 112)]
		protected new ref struct __Received_NotifyTick_FunctionParams
		{
			// Token: 0x0403266E RID: 206446
			[FieldOffset(0)]
			public IntPtr MeshComp;

			// Token: 0x0403266F RID: 206447
			[FieldOffset(8)]
			public IntPtr Animation;

			// Token: 0x04032670 RID: 206448
			[FieldOffset(16)]
			public float FrameDeltaTime;

			// Token: 0x04032671 RID: 206449
			[FieldOffset(20)]
			public bool __Result;
		}
	}
}
