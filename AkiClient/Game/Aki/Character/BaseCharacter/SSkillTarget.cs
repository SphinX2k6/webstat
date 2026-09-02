using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004280 RID: 17024
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SSkillTarget.SSkillTarget")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 36)]
	public class SSkillTarget : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D36D RID: 185197 RVA: 0x00ABA484 File Offset: 0x00AB8684
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSkillTarget._ScriptStructPtr != 0) ? SSkillTarget._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SSkillTarget.SSkillTarget", ref SSkillTarget._ScriptStructPtr);
		}

		// Token: 0x17007B30 RID: 31536
		// (get) Token: 0x0602D36E RID: 185198 RVA: 0x00ABA4A8 File Offset: 0x00AB86A8
		// (set) Token: 0x0602D36F RID: 185199 RVA: 0x00ABA4B8 File Offset: 0x00AB86B8
		public unsafe int LockOnConfigId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillTarget.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillTarget.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007B31 RID: 31537
		// (get) Token: 0x0602D370 RID: 185200 RVA: 0x00ABA4C9 File Offset: 0x00AB86C9
		// (set) Token: 0x0602D371 RID: 185201 RVA: 0x00ABA4DD File Offset: 0x00AB86DD
		public unsafe TEnumAsByte<ESkillTargetPriority> SkillTargetPriority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillTarget.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillTarget.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007B32 RID: 31538
		// (get) Token: 0x0602D372 RID: 185202 RVA: 0x00ABA4F2 File Offset: 0x00AB86F2
		// (set) Token: 0x0602D373 RID: 185203 RVA: 0x00ABA502 File Offset: 0x00AB8702
		public unsafe bool ShowTarget
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillTarget.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillTarget.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B33 RID: 31539
		// (get) Token: 0x0602D374 RID: 185204 RVA: 0x00ABA513 File Offset: 0x00AB8713
		// (set) Token: 0x0602D375 RID: 185205 RVA: 0x00ABA523 File Offset: 0x00AB8723
		public unsafe bool HateOrLockOnChanged
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillTarget.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillTarget.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B34 RID: 31540
		// (get) Token: 0x0602D376 RID: 185206 RVA: 0x00ABA534 File Offset: 0x00AB8734
		// (set) Token: 0x0602D377 RID: 185207 RVA: 0x00ABA544 File Offset: 0x00AB8744
		public unsafe bool TargetDied
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillTarget.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillTarget.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B35 RID: 31541
		// (get) Token: 0x0602D378 RID: 185208 RVA: 0x00ABA555 File Offset: 0x00AB8755
		// (set) Token: 0x0602D379 RID: 185209 RVA: 0x00ABA565 File Offset: 0x00AB8765
		public unsafe bool GlobalTarget
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillTarget.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillTarget.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007B36 RID: 31542
		// (get) Token: 0x0602D37A RID: 185210 RVA: 0x00ABA576 File Offset: 0x00AB8776
		// (set) Token: 0x0602D37B RID: 185211 RVA: 0x00ABA58A File Offset: 0x00AB878A
		[Nullable(1)]
		public unsafe string BlackboardKey
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSkillTarget.__PropertyOffset_6)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSkillTarget.__PropertyOffset_6)), value);
			}
		}

		// Token: 0x17007B37 RID: 31543
		// (get) Token: 0x0602D37C RID: 185212 RVA: 0x00ABA59F File Offset: 0x00AB879F
		// (set) Token: 0x0602D37D RID: 185213 RVA: 0x00ABA5AF File Offset: 0x00AB87AF
		public unsafe float SkillTargetRemainTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillTarget.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillTarget.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x0602D37E RID: 185214 RVA: 0x00ABA5C0 File Offset: 0x00AB87C0
		public SSkillTarget()
		{
		}

		// Token: 0x0602D37F RID: 185215 RVA: 0x00ABA5C8 File Offset: 0x00AB87C8
		public SSkillTarget(int LockOnConfigId, TEnumAsByte<ESkillTargetPriority> SkillTargetPriority, bool ShowTarget, bool HateOrLockOnChanged, bool TargetDied, bool GlobalTarget, [Nullable(1)] string BlackboardKey, float SkillTargetRemainTime)
		{
			this.LockOnConfigId = LockOnConfigId;
			this.SkillTargetPriority = SkillTargetPriority;
			this.ShowTarget = ShowTarget;
			this.HateOrLockOnChanged = HateOrLockOnChanged;
			this.TargetDied = TargetDied;
			this.GlobalTarget = GlobalTarget;
			this.BlackboardKey = BlackboardKey;
			this.SkillTargetRemainTime = SkillTargetRemainTime;
		}

		// Token: 0x0602D380 RID: 185216 RVA: 0x00ABA618 File Offset: 0x00AB8818
		protected override IntPtr GetUStructPtr()
		{
			return SSkillTarget.StaticStruct();
		}

		// Token: 0x0602D381 RID: 185217 RVA: 0x00ABA624 File Offset: 0x00AB8824
		[NullableContext(2)]
		public SSkillTarget(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D382 RID: 185218 RVA: 0x00ABA62E File Offset: 0x00AB882E
		public SSkillTarget(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D383 RID: 185219 RVA: 0x00ABA639 File Offset: 0x00AB8839
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSkillTarget(Pointer, false, true);
		}

		// Token: 0x0602D384 RID: 185220 RVA: 0x00ABA643 File Offset: 0x00AB8843
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSkillTarget(Pointer, MemoryOwner);
		}

		// Token: 0x04019596 RID: 103830
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SSkillTarget.SSkillTarget";

		// Token: 0x04019597 RID: 103831
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019598 RID: 103832
		internal static int __PropertyOffset_0;

		// Token: 0x04019599 RID: 103833
		internal static int __PropertyOffset_1;

		// Token: 0x0401959A RID: 103834
		internal static int __PropertyOffset_2;

		// Token: 0x0401959B RID: 103835
		internal static int __PropertyOffset_3;

		// Token: 0x0401959C RID: 103836
		internal static int __PropertyOffset_4;

		// Token: 0x0401959D RID: 103837
		internal static int __PropertyOffset_5;

		// Token: 0x0401959E RID: 103838
		internal static int __PropertyOffset_6;

		// Token: 0x0401959F RID: 103839
		internal static int __PropertyOffset_7;
	}
}
