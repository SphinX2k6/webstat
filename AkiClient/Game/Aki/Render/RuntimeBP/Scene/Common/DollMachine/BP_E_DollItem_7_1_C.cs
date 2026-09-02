using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B15 RID: 15125
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_7_1.BP_E_DollItem_7_1_C")]
	[UnrealStructLayout(1536, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1536)]
	public class BP_E_DollItem_7_1_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602082A RID: 133162 RVA: 0x0092E179 File Offset: 0x0092C379
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_E_DollItem_7_1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_7_1.BP_E_DollItem_7_1_C");
			}
			return BP_E_DollItem_7_1_C._ClassPtr;
		}

		// Token: 0x0602082B RID: 133163 RVA: 0x0092E1A0 File Offset: 0x0092C3A0
		public BP_E_DollItem_7_1_C() : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_7_1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602082C RID: 133164 RVA: 0x0092E1C8 File Offset: 0x0092C3C8
		[NullableContext(1)]
		public BP_E_DollItem_7_1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_7_1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035EE RID: 13806
		// (get) Token: 0x0602082D RID: 133165 RVA: 0x0092E1FB File Offset: 0x0092C3FB
		// (set) Token: 0x0602082E RID: 133166 RVA: 0x0092E20F File Offset: 0x0092C40F
		[Nullable(2)]
		public unsafe USkeletalMeshComponent EpropJiwawa07Md10011
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_E_DollItem_7_1_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_E_DollItem_7_1_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602082F RID: 133167 RVA: 0x0092E224 File Offset: 0x0092C424
		protected BP_E_DollItem_7_1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010417 RID: 66583
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_7_1.BP_E_DollItem_7_1_C";

		// Token: 0x04010418 RID: 66584
		private static IntPtr _ClassPtr;

		// Token: 0x04010419 RID: 66585
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401041A RID: 66586
		internal new static int __PropertyOffset_0;
	}
}
