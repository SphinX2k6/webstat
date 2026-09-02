using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA028
{
	// Token: 0x02004161 RID: 16737
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA028/ABP_NA028.ABP_NA028_C")]
	[UnrealStructLayout(18528, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18515)]
	public class ABP_NA028_C : ABP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6AF RID: 181935 RVA: 0x00AA0B50 File Offset: 0x00A9ED50
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_NA028_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA028/ABP_NA028.ABP_NA028_C");
			}
			return ABP_NA028_C._ClassPtr;
		}

		// Token: 0x0602C6B0 RID: 181936 RVA: 0x00AA0B74 File Offset: 0x00A9ED74
		public ABP_NA028_C() : this(BuiltinUtils.AllocNativeUObject(ABP_NA028_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6B1 RID: 181937 RVA: 0x00AA0B9C File Offset: 0x00A9ED9C
		[NullableContext(1)]
		public ABP_NA028_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_NA028_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C6B2 RID: 181938 RVA: 0x00AA0BCF File Offset: 0x00A9EDCF
		protected ABP_NA028_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A9E RID: 101022
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA028/ABP_NA028.ABP_NA028_C";

		// Token: 0x04018A9F RID: 101023
		private static IntPtr _ClassPtr;

		// Token: 0x04018AA0 RID: 101024
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
