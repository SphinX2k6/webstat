using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA043.Spec
{
	// Token: 0x02004148 RID: 16712
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA043/Spec/ABP_NA043_Spec.ABP_NA043_Spec_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA043_Spec_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C634 RID: 181812 RVA: 0x00A9FA38 File Offset: 0x00A9DC38
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA043_Spec_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA043/Spec/ABP_NA043_Spec.ABP_NA043_Spec_C");
			}
			return ABP_NA043_Spec_C._ClassPtr;
		}

		// Token: 0x0602C635 RID: 181813 RVA: 0x00A9FA5C File Offset: 0x00A9DC5C
		public ABP_NA043_Spec_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA043_Spec_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C636 RID: 181814 RVA: 0x00A9FA84 File Offset: 0x00A9DC84
		[NullableContext(1)]
		public ABP_NA043_Spec_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA043_Spec_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C637 RID: 181815 RVA: 0x00A9FAB7 File Offset: 0x00A9DCB7
		protected ABP_NA043_Spec_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A42 RID: 100930
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA043/Spec/ABP_NA043_Spec.ABP_NA043_Spec_C";

		// Token: 0x04018A43 RID: 100931
		private static IntPtr _ClassPtr;

		// Token: 0x04018A44 RID: 100932
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
