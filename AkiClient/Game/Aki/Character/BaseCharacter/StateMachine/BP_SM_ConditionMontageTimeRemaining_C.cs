using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042D2 RID: 17106
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionMontageTimeRemaining.BP_SM_ConditionMontageTimeRemaining_C")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 60)]
	public class BP_SM_ConditionMontageTimeRemaining_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D61D RID: 185885 RVA: 0x00ABEA49 File Offset: 0x00ABCC49
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionMontageTimeRemaining_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionMontageTimeRemaining.BP_SM_ConditionMontageTimeRemaining_C");
			}
			return BP_SM_ConditionMontageTimeRemaining_C._ClassPtr;
		}

		// Token: 0x0602D61E RID: 185886 RVA: 0x00ABEA70 File Offset: 0x00ABCC70
		public BP_SM_ConditionMontageTimeRemaining_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionMontageTimeRemaining_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D61F RID: 185887 RVA: 0x00ABEA98 File Offset: 0x00ABCC98
		[NullableContext(1)]
		public BP_SM_ConditionMontageTimeRemaining_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionMontageTimeRemaining_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BC9 RID: 31689
		// (get) Token: 0x0602D620 RID: 185888 RVA: 0x00ABEACB File Offset: 0x00ABCCCB
		// (set) Token: 0x0602D621 RID: 185889 RVA: 0x00ABEADB File Offset: 0x00ABCCDB
		public unsafe int Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionMontageTimeRemaining_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionMontageTimeRemaining_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x0602D622 RID: 185890 RVA: 0x00ABEAEC File Offset: 0x00ABCCEC
		protected BP_SM_ConditionMontageTimeRemaining_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019739 RID: 104249
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionMontageTimeRemaining.BP_SM_ConditionMontageTimeRemaining_C";

		// Token: 0x0401973A RID: 104250
		private static IntPtr _ClassPtr;

		// Token: 0x0401973B RID: 104251
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401973C RID: 104252
		internal static int __PropertyOffset_0;
	}
}
