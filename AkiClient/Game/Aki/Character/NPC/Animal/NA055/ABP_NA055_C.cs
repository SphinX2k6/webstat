using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA055
{
	// Token: 0x0200412F RID: 16687
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA055/ABP_NA055.ABP_NA055_C")]
	[UnrealStructLayout(18848, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18834)]
	public class ABP_NA055_C : ABP_BaseRunAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C5BA RID: 181690 RVA: 0x00A9EA24 File Offset: 0x00A9CC24
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA055_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA055/ABP_NA055.ABP_NA055_C");
			}
			return ABP_NA055_C._ClassPtr;
		}

		// Token: 0x0602C5BB RID: 181691 RVA: 0x00A9EA48 File Offset: 0x00A9CC48
		public ABP_NA055_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA055_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C5BC RID: 181692 RVA: 0x00A9EA70 File Offset: 0x00A9CC70
		[NullableContext(1)]
		public ABP_NA055_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA055_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C5BD RID: 181693 RVA: 0x00A9EAA3 File Offset: 0x00A9CCA3
		protected ABP_NA055_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040189E7 RID: 100839
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA055/ABP_NA055.ABP_NA055_C";

		// Token: 0x040189E8 RID: 100840
		private static IntPtr _ClassPtr;

		// Token: 0x040189E9 RID: 100841
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
