using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042C8 RID: 17096
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckInstState.BP_SM_ConditionCheckInstState_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 68)]
	public class BP_SM_ConditionCheckInstState_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D5D7 RID: 185815 RVA: 0x00ABE2C8 File Offset: 0x00ABC4C8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionCheckInstState_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckInstState.BP_SM_ConditionCheckInstState_C");
			}
			return BP_SM_ConditionCheckInstState_C._ClassPtr;
		}

		// Token: 0x0602D5D8 RID: 185816 RVA: 0x00ABE2EC File Offset: 0x00ABC4EC
		public BP_SM_ConditionCheckInstState_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionCheckInstState_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D5D9 RID: 185817 RVA: 0x00ABE314 File Offset: 0x00ABC514
		[NullableContext(1)]
		public BP_SM_ConditionCheckInstState_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionCheckInstState_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BBA RID: 31674
		// (get) Token: 0x0602D5DA RID: 185818 RVA: 0x00ABE347 File Offset: 0x00ABC547
		// (set) Token: 0x0602D5DB RID: 185819 RVA: 0x00ABE35B File Offset: 0x00ABC55B
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionCheckInstState_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionCheckInstState_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x0602D5DC RID: 185820 RVA: 0x00ABE370 File Offset: 0x00ABC570
		protected BP_SM_ConditionCheckInstState_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401970C RID: 104204
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckInstState.BP_SM_ConditionCheckInstState_C";

		// Token: 0x0401970D RID: 104205
		private static IntPtr _ClassPtr;

		// Token: 0x0401970E RID: 104206
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401970F RID: 104207
		internal static int __PropertyOffset_0;
	}
}
