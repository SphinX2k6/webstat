using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Core.World
{
	// Token: 0x02003F46 RID: 16198
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Core/World/STags.STags")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class STags : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602871A RID: 165658 RVA: 0x00A0B198 File Offset: 0x00A09398
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (STags._ScriptStructPtr != 0) ? STags._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Core/World/STags.STags", ref STags._ScriptStructPtr);
		}

		// Token: 0x17006245 RID: 25157
		// (get) Token: 0x0602871B RID: 165659 RVA: 0x00A0B1BC File Offset: 0x00A093BC
		// (set) Token: 0x0602871C RID: 165660 RVA: 0x00A0B1FF File Offset: 0x00A093FF
		public TArray<string> Tags
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._Tags) == null)
				{
					result = (this._Tags = new TArray<string>(base.NativePtr + (IntPtr)STags.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Tags.CopyAssign(value);
			}
		}

		// Token: 0x17006246 RID: 25158
		// (get) Token: 0x0602871D RID: 165661 RVA: 0x00A0B210 File Offset: 0x00A09410
		// (set) Token: 0x0602871E RID: 165662 RVA: 0x00A0B253 File Offset: 0x00A09453
		public TArray<string> PrivateTags
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._PrivateTags) == null)
				{
					result = (this._PrivateTags = new TArray<string>(base.NativePtr + (IntPtr)STags.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.PrivateTags.CopyAssign(value);
			}
		}

		// Token: 0x0602871F RID: 165663 RVA: 0x00A0B261 File Offset: 0x00A09461
		public STags()
		{
		}

		// Token: 0x06028720 RID: 165664 RVA: 0x00A0B269 File Offset: 0x00A09469
		public STags(TArray<string> Tags, TArray<string> PrivateTags)
		{
			this.Tags = Tags;
			this.PrivateTags = PrivateTags;
		}

		// Token: 0x06028721 RID: 165665 RVA: 0x00A0B27F File Offset: 0x00A0947F
		protected override IntPtr GetUStructPtr()
		{
			return STags.StaticStruct();
		}

		// Token: 0x06028722 RID: 165666 RVA: 0x00A0B28B File Offset: 0x00A0948B
		[NullableContext(2)]
		public STags(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028723 RID: 165667 RVA: 0x00A0B295 File Offset: 0x00A09495
		public STags(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028724 RID: 165668 RVA: 0x00A0B2A0 File Offset: 0x00A094A0
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new STags(Pointer, false, true);
		}

		// Token: 0x06028725 RID: 165669 RVA: 0x00A0B2AA File Offset: 0x00A094AA
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new STags(Pointer, MemoryOwner);
		}

		// Token: 0x0401546F RID: 87151
		public const string __ObjectPath = "/Game/Aki/Core/World/STags.STags";

		// Token: 0x04015470 RID: 87152
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015471 RID: 87153
		internal static int __PropertyOffset_0;

		// Token: 0x04015472 RID: 87154
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _Tags;

		// Token: 0x04015473 RID: 87155
		internal static int __PropertyOffset_1;

		// Token: 0x04015474 RID: 87156
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _PrivateTags;
	}
}
