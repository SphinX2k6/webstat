using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Com3_Veg_50
{
	// Token: 0x02003BCA RID: 15306
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_50/BP_SnowTypeA_Veg_50AS.BP_SnowTypeA_Veg_50AS_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeA_Veg_50AS_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602259D RID: 140701 RVA: 0x009630B1 File Offset: 0x009612B1
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeA_Veg_50AS_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_50/BP_SnowTypeA_Veg_50AS.BP_SnowTypeA_Veg_50AS_C");
			}
			return BP_SnowTypeA_Veg_50AS_C._ClassPtr;
		}

		// Token: 0x0602259E RID: 140702 RVA: 0x009630D8 File Offset: 0x009612D8
		public BP_SnowTypeA_Veg_50AS_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeA_Veg_50AS_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602259F RID: 140703 RVA: 0x00963100 File Offset: 0x00961300
		[NullableContext(1)]
		public BP_SnowTypeA_Veg_50AS_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeA_Veg_50AS_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004063 RID: 16483
		// (get) Token: 0x060225A0 RID: 140704 RVA: 0x00963133 File Offset: 0x00961333
		// (set) Token: 0x060225A1 RID: 140705 RVA: 0x00963147 File Offset: 0x00961347
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeA
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeA_Veg_50AS_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeA_Veg_50AS_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060225A2 RID: 140706 RVA: 0x0096315C File Offset: 0x0096135C
		protected BP_SnowTypeA_Veg_50AS_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011618 RID: 71192
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_50/BP_SnowTypeA_Veg_50AS.BP_SnowTypeA_Veg_50AS_C";

		// Token: 0x04011619 RID: 71193
		private static IntPtr _ClassPtr;

		// Token: 0x0401161A RID: 71194
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401161B RID: 71195
		internal new static int __PropertyOffset_0;
	}
}
