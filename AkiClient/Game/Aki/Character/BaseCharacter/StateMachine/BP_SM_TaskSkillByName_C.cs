using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042E1 RID: 17121
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskSkillByName.BP_SM_TaskSkillByName_C")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 80)]
	public class BP_SM_TaskSkillByName_C : UASMTask, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D6AA RID: 186026 RVA: 0x00ABF8A0 File Offset: 0x00ABDAA0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_TaskSkillByName_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskSkillByName.BP_SM_TaskSkillByName_C");
			}
			return BP_SM_TaskSkillByName_C._ClassPtr;
		}

		// Token: 0x0602D6AB RID: 186027 RVA: 0x00ABF8C4 File Offset: 0x00ABDAC4
		public BP_SM_TaskSkillByName_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskSkillByName_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D6AC RID: 186028 RVA: 0x00ABF8EC File Offset: 0x00ABDAEC
		public BP_SM_TaskSkillByName_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskSkillByName_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BF0 RID: 31728
		// (get) Token: 0x0602D6AD RID: 186029 RVA: 0x00ABF91F File Offset: 0x00ABDB1F
		// (set) Token: 0x0602D6AE RID: 186030 RVA: 0x00ABF933 File Offset: 0x00ABDB33
		public unsafe string SkillName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_TaskSkillByName_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_TaskSkillByName_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007BF1 RID: 31729
		// (get) Token: 0x0602D6AF RID: 186031 RVA: 0x00ABF948 File Offset: 0x00ABDB48
		// (set) Token: 0x0602D6B0 RID: 186032 RVA: 0x00ABF958 File Offset: 0x00ABDB58
		public unsafe bool 允许打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskSkillByName_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskSkillByName_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BF2 RID: 31730
		// (get) Token: 0x0602D6B1 RID: 186033 RVA: 0x00ABF969 File Offset: 0x00ABDB69
		// (set) Token: 0x0602D6B2 RID: 186034 RVA: 0x00ABF97D File Offset: 0x00ABDB7D
		public unsafe FGameplayTag ConfigReplaceTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskSkillByName_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskSkillByName_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602D6B3 RID: 186035 RVA: 0x00ABF992 File Offset: 0x00ABDB92
		protected BP_SM_TaskSkillByName_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019793 RID: 104339
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskSkillByName.BP_SM_TaskSkillByName_C";

		// Token: 0x04019794 RID: 104340
		private static IntPtr _ClassPtr;

		// Token: 0x04019795 RID: 104341
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019796 RID: 104342
		internal static int __PropertyOffset_0;

		// Token: 0x04019797 RID: 104343
		internal static int __PropertyOffset_1;

		// Token: 0x04019798 RID: 104344
		internal static int __PropertyOffset_2;
	}
}
