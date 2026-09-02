using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA041
{
	// Token: 0x0200414C RID: 16716
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA041/ABP_NA041.ABP_NA041_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA041_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C651 RID: 181841 RVA: 0x00A9FF55 File Offset: 0x00A9E155
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA041_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA041/ABP_NA041.ABP_NA041_C");
			}
			return ABP_NA041_C._ClassPtr;
		}

		// Token: 0x0602C652 RID: 181842 RVA: 0x00A9FF7C File Offset: 0x00A9E17C
		public ABP_NA041_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA041_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C653 RID: 181843 RVA: 0x00A9FFA4 File Offset: 0x00A9E1A4
		[NullableContext(1)]
		public ABP_NA041_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA041_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C654 RID: 181844 RVA: 0x00A9FFD7 File Offset: 0x00A9E1D7
		protected ABP_NA041_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A5A RID: 100954
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA041/ABP_NA041.ABP_NA041_C";

		// Token: 0x04018A5B RID: 100955
		private static IntPtr _ClassPtr;

		// Token: 0x04018A5C RID: 100956
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
