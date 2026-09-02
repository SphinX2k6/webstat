using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonPet;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA012
{
	// Token: 0x0200417B RID: 16763
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA012/BP_NA012.BP_NA012_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2240)]
	public class BP_NA012_C : BP_CommonPet_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C72A RID: 182058 RVA: 0x00AA1BB8 File Offset: 0x00A9FDB8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA012_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA012/BP_NA012.BP_NA012_C");
			}
			return BP_NA012_C._ClassPtr;
		}

		// Token: 0x0602C72B RID: 182059 RVA: 0x00AA1BDC File Offset: 0x00A9FDDC
		public BP_NA012_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA012_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C72C RID: 182060 RVA: 0x00AA1C04 File Offset: 0x00A9FE04
		[NullableContext(1)]
		public BP_NA012_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA012_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C72D RID: 182061 RVA: 0x00AA1C37 File Offset: 0x00A9FE37
		protected BP_NA012_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AF9 RID: 101113
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA012/BP_NA012.BP_NA012_C";

		// Token: 0x04018AFA RID: 101114
		private static IntPtr _ClassPtr;

		// Token: 0x04018AFB RID: 101115
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
