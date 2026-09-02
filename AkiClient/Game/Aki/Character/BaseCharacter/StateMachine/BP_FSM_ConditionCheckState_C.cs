using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x0200429A RID: 17050
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_ConditionCheckState.BP_FSM_ConditionCheckState_C")]
	[UnrealStructLayout(104, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 97)]
	public class BP_FSM_ConditionCheckState_C : UKuroStateMachineConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D483 RID: 185475 RVA: 0x00ABBD7C File Offset: 0x00AB9F7C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FSM_ConditionCheckState_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_ConditionCheckState.BP_FSM_ConditionCheckState_C");
			}
			return BP_FSM_ConditionCheckState_C._ClassPtr;
		}

		// Token: 0x0602D484 RID: 185476 RVA: 0x00ABBDA0 File Offset: 0x00AB9FA0
		public BP_FSM_ConditionCheckState_C() : this(BuiltinUtils.AllocNativeUObject(BP_FSM_ConditionCheckState_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D485 RID: 185477 RVA: 0x00ABBDC8 File Offset: 0x00AB9FC8
		public BP_FSM_ConditionCheckState_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FSM_ConditionCheckState_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B6C RID: 31596
		// (get) Token: 0x0602D486 RID: 185478 RVA: 0x00ABBDFC File Offset: 0x00AB9FFC
		// (set) Token: 0x0602D487 RID: 185479 RVA: 0x00ABBE35 File Offset: 0x00ABA035
		public TArray<string> States
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._States) == null)
				{
					result = (this._States = new TArray<string>(base.NativePtr + (IntPtr)BP_FSM_ConditionCheckState_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.States.CopyAssign(value);
			}
		}

		// Token: 0x17007B6D RID: 31597
		// (get) Token: 0x0602D488 RID: 185480 RVA: 0x00ABBE43 File Offset: 0x00ABA043
		// (set) Token: 0x0602D489 RID: 185481 RVA: 0x00ABBE53 File Offset: 0x00ABA053
		public unsafe bool Activated
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FSM_ConditionCheckState_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FSM_ConditionCheckState_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D48A RID: 185482 RVA: 0x00ABBE64 File Offset: 0x00ABA064
		protected BP_FSM_ConditionCheckState_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019629 RID: 103977
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_ConditionCheckState.BP_FSM_ConditionCheckState_C";

		// Token: 0x0401962A RID: 103978
		private static IntPtr _ClassPtr;

		// Token: 0x0401962B RID: 103979
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401962C RID: 103980
		internal static int __PropertyOffset_0;

		// Token: 0x0401962D RID: 103981
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _States;

		// Token: 0x0401962E RID: 103982
		internal static int __PropertyOffset_1;
	}
}
