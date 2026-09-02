using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA069
{
	// Token: 0x02004101 RID: 16641
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA069/ABP_NA069.ABP_NA069_C")]
	[UnrealStructLayout(18848, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18834)]
	public class ABP_NA069_C : ABP_BaseRunAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C487 RID: 181383 RVA: 0x00A9C304 File Offset: 0x00A9A504
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA069_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA069/ABP_NA069.ABP_NA069_C");
			}
			return ABP_NA069_C._ClassPtr;
		}

		// Token: 0x0602C488 RID: 181384 RVA: 0x00A9C328 File Offset: 0x00A9A528
		public ABP_NA069_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA069_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C489 RID: 181385 RVA: 0x00A9C350 File Offset: 0x00A9A550
		[NullableContext(1)]
		public ABP_NA069_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA069_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C48A RID: 181386 RVA: 0x00A9C383 File Offset: 0x00A9A583
		protected ABP_NA069_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401890B RID: 100619
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA069/ABP_NA069.ABP_NA069_C";

		// Token: 0x0401890C RID: 100620
		private static IntPtr _ClassPtr;

		// Token: 0x0401890D RID: 100621
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
