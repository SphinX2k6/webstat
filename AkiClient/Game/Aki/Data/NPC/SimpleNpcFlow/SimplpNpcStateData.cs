using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.NPC.SimpleNpcFlow
{
	// Token: 0x02003E5F RID: 15967
	[UnrealObjectPath("/Game/Aki/Data/NPC/SimpleNpcFlow/SimplpNpcStateData.SimplpNpcStateData")]
	[UnrealStructLayout(88, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 88)]
	public class SimplpNpcStateData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602768F RID: 161423 RVA: 0x009F1481 File Offset: 0x009EF681
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SimplpNpcStateData._ScriptStructPtr != 0) ? SimplpNpcStateData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/NPC/SimpleNpcFlow/SimplpNpcStateData.SimplpNpcStateData", ref SimplpNpcStateData._ScriptStructPtr);
		}

		// Token: 0x17005C9E RID: 23710
		// (get) Token: 0x06027690 RID: 161424 RVA: 0x009F14A5 File Offset: 0x009EF6A5
		// (set) Token: 0x06027691 RID: 161425 RVA: 0x009F14B5 File Offset: 0x009EF6B5
		public unsafe bool MeetAllConditions
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SimplpNpcStateData.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SimplpNpcStateData.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C9F RID: 23711
		// (get) Token: 0x06027692 RID: 161426 RVA: 0x009F14C8 File Offset: 0x009EF6C8
		// (set) Token: 0x06027693 RID: 161427 RVA: 0x009F150B File Offset: 0x009EF70B
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TMap<TEnumAsByte<ESimpleNpcWorldState>, int> WorldStateMap
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<ESimpleNpcWorldState>, int> result;
				if ((result = this._WorldStateMap) == null)
				{
					result = (this._WorldStateMap = new TMap<TEnumAsByte<ESimpleNpcWorldState>, int>(base.NativePtr + (IntPtr)SimplpNpcStateData.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.WorldStateMap.CopyAssign(value);
			}
		}

		// Token: 0x06027694 RID: 161428 RVA: 0x009F1519 File Offset: 0x009EF719
		public SimplpNpcStateData()
		{
		}

		// Token: 0x06027695 RID: 161429 RVA: 0x009F1521 File Offset: 0x009EF721
		public SimplpNpcStateData(bool MeetAllConditions, [Nullable(new byte[]
		{
			1,
			0
		})] TMap<TEnumAsByte<ESimpleNpcWorldState>, int> WorldStateMap)
		{
			this.MeetAllConditions = MeetAllConditions;
			this.WorldStateMap = WorldStateMap;
		}

		// Token: 0x06027696 RID: 161430 RVA: 0x009F1537 File Offset: 0x009EF737
		protected override IntPtr GetUStructPtr()
		{
			return SimplpNpcStateData.StaticStruct();
		}

		// Token: 0x06027697 RID: 161431 RVA: 0x009F1543 File Offset: 0x009EF743
		[NullableContext(2)]
		public SimplpNpcStateData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027698 RID: 161432 RVA: 0x009F154D File Offset: 0x009EF74D
		public SimplpNpcStateData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027699 RID: 161433 RVA: 0x009F1558 File Offset: 0x009EF758
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SimplpNpcStateData(Pointer, false, true);
		}

		// Token: 0x0602769A RID: 161434 RVA: 0x009F1562 File Offset: 0x009EF762
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SimplpNpcStateData(Pointer, MemoryOwner);
		}

		// Token: 0x04014A47 RID: 84551
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/NPC/SimpleNpcFlow/SimplpNpcStateData.SimplpNpcStateData";

		// Token: 0x04014A48 RID: 84552
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014A49 RID: 84553
		internal static int __PropertyOffset_0;

		// Token: 0x04014A4A RID: 84554
		internal static int __PropertyOffset_1;

		// Token: 0x04014A4B RID: 84555
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TMap<TEnumAsByte<ESimpleNpcWorldState>, int> _WorldStateMap;
	}
}
