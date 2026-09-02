using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.AI.Struct
{
	// Token: 0x02003F1E RID: 16158
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/AI/Struct/SAIPathPoint.SAIPathPoint")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SAIPathPoint : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028539 RID: 165177 RVA: 0x00A07C18 File Offset: 0x00A05E18
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAIPathPoint._ScriptStructPtr != 0) ? SAIPathPoint._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/AI/Struct/SAIPathPoint.SAIPathPoint", ref SAIPathPoint._ScriptStructPtr);
		}

		// Token: 0x170061D3 RID: 25043
		// (get) Token: 0x0602853A RID: 165178 RVA: 0x00A07C3C File Offset: 0x00A05E3C
		// (set) Token: 0x0602853B RID: 165179 RVA: 0x00A07C4C File Offset: 0x00A05E4C
		public unsafe int PathID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAIPathPoint.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAIPathPoint.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170061D4 RID: 25044
		// (get) Token: 0x0602853C RID: 165180 RVA: 0x00A07C5D File Offset: 0x00A05E5D
		// (set) Token: 0x0602853D RID: 165181 RVA: 0x00A07C6D File Offset: 0x00A05E6D
		public unsafe bool MoveBack
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAIPathPoint.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAIPathPoint.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x170061D5 RID: 25045
		// (get) Token: 0x0602853E RID: 165182 RVA: 0x00A07C80 File Offset: 0x00A05E80
		// (set) Token: 0x0602853F RID: 165183 RVA: 0x00A07CC3 File Offset: 0x00A05EC3
		public TArray<FVector> PointList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._PointList) == null)
				{
					result = (this._PointList = new TArray<FVector>(base.NativePtr + (IntPtr)SAIPathPoint.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.PointList.CopyAssign(value);
			}
		}

		// Token: 0x06028540 RID: 165184 RVA: 0x00A07CD1 File Offset: 0x00A05ED1
		public SAIPathPoint()
		{
		}

		// Token: 0x06028541 RID: 165185 RVA: 0x00A07CD9 File Offset: 0x00A05ED9
		public SAIPathPoint(int PathID, bool MoveBack, TArray<FVector> PointList)
		{
			this.PathID = PathID;
			this.MoveBack = MoveBack;
			this.PointList = PointList;
		}

		// Token: 0x06028542 RID: 165186 RVA: 0x00A07CF6 File Offset: 0x00A05EF6
		protected override IntPtr GetUStructPtr()
		{
			return SAIPathPoint.StaticStruct();
		}

		// Token: 0x06028543 RID: 165187 RVA: 0x00A07D02 File Offset: 0x00A05F02
		[NullableContext(2)]
		public SAIPathPoint(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028544 RID: 165188 RVA: 0x00A07D0C File Offset: 0x00A05F0C
		public SAIPathPoint(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028545 RID: 165189 RVA: 0x00A07D17 File Offset: 0x00A05F17
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAIPathPoint(Pointer, false, true);
		}

		// Token: 0x06028546 RID: 165190 RVA: 0x00A07D21 File Offset: 0x00A05F21
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAIPathPoint(Pointer, MemoryOwner);
		}

		// Token: 0x04015355 RID: 86869
		public const string __ObjectPath = "/Game/Aki/Data/AI/Struct/SAIPathPoint.SAIPathPoint";

		// Token: 0x04015356 RID: 86870
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015357 RID: 86871
		internal static int __PropertyOffset_0;

		// Token: 0x04015358 RID: 86872
		internal static int __PropertyOffset_1;

		// Token: 0x04015359 RID: 86873
		internal static int __PropertyOffset_2;

		// Token: 0x0401535A RID: 86874
		[Nullable(2)]
		private TArray<FVector> _PointList;
	}
}
