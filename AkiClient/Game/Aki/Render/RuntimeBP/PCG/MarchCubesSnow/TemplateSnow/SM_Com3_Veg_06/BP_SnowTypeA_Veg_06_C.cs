using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Com3_Veg_06
{
	// Token: 0x02003BD3 RID: 15315
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_06/BP_SnowTypeA_Veg_06.BP_SnowTypeA_Veg_06_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeA_Veg_06_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060225D3 RID: 140755 RVA: 0x00963705 File Offset: 0x00961905
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeA_Veg_06_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_06/BP_SnowTypeA_Veg_06.BP_SnowTypeA_Veg_06_C");
			}
			return BP_SnowTypeA_Veg_06_C._ClassPtr;
		}

		// Token: 0x060225D4 RID: 140756 RVA: 0x0096372C File Offset: 0x0096192C
		public BP_SnowTypeA_Veg_06_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeA_Veg_06_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060225D5 RID: 140757 RVA: 0x00963754 File Offset: 0x00961954
		[NullableContext(1)]
		public BP_SnowTypeA_Veg_06_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeA_Veg_06_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700406C RID: 16492
		// (get) Token: 0x060225D6 RID: 140758 RVA: 0x00963787 File Offset: 0x00961987
		// (set) Token: 0x060225D7 RID: 140759 RVA: 0x0096379B File Offset: 0x0096199B
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeA
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeA_Veg_06_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeA_Veg_06_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060225D8 RID: 140760 RVA: 0x009637B0 File Offset: 0x009619B0
		protected BP_SnowTypeA_Veg_06_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401163C RID: 71228
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_06/BP_SnowTypeA_Veg_06.BP_SnowTypeA_Veg_06_C";

		// Token: 0x0401163D RID: 71229
		private static IntPtr _ClassPtr;

		// Token: 0x0401163E RID: 71230
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401163F RID: 71231
		internal new static int __PropertyOffset_0;
	}
}
