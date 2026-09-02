using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042B0 RID: 17072
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionStopMontage.BP_SM_ActionStopMontage_C")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 52)]
	public class BP_SM_ActionStopMontage_C : UASMAction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D517 RID: 185623 RVA: 0x00ABCE64 File Offset: 0x00ABB064
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ActionStopMontage_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionStopMontage.BP_SM_ActionStopMontage_C");
			}
			return BP_SM_ActionStopMontage_C._ClassPtr;
		}

		// Token: 0x0602D518 RID: 185624 RVA: 0x00ABCE88 File Offset: 0x00ABB088
		public BP_SM_ActionStopMontage_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionStopMontage_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D519 RID: 185625 RVA: 0x00ABCEB0 File Offset: 0x00ABB0B0
		[NullableContext(1)]
		public BP_SM_ActionStopMontage_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionStopMontage_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B8A RID: 31626
		// (get) Token: 0x0602D51A RID: 185626 RVA: 0x00ABCEE3 File Offset: 0x00ABB0E3
		// (set) Token: 0x0602D51B RID: 185627 RVA: 0x00ABCEF3 File Offset: 0x00ABB0F3
		public unsafe int 淡出时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ActionStopMontage_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ActionStopMontage_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x0602D51C RID: 185628 RVA: 0x00ABCF04 File Offset: 0x00ABB104
		protected BP_SM_ActionStopMontage_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401968F RID: 104079
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionStopMontage.BP_SM_ActionStopMontage_C";

		// Token: 0x04019690 RID: 104080
		private static IntPtr _ClassPtr;

		// Token: 0x04019691 RID: 104081
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019692 RID: 104082
		internal static int __PropertyOffset_0;
	}
}
