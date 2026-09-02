using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_Tough
{
	// Token: 0x02004349 RID: 17225
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Tough/GE_Tough_Skill.GE_Tough_Skill_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Tough_Skill_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA92 RID: 187026 RVA: 0x00AC6244 File Offset: 0x00AC4444
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Tough_Skill_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Tough/GE_Tough_Skill.GE_Tough_Skill_C");
			}
			return GE_Tough_Skill_C._ClassPtr;
		}

		// Token: 0x0602DA93 RID: 187027 RVA: 0x00AC6268 File Offset: 0x00AC4468
		public GE_Tough_Skill_C() : this(BuiltinUtils.AllocNativeUObject(GE_Tough_Skill_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA94 RID: 187028 RVA: 0x00AC6290 File Offset: 0x00AC4490
		[NullableContext(1)]
		public GE_Tough_Skill_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Tough_Skill_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA95 RID: 187029 RVA: 0x00AC62C3 File Offset: 0x00AC44C3
		protected GE_Tough_Skill_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BF7 RID: 105463
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_Tough/GE_Tough_Skill.GE_Tough_Skill_C";

		// Token: 0x04019BF8 RID: 105464
		private static IntPtr _ClassPtr;

		// Token: 0x04019BF9 RID: 105465
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
