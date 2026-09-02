using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA067
{
	// Token: 0x02004109 RID: 16649
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA067/ABP_NA067_NPC.ABP_NA067_NPC_C")]
	[UnrealStructLayout(12768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 12761)]
	public class ABP_NA067_NPC_C : ABP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C4BF RID: 181439 RVA: 0x00A9CA00 File Offset: 0x00A9AC00
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA067_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA067/ABP_NA067_NPC.ABP_NA067_NPC_C");
			}
			return ABP_NA067_NPC_C._ClassPtr;
		}

		// Token: 0x0602C4C0 RID: 181440 RVA: 0x00A9CA24 File Offset: 0x00A9AC24
		public ABP_NA067_NPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA067_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C4C1 RID: 181441 RVA: 0x00A9CA4C File Offset: 0x00A9AC4C
		[NullableContext(1)]
		public ABP_NA067_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA067_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C4C2 RID: 181442 RVA: 0x00A9CA7F File Offset: 0x00A9AC7F
		protected ABP_NA067_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018932 RID: 100658
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA067/ABP_NA067_NPC.ABP_NA067_NPC_C";

		// Token: 0x04018933 RID: 100659
		private static IntPtr _ClassPtr;

		// Token: 0x04018934 RID: 100660
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
