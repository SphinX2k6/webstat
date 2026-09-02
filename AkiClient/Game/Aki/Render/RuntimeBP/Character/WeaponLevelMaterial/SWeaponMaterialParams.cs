using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.WeaponLevelMaterial
{
	// Token: 0x02003D5F RID: 15711
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/WeaponLevelMaterial/SWeaponMaterialParams.SWeaponMaterialParams")]
	[UnrealStructLayout(240, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 240)]
	public class SWeaponMaterialParams : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026313 RID: 156435 RVA: 0x009D0840 File Offset: 0x009CEA40
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SWeaponMaterialParams._ScriptStructPtr != 0) ? SWeaponMaterialParams._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/WeaponLevelMaterial/SWeaponMaterialParams.SWeaponMaterialParams", ref SWeaponMaterialParams._ScriptStructPtr);
		}

		// Token: 0x170055EB RID: 21995
		// (get) Token: 0x06026314 RID: 156436 RVA: 0x009D0864 File Offset: 0x009CEA64
		// (set) Token: 0x06026315 RID: 156437 RVA: 0x009D08A7 File Offset: 0x009CEAA7
		public TMap<string, float> FloatParams
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, float> result;
				if ((result = this._FloatParams) == null)
				{
					result = (this._FloatParams = new TMap<string, float>(base.NativePtr + (IntPtr)SWeaponMaterialParams.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.FloatParams.CopyAssign(value);
			}
		}

		// Token: 0x170055EC RID: 21996
		// (get) Token: 0x06026316 RID: 156438 RVA: 0x009D08B8 File Offset: 0x009CEAB8
		// (set) Token: 0x06026317 RID: 156439 RVA: 0x009D08FB File Offset: 0x009CEAFB
		public TMap<string, FLinearColor> ColorParams
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, FLinearColor> result;
				if ((result = this._ColorParams) == null)
				{
					result = (this._ColorParams = new TMap<string, FLinearColor>(base.NativePtr + (IntPtr)SWeaponMaterialParams.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ColorParams.CopyAssign(value);
			}
		}

		// Token: 0x170055ED RID: 21997
		// (get) Token: 0x06026318 RID: 156440 RVA: 0x009D090C File Offset: 0x009CEB0C
		// (set) Token: 0x06026319 RID: 156441 RVA: 0x009D094F File Offset: 0x009CEB4F
		public TMap<string, UTexture> TextureParams
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, UTexture> result;
				if ((result = this._TextureParams) == null)
				{
					result = (this._TextureParams = new TMap<string, UTexture>(base.NativePtr + (IntPtr)SWeaponMaterialParams.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.TextureParams.CopyAssign(value);
			}
		}

		// Token: 0x0602631A RID: 156442 RVA: 0x009D095D File Offset: 0x009CEB5D
		public SWeaponMaterialParams()
		{
		}

		// Token: 0x0602631B RID: 156443 RVA: 0x009D0965 File Offset: 0x009CEB65
		public SWeaponMaterialParams(TMap<string, float> FloatParams, TMap<string, FLinearColor> ColorParams, TMap<string, UTexture> TextureParams)
		{
			this.FloatParams = FloatParams;
			this.ColorParams = ColorParams;
			this.TextureParams = TextureParams;
		}

		// Token: 0x0602631C RID: 156444 RVA: 0x009D0982 File Offset: 0x009CEB82
		protected override IntPtr GetUStructPtr()
		{
			return SWeaponMaterialParams.StaticStruct();
		}

		// Token: 0x0602631D RID: 156445 RVA: 0x009D098E File Offset: 0x009CEB8E
		[NullableContext(2)]
		public SWeaponMaterialParams(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602631E RID: 156446 RVA: 0x009D0998 File Offset: 0x009CEB98
		public SWeaponMaterialParams(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602631F RID: 156447 RVA: 0x009D09A3 File Offset: 0x009CEBA3
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SWeaponMaterialParams(Pointer, false, true);
		}

		// Token: 0x06026320 RID: 156448 RVA: 0x009D09AD File Offset: 0x009CEBAD
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SWeaponMaterialParams(Pointer, MemoryOwner);
		}

		// Token: 0x04013C9A RID: 81050
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/WeaponLevelMaterial/SWeaponMaterialParams.SWeaponMaterialParams";

		// Token: 0x04013C9B RID: 81051
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013C9C RID: 81052
		internal static int __PropertyOffset_0;

		// Token: 0x04013C9D RID: 81053
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, float> _FloatParams;

		// Token: 0x04013C9E RID: 81054
		internal static int __PropertyOffset_1;

		// Token: 0x04013C9F RID: 81055
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, FLinearColor> _ColorParams;

		// Token: 0x04013CA0 RID: 81056
		internal static int __PropertyOffset_2;

		// Token: 0x04013CA1 RID: 81057
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<string, UTexture> _TextureParams;
	}
}
