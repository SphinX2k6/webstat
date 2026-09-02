using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Fight.UI
{
	// Token: 0x02003EC5 RID: 16069
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/UI/SUiEnvironmentProperty.SUiEnvironmentProperty")]
	[UnrealStructLayout(200, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 200)]
	public class SUiEnvironmentProperty : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027EA9 RID: 163497 RVA: 0x009FDDD0 File Offset: 0x009FBFD0
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SUiEnvironmentProperty._ScriptStructPtr != 0) ? SUiEnvironmentProperty._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/UI/SUiEnvironmentProperty.SUiEnvironmentProperty", ref SUiEnvironmentProperty._ScriptStructPtr);
		}

		// Token: 0x17005F80 RID: 24448
		// (get) Token: 0x06027EAA RID: 163498 RVA: 0x009FDDF4 File Offset: 0x009FBFF4
		// (set) Token: 0x06027EAB RID: 163499 RVA: 0x009FDE37 File Offset: 0x009FC037
		public FSoftObjectPath IconFrame
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._IconFrame) == null)
				{
					result = (this._IconFrame = new FSoftObjectPath(base.NativePtr + (IntPtr)SUiEnvironmentProperty.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)SUiEnvironmentProperty.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005F81 RID: 24449
		// (get) Token: 0x06027EAC RID: 163500 RVA: 0x009FDE58 File Offset: 0x009FC058
		// (set) Token: 0x06027EAD RID: 163501 RVA: 0x009FDE9B File Offset: 0x009FC09B
		public FSoftObjectPath Icon
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._Icon) == null)
				{
					result = (this._Icon = new FSoftObjectPath(base.NativePtr + (IntPtr)SUiEnvironmentProperty.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)SUiEnvironmentProperty.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005F82 RID: 24450
		// (get) Token: 0x06027EAE RID: 163502 RVA: 0x009FDEBC File Offset: 0x009FC0BC
		// (set) Token: 0x06027EAF RID: 163503 RVA: 0x009FDEFF File Offset: 0x009FC0FF
		public FSoftObjectPath IconFull
		{
			get
			{
				base.FastCheckIsValid();
				FSoftObjectPath result;
				if ((result = this._IconFull) == null)
				{
					result = (this._IconFull = new FSoftObjectPath(base.NativePtr + (IntPtr)SUiEnvironmentProperty.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FSoftObjectPath.StaticStruct(), base.NativePtr + (IntPtr)SUiEnvironmentProperty.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005F83 RID: 24451
		// (get) Token: 0x06027EB0 RID: 163504 RVA: 0x009FDF20 File Offset: 0x009FC120
		// (set) Token: 0x06027EB1 RID: 163505 RVA: 0x009FDF30 File Offset: 0x009FC130
		public unsafe float WarningPercent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiEnvironmentProperty.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiEnvironmentProperty.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005F84 RID: 24452
		// (get) Token: 0x06027EB2 RID: 163506 RVA: 0x009FDF44 File Offset: 0x009FC144
		// (set) Token: 0x06027EB3 RID: 163507 RVA: 0x009FDF87 File Offset: 0x009FC187
		public TArray<FColor> BgColors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FColor> result;
				if ((result = this._BgColors) == null)
				{
					result = (this._BgColors = new TArray<FColor>(base.NativePtr + (IntPtr)SUiEnvironmentProperty.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.BgColors.CopyAssign(value);
			}
		}

		// Token: 0x17005F85 RID: 24453
		// (get) Token: 0x06027EB4 RID: 163508 RVA: 0x009FDF98 File Offset: 0x009FC198
		// (set) Token: 0x06027EB5 RID: 163509 RVA: 0x009FDFDB File Offset: 0x009FC1DB
		public TArray<FColor> BarColors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FColor> result;
				if ((result = this._BarColors) == null)
				{
					result = (this._BarColors = new TArray<FColor>(base.NativePtr + (IntPtr)SUiEnvironmentProperty.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.BarColors.CopyAssign(value);
			}
		}

		// Token: 0x17005F86 RID: 24454
		// (get) Token: 0x06027EB6 RID: 163510 RVA: 0x009FDFE9 File Offset: 0x009FC1E9
		// (set) Token: 0x06027EB7 RID: 163511 RVA: 0x009FE008 File Offset: 0x009FC208
		public TSoftObjectPtr<EffectScreenPlayData_C> SceneEffect
		{
			get
			{
				return new TSoftObjectPtr<EffectScreenPlayData_C>(base.NativePtr + (IntPtr)SUiEnvironmentProperty.__PropertyOffset_6, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SUiEnvironmentProperty.__PropertyOffset_6, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005F87 RID: 24455
		// (get) Token: 0x06027EB8 RID: 163512 RVA: 0x009FE030 File Offset: 0x009FC230
		// (set) Token: 0x06027EB9 RID: 163513 RVA: 0x009FE073 File Offset: 0x009FC273
		public TArray<FColor> Colors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FColor> result;
				if ((result = this._Colors) == null)
				{
					result = (this._Colors = new TArray<FColor>(base.NativePtr + (IntPtr)SUiEnvironmentProperty.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Colors.CopyAssign(value);
			}
		}

		// Token: 0x06027EBA RID: 163514 RVA: 0x009FE081 File Offset: 0x009FC281
		public SUiEnvironmentProperty()
		{
		}

		// Token: 0x06027EBB RID: 163515 RVA: 0x009FE08C File Offset: 0x009FC28C
		public SUiEnvironmentProperty(FSoftObjectPath IconFrame, FSoftObjectPath Icon, FSoftObjectPath IconFull, float WarningPercent, TArray<FColor> BgColors, TArray<FColor> BarColors, TSoftObjectPtr<EffectScreenPlayData_C> SceneEffect, TArray<FColor> Colors)
		{
			this.IconFrame = IconFrame;
			this.Icon = Icon;
			this.IconFull = IconFull;
			this.WarningPercent = WarningPercent;
			this.BgColors = BgColors;
			this.BarColors = BarColors;
			this.SceneEffect = SceneEffect;
			this.Colors = Colors;
		}

		// Token: 0x06027EBC RID: 163516 RVA: 0x009FE0DC File Offset: 0x009FC2DC
		protected override IntPtr GetUStructPtr()
		{
			return SUiEnvironmentProperty.StaticStruct();
		}

		// Token: 0x06027EBD RID: 163517 RVA: 0x009FE0E8 File Offset: 0x009FC2E8
		[NullableContext(2)]
		public SUiEnvironmentProperty(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027EBE RID: 163518 RVA: 0x009FE0F2 File Offset: 0x009FC2F2
		public SUiEnvironmentProperty(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027EBF RID: 163519 RVA: 0x009FE0FD File Offset: 0x009FC2FD
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SUiEnvironmentProperty(Pointer, false, true);
		}

		// Token: 0x06027EC0 RID: 163520 RVA: 0x009FE107 File Offset: 0x009FC307
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SUiEnvironmentProperty(Pointer, MemoryOwner);
		}

		// Token: 0x04014F48 RID: 85832
		public const string __ObjectPath = "/Game/Aki/Data/Fight/UI/SUiEnvironmentProperty.SUiEnvironmentProperty";

		// Token: 0x04014F49 RID: 85833
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014F4A RID: 85834
		internal static int __PropertyOffset_0;

		// Token: 0x04014F4B RID: 85835
		[Nullable(2)]
		private FSoftObjectPath _IconFrame;

		// Token: 0x04014F4C RID: 85836
		internal static int __PropertyOffset_1;

		// Token: 0x04014F4D RID: 85837
		[Nullable(2)]
		private FSoftObjectPath _Icon;

		// Token: 0x04014F4E RID: 85838
		internal static int __PropertyOffset_2;

		// Token: 0x04014F4F RID: 85839
		[Nullable(2)]
		private FSoftObjectPath _IconFull;

		// Token: 0x04014F50 RID: 85840
		internal static int __PropertyOffset_3;

		// Token: 0x04014F51 RID: 85841
		internal static int __PropertyOffset_4;

		// Token: 0x04014F52 RID: 85842
		[Nullable(2)]
		private TArray<FColor> _BgColors;

		// Token: 0x04014F53 RID: 85843
		internal static int __PropertyOffset_5;

		// Token: 0x04014F54 RID: 85844
		[Nullable(2)]
		private TArray<FColor> _BarColors;

		// Token: 0x04014F55 RID: 85845
		internal static int __PropertyOffset_6;

		// Token: 0x04014F56 RID: 85846
		internal static int __PropertyOffset_7;

		// Token: 0x04014F57 RID: 85847
		[Nullable(2)]
		private TArray<FColor> _Colors;
	}
}
