using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Com3_Veg_27
{
	// Token: 0x02003BCF RID: 15311
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_27/BP_SnowTypeC_Veg_27.BP_SnowTypeC_Veg_27_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeC_Veg_27_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060225BB RID: 140731 RVA: 0x00963435 File Offset: 0x00961635
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeC_Veg_27_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_27/BP_SnowTypeC_Veg_27.BP_SnowTypeC_Veg_27_C");
			}
			return BP_SnowTypeC_Veg_27_C._ClassPtr;
		}

		// Token: 0x060225BC RID: 140732 RVA: 0x0096345C File Offset: 0x0096165C
		public BP_SnowTypeC_Veg_27_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeC_Veg_27_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060225BD RID: 140733 RVA: 0x00963484 File Offset: 0x00961684
		[NullableContext(1)]
		public BP_SnowTypeC_Veg_27_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeC_Veg_27_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004068 RID: 16488
		// (get) Token: 0x060225BE RID: 140734 RVA: 0x009634B7 File Offset: 0x009616B7
		// (set) Token: 0x060225BF RID: 140735 RVA: 0x009634CB File Offset: 0x009616CB
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeC
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeC_Veg_27_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeC_Veg_27_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060225C0 RID: 140736 RVA: 0x009634E0 File Offset: 0x009616E0
		protected BP_SnowTypeC_Veg_27_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401162C RID: 71212
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_27/BP_SnowTypeC_Veg_27.BP_SnowTypeC_Veg_27_C";

		// Token: 0x0401162D RID: 71213
		private static IntPtr _ClassPtr;

		// Token: 0x0401162E RID: 71214
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401162F RID: 71215
		internal new static int __PropertyOffset_0;
	}
}
