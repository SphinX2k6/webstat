using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.CreatureTools.Designer
{
	// Token: 0x02003F2F RID: 16175
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/CreatureTools/Designer/NPCQuest.NPCQuest")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 36)]
	public class NPCQuest : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060285FF RID: 165375 RVA: 0x00A08D0B File Offset: 0x00A06F0B
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (NPCQuest._ScriptStructPtr != 0) ? NPCQuest._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/CreatureTools/Designer/NPCQuest.NPCQuest", ref NPCQuest._ScriptStructPtr);
		}

		// Token: 0x17006206 RID: 25094
		// (get) Token: 0x06028600 RID: 165376 RVA: 0x00A08D2F File Offset: 0x00A06F2F
		// (set) Token: 0x06028601 RID: 165377 RVA: 0x00A08D3F File Offset: 0x00A06F3F
		public unsafe int Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCQuest.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCQuest.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006207 RID: 25095
		// (get) Token: 0x06028602 RID: 165378 RVA: 0x00A08D50 File Offset: 0x00A06F50
		// (set) Token: 0x06028603 RID: 165379 RVA: 0x00A08D64 File Offset: 0x00A06F64
		public unsafe string QuestKey
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NPCQuest.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NPCQuest.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17006208 RID: 25096
		// (get) Token: 0x06028604 RID: 165380 RVA: 0x00A08D79 File Offset: 0x00A06F79
		// (set) Token: 0x06028605 RID: 165381 RVA: 0x00A08D89 File Offset: 0x00A06F89
		public unsafe int QuestType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCQuest.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCQuest.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17006209 RID: 25097
		// (get) Token: 0x06028606 RID: 165382 RVA: 0x00A08D9A File Offset: 0x00A06F9A
		// (set) Token: 0x06028607 RID: 165383 RVA: 0x00A08DAA File Offset: 0x00A06FAA
		public unsafe bool IsRepeat
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCQuest.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCQuest.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700620A RID: 25098
		// (get) Token: 0x06028608 RID: 165384 RVA: 0x00A08DBB File Offset: 0x00A06FBB
		// (set) Token: 0x06028609 RID: 165385 RVA: 0x00A08DCB File Offset: 0x00A06FCB
		public unsafe int Duration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCQuest.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCQuest.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x0602860A RID: 165386 RVA: 0x00A08DDC File Offset: 0x00A06FDC
		public NPCQuest()
		{
		}

		// Token: 0x0602860B RID: 165387 RVA: 0x00A08DE4 File Offset: 0x00A06FE4
		public NPCQuest(int Id, string QuestKey, int QuestType, bool IsRepeat, int Duration)
		{
			this.Id = Id;
			this.QuestKey = QuestKey;
			this.QuestType = QuestType;
			this.IsRepeat = IsRepeat;
			this.Duration = Duration;
		}

		// Token: 0x0602860C RID: 165388 RVA: 0x00A08E11 File Offset: 0x00A07011
		protected override IntPtr GetUStructPtr()
		{
			return NPCQuest.StaticStruct();
		}

		// Token: 0x0602860D RID: 165389 RVA: 0x00A08E1D File Offset: 0x00A0701D
		[NullableContext(2)]
		public NPCQuest(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602860E RID: 165390 RVA: 0x00A08E27 File Offset: 0x00A07027
		public NPCQuest(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602860F RID: 165391 RVA: 0x00A08E32 File Offset: 0x00A07032
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new NPCQuest(Pointer, false, true);
		}

		// Token: 0x06028610 RID: 165392 RVA: 0x00A08E3C File Offset: 0x00A0703C
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new NPCQuest(Pointer, MemoryOwner);
		}

		// Token: 0x040153C0 RID: 86976
		public const string __ObjectPath = "/Game/Aki/CreatureTools/Designer/NPCQuest.NPCQuest";

		// Token: 0x040153C1 RID: 86977
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040153C2 RID: 86978
		internal static int __PropertyOffset_0;

		// Token: 0x040153C3 RID: 86979
		internal static int __PropertyOffset_1;

		// Token: 0x040153C4 RID: 86980
		internal static int __PropertyOffset_2;

		// Token: 0x040153C5 RID: 86981
		internal static int __PropertyOffset_3;

		// Token: 0x040153C6 RID: 86982
		internal static int __PropertyOffset_4;
	}
}
