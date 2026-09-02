using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA069
{
	// Token: 0x02004103 RID: 16643
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA069/BP_NA069_NPC.BP_NA069_NPC_C")]
	[UnrealStructLayout(2320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2314)]
	public class BP_NA069_NPC_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C498 RID: 181400 RVA: 0x00A9C534 File Offset: 0x00A9A734
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA069_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA069/BP_NA069_NPC.BP_NA069_NPC_C");
			}
			return BP_NA069_NPC_C._ClassPtr;
		}

		// Token: 0x0602C499 RID: 181401 RVA: 0x00A9C558 File Offset: 0x00A9A758
		public BP_NA069_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA069_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C49A RID: 181402 RVA: 0x00A9C580 File Offset: 0x00A9A780
		[NullableContext(1)]
		public BP_NA069_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA069_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C49B RID: 181403 RVA: 0x00A9C5B3 File Offset: 0x00A9A7B3
		protected BP_NA069_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018917 RID: 100631
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA069/BP_NA069_NPC.BP_NA069_NPC_C";

		// Token: 0x04018918 RID: 100632
		private static IntPtr _ClassPtr;

		// Token: 0x04018919 RID: 100633
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
