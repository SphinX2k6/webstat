using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Gameplay.ZoneFollowCamera
{
	// Token: 0x02003E93 RID: 16019
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/ZoneFollowCamera/SZoneFollowCameraSettings.SZoneFollowCameraSettings")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class SZoneFollowCameraSettings : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027AF4 RID: 162548 RVA: 0x009F8017 File Offset: 0x009F6217
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SZoneFollowCameraSettings._ScriptStructPtr != 0) ? SZoneFollowCameraSettings._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/ZoneFollowCamera/SZoneFollowCameraSettings.SZoneFollowCameraSettings", ref SZoneFollowCameraSettings._ScriptStructPtr);
		}

		// Token: 0x17005E45 RID: 24133
		// (get) Token: 0x06027AF5 RID: 162549 RVA: 0x009F803B File Offset: 0x009F623B
		// (set) Token: 0x06027AF6 RID: 162550 RVA: 0x009F804B File Offset: 0x009F624B
		public unsafe float LerpSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SZoneFollowCameraSettings.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SZoneFollowCameraSettings.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005E46 RID: 24134
		// (get) Token: 0x06027AF7 RID: 162551 RVA: 0x009F805C File Offset: 0x009F625C
		// (set) Token: 0x06027AF8 RID: 162552 RVA: 0x009F806C File Offset: 0x009F626C
		public unsafe float CameraFov
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SZoneFollowCameraSettings.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SZoneFollowCameraSettings.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005E47 RID: 24135
		// (get) Token: 0x06027AF9 RID: 162553 RVA: 0x009F8080 File Offset: 0x009F6280
		// (set) Token: 0x06027AFA RID: 162554 RVA: 0x009F80C3 File Offset: 0x009F62C3
		public TArray<SZoneFollowCameraZoneSetting> ZoneConfigs
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SZoneFollowCameraZoneSetting> result;
				if ((result = this._ZoneConfigs) == null)
				{
					result = (this._ZoneConfigs = new TArray<SZoneFollowCameraZoneSetting>(base.NativePtr + (IntPtr)SZoneFollowCameraSettings.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ZoneConfigs.CopyAssign(value);
			}
		}

		// Token: 0x17005E48 RID: 24136
		// (get) Token: 0x06027AFB RID: 162555 RVA: 0x009F80D1 File Offset: 0x009F62D1
		// (set) Token: 0x06027AFC RID: 162556 RVA: 0x009F80E5 File Offset: 0x009F62E5
		public unsafe FVector DefaultCameraOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SZoneFollowCameraSettings.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SZoneFollowCameraSettings.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005E49 RID: 24137
		// (get) Token: 0x06027AFD RID: 162557 RVA: 0x009F80FA File Offset: 0x009F62FA
		// (set) Token: 0x06027AFE RID: 162558 RVA: 0x009F810E File Offset: 0x009F630E
		public unsafe FRotator DefaultCameraRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SZoneFollowCameraSettings.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SZoneFollowCameraSettings.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x06027AFF RID: 162559 RVA: 0x009F8123 File Offset: 0x009F6323
		public SZoneFollowCameraSettings()
		{
		}

		// Token: 0x06027B00 RID: 162560 RVA: 0x009F812B File Offset: 0x009F632B
		public SZoneFollowCameraSettings(float LerpSpeed, float CameraFov, TArray<SZoneFollowCameraZoneSetting> ZoneConfigs, FVector DefaultCameraOffset, FRotator DefaultCameraRotation)
		{
			this.LerpSpeed = LerpSpeed;
			this.CameraFov = CameraFov;
			this.ZoneConfigs = ZoneConfigs;
			this.DefaultCameraOffset = DefaultCameraOffset;
			this.DefaultCameraRotation = DefaultCameraRotation;
		}

		// Token: 0x06027B01 RID: 162561 RVA: 0x009F8158 File Offset: 0x009F6358
		protected override IntPtr GetUStructPtr()
		{
			return SZoneFollowCameraSettings.StaticStruct();
		}

		// Token: 0x06027B02 RID: 162562 RVA: 0x009F8164 File Offset: 0x009F6364
		[NullableContext(2)]
		public SZoneFollowCameraSettings(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027B03 RID: 162563 RVA: 0x009F816E File Offset: 0x009F636E
		public SZoneFollowCameraSettings(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027B04 RID: 162564 RVA: 0x009F8179 File Offset: 0x009F6379
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SZoneFollowCameraSettings(Pointer, false, true);
		}

		// Token: 0x06027B05 RID: 162565 RVA: 0x009F8183 File Offset: 0x009F6383
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SZoneFollowCameraSettings(Pointer, MemoryOwner);
		}

		// Token: 0x04014D0A RID: 85258
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/ZoneFollowCamera/SZoneFollowCameraSettings.SZoneFollowCameraSettings";

		// Token: 0x04014D0B RID: 85259
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014D0C RID: 85260
		internal static int __PropertyOffset_0;

		// Token: 0x04014D0D RID: 85261
		internal static int __PropertyOffset_1;

		// Token: 0x04014D0E RID: 85262
		internal static int __PropertyOffset_2;

		// Token: 0x04014D0F RID: 85263
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SZoneFollowCameraZoneSetting> _ZoneConfigs;

		// Token: 0x04014D10 RID: 85264
		internal static int __PropertyOffset_3;

		// Token: 0x04014D11 RID: 85265
		internal static int __PropertyOffset_4;
	}
}
