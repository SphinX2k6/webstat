using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.AI.AIFunctionCommon.KFCS_WandersData
{
	// Token: 0x02004390 RID: 17296
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/KFCS_WanderDirectionProbability.KFCS_WanderDirectionProbability")]
	[UnrealStructLayout(72, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 72)]
	public class KFCS_WanderDirectionProbability : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602DD85 RID: 187781 RVA: 0x00ACE196 File Offset: 0x00ACC396
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (KFCS_WanderDirectionProbability._ScriptStructPtr != 0) ? KFCS_WanderDirectionProbability._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/KFCS_WanderDirectionProbability.KFCS_WanderDirectionProbability", ref KFCS_WanderDirectionProbability._ScriptStructPtr);
		}

		// Token: 0x17007DB1 RID: 32177
		// (get) Token: 0x0602DD86 RID: 187782 RVA: 0x00ACE1BA File Offset: 0x00ACC3BA
		// (set) Token: 0x0602DD87 RID: 187783 RVA: 0x00ACE1CA File Offset: 0x00ACC3CA
		public unsafe float 近距离前走概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007DB2 RID: 32178
		// (get) Token: 0x0602DD88 RID: 187784 RVA: 0x00ACE1DB File Offset: 0x00ACC3DB
		// (set) Token: 0x0602DD89 RID: 187785 RVA: 0x00ACE1EB File Offset: 0x00ACC3EB
		public unsafe float 近距离后走概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007DB3 RID: 32179
		// (get) Token: 0x0602DD8A RID: 187786 RVA: 0x00ACE1FC File Offset: 0x00ACC3FC
		// (set) Token: 0x0602DD8B RID: 187787 RVA: 0x00ACE20C File Offset: 0x00ACC40C
		public unsafe float 近距离左走概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007DB4 RID: 32180
		// (get) Token: 0x0602DD8C RID: 187788 RVA: 0x00ACE21D File Offset: 0x00ACC41D
		// (set) Token: 0x0602DD8D RID: 187789 RVA: 0x00ACE22D File Offset: 0x00ACC42D
		public unsafe float 近距离右走概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007DB5 RID: 32181
		// (get) Token: 0x0602DD8E RID: 187790 RVA: 0x00ACE23E File Offset: 0x00ACC43E
		// (set) Token: 0x0602DD8F RID: 187791 RVA: 0x00ACE24E File Offset: 0x00ACC44E
		public unsafe float 近距离发呆概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007DB6 RID: 32182
		// (get) Token: 0x0602DD90 RID: 187792 RVA: 0x00ACE25F File Offset: 0x00ACC45F
		// (set) Token: 0x0602DD91 RID: 187793 RVA: 0x00ACE26F File Offset: 0x00ACC46F
		public unsafe float 中距离前走概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007DB7 RID: 32183
		// (get) Token: 0x0602DD92 RID: 187794 RVA: 0x00ACE280 File Offset: 0x00ACC480
		// (set) Token: 0x0602DD93 RID: 187795 RVA: 0x00ACE290 File Offset: 0x00ACC490
		public unsafe float 中距离后走概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007DB8 RID: 32184
		// (get) Token: 0x0602DD94 RID: 187796 RVA: 0x00ACE2A1 File Offset: 0x00ACC4A1
		// (set) Token: 0x0602DD95 RID: 187797 RVA: 0x00ACE2B1 File Offset: 0x00ACC4B1
		public unsafe float 中距离左走概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007DB9 RID: 32185
		// (get) Token: 0x0602DD96 RID: 187798 RVA: 0x00ACE2C2 File Offset: 0x00ACC4C2
		// (set) Token: 0x0602DD97 RID: 187799 RVA: 0x00ACE2D2 File Offset: 0x00ACC4D2
		public unsafe float 中距离右走概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007DBA RID: 32186
		// (get) Token: 0x0602DD98 RID: 187800 RVA: 0x00ACE2E3 File Offset: 0x00ACC4E3
		// (set) Token: 0x0602DD99 RID: 187801 RVA: 0x00ACE2F3 File Offset: 0x00ACC4F3
		public unsafe float 中距离发呆概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007DBB RID: 32187
		// (get) Token: 0x0602DD9A RID: 187802 RVA: 0x00ACE304 File Offset: 0x00ACC504
		// (set) Token: 0x0602DD9B RID: 187803 RVA: 0x00ACE314 File Offset: 0x00ACC514
		public unsafe float 远距离前走概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17007DBC RID: 32188
		// (get) Token: 0x0602DD9C RID: 187804 RVA: 0x00ACE325 File Offset: 0x00ACC525
		// (set) Token: 0x0602DD9D RID: 187805 RVA: 0x00ACE335 File Offset: 0x00ACC535
		public unsafe float 远距离后走概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007DBD RID: 32189
		// (get) Token: 0x0602DD9E RID: 187806 RVA: 0x00ACE346 File Offset: 0x00ACC546
		// (set) Token: 0x0602DD9F RID: 187807 RVA: 0x00ACE356 File Offset: 0x00ACC556
		public unsafe float 远距离左走概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007DBE RID: 32190
		// (get) Token: 0x0602DDA0 RID: 187808 RVA: 0x00ACE367 File Offset: 0x00ACC567
		// (set) Token: 0x0602DDA1 RID: 187809 RVA: 0x00ACE377 File Offset: 0x00ACC577
		public unsafe float 远距离右走概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17007DBF RID: 32191
		// (get) Token: 0x0602DDA2 RID: 187810 RVA: 0x00ACE388 File Offset: 0x00ACC588
		// (set) Token: 0x0602DDA3 RID: 187811 RVA: 0x00ACE398 File Offset: 0x00ACC598
		public unsafe float 远距离发呆概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17007DC0 RID: 32192
		// (get) Token: 0x0602DDA4 RID: 187812 RVA: 0x00ACE3A9 File Offset: 0x00ACC5A9
		// (set) Token: 0x0602DDA5 RID: 187813 RVA: 0x00ACE3B9 File Offset: 0x00ACC5B9
		public unsafe float 近距离乱序移动的概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17007DC1 RID: 32193
		// (get) Token: 0x0602DDA6 RID: 187814 RVA: 0x00ACE3CA File Offset: 0x00ACC5CA
		// (set) Token: 0x0602DDA7 RID: 187815 RVA: 0x00ACE3DA File Offset: 0x00ACC5DA
		public unsafe float 中距离乱序移动的概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17007DC2 RID: 32194
		// (get) Token: 0x0602DDA8 RID: 187816 RVA: 0x00ACE3EB File Offset: 0x00ACC5EB
		// (set) Token: 0x0602DDA9 RID: 187817 RVA: 0x00ACE3FB File Offset: 0x00ACC5FB
		public unsafe float 远距离乱序移动的概率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)KFCS_WanderDirectionProbability.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x0602DDAA RID: 187818 RVA: 0x00ACE40C File Offset: 0x00ACC60C
		public KFCS_WanderDirectionProbability()
		{
		}

		// Token: 0x0602DDAB RID: 187819 RVA: 0x00ACE414 File Offset: 0x00ACC614
		public KFCS_WanderDirectionProbability(float 近距离前走概率, float 近距离后走概率, float 近距离左走概率, float 近距离右走概率, float 近距离发呆概率, float 中距离前走概率, float 中距离后走概率, float 中距离左走概率, float 中距离右走概率, float 中距离发呆概率, float 远距离前走概率, float 远距离后走概率, float 远距离左走概率, float 远距离右走概率, float 远距离发呆概率, float 近距离乱序移动的概率, float 中距离乱序移动的概率, float 远距离乱序移动的概率)
		{
			this.近距离前走概率 = 近距离前走概率;
			this.近距离后走概率 = 近距离后走概率;
			this.近距离左走概率 = 近距离左走概率;
			this.近距离右走概率 = 近距离右走概率;
			this.近距离发呆概率 = 近距离发呆概率;
			this.中距离前走概率 = 中距离前走概率;
			this.中距离后走概率 = 中距离后走概率;
			this.中距离左走概率 = 中距离左走概率;
			this.中距离右走概率 = 中距离右走概率;
			this.中距离发呆概率 = 中距离发呆概率;
			this.远距离前走概率 = 远距离前走概率;
			this.远距离后走概率 = 远距离后走概率;
			this.远距离左走概率 = 远距离左走概率;
			this.远距离右走概率 = 远距离右走概率;
			this.远距离发呆概率 = 远距离发呆概率;
			this.近距离乱序移动的概率 = 近距离乱序移动的概率;
			this.中距离乱序移动的概率 = 中距离乱序移动的概率;
			this.远距离乱序移动的概率 = 远距离乱序移动的概率;
		}

		// Token: 0x0602DDAC RID: 187820 RVA: 0x00ACE4B4 File Offset: 0x00ACC6B4
		protected override IntPtr GetUStructPtr()
		{
			return KFCS_WanderDirectionProbability.StaticStruct();
		}

		// Token: 0x0602DDAD RID: 187821 RVA: 0x00ACE4C0 File Offset: 0x00ACC6C0
		[NullableContext(2)]
		public KFCS_WanderDirectionProbability(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602DDAE RID: 187822 RVA: 0x00ACE4CA File Offset: 0x00ACC6CA
		public KFCS_WanderDirectionProbability(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602DDAF RID: 187823 RVA: 0x00ACE4D5 File Offset: 0x00ACC6D5
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new KFCS_WanderDirectionProbability(Pointer, false, true);
		}

		// Token: 0x0602DDB0 RID: 187824 RVA: 0x00ACE4DF File Offset: 0x00ACC6DF
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new KFCS_WanderDirectionProbability(Pointer, MemoryOwner);
		}

		// Token: 0x04019E76 RID: 106102
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/KFCS_WanderDirectionProbability.KFCS_WanderDirectionProbability";

		// Token: 0x04019E77 RID: 106103
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019E78 RID: 106104
		internal static int __PropertyOffset_0;

		// Token: 0x04019E79 RID: 106105
		internal static int __PropertyOffset_1;

		// Token: 0x04019E7A RID: 106106
		internal static int __PropertyOffset_2;

		// Token: 0x04019E7B RID: 106107
		internal static int __PropertyOffset_3;

		// Token: 0x04019E7C RID: 106108
		internal static int __PropertyOffset_4;

		// Token: 0x04019E7D RID: 106109
		internal static int __PropertyOffset_5;

		// Token: 0x04019E7E RID: 106110
		internal static int __PropertyOffset_6;

		// Token: 0x04019E7F RID: 106111
		internal static int __PropertyOffset_7;

		// Token: 0x04019E80 RID: 106112
		internal static int __PropertyOffset_8;

		// Token: 0x04019E81 RID: 106113
		internal static int __PropertyOffset_9;

		// Token: 0x04019E82 RID: 106114
		internal static int __PropertyOffset_10;

		// Token: 0x04019E83 RID: 106115
		internal static int __PropertyOffset_11;

		// Token: 0x04019E84 RID: 106116
		internal static int __PropertyOffset_12;

		// Token: 0x04019E85 RID: 106117
		internal static int __PropertyOffset_13;

		// Token: 0x04019E86 RID: 106118
		internal static int __PropertyOffset_14;

		// Token: 0x04019E87 RID: 106119
		internal static int __PropertyOffset_15;

		// Token: 0x04019E88 RID: 106120
		internal static int __PropertyOffset_16;

		// Token: 0x04019E89 RID: 106121
		internal static int __PropertyOffset_17;
	}
}
