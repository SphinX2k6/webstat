using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA046
{
	// Token: 0x0200413E RID: 16702
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA046/ABP_NA046.ABP_NA046_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA046_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C604 RID: 181764 RVA: 0x00A9F404 File Offset: 0x00A9D604
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA046_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA046/ABP_NA046.ABP_NA046_C");
			}
			return ABP_NA046_C._ClassPtr;
		}

		// Token: 0x0602C605 RID: 181765 RVA: 0x00A9F428 File Offset: 0x00A9D628
		public ABP_NA046_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA046_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C606 RID: 181766 RVA: 0x00A9F450 File Offset: 0x00A9D650
		[NullableContext(1)]
		public ABP_NA046_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA046_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C607 RID: 181767 RVA: 0x00A9F483 File Offset: 0x00A9D683
		protected ABP_NA046_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A1E RID: 100894
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA046/ABP_NA046.ABP_NA046_C";

		// Token: 0x04018A1F RID: 100895
		private static IntPtr _ClassPtr;

		// Token: 0x04018A20 RID: 100896
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
