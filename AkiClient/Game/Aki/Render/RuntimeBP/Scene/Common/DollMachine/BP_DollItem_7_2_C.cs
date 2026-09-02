using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B01 RID: 15105
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_7_2.BP_DollItem_7_2_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_7_2_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602072D RID: 132909 RVA: 0x0092C46A File Offset: 0x0092A66A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_7_2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_7_2.BP_DollItem_7_2_C");
			}
			return BP_DollItem_7_2_C._ClassPtr;
		}

		// Token: 0x0602072E RID: 132910 RVA: 0x0092C490 File Offset: 0x0092A690
		public BP_DollItem_7_2_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_7_2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602072F RID: 132911 RVA: 0x0092C4B8 File Offset: 0x0092A6B8
		[NullableContext(1)]
		public BP_DollItem_7_2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_7_2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035A8 RID: 13736
		// (get) Token: 0x06020730 RID: 132912 RVA: 0x0092C4EB File Offset: 0x0092A6EB
		// (set) Token: 0x06020731 RID: 132913 RVA: 0x0092C4FF File Offset: 0x0092A6FF
		public unsafe UPointLightComponent PointLight1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_7_2_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_7_2_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170035A9 RID: 13737
		// (get) Token: 0x06020732 RID: 132914 RVA: 0x0092C514 File Offset: 0x0092A714
		// (set) Token: 0x06020733 RID: 132915 RVA: 0x0092C528 File Offset: 0x0092A728
		public unsafe USkeletalMeshComponent EpropJiwawa07Md10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_7_2_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_7_2_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06020734 RID: 132916 RVA: 0x0092C53D File Offset: 0x0092A73D
		protected BP_DollItem_7_2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010375 RID: 66421
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_7_2.BP_DollItem_7_2_C";

		// Token: 0x04010376 RID: 66422
		private static IntPtr _ClassPtr;

		// Token: 0x04010377 RID: 66423
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010378 RID: 66424
		internal new static int __PropertyOffset_0;

		// Token: 0x04010379 RID: 66425
		internal new static int __PropertyOffset_1;
	}
}
