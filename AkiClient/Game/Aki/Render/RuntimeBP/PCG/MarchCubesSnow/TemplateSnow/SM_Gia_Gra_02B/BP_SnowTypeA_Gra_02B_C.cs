using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Gia_Gra_02B
{
	// Token: 0x02003BC7 RID: 15303
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Gia_Gra_02B/BP_SnowTypeA_Gra_02B.BP_SnowTypeA_Gra_02B_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeA_Gra_02B_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602258B RID: 140683 RVA: 0x00962E95 File Offset: 0x00961095
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeA_Gra_02B_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Gia_Gra_02B/BP_SnowTypeA_Gra_02B.BP_SnowTypeA_Gra_02B_C");
			}
			return BP_SnowTypeA_Gra_02B_C._ClassPtr;
		}

		// Token: 0x0602258C RID: 140684 RVA: 0x00962EBC File Offset: 0x009610BC
		public BP_SnowTypeA_Gra_02B_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeA_Gra_02B_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602258D RID: 140685 RVA: 0x00962EE4 File Offset: 0x009610E4
		[NullableContext(1)]
		public BP_SnowTypeA_Gra_02B_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeA_Gra_02B_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004060 RID: 16480
		// (get) Token: 0x0602258E RID: 140686 RVA: 0x00962F17 File Offset: 0x00961117
		// (set) Token: 0x0602258F RID: 140687 RVA: 0x00962F2B File Offset: 0x0096112B
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeD
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeA_Gra_02B_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeA_Gra_02B_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06022590 RID: 140688 RVA: 0x00962F40 File Offset: 0x00961140
		protected BP_SnowTypeA_Gra_02B_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401160C RID: 71180
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Gia_Gra_02B/BP_SnowTypeA_Gra_02B.BP_SnowTypeA_Gra_02B_C";

		// Token: 0x0401160D RID: 71181
		private static IntPtr _ClassPtr;

		// Token: 0x0401160E RID: 71182
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401160F RID: 71183
		internal new static int __PropertyOffset_0;
	}
}
