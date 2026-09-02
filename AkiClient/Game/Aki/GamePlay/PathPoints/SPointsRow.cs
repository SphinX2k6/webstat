using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.GamePlay.PathPoints
{
	// Token: 0x02003DD0 RID: 15824
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/GamePlay/PathPoints/SPointsRow.SPointsRow")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SPointsRow : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026C2E RID: 158766 RVA: 0x009E1658 File Offset: 0x009DF858
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SPointsRow._ScriptStructPtr != 0) ? SPointsRow._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/GamePlay/PathPoints/SPointsRow.SPointsRow", ref SPointsRow._ScriptStructPtr);
		}

		// Token: 0x170058F0 RID: 22768
		// (get) Token: 0x06026C2F RID: 158767 RVA: 0x009E167C File Offset: 0x009DF87C
		// (set) Token: 0x06026C30 RID: 158768 RVA: 0x009E168C File Offset: 0x009DF88C
		public unsafe float X
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPointsRow.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPointsRow.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170058F1 RID: 22769
		// (get) Token: 0x06026C31 RID: 158769 RVA: 0x009E16A0 File Offset: 0x009DF8A0
		// (set) Token: 0x06026C32 RID: 158770 RVA: 0x009E16E3 File Offset: 0x009DF8E3
		public TArray<FVector> PointsRow
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._PointsRow) == null)
				{
					result = (this._PointsRow = new TArray<FVector>(base.NativePtr + (IntPtr)SPointsRow.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.PointsRow.CopyAssign(value);
			}
		}

		// Token: 0x06026C33 RID: 158771 RVA: 0x009E16F1 File Offset: 0x009DF8F1
		public SPointsRow()
		{
		}

		// Token: 0x06026C34 RID: 158772 RVA: 0x009E16F9 File Offset: 0x009DF8F9
		public SPointsRow(float X, TArray<FVector> PointsRow)
		{
			this.X = X;
			this.PointsRow = PointsRow;
		}

		// Token: 0x06026C35 RID: 158773 RVA: 0x009E170F File Offset: 0x009DF90F
		protected override IntPtr GetUStructPtr()
		{
			return SPointsRow.StaticStruct();
		}

		// Token: 0x06026C36 RID: 158774 RVA: 0x009E171B File Offset: 0x009DF91B
		[NullableContext(2)]
		public SPointsRow(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026C37 RID: 158775 RVA: 0x009E1725 File Offset: 0x009DF925
		public SPointsRow(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026C38 RID: 158776 RVA: 0x009E1730 File Offset: 0x009DF930
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SPointsRow(Pointer, false, true);
		}

		// Token: 0x06026C39 RID: 158777 RVA: 0x009E173A File Offset: 0x009DF93A
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SPointsRow(Pointer, MemoryOwner);
		}

		// Token: 0x0401436F RID: 82799
		public const string __ObjectPath = "/Game/Aki/GamePlay/PathPoints/SPointsRow.SPointsRow";

		// Token: 0x04014370 RID: 82800
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014371 RID: 82801
		internal static int __PropertyOffset_0;

		// Token: 0x04014372 RID: 82802
		internal static int __PropertyOffset_1;

		// Token: 0x04014373 RID: 82803
		[Nullable(2)]
		private TArray<FVector> _PointsRow;
	}
}
