using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA053
{
	// Token: 0x02004136 RID: 16694
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA053/ABP_NA053_NPC.ABP_NA053_NPC_C")]
	[UnrealStructLayout(12768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 12761)]
	public class ABP_NA053_NPC_C : ABP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C5E4 RID: 181732 RVA: 0x00A9EFC4 File Offset: 0x00A9D1C4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA053_NPC_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA053/ABP_NA053_NPC.ABP_NA053_NPC_C");
			}
			return ABP_NA053_NPC_C._ClassPtr;
		}

		// Token: 0x0602C5E5 RID: 181733 RVA: 0x00A9EFE8 File Offset: 0x00A9D1E8
		public ABP_NA053_NPC_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA053_NPC_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C5E6 RID: 181734 RVA: 0x00A9F010 File Offset: 0x00A9D210
		[NullableContext(1)]
		public ABP_NA053_NPC_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA053_NPC_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C5E7 RID: 181735 RVA: 0x00A9F043 File Offset: 0x00A9D243
		protected ABP_NA053_NPC_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A06 RID: 100870
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA053/ABP_NA053_NPC.ABP_NA053_NPC_C";

		// Token: 0x04018A07 RID: 100871
		private static IntPtr _ClassPtr;

		// Token: 0x04018A08 RID: 100872
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
