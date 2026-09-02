using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AFF RID: 15103
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_6_3.BP_DollItem_6_3_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_6_3_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602071D RID: 132893 RVA: 0x0092C2B2 File Offset: 0x0092A4B2
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_6_3_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_6_3.BP_DollItem_6_3_C");
			}
			return BP_DollItem_6_3_C._ClassPtr;
		}

		// Token: 0x0602071E RID: 132894 RVA: 0x0092C2D8 File Offset: 0x0092A4D8
		public BP_DollItem_6_3_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_6_3_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602071F RID: 132895 RVA: 0x0092C300 File Offset: 0x0092A500
		[NullableContext(1)]
		public BP_DollItem_6_3_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_6_3_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035A4 RID: 13732
		// (get) Token: 0x06020720 RID: 132896 RVA: 0x0092C333 File Offset: 0x0092A533
		// (set) Token: 0x06020721 RID: 132897 RVA: 0x0092C347 File Offset: 0x0092A547
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_6_3_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_6_3_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170035A5 RID: 13733
		// (get) Token: 0x06020722 RID: 132898 RVA: 0x0092C35C File Offset: 0x0092A55C
		// (set) Token: 0x06020723 RID: 132899 RVA: 0x0092C370 File Offset: 0x0092A570
		public unsafe USkeletalMeshComponent EpropJiwawa06Tiao1Md10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_6_3_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_6_3_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06020724 RID: 132900 RVA: 0x0092C385 File Offset: 0x0092A585
		protected BP_DollItem_6_3_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401036B RID: 66411
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_6_3.BP_DollItem_6_3_C";

		// Token: 0x0401036C RID: 66412
		private static IntPtr _ClassPtr;

		// Token: 0x0401036D RID: 66413
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401036E RID: 66414
		internal new static int __PropertyOffset_0;

		// Token: 0x0401036F RID: 66415
		internal new static int __PropertyOffset_1;
	}
}
