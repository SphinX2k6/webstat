using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Com3_Veg_06
{
	// Token: 0x02003BD4 RID: 15316
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_06/BP_SnowTypeB_Veg_06.BP_SnowTypeB_Veg_06_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeB_Veg_06_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060225D9 RID: 140761 RVA: 0x009637B9 File Offset: 0x009619B9
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeB_Veg_06_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_06/BP_SnowTypeB_Veg_06.BP_SnowTypeB_Veg_06_C");
			}
			return BP_SnowTypeB_Veg_06_C._ClassPtr;
		}

		// Token: 0x060225DA RID: 140762 RVA: 0x009637E0 File Offset: 0x009619E0
		public BP_SnowTypeB_Veg_06_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeB_Veg_06_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060225DB RID: 140763 RVA: 0x00963808 File Offset: 0x00961A08
		[NullableContext(1)]
		public BP_SnowTypeB_Veg_06_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeB_Veg_06_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700406D RID: 16493
		// (get) Token: 0x060225DC RID: 140764 RVA: 0x0096383B File Offset: 0x00961A3B
		// (set) Token: 0x060225DD RID: 140765 RVA: 0x0096384F File Offset: 0x00961A4F
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeB
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeB_Veg_06_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeB_Veg_06_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060225DE RID: 140766 RVA: 0x00963864 File Offset: 0x00961A64
		protected BP_SnowTypeB_Veg_06_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011640 RID: 71232
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_06/BP_SnowTypeB_Veg_06.BP_SnowTypeB_Veg_06_C";

		// Token: 0x04011641 RID: 71233
		private static IntPtr _ClassPtr;

		// Token: 0x04011642 RID: 71234
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011643 RID: 71235
		internal new static int __PropertyOffset_0;
	}
}
