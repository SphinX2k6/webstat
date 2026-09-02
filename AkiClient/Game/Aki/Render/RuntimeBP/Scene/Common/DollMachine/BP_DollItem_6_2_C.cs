using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AFE RID: 15102
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_6_2.BP_DollItem_6_2_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_6_2_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020715 RID: 132885 RVA: 0x0092C1D6 File Offset: 0x0092A3D6
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_6_2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_6_2.BP_DollItem_6_2_C");
			}
			return BP_DollItem_6_2_C._ClassPtr;
		}

		// Token: 0x06020716 RID: 132886 RVA: 0x0092C1FC File Offset: 0x0092A3FC
		public BP_DollItem_6_2_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_6_2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020717 RID: 132887 RVA: 0x0092C224 File Offset: 0x0092A424
		[NullableContext(1)]
		public BP_DollItem_6_2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_6_2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035A2 RID: 13730
		// (get) Token: 0x06020718 RID: 132888 RVA: 0x0092C257 File Offset: 0x0092A457
		// (set) Token: 0x06020719 RID: 132889 RVA: 0x0092C26B File Offset: 0x0092A46B
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_6_2_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_6_2_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170035A3 RID: 13731
		// (get) Token: 0x0602071A RID: 132890 RVA: 0x0092C280 File Offset: 0x0092A480
		// (set) Token: 0x0602071B RID: 132891 RVA: 0x0092C294 File Offset: 0x0092A494
		public unsafe USkeletalMeshComponent EpropJiwawa06Tiao1Md10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_6_2_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_6_2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602071C RID: 132892 RVA: 0x0092C2A9 File Offset: 0x0092A4A9
		protected BP_DollItem_6_2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010366 RID: 66406
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_6_2.BP_DollItem_6_2_C";

		// Token: 0x04010367 RID: 66407
		private static IntPtr _ClassPtr;

		// Token: 0x04010368 RID: 66408
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010369 RID: 66409
		internal new static int __PropertyOffset_0;

		// Token: 0x0401036A RID: 66410
		internal new static int __PropertyOffset_1;
	}
}
