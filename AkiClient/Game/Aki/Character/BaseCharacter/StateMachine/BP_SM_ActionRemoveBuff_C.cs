using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042AA RID: 17066
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionRemoveBuff.BP_SM_ActionRemoveBuff_C")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 56)]
	public class BP_SM_ActionRemoveBuff_C : UASMAction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D4F1 RID: 185585 RVA: 0x00ABCA2C File Offset: 0x00ABAC2C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ActionRemoveBuff_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionRemoveBuff.BP_SM_ActionRemoveBuff_C");
			}
			return BP_SM_ActionRemoveBuff_C._ClassPtr;
		}

		// Token: 0x0602D4F2 RID: 185586 RVA: 0x00ABCA50 File Offset: 0x00ABAC50
		public BP_SM_ActionRemoveBuff_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionRemoveBuff_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D4F3 RID: 185587 RVA: 0x00ABCA78 File Offset: 0x00ABAC78
		[NullableContext(1)]
		public BP_SM_ActionRemoveBuff_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionRemoveBuff_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B83 RID: 31619
		// (get) Token: 0x0602D4F4 RID: 185588 RVA: 0x00ABCAAB File Offset: 0x00ABACAB
		// (set) Token: 0x0602D4F5 RID: 185589 RVA: 0x00ABCABB File Offset: 0x00ABACBB
		public unsafe long BuffId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ActionRemoveBuff_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ActionRemoveBuff_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x0602D4F6 RID: 185590 RVA: 0x00ABCACC File Offset: 0x00ABACCC
		protected BP_SM_ActionRemoveBuff_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019676 RID: 104054
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionRemoveBuff.BP_SM_ActionRemoveBuff_C";

		// Token: 0x04019677 RID: 104055
		private static IntPtr _ClassPtr;

		// Token: 0x04019678 RID: 104056
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019679 RID: 104057
		internal static int __PropertyOffset_0;
	}
}
