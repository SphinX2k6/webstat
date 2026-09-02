using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.MarchCubesSnow.TemplateSnow.SM_Gia_Gra_02B
{
	// Token: 0x02003BC9 RID: 15305
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Gia_Gra_02B/BP_SnowTypeC_Gra_02B.BP_SnowTypeC_Gra_02B_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_SnowTypeC_Gra_02B_C : BP_MarchCubes_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022597 RID: 140695 RVA: 0x00962FFD File Offset: 0x009611FD
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SnowTypeC_Gra_02B_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Gia_Gra_02B/BP_SnowTypeC_Gra_02B.BP_SnowTypeC_Gra_02B_C");
			}
			return BP_SnowTypeC_Gra_02B_C._ClassPtr;
		}

		// Token: 0x06022598 RID: 140696 RVA: 0x00963024 File Offset: 0x00961224
		public BP_SnowTypeC_Gra_02B_C() : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeC_Gra_02B_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022599 RID: 140697 RVA: 0x0096304C File Offset: 0x0096124C
		[NullableContext(1)]
		public BP_SnowTypeC_Gra_02B_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SnowTypeC_Gra_02B_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004062 RID: 16482
		// (get) Token: 0x0602259A RID: 140698 RVA: 0x0096307F File Offset: 0x0096127F
		// (set) Token: 0x0602259B RID: 140699 RVA: 0x00963093 File Offset: 0x00961293
		[Nullable(2)]
		public unsafe UStaticMeshComponent SM_SnowTypeF
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeC_Gra_02B_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SnowTypeC_Gra_02B_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602259C RID: 140700 RVA: 0x009630A8 File Offset: 0x009612A8
		protected BP_SnowTypeC_Gra_02B_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011614 RID: 71188
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/MarchCubesSnow/TemplateSnow/SM_Gia_Gra_02B/BP_SnowTypeC_Gra_02B.BP_SnowTypeC_Gra_02B_C";

		// Token: 0x04011615 RID: 71189
		private static IntPtr _ClassPtr;

		// Token: 0x04011616 RID: 71190
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011617 RID: 71191
		internal new static int __PropertyOffset_0;
	}
}
