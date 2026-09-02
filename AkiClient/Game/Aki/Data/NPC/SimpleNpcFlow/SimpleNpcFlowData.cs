using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.NPC.SimpleNpcFlow
{
	// Token: 0x02003E5E RID: 15966
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/NPC/SimpleNpcFlow/SimpleNpcFlowData.SimpleNpcFlowData")]
	[UnrealStructLayout(136, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 136)]
	public class SimpleNpcFlowData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027679 RID: 161401 RVA: 0x009F1299 File Offset: 0x009EF499
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SimpleNpcFlowData._ScriptStructPtr != 0) ? SimpleNpcFlowData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/NPC/SimpleNpcFlow/SimpleNpcFlowData.SimpleNpcFlowData", ref SimpleNpcFlowData._ScriptStructPtr);
		}

		// Token: 0x17005C97 RID: 23703
		// (get) Token: 0x0602767A RID: 161402 RVA: 0x009F12BD File Offset: 0x009EF4BD
		// (set) Token: 0x0602767B RID: 161403 RVA: 0x009F12D1 File Offset: 0x009EF4D1
		[Nullable(0)]
		public unsafe TEnumAsByte<ESimpleNpcFlowIndex> Pawn
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SimpleNpcFlowData.__PropertyOffset_0);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SimpleNpcFlowData.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005C98 RID: 23704
		// (get) Token: 0x0602767C RID: 161404 RVA: 0x009F12E6 File Offset: 0x009EF4E6
		// (set) Token: 0x0602767D RID: 161405 RVA: 0x009F12FA File Offset: 0x009EF4FA
		[Nullable(0)]
		public unsafe TEnumAsByte<ESimpleNpcFlowCheckType> CheckType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SimpleNpcFlowData.__PropertyOffset_1);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SimpleNpcFlowData.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005C99 RID: 23705
		// (get) Token: 0x0602767E RID: 161406 RVA: 0x009F130F File Offset: 0x009EF50F
		// (set) Token: 0x0602767F RID: 161407 RVA: 0x009F131F File Offset: 0x009EF51F
		public unsafe int CheckValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SimpleNpcFlowData.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SimpleNpcFlowData.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005C9A RID: 23706
		// (get) Token: 0x06027680 RID: 161408 RVA: 0x009F1330 File Offset: 0x009EF530
		// (set) Token: 0x06027681 RID: 161409 RVA: 0x009F1344 File Offset: 0x009EF544
		public unsafe string FlowListName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SimpleNpcFlowData.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SimpleNpcFlowData.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x17005C9B RID: 23707
		// (get) Token: 0x06027682 RID: 161410 RVA: 0x009F1359 File Offset: 0x009EF559
		// (set) Token: 0x06027683 RID: 161411 RVA: 0x009F136D File Offset: 0x009EF56D
		public unsafe string FlowSubTitle
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SimpleNpcFlowData.__PropertyOffset_4)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SimpleNpcFlowData.__PropertyOffset_4)), value);
			}
		}

		// Token: 0x17005C9C RID: 23708
		// (get) Token: 0x06027684 RID: 161412 RVA: 0x009F1382 File Offset: 0x009EF582
		// (set) Token: 0x06027685 RID: 161413 RVA: 0x009F1392 File Offset: 0x009EF592
		public unsafe float LoopTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SimpleNpcFlowData.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SimpleNpcFlowData.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005C9D RID: 23709
		// (get) Token: 0x06027686 RID: 161414 RVA: 0x009F13A4 File Offset: 0x009EF5A4
		// (set) Token: 0x06027687 RID: 161415 RVA: 0x009F13E7 File Offset: 0x009EF5E7
		public SimplpNpcStateData WorldState
		{
			get
			{
				base.FastCheckIsValid();
				SimplpNpcStateData result;
				if ((result = this._WorldState) == null)
				{
					result = (this._WorldState = new SimplpNpcStateData(base.NativePtr + (IntPtr)SimpleNpcFlowData.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SimplpNpcStateData.StaticStruct(), base.NativePtr + (IntPtr)SimpleNpcFlowData.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06027688 RID: 161416 RVA: 0x009F1408 File Offset: 0x009EF608
		public SimpleNpcFlowData()
		{
		}

		// Token: 0x06027689 RID: 161417 RVA: 0x009F1410 File Offset: 0x009EF610
		public SimpleNpcFlowData([Nullable(0)] TEnumAsByte<ESimpleNpcFlowIndex> Pawn, [Nullable(0)] TEnumAsByte<ESimpleNpcFlowCheckType> CheckType, int CheckValue, string FlowListName, string FlowSubTitle, float LoopTime, SimplpNpcStateData WorldState)
		{
			this.Pawn = Pawn;
			this.CheckType = CheckType;
			this.CheckValue = CheckValue;
			this.FlowListName = FlowListName;
			this.FlowSubTitle = FlowSubTitle;
			this.LoopTime = LoopTime;
			this.WorldState = WorldState;
		}

		// Token: 0x0602768A RID: 161418 RVA: 0x009F144D File Offset: 0x009EF64D
		protected override IntPtr GetUStructPtr()
		{
			return SimpleNpcFlowData.StaticStruct();
		}

		// Token: 0x0602768B RID: 161419 RVA: 0x009F1459 File Offset: 0x009EF659
		[NullableContext(2)]
		public SimpleNpcFlowData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602768C RID: 161420 RVA: 0x009F1463 File Offset: 0x009EF663
		public SimpleNpcFlowData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602768D RID: 161421 RVA: 0x009F146E File Offset: 0x009EF66E
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SimpleNpcFlowData(Pointer, false, true);
		}

		// Token: 0x0602768E RID: 161422 RVA: 0x009F1478 File Offset: 0x009EF678
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SimpleNpcFlowData(Pointer, MemoryOwner);
		}

		// Token: 0x04014A3D RID: 84541
		public const string __ObjectPath = "/Game/Aki/Data/NPC/SimpleNpcFlow/SimpleNpcFlowData.SimpleNpcFlowData";

		// Token: 0x04014A3E RID: 84542
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014A3F RID: 84543
		internal static int __PropertyOffset_0;

		// Token: 0x04014A40 RID: 84544
		internal static int __PropertyOffset_1;

		// Token: 0x04014A41 RID: 84545
		internal static int __PropertyOffset_2;

		// Token: 0x04014A42 RID: 84546
		internal static int __PropertyOffset_3;

		// Token: 0x04014A43 RID: 84547
		internal static int __PropertyOffset_4;

		// Token: 0x04014A44 RID: 84548
		internal static int __PropertyOffset_5;

		// Token: 0x04014A45 RID: 84549
		internal static int __PropertyOffset_6;

		// Token: 0x04014A46 RID: 84550
		[Nullable(2)]
		private SimplpNpcStateData _WorldState;
	}
}
