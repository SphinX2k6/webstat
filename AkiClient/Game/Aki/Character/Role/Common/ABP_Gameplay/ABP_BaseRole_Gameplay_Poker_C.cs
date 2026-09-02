using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.ABP_Gameplay
{
	// Token: 0x0200406F RID: 16495
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_Poker.ABP_BaseRole_Gameplay_Poker_C")]
	[UnrealStructLayout(13840, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 13834)]
	public class ABP_BaseRole_Gameplay_Poker_C : UKuroAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602ABC5 RID: 175045 RVA: 0x00A627D8 File Offset: 0x00A609D8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_BaseRole_Gameplay_Poker_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_Poker.ABP_BaseRole_Gameplay_Poker_C");
			}
			return ABP_BaseRole_Gameplay_Poker_C._ClassPtr;
		}

		// Token: 0x0602ABC6 RID: 175046 RVA: 0x00A627FC File Offset: 0x00A609FC
		public ABP_BaseRole_Gameplay_Poker_C() : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRole_Gameplay_Poker_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602ABC7 RID: 175047 RVA: 0x00A62824 File Offset: 0x00A60A24
		public ABP_BaseRole_Gameplay_Poker_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRole_Gameplay_Poker_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006F37 RID: 28471
		// (get) Token: 0x0602ABC8 RID: 175048 RVA: 0x00A62858 File Offset: 0x00A60A58
		// (set) Token: 0x0602ABC9 RID: 175049 RVA: 0x00A62891 File Offset: 0x00A60A91
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F38 RID: 28472
		// (get) Token: 0x0602ABCA RID: 175050 RVA: 0x00A628B4 File Offset: 0x00A60AB4
		// (set) Token: 0x0602ABCB RID: 175051 RVA: 0x00A628ED File Offset: 0x00A60AED
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F39 RID: 28473
		// (get) Token: 0x0602ABCC RID: 175052 RVA: 0x00A62910 File Offset: 0x00A60B10
		// (set) Token: 0x0602ABCD RID: 175053 RVA: 0x00A62949 File Offset: 0x00A60B49
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_51
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_51) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_51 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F3A RID: 28474
		// (get) Token: 0x0602ABCE RID: 175054 RVA: 0x00A6296C File Offset: 0x00A60B6C
		// (set) Token: 0x0602ABCF RID: 175055 RVA: 0x00A629A5 File Offset: 0x00A60BA5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_50
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_50) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_50 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F3B RID: 28475
		// (get) Token: 0x0602ABD0 RID: 175056 RVA: 0x00A629C8 File Offset: 0x00A60BC8
		// (set) Token: 0x0602ABD1 RID: 175057 RVA: 0x00A62A01 File Offset: 0x00A60C01
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_49
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_49) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_49 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F3C RID: 28476
		// (get) Token: 0x0602ABD2 RID: 175058 RVA: 0x00A62A24 File Offset: 0x00A60C24
		// (set) Token: 0x0602ABD3 RID: 175059 RVA: 0x00A62A5D File Offset: 0x00A60C5D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_48
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_48) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_48 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F3D RID: 28477
		// (get) Token: 0x0602ABD4 RID: 175060 RVA: 0x00A62A80 File Offset: 0x00A60C80
		// (set) Token: 0x0602ABD5 RID: 175061 RVA: 0x00A62AB9 File Offset: 0x00A60CB9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_47
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_47) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_47 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F3E RID: 28478
		// (get) Token: 0x0602ABD6 RID: 175062 RVA: 0x00A62ADC File Offset: 0x00A60CDC
		// (set) Token: 0x0602ABD7 RID: 175063 RVA: 0x00A62B15 File Offset: 0x00A60D15
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_46
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_46) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_46 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F3F RID: 28479
		// (get) Token: 0x0602ABD8 RID: 175064 RVA: 0x00A62B38 File Offset: 0x00A60D38
		// (set) Token: 0x0602ABD9 RID: 175065 RVA: 0x00A62B71 File Offset: 0x00A60D71
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_45
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_45) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_45 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F40 RID: 28480
		// (get) Token: 0x0602ABDA RID: 175066 RVA: 0x00A62B94 File Offset: 0x00A60D94
		// (set) Token: 0x0602ABDB RID: 175067 RVA: 0x00A62BCD File Offset: 0x00A60DCD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_44
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_44) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_44 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F41 RID: 28481
		// (get) Token: 0x0602ABDC RID: 175068 RVA: 0x00A62BF0 File Offset: 0x00A60DF0
		// (set) Token: 0x0602ABDD RID: 175069 RVA: 0x00A62C29 File Offset: 0x00A60E29
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_43
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_43) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_43 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F42 RID: 28482
		// (get) Token: 0x0602ABDE RID: 175070 RVA: 0x00A62C4C File Offset: 0x00A60E4C
		// (set) Token: 0x0602ABDF RID: 175071 RVA: 0x00A62C85 File Offset: 0x00A60E85
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_42
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_42) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_42 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F43 RID: 28483
		// (get) Token: 0x0602ABE0 RID: 175072 RVA: 0x00A62CA8 File Offset: 0x00A60EA8
		// (set) Token: 0x0602ABE1 RID: 175073 RVA: 0x00A62CE1 File Offset: 0x00A60EE1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_41
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_41) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_41 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F44 RID: 28484
		// (get) Token: 0x0602ABE2 RID: 175074 RVA: 0x00A62D04 File Offset: 0x00A60F04
		// (set) Token: 0x0602ABE3 RID: 175075 RVA: 0x00A62D3D File Offset: 0x00A60F3D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_40
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_40) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_40 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F45 RID: 28485
		// (get) Token: 0x0602ABE4 RID: 175076 RVA: 0x00A62D60 File Offset: 0x00A60F60
		// (set) Token: 0x0602ABE5 RID: 175077 RVA: 0x00A62D99 File Offset: 0x00A60F99
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_39
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_39) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_39 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F46 RID: 28486
		// (get) Token: 0x0602ABE6 RID: 175078 RVA: 0x00A62DBC File Offset: 0x00A60FBC
		// (set) Token: 0x0602ABE7 RID: 175079 RVA: 0x00A62DF5 File Offset: 0x00A60FF5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_38
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_38) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_38 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F47 RID: 28487
		// (get) Token: 0x0602ABE8 RID: 175080 RVA: 0x00A62E18 File Offset: 0x00A61018
		// (set) Token: 0x0602ABE9 RID: 175081 RVA: 0x00A62E51 File Offset: 0x00A61051
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_37
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_37) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_37 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F48 RID: 28488
		// (get) Token: 0x0602ABEA RID: 175082 RVA: 0x00A62E74 File Offset: 0x00A61074
		// (set) Token: 0x0602ABEB RID: 175083 RVA: 0x00A62EAD File Offset: 0x00A610AD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_36
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_36) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_36 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F49 RID: 28489
		// (get) Token: 0x0602ABEC RID: 175084 RVA: 0x00A62ED0 File Offset: 0x00A610D0
		// (set) Token: 0x0602ABED RID: 175085 RVA: 0x00A62F09 File Offset: 0x00A61109
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_35
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_35) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_35 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F4A RID: 28490
		// (get) Token: 0x0602ABEE RID: 175086 RVA: 0x00A62F2C File Offset: 0x00A6112C
		// (set) Token: 0x0602ABEF RID: 175087 RVA: 0x00A62F65 File Offset: 0x00A61165
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_34
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_34) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_34 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F4B RID: 28491
		// (get) Token: 0x0602ABF0 RID: 175088 RVA: 0x00A62F88 File Offset: 0x00A61188
		// (set) Token: 0x0602ABF1 RID: 175089 RVA: 0x00A62FC1 File Offset: 0x00A611C1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_33
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_33) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_33 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F4C RID: 28492
		// (get) Token: 0x0602ABF2 RID: 175090 RVA: 0x00A62FE4 File Offset: 0x00A611E4
		// (set) Token: 0x0602ABF3 RID: 175091 RVA: 0x00A6301D File Offset: 0x00A6121D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_32
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_32) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_32 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F4D RID: 28493
		// (get) Token: 0x0602ABF4 RID: 175092 RVA: 0x00A63040 File Offset: 0x00A61240
		// (set) Token: 0x0602ABF5 RID: 175093 RVA: 0x00A63079 File Offset: 0x00A61279
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_31
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_31) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_31 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F4E RID: 28494
		// (get) Token: 0x0602ABF6 RID: 175094 RVA: 0x00A6309C File Offset: 0x00A6129C
		// (set) Token: 0x0602ABF7 RID: 175095 RVA: 0x00A630D5 File Offset: 0x00A612D5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_30
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_30) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_30 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F4F RID: 28495
		// (get) Token: 0x0602ABF8 RID: 175096 RVA: 0x00A630F8 File Offset: 0x00A612F8
		// (set) Token: 0x0602ABF9 RID: 175097 RVA: 0x00A63131 File Offset: 0x00A61331
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_29
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_29) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_29 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_24, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F50 RID: 28496
		// (get) Token: 0x0602ABFA RID: 175098 RVA: 0x00A63154 File Offset: 0x00A61354
		// (set) Token: 0x0602ABFB RID: 175099 RVA: 0x00A6318D File Offset: 0x00A6138D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_28
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_28) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_28 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F51 RID: 28497
		// (get) Token: 0x0602ABFC RID: 175100 RVA: 0x00A631B0 File Offset: 0x00A613B0
		// (set) Token: 0x0602ABFD RID: 175101 RVA: 0x00A631E9 File Offset: 0x00A613E9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_27
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_27) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_27 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_26, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F52 RID: 28498
		// (get) Token: 0x0602ABFE RID: 175102 RVA: 0x00A6320C File Offset: 0x00A6140C
		// (set) Token: 0x0602ABFF RID: 175103 RVA: 0x00A63245 File Offset: 0x00A61445
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_26) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_26 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_27, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F53 RID: 28499
		// (get) Token: 0x0602AC00 RID: 175104 RVA: 0x00A63268 File Offset: 0x00A61468
		// (set) Token: 0x0602AC01 RID: 175105 RVA: 0x00A632A1 File Offset: 0x00A614A1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_25) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_25 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_28, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F54 RID: 28500
		// (get) Token: 0x0602AC02 RID: 175106 RVA: 0x00A632C4 File Offset: 0x00A614C4
		// (set) Token: 0x0602AC03 RID: 175107 RVA: 0x00A632FD File Offset: 0x00A614FD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_24) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_24 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_29, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F55 RID: 28501
		// (get) Token: 0x0602AC04 RID: 175108 RVA: 0x00A63320 File Offset: 0x00A61520
		// (set) Token: 0x0602AC05 RID: 175109 RVA: 0x00A63359 File Offset: 0x00A61559
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_23) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_23 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_30, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F56 RID: 28502
		// (get) Token: 0x0602AC06 RID: 175110 RVA: 0x00A6337C File Offset: 0x00A6157C
		// (set) Token: 0x0602AC07 RID: 175111 RVA: 0x00A633B5 File Offset: 0x00A615B5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_22) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_22 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_31, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F57 RID: 28503
		// (get) Token: 0x0602AC08 RID: 175112 RVA: 0x00A633D8 File Offset: 0x00A615D8
		// (set) Token: 0x0602AC09 RID: 175113 RVA: 0x00A63411 File Offset: 0x00A61611
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_21) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_21 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_32, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F58 RID: 28504
		// (get) Token: 0x0602AC0A RID: 175114 RVA: 0x00A63434 File Offset: 0x00A61634
		// (set) Token: 0x0602AC0B RID: 175115 RVA: 0x00A6346D File Offset: 0x00A6166D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_20) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_20 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_33, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F59 RID: 28505
		// (get) Token: 0x0602AC0C RID: 175116 RVA: 0x00A63490 File Offset: 0x00A61690
		// (set) Token: 0x0602AC0D RID: 175117 RVA: 0x00A634C9 File Offset: 0x00A616C9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_19) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_19 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F5A RID: 28506
		// (get) Token: 0x0602AC0E RID: 175118 RVA: 0x00A634EC File Offset: 0x00A616EC
		// (set) Token: 0x0602AC0F RID: 175119 RVA: 0x00A63525 File Offset: 0x00A61725
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_18) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_18 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_35, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F5B RID: 28507
		// (get) Token: 0x0602AC10 RID: 175120 RVA: 0x00A63548 File Offset: 0x00A61748
		// (set) Token: 0x0602AC11 RID: 175121 RVA: 0x00A63581 File Offset: 0x00A61781
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_17) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_17 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_36, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_36, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F5C RID: 28508
		// (get) Token: 0x0602AC12 RID: 175122 RVA: 0x00A635A4 File Offset: 0x00A617A4
		// (set) Token: 0x0602AC13 RID: 175123 RVA: 0x00A635DD File Offset: 0x00A617DD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_16) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_16 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_37, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F5D RID: 28509
		// (get) Token: 0x0602AC14 RID: 175124 RVA: 0x00A63600 File Offset: 0x00A61800
		// (set) Token: 0x0602AC15 RID: 175125 RVA: 0x00A63639 File Offset: 0x00A61839
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_15) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_15 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_38, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F5E RID: 28510
		// (get) Token: 0x0602AC16 RID: 175126 RVA: 0x00A6365C File Offset: 0x00A6185C
		// (set) Token: 0x0602AC17 RID: 175127 RVA: 0x00A63695 File Offset: 0x00A61895
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_14) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_14 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_39, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_39, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F5F RID: 28511
		// (get) Token: 0x0602AC18 RID: 175128 RVA: 0x00A636B8 File Offset: 0x00A618B8
		// (set) Token: 0x0602AC19 RID: 175129 RVA: 0x00A636F1 File Offset: 0x00A618F1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_13) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_13 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_40, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_40, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F60 RID: 28512
		// (get) Token: 0x0602AC1A RID: 175130 RVA: 0x00A63714 File Offset: 0x00A61914
		// (set) Token: 0x0602AC1B RID: 175131 RVA: 0x00A6374D File Offset: 0x00A6194D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_12) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_12 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_41, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_41, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F61 RID: 28513
		// (get) Token: 0x0602AC1C RID: 175132 RVA: 0x00A63770 File Offset: 0x00A61970
		// (set) Token: 0x0602AC1D RID: 175133 RVA: 0x00A637A9 File Offset: 0x00A619A9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_11) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_11 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_42, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_42, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F62 RID: 28514
		// (get) Token: 0x0602AC1E RID: 175134 RVA: 0x00A637CC File Offset: 0x00A619CC
		// (set) Token: 0x0602AC1F RID: 175135 RVA: 0x00A63805 File Offset: 0x00A61A05
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_10) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_10 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_43, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_43, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F63 RID: 28515
		// (get) Token: 0x0602AC20 RID: 175136 RVA: 0x00A63828 File Offset: 0x00A61A28
		// (set) Token: 0x0602AC21 RID: 175137 RVA: 0x00A63861 File Offset: 0x00A61A61
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_9) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_9 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_44, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_44, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F64 RID: 28516
		// (get) Token: 0x0602AC22 RID: 175138 RVA: 0x00A63884 File Offset: 0x00A61A84
		// (set) Token: 0x0602AC23 RID: 175139 RVA: 0x00A638BD File Offset: 0x00A61ABD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_8) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_8 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_45, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_45, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F65 RID: 28517
		// (get) Token: 0x0602AC24 RID: 175140 RVA: 0x00A638E0 File Offset: 0x00A61AE0
		// (set) Token: 0x0602AC25 RID: 175141 RVA: 0x00A63919 File Offset: 0x00A61B19
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_7) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_7 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_46, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_46, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F66 RID: 28518
		// (get) Token: 0x0602AC26 RID: 175142 RVA: 0x00A6393C File Offset: 0x00A61B3C
		// (set) Token: 0x0602AC27 RID: 175143 RVA: 0x00A63975 File Offset: 0x00A61B75
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_26) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_26 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_47, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_47, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F67 RID: 28519
		// (get) Token: 0x0602AC28 RID: 175144 RVA: 0x00A63998 File Offset: 0x00A61B98
		// (set) Token: 0x0602AC29 RID: 175145 RVA: 0x00A639D1 File Offset: 0x00A61BD1
		public FAnimNode_StateResult AnimGraphNode_StateResult_29
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_29) == null)
				{
					result = (this._AnimGraphNode_StateResult_29 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_48, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_48, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F68 RID: 28520
		// (get) Token: 0x0602AC2A RID: 175146 RVA: 0x00A639F4 File Offset: 0x00A61BF4
		// (set) Token: 0x0602AC2B RID: 175147 RVA: 0x00A63A2D File Offset: 0x00A61C2D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_25) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_25 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_49, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_49, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F69 RID: 28521
		// (get) Token: 0x0602AC2C RID: 175148 RVA: 0x00A63A50 File Offset: 0x00A61C50
		// (set) Token: 0x0602AC2D RID: 175149 RVA: 0x00A63A89 File Offset: 0x00A61C89
		public FAnimNode_StateResult AnimGraphNode_StateResult_28
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_28) == null)
				{
					result = (this._AnimGraphNode_StateResult_28 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_50, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_50, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F6A RID: 28522
		// (get) Token: 0x0602AC2E RID: 175150 RVA: 0x00A63AAC File Offset: 0x00A61CAC
		// (set) Token: 0x0602AC2F RID: 175151 RVA: 0x00A63AE5 File Offset: 0x00A61CE5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_24) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_24 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_51, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_51, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F6B RID: 28523
		// (get) Token: 0x0602AC30 RID: 175152 RVA: 0x00A63B08 File Offset: 0x00A61D08
		// (set) Token: 0x0602AC31 RID: 175153 RVA: 0x00A63B41 File Offset: 0x00A61D41
		public FAnimNode_StateResult AnimGraphNode_StateResult_27
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_27) == null)
				{
					result = (this._AnimGraphNode_StateResult_27 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_52, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_52, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F6C RID: 28524
		// (get) Token: 0x0602AC32 RID: 175154 RVA: 0x00A63B64 File Offset: 0x00A61D64
		// (set) Token: 0x0602AC33 RID: 175155 RVA: 0x00A63B9D File Offset: 0x00A61D9D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_23) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_23 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_53, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_53, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F6D RID: 28525
		// (get) Token: 0x0602AC34 RID: 175156 RVA: 0x00A63BC0 File Offset: 0x00A61DC0
		// (set) Token: 0x0602AC35 RID: 175157 RVA: 0x00A63BF9 File Offset: 0x00A61DF9
		public FAnimNode_StateResult AnimGraphNode_StateResult_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_26) == null)
				{
					result = (this._AnimGraphNode_StateResult_26 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_54, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_54, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F6E RID: 28526
		// (get) Token: 0x0602AC36 RID: 175158 RVA: 0x00A63C1C File Offset: 0x00A61E1C
		// (set) Token: 0x0602AC37 RID: 175159 RVA: 0x00A63C55 File Offset: 0x00A61E55
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_22) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_22 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_55, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_55, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F6F RID: 28527
		// (get) Token: 0x0602AC38 RID: 175160 RVA: 0x00A63C78 File Offset: 0x00A61E78
		// (set) Token: 0x0602AC39 RID: 175161 RVA: 0x00A63CB1 File Offset: 0x00A61EB1
		public FAnimNode_StateResult AnimGraphNode_StateResult_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_25) == null)
				{
					result = (this._AnimGraphNode_StateResult_25 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_56, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_56, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F70 RID: 28528
		// (get) Token: 0x0602AC3A RID: 175162 RVA: 0x00A63CD4 File Offset: 0x00A61ED4
		// (set) Token: 0x0602AC3B RID: 175163 RVA: 0x00A63D0D File Offset: 0x00A61F0D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_21) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_21 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_57, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_57, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F71 RID: 28529
		// (get) Token: 0x0602AC3C RID: 175164 RVA: 0x00A63D30 File Offset: 0x00A61F30
		// (set) Token: 0x0602AC3D RID: 175165 RVA: 0x00A63D69 File Offset: 0x00A61F69
		public FAnimNode_StateResult AnimGraphNode_StateResult_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_24) == null)
				{
					result = (this._AnimGraphNode_StateResult_24 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_58, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_58, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F72 RID: 28530
		// (get) Token: 0x0602AC3E RID: 175166 RVA: 0x00A63D8C File Offset: 0x00A61F8C
		// (set) Token: 0x0602AC3F RID: 175167 RVA: 0x00A63DC5 File Offset: 0x00A61FC5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_20) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_20 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_59, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_59, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F73 RID: 28531
		// (get) Token: 0x0602AC40 RID: 175168 RVA: 0x00A63DE8 File Offset: 0x00A61FE8
		// (set) Token: 0x0602AC41 RID: 175169 RVA: 0x00A63E21 File Offset: 0x00A62021
		public FAnimNode_StateResult AnimGraphNode_StateResult_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_23) == null)
				{
					result = (this._AnimGraphNode_StateResult_23 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_60, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_60, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F74 RID: 28532
		// (get) Token: 0x0602AC42 RID: 175170 RVA: 0x00A63E44 File Offset: 0x00A62044
		// (set) Token: 0x0602AC43 RID: 175171 RVA: 0x00A63E7D File Offset: 0x00A6207D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_19) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_19 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_61, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_61, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F75 RID: 28533
		// (get) Token: 0x0602AC44 RID: 175172 RVA: 0x00A63EA0 File Offset: 0x00A620A0
		// (set) Token: 0x0602AC45 RID: 175173 RVA: 0x00A63ED9 File Offset: 0x00A620D9
		public FAnimNode_StateResult AnimGraphNode_StateResult_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_22) == null)
				{
					result = (this._AnimGraphNode_StateResult_22 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_62, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_62, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F76 RID: 28534
		// (get) Token: 0x0602AC46 RID: 175174 RVA: 0x00A63EFC File Offset: 0x00A620FC
		// (set) Token: 0x0602AC47 RID: 175175 RVA: 0x00A63F35 File Offset: 0x00A62135
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_18) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_18 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_63, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_63, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F77 RID: 28535
		// (get) Token: 0x0602AC48 RID: 175176 RVA: 0x00A63F58 File Offset: 0x00A62158
		// (set) Token: 0x0602AC49 RID: 175177 RVA: 0x00A63F91 File Offset: 0x00A62191
		public FAnimNode_StateResult AnimGraphNode_StateResult_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_21) == null)
				{
					result = (this._AnimGraphNode_StateResult_21 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_64, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_64, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F78 RID: 28536
		// (get) Token: 0x0602AC4A RID: 175178 RVA: 0x00A63FB4 File Offset: 0x00A621B4
		// (set) Token: 0x0602AC4B RID: 175179 RVA: 0x00A63FED File Offset: 0x00A621ED
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_17) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_17 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_65, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_65, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F79 RID: 28537
		// (get) Token: 0x0602AC4C RID: 175180 RVA: 0x00A64010 File Offset: 0x00A62210
		// (set) Token: 0x0602AC4D RID: 175181 RVA: 0x00A64049 File Offset: 0x00A62249
		public FAnimNode_StateResult AnimGraphNode_StateResult_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_20) == null)
				{
					result = (this._AnimGraphNode_StateResult_20 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_66, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_66, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F7A RID: 28538
		// (get) Token: 0x0602AC4E RID: 175182 RVA: 0x00A6406C File Offset: 0x00A6226C
		// (set) Token: 0x0602AC4F RID: 175183 RVA: 0x00A640A5 File Offset: 0x00A622A5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_16) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_16 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_67, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_67, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F7B RID: 28539
		// (get) Token: 0x0602AC50 RID: 175184 RVA: 0x00A640C8 File Offset: 0x00A622C8
		// (set) Token: 0x0602AC51 RID: 175185 RVA: 0x00A64101 File Offset: 0x00A62301
		public FAnimNode_StateResult AnimGraphNode_StateResult_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_19) == null)
				{
					result = (this._AnimGraphNode_StateResult_19 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_68, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_68, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F7C RID: 28540
		// (get) Token: 0x0602AC52 RID: 175186 RVA: 0x00A64124 File Offset: 0x00A62324
		// (set) Token: 0x0602AC53 RID: 175187 RVA: 0x00A6415D File Offset: 0x00A6235D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_15) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_15 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_69, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_69, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F7D RID: 28541
		// (get) Token: 0x0602AC54 RID: 175188 RVA: 0x00A64180 File Offset: 0x00A62380
		// (set) Token: 0x0602AC55 RID: 175189 RVA: 0x00A641B9 File Offset: 0x00A623B9
		public FAnimNode_StateResult AnimGraphNode_StateResult_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_18) == null)
				{
					result = (this._AnimGraphNode_StateResult_18 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_70, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_70, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F7E RID: 28542
		// (get) Token: 0x0602AC56 RID: 175190 RVA: 0x00A641DC File Offset: 0x00A623DC
		// (set) Token: 0x0602AC57 RID: 175191 RVA: 0x00A64215 File Offset: 0x00A62415
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_6) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_6 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_71, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_71, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F7F RID: 28543
		// (get) Token: 0x0602AC58 RID: 175192 RVA: 0x00A64238 File Offset: 0x00A62438
		// (set) Token: 0x0602AC59 RID: 175193 RVA: 0x00A64271 File Offset: 0x00A62471
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_14) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_14 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_72, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_72, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F80 RID: 28544
		// (get) Token: 0x0602AC5A RID: 175194 RVA: 0x00A64294 File Offset: 0x00A62494
		// (set) Token: 0x0602AC5B RID: 175195 RVA: 0x00A642CD File Offset: 0x00A624CD
		public FAnimNode_StateResult AnimGraphNode_StateResult_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_17) == null)
				{
					result = (this._AnimGraphNode_StateResult_17 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_73, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_73, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F81 RID: 28545
		// (get) Token: 0x0602AC5C RID: 175196 RVA: 0x00A642F0 File Offset: 0x00A624F0
		// (set) Token: 0x0602AC5D RID: 175197 RVA: 0x00A64329 File Offset: 0x00A62529
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_13) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_13 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_74, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_74, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F82 RID: 28546
		// (get) Token: 0x0602AC5E RID: 175198 RVA: 0x00A6434C File Offset: 0x00A6254C
		// (set) Token: 0x0602AC5F RID: 175199 RVA: 0x00A64385 File Offset: 0x00A62585
		public FAnimNode_StateResult AnimGraphNode_StateResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_16) == null)
				{
					result = (this._AnimGraphNode_StateResult_16 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_75, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_75, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F83 RID: 28547
		// (get) Token: 0x0602AC60 RID: 175200 RVA: 0x00A643A8 File Offset: 0x00A625A8
		// (set) Token: 0x0602AC61 RID: 175201 RVA: 0x00A643E1 File Offset: 0x00A625E1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_12) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_12 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_76, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_76, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F84 RID: 28548
		// (get) Token: 0x0602AC62 RID: 175202 RVA: 0x00A64404 File Offset: 0x00A62604
		// (set) Token: 0x0602AC63 RID: 175203 RVA: 0x00A6443D File Offset: 0x00A6263D
		public FAnimNode_StateResult AnimGraphNode_StateResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_15) == null)
				{
					result = (this._AnimGraphNode_StateResult_15 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_77, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_77, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F85 RID: 28549
		// (get) Token: 0x0602AC64 RID: 175204 RVA: 0x00A64460 File Offset: 0x00A62660
		// (set) Token: 0x0602AC65 RID: 175205 RVA: 0x00A64499 File Offset: 0x00A62699
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_11) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_11 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_78, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_78, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F86 RID: 28550
		// (get) Token: 0x0602AC66 RID: 175206 RVA: 0x00A644BC File Offset: 0x00A626BC
		// (set) Token: 0x0602AC67 RID: 175207 RVA: 0x00A644F5 File Offset: 0x00A626F5
		public FAnimNode_StateResult AnimGraphNode_StateResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_14) == null)
				{
					result = (this._AnimGraphNode_StateResult_14 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_79, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_79, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F87 RID: 28551
		// (get) Token: 0x0602AC68 RID: 175208 RVA: 0x00A64518 File Offset: 0x00A62718
		// (set) Token: 0x0602AC69 RID: 175209 RVA: 0x00A64551 File Offset: 0x00A62751
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_10) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_10 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_80, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_80, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F88 RID: 28552
		// (get) Token: 0x0602AC6A RID: 175210 RVA: 0x00A64574 File Offset: 0x00A62774
		// (set) Token: 0x0602AC6B RID: 175211 RVA: 0x00A645AD File Offset: 0x00A627AD
		public FAnimNode_StateResult AnimGraphNode_StateResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_13) == null)
				{
					result = (this._AnimGraphNode_StateResult_13 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_81, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_81, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F89 RID: 28553
		// (get) Token: 0x0602AC6C RID: 175212 RVA: 0x00A645D0 File Offset: 0x00A627D0
		// (set) Token: 0x0602AC6D RID: 175213 RVA: 0x00A64609 File Offset: 0x00A62809
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_9) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_9 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_82, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_82, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F8A RID: 28554
		// (get) Token: 0x0602AC6E RID: 175214 RVA: 0x00A6462C File Offset: 0x00A6282C
		// (set) Token: 0x0602AC6F RID: 175215 RVA: 0x00A64665 File Offset: 0x00A62865
		public FAnimNode_StateResult AnimGraphNode_StateResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_12) == null)
				{
					result = (this._AnimGraphNode_StateResult_12 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_83, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_83, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F8B RID: 28555
		// (get) Token: 0x0602AC70 RID: 175216 RVA: 0x00A64688 File Offset: 0x00A62888
		// (set) Token: 0x0602AC71 RID: 175217 RVA: 0x00A646C1 File Offset: 0x00A628C1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_8) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_8 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_84, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_84, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F8C RID: 28556
		// (get) Token: 0x0602AC72 RID: 175218 RVA: 0x00A646E4 File Offset: 0x00A628E4
		// (set) Token: 0x0602AC73 RID: 175219 RVA: 0x00A6471D File Offset: 0x00A6291D
		public FAnimNode_StateResult AnimGraphNode_StateResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_11) == null)
				{
					result = (this._AnimGraphNode_StateResult_11 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_85, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_85, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F8D RID: 28557
		// (get) Token: 0x0602AC74 RID: 175220 RVA: 0x00A64740 File Offset: 0x00A62940
		// (set) Token: 0x0602AC75 RID: 175221 RVA: 0x00A64779 File Offset: 0x00A62979
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_7) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_7 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_86, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_86, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F8E RID: 28558
		// (get) Token: 0x0602AC76 RID: 175222 RVA: 0x00A6479C File Offset: 0x00A6299C
		// (set) Token: 0x0602AC77 RID: 175223 RVA: 0x00A647D5 File Offset: 0x00A629D5
		public FAnimNode_StateResult AnimGraphNode_StateResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_10) == null)
				{
					result = (this._AnimGraphNode_StateResult_10 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_87, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_87, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F8F RID: 28559
		// (get) Token: 0x0602AC78 RID: 175224 RVA: 0x00A647F8 File Offset: 0x00A629F8
		// (set) Token: 0x0602AC79 RID: 175225 RVA: 0x00A64831 File Offset: 0x00A62A31
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_5) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_5 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_88, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_88, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F90 RID: 28560
		// (get) Token: 0x0602AC7A RID: 175226 RVA: 0x00A64854 File Offset: 0x00A62A54
		// (set) Token: 0x0602AC7B RID: 175227 RVA: 0x00A6488D File Offset: 0x00A62A8D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_4) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_4 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_89, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_89, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F91 RID: 28561
		// (get) Token: 0x0602AC7C RID: 175228 RVA: 0x00A648B0 File Offset: 0x00A62AB0
		// (set) Token: 0x0602AC7D RID: 175229 RVA: 0x00A648E9 File Offset: 0x00A62AE9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_3 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_90, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_90, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F92 RID: 28562
		// (get) Token: 0x0602AC7E RID: 175230 RVA: 0x00A6490C File Offset: 0x00A62B0C
		// (set) Token: 0x0602AC7F RID: 175231 RVA: 0x00A64945 File Offset: 0x00A62B45
		public FAnimNode_StateResult AnimGraphNode_StateResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_9) == null)
				{
					result = (this._AnimGraphNode_StateResult_9 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_91, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_91, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F93 RID: 28563
		// (get) Token: 0x0602AC80 RID: 175232 RVA: 0x00A64968 File Offset: 0x00A62B68
		// (set) Token: 0x0602AC81 RID: 175233 RVA: 0x00A649A1 File Offset: 0x00A62BA1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_6) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_6 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_92, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_92, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F94 RID: 28564
		// (get) Token: 0x0602AC82 RID: 175234 RVA: 0x00A649C4 File Offset: 0x00A62BC4
		// (set) Token: 0x0602AC83 RID: 175235 RVA: 0x00A649FD File Offset: 0x00A62BFD
		public FAnimNode_StateResult AnimGraphNode_StateResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_8) == null)
				{
					result = (this._AnimGraphNode_StateResult_8 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_93, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_93, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F95 RID: 28565
		// (get) Token: 0x0602AC84 RID: 175236 RVA: 0x00A64A20 File Offset: 0x00A62C20
		// (set) Token: 0x0602AC85 RID: 175237 RVA: 0x00A64A59 File Offset: 0x00A62C59
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_5) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_5 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_94, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_94, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F96 RID: 28566
		// (get) Token: 0x0602AC86 RID: 175238 RVA: 0x00A64A7C File Offset: 0x00A62C7C
		// (set) Token: 0x0602AC87 RID: 175239 RVA: 0x00A64AB5 File Offset: 0x00A62CB5
		public FAnimNode_StateResult AnimGraphNode_StateResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_7) == null)
				{
					result = (this._AnimGraphNode_StateResult_7 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_95, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_95, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F97 RID: 28567
		// (get) Token: 0x0602AC88 RID: 175240 RVA: 0x00A64AD8 File Offset: 0x00A62CD8
		// (set) Token: 0x0602AC89 RID: 175241 RVA: 0x00A64B11 File Offset: 0x00A62D11
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_4) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_4 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_96, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_96, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F98 RID: 28568
		// (get) Token: 0x0602AC8A RID: 175242 RVA: 0x00A64B34 File Offset: 0x00A62D34
		// (set) Token: 0x0602AC8B RID: 175243 RVA: 0x00A64B6D File Offset: 0x00A62D6D
		public FAnimNode_StateResult AnimGraphNode_StateResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_6) == null)
				{
					result = (this._AnimGraphNode_StateResult_6 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_97, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_97, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F99 RID: 28569
		// (get) Token: 0x0602AC8C RID: 175244 RVA: 0x00A64B90 File Offset: 0x00A62D90
		// (set) Token: 0x0602AC8D RID: 175245 RVA: 0x00A64BC9 File Offset: 0x00A62DC9
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_2) == null)
				{
					result = (this._AnimGraphNode_StateMachine_2 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_98, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_98, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F9A RID: 28570
		// (get) Token: 0x0602AC8E RID: 175246 RVA: 0x00A64BEC File Offset: 0x00A62DEC
		// (set) Token: 0x0602AC8F RID: 175247 RVA: 0x00A64C25 File Offset: 0x00A62E25
		public FAnimNode_StateResult AnimGraphNode_StateResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_5) == null)
				{
					result = (this._AnimGraphNode_StateResult_5 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_99, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_99, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F9B RID: 28571
		// (get) Token: 0x0602AC90 RID: 175248 RVA: 0x00A64C48 File Offset: 0x00A62E48
		// (set) Token: 0x0602AC91 RID: 175249 RVA: 0x00A64C81 File Offset: 0x00A62E81
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_100, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_100, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F9C RID: 28572
		// (get) Token: 0x0602AC92 RID: 175250 RVA: 0x00A64CA4 File Offset: 0x00A62EA4
		// (set) Token: 0x0602AC93 RID: 175251 RVA: 0x00A64CDD File Offset: 0x00A62EDD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_101, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_101, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F9D RID: 28573
		// (get) Token: 0x0602AC94 RID: 175252 RVA: 0x00A64D00 File Offset: 0x00A62F00
		// (set) Token: 0x0602AC95 RID: 175253 RVA: 0x00A64D39 File Offset: 0x00A62F39
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_102, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_102, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F9E RID: 28574
		// (get) Token: 0x0602AC96 RID: 175254 RVA: 0x00A64D5C File Offset: 0x00A62F5C
		// (set) Token: 0x0602AC97 RID: 175255 RVA: 0x00A64D95 File Offset: 0x00A62F95
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_3) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_3 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_103, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_103, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F9F RID: 28575
		// (get) Token: 0x0602AC98 RID: 175256 RVA: 0x00A64DB8 File Offset: 0x00A62FB8
		// (set) Token: 0x0602AC99 RID: 175257 RVA: 0x00A64DF1 File Offset: 0x00A62FF1
		public FAnimNode_StateResult AnimGraphNode_StateResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_4) == null)
				{
					result = (this._AnimGraphNode_StateResult_4 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_104, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_104, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FA0 RID: 28576
		// (get) Token: 0x0602AC9A RID: 175258 RVA: 0x00A64E14 File Offset: 0x00A63014
		// (set) Token: 0x0602AC9B RID: 175259 RVA: 0x00A64E4D File Offset: 0x00A6304D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_2) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_2 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_105, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_105, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FA1 RID: 28577
		// (get) Token: 0x0602AC9C RID: 175260 RVA: 0x00A64E70 File Offset: 0x00A63070
		// (set) Token: 0x0602AC9D RID: 175261 RVA: 0x00A64EA9 File Offset: 0x00A630A9
		public FAnimNode_StateResult AnimGraphNode_StateResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_3) == null)
				{
					result = (this._AnimGraphNode_StateResult_3 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_106, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_106, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FA2 RID: 28578
		// (get) Token: 0x0602AC9E RID: 175262 RVA: 0x00A64ECC File Offset: 0x00A630CC
		// (set) Token: 0x0602AC9F RID: 175263 RVA: 0x00A64F05 File Offset: 0x00A63105
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_1 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_107, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_107, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FA3 RID: 28579
		// (get) Token: 0x0602ACA0 RID: 175264 RVA: 0x00A64F28 File Offset: 0x00A63128
		// (set) Token: 0x0602ACA1 RID: 175265 RVA: 0x00A64F61 File Offset: 0x00A63161
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_108, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_108, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FA4 RID: 28580
		// (get) Token: 0x0602ACA2 RID: 175266 RVA: 0x00A64F84 File Offset: 0x00A63184
		// (set) Token: 0x0602ACA3 RID: 175267 RVA: 0x00A64FBD File Offset: 0x00A631BD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_109, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_109, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FA5 RID: 28581
		// (get) Token: 0x0602ACA4 RID: 175268 RVA: 0x00A64FE0 File Offset: 0x00A631E0
		// (set) Token: 0x0602ACA5 RID: 175269 RVA: 0x00A65019 File Offset: 0x00A63219
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_110, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_110, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FA6 RID: 28582
		// (get) Token: 0x0602ACA6 RID: 175270 RVA: 0x00A6503C File Offset: 0x00A6323C
		// (set) Token: 0x0602ACA7 RID: 175271 RVA: 0x00A65075 File Offset: 0x00A63275
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_1) == null)
				{
					result = (this._AnimGraphNode_StateMachine_1 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_111, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_111, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FA7 RID: 28583
		// (get) Token: 0x0602ACA8 RID: 175272 RVA: 0x00A65098 File Offset: 0x00A63298
		// (set) Token: 0x0602ACA9 RID: 175273 RVA: 0x00A650D1 File Offset: 0x00A632D1
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_112, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_112, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FA8 RID: 28584
		// (get) Token: 0x0602ACAA RID: 175274 RVA: 0x00A650F4 File Offset: 0x00A632F4
		// (set) Token: 0x0602ACAB RID: 175275 RVA: 0x00A6512D File Offset: 0x00A6332D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_113, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_113, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FA9 RID: 28585
		// (get) Token: 0x0602ACAC RID: 175276 RVA: 0x00A65150 File Offset: 0x00A63350
		// (set) Token: 0x0602ACAD RID: 175277 RVA: 0x00A65189 File Offset: 0x00A63389
		public FAnimNode_CombineCurves AnimGraphNode_CombineCurves
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_CombineCurves result;
				if ((result = this._AnimGraphNode_CombineCurves) == null)
				{
					result = (this._AnimGraphNode_CombineCurves = new FAnimNode_CombineCurves(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_114, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_CombineCurves.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_114, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006FAA RID: 28586
		// (get) Token: 0x0602ACAE RID: 175278 RVA: 0x00A651AA File Offset: 0x00A633AA
		// (set) Token: 0x0602ACAF RID: 175279 RVA: 0x00A651BE File Offset: 0x00A633BE
		[Nullable(0)]
		public unsafe TEnumAsByte<EPokerStateType> PokerState
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_115);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_115) = value;
			}
		}

		// Token: 0x17006FAB RID: 28587
		// (get) Token: 0x0602ACB0 RID: 175280 RVA: 0x00A651D3 File Offset: 0x00A633D3
		// (set) Token: 0x0602ACB1 RID: 175281 RVA: 0x00A651E3 File Offset: 0x00A633E3
		public unsafe float 猜鬼牌表演倒计时
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_116);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_116) = value;
			}
		}

		// Token: 0x17006FAC RID: 28588
		// (get) Token: 0x0602ACB2 RID: 175282 RVA: 0x00A651F4 File Offset: 0x00A633F4
		// (set) Token: 0x0602ACB3 RID: 175283 RVA: 0x00A65204 File Offset: 0x00A63404
		public unsafe int PokerPerformanceIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_117);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_117) = value;
			}
		}

		// Token: 0x17006FAD RID: 28589
		// (get) Token: 0x0602ACB4 RID: 175284 RVA: 0x00A65215 File Offset: 0x00A63415
		// (set) Token: 0x0602ACB5 RID: 175285 RVA: 0x00A65225 File Offset: 0x00A63425
		public unsafe float DeltaTimeX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_118);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_118) = value;
			}
		}

		// Token: 0x17006FAE RID: 28590
		// (get) Token: 0x0602ACB6 RID: 175286 RVA: 0x00A65236 File Offset: 0x00A63436
		// (set) Token: 0x0602ACB7 RID: 175287 RVA: 0x00A6524A File Offset: 0x00A6344A
		[Nullable(0)]
		public unsafe TEnumAsByte<EPokerIdleState> IdleState
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_119);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_119) = value;
			}
		}

		// Token: 0x17006FAF RID: 28591
		// (get) Token: 0x0602ACB8 RID: 175288 RVA: 0x00A6525F File Offset: 0x00A6345F
		// (set) Token: 0x0602ACB9 RID: 175289 RVA: 0x00A6526F File Offset: 0x00A6346F
		public unsafe bool bIdleTimerActive
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_120) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_120) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006FB0 RID: 28592
		// (get) Token: 0x0602ACBA RID: 175290 RVA: 0x00A65280 File Offset: 0x00A63480
		// (set) Token: 0x0602ACBB RID: 175291 RVA: 0x00A65290 File Offset: 0x00A63490
		public unsafe int BeChooseEmotionIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_121);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_121) = value;
			}
		}

		// Token: 0x17006FB1 RID: 28593
		// (get) Token: 0x0602ACBC RID: 175292 RVA: 0x00A652A1 File Offset: 0x00A634A1
		// (set) Token: 0x0602ACBD RID: 175293 RVA: 0x00A652B1 File Offset: 0x00A634B1
		public unsafe bool bPlayerInteractiveStage
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_122) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_122) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006FB2 RID: 28594
		// (get) Token: 0x0602ACBE RID: 175294 RVA: 0x00A652C2 File Offset: 0x00A634C2
		// (set) Token: 0x0602ACBF RID: 175295 RVA: 0x00A652D2 File Offset: 0x00A634D2
		public unsafe bool bForceEndLoop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_123) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_Poker_C.__PropertyOffset_123) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602ACC0 RID: 175296 RVA: 0x00A652E4 File Offset: 0x00A634E4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_BaseRole_Gameplay_Poker_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_Poker_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_Poker_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_Poker_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602ACC1 RID: 175297 RVA: 0x00A6536B File Offset: 0x00A6356B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InitPerformanceTickTime()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__InitPerformanceTickTime_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACC2 RID: 175298 RVA: 0x00A65380 File Offset: 0x00A63580
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetPlayerInteractiveStage(bool isInteractive)
		{
			ABP_BaseRole_Gameplay_Poker_C.__SetPlayerInteractiveStage_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_Poker_C.__SetPlayerInteractiveStage_FunctionParams[(UIntPtr)18] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_Poker_C.__SetPlayerInteractiveStage_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_Poker_C.__SetPlayerInteractiveStage_NativeFunctionPtr, (void*)ptr, 1);
			ptr->isInteractive = isInteractive;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__SetPlayerInteractiveStage_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602ACC3 RID: 175299 RVA: 0x00A653C8 File Offset: 0x00A635C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetBeChooseEmotionIndex(int index)
		{
			ABP_BaseRole_Gameplay_Poker_C.__SetBeChooseEmotionIndex_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_Poker_C.__SetBeChooseEmotionIndex_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_Poker_C.__SetBeChooseEmotionIndex_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_Poker_C.__SetBeChooseEmotionIndex_NativeFunctionPtr, (void*)ptr, 1);
			ptr->index = index;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__SetBeChooseEmotionIndex_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602ACC4 RID: 175300 RVA: 0x00A6540E File Offset: 0x00A6360E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ReturnIdel()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__ReturnIdel_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACC5 RID: 175301 RVA: 0x00A65424 File Offset: 0x00A63624
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetPokerIdleState(EPokerIdleState IdleState)
		{
			ABP_BaseRole_Gameplay_Poker_C.__SetPokerIdleState_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_Poker_C.__SetPokerIdleState_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_Poker_C.__SetPokerIdleState_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_Poker_C.__SetPokerIdleState_NativeFunctionPtr, (void*)ptr, 1);
			ptr->IdleState = IdleState;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__SetPokerIdleState_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602ACC6 RID: 175302 RVA: 0x00A65470 File Offset: 0x00A63670
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetPokerState(EPokerStateType PokerState)
		{
			ABP_BaseRole_Gameplay_Poker_C.__SetPokerState_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_Poker_C.__SetPokerState_FunctionParams[(UIntPtr)71] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_Poker_C.__SetPokerState_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_Poker_C.__SetPokerState_NativeFunctionPtr, (void*)ptr, 1);
			ptr->PokerState = PokerState;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__SetPokerState_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602ACC7 RID: 175303 RVA: 0x00A654BB File Offset: 0x00A636BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 设置猜鬼牌表演倒计时()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__设置猜鬼牌表演倒计时_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACC8 RID: 175304 RVA: 0x00A654CF File Offset: 0x00A636CF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_B0C4264C477F9205671B229D72F82639()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_B0C4264C477F9205671B229D72F82639_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACC9 RID: 175305 RVA: 0x00A654E3 File Offset: 0x00A636E3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_22DE1A4C4E44B1104D60A4BF1F11DA28()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_22DE1A4C4E44B1104D60A4BF1F11DA28_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACCA RID: 175306 RVA: 0x00A654F7 File Offset: 0x00A636F7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_1A772CD743C7FC372EB67489E73C289E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_1A772CD743C7FC372EB67489E73C289E_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACCB RID: 175307 RVA: 0x00A6550B File Offset: 0x00A6370B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_3A40E8754ADFC24EE0AF45B0C85BC41C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_3A40E8754ADFC24EE0AF45B0C85BC41C_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACCC RID: 175308 RVA: 0x00A6551F File Offset: 0x00A6371F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_F6EC2F8B4CCCB0E29BF88AB1173DD3ED()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_F6EC2F8B4CCCB0E29BF88AB1173DD3ED_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACCD RID: 175309 RVA: 0x00A65533 File Offset: 0x00A63733
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_666E367B41DAF09350BF73AABC60140E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_666E367B41DAF09350BF73AABC60140E_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACCE RID: 175310 RVA: 0x00A65547 File Offset: 0x00A63747
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_093778EF47276D0CF81ABEADE900AEB1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_093778EF47276D0CF81ABEADE900AEB1_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACCF RID: 175311 RVA: 0x00A6555B File Offset: 0x00A6375B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_5E39136C478670F29BD7E3B1B62D0F57()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_5E39136C478670F29BD7E3B1B62D0F57_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACD0 RID: 175312 RVA: 0x00A6556F File Offset: 0x00A6376F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_F8E0F34B4FC5EF76DA95C7B116578734()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_F8E0F34B4FC5EF76DA95C7B116578734_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACD1 RID: 175313 RVA: 0x00A65583 File Offset: 0x00A63783
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_F94C0BF043DA97DBD5E647BFA2CD4DB1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_F94C0BF043DA97DBD5E647BFA2CD4DB1_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACD2 RID: 175314 RVA: 0x00A65597 File Offset: 0x00A63797
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_AC461C304B69A536250CCE8A3982A466()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_AC461C304B69A536250CCE8A3982A466_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACD3 RID: 175315 RVA: 0x00A655AB File Offset: 0x00A637AB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_9A24B50941EF191D85D7BCB0EF1FAC6F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_9A24B50941EF191D85D7BCB0EF1FAC6F_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACD4 RID: 175316 RVA: 0x00A655BF File Offset: 0x00A637BF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_415A7B6B426DA35AE6422192B98E0EAF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_415A7B6B426DA35AE6422192B98E0EAF_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACD5 RID: 175317 RVA: 0x00A655D3 File Offset: 0x00A637D3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_E1EC354344A3A58CD369EDB992E81F08()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_E1EC354344A3A58CD369EDB992E81F08_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACD6 RID: 175318 RVA: 0x00A655E7 File Offset: 0x00A637E7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_5F0A7FFC4791AD211417B3AB0D494E5F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_5F0A7FFC4791AD211417B3AB0D494E5F_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACD7 RID: 175319 RVA: 0x00A655FB File Offset: 0x00A637FB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_37EF4BE94A4877A983454F9D706735EB()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_37EF4BE94A4877A983454F9D706735EB_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACD8 RID: 175320 RVA: 0x00A6560F File Offset: 0x00A6380F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_960E2E2B40B6EE6B49C23EB99E6FEC9E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_960E2E2B40B6EE6B49C23EB99E6FEC9E_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACD9 RID: 175321 RVA: 0x00A65623 File Offset: 0x00A63823
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_0158D08F4E06F22B0A0442892892A5A2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_0158D08F4E06F22B0A0442892892A5A2_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACDA RID: 175322 RVA: 0x00A65637 File Offset: 0x00A63837
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_6F6373414A565BC8512F10AFA3648616()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_6F6373414A565BC8512F10AFA3648616_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACDB RID: 175323 RVA: 0x00A6564B File Offset: 0x00A6384B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_A8E7C4D949B7290E417AA1BD8566E8D6()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_A8E7C4D949B7290E417AA1BD8566E8D6_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACDC RID: 175324 RVA: 0x00A6565F File Offset: 0x00A6385F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_7B48530442DBD2FC3212AA8D28AD1F09()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_7B48530442DBD2FC3212AA8D28AD1F09_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACDD RID: 175325 RVA: 0x00A65673 File Offset: 0x00A63873
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_9A443BC348501E8345779E8D58FCE275()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_9A443BC348501E8345779E8D58FCE275_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACDE RID: 175326 RVA: 0x00A65687 File Offset: 0x00A63887
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_4D3A50834C1D4A7382D044B79E9DD869()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_4D3A50834C1D4A7382D044B79E9DD869_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACDF RID: 175327 RVA: 0x00A6569B File Offset: 0x00A6389B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_7747F7174964FD29E00A4DA71A2E589E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_7747F7174964FD29E00A4DA71A2E589E_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACE0 RID: 175328 RVA: 0x00A656AF File Offset: 0x00A638AF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_BF4F3D8746771E512F5D61B457910BA3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_BF4F3D8746771E512F5D61B457910BA3_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACE1 RID: 175329 RVA: 0x00A656C3 File Offset: 0x00A638C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_8E2DD6A945D0BDC3026990A484866CA8()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_8E2DD6A945D0BDC3026990A484866CA8_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACE2 RID: 175330 RVA: 0x00A656D7 File Offset: 0x00A638D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_499314C8495841690B9E49BCB8E7C22D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_499314C8495841690B9E49BCB8E7C22D_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACE3 RID: 175331 RVA: 0x00A656EB File Offset: 0x00A638EB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_4AF2938C449D80F9C0461E8C73EE2FEB()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_4AF2938C449D80F9C0461E8C73EE2FEB_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACE4 RID: 175332 RVA: 0x00A656FF File Offset: 0x00A638FF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_DB14B4C343EC397E3FB42EB2A40B0141()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_DB14B4C343EC397E3FB42EB2A40B0141_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACE5 RID: 175333 RVA: 0x00A65713 File Offset: 0x00A63913
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_8C5202BF4A69202AB36633A3E97FEF65()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_8C5202BF4A69202AB36633A3E97FEF65_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACE6 RID: 175334 RVA: 0x00A65727 File Offset: 0x00A63927
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_926C049F4DA95F740F2F218C1BD85CFE()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_926C049F4DA95F740F2F218C1BD85CFE_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACE7 RID: 175335 RVA: 0x00A6573B File Offset: 0x00A6393B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_4801312C4D8DF468C46D1D93174EC9A4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_4801312C4D8DF468C46D1D93174EC9A4_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACE8 RID: 175336 RVA: 0x00A6574F File Offset: 0x00A6394F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_1F194F3F4BCE645F564A02968502F213()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_1F194F3F4BCE645F564A02968502F213_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACE9 RID: 175337 RVA: 0x00A65763 File Offset: 0x00A63963
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_EBADE6A34327B51501502FA7BE8E8384()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_EBADE6A34327B51501502FA7BE8E8384_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACEA RID: 175338 RVA: 0x00A65777 File Offset: 0x00A63977
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_887DB51B4F64690FB58CBB989A710857()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_887DB51B4F64690FB58CBB989A710857_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACEB RID: 175339 RVA: 0x00A6578B File Offset: 0x00A6398B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_9EA66DFA4EEE07582FBF74B5AFE66E59()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_9EA66DFA4EEE07582FBF74B5AFE66E59_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACEC RID: 175340 RVA: 0x00A6579F File Offset: 0x00A6399F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_ED171D964BA38FBCC0BA709BF3DB9C7D()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_ED171D964BA38FBCC0BA709BF3DB9C7D_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACED RID: 175341 RVA: 0x00A657B3 File Offset: 0x00A639B3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_D98BEBD74142CAB1B546FAB7CBF67B66()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_D98BEBD74142CAB1B546FAB7CBF67B66_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACEE RID: 175342 RVA: 0x00A657C7 File Offset: 0x00A639C7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_B583FF3940FA4F3BB8CF51BAF724CAFE()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_B583FF3940FA4F3BB8CF51BAF724CAFE_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACEF RID: 175343 RVA: 0x00A657DB File Offset: 0x00A639DB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_C9D4C5334F2636A49BD23087F037D0BA()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_C9D4C5334F2636A49BD23087F037D0BA_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACF0 RID: 175344 RVA: 0x00A657EF File Offset: 0x00A639EF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_3A865E1E47D9AE2EA9A7CF8BE52DDD3B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_3A865E1E47D9AE2EA9A7CF8BE52DDD3B_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACF1 RID: 175345 RVA: 0x00A65803 File Offset: 0x00A63A03
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_6C81EF6A498FF24335454C85689CB997()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_6C81EF6A498FF24335454C85689CB997_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACF2 RID: 175346 RVA: 0x00A65817 File Offset: 0x00A63A17
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_EAA2C8CD47CF5A338C60978DA53CE95C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_EAA2C8CD47CF5A338C60978DA53CE95C_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACF3 RID: 175347 RVA: 0x00A6582B File Offset: 0x00A63A2B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_DA6A1C044CE93463C5AE0A889D4D7B8A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_DA6A1C044CE93463C5AE0A889D4D7B8A_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACF4 RID: 175348 RVA: 0x00A6583F File Offset: 0x00A63A3F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_496EABA04159767BD3E823B7F2E4CD56()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_496EABA04159767BD3E823B7F2E4CD56_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACF5 RID: 175349 RVA: 0x00A65853 File Offset: 0x00A63A53
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_1FE3F7B34280D62B2B6341AE066E2665()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_1FE3F7B34280D62B2B6341AE066E2665_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACF6 RID: 175350 RVA: 0x00A65867 File Offset: 0x00A63A67
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_F10860ED46275A7B47A9F5897BA7D588()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_F10860ED46275A7B47A9F5897BA7D588_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACF7 RID: 175351 RVA: 0x00A6587B File Offset: 0x00A63A7B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_C31E814D4A96EFCE81E7A9AE1AE3A091()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_C31E814D4A96EFCE81E7A9AE1AE3A091_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACF8 RID: 175352 RVA: 0x00A6588F File Offset: 0x00A63A8F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_9AB8ED4140C26735C713399F8CCBBD24()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_9AB8ED4140C26735C713399F8CCBBD24_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACF9 RID: 175353 RVA: 0x00A658A4 File Offset: 0x00A63AA4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_BaseRole_Gameplay_Poker_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_Poker_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_Poker_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_Poker_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602ACFA RID: 175354 RVA: 0x00A658EC File Offset: 0x00A63AEC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_BaseRole_Gameplay_Poker_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_Poker_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_Poker_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_Poker_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602ACFB RID: 175355 RVA: 0x00A65933 File Offset: 0x00A63B33
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_进入猜鬼牌待机表演()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__AnimNotify_进入猜鬼牌待机表演_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACFC RID: 175356 RVA: 0x00A65947 File Offset: 0x00A63B47
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_离开获得牌高兴()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__AnimNotify_离开获得牌高兴_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACFD RID: 175357 RVA: 0x00A6595B File Offset: 0x00A63B5B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_离开获得牌难过()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__AnimNotify_离开获得牌难过_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACFE RID: 175358 RVA: 0x00A6596F File Offset: 0x00A63B6F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_离开被抽牌高兴()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__AnimNotify_离开被抽牌高兴_NativeFunctionPtr, null);
		}

		// Token: 0x0602ACFF RID: 175359 RVA: 0x00A65983 File Offset: 0x00A63B83
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_离开被抽牌难过()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__AnimNotify_离开被抽牌难过_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD00 RID: 175360 RVA: 0x00A65997 File Offset: 0x00A63B97
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_离开抽牌普通()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__AnimNotify_离开抽牌普通_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD01 RID: 175361 RVA: 0x00A659AB File Offset: 0x00A63BAB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_离开抽牌犹豫()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__AnimNotify_离开抽牌犹豫_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD02 RID: 175362 RVA: 0x00A659BF File Offset: 0x00A63BBF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_离开胜利()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__AnimNotify_离开胜利_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD03 RID: 175363 RVA: 0x00A659D3 File Offset: 0x00A63BD3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_离开失败()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__AnimNotify_离开失败_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD04 RID: 175364 RVA: 0x00A659E7 File Offset: 0x00A63BE7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_离开待机表演()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__AnimNotify_离开待机表演_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD05 RID: 175365 RVA: 0x00A659FB File Offset: 0x00A63BFB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_进入弱情绪表演Start1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__AnimNotify_进入弱情绪表演Start1_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD06 RID: 175366 RVA: 0x00A65A0F File Offset: 0x00A63C0F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_进入强情绪表演Start1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__AnimNotify_进入强情绪表演Start1_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD07 RID: 175367 RVA: 0x00A65A23 File Offset: 0x00A63C23
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_进入弱情绪表演Start2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__AnimNotify_进入弱情绪表演Start2_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD08 RID: 175368 RVA: 0x00A65A37 File Offset: 0x00A63C37
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_进入强情绪表演Start2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__AnimNotify_进入强情绪表演Start2_NativeFunctionPtr, null);
		}

		// Token: 0x0602AD09 RID: 175369 RVA: 0x00A65A4C File Offset: 0x00A63C4C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker(int EntryPoint)
		{
			ABP_BaseRole_Gameplay_Poker_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_Poker_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_FunctionParams[(UIntPtr)307] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_Poker_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_Poker_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRole_Gameplay_Poker_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AD0A RID: 175370 RVA: 0x00A65A96 File Offset: 0x00A63C96
		protected ABP_BaseRole_Gameplay_Poker_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017487 RID: 95367
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_Poker.ABP_BaseRole_Gameplay_Poker_C";

		// Token: 0x04017488 RID: 95368
		private static IntPtr _ClassPtr;

		// Token: 0x04017489 RID: 95369
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401748A RID: 95370
		internal static int __PropertyOffset_0;

		// Token: 0x0401748B RID: 95371
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401748C RID: 95372
		internal static int __PropertyOffset_1;

		// Token: 0x0401748D RID: 95373
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x0401748E RID: 95374
		internal static int __PropertyOffset_2;

		// Token: 0x0401748F RID: 95375
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_51;

		// Token: 0x04017490 RID: 95376
		internal static int __PropertyOffset_3;

		// Token: 0x04017491 RID: 95377
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_50;

		// Token: 0x04017492 RID: 95378
		internal static int __PropertyOffset_4;

		// Token: 0x04017493 RID: 95379
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_49;

		// Token: 0x04017494 RID: 95380
		internal static int __PropertyOffset_5;

		// Token: 0x04017495 RID: 95381
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_48;

		// Token: 0x04017496 RID: 95382
		internal static int __PropertyOffset_6;

		// Token: 0x04017497 RID: 95383
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_47;

		// Token: 0x04017498 RID: 95384
		internal static int __PropertyOffset_7;

		// Token: 0x04017499 RID: 95385
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_46;

		// Token: 0x0401749A RID: 95386
		internal static int __PropertyOffset_8;

		// Token: 0x0401749B RID: 95387
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_45;

		// Token: 0x0401749C RID: 95388
		internal static int __PropertyOffset_9;

		// Token: 0x0401749D RID: 95389
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_44;

		// Token: 0x0401749E RID: 95390
		internal static int __PropertyOffset_10;

		// Token: 0x0401749F RID: 95391
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_43;

		// Token: 0x040174A0 RID: 95392
		internal static int __PropertyOffset_11;

		// Token: 0x040174A1 RID: 95393
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_42;

		// Token: 0x040174A2 RID: 95394
		internal static int __PropertyOffset_12;

		// Token: 0x040174A3 RID: 95395
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_41;

		// Token: 0x040174A4 RID: 95396
		internal static int __PropertyOffset_13;

		// Token: 0x040174A5 RID: 95397
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_40;

		// Token: 0x040174A6 RID: 95398
		internal static int __PropertyOffset_14;

		// Token: 0x040174A7 RID: 95399
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_39;

		// Token: 0x040174A8 RID: 95400
		internal static int __PropertyOffset_15;

		// Token: 0x040174A9 RID: 95401
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_38;

		// Token: 0x040174AA RID: 95402
		internal static int __PropertyOffset_16;

		// Token: 0x040174AB RID: 95403
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_37;

		// Token: 0x040174AC RID: 95404
		internal static int __PropertyOffset_17;

		// Token: 0x040174AD RID: 95405
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_36;

		// Token: 0x040174AE RID: 95406
		internal static int __PropertyOffset_18;

		// Token: 0x040174AF RID: 95407
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_35;

		// Token: 0x040174B0 RID: 95408
		internal static int __PropertyOffset_19;

		// Token: 0x040174B1 RID: 95409
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_34;

		// Token: 0x040174B2 RID: 95410
		internal static int __PropertyOffset_20;

		// Token: 0x040174B3 RID: 95411
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_33;

		// Token: 0x040174B4 RID: 95412
		internal static int __PropertyOffset_21;

		// Token: 0x040174B5 RID: 95413
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_32;

		// Token: 0x040174B6 RID: 95414
		internal static int __PropertyOffset_22;

		// Token: 0x040174B7 RID: 95415
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_31;

		// Token: 0x040174B8 RID: 95416
		internal static int __PropertyOffset_23;

		// Token: 0x040174B9 RID: 95417
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_30;

		// Token: 0x040174BA RID: 95418
		internal static int __PropertyOffset_24;

		// Token: 0x040174BB RID: 95419
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_29;

		// Token: 0x040174BC RID: 95420
		internal static int __PropertyOffset_25;

		// Token: 0x040174BD RID: 95421
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_28;

		// Token: 0x040174BE RID: 95422
		internal static int __PropertyOffset_26;

		// Token: 0x040174BF RID: 95423
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_27;

		// Token: 0x040174C0 RID: 95424
		internal static int __PropertyOffset_27;

		// Token: 0x040174C1 RID: 95425
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_26;

		// Token: 0x040174C2 RID: 95426
		internal static int __PropertyOffset_28;

		// Token: 0x040174C3 RID: 95427
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_25;

		// Token: 0x040174C4 RID: 95428
		internal static int __PropertyOffset_29;

		// Token: 0x040174C5 RID: 95429
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_24;

		// Token: 0x040174C6 RID: 95430
		internal static int __PropertyOffset_30;

		// Token: 0x040174C7 RID: 95431
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_23;

		// Token: 0x040174C8 RID: 95432
		internal static int __PropertyOffset_31;

		// Token: 0x040174C9 RID: 95433
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_22;

		// Token: 0x040174CA RID: 95434
		internal static int __PropertyOffset_32;

		// Token: 0x040174CB RID: 95435
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_21;

		// Token: 0x040174CC RID: 95436
		internal static int __PropertyOffset_33;

		// Token: 0x040174CD RID: 95437
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_20;

		// Token: 0x040174CE RID: 95438
		internal static int __PropertyOffset_34;

		// Token: 0x040174CF RID: 95439
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_19;

		// Token: 0x040174D0 RID: 95440
		internal static int __PropertyOffset_35;

		// Token: 0x040174D1 RID: 95441
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_18;

		// Token: 0x040174D2 RID: 95442
		internal static int __PropertyOffset_36;

		// Token: 0x040174D3 RID: 95443
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_17;

		// Token: 0x040174D4 RID: 95444
		internal static int __PropertyOffset_37;

		// Token: 0x040174D5 RID: 95445
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_16;

		// Token: 0x040174D6 RID: 95446
		internal static int __PropertyOffset_38;

		// Token: 0x040174D7 RID: 95447
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_15;

		// Token: 0x040174D8 RID: 95448
		internal static int __PropertyOffset_39;

		// Token: 0x040174D9 RID: 95449
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_14;

		// Token: 0x040174DA RID: 95450
		internal static int __PropertyOffset_40;

		// Token: 0x040174DB RID: 95451
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_13;

		// Token: 0x040174DC RID: 95452
		internal static int __PropertyOffset_41;

		// Token: 0x040174DD RID: 95453
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_12;

		// Token: 0x040174DE RID: 95454
		internal static int __PropertyOffset_42;

		// Token: 0x040174DF RID: 95455
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_11;

		// Token: 0x040174E0 RID: 95456
		internal static int __PropertyOffset_43;

		// Token: 0x040174E1 RID: 95457
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_10;

		// Token: 0x040174E2 RID: 95458
		internal static int __PropertyOffset_44;

		// Token: 0x040174E3 RID: 95459
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_9;

		// Token: 0x040174E4 RID: 95460
		internal static int __PropertyOffset_45;

		// Token: 0x040174E5 RID: 95461
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_8;

		// Token: 0x040174E6 RID: 95462
		internal static int __PropertyOffset_46;

		// Token: 0x040174E7 RID: 95463
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_7;

		// Token: 0x040174E8 RID: 95464
		internal static int __PropertyOffset_47;

		// Token: 0x040174E9 RID: 95465
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_26;

		// Token: 0x040174EA RID: 95466
		internal static int __PropertyOffset_48;

		// Token: 0x040174EB RID: 95467
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_29;

		// Token: 0x040174EC RID: 95468
		internal static int __PropertyOffset_49;

		// Token: 0x040174ED RID: 95469
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_25;

		// Token: 0x040174EE RID: 95470
		internal static int __PropertyOffset_50;

		// Token: 0x040174EF RID: 95471
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_28;

		// Token: 0x040174F0 RID: 95472
		internal static int __PropertyOffset_51;

		// Token: 0x040174F1 RID: 95473
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_24;

		// Token: 0x040174F2 RID: 95474
		internal static int __PropertyOffset_52;

		// Token: 0x040174F3 RID: 95475
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_27;

		// Token: 0x040174F4 RID: 95476
		internal static int __PropertyOffset_53;

		// Token: 0x040174F5 RID: 95477
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_23;

		// Token: 0x040174F6 RID: 95478
		internal static int __PropertyOffset_54;

		// Token: 0x040174F7 RID: 95479
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_26;

		// Token: 0x040174F8 RID: 95480
		internal static int __PropertyOffset_55;

		// Token: 0x040174F9 RID: 95481
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_22;

		// Token: 0x040174FA RID: 95482
		internal static int __PropertyOffset_56;

		// Token: 0x040174FB RID: 95483
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_25;

		// Token: 0x040174FC RID: 95484
		internal static int __PropertyOffset_57;

		// Token: 0x040174FD RID: 95485
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_21;

		// Token: 0x040174FE RID: 95486
		internal static int __PropertyOffset_58;

		// Token: 0x040174FF RID: 95487
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_24;

		// Token: 0x04017500 RID: 95488
		internal static int __PropertyOffset_59;

		// Token: 0x04017501 RID: 95489
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_20;

		// Token: 0x04017502 RID: 95490
		internal static int __PropertyOffset_60;

		// Token: 0x04017503 RID: 95491
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_23;

		// Token: 0x04017504 RID: 95492
		internal static int __PropertyOffset_61;

		// Token: 0x04017505 RID: 95493
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_19;

		// Token: 0x04017506 RID: 95494
		internal static int __PropertyOffset_62;

		// Token: 0x04017507 RID: 95495
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_22;

		// Token: 0x04017508 RID: 95496
		internal static int __PropertyOffset_63;

		// Token: 0x04017509 RID: 95497
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_18;

		// Token: 0x0401750A RID: 95498
		internal static int __PropertyOffset_64;

		// Token: 0x0401750B RID: 95499
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_21;

		// Token: 0x0401750C RID: 95500
		internal static int __PropertyOffset_65;

		// Token: 0x0401750D RID: 95501
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_17;

		// Token: 0x0401750E RID: 95502
		internal static int __PropertyOffset_66;

		// Token: 0x0401750F RID: 95503
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_20;

		// Token: 0x04017510 RID: 95504
		internal static int __PropertyOffset_67;

		// Token: 0x04017511 RID: 95505
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_16;

		// Token: 0x04017512 RID: 95506
		internal static int __PropertyOffset_68;

		// Token: 0x04017513 RID: 95507
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_19;

		// Token: 0x04017514 RID: 95508
		internal static int __PropertyOffset_69;

		// Token: 0x04017515 RID: 95509
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_15;

		// Token: 0x04017516 RID: 95510
		internal static int __PropertyOffset_70;

		// Token: 0x04017517 RID: 95511
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_18;

		// Token: 0x04017518 RID: 95512
		internal static int __PropertyOffset_71;

		// Token: 0x04017519 RID: 95513
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_6;

		// Token: 0x0401751A RID: 95514
		internal static int __PropertyOffset_72;

		// Token: 0x0401751B RID: 95515
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_14;

		// Token: 0x0401751C RID: 95516
		internal static int __PropertyOffset_73;

		// Token: 0x0401751D RID: 95517
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_17;

		// Token: 0x0401751E RID: 95518
		internal static int __PropertyOffset_74;

		// Token: 0x0401751F RID: 95519
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_13;

		// Token: 0x04017520 RID: 95520
		internal static int __PropertyOffset_75;

		// Token: 0x04017521 RID: 95521
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_16;

		// Token: 0x04017522 RID: 95522
		internal static int __PropertyOffset_76;

		// Token: 0x04017523 RID: 95523
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_12;

		// Token: 0x04017524 RID: 95524
		internal static int __PropertyOffset_77;

		// Token: 0x04017525 RID: 95525
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_15;

		// Token: 0x04017526 RID: 95526
		internal static int __PropertyOffset_78;

		// Token: 0x04017527 RID: 95527
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_11;

		// Token: 0x04017528 RID: 95528
		internal static int __PropertyOffset_79;

		// Token: 0x04017529 RID: 95529
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_14;

		// Token: 0x0401752A RID: 95530
		internal static int __PropertyOffset_80;

		// Token: 0x0401752B RID: 95531
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_10;

		// Token: 0x0401752C RID: 95532
		internal static int __PropertyOffset_81;

		// Token: 0x0401752D RID: 95533
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_13;

		// Token: 0x0401752E RID: 95534
		internal static int __PropertyOffset_82;

		// Token: 0x0401752F RID: 95535
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_9;

		// Token: 0x04017530 RID: 95536
		internal static int __PropertyOffset_83;

		// Token: 0x04017531 RID: 95537
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_12;

		// Token: 0x04017532 RID: 95538
		internal static int __PropertyOffset_84;

		// Token: 0x04017533 RID: 95539
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_8;

		// Token: 0x04017534 RID: 95540
		internal static int __PropertyOffset_85;

		// Token: 0x04017535 RID: 95541
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_11;

		// Token: 0x04017536 RID: 95542
		internal static int __PropertyOffset_86;

		// Token: 0x04017537 RID: 95543
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_7;

		// Token: 0x04017538 RID: 95544
		internal static int __PropertyOffset_87;

		// Token: 0x04017539 RID: 95545
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_10;

		// Token: 0x0401753A RID: 95546
		internal static int __PropertyOffset_88;

		// Token: 0x0401753B RID: 95547
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_5;

		// Token: 0x0401753C RID: 95548
		internal static int __PropertyOffset_89;

		// Token: 0x0401753D RID: 95549
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_4;

		// Token: 0x0401753E RID: 95550
		internal static int __PropertyOffset_90;

		// Token: 0x0401753F RID: 95551
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_3;

		// Token: 0x04017540 RID: 95552
		internal static int __PropertyOffset_91;

		// Token: 0x04017541 RID: 95553
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_9;

		// Token: 0x04017542 RID: 95554
		internal static int __PropertyOffset_92;

		// Token: 0x04017543 RID: 95555
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_6;

		// Token: 0x04017544 RID: 95556
		internal static int __PropertyOffset_93;

		// Token: 0x04017545 RID: 95557
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_8;

		// Token: 0x04017546 RID: 95558
		internal static int __PropertyOffset_94;

		// Token: 0x04017547 RID: 95559
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_5;

		// Token: 0x04017548 RID: 95560
		internal static int __PropertyOffset_95;

		// Token: 0x04017549 RID: 95561
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_7;

		// Token: 0x0401754A RID: 95562
		internal static int __PropertyOffset_96;

		// Token: 0x0401754B RID: 95563
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_4;

		// Token: 0x0401754C RID: 95564
		internal static int __PropertyOffset_97;

		// Token: 0x0401754D RID: 95565
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_6;

		// Token: 0x0401754E RID: 95566
		internal static int __PropertyOffset_98;

		// Token: 0x0401754F RID: 95567
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_2;

		// Token: 0x04017550 RID: 95568
		internal static int __PropertyOffset_99;

		// Token: 0x04017551 RID: 95569
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_5;

		// Token: 0x04017552 RID: 95570
		internal static int __PropertyOffset_100;

		// Token: 0x04017553 RID: 95571
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x04017554 RID: 95572
		internal static int __PropertyOffset_101;

		// Token: 0x04017555 RID: 95573
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x04017556 RID: 95574
		internal static int __PropertyOffset_102;

		// Token: 0x04017557 RID: 95575
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x04017558 RID: 95576
		internal static int __PropertyOffset_103;

		// Token: 0x04017559 RID: 95577
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_3;

		// Token: 0x0401755A RID: 95578
		internal static int __PropertyOffset_104;

		// Token: 0x0401755B RID: 95579
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_4;

		// Token: 0x0401755C RID: 95580
		internal static int __PropertyOffset_105;

		// Token: 0x0401755D RID: 95581
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_2;

		// Token: 0x0401755E RID: 95582
		internal static int __PropertyOffset_106;

		// Token: 0x0401755F RID: 95583
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_3;

		// Token: 0x04017560 RID: 95584
		internal static int __PropertyOffset_107;

		// Token: 0x04017561 RID: 95585
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_1;

		// Token: 0x04017562 RID: 95586
		internal static int __PropertyOffset_108;

		// Token: 0x04017563 RID: 95587
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x04017564 RID: 95588
		internal static int __PropertyOffset_109;

		// Token: 0x04017565 RID: 95589
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04017566 RID: 95590
		internal static int __PropertyOffset_110;

		// Token: 0x04017567 RID: 95591
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x04017568 RID: 95592
		internal static int __PropertyOffset_111;

		// Token: 0x04017569 RID: 95593
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_1;

		// Token: 0x0401756A RID: 95594
		internal static int __PropertyOffset_112;

		// Token: 0x0401756B RID: 95595
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x0401756C RID: 95596
		internal static int __PropertyOffset_113;

		// Token: 0x0401756D RID: 95597
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x0401756E RID: 95598
		internal static int __PropertyOffset_114;

		// Token: 0x0401756F RID: 95599
		[Nullable(2)]
		private FAnimNode_CombineCurves _AnimGraphNode_CombineCurves;

		// Token: 0x04017570 RID: 95600
		internal static int __PropertyOffset_115;

		// Token: 0x04017571 RID: 95601
		internal static int __PropertyOffset_116;

		// Token: 0x04017572 RID: 95602
		internal static int __PropertyOffset_117;

		// Token: 0x04017573 RID: 95603
		internal static int __PropertyOffset_118;

		// Token: 0x04017574 RID: 95604
		internal static int __PropertyOffset_119;

		// Token: 0x04017575 RID: 95605
		internal static int __PropertyOffset_120;

		// Token: 0x04017576 RID: 95606
		internal static int __PropertyOffset_121;

		// Token: 0x04017577 RID: 95607
		internal static int __PropertyOffset_122;

		// Token: 0x04017578 RID: 95608
		internal static int __PropertyOffset_123;

		// Token: 0x04017579 RID: 95609
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x0401757A RID: 95610
		private static IntPtr __InitPerformanceTickTime_NativeFunctionPtr;

		// Token: 0x0401757B RID: 95611
		private static IntPtr __SetPlayerInteractiveStage_NativeFunctionPtr;

		// Token: 0x0401757C RID: 95612
		private static IntPtr __SetBeChooseEmotionIndex_NativeFunctionPtr;

		// Token: 0x0401757D RID: 95613
		private static IntPtr __ReturnIdel_NativeFunctionPtr;

		// Token: 0x0401757E RID: 95614
		private static IntPtr __SetPokerIdleState_NativeFunctionPtr;

		// Token: 0x0401757F RID: 95615
		private static IntPtr __SetPokerState_NativeFunctionPtr;

		// Token: 0x04017580 RID: 95616
		private static IntPtr __设置猜鬼牌表演倒计时_NativeFunctionPtr;

		// Token: 0x04017581 RID: 95617
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_B0C4264C477F9205671B229D72F82639_NativeFunctionPtr;

		// Token: 0x04017582 RID: 95618
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_22DE1A4C4E44B1104D60A4BF1F11DA28_NativeFunctionPtr;

		// Token: 0x04017583 RID: 95619
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_1A772CD743C7FC372EB67489E73C289E_NativeFunctionPtr;

		// Token: 0x04017584 RID: 95620
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_3A40E8754ADFC24EE0AF45B0C85BC41C_NativeFunctionPtr;

		// Token: 0x04017585 RID: 95621
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_F6EC2F8B4CCCB0E29BF88AB1173DD3ED_NativeFunctionPtr;

		// Token: 0x04017586 RID: 95622
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_666E367B41DAF09350BF73AABC60140E_NativeFunctionPtr;

		// Token: 0x04017587 RID: 95623
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_093778EF47276D0CF81ABEADE900AEB1_NativeFunctionPtr;

		// Token: 0x04017588 RID: 95624
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_5E39136C478670F29BD7E3B1B62D0F57_NativeFunctionPtr;

		// Token: 0x04017589 RID: 95625
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_F8E0F34B4FC5EF76DA95C7B116578734_NativeFunctionPtr;

		// Token: 0x0401758A RID: 95626
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_F94C0BF043DA97DBD5E647BFA2CD4DB1_NativeFunctionPtr;

		// Token: 0x0401758B RID: 95627
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_AC461C304B69A536250CCE8A3982A466_NativeFunctionPtr;

		// Token: 0x0401758C RID: 95628
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_9A24B50941EF191D85D7BCB0EF1FAC6F_NativeFunctionPtr;

		// Token: 0x0401758D RID: 95629
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_415A7B6B426DA35AE6422192B98E0EAF_NativeFunctionPtr;

		// Token: 0x0401758E RID: 95630
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_E1EC354344A3A58CD369EDB992E81F08_NativeFunctionPtr;

		// Token: 0x0401758F RID: 95631
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_5F0A7FFC4791AD211417B3AB0D494E5F_NativeFunctionPtr;

		// Token: 0x04017590 RID: 95632
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_37EF4BE94A4877A983454F9D706735EB_NativeFunctionPtr;

		// Token: 0x04017591 RID: 95633
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_960E2E2B40B6EE6B49C23EB99E6FEC9E_NativeFunctionPtr;

		// Token: 0x04017592 RID: 95634
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_0158D08F4E06F22B0A0442892892A5A2_NativeFunctionPtr;

		// Token: 0x04017593 RID: 95635
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_6F6373414A565BC8512F10AFA3648616_NativeFunctionPtr;

		// Token: 0x04017594 RID: 95636
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_A8E7C4D949B7290E417AA1BD8566E8D6_NativeFunctionPtr;

		// Token: 0x04017595 RID: 95637
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_7B48530442DBD2FC3212AA8D28AD1F09_NativeFunctionPtr;

		// Token: 0x04017596 RID: 95638
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_9A443BC348501E8345779E8D58FCE275_NativeFunctionPtr;

		// Token: 0x04017597 RID: 95639
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_4D3A50834C1D4A7382D044B79E9DD869_NativeFunctionPtr;

		// Token: 0x04017598 RID: 95640
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_7747F7174964FD29E00A4DA71A2E589E_NativeFunctionPtr;

		// Token: 0x04017599 RID: 95641
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_BF4F3D8746771E512F5D61B457910BA3_NativeFunctionPtr;

		// Token: 0x0401759A RID: 95642
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_8E2DD6A945D0BDC3026990A484866CA8_NativeFunctionPtr;

		// Token: 0x0401759B RID: 95643
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_499314C8495841690B9E49BCB8E7C22D_NativeFunctionPtr;

		// Token: 0x0401759C RID: 95644
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_4AF2938C449D80F9C0461E8C73EE2FEB_NativeFunctionPtr;

		// Token: 0x0401759D RID: 95645
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_DB14B4C343EC397E3FB42EB2A40B0141_NativeFunctionPtr;

		// Token: 0x0401759E RID: 95646
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_8C5202BF4A69202AB36633A3E97FEF65_NativeFunctionPtr;

		// Token: 0x0401759F RID: 95647
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_926C049F4DA95F740F2F218C1BD85CFE_NativeFunctionPtr;

		// Token: 0x040175A0 RID: 95648
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_4801312C4D8DF468C46D1D93174EC9A4_NativeFunctionPtr;

		// Token: 0x040175A1 RID: 95649
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_1F194F3F4BCE645F564A02968502F213_NativeFunctionPtr;

		// Token: 0x040175A2 RID: 95650
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_EBADE6A34327B51501502FA7BE8E8384_NativeFunctionPtr;

		// Token: 0x040175A3 RID: 95651
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_887DB51B4F64690FB58CBB989A710857_NativeFunctionPtr;

		// Token: 0x040175A4 RID: 95652
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_9EA66DFA4EEE07582FBF74B5AFE66E59_NativeFunctionPtr;

		// Token: 0x040175A5 RID: 95653
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_ED171D964BA38FBCC0BA709BF3DB9C7D_NativeFunctionPtr;

		// Token: 0x040175A6 RID: 95654
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_D98BEBD74142CAB1B546FAB7CBF67B66_NativeFunctionPtr;

		// Token: 0x040175A7 RID: 95655
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_B583FF3940FA4F3BB8CF51BAF724CAFE_NativeFunctionPtr;

		// Token: 0x040175A8 RID: 95656
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_C9D4C5334F2636A49BD23087F037D0BA_NativeFunctionPtr;

		// Token: 0x040175A9 RID: 95657
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_3A865E1E47D9AE2EA9A7CF8BE52DDD3B_NativeFunctionPtr;

		// Token: 0x040175AA RID: 95658
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_6C81EF6A498FF24335454C85689CB997_NativeFunctionPtr;

		// Token: 0x040175AB RID: 95659
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_EAA2C8CD47CF5A338C60978DA53CE95C_NativeFunctionPtr;

		// Token: 0x040175AC RID: 95660
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_DA6A1C044CE93463C5AE0A889D4D7B8A_NativeFunctionPtr;

		// Token: 0x040175AD RID: 95661
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_496EABA04159767BD3E823B7F2E4CD56_NativeFunctionPtr;

		// Token: 0x040175AE RID: 95662
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_1FE3F7B34280D62B2B6341AE066E2665_NativeFunctionPtr;

		// Token: 0x040175AF RID: 95663
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_F10860ED46275A7B47A9F5897BA7D588_NativeFunctionPtr;

		// Token: 0x040175B0 RID: 95664
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_C31E814D4A96EFCE81E7A9AE1AE3A091_NativeFunctionPtr;

		// Token: 0x040175B1 RID: 95665
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_AnimGraphNode_TransitionResult_9AB8ED4140C26735C713399F8CCBBD24_NativeFunctionPtr;

		// Token: 0x040175B2 RID: 95666
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x040175B3 RID: 95667
		private static IntPtr __AnimNotify_进入猜鬼牌待机表演_NativeFunctionPtr;

		// Token: 0x040175B4 RID: 95668
		private static IntPtr __AnimNotify_离开获得牌高兴_NativeFunctionPtr;

		// Token: 0x040175B5 RID: 95669
		private static IntPtr __AnimNotify_离开获得牌难过_NativeFunctionPtr;

		// Token: 0x040175B6 RID: 95670
		private static IntPtr __AnimNotify_离开被抽牌高兴_NativeFunctionPtr;

		// Token: 0x040175B7 RID: 95671
		private static IntPtr __AnimNotify_离开被抽牌难过_NativeFunctionPtr;

		// Token: 0x040175B8 RID: 95672
		private static IntPtr __AnimNotify_离开抽牌普通_NativeFunctionPtr;

		// Token: 0x040175B9 RID: 95673
		private static IntPtr __AnimNotify_离开抽牌犹豫_NativeFunctionPtr;

		// Token: 0x040175BA RID: 95674
		private static IntPtr __AnimNotify_离开胜利_NativeFunctionPtr;

		// Token: 0x040175BB RID: 95675
		private static IntPtr __AnimNotify_离开失败_NativeFunctionPtr;

		// Token: 0x040175BC RID: 95676
		private static IntPtr __AnimNotify_离开待机表演_NativeFunctionPtr;

		// Token: 0x040175BD RID: 95677
		private static IntPtr __AnimNotify_进入弱情绪表演Start1_NativeFunctionPtr;

		// Token: 0x040175BE RID: 95678
		private static IntPtr __AnimNotify_进入强情绪表演Start1_NativeFunctionPtr;

		// Token: 0x040175BF RID: 95679
		private static IntPtr __AnimNotify_进入弱情绪表演Start2_NativeFunctionPtr;

		// Token: 0x040175C0 RID: 95680
		private static IntPtr __AnimNotify_进入强情绪表演Start2_NativeFunctionPtr;

		// Token: 0x040175C1 RID: 95681
		private static IntPtr __ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_NativeFunctionPtr;

		// Token: 0x0200A25C RID: 41564
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04033006 RID: 208902
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A25D RID: 41565
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 3)]
		protected ref struct __SetPlayerInteractiveStage_FunctionParams
		{
			// Token: 0x04033007 RID: 208903
			[FieldOffset(0)]
			public bool isInteractive;
		}

		// Token: 0x0200A25E RID: 41566
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __SetBeChooseEmotionIndex_FunctionParams
		{
			// Token: 0x04033008 RID: 208904
			[FieldOffset(0)]
			public int index;
		}

		// Token: 0x0200A25F RID: 41567
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __SetPokerIdleState_FunctionParams
		{
			// Token: 0x04033009 RID: 208905
			[FieldOffset(0)]
			public TEnumAsByte<EPokerIdleState> IdleState;
		}

		// Token: 0x0200A260 RID: 41568
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 56)]
		protected ref struct __SetPokerState_FunctionParams
		{
			// Token: 0x0403300A RID: 208906
			[FieldOffset(0)]
			public TEnumAsByte<EPokerStateType> PokerState;
		}

		// Token: 0x0200A261 RID: 41569
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x0403300B RID: 208907
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A262 RID: 41570
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 292)]
		protected ref struct __ExecuteUbergraph_ABP_BaseRole_Gameplay_Poker_FunctionParams
		{
			// Token: 0x0403300C RID: 208908
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
