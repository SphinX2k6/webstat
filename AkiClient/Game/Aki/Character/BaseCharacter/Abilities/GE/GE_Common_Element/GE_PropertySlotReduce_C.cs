using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Element
{
	// Token: 0x0200435C RID: 17244
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/GE_PropertySlotReduce.GE_PropertySlotReduce_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_PropertySlotReduce_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DADE RID: 187102 RVA: 0x00AC6C5C File Offset: 0x00AC4E5C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_PropertySlotReduce_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/GE_PropertySlotReduce.GE_PropertySlotReduce_C");
			}
			return GE_PropertySlotReduce_C._ClassPtr;
		}

		// Token: 0x0602DADF RID: 187103 RVA: 0x00AC6C80 File Offset: 0x00AC4E80
		public GE_PropertySlotReduce_C() : this(BuiltinUtils.AllocNativeUObject(GE_PropertySlotReduce_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAE0 RID: 187104 RVA: 0x00AC6CA8 File Offset: 0x00AC4EA8
		[NullableContext(1)]
		public GE_PropertySlotReduce_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_PropertySlotReduce_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAE1 RID: 187105 RVA: 0x00AC6CDB File Offset: 0x00AC4EDB
		protected GE_PropertySlotReduce_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C30 RID: 105520
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Element/GE_PropertySlotReduce.GE_PropertySlotReduce_C";

		// Token: 0x04019C31 RID: 105521
		private static IntPtr _ClassPtr;

		// Token: 0x04019C32 RID: 105522
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
