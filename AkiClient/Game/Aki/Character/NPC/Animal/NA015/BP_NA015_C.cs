using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonPet;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA015
{
	// Token: 0x02004175 RID: 16757
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA015/BP_NA015.BP_NA015_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2240)]
	public class BP_NA015_C : BP_CommonPet_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C70B RID: 182027 RVA: 0x00AA172C File Offset: 0x00A9F92C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA015_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA015/BP_NA015.BP_NA015_C");
			}
			return BP_NA015_C._ClassPtr;
		}

		// Token: 0x0602C70C RID: 182028 RVA: 0x00AA1750 File Offset: 0x00A9F950
		public BP_NA015_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA015_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C70D RID: 182029 RVA: 0x00AA1778 File Offset: 0x00A9F978
		[NullableContext(1)]
		public BP_NA015_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA015_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C70E RID: 182030 RVA: 0x00AA17AB File Offset: 0x00A9F9AB
		protected BP_NA015_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AE2 RID: 101090
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA015/BP_NA015.BP_NA015_C";

		// Token: 0x04018AE3 RID: 101091
		private static IntPtr _ClassPtr;

		// Token: 0x04018AE4 RID: 101092
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
