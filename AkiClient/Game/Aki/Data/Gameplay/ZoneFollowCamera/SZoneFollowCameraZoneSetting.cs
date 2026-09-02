using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Gameplay.ZoneFollowCamera
{
	// Token: 0x02003E94 RID: 16020
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/ZoneFollowCamera/SZoneFollowCameraZoneSetting.SZoneFollowCameraZoneSetting")]
	[UnrealStructLayout(112, 16, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 108)]
	public class SZoneFollowCameraZoneSetting : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027B06 RID: 162566 RVA: 0x009F818C File Offset: 0x009F638C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SZoneFollowCameraZoneSetting._ScriptStructPtr != 0) ? SZoneFollowCameraZoneSetting._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/ZoneFollowCamera/SZoneFollowCameraZoneSetting.SZoneFollowCameraZoneSetting", ref SZoneFollowCameraZoneSetting._ScriptStructPtr);
		}

		// Token: 0x17005E4A RID: 24138
		// (get) Token: 0x06027B07 RID: 162567 RVA: 0x009F81B0 File Offset: 0x009F63B0
		// (set) Token: 0x06027B08 RID: 162568 RVA: 0x009F81C4 File Offset: 0x009F63C4
		public unsafe FTransform BoxTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SZoneFollowCameraZoneSetting.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SZoneFollowCameraZoneSetting.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005E4B RID: 24139
		// (get) Token: 0x06027B09 RID: 162569 RVA: 0x009F81D9 File Offset: 0x009F63D9
		// (set) Token: 0x06027B0A RID: 162570 RVA: 0x009F81ED File Offset: 0x009F63ED
		public unsafe FVector BoxExtend
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SZoneFollowCameraZoneSetting.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SZoneFollowCameraZoneSetting.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005E4C RID: 24140
		// (get) Token: 0x06027B0B RID: 162571 RVA: 0x009F8202 File Offset: 0x009F6402
		// (set) Token: 0x06027B0C RID: 162572 RVA: 0x009F8216 File Offset: 0x009F6416
		public unsafe FVector CenterPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SZoneFollowCameraZoneSetting.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SZoneFollowCameraZoneSetting.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005E4D RID: 24141
		// (get) Token: 0x06027B0D RID: 162573 RVA: 0x009F822B File Offset: 0x009F642B
		// (set) Token: 0x06027B0E RID: 162574 RVA: 0x009F823F File Offset: 0x009F643F
		public unsafe FVector CameraOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SZoneFollowCameraZoneSetting.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SZoneFollowCameraZoneSetting.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005E4E RID: 24142
		// (get) Token: 0x06027B0F RID: 162575 RVA: 0x009F8254 File Offset: 0x009F6454
		// (set) Token: 0x06027B10 RID: 162576 RVA: 0x009F8268 File Offset: 0x009F6468
		public unsafe FRotator CameraRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SZoneFollowCameraZoneSetting.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SZoneFollowCameraZoneSetting.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005E4F RID: 24143
		// (get) Token: 0x06027B11 RID: 162577 RVA: 0x009F827D File Offset: 0x009F647D
		// (set) Token: 0x06027B12 RID: 162578 RVA: 0x009F8291 File Offset: 0x009F6491
		public unsafe FVector CameraOffsetAlpha
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SZoneFollowCameraZoneSetting.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SZoneFollowCameraZoneSetting.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x06027B13 RID: 162579 RVA: 0x009F82A6 File Offset: 0x009F64A6
		public SZoneFollowCameraZoneSetting()
		{
		}

		// Token: 0x06027B14 RID: 162580 RVA: 0x009F82AE File Offset: 0x009F64AE
		public SZoneFollowCameraZoneSetting(FTransform BoxTransform, FVector BoxExtend, FVector CenterPosition, FVector CameraOffset, FRotator CameraRotation, FVector CameraOffsetAlpha)
		{
			this.BoxTransform = BoxTransform;
			this.BoxExtend = BoxExtend;
			this.CenterPosition = CenterPosition;
			this.CameraOffset = CameraOffset;
			this.CameraRotation = CameraRotation;
			this.CameraOffsetAlpha = CameraOffsetAlpha;
		}

		// Token: 0x06027B15 RID: 162581 RVA: 0x009F82E3 File Offset: 0x009F64E3
		protected override IntPtr GetUStructPtr()
		{
			return SZoneFollowCameraZoneSetting.StaticStruct();
		}

		// Token: 0x06027B16 RID: 162582 RVA: 0x009F82EF File Offset: 0x009F64EF
		[NullableContext(2)]
		public SZoneFollowCameraZoneSetting(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027B17 RID: 162583 RVA: 0x009F82F9 File Offset: 0x009F64F9
		public SZoneFollowCameraZoneSetting(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027B18 RID: 162584 RVA: 0x009F8304 File Offset: 0x009F6504
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SZoneFollowCameraZoneSetting(Pointer, false, true);
		}

		// Token: 0x06027B19 RID: 162585 RVA: 0x009F830E File Offset: 0x009F650E
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SZoneFollowCameraZoneSetting(Pointer, MemoryOwner);
		}

		// Token: 0x04014D12 RID: 85266
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/ZoneFollowCamera/SZoneFollowCameraZoneSetting.SZoneFollowCameraZoneSetting";

		// Token: 0x04014D13 RID: 85267
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014D14 RID: 85268
		internal static int __PropertyOffset_0;

		// Token: 0x04014D15 RID: 85269
		internal static int __PropertyOffset_1;

		// Token: 0x04014D16 RID: 85270
		internal static int __PropertyOffset_2;

		// Token: 0x04014D17 RID: 85271
		internal static int __PropertyOffset_3;

		// Token: 0x04014D18 RID: 85272
		internal static int __PropertyOffset_4;

		// Token: 0x04014D19 RID: 85273
		internal static int __PropertyOffset_5;
	}
}
