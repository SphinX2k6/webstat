using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.CreatureTools.Designer
{
	// Token: 0x02003F31 RID: 16177
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/CreatureTools/Designer/QuestAll.QuestAll")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class QuestAll : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602863F RID: 165439 RVA: 0x00A0925C File Offset: 0x00A0745C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (QuestAll._ScriptStructPtr != 0) ? QuestAll._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/CreatureTools/Designer/QuestAll.QuestAll", ref QuestAll._ScriptStructPtr);
		}

		// Token: 0x1700621E RID: 25118
		// (get) Token: 0x06028640 RID: 165440 RVA: 0x00A09280 File Offset: 0x00A07480
		// (set) Token: 0x06028641 RID: 165441 RVA: 0x00A09294 File Offset: 0x00A07494
		public unsafe string DefineMd5
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)QuestAll.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)QuestAll.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x1700621F RID: 25119
		// (get) Token: 0x06028642 RID: 165442 RVA: 0x00A092A9 File Offset: 0x00A074A9
		// (set) Token: 0x06028643 RID: 165443 RVA: 0x00A092BD File Offset: 0x00A074BD
		public unsafe string DataMd5
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)QuestAll.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)QuestAll.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17006220 RID: 25120
		// (get) Token: 0x06028644 RID: 165444 RVA: 0x00A092D4 File Offset: 0x00A074D4
		// (set) Token: 0x06028645 RID: 165445 RVA: 0x00A09317 File Offset: 0x00A07517
		public TArray<NPCQuest> Data
		{
			get
			{
				base.FastCheckIsValid();
				TArray<NPCQuest> result;
				if ((result = this._Data) == null)
				{
					result = (this._Data = new TArray<NPCQuest>(base.NativePtr + (IntPtr)QuestAll.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Data.CopyAssign(value);
			}
		}

		// Token: 0x06028646 RID: 165446 RVA: 0x00A09325 File Offset: 0x00A07525
		public QuestAll()
		{
		}

		// Token: 0x06028647 RID: 165447 RVA: 0x00A0932D File Offset: 0x00A0752D
		public QuestAll(string DefineMd5, string DataMd5, TArray<NPCQuest> Data)
		{
			this.DefineMd5 = DefineMd5;
			this.DataMd5 = DataMd5;
			this.Data = Data;
		}

		// Token: 0x06028648 RID: 165448 RVA: 0x00A0934A File Offset: 0x00A0754A
		protected override IntPtr GetUStructPtr()
		{
			return QuestAll.StaticStruct();
		}

		// Token: 0x06028649 RID: 165449 RVA: 0x00A09356 File Offset: 0x00A07556
		[NullableContext(2)]
		public QuestAll(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602864A RID: 165450 RVA: 0x00A09360 File Offset: 0x00A07560
		public QuestAll(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602864B RID: 165451 RVA: 0x00A0936B File Offset: 0x00A0756B
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new QuestAll(Pointer, false, true);
		}

		// Token: 0x0602864C RID: 165452 RVA: 0x00A09375 File Offset: 0x00A07575
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new QuestAll(Pointer, MemoryOwner);
		}

		// Token: 0x040153DF RID: 87007
		public const string __ObjectPath = "/Game/Aki/CreatureTools/Designer/QuestAll.QuestAll";

		// Token: 0x040153E0 RID: 87008
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040153E1 RID: 87009
		internal static int __PropertyOffset_0;

		// Token: 0x040153E2 RID: 87010
		internal static int __PropertyOffset_1;

		// Token: 0x040153E3 RID: 87011
		internal static int __PropertyOffset_2;

		// Token: 0x040153E4 RID: 87012
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<NPCQuest> _Data;
	}
}
