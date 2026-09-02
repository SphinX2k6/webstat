using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction
{
	// Token: 0x02003AC7 RID: 15047
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionitemIndestructibleEffectsParameters.SSceneInteractionitemIndestructibleEffectsParameters")]
	[UnrealStructLayout(168, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 164)]
	public class SSceneInteractionitemIndestructibleEffectsParameters : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06020233 RID: 131635 RVA: 0x00923450 File Offset: 0x00921650
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSceneInteractionitemIndestructibleEffectsParameters._ScriptStructPtr != 0) ? SSceneInteractionitemIndestructibleEffectsParameters._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionitemIndestructibleEffectsParameters.SSceneInteractionitemIndestructibleEffectsParameters", ref SSceneInteractionitemIndestructibleEffectsParameters._ScriptStructPtr);
		}

		// Token: 0x1700341B RID: 13339
		// (get) Token: 0x06020234 RID: 131636 RVA: 0x00923474 File Offset: 0x00921674
		// (set) Token: 0x06020235 RID: 131637 RVA: 0x009234B7 File Offset: 0x009216B7
		public TMap<string, float> FloatParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, float> result;
				if ((result = this._FloatParameters) == null)
				{
					result = (this._FloatParameters = new TMap<string, float>(base.NativePtr + (IntPtr)SSceneInteractionitemIndestructibleEffectsParameters.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.FloatParameters.CopyAssign(value);
			}
		}

		// Token: 0x1700341C RID: 13340
		// (get) Token: 0x06020236 RID: 131638 RVA: 0x009234C8 File Offset: 0x009216C8
		// (set) Token: 0x06020237 RID: 131639 RVA: 0x0092350B File Offset: 0x0092170B
		public TMap<string, FLinearColor> ColorParameters
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, FLinearColor> result;
				if ((result = this._ColorParameters) == null)
				{
					result = (this._ColorParameters = new TMap<string, FLinearColor>(base.NativePtr + (IntPtr)SSceneInteractionitemIndestructibleEffectsParameters.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ColorParameters.CopyAssign(value);
			}
		}

		// Token: 0x1700341D RID: 13341
		// (get) Token: 0x06020238 RID: 131640 RVA: 0x00923519 File Offset: 0x00921719
		// (set) Token: 0x06020239 RID: 131641 RVA: 0x00923529 File Offset: 0x00921729
		public unsafe int IndestructibleEffectIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSceneInteractionitemIndestructibleEffectsParameters.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSceneInteractionitemIndestructibleEffectsParameters.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602023A RID: 131642 RVA: 0x0092353A File Offset: 0x0092173A
		public SSceneInteractionitemIndestructibleEffectsParameters()
		{
		}

		// Token: 0x0602023B RID: 131643 RVA: 0x00923542 File Offset: 0x00921742
		public SSceneInteractionitemIndestructibleEffectsParameters(TMap<string, float> FloatParameters, TMap<string, FLinearColor> ColorParameters, int IndestructibleEffectIndex)
		{
			this.FloatParameters = FloatParameters;
			this.ColorParameters = ColorParameters;
			this.IndestructibleEffectIndex = IndestructibleEffectIndex;
		}

		// Token: 0x0602023C RID: 131644 RVA: 0x0092355F File Offset: 0x0092175F
		protected override IntPtr GetUStructPtr()
		{
			return SSceneInteractionitemIndestructibleEffectsParameters.StaticStruct();
		}

		// Token: 0x0602023D RID: 131645 RVA: 0x0092356B File Offset: 0x0092176B
		[NullableContext(2)]
		public SSceneInteractionitemIndestructibleEffectsParameters(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602023E RID: 131646 RVA: 0x00923575 File Offset: 0x00921775
		public SSceneInteractionitemIndestructibleEffectsParameters(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602023F RID: 131647 RVA: 0x00923580 File Offset: 0x00921780
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSceneInteractionitemIndestructibleEffectsParameters(Pointer, false, true);
		}

		// Token: 0x06020240 RID: 131648 RVA: 0x0092358A File Offset: 0x0092178A
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSceneInteractionitemIndestructibleEffectsParameters(Pointer, MemoryOwner);
		}

		// Token: 0x04010049 RID: 65609
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionitemIndestructibleEffectsParameters.SSceneInteractionitemIndestructibleEffectsParameters";

		// Token: 0x0401004A RID: 65610
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401004B RID: 65611
		internal static int __PropertyOffset_0;

		// Token: 0x0401004C RID: 65612
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, float> _FloatParameters;

		// Token: 0x0401004D RID: 65613
		internal static int __PropertyOffset_1;

		// Token: 0x0401004E RID: 65614
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, FLinearColor> _ColorParameters;

		// Token: 0x0401004F RID: 65615
		internal static int __PropertyOffset_2;
	}
}
