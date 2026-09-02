using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Role.Struct
{
	// Token: 0x02003E0D RID: 15885
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Role/Struct/SRoleResonanceInfo.SRoleResonanceInfo")]
	[UnrealStructLayout(112, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 108)]
	public class SRoleResonanceInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027263 RID: 160355 RVA: 0x009EAE5D File Offset: 0x009E905D
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SRoleResonanceInfo._ScriptStructPtr != 0) ? SRoleResonanceInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Role/Struct/SRoleResonanceInfo.SRoleResonanceInfo", ref SRoleResonanceInfo._ScriptStructPtr);
		}

		// Token: 0x17005B55 RID: 23381
		// (get) Token: 0x06027264 RID: 160356 RVA: 0x009EAE81 File Offset: 0x009E9081
		// (set) Token: 0x06027265 RID: 160357 RVA: 0x009EAE91 File Offset: 0x009E9091
		public unsafe int 共鸣组Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleResonanceInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleResonanceInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005B56 RID: 23382
		// (get) Token: 0x06027266 RID: 160358 RVA: 0x009EAEA2 File Offset: 0x009E90A2
		// (set) Token: 0x06027267 RID: 160359 RVA: 0x009EAEB6 File Offset: 0x009E90B6
		public unsafe FName 共鸣名称
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleResonanceInfo.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleResonanceInfo.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005B57 RID: 23383
		// (get) Token: 0x06027268 RID: 160360 RVA: 0x009EAECB File Offset: 0x009E90CB
		// (set) Token: 0x06027269 RID: 160361 RVA: 0x009EAEDB File Offset: 0x009E90DB
		public unsafe int 共鸣Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleResonanceInfo.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleResonanceInfo.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005B58 RID: 23384
		// (get) Token: 0x0602726A RID: 160362 RVA: 0x009EAEEC File Offset: 0x009E90EC
		// (set) Token: 0x0602726B RID: 160363 RVA: 0x009EAF2F File Offset: 0x009E912F
		public TArray<int> 共鸣效果Id列表
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._共鸣效果Id列表) == null)
				{
					result = (this._共鸣效果Id列表 = new TArray<int>(base.NativePtr + (IntPtr)SRoleResonanceInfo.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.共鸣效果Id列表.CopyAssign(value);
			}
		}

		// Token: 0x17005B59 RID: 23385
		// (get) Token: 0x0602726C RID: 160364 RVA: 0x009EAF3D File Offset: 0x009E913D
		// (set) Token: 0x0602726D RID: 160365 RVA: 0x009EAF51 File Offset: 0x009E9151
		public unsafe FName 共鸣效果描述
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleResonanceInfo.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleResonanceInfo.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005B5A RID: 23386
		// (get) Token: 0x0602726E RID: 160366 RVA: 0x009EAF66 File Offset: 0x009E9166
		// (set) Token: 0x0602726F RID: 160367 RVA: 0x009EAF76 File Offset: 0x009E9176
		public unsafe int 增幅id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleResonanceInfo.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleResonanceInfo.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005B5B RID: 23387
		// (get) Token: 0x06027270 RID: 160368 RVA: 0x009EAF87 File Offset: 0x009E9187
		// (set) Token: 0x06027271 RID: 160369 RVA: 0x009EAFA6 File Offset: 0x009E91A6
		public TSoftObjectPtr<UTexture2D> Icon路径
		{
			get
			{
				return new TSoftObjectPtr<UTexture2D>(base.NativePtr + (IntPtr)SRoleResonanceInfo.__PropertyOffset_6, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SRoleResonanceInfo.__PropertyOffset_6, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005B5C RID: 23388
		// (get) Token: 0x06027272 RID: 160370 RVA: 0x009EAFCB File Offset: 0x009E91CB
		// (set) Token: 0x06027273 RID: 160371 RVA: 0x009EAFDB File Offset: 0x009E91DB
		public unsafe int 共鸣消耗Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SRoleResonanceInfo.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SRoleResonanceInfo.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x06027274 RID: 160372 RVA: 0x009EAFEC File Offset: 0x009E91EC
		public SRoleResonanceInfo()
		{
		}

		// Token: 0x06027275 RID: 160373 RVA: 0x009EAFF4 File Offset: 0x009E91F4
		public SRoleResonanceInfo(int 共鸣组Id, FName 共鸣名称, int 共鸣Id, TArray<int> 共鸣效果Id列表, FName 共鸣效果描述, int 增幅id, TSoftObjectPtr<UTexture2D> Icon路径, int 共鸣消耗Id)
		{
			this.共鸣组Id = 共鸣组Id;
			this.共鸣名称 = 共鸣名称;
			this.共鸣Id = 共鸣Id;
			this.共鸣效果Id列表 = 共鸣效果Id列表;
			this.共鸣效果描述 = 共鸣效果描述;
			this.增幅id = 增幅id;
			this.Icon路径 = Icon路径;
			this.共鸣消耗Id = 共鸣消耗Id;
		}

		// Token: 0x06027276 RID: 160374 RVA: 0x009EB044 File Offset: 0x009E9244
		protected override IntPtr GetUStructPtr()
		{
			return SRoleResonanceInfo.StaticStruct();
		}

		// Token: 0x06027277 RID: 160375 RVA: 0x009EB050 File Offset: 0x009E9250
		[NullableContext(2)]
		public SRoleResonanceInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027278 RID: 160376 RVA: 0x009EB05A File Offset: 0x009E925A
		public SRoleResonanceInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027279 RID: 160377 RVA: 0x009EB065 File Offset: 0x009E9265
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SRoleResonanceInfo(Pointer, false, true);
		}

		// Token: 0x0602727A RID: 160378 RVA: 0x009EB06F File Offset: 0x009E926F
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SRoleResonanceInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04014745 RID: 83781
		public const string __ObjectPath = "/Game/Aki/Data/Role/Struct/SRoleResonanceInfo.SRoleResonanceInfo";

		// Token: 0x04014746 RID: 83782
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014747 RID: 83783
		internal static int __PropertyOffset_0;

		// Token: 0x04014748 RID: 83784
		internal static int __PropertyOffset_1;

		// Token: 0x04014749 RID: 83785
		internal static int __PropertyOffset_2;

		// Token: 0x0401474A RID: 83786
		internal static int __PropertyOffset_3;

		// Token: 0x0401474B RID: 83787
		[Nullable(2)]
		private TArray<int> _共鸣效果Id列表;

		// Token: 0x0401474C RID: 83788
		internal static int __PropertyOffset_4;

		// Token: 0x0401474D RID: 83789
		internal static int __PropertyOffset_5;

		// Token: 0x0401474E RID: 83790
		internal static int __PropertyOffset_6;

		// Token: 0x0401474F RID: 83791
		internal static int __PropertyOffset_7;
	}
}
