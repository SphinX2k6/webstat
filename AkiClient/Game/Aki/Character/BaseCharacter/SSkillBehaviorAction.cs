using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004277 RID: 17015
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SSkillBehaviorAction.SSkillBehaviorAction")]
	[UnrealStructLayout(840, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 836)]
	public class SSkillBehaviorAction : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D220 RID: 184864 RVA: 0x00AB832B File Offset: 0x00AB652B
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSkillBehaviorAction._ScriptStructPtr != 0) ? SSkillBehaviorAction._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SSkillBehaviorAction.SSkillBehaviorAction", ref SSkillBehaviorAction._ScriptStructPtr);
		}

		// Token: 0x17007AAD RID: 31405
		// (get) Token: 0x0602D221 RID: 184865 RVA: 0x00AB834F File Offset: 0x00AB654F
		// (set) Token: 0x0602D222 RID: 184866 RVA: 0x00AB8363 File Offset: 0x00AB6563
		public unsafe TEnumAsByte<ESkillBehaviorActionType> ActionType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007AAE RID: 31406
		// (get) Token: 0x0602D223 RID: 184867 RVA: 0x00AB8378 File Offset: 0x00AB6578
		// (set) Token: 0x0602D224 RID: 184868 RVA: 0x00AB838C File Offset: 0x00AB658C
		public unsafe TEnumAsByte<ESkillBehaviorLocationType> LocationType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007AAF RID: 31407
		// (get) Token: 0x0602D225 RID: 184869 RVA: 0x00AB83A1 File Offset: 0x00AB65A1
		// (set) Token: 0x0602D226 RID: 184870 RVA: 0x00AB83B5 File Offset: 0x00AB65B5
		[Nullable(1)]
		public unsafe string BlackboardKey
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSkillBehaviorAction.__PropertyOffset_2)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSkillBehaviorAction.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x17007AB0 RID: 31408
		// (get) Token: 0x0602D227 RID: 184871 RVA: 0x00AB83CA File Offset: 0x00AB65CA
		// (set) Token: 0x0602D228 RID: 184872 RVA: 0x00AB83DE File Offset: 0x00AB65DE
		public unsafe TEnumAsByte<ESkillBehaviorLocationForwardType> LocationForwardType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007AB1 RID: 31409
		// (get) Token: 0x0602D229 RID: 184873 RVA: 0x00AB83F3 File Offset: 0x00AB65F3
		// (set) Token: 0x0602D22A RID: 184874 RVA: 0x00AB8407 File Offset: 0x00AB6607
		public unsafe FVector LocationOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007AB2 RID: 31410
		// (get) Token: 0x0602D22B RID: 184875 RVA: 0x00AB841C File Offset: 0x00AB661C
		// (set) Token: 0x0602D22C RID: 184876 RVA: 0x00AB842C File Offset: 0x00AB662C
		public unsafe bool Restrict
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007AB3 RID: 31411
		// (get) Token: 0x0602D22D RID: 184877 RVA: 0x00AB843D File Offset: 0x00AB663D
		// (set) Token: 0x0602D22E RID: 184878 RVA: 0x00AB8451 File Offset: 0x00AB6651
		public unsafe TEnumAsByte<ESkillBehaviorRestrictType> RestrictType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007AB4 RID: 31412
		// (get) Token: 0x0602D22F RID: 184879 RVA: 0x00AB8466 File Offset: 0x00AB6666
		// (set) Token: 0x0602D230 RID: 184880 RVA: 0x00AB8476 File Offset: 0x00AB6676
		public unsafe int RestrictDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007AB5 RID: 31413
		// (get) Token: 0x0602D231 RID: 184881 RVA: 0x00AB8487 File Offset: 0x00AB6687
		// (set) Token: 0x0602D232 RID: 184882 RVA: 0x00AB8497 File Offset: 0x00AB6697
		public unsafe bool BestSpot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007AB6 RID: 31414
		// (get) Token: 0x0602D233 RID: 184883 RVA: 0x00AB84A8 File Offset: 0x00AB66A8
		// (set) Token: 0x0602D234 RID: 184884 RVA: 0x00AB84BC File Offset: 0x00AB66BC
		public unsafe TEnumAsByte<ESkillBehaviorRotationType> RotationType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007AB7 RID: 31415
		// (get) Token: 0x0602D235 RID: 184885 RVA: 0x00AB84D1 File Offset: 0x00AB66D1
		// (set) Token: 0x0602D236 RID: 184886 RVA: 0x00AB84E1 File Offset: 0x00AB66E1
		public unsafe float DirectionOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17007AB8 RID: 31416
		// (get) Token: 0x0602D237 RID: 184887 RVA: 0x00AB84F4 File Offset: 0x00AB66F4
		// (set) Token: 0x0602D238 RID: 184888 RVA: 0x00AB8537 File Offset: 0x00AB6737
		[Nullable(1)]
		public TArray<SSkillBehaviorCue> Cues
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<SSkillBehaviorCue> result;
				if ((result = this._Cues) == null)
				{
					result = (this._Cues = new TArray<SSkillBehaviorCue>(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_11, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Cues.CopyAssign(value);
			}
		}

		// Token: 0x17007AB9 RID: 31417
		// (get) Token: 0x0602D239 RID: 184889 RVA: 0x00AB8548 File Offset: 0x00AB6748
		// (set) Token: 0x0602D23A RID: 184890 RVA: 0x00AB858B File Offset: 0x00AB678B
		[Nullable(1)]
		public TArray<SSkillBehaviorBullet> Bullets
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<SSkillBehaviorBullet> result;
				if ((result = this._Bullets) == null)
				{
					result = (this._Bullets = new TArray<SSkillBehaviorBullet>(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_12, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Bullets.CopyAssign(value);
			}
		}

		// Token: 0x17007ABA RID: 31418
		// (get) Token: 0x0602D23B RID: 184891 RVA: 0x00AB8599 File Offset: 0x00AB6799
		// (set) Token: 0x0602D23C RID: 184892 RVA: 0x00AB85AD File Offset: 0x00AB67AD
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17007ABB RID: 31419
		// (get) Token: 0x0602D23D RID: 184893 RVA: 0x00AB85C2 File Offset: 0x00AB67C2
		// (set) Token: 0x0602D23E RID: 184894 RVA: 0x00AB85D2 File Offset: 0x00AB67D2
		public unsafe float Duration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17007ABC RID: 31420
		// (get) Token: 0x0602D23F RID: 184895 RVA: 0x00AB85E3 File Offset: 0x00AB67E3
		// (set) Token: 0x0602D240 RID: 184896 RVA: 0x00AB85F3 File Offset: 0x00AB67F3
		public unsafe float BlendInTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17007ABD RID: 31421
		// (get) Token: 0x0602D241 RID: 184897 RVA: 0x00AB8604 File Offset: 0x00AB6804
		// (set) Token: 0x0602D242 RID: 184898 RVA: 0x00AB8614 File Offset: 0x00AB6814
		public unsafe float BlendOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17007ABE RID: 31422
		// (get) Token: 0x0602D243 RID: 184899 RVA: 0x00AB8625 File Offset: 0x00AB6825
		// (set) Token: 0x0602D244 RID: 184900 RVA: 0x00AB8635 File Offset: 0x00AB6835
		public unsafe float BreakBlendOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17007ABF RID: 31423
		// (get) Token: 0x0602D245 RID: 184901 RVA: 0x00AB8648 File Offset: 0x00AB6848
		// (set) Token: 0x0602D246 RID: 184902 RVA: 0x00AB868B File Offset: 0x00AB688B
		[Nullable(1)]
		public SBaseCurve BlendInCurve
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SBaseCurve result;
				if ((result = this._BlendInCurve) == null)
				{
					result = (this._BlendInCurve = new SBaseCurve(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_18, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBaseCurve.StaticStruct(), base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007AC0 RID: 31424
		// (get) Token: 0x0602D247 RID: 184903 RVA: 0x00AB86AC File Offset: 0x00AB68AC
		// (set) Token: 0x0602D248 RID: 184904 RVA: 0x00AB86EF File Offset: 0x00AB68EF
		[Nullable(1)]
		public SBaseCurve BlendOutCurve
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SBaseCurve result;
				if ((result = this._BlendOutCurve) == null)
				{
					result = (this._BlendOutCurve = new SBaseCurve(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_19, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SBaseCurve.StaticStruct(), base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007AC1 RID: 31425
		// (get) Token: 0x0602D249 RID: 184905 RVA: 0x00AB8710 File Offset: 0x00AB6910
		// (set) Token: 0x0602D24A RID: 184906 RVA: 0x00AB8724 File Offset: 0x00AB6924
		public unsafe TEnumAsByte<ECameraAnsEffectiveClientType> CameraEffectiveClientType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x17007AC2 RID: 31426
		// (get) Token: 0x0602D24B RID: 184907 RVA: 0x00AB873C File Offset: 0x00AB693C
		// (set) Token: 0x0602D24C RID: 184908 RVA: 0x00AB877F File Offset: 0x00AB697F
		[Nullable(1)]
		public TArray<SCameraModifier_Condition> CameraModifierConditions
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<SCameraModifier_Condition> result;
				if ((result = this._CameraModifierConditions) == null)
				{
					result = (this._CameraModifierConditions = new TArray<SCameraModifier_Condition>(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_21, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CameraModifierConditions.CopyAssign(value);
			}
		}

		// Token: 0x17007AC3 RID: 31427
		// (get) Token: 0x0602D24D RID: 184909 RVA: 0x00AB8790 File Offset: 0x00AB6990
		// (set) Token: 0x0602D24E RID: 184910 RVA: 0x00AB87D3 File Offset: 0x00AB69D3
		[Nullable(1)]
		public SCameraModifier_Settings CameraModifierSettings
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SCameraModifier_Settings result;
				if ((result = this._CameraModifierSettings) == null)
				{
					result = (this._CameraModifierSettings = new SCameraModifier_Settings(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_22, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCameraModifier_Settings.StaticStruct(), base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007AC4 RID: 31428
		// (get) Token: 0x0602D24F RID: 184911 RVA: 0x00AB87F4 File Offset: 0x00AB69F4
		// (set) Token: 0x0602D250 RID: 184912 RVA: 0x00AB8837 File Offset: 0x00AB6A37
		[Nullable(1)]
		public SSequenceCamera_Settings CameraSequenceSettings
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SSequenceCamera_Settings result;
				if ((result = this._CameraSequenceSettings) == null)
				{
					result = (this._CameraSequenceSettings = new SSequenceCamera_Settings(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_23, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SSequenceCamera_Settings.StaticStruct(), base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007AC5 RID: 31429
		// (get) Token: 0x0602D251 RID: 184913 RVA: 0x00AB8858 File Offset: 0x00AB6A58
		// (set) Token: 0x0602D252 RID: 184914 RVA: 0x00AB8868 File Offset: 0x00AB6A68
		public unsafe bool ResetLockOnCamera
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007AC6 RID: 31430
		// (get) Token: 0x0602D253 RID: 184915 RVA: 0x00AB8879 File Offset: 0x00AB6A79
		// (set) Token: 0x0602D254 RID: 184916 RVA: 0x00AB888D File Offset: 0x00AB6A8D
		public unsafe FRotator AdditiveRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17007AC7 RID: 31431
		// (get) Token: 0x0602D255 RID: 184917 RVA: 0x00AB88A2 File Offset: 0x00AB6AA2
		// (set) Token: 0x0602D256 RID: 184918 RVA: 0x00AB88B6 File Offset: 0x00AB6AB6
		public unsafe FName CameraAttachSocket
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17007AC8 RID: 31432
		// (get) Token: 0x0602D257 RID: 184919 RVA: 0x00AB88CB File Offset: 0x00AB6ACB
		// (set) Token: 0x0602D258 RID: 184920 RVA: 0x00AB88DF File Offset: 0x00AB6ADF
		public unsafe FName CameraDetectSocket
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17007AC9 RID: 31433
		// (get) Token: 0x0602D259 RID: 184921 RVA: 0x00AB88F4 File Offset: 0x00AB6AF4
		// (set) Token: 0x0602D25A RID: 184922 RVA: 0x00AB8904 File Offset: 0x00AB6B04
		public unsafe float ExtraDetectSphereRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17007ACA RID: 31434
		// (get) Token: 0x0602D25B RID: 184923 RVA: 0x00AB8915 File Offset: 0x00AB6B15
		// (set) Token: 0x0602D25C RID: 184924 RVA: 0x00AB8929 File Offset: 0x00AB6B29
		public unsafe FVector ExtraSphereLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_29);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17007ACB RID: 31435
		// (get) Token: 0x0602D25D RID: 184925 RVA: 0x00AB893E File Offset: 0x00AB6B3E
		// (set) Token: 0x0602D25E RID: 184926 RVA: 0x00AB894E File Offset: 0x00AB6B4E
		public unsafe bool IsShowExtraSphere
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_30) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_30) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007ACC RID: 31436
		// (get) Token: 0x0602D25F RID: 184927 RVA: 0x00AB895F File Offset: 0x00AB6B5F
		// (set) Token: 0x0602D260 RID: 184928 RVA: 0x00AB8973 File Offset: 0x00AB6B73
		public unsafe TEnumAsByte<EMovementMode> BeginMovementMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_31);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_31) = value;
			}
		}

		// Token: 0x17007ACD RID: 31437
		// (get) Token: 0x0602D261 RID: 184929 RVA: 0x00AB8988 File Offset: 0x00AB6B88
		// (set) Token: 0x0602D262 RID: 184930 RVA: 0x00AB899C File Offset: 0x00AB6B9C
		public unsafe TEnumAsByte<EMovementMode> EndMovementMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_32);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_32) = value;
			}
		}

		// Token: 0x17007ACE RID: 31438
		// (get) Token: 0x0602D263 RID: 184931 RVA: 0x00AB89B1 File Offset: 0x00AB6BB1
		// (set) Token: 0x0602D264 RID: 184932 RVA: 0x00AB89C5 File Offset: 0x00AB6BC5
		public unsafe TEnumAsByte<ECollisionResponse> CollisionResponse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x17007ACF RID: 31439
		// (get) Token: 0x0602D265 RID: 184933 RVA: 0x00AB89DA File Offset: 0x00AB6BDA
		// (set) Token: 0x0602D266 RID: 184934 RVA: 0x00AB89EE File Offset: 0x00AB6BEE
		public unsafe TEnumAsByte<ECollisionChannel> CollisionChannel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17007AD0 RID: 31440
		// (get) Token: 0x0602D267 RID: 184935 RVA: 0x00AB8A03 File Offset: 0x00AB6C03
		// (set) Token: 0x0602D268 RID: 184936 RVA: 0x00AB8A13 File Offset: 0x00AB6C13
		public unsafe bool CollisionRestore
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_35) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_35) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007AD1 RID: 31441
		// (get) Token: 0x0602D269 RID: 184937 RVA: 0x00AB8A24 File Offset: 0x00AB6C24
		// (set) Token: 0x0602D26A RID: 184938 RVA: 0x00AB8A34 File Offset: 0x00AB6C34
		public unsafe int FollowIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x17007AD2 RID: 31442
		// (get) Token: 0x0602D26B RID: 184939 RVA: 0x00AB8A45 File Offset: 0x00AB6C45
		// (set) Token: 0x0602D26C RID: 184940 RVA: 0x00AB8A55 File Offset: 0x00AB6C55
		public unsafe int SummonSkillId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_37);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_37) = value;
			}
		}

		// Token: 0x17007AD3 RID: 31443
		// (get) Token: 0x0602D26D RID: 184941 RVA: 0x00AB8A66 File Offset: 0x00AB6C66
		// (set) Token: 0x0602D26E RID: 184942 RVA: 0x00AB8A76 File Offset: 0x00AB6C76
		public unsafe bool StopSummonSkill
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_38) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_38) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007AD4 RID: 31444
		// (get) Token: 0x0602D26F RID: 184943 RVA: 0x00AB8A87 File Offset: 0x00AB6C87
		// (set) Token: 0x0602D270 RID: 184944 RVA: 0x00AB8A9B File Offset: 0x00AB6C9B
		public unsafe TEnumAsByte<ESkillBehaviorBestSpotType> Strategy
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x17007AD5 RID: 31445
		// (get) Token: 0x0602D271 RID: 184945 RVA: 0x00AB8AB0 File Offset: 0x00AB6CB0
		// (set) Token: 0x0602D272 RID: 184946 RVA: 0x00AB8AF3 File Offset: 0x00AB6CF3
		[Nullable(1)]
		public TArray<float> AngleOffsets
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._AngleOffsets) == null)
				{
					result = (this._AngleOffsets = new TArray<float>(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_40, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.AngleOffsets.CopyAssign(value);
			}
		}

		// Token: 0x17007AD6 RID: 31446
		// (get) Token: 0x0602D273 RID: 184947 RVA: 0x00AB8B01 File Offset: 0x00AB6D01
		// (set) Token: 0x0602D274 RID: 184948 RVA: 0x00AB8B11 File Offset: 0x00AB6D11
		public unsafe bool OnGround
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_41) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_41) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007AD7 RID: 31447
		// (get) Token: 0x0602D275 RID: 184949 RVA: 0x00AB8B22 File Offset: 0x00AB6D22
		// (set) Token: 0x0602D276 RID: 184950 RVA: 0x00AB8B32 File Offset: 0x00AB6D32
		public unsafe int GroundOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x17007AD8 RID: 31448
		// (get) Token: 0x0602D277 RID: 184951 RVA: 0x00AB8B43 File Offset: 0x00AB6D43
		// (set) Token: 0x0602D278 RID: 184952 RVA: 0x00AB8B53 File Offset: 0x00AB6D53
		public unsafe bool DebugTrace
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_43) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_43) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007AD9 RID: 31449
		// (get) Token: 0x0602D279 RID: 184953 RVA: 0x00AB8B64 File Offset: 0x00AB6D64
		// (set) Token: 0x0602D27A RID: 184954 RVA: 0x00AB8B74 File Offset: 0x00AB6D74
		public unsafe int Navigation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x17007ADA RID: 31450
		// (get) Token: 0x0602D27B RID: 184955 RVA: 0x00AB8B85 File Offset: 0x00AB6D85
		// (set) Token: 0x0602D27C RID: 184956 RVA: 0x00AB8B95 File Offset: 0x00AB6D95
		public unsafe long BuffId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x17007ADB RID: 31451
		// (get) Token: 0x0602D27D RID: 184957 RVA: 0x00AB8BA6 File Offset: 0x00AB6DA6
		// (set) Token: 0x0602D27E RID: 184958 RVA: 0x00AB8BBA File Offset: 0x00AB6DBA
		public unsafe TEnumAsByte<ESkillBehaviorBuffTargetType> BuffTarget
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x17007ADC RID: 31452
		// (get) Token: 0x0602D27F RID: 184959 RVA: 0x00AB8BCF File Offset: 0x00AB6DCF
		// (set) Token: 0x0602D280 RID: 184960 RVA: 0x00AB8BDF File Offset: 0x00AB6DDF
		public unsafe bool Add
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_47) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_47) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007ADD RID: 31453
		// (get) Token: 0x0602D281 RID: 184961 RVA: 0x00AB8BF0 File Offset: 0x00AB6DF0
		// (set) Token: 0x0602D282 RID: 184962 RVA: 0x00AB8C00 File Offset: 0x00AB6E00
		public unsafe int MontageIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_48);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_48) = value;
			}
		}

		// Token: 0x17007ADE RID: 31454
		// (get) Token: 0x0602D283 RID: 184963 RVA: 0x00AB8C11 File Offset: 0x00AB6E11
		// (set) Token: 0x0602D284 RID: 184964 RVA: 0x00AB8C25 File Offset: 0x00AB6E25
		[Nullable(1)]
		public unsafe string StartSection
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSkillBehaviorAction.__PropertyOffset_49)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSkillBehaviorAction.__PropertyOffset_49)), value);
			}
		}

		// Token: 0x17007ADF RID: 31455
		// (get) Token: 0x0602D285 RID: 184965 RVA: 0x00AB8C3A File Offset: 0x00AB6E3A
		// (set) Token: 0x0602D286 RID: 184966 RVA: 0x00AB8C4A File Offset: 0x00AB6E4A
		public unsafe float StartTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_50);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_50) = value;
			}
		}

		// Token: 0x17007AE0 RID: 31456
		// (get) Token: 0x0602D287 RID: 184967 RVA: 0x00AB8C5C File Offset: 0x00AB6E5C
		// (set) Token: 0x0602D288 RID: 184968 RVA: 0x00AB8C9F File Offset: 0x00AB6E9F
		[Nullable(1)]
		public SSkillBehaviorUpdateCustomValue UpdateCustomValue
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SSkillBehaviorUpdateCustomValue result;
				if ((result = this._UpdateCustomValue) == null)
				{
					result = (this._UpdateCustomValue = new SSkillBehaviorUpdateCustomValue(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_51, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SSkillBehaviorUpdateCustomValue.StaticStruct(), base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_51, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007AE1 RID: 31457
		// (get) Token: 0x0602D289 RID: 184969 RVA: 0x00AB8CC0 File Offset: 0x00AB6EC0
		// (set) Token: 0x0602D28A RID: 184970 RVA: 0x00AB8CDF File Offset: 0x00AB6EDF
		[Nullable(1)]
		public TSoftObjectPtr<UPrimaryDataAsset> CommonConf
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<UPrimaryDataAsset>(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_52, base.MemoryOwner ?? this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_52, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007AE2 RID: 31458
		// (get) Token: 0x0602D28B RID: 184971 RVA: 0x00AB8D04 File Offset: 0x00AB6F04
		// (set) Token: 0x0602D28C RID: 184972 RVA: 0x00AB8D18 File Offset: 0x00AB6F18
		public unsafe FName BoneName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_53);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorAction.__PropertyOffset_53) = value;
			}
		}

		// Token: 0x0602D28D RID: 184973 RVA: 0x00AB8D2D File Offset: 0x00AB6F2D
		public SSkillBehaviorAction()
		{
		}

		// Token: 0x0602D28E RID: 184974 RVA: 0x00AB8D38 File Offset: 0x00AB6F38
		public SSkillBehaviorAction(TEnumAsByte<ESkillBehaviorActionType> ActionType, TEnumAsByte<ESkillBehaviorLocationType> LocationType, [Nullable(1)] string BlackboardKey, TEnumAsByte<ESkillBehaviorLocationForwardType> LocationForwardType, FVector LocationOffset, bool Restrict, TEnumAsByte<ESkillBehaviorRestrictType> RestrictType, int RestrictDistance, bool BestSpot, TEnumAsByte<ESkillBehaviorRotationType> RotationType, float DirectionOffset, [Nullable(1)] TArray<SSkillBehaviorCue> Cues, [Nullable(1)] TArray<SSkillBehaviorBullet> Bullets, FGameplayTag Tag, float Duration, float BlendInTime, float BlendOutTime, float BreakBlendOutTime, [Nullable(1)] SBaseCurve BlendInCurve, [Nullable(1)] SBaseCurve BlendOutCurve, TEnumAsByte<ECameraAnsEffectiveClientType> CameraEffectiveClientType, [Nullable(1)] TArray<SCameraModifier_Condition> CameraModifierConditions, [Nullable(1)] SCameraModifier_Settings CameraModifierSettings, [Nullable(1)] SSequenceCamera_Settings CameraSequenceSettings, bool ResetLockOnCamera, FRotator AdditiveRotation, FName CameraAttachSocket, FName CameraDetectSocket, float ExtraDetectSphereRadius, FVector ExtraSphereLocation, bool IsShowExtraSphere, TEnumAsByte<EMovementMode> BeginMovementMode, TEnumAsByte<EMovementMode> EndMovementMode, TEnumAsByte<ECollisionResponse> CollisionResponse, TEnumAsByte<ECollisionChannel> CollisionChannel, bool CollisionRestore, int FollowIndex, int SummonSkillId, bool StopSummonSkill, TEnumAsByte<ESkillBehaviorBestSpotType> Strategy, [Nullable(1)] TArray<float> AngleOffsets, bool OnGround, int GroundOffset, bool DebugTrace, int Navigation, long BuffId, TEnumAsByte<ESkillBehaviorBuffTargetType> BuffTarget, bool Add, int MontageIndex, [Nullable(1)] string StartSection, float StartTime, [Nullable(1)] SSkillBehaviorUpdateCustomValue UpdateCustomValue, [Nullable(1)] TSoftObjectPtr<UPrimaryDataAsset> CommonConf, FName BoneName)
		{
			this.ActionType = ActionType;
			this.LocationType = LocationType;
			this.BlackboardKey = BlackboardKey;
			this.LocationForwardType = LocationForwardType;
			this.LocationOffset = LocationOffset;
			this.Restrict = Restrict;
			this.RestrictType = RestrictType;
			this.RestrictDistance = RestrictDistance;
			this.BestSpot = BestSpot;
			this.RotationType = RotationType;
			this.DirectionOffset = DirectionOffset;
			this.Cues = Cues;
			this.Bullets = Bullets;
			this.Tag = Tag;
			this.Duration = Duration;
			this.BlendInTime = BlendInTime;
			this.BlendOutTime = BlendOutTime;
			this.BreakBlendOutTime = BreakBlendOutTime;
			this.BlendInCurve = BlendInCurve;
			this.BlendOutCurve = BlendOutCurve;
			this.CameraEffectiveClientType = CameraEffectiveClientType;
			this.CameraModifierConditions = CameraModifierConditions;
			this.CameraModifierSettings = CameraModifierSettings;
			this.CameraSequenceSettings = CameraSequenceSettings;
			this.ResetLockOnCamera = ResetLockOnCamera;
			this.AdditiveRotation = AdditiveRotation;
			this.CameraAttachSocket = CameraAttachSocket;
			this.CameraDetectSocket = CameraDetectSocket;
			this.ExtraDetectSphereRadius = ExtraDetectSphereRadius;
			this.ExtraSphereLocation = ExtraSphereLocation;
			this.IsShowExtraSphere = IsShowExtraSphere;
			this.BeginMovementMode = BeginMovementMode;
			this.EndMovementMode = EndMovementMode;
			this.CollisionResponse = CollisionResponse;
			this.CollisionChannel = CollisionChannel;
			this.CollisionRestore = CollisionRestore;
			this.FollowIndex = FollowIndex;
			this.SummonSkillId = SummonSkillId;
			this.StopSummonSkill = StopSummonSkill;
			this.Strategy = Strategy;
			this.AngleOffsets = AngleOffsets;
			this.OnGround = OnGround;
			this.GroundOffset = GroundOffset;
			this.DebugTrace = DebugTrace;
			this.Navigation = Navigation;
			this.BuffId = BuffId;
			this.BuffTarget = BuffTarget;
			this.Add = Add;
			this.MontageIndex = MontageIndex;
			this.StartSection = StartSection;
			this.StartTime = StartTime;
			this.UpdateCustomValue = UpdateCustomValue;
			this.CommonConf = CommonConf;
			this.BoneName = BoneName;
		}

		// Token: 0x0602D28F RID: 184975 RVA: 0x00AB8EF8 File Offset: 0x00AB70F8
		protected override IntPtr GetUStructPtr()
		{
			return SSkillBehaviorAction.StaticStruct();
		}

		// Token: 0x0602D290 RID: 184976 RVA: 0x00AB8F04 File Offset: 0x00AB7104
		[NullableContext(2)]
		public SSkillBehaviorAction(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D291 RID: 184977 RVA: 0x00AB8F0E File Offset: 0x00AB710E
		public SSkillBehaviorAction(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D292 RID: 184978 RVA: 0x00AB8F19 File Offset: 0x00AB7119
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSkillBehaviorAction(Pointer, false, true);
		}

		// Token: 0x0602D293 RID: 184979 RVA: 0x00AB8F23 File Offset: 0x00AB7123
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSkillBehaviorAction(Pointer, MemoryOwner);
		}

		// Token: 0x040194DE RID: 103646
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SSkillBehaviorAction.SSkillBehaviorAction";

		// Token: 0x040194DF RID: 103647
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040194E0 RID: 103648
		internal static int __PropertyOffset_0;

		// Token: 0x040194E1 RID: 103649
		internal static int __PropertyOffset_1;

		// Token: 0x040194E2 RID: 103650
		internal static int __PropertyOffset_2;

		// Token: 0x040194E3 RID: 103651
		internal static int __PropertyOffset_3;

		// Token: 0x040194E4 RID: 103652
		internal static int __PropertyOffset_4;

		// Token: 0x040194E5 RID: 103653
		internal static int __PropertyOffset_5;

		// Token: 0x040194E6 RID: 103654
		internal static int __PropertyOffset_6;

		// Token: 0x040194E7 RID: 103655
		internal static int __PropertyOffset_7;

		// Token: 0x040194E8 RID: 103656
		internal static int __PropertyOffset_8;

		// Token: 0x040194E9 RID: 103657
		internal static int __PropertyOffset_9;

		// Token: 0x040194EA RID: 103658
		internal static int __PropertyOffset_10;

		// Token: 0x040194EB RID: 103659
		internal static int __PropertyOffset_11;

		// Token: 0x040194EC RID: 103660
		[Nullable(2)]
		private TArray<SSkillBehaviorCue> _Cues;

		// Token: 0x040194ED RID: 103661
		internal static int __PropertyOffset_12;

		// Token: 0x040194EE RID: 103662
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SSkillBehaviorBullet> _Bullets;

		// Token: 0x040194EF RID: 103663
		internal static int __PropertyOffset_13;

		// Token: 0x040194F0 RID: 103664
		internal static int __PropertyOffset_14;

		// Token: 0x040194F1 RID: 103665
		internal static int __PropertyOffset_15;

		// Token: 0x040194F2 RID: 103666
		internal static int __PropertyOffset_16;

		// Token: 0x040194F3 RID: 103667
		internal static int __PropertyOffset_17;

		// Token: 0x040194F4 RID: 103668
		internal static int __PropertyOffset_18;

		// Token: 0x040194F5 RID: 103669
		[Nullable(2)]
		private SBaseCurve _BlendInCurve;

		// Token: 0x040194F6 RID: 103670
		internal static int __PropertyOffset_19;

		// Token: 0x040194F7 RID: 103671
		[Nullable(2)]
		private SBaseCurve _BlendOutCurve;

		// Token: 0x040194F8 RID: 103672
		internal static int __PropertyOffset_20;

		// Token: 0x040194F9 RID: 103673
		internal static int __PropertyOffset_21;

		// Token: 0x040194FA RID: 103674
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SCameraModifier_Condition> _CameraModifierConditions;

		// Token: 0x040194FB RID: 103675
		internal static int __PropertyOffset_22;

		// Token: 0x040194FC RID: 103676
		[Nullable(2)]
		private SCameraModifier_Settings _CameraModifierSettings;

		// Token: 0x040194FD RID: 103677
		internal static int __PropertyOffset_23;

		// Token: 0x040194FE RID: 103678
		[Nullable(2)]
		private SSequenceCamera_Settings _CameraSequenceSettings;

		// Token: 0x040194FF RID: 103679
		internal static int __PropertyOffset_24;

		// Token: 0x04019500 RID: 103680
		internal static int __PropertyOffset_25;

		// Token: 0x04019501 RID: 103681
		internal static int __PropertyOffset_26;

		// Token: 0x04019502 RID: 103682
		internal static int __PropertyOffset_27;

		// Token: 0x04019503 RID: 103683
		internal static int __PropertyOffset_28;

		// Token: 0x04019504 RID: 103684
		internal static int __PropertyOffset_29;

		// Token: 0x04019505 RID: 103685
		internal static int __PropertyOffset_30;

		// Token: 0x04019506 RID: 103686
		internal static int __PropertyOffset_31;

		// Token: 0x04019507 RID: 103687
		internal static int __PropertyOffset_32;

		// Token: 0x04019508 RID: 103688
		internal static int __PropertyOffset_33;

		// Token: 0x04019509 RID: 103689
		internal static int __PropertyOffset_34;

		// Token: 0x0401950A RID: 103690
		internal static int __PropertyOffset_35;

		// Token: 0x0401950B RID: 103691
		internal static int __PropertyOffset_36;

		// Token: 0x0401950C RID: 103692
		internal static int __PropertyOffset_37;

		// Token: 0x0401950D RID: 103693
		internal static int __PropertyOffset_38;

		// Token: 0x0401950E RID: 103694
		internal static int __PropertyOffset_39;

		// Token: 0x0401950F RID: 103695
		internal static int __PropertyOffset_40;

		// Token: 0x04019510 RID: 103696
		[Nullable(2)]
		private TArray<float> _AngleOffsets;

		// Token: 0x04019511 RID: 103697
		internal static int __PropertyOffset_41;

		// Token: 0x04019512 RID: 103698
		internal static int __PropertyOffset_42;

		// Token: 0x04019513 RID: 103699
		internal static int __PropertyOffset_43;

		// Token: 0x04019514 RID: 103700
		internal static int __PropertyOffset_44;

		// Token: 0x04019515 RID: 103701
		internal static int __PropertyOffset_45;

		// Token: 0x04019516 RID: 103702
		internal static int __PropertyOffset_46;

		// Token: 0x04019517 RID: 103703
		internal static int __PropertyOffset_47;

		// Token: 0x04019518 RID: 103704
		internal static int __PropertyOffset_48;

		// Token: 0x04019519 RID: 103705
		internal static int __PropertyOffset_49;

		// Token: 0x0401951A RID: 103706
		internal static int __PropertyOffset_50;

		// Token: 0x0401951B RID: 103707
		internal static int __PropertyOffset_51;

		// Token: 0x0401951C RID: 103708
		[Nullable(2)]
		private SSkillBehaviorUpdateCustomValue _UpdateCustomValue;

		// Token: 0x0401951D RID: 103709
		internal static int __PropertyOffset_52;

		// Token: 0x0401951E RID: 103710
		internal static int __PropertyOffset_53;
	}
}
