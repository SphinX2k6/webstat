using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B1B RID: 15131
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_FuDai_S.BP_E_DollItem_FuDai_S_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1528)]
	public class BP_E_DollItem_FuDai_S_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602084D RID: 133197 RVA: 0x0092E5FC File Offset: 0x0092C7FC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_E_DollItem_FuDai_S_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_FuDai_S.BP_E_DollItem_FuDai_S_C");
			}
			return BP_E_DollItem_FuDai_S_C._ClassPtr;
		}

		// Token: 0x0602084E RID: 133198 RVA: 0x0092E620 File Offset: 0x0092C820
		public BP_E_DollItem_FuDai_S_C() : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_FuDai_S_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602084F RID: 133199 RVA: 0x0092E648 File Offset: 0x0092C848
		[NullableContext(1)]
		public BP_E_DollItem_FuDai_S_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_FuDai_S_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06020850 RID: 133200 RVA: 0x0092E67B File Offset: 0x0092C87B
		protected BP_E_DollItem_FuDai_S_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010430 RID: 66608
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_FuDai_S.BP_E_DollItem_FuDai_S_C";

		// Token: 0x04010431 RID: 66609
		private static IntPtr _ClassPtr;

		// Token: 0x04010432 RID: 66610
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
