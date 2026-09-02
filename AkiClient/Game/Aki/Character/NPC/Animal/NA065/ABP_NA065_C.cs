using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA065
{
	// Token: 0x02004110 RID: 16656
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA065/ABP_NA065.ABP_NA065_C")]
	[UnrealStructLayout(18848, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18834)]
	public class ABP_NA065_C : ABP_BaseRunAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C4E8 RID: 181480 RVA: 0x00A9CF29 File Offset: 0x00A9B129
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA065_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA065/ABP_NA065.ABP_NA065_C");
			}
			return ABP_NA065_C._ClassPtr;
		}

		// Token: 0x0602C4E9 RID: 181481 RVA: 0x00A9CF50 File Offset: 0x00A9B150
		public ABP_NA065_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA065_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C4EA RID: 181482 RVA: 0x00A9CF78 File Offset: 0x00A9B178
		[NullableContext(1)]
		public ABP_NA065_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA065_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C4EB RID: 181483 RVA: 0x00A9CFAB File Offset: 0x00A9B1AB
		protected ABP_NA065_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401894F RID: 100687
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA065/ABP_NA065.ABP_NA065_C";

		// Token: 0x04018950 RID: 100688
		private static IntPtr _ClassPtr;

		// Token: 0x04018951 RID: 100689
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
