using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004274 RID: 17012
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SReplaceEffect.SReplaceEffect")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 96)]
	public class SReplaceEffect : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D1F8 RID: 184824 RVA: 0x00AB7FBA File Offset: 0x00AB61BA
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SReplaceEffect._ScriptStructPtr != 0) ? SReplaceEffect._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SReplaceEffect.SReplaceEffect", ref SReplaceEffect._ScriptStructPtr);
		}

		// Token: 0x17007AA5 RID: 31397
		// (get) Token: 0x0602D1F9 RID: 184825 RVA: 0x00AB7FDE File Offset: 0x00AB61DE
		// (set) Token: 0x0602D1FA RID: 184826 RVA: 0x00AB7FFD File Offset: 0x00AB61FD
		public TSoftObjectPtr<UObject> OldEffect
		{
			get
			{
				return new TSoftObjectPtr<UObject>(base.NativePtr + (IntPtr)SReplaceEffect.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SReplaceEffect.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007AA6 RID: 31398
		// (get) Token: 0x0602D1FB RID: 184827 RVA: 0x00AB8022 File Offset: 0x00AB6222
		// (set) Token: 0x0602D1FC RID: 184828 RVA: 0x00AB8041 File Offset: 0x00AB6241
		public TSoftObjectPtr<UObject> NewEffect
		{
			get
			{
				return new TSoftObjectPtr<UObject>(base.NativePtr + (IntPtr)SReplaceEffect.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SReplaceEffect.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x0602D1FD RID: 184829 RVA: 0x00AB8066 File Offset: 0x00AB6266
		public SReplaceEffect()
		{
		}

		// Token: 0x0602D1FE RID: 184830 RVA: 0x00AB806E File Offset: 0x00AB626E
		public SReplaceEffect(TSoftObjectPtr<UObject> OldEffect, TSoftObjectPtr<UObject> NewEffect)
		{
			this.OldEffect = OldEffect;
			this.NewEffect = NewEffect;
		}

		// Token: 0x0602D1FF RID: 184831 RVA: 0x00AB8084 File Offset: 0x00AB6284
		protected override IntPtr GetUStructPtr()
		{
			return SReplaceEffect.StaticStruct();
		}

		// Token: 0x0602D200 RID: 184832 RVA: 0x00AB8090 File Offset: 0x00AB6290
		[NullableContext(2)]
		public SReplaceEffect(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D201 RID: 184833 RVA: 0x00AB809A File Offset: 0x00AB629A
		public SReplaceEffect(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D202 RID: 184834 RVA: 0x00AB80A5 File Offset: 0x00AB62A5
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SReplaceEffect(Pointer, false, true);
		}

		// Token: 0x0602D203 RID: 184835 RVA: 0x00AB80AF File Offset: 0x00AB62AF
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SReplaceEffect(Pointer, MemoryOwner);
		}

		// Token: 0x040194CE RID: 103630
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SReplaceEffect.SReplaceEffect";

		// Token: 0x040194CF RID: 103631
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040194D0 RID: 103632
		internal static int __PropertyOffset_0;

		// Token: 0x040194D1 RID: 103633
		internal static int __PropertyOffset_1;
	}
}
