using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Gia_Gra_02C
{
	// Token: 0x02003BC4 RID: 15300
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Gia_Gra_02C/BP_SnowTypeA_Gra_02C.BP_SnowTypeA_Gra_02C_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeA_Gra_02C_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022579 RID: 140665 RVA: 0x00962C7B File Offset: 0x00960E7B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeA_Gra_02C_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Gia_Gra_02C/BP_SnowTypeA_Gra_02C.BP_SnowTypeA_Gra_02C_C");
			}
			return BP_SnowTypeA_Gra_02C_C._ClassPtr;
		}

		// Token: 0x0602257A RID: 140666 RVA: 0x00962CA0 File Offset: 0x00960EA0
		public BP_SnowTypeA_Gra_02C_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeA_Gra_02C_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602257B RID: 140667 RVA: 0x00962CC8 File Offset: 0x00960EC8
		[NullableContext(1)]
		public BP_SnowTypeA_Gra_02C_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeA_Gra_02C_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700405D RID: 16477
		// (get) Token: 0x0602257C RID: 140668 RVA: 0x00962CFB File Offset: 0x00960EFB
		// (set) Token: 0x0602257D RID: 140669 RVA: 0x00962D0F File Offset: 0x00960F0F
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeA
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeA_Gra_02C_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeA_Gra_02C_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602257E RID: 140670 RVA: 0x00962D24 File Offset: 0x00960F24
		protected BP_SnowTypeA_Gra_02C_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011600 RID: 71168
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Gia_Gra_02C/BP_SnowTypeA_Gra_02C.BP_SnowTypeA_Gra_02C_C";

		// Token: 0x04011601 RID: 71169
		private static IntPtr _ClassPtr;

		// Token: 0x04011602 RID: 71170
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011603 RID: 71171
		internal new static int __PropertyOffset_0;
	}
}
