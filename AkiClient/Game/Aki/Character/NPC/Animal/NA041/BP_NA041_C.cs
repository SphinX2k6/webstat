using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA041
{
	// Token: 0x0200414D RID: 16717
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA041/BP_NA041.BP_NA041_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA041_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C655 RID: 181845 RVA: 0x00A9FFE0 File Offset: 0x00A9E1E0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA041_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA041/BP_NA041.BP_NA041_C");
			}
			return BP_NA041_C._ClassPtr;
		}

		// Token: 0x0602C656 RID: 181846 RVA: 0x00AA0004 File Offset: 0x00A9E204
		public BP_NA041_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA041_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C657 RID: 181847 RVA: 0x00AA002C File Offset: 0x00A9E22C
		[NullableContext(1)]
		public BP_NA041_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA041_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C658 RID: 181848 RVA: 0x00AA005F File Offset: 0x00A9E25F
		protected BP_NA041_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A5D RID: 100957
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA041/BP_NA041.BP_NA041_C";

		// Token: 0x04018A5E RID: 100958
		private static IntPtr _ClassPtr;

		// Token: 0x04018A5F RID: 100959
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
