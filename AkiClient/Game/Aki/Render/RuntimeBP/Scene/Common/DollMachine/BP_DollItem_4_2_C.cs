using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AF8 RID: 15096
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_4_2.BP_DollItem_4_2_C")]
	[UnrealStructLayout(1552, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1552)]
	public class BP_DollItem_4_2_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060206E3 RID: 132835 RVA: 0x0092BC86 File Offset: 0x00929E86
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_4_2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_4_2.BP_DollItem_4_2_C");
			}
			return BP_DollItem_4_2_C._ClassPtr;
		}

		// Token: 0x060206E4 RID: 132836 RVA: 0x0092BCAC File Offset: 0x00929EAC
		public BP_DollItem_4_2_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_4_2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060206E5 RID: 132837 RVA: 0x0092BCD4 File Offset: 0x00929ED4
		[NullableContext(1)]
		public BP_DollItem_4_2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_4_2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003595 RID: 13717
		// (get) Token: 0x060206E6 RID: 132838 RVA: 0x0092BD07 File Offset: 0x00929F07
		// (set) Token: 0x060206E7 RID: 132839 RVA: 0x0092BD1B File Offset: 0x00929F1B
		public unsafe USkeletalMeshComponent EpropJiwawa04YulouMd10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_4_2_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_4_2_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003596 RID: 13718
		// (get) Token: 0x060206E8 RID: 132840 RVA: 0x0092BD30 File Offset: 0x00929F30
		// (set) Token: 0x060206E9 RID: 132841 RVA: 0x0092BD44 File Offset: 0x00929F44
		public unsafe UPointLightComponent PointLight1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_4_2_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_4_2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003597 RID: 13719
		// (get) Token: 0x060206EA RID: 132842 RVA: 0x0092BD59 File Offset: 0x00929F59
		// (set) Token: 0x060206EB RID: 132843 RVA: 0x0092BD6D File Offset: 0x00929F6D
		public unsafe USkeletalMeshComponent EpropJiwawa04YujuMd10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_4_2_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_4_2_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x060206EC RID: 132844 RVA: 0x0092BD82 File Offset: 0x00929F82
		protected BP_DollItem_4_2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010347 RID: 66375
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_4_2.BP_DollItem_4_2_C";

		// Token: 0x04010348 RID: 66376
		private static IntPtr _ClassPtr;

		// Token: 0x04010349 RID: 66377
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401034A RID: 66378
		internal new static int __PropertyOffset_0;

		// Token: 0x0401034B RID: 66379
		internal new static int __PropertyOffset_1;

		// Token: 0x0401034C RID: 66380
		internal new static int __PropertyOffset_2;
	}
}
