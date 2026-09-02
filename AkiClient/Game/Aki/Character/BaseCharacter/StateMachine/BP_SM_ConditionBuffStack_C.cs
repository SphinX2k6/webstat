using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042C4 RID: 17092
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionBuffStack.BP_SM_ConditionBuffStack_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 72)]
	public class BP_SM_ConditionBuffStack_C : UASMConditionBase, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D5C1 RID: 185793 RVA: 0x00ABE043 File Offset: 0x00ABC243
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ConditionBuffStack_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionBuffStack.BP_SM_ConditionBuffStack_C");
			}
			return BP_SM_ConditionBuffStack_C._ClassPtr;
		}

		// Token: 0x0602D5C2 RID: 185794 RVA: 0x00ABE068 File Offset: 0x00ABC268
		public BP_SM_ConditionBuffStack_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionBuffStack_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D5C3 RID: 185795 RVA: 0x00ABE090 File Offset: 0x00ABC290
		[NullableContext(1)]
		public BP_SM_ConditionBuffStack_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ConditionBuffStack_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BB7 RID: 31671
		// (get) Token: 0x0602D5C4 RID: 185796 RVA: 0x00ABE0C3 File Offset: 0x00ABC2C3
		// (set) Token: 0x0602D5C5 RID: 185797 RVA: 0x00ABE0D3 File Offset: 0x00ABC2D3
		public unsafe long BuffId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionBuffStack_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionBuffStack_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007BB8 RID: 31672
		// (get) Token: 0x0602D5C6 RID: 185798 RVA: 0x00ABE0E4 File Offset: 0x00ABC2E4
		// (set) Token: 0x0602D5C7 RID: 185799 RVA: 0x00ABE0F4 File Offset: 0x00ABC2F4
		public unsafe int Min
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionBuffStack_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionBuffStack_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007BB9 RID: 31673
		// (get) Token: 0x0602D5C8 RID: 185800 RVA: 0x00ABE105 File Offset: 0x00ABC305
		// (set) Token: 0x0602D5C9 RID: 185801 RVA: 0x00ABE115 File Offset: 0x00ABC315
		public unsafe int Max
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ConditionBuffStack_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ConditionBuffStack_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602D5CA RID: 185802 RVA: 0x00ABE126 File Offset: 0x00ABC326
		protected BP_SM_ConditionBuffStack_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040196FD RID: 104189
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ConditionBuffStack.BP_SM_ConditionBuffStack_C";

		// Token: 0x040196FE RID: 104190
		private static IntPtr _ClassPtr;

		// Token: 0x040196FF RID: 104191
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019700 RID: 104192
		internal static int __PropertyOffset_0;

		// Token: 0x04019701 RID: 104193
		internal static int __PropertyOffset_1;

		// Token: 0x04019702 RID: 104194
		internal static int __PropertyOffset_2;
	}
}
