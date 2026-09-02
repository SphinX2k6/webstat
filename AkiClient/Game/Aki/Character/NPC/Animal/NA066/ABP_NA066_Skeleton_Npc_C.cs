using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA066
{
	// Token: 0x0200410D RID: 16653
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA066/ABP_NA066_Skeleton_Npc.ABP_NA066_Skeleton_Npc_C")]
	[UnrealStructLayout(12768, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 12761)]
	public class ABP_NA066_Skeleton_Npc_C : ABP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C4CF RID: 181455 RVA: 0x00A9CC20 File Offset: 0x00A9AE20
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA066_Skeleton_Npc_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA066/ABP_NA066_Skeleton_Npc.ABP_NA066_Skeleton_Npc_C");
			}
			return ABP_NA066_Skeleton_Npc_C._ClassPtr;
		}

		// Token: 0x0602C4D0 RID: 181456 RVA: 0x00A9CC44 File Offset: 0x00A9AE44
		public ABP_NA066_Skeleton_Npc_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA066_Skeleton_Npc_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C4D1 RID: 181457 RVA: 0x00A9CC6C File Offset: 0x00A9AE6C
		[NullableContext(1)]
		public ABP_NA066_Skeleton_Npc_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA066_Skeleton_Npc_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C4D2 RID: 181458 RVA: 0x00A9CC9F File Offset: 0x00A9AE9F
		protected ABP_NA066_Skeleton_Npc_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401893E RID: 100670
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA066/ABP_NA066_Skeleton_Npc.ABP_NA066_Skeleton_Npc_C";

		// Token: 0x0401893F RID: 100671
		private static IntPtr _ClassPtr;

		// Token: 0x04018940 RID: 100672
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
