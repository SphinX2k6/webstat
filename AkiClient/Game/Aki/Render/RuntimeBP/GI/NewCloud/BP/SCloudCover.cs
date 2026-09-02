using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.NewCloud.BP
{
	// Token: 0x02003CCD RID: 15565
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/SCloudCover.SCloudCover")]
	[UnrealStructLayout(8, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 8)]
	public class SCloudCover : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060251A3 RID: 151971 RVA: 0x009B1020 File Offset: 0x009AF220
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCloudCover._ScriptStructPtr != 0) ? SCloudCover._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/SCloudCover.SCloudCover", ref SCloudCover._ScriptStructPtr);
		}

		// Token: 0x17004FB0 RID: 20400
		// (get) Token: 0x060251A4 RID: 151972 RVA: 0x009B1044 File Offset: 0x009AF244
		// (set) Token: 0x060251A5 RID: 151973 RVA: 0x009B1058 File Offset: 0x009AF258
		[Nullable(2)]
		public unsafe UMaterialInterface CoverMaterial
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + SCloudCover.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SCloudCover.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060251A6 RID: 151974 RVA: 0x009B106D File Offset: 0x009AF26D
		public SCloudCover()
		{
		}

		// Token: 0x060251A7 RID: 151975 RVA: 0x009B1075 File Offset: 0x009AF275
		[NullableContext(1)]
		public SCloudCover(UMaterialInterface CoverMaterial)
		{
			this.CoverMaterial = CoverMaterial;
		}

		// Token: 0x060251A8 RID: 151976 RVA: 0x009B1084 File Offset: 0x009AF284
		protected override IntPtr GetUStructPtr()
		{
			return SCloudCover.StaticStruct();
		}

		// Token: 0x060251A9 RID: 151977 RVA: 0x009B1090 File Offset: 0x009AF290
		[NullableContext(2)]
		public SCloudCover(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060251AA RID: 151978 RVA: 0x009B109A File Offset: 0x009AF29A
		public SCloudCover(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060251AB RID: 151979 RVA: 0x009B10A5 File Offset: 0x009AF2A5
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCloudCover(Pointer, false, true);
		}

		// Token: 0x060251AC RID: 151980 RVA: 0x009B10AF File Offset: 0x009AF2AF
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCloudCover(Pointer, MemoryOwner);
		}

		// Token: 0x0401319C RID: 78236
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/NewCloud/BP/SCloudCover.SCloudCover";

		// Token: 0x0401319D RID: 78237
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401319E RID: 78238
		internal static int __PropertyOffset_0;
	}
}
