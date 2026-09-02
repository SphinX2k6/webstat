using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA068
{
	// Token: 0x02004104 RID: 16644
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA068/ABP_NA068.ABP_NA068_C")]
	[UnrealStructLayout(18848, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18834)]
	public class ABP_NA068_C : ABP_BaseRunAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C49C RID: 181404 RVA: 0x00A9C5BC File Offset: 0x00A9A7BC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA068_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA068/ABP_NA068.ABP_NA068_C");
			}
			return ABP_NA068_C._ClassPtr;
		}

		// Token: 0x0602C49D RID: 181405 RVA: 0x00A9C5E0 File Offset: 0x00A9A7E0
		public ABP_NA068_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA068_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C49E RID: 181406 RVA: 0x00A9C608 File Offset: 0x00A9A808
		[NullableContext(1)]
		public ABP_NA068_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA068_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C49F RID: 181407 RVA: 0x00A9C63B File Offset: 0x00A9A83B
		protected ABP_NA068_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401891A RID: 100634
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA068/ABP_NA068.ABP_NA068_C";

		// Token: 0x0401891B RID: 100635
		private static IntPtr _ClassPtr;

		// Token: 0x0401891C RID: 100636
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
