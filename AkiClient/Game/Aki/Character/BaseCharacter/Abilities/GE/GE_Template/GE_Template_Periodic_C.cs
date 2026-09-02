using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GE.GE_Template
{
	// Token: 0x02004336 RID: 17206
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Template/GE_Template_Periodic.GE_Template_Periodic_C")]
	[UnrealStructLayout(2376, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 2376)]
	public class GE_Template_Periodic_C : UGameplayEffect, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DA3D RID: 186941 RVA: 0x00AC55E0 File Offset: 0x00AC37E0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GE_Template_Periodic_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Template/GE_Template_Periodic.GE_Template_Periodic_C");
			}
			return GE_Template_Periodic_C._ClassPtr;
		}

		// Token: 0x0602DA3E RID: 186942 RVA: 0x00AC5604 File Offset: 0x00AC3804
		public GE_Template_Periodic_C() : this(BuiltinUtils.AllocNativeUObject(GE_Template_Periodic_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DA3F RID: 186943 RVA: 0x00AC562C File Offset: 0x00AC382C
		[NullableContext(1)]
		public GE_Template_Periodic_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GE_Template_Periodic_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602DA40 RID: 186944 RVA: 0x00AC565F File Offset: 0x00AC385F
		protected GE_Template_Periodic_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019BB8 RID: 105400
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Abilities/GE/GE_Template/GE_Template_Periodic.GE_Template_Periodic_C";

		// Token: 0x04019BB9 RID: 105401
		private static IntPtr _ClassPtr;

		// Token: 0x04019BBA RID: 105402
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
