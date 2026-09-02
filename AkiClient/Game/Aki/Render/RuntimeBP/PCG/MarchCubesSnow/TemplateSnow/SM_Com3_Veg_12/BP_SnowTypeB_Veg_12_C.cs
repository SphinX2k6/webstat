using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Com3_Veg_12
{
	// Token: 0x02003BD1 RID: 15313
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_12/BP_SnowTypeB_Veg_12.BP_SnowTypeB_Veg_12_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeB_Veg_12_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060225C7 RID: 140743 RVA: 0x0096359D File Offset: 0x0096179D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeB_Veg_12_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_12/BP_SnowTypeB_Veg_12.BP_SnowTypeB_Veg_12_C");
			}
			return BP_SnowTypeB_Veg_12_C._ClassPtr;
		}

		// Token: 0x060225C8 RID: 140744 RVA: 0x009635C4 File Offset: 0x009617C4
		public BP_SnowTypeB_Veg_12_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeB_Veg_12_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060225C9 RID: 140745 RVA: 0x009635EC File Offset: 0x009617EC
		[NullableContext(1)]
		public BP_SnowTypeB_Veg_12_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeB_Veg_12_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700406A RID: 16490
		// (get) Token: 0x060225CA RID: 140746 RVA: 0x0096361F File Offset: 0x0096181F
		// (set) Token: 0x060225CB RID: 140747 RVA: 0x00963633 File Offset: 0x00961833
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeB
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeB_Veg_12_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeB_Veg_12_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060225CC RID: 140748 RVA: 0x00963648 File Offset: 0x00961848
		protected BP_SnowTypeB_Veg_12_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011634 RID: 71220
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_12/BP_SnowTypeB_Veg_12.BP_SnowTypeB_Veg_12_C";

		// Token: 0x04011635 RID: 71221
		private static IntPtr _ClassPtr;

		// Token: 0x04011636 RID: 71222
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011637 RID: 71223
		internal new static int __PropertyOffset_0;
	}
}
