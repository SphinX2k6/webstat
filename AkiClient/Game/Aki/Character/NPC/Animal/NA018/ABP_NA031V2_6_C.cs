using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA018
{
	// Token: 0x0200416B RID: 16747
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA018/ABP_NA031V2_6.ABP_NA031V2_6_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA031V2_6_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6DB RID: 181979 RVA: 0x00AA10F8 File Offset: 0x00A9F2F8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA031V2_6_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA018/ABP_NA031V2_6.ABP_NA031V2_6_C");
			}
			return ABP_NA031V2_6_C._ClassPtr;
		}

		// Token: 0x0602C6DC RID: 181980 RVA: 0x00AA111C File Offset: 0x00A9F31C
		public ABP_NA031V2_6_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA031V2_6_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6DD RID: 181981 RVA: 0x00AA1144 File Offset: 0x00A9F344
		[NullableContext(1)]
		public ABP_NA031V2_6_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA031V2_6_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C6DE RID: 181982 RVA: 0x00AA1177 File Offset: 0x00A9F377
		protected ABP_NA031V2_6_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018ABE RID: 101054
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA018/ABP_NA031V2_6.ABP_NA031V2_6_C";

		// Token: 0x04018ABF RID: 101055
		private static IntPtr _ClassPtr;

		// Token: 0x04018AC0 RID: 101056
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
