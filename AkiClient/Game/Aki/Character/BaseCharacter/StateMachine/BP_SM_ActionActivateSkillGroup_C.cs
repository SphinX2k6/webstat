using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042A0 RID: 17056
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionActivateSkillGroup.BP_SM_ActionActivateSkillGroup_C")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 53)]
	public class BP_SM_ActionActivateSkillGroup_C : UASMAction, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D4B5 RID: 185525 RVA: 0x00ABC336 File Offset: 0x00ABA536
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_ActionActivateSkillGroup_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionActivateSkillGroup.BP_SM_ActionActivateSkillGroup_C");
			}
			return BP_SM_ActionActivateSkillGroup_C._ClassPtr;
		}

		// Token: 0x0602D4B6 RID: 185526 RVA: 0x00ABC35C File Offset: 0x00ABA55C
		public BP_SM_ActionActivateSkillGroup_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionActivateSkillGroup_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D4B7 RID: 185527 RVA: 0x00ABC384 File Offset: 0x00ABA584
		[NullableContext(1)]
		public BP_SM_ActionActivateSkillGroup_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_ActionActivateSkillGroup_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B79 RID: 31609
		// (get) Token: 0x0602D4B8 RID: 185528 RVA: 0x00ABC3B7 File Offset: 0x00ABA5B7
		// (set) Token: 0x0602D4B9 RID: 185529 RVA: 0x00ABC3C7 File Offset: 0x00ABA5C7
		public unsafe int ConfigId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ActionActivateSkillGroup_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ActionActivateSkillGroup_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007B7A RID: 31610
		// (get) Token: 0x0602D4BA RID: 185530 RVA: 0x00ABC3D8 File Offset: 0x00ABA5D8
		// (set) Token: 0x0602D4BB RID: 185531 RVA: 0x00ABC3E8 File Offset: 0x00ABA5E8
		public unsafe bool 激活
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_ActionActivateSkillGroup_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_ActionActivateSkillGroup_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D4BC RID: 185532 RVA: 0x00ABC3F9 File Offset: 0x00ABA5F9
		protected BP_SM_ActionActivateSkillGroup_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401964D RID: 104013
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_ActionActivateSkillGroup.BP_SM_ActionActivateSkillGroup_C";

		// Token: 0x0401964E RID: 104014
		private static IntPtr _ClassPtr;

		// Token: 0x0401964F RID: 104015
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019650 RID: 104016
		internal static int __PropertyOffset_0;

		// Token: 0x04019651 RID: 104017
		internal static int __PropertyOffset_1;
	}
}
