using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA065
{
	// Token: 0x02004113 RID: 16659
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA065/BP_NA065_NPC.BP_NA065_NPC_C")]
	[UnrealStructLayout(2320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2314)]
	public class BP_NA065_NPC_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C4FD RID: 181501 RVA: 0x00A9D1E4 File Offset: 0x00A9B3E4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA065_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA065/BP_NA065_NPC.BP_NA065_NPC_C");
			}
			return BP_NA065_NPC_C._ClassPtr;
		}

		// Token: 0x0602C4FE RID: 181502 RVA: 0x00A9D208 File Offset: 0x00A9B408
		public BP_NA065_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA065_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C4FF RID: 181503 RVA: 0x00A9D230 File Offset: 0x00A9B430
		[NullableContext(1)]
		public BP_NA065_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA065_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C500 RID: 181504 RVA: 0x00A9D263 File Offset: 0x00A9B463
		protected BP_NA065_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401895E RID: 100702
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA065/BP_NA065_NPC.BP_NA065_NPC_C";

		// Token: 0x0401895F RID: 100703
		private static IntPtr _ClassPtr;

		// Token: 0x04018960 RID: 100704
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
