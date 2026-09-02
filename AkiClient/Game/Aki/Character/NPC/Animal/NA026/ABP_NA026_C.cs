using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA026
{
	// Token: 0x02004164 RID: 16740
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA026/ABP_NA026.ABP_NA026_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA026_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6BB RID: 181947 RVA: 0x00AA0CE8 File Offset: 0x00A9EEE8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA026_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA026/ABP_NA026.ABP_NA026_C");
			}
			return ABP_NA026_C._ClassPtr;
		}

		// Token: 0x0602C6BC RID: 181948 RVA: 0x00AA0D0C File Offset: 0x00A9EF0C
		public ABP_NA026_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA026_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6BD RID: 181949 RVA: 0x00AA0D34 File Offset: 0x00A9EF34
		[NullableContext(1)]
		public ABP_NA026_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA026_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C6BE RID: 181950 RVA: 0x00AA0D67 File Offset: 0x00A9EF67
		protected ABP_NA026_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AA7 RID: 101031
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA026/ABP_NA026.ABP_NA026_C";

		// Token: 0x04018AA8 RID: 101032
		private static IntPtr _ClassPtr;

		// Token: 0x04018AA9 RID: 101033
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
