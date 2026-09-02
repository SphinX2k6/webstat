using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004239 RID: 16953
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SAudioEventProbabilityCooldownInfo.SAudioEventProbabilityCooldownInfo")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SAudioEventProbabilityCooldownInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CD65 RID: 183653 RVA: 0x00AB14B8 File Offset: 0x00AAF6B8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAudioEventProbabilityCooldownInfo._ScriptStructPtr != 0) ? SAudioEventProbabilityCooldownInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SAudioEventProbabilityCooldownInfo.SAudioEventProbabilityCooldownInfo", ref SAudioEventProbabilityCooldownInfo._ScriptStructPtr);
		}

		// Token: 0x17007943 RID: 31043
		// (get) Token: 0x0602CD66 RID: 183654 RVA: 0x00AB14DC File Offset: 0x00AAF6DC
		// (set) Token: 0x0602CD67 RID: 183655 RVA: 0x00AB14EC File Offset: 0x00AAF6EC
		public unsafe float DefaultProbability
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAudioEventProbabilityCooldownInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAudioEventProbabilityCooldownInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007944 RID: 31044
		// (get) Token: 0x0602CD68 RID: 183656 RVA: 0x00AB14FD File Offset: 0x00AAF6FD
		// (set) Token: 0x0602CD69 RID: 183657 RVA: 0x00AB150D File Offset: 0x00AAF70D
		public unsafe int DefaultCooldownTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAudioEventProbabilityCooldownInfo.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAudioEventProbabilityCooldownInfo.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007945 RID: 31045
		// (get) Token: 0x0602CD6A RID: 183658 RVA: 0x00AB1520 File Offset: 0x00AAF720
		// (set) Token: 0x0602CD6B RID: 183659 RVA: 0x00AB1563 File Offset: 0x00AAF763
		public TArray<SGameplayTagProbabilityCooldownInfo> TagProbability
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SGameplayTagProbabilityCooldownInfo> result;
				if ((result = this._TagProbability) == null)
				{
					result = (this._TagProbability = new TArray<SGameplayTagProbabilityCooldownInfo>(base.NativePtr + (IntPtr)SAudioEventProbabilityCooldownInfo.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.TagProbability.CopyAssign(value);
			}
		}

		// Token: 0x0602CD6C RID: 183660 RVA: 0x00AB1571 File Offset: 0x00AAF771
		public SAudioEventProbabilityCooldownInfo()
		{
		}

		// Token: 0x0602CD6D RID: 183661 RVA: 0x00AB1579 File Offset: 0x00AAF779
		public SAudioEventProbabilityCooldownInfo(float DefaultProbability, int DefaultCooldownTime, TArray<SGameplayTagProbabilityCooldownInfo> TagProbability)
		{
			this.DefaultProbability = DefaultProbability;
			this.DefaultCooldownTime = DefaultCooldownTime;
			this.TagProbability = TagProbability;
		}

		// Token: 0x0602CD6E RID: 183662 RVA: 0x00AB1596 File Offset: 0x00AAF796
		protected override IntPtr GetUStructPtr()
		{
			return SAudioEventProbabilityCooldownInfo.StaticStruct();
		}

		// Token: 0x0602CD6F RID: 183663 RVA: 0x00AB15A2 File Offset: 0x00AAF7A2
		[NullableContext(2)]
		public SAudioEventProbabilityCooldownInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CD70 RID: 183664 RVA: 0x00AB15AC File Offset: 0x00AAF7AC
		public SAudioEventProbabilityCooldownInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CD71 RID: 183665 RVA: 0x00AB15B7 File Offset: 0x00AAF7B7
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAudioEventProbabilityCooldownInfo(Pointer, false, true);
		}

		// Token: 0x0602CD72 RID: 183666 RVA: 0x00AB15C1 File Offset: 0x00AAF7C1
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAudioEventProbabilityCooldownInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04019293 RID: 103059
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SAudioEventProbabilityCooldownInfo.SAudioEventProbabilityCooldownInfo";

		// Token: 0x04019294 RID: 103060
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019295 RID: 103061
		internal static int __PropertyOffset_0;

		// Token: 0x04019296 RID: 103062
		internal static int __PropertyOffset_1;

		// Token: 0x04019297 RID: 103063
		internal static int __PropertyOffset_2;

		// Token: 0x04019298 RID: 103064
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SGameplayTagProbabilityCooldownInfo> _TagProbability;
	}
}
