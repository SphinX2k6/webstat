using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.AI.AIFunctionCommon.KFCS_WandersData
{
	// Token: 0x02004395 RID: 17301
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/SMonsterAttackDistanceValue.SMonsterAttackDistanceValue")]
	[UnrealStructLayout(28, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 28)]
	public class SMonsterAttackDistanceValue : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602DDD7 RID: 187863 RVA: 0x00ACE8C4 File Offset: 0x00ACCAC4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMonsterAttackDistanceValue._ScriptStructPtr != 0) ? SMonsterAttackDistanceValue._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/SMonsterAttackDistanceValue.SMonsterAttackDistanceValue", ref SMonsterAttackDistanceValue._ScriptStructPtr);
		}

		// Token: 0x17007DC7 RID: 32199
		// (get) Token: 0x0602DDD8 RID: 187864 RVA: 0x00ACE8E8 File Offset: 0x00ACCAE8
		// (set) Token: 0x0602DDD9 RID: 187865 RVA: 0x00ACE8F8 File Offset: 0x00ACCAF8
		public unsafe float 近距离战斗圈
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMonsterAttackDistanceValue.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMonsterAttackDistanceValue.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007DC8 RID: 32200
		// (get) Token: 0x0602DDDA RID: 187866 RVA: 0x00ACE909 File Offset: 0x00ACCB09
		// (set) Token: 0x0602DDDB RID: 187867 RVA: 0x00ACE919 File Offset: 0x00ACCB19
		public unsafe float 远距离战斗圈
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMonsterAttackDistanceValue.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMonsterAttackDistanceValue.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007DC9 RID: 32201
		// (get) Token: 0x0602DDDC RID: 187868 RVA: 0x00ACE92A File Offset: 0x00ACCB2A
		// (set) Token: 0x0602DDDD RID: 187869 RVA: 0x00ACE93A File Offset: 0x00ACCB3A
		public unsafe float 近距离战斗角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMonsterAttackDistanceValue.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMonsterAttackDistanceValue.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007DCA RID: 32202
		// (get) Token: 0x0602DDDE RID: 187870 RVA: 0x00ACE94B File Offset: 0x00ACCB4B
		// (set) Token: 0x0602DDDF RID: 187871 RVA: 0x00ACE95B File Offset: 0x00ACCB5B
		public unsafe float 近距离摄像机角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMonsterAttackDistanceValue.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMonsterAttackDistanceValue.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007DCB RID: 32203
		// (get) Token: 0x0602DDE0 RID: 187872 RVA: 0x00ACE96C File Offset: 0x00ACCB6C
		// (set) Token: 0x0602DDE1 RID: 187873 RVA: 0x00ACE97C File Offset: 0x00ACCB7C
		public unsafe float 中距离战斗角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMonsterAttackDistanceValue.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMonsterAttackDistanceValue.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007DCC RID: 32204
		// (get) Token: 0x0602DDE2 RID: 187874 RVA: 0x00ACE98D File Offset: 0x00ACCB8D
		// (set) Token: 0x0602DDE3 RID: 187875 RVA: 0x00ACE99D File Offset: 0x00ACCB9D
		public unsafe float 中距离摄像机角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMonsterAttackDistanceValue.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMonsterAttackDistanceValue.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007DCD RID: 32205
		// (get) Token: 0x0602DDE4 RID: 187876 RVA: 0x00ACE9AE File Offset: 0x00ACCBAE
		// (set) Token: 0x0602DDE5 RID: 187877 RVA: 0x00ACE9BE File Offset: 0x00ACCBBE
		public unsafe float 远距离摄像机角度
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMonsterAttackDistanceValue.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMonsterAttackDistanceValue.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x0602DDE6 RID: 187878 RVA: 0x00ACE9CF File Offset: 0x00ACCBCF
		public SMonsterAttackDistanceValue()
		{
		}

		// Token: 0x0602DDE7 RID: 187879 RVA: 0x00ACE9D7 File Offset: 0x00ACCBD7
		public SMonsterAttackDistanceValue(float 近距离战斗圈, float 远距离战斗圈, float 近距离战斗角度, float 近距离摄像机角度, float 中距离战斗角度, float 中距离摄像机角度, float 远距离摄像机角度)
		{
			this.近距离战斗圈 = 近距离战斗圈;
			this.远距离战斗圈 = 远距离战斗圈;
			this.近距离战斗角度 = 近距离战斗角度;
			this.近距离摄像机角度 = 近距离摄像机角度;
			this.中距离战斗角度 = 中距离战斗角度;
			this.中距离摄像机角度 = 中距离摄像机角度;
			this.远距离摄像机角度 = 远距离摄像机角度;
		}

		// Token: 0x0602DDE8 RID: 187880 RVA: 0x00ACEA14 File Offset: 0x00ACCC14
		protected override IntPtr GetUStructPtr()
		{
			return SMonsterAttackDistanceValue.StaticStruct();
		}

		// Token: 0x0602DDE9 RID: 187881 RVA: 0x00ACEA20 File Offset: 0x00ACCC20
		[NullableContext(2)]
		public SMonsterAttackDistanceValue(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602DDEA RID: 187882 RVA: 0x00ACEA2A File Offset: 0x00ACCC2A
		public SMonsterAttackDistanceValue(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602DDEB RID: 187883 RVA: 0x00ACEA35 File Offset: 0x00ACCC35
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMonsterAttackDistanceValue(Pointer, false, true);
		}

		// Token: 0x0602DDEC RID: 187884 RVA: 0x00ACEA3F File Offset: 0x00ACCC3F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMonsterAttackDistanceValue(Pointer, MemoryOwner);
		}

		// Token: 0x04019EA1 RID: 106145
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/SMonsterAttackDistanceValue.SMonsterAttackDistanceValue";

		// Token: 0x04019EA2 RID: 106146
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019EA3 RID: 106147
		internal static int __PropertyOffset_0;

		// Token: 0x04019EA4 RID: 106148
		internal static int __PropertyOffset_1;

		// Token: 0x04019EA5 RID: 106149
		internal static int __PropertyOffset_2;

		// Token: 0x04019EA6 RID: 106150
		internal static int __PropertyOffset_3;

		// Token: 0x04019EA7 RID: 106151
		internal static int __PropertyOffset_4;

		// Token: 0x04019EA8 RID: 106152
		internal static int __PropertyOffset_5;

		// Token: 0x04019EA9 RID: 106153
		internal static int __PropertyOffset_6;
	}
}
