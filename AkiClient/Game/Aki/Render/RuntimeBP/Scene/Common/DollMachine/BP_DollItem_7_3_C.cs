using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B02 RID: 15106
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_7_3.BP_DollItem_7_3_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_7_3_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020735 RID: 132917 RVA: 0x0092C546 File Offset: 0x0092A746
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_7_3_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_7_3.BP_DollItem_7_3_C");
			}
			return BP_DollItem_7_3_C._ClassPtr;
		}

		// Token: 0x06020736 RID: 132918 RVA: 0x0092C56C File Offset: 0x0092A76C
		public BP_DollItem_7_3_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_7_3_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020737 RID: 132919 RVA: 0x0092C594 File Offset: 0x0092A794
		[NullableContext(1)]
		public BP_DollItem_7_3_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_7_3_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035AA RID: 13738
		// (get) Token: 0x06020738 RID: 132920 RVA: 0x0092C5C7 File Offset: 0x0092A7C7
		// (set) Token: 0x06020739 RID: 132921 RVA: 0x0092C5DB File Offset: 0x0092A7DB
		public unsafe UPointLightComponent PointLight1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_7_3_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_7_3_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170035AB RID: 13739
		// (get) Token: 0x0602073A RID: 132922 RVA: 0x0092C5F0 File Offset: 0x0092A7F0
		// (set) Token: 0x0602073B RID: 132923 RVA: 0x0092C604 File Offset: 0x0092A804
		public unsafe USkeletalMeshComponent EpropJiwawa07DitaiMd10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_7_3_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_7_3_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602073C RID: 132924 RVA: 0x0092C619 File Offset: 0x0092A819
		protected BP_DollItem_7_3_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401037A RID: 66426
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_7_3.BP_DollItem_7_3_C";

		// Token: 0x0401037B RID: 66427
		private static IntPtr _ClassPtr;

		// Token: 0x0401037C RID: 66428
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401037D RID: 66429
		internal new static int __PropertyOffset_0;

		// Token: 0x0401037E RID: 66430
		internal new static int __PropertyOffset_1;
	}
}
