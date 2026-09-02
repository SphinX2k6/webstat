using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA070
{
	// Token: 0x02004100 RID: 16640
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA070/BP_NA070_NPC.BP_NA070_NPC_C")]
	[UnrealStructLayout(2320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2314)]
	public class BP_NA070_NPC_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C483 RID: 181379 RVA: 0x00A9C279 File Offset: 0x00A9A479
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA070_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA070/BP_NA070_NPC.BP_NA070_NPC_C");
			}
			return BP_NA070_NPC_C._ClassPtr;
		}

		// Token: 0x0602C484 RID: 181380 RVA: 0x00A9C2A0 File Offset: 0x00A9A4A0
		public BP_NA070_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA070_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C485 RID: 181381 RVA: 0x00A9C2C8 File Offset: 0x00A9A4C8
		[NullableContext(1)]
		public BP_NA070_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA070_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C486 RID: 181382 RVA: 0x00A9C2FB File Offset: 0x00A9A4FB
		protected BP_NA070_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018908 RID: 100616
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA070/BP_NA070_NPC.BP_NA070_NPC_C";

		// Token: 0x04018909 RID: 100617
		private static IntPtr _ClassPtr;

		// Token: 0x0401890A RID: 100618
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
