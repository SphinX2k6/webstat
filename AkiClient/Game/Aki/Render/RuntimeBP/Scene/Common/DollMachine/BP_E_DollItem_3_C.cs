using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B11 RID: 15121
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_3.BP_E_DollItem_3_C")]
	[UnrealStructLayout(1536, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1536)]
	public class BP_E_DollItem_3_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020812 RID: 133138 RVA: 0x0092DEA9 File Offset: 0x0092C0A9
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_E_DollItem_3_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_3.BP_E_DollItem_3_C");
			}
			return BP_E_DollItem_3_C._ClassPtr;
		}

		// Token: 0x06020813 RID: 133139 RVA: 0x0092DED0 File Offset: 0x0092C0D0
		public BP_E_DollItem_3_C() : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_3_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020814 RID: 133140 RVA: 0x0092DEF8 File Offset: 0x0092C0F8
		[NullableContext(1)]
		public BP_E_DollItem_3_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_3_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035EA RID: 13802
		// (get) Token: 0x06020815 RID: 133141 RVA: 0x0092DF2B File Offset: 0x0092C12B
		// (set) Token: 0x06020816 RID: 133142 RVA: 0x0092DF3F File Offset: 0x0092C13F
		[Nullable(2)]
		public unsafe USkeletalMeshComponent EpropJiwawa03Md10011
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_E_DollItem_3_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_E_DollItem_3_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06020817 RID: 133143 RVA: 0x0092DF54 File Offset: 0x0092C154
		protected BP_E_DollItem_3_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010407 RID: 66567
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_3.BP_E_DollItem_3_C";

		// Token: 0x04010408 RID: 66568
		private static IntPtr _ClassPtr;

		// Token: 0x04010409 RID: 66569
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401040A RID: 66570
		internal new static int __PropertyOffset_0;
	}
}
