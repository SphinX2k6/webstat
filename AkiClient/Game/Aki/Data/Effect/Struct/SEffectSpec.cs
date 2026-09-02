using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Effect.Struct
{
	// Token: 0x02003F01 RID: 16129
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Effect/Struct/SEffectSpec.SEffectSpec")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class SEffectSpec : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060282CA RID: 164554 RVA: 0x00A0469B File Offset: 0x00A0289B
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SEffectSpec._ScriptStructPtr != 0) ? SEffectSpec._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Effect/Struct/SEffectSpec.SEffectSpec", ref SEffectSpec._ScriptStructPtr);
		}

		// Token: 0x170060EF RID: 24815
		// (get) Token: 0x060282CB RID: 164555 RVA: 0x00A046BF File Offset: 0x00A028BF
		// (set) Token: 0x060282CC RID: 164556 RVA: 0x00A046D3 File Offset: 0x00A028D3
		public unsafe string Class
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SEffectSpec.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SEffectSpec.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x170060F0 RID: 24816
		// (get) Token: 0x060282CD RID: 164557 RVA: 0x00A046E8 File Offset: 0x00A028E8
		// (set) Token: 0x060282CE RID: 164558 RVA: 0x00A0472B File Offset: 0x00A0292B
		public TArray<string> Effects
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._Effects) == null)
				{
					result = (this._Effects = new TArray<string>(base.NativePtr + (IntPtr)SEffectSpec.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Effects.CopyAssign(value);
			}
		}

		// Token: 0x060282CF RID: 164559 RVA: 0x00A04739 File Offset: 0x00A02939
		public SEffectSpec()
		{
		}

		// Token: 0x060282D0 RID: 164560 RVA: 0x00A04741 File Offset: 0x00A02941
		public SEffectSpec(string Class, TArray<string> Effects)
		{
			this.Class = Class;
			this.Effects = Effects;
		}

		// Token: 0x060282D1 RID: 164561 RVA: 0x00A04757 File Offset: 0x00A02957
		protected override IntPtr GetUStructPtr()
		{
			return SEffectSpec.StaticStruct();
		}

		// Token: 0x060282D2 RID: 164562 RVA: 0x00A04763 File Offset: 0x00A02963
		[NullableContext(2)]
		public SEffectSpec(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060282D3 RID: 164563 RVA: 0x00A0476D File Offset: 0x00A0296D
		public SEffectSpec(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060282D4 RID: 164564 RVA: 0x00A04778 File Offset: 0x00A02978
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SEffectSpec(Pointer, false, true);
		}

		// Token: 0x060282D5 RID: 164565 RVA: 0x00A04782 File Offset: 0x00A02982
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SEffectSpec(Pointer, MemoryOwner);
		}

		// Token: 0x040151E8 RID: 86504
		public const string __ObjectPath = "/Game/Aki/Data/Effect/Struct/SEffectSpec.SEffectSpec";

		// Token: 0x040151E9 RID: 86505
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040151EA RID: 86506
		internal static int __PropertyOffset_0;

		// Token: 0x040151EB RID: 86507
		internal static int __PropertyOffset_1;

		// Token: 0x040151EC RID: 86508
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _Effects;
	}
}
