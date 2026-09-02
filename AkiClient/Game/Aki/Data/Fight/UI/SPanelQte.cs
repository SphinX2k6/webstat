using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.UI
{
	// Token: 0x02003EBE RID: 16062
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/UI/SPanelQte.SPanelQte")]
	[UnrealStructLayout(200, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 200)]
	public class SPanelQte : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027E11 RID: 163345 RVA: 0x009FCEA4 File Offset: 0x009FB0A4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SPanelQte._ScriptStructPtr != 0) ? SPanelQte._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/UI/SPanelQte.SPanelQte", ref SPanelQte._ScriptStructPtr);
		}

		// Token: 0x17005F4F RID: 24399
		// (get) Token: 0x06027E12 RID: 163346 RVA: 0x009FCEC8 File Offset: 0x009FB0C8
		// (set) Token: 0x06027E13 RID: 163347 RVA: 0x009FCEDC File Offset: 0x009FB0DC
		[Nullable(0)]
		public unsafe TEnumAsByte<EPanelQteViewType> ViewType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_0);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005F50 RID: 24400
		// (get) Token: 0x06027E14 RID: 163348 RVA: 0x009FCEF1 File Offset: 0x009FB0F1
		// (set) Token: 0x06027E15 RID: 163349 RVA: 0x009FCF01 File Offset: 0x009FB101
		public unsafe float Duration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005F51 RID: 24401
		// (get) Token: 0x06027E16 RID: 163350 RVA: 0x009FCF12 File Offset: 0x009FB112
		// (set) Token: 0x06027E17 RID: 163351 RVA: 0x009FCF22 File Offset: 0x009FB122
		public unsafe float WorldTimeDilation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005F52 RID: 24402
		// (get) Token: 0x06027E18 RID: 163352 RVA: 0x009FCF33 File Offset: 0x009FB133
		// (set) Token: 0x06027E19 RID: 163353 RVA: 0x009FCF43 File Offset: 0x009FB143
		public unsafe int MinSuccessCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005F53 RID: 24403
		// (get) Token: 0x06027E1A RID: 163354 RVA: 0x009FCF54 File Offset: 0x009FB154
		// (set) Token: 0x06027E1B RID: 163355 RVA: 0x009FCF64 File Offset: 0x009FB164
		public unsafe int MaxSuccessCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005F54 RID: 24404
		// (get) Token: 0x06027E1C RID: 163356 RVA: 0x009FCF75 File Offset: 0x009FB175
		// (set) Token: 0x06027E1D RID: 163357 RVA: 0x009FCF85 File Offset: 0x009FB185
		public unsafe bool HideAllBattleUi
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005F55 RID: 24405
		// (get) Token: 0x06027E1E RID: 163358 RVA: 0x009FCF98 File Offset: 0x009FB198
		// (set) Token: 0x06027E1F RID: 163359 RVA: 0x009FCFDB File Offset: 0x009FB1DB
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EBattleUIChild>> HideUIElement
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EBattleUIChild>> result;
				if ((result = this._HideUIElement) == null)
				{
					result = (this._HideUIElement = new TArray<TEnumAsByte<EBattleUIChild>>(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_6, base.MemoryOwner ?? this));
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
				this.HideUIElement.CopyAssign(value);
			}
		}

		// Token: 0x17005F56 RID: 24406
		// (get) Token: 0x06027E20 RID: 163360 RVA: 0x009FCFEC File Offset: 0x009FB1EC
		// (set) Token: 0x06027E21 RID: 163361 RVA: 0x009FD02F File Offset: 0x009FB22F
		public TArray<SPanelQteAction> SuccessActions
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SPanelQteAction> result;
				if ((result = this._SuccessActions) == null)
				{
					result = (this._SuccessActions = new TArray<SPanelQteAction>(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SuccessActions.CopyAssign(value);
			}
		}

		// Token: 0x17005F57 RID: 24407
		// (get) Token: 0x06027E22 RID: 163362 RVA: 0x009FD040 File Offset: 0x009FB240
		// (set) Token: 0x06027E23 RID: 163363 RVA: 0x009FD083 File Offset: 0x009FB283
		public TArray<SPanelQteAction> FailActions
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SPanelQteAction> result;
				if ((result = this._FailActions) == null)
				{
					result = (this._FailActions = new TArray<SPanelQteAction>(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.FailActions.CopyAssign(value);
			}
		}

		// Token: 0x17005F58 RID: 24408
		// (get) Token: 0x06027E24 RID: 163364 RVA: 0x009FD091 File Offset: 0x009FB291
		// (set) Token: 0x06027E25 RID: 163365 RVA: 0x009FD0A1 File Offset: 0x009FB2A1
		public unsafe long BuffOnInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005F59 RID: 24409
		// (get) Token: 0x06027E26 RID: 163366 RVA: 0x009FD0B2 File Offset: 0x009FB2B2
		// (set) Token: 0x06027E27 RID: 163367 RVA: 0x009FD0C2 File Offset: 0x009FB2C2
		public unsafe float BuffCd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005F5A RID: 24410
		// (get) Token: 0x06027E28 RID: 163368 RVA: 0x009FD0D3 File Offset: 0x009FB2D3
		// (set) Token: 0x06027E29 RID: 163369 RVA: 0x009FD0E3 File Offset: 0x009FB2E3
		public unsafe bool CameraShakeOnInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005F5B RID: 24411
		// (get) Token: 0x06027E2A RID: 163370 RVA: 0x009FD0F4 File Offset: 0x009FB2F4
		// (set) Token: 0x06027E2B RID: 163371 RVA: 0x009FD113 File Offset: 0x009FB313
		public TSoftClassPtr<UMatineeCameraShake> CameraShakeType
		{
			get
			{
				return new TSoftClassPtr<UMatineeCameraShake>(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_12, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_12, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005F5C RID: 24412
		// (get) Token: 0x06027E2C RID: 163372 RVA: 0x009FD138 File Offset: 0x009FB338
		// (set) Token: 0x06027E2D RID: 163373 RVA: 0x009FD14C File Offset: 0x009FB34C
		public unsafe string Action
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SPanelQte.__PropertyOffset_13)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SPanelQte.__PropertyOffset_13)), value);
			}
		}

		// Token: 0x17005F5D RID: 24413
		// (get) Token: 0x06027E2E RID: 163374 RVA: 0x009FD161 File Offset: 0x009FB361
		// (set) Token: 0x06027E2F RID: 163375 RVA: 0x009FD180 File Offset: 0x009FB380
		public TSoftObjectPtr<ULGUITexturePackerSpriteData> Icon
		{
			get
			{
				return new TSoftObjectPtr<ULGUITexturePackerSpriteData>(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_14, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SPanelQte.__PropertyOffset_14, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x06027E30 RID: 163376 RVA: 0x009FD1A5 File Offset: 0x009FB3A5
		public SPanelQte()
		{
		}

		// Token: 0x06027E31 RID: 163377 RVA: 0x009FD1B0 File Offset: 0x009FB3B0
		public SPanelQte([Nullable(0)] TEnumAsByte<EPanelQteViewType> ViewType, float Duration, float WorldTimeDilation, int MinSuccessCount, int MaxSuccessCount, bool HideAllBattleUi, [Nullable(new byte[]
		{
			1,
			0
		})] TArray<TEnumAsByte<EBattleUIChild>> HideUIElement, TArray<SPanelQteAction> SuccessActions, TArray<SPanelQteAction> FailActions, long BuffOnInput, float BuffCd, bool CameraShakeOnInput, TSoftClassPtr<UMatineeCameraShake> CameraShakeType, string Action, TSoftObjectPtr<ULGUITexturePackerSpriteData> Icon)
		{
			this.ViewType = ViewType;
			this.Duration = Duration;
			this.WorldTimeDilation = WorldTimeDilation;
			this.MinSuccessCount = MinSuccessCount;
			this.MaxSuccessCount = MaxSuccessCount;
			this.HideAllBattleUi = HideAllBattleUi;
			this.HideUIElement = HideUIElement;
			this.SuccessActions = SuccessActions;
			this.FailActions = FailActions;
			this.BuffOnInput = BuffOnInput;
			this.BuffCd = BuffCd;
			this.CameraShakeOnInput = CameraShakeOnInput;
			this.CameraShakeType = CameraShakeType;
			this.Action = Action;
			this.Icon = Icon;
		}

		// Token: 0x06027E32 RID: 163378 RVA: 0x009FD238 File Offset: 0x009FB438
		protected override IntPtr GetUStructPtr()
		{
			return SPanelQte.StaticStruct();
		}

		// Token: 0x06027E33 RID: 163379 RVA: 0x009FD244 File Offset: 0x009FB444
		[NullableContext(2)]
		public SPanelQte(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027E34 RID: 163380 RVA: 0x009FD24E File Offset: 0x009FB44E
		public SPanelQte(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027E35 RID: 163381 RVA: 0x009FD259 File Offset: 0x009FB459
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SPanelQte(Pointer, false, true);
		}

		// Token: 0x06027E36 RID: 163382 RVA: 0x009FD263 File Offset: 0x009FB463
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SPanelQte(Pointer, MemoryOwner);
		}

		// Token: 0x04014EF5 RID: 85749
		public const string __ObjectPath = "/Game/Aki/Data/Fight/UI/SPanelQte.SPanelQte";

		// Token: 0x04014EF6 RID: 85750
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014EF7 RID: 85751
		internal static int __PropertyOffset_0;

		// Token: 0x04014EF8 RID: 85752
		internal static int __PropertyOffset_1;

		// Token: 0x04014EF9 RID: 85753
		internal static int __PropertyOffset_2;

		// Token: 0x04014EFA RID: 85754
		internal static int __PropertyOffset_3;

		// Token: 0x04014EFB RID: 85755
		internal static int __PropertyOffset_4;

		// Token: 0x04014EFC RID: 85756
		internal static int __PropertyOffset_5;

		// Token: 0x04014EFD RID: 85757
		internal static int __PropertyOffset_6;

		// Token: 0x04014EFE RID: 85758
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EBattleUIChild>> _HideUIElement;

		// Token: 0x04014EFF RID: 85759
		internal static int __PropertyOffset_7;

		// Token: 0x04014F00 RID: 85760
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SPanelQteAction> _SuccessActions;

		// Token: 0x04014F01 RID: 85761
		internal static int __PropertyOffset_8;

		// Token: 0x04014F02 RID: 85762
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SPanelQteAction> _FailActions;

		// Token: 0x04014F03 RID: 85763
		internal static int __PropertyOffset_9;

		// Token: 0x04014F04 RID: 85764
		internal static int __PropertyOffset_10;

		// Token: 0x04014F05 RID: 85765
		internal static int __PropertyOffset_11;

		// Token: 0x04014F06 RID: 85766
		internal static int __PropertyOffset_12;

		// Token: 0x04014F07 RID: 85767
		internal static int __PropertyOffset_13;

		// Token: 0x04014F08 RID: 85768
		internal static int __PropertyOffset_14;
	}
}
