using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonPet;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA012
{
	// Token: 0x0200417C RID: 16764
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA012/BP_NA012_little.BP_NA012_little_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2240)]
	public class BP_NA012_little_C : BP_CommonPet_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C72E RID: 182062 RVA: 0x00AA1C40 File Offset: 0x00A9FE40
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA012_little_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA012/BP_NA012_little.BP_NA012_little_C");
			}
			return BP_NA012_little_C._ClassPtr;
		}

		// Token: 0x0602C72F RID: 182063 RVA: 0x00AA1C64 File Offset: 0x00A9FE64
		public BP_NA012_little_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA012_little_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C730 RID: 182064 RVA: 0x00AA1C8C File Offset: 0x00A9FE8C
		[NullableContext(1)]
		public BP_NA012_little_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA012_little_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C731 RID: 182065 RVA: 0x00AA1CBF File Offset: 0x00A9FEBF
		protected BP_NA012_little_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AFC RID: 101116
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA012/BP_NA012_little.BP_NA012_little_C";

		// Token: 0x04018AFD RID: 101117
		private static IntPtr _ClassPtr;

		// Token: 0x04018AFE RID: 101118
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
