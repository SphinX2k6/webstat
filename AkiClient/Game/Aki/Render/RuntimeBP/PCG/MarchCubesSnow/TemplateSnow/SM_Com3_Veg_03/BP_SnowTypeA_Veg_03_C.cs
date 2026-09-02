using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Com3_Veg_03
{
	// Token: 0x02003BD6 RID: 15318
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_03/BP_SnowTypeA_Veg_03.BP_SnowTypeA_Veg_03_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeA_Veg_03_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060225E5 RID: 140773 RVA: 0x00963921 File Offset: 0x00961B21
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeA_Veg_03_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_03/BP_SnowTypeA_Veg_03.BP_SnowTypeA_Veg_03_C");
			}
			return BP_SnowTypeA_Veg_03_C._ClassPtr;
		}

		// Token: 0x060225E6 RID: 140774 RVA: 0x00963948 File Offset: 0x00961B48
		public BP_SnowTypeA_Veg_03_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeA_Veg_03_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060225E7 RID: 140775 RVA: 0x00963970 File Offset: 0x00961B70
		[NullableContext(1)]
		public BP_SnowTypeA_Veg_03_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeA_Veg_03_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700406F RID: 16495
		// (get) Token: 0x060225E8 RID: 140776 RVA: 0x009639A3 File Offset: 0x00961BA3
		// (set) Token: 0x060225E9 RID: 140777 RVA: 0x009639B7 File Offset: 0x00961BB7
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeA
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeA_Veg_03_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeA_Veg_03_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060225EA RID: 140778 RVA: 0x009639CC File Offset: 0x00961BCC
		protected BP_SnowTypeA_Veg_03_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011648 RID: 71240
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_03/BP_SnowTypeA_Veg_03.BP_SnowTypeA_Veg_03_C";

		// Token: 0x04011649 RID: 71241
		private static IntPtr _ClassPtr;

		// Token: 0x0401164A RID: 71242
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401164B RID: 71243
		internal new static int __PropertyOffset_0;
	}
}
