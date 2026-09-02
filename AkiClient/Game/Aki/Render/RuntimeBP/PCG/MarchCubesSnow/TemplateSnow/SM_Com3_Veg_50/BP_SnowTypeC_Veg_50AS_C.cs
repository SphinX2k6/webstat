using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Com3_Veg_50
{
	// Token: 0x02003BCC RID: 15308
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_50/BP_SnowTypeC_Veg_50AS.BP_SnowTypeC_Veg_50AS_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeC_Veg_50AS_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060225A9 RID: 140713 RVA: 0x00963219 File Offset: 0x00961419
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeC_Veg_50AS_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_50/BP_SnowTypeC_Veg_50AS.BP_SnowTypeC_Veg_50AS_C");
			}
			return BP_SnowTypeC_Veg_50AS_C._ClassPtr;
		}

		// Token: 0x060225AA RID: 140714 RVA: 0x00963240 File Offset: 0x00961440
		public BP_SnowTypeC_Veg_50AS_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeC_Veg_50AS_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060225AB RID: 140715 RVA: 0x00963268 File Offset: 0x00961468
		[NullableContext(1)]
		public BP_SnowTypeC_Veg_50AS_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeC_Veg_50AS_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004065 RID: 16485
		// (get) Token: 0x060225AC RID: 140716 RVA: 0x0096329B File Offset: 0x0096149B
		// (set) Token: 0x060225AD RID: 140717 RVA: 0x009632AF File Offset: 0x009614AF
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeC
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeC_Veg_50AS_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeC_Veg_50AS_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060225AE RID: 140718 RVA: 0x009632C4 File Offset: 0x009614C4
		protected BP_SnowTypeC_Veg_50AS_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011620 RID: 71200
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_50/BP_SnowTypeC_Veg_50AS.BP_SnowTypeC_Veg_50AS_C";

		// Token: 0x04011621 RID: 71201
		private static IntPtr _ClassPtr;

		// Token: 0x04011622 RID: 71202
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011623 RID: 71203
		internal new static int __PropertyOffset_0;
	}
}
