using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.LightPrefab.Struction
{
	// Token: 0x02003BDB RID: 15323
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Decal.PCG_LightPrefab_Decal")]
	[UnrealStructLayout(544, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 544)]
	public class PCG_LightPrefab_Decal : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602264B RID: 140875 RVA: 0x00964607 File Offset: 0x00962807
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (PCG_LightPrefab_Decal._ScriptStructPtr != 0) ? PCG_LightPrefab_Decal._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Decal.PCG_LightPrefab_Decal", ref PCG_LightPrefab_Decal._ScriptStructPtr);
		}

		// Token: 0x1700408A RID: 16522
		// (get) Token: 0x0602264C RID: 140876 RVA: 0x0096462C File Offset: 0x0096282C
		// (set) Token: 0x0602264D RID: 140877 RVA: 0x0096466F File Offset: 0x0096286F
		public FKuroCurveLinearColor 贴花颜色
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._贴花颜色) == null)
				{
					result = (this._贴花颜色 = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)PCG_LightPrefab_Decal.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)PCG_LightPrefab_Decal.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602264E RID: 140878 RVA: 0x00964690 File Offset: 0x00962890
		public PCG_LightPrefab_Decal()
		{
		}

		// Token: 0x0602264F RID: 140879 RVA: 0x00964698 File Offset: 0x00962898
		public PCG_LightPrefab_Decal(FKuroCurveLinearColor 贴花颜色)
		{
			this.贴花颜色 = 贴花颜色;
		}

		// Token: 0x06022650 RID: 140880 RVA: 0x009646A7 File Offset: 0x009628A7
		protected override IntPtr GetUStructPtr()
		{
			return PCG_LightPrefab_Decal.StaticStruct();
		}

		// Token: 0x06022651 RID: 140881 RVA: 0x009646B3 File Offset: 0x009628B3
		[NullableContext(2)]
		public PCG_LightPrefab_Decal(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06022652 RID: 140882 RVA: 0x009646BD File Offset: 0x009628BD
		public PCG_LightPrefab_Decal(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06022653 RID: 140883 RVA: 0x009646C8 File Offset: 0x009628C8
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new PCG_LightPrefab_Decal(Pointer, false, true);
		}

		// Token: 0x06022654 RID: 140884 RVA: 0x009646D2 File Offset: 0x009628D2
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new PCG_LightPrefab_Decal(Pointer, MemoryOwner);
		}

		// Token: 0x0401168E RID: 71310
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Decal.PCG_LightPrefab_Decal";

		// Token: 0x0401168F RID: 71311
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04011690 RID: 71312
		internal static int __PropertyOffset_0;

		// Token: 0x04011691 RID: 71313
		[Nullable(2)]
		private FKuroCurveLinearColor _贴花颜色;
	}
}
