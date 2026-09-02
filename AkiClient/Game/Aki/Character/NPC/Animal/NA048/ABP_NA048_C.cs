using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA048
{
	// Token: 0x0200413A RID: 16698
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA048/ABP_NA048.ABP_NA048_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA048_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C5F4 RID: 181748 RVA: 0x00A9F1E4 File Offset: 0x00A9D3E4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA048_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA048/ABP_NA048.ABP_NA048_C");
			}
			return ABP_NA048_C._ClassPtr;
		}

		// Token: 0x0602C5F5 RID: 181749 RVA: 0x00A9F208 File Offset: 0x00A9D408
		public ABP_NA048_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA048_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C5F6 RID: 181750 RVA: 0x00A9F230 File Offset: 0x00A9D430
		[NullableContext(1)]
		public ABP_NA048_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA048_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C5F7 RID: 181751 RVA: 0x00A9F263 File Offset: 0x00A9D463
		protected ABP_NA048_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A12 RID: 100882
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA048/ABP_NA048.ABP_NA048_C";

		// Token: 0x04018A13 RID: 100883
		private static IntPtr _ClassPtr;

		// Token: 0x04018A14 RID: 100884
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
