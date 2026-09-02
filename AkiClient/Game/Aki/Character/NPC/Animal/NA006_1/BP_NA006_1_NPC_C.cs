using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA006_1
{
	// Token: 0x02004186 RID: 16774
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA006_1/BP_NA006_1_NPC.BP_NA006_1_NPC_C")]
	[UnrealStructLayout(2320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2314)]
	public class BP_NA006_1_NPC_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C75F RID: 182111 RVA: 0x00AA2318 File Offset: 0x00AA0518
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA006_1_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA006_1/BP_NA006_1_NPC.BP_NA006_1_NPC_C");
			}
			return BP_NA006_1_NPC_C._ClassPtr;
		}

		// Token: 0x0602C760 RID: 182112 RVA: 0x00AA233C File Offset: 0x00AA053C
		public BP_NA006_1_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA006_1_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C761 RID: 182113 RVA: 0x00AA2364 File Offset: 0x00AA0564
		[NullableContext(1)]
		public BP_NA006_1_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA006_1_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C762 RID: 182114 RVA: 0x00AA2397 File Offset: 0x00AA0597
		protected BP_NA006_1_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B20 RID: 101152
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA006_1/BP_NA006_1_NPC.BP_NA006_1_NPC_C";

		// Token: 0x04018B21 RID: 101153
		private static IntPtr _ClassPtr;

		// Token: 0x04018B22 RID: 101154
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
