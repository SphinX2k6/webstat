using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Interaction.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Interaction.Struct
{
	// Token: 0x02003E86 RID: 16006
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Interaction/Struct/SInteractionConfig.SInteractionConfig")]
	[UnrealStructLayout(208, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 202)]
	public class SInteractionConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027A45 RID: 162373 RVA: 0x009F6E28 File Offset: 0x009F5028
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SInteractionConfig._ScriptStructPtr != 0) ? SInteractionConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Interaction/Struct/SInteractionConfig.SInteractionConfig", ref SInteractionConfig._ScriptStructPtr);
		}

		// Token: 0x17005E10 RID: 24080
		// (get) Token: 0x06027A46 RID: 162374 RVA: 0x009F6E4C File Offset: 0x009F504C
		// (set) Token: 0x06027A47 RID: 162375 RVA: 0x009F6E60 File Offset: 0x009F5060
		public unsafe FName ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005E11 RID: 24081
		// (get) Token: 0x06027A48 RID: 162376 RVA: 0x009F6E75 File Offset: 0x009F5075
		// (set) Token: 0x06027A49 RID: 162377 RVA: 0x009F6E89 File Offset: 0x009F5089
		public unsafe FName 组ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005E12 RID: 24082
		// (get) Token: 0x06027A4A RID: 162378 RVA: 0x009F6E9E File Offset: 0x009F509E
		// (set) Token: 0x06027A4B RID: 162379 RVA: 0x009F6EAE File Offset: 0x009F50AE
		public unsafe bool 是否自动触发
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005E13 RID: 24083
		// (get) Token: 0x06027A4C RID: 162380 RVA: 0x009F6EBF File Offset: 0x009F50BF
		// (set) Token: 0x06027A4D RID: 162381 RVA: 0x009F6ED3 File Offset: 0x009F50D3
		[Nullable(0)]
		public unsafe TEnumAsByte<EInteractionType> 交互类型
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_3);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005E14 RID: 24084
		// (get) Token: 0x06027A4E RID: 162382 RVA: 0x009F6EE8 File Offset: 0x009F50E8
		// (set) Token: 0x06027A4F RID: 162383 RVA: 0x009F6F2B File Offset: 0x009F512B
		public TArray<SInteractionOption> 交互选项组
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SInteractionOption> result;
				if ((result = this._交互选项组) == null)
				{
					result = (this._交互选项组 = new TArray<SInteractionOption>(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.交互选项组.CopyAssign(value);
			}
		}

		// Token: 0x17005E15 RID: 24085
		// (get) Token: 0x06027A50 RID: 162384 RVA: 0x009F6F39 File Offset: 0x009F5139
		// (set) Token: 0x06027A51 RID: 162385 RVA: 0x009F6F4D File Offset: 0x009F514D
		public unsafe FName 交互SequenceNetwrokID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005E16 RID: 24086
		// (get) Token: 0x06027A52 RID: 162386 RVA: 0x009F6F62 File Offset: 0x009F5162
		// (set) Token: 0x06027A53 RID: 162387 RVA: 0x009F6F81 File Offset: 0x009F5181
		public TSoftObjectPtr<UDataTable> 交互SequenceNetwrok
		{
			get
			{
				return new TSoftObjectPtr<UDataTable>(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_6, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_6, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E17 RID: 24087
		// (get) Token: 0x06027A54 RID: 162388 RVA: 0x009F6FA6 File Offset: 0x009F51A6
		// (set) Token: 0x06027A55 RID: 162389 RVA: 0x009F6FBA File Offset: 0x009F51BA
		public unsafe FName 交互条件组ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005E18 RID: 24088
		// (get) Token: 0x06027A56 RID: 162390 RVA: 0x009F6FCF File Offset: 0x009F51CF
		// (set) Token: 0x06027A57 RID: 162391 RVA: 0x009F6FDF File Offset: 0x009F51DF
		public unsafe float 交互范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005E19 RID: 24089
		// (get) Token: 0x06027A58 RID: 162392 RVA: 0x009F6FF0 File Offset: 0x009F51F0
		// (set) Token: 0x06027A59 RID: 162393 RVA: 0x009F7033 File Offset: 0x009F5233
		public unsafe FText 描述
		{
			get
			{
				base.FastCheckIsValid();
				FText result;
				if ((result = this._描述) == null)
				{
					result = (this._描述 = new FText(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_9, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				FText.NativeCopy((void*)(base.NativePtr + (byte*)((IntPtr)SInteractionConfig.__PropertyOffset_9)), value.NativePtr, 1);
			}
		}

		// Token: 0x17005E1A RID: 24090
		// (get) Token: 0x06027A5A RID: 162394 RVA: 0x009F704E File Offset: 0x009F524E
		// (set) Token: 0x06027A5B RID: 162395 RVA: 0x009F706D File Offset: 0x009F526D
		public TSoftObjectPtr<UTexture2D> 图标路径
		{
			get
			{
				return new TSoftObjectPtr<UTexture2D>(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_10, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_10, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E1B RID: 24091
		// (get) Token: 0x06027A5C RID: 162396 RVA: 0x009F7092 File Offset: 0x009F5292
		// (set) Token: 0x06027A5D RID: 162397 RVA: 0x009F70A6 File Offset: 0x009F52A6
		[Nullable(0)]
		public unsafe TEnumAsByte<EInteractionIconType> 图标类型
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_11);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005E1C RID: 24092
		// (get) Token: 0x06027A5E RID: 162398 RVA: 0x009F70BB File Offset: 0x009F52BB
		// (set) Token: 0x06027A5F RID: 162399 RVA: 0x009F70CB File Offset: 0x009F52CB
		public unsafe bool 是否添加离开选项
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInteractionConfig.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x06027A60 RID: 162400 RVA: 0x009F70DC File Offset: 0x009F52DC
		public SInteractionConfig()
		{
		}

		// Token: 0x06027A61 RID: 162401 RVA: 0x009F70E4 File Offset: 0x009F52E4
		public SInteractionConfig(FName ID, FName 组ID, bool 是否自动触发, [Nullable(0)] TEnumAsByte<EInteractionType> 交互类型, TArray<SInteractionOption> 交互选项组, FName 交互SequenceNetwrokID, TSoftObjectPtr<UDataTable> 交互SequenceNetwrok, FName 交互条件组ID, float 交互范围, FText 描述, TSoftObjectPtr<UTexture2D> 图标路径, [Nullable(0)] TEnumAsByte<EInteractionIconType> 图标类型, bool 是否添加离开选项)
		{
			this.ID = ID;
			this.组ID = 组ID;
			this.是否自动触发 = 是否自动触发;
			this.交互类型 = 交互类型;
			this.交互选项组 = 交互选项组;
			this.交互SequenceNetwrokID = 交互SequenceNetwrokID;
			this.交互SequenceNetwrok = 交互SequenceNetwrok;
			this.交互条件组ID = 交互条件组ID;
			this.交互范围 = 交互范围;
			this.描述 = 描述;
			this.图标路径 = 图标路径;
			this.图标类型 = 图标类型;
			this.是否添加离开选项 = 是否添加离开选项;
		}

		// Token: 0x06027A62 RID: 162402 RVA: 0x009F715C File Offset: 0x009F535C
		protected override IntPtr GetUStructPtr()
		{
			return SInteractionConfig.StaticStruct();
		}

		// Token: 0x06027A63 RID: 162403 RVA: 0x009F7168 File Offset: 0x009F5368
		[NullableContext(2)]
		public SInteractionConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027A64 RID: 162404 RVA: 0x009F7172 File Offset: 0x009F5372
		public SInteractionConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027A65 RID: 162405 RVA: 0x009F717D File Offset: 0x009F537D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SInteractionConfig(Pointer, false, true);
		}

		// Token: 0x06027A66 RID: 162406 RVA: 0x009F7187 File Offset: 0x009F5387
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SInteractionConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04014C9A RID: 85146
		public const string __ObjectPath = "/Game/Aki/Data/Interaction/Struct/SInteractionConfig.SInteractionConfig";

		// Token: 0x04014C9B RID: 85147
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014C9C RID: 85148
		internal static int __PropertyOffset_0;

		// Token: 0x04014C9D RID: 85149
		internal static int __PropertyOffset_1;

		// Token: 0x04014C9E RID: 85150
		internal static int __PropertyOffset_2;

		// Token: 0x04014C9F RID: 85151
		internal static int __PropertyOffset_3;

		// Token: 0x04014CA0 RID: 85152
		internal static int __PropertyOffset_4;

		// Token: 0x04014CA1 RID: 85153
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SInteractionOption> _交互选项组;

		// Token: 0x04014CA2 RID: 85154
		internal static int __PropertyOffset_5;

		// Token: 0x04014CA3 RID: 85155
		internal static int __PropertyOffset_6;

		// Token: 0x04014CA4 RID: 85156
		internal static int __PropertyOffset_7;

		// Token: 0x04014CA5 RID: 85157
		internal static int __PropertyOffset_8;

		// Token: 0x04014CA6 RID: 85158
		internal static int __PropertyOffset_9;

		// Token: 0x04014CA7 RID: 85159
		[Nullable(2)]
		private FText _描述;

		// Token: 0x04014CA8 RID: 85160
		internal static int __PropertyOffset_10;

		// Token: 0x04014CA9 RID: 85161
		internal static int __PropertyOffset_11;

		// Token: 0x04014CAA RID: 85162
		internal static int __PropertyOffset_12;
	}
}
