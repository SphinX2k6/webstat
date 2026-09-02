using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AF1 RID: 15089
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_2_1.BP_DollItem_2_1_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_2_1_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060206AB RID: 132779 RVA: 0x0092B682 File Offset: 0x00929882
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_2_1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_2_1.BP_DollItem_2_1_C");
			}
			return BP_DollItem_2_1_C._ClassPtr;
		}

		// Token: 0x060206AC RID: 132780 RVA: 0x0092B6A8 File Offset: 0x009298A8
		public BP_DollItem_2_1_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_2_1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060206AD RID: 132781 RVA: 0x0092B6D0 File Offset: 0x009298D0
		[NullableContext(1)]
		public BP_DollItem_2_1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_2_1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003587 RID: 13703
		// (get) Token: 0x060206AE RID: 132782 RVA: 0x0092B703 File Offset: 0x00929903
		// (set) Token: 0x060206AF RID: 132783 RVA: 0x0092B717 File Offset: 0x00929917
		public unsafe UPointLightComponent PointLight1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_2_1_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_2_1_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003588 RID: 13704
		// (get) Token: 0x060206B0 RID: 132784 RVA: 0x0092B72C File Offset: 0x0092992C
		// (set) Token: 0x060206B1 RID: 132785 RVA: 0x0092B740 File Offset: 0x00929940
		public unsafe USkeletalMeshComponent EpropJiwawa02Md10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_2_1_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_2_1_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060206B2 RID: 132786 RVA: 0x0092B755 File Offset: 0x00929955
		protected BP_DollItem_2_1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010324 RID: 66340
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_2_1.BP_DollItem_2_1_C";

		// Token: 0x04010325 RID: 66341
		private static IntPtr _ClassPtr;

		// Token: 0x04010326 RID: 66342
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010327 RID: 66343
		internal new static int __PropertyOffset_0;

		// Token: 0x04010328 RID: 66344
		internal new static int __PropertyOffset_1;
	}
}
