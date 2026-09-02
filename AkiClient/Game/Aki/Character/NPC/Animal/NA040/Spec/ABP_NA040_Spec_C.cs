using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA040.Spec
{
	// Token: 0x02004150 RID: 16720
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA040/Spec/ABP_NA040_Spec.ABP_NA040_Spec_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA040_Spec_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C661 RID: 181857 RVA: 0x00AA0178 File Offset: 0x00A9E378
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA040_Spec_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA040/Spec/ABP_NA040_Spec.ABP_NA040_Spec_C");
			}
			return ABP_NA040_Spec_C._ClassPtr;
		}

		// Token: 0x0602C662 RID: 181858 RVA: 0x00AA019C File Offset: 0x00A9E39C
		public ABP_NA040_Spec_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA040_Spec_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C663 RID: 181859 RVA: 0x00AA01C4 File Offset: 0x00A9E3C4
		[NullableContext(1)]
		public ABP_NA040_Spec_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA040_Spec_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C664 RID: 181860 RVA: 0x00AA01F7 File Offset: 0x00A9E3F7
		protected ABP_NA040_Spec_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A66 RID: 100966
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA040/Spec/ABP_NA040_Spec.ABP_NA040_Spec_C";

		// Token: 0x04018A67 RID: 100967
		private static IntPtr _ClassPtr;

		// Token: 0x04018A68 RID: 100968
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
