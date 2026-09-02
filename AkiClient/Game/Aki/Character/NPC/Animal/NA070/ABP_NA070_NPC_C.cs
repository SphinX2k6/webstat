using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA070
{
	// Token: 0x020040FE RID: 16638
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA070/ABP_NA070_NPC.ABP_NA070_NPC_C")]
	[UnrealStructLayout(12768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 12761)]
	public class ABP_NA070_NPC_C : ABP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C479 RID: 181369 RVA: 0x00A9C140 File Offset: 0x00A9A340
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA070_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA070/ABP_NA070_NPC.ABP_NA070_NPC_C");
			}
			return ABP_NA070_NPC_C._ClassPtr;
		}

		// Token: 0x0602C47A RID: 181370 RVA: 0x00A9C164 File Offset: 0x00A9A364
		public ABP_NA070_NPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA070_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C47B RID: 181371 RVA: 0x00A9C18C File Offset: 0x00A9A38C
		[NullableContext(1)]
		public ABP_NA070_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA070_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C47C RID: 181372 RVA: 0x00A9C1BF File Offset: 0x00A9A3BF
		protected ABP_NA070_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018901 RID: 100609
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA070/ABP_NA070_NPC.ABP_NA070_NPC_C";

		// Token: 0x04018902 RID: 100610
		private static IntPtr _ClassPtr;

		// Token: 0x04018903 RID: 100611
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
