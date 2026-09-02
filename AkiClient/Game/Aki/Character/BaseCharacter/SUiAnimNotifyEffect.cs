using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004283 RID: 17027
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SUiAnimNotifyEffect.SUiAnimNotifyEffect")]
	[UnrealStructLayout(96, 16, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 81)]
	public class SUiAnimNotifyEffect : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D3A9 RID: 185257 RVA: 0x00ABA913 File Offset: 0x00AB8B13
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SUiAnimNotifyEffect._ScriptStructPtr != 0) ? SUiAnimNotifyEffect._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SUiAnimNotifyEffect.SUiAnimNotifyEffect", ref SUiAnimNotifyEffect._ScriptStructPtr);
		}

		// Token: 0x17007B42 RID: 31554
		// (get) Token: 0x0602D3AA RID: 185258 RVA: 0x00ABA937 File Offset: 0x00AB8B37
		// (set) Token: 0x0602D3AB RID: 185259 RVA: 0x00ABA94B File Offset: 0x00AB8B4B
		public unsafe string SocketName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SUiAnimNotifyEffect.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SUiAnimNotifyEffect.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007B43 RID: 31555
		// (get) Token: 0x0602D3AC RID: 185260 RVA: 0x00ABA960 File Offset: 0x00AB8B60
		// (set) Token: 0x0602D3AD RID: 185261 RVA: 0x00ABA974 File Offset: 0x00AB8B74
		public unsafe FTransform Transform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SUiAnimNotifyEffect.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SUiAnimNotifyEffect.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007B44 RID: 31556
		// (get) Token: 0x0602D3AE RID: 185262 RVA: 0x00ABA98C File Offset: 0x00AB8B8C
		// (set) Token: 0x0602D3AF RID: 185263 RVA: 0x00ABA9CF File Offset: 0x00AB8BCF
		public TArray<TSoftObjectPtr<UObject>> Effects
		{
			get
			{
				base.FastCheckIsValid();
				TArray<TSoftObjectPtr<UObject>> result;
				if ((result = this._Effects) == null)
				{
					result = (this._Effects = new TArray<TSoftObjectPtr<UObject>>(base.NativePtr + (IntPtr)SUiAnimNotifyEffect.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Effects.CopyAssign(value);
			}
		}

		// Token: 0x17007B45 RID: 31557
		// (get) Token: 0x0602D3B0 RID: 185264 RVA: 0x00ABA9DD File Offset: 0x00AB8BDD
		// (set) Token: 0x0602D3B1 RID: 185265 RVA: 0x00ABA9F1 File Offset: 0x00AB8BF1
		[Nullable(0)]
		public unsafe TEnumAsByte<EPerformanceRoleState> AnimState
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SUiAnimNotifyEffect.__PropertyOffset_3);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SUiAnimNotifyEffect.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x0602D3B2 RID: 185266 RVA: 0x00ABAA06 File Offset: 0x00AB8C06
		public SUiAnimNotifyEffect()
		{
		}

		// Token: 0x0602D3B3 RID: 185267 RVA: 0x00ABAA0E File Offset: 0x00AB8C0E
		public SUiAnimNotifyEffect(string SocketName, FTransform Transform, TArray<TSoftObjectPtr<UObject>> Effects, [Nullable(0)] TEnumAsByte<EPerformanceRoleState> AnimState)
		{
			this.SocketName = SocketName;
			this.Transform = Transform;
			this.Effects = Effects;
			this.AnimState = AnimState;
		}

		// Token: 0x0602D3B4 RID: 185268 RVA: 0x00ABAA33 File Offset: 0x00AB8C33
		protected override IntPtr GetUStructPtr()
		{
			return SUiAnimNotifyEffect.StaticStruct();
		}

		// Token: 0x0602D3B5 RID: 185269 RVA: 0x00ABAA3F File Offset: 0x00AB8C3F
		[NullableContext(2)]
		public SUiAnimNotifyEffect(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D3B6 RID: 185270 RVA: 0x00ABAA49 File Offset: 0x00AB8C49
		public SUiAnimNotifyEffect(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D3B7 RID: 185271 RVA: 0x00ABAA54 File Offset: 0x00AB8C54
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SUiAnimNotifyEffect(Pointer, false, true);
		}

		// Token: 0x0602D3B8 RID: 185272 RVA: 0x00ABAA5E File Offset: 0x00AB8C5E
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SUiAnimNotifyEffect(Pointer, MemoryOwner);
		}

		// Token: 0x040195AF RID: 103855
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SUiAnimNotifyEffect.SUiAnimNotifyEffect";

		// Token: 0x040195B0 RID: 103856
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040195B1 RID: 103857
		internal static int __PropertyOffset_0;

		// Token: 0x040195B2 RID: 103858
		internal static int __PropertyOffset_1;

		// Token: 0x040195B3 RID: 103859
		internal static int __PropertyOffset_2;

		// Token: 0x040195B4 RID: 103860
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TArray<TSoftObjectPtr<UObject>> _Effects;

		// Token: 0x040195B5 RID: 103861
		internal static int __PropertyOffset_3;
	}
}
