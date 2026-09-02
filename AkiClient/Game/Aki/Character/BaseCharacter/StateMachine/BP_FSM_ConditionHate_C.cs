using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x0200429B RID: 17051
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_ConditionHate.BP_FSM_ConditionHate_C")]
	[UnrealStructLayout(88, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 81)]
	public class BP_FSM_ConditionHate_C : UKuroStateMachineConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D48B RID: 185483 RVA: 0x00ABBE6D File Offset: 0x00ABA06D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FSM_ConditionHate_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_ConditionHate.BP_FSM_ConditionHate_C");
			}
			return BP_FSM_ConditionHate_C._ClassPtr;
		}

		// Token: 0x0602D48C RID: 185484 RVA: 0x00ABBE94 File Offset: 0x00ABA094
		public BP_FSM_ConditionHate_C() : this(BuiltinUtils.AllocNativeUObject(BP_FSM_ConditionHate_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D48D RID: 185485 RVA: 0x00ABBEBC File Offset: 0x00ABA0BC
		[NullableContext(1)]
		public BP_FSM_ConditionHate_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FSM_ConditionHate_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B6E RID: 31598
		// (get) Token: 0x0602D48E RID: 185486 RVA: 0x00ABBEEF File Offset: 0x00ABA0EF
		// (set) Token: 0x0602D48F RID: 185487 RVA: 0x00ABBEFF File Offset: 0x00ABA0FF
		public unsafe bool HasHateTarget
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FSM_ConditionHate_C.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FSM_ConditionHate_C.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D490 RID: 185488 RVA: 0x00ABBF10 File Offset: 0x00ABA110
		protected BP_FSM_ConditionHate_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401962F RID: 103983
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_ConditionHate.BP_FSM_ConditionHate_C";

		// Token: 0x04019630 RID: 103984
		private static IntPtr _ClassPtr;

		// Token: 0x04019631 RID: 103985
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019632 RID: 103986
		internal static int __PropertyOffset_0;
	}
}
