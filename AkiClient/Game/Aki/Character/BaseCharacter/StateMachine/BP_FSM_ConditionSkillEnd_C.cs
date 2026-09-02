using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x0200429C RID: 17052
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_ConditionSkillEnd.BP_FSM_ConditionSkillEnd_C")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 80)]
	public class BP_FSM_ConditionSkillEnd_C : UKuroStateMachineConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D491 RID: 185489 RVA: 0x00ABBF19 File Offset: 0x00ABA119
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FSM_ConditionSkillEnd_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_ConditionSkillEnd.BP_FSM_ConditionSkillEnd_C");
			}
			return BP_FSM_ConditionSkillEnd_C._ClassPtr;
		}

		// Token: 0x0602D492 RID: 185490 RVA: 0x00ABBF40 File Offset: 0x00ABA140
		public BP_FSM_ConditionSkillEnd_C() : this(BuiltinUtils.AllocNativeUObject(BP_FSM_ConditionSkillEnd_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D493 RID: 185491 RVA: 0x00ABBF68 File Offset: 0x00ABA168
		[NullableContext(1)]
		public BP_FSM_ConditionSkillEnd_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FSM_ConditionSkillEnd_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D494 RID: 185492 RVA: 0x00ABBF9B File Offset: 0x00ABA19B
		protected BP_FSM_ConditionSkillEnd_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019633 RID: 103987
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_ConditionSkillEnd.BP_FSM_ConditionSkillEnd_C";

		// Token: 0x04019634 RID: 103988
		private static IntPtr _ClassPtr;

		// Token: 0x04019635 RID: 103989
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
