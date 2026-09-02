using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x0200429D RID: 17053
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_ConditionTag.BP_FSM_ConditionTag_C")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 93)]
	public class BP_FSM_ConditionTag_C : UKuroStateMachineConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D495 RID: 185493 RVA: 0x00ABBFA4 File Offset: 0x00ABA1A4
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FSM_ConditionTag_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_ConditionTag.BP_FSM_ConditionTag_C");
			}
			return BP_FSM_ConditionTag_C._ClassPtr;
		}

		// Token: 0x0602D496 RID: 185494 RVA: 0x00ABBFC8 File Offset: 0x00ABA1C8
		public BP_FSM_ConditionTag_C() : this(BuiltinUtils.AllocNativeUObject(BP_FSM_ConditionTag_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D497 RID: 185495 RVA: 0x00ABBFF0 File Offset: 0x00ABA1F0
		[NullableContext(1)]
		public BP_FSM_ConditionTag_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FSM_ConditionTag_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B6F RID: 31599
		// (get) Token: 0x0602D498 RID: 185496 RVA: 0x00ABC023 File Offset: 0x00ABA223
		// (set) Token: 0x0602D499 RID: 185497 RVA: 0x00ABC037 File Offset: 0x00ABA237
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FSM_ConditionTag_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FSM_ConditionTag_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007B70 RID: 31600
		// (get) Token: 0x0602D49A RID: 185498 RVA: 0x00ABC04C File Offset: 0x00ABA24C
		// (set) Token: 0x0602D49B RID: 185499 RVA: 0x00ABC05C File Offset: 0x00ABA25C
		public unsafe bool CheckExist
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FSM_ConditionTag_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FSM_ConditionTag_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D49C RID: 185500 RVA: 0x00ABC06D File Offset: 0x00ABA26D
		protected BP_FSM_ConditionTag_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019636 RID: 103990
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_FSM_ConditionTag.BP_FSM_ConditionTag_C";

		// Token: 0x04019637 RID: 103991
		private static IntPtr _ClassPtr;

		// Token: 0x04019638 RID: 103992
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019639 RID: 103993
		internal static int __PropertyOffset_0;

		// Token: 0x0401963A RID: 103994
		internal static int __PropertyOffset_1;
	}
}
