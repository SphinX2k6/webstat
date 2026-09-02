using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B16 RID: 15126
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_7_2.BP_E_DollItem_7_2_C")]
	[UnrealStructLayout(1536, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1536)]
	public class BP_E_DollItem_7_2_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020830 RID: 133168 RVA: 0x0092E22D File Offset: 0x0092C42D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_E_DollItem_7_2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_7_2.BP_E_DollItem_7_2_C");
			}
			return BP_E_DollItem_7_2_C._ClassPtr;
		}

		// Token: 0x06020831 RID: 133169 RVA: 0x0092E254 File Offset: 0x0092C454
		public BP_E_DollItem_7_2_C() : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_7_2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020832 RID: 133170 RVA: 0x0092E27C File Offset: 0x0092C47C
		[NullableContext(1)]
		public BP_E_DollItem_7_2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_7_2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035EF RID: 13807
		// (get) Token: 0x06020833 RID: 133171 RVA: 0x0092E2AF File Offset: 0x0092C4AF
		// (set) Token: 0x06020834 RID: 133172 RVA: 0x0092E2C3 File Offset: 0x0092C4C3
		[Nullable(2)]
		public unsafe USkeletalMeshComponent EpropJiwawa07Md10011
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_E_DollItem_7_2_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_E_DollItem_7_2_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06020835 RID: 133173 RVA: 0x0092E2D8 File Offset: 0x0092C4D8
		protected BP_E_DollItem_7_2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401041B RID: 66587
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_7_2.BP_E_DollItem_7_2_C";

		// Token: 0x0401041C RID: 66588
		private static IntPtr _ClassPtr;

		// Token: 0x0401041D RID: 66589
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401041E RID: 66590
		internal new static int __PropertyOffset_0;
	}
}
