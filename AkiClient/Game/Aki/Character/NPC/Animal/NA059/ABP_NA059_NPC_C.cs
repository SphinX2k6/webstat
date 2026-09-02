using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA059
{
	// Token: 0x02004124 RID: 16676
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA059/ABP_NA059_NPC.ABP_NA059_NPC_C")]
	[UnrealStructLayout(12768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 12761)]
	public class ABP_NA059_NPC_C : ABP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C56C RID: 181612 RVA: 0x00A9E05C File Offset: 0x00A9C25C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA059_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA059/ABP_NA059_NPC.ABP_NA059_NPC_C");
			}
			return ABP_NA059_NPC_C._ClassPtr;
		}

		// Token: 0x0602C56D RID: 181613 RVA: 0x00A9E080 File Offset: 0x00A9C280
		public ABP_NA059_NPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA059_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C56E RID: 181614 RVA: 0x00A9E0A8 File Offset: 0x00A9C2A8
		[NullableContext(1)]
		public ABP_NA059_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA059_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C56F RID: 181615 RVA: 0x00A9E0DB File Offset: 0x00A9C2DB
		protected ABP_NA059_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040189AE RID: 100782
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA059/ABP_NA059_NPC.ABP_NA059_NPC_C";

		// Token: 0x040189AF RID: 100783
		private static IntPtr _ClassPtr;

		// Token: 0x040189B0 RID: 100784
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
