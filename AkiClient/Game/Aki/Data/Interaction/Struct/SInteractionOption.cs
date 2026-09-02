using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Interaction.Enum;
using AkiClient.Game.Aki.Data.Quest.Structures;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Interaction.Struct
{
	// Token: 0x02003E88 RID: 16008
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Interaction/Struct/SInteractionOption.SInteractionOption")]
	[UnrealStructLayout(248, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 241)]
	public class SInteractionOption : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027A6E RID: 162414 RVA: 0x009F7256 File Offset: 0x009F5456
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SInteractionOption._ScriptStructPtr != 0) ? SInteractionOption._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Interaction/Struct/SInteractionOption.SInteractionOption", ref SInteractionOption._ScriptStructPtr);
		}

		// Token: 0x17005E1D RID: 24093
		// (get) Token: 0x06027A6F RID: 162415 RVA: 0x009F727C File Offset: 0x009F547C
		// (set) Token: 0x06027A70 RID: 162416 RVA: 0x009F72BF File Offset: 0x009F54BF
		public unsafe FText 选项内容
		{
			get
			{
				base.FastCheckIsValid();
				FText result;
				if ((result = this._选项内容) == null)
				{
					result = (this._选项内容 = new FText(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				FText.NativeCopy((void*)(base.NativePtr + (byte*)((IntPtr)SInteractionOption.__PropertyOffset_0)), value.NativePtr, 1);
			}
		}

		// Token: 0x17005E1E RID: 24094
		// (get) Token: 0x06027A71 RID: 162417 RVA: 0x009F72DA File Offset: 0x009F54DA
		// (set) Token: 0x06027A72 RID: 162418 RVA: 0x009F72EE File Offset: 0x009F54EE
		[Nullable(0)]
		public unsafe TEnumAsByte<EInteractOptionType> 类型
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_1);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005E1F RID: 24095
		// (get) Token: 0x06027A73 RID: 162419 RVA: 0x009F7303 File Offset: 0x009F5503
		// (set) Token: 0x06027A74 RID: 162420 RVA: 0x009F7317 File Offset: 0x009F5517
		public unsafe FName 解锁条件组ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005E20 RID: 24096
		// (get) Token: 0x06027A75 RID: 162421 RVA: 0x009F732C File Offset: 0x009F552C
		// (set) Token: 0x06027A76 RID: 162422 RVA: 0x009F736F File Offset: 0x009F556F
		public SQuestRequest 任务
		{
			get
			{
				base.FastCheckIsValid();
				SQuestRequest result;
				if ((result = this._任务) == null)
				{
					result = (this._任务 = new SQuestRequest(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SQuestRequest.StaticStruct(), base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005E21 RID: 24097
		// (get) Token: 0x06027A77 RID: 162423 RVA: 0x009F7390 File Offset: 0x009F5590
		// (set) Token: 0x06027A78 RID: 162424 RVA: 0x009F73A4 File Offset: 0x009F55A4
		public unsafe FName 剧情ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005E22 RID: 24098
		// (get) Token: 0x06027A79 RID: 162425 RVA: 0x009F73B9 File Offset: 0x009F55B9
		// (set) Token: 0x06027A7A RID: 162426 RVA: 0x009F73D8 File Offset: 0x009F55D8
		public TSoftObjectPtr<UDataTable> 剧情资源
		{
			get
			{
				return new TSoftObjectPtr<UDataTable>(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_5, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_5, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E23 RID: 24099
		// (get) Token: 0x06027A7B RID: 162427 RVA: 0x009F73FD File Offset: 0x009F55FD
		// (set) Token: 0x06027A7C RID: 162428 RVA: 0x009F7411 File Offset: 0x009F5611
		public unsafe string Plot
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SInteractionOption.__PropertyOffset_6)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SInteractionOption.__PropertyOffset_6)), value);
			}
		}

		// Token: 0x17005E24 RID: 24100
		// (get) Token: 0x06027A7D RID: 162429 RVA: 0x009F7426 File Offset: 0x009F5626
		// (set) Token: 0x06027A7E RID: 162430 RVA: 0x009F743A File Offset: 0x009F563A
		public unsafe FName 事件ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005E25 RID: 24101
		// (get) Token: 0x06027A7F RID: 162431 RVA: 0x009F744F File Offset: 0x009F564F
		// (set) Token: 0x06027A80 RID: 162432 RVA: 0x009F745F File Offset: 0x009F565F
		public unsafe bool 是否关闭交互界面
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005E26 RID: 24102
		// (get) Token: 0x06027A81 RID: 162433 RVA: 0x009F7470 File Offset: 0x009F5670
		// (set) Token: 0x06027A82 RID: 162434 RVA: 0x009F7484 File Offset: 0x009F5684
		public unsafe SInteractionLimit 交互选项限制
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005E27 RID: 24103
		// (get) Token: 0x06027A83 RID: 162435 RVA: 0x009F7499 File Offset: 0x009F5699
		// (set) Token: 0x06027A84 RID: 162436 RVA: 0x009F74B8 File Offset: 0x009F56B8
		public TSoftObjectPtr<UTexture2D> 图标路径
		{
			get
			{
				return new TSoftObjectPtr<UTexture2D>(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_10, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_10, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005E28 RID: 24104
		// (get) Token: 0x06027A85 RID: 162437 RVA: 0x009F74DD File Offset: 0x009F56DD
		// (set) Token: 0x06027A86 RID: 162438 RVA: 0x009F74F1 File Offset: 0x009F56F1
		[Nullable(0)]
		public unsafe TEnumAsByte<EInteractionIconType> 交互图标类型
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_11);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SInteractionOption.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x06027A87 RID: 162439 RVA: 0x009F7506 File Offset: 0x009F5706
		public SInteractionOption()
		{
		}

		// Token: 0x06027A88 RID: 162440 RVA: 0x009F7510 File Offset: 0x009F5710
		public SInteractionOption(FText 选项内容, [Nullable(0)] TEnumAsByte<EInteractOptionType> 类型, FName 解锁条件组ID, SQuestRequest 任务, FName 剧情ID, TSoftObjectPtr<UDataTable> 剧情资源, string Plot, FName 事件ID, bool 是否关闭交互界面, SInteractionLimit 交互选项限制, TSoftObjectPtr<UTexture2D> 图标路径, [Nullable(0)] TEnumAsByte<EInteractionIconType> 交互图标类型)
		{
			this.选项内容 = 选项内容;
			this.类型 = 类型;
			this.解锁条件组ID = 解锁条件组ID;
			this.任务 = 任务;
			this.剧情ID = 剧情ID;
			this.剧情资源 = 剧情资源;
			this.Plot = Plot;
			this.事件ID = 事件ID;
			this.是否关闭交互界面 = 是否关闭交互界面;
			this.交互选项限制 = 交互选项限制;
			this.图标路径 = 图标路径;
			this.交互图标类型 = 交互图标类型;
		}

		// Token: 0x06027A89 RID: 162441 RVA: 0x009F7580 File Offset: 0x009F5780
		protected override IntPtr GetUStructPtr()
		{
			return SInteractionOption.StaticStruct();
		}

		// Token: 0x06027A8A RID: 162442 RVA: 0x009F758C File Offset: 0x009F578C
		[NullableContext(2)]
		public SInteractionOption(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027A8B RID: 162443 RVA: 0x009F7596 File Offset: 0x009F5796
		public SInteractionOption(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027A8C RID: 162444 RVA: 0x009F75A1 File Offset: 0x009F57A1
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SInteractionOption(Pointer, false, true);
		}

		// Token: 0x06027A8D RID: 162445 RVA: 0x009F75AB File Offset: 0x009F57AB
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SInteractionOption(Pointer, MemoryOwner);
		}

		// Token: 0x04014CB0 RID: 85168
		public const string __ObjectPath = "/Game/Aki/Data/Interaction/Struct/SInteractionOption.SInteractionOption";

		// Token: 0x04014CB1 RID: 85169
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014CB2 RID: 85170
		internal static int __PropertyOffset_0;

		// Token: 0x04014CB3 RID: 85171
		[Nullable(2)]
		private FText _选项内容;

		// Token: 0x04014CB4 RID: 85172
		internal static int __PropertyOffset_1;

		// Token: 0x04014CB5 RID: 85173
		internal static int __PropertyOffset_2;

		// Token: 0x04014CB6 RID: 85174
		internal static int __PropertyOffset_3;

		// Token: 0x04014CB7 RID: 85175
		[Nullable(2)]
		private SQuestRequest _任务;

		// Token: 0x04014CB8 RID: 85176
		internal static int __PropertyOffset_4;

		// Token: 0x04014CB9 RID: 85177
		internal static int __PropertyOffset_5;

		// Token: 0x04014CBA RID: 85178
		internal static int __PropertyOffset_6;

		// Token: 0x04014CBB RID: 85179
		internal static int __PropertyOffset_7;

		// Token: 0x04014CBC RID: 85180
		internal static int __PropertyOffset_8;

		// Token: 0x04014CBD RID: 85181
		internal static int __PropertyOffset_9;

		// Token: 0x04014CBE RID: 85182
		internal static int __PropertyOffset_10;

		// Token: 0x04014CBF RID: 85183
		internal static int __PropertyOffset_11;
	}
}
