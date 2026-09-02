using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.LightPrefab.Struction
{
	// Token: 0x02003BDF RID: 15327
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Mesh.PCG_LightPrefab_Mesh")]
	[UnrealStructLayout(1104, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 1098)]
	public class PCG_LightPrefab_Mesh : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06022675 RID: 140917 RVA: 0x009649C2 File Offset: 0x00962BC2
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (PCG_LightPrefab_Mesh._ScriptStructPtr != 0) ? PCG_LightPrefab_Mesh._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Mesh.PCG_LightPrefab_Mesh", ref PCG_LightPrefab_Mesh._ScriptStructPtr);
		}

		// Token: 0x1700408F RID: 16527
		// (get) Token: 0x06022676 RID: 140918 RVA: 0x009649E6 File Offset: 0x00962BE6
		// (set) Token: 0x06022677 RID: 140919 RVA: 0x009649FA File Offset: 0x00962BFA
		[Nullable(2)]
		public unsafe UStaticMesh 灯光模型
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PCG_LightPrefab_Mesh.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PCG_LightPrefab_Mesh.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17004090 RID: 16528
		// (get) Token: 0x06022678 RID: 140920 RVA: 0x00964A10 File Offset: 0x00962C10
		// (set) Token: 0x06022679 RID: 140921 RVA: 0x00964A53 File Offset: 0x00962C53
		public FKuroCurveLinearColor 自发光颜色Color
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._自发光颜色Color) == null)
				{
					result = (this._自发光颜色Color = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)PCG_LightPrefab_Mesh.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)PCG_LightPrefab_Mesh.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004091 RID: 16529
		// (get) Token: 0x0602267A RID: 140922 RVA: 0x00964A74 File Offset: 0x00962C74
		// (set) Token: 0x0602267B RID: 140923 RVA: 0x00964AB7 File Offset: 0x00962CB7
		public FKuroCurveLinearColor 自发光颜色DayColor
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._自发光颜色DayColor) == null)
				{
					result = (this._自发光颜色DayColor = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)PCG_LightPrefab_Mesh.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)PCG_LightPrefab_Mesh.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004092 RID: 16530
		// (get) Token: 0x0602267C RID: 140924 RVA: 0x00964AD8 File Offset: 0x00962CD8
		// (set) Token: 0x0602267D RID: 140925 RVA: 0x00964AE8 File Offset: 0x00962CE8
		public unsafe bool UseWholeDayEmission
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_LightPrefab_Mesh.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_LightPrefab_Mesh.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17004093 RID: 16531
		// (get) Token: 0x0602267E RID: 140926 RVA: 0x00964AF9 File Offset: 0x00962CF9
		// (set) Token: 0x0602267F RID: 140927 RVA: 0x00964B09 File Offset: 0x00962D09
		public unsafe bool UseMaterialLOD
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PCG_LightPrefab_Mesh.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)PCG_LightPrefab_Mesh.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x06022680 RID: 140928 RVA: 0x00964B1A File Offset: 0x00962D1A
		public PCG_LightPrefab_Mesh()
		{
		}

		// Token: 0x06022681 RID: 140929 RVA: 0x00964B22 File Offset: 0x00962D22
		public PCG_LightPrefab_Mesh(UStaticMesh 灯光模型, FKuroCurveLinearColor 自发光颜色Color, FKuroCurveLinearColor 自发光颜色DayColor, bool UseWholeDayEmission, bool UseMaterialLOD)
		{
			this.灯光模型 = 灯光模型;
			this.自发光颜色Color = 自发光颜色Color;
			this.自发光颜色DayColor = 自发光颜色DayColor;
			this.UseWholeDayEmission = UseWholeDayEmission;
			this.UseMaterialLOD = UseMaterialLOD;
		}

		// Token: 0x06022682 RID: 140930 RVA: 0x00964B4F File Offset: 0x00962D4F
		protected override IntPtr GetUStructPtr()
		{
			return PCG_LightPrefab_Mesh.StaticStruct();
		}

		// Token: 0x06022683 RID: 140931 RVA: 0x00964B5B File Offset: 0x00962D5B
		[NullableContext(2)]
		public PCG_LightPrefab_Mesh(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06022684 RID: 140932 RVA: 0x00964B65 File Offset: 0x00962D65
		public PCG_LightPrefab_Mesh(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06022685 RID: 140933 RVA: 0x00964B70 File Offset: 0x00962D70
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new PCG_LightPrefab_Mesh(Pointer, false, true);
		}

		// Token: 0x06022686 RID: 140934 RVA: 0x00964B7A File Offset: 0x00962D7A
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new PCG_LightPrefab_Mesh(Pointer, MemoryOwner);
		}

		// Token: 0x040116A0 RID: 71328
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/LightPrefab/Struction/PCG_LightPrefab_Mesh.PCG_LightPrefab_Mesh";

		// Token: 0x040116A1 RID: 71329
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040116A2 RID: 71330
		internal static int __PropertyOffset_0;

		// Token: 0x040116A3 RID: 71331
		internal static int __PropertyOffset_1;

		// Token: 0x040116A4 RID: 71332
		[Nullable(2)]
		private FKuroCurveLinearColor _自发光颜色Color;

		// Token: 0x040116A5 RID: 71333
		internal static int __PropertyOffset_2;

		// Token: 0x040116A6 RID: 71334
		[Nullable(2)]
		private FKuroCurveLinearColor _自发光颜色DayColor;

		// Token: 0x040116A7 RID: 71335
		internal static int __PropertyOffset_3;

		// Token: 0x040116A8 RID: 71336
		internal static int __PropertyOffset_4;
	}
}
