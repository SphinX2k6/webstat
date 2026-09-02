using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.PlanarReflection
{
	// Token: 0x02003D3E RID: 15678
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/PlanarReflection/BP_EffectPlanarReflection_Middle.BP_EffectPlanarReflection_Middle_C")]
	[UnrealStructLayout(1104, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1104)]
	public class BP_EffectPlanarReflection_Middle_C : BP_EffectPlanarReflection_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060260D5 RID: 155861 RVA: 0x009CCA16 File Offset: 0x009CAC16
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectPlanarReflection_Middle_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/PlanarReflection/BP_EffectPlanarReflection_Middle.BP_EffectPlanarReflection_Middle_C");
			}
			return BP_EffectPlanarReflection_Middle_C._ClassPtr;
		}

		// Token: 0x060260D6 RID: 155862 RVA: 0x009CCA3C File Offset: 0x009CAC3C
		public BP_EffectPlanarReflection_Middle_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectPlanarReflection_Middle_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060260D7 RID: 155863 RVA: 0x009CCA64 File Offset: 0x009CAC64
		[NullableContext(1)]
		public BP_EffectPlanarReflection_Middle_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectPlanarReflection_Middle_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700553F RID: 21823
		// (get) Token: 0x060260D8 RID: 155864 RVA: 0x009CCA97 File Offset: 0x009CAC97
		// (set) Token: 0x060260D9 RID: 155865 RVA: 0x009CCAAB File Offset: 0x009CACAB
		public unsafe UStaticMeshComponent Sphere_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectPlanarReflection_Middle_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectPlanarReflection_Middle_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005540 RID: 21824
		// (get) Token: 0x060260DA RID: 155866 RVA: 0x009CCAC0 File Offset: 0x009CACC0
		// (set) Token: 0x060260DB RID: 155867 RVA: 0x009CCAD4 File Offset: 0x009CACD4
		public unsafe UStaticMeshComponent Plane_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectPlanarReflection_Middle_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectPlanarReflection_Middle_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060260DC RID: 155868 RVA: 0x009CCAE9 File Offset: 0x009CACE9
		protected BP_EffectPlanarReflection_Middle_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013B16 RID: 80662
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/PlanarReflection/BP_EffectPlanarReflection_Middle.BP_EffectPlanarReflection_Middle_C";

		// Token: 0x04013B17 RID: 80663
		private static IntPtr _ClassPtr;

		// Token: 0x04013B18 RID: 80664
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013B19 RID: 80665
		internal new static int __PropertyOffset_0;

		// Token: 0x04013B1A RID: 80666
		internal new static int __PropertyOffset_1;
	}
}
