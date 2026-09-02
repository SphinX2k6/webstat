using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Com3_Veg_12
{
	// Token: 0x02003BD0 RID: 15312
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_12/BP_SnowTypeA_Veg_12.BP_SnowTypeA_Veg_12_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeA_Veg_12_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060225C1 RID: 140737 RVA: 0x009634E9 File Offset: 0x009616E9
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeA_Veg_12_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_12/BP_SnowTypeA_Veg_12.BP_SnowTypeA_Veg_12_C");
			}
			return BP_SnowTypeA_Veg_12_C._ClassPtr;
		}

		// Token: 0x060225C2 RID: 140738 RVA: 0x00963510 File Offset: 0x00961710
		public BP_SnowTypeA_Veg_12_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeA_Veg_12_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060225C3 RID: 140739 RVA: 0x00963538 File Offset: 0x00961738
		[NullableContext(1)]
		public BP_SnowTypeA_Veg_12_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeA_Veg_12_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004069 RID: 16489
		// (get) Token: 0x060225C4 RID: 140740 RVA: 0x0096356B File Offset: 0x0096176B
		// (set) Token: 0x060225C5 RID: 140741 RVA: 0x0096357F File Offset: 0x0096177F
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeA
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeA_Veg_12_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeA_Veg_12_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060225C6 RID: 140742 RVA: 0x00963594 File Offset: 0x00961794
		protected BP_SnowTypeA_Veg_12_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011630 RID: 71216
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_12/BP_SnowTypeA_Veg_12.BP_SnowTypeA_Veg_12_C";

		// Token: 0x04011631 RID: 71217
		private static IntPtr _ClassPtr;

		// Token: 0x04011632 RID: 71218
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011633 RID: 71219
		internal new static int __PropertyOffset_0;
	}
}
