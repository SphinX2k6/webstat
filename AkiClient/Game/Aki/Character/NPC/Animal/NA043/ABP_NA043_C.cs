using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA043
{
	// Token: 0x02004146 RID: 16710
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA043/ABP_NA043.ABP_NA043_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA043_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C624 RID: 181796 RVA: 0x00A9F844 File Offset: 0x00A9DA44
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA043_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA043/ABP_NA043.ABP_NA043_C");
			}
			return ABP_NA043_C._ClassPtr;
		}

		// Token: 0x0602C625 RID: 181797 RVA: 0x00A9F868 File Offset: 0x00A9DA68
		public ABP_NA043_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA043_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C626 RID: 181798 RVA: 0x00A9F890 File Offset: 0x00A9DA90
		[NullableContext(1)]
		public ABP_NA043_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA043_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C627 RID: 181799 RVA: 0x00A9F8C3 File Offset: 0x00A9DAC3
		protected ABP_NA043_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A36 RID: 100918
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA043/ABP_NA043.ABP_NA043_C";

		// Token: 0x04018A37 RID: 100919
		private static IntPtr _ClassPtr;

		// Token: 0x04018A38 RID: 100920
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
