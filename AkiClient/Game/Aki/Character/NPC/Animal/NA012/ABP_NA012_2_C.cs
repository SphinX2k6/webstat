using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA012
{
	// Token: 0x02004179 RID: 16761
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA012/ABP_NA012_2.ABP_NA012_2_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA012_2_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C722 RID: 182050 RVA: 0x00AA1AA8 File Offset: 0x00A9FCA8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA012_2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA012/ABP_NA012_2.ABP_NA012_2_C");
			}
			return ABP_NA012_2_C._ClassPtr;
		}

		// Token: 0x0602C723 RID: 182051 RVA: 0x00AA1ACC File Offset: 0x00A9FCCC
		public ABP_NA012_2_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA012_2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C724 RID: 182052 RVA: 0x00AA1AF4 File Offset: 0x00A9FCF4
		[NullableContext(1)]
		public ABP_NA012_2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA012_2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C725 RID: 182053 RVA: 0x00AA1B27 File Offset: 0x00A9FD27
		protected ABP_NA012_2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AF3 RID: 101107
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA012/ABP_NA012_2.ABP_NA012_2_C";

		// Token: 0x04018AF4 RID: 101108
		private static IntPtr _ClassPtr;

		// Token: 0x04018AF5 RID: 101109
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
