using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.PathLine;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.AI.Struct
{
	// Token: 0x02003F1D RID: 16157
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/AI/Struct/SAIMonsterPatrol.SAIMonsterPatrol")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 28)]
	public class SAIMonsterPatrol : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028523 RID: 165155 RVA: 0x00A07A84 File Offset: 0x00A05C84
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAIMonsterPatrol._ScriptStructPtr != 0) ? SAIMonsterPatrol._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/AI/Struct/SAIMonsterPatrol.SAIMonsterPatrol", ref SAIMonsterPatrol._ScriptStructPtr);
		}

		// Token: 0x170061CC RID: 25036
		// (get) Token: 0x06028524 RID: 165156 RVA: 0x00A07AA8 File Offset: 0x00A05CA8
		// (set) Token: 0x06028525 RID: 165157 RVA: 0x00A07ABC File Offset: 0x00A05CBC
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<BP_BasePathLine_C> 样条对象
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)SAIMonsterPatrol.__PropertyOffset_0);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)SAIMonsterPatrol.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170061CD RID: 25037
		// (get) Token: 0x06028526 RID: 165158 RVA: 0x00A07AD1 File Offset: 0x00A05CD1
		// (set) Token: 0x06028527 RID: 165159 RVA: 0x00A07AE1 File Offset: 0x00A05CE1
		public unsafe bool 巡逻开始
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAIMonsterPatrol.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAIMonsterPatrol.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x170061CE RID: 25038
		// (get) Token: 0x06028528 RID: 165160 RVA: 0x00A07AF2 File Offset: 0x00A05CF2
		// (set) Token: 0x06028529 RID: 165161 RVA: 0x00A07B02 File Offset: 0x00A05D02
		public unsafe bool 循环巡逻
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAIMonsterPatrol.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAIMonsterPatrol.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x170061CF RID: 25039
		// (get) Token: 0x0602852A RID: 165162 RVA: 0x00A07B13 File Offset: 0x00A05D13
		// (set) Token: 0x0602852B RID: 165163 RVA: 0x00A07B23 File Offset: 0x00A05D23
		public unsafe bool 巡逻反向移动
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAIMonsterPatrol.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAIMonsterPatrol.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x170061D0 RID: 25040
		// (get) Token: 0x0602852C RID: 165164 RVA: 0x00A07B34 File Offset: 0x00A05D34
		// (set) Token: 0x0602852D RID: 165165 RVA: 0x00A07B44 File Offset: 0x00A05D44
		public unsafe bool 巡逻初始化
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAIMonsterPatrol.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAIMonsterPatrol.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x170061D1 RID: 25041
		// (get) Token: 0x0602852E RID: 165166 RVA: 0x00A07B55 File Offset: 0x00A05D55
		// (set) Token: 0x0602852F RID: 165167 RVA: 0x00A07B69 File Offset: 0x00A05D69
		[Nullable(2)]
		public unsafe TsBaseCharacter 巡逻限制NPC
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + SAIMonsterPatrol.__PropertyOffset_5);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SAIMonsterPatrol.__PropertyOffset_5, value);
			}
		}

		// Token: 0x170061D2 RID: 25042
		// (get) Token: 0x06028530 RID: 165168 RVA: 0x00A07B7E File Offset: 0x00A05D7E
		// (set) Token: 0x06028531 RID: 165169 RVA: 0x00A07B8E File Offset: 0x00A05D8E
		public unsafe float 巡逻限制NPC距离
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAIMonsterPatrol.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAIMonsterPatrol.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x06028532 RID: 165170 RVA: 0x00A07B9F File Offset: 0x00A05D9F
		public SAIMonsterPatrol()
		{
		}

		// Token: 0x06028533 RID: 165171 RVA: 0x00A07BA7 File Offset: 0x00A05DA7
		[NullableContext(1)]
		public SAIMonsterPatrol([Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<BP_BasePathLine_C> 样条对象, bool 巡逻开始, bool 循环巡逻, bool 巡逻反向移动, bool 巡逻初始化, TsBaseCharacter 巡逻限制NPC, float 巡逻限制NPC距离)
		{
			this.样条对象 = 样条对象;
			this.巡逻开始 = 巡逻开始;
			this.循环巡逻 = 循环巡逻;
			this.巡逻反向移动 = 巡逻反向移动;
			this.巡逻初始化 = 巡逻初始化;
			this.巡逻限制NPC = 巡逻限制NPC;
			this.巡逻限制NPC距离 = 巡逻限制NPC距离;
		}

		// Token: 0x06028534 RID: 165172 RVA: 0x00A07BE4 File Offset: 0x00A05DE4
		protected override IntPtr GetUStructPtr()
		{
			return SAIMonsterPatrol.StaticStruct();
		}

		// Token: 0x06028535 RID: 165173 RVA: 0x00A07BF0 File Offset: 0x00A05DF0
		[NullableContext(2)]
		public SAIMonsterPatrol(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028536 RID: 165174 RVA: 0x00A07BFA File Offset: 0x00A05DFA
		public SAIMonsterPatrol(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028537 RID: 165175 RVA: 0x00A07C05 File Offset: 0x00A05E05
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAIMonsterPatrol(Pointer, false, true);
		}

		// Token: 0x06028538 RID: 165176 RVA: 0x00A07C0F File Offset: 0x00A05E0F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAIMonsterPatrol(Pointer, MemoryOwner);
		}

		// Token: 0x0401534C RID: 86860
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/AI/Struct/SAIMonsterPatrol.SAIMonsterPatrol";

		// Token: 0x0401534D RID: 86861
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401534E RID: 86862
		internal static int __PropertyOffset_0;

		// Token: 0x0401534F RID: 86863
		internal static int __PropertyOffset_1;

		// Token: 0x04015350 RID: 86864
		internal static int __PropertyOffset_2;

		// Token: 0x04015351 RID: 86865
		internal static int __PropertyOffset_3;

		// Token: 0x04015352 RID: 86866
		internal static int __PropertyOffset_4;

		// Token: 0x04015353 RID: 86867
		internal static int __PropertyOffset_5;

		// Token: 0x04015354 RID: 86868
		internal static int __PropertyOffset_6;
	}
}
