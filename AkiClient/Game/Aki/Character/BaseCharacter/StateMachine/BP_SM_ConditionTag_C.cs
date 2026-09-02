using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042D4 RID: 17108
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionTag.BP_SM_ConditionTag_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 69)]
	public class BP_SM_ConditionTag_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D62F RID: 185903 RVA: 0x00ABEC0C File Offset: 0x00ABCE0C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionTag_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionTag.BP_SM_ConditionTag_C");
			}
			return BP_SM_ConditionTag_C._ClassPtr;
		}

		// Token: 0x0602D630 RID: 185904 RVA: 0x00ABEC30 File Offset: 0x00ABCE30
		public BP_SM_ConditionTag_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionTag_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D631 RID: 185905 RVA: 0x00ABEC58 File Offset: 0x00ABCE58
		[NullableContext(1)]
		public BP_SM_ConditionTag_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionTag_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BCE RID: 31694
		// (get) Token: 0x0602D632 RID: 185906 RVA: 0x00ABEC8B File Offset: 0x00ABCE8B
		// (set) Token: 0x0602D633 RID: 185907 RVA: 0x00ABEC9F File Offset: 0x00ABCE9F
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionTag_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionTag_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007BCF RID: 31695
		// (get) Token: 0x0602D634 RID: 185908 RVA: 0x00ABECB4 File Offset: 0x00ABCEB4
		// (set) Token: 0x0602D635 RID: 185909 RVA: 0x00ABECC4 File Offset: 0x00ABCEC4
		public unsafe bool IsClient
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionTag_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionTag_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D636 RID: 185910 RVA: 0x00ABECD5 File Offset: 0x00ABCED5
		protected BP_SM_ConditionTag_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019744 RID: 104260
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionTag.BP_SM_ConditionTag_C";

		// Token: 0x04019745 RID: 104261
		private static IntPtr _ClassPtr;

		// Token: 0x04019746 RID: 104262
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019747 RID: 104263
		internal static int __PropertyOffset_0;

		// Token: 0x04019748 RID: 104264
		internal static int __PropertyOffset_1;
	}
}
