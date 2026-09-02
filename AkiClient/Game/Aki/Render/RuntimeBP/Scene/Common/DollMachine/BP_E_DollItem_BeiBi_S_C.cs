using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine
{
	// Token: 0x02003B19 RID: 15129
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_BeiBi_S.BP_E_DollItem_BeiBi_S_C")]
	[UnrealStructLayout(1528, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1528)]
	public class BP_E_DollItem_BeiBi_S_C : BP_DollActor_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020845 RID: 133189 RVA: 0x0092E4EC File Offset: 0x0092C6EC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_E_DollItem_BeiBi_S_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_BeiBi_S.BP_E_DollItem_BeiBi_S_C");
			}
			return BP_E_DollItem_BeiBi_S_C._ClassPtr;
		}

		// Token: 0x06020846 RID: 133190 RVA: 0x0092E510 File Offset: 0x0092C710
		public BP_E_DollItem_BeiBi_S_C() : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_BeiBi_S_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020847 RID: 133191 RVA: 0x0092E538 File Offset: 0x0092C738
		[NullableContext(1)]
		public BP_E_DollItem_BeiBi_S_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_E_DollItem_BeiBi_S_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06020848 RID: 133192 RVA: 0x0092E56B File Offset: 0x0092C76B
		protected BP_E_DollItem_BeiBi_S_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401042A RID: 66602
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/DollMachine/BP_E_DollItem_BeiBi_S.BP_E_DollItem_BeiBi_S_C";

		// Token: 0x0401042B RID: 66603
		private static IntPtr _ClassPtr;

		// Token: 0x0401042C RID: 66604
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
