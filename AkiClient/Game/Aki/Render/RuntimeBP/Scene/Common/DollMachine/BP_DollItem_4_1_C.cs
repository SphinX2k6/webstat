using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AF7 RID: 15095
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_4_1.BP_DollItem_4_1_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_4_1_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060206DB RID: 132827 RVA: 0x0092BBAA File Offset: 0x00929DAA
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_4_1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_4_1.BP_DollItem_4_1_C");
			}
			return BP_DollItem_4_1_C._ClassPtr;
		}

		// Token: 0x060206DC RID: 132828 RVA: 0x0092BBD0 File Offset: 0x00929DD0
		public BP_DollItem_4_1_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_4_1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060206DD RID: 132829 RVA: 0x0092BBF8 File Offset: 0x00929DF8
		[NullableContext(1)]
		public BP_DollItem_4_1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_4_1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003593 RID: 13715
		// (get) Token: 0x060206DE RID: 132830 RVA: 0x0092BC2B File Offset: 0x00929E2B
		// (set) Token: 0x060206DF RID: 132831 RVA: 0x0092BC3F File Offset: 0x00929E3F
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_4_1_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_4_1_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003594 RID: 13716
		// (get) Token: 0x060206E0 RID: 132832 RVA: 0x0092BC54 File Offset: 0x00929E54
		// (set) Token: 0x060206E1 RID: 132833 RVA: 0x0092BC68 File Offset: 0x00929E68
		public unsafe USkeletalMeshComponent EpropJiwawa04Md10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_4_1_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_4_1_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060206E2 RID: 132834 RVA: 0x0092BC7D File Offset: 0x00929E7D
		protected BP_DollItem_4_1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010342 RID: 66370
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_4_1.BP_DollItem_4_1_C";

		// Token: 0x04010343 RID: 66371
		private static IntPtr _ClassPtr;

		// Token: 0x04010344 RID: 66372
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010345 RID: 66373
		internal new static int __PropertyOffset_0;

		// Token: 0x04010346 RID: 66374
		internal new static int __PropertyOffset_1;
	}
}
