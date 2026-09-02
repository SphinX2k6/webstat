using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042C9 RID: 17097
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckLastState.BP_SM_ConditionCheckLastState_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 72)]
	public class BP_SM_ConditionCheckLastState_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D5DD RID: 185821 RVA: 0x00ABE379 File Offset: 0x00ABC579
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionCheckLastState_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckLastState.BP_SM_ConditionCheckLastState_C");
			}
			return BP_SM_ConditionCheckLastState_C._ClassPtr;
		}

		// Token: 0x0602D5DE RID: 185822 RVA: 0x00ABE3A0 File Offset: 0x00ABC5A0
		public BP_SM_ConditionCheckLastState_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionCheckLastState_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D5DF RID: 185823 RVA: 0x00ABE3C8 File Offset: 0x00ABC5C8
		public BP_SM_ConditionCheckLastState_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionCheckLastState_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BBB RID: 31675
		// (get) Token: 0x0602D5E0 RID: 185824 RVA: 0x00ABE3FB File Offset: 0x00ABC5FB
		// (set) Token: 0x0602D5E1 RID: 185825 RVA: 0x00ABE40F File Offset: 0x00ABC60F
		public unsafe string 检查状态
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_ConditionCheckLastState_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_ConditionCheckLastState_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x0602D5E2 RID: 185826 RVA: 0x00ABE424 File Offset: 0x00ABC624
		protected BP_SM_ConditionCheckLastState_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019710 RID: 104208
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckLastState.BP_SM_ConditionCheckLastState_C";

		// Token: 0x04019711 RID: 104209
		private static IntPtr _ClassPtr;

		// Token: 0x04019712 RID: 104210
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019713 RID: 104211
		internal static int __PropertyOffset_0;
	}
}
