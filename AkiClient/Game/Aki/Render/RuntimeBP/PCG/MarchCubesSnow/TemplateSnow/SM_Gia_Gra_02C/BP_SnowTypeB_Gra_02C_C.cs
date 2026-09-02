using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Gia_Gra_02C
{
	// Token: 0x02003BC5 RID: 15301
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Gia_Gra_02C/BP_SnowTypeB_Gra_02C.BP_SnowTypeB_Gra_02C_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeB_Gra_02C_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602257F RID: 140671 RVA: 0x00962D2D File Offset: 0x00960F2D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeB_Gra_02C_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Gia_Gra_02C/BP_SnowTypeB_Gra_02C.BP_SnowTypeB_Gra_02C_C");
			}
			return BP_SnowTypeB_Gra_02C_C._ClassPtr;
		}

		// Token: 0x06022580 RID: 140672 RVA: 0x00962D54 File Offset: 0x00960F54
		public BP_SnowTypeB_Gra_02C_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeB_Gra_02C_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022581 RID: 140673 RVA: 0x00962D7C File Offset: 0x00960F7C
		[NullableContext(1)]
		public BP_SnowTypeB_Gra_02C_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeB_Gra_02C_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700405E RID: 16478
		// (get) Token: 0x06022582 RID: 140674 RVA: 0x00962DAF File Offset: 0x00960FAF
		// (set) Token: 0x06022583 RID: 140675 RVA: 0x00962DC3 File Offset: 0x00960FC3
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeB
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeB_Gra_02C_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeB_Gra_02C_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06022584 RID: 140676 RVA: 0x00962DD8 File Offset: 0x00960FD8
		protected BP_SnowTypeB_Gra_02C_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011604 RID: 71172
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Gia_Gra_02C/BP_SnowTypeB_Gra_02C.BP_SnowTypeB_Gra_02C_C";

		// Token: 0x04011605 RID: 71173
		private static IntPtr _ClassPtr;

		// Token: 0x04011606 RID: 71174
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011607 RID: 71175
		internal new static int __PropertyOffset_0;
	}
}
