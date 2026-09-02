using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.Structure
{
	// Token: 0x0200400D RID: 16397
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/Structure/SSpecialTagListenerInfo.SSpecialTagListenerInfo")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 80)]
	public class SSpecialTagListenerInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602A98F RID: 174479 RVA: 0x00A5D8DE File Offset: 0x00A5BADE
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSpecialTagListenerInfo._ScriptStructPtr != 0) ? SSpecialTagListenerInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/Role/Common/Data/Structure/SSpecialTagListenerInfo.SSpecialTagListenerInfo", ref SSpecialTagListenerInfo._ScriptStructPtr);
		}

		// Token: 0x17006EF0 RID: 28400
		// (get) Token: 0x0602A990 RID: 174480 RVA: 0x00A5D902 File Offset: 0x00A5BB02
		// (set) Token: 0x0602A991 RID: 174481 RVA: 0x00A5D916 File Offset: 0x00A5BB16
		public unsafe FGameplayTag SpecialTagListener
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSpecialTagListenerInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSpecialTagListenerInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006EF1 RID: 28401
		// (get) Token: 0x0602A992 RID: 174482 RVA: 0x00A5D92C File Offset: 0x00A5BB2C
		// (set) Token: 0x0602A993 RID: 174483 RVA: 0x00A5D96F File Offset: 0x00A5BB6F
		public FGameplayTagContainer TargetTagList
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._TargetTagList) == null)
				{
					result = (this._TargetTagList = new FGameplayTagContainer(base.NativePtr + (IntPtr)SSpecialTagListenerInfo.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SSpecialTagListenerInfo.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006EF2 RID: 28402
		// (get) Token: 0x0602A994 RID: 174484 RVA: 0x00A5D990 File Offset: 0x00A5BB90
		// (set) Token: 0x0602A995 RID: 174485 RVA: 0x00A5D9D3 File Offset: 0x00A5BBD3
		public FGameplayTagContainer ForbidTagList
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._ForbidTagList) == null)
				{
					result = (this._ForbidTagList = new FGameplayTagContainer(base.NativePtr + (IntPtr)SSpecialTagListenerInfo.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SSpecialTagListenerInfo.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602A996 RID: 174486 RVA: 0x00A5D9F4 File Offset: 0x00A5BBF4
		public SSpecialTagListenerInfo()
		{
		}

		// Token: 0x0602A997 RID: 174487 RVA: 0x00A5D9FC File Offset: 0x00A5BBFC
		public SSpecialTagListenerInfo(FGameplayTag SpecialTagListener, FGameplayTagContainer TargetTagList, FGameplayTagContainer ForbidTagList)
		{
			this.SpecialTagListener = SpecialTagListener;
			this.TargetTagList = TargetTagList;
			this.ForbidTagList = ForbidTagList;
		}

		// Token: 0x0602A998 RID: 174488 RVA: 0x00A5DA19 File Offset: 0x00A5BC19
		protected override IntPtr GetUStructPtr()
		{
			return SSpecialTagListenerInfo.StaticStruct();
		}

		// Token: 0x0602A999 RID: 174489 RVA: 0x00A5DA25 File Offset: 0x00A5BC25
		[NullableContext(2)]
		public SSpecialTagListenerInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602A99A RID: 174490 RVA: 0x00A5DA2F File Offset: 0x00A5BC2F
		public SSpecialTagListenerInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602A99B RID: 174491 RVA: 0x00A5DA3A File Offset: 0x00A5BC3A
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSpecialTagListenerInfo(Pointer, false, true);
		}

		// Token: 0x0602A99C RID: 174492 RVA: 0x00A5DA44 File Offset: 0x00A5BC44
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSpecialTagListenerInfo(Pointer, MemoryOwner);
		}

		// Token: 0x040172A9 RID: 94889
		public const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/Structure/SSpecialTagListenerInfo.SSpecialTagListenerInfo";

		// Token: 0x040172AA RID: 94890
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040172AB RID: 94891
		internal static int __PropertyOffset_0;

		// Token: 0x040172AC RID: 94892
		internal static int __PropertyOffset_1;

		// Token: 0x040172AD RID: 94893
		[Nullable(2)]
		private FGameplayTagContainer _TargetTagList;

		// Token: 0x040172AE RID: 94894
		internal static int __PropertyOffset_2;

		// Token: 0x040172AF RID: 94895
		[Nullable(2)]
		private FGameplayTagContainer _ForbidTagList;
	}
}
