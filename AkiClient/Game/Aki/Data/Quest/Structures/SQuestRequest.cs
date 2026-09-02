using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Quest.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Quest.Structures
{
	// Token: 0x02003E2F RID: 15919
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Quest/Structures/SQuestRequest.SQuestRequest")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 40)]
	public class SQuestRequest : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060273D4 RID: 160724 RVA: 0x009ED0B8 File Offset: 0x009EB2B8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SQuestRequest._ScriptStructPtr != 0) ? SQuestRequest._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Quest/Structures/SQuestRequest.SQuestRequest", ref SQuestRequest._ScriptStructPtr);
		}

		// Token: 0x17005BBE RID: 23486
		// (get) Token: 0x060273D5 RID: 160725 RVA: 0x009ED0DC File Offset: 0x009EB2DC
		// (set) Token: 0x060273D6 RID: 160726 RVA: 0x009ED0F0 File Offset: 0x009EB2F0
		public unsafe FName QuestID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestRequest.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestRequest.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005BBF RID: 23487
		// (get) Token: 0x060273D7 RID: 160727 RVA: 0x009ED105 File Offset: 0x009EB305
		// (set) Token: 0x060273D8 RID: 160728 RVA: 0x009ED119 File Offset: 0x009EB319
		public unsafe FName QuestStepID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestRequest.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestRequest.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005BC0 RID: 23488
		// (get) Token: 0x060273D9 RID: 160729 RVA: 0x009ED12E File Offset: 0x009EB32E
		// (set) Token: 0x060273DA RID: 160730 RVA: 0x009ED142 File Offset: 0x009EB342
		[Nullable(2)]
		public unsafe UDataTable QuestData
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + SQuestRequest.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SQuestRequest.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005BC1 RID: 23489
		// (get) Token: 0x060273DB RID: 160731 RVA: 0x009ED157 File Offset: 0x009EB357
		// (set) Token: 0x060273DC RID: 160732 RVA: 0x009ED16B File Offset: 0x009EB36B
		public unsafe TEnumAsByte<EQuestHandleType> QuesetHandleType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestRequest.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestRequest.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005BC2 RID: 23490
		// (get) Token: 0x060273DD RID: 160733 RVA: 0x009ED180 File Offset: 0x009EB380
		// (set) Token: 0x060273DE RID: 160734 RVA: 0x009ED190 File Offset: 0x009EB390
		public unsafe float QuestDelay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQuestRequest.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQuestRequest.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x060273DF RID: 160735 RVA: 0x009ED1A1 File Offset: 0x009EB3A1
		public SQuestRequest()
		{
		}

		// Token: 0x060273E0 RID: 160736 RVA: 0x009ED1A9 File Offset: 0x009EB3A9
		public SQuestRequest(FName QuestID, FName QuestStepID, [Nullable(1)] UDataTable QuestData, TEnumAsByte<EQuestHandleType> QuesetHandleType, float QuestDelay)
		{
			this.QuestID = QuestID;
			this.QuestStepID = QuestStepID;
			this.QuestData = QuestData;
			this.QuesetHandleType = QuesetHandleType;
			this.QuestDelay = QuestDelay;
		}

		// Token: 0x060273E1 RID: 160737 RVA: 0x009ED1D6 File Offset: 0x009EB3D6
		protected override IntPtr GetUStructPtr()
		{
			return SQuestRequest.StaticStruct();
		}

		// Token: 0x060273E2 RID: 160738 RVA: 0x009ED1E2 File Offset: 0x009EB3E2
		[NullableContext(2)]
		public SQuestRequest(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060273E3 RID: 160739 RVA: 0x009ED1EC File Offset: 0x009EB3EC
		public SQuestRequest(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060273E4 RID: 160740 RVA: 0x009ED1F7 File Offset: 0x009EB3F7
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SQuestRequest(Pointer, false, true);
		}

		// Token: 0x060273E5 RID: 160741 RVA: 0x009ED201 File Offset: 0x009EB401
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SQuestRequest(Pointer, MemoryOwner);
		}

		// Token: 0x04014840 RID: 84032
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Quest/Structures/SQuestRequest.SQuestRequest";

		// Token: 0x04014841 RID: 84033
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014842 RID: 84034
		internal static int __PropertyOffset_0;

		// Token: 0x04014843 RID: 84035
		internal static int __PropertyOffset_1;

		// Token: 0x04014844 RID: 84036
		internal static int __PropertyOffset_2;

		// Token: 0x04014845 RID: 84037
		internal static int __PropertyOffset_3;

		// Token: 0x04014846 RID: 84038
		internal static int __PropertyOffset_4;
	}
}
