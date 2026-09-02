using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AF0 RID: 15088
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_1_3.BP_DollItem_1_3_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_1_3_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060206A3 RID: 132771 RVA: 0x0092B5A6 File Offset: 0x009297A6
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_1_3_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_1_3.BP_DollItem_1_3_C");
			}
			return BP_DollItem_1_3_C._ClassPtr;
		}

		// Token: 0x060206A4 RID: 132772 RVA: 0x0092B5CC File Offset: 0x009297CC
		public BP_DollItem_1_3_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_1_3_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060206A5 RID: 132773 RVA: 0x0092B5F4 File Offset: 0x009297F4
		[NullableContext(1)]
		public BP_DollItem_1_3_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_1_3_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003585 RID: 13701
		// (get) Token: 0x060206A6 RID: 132774 RVA: 0x0092B627 File Offset: 0x00929827
		// (set) Token: 0x060206A7 RID: 132775 RVA: 0x0092B63B File Offset: 0x0092983B
		public unsafe UPointLightComponent PointLight1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_1_3_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_1_3_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003586 RID: 13702
		// (get) Token: 0x060206A8 RID: 132776 RVA: 0x0092B650 File Offset: 0x00929850
		// (set) Token: 0x060206A9 RID: 132777 RVA: 0x0092B664 File Offset: 0x00929864
		public unsafe USkeletalMeshComponent EpropJiwawa01RDoorMd10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_1_3_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_1_3_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060206AA RID: 132778 RVA: 0x0092B679 File Offset: 0x00929879
		protected BP_DollItem_1_3_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401031F RID: 66335
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_1_3.BP_DollItem_1_3_C";

		// Token: 0x04010320 RID: 66336
		private static IntPtr _ClassPtr;

		// Token: 0x04010321 RID: 66337
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010322 RID: 66338
		internal new static int __PropertyOffset_0;

		// Token: 0x04010323 RID: 66339
		internal new static int __PropertyOffset_1;
	}
}
