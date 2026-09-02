using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Com3_Veg_50
{
	// Token: 0x02003BCB RID: 15307
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_50/BP_SnowTypeB_Veg_50AS.BP_SnowTypeB_Veg_50AS_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeB_Veg_50AS_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060225A3 RID: 140707 RVA: 0x00963165 File Offset: 0x00961365
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeB_Veg_50AS_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_50/BP_SnowTypeB_Veg_50AS.BP_SnowTypeB_Veg_50AS_C");
			}
			return BP_SnowTypeB_Veg_50AS_C._ClassPtr;
		}

		// Token: 0x060225A4 RID: 140708 RVA: 0x0096318C File Offset: 0x0096138C
		public BP_SnowTypeB_Veg_50AS_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeB_Veg_50AS_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060225A5 RID: 140709 RVA: 0x009631B4 File Offset: 0x009613B4
		[NullableContext(1)]
		public BP_SnowTypeB_Veg_50AS_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeB_Veg_50AS_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004064 RID: 16484
		// (get) Token: 0x060225A6 RID: 140710 RVA: 0x009631E7 File Offset: 0x009613E7
		// (set) Token: 0x060225A7 RID: 140711 RVA: 0x009631FB File Offset: 0x009613FB
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeB
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeB_Veg_50AS_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeB_Veg_50AS_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060225A8 RID: 140712 RVA: 0x00963210 File Offset: 0x00961410
		protected BP_SnowTypeB_Veg_50AS_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401161C RID: 71196
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_50/BP_SnowTypeB_Veg_50AS.BP_SnowTypeB_Veg_50AS_C";

		// Token: 0x0401161D RID: 71197
		private static IntPtr _ClassPtr;

		// Token: 0x0401161E RID: 71198
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401161F RID: 71199
		internal new static int __PropertyOffset_0;
	}
}
