using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200427F RID: 17023
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SSkillInfo.SSkillInfo")]
	[UnrealStructLayout(464, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 460)]
	public class SSkillInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D31B RID: 185115 RVA: 0x00AB9A86 File Offset: 0x00AB7C86
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSkillInfo._ScriptStructPtr != 0) ? SSkillInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SSkillInfo.SSkillInfo", ref SSkillInfo._ScriptStructPtr);
		}

		// Token: 0x17007B0B RID: 31499
		// (get) Token: 0x0602D31C RID: 185116 RVA: 0x00AB9AAA File Offset: 0x00AB7CAA
		// (set) Token: 0x0602D31D RID: 185117 RVA: 0x00AB9ABE File Offset: 0x00AB7CBE
		public unsafe FName SkillName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007B0C RID: 31500
		// (get) Token: 0x0602D31E RID: 185118 RVA: 0x00AB9AD4 File Offset: 0x00AB7CD4
		// (set) Token: 0x0602D31F RID: 185119 RVA: 0x00AB9B17 File Offset: 0x00AB7D17
		public FSoftObjectPath SkillIcon
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._SkillIcon) == null)
				{
					result = (this._SkillIcon = new FSoftObjectPath(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007B0D RID: 31501
		// (get) Token: 0x0602D320 RID: 185120 RVA: 0x00AB9B38 File Offset: 0x00AB7D38
		// (set) Token: 0x0602D321 RID: 185121 RVA: 0x00AB9B4C File Offset: 0x00AB7D4C
		[Nullable(0)]
		public unsafe TEnumAsByte<ESkillMode> SkillMode
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_2);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007B0E RID: 31502
		// (get) Token: 0x0602D322 RID: 185122 RVA: 0x00AB9B64 File Offset: 0x00AB7D64
		// (set) Token: 0x0602D323 RID: 185123 RVA: 0x00AB9BA7 File Offset: 0x00AB7DA7
		public TArray<SSkillTrigger> SkillTriggers
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SSkillTrigger> result;
				if ((result = this._SkillTriggers) == null)
				{
					result = (this._SkillTriggers = new TArray<SSkillTrigger>(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SkillTriggers.CopyAssign(value);
			}
		}

		// Token: 0x17007B0F RID: 31503
		// (get) Token: 0x0602D324 RID: 185124 RVA: 0x00AB9BB8 File Offset: 0x00AB7DB8
		// (set) Token: 0x0602D325 RID: 185125 RVA: 0x00AB9BFB File Offset: 0x00AB7DFB
		public TArray<SSkillBehavior> SkillBehaviorGroup
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SSkillBehavior> result;
				if ((result = this._SkillBehaviorGroup) == null)
				{
					result = (this._SkillBehaviorGroup = new TArray<SSkillBehavior>(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SkillBehaviorGroup.CopyAssign(value);
			}
		}

		// Token: 0x17007B10 RID: 31504
		// (get) Token: 0x0602D326 RID: 185126 RVA: 0x00AB9C0C File Offset: 0x00AB7E0C
		// (set) Token: 0x0602D327 RID: 185127 RVA: 0x00AB9C4F File Offset: 0x00AB7E4F
		public FSoftClassPath SkillGA
		{
			get
			{
				base.FastCheckIsValid();
				FSoftClassPath result;
				if ((result = this._SkillGA) == null)
				{
					result = (this._SkillGA = new FSoftClassPath(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftClassPath.StaticStruct(), base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007B11 RID: 31505
		// (get) Token: 0x0602D328 RID: 185128 RVA: 0x00AB9C70 File Offset: 0x00AB7E70
		// (set) Token: 0x0602D329 RID: 185129 RVA: 0x00AB9CB3 File Offset: 0x00AB7EB3
		public TArray<FSoftObjectPath> Animations
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FSoftObjectPath> result;
				if ((result = this._Animations) == null)
				{
					result = (this._Animations = new TArray<FSoftObjectPath>(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Animations.CopyAssign(value);
			}
		}

		// Token: 0x17007B12 RID: 31506
		// (get) Token: 0x0602D32A RID: 185130 RVA: 0x00AB9CC4 File Offset: 0x00AB7EC4
		// (set) Token: 0x0602D32B RID: 185131 RVA: 0x00AB9D07 File Offset: 0x00AB7F07
		public TArray<string> MontagePaths
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._MontagePaths) == null)
				{
					result = (this._MontagePaths = new TArray<string>(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.MontagePaths.CopyAssign(value);
			}
		}

		// Token: 0x17007B13 RID: 31507
		// (get) Token: 0x0602D32C RID: 185132 RVA: 0x00AB9D18 File Offset: 0x00AB7F18
		// (set) Token: 0x0602D32D RID: 185133 RVA: 0x00AB9D5B File Offset: 0x00AB7F5B
		public TArray<FGameplayTag> SkillTag
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._SkillTag) == null)
				{
					result = (this._SkillTag = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SkillTag.CopyAssign(value);
			}
		}

		// Token: 0x17007B14 RID: 31508
		// (get) Token: 0x0602D32E RID: 185134 RVA: 0x00AB9D69 File Offset: 0x00AB7F69
		// (set) Token: 0x0602D32F RID: 185135 RVA: 0x00AB9D79 File Offset: 0x00AB7F79
		public unsafe int GroupId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007B15 RID: 31509
		// (get) Token: 0x0602D330 RID: 185136 RVA: 0x00AB9D8A File Offset: 0x00AB7F8A
		// (set) Token: 0x0602D331 RID: 185137 RVA: 0x00AB9D9A File Offset: 0x00AB7F9A
		public unsafe int InterruptLevel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17007B16 RID: 31510
		// (get) Token: 0x0602D332 RID: 185138 RVA: 0x00AB9DAB File Offset: 0x00AB7FAB
		// (set) Token: 0x0602D333 RID: 185139 RVA: 0x00AB9DBF File Offset: 0x00AB7FBF
		[Nullable(0)]
		public unsafe TEnumAsByte<ESkillGenre> SkillGenre
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_11);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007B17 RID: 31511
		// (get) Token: 0x0602D334 RID: 185140 RVA: 0x00AB9DD4 File Offset: 0x00AB7FD4
		// (set) Token: 0x0602D335 RID: 185141 RVA: 0x00AB9DE4 File Offset: 0x00AB7FE4
		public unsafe bool IsLockOn
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B18 RID: 31512
		// (get) Token: 0x0602D336 RID: 185142 RVA: 0x00AB9DF8 File Offset: 0x00AB7FF8
		// (set) Token: 0x0602D337 RID: 185143 RVA: 0x00AB9E3B File Offset: 0x00AB803B
		public SSkillTarget SkillTarget
		{
			get
			{
				base.FastCheckIsValid();
				SSkillTarget result;
				if ((result = this._SkillTarget) == null)
				{
					result = (this._SkillTarget = new SSkillTarget(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_13, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SSkillTarget.StaticStruct(), base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007B19 RID: 31513
		// (get) Token: 0x0602D338 RID: 185144 RVA: 0x00AB9E5C File Offset: 0x00AB805C
		// (set) Token: 0x0602D339 RID: 185145 RVA: 0x00AB9E70 File Offset: 0x00AB8070
		[Nullable(0)]
		public unsafe TEnumAsByte<ESkillTargetDirection> SkillDirection
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_14);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17007B1A RID: 31514
		// (get) Token: 0x0602D33A RID: 185146 RVA: 0x00AB9E88 File Offset: 0x00AB8088
		// (set) Token: 0x0602D33B RID: 185147 RVA: 0x00AB9ECB File Offset: 0x00AB80CB
		public SSkillCooldownInfo CooldownConfig
		{
			get
			{
				base.FastCheckIsValid();
				SSkillCooldownInfo result;
				if ((result = this._CooldownConfig) == null)
				{
					result = (this._CooldownConfig = new SSkillCooldownInfo(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_15, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SSkillCooldownInfo.StaticStruct(), base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007B1B RID: 31515
		// (get) Token: 0x0602D33C RID: 185148 RVA: 0x00AB9EEC File Offset: 0x00AB80EC
		// (set) Token: 0x0602D33D RID: 185149 RVA: 0x00AB9EFC File Offset: 0x00AB80FC
		public unsafe bool WalkOffLedge
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B1C RID: 31516
		// (get) Token: 0x0602D33E RID: 185150 RVA: 0x00AB9F10 File Offset: 0x00AB8110
		// (set) Token: 0x0602D33F RID: 185151 RVA: 0x00AB9F53 File Offset: 0x00AB8153
		public TArray<long> SkillBuff
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._SkillBuff) == null)
				{
					result = (this._SkillBuff = new TArray<long>(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_17, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SkillBuff.CopyAssign(value);
			}
		}

		// Token: 0x17007B1D RID: 31517
		// (get) Token: 0x0602D340 RID: 185152 RVA: 0x00AB9F64 File Offset: 0x00AB8164
		// (set) Token: 0x0602D341 RID: 185153 RVA: 0x00AB9FA7 File Offset: 0x00AB81A7
		public TArray<long> SkillStartBuff
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._SkillStartBuff) == null)
				{
					result = (this._SkillStartBuff = new TArray<long>(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_18, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SkillStartBuff.CopyAssign(value);
			}
		}

		// Token: 0x17007B1E RID: 31518
		// (get) Token: 0x0602D342 RID: 185154 RVA: 0x00AB9FB8 File Offset: 0x00AB81B8
		// (set) Token: 0x0602D343 RID: 185155 RVA: 0x00AB9FFB File Offset: 0x00AB81FB
		public TArray<long> StartRemoveBuffIds
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._StartRemoveBuffIds) == null)
				{
					result = (this._StartRemoveBuffIds = new TArray<long>(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_19, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.StartRemoveBuffIds.CopyAssign(value);
			}
		}

		// Token: 0x17007B1F RID: 31519
		// (get) Token: 0x0602D344 RID: 185156 RVA: 0x00ABA00C File Offset: 0x00AB820C
		// (set) Token: 0x0602D345 RID: 185157 RVA: 0x00ABA04F File Offset: 0x00AB824F
		public TArray<long> SkillEndBuff
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._SkillEndBuff) == null)
				{
					result = (this._SkillEndBuff = new TArray<long>(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_20, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SkillEndBuff.CopyAssign(value);
			}
		}

		// Token: 0x17007B20 RID: 31520
		// (get) Token: 0x0602D346 RID: 185158 RVA: 0x00ABA060 File Offset: 0x00AB8260
		// (set) Token: 0x0602D347 RID: 185159 RVA: 0x00ABA0A3 File Offset: 0x00AB82A3
		public TArray<long> EndRemoveBuffIds
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._EndRemoveBuffIds) == null)
				{
					result = (this._EndRemoveBuffIds = new TArray<long>(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_21, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.EndRemoveBuffIds.CopyAssign(value);
			}
		}

		// Token: 0x17007B21 RID: 31521
		// (get) Token: 0x0602D348 RID: 185160 RVA: 0x00ABA0B1 File Offset: 0x00AB82B1
		// (set) Token: 0x0602D349 RID: 185161 RVA: 0x00ABA0C1 File Offset: 0x00AB82C1
		public unsafe float ToughRatio
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17007B22 RID: 31522
		// (get) Token: 0x0602D34A RID: 185162 RVA: 0x00ABA0D2 File Offset: 0x00AB82D2
		// (set) Token: 0x0602D34B RID: 185163 RVA: 0x00ABA0E2 File Offset: 0x00AB82E2
		public unsafe float StrengthCost
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17007B23 RID: 31523
		// (get) Token: 0x0602D34C RID: 185164 RVA: 0x00ABA0F3 File Offset: 0x00AB82F3
		// (set) Token: 0x0602D34D RID: 185165 RVA: 0x00ABA103 File Offset: 0x00AB8303
		public unsafe bool IsFullBodySkill
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B24 RID: 31524
		// (get) Token: 0x0602D34E RID: 185166 RVA: 0x00ABA114 File Offset: 0x00AB8314
		// (set) Token: 0x0602D34F RID: 185167 RVA: 0x00ABA124 File Offset: 0x00AB8324
		public unsafe bool AutonomouslyBySimulate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B25 RID: 31525
		// (get) Token: 0x0602D350 RID: 185168 RVA: 0x00ABA135 File Offset: 0x00AB8335
		// (set) Token: 0x0602D351 RID: 185169 RVA: 0x00ABA145 File Offset: 0x00AB8345
		public unsafe float MoveControllerTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17007B26 RID: 31526
		// (get) Token: 0x0602D352 RID: 185170 RVA: 0x00ABA156 File Offset: 0x00AB8356
		// (set) Token: 0x0602D353 RID: 185171 RVA: 0x00ABA166 File Offset: 0x00AB8366
		public unsafe float ImmuneFallDamageTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17007B27 RID: 31527
		// (get) Token: 0x0602D354 RID: 185172 RVA: 0x00ABA177 File Offset: 0x00AB8377
		// (set) Token: 0x0602D355 RID: 185173 RVA: 0x00ABA187 File Offset: 0x00AB8387
		public unsafe bool OverrideHit
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B28 RID: 31528
		// (get) Token: 0x0602D356 RID: 185174 RVA: 0x00ABA198 File Offset: 0x00AB8398
		// (set) Token: 0x0602D357 RID: 185175 RVA: 0x00ABA1AC File Offset: 0x00AB83AC
		[Nullable(0)]
		public unsafe TEnumAsByte<ESkillOverrideType> OverrideType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_29);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_29) = value;
			}
		}

		// Token: 0x17007B29 RID: 31529
		// (get) Token: 0x0602D358 RID: 185176 RVA: 0x00ABA1C4 File Offset: 0x00AB83C4
		// (set) Token: 0x0602D359 RID: 185177 RVA: 0x00ABA207 File Offset: 0x00AB8407
		public TArray<FSoftObjectPath> ExportSpecialAnim
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FSoftObjectPath> result;
				if ((result = this._ExportSpecialAnim) == null)
				{
					result = (this._ExportSpecialAnim = new TArray<FSoftObjectPath>(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_30, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ExportSpecialAnim.CopyAssign(value);
			}
		}

		// Token: 0x17007B2A RID: 31530
		// (get) Token: 0x0602D35A RID: 185178 RVA: 0x00ABA215 File Offset: 0x00AB8415
		// (set) Token: 0x0602D35B RID: 185179 RVA: 0x00ABA225 File Offset: 0x00AB8425
		public unsafe bool MontageDelayOneFrame
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B2B RID: 31531
		// (get) Token: 0x0602D35C RID: 185180 RVA: 0x00ABA236 File Offset: 0x00AB8436
		// (set) Token: 0x0602D35D RID: 185181 RVA: 0x00ABA246 File Offset: 0x00AB8446
		public unsafe bool SkillStepUp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_32) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_32) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B2C RID: 31532
		// (get) Token: 0x0602D35E RID: 185182 RVA: 0x00ABA257 File Offset: 0x00AB8457
		// (set) Token: 0x0602D35F RID: 185183 RVA: 0x00ABA267 File Offset: 0x00AB8467
		public unsafe bool SkillCanBeginWithoutControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_33) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_33) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B2D RID: 31533
		// (get) Token: 0x0602D360 RID: 185184 RVA: 0x00ABA278 File Offset: 0x00AB8478
		// (set) Token: 0x0602D361 RID: 185185 RVA: 0x00ABA288 File Offset: 0x00AB8488
		public unsafe int MaxCounterCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_34);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_34) = value;
			}
		}

		// Token: 0x17007B2E RID: 31534
		// (get) Token: 0x0602D362 RID: 185186 RVA: 0x00ABA29C File Offset: 0x00AB849C
		// (set) Token: 0x0602D363 RID: 185187 RVA: 0x00ABA2DF File Offset: 0x00AB84DF
		public TArray<long> SpecialBuffInCode
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._SpecialBuffInCode) == null)
				{
					result = (this._SpecialBuffInCode = new TArray<long>(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_35, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SpecialBuffInCode.CopyAssign(value);
			}
		}

		// Token: 0x17007B2F RID: 31535
		// (get) Token: 0x0602D364 RID: 185188 RVA: 0x00ABA2ED File Offset: 0x00AB84ED
		// (set) Token: 0x0602D365 RID: 185189 RVA: 0x00ABA2FD File Offset: 0x00AB84FD
		public unsafe float BurstLockTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillInfo.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x0602D366 RID: 185190 RVA: 0x00ABA30E File Offset: 0x00AB850E
		public SSkillInfo()
		{
		}

		// Token: 0x0602D367 RID: 185191 RVA: 0x00ABA318 File Offset: 0x00AB8518
		public SSkillInfo(FName SkillName, FSoftObjectPath SkillIcon, [Nullable(0)] TEnumAsByte<ESkillMode> SkillMode, TArray<SSkillTrigger> SkillTriggers, TArray<SSkillBehavior> SkillBehaviorGroup, FSoftClassPath SkillGA, TArray<FSoftObjectPath> Animations, TArray<string> MontagePaths, TArray<FGameplayTag> SkillTag, int GroupId, int InterruptLevel, [Nullable(0)] TEnumAsByte<ESkillGenre> SkillGenre, bool IsLockOn, SSkillTarget SkillTarget, [Nullable(0)] TEnumAsByte<ESkillTargetDirection> SkillDirection, SSkillCooldownInfo CooldownConfig, bool WalkOffLedge, TArray<long> SkillBuff, TArray<long> SkillStartBuff, TArray<long> StartRemoveBuffIds, TArray<long> SkillEndBuff, TArray<long> EndRemoveBuffIds, float ToughRatio, float StrengthCost, bool IsFullBodySkill, bool AutonomouslyBySimulate, float MoveControllerTime, float ImmuneFallDamageTime, bool OverrideHit, [Nullable(0)] TEnumAsByte<ESkillOverrideType> OverrideType, TArray<FSoftObjectPath> ExportSpecialAnim, bool MontageDelayOneFrame, bool SkillStepUp, bool SkillCanBeginWithoutControl, int MaxCounterCount, TArray<long> SpecialBuffInCode, float BurstLockTime)
		{
			this.SkillName = SkillName;
			this.SkillIcon = SkillIcon;
			this.SkillMode = SkillMode;
			this.SkillTriggers = SkillTriggers;
			this.SkillBehaviorGroup = SkillBehaviorGroup;
			this.SkillGA = SkillGA;
			this.Animations = Animations;
			this.MontagePaths = MontagePaths;
			this.SkillTag = SkillTag;
			this.GroupId = GroupId;
			this.InterruptLevel = InterruptLevel;
			this.SkillGenre = SkillGenre;
			this.IsLockOn = IsLockOn;
			this.SkillTarget = SkillTarget;
			this.SkillDirection = SkillDirection;
			this.CooldownConfig = CooldownConfig;
			this.WalkOffLedge = WalkOffLedge;
			this.SkillBuff = SkillBuff;
			this.SkillStartBuff = SkillStartBuff;
			this.StartRemoveBuffIds = StartRemoveBuffIds;
			this.SkillEndBuff = SkillEndBuff;
			this.EndRemoveBuffIds = EndRemoveBuffIds;
			this.ToughRatio = ToughRatio;
			this.StrengthCost = StrengthCost;
			this.IsFullBodySkill = IsFullBodySkill;
			this.AutonomouslyBySimulate = AutonomouslyBySimulate;
			this.MoveControllerTime = MoveControllerTime;
			this.ImmuneFallDamageTime = ImmuneFallDamageTime;
			this.OverrideHit = OverrideHit;
			this.OverrideType = OverrideType;
			this.ExportSpecialAnim = ExportSpecialAnim;
			this.MontageDelayOneFrame = MontageDelayOneFrame;
			this.SkillStepUp = SkillStepUp;
			this.SkillCanBeginWithoutControl = SkillCanBeginWithoutControl;
			this.MaxCounterCount = MaxCounterCount;
			this.SpecialBuffInCode = SpecialBuffInCode;
			this.BurstLockTime = BurstLockTime;
		}

		// Token: 0x0602D368 RID: 185192 RVA: 0x00ABA450 File Offset: 0x00AB8650
		protected override IntPtr GetUStructPtr()
		{
			return SSkillInfo.StaticStruct();
		}

		// Token: 0x0602D369 RID: 185193 RVA: 0x00ABA45C File Offset: 0x00AB865C
		[NullableContext(2)]
		public SSkillInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D36A RID: 185194 RVA: 0x00ABA466 File Offset: 0x00AB8666
		public SSkillInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D36B RID: 185195 RVA: 0x00ABA471 File Offset: 0x00AB8671
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSkillInfo(Pointer, false, true);
		}

		// Token: 0x0602D36C RID: 185196 RVA: 0x00ABA47B File Offset: 0x00AB867B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSkillInfo(Pointer, MemoryOwner);
		}

		// Token: 0x0401955F RID: 103775
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SSkillInfo.SSkillInfo";

		// Token: 0x04019560 RID: 103776
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019561 RID: 103777
		internal static int __PropertyOffset_0;

		// Token: 0x04019562 RID: 103778
		internal static int __PropertyOffset_1;

		// Token: 0x04019563 RID: 103779
		[Nullable(2)]
		private FSoftObjectPath _SkillIcon;

		// Token: 0x04019564 RID: 103780
		internal static int __PropertyOffset_2;

		// Token: 0x04019565 RID: 103781
		internal static int __PropertyOffset_3;

		// Token: 0x04019566 RID: 103782
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SSkillTrigger> _SkillTriggers;

		// Token: 0x04019567 RID: 103783
		internal static int __PropertyOffset_4;

		// Token: 0x04019568 RID: 103784
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SSkillBehavior> _SkillBehaviorGroup;

		// Token: 0x04019569 RID: 103785
		internal static int __PropertyOffset_5;

		// Token: 0x0401956A RID: 103786
		[Nullable(2)]
		private FSoftClassPath _SkillGA;

		// Token: 0x0401956B RID: 103787
		internal static int __PropertyOffset_6;

		// Token: 0x0401956C RID: 103788
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FSoftObjectPath> _Animations;

		// Token: 0x0401956D RID: 103789
		internal static int __PropertyOffset_7;

		// Token: 0x0401956E RID: 103790
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _MontagePaths;

		// Token: 0x0401956F RID: 103791
		internal static int __PropertyOffset_8;

		// Token: 0x04019570 RID: 103792
		[Nullable(2)]
		private TArray<FGameplayTag> _SkillTag;

		// Token: 0x04019571 RID: 103793
		internal static int __PropertyOffset_9;

		// Token: 0x04019572 RID: 103794
		internal static int __PropertyOffset_10;

		// Token: 0x04019573 RID: 103795
		internal static int __PropertyOffset_11;

		// Token: 0x04019574 RID: 103796
		internal static int __PropertyOffset_12;

		// Token: 0x04019575 RID: 103797
		internal static int __PropertyOffset_13;

		// Token: 0x04019576 RID: 103798
		[Nullable(2)]
		private SSkillTarget _SkillTarget;

		// Token: 0x04019577 RID: 103799
		internal static int __PropertyOffset_14;

		// Token: 0x04019578 RID: 103800
		internal static int __PropertyOffset_15;

		// Token: 0x04019579 RID: 103801
		[Nullable(2)]
		private SSkillCooldownInfo _CooldownConfig;

		// Token: 0x0401957A RID: 103802
		internal static int __PropertyOffset_16;

		// Token: 0x0401957B RID: 103803
		internal static int __PropertyOffset_17;

		// Token: 0x0401957C RID: 103804
		[Nullable(2)]
		private TArray<long> _SkillBuff;

		// Token: 0x0401957D RID: 103805
		internal static int __PropertyOffset_18;

		// Token: 0x0401957E RID: 103806
		[Nullable(2)]
		private TArray<long> _SkillStartBuff;

		// Token: 0x0401957F RID: 103807
		internal static int __PropertyOffset_19;

		// Token: 0x04019580 RID: 103808
		[Nullable(2)]
		private TArray<long> _StartRemoveBuffIds;

		// Token: 0x04019581 RID: 103809
		internal static int __PropertyOffset_20;

		// Token: 0x04019582 RID: 103810
		[Nullable(2)]
		private TArray<long> _SkillEndBuff;

		// Token: 0x04019583 RID: 103811
		internal static int __PropertyOffset_21;

		// Token: 0x04019584 RID: 103812
		[Nullable(2)]
		private TArray<long> _EndRemoveBuffIds;

		// Token: 0x04019585 RID: 103813
		internal static int __PropertyOffset_22;

		// Token: 0x04019586 RID: 103814
		internal static int __PropertyOffset_23;

		// Token: 0x04019587 RID: 103815
		internal static int __PropertyOffset_24;

		// Token: 0x04019588 RID: 103816
		internal static int __PropertyOffset_25;

		// Token: 0x04019589 RID: 103817
		internal static int __PropertyOffset_26;

		// Token: 0x0401958A RID: 103818
		internal static int __PropertyOffset_27;

		// Token: 0x0401958B RID: 103819
		internal static int __PropertyOffset_28;

		// Token: 0x0401958C RID: 103820
		internal static int __PropertyOffset_29;

		// Token: 0x0401958D RID: 103821
		internal static int __PropertyOffset_30;

		// Token: 0x0401958E RID: 103822
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<FSoftObjectPath> _ExportSpecialAnim;

		// Token: 0x0401958F RID: 103823
		internal static int __PropertyOffset_31;

		// Token: 0x04019590 RID: 103824
		internal static int __PropertyOffset_32;

		// Token: 0x04019591 RID: 103825
		internal static int __PropertyOffset_33;

		// Token: 0x04019592 RID: 103826
		internal static int __PropertyOffset_34;

		// Token: 0x04019593 RID: 103827
		internal static int __PropertyOffset_35;

		// Token: 0x04019594 RID: 103828
		[Nullable(2)]
		private TArray<long> _SpecialBuffInCode;

		// Token: 0x04019595 RID: 103829
		internal static int __PropertyOffset_36;
	}
}
