using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B0C RID: 15116
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_XingSheng.BP_DollItem_XingSheng_C")]
	[UnrealStructLayout(1536, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1536)]
	public class BP_DollItem_XingSheng_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060207DA RID: 133082 RVA: 0x0092D835 File Offset: 0x0092BA35
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_XingSheng_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_XingSheng.BP_DollItem_XingSheng_C");
			}
			return BP_DollItem_XingSheng_C._ClassPtr;
		}

		// Token: 0x060207DB RID: 133083 RVA: 0x0092D85C File Offset: 0x0092BA5C
		public BP_DollItem_XingSheng_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_XingSheng_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060207DC RID: 133084 RVA: 0x0092D884 File Offset: 0x0092BA84
		[NullableContext(1)]
		public BP_DollItem_XingSheng_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_XingSheng_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035DA RID: 13786
		// (get) Token: 0x060207DD RID: 133085 RVA: 0x0092D8B7 File Offset: 0x0092BAB7
		// (set) Token: 0x060207DE RID: 133086 RVA: 0x0092D8CB File Offset: 0x0092BACB
		[Nullable(2)]
		public unsafe UPointLightComponent PointLight1
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_XingSheng_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_XingSheng_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060207DF RID: 133087 RVA: 0x0092D8E0 File Offset: 0x0092BAE0
		protected BP_DollItem_XingSheng_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040103E1 RID: 66529
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_XingSheng.BP_DollItem_XingSheng_C";

		// Token: 0x040103E2 RID: 66530
		private static IntPtr _ClassPtr;

		// Token: 0x040103E3 RID: 66531
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040103E4 RID: 66532
		internal new static int __PropertyOffset_0;
	}
}
