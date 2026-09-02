using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.CommonBigAnimal
{
	// Token: 0x02004197 RID: 16791
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/CommonBigAnimal/BP_CommonBigAnimal.BP_CommonBigAnimal_C")]
	[UnrealStructLayout(2240, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2232)]
	public class BP_CommonBigAnimal_C : BP_BaseAnimal_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C84C RID: 182348 RVA: 0x00AA4994 File Offset: 0x00AA2B94
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CommonBigAnimal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/CommonBigAnimal/BP_CommonBigAnimal.BP_CommonBigAnimal_C");
			}
			return BP_CommonBigAnimal_C._ClassPtr;
		}

		// Token: 0x0602C84D RID: 182349 RVA: 0x00AA49B8 File Offset: 0x00AA2BB8
		public BP_CommonBigAnimal_C() : this(BuiltinUtils.AllocNativeUObject(BP_CommonBigAnimal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C84E RID: 182350 RVA: 0x00AA49E0 File Offset: 0x00AA2BE0
		[NullableContext(1)]
		public BP_CommonBigAnimal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CommonBigAnimal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602C84F RID: 182351 RVA: 0x00AA4A13 File Offset: 0x00AA2C13
		protected BP_CommonBigAnimal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018BE5 RID: 101349
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/CommonBigAnimal/BP_CommonBigAnimal.BP_CommonBigAnimal_C";

		// Token: 0x04018BE6 RID: 101350
		private static IntPtr _ClassPtr;

		// Token: 0x04018BE7 RID: 101351
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
