using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B0D RID: 15117
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_XingSheng_S.BP_DollItem_XingSheng_S_C")]
	[UnrealStructLayout(1536, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1536)]
	public class BP_DollItem_XingSheng_S_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060207E0 RID: 133088 RVA: 0x0092D8E9 File Offset: 0x0092BAE9
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_XingSheng_S_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_XingSheng_S.BP_DollItem_XingSheng_S_C");
			}
			return BP_DollItem_XingSheng_S_C._ClassPtr;
		}

		// Token: 0x060207E1 RID: 133089 RVA: 0x0092D910 File Offset: 0x0092BB10
		public BP_DollItem_XingSheng_S_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_XingSheng_S_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060207E2 RID: 133090 RVA: 0x0092D938 File Offset: 0x0092BB38
		[NullableContext(1)]
		public BP_DollItem_XingSheng_S_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_XingSheng_S_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035DB RID: 13787
		// (get) Token: 0x060207E3 RID: 133091 RVA: 0x0092D96B File Offset: 0x0092BB6B
		// (set) Token: 0x060207E4 RID: 133092 RVA: 0x0092D97F File Offset: 0x0092BB7F
		[Nullable(2)]
		public unsafe UPointLightComponent PointLight1
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_XingSheng_S_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_XingSheng_S_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060207E5 RID: 133093 RVA: 0x0092D994 File Offset: 0x0092BB94
		protected BP_DollItem_XingSheng_S_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040103E5 RID: 66533
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_XingSheng_S.BP_DollItem_XingSheng_S_C";

		// Token: 0x040103E6 RID: 66534
		private static IntPtr _ClassPtr;

		// Token: 0x040103E7 RID: 66535
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040103E8 RID: 66536
		internal new static int __PropertyOffset_0;
	}
}
