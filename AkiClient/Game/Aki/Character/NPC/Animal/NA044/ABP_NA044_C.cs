using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA044
{
	// Token: 0x02004144 RID: 16708
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA044/ABP_NA044.ABP_NA044_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA044_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C61C RID: 181788 RVA: 0x00A9F734 File Offset: 0x00A9D934
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA044_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA044/ABP_NA044.ABP_NA044_C");
			}
			return ABP_NA044_C._ClassPtr;
		}

		// Token: 0x0602C61D RID: 181789 RVA: 0x00A9F758 File Offset: 0x00A9D958
		public ABP_NA044_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA044_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C61E RID: 181790 RVA: 0x00A9F780 File Offset: 0x00A9D980
		[NullableContext(1)]
		public ABP_NA044_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA044_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C61F RID: 181791 RVA: 0x00A9F7B3 File Offset: 0x00A9D9B3
		protected ABP_NA044_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A30 RID: 100912
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA044/ABP_NA044.ABP_NA044_C";

		// Token: 0x04018A31 RID: 100913
		private static IntPtr _ClassPtr;

		// Token: 0x04018A32 RID: 100914
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
