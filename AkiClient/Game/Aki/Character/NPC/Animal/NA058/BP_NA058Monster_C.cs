using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA058
{
	// Token: 0x02004129 RID: 16681
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA058/BP_NA058Monster.BP_NA058Monster_C")]
	[UnrealStructLayout(2224, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2224)]
	public class BP_NA058Monster_C : __TsBaseCharacter_InheritProxy, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C598 RID: 181656 RVA: 0x00A9E5C0 File Offset: 0x00A9C7C0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA058Monster_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA058/BP_NA058Monster.BP_NA058Monster_C");
			}
			return BP_NA058Monster_C._ClassPtr;
		}

		// Token: 0x0602C599 RID: 181657 RVA: 0x00A9E5E4 File Offset: 0x00A9C7E4
		public BP_NA058Monster_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA058Monster_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C59A RID: 181658 RVA: 0x00A9E60C File Offset: 0x00A9C80C
		[NullableContext(1)]
		public BP_NA058Monster_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA058Monster_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C59B RID: 181659 RVA: 0x00A9E63F File Offset: 0x00A9C83F
		protected BP_NA058Monster_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040189CC RID: 100812
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA058/BP_NA058Monster.BP_NA058Monster_C";

		// Token: 0x040189CD RID: 100813
		private static IntPtr _ClassPtr;

		// Token: 0x040189CE RID: 100814
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
