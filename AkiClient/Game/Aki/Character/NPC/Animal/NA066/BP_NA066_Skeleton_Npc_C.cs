using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Common;
using AkiClient.Game.Aki.Render.RuntimeBP.SnowCoverInteraction.BluePrints;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA066
{
	// Token: 0x0200410F RID: 16655
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA066/BP_NA066_Skeleton_Npc.BP_NA066_Skeleton_Npc_C")]
	[UnrealStructLayout(2336, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2328)]
	public class BP_NA066_Skeleton_Npc_C : BP_BaseNPC_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C4E2 RID: 181474 RVA: 0x00A9CE78 File Offset: 0x00A9B078
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA066_Skeleton_Npc_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA066/BP_NA066_Skeleton_Npc.BP_NA066_Skeleton_Npc_C");
			}
			return BP_NA066_Skeleton_Npc_C._ClassPtr;
		}

		// Token: 0x0602C4E3 RID: 181475 RVA: 0x00A9CE9C File Offset: 0x00A9B09C
		public BP_NA066_Skeleton_Npc_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA066_Skeleton_Npc_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C4E4 RID: 181476 RVA: 0x00A9CEC4 File Offset: 0x00A9B0C4
		[NullableContext(1)]
		public BP_NA066_Skeleton_Npc_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA066_Skeleton_Npc_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007746 RID: 30534
		// (get) Token: 0x0602C4E5 RID: 181477 RVA: 0x00A9CEF7 File Offset: 0x00A9B0F7
		// (set) Token: 0x0602C4E6 RID: 181478 RVA: 0x00A9CF0B File Offset: 0x00A9B10B
		[Nullable(2)]
		public unsafe BP_SnowTrailComponent_NPC_C BP_SnowTrailComponent_NPC
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SnowTrailComponent_NPC_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA066_Skeleton_Npc_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_NA066_Skeleton_Npc_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602C4E7 RID: 181479 RVA: 0x00A9CF20 File Offset: 0x00A9B120
		protected BP_NA066_Skeleton_Npc_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401894B RID: 100683
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA066/BP_NA066_Skeleton_Npc.BP_NA066_Skeleton_Npc_C";

		// Token: 0x0401894C RID: 100684
		private static IntPtr _ClassPtr;

		// Token: 0x0401894D RID: 100685
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401894E RID: 100686
		internal new static int __PropertyOffset_0;
	}
}
