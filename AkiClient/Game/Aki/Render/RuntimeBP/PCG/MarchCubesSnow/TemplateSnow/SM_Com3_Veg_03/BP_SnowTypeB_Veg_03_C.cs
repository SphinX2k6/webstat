using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Com3_Veg_03
{
	// Token: 0x02003BD7 RID: 15319
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_03/BP_SnowTypeB_Veg_03.BP_SnowTypeB_Veg_03_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeB_Veg_03_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060225EB RID: 140779 RVA: 0x009639D5 File Offset: 0x00961BD5
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeB_Veg_03_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_03/BP_SnowTypeB_Veg_03.BP_SnowTypeB_Veg_03_C");
			}
			return BP_SnowTypeB_Veg_03_C._ClassPtr;
		}

		// Token: 0x060225EC RID: 140780 RVA: 0x009639FC File Offset: 0x00961BFC
		public BP_SnowTypeB_Veg_03_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeB_Veg_03_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060225ED RID: 140781 RVA: 0x00963A24 File Offset: 0x00961C24
		[NullableContext(1)]
		public BP_SnowTypeB_Veg_03_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeB_Veg_03_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004070 RID: 16496
		// (get) Token: 0x060225EE RID: 140782 RVA: 0x00963A57 File Offset: 0x00961C57
		// (set) Token: 0x060225EF RID: 140783 RVA: 0x00963A6B File Offset: 0x00961C6B
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeB
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeB_Veg_03_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeB_Veg_03_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060225F0 RID: 140784 RVA: 0x00963A80 File Offset: 0x00961C80
		protected BP_SnowTypeB_Veg_03_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401164C RID: 71244
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Com3_Veg_03/BP_SnowTypeB_Veg_03.BP_SnowTypeB_Veg_03_C";

		// Token: 0x0401164D RID: 71245
		private static IntPtr _ClassPtr;

		// Token: 0x0401164E RID: 71246
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401164F RID: 71247
		internal new static int __PropertyOffset_0;
	}
}
