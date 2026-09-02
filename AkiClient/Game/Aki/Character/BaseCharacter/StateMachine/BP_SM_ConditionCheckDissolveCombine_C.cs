using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042C5 RID: 17093
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckDissolveCombine.BP_SM_ConditionCheckDissolveCombine_C")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 56)]
	public class BP_SM_ConditionCheckDissolveCombine_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D5CB RID: 185803 RVA: 0x00ABE12F File Offset: 0x00ABC32F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionCheckDissolveCombine_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckDissolveCombine.BP_SM_ConditionCheckDissolveCombine_C");
			}
			return BP_SM_ConditionCheckDissolveCombine_C._ClassPtr;
		}

		// Token: 0x0602D5CC RID: 185804 RVA: 0x00ABE154 File Offset: 0x00ABC354
		public BP_SM_ConditionCheckDissolveCombine_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionCheckDissolveCombine_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D5CD RID: 185805 RVA: 0x00ABE17C File Offset: 0x00ABC37C
		[NullableContext(1)]
		public BP_SM_ConditionCheckDissolveCombine_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionCheckDissolveCombine_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D5CE RID: 185806 RVA: 0x00ABE1AF File Offset: 0x00ABC3AF
		protected BP_SM_ConditionCheckDissolveCombine_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019703 RID: 104195
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckDissolveCombine.BP_SM_ConditionCheckDissolveCombine_C";

		// Token: 0x04019704 RID: 104196
		private static IntPtr _ClassPtr;

		// Token: 0x04019705 RID: 104197
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
