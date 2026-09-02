using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.ABP_Gameplay
{
	// Token: 0x02004070 RID: 16496
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_SlopeSlide.ABP_BaseRole_Gameplay_SlopeSlide_C")]
	[UnrealStructLayout(8736, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 8729)]
	public class ABP_BaseRole_Gameplay_SlopeSlide_C : UKuroAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AD0B RID: 175371 RVA: 0x00A65A9F File Offset: 0x00A63C9F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_BaseRole_Gameplay_SlopeSlide_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_SlopeSlide.ABP_BaseRole_Gameplay_SlopeSlide_C");
			}
			return ABP_BaseRole_Gameplay_SlopeSlide_C._ClassPtr;
		}

		// Token: 0x0602AD0C RID: 175372 RVA: 0x00A65AC4 File Offset: 0x00A63CC4
		public ABP_BaseRole_Gameplay_SlopeSlide_C() : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRole_Gameplay_SlopeSlide_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AD0D RID: 175373 RVA: 0x00A65AEC File Offset: 0x00A63CEC
		public ABP_BaseRole_Gameplay_SlopeSlide_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRole_Gameplay_SlopeSlide_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006FB3 RID: 28595
		// (get) Token: 0x0602AD0E RID: 175374 RVA: 0x00A65B20 File Offset: 0x00A63D20
		// (set) Token: 0x0602AD0F RID: 175375 RVA: 0x00A65B59 File Offset: 0x00A63D59
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FB4 RID: 28596
		// (get) Token: 0x0602AD10 RID: 175376 RVA: 0x00A65B7C File Offset: 0x00A63D7C
		// (set) Token: 0x0602AD11 RID: 175377 RVA: 0x00A65BB5 File Offset: 0x00A63DB5
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FB5 RID: 28597
		// (get) Token: 0x0602AD12 RID: 175378 RVA: 0x00A65BD8 File Offset: 0x00A63DD8
		// (set) Token: 0x0602AD13 RID: 175379 RVA: 0x00A65C11 File Offset: 0x00A63E11
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_16) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_16 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FB6 RID: 28598
		// (get) Token: 0x0602AD14 RID: 175380 RVA: 0x00A65C34 File Offset: 0x00A63E34
		// (set) Token: 0x0602AD15 RID: 175381 RVA: 0x00A65C6D File Offset: 0x00A63E6D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_15) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_15 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FB7 RID: 28599
		// (get) Token: 0x0602AD16 RID: 175382 RVA: 0x00A65C90 File Offset: 0x00A63E90
		// (set) Token: 0x0602AD17 RID: 175383 RVA: 0x00A65CC9 File Offset: 0x00A63EC9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_14) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_14 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FB8 RID: 28600
		// (get) Token: 0x0602AD18 RID: 175384 RVA: 0x00A65CEC File Offset: 0x00A63EEC
		// (set) Token: 0x0602AD19 RID: 175385 RVA: 0x00A65D25 File Offset: 0x00A63F25
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_13) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_13 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FB9 RID: 28601
		// (get) Token: 0x0602AD1A RID: 175386 RVA: 0x00A65D48 File Offset: 0x00A63F48
		// (set) Token: 0x0602AD1B RID: 175387 RVA: 0x00A65D81 File Offset: 0x00A63F81
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_12) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_12 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FBA RID: 28602
		// (get) Token: 0x0602AD1C RID: 175388 RVA: 0x00A65DA4 File Offset: 0x00A63FA4
		// (set) Token: 0x0602AD1D RID: 175389 RVA: 0x00A65DDD File Offset: 0x00A63FDD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_11) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_11 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FBB RID: 28603
		// (get) Token: 0x0602AD1E RID: 175390 RVA: 0x00A65E00 File Offset: 0x00A64000
		// (set) Token: 0x0602AD1F RID: 175391 RVA: 0x00A65E39 File Offset: 0x00A64039
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_10) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_10 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FBC RID: 28604
		// (get) Token: 0x0602AD20 RID: 175392 RVA: 0x00A65E5C File Offset: 0x00A6405C
		// (set) Token: 0x0602AD21 RID: 175393 RVA: 0x00A65E95 File Offset: 0x00A64095
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_9) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_9 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FBD RID: 28605
		// (get) Token: 0x0602AD22 RID: 175394 RVA: 0x00A65EB8 File Offset: 0x00A640B8
		// (set) Token: 0x0602AD23 RID: 175395 RVA: 0x00A65EF1 File Offset: 0x00A640F1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_8) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_8 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FBE RID: 28606
		// (get) Token: 0x0602AD24 RID: 175396 RVA: 0x00A65F14 File Offset: 0x00A64114
		// (set) Token: 0x0602AD25 RID: 175397 RVA: 0x00A65F4D File Offset: 0x00A6414D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_7) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_7 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FBF RID: 28607
		// (get) Token: 0x0602AD26 RID: 175398 RVA: 0x00A65F70 File Offset: 0x00A64170
		// (set) Token: 0x0602AD27 RID: 175399 RVA: 0x00A65FA9 File Offset: 0x00A641A9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_6) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_6 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FC0 RID: 28608
		// (get) Token: 0x0602AD28 RID: 175400 RVA: 0x00A65FCC File Offset: 0x00A641CC
		// (set) Token: 0x0602AD29 RID: 175401 RVA: 0x00A66005 File Offset: 0x00A64205
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_9) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_9 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FC1 RID: 28609
		// (get) Token: 0x0602AD2A RID: 175402 RVA: 0x00A66028 File Offset: 0x00A64228
		// (set) Token: 0x0602AD2B RID: 175403 RVA: 0x00A66061 File Offset: 0x00A64261
		public FAnimNode_StateResult AnimGraphNode_StateResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_16) == null)
				{
					result = (this._AnimGraphNode_StateResult_16 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FC2 RID: 28610
		// (get) Token: 0x0602AD2C RID: 175404 RVA: 0x00A66084 File Offset: 0x00A64284
		// (set) Token: 0x0602AD2D RID: 175405 RVA: 0x00A660BD File Offset: 0x00A642BD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_8) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_8 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FC3 RID: 28611
		// (get) Token: 0x0602AD2E RID: 175406 RVA: 0x00A660E0 File Offset: 0x00A642E0
		// (set) Token: 0x0602AD2F RID: 175407 RVA: 0x00A66119 File Offset: 0x00A64319
		public FAnimNode_StateResult AnimGraphNode_StateResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_15) == null)
				{
					result = (this._AnimGraphNode_StateResult_15 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FC4 RID: 28612
		// (get) Token: 0x0602AD30 RID: 175408 RVA: 0x00A6613C File Offset: 0x00A6433C
		// (set) Token: 0x0602AD31 RID: 175409 RVA: 0x00A66175 File Offset: 0x00A64375
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_7) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_7 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FC5 RID: 28613
		// (get) Token: 0x0602AD32 RID: 175410 RVA: 0x00A66198 File Offset: 0x00A64398
		// (set) Token: 0x0602AD33 RID: 175411 RVA: 0x00A661D1 File Offset: 0x00A643D1
		public FAnimNode_StateResult AnimGraphNode_StateResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_14) == null)
				{
					result = (this._AnimGraphNode_StateResult_14 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FC6 RID: 28614
		// (get) Token: 0x0602AD34 RID: 175412 RVA: 0x00A661F4 File Offset: 0x00A643F4
		// (set) Token: 0x0602AD35 RID: 175413 RVA: 0x00A6622D File Offset: 0x00A6442D
		public FAnimNode_StateResult AnimGraphNode_StateResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_13) == null)
				{
					result = (this._AnimGraphNode_StateResult_13 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FC7 RID: 28615
		// (get) Token: 0x0602AD36 RID: 175414 RVA: 0x00A66250 File Offset: 0x00A64450
		// (set) Token: 0x0602AD37 RID: 175415 RVA: 0x00A66289 File Offset: 0x00A64489
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_3) == null)
				{
					result = (this._AnimGraphNode_StateMachine_3 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FC8 RID: 28616
		// (get) Token: 0x0602AD38 RID: 175416 RVA: 0x00A662AC File Offset: 0x00A644AC
		// (set) Token: 0x0602AD39 RID: 175417 RVA: 0x00A662E5 File Offset: 0x00A644E5
		public FAnimNode_StateResult AnimGraphNode_StateResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_12) == null)
				{
					result = (this._AnimGraphNode_StateResult_12 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FC9 RID: 28617
		// (get) Token: 0x0602AD3A RID: 175418 RVA: 0x00A66308 File Offset: 0x00A64508
		// (set) Token: 0x0602AD3B RID: 175419 RVA: 0x00A66341 File Offset: 0x00A64541
		public FAnimNode_StateResult AnimGraphNode_StateResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_11) == null)
				{
					result = (this._AnimGraphNode_StateResult_11 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FCA RID: 28618
		// (get) Token: 0x0602AD3C RID: 175420 RVA: 0x00A66364 File Offset: 0x00A64564
		// (set) Token: 0x0602AD3D RID: 175421 RVA: 0x00A6639D File Offset: 0x00A6459D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_5) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_5 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FCB RID: 28619
		// (get) Token: 0x0602AD3E RID: 175422 RVA: 0x00A663C0 File Offset: 0x00A645C0
		// (set) Token: 0x0602AD3F RID: 175423 RVA: 0x00A663F9 File Offset: 0x00A645F9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_4) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_4 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_24, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FCC RID: 28620
		// (get) Token: 0x0602AD40 RID: 175424 RVA: 0x00A6641C File Offset: 0x00A6461C
		// (set) Token: 0x0602AD41 RID: 175425 RVA: 0x00A66455 File Offset: 0x00A64655
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_3 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FCD RID: 28621
		// (get) Token: 0x0602AD42 RID: 175426 RVA: 0x00A66478 File Offset: 0x00A64678
		// (set) Token: 0x0602AD43 RID: 175427 RVA: 0x00A664B1 File Offset: 0x00A646B1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_6) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_6 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_26, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FCE RID: 28622
		// (get) Token: 0x0602AD44 RID: 175428 RVA: 0x00A664D4 File Offset: 0x00A646D4
		// (set) Token: 0x0602AD45 RID: 175429 RVA: 0x00A6650D File Offset: 0x00A6470D
		public FAnimNode_StateResult AnimGraphNode_StateResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_10) == null)
				{
					result = (this._AnimGraphNode_StateResult_10 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_27, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FCF RID: 28623
		// (get) Token: 0x0602AD46 RID: 175430 RVA: 0x00A66530 File Offset: 0x00A64730
		// (set) Token: 0x0602AD47 RID: 175431 RVA: 0x00A66569 File Offset: 0x00A64769
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_5) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_5 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_28, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FD0 RID: 28624
		// (get) Token: 0x0602AD48 RID: 175432 RVA: 0x00A6658C File Offset: 0x00A6478C
		// (set) Token: 0x0602AD49 RID: 175433 RVA: 0x00A665C5 File Offset: 0x00A647C5
		public FAnimNode_StateResult AnimGraphNode_StateResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_9) == null)
				{
					result = (this._AnimGraphNode_StateResult_9 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_29, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FD1 RID: 28625
		// (get) Token: 0x0602AD4A RID: 175434 RVA: 0x00A665E8 File Offset: 0x00A647E8
		// (set) Token: 0x0602AD4B RID: 175435 RVA: 0x00A66621 File Offset: 0x00A64821
		public FAnimNode_StateResult AnimGraphNode_StateResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_8) == null)
				{
					result = (this._AnimGraphNode_StateResult_8 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_30, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FD2 RID: 28626
		// (get) Token: 0x0602AD4C RID: 175436 RVA: 0x00A66644 File Offset: 0x00A64844
		// (set) Token: 0x0602AD4D RID: 175437 RVA: 0x00A6667D File Offset: 0x00A6487D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_4) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_4 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_31, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FD3 RID: 28627
		// (get) Token: 0x0602AD4E RID: 175438 RVA: 0x00A666A0 File Offset: 0x00A648A0
		// (set) Token: 0x0602AD4F RID: 175439 RVA: 0x00A666D9 File Offset: 0x00A648D9
		public FAnimNode_StateResult AnimGraphNode_StateResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_7) == null)
				{
					result = (this._AnimGraphNode_StateResult_7 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_32, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FD4 RID: 28628
		// (get) Token: 0x0602AD50 RID: 175440 RVA: 0x00A666FC File Offset: 0x00A648FC
		// (set) Token: 0x0602AD51 RID: 175441 RVA: 0x00A66735 File Offset: 0x00A64935
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_2) == null)
				{
					result = (this._AnimGraphNode_StateMachine_2 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_33, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FD5 RID: 28629
		// (get) Token: 0x0602AD52 RID: 175442 RVA: 0x00A66758 File Offset: 0x00A64958
		// (set) Token: 0x0602AD53 RID: 175443 RVA: 0x00A66791 File Offset: 0x00A64991
		public FAnimNode_StateResult AnimGraphNode_StateResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_6) == null)
				{
					result = (this._AnimGraphNode_StateResult_6 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FD6 RID: 28630
		// (get) Token: 0x0602AD54 RID: 175444 RVA: 0x00A667B4 File Offset: 0x00A649B4
		// (set) Token: 0x0602AD55 RID: 175445 RVA: 0x00A667ED File Offset: 0x00A649ED
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_35, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FD7 RID: 28631
		// (get) Token: 0x0602AD56 RID: 175446 RVA: 0x00A66810 File Offset: 0x00A64A10
		// (set) Token: 0x0602AD57 RID: 175447 RVA: 0x00A66849 File Offset: 0x00A64A49
		public FAnimNode_ApplyAdditive AnimGraphNode_ApplyAdditive
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ApplyAdditive result;
				if ((result = this._AnimGraphNode_ApplyAdditive) == null)
				{
					result = (this._AnimGraphNode_ApplyAdditive = new FAnimNode_ApplyAdditive(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_36, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ApplyAdditive.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_36, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FD8 RID: 28632
		// (get) Token: 0x0602AD58 RID: 175448 RVA: 0x00A6686C File Offset: 0x00A64A6C
		// (set) Token: 0x0602AD59 RID: 175449 RVA: 0x00A668A5 File Offset: 0x00A64AA5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_3) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_3 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_37, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FD9 RID: 28633
		// (get) Token: 0x0602AD5A RID: 175450 RVA: 0x00A668C8 File Offset: 0x00A64AC8
		// (set) Token: 0x0602AD5B RID: 175451 RVA: 0x00A66901 File Offset: 0x00A64B01
		public FAnimNode_StateResult AnimGraphNode_StateResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_5) == null)
				{
					result = (this._AnimGraphNode_StateResult_5 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_38, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FDA RID: 28634
		// (get) Token: 0x0602AD5C RID: 175452 RVA: 0x00A66924 File Offset: 0x00A64B24
		// (set) Token: 0x0602AD5D RID: 175453 RVA: 0x00A6695D File Offset: 0x00A64B5D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_39, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_39, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FDB RID: 28635
		// (get) Token: 0x0602AD5E RID: 175454 RVA: 0x00A66980 File Offset: 0x00A64B80
		// (set) Token: 0x0602AD5F RID: 175455 RVA: 0x00A669B9 File Offset: 0x00A64BB9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_40, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_40, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FDC RID: 28636
		// (get) Token: 0x0602AD60 RID: 175456 RVA: 0x00A669DC File Offset: 0x00A64BDC
		// (set) Token: 0x0602AD61 RID: 175457 RVA: 0x00A66A15 File Offset: 0x00A64C15
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_41, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_41, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FDD RID: 28637
		// (get) Token: 0x0602AD62 RID: 175458 RVA: 0x00A66A38 File Offset: 0x00A64C38
		// (set) Token: 0x0602AD63 RID: 175459 RVA: 0x00A66A71 File Offset: 0x00A64C71
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_2) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_2 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_42, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_42, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FDE RID: 28638
		// (get) Token: 0x0602AD64 RID: 175460 RVA: 0x00A66A94 File Offset: 0x00A64C94
		// (set) Token: 0x0602AD65 RID: 175461 RVA: 0x00A66ACD File Offset: 0x00A64CCD
		public FAnimNode_StateResult AnimGraphNode_StateResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_4) == null)
				{
					result = (this._AnimGraphNode_StateResult_4 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_43, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_43, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FDF RID: 28639
		// (get) Token: 0x0602AD66 RID: 175462 RVA: 0x00A66AF0 File Offset: 0x00A64CF0
		// (set) Token: 0x0602AD67 RID: 175463 RVA: 0x00A66B29 File Offset: 0x00A64D29
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_1 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_44, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_44, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FE0 RID: 28640
		// (get) Token: 0x0602AD68 RID: 175464 RVA: 0x00A66B4C File Offset: 0x00A64D4C
		// (set) Token: 0x0602AD69 RID: 175465 RVA: 0x00A66B85 File Offset: 0x00A64D85
		public FAnimNode_StateResult AnimGraphNode_StateResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_3) == null)
				{
					result = (this._AnimGraphNode_StateResult_3 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_45, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_45, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FE1 RID: 28641
		// (get) Token: 0x0602AD6A RID: 175466 RVA: 0x00A66BA8 File Offset: 0x00A64DA8
		// (set) Token: 0x0602AD6B RID: 175467 RVA: 0x00A66BE1 File Offset: 0x00A64DE1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_46, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_46, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FE2 RID: 28642
		// (get) Token: 0x0602AD6C RID: 175468 RVA: 0x00A66C04 File Offset: 0x00A64E04
		// (set) Token: 0x0602AD6D RID: 175469 RVA: 0x00A66C3D File Offset: 0x00A64E3D
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_47, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_47, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FE3 RID: 28643
		// (get) Token: 0x0602AD6E RID: 175470 RVA: 0x00A66C60 File Offset: 0x00A64E60
		// (set) Token: 0x0602AD6F RID: 175471 RVA: 0x00A66C99 File Offset: 0x00A64E99
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_48, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_48, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FE4 RID: 28644
		// (get) Token: 0x0602AD70 RID: 175472 RVA: 0x00A66CBC File Offset: 0x00A64EBC
		// (set) Token: 0x0602AD71 RID: 175473 RVA: 0x00A66CF5 File Offset: 0x00A64EF5
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_1) == null)
				{
					result = (this._AnimGraphNode_StateMachine_1 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_49, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_49, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FE5 RID: 28645
		// (get) Token: 0x0602AD72 RID: 175474 RVA: 0x00A66D18 File Offset: 0x00A64F18
		// (set) Token: 0x0602AD73 RID: 175475 RVA: 0x00A66D51 File Offset: 0x00A64F51
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_50, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_50, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FE6 RID: 28646
		// (get) Token: 0x0602AD74 RID: 175476 RVA: 0x00A66D74 File Offset: 0x00A64F74
		// (set) Token: 0x0602AD75 RID: 175477 RVA: 0x00A66DAD File Offset: 0x00A64FAD
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_51, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_51, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FE7 RID: 28647
		// (get) Token: 0x0602AD76 RID: 175478 RVA: 0x00A66DCE File Offset: 0x00A64FCE
		// (set) Token: 0x0602AD77 RID: 175479 RVA: 0x00A66DE2 File Offset: 0x00A64FE2
		[Nullable(2)]
		public unsafe TsBaseCharacter 角色蓝图
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_52);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_52, value);
			}
		}

		// Token: 0x17006FE8 RID: 28648
		// (get) Token: 0x0602AD78 RID: 175480 RVA: 0x00A66DF7 File Offset: 0x00A64FF7
		// (set) Token: 0x0602AD79 RID: 175481 RVA: 0x00A66E0B File Offset: 0x00A6500B
		[Nullable(2)]
		public unsafe UKuroAnimInstanceRole Kuro_Anim_Instance_Role
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAnimInstanceRole>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_53);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_53, value);
			}
		}

		// Token: 0x17006FE9 RID: 28649
		// (get) Token: 0x0602AD7A RID: 175482 RVA: 0x00A66E20 File Offset: 0x00A65020
		// (set) Token: 0x0602AD7B RID: 175483 RVA: 0x00A66E30 File Offset: 0x00A65030
		public unsafe bool Start
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_54) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_SlopeSlide_C.__PropertyOffset_54) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602AD7C RID: 175484 RVA: 0x00A66E44 File Offset: 0x00A65044
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_BaseRole_Gameplay_SlopeSlide_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_SlopeSlide_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_SlopeSlide_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_SlopeSlide_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SlopeSlide_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602AD7D RID: 175485 RVA: 0x00A66ECB File Offset: 0x00A650CB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_B5CBAB3F41ED2B6BCB4F6BB243B27463()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SlopeSlide_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_B5CBAB3F41ED2B6BCB4F6BB243B27463_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD7E RID: 175486 RVA: 0x00A66EDF File Offset: 0x00A650DF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_48657E0742C983976324929C0CCF3846()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SlopeSlide_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_48657E0742C983976324929C0CCF3846_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD7F RID: 175487 RVA: 0x00A66EF3 File Offset: 0x00A650F3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_BlendSpacePlayer_2BB971E34E45D392D9A585AB63740A54()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SlopeSlide_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_BlendSpacePlayer_2BB971E34E45D392D9A585AB63740A54_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD80 RID: 175488 RVA: 0x00A66F07 File Offset: 0x00A65107
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_30F8EAB94322AE3B8358028171AE42BF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SlopeSlide_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_30F8EAB94322AE3B8358028171AE42BF_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD81 RID: 175489 RVA: 0x00A66F1B File Offset: 0x00A6511B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_43E3573543B26BF9D5D6548362EB9017()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SlopeSlide_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_43E3573543B26BF9D5D6548362EB9017_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD82 RID: 175490 RVA: 0x00A66F2F File Offset: 0x00A6512F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_0F79CA324B712AC43409FD9733E8525D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SlopeSlide_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_0F79CA324B712AC43409FD9733E8525D_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD83 RID: 175491 RVA: 0x00A66F43 File Offset: 0x00A65143
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_D59858444A545F6A1074038BE506BB46()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SlopeSlide_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_D59858444A545F6A1074038BE506BB46_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD84 RID: 175492 RVA: 0x00A66F57 File Offset: 0x00A65157
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_8BA412954EEF65D95658388339F9A18A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SlopeSlide_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_8BA412954EEF65D95658388339F9A18A_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD85 RID: 175493 RVA: 0x00A66F6B File Offset: 0x00A6516B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_313048444F419BE4DB02DDAA1499ACEA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SlopeSlide_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_313048444F419BE4DB02DDAA1499ACEA_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD86 RID: 175494 RVA: 0x00A66F7F File Offset: 0x00A6517F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_4B9536024FFE39D92C30F4879130C5CF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SlopeSlide_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_4B9536024FFE39D92C30F4879130C5CF_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD87 RID: 175495 RVA: 0x00A66F93 File Offset: 0x00A65193
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_EFCB696347F7C0A54F1324AE80270382()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SlopeSlide_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_EFCB696347F7C0A54F1324AE80270382_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD88 RID: 175496 RVA: 0x00A66FA7 File Offset: 0x00A651A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_15FFAB6B40D8B805F19CD7B76167BF00()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SlopeSlide_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_15FFAB6B40D8B805F19CD7B76167BF00_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD89 RID: 175497 RVA: 0x00A66FBB File Offset: 0x00A651BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_2B3E91454CFDB7DF95BB3C9DDD5B8D7C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SlopeSlide_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_2B3E91454CFDB7DF95BB3C9DDD5B8D7C_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD8A RID: 175498 RVA: 0x00A66FCF File Offset: 0x00A651CF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_4425D99945127B24510AEE9F851E0921()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SlopeSlide_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_4425D99945127B24510AEE9F851E0921_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD8B RID: 175499 RVA: 0x00A66FE3 File Offset: 0x00A651E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_0C5B9B084A09757D7A2970B9B66D9A11()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SlopeSlide_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_0C5B9B084A09757D7A2970B9B66D9A11_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD8C RID: 175500 RVA: 0x00A66FF7 File Offset: 0x00A651F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SlopeSlide_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD8D RID: 175501 RVA: 0x00A6700B File Offset: 0x00A6520B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SlopeSlide_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AD8E RID: 175502 RVA: 0x00A67020 File Offset: 0x00A65220
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide(int EntryPoint)
		{
			ABP_BaseRole_Gameplay_SlopeSlide_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_SlopeSlide_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_FunctionParams[(UIntPtr)111] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_SlopeSlide_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_SlopeSlide_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRole_Gameplay_SlopeSlide_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AD8F RID: 175503 RVA: 0x00A67067 File Offset: 0x00A65267
		protected ABP_BaseRole_Gameplay_SlopeSlide_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040175C2 RID: 95682
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_SlopeSlide.ABP_BaseRole_Gameplay_SlopeSlide_C";

		// Token: 0x040175C3 RID: 95683
		private static IntPtr _ClassPtr;

		// Token: 0x040175C4 RID: 95684
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040175C5 RID: 95685
		internal static int __PropertyOffset_0;

		// Token: 0x040175C6 RID: 95686
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040175C7 RID: 95687
		internal static int __PropertyOffset_1;

		// Token: 0x040175C8 RID: 95688
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x040175C9 RID: 95689
		internal static int __PropertyOffset_2;

		// Token: 0x040175CA RID: 95690
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_16;

		// Token: 0x040175CB RID: 95691
		internal static int __PropertyOffset_3;

		// Token: 0x040175CC RID: 95692
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_15;

		// Token: 0x040175CD RID: 95693
		internal static int __PropertyOffset_4;

		// Token: 0x040175CE RID: 95694
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_14;

		// Token: 0x040175CF RID: 95695
		internal static int __PropertyOffset_5;

		// Token: 0x040175D0 RID: 95696
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_13;

		// Token: 0x040175D1 RID: 95697
		internal static int __PropertyOffset_6;

		// Token: 0x040175D2 RID: 95698
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_12;

		// Token: 0x040175D3 RID: 95699
		internal static int __PropertyOffset_7;

		// Token: 0x040175D4 RID: 95700
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_11;

		// Token: 0x040175D5 RID: 95701
		internal static int __PropertyOffset_8;

		// Token: 0x040175D6 RID: 95702
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_10;

		// Token: 0x040175D7 RID: 95703
		internal static int __PropertyOffset_9;

		// Token: 0x040175D8 RID: 95704
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_9;

		// Token: 0x040175D9 RID: 95705
		internal static int __PropertyOffset_10;

		// Token: 0x040175DA RID: 95706
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_8;

		// Token: 0x040175DB RID: 95707
		internal static int __PropertyOffset_11;

		// Token: 0x040175DC RID: 95708
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_7;

		// Token: 0x040175DD RID: 95709
		internal static int __PropertyOffset_12;

		// Token: 0x040175DE RID: 95710
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_6;

		// Token: 0x040175DF RID: 95711
		internal static int __PropertyOffset_13;

		// Token: 0x040175E0 RID: 95712
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_9;

		// Token: 0x040175E1 RID: 95713
		internal static int __PropertyOffset_14;

		// Token: 0x040175E2 RID: 95714
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_16;

		// Token: 0x040175E3 RID: 95715
		internal static int __PropertyOffset_15;

		// Token: 0x040175E4 RID: 95716
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_8;

		// Token: 0x040175E5 RID: 95717
		internal static int __PropertyOffset_16;

		// Token: 0x040175E6 RID: 95718
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_15;

		// Token: 0x040175E7 RID: 95719
		internal static int __PropertyOffset_17;

		// Token: 0x040175E8 RID: 95720
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_7;

		// Token: 0x040175E9 RID: 95721
		internal static int __PropertyOffset_18;

		// Token: 0x040175EA RID: 95722
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_14;

		// Token: 0x040175EB RID: 95723
		internal static int __PropertyOffset_19;

		// Token: 0x040175EC RID: 95724
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_13;

		// Token: 0x040175ED RID: 95725
		internal static int __PropertyOffset_20;

		// Token: 0x040175EE RID: 95726
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_3;

		// Token: 0x040175EF RID: 95727
		internal static int __PropertyOffset_21;

		// Token: 0x040175F0 RID: 95728
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_12;

		// Token: 0x040175F1 RID: 95729
		internal static int __PropertyOffset_22;

		// Token: 0x040175F2 RID: 95730
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_11;

		// Token: 0x040175F3 RID: 95731
		internal static int __PropertyOffset_23;

		// Token: 0x040175F4 RID: 95732
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_5;

		// Token: 0x040175F5 RID: 95733
		internal static int __PropertyOffset_24;

		// Token: 0x040175F6 RID: 95734
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_4;

		// Token: 0x040175F7 RID: 95735
		internal static int __PropertyOffset_25;

		// Token: 0x040175F8 RID: 95736
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_3;

		// Token: 0x040175F9 RID: 95737
		internal static int __PropertyOffset_26;

		// Token: 0x040175FA RID: 95738
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_6;

		// Token: 0x040175FB RID: 95739
		internal static int __PropertyOffset_27;

		// Token: 0x040175FC RID: 95740
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_10;

		// Token: 0x040175FD RID: 95741
		internal static int __PropertyOffset_28;

		// Token: 0x040175FE RID: 95742
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_5;

		// Token: 0x040175FF RID: 95743
		internal static int __PropertyOffset_29;

		// Token: 0x04017600 RID: 95744
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_9;

		// Token: 0x04017601 RID: 95745
		internal static int __PropertyOffset_30;

		// Token: 0x04017602 RID: 95746
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_8;

		// Token: 0x04017603 RID: 95747
		internal static int __PropertyOffset_31;

		// Token: 0x04017604 RID: 95748
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_4;

		// Token: 0x04017605 RID: 95749
		internal static int __PropertyOffset_32;

		// Token: 0x04017606 RID: 95750
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_7;

		// Token: 0x04017607 RID: 95751
		internal static int __PropertyOffset_33;

		// Token: 0x04017608 RID: 95752
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_2;

		// Token: 0x04017609 RID: 95753
		internal static int __PropertyOffset_34;

		// Token: 0x0401760A RID: 95754
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_6;

		// Token: 0x0401760B RID: 95755
		internal static int __PropertyOffset_35;

		// Token: 0x0401760C RID: 95756
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer;

		// Token: 0x0401760D RID: 95757
		internal static int __PropertyOffset_36;

		// Token: 0x0401760E RID: 95758
		[Nullable(2)]
		private FAnimNode_ApplyAdditive _AnimGraphNode_ApplyAdditive;

		// Token: 0x0401760F RID: 95759
		internal static int __PropertyOffset_37;

		// Token: 0x04017610 RID: 95760
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_3;

		// Token: 0x04017611 RID: 95761
		internal static int __PropertyOffset_38;

		// Token: 0x04017612 RID: 95762
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_5;

		// Token: 0x04017613 RID: 95763
		internal static int __PropertyOffset_39;

		// Token: 0x04017614 RID: 95764
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x04017615 RID: 95765
		internal static int __PropertyOffset_40;

		// Token: 0x04017616 RID: 95766
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x04017617 RID: 95767
		internal static int __PropertyOffset_41;

		// Token: 0x04017618 RID: 95768
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x04017619 RID: 95769
		internal static int __PropertyOffset_42;

		// Token: 0x0401761A RID: 95770
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_2;

		// Token: 0x0401761B RID: 95771
		internal static int __PropertyOffset_43;

		// Token: 0x0401761C RID: 95772
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_4;

		// Token: 0x0401761D RID: 95773
		internal static int __PropertyOffset_44;

		// Token: 0x0401761E RID: 95774
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_1;

		// Token: 0x0401761F RID: 95775
		internal static int __PropertyOffset_45;

		// Token: 0x04017620 RID: 95776
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_3;

		// Token: 0x04017621 RID: 95777
		internal static int __PropertyOffset_46;

		// Token: 0x04017622 RID: 95778
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04017623 RID: 95779
		internal static int __PropertyOffset_47;

		// Token: 0x04017624 RID: 95780
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x04017625 RID: 95781
		internal static int __PropertyOffset_48;

		// Token: 0x04017626 RID: 95782
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x04017627 RID: 95783
		internal static int __PropertyOffset_49;

		// Token: 0x04017628 RID: 95784
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_1;

		// Token: 0x04017629 RID: 95785
		internal static int __PropertyOffset_50;

		// Token: 0x0401762A RID: 95786
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x0401762B RID: 95787
		internal static int __PropertyOffset_51;

		// Token: 0x0401762C RID: 95788
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x0401762D RID: 95789
		internal static int __PropertyOffset_52;

		// Token: 0x0401762E RID: 95790
		internal static int __PropertyOffset_53;

		// Token: 0x0401762F RID: 95791
		internal static int __PropertyOffset_54;

		// Token: 0x04017630 RID: 95792
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04017631 RID: 95793
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_B5CBAB3F41ED2B6BCB4F6BB243B27463_NativeFunctionPtr;

		// Token: 0x04017632 RID: 95794
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_48657E0742C983976324929C0CCF3846_NativeFunctionPtr;

		// Token: 0x04017633 RID: 95795
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_BlendSpacePlayer_2BB971E34E45D392D9A585AB63740A54_NativeFunctionPtr;

		// Token: 0x04017634 RID: 95796
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_30F8EAB94322AE3B8358028171AE42BF_NativeFunctionPtr;

		// Token: 0x04017635 RID: 95797
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_43E3573543B26BF9D5D6548362EB9017_NativeFunctionPtr;

		// Token: 0x04017636 RID: 95798
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_0F79CA324B712AC43409FD9733E8525D_NativeFunctionPtr;

		// Token: 0x04017637 RID: 95799
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_D59858444A545F6A1074038BE506BB46_NativeFunctionPtr;

		// Token: 0x04017638 RID: 95800
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_8BA412954EEF65D95658388339F9A18A_NativeFunctionPtr;

		// Token: 0x04017639 RID: 95801
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_313048444F419BE4DB02DDAA1499ACEA_NativeFunctionPtr;

		// Token: 0x0401763A RID: 95802
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_4B9536024FFE39D92C30F4879130C5CF_NativeFunctionPtr;

		// Token: 0x0401763B RID: 95803
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_EFCB696347F7C0A54F1324AE80270382_NativeFunctionPtr;

		// Token: 0x0401763C RID: 95804
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_15FFAB6B40D8B805F19CD7B76167BF00_NativeFunctionPtr;

		// Token: 0x0401763D RID: 95805
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_2B3E91454CFDB7DF95BB3C9DDD5B8D7C_NativeFunctionPtr;

		// Token: 0x0401763E RID: 95806
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_4425D99945127B24510AEE9F851E0921_NativeFunctionPtr;

		// Token: 0x0401763F RID: 95807
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_AnimGraphNode_TransitionResult_0C5B9B084A09757D7A2970B9B66D9A11_NativeFunctionPtr;

		// Token: 0x04017640 RID: 95808
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x04017641 RID: 95809
		private static IntPtr __ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_NativeFunctionPtr;

		// Token: 0x0200A263 RID: 41571
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x0403300D RID: 208909
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A264 RID: 41572
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 96)]
		protected ref struct __ExecuteUbergraph_ABP_BaseRole_Gameplay_SlopeSlide_FunctionParams
		{
			// Token: 0x0403300E RID: 208910
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
