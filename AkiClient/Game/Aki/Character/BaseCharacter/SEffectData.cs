using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200425B RID: 16987
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SEffectData.SEffectData")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SEffectData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D025 RID: 184357 RVA: 0x00AB5516 File Offset: 0x00AB3716
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SEffectData._ScriptStructPtr != 0) ? SEffectData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SEffectData.SEffectData", ref SEffectData._ScriptStructPtr);
		}

		// Token: 0x17007A1D RID: 31261
		// (get) Token: 0x0602D026 RID: 184358 RVA: 0x00AB553C File Offset: 0x00AB373C
		// (set) Token: 0x0602D027 RID: 184359 RVA: 0x00AB557F File Offset: 0x00AB377F
		public TArray<SEffectType> 效果
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SEffectType> result;
				if ((result = this._效果) == null)
				{
					result = (this._效果 = new TArray<SEffectType>(base.NativePtr + (IntPtr)SEffectData.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.效果.CopyAssign(value);
			}
		}

		// Token: 0x0602D028 RID: 184360 RVA: 0x00AB558D File Offset: 0x00AB378D
		public SEffectData()
		{
		}

		// Token: 0x0602D029 RID: 184361 RVA: 0x00AB5595 File Offset: 0x00AB3795
		public SEffectData(TArray<SEffectType> 效果)
		{
			this.效果 = 效果;
		}

		// Token: 0x0602D02A RID: 184362 RVA: 0x00AB55A4 File Offset: 0x00AB37A4
		protected override IntPtr GetUStructPtr()
		{
			return SEffectData.StaticStruct();
		}

		// Token: 0x0602D02B RID: 184363 RVA: 0x00AB55B0 File Offset: 0x00AB37B0
		[NullableContext(2)]
		public SEffectData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D02C RID: 184364 RVA: 0x00AB55BA File Offset: 0x00AB37BA
		public SEffectData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D02D RID: 184365 RVA: 0x00AB55C5 File Offset: 0x00AB37C5
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SEffectData(Pointer, false, true);
		}

		// Token: 0x0602D02E RID: 184366 RVA: 0x00AB55CF File Offset: 0x00AB37CF
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SEffectData(Pointer, MemoryOwner);
		}

		// Token: 0x040193E8 RID: 103400
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SEffectData.SEffectData";

		// Token: 0x040193E9 RID: 103401
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040193EA RID: 103402
		internal static int __PropertyOffset_0;

		// Token: 0x040193EB RID: 103403
		[Nullable(2)]
		private TArray<SEffectType> _效果;
	}
}
