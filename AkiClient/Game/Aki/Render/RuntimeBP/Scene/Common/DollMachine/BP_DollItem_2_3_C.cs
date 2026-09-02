using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AF3 RID: 15091
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_2_3.BP_DollItem_2_3_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_2_3_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060206BB RID: 132795 RVA: 0x0092B83A File Offset: 0x00929A3A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_2_3_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_2_3.BP_DollItem_2_3_C");
			}
			return BP_DollItem_2_3_C._ClassPtr;
		}

		// Token: 0x060206BC RID: 132796 RVA: 0x0092B860 File Offset: 0x00929A60
		public BP_DollItem_2_3_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_2_3_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060206BD RID: 132797 RVA: 0x0092B888 File Offset: 0x00929A88
		[NullableContext(1)]
		public BP_DollItem_2_3_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_2_3_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700358B RID: 13707
		// (get) Token: 0x060206BE RID: 132798 RVA: 0x0092B8BB File Offset: 0x00929ABB
		// (set) Token: 0x060206BF RID: 132799 RVA: 0x0092B8CF File Offset: 0x00929ACF
		public unsafe UPointLightComponent PointLight1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_2_3_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_2_3_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700358C RID: 13708
		// (get) Token: 0x060206C0 RID: 132800 RVA: 0x0092B8E4 File Offset: 0x00929AE4
		// (set) Token: 0x060206C1 RID: 132801 RVA: 0x0092B8F8 File Offset: 0x00929AF8
		public unsafe USkeletalMeshComponent EpropJiwawa02QiaoMd10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_2_3_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_2_3_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060206C2 RID: 132802 RVA: 0x0092B90D File Offset: 0x00929B0D
		protected BP_DollItem_2_3_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401032E RID: 66350
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_2_3.BP_DollItem_2_3_C";

		// Token: 0x0401032F RID: 66351
		private static IntPtr _ClassPtr;

		// Token: 0x04010330 RID: 66352
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010331 RID: 66353
		internal new static int __PropertyOffset_0;

		// Token: 0x04010332 RID: 66354
		internal new static int __PropertyOffset_1;
	}
}
