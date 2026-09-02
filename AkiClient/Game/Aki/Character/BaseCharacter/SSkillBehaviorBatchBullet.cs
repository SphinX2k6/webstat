using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004278 RID: 17016
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SSkillBehaviorBatchBullet.SSkillBehaviorBatchBullet")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 41)]
	public class SSkillBehaviorBatchBullet : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D294 RID: 184980 RVA: 0x00AB8F2C File Offset: 0x00AB712C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSkillBehaviorBatchBullet._ScriptStructPtr != 0) ? SSkillBehaviorBatchBullet._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SSkillBehaviorBatchBullet.SSkillBehaviorBatchBullet", ref SSkillBehaviorBatchBullet._ScriptStructPtr);
		}

		// Token: 0x17007AE3 RID: 31459
		// (get) Token: 0x0602D295 RID: 184981 RVA: 0x00AB8F50 File Offset: 0x00AB7150
		// (set) Token: 0x0602D296 RID: 184982 RVA: 0x00AB8F93 File Offset: 0x00AB7193
		[Nullable(1)]
		public TArray<string> Id
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._Id) == null)
				{
					result = (this._Id = new TArray<string>(base.NativePtr + (IntPtr)SSkillBehaviorBatchBullet.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.Id.CopyAssign(value);
			}
		}

		// Token: 0x17007AE4 RID: 31460
		// (get) Token: 0x0602D297 RID: 184983 RVA: 0x00AB8FA1 File Offset: 0x00AB71A1
		// (set) Token: 0x0602D298 RID: 184984 RVA: 0x00AB8FB1 File Offset: 0x00AB71B1
		public unsafe int Number
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorBatchBullet.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorBatchBullet.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007AE5 RID: 31461
		// (get) Token: 0x0602D299 RID: 184985 RVA: 0x00AB8FC2 File Offset: 0x00AB71C2
		// (set) Token: 0x0602D29A RID: 184986 RVA: 0x00AB8FD2 File Offset: 0x00AB71D2
		public unsafe float Interval
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorBatchBullet.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorBatchBullet.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007AE6 RID: 31462
		// (get) Token: 0x0602D29B RID: 184987 RVA: 0x00AB8FE3 File Offset: 0x00AB71E3
		// (set) Token: 0x0602D29C RID: 184988 RVA: 0x00AB8FF3 File Offset: 0x00AB71F3
		public unsafe bool StopOnSkillEnd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorBatchBullet.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorBatchBullet.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007AE7 RID: 31463
		// (get) Token: 0x0602D29D RID: 184989 RVA: 0x00AB9004 File Offset: 0x00AB7204
		// (set) Token: 0x0602D29E RID: 184990 RVA: 0x00AB9018 File Offset: 0x00AB7218
		public unsafe FGameplayTag ContinueWithTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorBatchBullet.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorBatchBullet.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007AE8 RID: 31464
		// (get) Token: 0x0602D29F RID: 184991 RVA: 0x00AB902D File Offset: 0x00AB722D
		// (set) Token: 0x0602D2A0 RID: 184992 RVA: 0x00AB9041 File Offset: 0x00AB7241
		public unsafe TEnumAsByte<EBatchBulletMoveStartMode> StartMoving
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSkillBehaviorBatchBullet.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSkillBehaviorBatchBullet.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x0602D2A1 RID: 184993 RVA: 0x00AB9056 File Offset: 0x00AB7256
		public SSkillBehaviorBatchBullet()
		{
		}

		// Token: 0x0602D2A2 RID: 184994 RVA: 0x00AB905E File Offset: 0x00AB725E
		public SSkillBehaviorBatchBullet([Nullable(1)] TArray<string> Id, int Number, float Interval, bool StopOnSkillEnd, FGameplayTag ContinueWithTag, TEnumAsByte<EBatchBulletMoveStartMode> StartMoving)
		{
			this.Id = Id;
			this.Number = Number;
			this.Interval = Interval;
			this.StopOnSkillEnd = StopOnSkillEnd;
			this.ContinueWithTag = ContinueWithTag;
			this.StartMoving = StartMoving;
		}

		// Token: 0x0602D2A3 RID: 184995 RVA: 0x00AB9093 File Offset: 0x00AB7293
		protected override IntPtr GetUStructPtr()
		{
			return SSkillBehaviorBatchBullet.StaticStruct();
		}

		// Token: 0x0602D2A4 RID: 184996 RVA: 0x00AB909F File Offset: 0x00AB729F
		[NullableContext(2)]
		public SSkillBehaviorBatchBullet(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D2A5 RID: 184997 RVA: 0x00AB90A9 File Offset: 0x00AB72A9
		public SSkillBehaviorBatchBullet(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D2A6 RID: 184998 RVA: 0x00AB90B4 File Offset: 0x00AB72B4
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSkillBehaviorBatchBullet(Pointer, false, true);
		}

		// Token: 0x0602D2A7 RID: 184999 RVA: 0x00AB90BE File Offset: 0x00AB72BE
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSkillBehaviorBatchBullet(Pointer, MemoryOwner);
		}

		// Token: 0x0401951F RID: 103711
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SSkillBehaviorBatchBullet.SSkillBehaviorBatchBullet";

		// Token: 0x04019520 RID: 103712
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019521 RID: 103713
		internal static int __PropertyOffset_0;

		// Token: 0x04019522 RID: 103714
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _Id;

		// Token: 0x04019523 RID: 103715
		internal static int __PropertyOffset_1;

		// Token: 0x04019524 RID: 103716
		internal static int __PropertyOffset_2;

		// Token: 0x04019525 RID: 103717
		internal static int __PropertyOffset_3;

		// Token: 0x04019526 RID: 103718
		internal static int __PropertyOffset_4;

		// Token: 0x04019527 RID: 103719
		internal static int __PropertyOffset_5;
	}
}
