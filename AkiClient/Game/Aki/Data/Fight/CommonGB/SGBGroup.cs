using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.CommonGB
{
	// Token: 0x02003EE8 RID: 16104
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/CommonGB/SGBGroup.SGBGroup")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SGBGroup : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602817D RID: 164221 RVA: 0x00A023CD File Offset: 0x00A005CD
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SGBGroup._ScriptStructPtr != 0) ? SGBGroup._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/CommonGB/SGBGroup.SGBGroup", ref SGBGroup._ScriptStructPtr);
		}

		// Token: 0x17006081 RID: 24705
		// (get) Token: 0x0602817E RID: 164222 RVA: 0x00A023F4 File Offset: 0x00A005F4
		// (set) Token: 0x0602817F RID: 164223 RVA: 0x00A02437 File Offset: 0x00A00637
		public TArray<UKuroBpDataAssetGroup> GBGroup
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UKuroBpDataAssetGroup> result;
				if ((result = this._GBGroup) == null)
				{
					result = (this._GBGroup = new TArray<UKuroBpDataAssetGroup>(base.NativePtr + (IntPtr)SGBGroup.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.GBGroup.CopyAssign(value);
			}
		}

		// Token: 0x06028180 RID: 164224 RVA: 0x00A02445 File Offset: 0x00A00645
		public SGBGroup()
		{
		}

		// Token: 0x06028181 RID: 164225 RVA: 0x00A0244D File Offset: 0x00A0064D
		public SGBGroup(TArray<UKuroBpDataAssetGroup> GBGroup)
		{
			this.GBGroup = GBGroup;
		}

		// Token: 0x06028182 RID: 164226 RVA: 0x00A0245C File Offset: 0x00A0065C
		protected override IntPtr GetUStructPtr()
		{
			return SGBGroup.StaticStruct();
		}

		// Token: 0x06028183 RID: 164227 RVA: 0x00A02468 File Offset: 0x00A00668
		[NullableContext(2)]
		public SGBGroup(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06028184 RID: 164228 RVA: 0x00A02472 File Offset: 0x00A00672
		public SGBGroup(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06028185 RID: 164229 RVA: 0x00A0247D File Offset: 0x00A0067D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SGBGroup(Pointer, false, true);
		}

		// Token: 0x06028186 RID: 164230 RVA: 0x00A02487 File Offset: 0x00A00687
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SGBGroup(Pointer, MemoryOwner);
		}

		// Token: 0x040150E6 RID: 86246
		public const string __ObjectPath = "/Game/Aki/Data/Fight/CommonGB/SGBGroup.SGBGroup";

		// Token: 0x040150E7 RID: 86247
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040150E8 RID: 86248
		internal static int __PropertyOffset_0;

		// Token: 0x040150E9 RID: 86249
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UKuroBpDataAssetGroup> _GBGroup;
	}
}
