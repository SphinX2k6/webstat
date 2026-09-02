using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Com3_Veg_06
{
	// Token: 0x02003BD5 RID: 15317
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_06/BP_SnowTypeC_Veg_06.BP_SnowTypeC_Veg_06_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeC_Veg_06_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060225DF RID: 140767 RVA: 0x0096386D File Offset: 0x00961A6D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeC_Veg_06_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_06/BP_SnowTypeC_Veg_06.BP_SnowTypeC_Veg_06_C");
			}
			return BP_SnowTypeC_Veg_06_C._ClassPtr;
		}

		// Token: 0x060225E0 RID: 140768 RVA: 0x00963894 File Offset: 0x00961A94
		public BP_SnowTypeC_Veg_06_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeC_Veg_06_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060225E1 RID: 140769 RVA: 0x009638BC File Offset: 0x00961ABC
		[NullableContext(1)]
		public BP_SnowTypeC_Veg_06_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeC_Veg_06_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700406E RID: 16494
		// (get) Token: 0x060225E2 RID: 140770 RVA: 0x009638EF File Offset: 0x00961AEF
		// (set) Token: 0x060225E3 RID: 140771 RVA: 0x00963903 File Offset: 0x00961B03
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeC
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeC_Veg_06_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeC_Veg_06_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060225E4 RID: 140772 RVA: 0x00963918 File Offset: 0x00961B18
		protected BP_SnowTypeC_Veg_06_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011644 RID: 71236
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_06/BP_SnowTypeC_Veg_06.BP_SnowTypeC_Veg_06_C";

		// Token: 0x04011645 RID: 71237
		private static IntPtr _ClassPtr;

		// Token: 0x04011646 RID: 71238
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011647 RID: 71239
		internal new static int __PropertyOffset_0;
	}
}
