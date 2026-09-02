using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Template;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Common_State
{
	// Token: 0x0200434F RID: 17231
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_State/GE_Stiff.GE_Stiff_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Stiff_C : GE_Template_Duration_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DAAA RID: 187050 RVA: 0x00AC6574 File Offset: 0x00AC4774
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Stiff_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_State/GE_Stiff.GE_Stiff_C");
			}
			return GE_Stiff_C._ClassPtr;
		}

		// Token: 0x0602DAAB RID: 187051 RVA: 0x00AC6598 File Offset: 0x00AC4798
		public GE_Stiff_C() : this(BuiltinUtils.AllocNativeUObject(GE_Stiff_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DAAC RID: 187052 RVA: 0x00AC65C0 File Offset: 0x00AC47C0
		[NullableContext(1)]
		public GE_Stiff_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Stiff_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DAAD RID: 187053 RVA: 0x00AC65F3 File Offset: 0x00AC47F3
		protected GE_Stiff_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019C09 RID: 105481
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Common_State/GE_Stiff.GE_Stiff_C";

		// Token: 0x04019C0A RID: 105482
		private static IntPtr _ClassPtr;

		// Token: 0x04019C0B RID: 105483
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
