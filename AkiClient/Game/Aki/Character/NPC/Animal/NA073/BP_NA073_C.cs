using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonBird;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA073
{
	// Token: 0x020040F7 RID: 16631
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA073/BP_NA073.BP_NA073_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA073_C : BP_BaseBird_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C45D RID: 181341 RVA: 0x00A9BD88 File Offset: 0x00A99F88
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA073_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA073/BP_NA073.BP_NA073_C");
			}
			return BP_NA073_C._ClassPtr;
		}

		// Token: 0x0602C45E RID: 181342 RVA: 0x00A9BDAC File Offset: 0x00A99FAC
		public BP_NA073_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA073_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C45F RID: 181343 RVA: 0x00A9BDD4 File Offset: 0x00A99FD4
		[NullableContext(1)]
		public BP_NA073_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA073_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C460 RID: 181344 RVA: 0x00A9BE07 File Offset: 0x00A9A007
		protected BP_NA073_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040188EC RID: 100588
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA073/BP_NA073.BP_NA073_C";

		// Token: 0x040188ED RID: 100589
		private static IntPtr _ClassPtr;

		// Token: 0x040188EE RID: 100590
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
