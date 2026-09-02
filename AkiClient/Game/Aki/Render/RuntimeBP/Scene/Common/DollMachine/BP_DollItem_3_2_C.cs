using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AF5 RID: 15093
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_3_2.BP_DollItem_3_2_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_3_2_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060206CB RID: 132811 RVA: 0x0092B9F2 File Offset: 0x00929BF2
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_3_2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_3_2.BP_DollItem_3_2_C");
			}
			return BP_DollItem_3_2_C._ClassPtr;
		}

		// Token: 0x060206CC RID: 132812 RVA: 0x0092BA18 File Offset: 0x00929C18
		public BP_DollItem_3_2_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_3_2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060206CD RID: 132813 RVA: 0x0092BA40 File Offset: 0x00929C40
		[NullableContext(1)]
		public BP_DollItem_3_2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_3_2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700358F RID: 13711
		// (get) Token: 0x060206CE RID: 132814 RVA: 0x0092BA73 File Offset: 0x00929C73
		// (set) Token: 0x060206CF RID: 132815 RVA: 0x0092BA87 File Offset: 0x00929C87
		public unsafe UPointLightComponent PointLight1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_3_2_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_3_2_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003590 RID: 13712
		// (get) Token: 0x060206D0 RID: 132816 RVA: 0x0092BA9C File Offset: 0x00929C9C
		// (set) Token: 0x060206D1 RID: 132817 RVA: 0x0092BAB0 File Offset: 0x00929CB0
		public unsafe USkeletalMeshComponent EpropJiwawa03AppleMd10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_3_2_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_3_2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060206D2 RID: 132818 RVA: 0x0092BAC5 File Offset: 0x00929CC5
		protected BP_DollItem_3_2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010338 RID: 66360
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_3_2.BP_DollItem_3_2_C";

		// Token: 0x04010339 RID: 66361
		private static IntPtr _ClassPtr;

		// Token: 0x0401033A RID: 66362
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401033B RID: 66363
		internal new static int __PropertyOffset_0;

		// Token: 0x0401033C RID: 66364
		internal new static int __PropertyOffset_1;
	}
}
