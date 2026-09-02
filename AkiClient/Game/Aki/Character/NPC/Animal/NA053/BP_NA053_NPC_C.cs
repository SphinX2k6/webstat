using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA053
{
	// Token: 0x02004137 RID: 16695
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA053/BP_NA053_NPC.BP_NA053_NPC_C")]
	[UnrealStructLayout(2320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2314)]
	public class BP_NA053_NPC_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C5E8 RID: 181736 RVA: 0x00A9F04C File Offset: 0x00A9D24C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA053_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA053/BP_NA053_NPC.BP_NA053_NPC_C");
			}
			return BP_NA053_NPC_C._ClassPtr;
		}

		// Token: 0x0602C5E9 RID: 181737 RVA: 0x00A9F070 File Offset: 0x00A9D270
		public BP_NA053_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA053_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C5EA RID: 181738 RVA: 0x00A9F098 File Offset: 0x00A9D298
		[NullableContext(1)]
		public BP_NA053_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA053_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C5EB RID: 181739 RVA: 0x00A9F0CB File Offset: 0x00A9D2CB
		protected BP_NA053_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A09 RID: 100873
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA053/BP_NA053_NPC.BP_NA053_NPC_C";

		// Token: 0x04018A0A RID: 100874
		private static IntPtr _ClassPtr;

		// Token: 0x04018A0B RID: 100875
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
