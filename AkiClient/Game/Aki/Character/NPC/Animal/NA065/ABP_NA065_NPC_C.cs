using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA065
{
	// Token: 0x02004111 RID: 16657
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA065/ABP_NA065_NPC.ABP_NA065_NPC_C")]
	[UnrealStructLayout(12768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 12761)]
	public class ABP_NA065_NPC_C : ABP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C4EC RID: 181484 RVA: 0x00A9CFB4 File Offset: 0x00A9B1B4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA065_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA065/ABP_NA065_NPC.ABP_NA065_NPC_C");
			}
			return ABP_NA065_NPC_C._ClassPtr;
		}

		// Token: 0x0602C4ED RID: 181485 RVA: 0x00A9CFD8 File Offset: 0x00A9B1D8
		public ABP_NA065_NPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA065_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C4EE RID: 181486 RVA: 0x00A9D000 File Offset: 0x00A9B200
		[NullableContext(1)]
		public ABP_NA065_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA065_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C4EF RID: 181487 RVA: 0x00A9D033 File Offset: 0x00A9B233
		protected ABP_NA065_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018952 RID: 100690
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA065/ABP_NA065_NPC.ABP_NA065_NPC_C";

		// Token: 0x04018953 RID: 100691
		private static IntPtr _ClassPtr;

		// Token: 0x04018954 RID: 100692
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
