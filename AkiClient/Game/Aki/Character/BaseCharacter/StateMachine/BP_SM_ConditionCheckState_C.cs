using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042CC RID: 17100
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckState.BP_SM_ConditionCheckState_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 72)]
	public class BP_SM_ConditionCheckState_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D5EF RID: 185839 RVA: 0x00ABE595 File Offset: 0x00ABC795
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionCheckState_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckState.BP_SM_ConditionCheckState_C");
			}
			return BP_SM_ConditionCheckState_C._ClassPtr;
		}

		// Token: 0x0602D5F0 RID: 185840 RVA: 0x00ABE5BC File Offset: 0x00ABC7BC
		public BP_SM_ConditionCheckState_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionCheckState_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D5F1 RID: 185841 RVA: 0x00ABE5E4 File Offset: 0x00ABC7E4
		public BP_SM_ConditionCheckState_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionCheckState_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BBE RID: 31678
		// (get) Token: 0x0602D5F2 RID: 185842 RVA: 0x00ABE617 File Offset: 0x00ABC817
		// (set) Token: 0x0602D5F3 RID: 185843 RVA: 0x00ABE62B File Offset: 0x00ABC82B
		public unsafe string 检查状态
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_ConditionCheckState_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_ConditionCheckState_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x0602D5F4 RID: 185844 RVA: 0x00ABE640 File Offset: 0x00ABC840
		protected BP_SM_ConditionCheckState_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401971C RID: 104220
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionCheckState.BP_SM_ConditionCheckState_C";

		// Token: 0x0401971D RID: 104221
		private static IntPtr _ClassPtr;

		// Token: 0x0401971E RID: 104222
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401971F RID: 104223
		internal static int __PropertyOffset_0;
	}
}
