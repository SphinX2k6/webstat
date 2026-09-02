using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.QuickTimeAction
{
	// Token: 0x02003E22 RID: 15906
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/SQtaPrompt_Content.SQtaPrompt_Content")]
	[UnrealStructLayout(256, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 256)]
	public class SQtaPrompt_Content : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602733E RID: 160574 RVA: 0x009EC366 File Offset: 0x009EA566
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SQtaPrompt_Content._ScriptStructPtr != 0) ? SQtaPrompt_Content._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/QuickTimeAction/SQtaPrompt_Content.SQtaPrompt_Content", ref SQtaPrompt_Content._ScriptStructPtr);
		}

		// Token: 0x17005B99 RID: 23449
		// (get) Token: 0x0602733F RID: 160575 RVA: 0x009EC38C File Offset: 0x009EA58C
		// (set) Token: 0x06027340 RID: 160576 RVA: 0x009EC3CF File Offset: 0x009EA5CF
		public TArray<long> Cue
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._Cue) == null)
				{
					result = (this._Cue = new TArray<long>(base.NativePtr + (IntPtr)SQtaPrompt_Content.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Cue.CopyAssign(value);
			}
		}

		// Token: 0x17005B9A RID: 23450
		// (get) Token: 0x06027341 RID: 160577 RVA: 0x009EC3DD File Offset: 0x009EA5DD
		// (set) Token: 0x06027342 RID: 160578 RVA: 0x009EC3FC File Offset: 0x009EA5FC
		public TSoftObjectPtr<EffectScreenPlayData_C> ScreenEffectType1
		{
			get
			{
				return new TSoftObjectPtr<EffectScreenPlayData_C>(base.NativePtr + (IntPtr)SQtaPrompt_Content.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SQtaPrompt_Content.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005B9B RID: 23451
		// (get) Token: 0x06027343 RID: 160579 RVA: 0x009EC421 File Offset: 0x009EA621
		// (set) Token: 0x06027344 RID: 160580 RVA: 0x009EC440 File Offset: 0x009EA640
		public TSoftObjectPtr<EffectModelPostProcess> ScreenEffectType2
		{
			get
			{
				return new TSoftObjectPtr<EffectModelPostProcess>(base.NativePtr + (IntPtr)SQtaPrompt_Content.__PropertyOffset_2, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SQtaPrompt_Content.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005B9C RID: 23452
		// (get) Token: 0x06027345 RID: 160581 RVA: 0x009EC465 File Offset: 0x009EA665
		// (set) Token: 0x06027346 RID: 160582 RVA: 0x009EC484 File Offset: 0x009EA684
		public TSoftClassPtr<UMatineeCameraShake> CameraShake
		{
			get
			{
				return new TSoftClassPtr<UMatineeCameraShake>(base.NativePtr + (IntPtr)SQtaPrompt_Content.__PropertyOffset_3, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SQtaPrompt_Content.__PropertyOffset_3, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005B9D RID: 23453
		// (get) Token: 0x06027347 RID: 160583 RVA: 0x009EC4A9 File Offset: 0x009EA6A9
		// (set) Token: 0x06027348 RID: 160584 RVA: 0x009EC4C8 File Offset: 0x009EA6C8
		public TSoftObjectPtr<UKuroForceFeedbackEffect> GamepadShake
		{
			get
			{
				return new TSoftObjectPtr<UKuroForceFeedbackEffect>(base.NativePtr + (IntPtr)SQtaPrompt_Content.__PropertyOffset_4, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SQtaPrompt_Content.__PropertyOffset_4, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005B9E RID: 23454
		// (get) Token: 0x06027349 RID: 160585 RVA: 0x009EC4ED File Offset: 0x009EA6ED
		// (set) Token: 0x0602734A RID: 160586 RVA: 0x009EC50C File Offset: 0x009EA70C
		public TSoftObjectPtr<UAkAudioEvent> Audio
		{
			get
			{
				return new TSoftObjectPtr<UAkAudioEvent>(base.NativePtr + (IntPtr)SQtaPrompt_Content.__PropertyOffset_5, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SQtaPrompt_Content.__PropertyOffset_5, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x0602734B RID: 160587 RVA: 0x009EC531 File Offset: 0x009EA731
		public SQtaPrompt_Content()
		{
		}

		// Token: 0x0602734C RID: 160588 RVA: 0x009EC539 File Offset: 0x009EA739
		public SQtaPrompt_Content(TArray<long> Cue, TSoftObjectPtr<EffectScreenPlayData_C> ScreenEffectType1, TSoftObjectPtr<EffectModelPostProcess> ScreenEffectType2, TSoftClassPtr<UMatineeCameraShake> CameraShake, TSoftObjectPtr<UKuroForceFeedbackEffect> GamepadShake, TSoftObjectPtr<UAkAudioEvent> Audio)
		{
			this.Cue = Cue;
			this.ScreenEffectType1 = ScreenEffectType1;
			this.ScreenEffectType2 = ScreenEffectType2;
			this.CameraShake = CameraShake;
			this.GamepadShake = GamepadShake;
			this.Audio = Audio;
		}

		// Token: 0x0602734D RID: 160589 RVA: 0x009EC56E File Offset: 0x009EA76E
		protected override IntPtr GetUStructPtr()
		{
			return SQtaPrompt_Content.StaticStruct();
		}

		// Token: 0x0602734E RID: 160590 RVA: 0x009EC57A File Offset: 0x009EA77A
		[NullableContext(2)]
		public SQtaPrompt_Content(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602734F RID: 160591 RVA: 0x009EC584 File Offset: 0x009EA784
		public SQtaPrompt_Content(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027350 RID: 160592 RVA: 0x009EC58F File Offset: 0x009EA78F
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SQtaPrompt_Content(Pointer, false, true);
		}

		// Token: 0x06027351 RID: 160593 RVA: 0x009EC599 File Offset: 0x009EA799
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SQtaPrompt_Content(Pointer, MemoryOwner);
		}

		// Token: 0x040147EF RID: 83951
		public const string __ObjectPath = "/Game/Aki/Data/QuickTimeAction/SQtaPrompt_Content.SQtaPrompt_Content";

		// Token: 0x040147F0 RID: 83952
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040147F1 RID: 83953
		internal static int __PropertyOffset_0;

		// Token: 0x040147F2 RID: 83954
		[Nullable(2)]
		private TArray<long> _Cue;

		// Token: 0x040147F3 RID: 83955
		internal static int __PropertyOffset_1;

		// Token: 0x040147F4 RID: 83956
		internal static int __PropertyOffset_2;

		// Token: 0x040147F5 RID: 83957
		internal static int __PropertyOffset_3;

		// Token: 0x040147F6 RID: 83958
		internal static int __PropertyOffset_4;

		// Token: 0x040147F7 RID: 83959
		internal static int __PropertyOffset_5;
	}
}
