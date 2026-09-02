using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonBigAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA040
{
	// Token: 0x0200414F RID: 16719
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA040/BP_NA040.BP_NA040_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA040_C : BP_CommonBigAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C65D RID: 181853 RVA: 0x00AA00F0 File Offset: 0x00A9E2F0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA040_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA040/BP_NA040.BP_NA040_C");
			}
			return BP_NA040_C._ClassPtr;
		}

		// Token: 0x0602C65E RID: 181854 RVA: 0x00AA0114 File Offset: 0x00A9E314
		public BP_NA040_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA040_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C65F RID: 181855 RVA: 0x00AA013C File Offset: 0x00A9E33C
		[NullableContext(1)]
		public BP_NA040_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA040_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C660 RID: 181856 RVA: 0x00AA016F File Offset: 0x00A9E36F
		protected BP_NA040_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A63 RID: 100963
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA040/BP_NA040.BP_NA040_C";

		// Token: 0x04018A64 RID: 100964
		private static IntPtr _ClassPtr;

		// Token: 0x04018A65 RID: 100965
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
