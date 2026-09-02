using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042A4 RID: 17060
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionChangeInstState.BP_SM_ActionChangeInstState_C")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 60)]
	public class BP_SM_ActionChangeInstState_C : UASMAction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D4D1 RID: 185553 RVA: 0x00ABC62D File Offset: 0x00ABA82D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ActionChangeInstState_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionChangeInstState.BP_SM_ActionChangeInstState_C");
			}
			return BP_SM_ActionChangeInstState_C._ClassPtr;
		}

		// Token: 0x0602D4D2 RID: 185554 RVA: 0x00ABC654 File Offset: 0x00ABA854
		public BP_SM_ActionChangeInstState_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionChangeInstState_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D4D3 RID: 185555 RVA: 0x00ABC67C File Offset: 0x00ABA87C
		[NullableContext(1)]
		public BP_SM_ActionChangeInstState_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionChangeInstState_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B7F RID: 31615
		// (get) Token: 0x0602D4D4 RID: 185556 RVA: 0x00ABC6AF File Offset: 0x00ABA8AF
		// (set) Token: 0x0602D4D5 RID: 185557 RVA: 0x00ABC6C3 File Offset: 0x00ABA8C3
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ActionChangeInstState_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ActionChangeInstState_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x0602D4D6 RID: 185558 RVA: 0x00ABC6D8 File Offset: 0x00ABA8D8
		protected BP_SM_ActionChangeInstState_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401965F RID: 104031
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionChangeInstState.BP_SM_ActionChangeInstState_C";

		// Token: 0x04019660 RID: 104032
		private static IntPtr _ClassPtr;

		// Token: 0x04019661 RID: 104033
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019662 RID: 104034
		internal static int __PropertyOffset_0;
	}
}
