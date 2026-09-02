using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroCS.Liushu
{
	// Token: 0x02003BFC RID: 15356
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Liushu/S_LiushuPreset.S_LiushuPreset")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 77)]
	public class S_LiushuPreset : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06022BF0 RID: 142320 RVA: 0x0096DCC2 File Offset: 0x0096BEC2
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_LiushuPreset._ScriptStructPtr != 0) ? S_LiushuPreset._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Liushu/S_LiushuPreset.S_LiushuPreset", ref S_LiushuPreset._ScriptStructPtr);
		}

		// Token: 0x17004284 RID: 17028
		// (get) Token: 0x06022BF1 RID: 142321 RVA: 0x0096DCE6 File Offset: 0x0096BEE6
		// (set) Token: 0x06022BF2 RID: 142322 RVA: 0x0096DCFA File Offset: 0x0096BEFA
		[Nullable(2)]
		public unsafe UDataTable DT
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + S_LiushuPreset.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + S_LiushuPreset.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17004285 RID: 17029
		// (get) Token: 0x06022BF3 RID: 142323 RVA: 0x0096DD10 File Offset: 0x0096BF10
		// (set) Token: 0x06022BF4 RID: 142324 RVA: 0x0096DD53 File Offset: 0x0096BF53
		public TArray<int> SectionNeedToSwitch
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._SectionNeedToSwitch) == null)
				{
					result = (this._SectionNeedToSwitch = new TArray<int>(base.NativePtr + (IntPtr)S_LiushuPreset.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SectionNeedToSwitch.CopyAssign(value);
			}
		}

		// Token: 0x17004286 RID: 17030
		// (get) Token: 0x06022BF5 RID: 142325 RVA: 0x0096DD64 File Offset: 0x0096BF64
		// (set) Token: 0x06022BF6 RID: 142326 RVA: 0x0096DDA7 File Offset: 0x0096BFA7
		public TArray<UMaterialInstanceConstant> HighQualityMats
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceConstant> result;
				if ((result = this._HighQualityMats) == null)
				{
					result = (this._HighQualityMats = new TArray<UMaterialInstanceConstant>(base.NativePtr + (IntPtr)S_LiushuPreset.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.HighQualityMats.CopyAssign(value);
			}
		}

		// Token: 0x17004287 RID: 17031
		// (get) Token: 0x06022BF7 RID: 142327 RVA: 0x0096DDB8 File Offset: 0x0096BFB8
		// (set) Token: 0x06022BF8 RID: 142328 RVA: 0x0096DDFB File Offset: 0x0096BFFB
		public TArray<UMaterialInstanceConstant> MiddleQualityMats
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceConstant> result;
				if ((result = this._MiddleQualityMats) == null)
				{
					result = (this._MiddleQualityMats = new TArray<UMaterialInstanceConstant>(base.NativePtr + (IntPtr)S_LiushuPreset.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.MiddleQualityMats.CopyAssign(value);
			}
		}

		// Token: 0x17004288 RID: 17032
		// (get) Token: 0x06022BF9 RID: 142329 RVA: 0x0096DE0C File Offset: 0x0096C00C
		// (set) Token: 0x06022BFA RID: 142330 RVA: 0x0096DE4F File Offset: 0x0096C04F
		public TArray<UMaterialInstanceConstant> LowQualityMats
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInstanceConstant> result;
				if ((result = this._LowQualityMats) == null)
				{
					result = (this._LowQualityMats = new TArray<UMaterialInstanceConstant>(base.NativePtr + (IntPtr)S_LiushuPreset.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.LowQualityMats.CopyAssign(value);
			}
		}

		// Token: 0x17004289 RID: 17033
		// (get) Token: 0x06022BFB RID: 142331 RVA: 0x0096DE5D File Offset: 0x0096C05D
		// (set) Token: 0x06022BFC RID: 142332 RVA: 0x0096DE6D File Offset: 0x0096C06D
		public unsafe float BoundScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_LiushuPreset.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_LiushuPreset.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700428A RID: 17034
		// (get) Token: 0x06022BFD RID: 142333 RVA: 0x0096DE7E File Offset: 0x0096C07E
		// (set) Token: 0x06022BFE RID: 142334 RVA: 0x0096DE8E File Offset: 0x0096C08E
		public unsafe bool bAutoSetCenterBox
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_LiushuPreset.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_LiushuPreset.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x06022BFF RID: 142335 RVA: 0x0096DE9F File Offset: 0x0096C09F
		public S_LiushuPreset()
		{
		}

		// Token: 0x06022C00 RID: 142336 RVA: 0x0096DEA7 File Offset: 0x0096C0A7
		public S_LiushuPreset(UDataTable DT, TArray<int> SectionNeedToSwitch, TArray<UMaterialInstanceConstant> HighQualityMats, TArray<UMaterialInstanceConstant> MiddleQualityMats, TArray<UMaterialInstanceConstant> LowQualityMats, float BoundScale, bool bAutoSetCenterBox)
		{
			this.DT = DT;
			this.SectionNeedToSwitch = SectionNeedToSwitch;
			this.HighQualityMats = HighQualityMats;
			this.MiddleQualityMats = MiddleQualityMats;
			this.LowQualityMats = LowQualityMats;
			this.BoundScale = BoundScale;
			this.bAutoSetCenterBox = bAutoSetCenterBox;
		}

		// Token: 0x06022C01 RID: 142337 RVA: 0x0096DEE4 File Offset: 0x0096C0E4
		protected override IntPtr GetUStructPtr()
		{
			return S_LiushuPreset.StaticStruct();
		}

		// Token: 0x06022C02 RID: 142338 RVA: 0x0096DEF0 File Offset: 0x0096C0F0
		[NullableContext(2)]
		public S_LiushuPreset(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06022C03 RID: 142339 RVA: 0x0096DEFA File Offset: 0x0096C0FA
		public S_LiushuPreset(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06022C04 RID: 142340 RVA: 0x0096DF05 File Offset: 0x0096C105
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new S_LiushuPreset(Pointer, false, true);
		}

		// Token: 0x06022C05 RID: 142341 RVA: 0x0096DF0F File Offset: 0x0096C10F
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new S_LiushuPreset(Pointer, MemoryOwner);
		}

		// Token: 0x040119EF RID: 72175
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/KuroCS/Liushu/S_LiushuPreset.S_LiushuPreset";

		// Token: 0x040119F0 RID: 72176
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040119F1 RID: 72177
		internal static int __PropertyOffset_0;

		// Token: 0x040119F2 RID: 72178
		internal static int __PropertyOffset_1;

		// Token: 0x040119F3 RID: 72179
		[Nullable(2)]
		private TArray<int> _SectionNeedToSwitch;

		// Token: 0x040119F4 RID: 72180
		internal static int __PropertyOffset_2;

		// Token: 0x040119F5 RID: 72181
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceConstant> _HighQualityMats;

		// Token: 0x040119F6 RID: 72182
		internal static int __PropertyOffset_3;

		// Token: 0x040119F7 RID: 72183
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceConstant> _MiddleQualityMats;

		// Token: 0x040119F8 RID: 72184
		internal static int __PropertyOffset_4;

		// Token: 0x040119F9 RID: 72185
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInstanceConstant> _LowQualityMats;

		// Token: 0x040119FA RID: 72186
		internal static int __PropertyOffset_5;

		// Token: 0x040119FB RID: 72187
		internal static int __PropertyOffset_6;
	}
}
