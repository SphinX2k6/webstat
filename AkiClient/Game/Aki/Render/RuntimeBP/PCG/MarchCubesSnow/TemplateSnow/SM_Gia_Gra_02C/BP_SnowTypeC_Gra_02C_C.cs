using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Gia_Gra_02C
{
	// Token: 0x02003BC6 RID: 15302
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Gia_Gra_02C/BP_SnowTypeC_Gra_02C.BP_SnowTypeC_Gra_02C_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeC_Gra_02C_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022585 RID: 140677 RVA: 0x00962DE1 File Offset: 0x00960FE1
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeC_Gra_02C_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Gia_Gra_02C/BP_SnowTypeC_Gra_02C.BP_SnowTypeC_Gra_02C_C");
			}
			return BP_SnowTypeC_Gra_02C_C._ClassPtr;
		}

		// Token: 0x06022586 RID: 140678 RVA: 0x00962E08 File Offset: 0x00961008
		public BP_SnowTypeC_Gra_02C_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeC_Gra_02C_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022587 RID: 140679 RVA: 0x00962E30 File Offset: 0x00961030
		[NullableContext(1)]
		public BP_SnowTypeC_Gra_02C_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeC_Gra_02C_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700405F RID: 16479
		// (get) Token: 0x06022588 RID: 140680 RVA: 0x00962E63 File Offset: 0x00961063
		// (set) Token: 0x06022589 RID: 140681 RVA: 0x00962E77 File Offset: 0x00961077
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeD
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeC_Gra_02C_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeC_Gra_02C_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602258A RID: 140682 RVA: 0x00962E8C File Offset: 0x0096108C
		protected BP_SnowTypeC_Gra_02C_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011608 RID: 71176
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Gia_Gra_02C/BP_SnowTypeC_Gra_02C.BP_SnowTypeC_Gra_02C_C";

		// Token: 0x04011609 RID: 71177
		private static IntPtr _ClassPtr;

		// Token: 0x0401160A RID: 71178
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401160B RID: 71179
		internal new static int __PropertyOffset_0;
	}
}
