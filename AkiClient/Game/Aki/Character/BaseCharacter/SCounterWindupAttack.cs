using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004253 RID: 16979
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SCounterWindupAttack.SCounterWindupAttack")]
	[UnrealStructLayout(144, 16, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 144)]
	public class SCounterWindupAttack : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CF9C RID: 184220 RVA: 0x00AB49B4 File Offset: 0x00AB2BB4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCounterWindupAttack._ScriptStructPtr != 0) ? SCounterWindupAttack._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SCounterWindupAttack.SCounterWindupAttack", ref SCounterWindupAttack._ScriptStructPtr);
		}

		// Token: 0x170079F8 RID: 31224
		// (get) Token: 0x0602CF9D RID: 184221 RVA: 0x00AB49D8 File Offset: 0x00AB2BD8
		// (set) Token: 0x0602CF9E RID: 184222 RVA: 0x00AB49F7 File Offset: 0x00AB2BF7
		public TSoftObjectPtr<UEffectModelBase> Effect
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)SCounterWindupAttack.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCounterWindupAttack.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x170079F9 RID: 31225
		// (get) Token: 0x0602CF9F RID: 184223 RVA: 0x00AB4A1C File Offset: 0x00AB2C1C
		// (set) Token: 0x0602CFA0 RID: 184224 RVA: 0x00AB4A30 File Offset: 0x00AB2C30
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterWindupAttack.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterWindupAttack.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170079FA RID: 31226
		// (get) Token: 0x0602CFA1 RID: 184225 RVA: 0x00AB4A48 File Offset: 0x00AB2C48
		// (set) Token: 0x0602CFA2 RID: 184226 RVA: 0x00AB4A8B File Offset: 0x00AB2C8B
		public TArray<long> Buff
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._Buff) == null)
				{
					result = (this._Buff = new TArray<long>(base.NativePtr + (IntPtr)SCounterWindupAttack.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Buff.CopyAssign(value);
			}
		}

		// Token: 0x170079FB RID: 31227
		// (get) Token: 0x0602CFA3 RID: 184227 RVA: 0x00AB4A99 File Offset: 0x00AB2C99
		// (set) Token: 0x0602CFA4 RID: 184228 RVA: 0x00AB4AAD File Offset: 0x00AB2CAD
		public unsafe FName SocketName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterWindupAttack.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterWindupAttack.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170079FC RID: 31228
		// (get) Token: 0x0602CFA5 RID: 184229 RVA: 0x00AB4AC2 File Offset: 0x00AB2CC2
		// (set) Token: 0x0602CFA6 RID: 184230 RVA: 0x00AB4AD2 File Offset: 0x00AB2CD2
		public unsafe bool EffectAttach
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterWindupAttack.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterWindupAttack.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x170079FD RID: 31229
		// (get) Token: 0x0602CFA7 RID: 184231 RVA: 0x00AB4AE3 File Offset: 0x00AB2CE3
		// (set) Token: 0x0602CFA8 RID: 184232 RVA: 0x00AB4AF7 File Offset: 0x00AB2CF7
		public unsafe FTransform RelativeTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCounterWindupAttack.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCounterWindupAttack.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x0602CFA9 RID: 184233 RVA: 0x00AB4B0C File Offset: 0x00AB2D0C
		public SCounterWindupAttack()
		{
		}

		// Token: 0x0602CFAA RID: 184234 RVA: 0x00AB4B14 File Offset: 0x00AB2D14
		public SCounterWindupAttack(TSoftObjectPtr<UEffectModelBase> Effect, FGameplayTag Tag, TArray<long> Buff, FName SocketName, bool EffectAttach, FTransform RelativeTransform)
		{
			this.Effect = Effect;
			this.Tag = Tag;
			this.Buff = Buff;
			this.SocketName = SocketName;
			this.EffectAttach = EffectAttach;
			this.RelativeTransform = RelativeTransform;
		}

		// Token: 0x0602CFAB RID: 184235 RVA: 0x00AB4B49 File Offset: 0x00AB2D49
		protected override IntPtr GetUStructPtr()
		{
			return SCounterWindupAttack.StaticStruct();
		}

		// Token: 0x0602CFAC RID: 184236 RVA: 0x00AB4B55 File Offset: 0x00AB2D55
		[NullableContext(2)]
		public SCounterWindupAttack(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CFAD RID: 184237 RVA: 0x00AB4B5F File Offset: 0x00AB2D5F
		public SCounterWindupAttack(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CFAE RID: 184238 RVA: 0x00AB4B6A File Offset: 0x00AB2D6A
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCounterWindupAttack(Pointer, false, true);
		}

		// Token: 0x0602CFAF RID: 184239 RVA: 0x00AB4B74 File Offset: 0x00AB2D74
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCounterWindupAttack(Pointer, MemoryOwner);
		}

		// Token: 0x040193AB RID: 103339
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SCounterWindupAttack.SCounterWindupAttack";

		// Token: 0x040193AC RID: 103340
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040193AD RID: 103341
		internal static int __PropertyOffset_0;

		// Token: 0x040193AE RID: 103342
		internal static int __PropertyOffset_1;

		// Token: 0x040193AF RID: 103343
		internal static int __PropertyOffset_2;

		// Token: 0x040193B0 RID: 103344
		[Nullable(2)]
		private TArray<long> _Buff;

		// Token: 0x040193B1 RID: 103345
		internal static int __PropertyOffset_3;

		// Token: 0x040193B2 RID: 103346
		internal static int __PropertyOffset_4;

		// Token: 0x040193B3 RID: 103347
		internal static int __PropertyOffset_5;
	}
}
