using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Template
{
	// Token: 0x02004333 RID: 17203
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Template/GE_Template_InfinitePeriodic.GE_Template_InfinitePeriodic_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Template_InfinitePeriodic_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA31 RID: 186929 RVA: 0x00AC5448 File Offset: 0x00AC3648
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Template_InfinitePeriodic_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Template/GE_Template_InfinitePeriodic.GE_Template_InfinitePeriodic_C");
			}
			return GE_Template_InfinitePeriodic_C._ClassPtr;
		}

		// Token: 0x0602DA32 RID: 186930 RVA: 0x00AC546C File Offset: 0x00AC366C
		public GE_Template_InfinitePeriodic_C() : this(BuiltinUtils.AllocNativeUObject(GE_Template_InfinitePeriodic_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA33 RID: 186931 RVA: 0x00AC5494 File Offset: 0x00AC3694
		[NullableContext(1)]
		public GE_Template_InfinitePeriodic_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Template_InfinitePeriodic_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA34 RID: 186932 RVA: 0x00AC54C7 File Offset: 0x00AC36C7
		protected GE_Template_InfinitePeriodic_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BAF RID: 105391
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Template/GE_Template_InfinitePeriodic.GE_Template_InfinitePeriodic_C";

		// Token: 0x04019BB0 RID: 105392
		private static IntPtr _ClassPtr;

		// Token: 0x04019BB1 RID: 105393
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
