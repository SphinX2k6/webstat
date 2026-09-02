using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonBigAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA017
{
	// Token: 0x0200416F RID: 16751
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA017/BP_NA017.BP_NA017_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA017_C : BP_CommonBigAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6F3 RID: 182003 RVA: 0x00AA13FC File Offset: 0x00A9F5FC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA017_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA017/BP_NA017.BP_NA017_C");
			}
			return BP_NA017_C._ClassPtr;
		}

		// Token: 0x0602C6F4 RID: 182004 RVA: 0x00AA1420 File Offset: 0x00A9F620
		public BP_NA017_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA017_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6F5 RID: 182005 RVA: 0x00AA1448 File Offset: 0x00A9F648
		[NullableContext(1)]
		public BP_NA017_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA017_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C6F6 RID: 182006 RVA: 0x00AA147B File Offset: 0x00A9F67B
		protected BP_NA017_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AD0 RID: 101072
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA017/BP_NA017.BP_NA017_C";

		// Token: 0x04018AD1 RID: 101073
		private static IntPtr _ClassPtr;

		// Token: 0x04018AD2 RID: 101074
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
