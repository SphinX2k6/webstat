using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Role.Struct
{
	// Token: 0x02003E09 RID: 15881
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Role/Struct/SCharacterInputSet.SCharacterInputSet")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 93)]
	public class SCharacterInputSet : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027207 RID: 160263 RVA: 0x009EA63F File Offset: 0x009E883F
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCharacterInputSet._ScriptStructPtr != 0) ? SCharacterInputSet._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Role/Struct/SCharacterInputSet.SCharacterInputSet", ref SCharacterInputSet._ScriptStructPtr);
		}

		// Token: 0x17005B37 RID: 23351
		// (get) Token: 0x06027208 RID: 160264 RVA: 0x009EA663 File Offset: 0x009E8863
		// (set) Token: 0x06027209 RID: 160265 RVA: 0x009EA677 File Offset: 0x009E8877
		public unsafe FName 名称
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005B38 RID: 23352
		// (get) Token: 0x0602720A RID: 160266 RVA: 0x009EA68C File Offset: 0x009E888C
		// (set) Token: 0x0602720B RID: 160267 RVA: 0x009EA69C File Offset: 0x009E889C
		public unsafe bool 是否是大招
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B39 RID: 23353
		// (get) Token: 0x0602720C RID: 160268 RVA: 0x009EA6AD File Offset: 0x009E88AD
		// (set) Token: 0x0602720D RID: 160269 RVA: 0x009EA6BD File Offset: 0x009E88BD
		public unsafe bool 是否是幻象
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B3A RID: 23354
		// (get) Token: 0x0602720E RID: 160270 RVA: 0x009EA6CE File Offset: 0x009E88CE
		// (set) Token: 0x0602720F RID: 160271 RVA: 0x009EA6DE File Offset: 0x009E88DE
		public unsafe int ListenAttributeDataId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005B3B RID: 23355
		// (get) Token: 0x06027210 RID: 160272 RVA: 0x009EA6EF File Offset: 0x009E88EF
		// (set) Token: 0x06027211 RID: 160273 RVA: 0x009EA6FF File Offset: 0x009E88FF
		public unsafe int ListenMaxAttributeDataId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005B3C RID: 23356
		// (get) Token: 0x06027212 RID: 160274 RVA: 0x009EA710 File Offset: 0x009E8910
		// (set) Token: 0x06027213 RID: 160275 RVA: 0x009EA724 File Offset: 0x009E8924
		public unsafe string MaxAttributeEffect
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SCharacterInputSet.__PropertyOffset_5)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SCharacterInputSet.__PropertyOffset_5)), value);
			}
		}

		// Token: 0x17005B3D RID: 23357
		// (get) Token: 0x06027214 RID: 160276 RVA: 0x009EA739 File Offset: 0x009E8939
		// (set) Token: 0x06027215 RID: 160277 RVA: 0x009EA74D File Offset: 0x009E894D
		public unsafe FLinearColor AttributeColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005B3E RID: 23358
		// (get) Token: 0x06027216 RID: 160278 RVA: 0x009EA762 File Offset: 0x009E8962
		// (set) Token: 0x06027217 RID: 160279 RVA: 0x009EA772 File Offset: 0x009E8972
		public unsafe bool bUseElementColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005B3F RID: 23359
		// (get) Token: 0x06027218 RID: 160280 RVA: 0x009EA783 File Offset: 0x009E8983
		// (set) Token: 0x06027219 RID: 160281 RVA: 0x009EA793 File Offset: 0x009E8993
		public unsafe float 长按时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005B40 RID: 23360
		// (get) Token: 0x0602721A RID: 160282 RVA: 0x009EA7A4 File Offset: 0x009E89A4
		// (set) Token: 0x0602721B RID: 160283 RVA: 0x009EA7B4 File Offset: 0x009E89B4
		public unsafe float 按键缓存记录延迟时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005B41 RID: 23361
		// (get) Token: 0x0602721C RID: 160284 RVA: 0x009EA7C8 File Offset: 0x009E89C8
		// (set) Token: 0x0602721D RID: 160285 RVA: 0x009EA80B File Offset: 0x009E8A0B
		public TArray<int> 技能Id列表
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._技能Id列表) == null)
				{
					result = (this._技能Id列表 = new TArray<int>(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_10, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.技能Id列表.CopyAssign(value);
			}
		}

		// Token: 0x17005B42 RID: 23362
		// (get) Token: 0x0602721E RID: 160286 RVA: 0x009EA819 File Offset: 0x009E8A19
		// (set) Token: 0x0602721F RID: 160287 RVA: 0x009EA829 File Offset: 0x009E8A29
		public unsafe int 幻象id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005B43 RID: 23363
		// (get) Token: 0x06027220 RID: 160288 RVA: 0x009EA83A File Offset: 0x009E8A3A
		// (set) Token: 0x06027221 RID: 160289 RVA: 0x009EA84E File Offset: 0x009E8A4E
		[Nullable(0)]
		public unsafe TEnumAsByte<EInputAction> Action
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_12);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterInputSet.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x06027222 RID: 160290 RVA: 0x009EA863 File Offset: 0x009E8A63
		public SCharacterInputSet()
		{
		}

		// Token: 0x06027223 RID: 160291 RVA: 0x009EA86C File Offset: 0x009E8A6C
		public SCharacterInputSet(FName 名称, bool 是否是大招, bool 是否是幻象, int ListenAttributeDataId, int ListenMaxAttributeDataId, string MaxAttributeEffect, FLinearColor AttributeColor, bool bUseElementColor, float 长按时间, float 按键缓存记录延迟时间, TArray<int> 技能Id列表, int 幻象id, [Nullable(0)] TEnumAsByte<EInputAction> Action)
		{
			this.名称 = 名称;
			this.是否是大招 = 是否是大招;
			this.是否是幻象 = 是否是幻象;
			this.ListenAttributeDataId = ListenAttributeDataId;
			this.ListenMaxAttributeDataId = ListenMaxAttributeDataId;
			this.MaxAttributeEffect = MaxAttributeEffect;
			this.AttributeColor = AttributeColor;
			this.bUseElementColor = bUseElementColor;
			this.长按时间 = 长按时间;
			this.按键缓存记录延迟时间 = 按键缓存记录延迟时间;
			this.技能Id列表 = 技能Id列表;
			this.幻象id = 幻象id;
			this.Action = Action;
		}

		// Token: 0x06027224 RID: 160292 RVA: 0x009EA8E4 File Offset: 0x009E8AE4
		protected override IntPtr GetUStructPtr()
		{
			return SCharacterInputSet.StaticStruct();
		}

		// Token: 0x06027225 RID: 160293 RVA: 0x009EA8F0 File Offset: 0x009E8AF0
		[NullableContext(2)]
		public SCharacterInputSet(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027226 RID: 160294 RVA: 0x009EA8FA File Offset: 0x009E8AFA
		public SCharacterInputSet(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027227 RID: 160295 RVA: 0x009EA905 File Offset: 0x009E8B05
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCharacterInputSet(Pointer, false, true);
		}

		// Token: 0x06027228 RID: 160296 RVA: 0x009EA90F File Offset: 0x009E8B0F
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCharacterInputSet(Pointer, MemoryOwner);
		}

		// Token: 0x0401471C RID: 83740
		public const string __ObjectPath = "/Game/Aki/Data/Role/Struct/SCharacterInputSet.SCharacterInputSet";

		// Token: 0x0401471D RID: 83741
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401471E RID: 83742
		internal static int __PropertyOffset_0;

		// Token: 0x0401471F RID: 83743
		internal static int __PropertyOffset_1;

		// Token: 0x04014720 RID: 83744
		internal static int __PropertyOffset_2;

		// Token: 0x04014721 RID: 83745
		internal static int __PropertyOffset_3;

		// Token: 0x04014722 RID: 83746
		internal static int __PropertyOffset_4;

		// Token: 0x04014723 RID: 83747
		internal static int __PropertyOffset_5;

		// Token: 0x04014724 RID: 83748
		internal static int __PropertyOffset_6;

		// Token: 0x04014725 RID: 83749
		internal static int __PropertyOffset_7;

		// Token: 0x04014726 RID: 83750
		internal static int __PropertyOffset_8;

		// Token: 0x04014727 RID: 83751
		internal static int __PropertyOffset_9;

		// Token: 0x04014728 RID: 83752
		internal static int __PropertyOffset_10;

		// Token: 0x04014729 RID: 83753
		[Nullable(2)]
		private TArray<int> _技能Id列表;

		// Token: 0x0401472A RID: 83754
		internal static int __PropertyOffset_11;

		// Token: 0x0401472B RID: 83755
		internal static int __PropertyOffset_12;
	}
}
