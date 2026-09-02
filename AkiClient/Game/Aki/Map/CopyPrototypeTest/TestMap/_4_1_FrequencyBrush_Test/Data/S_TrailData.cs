using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Map.CopyPrototypeTest.TestMap._4_1_FrequencyBrush_Test.Data
{
	// Token: 0x02003DB7 RID: 15799
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Map/CopyPrototypeTest/TestMap/4_1_FrequencyBrush_Test/Data/S_TrailData.S_TrailData")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 96)]
	public class S_TrailData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026AEE RID: 158446 RVA: 0x009DEF20 File Offset: 0x009DD120
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_TrailData._ScriptStructPtr != 0) ? S_TrailData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Map/CopyPrototypeTest/TestMap/4_1_FrequencyBrush_Test/Data/S_TrailData.S_TrailData", ref S_TrailData._ScriptStructPtr);
		}

		// Token: 0x170058AD RID: 22701
		// (get) Token: 0x06026AEF RID: 158447 RVA: 0x009DEF44 File Offset: 0x009DD144
		// (set) Token: 0x06026AF0 RID: 158448 RVA: 0x009DEF54 File Offset: 0x009DD154
		public unsafe int TrailIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_TrailData.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_TrailData.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170058AE RID: 22702
		// (get) Token: 0x06026AF1 RID: 158449 RVA: 0x009DEF65 File Offset: 0x009DD165
		// (set) Token: 0x06026AF2 RID: 158450 RVA: 0x009DEF79 File Offset: 0x009DD179
		public unsafe FVectorDouble TrailCentroid
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_TrailData.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_TrailData.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170058AF RID: 22703
		// (get) Token: 0x06026AF3 RID: 158451 RVA: 0x009DEF8E File Offset: 0x009DD18E
		// (set) Token: 0x06026AF4 RID: 158452 RVA: 0x009DEFA2 File Offset: 0x009DD1A2
		public unsafe FVectorDouble TrailCentroidInWorld
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_TrailData.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_TrailData.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170058B0 RID: 22704
		// (get) Token: 0x06026AF5 RID: 158453 RVA: 0x009DEFB7 File Offset: 0x009DD1B7
		// (set) Token: 0x06026AF6 RID: 158454 RVA: 0x009DEFCB File Offset: 0x009DD1CB
		[Nullable(0)]
		public unsafe TEnumAsByte<E_FreqDrawResult> TrailDrawResult
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)S_TrailData.__PropertyOffset_3);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)S_TrailData.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170058B1 RID: 22705
		// (get) Token: 0x06026AF7 RID: 158455 RVA: 0x009DEFE0 File Offset: 0x009DD1E0
		// (set) Token: 0x06026AF8 RID: 158456 RVA: 0x009DF023 File Offset: 0x009DD223
		public TArray<FVectorDouble> TrailPoints
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVectorDouble> result;
				if ((result = this._TrailPoints) == null)
				{
					result = (this._TrailPoints = new TArray<FVectorDouble>(base.NativePtr + (IntPtr)S_TrailData.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.TrailPoints.CopyAssign(value);
			}
		}

		// Token: 0x170058B2 RID: 22706
		// (get) Token: 0x06026AF9 RID: 158457 RVA: 0x009DF034 File Offset: 0x009DD234
		// (set) Token: 0x06026AFA RID: 158458 RVA: 0x009DF077 File Offset: 0x009DD277
		public TArray<FVectorDouble> TrailPointsInWorld
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVectorDouble> result;
				if ((result = this._TrailPointsInWorld) == null)
				{
					result = (this._TrailPointsInWorld = new TArray<FVectorDouble>(base.NativePtr + (IntPtr)S_TrailData.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.TrailPointsInWorld.CopyAssign(value);
			}
		}

		// Token: 0x06026AFB RID: 158459 RVA: 0x009DF085 File Offset: 0x009DD285
		public S_TrailData()
		{
		}

		// Token: 0x06026AFC RID: 158460 RVA: 0x009DF08D File Offset: 0x009DD28D
		public S_TrailData(int TrailIndex, FVectorDouble TrailCentroid, FVectorDouble TrailCentroidInWorld, [Nullable(0)] TEnumAsByte<E_FreqDrawResult> TrailDrawResult, TArray<FVectorDouble> TrailPoints, TArray<FVectorDouble> TrailPointsInWorld)
		{
			this.TrailIndex = TrailIndex;
			this.TrailCentroid = TrailCentroid;
			this.TrailCentroidInWorld = TrailCentroidInWorld;
			this.TrailDrawResult = TrailDrawResult;
			this.TrailPoints = TrailPoints;
			this.TrailPointsInWorld = TrailPointsInWorld;
		}

		// Token: 0x06026AFD RID: 158461 RVA: 0x009DF0C2 File Offset: 0x009DD2C2
		protected override IntPtr GetUStructPtr()
		{
			return S_TrailData.StaticStruct();
		}

		// Token: 0x06026AFE RID: 158462 RVA: 0x009DF0CE File Offset: 0x009DD2CE
		[NullableContext(2)]
		public S_TrailData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026AFF RID: 158463 RVA: 0x009DF0D8 File Offset: 0x009DD2D8
		public S_TrailData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026B00 RID: 158464 RVA: 0x009DF0E3 File Offset: 0x009DD2E3
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new S_TrailData(Pointer, false, true);
		}

		// Token: 0x06026B01 RID: 158465 RVA: 0x009DF0ED File Offset: 0x009DD2ED
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new S_TrailData(Pointer, MemoryOwner);
		}

		// Token: 0x040142AB RID: 82603
		public const string __ObjectPath = "/Game/Aki/Map/CopyPrototypeTest/TestMap/4_1_FrequencyBrush_Test/Data/S_TrailData.S_TrailData";

		// Token: 0x040142AC RID: 82604
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040142AD RID: 82605
		internal static int __PropertyOffset_0;

		// Token: 0x040142AE RID: 82606
		internal static int __PropertyOffset_1;

		// Token: 0x040142AF RID: 82607
		internal static int __PropertyOffset_2;

		// Token: 0x040142B0 RID: 82608
		internal static int __PropertyOffset_3;

		// Token: 0x040142B1 RID: 82609
		internal static int __PropertyOffset_4;

		// Token: 0x040142B2 RID: 82610
		[Nullable(2)]
		private TArray<FVectorDouble> _TrailPoints;

		// Token: 0x040142B3 RID: 82611
		internal static int __PropertyOffset_5;

		// Token: 0x040142B4 RID: 82612
		[Nullable(2)]
		private TArray<FVectorDouble> _TrailPointsInWorld;
	}
}
