using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.PlanarReflection
{
	// Token: 0x02003D3B RID: 15675
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/PlanarReflection/BP_AnimNotifyPlanarReflection.BP_AnimNotifyPlanarReflection_C")]
	[UnrealStructLayout(368, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 368)]
	public class BP_AnimNotifyPlanarReflection_C : UKuroAnimNotifyState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060260AF RID: 155823 RVA: 0x009CC380 File Offset: 0x009CA580
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AnimNotifyPlanarReflection_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/PlanarReflection/BP_AnimNotifyPlanarReflection.BP_AnimNotifyPlanarReflection_C");
			}
			return BP_AnimNotifyPlanarReflection_C._ClassPtr;
		}

		// Token: 0x060260B0 RID: 155824 RVA: 0x009CC3A4 File Offset: 0x009CA5A4
		public BP_AnimNotifyPlanarReflection_C() : this(BuiltinUtils.AllocNativeUObject(BP_AnimNotifyPlanarReflection_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060260B1 RID: 155825 RVA: 0x009CC3CC File Offset: 0x009CA5CC
		public BP_AnimNotifyPlanarReflection_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AnimNotifyPlanarReflection_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005536 RID: 21814
		// (get) Token: 0x060260B2 RID: 155826 RVA: 0x009CC3FF File Offset: 0x009CA5FF
		// (set) Token: 0x060260B3 RID: 155827 RVA: 0x009CC413 File Offset: 0x009CA613
		public unsafe FTransform Spawn_Transform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AnimNotifyPlanarReflection_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AnimNotifyPlanarReflection_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005537 RID: 21815
		// (get) Token: 0x060260B4 RID: 155828 RVA: 0x009CC428 File Offset: 0x009CA628
		// (set) Token: 0x060260B5 RID: 155829 RVA: 0x009CC43C File Offset: 0x009CA63C
		public unsafe FName Socket_Name
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AnimNotifyPlanarReflection_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AnimNotifyPlanarReflection_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005538 RID: 21816
		// (get) Token: 0x060260B6 RID: 155830 RVA: 0x009CC454 File Offset: 0x009CA654
		// (set) Token: 0x060260B7 RID: 155831 RVA: 0x009CC48D File Offset: 0x009CA68D
		public TMap<FName, TSoftObjectPtr<BP_EffectPlanarReflection_Base_C>> PlanarReflection
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, TSoftObjectPtr<BP_EffectPlanarReflection_Base_C>> result;
				if ((result = this._PlanarReflection) == null)
				{
					result = (this._PlanarReflection = new TMap<FName, TSoftObjectPtr<BP_EffectPlanarReflection_Base_C>>(base.NativePtr + (IntPtr)BP_AnimNotifyPlanarReflection_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				this.PlanarReflection.CopyAssign(value);
			}
		}

		// Token: 0x17005539 RID: 21817
		// (get) Token: 0x060260B8 RID: 155832 RVA: 0x009CC49C File Offset: 0x009CA69C
		// (set) Token: 0x060260B9 RID: 155833 RVA: 0x009CC4D5 File Offset: 0x009CA6D5
		public FKuroCurveFloat OpacityCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._OpacityCurve) == null)
				{
					result = (this._OpacityCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)BP_AnimNotifyPlanarReflection_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)BP_AnimNotifyPlanarReflection_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x060260BA RID: 155834 RVA: 0x009CC4F8 File Offset: 0x009CA6F8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool K2_NotifyTick(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float FrameDeltaTime)
		{
			BP_AnimNotifyPlanarReflection_C.__K2_NotifyTick_FunctionParams* ptr = stackalloc BP_AnimNotifyPlanarReflection_C.__K2_NotifyTick_FunctionParams[(UIntPtr)207] + 15L / (long)sizeof(BP_AnimNotifyPlanarReflection_C.__K2_NotifyTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimNotifyPlanarReflection_C.__K2_NotifyTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			ptr->FrameDeltaTime = FrameDeltaTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimNotifyPlanarReflection_C.__K2_NotifyTick_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x060260BB RID: 155835 RVA: 0x009CC574 File Offset: 0x009CA774
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float FrameDeltaTime)
		{
			BP_AnimNotifyPlanarReflection_C.__K2_NotifyTick_FunctionParams* ptr = stackalloc BP_AnimNotifyPlanarReflection_C.__K2_NotifyTick_FunctionParams[(UIntPtr)207] + 15L / (long)sizeof(BP_AnimNotifyPlanarReflection_C.__K2_NotifyTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimNotifyPlanarReflection_C.__K2_NotifyTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			ptr->FrameDeltaTime = FrameDeltaTime;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AnimNotifyPlanarReflection_C.__K2_NotifyTick_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x060260BC RID: 155836 RVA: 0x009CC5F0 File Offset: 0x009CA7F0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float TotalDuration)
		{
			BP_AnimNotifyPlanarReflection_C.__K2_NotifyBegin_FunctionParams* ptr = stackalloc BP_AnimNotifyPlanarReflection_C.__K2_NotifyBegin_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_AnimNotifyPlanarReflection_C.__K2_NotifyBegin_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimNotifyPlanarReflection_C.__K2_NotifyBegin_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			ptr->TotalDuration = TotalDuration;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimNotifyPlanarReflection_C.__K2_NotifyBegin_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x060260BD RID: 155837 RVA: 0x009CC66C File Offset: 0x009CA86C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation, float TotalDuration)
		{
			BP_AnimNotifyPlanarReflection_C.__K2_NotifyBegin_FunctionParams* ptr = stackalloc BP_AnimNotifyPlanarReflection_C.__K2_NotifyBegin_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_AnimNotifyPlanarReflection_C.__K2_NotifyBegin_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimNotifyPlanarReflection_C.__K2_NotifyBegin_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			ptr->TotalDuration = TotalDuration;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AnimNotifyPlanarReflection_C.__K2_NotifyBegin_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x060260BE RID: 155838 RVA: 0x009CC6E8 File Offset: 0x009CA8E8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation)
		{
			BP_AnimNotifyPlanarReflection_C.__K2_NotifyEnd_FunctionParams* ptr = stackalloc BP_AnimNotifyPlanarReflection_C.__K2_NotifyEnd_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(BP_AnimNotifyPlanarReflection_C.__K2_NotifyEnd_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimNotifyPlanarReflection_C.__K2_NotifyEnd_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimNotifyPlanarReflection_C.__K2_NotifyEnd_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x060260BF RID: 155839 RVA: 0x009CC75C File Offset: 0x009CA95C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation)
		{
			BP_AnimNotifyPlanarReflection_C.__K2_NotifyEnd_FunctionParams* ptr = stackalloc BP_AnimNotifyPlanarReflection_C.__K2_NotifyEnd_FunctionParams[(UIntPtr)151] + 15L / (long)sizeof(BP_AnimNotifyPlanarReflection_C.__K2_NotifyEnd_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimNotifyPlanarReflection_C.__K2_NotifyEnd_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AnimNotifyPlanarReflection_C.__K2_NotifyEnd_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x060260C0 RID: 155840 RVA: 0x009CC7D1 File Offset: 0x009CA9D1
		protected BP_AnimNotifyPlanarReflection_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013AFD RID: 80637
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/PlanarReflection/BP_AnimNotifyPlanarReflection.BP_AnimNotifyPlanarReflection_C";

		// Token: 0x04013AFE RID: 80638
		private static IntPtr _ClassPtr;

		// Token: 0x04013AFF RID: 80639
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013B00 RID: 80640
		internal static int __PropertyOffset_0;

		// Token: 0x04013B01 RID: 80641
		internal static int __PropertyOffset_1;

		// Token: 0x04013B02 RID: 80642
		internal static int __PropertyOffset_2;

		// Token: 0x04013B03 RID: 80643
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<FName, TSoftObjectPtr<BP_EffectPlanarReflection_Base_C>> _PlanarReflection;

		// Token: 0x04013B04 RID: 80644
		internal static int __PropertyOffset_3;

		// Token: 0x04013B05 RID: 80645
		[Nullable(2)]
		private FKuroCurveFloat _OpacityCurve;

		// Token: 0x04013B06 RID: 80646
		private static IntPtr __K2_NotifyTick_NativeFunctionPtr;

		// Token: 0x04013B07 RID: 80647
		private static IntPtr __K2_NotifyBegin_NativeFunctionPtr;

		// Token: 0x04013B08 RID: 80648
		private static IntPtr __K2_NotifyEnd_NativeFunctionPtr;

		// Token: 0x02009FF3 RID: 40947
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 192)]
		protected new ref struct __K2_NotifyTick_FunctionParams
		{
			// Token: 0x04032BC6 RID: 207814
			[FieldOffset(0)]
			public IntPtr MeshComp;

			// Token: 0x04032BC7 RID: 207815
			[FieldOffset(8)]
			public IntPtr Animation;

			// Token: 0x04032BC8 RID: 207816
			[FieldOffset(16)]
			public float FrameDeltaTime;

			// Token: 0x04032BC9 RID: 207817
			[FieldOffset(20)]
			public bool __Result;
		}

		// Token: 0x02009FF4 RID: 40948
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected new ref struct __K2_NotifyBegin_FunctionParams
		{
			// Token: 0x04032BCA RID: 207818
			[FieldOffset(0)]
			public IntPtr MeshComp;

			// Token: 0x04032BCB RID: 207819
			[FieldOffset(8)]
			public IntPtr Animation;

			// Token: 0x04032BCC RID: 207820
			[FieldOffset(16)]
			public float TotalDuration;

			// Token: 0x04032BCD RID: 207821
			[FieldOffset(20)]
			public bool __Result;
		}

		// Token: 0x02009FF5 RID: 40949
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 136)]
		protected new ref struct __K2_NotifyEnd_FunctionParams
		{
			// Token: 0x04032BCE RID: 207822
			[FieldOffset(0)]
			public IntPtr MeshComp;

			// Token: 0x04032BCF RID: 207823
			[FieldOffset(8)]
			public IntPtr Animation;

			// Token: 0x04032BD0 RID: 207824
			[FieldOffset(16)]
			public bool __Result;
		}
	}
}
