using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA054
{
	// Token: 0x02004133 RID: 16691
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA054/ABP_NA054_NPC.ABP_NA054_NPC_C")]
	[UnrealStructLayout(12768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 12761)]
	public class ABP_NA054_NPC_C : ABP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C5D8 RID: 181720 RVA: 0x00A9EE2C File Offset: 0x00A9D02C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA054_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA054/ABP_NA054_NPC.ABP_NA054_NPC_C");
			}
			return ABP_NA054_NPC_C._ClassPtr;
		}

		// Token: 0x0602C5D9 RID: 181721 RVA: 0x00A9EE50 File Offset: 0x00A9D050
		public ABP_NA054_NPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA054_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C5DA RID: 181722 RVA: 0x00A9EE78 File Offset: 0x00A9D078
		[NullableContext(1)]
		public ABP_NA054_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA054_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C5DB RID: 181723 RVA: 0x00A9EEAB File Offset: 0x00A9D0AB
		protected ABP_NA054_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040189FD RID: 100861
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA054/ABP_NA054_NPC.ABP_NA054_NPC_C";

		// Token: 0x040189FE RID: 100862
		private static IntPtr _ClassPtr;

		// Token: 0x040189FF RID: 100863
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
