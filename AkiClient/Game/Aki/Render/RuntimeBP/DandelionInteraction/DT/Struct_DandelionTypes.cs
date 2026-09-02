using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.InteractFoliage.Blueprint.MeshActor;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.DandelionInteraction.DT
{
	// Token: 0x02003D53 RID: 15699
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/DandelionInteraction/DT/Struct_DandelionTypes.Struct_DandelionTypes")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 57)]
	public class Struct_DandelionTypes : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026208 RID: 156168 RVA: 0x009CEB33 File Offset: 0x009CCD33
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (Struct_DandelionTypes._ScriptStructPtr != 0) ? Struct_DandelionTypes._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/DandelionInteraction/DT/Struct_DandelionTypes.Struct_DandelionTypes", ref Struct_DandelionTypes._ScriptStructPtr);
		}

		// Token: 0x17005598 RID: 21912
		// (get) Token: 0x06026209 RID: 156169 RVA: 0x009CEB57 File Offset: 0x009CCD57
		// (set) Token: 0x0602620A RID: 156170 RVA: 0x009CEB6B File Offset: 0x009CCD6B
		public unsafe UStaticMesh StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + Struct_DandelionTypes.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Struct_DandelionTypes.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005599 RID: 21913
		// (get) Token: 0x0602620B RID: 156171 RVA: 0x009CEB80 File Offset: 0x009CCD80
		// (set) Token: 0x0602620C RID: 156172 RVA: 0x009CEB94 File Offset: 0x009CCD94
		public unsafe USkeletalMesh SkeletonMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + Struct_DandelionTypes.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Struct_DandelionTypes.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700559A RID: 21914
		// (get) Token: 0x0602620D RID: 156173 RVA: 0x009CEBA9 File Offset: 0x009CCDA9
		// (set) Token: 0x0602620E RID: 156174 RVA: 0x009CEBB9 File Offset: 0x009CCDB9
		public unsafe float TraceRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_DandelionTypes.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_DandelionTypes.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700559B RID: 21915
		// (get) Token: 0x0602620F RID: 156175 RVA: 0x009CEBCA File Offset: 0x009CCDCA
		// (set) Token: 0x06026210 RID: 156176 RVA: 0x009CEBDE File Offset: 0x009CCDDE
		public unsafe KUROInteractFoliage_C FoliageType
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<KUROInteractFoliage_C>(base.NativePtr / (IntPtr)sizeof(void*) + Struct_DandelionTypes.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Struct_DandelionTypes.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700559C RID: 21916
		// (get) Token: 0x06026211 RID: 156177 RVA: 0x009CEBF3 File Offset: 0x009CCDF3
		// (set) Token: 0x06026212 RID: 156178 RVA: 0x009CEC07 File Offset: 0x009CCE07
		public unsafe UNiagaraSystem NiagaraSystem
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraSystem>(base.NativePtr / (IntPtr)sizeof(void*) + Struct_DandelionTypes.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Struct_DandelionTypes.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700559D RID: 21917
		// (get) Token: 0x06026213 RID: 156179 RVA: 0x009CEC1C File Offset: 0x009CCE1C
		// (set) Token: 0x06026214 RID: 156180 RVA: 0x009CEC5F File Offset: 0x009CCE5F
		[Nullable(1)]
		public TArray<FName> ParentSocketNames
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._ParentSocketNames) == null)
				{
					result = (this._ParentSocketNames = new TArray<FName>(base.NativePtr + (IntPtr)Struct_DandelionTypes.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.ParentSocketNames.CopyAssign(value);
			}
		}

		// Token: 0x1700559E RID: 21918
		// (get) Token: 0x06026215 RID: 156181 RVA: 0x009CEC6D File Offset: 0x009CCE6D
		// (set) Token: 0x06026216 RID: 156182 RVA: 0x009CEC7D File Offset: 0x009CCE7D
		public unsafe bool OpenWeaponInteraction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_DandelionTypes.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_DandelionTypes.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x06026217 RID: 156183 RVA: 0x009CEC8E File Offset: 0x009CCE8E
		public Struct_DandelionTypes()
		{
		}

		// Token: 0x06026218 RID: 156184 RVA: 0x009CEC96 File Offset: 0x009CCE96
		[NullableContext(1)]
		public Struct_DandelionTypes(UStaticMesh StaticMesh, USkeletalMesh SkeletonMesh, float TraceRadius, KUROInteractFoliage_C FoliageType, UNiagaraSystem NiagaraSystem, TArray<FName> ParentSocketNames, bool OpenWeaponInteraction)
		{
			this.StaticMesh = StaticMesh;
			this.SkeletonMesh = SkeletonMesh;
			this.TraceRadius = TraceRadius;
			this.FoliageType = FoliageType;
			this.NiagaraSystem = NiagaraSystem;
			this.ParentSocketNames = ParentSocketNames;
			this.OpenWeaponInteraction = OpenWeaponInteraction;
		}

		// Token: 0x06026219 RID: 156185 RVA: 0x009CECD3 File Offset: 0x009CCED3
		protected override IntPtr GetUStructPtr()
		{
			return Struct_DandelionTypes.StaticStruct();
		}

		// Token: 0x0602621A RID: 156186 RVA: 0x009CECDF File Offset: 0x009CCEDF
		public Struct_DandelionTypes(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602621B RID: 156187 RVA: 0x009CECE9 File Offset: 0x009CCEE9
		public Struct_DandelionTypes(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602621C RID: 156188 RVA: 0x009CECF4 File Offset: 0x009CCEF4
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new Struct_DandelionTypes(Pointer, false, true);
		}

		// Token: 0x0602621D RID: 156189 RVA: 0x009CECFE File Offset: 0x009CCEFE
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new Struct_DandelionTypes(Pointer, MemoryOwner);
		}

		// Token: 0x04013BFB RID: 80891
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/DandelionInteraction/DT/Struct_DandelionTypes.Struct_DandelionTypes";

		// Token: 0x04013BFC RID: 80892
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013BFD RID: 80893
		internal static int __PropertyOffset_0;

		// Token: 0x04013BFE RID: 80894
		internal static int __PropertyOffset_1;

		// Token: 0x04013BFF RID: 80895
		internal static int __PropertyOffset_2;

		// Token: 0x04013C00 RID: 80896
		internal static int __PropertyOffset_3;

		// Token: 0x04013C01 RID: 80897
		internal static int __PropertyOffset_4;

		// Token: 0x04013C02 RID: 80898
		internal static int __PropertyOffset_5;

		// Token: 0x04013C03 RID: 80899
		private TArray<FName> _ParentSocketNames;

		// Token: 0x04013C04 RID: 80900
		internal static int __PropertyOffset_6;
	}
}
