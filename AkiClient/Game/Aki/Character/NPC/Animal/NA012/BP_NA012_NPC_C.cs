using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA012
{
	// Token: 0x0200417D RID: 16765
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA012/BP_NA012_NPC.BP_NA012_NPC_C")]
	[UnrealStructLayout(2320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2314)]
	public class BP_NA012_NPC_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C732 RID: 182066 RVA: 0x00AA1CC8 File Offset: 0x00A9FEC8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA012_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA012/BP_NA012_NPC.BP_NA012_NPC_C");
			}
			return BP_NA012_NPC_C._ClassPtr;
		}

		// Token: 0x0602C733 RID: 182067 RVA: 0x00AA1CEC File Offset: 0x00A9FEEC
		public BP_NA012_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA012_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C734 RID: 182068 RVA: 0x00AA1D14 File Offset: 0x00A9FF14
		[NullableContext(1)]
		public BP_NA012_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA012_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C735 RID: 182069 RVA: 0x00AA1D47 File Offset: 0x00A9FF47
		protected BP_NA012_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AFF RID: 101119
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA012/BP_NA012_NPC.BP_NA012_NPC_C";

		// Token: 0x04018B00 RID: 101120
		private static IntPtr _ClassPtr;

		// Token: 0x04018B01 RID: 101121
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
