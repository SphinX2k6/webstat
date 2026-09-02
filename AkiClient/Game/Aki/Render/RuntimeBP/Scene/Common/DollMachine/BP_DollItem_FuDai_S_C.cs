using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B0B RID: 15115
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_FuDai_S.BP_DollItem_FuDai_S_C")]
	[UnrealStructLayout(1536, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1536)]
	public class BP_DollItem_FuDai_S_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060207D4 RID: 133076 RVA: 0x0092D784 File Offset: 0x0092B984
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollItem_FuDai_S_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_FuDai_S.BP_DollItem_FuDai_S_C");
			}
			return BP_DollItem_FuDai_S_C._ClassPtr;
		}

		// Token: 0x060207D5 RID: 133077 RVA: 0x0092D7A8 File Offset: 0x0092B9A8
		public BP_DollItem_FuDai_S_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_FuDai_S_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060207D6 RID: 133078 RVA: 0x0092D7D0 File Offset: 0x0092B9D0
		[NullableContext(1)]
		public BP_DollItem_FuDai_S_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollItem_FuDai_S_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170035D9 RID: 13785
		// (get) Token: 0x060207D7 RID: 133079 RVA: 0x0092D803 File Offset: 0x0092BA03
		// (set) Token: 0x060207D8 RID: 133080 RVA: 0x0092D817 File Offset: 0x0092BA17
		[Nullable(2)]
		public unsafe UPointLightComponent PointLight
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_S_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollItem_FuDai_S_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060207D9 RID: 133081 RVA: 0x0092D82C File Offset: 0x0092BA2C
		protected BP_DollItem_FuDai_S_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040103DD RID: 66525
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_DollItem_FuDai_S.BP_DollItem_FuDai_S_C";

		// Token: 0x040103DE RID: 66526
		private static IntPtr _ClassPtr;

		// Token: 0x040103DF RID: 66527
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040103E0 RID: 66528
		internal new static int __PropertyOffset_0;
	}
}
