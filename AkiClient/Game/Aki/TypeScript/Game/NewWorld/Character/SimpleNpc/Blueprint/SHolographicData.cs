using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.TypeScript.Game.NewWorld.Character.SimpleNpc.Blueprint
{
	// Token: 0x020039BF RID: 14783
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/SHolographicData.SHolographicData")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 89)]
	public class SHolographicData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601DE18 RID: 122392 RVA: 0x008E5B9D File Offset: 0x008E3D9D
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SHolographicData._ScriptStructPtr != 0) ? SHolographicData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/SHolographicData.SHolographicData", ref SHolographicData._ScriptStructPtr);
		}

		// Token: 0x170027A2 RID: 10146
		// (get) Token: 0x0601DE19 RID: 122393 RVA: 0x008E5BC1 File Offset: 0x008E3DC1
		// (set) Token: 0x0601DE1A RID: 122394 RVA: 0x008E5BD5 File Offset: 0x008E3DD5
		public unsafe UMaterialInterface ReplaceMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + SHolographicData.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SHolographicData.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170027A3 RID: 10147
		// (get) Token: 0x0601DE1B RID: 122395 RVA: 0x008E5BEA File Offset: 0x008E3DEA
		// (set) Token: 0x0601DE1C RID: 122396 RVA: 0x008E5BFA File Offset: 0x008E3DFA
		public unsafe bool MobileUseDifferentMaterial
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHolographicData.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHolographicData.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x170027A4 RID: 10148
		// (get) Token: 0x0601DE1D RID: 122397 RVA: 0x008E5C0B File Offset: 0x008E3E0B
		// (set) Token: 0x0601DE1E RID: 122398 RVA: 0x008E5C1F File Offset: 0x008E3E1F
		public unsafe UMaterialInterface ReplaceMaterialMobile
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + SHolographicData.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SHolographicData.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170027A5 RID: 10149
		// (get) Token: 0x0601DE1F RID: 122399 RVA: 0x008E5C34 File Offset: 0x008E3E34
		// (set) Token: 0x0601DE20 RID: 122400 RVA: 0x008E5C44 File Offset: 0x008E3E44
		public unsafe bool UseCustomParameters
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHolographicData.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHolographicData.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x170027A6 RID: 10150
		// (get) Token: 0x0601DE21 RID: 122401 RVA: 0x008E5C58 File Offset: 0x008E3E58
		// (set) Token: 0x0601DE22 RID: 122402 RVA: 0x008E5C9B File Offset: 0x008E3E9B
		[Nullable(1)]
		public TArray<SMaterialControllerFloatParameter> CustomFloats
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<SMaterialControllerFloatParameter> result;
				if ((result = this._CustomFloats) == null)
				{
					result = (this._CustomFloats = new TArray<SMaterialControllerFloatParameter>(base.NativePtr + (IntPtr)SHolographicData.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CustomFloats.CopyAssign(value);
			}
		}

		// Token: 0x170027A7 RID: 10151
		// (get) Token: 0x0601DE23 RID: 122403 RVA: 0x008E5CAC File Offset: 0x008E3EAC
		// (set) Token: 0x0601DE24 RID: 122404 RVA: 0x008E5CEF File Offset: 0x008E3EEF
		[Nullable(1)]
		public TArray<SMaterialControllerColorParameter> CustomColors
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<SMaterialControllerColorParameter> result;
				if ((result = this._CustomColors) == null)
				{
					result = (this._CustomColors = new TArray<SMaterialControllerColorParameter>(base.NativePtr + (IntPtr)SHolographicData.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CustomColors.CopyAssign(value);
			}
		}

		// Token: 0x170027A8 RID: 10152
		// (get) Token: 0x0601DE25 RID: 122405 RVA: 0x008E5CFD File Offset: 0x008E3EFD
		// (set) Token: 0x0601DE26 RID: 122406 RVA: 0x008E5D0D File Offset: 0x008E3F0D
		public unsafe bool bActive
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHolographicData.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHolographicData.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x170027A9 RID: 10153
		// (get) Token: 0x0601DE27 RID: 122407 RVA: 0x008E5D1E File Offset: 0x008E3F1E
		// (set) Token: 0x0601DE28 RID: 122408 RVA: 0x008E5D32 File Offset: 0x008E3F32
		public unsafe UTexture2D Tex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + SHolographicData.__PropertyOffset_7);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SHolographicData.__PropertyOffset_7, value);
			}
		}

		// Token: 0x170027AA RID: 10154
		// (get) Token: 0x0601DE29 RID: 122409 RVA: 0x008E5D47 File Offset: 0x008E3F47
		// (set) Token: 0x0601DE2A RID: 122410 RVA: 0x008E5D5B File Offset: 0x008E3F5B
		public unsafe UTexture2D BaseTex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + SHolographicData.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SHolographicData.__PropertyOffset_8, value);
			}
		}

		// Token: 0x170027AB RID: 10155
		// (get) Token: 0x0601DE2B RID: 122411 RVA: 0x008E5D70 File Offset: 0x008E3F70
		// (set) Token: 0x0601DE2C RID: 122412 RVA: 0x008E5D80 File Offset: 0x008E3F80
		public unsafe bool UseDissolve
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SHolographicData.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SHolographicData.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601DE2D RID: 122413 RVA: 0x008E5D91 File Offset: 0x008E3F91
		public SHolographicData()
		{
		}

		// Token: 0x0601DE2E RID: 122414 RVA: 0x008E5D9C File Offset: 0x008E3F9C
		[NullableContext(1)]
		public SHolographicData(UMaterialInterface ReplaceMaterial, bool MobileUseDifferentMaterial, UMaterialInterface ReplaceMaterialMobile, bool UseCustomParameters, TArray<SMaterialControllerFloatParameter> CustomFloats, TArray<SMaterialControllerColorParameter> CustomColors, bool bActive, UTexture2D Tex, UTexture2D BaseTex, bool UseDissolve)
		{
			this.ReplaceMaterial = ReplaceMaterial;
			this.MobileUseDifferentMaterial = MobileUseDifferentMaterial;
			this.ReplaceMaterialMobile = ReplaceMaterialMobile;
			this.UseCustomParameters = UseCustomParameters;
			this.CustomFloats = CustomFloats;
			this.CustomColors = CustomColors;
			this.bActive = bActive;
			this.Tex = Tex;
			this.BaseTex = BaseTex;
			this.UseDissolve = UseDissolve;
		}

		// Token: 0x0601DE2F RID: 122415 RVA: 0x008E5DFC File Offset: 0x008E3FFC
		protected override IntPtr GetUStructPtr()
		{
			return SHolographicData.StaticStruct();
		}

		// Token: 0x0601DE30 RID: 122416 RVA: 0x008E5E08 File Offset: 0x008E4008
		public SHolographicData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601DE31 RID: 122417 RVA: 0x008E5E12 File Offset: 0x008E4012
		public SHolographicData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601DE32 RID: 122418 RVA: 0x008E5E1D File Offset: 0x008E401D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SHolographicData(Pointer, false, true);
		}

		// Token: 0x0601DE33 RID: 122419 RVA: 0x008E5E27 File Offset: 0x008E4027
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SHolographicData(Pointer, MemoryOwner);
		}

		// Token: 0x0400EA35 RID: 59957
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/SHolographicData.SHolographicData";

		// Token: 0x0400EA36 RID: 59958
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400EA37 RID: 59959
		internal static int __PropertyOffset_0;

		// Token: 0x0400EA38 RID: 59960
		internal static int __PropertyOffset_1;

		// Token: 0x0400EA39 RID: 59961
		internal static int __PropertyOffset_2;

		// Token: 0x0400EA3A RID: 59962
		internal static int __PropertyOffset_3;

		// Token: 0x0400EA3B RID: 59963
		internal static int __PropertyOffset_4;

		// Token: 0x0400EA3C RID: 59964
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SMaterialControllerFloatParameter> _CustomFloats;

		// Token: 0x0400EA3D RID: 59965
		internal static int __PropertyOffset_5;

		// Token: 0x0400EA3E RID: 59966
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SMaterialControllerColorParameter> _CustomColors;

		// Token: 0x0400EA3F RID: 59967
		internal static int __PropertyOffset_6;

		// Token: 0x0400EA40 RID: 59968
		internal static int __PropertyOffset_7;

		// Token: 0x0400EA41 RID: 59969
		internal static int __PropertyOffset_8;

		// Token: 0x0400EA42 RID: 59970
		internal static int __PropertyOffset_9;
	}
}
