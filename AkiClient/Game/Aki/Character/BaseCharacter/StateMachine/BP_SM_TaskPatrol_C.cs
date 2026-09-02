using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042DF RID: 17119
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskPatrol.BP_SM_TaskPatrol_C")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 54)]
	public class BP_SM_TaskPatrol_C : UASMTask, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D692 RID: 186002 RVA: 0x00ABF65E File Offset: 0x00ABD85E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_TaskPatrol_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskPatrol.BP_SM_TaskPatrol_C");
			}
			return BP_SM_TaskPatrol_C._ClassPtr;
		}

		// Token: 0x0602D693 RID: 186003 RVA: 0x00ABF684 File Offset: 0x00ABD884
		public BP_SM_TaskPatrol_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskPatrol_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D694 RID: 186004 RVA: 0x00ABF6AC File Offset: 0x00ABD8AC
		[NullableContext(1)]
		public BP_SM_TaskPatrol_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskPatrol_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BE8 RID: 31720
		// (get) Token: 0x0602D695 RID: 186005 RVA: 0x00ABF6DF File Offset: 0x00ABD8DF
		// (set) Token: 0x0602D696 RID: 186006 RVA: 0x00ABF6EF File Offset: 0x00ABD8EF
		public unsafe int 移动方式
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskPatrol_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskPatrol_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007BE9 RID: 31721
		// (get) Token: 0x0602D697 RID: 186007 RVA: 0x00ABF700 File Offset: 0x00ABD900
		// (set) Token: 0x0602D698 RID: 186008 RVA: 0x00ABF710 File Offset: 0x00ABD910
		public unsafe bool 调试模式
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskPatrol_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskPatrol_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BEA RID: 31722
		// (get) Token: 0x0602D699 RID: 186009 RVA: 0x00ABF721 File Offset: 0x00ABD921
		// (set) Token: 0x0602D69A RID: 186010 RVA: 0x00ABF731 File Offset: 0x00ABD931
		public unsafe bool 允许打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskPatrol_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskPatrol_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D69B RID: 186011 RVA: 0x00ABF742 File Offset: 0x00ABD942
		protected BP_SM_TaskPatrol_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019784 RID: 104324
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskPatrol.BP_SM_TaskPatrol_C";

		// Token: 0x04019785 RID: 104325
		private static IntPtr _ClassPtr;

		// Token: 0x04019786 RID: 104326
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019787 RID: 104327
		internal static int __PropertyOffset_0;

		// Token: 0x04019788 RID: 104328
		internal static int __PropertyOffset_1;

		// Token: 0x04019789 RID: 104329
		internal static int __PropertyOffset_2;
	}
}
