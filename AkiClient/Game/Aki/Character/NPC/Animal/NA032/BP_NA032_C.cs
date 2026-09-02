using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA032
{
	// Token: 0x02004160 RID: 16736
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA032/BP_NA032.BP_NA032_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_NA032_C : BP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C6AB RID: 181931 RVA: 0x00AA0AC8 File Offset: 0x00A9ECC8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_NA032_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA032/BP_NA032.BP_NA032_C");
			}
			return BP_NA032_C._ClassPtr;
		}

		// Token: 0x0602C6AC RID: 181932 RVA: 0x00AA0AEC File Offset: 0x00A9ECEC
		public BP_NA032_C() : this(BuiltinUtils.AllocNativeUObject(BP_NA032_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C6AD RID: 181933 RVA: 0x00AA0B14 File Offset: 0x00A9ED14
		[NullableContext(1)]
		public BP_NA032_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_NA032_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C6AE RID: 181934 RVA: 0x00AA0B47 File Offset: 0x00A9ED47
		protected BP_NA032_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A9B RID: 101019
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA032/BP_NA032.BP_NA032_C";

		// Token: 0x04018A9C RID: 101020
		private static IntPtr _ClassPtr;

		// Token: 0x04018A9D RID: 101021
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
