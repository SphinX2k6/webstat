using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA054
{
	// Token: 0x02004135 RID: 16693
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA054/BP_NA054_NPC.BP_NA054_NPC_C")]
	[UnrealStructLayout(2320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2314)]
	public class BP_NA054_NPC_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C5E0 RID: 181728 RVA: 0x00A9EF3C File Offset: 0x00A9D13C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA054_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA054/BP_NA054_NPC.BP_NA054_NPC_C");
			}
			return BP_NA054_NPC_C._ClassPtr;
		}

		// Token: 0x0602C5E1 RID: 181729 RVA: 0x00A9EF60 File Offset: 0x00A9D160
		public BP_NA054_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA054_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C5E2 RID: 181730 RVA: 0x00A9EF88 File Offset: 0x00A9D188
		[NullableContext(1)]
		public BP_NA054_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA054_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C5E3 RID: 181731 RVA: 0x00A9EFBB File Offset: 0x00A9D1BB
		protected BP_NA054_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A03 RID: 100867
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA054/BP_NA054_NPC.BP_NA054_NPC_C";

		// Token: 0x04018A04 RID: 100868
		private static IntPtr _ClassPtr;

		// Token: 0x04018A05 RID: 100869
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
