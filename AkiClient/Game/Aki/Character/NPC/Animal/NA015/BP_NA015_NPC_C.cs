using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA015
{
	// Token: 0x02004176 RID: 16758
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA015/BP_NA015_NPC.BP_NA015_NPC_C")]
	[UnrealStructLayout(2320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2314)]
	public class BP_NA015_NPC_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C70F RID: 182031 RVA: 0x00AA17B4 File Offset: 0x00A9F9B4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA015_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA015/BP_NA015_NPC.BP_NA015_NPC_C");
			}
			return BP_NA015_NPC_C._ClassPtr;
		}

		// Token: 0x0602C710 RID: 182032 RVA: 0x00AA17D8 File Offset: 0x00A9F9D8
		public BP_NA015_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA015_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C711 RID: 182033 RVA: 0x00AA1800 File Offset: 0x00A9FA00
		[NullableContext(1)]
		public BP_NA015_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA015_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C712 RID: 182034 RVA: 0x00AA1833 File Offset: 0x00A9FA33
		protected BP_NA015_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AE5 RID: 101093
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA015/BP_NA015_NPC.BP_NA015_NPC_C";

		// Token: 0x04018AE6 RID: 101094
		private static IntPtr _ClassPtr;

		// Token: 0x04018AE7 RID: 101095
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
