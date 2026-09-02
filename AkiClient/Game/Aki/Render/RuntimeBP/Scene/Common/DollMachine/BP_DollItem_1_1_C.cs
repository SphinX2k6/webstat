using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003AEE RID: 15086
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_1_1.BP_DollItem_1_1_C")]
	[UnrealStructLayout(1544, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1544)]
	public class BP_DollItem_1_1_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020693 RID: 132755 RVA: 0x0092B3ED File Offset: 0x009295ED
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_1_1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_1_1.BP_DollItem_1_1_C");
			}
			return BP_DollItem_1_1_C._ClassPtr;
		}

		// Token: 0x06020694 RID: 132756 RVA: 0x0092B414 File Offset: 0x00929614
		public BP_DollItem_1_1_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_1_1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020695 RID: 132757 RVA: 0x0092B43C File Offset: 0x0092963C
		[NullableContext(1)]
		public BP_DollItem_1_1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_1_1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003581 RID: 13697
		// (get) Token: 0x06020696 RID: 132758 RVA: 0x0092B46F File Offset: 0x0092966F
		// (set) Token: 0x06020697 RID: 132759 RVA: 0x0092B483 File Offset: 0x00929683
		public unsafe USkeletalMeshComponent EpropJiwawa01Md10011
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_1_1_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_1_1_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003582 RID: 13698
		// (get) Token: 0x06020698 RID: 132760 RVA: 0x0092B498 File Offset: 0x00929698
		// (set) Token: 0x06020699 RID: 132761 RVA: 0x0092B4AC File Offset: 0x009296AC
		public unsafe UPointLightComponent PointLight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_1_1_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_1_1_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x0602069A RID: 132762 RVA: 0x0092B4C1 File Offset: 0x009296C1
		protected BP_DollItem_1_1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010315 RID: 66325
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_1_1.BP_DollItem_1_1_C";

		// Token: 0x04010316 RID: 66326
		private static IntPtr _ClassPtr;

		// Token: 0x04010317 RID: 66327
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010318 RID: 66328
		internal new static int __PropertyOffset_0;

		// Token: 0x04010319 RID: 66329
		internal new static int __PropertyOffset_1;
	}
}
