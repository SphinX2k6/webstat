using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Quest.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Quest.Structures
{
	// Token: 0x02003E2E RID: 15918
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Quest/Structures/SQuest.SQuest")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 33)]
	public class SQuest : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060273BC RID: 160700 RVA: 0x009ECEEE File Offset: 0x009EB0EE
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SQuest._ScriptStructPtr != 0) ? SQuest._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Quest/Structures/SQuest.SQuest", ref SQuest._ScriptStructPtr);
		}

		// Token: 0x17005BB6 RID: 23478
		// (get) Token: 0x060273BD RID: 160701 RVA: 0x009ECF12 File Offset: 0x009EB112
		// (set) Token: 0x060273BE RID: 160702 RVA: 0x009ECF22 File Offset: 0x009EB122
		public unsafe int ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuest.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuest.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005BB7 RID: 23479
		// (get) Token: 0x060273BF RID: 160703 RVA: 0x009ECF33 File Offset: 0x009EB133
		// (set) Token: 0x060273C0 RID: 160704 RVA: 0x009ECF43 File Offset: 0x009EB143
		public unsafe int 任务名称
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuest.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuest.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005BB8 RID: 23480
		// (get) Token: 0x060273C1 RID: 160705 RVA: 0x009ECF54 File Offset: 0x009EB154
		// (set) Token: 0x060273C2 RID: 160706 RVA: 0x009ECF68 File Offset: 0x009EB168
		[Nullable(1)]
		public unsafe string 任务KEY
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SQuest.__PropertyOffset_2)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SQuest.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x17005BB9 RID: 23481
		// (get) Token: 0x060273C3 RID: 160707 RVA: 0x009ECF7D File Offset: 0x009EB17D
		// (set) Token: 0x060273C4 RID: 160708 RVA: 0x009ECF91 File Offset: 0x009EB191
		public unsafe TEnumAsByte<EQuestType> 任务类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuest.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuest.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005BBA RID: 23482
		// (get) Token: 0x060273C5 RID: 160709 RVA: 0x009ECFA6 File Offset: 0x009EB1A6
		// (set) Token: 0x060273C6 RID: 160710 RVA: 0x009ECFB6 File Offset: 0x009EB1B6
		public unsafe bool 是否可重复
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuest.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuest.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005BBB RID: 23483
		// (get) Token: 0x060273C7 RID: 160711 RVA: 0x009ECFC7 File Offset: 0x009EB1C7
		// (set) Token: 0x060273C8 RID: 160712 RVA: 0x009ECFD7 File Offset: 0x009EB1D7
		public unsafe bool 是否完成
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuest.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuest.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005BBC RID: 23484
		// (get) Token: 0x060273C9 RID: 160713 RVA: 0x009ECFE8 File Offset: 0x009EB1E8
		// (set) Token: 0x060273CA RID: 160714 RVA: 0x009ECFF8 File Offset: 0x009EB1F8
		public unsafe int 任务详细信息
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuest.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuest.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005BBD RID: 23485
		// (get) Token: 0x060273CB RID: 160715 RVA: 0x009ED009 File Offset: 0x009EB209
		// (set) Token: 0x060273CC RID: 160716 RVA: 0x009ED019 File Offset: 0x009EB219
		public unsafe bool 是否可联机
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuest.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuest.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x060273CD RID: 160717 RVA: 0x009ED02A File Offset: 0x009EB22A
		public SQuest()
		{
		}

		// Token: 0x060273CE RID: 160718 RVA: 0x009ED034 File Offset: 0x009EB234
		public SQuest(int ID, int 任务名称, [Nullable(1)] string 任务KEY, TEnumAsByte<EQuestType> 任务类型, bool 是否可重复, bool 是否完成, int 任务详细信息, bool 是否可联机)
		{
			this.ID = ID;
			this.任务名称 = 任务名称;
			this.任务KEY = 任务KEY;
			this.任务类型 = 任务类型;
			this.是否可重复 = 是否可重复;
			this.是否完成 = 是否完成;
			this.任务详细信息 = 任务详细信息;
			this.是否可联机 = 是否可联机;
		}

		// Token: 0x060273CF RID: 160719 RVA: 0x009ED084 File Offset: 0x009EB284
		protected override IntPtr GetUStructPtr()
		{
			return SQuest.StaticStruct();
		}

		// Token: 0x060273D0 RID: 160720 RVA: 0x009ED090 File Offset: 0x009EB290
		[NullableContext(2)]
		public SQuest(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060273D1 RID: 160721 RVA: 0x009ED09A File Offset: 0x009EB29A
		public SQuest(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060273D2 RID: 160722 RVA: 0x009ED0A5 File Offset: 0x009EB2A5
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SQuest(Pointer, false, true);
		}

		// Token: 0x060273D3 RID: 160723 RVA: 0x009ED0AF File Offset: 0x009EB2AF
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SQuest(Pointer, MemoryOwner);
		}

		// Token: 0x04014836 RID: 84022
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Quest/Structures/SQuest.SQuest";

		// Token: 0x04014837 RID: 84023
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014838 RID: 84024
		internal static int __PropertyOffset_0;

		// Token: 0x04014839 RID: 84025
		internal static int __PropertyOffset_1;

		// Token: 0x0401483A RID: 84026
		internal static int __PropertyOffset_2;

		// Token: 0x0401483B RID: 84027
		internal static int __PropertyOffset_3;

		// Token: 0x0401483C RID: 84028
		internal static int __PropertyOffset_4;

		// Token: 0x0401483D RID: 84029
		internal static int __PropertyOffset_5;

		// Token: 0x0401483E RID: 84030
		internal static int __PropertyOffset_6;

		// Token: 0x0401483F RID: 84031
		internal static int __PropertyOffset_7;
	}
}
