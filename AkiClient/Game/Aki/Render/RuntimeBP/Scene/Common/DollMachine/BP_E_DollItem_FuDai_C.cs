using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B1A RID: 15130
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_FuDai.BP_E_DollItem_FuDai_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1528)]
	public class BP_E_DollItem_FuDai_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020849 RID: 133193 RVA: 0x0092E574 File Offset: 0x0092C774
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_E_DollItem_FuDai_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_FuDai.BP_E_DollItem_FuDai_C");
			}
			return BP_E_DollItem_FuDai_C._ClassPtr;
		}

		// Token: 0x0602084A RID: 133194 RVA: 0x0092E598 File Offset: 0x0092C798
		public BP_E_DollItem_FuDai_C() : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_FuDai_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602084B RID: 133195 RVA: 0x0092E5C0 File Offset: 0x0092C7C0
		[NullableContext(1)]
		public BP_E_DollItem_FuDai_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_FuDai_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602084C RID: 133196 RVA: 0x0092E5F3 File Offset: 0x0092C7F3
		protected BP_E_DollItem_FuDai_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401042D RID: 66605
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_FuDai.BP_E_DollItem_FuDai_C";

		// Token: 0x0401042E RID: 66606
		private static IntPtr _ClassPtr;

		// Token: 0x0401042F RID: 66607
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
