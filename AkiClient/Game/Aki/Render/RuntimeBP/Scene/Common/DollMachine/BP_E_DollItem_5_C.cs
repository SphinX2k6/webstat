using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B13 RID: 15123
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_5.BP_E_DollItem_5_C")]
	[UnrealStructLayout(1536, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1536)]
	public class BP_E_DollItem_5_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602081E RID: 133150 RVA: 0x0092E011 File Offset: 0x0092C211
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_E_DollItem_5_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_5.BP_E_DollItem_5_C");
			}
			return BP_E_DollItem_5_C._ClassPtr;
		}

		// Token: 0x0602081F RID: 133151 RVA: 0x0092E038 File Offset: 0x0092C238
		public BP_E_DollItem_5_C() : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_5_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020820 RID: 133152 RVA: 0x0092E060 File Offset: 0x0092C260
		[NullableContext(1)]
		public BP_E_DollItem_5_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_5_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035EC RID: 13804
		// (get) Token: 0x06020821 RID: 133153 RVA: 0x0092E093 File Offset: 0x0092C293
		// (set) Token: 0x06020822 RID: 133154 RVA: 0x0092E0A7 File Offset: 0x0092C2A7
		[Nullable(2)]
		public unsafe USkeletalMeshComponent EpropJiwawa05Md10011
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_E_DollItem_5_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_E_DollItem_5_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06020823 RID: 133155 RVA: 0x0092E0BC File Offset: 0x0092C2BC
		protected BP_E_DollItem_5_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401040F RID: 66575
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_5.BP_E_DollItem_5_C";

		// Token: 0x04010410 RID: 66576
		private static IntPtr _ClassPtr;

		// Token: 0x04010411 RID: 66577
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010412 RID: 66578
		internal new static int __PropertyOffset_0;
	}
}
