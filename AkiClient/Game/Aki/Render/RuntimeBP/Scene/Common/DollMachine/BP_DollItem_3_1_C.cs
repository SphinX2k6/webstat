using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AF4 RID: 15092
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_3_1.BP_DollItem_3_1_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_3_1_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060206C3 RID: 132803 RVA: 0x0092B916 File Offset: 0x00929B16
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_3_1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_3_1.BP_DollItem_3_1_C");
			}
			return BP_DollItem_3_1_C._ClassPtr;
		}

		// Token: 0x060206C4 RID: 132804 RVA: 0x0092B93C File Offset: 0x00929B3C
		public BP_DollItem_3_1_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_3_1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060206C5 RID: 132805 RVA: 0x0092B964 File Offset: 0x00929B64
		[NullableContext(1)]
		public BP_DollItem_3_1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_3_1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700358D RID: 13709
		// (get) Token: 0x060206C6 RID: 132806 RVA: 0x0092B997 File Offset: 0x00929B97
		// (set) Token: 0x060206C7 RID: 132807 RVA: 0x0092B9AB File Offset: 0x00929BAB
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_3_1_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_3_1_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700358E RID: 13710
		// (get) Token: 0x060206C8 RID: 132808 RVA: 0x0092B9C0 File Offset: 0x00929BC0
		// (set) Token: 0x060206C9 RID: 132809 RVA: 0x0092B9D4 File Offset: 0x00929BD4
		public unsafe USkeletalMeshComponent EpropJiwawa03Md10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_3_1_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_3_1_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060206CA RID: 132810 RVA: 0x0092B9E9 File Offset: 0x00929BE9
		protected BP_DollItem_3_1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010333 RID: 66355
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_3_1.BP_DollItem_3_1_C";

		// Token: 0x04010334 RID: 66356
		private static IntPtr _ClassPtr;

		// Token: 0x04010335 RID: 66357
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010336 RID: 66358
		internal new static int __PropertyOffset_0;

		// Token: 0x04010337 RID: 66359
		internal new static int __PropertyOffset_1;
	}
}
