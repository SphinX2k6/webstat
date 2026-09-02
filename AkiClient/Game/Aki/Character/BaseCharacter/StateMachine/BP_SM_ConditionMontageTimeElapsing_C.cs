using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042D1 RID: 17105
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionMontageTimeElapsing.BP_SM_ConditionMontageTimeElapsing_C")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 60)]
	public class BP_SM_ConditionMontageTimeElapsing_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D617 RID: 185879 RVA: 0x00ABE99D File Offset: 0x00ABCB9D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionMontageTimeElapsing_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionMontageTimeElapsing.BP_SM_ConditionMontageTimeElapsing_C");
			}
			return BP_SM_ConditionMontageTimeElapsing_C._ClassPtr;
		}

		// Token: 0x0602D618 RID: 185880 RVA: 0x00ABE9C4 File Offset: 0x00ABCBC4
		public BP_SM_ConditionMontageTimeElapsing_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionMontageTimeElapsing_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D619 RID: 185881 RVA: 0x00ABE9EC File Offset: 0x00ABCBEC
		[NullableContext(1)]
		public BP_SM_ConditionMontageTimeElapsing_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionMontageTimeElapsing_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BC8 RID: 31688
		// (get) Token: 0x0602D61A RID: 185882 RVA: 0x00ABEA1F File Offset: 0x00ABCC1F
		// (set) Token: 0x0602D61B RID: 185883 RVA: 0x00ABEA2F File Offset: 0x00ABCC2F
		public unsafe int Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionMontageTimeElapsing_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionMontageTimeElapsing_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x0602D61C RID: 185884 RVA: 0x00ABEA40 File Offset: 0x00ABCC40
		protected BP_SM_ConditionMontageTimeElapsing_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019735 RID: 104245
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionMontageTimeElapsing.BP_SM_ConditionMontageTimeElapsing_C";

		// Token: 0x04019736 RID: 104246
		private static IntPtr _ClassPtr;

		// Token: 0x04019737 RID: 104247
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019738 RID: 104248
		internal static int __PropertyOffset_0;
	}
}
