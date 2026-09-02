using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA073
{
	// Token: 0x020040F6 RID: 16630
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA073/ABP_NA073.ABP_NA073_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA073_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C459 RID: 181337 RVA: 0x00A9BCFD File Offset: 0x00A99EFD
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA073_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA073/ABP_NA073.ABP_NA073_C");
			}
			return ABP_NA073_C._ClassPtr;
		}

		// Token: 0x0602C45A RID: 181338 RVA: 0x00A9BD24 File Offset: 0x00A99F24
		public ABP_NA073_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA073_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C45B RID: 181339 RVA: 0x00A9BD4C File Offset: 0x00A99F4C
		[NullableContext(1)]
		public ABP_NA073_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA073_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C45C RID: 181340 RVA: 0x00A9BD7F File Offset: 0x00A99F7F
		protected ABP_NA073_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040188E9 RID: 100585
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA073/ABP_NA073.ABP_NA073_C";

		// Token: 0x040188EA RID: 100586
		private static IntPtr _ClassPtr;

		// Token: 0x040188EB RID: 100587
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
