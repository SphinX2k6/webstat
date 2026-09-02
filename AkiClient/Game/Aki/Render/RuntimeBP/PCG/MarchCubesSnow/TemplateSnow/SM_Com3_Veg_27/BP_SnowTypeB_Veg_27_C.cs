using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Com3_Veg_27
{
	// Token: 0x02003BCE RID: 15310
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_27/BP_SnowTypeB_Veg_27.BP_SnowTypeB_Veg_27_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeB_Veg_27_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060225B5 RID: 140725 RVA: 0x00963381 File Offset: 0x00961581
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeB_Veg_27_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_27/BP_SnowTypeB_Veg_27.BP_SnowTypeB_Veg_27_C");
			}
			return BP_SnowTypeB_Veg_27_C._ClassPtr;
		}

		// Token: 0x060225B6 RID: 140726 RVA: 0x009633A8 File Offset: 0x009615A8
		public BP_SnowTypeB_Veg_27_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeB_Veg_27_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060225B7 RID: 140727 RVA: 0x009633D0 File Offset: 0x009615D0
		[NullableContext(1)]
		public BP_SnowTypeB_Veg_27_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeB_Veg_27_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004067 RID: 16487
		// (get) Token: 0x060225B8 RID: 140728 RVA: 0x00963403 File Offset: 0x00961603
		// (set) Token: 0x060225B9 RID: 140729 RVA: 0x00963417 File Offset: 0x00961617
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeB
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeB_Veg_27_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeB_Veg_27_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060225BA RID: 140730 RVA: 0x0096342C File Offset: 0x0096162C
		protected BP_SnowTypeB_Veg_27_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011628 RID: 71208
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_27/BP_SnowTypeB_Veg_27.BP_SnowTypeB_Veg_27_C";

		// Token: 0x04011629 RID: 71209
		private static IntPtr _ClassPtr;

		// Token: 0x0401162A RID: 71210
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401162B RID: 71211
		internal new static int __PropertyOffset_0;
	}
}
