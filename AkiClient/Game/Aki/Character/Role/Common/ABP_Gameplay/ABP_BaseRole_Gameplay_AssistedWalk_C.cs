using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.ABP_Gameplay
{
	// Token: 0x0200406D RID: 16493
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_AssistedWalk.ABP_BaseRole_Gameplay_AssistedWalk_C")]
	[UnrealStructLayout(7824, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 7809)]
	public class ABP_BaseRole_Gameplay_AssistedWalk_C : UKuroAnimInstance, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602AB19 RID: 174873 RVA: 0x00A60BE8 File Offset: 0x00A5EDE8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_BaseRole_Gameplay_AssistedWalk_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_AssistedWalk.ABP_BaseRole_Gameplay_AssistedWalk_C");
			}
			return ABP_BaseRole_Gameplay_AssistedWalk_C._ClassPtr;
		}

		// Token: 0x0602AB1A RID: 174874 RVA: 0x00A60C0C File Offset: 0x00A5EE0C
		public ABP_BaseRole_Gameplay_AssistedWalk_C() : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRole_Gameplay_AssistedWalk_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602AB1B RID: 174875 RVA: 0x00A60C34 File Offset: 0x00A5EE34
		public ABP_BaseRole_Gameplay_AssistedWalk_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRole_Gameplay_AssistedWalk_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006EF5 RID: 28405
		// (get) Token: 0x0602AB1C RID: 174876 RVA: 0x00A60C68 File Offset: 0x00A5EE68
		// (set) Token: 0x0602AB1D RID: 174877 RVA: 0x00A60CA1 File Offset: 0x00A5EEA1
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006EF6 RID: 28406
		// (get) Token: 0x0602AB1E RID: 174878 RVA: 0x00A60CC4 File Offset: 0x00A5EEC4
		// (set) Token: 0x0602AB1F RID: 174879 RVA: 0x00A60CFD File Offset: 0x00A5EEFD
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006EF7 RID: 28407
		// (get) Token: 0x0602AB20 RID: 174880 RVA: 0x00A60D20 File Offset: 0x00A5EF20
		// (set) Token: 0x0602AB21 RID: 174881 RVA: 0x00A60D59 File Offset: 0x00A5EF59
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_15) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_15 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006EF8 RID: 28408
		// (get) Token: 0x0602AB22 RID: 174882 RVA: 0x00A60D7C File Offset: 0x00A5EF7C
		// (set) Token: 0x0602AB23 RID: 174883 RVA: 0x00A60DB5 File Offset: 0x00A5EFB5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_14) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_14 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006EF9 RID: 28409
		// (get) Token: 0x0602AB24 RID: 174884 RVA: 0x00A60DD8 File Offset: 0x00A5EFD8
		// (set) Token: 0x0602AB25 RID: 174885 RVA: 0x00A60E11 File Offset: 0x00A5F011
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_13) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_13 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006EFA RID: 28410
		// (get) Token: 0x0602AB26 RID: 174886 RVA: 0x00A60E34 File Offset: 0x00A5F034
		// (set) Token: 0x0602AB27 RID: 174887 RVA: 0x00A60E6D File Offset: 0x00A5F06D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_12) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_12 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006EFB RID: 28411
		// (get) Token: 0x0602AB28 RID: 174888 RVA: 0x00A60E90 File Offset: 0x00A5F090
		// (set) Token: 0x0602AB29 RID: 174889 RVA: 0x00A60EC9 File Offset: 0x00A5F0C9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_8) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_8 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006EFC RID: 28412
		// (get) Token: 0x0602AB2A RID: 174890 RVA: 0x00A60EEC File Offset: 0x00A5F0EC
		// (set) Token: 0x0602AB2B RID: 174891 RVA: 0x00A60F25 File Offset: 0x00A5F125
		public FAnimNode_StateResult AnimGraphNode_StateResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_12) == null)
				{
					result = (this._AnimGraphNode_StateResult_12 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006EFD RID: 28413
		// (get) Token: 0x0602AB2C RID: 174892 RVA: 0x00A60F48 File Offset: 0x00A5F148
		// (set) Token: 0x0602AB2D RID: 174893 RVA: 0x00A60F81 File Offset: 0x00A5F181
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_11) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_11 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006EFE RID: 28414
		// (get) Token: 0x0602AB2E RID: 174894 RVA: 0x00A60FA4 File Offset: 0x00A5F1A4
		// (set) Token: 0x0602AB2F RID: 174895 RVA: 0x00A60FDD File Offset: 0x00A5F1DD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_10) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_10 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006EFF RID: 28415
		// (get) Token: 0x0602AB30 RID: 174896 RVA: 0x00A61000 File Offset: 0x00A5F200
		// (set) Token: 0x0602AB31 RID: 174897 RVA: 0x00A61039 File Offset: 0x00A5F239
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_9) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_9 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F00 RID: 28416
		// (get) Token: 0x0602AB32 RID: 174898 RVA: 0x00A6105C File Offset: 0x00A5F25C
		// (set) Token: 0x0602AB33 RID: 174899 RVA: 0x00A61095 File Offset: 0x00A5F295
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_8) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_8 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F01 RID: 28417
		// (get) Token: 0x0602AB34 RID: 174900 RVA: 0x00A610B8 File Offset: 0x00A5F2B8
		// (set) Token: 0x0602AB35 RID: 174901 RVA: 0x00A610F1 File Offset: 0x00A5F2F1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_7) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_7 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F02 RID: 28418
		// (get) Token: 0x0602AB36 RID: 174902 RVA: 0x00A61114 File Offset: 0x00A5F314
		// (set) Token: 0x0602AB37 RID: 174903 RVA: 0x00A6114D File Offset: 0x00A5F34D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_6) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_6 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F03 RID: 28419
		// (get) Token: 0x0602AB38 RID: 174904 RVA: 0x00A61170 File Offset: 0x00A5F370
		// (set) Token: 0x0602AB39 RID: 174905 RVA: 0x00A611A9 File Offset: 0x00A5F3A9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_7) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_7 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F04 RID: 28420
		// (get) Token: 0x0602AB3A RID: 174906 RVA: 0x00A611CC File Offset: 0x00A5F3CC
		// (set) Token: 0x0602AB3B RID: 174907 RVA: 0x00A61205 File Offset: 0x00A5F405
		public FAnimNode_StateResult AnimGraphNode_StateResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_11) == null)
				{
					result = (this._AnimGraphNode_StateResult_11 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F05 RID: 28421
		// (get) Token: 0x0602AB3C RID: 174908 RVA: 0x00A61228 File Offset: 0x00A5F428
		// (set) Token: 0x0602AB3D RID: 174909 RVA: 0x00A61261 File Offset: 0x00A5F461
		public FAnimNode_SequenceSyncMarkerPlayer AnimGraphNode_SequenceSyncMarkerPlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequenceSyncMarkerPlayer result;
				if ((result = this._AnimGraphNode_SequenceSyncMarkerPlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequenceSyncMarkerPlayer_1 = new FAnimNode_SequenceSyncMarkerPlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequenceSyncMarkerPlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F06 RID: 28422
		// (get) Token: 0x0602AB3E RID: 174910 RVA: 0x00A61284 File Offset: 0x00A5F484
		// (set) Token: 0x0602AB3F RID: 174911 RVA: 0x00A612BD File Offset: 0x00A5F4BD
		public FAnimNode_StateResult AnimGraphNode_StateResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_10) == null)
				{
					result = (this._AnimGraphNode_StateResult_10 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F07 RID: 28423
		// (get) Token: 0x0602AB40 RID: 174912 RVA: 0x00A612E0 File Offset: 0x00A5F4E0
		// (set) Token: 0x0602AB41 RID: 174913 RVA: 0x00A61319 File Offset: 0x00A5F519
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_6) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_6 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F08 RID: 28424
		// (get) Token: 0x0602AB42 RID: 174914 RVA: 0x00A6133C File Offset: 0x00A5F53C
		// (set) Token: 0x0602AB43 RID: 174915 RVA: 0x00A61375 File Offset: 0x00A5F575
		public FAnimNode_StateResult AnimGraphNode_StateResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_9) == null)
				{
					result = (this._AnimGraphNode_StateResult_9 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F09 RID: 28425
		// (get) Token: 0x0602AB44 RID: 174916 RVA: 0x00A61398 File Offset: 0x00A5F598
		// (set) Token: 0x0602AB45 RID: 174917 RVA: 0x00A613D1 File Offset: 0x00A5F5D1
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_5) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_5 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F0A RID: 28426
		// (get) Token: 0x0602AB46 RID: 174918 RVA: 0x00A613F4 File Offset: 0x00A5F5F4
		// (set) Token: 0x0602AB47 RID: 174919 RVA: 0x00A6142D File Offset: 0x00A5F62D
		public FAnimNode_StateResult AnimGraphNode_StateResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_8) == null)
				{
					result = (this._AnimGraphNode_StateResult_8 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F0B RID: 28427
		// (get) Token: 0x0602AB48 RID: 174920 RVA: 0x00A61450 File Offset: 0x00A5F650
		// (set) Token: 0x0602AB49 RID: 174921 RVA: 0x00A61489 File Offset: 0x00A5F689
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_4) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_4 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F0C RID: 28428
		// (get) Token: 0x0602AB4A RID: 174922 RVA: 0x00A614AC File Offset: 0x00A5F6AC
		// (set) Token: 0x0602AB4B RID: 174923 RVA: 0x00A614E5 File Offset: 0x00A5F6E5
		public FAnimNode_StateResult AnimGraphNode_StateResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_7) == null)
				{
					result = (this._AnimGraphNode_StateResult_7 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F0D RID: 28429
		// (get) Token: 0x0602AB4C RID: 174924 RVA: 0x00A61508 File Offset: 0x00A5F708
		// (set) Token: 0x0602AB4D RID: 174925 RVA: 0x00A61541 File Offset: 0x00A5F741
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_2) == null)
				{
					result = (this._AnimGraphNode_StateMachine_2 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_24, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F0E RID: 28430
		// (get) Token: 0x0602AB4E RID: 174926 RVA: 0x00A61564 File Offset: 0x00A5F764
		// (set) Token: 0x0602AB4F RID: 174927 RVA: 0x00A6159D File Offset: 0x00A5F79D
		public FAnimNode_StateResult AnimGraphNode_StateResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_6) == null)
				{
					result = (this._AnimGraphNode_StateResult_6 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F0F RID: 28431
		// (get) Token: 0x0602AB50 RID: 174928 RVA: 0x00A615C0 File Offset: 0x00A5F7C0
		// (set) Token: 0x0602AB51 RID: 174929 RVA: 0x00A615F9 File Offset: 0x00A5F7F9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_5) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_5 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_26, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F10 RID: 28432
		// (get) Token: 0x0602AB52 RID: 174930 RVA: 0x00A6161C File Offset: 0x00A5F81C
		// (set) Token: 0x0602AB53 RID: 174931 RVA: 0x00A61655 File Offset: 0x00A5F855
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_4) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_4 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_27, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F11 RID: 28433
		// (get) Token: 0x0602AB54 RID: 174932 RVA: 0x00A61678 File Offset: 0x00A5F878
		// (set) Token: 0x0602AB55 RID: 174933 RVA: 0x00A616B1 File Offset: 0x00A5F8B1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_3 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_28, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F12 RID: 28434
		// (get) Token: 0x0602AB56 RID: 174934 RVA: 0x00A616D4 File Offset: 0x00A5F8D4
		// (set) Token: 0x0602AB57 RID: 174935 RVA: 0x00A6170D File Offset: 0x00A5F90D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_29, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F13 RID: 28435
		// (get) Token: 0x0602AB58 RID: 174936 RVA: 0x00A61730 File Offset: 0x00A5F930
		// (set) Token: 0x0602AB59 RID: 174937 RVA: 0x00A61769 File Offset: 0x00A5F969
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_30, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F14 RID: 28436
		// (get) Token: 0x0602AB5A RID: 174938 RVA: 0x00A6178C File Offset: 0x00A5F98C
		// (set) Token: 0x0602AB5B RID: 174939 RVA: 0x00A617C5 File Offset: 0x00A5F9C5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_31, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F15 RID: 28437
		// (get) Token: 0x0602AB5C RID: 174940 RVA: 0x00A617E8 File Offset: 0x00A5F9E8
		// (set) Token: 0x0602AB5D RID: 174941 RVA: 0x00A61821 File Offset: 0x00A5FA21
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_3) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_3 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_32, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F16 RID: 28438
		// (get) Token: 0x0602AB5E RID: 174942 RVA: 0x00A61844 File Offset: 0x00A5FA44
		// (set) Token: 0x0602AB5F RID: 174943 RVA: 0x00A6187D File Offset: 0x00A5FA7D
		public FAnimNode_StateResult AnimGraphNode_StateResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_5) == null)
				{
					result = (this._AnimGraphNode_StateResult_5 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_33, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F17 RID: 28439
		// (get) Token: 0x0602AB60 RID: 174944 RVA: 0x00A618A0 File Offset: 0x00A5FAA0
		// (set) Token: 0x0602AB61 RID: 174945 RVA: 0x00A618D9 File Offset: 0x00A5FAD9
		public FAnimNode_SequenceSyncMarkerPlayer AnimGraphNode_SequenceSyncMarkerPlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequenceSyncMarkerPlayer result;
				if ((result = this._AnimGraphNode_SequenceSyncMarkerPlayer) == null)
				{
					result = (this._AnimGraphNode_SequenceSyncMarkerPlayer = new FAnimNode_SequenceSyncMarkerPlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequenceSyncMarkerPlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F18 RID: 28440
		// (get) Token: 0x0602AB62 RID: 174946 RVA: 0x00A618FC File Offset: 0x00A5FAFC
		// (set) Token: 0x0602AB63 RID: 174947 RVA: 0x00A61935 File Offset: 0x00A5FB35
		public FAnimNode_StateResult AnimGraphNode_StateResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_4) == null)
				{
					result = (this._AnimGraphNode_StateResult_4 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_35, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F19 RID: 28441
		// (get) Token: 0x0602AB64 RID: 174948 RVA: 0x00A61958 File Offset: 0x00A5FB58
		// (set) Token: 0x0602AB65 RID: 174949 RVA: 0x00A61991 File Offset: 0x00A5FB91
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_2) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_2 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_36, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_36, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F1A RID: 28442
		// (get) Token: 0x0602AB66 RID: 174950 RVA: 0x00A619B4 File Offset: 0x00A5FBB4
		// (set) Token: 0x0602AB67 RID: 174951 RVA: 0x00A619ED File Offset: 0x00A5FBED
		public FAnimNode_StateResult AnimGraphNode_StateResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_3) == null)
				{
					result = (this._AnimGraphNode_StateResult_3 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_37, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F1B RID: 28443
		// (get) Token: 0x0602AB68 RID: 174952 RVA: 0x00A61A10 File Offset: 0x00A5FC10
		// (set) Token: 0x0602AB69 RID: 174953 RVA: 0x00A61A49 File Offset: 0x00A5FC49
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_1 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_38, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F1C RID: 28444
		// (get) Token: 0x0602AB6A RID: 174954 RVA: 0x00A61A6C File Offset: 0x00A5FC6C
		// (set) Token: 0x0602AB6B RID: 174955 RVA: 0x00A61AA5 File Offset: 0x00A5FCA5
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_39, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_39, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F1D RID: 28445
		// (get) Token: 0x0602AB6C RID: 174956 RVA: 0x00A61AC8 File Offset: 0x00A5FCC8
		// (set) Token: 0x0602AB6D RID: 174957 RVA: 0x00A61B01 File Offset: 0x00A5FD01
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_40, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_40, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F1E RID: 28446
		// (get) Token: 0x0602AB6E RID: 174958 RVA: 0x00A61B24 File Offset: 0x00A5FD24
		// (set) Token: 0x0602AB6F RID: 174959 RVA: 0x00A61B5D File Offset: 0x00A5FD5D
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_41, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_41, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F1F RID: 28447
		// (get) Token: 0x0602AB70 RID: 174960 RVA: 0x00A61B80 File Offset: 0x00A5FD80
		// (set) Token: 0x0602AB71 RID: 174961 RVA: 0x00A61BB9 File Offset: 0x00A5FDB9
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_1) == null)
				{
					result = (this._AnimGraphNode_StateMachine_1 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_42, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_42, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F20 RID: 28448
		// (get) Token: 0x0602AB72 RID: 174962 RVA: 0x00A61BDC File Offset: 0x00A5FDDC
		// (set) Token: 0x0602AB73 RID: 174963 RVA: 0x00A61C15 File Offset: 0x00A5FE15
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_43, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_43, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F21 RID: 28449
		// (get) Token: 0x0602AB74 RID: 174964 RVA: 0x00A61C38 File Offset: 0x00A5FE38
		// (set) Token: 0x0602AB75 RID: 174965 RVA: 0x00A61C71 File Offset: 0x00A5FE71
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_44, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_44, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006F22 RID: 28450
		// (get) Token: 0x0602AB76 RID: 174966 RVA: 0x00A61C92 File Offset: 0x00A5FE92
		// (set) Token: 0x0602AB77 RID: 174967 RVA: 0x00A61CA6 File Offset: 0x00A5FEA6
		[Nullable(2)]
		public unsafe TsBaseCharacter As_Ts_Base_Character
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_45);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_45, value);
			}
		}

		// Token: 0x17006F23 RID: 28451
		// (get) Token: 0x0602AB78 RID: 174968 RVA: 0x00A61CBB File Offset: 0x00A5FEBB
		// (set) Token: 0x0602AB79 RID: 174969 RVA: 0x00A61CCF File Offset: 0x00A5FECF
		[Nullable(2)]
		public unsafe UKuroAnimInstanceChar As_Kuro_Anim_Instance_Char
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroAnimInstanceChar>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_46);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_46, value);
			}
		}

		// Token: 0x17006F24 RID: 28452
		// (get) Token: 0x0602AB7A RID: 174970 RVA: 0x00A61CE4 File Offset: 0x00A5FEE4
		// (set) Token: 0x0602AB7B RID: 174971 RVA: 0x00A61CF4 File Offset: 0x00A5FEF4
		public unsafe bool IsStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_47) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRole_Gameplay_AssistedWalk_C.__PropertyOffset_47) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602AB7C RID: 174972 RVA: 0x00A61D08 File Offset: 0x00A5FF08
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_BaseRole_Gameplay_AssistedWalk_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_AssistedWalk_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_AssistedWalk_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_AssistedWalk_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602AB7D RID: 174973 RVA: 0x00A61D8F File Offset: 0x00A5FF8F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_SequencePlayer_5A2F90F945ADD0C454F3A3B96B8CF817()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_SequencePlayer_5A2F90F945ADD0C454F3A3B96B8CF817_NativeFunctionPtr, null);
		}

		// Token: 0x0602AB7E RID: 174974 RVA: 0x00A61DA3 File Offset: 0x00A5FFA3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_5B2C80434B7C6D59D1A1A19FA4DF6A5B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_5B2C80434B7C6D59D1A1A19FA4DF6A5B_NativeFunctionPtr, null);
		}

		// Token: 0x0602AB7F RID: 174975 RVA: 0x00A61DB7 File Offset: 0x00A5FFB7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_A830A22141DE76A5B7227DA1495241E3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_A830A22141DE76A5B7227DA1495241E3_NativeFunctionPtr, null);
		}

		// Token: 0x0602AB80 RID: 174976 RVA: 0x00A61DCB File Offset: 0x00A5FFCB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_737CED7649F6856AFE2400B409A29ECC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_737CED7649F6856AFE2400B409A29ECC_NativeFunctionPtr, null);
		}

		// Token: 0x0602AB81 RID: 174977 RVA: 0x00A61DDF File Offset: 0x00A5FFDF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_21D5CBCA49935C0C91FEFD97316693F3()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_21D5CBCA49935C0C91FEFD97316693F3_NativeFunctionPtr, null);
		}

		// Token: 0x0602AB82 RID: 174978 RVA: 0x00A61DF3 File Offset: 0x00A5FFF3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_0F20CFCE446B7348A22790BB56005820()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_0F20CFCE446B7348A22790BB56005820_NativeFunctionPtr, null);
		}

		// Token: 0x0602AB83 RID: 174979 RVA: 0x00A61E07 File Offset: 0x00A60007
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_A88BEC154AC04A441625129A5F2D079E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_A88BEC154AC04A441625129A5F2D079E_NativeFunctionPtr, null);
		}

		// Token: 0x0602AB84 RID: 174980 RVA: 0x00A61E1B File Offset: 0x00A6001B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_2B5BA779449AE4E79DF0F28D480E1480()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_2B5BA779449AE4E79DF0F28D480E1480_NativeFunctionPtr, null);
		}

		// Token: 0x0602AB85 RID: 174981 RVA: 0x00A61E2F File Offset: 0x00A6002F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_08FD9FC041089C85833182B02EAED8E8()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_08FD9FC041089C85833182B02EAED8E8_NativeFunctionPtr, null);
		}

		// Token: 0x0602AB86 RID: 174982 RVA: 0x00A61E43 File Offset: 0x00A60043
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_566D4BEE49A252BF7A0118864D319F2E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_566D4BEE49A252BF7A0118864D319F2E_NativeFunctionPtr, null);
		}

		// Token: 0x0602AB87 RID: 174983 RVA: 0x00A61E57 File Offset: 0x00A60057
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_EEE10CA14239FB535E1C84A722ED8212()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_EEE10CA14239FB535E1C84A722ED8212_NativeFunctionPtr, null);
		}

		// Token: 0x0602AB88 RID: 174984 RVA: 0x00A61E6B File Offset: 0x00A6006B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_1EFDE95C40450146605AC684F7A2F199()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_1EFDE95C40450146605AC684F7A2F199_NativeFunctionPtr, null);
		}

		// Token: 0x0602AB89 RID: 174985 RVA: 0x00A61E7F File Offset: 0x00A6007F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_FA972E944D5953447C60AEB0B8B8008E()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_FA972E944D5953447C60AEB0B8B8008E_NativeFunctionPtr, null);
		}

		// Token: 0x0602AB8A RID: 174986 RVA: 0x00A61E93 File Offset: 0x00A60093
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_1055F3234D2ADCD3704F1381F084E765()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_1055F3234D2ADCD3704F1381F084E765_NativeFunctionPtr, null);
		}

		// Token: 0x0602AB8B RID: 174987 RVA: 0x00A61EA7 File Offset: 0x00A600A7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x0602AB8C RID: 174988 RVA: 0x00A61EBB File Offset: 0x00A600BB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602AB8D RID: 174989 RVA: 0x00A61ED0 File Offset: 0x00A600D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_进入搀扶移动()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__AnimNotify_进入搀扶移动_NativeFunctionPtr, null);
		}

		// Token: 0x0602AB8E RID: 174990 RVA: 0x00A61EE4 File Offset: 0x00A600E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_退出搀扶移动()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__AnimNotify_退出搀扶移动_NativeFunctionPtr, null);
		}

		// Token: 0x0602AB8F RID: 174991 RVA: 0x00A61EF8 File Offset: 0x00A600F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_进入搀扶站立()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__AnimNotify_进入搀扶站立_NativeFunctionPtr, null);
		}

		// Token: 0x0602AB90 RID: 174992 RVA: 0x00A61F0C File Offset: 0x00A6010C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_开始搀扶()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__AnimNotify_开始搀扶_NativeFunctionPtr, null);
		}

		// Token: 0x0602AB91 RID: 174993 RVA: 0x00A61F20 File Offset: 0x00A60120
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk(int EntryPoint)
		{
			ABP_BaseRole_Gameplay_AssistedWalk_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_FunctionParams* ptr = stackalloc ABP_BaseRole_Gameplay_AssistedWalk_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_FunctionParams[(UIntPtr)207] + 15L / (long)sizeof(ABP_BaseRole_Gameplay_AssistedWalk_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRole_Gameplay_AssistedWalk_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRole_Gameplay_AssistedWalk_C.__ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602AB92 RID: 174994 RVA: 0x00A61F6A File Offset: 0x00A6016A
		protected ABP_BaseRole_Gameplay_AssistedWalk_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040173E8 RID: 95208
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/ABP_Gameplay/ABP_BaseRole_Gameplay_AssistedWalk.ABP_BaseRole_Gameplay_AssistedWalk_C";

		// Token: 0x040173E9 RID: 95209
		private static IntPtr _ClassPtr;

		// Token: 0x040173EA RID: 95210
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040173EB RID: 95211
		internal static int __PropertyOffset_0;

		// Token: 0x040173EC RID: 95212
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040173ED RID: 95213
		internal static int __PropertyOffset_1;

		// Token: 0x040173EE RID: 95214
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x040173EF RID: 95215
		internal static int __PropertyOffset_2;

		// Token: 0x040173F0 RID: 95216
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_15;

		// Token: 0x040173F1 RID: 95217
		internal static int __PropertyOffset_3;

		// Token: 0x040173F2 RID: 95218
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_14;

		// Token: 0x040173F3 RID: 95219
		internal static int __PropertyOffset_4;

		// Token: 0x040173F4 RID: 95220
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_13;

		// Token: 0x040173F5 RID: 95221
		internal static int __PropertyOffset_5;

		// Token: 0x040173F6 RID: 95222
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_12;

		// Token: 0x040173F7 RID: 95223
		internal static int __PropertyOffset_6;

		// Token: 0x040173F8 RID: 95224
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_8;

		// Token: 0x040173F9 RID: 95225
		internal static int __PropertyOffset_7;

		// Token: 0x040173FA RID: 95226
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_12;

		// Token: 0x040173FB RID: 95227
		internal static int __PropertyOffset_8;

		// Token: 0x040173FC RID: 95228
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_11;

		// Token: 0x040173FD RID: 95229
		internal static int __PropertyOffset_9;

		// Token: 0x040173FE RID: 95230
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_10;

		// Token: 0x040173FF RID: 95231
		internal static int __PropertyOffset_10;

		// Token: 0x04017400 RID: 95232
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_9;

		// Token: 0x04017401 RID: 95233
		internal static int __PropertyOffset_11;

		// Token: 0x04017402 RID: 95234
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_8;

		// Token: 0x04017403 RID: 95235
		internal static int __PropertyOffset_12;

		// Token: 0x04017404 RID: 95236
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_7;

		// Token: 0x04017405 RID: 95237
		internal static int __PropertyOffset_13;

		// Token: 0x04017406 RID: 95238
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_6;

		// Token: 0x04017407 RID: 95239
		internal static int __PropertyOffset_14;

		// Token: 0x04017408 RID: 95240
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_7;

		// Token: 0x04017409 RID: 95241
		internal static int __PropertyOffset_15;

		// Token: 0x0401740A RID: 95242
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_11;

		// Token: 0x0401740B RID: 95243
		internal static int __PropertyOffset_16;

		// Token: 0x0401740C RID: 95244
		[Nullable(2)]
		private FAnimNode_SequenceSyncMarkerPlayer _AnimGraphNode_SequenceSyncMarkerPlayer_1;

		// Token: 0x0401740D RID: 95245
		internal static int __PropertyOffset_17;

		// Token: 0x0401740E RID: 95246
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_10;

		// Token: 0x0401740F RID: 95247
		internal static int __PropertyOffset_18;

		// Token: 0x04017410 RID: 95248
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_6;

		// Token: 0x04017411 RID: 95249
		internal static int __PropertyOffset_19;

		// Token: 0x04017412 RID: 95250
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_9;

		// Token: 0x04017413 RID: 95251
		internal static int __PropertyOffset_20;

		// Token: 0x04017414 RID: 95252
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_5;

		// Token: 0x04017415 RID: 95253
		internal static int __PropertyOffset_21;

		// Token: 0x04017416 RID: 95254
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_8;

		// Token: 0x04017417 RID: 95255
		internal static int __PropertyOffset_22;

		// Token: 0x04017418 RID: 95256
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_4;

		// Token: 0x04017419 RID: 95257
		internal static int __PropertyOffset_23;

		// Token: 0x0401741A RID: 95258
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_7;

		// Token: 0x0401741B RID: 95259
		internal static int __PropertyOffset_24;

		// Token: 0x0401741C RID: 95260
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_2;

		// Token: 0x0401741D RID: 95261
		internal static int __PropertyOffset_25;

		// Token: 0x0401741E RID: 95262
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_6;

		// Token: 0x0401741F RID: 95263
		internal static int __PropertyOffset_26;

		// Token: 0x04017420 RID: 95264
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_5;

		// Token: 0x04017421 RID: 95265
		internal static int __PropertyOffset_27;

		// Token: 0x04017422 RID: 95266
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_4;

		// Token: 0x04017423 RID: 95267
		internal static int __PropertyOffset_28;

		// Token: 0x04017424 RID: 95268
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_3;

		// Token: 0x04017425 RID: 95269
		internal static int __PropertyOffset_29;

		// Token: 0x04017426 RID: 95270
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x04017427 RID: 95271
		internal static int __PropertyOffset_30;

		// Token: 0x04017428 RID: 95272
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x04017429 RID: 95273
		internal static int __PropertyOffset_31;

		// Token: 0x0401742A RID: 95274
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x0401742B RID: 95275
		internal static int __PropertyOffset_32;

		// Token: 0x0401742C RID: 95276
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_3;

		// Token: 0x0401742D RID: 95277
		internal static int __PropertyOffset_33;

		// Token: 0x0401742E RID: 95278
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_5;

		// Token: 0x0401742F RID: 95279
		internal static int __PropertyOffset_34;

		// Token: 0x04017430 RID: 95280
		[Nullable(2)]
		private FAnimNode_SequenceSyncMarkerPlayer _AnimGraphNode_SequenceSyncMarkerPlayer;

		// Token: 0x04017431 RID: 95281
		internal static int __PropertyOffset_35;

		// Token: 0x04017432 RID: 95282
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_4;

		// Token: 0x04017433 RID: 95283
		internal static int __PropertyOffset_36;

		// Token: 0x04017434 RID: 95284
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_2;

		// Token: 0x04017435 RID: 95285
		internal static int __PropertyOffset_37;

		// Token: 0x04017436 RID: 95286
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_3;

		// Token: 0x04017437 RID: 95287
		internal static int __PropertyOffset_38;

		// Token: 0x04017438 RID: 95288
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_1;

		// Token: 0x04017439 RID: 95289
		internal static int __PropertyOffset_39;

		// Token: 0x0401743A RID: 95290
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x0401743B RID: 95291
		internal static int __PropertyOffset_40;

		// Token: 0x0401743C RID: 95292
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x0401743D RID: 95293
		internal static int __PropertyOffset_41;

		// Token: 0x0401743E RID: 95294
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x0401743F RID: 95295
		internal static int __PropertyOffset_42;

		// Token: 0x04017440 RID: 95296
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_1;

		// Token: 0x04017441 RID: 95297
		internal static int __PropertyOffset_43;

		// Token: 0x04017442 RID: 95298
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x04017443 RID: 95299
		internal static int __PropertyOffset_44;

		// Token: 0x04017444 RID: 95300
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x04017445 RID: 95301
		internal static int __PropertyOffset_45;

		// Token: 0x04017446 RID: 95302
		internal static int __PropertyOffset_46;

		// Token: 0x04017447 RID: 95303
		internal static int __PropertyOffset_47;

		// Token: 0x04017448 RID: 95304
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04017449 RID: 95305
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_SequencePlayer_5A2F90F945ADD0C454F3A3B96B8CF817_NativeFunctionPtr;

		// Token: 0x0401744A RID: 95306
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_5B2C80434B7C6D59D1A1A19FA4DF6A5B_NativeFunctionPtr;

		// Token: 0x0401744B RID: 95307
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_A830A22141DE76A5B7227DA1495241E3_NativeFunctionPtr;

		// Token: 0x0401744C RID: 95308
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_737CED7649F6856AFE2400B409A29ECC_NativeFunctionPtr;

		// Token: 0x0401744D RID: 95309
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_21D5CBCA49935C0C91FEFD97316693F3_NativeFunctionPtr;

		// Token: 0x0401744E RID: 95310
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_0F20CFCE446B7348A22790BB56005820_NativeFunctionPtr;

		// Token: 0x0401744F RID: 95311
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_A88BEC154AC04A441625129A5F2D079E_NativeFunctionPtr;

		// Token: 0x04017450 RID: 95312
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_2B5BA779449AE4E79DF0F28D480E1480_NativeFunctionPtr;

		// Token: 0x04017451 RID: 95313
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_08FD9FC041089C85833182B02EAED8E8_NativeFunctionPtr;

		// Token: 0x04017452 RID: 95314
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_566D4BEE49A252BF7A0118864D319F2E_NativeFunctionPtr;

		// Token: 0x04017453 RID: 95315
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_EEE10CA14239FB535E1C84A722ED8212_NativeFunctionPtr;

		// Token: 0x04017454 RID: 95316
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_1EFDE95C40450146605AC684F7A2F199_NativeFunctionPtr;

		// Token: 0x04017455 RID: 95317
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_FA972E944D5953447C60AEB0B8B8008E_NativeFunctionPtr;

		// Token: 0x04017456 RID: 95318
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_AnimGraphNode_TransitionResult_1055F3234D2ADCD3704F1381F084E765_NativeFunctionPtr;

		// Token: 0x04017457 RID: 95319
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x04017458 RID: 95320
		private static IntPtr __AnimNotify_进入搀扶移动_NativeFunctionPtr;

		// Token: 0x04017459 RID: 95321
		private static IntPtr __AnimNotify_退出搀扶移动_NativeFunctionPtr;

		// Token: 0x0401745A RID: 95322
		private static IntPtr __AnimNotify_进入搀扶站立_NativeFunctionPtr;

		// Token: 0x0401745B RID: 95323
		private static IntPtr __AnimNotify_开始搀扶_NativeFunctionPtr;

		// Token: 0x0401745C RID: 95324
		private static IntPtr __ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_NativeFunctionPtr;

		// Token: 0x0200A254 RID: 41556
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x04032FFD RID: 208893
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A255 RID: 41557
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 192)]
		protected ref struct __ExecuteUbergraph_ABP_BaseRole_Gameplay_AssistedWalk_FunctionParams
		{
			// Token: 0x04032FFE RID: 208894
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
