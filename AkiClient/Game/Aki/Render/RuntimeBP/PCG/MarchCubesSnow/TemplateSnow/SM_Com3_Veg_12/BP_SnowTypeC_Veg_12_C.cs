using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Com3_Veg_12
{
	// Token: 0x02003BD2 RID: 15314
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_12/BP_SnowTypeC_Veg_12.BP_SnowTypeC_Veg_12_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeC_Veg_12_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060225CD RID: 140749 RVA: 0x00963651 File Offset: 0x00961851
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeC_Veg_12_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_12/BP_SnowTypeC_Veg_12.BP_SnowTypeC_Veg_12_C");
			}
			return BP_SnowTypeC_Veg_12_C._ClassPtr;
		}

		// Token: 0x060225CE RID: 140750 RVA: 0x00963678 File Offset: 0x00961878
		public BP_SnowTypeC_Veg_12_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeC_Veg_12_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060225CF RID: 140751 RVA: 0x009636A0 File Offset: 0x009618A0
		[NullableContext(1)]
		public BP_SnowTypeC_Veg_12_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeC_Veg_12_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700406B RID: 16491
		// (get) Token: 0x060225D0 RID: 140752 RVA: 0x009636D3 File Offset: 0x009618D3
		// (set) Token: 0x060225D1 RID: 140753 RVA: 0x009636E7 File Offset: 0x009618E7
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeC
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeC_Veg_12_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeC_Veg_12_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060225D2 RID: 140754 RVA: 0x009636FC File Offset: 0x009618FC
		protected BP_SnowTypeC_Veg_12_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011638 RID: 71224
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_12/BP_SnowTypeC_Veg_12.BP_SnowTypeC_Veg_12_C";

		// Token: 0x04011639 RID: 71225
		private static IntPtr _ClassPtr;

		// Token: 0x0401163A RID: 71226
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401163B RID: 71227
		internal new static int __PropertyOffset_0;
	}
}
