using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Role.Struct
{
	// Token: 0x02003E0C RID: 15884
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Role/Struct/SRoleQualityInfo.SRoleQualityInfo")]
	[UnrealStructLayout(128, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 128)]
	public class SRoleQualityInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027253 RID: 160339 RVA: 0x009EACFE File Offset: 0x009E8EFE
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SRoleQualityInfo._ScriptStructPtr != 0) ? SRoleQualityInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Role/Struct/SRoleQualityInfo.SRoleQualityInfo", ref SRoleQualityInfo._ScriptStructPtr);
		}

		// Token: 0x17005B51 RID: 23377
		// (get) Token: 0x06027254 RID: 160340 RVA: 0x009EAD22 File Offset: 0x009E8F22
		// (set) Token: 0x06027255 RID: 160341 RVA: 0x009EAD36 File Offset: 0x009E8F36
		public unsafe FName 品质名称
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleQualityInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleQualityInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005B52 RID: 23378
		// (get) Token: 0x06027256 RID: 160342 RVA: 0x009EAD4B File Offset: 0x009E8F4B
		// (set) Token: 0x06027257 RID: 160343 RVA: 0x009EAD6A File Offset: 0x009E8F6A
		public TSoftObjectPtr<UTexture2D> 品质Icon
		{
			get
			{
				return new TSoftObjectPtr<UTexture2D>(base.NativePtr + (IntPtr)SRoleQualityInfo.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SRoleQualityInfo.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005B53 RID: 23379
		// (get) Token: 0x06027258 RID: 160344 RVA: 0x009EAD8F File Offset: 0x009E8F8F
		// (set) Token: 0x06027259 RID: 160345 RVA: 0x009EADAE File Offset: 0x009E8FAE
		public TSoftObjectPtr<UTexture2D> 卡牌品质边框Icon
		{
			get
			{
				return new TSoftObjectPtr<UTexture2D>(base.NativePtr + (IntPtr)SRoleQualityInfo.__PropertyOffset_2, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SRoleQualityInfo.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005B54 RID: 23380
		// (get) Token: 0x0602725A RID: 160346 RVA: 0x009EADD3 File Offset: 0x009E8FD3
		// (set) Token: 0x0602725B RID: 160347 RVA: 0x009EADE7 File Offset: 0x009E8FE7
		public unsafe FLinearColor 品质颜色
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleQualityInfo.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleQualityInfo.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x0602725C RID: 160348 RVA: 0x009EADFC File Offset: 0x009E8FFC
		public SRoleQualityInfo()
		{
		}

		// Token: 0x0602725D RID: 160349 RVA: 0x009EAE04 File Offset: 0x009E9004
		public SRoleQualityInfo(FName 品质名称, TSoftObjectPtr<UTexture2D> 品质Icon, TSoftObjectPtr<UTexture2D> 卡牌品质边框Icon, FLinearColor 品质颜色)
		{
			this.品质名称 = 品质名称;
			this.品质Icon = 品质Icon;
			this.卡牌品质边框Icon = 卡牌品质边框Icon;
			this.品质颜色 = 品质颜色;
		}

		// Token: 0x0602725E RID: 160350 RVA: 0x009EAE29 File Offset: 0x009E9029
		protected override IntPtr GetUStructPtr()
		{
			return SRoleQualityInfo.StaticStruct();
		}

		// Token: 0x0602725F RID: 160351 RVA: 0x009EAE35 File Offset: 0x009E9035
		[NullableContext(2)]
		public SRoleQualityInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027260 RID: 160352 RVA: 0x009EAE3F File Offset: 0x009E903F
		public SRoleQualityInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027261 RID: 160353 RVA: 0x009EAE4A File Offset: 0x009E904A
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SRoleQualityInfo(Pointer, false, true);
		}

		// Token: 0x06027262 RID: 160354 RVA: 0x009EAE54 File Offset: 0x009E9054
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SRoleQualityInfo(Pointer, MemoryOwner);
		}

		// Token: 0x0401473F RID: 83775
		public const string __ObjectPath = "/Game/Aki/Data/Role/Struct/SRoleQualityInfo.SRoleQualityInfo";

		// Token: 0x04014740 RID: 83776
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014741 RID: 83777
		internal static int __PropertyOffset_0;

		// Token: 0x04014742 RID: 83778
		internal static int __PropertyOffset_1;

		// Token: 0x04014743 RID: 83779
		internal static int __PropertyOffset_2;

		// Token: 0x04014744 RID: 83780
		internal static int __PropertyOffset_3;
	}
}
