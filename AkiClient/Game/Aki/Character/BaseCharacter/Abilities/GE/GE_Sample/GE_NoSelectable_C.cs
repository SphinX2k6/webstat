using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Sample
{
	// Token: 0x0200433F RID: 17215
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_NoSelectable.GE_NoSelectable_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_NoSelectable_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA68 RID: 186984 RVA: 0x00AC5B9C File Offset: 0x00AC3D9C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_NoSelectable_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_NoSelectable.GE_NoSelectable_C");
			}
			return GE_NoSelectable_C._ClassPtr;
		}

		// Token: 0x0602DA69 RID: 186985 RVA: 0x00AC5BC0 File Offset: 0x00AC3DC0
		public GE_NoSelectable_C() : this(BuiltinUtils.AllocNativeUObject(GE_NoSelectable_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA6A RID: 186986 RVA: 0x00AC5BE8 File Offset: 0x00AC3DE8
		[NullableContext(1)]
		public GE_NoSelectable_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_NoSelectable_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA6B RID: 186987 RVA: 0x00AC5C1B File Offset: 0x00AC3E1B
		protected GE_NoSelectable_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BD8 RID: 105432
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Sample/GE_NoSelectable.GE_NoSelectable_C";

		// Token: 0x04019BD9 RID: 105433
		private static IntPtr _ClassPtr;

		// Token: 0x04019BDA RID: 105434
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
