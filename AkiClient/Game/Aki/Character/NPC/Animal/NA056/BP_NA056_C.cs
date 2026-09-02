using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA056
{
	// Token: 0x0200412E RID: 16686
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA056/BP_NA056.BP_NA056_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA056_C : BP_CommonSmallAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C5B6 RID: 181686 RVA: 0x00A9E99C File Offset: 0x00A9CB9C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA056_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA056/BP_NA056.BP_NA056_C");
			}
			return BP_NA056_C._ClassPtr;
		}

		// Token: 0x0602C5B7 RID: 181687 RVA: 0x00A9E9C0 File Offset: 0x00A9CBC0
		public BP_NA056_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA056_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C5B8 RID: 181688 RVA: 0x00A9E9E8 File Offset: 0x00A9CBE8
		[NullableContext(1)]
		public BP_NA056_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA056_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C5B9 RID: 181689 RVA: 0x00A9EA1B File Offset: 0x00A9CC1B
		protected BP_NA056_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040189E4 RID: 100836
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA056/BP_NA056.BP_NA056_C";

		// Token: 0x040189E5 RID: 100837
		private static IntPtr _ClassPtr;

		// Token: 0x040189E6 RID: 100838
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
