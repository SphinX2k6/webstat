using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Gia_Gra_02B
{
	// Token: 0x02003BC8 RID: 15304
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Gia_Gra_02B/BP_SnowTypeB_Gra_02B.BP_SnowTypeB_Gra_02B_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeB_Gra_02B_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022591 RID: 140689 RVA: 0x00962F49 File Offset: 0x00961149
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeB_Gra_02B_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Gia_Gra_02B/BP_SnowTypeB_Gra_02B.BP_SnowTypeB_Gra_02B_C");
			}
			return BP_SnowTypeB_Gra_02B_C._ClassPtr;
		}

		// Token: 0x06022592 RID: 140690 RVA: 0x00962F70 File Offset: 0x00961170
		public BP_SnowTypeB_Gra_02B_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeB_Gra_02B_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022593 RID: 140691 RVA: 0x00962F98 File Offset: 0x00961198
		[NullableContext(1)]
		public BP_SnowTypeB_Gra_02B_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeB_Gra_02B_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004061 RID: 16481
		// (get) Token: 0x06022594 RID: 140692 RVA: 0x00962FCB File Offset: 0x009611CB
		// (set) Token: 0x06022595 RID: 140693 RVA: 0x00962FDF File Offset: 0x009611DF
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeE
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeB_Gra_02B_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeB_Gra_02B_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06022596 RID: 140694 RVA: 0x00962FF4 File Offset: 0x009611F4
		protected BP_SnowTypeB_Gra_02B_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011610 RID: 71184
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Gia_Gra_02B/BP_SnowTypeB_Gra_02B.BP_SnowTypeB_Gra_02B_C";

		// Token: 0x04011611 RID: 71185
		private static IntPtr _ClassPtr;

		// Token: 0x04011612 RID: 71186
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011613 RID: 71187
		internal new static int __PropertyOffset_0;
	}
}
