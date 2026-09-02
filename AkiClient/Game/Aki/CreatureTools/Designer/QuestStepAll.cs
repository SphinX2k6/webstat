using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.CreatureTools.Designer
{
	// Token: 0x02003F32 RID: 16178
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/CreatureTools/Designer/QuestStepAll.QuestStepAll")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class QuestStepAll : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602864D RID: 165453 RVA: 0x00A0937E File Offset: 0x00A0757E
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (QuestStepAll._ScriptStructPtr != 0) ? QuestStepAll._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/CreatureTools/Designer/QuestStepAll.QuestStepAll", ref QuestStepAll._ScriptStructPtr);
		}

		// Token: 0x17006221 RID: 25121
		// (get) Token: 0x0602864E RID: 165454 RVA: 0x00A093A2 File Offset: 0x00A075A2
		// (set) Token: 0x0602864F RID: 165455 RVA: 0x00A093B6 File Offset: 0x00A075B6
		public unsafe string DefineMd5
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)QuestStepAll.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)QuestStepAll.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17006222 RID: 25122
		// (get) Token: 0x06028650 RID: 165456 RVA: 0x00A093CB File Offset: 0x00A075CB
		// (set) Token: 0x06028651 RID: 165457 RVA: 0x00A093DF File Offset: 0x00A075DF
		public unsafe string DataMd5
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)QuestStepAll.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)QuestStepAll.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17006223 RID: 25123
		// (get) Token: 0x06028652 RID: 165458 RVA: 0x00A093F4 File Offset: 0x00A075F4
		// (set) Token: 0x06028653 RID: 165459 RVA: 0x00A09437 File Offset: 0x00A07637
		public TArray<NPCQuestStep> Data
		{
			get
			{
				base.FastCheckIsValid();
				TArray<NPCQuestStep> result;
				if ((result = this._Data) == null)
				{
					result = (this._Data = new TArray<NPCQuestStep>(base.NativePtr + (IntPtr)QuestStepAll.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Data.CopyAssign(value);
			}
		}

		// Token: 0x06028654 RID: 165460 RVA: 0x00A09445 File Offset: 0x00A07645
		public QuestStepAll()
		{
		}

		// Token: 0x06028655 RID: 165461 RVA: 0x00A0944D File Offset: 0x00A0764D
		public QuestStepAll(string DefineMd5, string DataMd5, TArray<NPCQuestStep> Data)
		{
			this.DefineMd5 = DefineMd5;
			this.DataMd5 = DataMd5;
			this.Data = Data;
		}

		// Token: 0x06028656 RID: 165462 RVA: 0x00A0946A File Offset: 0x00A0766A
		protected override IntPtr GetUStructPtr()
		{
			return QuestStepAll.StaticStruct();
		}

		// Token: 0x06028657 RID: 165463 RVA: 0x00A09476 File Offset: 0x00A07676
		[NullableContext(2)]
		public QuestStepAll(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028658 RID: 165464 RVA: 0x00A09480 File Offset: 0x00A07680
		public QuestStepAll(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028659 RID: 165465 RVA: 0x00A0948B File Offset: 0x00A0768B
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new QuestStepAll(Pointer, false, true);
		}

		// Token: 0x0602865A RID: 165466 RVA: 0x00A09495 File Offset: 0x00A07695
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new QuestStepAll(Pointer, MemoryOwner);
		}

		// Token: 0x040153E5 RID: 87013
		public const string __ObjectPath = "/Game/Aki/CreatureTools/Designer/QuestStepAll.QuestStepAll";

		// Token: 0x040153E6 RID: 87014
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040153E7 RID: 87015
		internal static int __PropertyOffset_0;

		// Token: 0x040153E8 RID: 87016
		internal static int __PropertyOffset_1;

		// Token: 0x040153E9 RID: 87017
		internal static int __PropertyOffset_2;

		// Token: 0x040153EA RID: 87018
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<NPCQuestStep> _Data;
	}
}
