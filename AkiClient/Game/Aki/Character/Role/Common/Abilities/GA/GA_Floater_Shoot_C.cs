using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Abilities.GA;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Abilities.GA
{
	// Token: 0x02004087 RID: 16519
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Abilities/GA/GA_Floater_Shoot.GA_Floater_Shoot_C")]
	[UnrealStructLayout(1472, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1468)]
	public class GA_Floater_Shoot_C : GA_Base_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AF7B RID: 175995 RVA: 0x00A6B8D0 File Offset: 0x00A69AD0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (GA_Floater_Shoot_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Floater_Shoot.GA_Floater_Shoot_C");
			}
			return GA_Floater_Shoot_C._ClassPtr;
		}

		// Token: 0x0602AF7C RID: 175996 RVA: 0x00A6B8F4 File Offset: 0x00A69AF4
		public GA_Floater_Shoot_C() : this(BuiltinUtils.AllocNativeUObject(GA_Floater_Shoot_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AF7D RID: 175997 RVA: 0x00A6B91C File Offset: 0x00A69B1C
		[NullableContext(1)]
		public GA_Floater_Shoot_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GA_Floater_Shoot_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602AF7E RID: 175998 RVA: 0x00A6B94F File Offset: 0x00A69B4F
		protected GA_Floater_Shoot_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040177AF RID: 96175
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Abilities/GA/GA_Floater_Shoot.GA_Floater_Shoot_C";

		// Token: 0x040177B0 RID: 96176
		private static IntPtr _ClassPtr;

		// Token: 0x040177B1 RID: 96177
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
