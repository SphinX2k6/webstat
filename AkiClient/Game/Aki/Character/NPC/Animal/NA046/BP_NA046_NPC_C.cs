using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA046
{
	// Token: 0x02004141 RID: 16705
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA046/BP_NA046_NPC.BP_NA046_NPC_C")]
	[UnrealStructLayout(2320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2314)]
	public class BP_NA046_NPC_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C610 RID: 181776 RVA: 0x00A9F59C File Offset: 0x00A9D79C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA046_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA046/BP_NA046_NPC.BP_NA046_NPC_C");
			}
			return BP_NA046_NPC_C._ClassPtr;
		}

		// Token: 0x0602C611 RID: 181777 RVA: 0x00A9F5C0 File Offset: 0x00A9D7C0
		public BP_NA046_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA046_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C612 RID: 181778 RVA: 0x00A9F5E8 File Offset: 0x00A9D7E8
		[NullableContext(1)]
		public BP_NA046_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA046_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C613 RID: 181779 RVA: 0x00A9F61B File Offset: 0x00A9D81B
		protected BP_NA046_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A27 RID: 100903
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA046/BP_NA046_NPC.BP_NA046_NPC_C";

		// Token: 0x04018A28 RID: 100904
		private static IntPtr _ClassPtr;

		// Token: 0x04018A29 RID: 100905
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
