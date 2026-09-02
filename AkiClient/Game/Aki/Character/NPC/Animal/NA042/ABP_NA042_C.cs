using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA042
{
	// Token: 0x02004149 RID: 16713
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA042/ABP_NA042.ABP_NA042_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA042_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C638 RID: 181816 RVA: 0x00A9FAC0 File Offset: 0x00A9DCC0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA042_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA042/ABP_NA042.ABP_NA042_C");
			}
			return ABP_NA042_C._ClassPtr;
		}

		// Token: 0x0602C639 RID: 181817 RVA: 0x00A9FAE4 File Offset: 0x00A9DCE4
		public ABP_NA042_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA042_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C63A RID: 181818 RVA: 0x00A9FB0C File Offset: 0x00A9DD0C
		[NullableContext(1)]
		public ABP_NA042_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA042_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C63B RID: 181819 RVA: 0x00A9FB3F File Offset: 0x00A9DD3F
		protected ABP_NA042_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A45 RID: 100933
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA042/ABP_NA042.ABP_NA042_C";

		// Token: 0x04018A46 RID: 100934
		private static IntPtr _ClassPtr;

		// Token: 0x04018A47 RID: 100935
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
