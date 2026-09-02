using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042B5 RID: 17077
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateBuff.BP_SM_BindStateBuff_C")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 56)]
	public class BP_SM_BindStateBuff_C : UASMBindState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D547 RID: 185671 RVA: 0x00ABD2F6 File Offset: 0x00ABB4F6
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_BindStateBuff_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateBuff.BP_SM_BindStateBuff_C");
			}
			return BP_SM_BindStateBuff_C._ClassPtr;
		}

		// Token: 0x0602D548 RID: 185672 RVA: 0x00ABD31C File Offset: 0x00ABB51C
		public BP_SM_BindStateBuff_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateBuff_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D549 RID: 185673 RVA: 0x00ABD344 File Offset: 0x00ABB544
		[NullableContext(1)]
		public BP_SM_BindStateBuff_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateBuff_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B98 RID: 31640
		// (get) Token: 0x0602D54A RID: 185674 RVA: 0x00ABD377 File Offset: 0x00ABB577
		// (set) Token: 0x0602D54B RID: 185675 RVA: 0x00ABD387 File Offset: 0x00ABB587
		public unsafe long BuffId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateBuff_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateBuff_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x0602D54C RID: 185676 RVA: 0x00ABD398 File Offset: 0x00ABB598
		protected BP_SM_BindStateBuff_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040196AC RID: 104108
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateBuff.BP_SM_BindStateBuff_C";

		// Token: 0x040196AD RID: 104109
		private static IntPtr _ClassPtr;

		// Token: 0x040196AE RID: 104110
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040196AF RID: 104111
		internal static int __PropertyOffset_0;
	}
}
