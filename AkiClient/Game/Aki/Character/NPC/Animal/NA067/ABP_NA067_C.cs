using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA067
{
	// Token: 0x02004108 RID: 16648
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA067/ABP_NA067.ABP_NA067_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA067_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C4BB RID: 181435 RVA: 0x00A9C976 File Offset: 0x00A9AB76
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA067_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA067/ABP_NA067.ABP_NA067_C");
			}
			return ABP_NA067_C._ClassPtr;
		}

		// Token: 0x0602C4BC RID: 181436 RVA: 0x00A9C99C File Offset: 0x00A9AB9C
		public ABP_NA067_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA067_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C4BD RID: 181437 RVA: 0x00A9C9C4 File Offset: 0x00A9ABC4
		[NullableContext(1)]
		public ABP_NA067_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA067_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C4BE RID: 181438 RVA: 0x00A9C9F7 File Offset: 0x00A9ABF7
		protected ABP_NA067_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401892F RID: 100655
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA067/ABP_NA067.ABP_NA067_C";

		// Token: 0x04018930 RID: 100656
		private static IntPtr _ClassPtr;

		// Token: 0x04018931 RID: 100657
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
