using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AF6 RID: 15094
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_3_3.BP_DollItem_3_3_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_3_3_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060206D3 RID: 132819 RVA: 0x0092BACE File Offset: 0x00929CCE
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_3_3_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_3_3.BP_DollItem_3_3_C");
			}
			return BP_DollItem_3_3_C._ClassPtr;
		}

		// Token: 0x060206D4 RID: 132820 RVA: 0x0092BAF4 File Offset: 0x00929CF4
		public BP_DollItem_3_3_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_3_3_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060206D5 RID: 132821 RVA: 0x0092BB1C File Offset: 0x00929D1C
		[NullableContext(1)]
		public BP_DollItem_3_3_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_3_3_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003591 RID: 13713
		// (get) Token: 0x060206D6 RID: 132822 RVA: 0x0092BB4F File Offset: 0x00929D4F
		// (set) Token: 0x060206D7 RID: 132823 RVA: 0x0092BB63 File Offset: 0x00929D63
		public unsafe UPointLightComponent PointLight1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_3_3_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_3_3_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003592 RID: 13714
		// (get) Token: 0x060206D8 RID: 132824 RVA: 0x0092BB78 File Offset: 0x00929D78
		// (set) Token: 0x060206D9 RID: 132825 RVA: 0x0092BB8C File Offset: 0x00929D8C
		public unsafe USkeletalMeshComponent EpropJiwawa03DengMd10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_3_3_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_3_3_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060206DA RID: 132826 RVA: 0x0092BBA1 File Offset: 0x00929DA1
		protected BP_DollItem_3_3_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401033D RID: 66365
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_3_3.BP_DollItem_3_3_C";

		// Token: 0x0401033E RID: 66366
		private static IntPtr _ClassPtr;

		// Token: 0x0401033F RID: 66367
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010340 RID: 66368
		internal new static int __PropertyOffset_0;

		// Token: 0x04010341 RID: 66369
		internal new static int __PropertyOffset_1;
	}
}
