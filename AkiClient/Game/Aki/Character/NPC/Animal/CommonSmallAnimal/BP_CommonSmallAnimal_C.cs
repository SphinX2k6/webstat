using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.CommonSmallAnimal
{
	// Token: 0x02004191 RID: 16785
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/CommonSmallAnimal/BP_CommonSmallAnimal.BP_CommonSmallAnimal_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_CommonSmallAnimal_C : BP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C7B9 RID: 182201 RVA: 0x00AA30B0 File Offset: 0x00AA12B0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CommonSmallAnimal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/CommonSmallAnimal/BP_CommonSmallAnimal.BP_CommonSmallAnimal_C");
			}
			return BP_CommonSmallAnimal_C._ClassPtr;
		}

		// Token: 0x0602C7BA RID: 182202 RVA: 0x00AA30D4 File Offset: 0x00AA12D4
		public BP_CommonSmallAnimal_C() : this(BuiltinUtils.AllocNativeUObject(BP_CommonSmallAnimal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C7BB RID: 182203 RVA: 0x00AA30FC File Offset: 0x00AA12FC
		[NullableContext(1)]
		public BP_CommonSmallAnimal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CommonSmallAnimal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C7BC RID: 182204 RVA: 0x00AA312F File Offset: 0x00AA132F
		protected BP_CommonSmallAnimal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B67 RID: 101223
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/CommonSmallAnimal/BP_CommonSmallAnimal.BP_CommonSmallAnimal_C";

		// Token: 0x04018B68 RID: 101224
		private static IntPtr _ClassPtr;

		// Token: 0x04018B69 RID: 101225
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
