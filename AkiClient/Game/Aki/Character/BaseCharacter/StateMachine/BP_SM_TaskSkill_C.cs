using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042E2 RID: 17122
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskSkill.BP_SM_TaskSkill_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 68)]
	public class BP_SM_TaskSkill_C : UASMTask, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D6B4 RID: 186036 RVA: 0x00ABF99B File Offset: 0x00ABDB9B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_TaskSkill_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskSkill.BP_SM_TaskSkill_C");
			}
			return BP_SM_TaskSkill_C._ClassPtr;
		}

		// Token: 0x0602D6B5 RID: 186037 RVA: 0x00ABF9C0 File Offset: 0x00ABDBC0
		public BP_SM_TaskSkill_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskSkill_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D6B6 RID: 186038 RVA: 0x00ABF9E8 File Offset: 0x00ABDBE8
		[NullableContext(1)]
		public BP_SM_TaskSkill_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskSkill_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BF3 RID: 31731
		// (get) Token: 0x0602D6B7 RID: 186039 RVA: 0x00ABFA1B File Offset: 0x00ABDC1B
		// (set) Token: 0x0602D6B8 RID: 186040 RVA: 0x00ABFA2B File Offset: 0x00ABDC2B
		public unsafe int SkillId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskSkill_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskSkill_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007BF4 RID: 31732
		// (get) Token: 0x0602D6B9 RID: 186041 RVA: 0x00ABFA3C File Offset: 0x00ABDC3C
		// (set) Token: 0x0602D6BA RID: 186042 RVA: 0x00ABFA4C File Offset: 0x00ABDC4C
		public unsafe bool 允许打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskSkill_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskSkill_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BF5 RID: 31733
		// (get) Token: 0x0602D6BB RID: 186043 RVA: 0x00ABFA5D File Offset: 0x00ABDC5D
		// (set) Token: 0x0602D6BC RID: 186044 RVA: 0x00ABFA71 File Offset: 0x00ABDC71
		public unsafe FGameplayTag ConfigReplaceTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskSkill_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskSkill_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602D6BD RID: 186045 RVA: 0x00ABFA86 File Offset: 0x00ABDC86
		protected BP_SM_TaskSkill_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019799 RID: 104345
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskSkill.BP_SM_TaskSkill_C";

		// Token: 0x0401979A RID: 104346
		private static IntPtr _ClassPtr;

		// Token: 0x0401979B RID: 104347
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401979C RID: 104348
		internal static int __PropertyOffset_0;

		// Token: 0x0401979D RID: 104349
		internal static int __PropertyOffset_1;

		// Token: 0x0401979E RID: 104350
		internal static int __PropertyOffset_2;
	}
}
