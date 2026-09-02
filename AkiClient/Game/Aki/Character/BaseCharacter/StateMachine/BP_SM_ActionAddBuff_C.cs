using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042A1 RID: 17057
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionAddBuff.BP_SM_ActionAddBuff_C")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 56)]
	public class BP_SM_ActionAddBuff_C : UASMAction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D4BD RID: 185533 RVA: 0x00ABC402 File Offset: 0x00ABA602
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ActionAddBuff_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionAddBuff.BP_SM_ActionAddBuff_C");
			}
			return BP_SM_ActionAddBuff_C._ClassPtr;
		}

		// Token: 0x0602D4BE RID: 185534 RVA: 0x00ABC428 File Offset: 0x00ABA628
		public BP_SM_ActionAddBuff_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionAddBuff_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D4BF RID: 185535 RVA: 0x00ABC450 File Offset: 0x00ABA650
		[NullableContext(1)]
		public BP_SM_ActionAddBuff_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionAddBuff_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B7B RID: 31611
		// (get) Token: 0x0602D4C0 RID: 185536 RVA: 0x00ABC483 File Offset: 0x00ABA683
		// (set) Token: 0x0602D4C1 RID: 185537 RVA: 0x00ABC493 File Offset: 0x00ABA693
		public unsafe long BuffId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ActionAddBuff_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ActionAddBuff_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x0602D4C2 RID: 185538 RVA: 0x00ABC4A4 File Offset: 0x00ABA6A4
		protected BP_SM_ActionAddBuff_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019652 RID: 104018
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionAddBuff.BP_SM_ActionAddBuff_C";

		// Token: 0x04019653 RID: 104019
		private static IntPtr _ClassPtr;

		// Token: 0x04019654 RID: 104020
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019655 RID: 104021
		internal static int __PropertyOffset_0;
	}
}
