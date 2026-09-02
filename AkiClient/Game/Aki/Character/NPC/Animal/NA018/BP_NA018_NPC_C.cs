using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA018
{
	// Token: 0x0200416D RID: 16749
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA018/BP_NA018_NPC.BP_NA018_NPC_C")]
	[UnrealStructLayout(2320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2314)]
	public class BP_NA018_NPC_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6EB RID: 181995 RVA: 0x00AA12EC File Offset: 0x00A9F4EC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA018_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA018/BP_NA018_NPC.BP_NA018_NPC_C");
			}
			return BP_NA018_NPC_C._ClassPtr;
		}

		// Token: 0x0602C6EC RID: 181996 RVA: 0x00AA1310 File Offset: 0x00A9F510
		public BP_NA018_NPC_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA018_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6ED RID: 181997 RVA: 0x00AA1338 File Offset: 0x00A9F538
		[NullableContext(1)]
		public BP_NA018_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA018_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C6EE RID: 181998 RVA: 0x00AA136B File Offset: 0x00A9F56B
		protected BP_NA018_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018ACA RID: 101066
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA018/BP_NA018_NPC.BP_NA018_NPC_C";

		// Token: 0x04018ACB RID: 101067
		private static IntPtr _ClassPtr;

		// Token: 0x04018ACC RID: 101068
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
