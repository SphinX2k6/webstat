using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AEF RID: 15087
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_1_2.BP_DollItem_1_2_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_1_2_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602069B RID: 132763 RVA: 0x0092B4CA File Offset: 0x009296CA
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_1_2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_1_2.BP_DollItem_1_2_C");
			}
			return BP_DollItem_1_2_C._ClassPtr;
		}

		// Token: 0x0602069C RID: 132764 RVA: 0x0092B4F0 File Offset: 0x009296F0
		public BP_DollItem_1_2_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_1_2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602069D RID: 132765 RVA: 0x0092B518 File Offset: 0x00929718
		[NullableContext(1)]
		public BP_DollItem_1_2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_1_2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003583 RID: 13699
		// (get) Token: 0x0602069E RID: 132766 RVA: 0x0092B54B File Offset: 0x0092974B
		// (set) Token: 0x0602069F RID: 132767 RVA: 0x0092B55F File Offset: 0x0092975F
		public unsafe USkeletalMeshComponent EpropJiwawa01LDoorMd10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_1_2_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_1_2_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003584 RID: 13700
		// (get) Token: 0x060206A0 RID: 132768 RVA: 0x0092B574 File Offset: 0x00929774
		// (set) Token: 0x060206A1 RID: 132769 RVA: 0x0092B588 File Offset: 0x00929788
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_1_2_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_1_2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060206A2 RID: 132770 RVA: 0x0092B59D File Offset: 0x0092979D
		protected BP_DollItem_1_2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401031A RID: 66330
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_1_2.BP_DollItem_1_2_C";

		// Token: 0x0401031B RID: 66331
		private static IntPtr _ClassPtr;

		// Token: 0x0401031C RID: 66332
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401031D RID: 66333
		internal new static int __PropertyOffset_0;

		// Token: 0x0401031E RID: 66334
		internal new static int __PropertyOffset_1;
	}
}
