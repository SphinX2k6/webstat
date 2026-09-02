using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA048
{
	// Token: 0x0200413D RID: 16701
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA048/BP_NA048_NPC.BP_NA048_NPC_C")]
	[UnrealStructLayout(2320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2314)]
	public class BP_NA048_NPC_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C600 RID: 181760 RVA: 0x00A9F37C File Offset: 0x00A9D57C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA048_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA048/BP_NA048_NPC.BP_NA048_NPC_C");
			}
			return BP_NA048_NPC_C._ClassPtr;
		}

		// Token: 0x0602C601 RID: 181761 RVA: 0x00A9F3A0 File Offset: 0x00A9D5A0
		public BP_NA048_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA048_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C602 RID: 181762 RVA: 0x00A9F3C8 File Offset: 0x00A9D5C8
		[NullableContext(1)]
		public BP_NA048_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA048_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C603 RID: 181763 RVA: 0x00A9F3FB File Offset: 0x00A9D5FB
		protected BP_NA048_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A1B RID: 100891
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA048/BP_NA048_NPC.BP_NA048_NPC_C";

		// Token: 0x04018A1C RID: 100892
		private static IntPtr _ClassPtr;

		// Token: 0x04018A1D RID: 100893
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
