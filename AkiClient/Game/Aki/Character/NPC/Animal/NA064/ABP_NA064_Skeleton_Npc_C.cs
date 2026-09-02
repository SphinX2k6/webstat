using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA064
{
	// Token: 0x02004114 RID: 16660
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA064/ABP_NA064_Skeleton_Npc.ABP_NA064_Skeleton_Npc_C")]
	[UnrealStructLayout(12768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 12761)]
	public class ABP_NA064_Skeleton_Npc_C : ABP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C501 RID: 181505 RVA: 0x00A9D26C File Offset: 0x00A9B46C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA064_Skeleton_Npc_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA064/ABP_NA064_Skeleton_Npc.ABP_NA064_Skeleton_Npc_C");
			}
			return ABP_NA064_Skeleton_Npc_C._ClassPtr;
		}

		// Token: 0x0602C502 RID: 181506 RVA: 0x00A9D290 File Offset: 0x00A9B490
		public ABP_NA064_Skeleton_Npc_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA064_Skeleton_Npc_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C503 RID: 181507 RVA: 0x00A9D2B8 File Offset: 0x00A9B4B8
		[NullableContext(1)]
		public ABP_NA064_Skeleton_Npc_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA064_Skeleton_Npc_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C504 RID: 181508 RVA: 0x00A9D2EB File Offset: 0x00A9B4EB
		protected ABP_NA064_Skeleton_Npc_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018961 RID: 100705
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA064/ABP_NA064_Skeleton_Npc.ABP_NA064_Skeleton_Npc_C";

		// Token: 0x04018962 RID: 100706
		private static IntPtr _ClassPtr;

		// Token: 0x04018963 RID: 100707
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
