using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E49 RID: 15945
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Qte/SCommonQte_Extra.SCommonQte_Extra")]
	[UnrealStructLayout(264, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 264)]
	public class SCommonQte_Extra : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027521 RID: 161057 RVA: 0x009EF0AC File Offset: 0x009ED2AC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCommonQte_Extra._ScriptStructPtr != 0) ? SCommonQte_Extra._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Qte/SCommonQte_Extra.SCommonQte_Extra", ref SCommonQte_Extra._ScriptStructPtr);
		}

		// Token: 0x17005C35 RID: 23605
		// (get) Token: 0x06027522 RID: 161058 RVA: 0x009EF0D0 File Offset: 0x009ED2D0
		// (set) Token: 0x06027523 RID: 161059 RVA: 0x009EF0E0 File Offset: 0x009ED2E0
		public unsafe bool IsBlockFightInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Extra.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Extra.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C36 RID: 23606
		// (get) Token: 0x06027524 RID: 161060 RVA: 0x009EF0F1 File Offset: 0x009ED2F1
		// (set) Token: 0x06027525 RID: 161061 RVA: 0x009EF101 File Offset: 0x009ED301
		public unsafe bool HideAllBattleUi
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Extra.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Extra.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C37 RID: 23607
		// (get) Token: 0x06027526 RID: 161062 RVA: 0x009EF114 File Offset: 0x009ED314
		// (set) Token: 0x06027527 RID: 161063 RVA: 0x009EF157 File Offset: 0x009ED357
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
					result = (this._HideUIElement = new TArray<TEnumAsByte<EBattleUIChild>>(base.NativePtr + (IntPtr)SCommonQte_Extra.__PropertyOffset_2, base.MemoryOwner ?? this));
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

		// Token: 0x17005C38 RID: 23608
		// (get) Token: 0x06027528 RID: 161064 RVA: 0x009EF165 File Offset: 0x009ED365
		// (set) Token: 0x06027529 RID: 161065 RVA: 0x009EF184 File Offset: 0x009ED384
		public TSoftObjectPtr<EffectScreenPlayData_C> ScreenEffectType1
		{
			get
			{
				return new TSoftObjectPtr<EffectScreenPlayData_C>(base.NativePtr + (IntPtr)SCommonQte_Extra.__PropertyOffset_3, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCommonQte_Extra.__PropertyOffset_3, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005C39 RID: 23609
		// (get) Token: 0x0602752A RID: 161066 RVA: 0x009EF1A9 File Offset: 0x009ED3A9
		// (set) Token: 0x0602752B RID: 161067 RVA: 0x009EF1C8 File Offset: 0x009ED3C8
		public TSoftObjectPtr<EffectModelPostProcess> ScreenEffectType2
		{
			get
			{
				return new TSoftObjectPtr<EffectModelPostProcess>(base.NativePtr + (IntPtr)SCommonQte_Extra.__PropertyOffset_4, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCommonQte_Extra.__PropertyOffset_4, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005C3A RID: 23610
		// (get) Token: 0x0602752C RID: 161068 RVA: 0x009EF1ED File Offset: 0x009ED3ED
		// (set) Token: 0x0602752D RID: 161069 RVA: 0x009EF20C File Offset: 0x009ED40C
		public TSoftClassPtr<UMatineeCameraShake> CameraShake
		{
			get
			{
				return new TSoftClassPtr<UMatineeCameraShake>(base.NativePtr + (IntPtr)SCommonQte_Extra.__PropertyOffset_5, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCommonQte_Extra.__PropertyOffset_5, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005C3B RID: 23611
		// (get) Token: 0x0602752E RID: 161070 RVA: 0x009EF231 File Offset: 0x009ED431
		// (set) Token: 0x0602752F RID: 161071 RVA: 0x009EF250 File Offset: 0x009ED450
		public TSoftObjectPtr<UKuroForceFeedbackEffect> GamepadShake
		{
			get
			{
				return new TSoftObjectPtr<UKuroForceFeedbackEffect>(base.NativePtr + (IntPtr)SCommonQte_Extra.__PropertyOffset_6, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCommonQte_Extra.__PropertyOffset_6, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005C3C RID: 23612
		// (get) Token: 0x06027530 RID: 161072 RVA: 0x009EF275 File Offset: 0x009ED475
		// (set) Token: 0x06027531 RID: 161073 RVA: 0x009EF294 File Offset: 0x009ED494
		public TSoftObjectPtr<UCurveFloat> UiScaleCurve
		{
			get
			{
				return new TSoftObjectPtr<UCurveFloat>(base.NativePtr + (IntPtr)SCommonQte_Extra.__PropertyOffset_7, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCommonQte_Extra.__PropertyOffset_7, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x06027532 RID: 161074 RVA: 0x009EF2B9 File Offset: 0x009ED4B9
		public SCommonQte_Extra()
		{
		}

		// Token: 0x06027533 RID: 161075 RVA: 0x009EF2C4 File Offset: 0x009ED4C4
		public SCommonQte_Extra(bool IsBlockFightInput, bool HideAllBattleUi, [Nullable(new byte[]
		{
			1,
			0
		})] TArray<TEnumAsByte<EBattleUIChild>> HideUIElement, TSoftObjectPtr<EffectScreenPlayData_C> ScreenEffectType1, TSoftObjectPtr<EffectModelPostProcess> ScreenEffectType2, TSoftClassPtr<UMatineeCameraShake> CameraShake, TSoftObjectPtr<UKuroForceFeedbackEffect> GamepadShake, TSoftObjectPtr<UCurveFloat> UiScaleCurve)
		{
			this.IsBlockFightInput = IsBlockFightInput;
			this.HideAllBattleUi = HideAllBattleUi;
			this.HideUIElement = HideUIElement;
			this.ScreenEffectType1 = ScreenEffectType1;
			this.ScreenEffectType2 = ScreenEffectType2;
			this.CameraShake = CameraShake;
			this.GamepadShake = GamepadShake;
			this.UiScaleCurve = UiScaleCurve;
		}

		// Token: 0x06027534 RID: 161076 RVA: 0x009EF314 File Offset: 0x009ED514
		protected override IntPtr GetUStructPtr()
		{
			return SCommonQte_Extra.StaticStruct();
		}

		// Token: 0x06027535 RID: 161077 RVA: 0x009EF320 File Offset: 0x009ED520
		[NullableContext(2)]
		public SCommonQte_Extra(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027536 RID: 161078 RVA: 0x009EF32A File Offset: 0x009ED52A
		public SCommonQte_Extra(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027537 RID: 161079 RVA: 0x009EF335 File Offset: 0x009ED535
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCommonQte_Extra(Pointer, false, true);
		}

		// Token: 0x06027538 RID: 161080 RVA: 0x009EF33F File Offset: 0x009ED53F
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCommonQte_Extra(Pointer, MemoryOwner);
		}

		// Token: 0x04014960 RID: 84320
		public const string __ObjectPath = "/Game/Aki/Data/Qte/SCommonQte_Extra.SCommonQte_Extra";

		// Token: 0x04014961 RID: 84321
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014962 RID: 84322
		internal static int __PropertyOffset_0;

		// Token: 0x04014963 RID: 84323
		internal static int __PropertyOffset_1;

		// Token: 0x04014964 RID: 84324
		internal static int __PropertyOffset_2;

		// Token: 0x04014965 RID: 84325
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EBattleUIChild>> _HideUIElement;

		// Token: 0x04014966 RID: 84326
		internal static int __PropertyOffset_3;

		// Token: 0x04014967 RID: 84327
		internal static int __PropertyOffset_4;

		// Token: 0x04014968 RID: 84328
		internal static int __PropertyOffset_5;

		// Token: 0x04014969 RID: 84329
		internal static int __PropertyOffset_6;

		// Token: 0x0401496A RID: 84330
		internal static int __PropertyOffset_7;
	}
}
