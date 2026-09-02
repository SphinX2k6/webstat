using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA064
{
	// Token: 0x02004118 RID: 16664
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA064/BP_NA064_Skeleton_Npc.BP_NA064_Skeleton_Npc_C")]
	[UnrealStructLayout(2320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2314)]
	public class BP_NA064_Skeleton_Npc_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C51C RID: 181532 RVA: 0x00A9D5D4 File Offset: 0x00A9B7D4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA064_Skeleton_Npc_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA064/BP_NA064_Skeleton_Npc.BP_NA064_Skeleton_Npc_C");
			}
			return BP_NA064_Skeleton_Npc_C._ClassPtr;
		}

		// Token: 0x0602C51D RID: 181533 RVA: 0x00A9D5F8 File Offset: 0x00A9B7F8
		public BP_NA064_Skeleton_Npc_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA064_Skeleton_Npc_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C51E RID: 181534 RVA: 0x00A9D620 File Offset: 0x00A9B820
		[NullableContext(1)]
		public BP_NA064_Skeleton_Npc_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA064_Skeleton_Npc_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C51F RID: 181535 RVA: 0x00A9D653 File Offset: 0x00A9B853
		protected BP_NA064_Skeleton_Npc_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018974 RID: 100724
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA064/BP_NA064_Skeleton_Npc.BP_NA064_Skeleton_Npc_C";

		// Token: 0x04018975 RID: 100725
		private static IntPtr _ClassPtr;

		// Token: 0x04018976 RID: 100726
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
