using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042CB RID: 17099
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckPositionState.BP_SM_ConditionCheckPositionState_C")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 57)]
	public class BP_SM_ConditionCheckPositionState_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D5E9 RID: 185833 RVA: 0x00ABE4E1 File Offset: 0x00ABC6E1
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionCheckPositionState_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckPositionState.BP_SM_ConditionCheckPositionState_C");
			}
			return BP_SM_ConditionCheckPositionState_C._ClassPtr;
		}

		// Token: 0x0602D5EA RID: 185834 RVA: 0x00ABE508 File Offset: 0x00ABC708
		public BP_SM_ConditionCheckPositionState_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionCheckPositionState_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D5EB RID: 185835 RVA: 0x00ABE530 File Offset: 0x00ABC730
		[NullableContext(1)]
		public BP_SM_ConditionCheckPositionState_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionCheckPositionState_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BBD RID: 31677
		// (get) Token: 0x0602D5EC RID: 185836 RVA: 0x00ABE563 File Offset: 0x00ABC763
		// (set) Token: 0x0602D5ED RID: 185837 RVA: 0x00ABE577 File Offset: 0x00ABC777
		public unsafe TEnumAsByte<ECharParentMoveState> 位置状态
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionCheckPositionState_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionCheckPositionState_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x0602D5EE RID: 185838 RVA: 0x00ABE58C File Offset: 0x00ABC78C
		protected BP_SM_ConditionCheckPositionState_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019718 RID: 104216
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckPositionState.BP_SM_ConditionCheckPositionState_C";

		// Token: 0x04019719 RID: 104217
		private static IntPtr _ClassPtr;

		// Token: 0x0401971A RID: 104218
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401971B RID: 104219
		internal static int __PropertyOffset_0;
	}
}
