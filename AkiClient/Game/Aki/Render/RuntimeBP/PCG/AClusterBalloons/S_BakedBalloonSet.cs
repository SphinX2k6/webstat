using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.AClusterBalloons
{
	// Token: 0x02003C4F RID: 15439
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/S_BakedBalloonSet.S_BakedBalloonSet")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 40)]
	public class S_BakedBalloonSet : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06023986 RID: 145798 RVA: 0x00986A2C File Offset: 0x00984C2C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_BakedBalloonSet._ScriptStructPtr != 0) ? S_BakedBalloonSet._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/S_BakedBalloonSet.S_BakedBalloonSet", ref S_BakedBalloonSet._ScriptStructPtr);
		}

		// Token: 0x17004750 RID: 18256
		// (get) Token: 0x06023987 RID: 145799 RVA: 0x00986A50 File Offset: 0x00984C50
		// (set) Token: 0x06023988 RID: 145800 RVA: 0x00986A93 File Offset: 0x00984C93
		[Nullable(1)]
		public TArray<UStaticMesh> SMarr
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMesh> result;
				if ((result = this._SMarr) == null)
				{
					result = (this._SMarr = new TArray<UStaticMesh>(base.NativePtr + (IntPtr)S_BakedBalloonSet.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.SMarr.CopyAssign(value);
			}
		}

		// Token: 0x17004751 RID: 18257
		// (get) Token: 0x06023989 RID: 145801 RVA: 0x00986AA1 File Offset: 0x00984CA1
		// (set) Token: 0x0602398A RID: 145802 RVA: 0x00986AB5 File Offset: 0x00984CB5
		public unsafe UDataTable BakedDA
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + S_BakedBalloonSet.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + S_BakedBalloonSet.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004752 RID: 18258
		// (get) Token: 0x0602398B RID: 145803 RVA: 0x00986ACA File Offset: 0x00984CCA
		// (set) Token: 0x0602398C RID: 145804 RVA: 0x00986ADE File Offset: 0x00984CDE
		public unsafe UTexture2D Tex
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + S_BakedBalloonSet.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + S_BakedBalloonSet.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004753 RID: 18259
		// (get) Token: 0x0602398D RID: 145805 RVA: 0x00986AF3 File Offset: 0x00984CF3
		// (set) Token: 0x0602398E RID: 145806 RVA: 0x00986B07 File Offset: 0x00984D07
		public unsafe UTexture2D Tex_N
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + S_BakedBalloonSet.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + S_BakedBalloonSet.__PropertyOffset_3, value);
			}
		}

		// Token: 0x0602398F RID: 145807 RVA: 0x00986B1C File Offset: 0x00984D1C
		public S_BakedBalloonSet()
		{
		}

		// Token: 0x06023990 RID: 145808 RVA: 0x00986B24 File Offset: 0x00984D24
		[NullableContext(1)]
		public S_BakedBalloonSet(TArray<UStaticMesh> SMarr, UDataTable BakedDA, UTexture2D Tex, UTexture2D Tex_N)
		{
			this.SMarr = SMarr;
			this.BakedDA = BakedDA;
			this.Tex = Tex;
			this.Tex_N = Tex_N;
		}

		// Token: 0x06023991 RID: 145809 RVA: 0x00986B49 File Offset: 0x00984D49
		protected override IntPtr GetUStructPtr()
		{
			return S_BakedBalloonSet.StaticStruct();
		}

		// Token: 0x06023992 RID: 145810 RVA: 0x00986B55 File Offset: 0x00984D55
		public S_BakedBalloonSet(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06023993 RID: 145811 RVA: 0x00986B5F File Offset: 0x00984D5F
		public S_BakedBalloonSet(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06023994 RID: 145812 RVA: 0x00986B6A File Offset: 0x00984D6A
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new S_BakedBalloonSet(Pointer, false, true);
		}

		// Token: 0x06023995 RID: 145813 RVA: 0x00986B74 File Offset: 0x00984D74
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new S_BakedBalloonSet(Pointer, MemoryOwner);
		}

		// Token: 0x0401221A RID: 74266
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/AClusterBalloons/S_BakedBalloonSet.S_BakedBalloonSet";

		// Token: 0x0401221B RID: 74267
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401221C RID: 74268
		internal static int __PropertyOffset_0;

		// Token: 0x0401221D RID: 74269
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMesh> _SMarr;

		// Token: 0x0401221E RID: 74270
		internal static int __PropertyOffset_1;

		// Token: 0x0401221F RID: 74271
		internal static int __PropertyOffset_2;

		// Token: 0x04012220 RID: 74272
		internal static int __PropertyOffset_3;
	}
}
