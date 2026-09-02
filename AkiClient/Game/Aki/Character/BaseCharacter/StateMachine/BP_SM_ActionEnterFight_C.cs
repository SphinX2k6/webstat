using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042A8 RID: 17064
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionEnterFight.BP_SM_ActionEnterFight_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BP_SM_ActionEnterFight_C : UASMAction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D4E9 RID: 185577 RVA: 0x00ABC91C File Offset: 0x00ABAB1C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ActionEnterFight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionEnterFight.BP_SM_ActionEnterFight_C");
			}
			return BP_SM_ActionEnterFight_C._ClassPtr;
		}

		// Token: 0x0602D4EA RID: 185578 RVA: 0x00ABC940 File Offset: 0x00ABAB40
		public BP_SM_ActionEnterFight_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionEnterFight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D4EB RID: 185579 RVA: 0x00ABC968 File Offset: 0x00ABAB68
		[NullableContext(1)]
		public BP_SM_ActionEnterFight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionEnterFight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D4EC RID: 185580 RVA: 0x00ABC99B File Offset: 0x00ABAB9B
		protected BP_SM_ActionEnterFight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019670 RID: 104048
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionEnterFight.BP_SM_ActionEnterFight_C";

		// Token: 0x04019671 RID: 104049
		private static IntPtr _ClassPtr;

		// Token: 0x04019672 RID: 104050
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
