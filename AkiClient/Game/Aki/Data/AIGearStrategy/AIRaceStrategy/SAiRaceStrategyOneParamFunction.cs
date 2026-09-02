using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.AIGearStrategy.AIRaceStrategy
{
	// Token: 0x02003F27 RID: 16167
	[UnrealObjectPath("/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/SAiRaceStrategyOneParamFunction.SAiRaceStrategyOneParamFunction")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 40)]
	public class SAiRaceStrategyOneParamFunction : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06028594 RID: 165268 RVA: 0x00A0842A File Offset: 0x00A0662A
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAiRaceStrategyOneParamFunction._ScriptStructPtr != 0) ? SAiRaceStrategyOneParamFunction._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/SAiRaceStrategyOneParamFunction.SAiRaceStrategyOneParamFunction", ref SAiRaceStrategyOneParamFunction._ScriptStructPtr);
		}

		// Token: 0x170061E9 RID: 25065
		// (get) Token: 0x06028595 RID: 165269 RVA: 0x00A0844E File Offset: 0x00A0664E
		// (set) Token: 0x06028596 RID: 165270 RVA: 0x00A08462 File Offset: 0x00A06662
		public unsafe FFloatRange ParamRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAiRaceStrategyOneParamFunction.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAiRaceStrategyOneParamFunction.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170061EA RID: 25066
		// (get) Token: 0x06028597 RID: 165271 RVA: 0x00A08477 File Offset: 0x00A06677
		// (set) Token: 0x06028598 RID: 165272 RVA: 0x00A0848B File Offset: 0x00A0668B
		public unsafe TEnumAsByte<EAiRaceStrategyOneParamFuncType> FunctionType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAiRaceStrategyOneParamFunction.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAiRaceStrategyOneParamFunction.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170061EB RID: 25067
		// (get) Token: 0x06028599 RID: 165273 RVA: 0x00A084A0 File Offset: 0x00A066A0
		// (set) Token: 0x0602859A RID: 165274 RVA: 0x00A084E3 File Offset: 0x00A066E3
		[Nullable(1)]
		public TArray<float> CoefficientList
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._CoefficientList) == null)
				{
					result = (this._CoefficientList = new TArray<float>(base.NativePtr + (IntPtr)SAiRaceStrategyOneParamFunction.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.CoefficientList.CopyAssign(value);
			}
		}

		// Token: 0x0602859B RID: 165275 RVA: 0x00A084F1 File Offset: 0x00A066F1
		public SAiRaceStrategyOneParamFunction()
		{
		}

		// Token: 0x0602859C RID: 165276 RVA: 0x00A084F9 File Offset: 0x00A066F9
		public SAiRaceStrategyOneParamFunction(FFloatRange ParamRange, TEnumAsByte<EAiRaceStrategyOneParamFuncType> FunctionType, [Nullable(1)] TArray<float> CoefficientList)
		{
			this.ParamRange = ParamRange;
			this.FunctionType = FunctionType;
			this.CoefficientList = CoefficientList;
		}

		// Token: 0x0602859D RID: 165277 RVA: 0x00A08516 File Offset: 0x00A06716
		protected override IntPtr GetUStructPtr()
		{
			return SAiRaceStrategyOneParamFunction.StaticStruct();
		}

		// Token: 0x0602859E RID: 165278 RVA: 0x00A08522 File Offset: 0x00A06722
		[NullableContext(2)]
		public SAiRaceStrategyOneParamFunction(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602859F RID: 165279 RVA: 0x00A0852C File Offset: 0x00A0672C
		public SAiRaceStrategyOneParamFunction(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060285A0 RID: 165280 RVA: 0x00A08537 File Offset: 0x00A06737
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAiRaceStrategyOneParamFunction(Pointer, false, true);
		}

		// Token: 0x060285A1 RID: 165281 RVA: 0x00A08541 File Offset: 0x00A06741
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAiRaceStrategyOneParamFunction(Pointer, MemoryOwner);
		}

		// Token: 0x04015390 RID: 86928
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/AIGearStrategy/AIRaceStrategy/SAiRaceStrategyOneParamFunction.SAiRaceStrategyOneParamFunction";

		// Token: 0x04015391 RID: 86929
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04015392 RID: 86930
		internal static int __PropertyOffset_0;

		// Token: 0x04015393 RID: 86931
		internal static int __PropertyOffset_1;

		// Token: 0x04015394 RID: 86932
		internal static int __PropertyOffset_2;

		// Token: 0x04015395 RID: 86933
		[Nullable(2)]
		private TArray<float> _CoefficientList;
	}
}
