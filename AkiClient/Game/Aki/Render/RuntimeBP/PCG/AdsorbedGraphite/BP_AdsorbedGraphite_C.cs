using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.AdsorbedGraphite
{
	// Token: 0x02003C4A RID: 15434
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/AdsorbedGraphite/BP_AdsorbedGraphite.BP_AdsorbedGraphite_C")]
	[UnrealStructLayout(1376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1373)]
	public class BP_AdsorbedGraphite_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023885 RID: 145541 RVA: 0x00984D77 File Offset: 0x00982F77
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AdsorbedGraphite_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/AdsorbedGraphite/BP_AdsorbedGraphite.BP_AdsorbedGraphite_C");
			}
			return BP_AdsorbedGraphite_C._ClassPtr;
		}

		// Token: 0x06023886 RID: 145542 RVA: 0x00984D9C File Offset: 0x00982F9C
		public BP_AdsorbedGraphite_C() : this(BuiltinUtils.AllocNativeUObject(BP_AdsorbedGraphite_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023887 RID: 145543 RVA: 0x00984DC4 File Offset: 0x00982FC4
		[NullableContext(1)]
		public BP_AdsorbedGraphite_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AdsorbedGraphite_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170046F1 RID: 18161
		// (get) Token: 0x06023888 RID: 145544 RVA: 0x00984DF8 File Offset: 0x00982FF8
		// (set) Token: 0x06023889 RID: 145545 RVA: 0x00984E31 File Offset: 0x00983031
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_AdsorbedGraphite_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_AdsorbedGraphite_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170046F2 RID: 18162
		// (get) Token: 0x0602388A RID: 145546 RVA: 0x00984E52 File Offset: 0x00983052
		// (set) Token: 0x0602388B RID: 145547 RVA: 0x00984E66 File Offset: 0x00983066
		public unsafe UBoxComponent Box
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AdsorbedGraphite_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AdsorbedGraphite_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170046F3 RID: 18163
		// (get) Token: 0x0602388C RID: 145548 RVA: 0x00984E7B File Offset: 0x0098307B
		// (set) Token: 0x0602388D RID: 145549 RVA: 0x00984E8F File Offset: 0x0098308F
		public unsafe UNiagaraComponent NS_Fx_AdsorbedGraphite
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AdsorbedGraphite_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AdsorbedGraphite_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170046F4 RID: 18164
		// (get) Token: 0x0602388E RID: 145550 RVA: 0x00984EA4 File Offset: 0x009830A4
		// (set) Token: 0x0602388F RID: 145551 RVA: 0x00984EB8 File Offset: 0x009830B8
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AdsorbedGraphite_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AdsorbedGraphite_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x170046F5 RID: 18165
		// (get) Token: 0x06023890 RID: 145552 RVA: 0x00984ECD File Offset: 0x009830CD
		// (set) Token: 0x06023891 RID: 145553 RVA: 0x00984EE1 File Offset: 0x009830E1
		public unsafe UChildActorComponent EditorTicker
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UChildActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AdsorbedGraphite_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AdsorbedGraphite_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170046F6 RID: 18166
		// (get) Token: 0x06023892 RID: 145554 RVA: 0x00984EF6 File Offset: 0x009830F6
		// (set) Token: 0x06023893 RID: 145555 RVA: 0x00984F06 File Offset: 0x00983106
		public unsafe bool UsePlayerAsTheAdsorbedCenter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AdsorbedGraphite_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AdsorbedGraphite_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x170046F7 RID: 18167
		// (get) Token: 0x06023894 RID: 145556 RVA: 0x00984F17 File Offset: 0x00983117
		// (set) Token: 0x06023895 RID: 145557 RVA: 0x00984F2B File Offset: 0x0098312B
		public unsafe FVector AdsorbedCenter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AdsorbedGraphite_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AdsorbedGraphite_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170046F8 RID: 18168
		// (get) Token: 0x06023896 RID: 145558 RVA: 0x00984F40 File Offset: 0x00983140
		// (set) Token: 0x06023897 RID: 145559 RVA: 0x00984F50 File Offset: 0x00983150
		public unsafe float AdsorbedRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AdsorbedGraphite_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AdsorbedGraphite_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170046F9 RID: 18169
		// (get) Token: 0x06023898 RID: 145560 RVA: 0x00984F61 File Offset: 0x00983161
		// (set) Token: 0x06023899 RID: 145561 RVA: 0x00984F71 File Offset: 0x00983171
		public unsafe float AdsorbedIntensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AdsorbedGraphite_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AdsorbedGraphite_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170046FA RID: 18170
		// (get) Token: 0x0602389A RID: 145562 RVA: 0x00984F82 File Offset: 0x00983182
		// (set) Token: 0x0602389B RID: 145563 RVA: 0x00984F92 File Offset: 0x00983192
		public unsafe float AdsorbedSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AdsorbedGraphite_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AdsorbedGraphite_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170046FB RID: 18171
		// (get) Token: 0x0602389C RID: 145564 RVA: 0x00984FA3 File Offset: 0x009831A3
		// (set) Token: 0x0602389D RID: 145565 RVA: 0x00984FB3 File Offset: 0x009831B3
		public unsafe bool bPlayerOverlap
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AdsorbedGraphite_C.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AdsorbedGraphite_C.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602389E RID: 145566 RVA: 0x00984FC4 File Offset: 0x009831C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateParam()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AdsorbedGraphite_C.__UpdateParam_NativeFunctionPtr, null);
		}

		// Token: 0x0602389F RID: 145567 RVA: 0x00984FD8 File Offset: 0x009831D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AdsorbedGraphite_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x060238A0 RID: 145568 RVA: 0x00984FEC File Offset: 0x009831EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AdsorbedGraphite_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x060238A1 RID: 145569 RVA: 0x00985004 File Offset: 0x00983204
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_AdsorbedGraphite_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_AdsorbedGraphite_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_AdsorbedGraphite_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AdsorbedGraphite_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AdsorbedGraphite_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060238A2 RID: 145570 RVA: 0x0098504C File Offset: 0x0098324C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_AdsorbedGraphite_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_AdsorbedGraphite_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_AdsorbedGraphite_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AdsorbedGraphite_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AdsorbedGraphite_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060238A3 RID: 145571 RVA: 0x00985093 File Offset: 0x00983293
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EditorTick()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AdsorbedGraphite_C.__EditorTick_NativeFunctionPtr, null);
		}

		// Token: 0x060238A4 RID: 145572 RVA: 0x009850A7 File Offset: 0x009832A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SetParamFromSeq()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AdsorbedGraphite_C.__SetParamFromSeq_NativeFunctionPtr, null);
		}

		// Token: 0x060238A5 RID: 145573 RVA: 0x009850BC File Offset: 0x009832BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorBeginOverlap(AActor OtherActor)
		{
			BP_AdsorbedGraphite_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_AdsorbedGraphite_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_AdsorbedGraphite_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AdsorbedGraphite_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AdsorbedGraphite_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060238A6 RID: 145574 RVA: 0x00985114 File Offset: 0x00983314
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorBeginOverlap_Implementation(AActor OtherActor)
		{
			BP_AdsorbedGraphite_C.__ReceiveActorBeginOverlap_FunctionParams* ptr = stackalloc BP_AdsorbedGraphite_C.__ReceiveActorBeginOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_AdsorbedGraphite_C.__ReceiveActorBeginOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AdsorbedGraphite_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AdsorbedGraphite_C.__ReceiveActorBeginOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060238A7 RID: 145575 RVA: 0x0098516C File Offset: 0x0098336C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveActorEndOverlap(AActor OtherActor)
		{
			BP_AdsorbedGraphite_C.__ReceiveActorEndOverlap_FunctionParams* ptr = stackalloc BP_AdsorbedGraphite_C.__ReceiveActorEndOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_AdsorbedGraphite_C.__ReceiveActorEndOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AdsorbedGraphite_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AdsorbedGraphite_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060238A8 RID: 145576 RVA: 0x009851C4 File Offset: 0x009833C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveActorEndOverlap_Implementation(AActor OtherActor)
		{
			BP_AdsorbedGraphite_C.__ReceiveActorEndOverlap_FunctionParams* ptr = stackalloc BP_AdsorbedGraphite_C.__ReceiveActorEndOverlap_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_AdsorbedGraphite_C.__ReceiveActorEndOverlap_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AdsorbedGraphite_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OtherActor = ((OtherActor != null) ? OtherActor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AdsorbedGraphite_C.__ReceiveActorEndOverlap_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060238A9 RID: 145577 RVA: 0x0098521C File Offset: 0x0098341C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_AdsorbedGraphite(int EntryPoint)
		{
			BP_AdsorbedGraphite_C.__ExecuteUbergraph_BP_AdsorbedGraphite_FunctionParams* ptr = stackalloc BP_AdsorbedGraphite_C.__ExecuteUbergraph_BP_AdsorbedGraphite_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_AdsorbedGraphite_C.__ExecuteUbergraph_BP_AdsorbedGraphite_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AdsorbedGraphite_C.__ExecuteUbergraph_BP_AdsorbedGraphite_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AdsorbedGraphite_C.__ExecuteUbergraph_BP_AdsorbedGraphite_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x060238AA RID: 145578 RVA: 0x00985263 File Offset: 0x00983463
		protected BP_AdsorbedGraphite_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012183 RID: 74115
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/AdsorbedGraphite/BP_AdsorbedGraphite.BP_AdsorbedGraphite_C";

		// Token: 0x04012184 RID: 74116
		private static IntPtr _ClassPtr;

		// Token: 0x04012185 RID: 74117
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012186 RID: 74118
		internal static int __PropertyOffset_0;

		// Token: 0x04012187 RID: 74119
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012188 RID: 74120
		internal static int __PropertyOffset_1;

		// Token: 0x04012189 RID: 74121
		internal static int __PropertyOffset_2;

		// Token: 0x0401218A RID: 74122
		internal static int __PropertyOffset_3;

		// Token: 0x0401218B RID: 74123
		internal static int __PropertyOffset_4;

		// Token: 0x0401218C RID: 74124
		internal static int __PropertyOffset_5;

		// Token: 0x0401218D RID: 74125
		internal static int __PropertyOffset_6;

		// Token: 0x0401218E RID: 74126
		internal static int __PropertyOffset_7;

		// Token: 0x0401218F RID: 74127
		internal static int __PropertyOffset_8;

		// Token: 0x04012190 RID: 74128
		internal static int __PropertyOffset_9;

		// Token: 0x04012191 RID: 74129
		internal static int __PropertyOffset_10;

		// Token: 0x04012192 RID: 74130
		private static IntPtr __UpdateParam_NativeFunctionPtr;

		// Token: 0x04012193 RID: 74131
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012194 RID: 74132
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04012195 RID: 74133
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x04012196 RID: 74134
		private static IntPtr __SetParamFromSeq_NativeFunctionPtr;

		// Token: 0x04012197 RID: 74135
		private static IntPtr __ReceiveActorBeginOverlap_NativeFunctionPtr;

		// Token: 0x04012198 RID: 74136
		private static IntPtr __ReceiveActorEndOverlap_NativeFunctionPtr;

		// Token: 0x04012199 RID: 74137
		private static IntPtr __ExecuteUbergraph_BP_AdsorbedGraphite_NativeFunctionPtr;

		// Token: 0x02009CFB RID: 40187
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403269B RID: 206491
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009CFC RID: 40188
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorBeginOverlap_FunctionParams
		{
			// Token: 0x0403269C RID: 206492
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x02009CFD RID: 40189
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveActorEndOverlap_FunctionParams
		{
			// Token: 0x0403269D RID: 206493
			[FieldOffset(0)]
			public IntPtr OtherActor;
		}

		// Token: 0x02009CFE RID: 40190
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_BP_AdsorbedGraphite_FunctionParams
		{
			// Token: 0x0403269E RID: 206494
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
