using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B03 RID: 15107
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_8_1.BP_DollItem_8_1_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_8_1_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602073D RID: 132925 RVA: 0x0092C622 File Offset: 0x0092A822
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_8_1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_8_1.BP_DollItem_8_1_C");
			}
			return BP_DollItem_8_1_C._ClassPtr;
		}

		// Token: 0x0602073E RID: 132926 RVA: 0x0092C648 File Offset: 0x0092A848
		public BP_DollItem_8_1_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_8_1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602073F RID: 132927 RVA: 0x0092C670 File Offset: 0x0092A870
		[NullableContext(1)]
		public BP_DollItem_8_1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_8_1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035AC RID: 13740
		// (get) Token: 0x06020740 RID: 132928 RVA: 0x0092C6A3 File Offset: 0x0092A8A3
		// (set) Token: 0x06020741 RID: 132929 RVA: 0x0092C6B7 File Offset: 0x0092A8B7
		public unsafe UPointLightComponent PointLight1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_8_1_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_8_1_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170035AD RID: 13741
		// (get) Token: 0x06020742 RID: 132930 RVA: 0x0092C6CC File Offset: 0x0092A8CC
		// (set) Token: 0x06020743 RID: 132931 RVA: 0x0092C6E0 File Offset: 0x0092A8E0
		public unsafe USkeletalMeshComponent EpropJiwawa08Md10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_8_1_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_8_1_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06020744 RID: 132932 RVA: 0x0092C6F5 File Offset: 0x0092A8F5
		protected BP_DollItem_8_1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401037F RID: 66431
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_8_1.BP_DollItem_8_1_C";

		// Token: 0x04010380 RID: 66432
		private static IntPtr _ClassPtr;

		// Token: 0x04010381 RID: 66433
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010382 RID: 66434
		internal new static int __PropertyOffset_0;

		// Token: 0x04010383 RID: 66435
		internal new static int __PropertyOffset_1;
	}
}
