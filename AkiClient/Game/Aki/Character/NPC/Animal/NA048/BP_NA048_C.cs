using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonPet;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA048
{
	// Token: 0x0200413C RID: 16700
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA048/BP_NA048.BP_NA048_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2240)]
	public class BP_NA048_C : BP_CommonPet_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C5FC RID: 181756 RVA: 0x00A9F2F4 File Offset: 0x00A9D4F4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA048_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA048/BP_NA048.BP_NA048_C");
			}
			return BP_NA048_C._ClassPtr;
		}

		// Token: 0x0602C5FD RID: 181757 RVA: 0x00A9F318 File Offset: 0x00A9D518
		public BP_NA048_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA048_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C5FE RID: 181758 RVA: 0x00A9F340 File Offset: 0x00A9D540
		[NullableContext(1)]
		public BP_NA048_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA048_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C5FF RID: 181759 RVA: 0x00A9F373 File Offset: 0x00A9D573
		protected BP_NA048_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A18 RID: 100888
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA048/BP_NA048.BP_NA048_C";

		// Token: 0x04018A19 RID: 100889
		private static IntPtr _ClassPtr;

		// Token: 0x04018A1A RID: 100890
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
