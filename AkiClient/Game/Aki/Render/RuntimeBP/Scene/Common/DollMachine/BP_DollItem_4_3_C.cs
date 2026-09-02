using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AF9 RID: 15097
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_4_3.BP_DollItem_4_3_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_4_3_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060206ED RID: 132845 RVA: 0x0092BD8B File Offset: 0x00929F8B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_4_3_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_4_3.BP_DollItem_4_3_C");
			}
			return BP_DollItem_4_3_C._ClassPtr;
		}

		// Token: 0x060206EE RID: 132846 RVA: 0x0092BDB0 File Offset: 0x00929FB0
		public BP_DollItem_4_3_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_4_3_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060206EF RID: 132847 RVA: 0x0092BDD8 File Offset: 0x00929FD8
		[NullableContext(1)]
		public BP_DollItem_4_3_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_4_3_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003598 RID: 13720
		// (get) Token: 0x060206F0 RID: 132848 RVA: 0x0092BE0B File Offset: 0x0092A00B
		// (set) Token: 0x060206F1 RID: 132849 RVA: 0x0092BE1F File Offset: 0x0092A01F
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_4_3_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_4_3_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003599 RID: 13721
		// (get) Token: 0x060206F2 RID: 132850 RVA: 0x0092BE34 File Offset: 0x0092A034
		// (set) Token: 0x060206F3 RID: 132851 RVA: 0x0092BE48 File Offset: 0x0092A048
		public unsafe USkeletalMeshComponent EpropJiwawa04PoolMd10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_4_3_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_4_3_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060206F4 RID: 132852 RVA: 0x0092BE5D File Offset: 0x0092A05D
		protected BP_DollItem_4_3_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401034D RID: 66381
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_4_3.BP_DollItem_4_3_C";

		// Token: 0x0401034E RID: 66382
		private static IntPtr _ClassPtr;

		// Token: 0x0401034F RID: 66383
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010350 RID: 66384
		internal new static int __PropertyOffset_0;

		// Token: 0x04010351 RID: 66385
		internal new static int __PropertyOffset_1;
	}
}
