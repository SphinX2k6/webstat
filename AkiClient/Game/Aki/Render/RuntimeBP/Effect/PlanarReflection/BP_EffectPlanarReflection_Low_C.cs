using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.PlanarReflection
{
	// Token: 0x02003D3D RID: 15677
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/PlanarReflection/BP_EffectPlanarReflection_Low.BP_EffectPlanarReflection_Low_C")]
	[UnrealStructLayout(1104, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1104)]
	public class BP_EffectPlanarReflection_Low_C : BP_EffectPlanarReflection_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060260CD RID: 155853 RVA: 0x009CC93B File Offset: 0x009CAB3B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_EffectPlanarReflection_Low_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/PlanarReflection/BP_EffectPlanarReflection_Low.BP_EffectPlanarReflection_Low_C");
			}
			return BP_EffectPlanarReflection_Low_C._ClassPtr;
		}

		// Token: 0x060260CE RID: 155854 RVA: 0x009CC960 File Offset: 0x009CAB60
		public BP_EffectPlanarReflection_Low_C() : this(BuiltinUtils.AllocNativeUObject(BP_EffectPlanarReflection_Low_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060260CF RID: 155855 RVA: 0x009CC988 File Offset: 0x009CAB88
		[NullableContext(1)]
		public BP_EffectPlanarReflection_Low_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_EffectPlanarReflection_Low_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700553D RID: 21821
		// (get) Token: 0x060260D0 RID: 155856 RVA: 0x009CC9BB File Offset: 0x009CABBB
		// (set) Token: 0x060260D1 RID: 155857 RVA: 0x009CC9CF File Offset: 0x009CABCF
		public unsafe UStaticMeshComponent Sphere_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectPlanarReflection_Low_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectPlanarReflection_Low_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700553E RID: 21822
		// (get) Token: 0x060260D2 RID: 155858 RVA: 0x009CC9E4 File Offset: 0x009CABE4
		// (set) Token: 0x060260D3 RID: 155859 RVA: 0x009CC9F8 File Offset: 0x009CABF8
		public unsafe UStaticMeshComponent Plane_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectPlanarReflection_Low_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_EffectPlanarReflection_Low_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060260D4 RID: 155860 RVA: 0x009CCA0D File Offset: 0x009CAC0D
		protected BP_EffectPlanarReflection_Low_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013B11 RID: 80657
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/PlanarReflection/BP_EffectPlanarReflection_Low.BP_EffectPlanarReflection_Low_C";

		// Token: 0x04013B12 RID: 80658
		private static IntPtr _ClassPtr;

		// Token: 0x04013B13 RID: 80659
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013B14 RID: 80660
		internal new static int __PropertyOffset_0;

		// Token: 0x04013B15 RID: 80661
		internal new static int __PropertyOffset_1;
	}
}
