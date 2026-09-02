using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA037
{
	// Token: 0x02004155 RID: 16725
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA037/ABP_NA037.ABP_NA037_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA037_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C675 RID: 181877 RVA: 0x00AA0420 File Offset: 0x00A9E620
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA037_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA037/ABP_NA037.ABP_NA037_C");
			}
			return ABP_NA037_C._ClassPtr;
		}

		// Token: 0x0602C676 RID: 181878 RVA: 0x00AA0444 File Offset: 0x00A9E644
		public ABP_NA037_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA037_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C677 RID: 181879 RVA: 0x00AA046C File Offset: 0x00A9E66C
		[NullableContext(1)]
		public ABP_NA037_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA037_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C678 RID: 181880 RVA: 0x00AA049F File Offset: 0x00A9E69F
		protected ABP_NA037_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A75 RID: 100981
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA037/ABP_NA037.ABP_NA037_C";

		// Token: 0x04018A76 RID: 100982
		private static IntPtr _ClassPtr;

		// Token: 0x04018A77 RID: 100983
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
