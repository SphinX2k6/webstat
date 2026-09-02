using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.PlanarReflection
{
	// Token: 0x02003D3C RID: 15676
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/PlanarReflection/BP_EffectPlanarReflection_Base.BP_EffectPlanarReflection_Base_C")]
	[UnrealStructLayout(1088, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1088)]
	public class BP_EffectPlanarReflection_Base_C : APlanarReflection, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060260C1 RID: 155841 RVA: 0x009CC7DA File Offset: 0x009CA9DA
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectPlanarReflection_Base_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/PlanarReflection/BP_EffectPlanarReflection_Base.BP_EffectPlanarReflection_Base_C");
			}
			return BP_EffectPlanarReflection_Base_C._ClassPtr;
		}

		// Token: 0x060260C2 RID: 155842 RVA: 0x009CC800 File Offset: 0x009CAA00
		public BP_EffectPlanarReflection_Base_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectPlanarReflection_Base_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060260C3 RID: 155843 RVA: 0x009CC828 File Offset: 0x009CAA28
		[NullableContext(1)]
		public BP_EffectPlanarReflection_Base_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectPlanarReflection_Base_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700553A RID: 21818
		// (get) Token: 0x060260C4 RID: 155844 RVA: 0x009CC85B File Offset: 0x009CAA5B
		// (set) Token: 0x060260C5 RID: 155845 RVA: 0x009CC86F File Offset: 0x009CAA6F
		public unsafe UStaticMeshComponent Sphere
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectPlanarReflection_Base_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectPlanarReflection_Base_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700553B RID: 21819
		// (get) Token: 0x060260C6 RID: 155846 RVA: 0x009CC884 File Offset: 0x009CAA84
		// (set) Token: 0x060260C7 RID: 155847 RVA: 0x009CC898 File Offset: 0x009CAA98
		public unsafe UStaticMeshComponent Plane
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectPlanarReflection_Base_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectPlanarReflection_Base_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700553C RID: 21820
		// (get) Token: 0x060260C8 RID: 155848 RVA: 0x009CC8AD File Offset: 0x009CAAAD
		// (set) Token: 0x060260C9 RID: 155849 RVA: 0x009CC8C1 File Offset: 0x009CAAC1
		public unsafe UMaterialInstanceDynamic MDI
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectPlanarReflection_Base_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectPlanarReflection_Base_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x060260CA RID: 155850 RVA: 0x009CC8D8 File Offset: 0x009CAAD8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetOpaticy(float Opacity)
		{
			BP_EffectPlanarReflection_Base_C.__SetOpaticy_FunctionParams* ptr = stackalloc BP_EffectPlanarReflection_Base_C.__SetOpaticy_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_EffectPlanarReflection_Base_C.__SetOpaticy_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_EffectPlanarReflection_Base_C.__SetOpaticy_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Opacity = Opacity;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectPlanarReflection_Base_C.__SetOpaticy_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x060260CB RID: 155851 RVA: 0x009CC91E File Offset: 0x009CAB1E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Setup()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_EffectPlanarReflection_Base_C.__Setup_NativeFunctionPtr, null);
		}

		// Token: 0x060260CC RID: 155852 RVA: 0x009CC932 File Offset: 0x009CAB32
		protected BP_EffectPlanarReflection_Base_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013B09 RID: 80649
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/PlanarReflection/BP_EffectPlanarReflection_Base.BP_EffectPlanarReflection_Base_C";

		// Token: 0x04013B0A RID: 80650
		private static IntPtr _ClassPtr;

		// Token: 0x04013B0B RID: 80651
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013B0C RID: 80652
		internal static int __PropertyOffset_0;

		// Token: 0x04013B0D RID: 80653
		internal static int __PropertyOffset_1;

		// Token: 0x04013B0E RID: 80654
		internal static int __PropertyOffset_2;

		// Token: 0x04013B0F RID: 80655
		private static IntPtr __SetOpaticy_NativeFunctionPtr;

		// Token: 0x04013B10 RID: 80656
		private static IntPtr __Setup_NativeFunctionPtr;

		// Token: 0x02009FF6 RID: 40950
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __SetOpaticy_FunctionParams
		{
			// Token: 0x04032BD1 RID: 207825
			[FieldOffset(0)]
			public float Opacity;
		}
	}
}
