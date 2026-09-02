using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.ConfirmBox.Struct
{
	// Token: 0x02003F04 RID: 16132
	[HasGetTypeHash]
	[UnrealBlittableStruct(UnrealReflectionPropertyTypeCode.UnrealBlittableStruct)]
	[UnrealStructLayout(60, 4, UnrealReflectionPropertyTypeCode.UnrealBlittableStruct, PropertiesSize = 60)]
	[UnrealObjectPath("/Game/Aki/Data/ConfirmBox/Struct/SItemComfirmBoxInfo.SItemComfirmBoxInfo")]
	[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 60)]
	public struct SItemComfirmBoxInfo : IEqualityOperators<SItemComfirmBoxInfo, SItemComfirmBoxInfo, bool>, IEquatable<SItemComfirmBoxInfo>, IUnrealScriptStruct
	{
		// Token: 0x060282F0 RID: 164592 RVA: 0x00A0499E File Offset: 0x00A02B9E
		public SItemComfirmBoxInfo(FName Name, FName Title, FName Tips, FName ConfirmText, FName CancelText)
		{
			this.Name = Name;
			this.Title = Title;
			this.Tips = Tips;
			this.ConfirmText = ConfirmText;
			this.CancelText = CancelText;
		}

		// Token: 0x060282F1 RID: 164593 RVA: 0x00A049C8 File Offset: 0x00A02BC8
		public static bool operator ==(SItemComfirmBoxInfo left, SItemComfirmBoxInfo right)
		{
			return left.Name == right.Name && left.Title == right.Title && left.Tips == right.Tips && left.ConfirmText == right.ConfirmText && left.CancelText == right.CancelText;
		}

		// Token: 0x060282F2 RID: 164594 RVA: 0x00A04A34 File Offset: 0x00A02C34
		public static bool operator !=(SItemComfirmBoxInfo left, SItemComfirmBoxInfo right)
		{
			return !(left == right);
		}

		// Token: 0x060282F3 RID: 164595 RVA: 0x00A04A40 File Offset: 0x00A02C40
		public bool Equals(SItemComfirmBoxInfo other)
		{
			return this == other;
		}

		// Token: 0x060282F4 RID: 164596 RVA: 0x00A04A50 File Offset: 0x00A02C50
		[NullableContext(2)]
		public override bool Equals(object obj)
		{
			if (obj is SItemComfirmBoxInfo)
			{
				SItemComfirmBoxInfo other = (SItemComfirmBoxInfo)obj;
				return this.Equals(other);
			}
			return false;
		}

		// Token: 0x060282F5 RID: 164597 RVA: 0x00A04A75 File Offset: 0x00A02C75
		public override int GetHashCode()
		{
			return HashCode.Combine<FName, FName, FName, FName, FName>(this.Name, this.Title, this.Tips, this.ConfirmText, this.CancelText);
		}

		// Token: 0x060282F6 RID: 164598 RVA: 0x00A04A9A File Offset: 0x00A02C9A
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SItemComfirmBoxInfo._ScriptStructPtr != 0) ? SItemComfirmBoxInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/ConfirmBox/Struct/SItemComfirmBoxInfo.SItemComfirmBoxInfo", ref SItemComfirmBoxInfo._ScriptStructPtr);
		}

		// Token: 0x040151F8 RID: 86520
		[FieldOffset(0)]
		public FName Name;

		// Token: 0x040151F9 RID: 86521
		[FieldOffset(12)]
		public FName Title;

		// Token: 0x040151FA RID: 86522
		[FieldOffset(24)]
		public FName Tips;

		// Token: 0x040151FB RID: 86523
		[FieldOffset(36)]
		public FName ConfirmText;

		// Token: 0x040151FC RID: 86524
		[FieldOffset(48)]
		public FName CancelText;

		// Token: 0x040151FD RID: 86525
		public const string __ObjectPath = "/Game/Aki/Data/ConfirmBox/Struct/SItemComfirmBoxInfo.SItemComfirmBoxInfo";

		// Token: 0x040151FE RID: 86526
		private static IntPtr _ScriptStructPtr;
	}
}
