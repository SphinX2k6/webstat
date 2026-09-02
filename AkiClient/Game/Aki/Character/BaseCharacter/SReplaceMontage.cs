using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004275 RID: 17013
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SReplaceMontage.SReplaceMontage")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 96)]
	public class SReplaceMontage : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D204 RID: 184836 RVA: 0x00AB80B8 File Offset: 0x00AB62B8
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SReplaceMontage._ScriptStructPtr != 0) ? SReplaceMontage._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SReplaceMontage.SReplaceMontage", ref SReplaceMontage._ScriptStructPtr);
		}

		// Token: 0x17007AA7 RID: 31399
		// (get) Token: 0x0602D205 RID: 184837 RVA: 0x00AB80DC File Offset: 0x00AB62DC
		// (set) Token: 0x0602D206 RID: 184838 RVA: 0x00AB80FB File Offset: 0x00AB62FB
		public TSoftObjectPtr<UAnimMontage> OldMontage
		{
			get
			{
				return new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)SReplaceMontage.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SReplaceMontage.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007AA8 RID: 31400
		// (get) Token: 0x0602D207 RID: 184839 RVA: 0x00AB8120 File Offset: 0x00AB6320
		// (set) Token: 0x0602D208 RID: 184840 RVA: 0x00AB813F File Offset: 0x00AB633F
		public TSoftObjectPtr<UAnimMontage> NewMontage
		{
			get
			{
				return new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)SReplaceMontage.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SReplaceMontage.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x0602D209 RID: 184841 RVA: 0x00AB8164 File Offset: 0x00AB6364
		public SReplaceMontage()
		{
		}

		// Token: 0x0602D20A RID: 184842 RVA: 0x00AB816C File Offset: 0x00AB636C
		public SReplaceMontage(TSoftObjectPtr<UAnimMontage> OldMontage, TSoftObjectPtr<UAnimMontage> NewMontage)
		{
			this.OldMontage = OldMontage;
			this.NewMontage = NewMontage;
		}

		// Token: 0x0602D20B RID: 184843 RVA: 0x00AB8182 File Offset: 0x00AB6382
		protected override IntPtr GetUStructPtr()
		{
			return SReplaceMontage.StaticStruct();
		}

		// Token: 0x0602D20C RID: 184844 RVA: 0x00AB818E File Offset: 0x00AB638E
		[NullableContext(2)]
		public SReplaceMontage(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D20D RID: 184845 RVA: 0x00AB8198 File Offset: 0x00AB6398
		public SReplaceMontage(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D20E RID: 184846 RVA: 0x00AB81A3 File Offset: 0x00AB63A3
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SReplaceMontage(Pointer, false, true);
		}

		// Token: 0x0602D20F RID: 184847 RVA: 0x00AB81AD File Offset: 0x00AB63AD
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SReplaceMontage(Pointer, MemoryOwner);
		}

		// Token: 0x040194D2 RID: 103634
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SReplaceMontage.SReplaceMontage";

		// Token: 0x040194D3 RID: 103635
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040194D4 RID: 103636
		internal static int __PropertyOffset_0;

		// Token: 0x040194D5 RID: 103637
		internal static int __PropertyOffset_1;
	}
}
