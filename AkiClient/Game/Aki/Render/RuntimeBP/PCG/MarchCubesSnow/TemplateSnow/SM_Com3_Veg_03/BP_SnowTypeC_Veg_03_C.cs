using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Com3_Veg_03
{
	// Token: 0x02003BD8 RID: 15320
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_03/BP_SnowTypeC_Veg_03.BP_SnowTypeC_Veg_03_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeC_Veg_03_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060225F1 RID: 140785 RVA: 0x00963A89 File Offset: 0x00961C89
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeC_Veg_03_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_03/BP_SnowTypeC_Veg_03.BP_SnowTypeC_Veg_03_C");
			}
			return BP_SnowTypeC_Veg_03_C._ClassPtr;
		}

		// Token: 0x060225F2 RID: 140786 RVA: 0x00963AB0 File Offset: 0x00961CB0
		public BP_SnowTypeC_Veg_03_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeC_Veg_03_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060225F3 RID: 140787 RVA: 0x00963AD8 File Offset: 0x00961CD8
		[NullableContext(1)]
		public BP_SnowTypeC_Veg_03_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeC_Veg_03_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004071 RID: 16497
		// (get) Token: 0x060225F4 RID: 140788 RVA: 0x00963B0B File Offset: 0x00961D0B
		// (set) Token: 0x060225F5 RID: 140789 RVA: 0x00963B1F File Offset: 0x00961D1F
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeC
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeC_Veg_03_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeC_Veg_03_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060225F6 RID: 140790 RVA: 0x00963B34 File Offset: 0x00961D34
		protected BP_SnowTypeC_Veg_03_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011650 RID: 71248
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_03/BP_SnowTypeC_Veg_03.BP_SnowTypeC_Veg_03_C";

		// Token: 0x04011651 RID: 71249
		private static IntPtr _ClassPtr;

		// Token: 0x04011652 RID: 71250
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011653 RID: 71251
		internal new static int __PropertyOffset_0;
	}
}
