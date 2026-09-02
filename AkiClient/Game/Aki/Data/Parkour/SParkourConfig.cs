using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Parkour
{
	// Token: 0x02003E58 RID: 15960
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Parkour/SParkourConfig.SParkourConfig")]
	[UnrealStructLayout(240, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 240)]
	public class SParkourConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602764A RID: 161354 RVA: 0x009F0D70 File Offset: 0x009EEF70
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SParkourConfig._ScriptStructPtr != 0) ? SParkourConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Parkour/SParkourConfig.SParkourConfig", ref SParkourConfig._ScriptStructPtr);
		}

		// Token: 0x17005C89 RID: 23689
		// (get) Token: 0x0602764B RID: 161355 RVA: 0x009F0D94 File Offset: 0x009EEF94
		// (set) Token: 0x0602764C RID: 161356 RVA: 0x009F0DA8 File Offset: 0x009EEFA8
		public unsafe FName ConfigName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005C8A RID: 23690
		// (get) Token: 0x0602764D RID: 161357 RVA: 0x009F0DBD File Offset: 0x009EEFBD
		// (set) Token: 0x0602764E RID: 161358 RVA: 0x009F0DCD File Offset: 0x009EEFCD
		public unsafe bool IstoStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C8B RID: 23691
		// (get) Token: 0x0602764F RID: 161359 RVA: 0x009F0DDE File Offset: 0x009EEFDE
		// (set) Token: 0x06027650 RID: 161360 RVA: 0x009F0DEE File Offset: 0x009EEFEE
		public unsafe bool IsRequireToEnd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C8C RID: 23692
		// (get) Token: 0x06027651 RID: 161361 RVA: 0x009F0E00 File Offset: 0x009EF000
		// (set) Token: 0x06027652 RID: 161362 RVA: 0x009F0E43 File Offset: 0x009EF043
		public TArray<SParkourPointInfo> ParkourPoints
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SParkourPointInfo> result;
				if ((result = this._ParkourPoints) == null)
				{
					result = (this._ParkourPoints = new TArray<SParkourPointInfo>(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ParkourPoints.CopyAssign(value);
			}
		}

		// Token: 0x17005C8D RID: 23693
		// (get) Token: 0x06027653 RID: 161363 RVA: 0x009F0E51 File Offset: 0x009EF051
		// (set) Token: 0x06027654 RID: 161364 RVA: 0x009F0E61 File Offset: 0x009EF061
		public unsafe int CheckPointsRequire
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005C8E RID: 23694
		// (get) Token: 0x06027655 RID: 161365 RVA: 0x009F0E72 File Offset: 0x009EF072
		// (set) Token: 0x06027656 RID: 161366 RVA: 0x009F0E91 File Offset: 0x009EF091
		public TSoftObjectPtr<UEffectModelBase> CheckPointResource
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_5, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_5, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005C8F RID: 23695
		// (get) Token: 0x06027657 RID: 161367 RVA: 0x009F0EB6 File Offset: 0x009EF0B6
		// (set) Token: 0x06027658 RID: 161368 RVA: 0x009F0ED5 File Offset: 0x009EF0D5
		public TSoftObjectPtr<UEffectModelBase> CheckPointsDestroyRes
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_6, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_6, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005C90 RID: 23696
		// (get) Token: 0x06027659 RID: 161369 RVA: 0x009F0EFA File Offset: 0x009EF0FA
		// (set) Token: 0x0602765A RID: 161370 RVA: 0x009F0F19 File Offset: 0x009EF119
		public TSoftObjectPtr<UEffectModelBase> StartResource
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_7, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_7, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005C91 RID: 23697
		// (get) Token: 0x0602765B RID: 161371 RVA: 0x009F0F3E File Offset: 0x009EF13E
		// (set) Token: 0x0602765C RID: 161372 RVA: 0x009F0F5D File Offset: 0x009EF15D
		public TSoftObjectPtr<UEffectModelBase> EndResource
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_8, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_8, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005C92 RID: 23698
		// (get) Token: 0x0602765D RID: 161373 RVA: 0x009F0F82 File Offset: 0x009EF182
		// (set) Token: 0x0602765E RID: 161374 RVA: 0x009F0F92 File Offset: 0x009EF192
		public unsafe float DefaultBuffId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005C93 RID: 23699
		// (get) Token: 0x0602765F RID: 161375 RVA: 0x009F0FA3 File Offset: 0x009EF1A3
		// (set) Token: 0x06027660 RID: 161376 RVA: 0x009F0FB3 File Offset: 0x009EF1B3
		public unsafe float DefaultModifiedTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SParkourConfig.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x06027661 RID: 161377 RVA: 0x009F0FC4 File Offset: 0x009EF1C4
		public SParkourConfig()
		{
		}

		// Token: 0x06027662 RID: 161378 RVA: 0x009F0FCC File Offset: 0x009EF1CC
		public SParkourConfig(FName ConfigName, bool IstoStart, bool IsRequireToEnd, TArray<SParkourPointInfo> ParkourPoints, int CheckPointsRequire, TSoftObjectPtr<UEffectModelBase> CheckPointResource, TSoftObjectPtr<UEffectModelBase> CheckPointsDestroyRes, TSoftObjectPtr<UEffectModelBase> StartResource, TSoftObjectPtr<UEffectModelBase> EndResource, float DefaultBuffId, float DefaultModifiedTime)
		{
			this.ConfigName = ConfigName;
			this.IstoStart = IstoStart;
			this.IsRequireToEnd = IsRequireToEnd;
			this.ParkourPoints = ParkourPoints;
			this.CheckPointsRequire = CheckPointsRequire;
			this.CheckPointResource = CheckPointResource;
			this.CheckPointsDestroyRes = CheckPointsDestroyRes;
			this.StartResource = StartResource;
			this.EndResource = EndResource;
			this.DefaultBuffId = DefaultBuffId;
			this.DefaultModifiedTime = DefaultModifiedTime;
		}

		// Token: 0x06027663 RID: 161379 RVA: 0x009F1034 File Offset: 0x009EF234
		protected override IntPtr GetUStructPtr()
		{
			return SParkourConfig.StaticStruct();
		}

		// Token: 0x06027664 RID: 161380 RVA: 0x009F1040 File Offset: 0x009EF240
		[NullableContext(2)]
		public SParkourConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027665 RID: 161381 RVA: 0x009F104A File Offset: 0x009EF24A
		public SParkourConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027666 RID: 161382 RVA: 0x009F1055 File Offset: 0x009EF255
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SParkourConfig(Pointer, false, true);
		}

		// Token: 0x06027667 RID: 161383 RVA: 0x009F105F File Offset: 0x009EF25F
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SParkourConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04014A03 RID: 84483
		public const string __ObjectPath = "/Game/Aki/Data/Parkour/SParkourConfig.SParkourConfig";

		// Token: 0x04014A04 RID: 84484
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014A05 RID: 84485
		internal static int __PropertyOffset_0;

		// Token: 0x04014A06 RID: 84486
		internal static int __PropertyOffset_1;

		// Token: 0x04014A07 RID: 84487
		internal static int __PropertyOffset_2;

		// Token: 0x04014A08 RID: 84488
		internal static int __PropertyOffset_3;

		// Token: 0x04014A09 RID: 84489
		[Nullable(2)]
		private TArray<SParkourPointInfo> _ParkourPoints;

		// Token: 0x04014A0A RID: 84490
		internal static int __PropertyOffset_4;

		// Token: 0x04014A0B RID: 84491
		internal static int __PropertyOffset_5;

		// Token: 0x04014A0C RID: 84492
		internal static int __PropertyOffset_6;

		// Token: 0x04014A0D RID: 84493
		internal static int __PropertyOffset_7;

		// Token: 0x04014A0E RID: 84494
		internal static int __PropertyOffset_8;

		// Token: 0x04014A0F RID: 84495
		internal static int __PropertyOffset_9;

		// Token: 0x04014A10 RID: 84496
		internal static int __PropertyOffset_10;
	}
}
