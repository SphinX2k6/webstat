using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.UiCameraAnimation.Struct
{
	// Token: 0x02003DFC RID: 15868
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/UiCameraAnimation/Struct/SUiCameraAnimationBlendSettings.SUiCameraAnimationBlendSettings")]
	[UnrealStructLayout(192, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 192)]
	public class SUiCameraAnimationBlendSettings : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060270C3 RID: 159939 RVA: 0x009E8B8C File Offset: 0x009E6D8C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SUiCameraAnimationBlendSettings._ScriptStructPtr != 0) ? SUiCameraAnimationBlendSettings._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/UiCameraAnimation/Struct/SUiCameraAnimationBlendSettings.SUiCameraAnimationBlendSettings", ref SUiCameraAnimationBlendSettings._ScriptStructPtr);
		}

		// Token: 0x17005AB5 RID: 23221
		// (get) Token: 0x060270C4 RID: 159940 RVA: 0x009E8BB0 File Offset: 0x009E6DB0
		// (set) Token: 0x060270C5 RID: 159941 RVA: 0x009E8BC0 File Offset: 0x009E6DC0
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationBlendSettings.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationBlendSettings.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005AB6 RID: 23222
		// (get) Token: 0x060270C6 RID: 159942 RVA: 0x009E8BD1 File Offset: 0x009E6DD1
		// (set) Token: 0x060270C7 RID: 159943 RVA: 0x009E8BF0 File Offset: 0x009E6DF0
		public TSoftObjectPtr<ULevelSequence> LevelSequence
		{
			get
			{
				return new TSoftObjectPtr<ULevelSequence>(base.NativePtr + (IntPtr)SUiCameraAnimationBlendSettings.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SUiCameraAnimationBlendSettings.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005AB7 RID: 23223
		// (get) Token: 0x060270C8 RID: 159944 RVA: 0x009E8C15 File Offset: 0x009E6E15
		// (set) Token: 0x060270C9 RID: 159945 RVA: 0x009E8C25 File Offset: 0x009E6E25
		public unsafe float PlayRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationBlendSettings.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationBlendSettings.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005AB8 RID: 23224
		// (get) Token: 0x060270CA RID: 159946 RVA: 0x009E8C36 File Offset: 0x009E6E36
		// (set) Token: 0x060270CB RID: 159947 RVA: 0x009E8C46 File Offset: 0x009E6E46
		public unsafe bool bReverse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiCameraAnimationBlendSettings.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiCameraAnimationBlendSettings.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005AB9 RID: 23225
		// (get) Token: 0x060270CC RID: 159948 RVA: 0x009E8C57 File Offset: 0x009E6E57
		// (set) Token: 0x060270CD RID: 159949 RVA: 0x009E8C76 File Offset: 0x009E6E76
		public TSoftObjectPtr<UCurveFloat> CommonCurve
		{
			get
			{
				return new TSoftObjectPtr<UCurveFloat>(base.NativePtr + (IntPtr)SUiCameraAnimationBlendSettings.__PropertyOffset_4, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SUiCameraAnimationBlendSettings.__PropertyOffset_4, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005ABA RID: 23226
		// (get) Token: 0x060270CE RID: 159950 RVA: 0x009E8C9C File Offset: 0x009E6E9C
		// (set) Token: 0x060270CF RID: 159951 RVA: 0x009E8CDF File Offset: 0x009E6EDF
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		public TMap<TEnumAsByte<EUiCameraAnimationAttributeType>, TSoftObjectPtr<UCurveFloat>> CurveMap
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<EUiCameraAnimationAttributeType>, TSoftObjectPtr<UCurveFloat>> result;
				if ((result = this._CurveMap) == null)
				{
					result = (this._CurveMap = new TMap<TEnumAsByte<EUiCameraAnimationAttributeType>, TSoftObjectPtr<UCurveFloat>>(base.NativePtr + (IntPtr)SUiCameraAnimationBlendSettings.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})]
			set
			{
				this.CurveMap.CopyAssign(value);
			}
		}

		// Token: 0x060270D0 RID: 159952 RVA: 0x009E8CED File Offset: 0x009E6EED
		public SUiCameraAnimationBlendSettings()
		{
		}

		// Token: 0x060270D1 RID: 159953 RVA: 0x009E8CF5 File Offset: 0x009E6EF5
		public SUiCameraAnimationBlendSettings(float Time, TSoftObjectPtr<ULevelSequence> LevelSequence, float PlayRate, bool bReverse, TSoftObjectPtr<UCurveFloat> CommonCurve, [Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})] TMap<TEnumAsByte<EUiCameraAnimationAttributeType>, TSoftObjectPtr<UCurveFloat>> CurveMap)
		{
			this.Time = Time;
			this.LevelSequence = LevelSequence;
			this.PlayRate = PlayRate;
			this.bReverse = bReverse;
			this.CommonCurve = CommonCurve;
			this.CurveMap = CurveMap;
		}

		// Token: 0x060270D2 RID: 159954 RVA: 0x009E8D2A File Offset: 0x009E6F2A
		protected override IntPtr GetUStructPtr()
		{
			return SUiCameraAnimationBlendSettings.StaticStruct();
		}

		// Token: 0x060270D3 RID: 159955 RVA: 0x009E8D36 File Offset: 0x009E6F36
		[NullableContext(2)]
		public SUiCameraAnimationBlendSettings(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060270D4 RID: 159956 RVA: 0x009E8D40 File Offset: 0x009E6F40
		public SUiCameraAnimationBlendSettings(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060270D5 RID: 159957 RVA: 0x009E8D4B File Offset: 0x009E6F4B
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SUiCameraAnimationBlendSettings(Pointer, false, true);
		}

		// Token: 0x060270D6 RID: 159958 RVA: 0x009E8D55 File Offset: 0x009E6F55
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SUiCameraAnimationBlendSettings(Pointer, MemoryOwner);
		}

		// Token: 0x0401465A RID: 83546
		public const string __ObjectPath = "/Game/Aki/Data/UiCameraAnimation/Struct/SUiCameraAnimationBlendSettings.SUiCameraAnimationBlendSettings";

		// Token: 0x0401465B RID: 83547
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401465C RID: 83548
		internal static int __PropertyOffset_0;

		// Token: 0x0401465D RID: 83549
		internal static int __PropertyOffset_1;

		// Token: 0x0401465E RID: 83550
		internal static int __PropertyOffset_2;

		// Token: 0x0401465F RID: 83551
		internal static int __PropertyOffset_3;

		// Token: 0x04014660 RID: 83552
		internal static int __PropertyOffset_4;

		// Token: 0x04014661 RID: 83553
		internal static int __PropertyOffset_5;

		// Token: 0x04014662 RID: 83554
		[Nullable(new byte[]
		{
			2,
			0,
			1,
			1
		})]
		private TMap<TEnumAsByte<EUiCameraAnimationAttributeType>, TSoftObjectPtr<UCurveFloat>> _CurveMap;
	}
}
