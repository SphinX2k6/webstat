using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonBird;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA038
{
	// Token: 0x02004154 RID: 16724
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA038/BP_NA038.BP_NA038_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA038_C : BP_BaseBird_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C671 RID: 181873 RVA: 0x00AA0398 File Offset: 0x00A9E598
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA038_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA038/BP_NA038.BP_NA038_C");
			}
			return BP_NA038_C._ClassPtr;
		}

		// Token: 0x0602C672 RID: 181874 RVA: 0x00AA03BC File Offset: 0x00A9E5BC
		public BP_NA038_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA038_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C673 RID: 181875 RVA: 0x00AA03E4 File Offset: 0x00A9E5E4
		[NullableContext(1)]
		public BP_NA038_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA038_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C674 RID: 181876 RVA: 0x00AA0417 File Offset: 0x00A9E617
		protected BP_NA038_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A72 RID: 100978
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA038/BP_NA038.BP_NA038_C";

		// Token: 0x04018A73 RID: 100979
		private static IntPtr _ClassPtr;

		// Token: 0x04018A74 RID: 100980
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
