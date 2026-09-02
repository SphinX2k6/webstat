using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E41 RID: 15937
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Qte/SCommonQte.SCommonQte")]
	[UnrealStructLayout(1664, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 1664)]
	public class SCommonQte : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602744A RID: 160842 RVA: 0x009EDBE4 File Offset: 0x009EBDE4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCommonQte._ScriptStructPtr != 0) ? SCommonQte._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Qte/SCommonQte.SCommonQte", ref SCommonQte._ScriptStructPtr);
		}

		// Token: 0x17005BE9 RID: 23529
		// (get) Token: 0x0602744B RID: 160843 RVA: 0x009EDC08 File Offset: 0x009EBE08
		// (set) Token: 0x0602744C RID: 160844 RVA: 0x009EDC1C File Offset: 0x009EBE1C
		public unsafe string Desc
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCommonQte.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCommonQte.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005BEA RID: 23530
		// (get) Token: 0x0602744D RID: 160845 RVA: 0x009EDC34 File Offset: 0x009EBE34
		// (set) Token: 0x0602744E RID: 160846 RVA: 0x009EDC77 File Offset: 0x009EBE77
		public SCommonQte_Base BaseConfig
		{
			get
			{
				base.FastCheckIsValid();
				SCommonQte_Base result;
				if ((result = this._BaseConfig) == null)
				{
					result = (this._BaseConfig = new SCommonQte_Base(base.NativePtr + (IntPtr)SCommonQte.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCommonQte_Base.StaticStruct(), base.NativePtr + (IntPtr)SCommonQte.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005BEB RID: 23531
		// (get) Token: 0x0602744F RID: 160847 RVA: 0x009EDC98 File Offset: 0x009EBE98
		// (set) Token: 0x06027450 RID: 160848 RVA: 0x009EDCDB File Offset: 0x009EBEDB
		public SCommonQte_Extra ExtraConfig
		{
			get
			{
				base.FastCheckIsValid();
				SCommonQte_Extra result;
				if ((result = this._ExtraConfig) == null)
				{
					result = (this._ExtraConfig = new SCommonQte_Extra(base.NativePtr + (IntPtr)SCommonQte.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCommonQte_Extra.StaticStruct(), base.NativePtr + (IntPtr)SCommonQte.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005BEC RID: 23532
		// (get) Token: 0x06027451 RID: 160849 RVA: 0x009EDCFC File Offset: 0x009EBEFC
		// (set) Token: 0x06027452 RID: 160850 RVA: 0x009EDD3F File Offset: 0x009EBF3F
		public SCommonQte_Audio AudioConfig
		{
			get
			{
				base.FastCheckIsValid();
				SCommonQte_Audio result;
				if ((result = this._AudioConfig) == null)
				{
					result = (this._AudioConfig = new SCommonQte_Audio(base.NativePtr + (IntPtr)SCommonQte.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCommonQte_Audio.StaticStruct(), base.NativePtr + (IntPtr)SCommonQte.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06027453 RID: 160851 RVA: 0x009EDD60 File Offset: 0x009EBF60
		public SCommonQte()
		{
		}

		// Token: 0x06027454 RID: 160852 RVA: 0x009EDD68 File Offset: 0x009EBF68
		public SCommonQte(string Desc, SCommonQte_Base BaseConfig, SCommonQte_Extra ExtraConfig, SCommonQte_Audio AudioConfig)
		{
			this.Desc = Desc;
			this.BaseConfig = BaseConfig;
			this.ExtraConfig = ExtraConfig;
			this.AudioConfig = AudioConfig;
		}

		// Token: 0x06027455 RID: 160853 RVA: 0x009EDD8D File Offset: 0x009EBF8D
		protected override IntPtr GetUStructPtr()
		{
			return SCommonQte.StaticStruct();
		}

		// Token: 0x06027456 RID: 160854 RVA: 0x009EDD99 File Offset: 0x009EBF99
		[NullableContext(2)]
		public SCommonQte(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027457 RID: 160855 RVA: 0x009EDDA3 File Offset: 0x009EBFA3
		public SCommonQte(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027458 RID: 160856 RVA: 0x009EDDAE File Offset: 0x009EBFAE
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCommonQte(Pointer, false, true);
		}

		// Token: 0x06027459 RID: 160857 RVA: 0x009EDDB8 File Offset: 0x009EBFB8
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCommonQte(Pointer, MemoryOwner);
		}

		// Token: 0x040148F5 RID: 84213
		public const string __ObjectPath = "/Game/Aki/Data/Qte/SCommonQte.SCommonQte";

		// Token: 0x040148F6 RID: 84214
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040148F7 RID: 84215
		internal static int __PropertyOffset_0;

		// Token: 0x040148F8 RID: 84216
		internal static int __PropertyOffset_1;

		// Token: 0x040148F9 RID: 84217
		[Nullable(2)]
		private SCommonQte_Base _BaseConfig;

		// Token: 0x040148FA RID: 84218
		internal static int __PropertyOffset_2;

		// Token: 0x040148FB RID: 84219
		[Nullable(2)]
		private SCommonQte_Extra _ExtraConfig;

		// Token: 0x040148FC RID: 84220
		internal static int __PropertyOffset_3;

		// Token: 0x040148FD RID: 84221
		[Nullable(2)]
		private SCommonQte_Audio _AudioConfig;
	}
}
