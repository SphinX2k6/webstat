using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA072
{
	// Token: 0x020040F8 RID: 16632
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA072/BP_NA072_NPC.BP_NA072_NPC_C")]
	[UnrealStructLayout(2320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2314)]
	public class BP_NA072_NPC_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C461 RID: 181345 RVA: 0x00A9BE10 File Offset: 0x00A9A010
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA072_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA072/BP_NA072_NPC.BP_NA072_NPC_C");
			}
			return BP_NA072_NPC_C._ClassPtr;
		}

		// Token: 0x0602C462 RID: 181346 RVA: 0x00A9BE34 File Offset: 0x00A9A034
		public BP_NA072_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA072_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C463 RID: 181347 RVA: 0x00A9BE5C File Offset: 0x00A9A05C
		[NullableContext(1)]
		public BP_NA072_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA072_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C464 RID: 181348 RVA: 0x00A9BE8F File Offset: 0x00A9A08F
		protected BP_NA072_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040188EF RID: 100591
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA072/BP_NA072_NPC.BP_NA072_NPC_C";

		// Token: 0x040188F0 RID: 100592
		private static IntPtr _ClassPtr;

		// Token: 0x040188F1 RID: 100593
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
