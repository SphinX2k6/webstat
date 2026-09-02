using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Com3_Veg_27
{
	// Token: 0x02003BCD RID: 15309
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_27/BP_SnowTypeA_Veg_27.BP_SnowTypeA_Veg_27_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeA_Veg_27_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060225AF RID: 140719 RVA: 0x009632CD File Offset: 0x009614CD
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeA_Veg_27_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_27/BP_SnowTypeA_Veg_27.BP_SnowTypeA_Veg_27_C");
			}
			return BP_SnowTypeA_Veg_27_C._ClassPtr;
		}

		// Token: 0x060225B0 RID: 140720 RVA: 0x009632F4 File Offset: 0x009614F4
		public BP_SnowTypeA_Veg_27_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeA_Veg_27_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060225B1 RID: 140721 RVA: 0x0096331C File Offset: 0x0096151C
		[NullableContext(1)]
		public BP_SnowTypeA_Veg_27_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeA_Veg_27_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004066 RID: 16486
		// (get) Token: 0x060225B2 RID: 140722 RVA: 0x0096334F File Offset: 0x0096154F
		// (set) Token: 0x060225B3 RID: 140723 RVA: 0x00963363 File Offset: 0x00961563
		[Nullable(2)]
		public unsafe UStaticMeshComponent SnowTypeA
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeA_Veg_27_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeA_Veg_27_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060225B4 RID: 140724 RVA: 0x00963378 File Offset: 0x00961578
		protected BP_SnowTypeA_Veg_27_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011624 RID: 71204
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_27/BP_SnowTypeA_Veg_27.BP_SnowTypeA_Veg_27_C";

		// Token: 0x04011625 RID: 71205
		private static IntPtr _ClassPtr;

		// Token: 0x04011626 RID: 71206
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011627 RID: 71207
		internal new static int __PropertyOffset_0;
	}
}
