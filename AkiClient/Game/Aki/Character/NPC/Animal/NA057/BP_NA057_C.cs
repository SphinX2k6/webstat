using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonBird;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA057
{
	// Token: 0x0200412C RID: 16684
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA057/BP_NA057.BP_NA057_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA057_C : BP_BaseBird_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C5AE RID: 181678 RVA: 0x00A9E88C File Offset: 0x00A9CA8C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA057_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA057/BP_NA057.BP_NA057_C");
			}
			return BP_NA057_C._ClassPtr;
		}

		// Token: 0x0602C5AF RID: 181679 RVA: 0x00A9E8B0 File Offset: 0x00A9CAB0
		public BP_NA057_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA057_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C5B0 RID: 181680 RVA: 0x00A9E8D8 File Offset: 0x00A9CAD8
		[NullableContext(1)]
		public BP_NA057_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA057_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C5B1 RID: 181681 RVA: 0x00A9E90B File Offset: 0x00A9CB0B
		protected BP_NA057_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040189DE RID: 100830
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA057/BP_NA057.BP_NA057_C";

		// Token: 0x040189DF RID: 100831
		private static IntPtr _ClassPtr;

		// Token: 0x040189E0 RID: 100832
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
