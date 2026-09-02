using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA060
{
	// Token: 0x02004121 RID: 16673
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA060/ABP_NA060.ABP_NA060_C")]
	[UnrealStructLayout(18848, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18834)]
	public class ABP_NA060_C : ABP_BaseRunAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C557 RID: 181591 RVA: 0x00A9DDA4 File Offset: 0x00A9BFA4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA060_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA060/ABP_NA060.ABP_NA060_C");
			}
			return ABP_NA060_C._ClassPtr;
		}

		// Token: 0x0602C558 RID: 181592 RVA: 0x00A9DDC8 File Offset: 0x00A9BFC8
		public ABP_NA060_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA060_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C559 RID: 181593 RVA: 0x00A9DDF0 File Offset: 0x00A9BFF0
		[NullableContext(1)]
		public ABP_NA060_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA060_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C55A RID: 181594 RVA: 0x00A9DE23 File Offset: 0x00A9C023
		protected ABP_NA060_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401899F RID: 100767
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA060/ABP_NA060.ABP_NA060_C";

		// Token: 0x040189A0 RID: 100768
		private static IntPtr _ClassPtr;

		// Token: 0x040189A1 RID: 100769
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
