using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA018
{
	// Token: 0x02004168 RID: 16744
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA018/ABP_NA018V2_6.ABP_NA018V2_6_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA018V2_6_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6CF RID: 181967 RVA: 0x00AA0F5D File Offset: 0x00A9F15D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA018V2_6_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA018/ABP_NA018V2_6.ABP_NA018V2_6_C");
			}
			return ABP_NA018V2_6_C._ClassPtr;
		}

		// Token: 0x0602C6D0 RID: 181968 RVA: 0x00AA0F84 File Offset: 0x00A9F184
		public ABP_NA018V2_6_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA018V2_6_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6D1 RID: 181969 RVA: 0x00AA0FAC File Offset: 0x00A9F1AC
		[NullableContext(1)]
		public ABP_NA018V2_6_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA018V2_6_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C6D2 RID: 181970 RVA: 0x00AA0FDF File Offset: 0x00A9F1DF
		protected ABP_NA018V2_6_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018AB5 RID: 101045
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA018/ABP_NA018V2_6.ABP_NA018V2_6_C";

		// Token: 0x04018AB6 RID: 101046
		private static IntPtr _ClassPtr;

		// Token: 0x04018AB7 RID: 101047
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
