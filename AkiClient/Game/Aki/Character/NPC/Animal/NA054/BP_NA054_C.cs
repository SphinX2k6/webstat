using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonBird;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA054
{
	// Token: 0x02004134 RID: 16692
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA054/BP_NA054.BP_NA054_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA054_C : BP_BaseBird_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C5DC RID: 181724 RVA: 0x00A9EEB4 File Offset: 0x00A9D0B4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA054_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA054/BP_NA054.BP_NA054_C");
			}
			return BP_NA054_C._ClassPtr;
		}

		// Token: 0x0602C5DD RID: 181725 RVA: 0x00A9EED8 File Offset: 0x00A9D0D8
		public BP_NA054_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA054_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C5DE RID: 181726 RVA: 0x00A9EF00 File Offset: 0x00A9D100
		[NullableContext(1)]
		public BP_NA054_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA054_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C5DF RID: 181727 RVA: 0x00A9EF33 File Offset: 0x00A9D133
		protected BP_NA054_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A00 RID: 100864
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA054/BP_NA054.BP_NA054_C";

		// Token: 0x04018A01 RID: 100865
		private static IntPtr _ClassPtr;

		// Token: 0x04018A02 RID: 100866
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
