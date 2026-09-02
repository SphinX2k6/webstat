using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonBird;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA028
{
	// Token: 0x02004162 RID: 16738
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA028/BP_NA028_boss.BP_NA028_boss_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA028_boss_C : BP_BaseBird_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6B3 RID: 181939 RVA: 0x00AA0BD8 File Offset: 0x00A9EDD8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA028_boss_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA028/BP_NA028_boss.BP_NA028_boss_C");
			}
			return BP_NA028_boss_C._ClassPtr;
		}

		// Token: 0x0602C6B4 RID: 181940 RVA: 0x00AA0BFC File Offset: 0x00A9EDFC
		public BP_NA028_boss_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA028_boss_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6B5 RID: 181941 RVA: 0x00AA0C24 File Offset: 0x00A9EE24
		[NullableContext(1)]
		public BP_NA028_boss_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA028_boss_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C6B6 RID: 181942 RVA: 0x00AA0C57 File Offset: 0x00A9EE57
		protected BP_NA028_boss_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AA1 RID: 101025
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA028/BP_NA028_boss.BP_NA028_boss_C";

		// Token: 0x04018AA2 RID: 101026
		private static IntPtr _ClassPtr;

		// Token: 0x04018AA3 RID: 101027
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
