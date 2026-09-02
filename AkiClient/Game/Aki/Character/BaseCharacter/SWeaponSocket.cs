using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004288 RID: 17032
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SWeaponSocket.SWeaponSocket")]
	[UnrealStructLayout(88, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 88)]
	public class SWeaponSocket : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D3F6 RID: 185334 RVA: 0x00ABAFD3 File Offset: 0x00AB91D3
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SWeaponSocket._ScriptStructPtr != 0) ? SWeaponSocket._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SWeaponSocket.SWeaponSocket", ref SWeaponSocket._ScriptStructPtr);
		}

		// Token: 0x17007B55 RID: 31573
		// (get) Token: 0x0602D3F7 RID: 185335 RVA: 0x00ABAFF8 File Offset: 0x00AB91F8
		// (set) Token: 0x0602D3F8 RID: 185336 RVA: 0x00ABB03B File Offset: 0x00AB923B
		public SWeaponSocketItem Weapon
		{
			get
			{
				base.FastCheckIsValid();
				SWeaponSocketItem result;
				if ((result = this._Weapon) == null)
				{
					result = (this._Weapon = new SWeaponSocketItem(base.NativePtr + (IntPtr)SWeaponSocket.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SWeaponSocketItem.StaticStruct(), base.NativePtr + (IntPtr)SWeaponSocket.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602D3F9 RID: 185337 RVA: 0x00ABB05C File Offset: 0x00AB925C
		public SWeaponSocket()
		{
		}

		// Token: 0x0602D3FA RID: 185338 RVA: 0x00ABB064 File Offset: 0x00AB9264
		public SWeaponSocket(SWeaponSocketItem Weapon)
		{
			this.Weapon = Weapon;
		}

		// Token: 0x0602D3FB RID: 185339 RVA: 0x00ABB073 File Offset: 0x00AB9273
		protected override IntPtr GetUStructPtr()
		{
			return SWeaponSocket.StaticStruct();
		}

		// Token: 0x0602D3FC RID: 185340 RVA: 0x00ABB07F File Offset: 0x00AB927F
		[NullableContext(2)]
		public SWeaponSocket(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D3FD RID: 185341 RVA: 0x00ABB089 File Offset: 0x00AB9289
		public SWeaponSocket(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D3FE RID: 185342 RVA: 0x00ABB094 File Offset: 0x00AB9294
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SWeaponSocket(Pointer, false, true);
		}

		// Token: 0x0602D3FF RID: 185343 RVA: 0x00ABB09E File Offset: 0x00AB929E
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SWeaponSocket(Pointer, MemoryOwner);
		}

		// Token: 0x040195D2 RID: 103890
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SWeaponSocket.SWeaponSocket";

		// Token: 0x040195D3 RID: 103891
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040195D4 RID: 103892
		internal static int __PropertyOffset_0;

		// Token: 0x040195D5 RID: 103893
		[Nullable(2)]
		private SWeaponSocketItem _Weapon;
	}
}
