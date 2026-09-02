using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA056
{
	// Token: 0x0200412D RID: 16685
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA056/ABP_NA056.ABP_NA056_C")]
	[UnrealStructLayout(18848, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18834)]
	public class ABP_NA056_C : ABP_BaseRunAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C5B2 RID: 181682 RVA: 0x00A9E914 File Offset: 0x00A9CB14
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA056_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA056/ABP_NA056.ABP_NA056_C");
			}
			return ABP_NA056_C._ClassPtr;
		}

		// Token: 0x0602C5B3 RID: 181683 RVA: 0x00A9E938 File Offset: 0x00A9CB38
		public ABP_NA056_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA056_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C5B4 RID: 181684 RVA: 0x00A9E960 File Offset: 0x00A9CB60
		[NullableContext(1)]
		public ABP_NA056_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA056_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C5B5 RID: 181685 RVA: 0x00A9E993 File Offset: 0x00A9CB93
		protected ABP_NA056_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040189E1 RID: 100833
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA056/ABP_NA056.ABP_NA056_C";

		// Token: 0x040189E2 RID: 100834
		private static IntPtr _ClassPtr;

		// Token: 0x040189E3 RID: 100835
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
