using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Tools.Data.Struct
{
	// Token: 0x02004296 RID: 17046
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Tools/Data/Struct/SBaseRoleAnimAdditionAssets.SBaseRoleAnimAdditionAssets")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class SBaseRoleAnimAdditionAssets : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D45B RID: 185435 RVA: 0x00ABB93F File Offset: 0x00AB9B3F
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBaseRoleAnimAdditionAssets._ScriptStructPtr != 0) ? SBaseRoleAnimAdditionAssets._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Tools/Data/Struct/SBaseRoleAnimAdditionAssets.SBaseRoleAnimAdditionAssets", ref SBaseRoleAnimAdditionAssets._ScriptStructPtr);
		}

		// Token: 0x17007B64 RID: 31588
		// (get) Token: 0x0602D45C RID: 185436 RVA: 0x00ABB964 File Offset: 0x00AB9B64
		// (set) Token: 0x0602D45D RID: 185437 RVA: 0x00ABB9A7 File Offset: 0x00AB9BA7
		public TArray<string> Paths
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._Paths) == null)
				{
					result = (this._Paths = new TArray<string>(base.NativePtr + (IntPtr)SBaseRoleAnimAdditionAssets.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Paths.CopyAssign(value);
			}
		}

		// Token: 0x17007B65 RID: 31589
		// (get) Token: 0x0602D45E RID: 185438 RVA: 0x00ABB9B8 File Offset: 0x00AB9BB8
		// (set) Token: 0x0602D45F RID: 185439 RVA: 0x00ABB9FB File Offset: 0x00AB9BFB
		public TArray<string> Anims
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._Anims) == null)
				{
					result = (this._Anims = new TArray<string>(base.NativePtr + (IntPtr)SBaseRoleAnimAdditionAssets.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Anims.CopyAssign(value);
			}
		}

		// Token: 0x17007B66 RID: 31590
		// (get) Token: 0x0602D460 RID: 185440 RVA: 0x00ABBA0C File Offset: 0x00AB9C0C
		// (set) Token: 0x0602D461 RID: 185441 RVA: 0x00ABBA4F File Offset: 0x00AB9C4F
		public TArray<string> Ribbons
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._Ribbons) == null)
				{
					result = (this._Ribbons = new TArray<string>(base.NativePtr + (IntPtr)SBaseRoleAnimAdditionAssets.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Ribbons.CopyAssign(value);
			}
		}

		// Token: 0x17007B67 RID: 31591
		// (get) Token: 0x0602D462 RID: 185442 RVA: 0x00ABBA60 File Offset: 0x00AB9C60
		// (set) Token: 0x0602D463 RID: 185443 RVA: 0x00ABBAA3 File Offset: 0x00AB9CA3
		public TArray<string> Blendspaces
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._Blendspaces) == null)
				{
					result = (this._Blendspaces = new TArray<string>(base.NativePtr + (IntPtr)SBaseRoleAnimAdditionAssets.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Blendspaces.CopyAssign(value);
			}
		}

		// Token: 0x0602D464 RID: 185444 RVA: 0x00ABBAB1 File Offset: 0x00AB9CB1
		public SBaseRoleAnimAdditionAssets()
		{
		}

		// Token: 0x0602D465 RID: 185445 RVA: 0x00ABBAB9 File Offset: 0x00AB9CB9
		public SBaseRoleAnimAdditionAssets(TArray<string> Paths, TArray<string> Anims, TArray<string> Ribbons, TArray<string> Blendspaces)
		{
			this.Paths = Paths;
			this.Anims = Anims;
			this.Ribbons = Ribbons;
			this.Blendspaces = Blendspaces;
		}

		// Token: 0x0602D466 RID: 185446 RVA: 0x00ABBADE File Offset: 0x00AB9CDE
		protected override IntPtr GetUStructPtr()
		{
			return SBaseRoleAnimAdditionAssets.StaticStruct();
		}

		// Token: 0x0602D467 RID: 185447 RVA: 0x00ABBAEA File Offset: 0x00AB9CEA
		[NullableContext(2)]
		public SBaseRoleAnimAdditionAssets(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D468 RID: 185448 RVA: 0x00ABBAF4 File Offset: 0x00AB9CF4
		public SBaseRoleAnimAdditionAssets(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D469 RID: 185449 RVA: 0x00ABBAFF File Offset: 0x00AB9CFF
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBaseRoleAnimAdditionAssets(Pointer, false, true);
		}

		// Token: 0x0602D46A RID: 185450 RVA: 0x00ABBB09 File Offset: 0x00AB9D09
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBaseRoleAnimAdditionAssets(Pointer, MemoryOwner);
		}

		// Token: 0x04019611 RID: 103953
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Tools/Data/Struct/SBaseRoleAnimAdditionAssets.SBaseRoleAnimAdditionAssets";

		// Token: 0x04019612 RID: 103954
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019613 RID: 103955
		internal static int __PropertyOffset_0;

		// Token: 0x04019614 RID: 103956
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _Paths;

		// Token: 0x04019615 RID: 103957
		internal static int __PropertyOffset_1;

		// Token: 0x04019616 RID: 103958
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _Anims;

		// Token: 0x04019617 RID: 103959
		internal static int __PropertyOffset_2;

		// Token: 0x04019618 RID: 103960
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _Ribbons;

		// Token: 0x04019619 RID: 103961
		internal static int __PropertyOffset_3;

		// Token: 0x0401961A RID: 103962
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _Blendspaces;
	}
}
