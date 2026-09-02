using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA057
{
	// Token: 0x0200412B RID: 16683
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA057/ABP_NA057.ABP_NA057_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA057_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C5AA RID: 181674 RVA: 0x00A9E803 File Offset: 0x00A9CA03
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA057_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA057/ABP_NA057.ABP_NA057_C");
			}
			return ABP_NA057_C._ClassPtr;
		}

		// Token: 0x0602C5AB RID: 181675 RVA: 0x00A9E828 File Offset: 0x00A9CA28
		public ABP_NA057_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA057_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C5AC RID: 181676 RVA: 0x00A9E850 File Offset: 0x00A9CA50
		[NullableContext(1)]
		public ABP_NA057_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA057_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C5AD RID: 181677 RVA: 0x00A9E883 File Offset: 0x00A9CA83
		protected ABP_NA057_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040189DB RID: 100827
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA057/ABP_NA057.ABP_NA057_C";

		// Token: 0x040189DC RID: 100828
		private static IntPtr _ClassPtr;

		// Token: 0x040189DD RID: 100829
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
