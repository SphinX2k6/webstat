using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA071
{
	// Token: 0x020040FA RID: 16634
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA071/ABP_NA071_NPC.ABP_NA071_NPC_C")]
	[UnrealStructLayout(12768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 12761)]
	public class ABP_NA071_NPC_C : ABP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C469 RID: 181353 RVA: 0x00A9BF20 File Offset: 0x00A9A120
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA071_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA071/ABP_NA071_NPC.ABP_NA071_NPC_C");
			}
			return ABP_NA071_NPC_C._ClassPtr;
		}

		// Token: 0x0602C46A RID: 181354 RVA: 0x00A9BF44 File Offset: 0x00A9A144
		public ABP_NA071_NPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA071_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C46B RID: 181355 RVA: 0x00A9BF6C File Offset: 0x00A9A16C
		[NullableContext(1)]
		public ABP_NA071_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA071_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C46C RID: 181356 RVA: 0x00A9BF9F File Offset: 0x00A9A19F
		protected ABP_NA071_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040188F5 RID: 100597
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA071/ABP_NA071_NPC.ABP_NA071_NPC_C";

		// Token: 0x040188F6 RID: 100598
		private static IntPtr _ClassPtr;

		// Token: 0x040188F7 RID: 100599
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
