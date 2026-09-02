using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B04 RID: 15108
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_8_2.BP_DollItem_8_2_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_8_2_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020745 RID: 132933 RVA: 0x0092C6FE File Offset: 0x0092A8FE
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_8_2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_8_2.BP_DollItem_8_2_C");
			}
			return BP_DollItem_8_2_C._ClassPtr;
		}

		// Token: 0x06020746 RID: 132934 RVA: 0x0092C724 File Offset: 0x0092A924
		public BP_DollItem_8_2_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_8_2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020747 RID: 132935 RVA: 0x0092C74C File Offset: 0x0092A94C
		[NullableContext(1)]
		public BP_DollItem_8_2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_8_2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035AE RID: 13742
		// (get) Token: 0x06020748 RID: 132936 RVA: 0x0092C77F File Offset: 0x0092A97F
		// (set) Token: 0x06020749 RID: 132937 RVA: 0x0092C793 File Offset: 0x0092A993
		public unsafe UPointLightComponent PointLight1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_8_2_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_8_2_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170035AF RID: 13743
		// (get) Token: 0x0602074A RID: 132938 RVA: 0x0092C7A8 File Offset: 0x0092A9A8
		// (set) Token: 0x0602074B RID: 132939 RVA: 0x0092C7BC File Offset: 0x0092A9BC
		public unsafe USkeletalMeshComponent EpropJiwawa08SashMd10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_8_2_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_8_2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602074C RID: 132940 RVA: 0x0092C7D1 File Offset: 0x0092A9D1
		protected BP_DollItem_8_2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010384 RID: 66436
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_8_2.BP_DollItem_8_2_C";

		// Token: 0x04010385 RID: 66437
		private static IntPtr _ClassPtr;

		// Token: 0x04010386 RID: 66438
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010387 RID: 66439
		internal new static int __PropertyOffset_0;

		// Token: 0x04010388 RID: 66440
		internal new static int __PropertyOffset_1;
	}
}
