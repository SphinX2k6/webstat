using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiNavigation.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.UiNavigation.Struct
{
	// Token: 0x02003DF5 RID: 15861
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/UiNavigation/Struct/SNavigationCursor.SNavigationCursor")]
	[UnrealStructLayout(12, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 9)]
	public class SNavigationCursor : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027041 RID: 159809 RVA: 0x009E8179 File Offset: 0x009E6379
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SNavigationCursor._ScriptStructPtr != 0) ? SNavigationCursor._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/UiNavigation/Struct/SNavigationCursor.SNavigationCursor", ref SNavigationCursor._ScriptStructPtr);
		}

		// Token: 0x17005A88 RID: 23176
		// (get) Token: 0x06027042 RID: 159810 RVA: 0x009E819D File Offset: 0x009E639D
		// (set) Token: 0x06027043 RID: 159811 RVA: 0x009E81B1 File Offset: 0x009E63B1
		public unsafe TEnumAsByte<ECursorOffsetType> OffsetType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNavigationCursor.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationCursor.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005A89 RID: 23177
		// (get) Token: 0x06027044 RID: 159812 RVA: 0x009E81C6 File Offset: 0x009E63C6
		// (set) Token: 0x06027045 RID: 159813 RVA: 0x009E81D6 File Offset: 0x009E63D6
		public unsafe int BoundOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNavigationCursor.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationCursor.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005A8A RID: 23178
		// (get) Token: 0x06027046 RID: 159814 RVA: 0x009E81E7 File Offset: 0x009E63E7
		// (set) Token: 0x06027047 RID: 159815 RVA: 0x009E81F7 File Offset: 0x009E63F7
		public unsafe bool Switch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SNavigationCursor.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SNavigationCursor.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x06027048 RID: 159816 RVA: 0x009E8208 File Offset: 0x009E6408
		public SNavigationCursor()
		{
		}

		// Token: 0x06027049 RID: 159817 RVA: 0x009E8210 File Offset: 0x009E6410
		public SNavigationCursor(TEnumAsByte<ECursorOffsetType> OffsetType, int BoundOffset, bool Switch)
		{
			this.OffsetType = OffsetType;
			this.BoundOffset = BoundOffset;
			this.Switch = Switch;
		}

		// Token: 0x0602704A RID: 159818 RVA: 0x009E822D File Offset: 0x009E642D
		protected override IntPtr GetUStructPtr()
		{
			return SNavigationCursor.StaticStruct();
		}

		// Token: 0x0602704B RID: 159819 RVA: 0x009E8239 File Offset: 0x009E6439
		[NullableContext(2)]
		public SNavigationCursor(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602704C RID: 159820 RVA: 0x009E8243 File Offset: 0x009E6443
		public SNavigationCursor(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602704D RID: 159821 RVA: 0x009E824E File Offset: 0x009E644E
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SNavigationCursor(Pointer, false, true);
		}

		// Token: 0x0602704E RID: 159822 RVA: 0x009E8258 File Offset: 0x009E6458
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SNavigationCursor(Pointer, MemoryOwner);
		}

		// Token: 0x04014616 RID: 83478
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/UiNavigation/Struct/SNavigationCursor.SNavigationCursor";

		// Token: 0x04014617 RID: 83479
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014618 RID: 83480
		internal static int __PropertyOffset_0;

		// Token: 0x04014619 RID: 83481
		internal static int __PropertyOffset_1;

		// Token: 0x0401461A RID: 83482
		internal static int __PropertyOffset_2;
	}
}
