using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.AnimNotifyState
{
	// Token: 0x02004330 RID: 17200
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/AnimNotifyState/SAnimNotifyInteractInfo.SAnimNotifyInteractInfo")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 26)]
	public class SAnimNotifyInteractInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602DA16 RID: 186902 RVA: 0x00AC51C1 File Offset: 0x00AC33C1
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAnimNotifyInteractInfo._ScriptStructPtr != 0) ? SAnimNotifyInteractInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/AnimNotifyState/SAnimNotifyInteractInfo.SAnimNotifyInteractInfo", ref SAnimNotifyInteractInfo._ScriptStructPtr);
		}

		// Token: 0x17007D1E RID: 32030
		// (get) Token: 0x0602DA17 RID: 186903 RVA: 0x00AC51E5 File Offset: 0x00AC33E5
		// (set) Token: 0x0602DA18 RID: 186904 RVA: 0x00AC51F5 File Offset: 0x00AC33F5
		public unsafe bool IsShowInteractUi
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAnimNotifyInteractInfo.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAnimNotifyInteractInfo.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007D1F RID: 32031
		// (get) Token: 0x0602DA19 RID: 186905 RVA: 0x00AC5206 File Offset: 0x00AC3406
		// (set) Token: 0x0602DA1A RID: 186906 RVA: 0x00AC521A File Offset: 0x00AC341A
		[Nullable(1)]
		public unsafe string InteractText
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SAnimNotifyInteractInfo.__PropertyOffset_1)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SAnimNotifyInteractInfo.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17007D20 RID: 32032
		// (get) Token: 0x0602DA1B RID: 186907 RVA: 0x00AC522F File Offset: 0x00AC342F
		// (set) Token: 0x0602DA1C RID: 186908 RVA: 0x00AC5243 File Offset: 0x00AC3443
		public unsafe TEnumAsByte<EExternalInteractIcon> InteractIconType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAnimNotifyInteractInfo.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAnimNotifyInteractInfo.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007D21 RID: 32033
		// (get) Token: 0x0602DA1D RID: 186909 RVA: 0x00AC5258 File Offset: 0x00AC3458
		// (set) Token: 0x0602DA1E RID: 186910 RVA: 0x00AC526C File Offset: 0x00AC346C
		public unsafe TEnumAsByte<EInputAction> InputAction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAnimNotifyInteractInfo.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAnimNotifyInteractInfo.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x0602DA1F RID: 186911 RVA: 0x00AC5281 File Offset: 0x00AC3481
		public SAnimNotifyInteractInfo()
		{
		}

		// Token: 0x0602DA20 RID: 186912 RVA: 0x00AC5289 File Offset: 0x00AC3489
		public SAnimNotifyInteractInfo(bool IsShowInteractUi, [Nullable(1)] string InteractText, TEnumAsByte<EExternalInteractIcon> InteractIconType, TEnumAsByte<EInputAction> InputAction)
		{
			this.IsShowInteractUi = IsShowInteractUi;
			this.InteractText = InteractText;
			this.InteractIconType = InteractIconType;
			this.InputAction = InputAction;
		}

		// Token: 0x0602DA21 RID: 186913 RVA: 0x00AC52AE File Offset: 0x00AC34AE
		protected override IntPtr GetUStructPtr()
		{
			return SAnimNotifyInteractInfo.StaticStruct();
		}

		// Token: 0x0602DA22 RID: 186914 RVA: 0x00AC52BA File Offset: 0x00AC34BA
		[NullableContext(2)]
		public SAnimNotifyInteractInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602DA23 RID: 186915 RVA: 0x00AC52C4 File Offset: 0x00AC34C4
		public SAnimNotifyInteractInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602DA24 RID: 186916 RVA: 0x00AC52CF File Offset: 0x00AC34CF
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAnimNotifyInteractInfo(Pointer, false, true);
		}

		// Token: 0x0602DA25 RID: 186917 RVA: 0x00AC52D9 File Offset: 0x00AC34D9
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAnimNotifyInteractInfo(Pointer, MemoryOwner);
		}

		// Token: 0x04019BA0 RID: 105376
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/AnimNotifyState/SAnimNotifyInteractInfo.SAnimNotifyInteractInfo";

		// Token: 0x04019BA1 RID: 105377
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019BA2 RID: 105378
		internal static int __PropertyOffset_0;

		// Token: 0x04019BA3 RID: 105379
		internal static int __PropertyOffset_1;

		// Token: 0x04019BA4 RID: 105380
		internal static int __PropertyOffset_2;

		// Token: 0x04019BA5 RID: 105381
		internal static int __PropertyOffset_3;
	}
}
