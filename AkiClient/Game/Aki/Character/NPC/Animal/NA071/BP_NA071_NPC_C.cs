using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA071
{
	// Token: 0x020040FC RID: 16636
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA071/BP_NA071_NPC.BP_NA071_NPC_C")]
	[UnrealStructLayout(2320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2314)]
	public class BP_NA071_NPC_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C471 RID: 181361 RVA: 0x00A9C030 File Offset: 0x00A9A230
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA071_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA071/BP_NA071_NPC.BP_NA071_NPC_C");
			}
			return BP_NA071_NPC_C._ClassPtr;
		}

		// Token: 0x0602C472 RID: 181362 RVA: 0x00A9C054 File Offset: 0x00A9A254
		public BP_NA071_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA071_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C473 RID: 181363 RVA: 0x00A9C07C File Offset: 0x00A9A27C
		[NullableContext(1)]
		public BP_NA071_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA071_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C474 RID: 181364 RVA: 0x00A9C0AF File Offset: 0x00A9A2AF
		protected BP_NA071_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040188FB RID: 100603
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA071/BP_NA071_NPC.BP_NA071_NPC_C";

		// Token: 0x040188FC RID: 100604
		private static IntPtr _ClassPtr;

		// Token: 0x040188FD RID: 100605
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
