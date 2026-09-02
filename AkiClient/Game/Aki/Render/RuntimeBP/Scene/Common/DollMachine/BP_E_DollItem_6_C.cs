using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B14 RID: 15124
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_6.BP_E_DollItem_6_C")]
	[UnrealStructLayout(1536, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1536)]
	public class BP_E_DollItem_6_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020824 RID: 133156 RVA: 0x0092E0C5 File Offset: 0x0092C2C5
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_E_DollItem_6_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_6.BP_E_DollItem_6_C");
			}
			return BP_E_DollItem_6_C._ClassPtr;
		}

		// Token: 0x06020825 RID: 133157 RVA: 0x0092E0EC File Offset: 0x0092C2EC
		public BP_E_DollItem_6_C() : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_6_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020826 RID: 133158 RVA: 0x0092E114 File Offset: 0x0092C314
		[NullableContext(1)]
		public BP_E_DollItem_6_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_6_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035ED RID: 13805
		// (get) Token: 0x06020827 RID: 133159 RVA: 0x0092E147 File Offset: 0x0092C347
		// (set) Token: 0x06020828 RID: 133160 RVA: 0x0092E15B File Offset: 0x0092C35B
		[Nullable(2)]
		public unsafe USkeletalMeshComponent EpropJiwawa06Md10011
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_E_DollItem_6_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_E_DollItem_6_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06020829 RID: 133161 RVA: 0x0092E170 File Offset: 0x0092C370
		protected BP_E_DollItem_6_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010413 RID: 66579
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_6.BP_E_DollItem_6_C";

		// Token: 0x04010414 RID: 66580
		private static IntPtr _ClassPtr;

		// Token: 0x04010415 RID: 66581
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010416 RID: 66582
		internal new static int __PropertyOffset_0;
	}
}
