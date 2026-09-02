using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA067
{
	// Token: 0x0200410A RID: 16650
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA067/BP_NA067.BP_NA067_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA067_C : BP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C4C3 RID: 181443 RVA: 0x00A9CA88 File Offset: 0x00A9AC88
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA067_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA067/BP_NA067.BP_NA067_C");
			}
			return BP_NA067_C._ClassPtr;
		}

		// Token: 0x0602C4C4 RID: 181444 RVA: 0x00A9CAAC File Offset: 0x00A9ACAC
		public BP_NA067_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA067_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C4C5 RID: 181445 RVA: 0x00A9CAD4 File Offset: 0x00A9ACD4
		[NullableContext(1)]
		public BP_NA067_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA067_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C4C6 RID: 181446 RVA: 0x00A9CB07 File Offset: 0x00A9AD07
		protected BP_NA067_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018935 RID: 100661
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA067/BP_NA067.BP_NA067_C";

		// Token: 0x04018936 RID: 100662
		private static IntPtr _ClassPtr;

		// Token: 0x04018937 RID: 100663
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
