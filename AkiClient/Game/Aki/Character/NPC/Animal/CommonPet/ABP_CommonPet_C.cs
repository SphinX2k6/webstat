using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.CommonPet
{
	// Token: 0x02004192 RID: 16786
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/CommonPet/ABP_CommonPet.ABP_CommonPet_C")]
	[UnrealStructLayout(4976, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 4968)]
	public class ABP_CommonPet_C : UKuroAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C7BD RID: 182205 RVA: 0x00AA3138 File Offset: 0x00AA1338
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_CommonPet_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/CommonPet/ABP_CommonPet.ABP_CommonPet_C");
			}
			return ABP_CommonPet_C._ClassPtr;
		}

		// Token: 0x0602C7BE RID: 182206 RVA: 0x00AA315C File Offset: 0x00AA135C
		public ABP_CommonPet_C() : this(BuiltinUtils.AllocNativeUObject(ABP_CommonPet_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C7BF RID: 182207 RVA: 0x00AA3184 File Offset: 0x00AA1384
		public ABP_CommonPet_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_CommonPet_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700778F RID: 30607
		// (get) Token: 0x0602C7C0 RID: 182208 RVA: 0x00AA31B8 File Offset: 0x00AA13B8
		// (set) Token: 0x0602C7C1 RID: 182209 RVA: 0x00AA31F1 File Offset: 0x00AA13F1
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007790 RID: 30608
		// (get) Token: 0x0602C7C2 RID: 182210 RVA: 0x00AA3214 File Offset: 0x00AA1414
		// (set) Token: 0x0602C7C3 RID: 182211 RVA: 0x00AA324D File Offset: 0x00AA144D
		public FAnimNode_Root AnimGraphNode_Root_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_1) == null)
				{
					result = (this._AnimGraphNode_Root_1 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007791 RID: 30609
		// (get) Token: 0x0602C7C4 RID: 182212 RVA: 0x00AA3270 File Offset: 0x00AA1470
		// (set) Token: 0x0602C7C5 RID: 182213 RVA: 0x00AA32A9 File Offset: 0x00AA14A9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007792 RID: 30610
		// (get) Token: 0x0602C7C6 RID: 182214 RVA: 0x00AA32CC File Offset: 0x00AA14CC
		// (set) Token: 0x0602C7C7 RID: 182215 RVA: 0x00AA3305 File Offset: 0x00AA1505
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007793 RID: 30611
		// (get) Token: 0x0602C7C8 RID: 182216 RVA: 0x00AA3328 File Offset: 0x00AA1528
		// (set) Token: 0x0602C7C9 RID: 182217 RVA: 0x00AA3361 File Offset: 0x00AA1561
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007794 RID: 30612
		// (get) Token: 0x0602C7CA RID: 182218 RVA: 0x00AA3384 File Offset: 0x00AA1584
		// (set) Token: 0x0602C7CB RID: 182219 RVA: 0x00AA33BD File Offset: 0x00AA15BD
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007795 RID: 30613
		// (get) Token: 0x0602C7CC RID: 182220 RVA: 0x00AA33E0 File Offset: 0x00AA15E0
		// (set) Token: 0x0602C7CD RID: 182221 RVA: 0x00AA3419 File Offset: 0x00AA1619
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007796 RID: 30614
		// (get) Token: 0x0602C7CE RID: 182222 RVA: 0x00AA343C File Offset: 0x00AA163C
		// (set) Token: 0x0602C7CF RID: 182223 RVA: 0x00AA3475 File Offset: 0x00AA1675
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007797 RID: 30615
		// (get) Token: 0x0602C7D0 RID: 182224 RVA: 0x00AA3498 File Offset: 0x00AA1698
		// (set) Token: 0x0602C7D1 RID: 182225 RVA: 0x00AA34D1 File Offset: 0x00AA16D1
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007798 RID: 30616
		// (get) Token: 0x0602C7D2 RID: 182226 RVA: 0x00AA34F4 File Offset: 0x00AA16F4
		// (set) Token: 0x0602C7D3 RID: 182227 RVA: 0x00AA352D File Offset: 0x00AA172D
		public FAnimNode_Inertialization AnimGraphNode_Inertialization
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Inertialization result;
				if ((result = this._AnimGraphNode_Inertialization) == null)
				{
					result = (this._AnimGraphNode_Inertialization = new FAnimNode_Inertialization(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Inertialization.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007799 RID: 30617
		// (get) Token: 0x0602C7D4 RID: 182228 RVA: 0x00AA3550 File Offset: 0x00AA1750
		// (set) Token: 0x0602C7D5 RID: 182229 RVA: 0x00AA3589 File Offset: 0x00AA1789
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700779A RID: 30618
		// (get) Token: 0x0602C7D6 RID: 182230 RVA: 0x00AA35AC File Offset: 0x00AA17AC
		// (set) Token: 0x0602C7D7 RID: 182231 RVA: 0x00AA35E5 File Offset: 0x00AA17E5
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700779B RID: 30619
		// (get) Token: 0x0602C7D8 RID: 182232 RVA: 0x00AA3608 File Offset: 0x00AA1808
		// (set) Token: 0x0602C7D9 RID: 182233 RVA: 0x00AA3641 File Offset: 0x00AA1841
		public FAnimNode_SightLock AnimGraphNode_SightLock
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SightLock result;
				if ((result = this._AnimGraphNode_SightLock) == null)
				{
					result = (this._AnimGraphNode_SightLock = new FAnimNode_SightLock(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SightLock.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700779C RID: 30620
		// (get) Token: 0x0602C7DA RID: 182234 RVA: 0x00AA3664 File Offset: 0x00AA1864
		// (set) Token: 0x0602C7DB RID: 182235 RVA: 0x00AA369D File Offset: 0x00AA189D
		public FAnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertLocalToComponentSpace result;
				if ((result = this._AnimGraphNode_LocalToComponentSpace) == null)
				{
					result = (this._AnimGraphNode_LocalToComponentSpace = new FAnimNode_ConvertLocalToComponentSpace(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertLocalToComponentSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700779D RID: 30621
		// (get) Token: 0x0602C7DC RID: 182236 RVA: 0x00AA36C0 File Offset: 0x00AA18C0
		// (set) Token: 0x0602C7DD RID: 182237 RVA: 0x00AA36F9 File Offset: 0x00AA18F9
		public FAnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertComponentToLocalSpace result;
				if ((result = this._AnimGraphNode_ComponentToLocalSpace) == null)
				{
					result = (this._AnimGraphNode_ComponentToLocalSpace = new FAnimNode_ConvertComponentToLocalSpace(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertComponentToLocalSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700779E RID: 30622
		// (get) Token: 0x0602C7DE RID: 182238 RVA: 0x00AA371C File Offset: 0x00AA191C
		// (set) Token: 0x0602C7DF RID: 182239 RVA: 0x00AA3755 File Offset: 0x00AA1955
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700779F RID: 30623
		// (get) Token: 0x0602C7E0 RID: 182240 RVA: 0x00AA3776 File Offset: 0x00AA1976
		// (set) Token: 0x0602C7E1 RID: 182241 RVA: 0x00AA378A File Offset: 0x00AA198A
		public unsafe FVector SightDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x170077A0 RID: 30624
		// (get) Token: 0x0602C7E2 RID: 182242 RVA: 0x00AA379F File Offset: 0x00AA199F
		// (set) Token: 0x0602C7E3 RID: 182243 RVA: 0x00AA37AF File Offset: 0x00AA19AF
		public unsafe SightLockMode SightLockMode
		{
			get
			{
				return (SightLockMode)(*(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_17));
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_17) = (byte)value;
			}
		}

		// Token: 0x170077A1 RID: 30625
		// (get) Token: 0x0602C7E4 RID: 182244 RVA: 0x00AA37C0 File Offset: 0x00AA19C0
		// (set) Token: 0x0602C7E5 RID: 182245 RVA: 0x00AA37D4 File Offset: 0x00AA19D4
		[Nullable(2)]
		public unsafe TsBaseCharacter 角色蓝图
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_CommonPet_C.__PropertyOffset_18);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_CommonPet_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x170077A2 RID: 30626
		// (get) Token: 0x0602C7E6 RID: 182246 RVA: 0x00AA37E9 File Offset: 0x00AA19E9
		// (set) Token: 0x0602C7E7 RID: 182247 RVA: 0x00AA37F9 File Offset: 0x00AA19F9
		public unsafe bool 是否有移动输入
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_19) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_19) = (value ? 1 : 0);
			}
		}

		// Token: 0x170077A3 RID: 30627
		// (get) Token: 0x0602C7E8 RID: 182248 RVA: 0x00AA380A File Offset: 0x00AA1A0A
		// (set) Token: 0x0602C7E9 RID: 182249 RVA: 0x00AA381A File Offset: 0x00AA1A1A
		public unsafe float 走跑混合速度参数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_CommonPet_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x0602C7EA RID: 182250 RVA: 0x00AA382C File Offset: 0x00AA1A2C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 基础层(ref FPoseLink 基础层)
		{
			ABP_CommonPet_C.__基础层_FunctionParams* ptr = stackalloc ABP_CommonPet_C.__基础层_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_CommonPet_C.__基础层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_CommonPet_C.__基础层_NativeFunctionPtr, (void*)ptr, 1);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->基础层, 基础层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_CommonPet_C.__基础层_NativeFunctionPtr, (void*)ptr);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 基础层.NativePtr, &ptr->基础层, 1, false);
			}
		}

		// Token: 0x0602C7EB RID: 182251 RVA: 0x00AA38B4 File Offset: 0x00AA1AB4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_CommonPet_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_CommonPet_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_CommonPet_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_CommonPet_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_CommonPet_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602C7EC RID: 182252 RVA: 0x00AA393B File Offset: 0x00AA1B3B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新角色移动()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_CommonPet_C.__更新角色移动_NativeFunctionPtr, null);
		}

		// Token: 0x0602C7ED RID: 182253 RVA: 0x00AA394F File Offset: 0x00AA1B4F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新视线()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_CommonPet_C.__更新视线_NativeFunctionPtr, null);
		}

		// Token: 0x0602C7EE RID: 182254 RVA: 0x00AA3964 File Offset: 0x00AA1B64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_CommonPet_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_CommonPet_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_CommonPet_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_CommonPet_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_CommonPet_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C7EF RID: 182255 RVA: 0x00AA39AC File Offset: 0x00AA1BAC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_CommonPet_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_CommonPet_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_CommonPet_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_CommonPet_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_CommonPet_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C7F0 RID: 182256 RVA: 0x00AA39F3 File Offset: 0x00AA1BF3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_CommonPet_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x0602C7F1 RID: 182257 RVA: 0x00AA3A07 File Offset: 0x00AA1C07
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_CommonPet_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C7F2 RID: 182258 RVA: 0x00AA3A1C File Offset: 0x00AA1C1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_CommonPet(int EntryPoint)
		{
			ABP_CommonPet_C.__ExecuteUbergraph_ABP_CommonPet_FunctionParams* ptr = stackalloc ABP_CommonPet_C.__ExecuteUbergraph_ABP_CommonPet_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(ABP_CommonPet_C.__ExecuteUbergraph_ABP_CommonPet_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_CommonPet_C.__ExecuteUbergraph_ABP_CommonPet_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_CommonPet_C.__ExecuteUbergraph_ABP_CommonPet_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C7F3 RID: 182259 RVA: 0x00AA3A63 File Offset: 0x00AA1C63
		protected ABP_CommonPet_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018B6A RID: 101226
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/CommonPet/ABP_CommonPet.ABP_CommonPet_C";

		// Token: 0x04018B6B RID: 101227
		private static IntPtr _ClassPtr;

		// Token: 0x04018B6C RID: 101228
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018B6D RID: 101229
		internal static int __PropertyOffset_0;

		// Token: 0x04018B6E RID: 101230
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018B6F RID: 101231
		internal static int __PropertyOffset_1;

		// Token: 0x04018B70 RID: 101232
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_1;

		// Token: 0x04018B71 RID: 101233
		internal static int __PropertyOffset_2;

		// Token: 0x04018B72 RID: 101234
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x04018B73 RID: 101235
		internal static int __PropertyOffset_3;

		// Token: 0x04018B74 RID: 101236
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x04018B75 RID: 101237
		internal static int __PropertyOffset_4;

		// Token: 0x04018B76 RID: 101238
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer;

		// Token: 0x04018B77 RID: 101239
		internal static int __PropertyOffset_5;

		// Token: 0x04018B78 RID: 101240
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x04018B79 RID: 101241
		internal static int __PropertyOffset_6;

		// Token: 0x04018B7A RID: 101242
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04018B7B RID: 101243
		internal static int __PropertyOffset_7;

		// Token: 0x04018B7C RID: 101244
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x04018B7D RID: 101245
		internal static int __PropertyOffset_8;

		// Token: 0x04018B7E RID: 101246
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x04018B7F RID: 101247
		internal static int __PropertyOffset_9;

		// Token: 0x04018B80 RID: 101248
		[Nullable(2)]
		private FAnimNode_Inertialization _AnimGraphNode_Inertialization;

		// Token: 0x04018B81 RID: 101249
		internal static int __PropertyOffset_10;

		// Token: 0x04018B82 RID: 101250
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x04018B83 RID: 101251
		internal static int __PropertyOffset_11;

		// Token: 0x04018B84 RID: 101252
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04018B85 RID: 101253
		internal static int __PropertyOffset_12;

		// Token: 0x04018B86 RID: 101254
		[Nullable(2)]
		private FAnimNode_SightLock _AnimGraphNode_SightLock;

		// Token: 0x04018B87 RID: 101255
		internal static int __PropertyOffset_13;

		// Token: 0x04018B88 RID: 101256
		[Nullable(2)]
		private FAnimNode_ConvertLocalToComponentSpace _AnimGraphNode_LocalToComponentSpace;

		// Token: 0x04018B89 RID: 101257
		internal static int __PropertyOffset_14;

		// Token: 0x04018B8A RID: 101258
		[Nullable(2)]
		private FAnimNode_ConvertComponentToLocalSpace _AnimGraphNode_ComponentToLocalSpace;

		// Token: 0x04018B8B RID: 101259
		internal static int __PropertyOffset_15;

		// Token: 0x04018B8C RID: 101260
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer;

		// Token: 0x04018B8D RID: 101261
		internal static int __PropertyOffset_16;

		// Token: 0x04018B8E RID: 101262
		internal static int __PropertyOffset_17;

		// Token: 0x04018B8F RID: 101263
		internal static int __PropertyOffset_18;

		// Token: 0x04018B90 RID: 101264
		internal static int __PropertyOffset_19;

		// Token: 0x04018B91 RID: 101265
		internal static int __PropertyOffset_20;

		// Token: 0x04018B92 RID: 101266
		private static IntPtr __基础层_NativeFunctionPtr;

		// Token: 0x04018B93 RID: 101267
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04018B94 RID: 101268
		private static IntPtr __更新角色移动_NativeFunctionPtr;

		// Token: 0x04018B95 RID: 101269
		private static IntPtr __更新视线_NativeFunctionPtr;

		// Token: 0x04018B96 RID: 101270
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x04018B97 RID: 101271
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x04018B98 RID: 101272
		private static IntPtr __ExecuteUbergraph_ABP_CommonPet_NativeFunctionPtr;

		// Token: 0x0200A453 RID: 42067
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __基础层_FunctionParams
		{
			// Token: 0x04033255 RID: 209493
			[FieldOffset(0)]
			public byte 基础层;
		}

		// Token: 0x0200A454 RID: 42068
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04033256 RID: 209494
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A455 RID: 42069
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x04033257 RID: 209495
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A456 RID: 42070
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __ExecuteUbergraph_ABP_CommonPet_FunctionParams
		{
			// Token: 0x04033258 RID: 209496
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
