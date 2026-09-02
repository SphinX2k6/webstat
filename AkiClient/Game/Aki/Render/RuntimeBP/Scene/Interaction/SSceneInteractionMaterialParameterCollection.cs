using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction
{
	// Token: 0x02003AC9 RID: 15049
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionMaterialParameterCollection.SSceneInteractionMaterialParameterCollection")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 160)]
	public class SSceneInteractionMaterialParameterCollection : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06020253 RID: 131667 RVA: 0x00923706 File Offset: 0x00921906
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSceneInteractionMaterialParameterCollection._ScriptStructPtr != 0) ? SSceneInteractionMaterialParameterCollection._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionMaterialParameterCollection.SSceneInteractionMaterialParameterCollection", ref SSceneInteractionMaterialParameterCollection._ScriptStructPtr);
		}

		// Token: 0x17003423 RID: 13347
		// (get) Token: 0x06020254 RID: 131668 RVA: 0x0092372C File Offset: 0x0092192C
		// (set) Token: 0x06020255 RID: 131669 RVA: 0x0092376F File Offset: 0x0092196F
		public TMap<string, FLinearColor> MPC_Vector
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, FLinearColor> result;
				if ((result = this._MPC_Vector) == null)
				{
					result = (this._MPC_Vector = new TMap<string, FLinearColor>(base.NativePtr + (IntPtr)SSceneInteractionMaterialParameterCollection.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.MPC_Vector.CopyAssign(value);
			}
		}

		// Token: 0x17003424 RID: 13348
		// (get) Token: 0x06020256 RID: 131670 RVA: 0x00923780 File Offset: 0x00921980
		// (set) Token: 0x06020257 RID: 131671 RVA: 0x009237C3 File Offset: 0x009219C3
		public TMap<string, float> MPC_Scalar
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, float> result;
				if ((result = this._MPC_Scalar) == null)
				{
					result = (this._MPC_Scalar = new TMap<string, float>(base.NativePtr + (IntPtr)SSceneInteractionMaterialParameterCollection.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.MPC_Scalar.CopyAssign(value);
			}
		}

		// Token: 0x06020258 RID: 131672 RVA: 0x009237D1 File Offset: 0x009219D1
		public SSceneInteractionMaterialParameterCollection()
		{
		}

		// Token: 0x06020259 RID: 131673 RVA: 0x009237D9 File Offset: 0x009219D9
		public SSceneInteractionMaterialParameterCollection(TMap<string, FLinearColor> MPC_Vector, TMap<string, float> MPC_Scalar)
		{
			this.MPC_Vector = MPC_Vector;
			this.MPC_Scalar = MPC_Scalar;
		}

		// Token: 0x0602025A RID: 131674 RVA: 0x009237EF File Offset: 0x009219EF
		protected override IntPtr GetUStructPtr()
		{
			return SSceneInteractionMaterialParameterCollection.StaticStruct();
		}

		// Token: 0x0602025B RID: 131675 RVA: 0x009237FB File Offset: 0x009219FB
		[NullableContext(2)]
		public SSceneInteractionMaterialParameterCollection(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602025C RID: 131676 RVA: 0x00923805 File Offset: 0x00921A05
		public SSceneInteractionMaterialParameterCollection(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602025D RID: 131677 RVA: 0x00923810 File Offset: 0x00921A10
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSceneInteractionMaterialParameterCollection(Pointer, false, true);
		}

		// Token: 0x0602025E RID: 131678 RVA: 0x0092381A File Offset: 0x00921A1A
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSceneInteractionMaterialParameterCollection(Pointer, MemoryOwner);
		}

		// Token: 0x04010058 RID: 65624
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionMaterialParameterCollection.SSceneInteractionMaterialParameterCollection";

		// Token: 0x04010059 RID: 65625
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401005A RID: 65626
		internal static int __PropertyOffset_0;

		// Token: 0x0401005B RID: 65627
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, FLinearColor> _MPC_Vector;

		// Token: 0x0401005C RID: 65628
		internal static int __PropertyOffset_1;

		// Token: 0x0401005D RID: 65629
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, float> _MPC_Scalar;
	}
}
