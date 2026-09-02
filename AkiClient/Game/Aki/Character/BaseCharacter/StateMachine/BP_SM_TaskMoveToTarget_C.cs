using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042DE RID: 17118
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskMoveToTarget.BP_SM_TaskMoveToTarget_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 66)]
	public class BP_SM_TaskMoveToTarget_C : UASMTask, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D682 RID: 185986 RVA: 0x00ABF50E File Offset: 0x00ABD70E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_TaskMoveToTarget_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskMoveToTarget.BP_SM_TaskMoveToTarget_C");
			}
			return BP_SM_TaskMoveToTarget_C._ClassPtr;
		}

		// Token: 0x0602D683 RID: 185987 RVA: 0x00ABF534 File Offset: 0x00ABD734
		public BP_SM_TaskMoveToTarget_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskMoveToTarget_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D684 RID: 185988 RVA: 0x00ABF55C File Offset: 0x00ABD75C
		[NullableContext(1)]
		public BP_SM_TaskMoveToTarget_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskMoveToTarget_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BE2 RID: 31714
		// (get) Token: 0x0602D685 RID: 185989 RVA: 0x00ABF58F File Offset: 0x00ABD78F
		// (set) Token: 0x0602D686 RID: 185990 RVA: 0x00ABF59F File Offset: 0x00ABD79F
		public unsafe int 目标类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskMoveToTarget_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskMoveToTarget_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007BE3 RID: 31715
		// (get) Token: 0x0602D687 RID: 185991 RVA: 0x00ABF5B0 File Offset: 0x00ABD7B0
		// (set) Token: 0x0602D688 RID: 185992 RVA: 0x00ABF5C0 File Offset: 0x00ABD7C0
		public unsafe int 移动方式
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskMoveToTarget_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskMoveToTarget_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007BE4 RID: 31716
		// (get) Token: 0x0602D689 RID: 185993 RVA: 0x00ABF5D1 File Offset: 0x00ABD7D1
		// (set) Token: 0x0602D68A RID: 185994 RVA: 0x00ABF5E1 File Offset: 0x00ABD7E1
		public unsafe int 停止距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskMoveToTarget_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskMoveToTarget_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007BE5 RID: 31717
		// (get) Token: 0x0602D68B RID: 185995 RVA: 0x00ABF5F2 File Offset: 0x00ABD7F2
		// (set) Token: 0x0602D68C RID: 185996 RVA: 0x00ABF602 File Offset: 0x00ABD802
		public unsafe int 转向速度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskMoveToTarget_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskMoveToTarget_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007BE6 RID: 31718
		// (get) Token: 0x0602D68D RID: 185997 RVA: 0x00ABF613 File Offset: 0x00ABD813
		// (set) Token: 0x0602D68E RID: 185998 RVA: 0x00ABF623 File Offset: 0x00ABD823
		public unsafe bool 结束时切换走路
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskMoveToTarget_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskMoveToTarget_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BE7 RID: 31719
		// (get) Token: 0x0602D68F RID: 185999 RVA: 0x00ABF634 File Offset: 0x00ABD834
		// (set) Token: 0x0602D690 RID: 186000 RVA: 0x00ABF644 File Offset: 0x00ABD844
		public unsafe bool 允许打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskMoveToTarget_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskMoveToTarget_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D691 RID: 186001 RVA: 0x00ABF655 File Offset: 0x00ABD855
		protected BP_SM_TaskMoveToTarget_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401977B RID: 104315
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskMoveToTarget.BP_SM_TaskMoveToTarget_C";

		// Token: 0x0401977C RID: 104316
		private static IntPtr _ClassPtr;

		// Token: 0x0401977D RID: 104317
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401977E RID: 104318
		internal static int __PropertyOffset_0;

		// Token: 0x0401977F RID: 104319
		internal static int __PropertyOffset_1;

		// Token: 0x04019780 RID: 104320
		internal static int __PropertyOffset_2;

		// Token: 0x04019781 RID: 104321
		internal static int __PropertyOffset_3;

		// Token: 0x04019782 RID: 104322
		internal static int __PropertyOffset_4;

		// Token: 0x04019783 RID: 104323
		internal static int __PropertyOffset_5;
	}
}
