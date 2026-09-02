using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA035
{
	// Token: 0x02004159 RID: 16729
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA035/ABP_NA035.ABP_NA035_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA035_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C685 RID: 181893 RVA: 0x00AA0640 File Offset: 0x00A9E840
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA035_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA035/ABP_NA035.ABP_NA035_C");
			}
			return ABP_NA035_C._ClassPtr;
		}

		// Token: 0x0602C686 RID: 181894 RVA: 0x00AA0664 File Offset: 0x00A9E864
		public ABP_NA035_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA035_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C687 RID: 181895 RVA: 0x00AA068C File Offset: 0x00A9E88C
		[NullableContext(1)]
		public ABP_NA035_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA035_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C688 RID: 181896 RVA: 0x00AA06BF File Offset: 0x00A9E8BF
		protected ABP_NA035_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A81 RID: 100993
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA035/ABP_NA035.ABP_NA035_C";

		// Token: 0x04018A82 RID: 100994
		private static IntPtr _ClassPtr;

		// Token: 0x04018A83 RID: 100995
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
