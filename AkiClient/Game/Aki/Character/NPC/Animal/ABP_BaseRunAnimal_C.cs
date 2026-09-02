using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal
{
	// Token: 0x020040F1 RID: 16625
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/ABP_BaseRunAnimal.ABP_BaseRunAnimal_C")]
	[UnrealStructLayout(18848, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 18834)]
	public class ABP_BaseRunAnimal_C : UKuroAnimInstance, IUnrealUObject, IUnrealObject, IBPI_AnimalEcological_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x0602C29E RID: 180894 RVA: 0x00A97987 File Offset: 0x00A95B87
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (ABP_BaseRunAnimal_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/ABP_BaseRunAnimal.ABP_BaseRunAnimal_C");
			}
			return ABP_BaseRunAnimal_C._ClassPtr;
		}

		// Token: 0x0602C29F RID: 180895 RVA: 0x00A979AC File Offset: 0x00A95BAC
		public ABP_BaseRunAnimal_C() : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRunAnimal_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C2A0 RID: 180896 RVA: 0x00A979D4 File Offset: 0x00A95BD4
		public ABP_BaseRunAnimal_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ABP_BaseRunAnimal_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700768E RID: 30350
		// (get) Token: 0x0602C2A1 RID: 180897 RVA: 0x00A97A08 File Offset: 0x00A95C08
		// (set) Token: 0x0602C2A2 RID: 180898 RVA: 0x00A97A41 File Offset: 0x00A95C41
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700768F RID: 30351
		// (get) Token: 0x0602C2A3 RID: 180899 RVA: 0x00A97A64 File Offset: 0x00A95C64
		// (set) Token: 0x0602C2A4 RID: 180900 RVA: 0x00A97A9D File Offset: 0x00A95C9D
		public FAnimNode_Root AnimGraphNode_Root_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_3) == null)
				{
					result = (this._AnimGraphNode_Root_3 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007690 RID: 30352
		// (get) Token: 0x0602C2A5 RID: 180901 RVA: 0x00A97AC0 File Offset: 0x00A95CC0
		// (set) Token: 0x0602C2A6 RID: 180902 RVA: 0x00A97AF9 File Offset: 0x00A95CF9
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose_1) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose_1 = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007691 RID: 30353
		// (get) Token: 0x0602C2A7 RID: 180903 RVA: 0x00A97B1C File Offset: 0x00A95D1C
		// (set) Token: 0x0602C2A8 RID: 180904 RVA: 0x00A97B55 File Offset: 0x00A95D55
		public FAnimNode_Root AnimGraphNode_Root_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_2) == null)
				{
					result = (this._AnimGraphNode_Root_2 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007692 RID: 30354
		// (get) Token: 0x0602C2A9 RID: 180905 RVA: 0x00A97B78 File Offset: 0x00A95D78
		// (set) Token: 0x0602C2AA RID: 180906 RVA: 0x00A97BB1 File Offset: 0x00A95DB1
		public FAnimNode_SightLock AnimGraphNode_SightLock
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SightLock result;
				if ((result = this._AnimGraphNode_SightLock) == null)
				{
					result = (this._AnimGraphNode_SightLock = new FAnimNode_SightLock(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SightLock.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007693 RID: 30355
		// (get) Token: 0x0602C2AB RID: 180907 RVA: 0x00A97BD4 File Offset: 0x00A95DD4
		// (set) Token: 0x0602C2AC RID: 180908 RVA: 0x00A97C0D File Offset: 0x00A95E0D
		public FAnimNode_ConvertLocalToComponentSpace AnimGraphNode_LocalToComponentSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertLocalToComponentSpace result;
				if ((result = this._AnimGraphNode_LocalToComponentSpace) == null)
				{
					result = (this._AnimGraphNode_LocalToComponentSpace = new FAnimNode_ConvertLocalToComponentSpace(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_5, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertLocalToComponentSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_5, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007694 RID: 30356
		// (get) Token: 0x0602C2AD RID: 180909 RVA: 0x00A97C30 File Offset: 0x00A95E30
		// (set) Token: 0x0602C2AE RID: 180910 RVA: 0x00A97C69 File Offset: 0x00A95E69
		public FAnimNode_ConvertComponentToLocalSpace AnimGraphNode_ComponentToLocalSpace
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_ConvertComponentToLocalSpace result;
				if ((result = this._AnimGraphNode_ComponentToLocalSpace) == null)
				{
					result = (this._AnimGraphNode_ComponentToLocalSpace = new FAnimNode_ConvertComponentToLocalSpace(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_ConvertComponentToLocalSpace.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007695 RID: 30357
		// (get) Token: 0x0602C2AF RID: 180911 RVA: 0x00A97C8C File Offset: 0x00A95E8C
		// (set) Token: 0x0602C2B0 RID: 180912 RVA: 0x00A97CC5 File Offset: 0x00A95EC5
		public FAnimNode_LinkedInputPose AnimGraphNode_LinkedInputPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedInputPose result;
				if ((result = this._AnimGraphNode_LinkedInputPose) == null)
				{
					result = (this._AnimGraphNode_LinkedInputPose = new FAnimNode_LinkedInputPose(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedInputPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_7, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007696 RID: 30358
		// (get) Token: 0x0602C2B1 RID: 180913 RVA: 0x00A97CE8 File Offset: 0x00A95EE8
		// (set) Token: 0x0602C2B2 RID: 180914 RVA: 0x00A97D21 File Offset: 0x00A95F21
		public FAnimNode_Root AnimGraphNode_Root_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root_1) == null)
				{
					result = (this._AnimGraphNode_Root_1 = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007697 RID: 30359
		// (get) Token: 0x0602C2B3 RID: 180915 RVA: 0x00A97D44 File Offset: 0x00A95F44
		// (set) Token: 0x0602C2B4 RID: 180916 RVA: 0x00A97D7D File Offset: 0x00A95F7D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_53
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_53) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_53 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_9, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007698 RID: 30360
		// (get) Token: 0x0602C2B5 RID: 180917 RVA: 0x00A97DA0 File Offset: 0x00A95FA0
		// (set) Token: 0x0602C2B6 RID: 180918 RVA: 0x00A97DD9 File Offset: 0x00A95FD9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_52
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_52) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_52 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007699 RID: 30361
		// (get) Token: 0x0602C2B7 RID: 180919 RVA: 0x00A97DFC File Offset: 0x00A95FFC
		// (set) Token: 0x0602C2B8 RID: 180920 RVA: 0x00A97E35 File Offset: 0x00A96035
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_51
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_51) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_51 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_11, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700769A RID: 30362
		// (get) Token: 0x0602C2B9 RID: 180921 RVA: 0x00A97E58 File Offset: 0x00A96058
		// (set) Token: 0x0602C2BA RID: 180922 RVA: 0x00A97E91 File Offset: 0x00A96091
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_50
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_50) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_50 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_12, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700769B RID: 30363
		// (get) Token: 0x0602C2BB RID: 180923 RVA: 0x00A97EB4 File Offset: 0x00A960B4
		// (set) Token: 0x0602C2BC RID: 180924 RVA: 0x00A97EED File Offset: 0x00A960ED
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_49
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_49) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_49 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_13, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_13, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700769C RID: 30364
		// (get) Token: 0x0602C2BD RID: 180925 RVA: 0x00A97F10 File Offset: 0x00A96110
		// (set) Token: 0x0602C2BE RID: 180926 RVA: 0x00A97F49 File Offset: 0x00A96149
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_48
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_48) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_48 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_14, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_14, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700769D RID: 30365
		// (get) Token: 0x0602C2BF RID: 180927 RVA: 0x00A97F6C File Offset: 0x00A9616C
		// (set) Token: 0x0602C2C0 RID: 180928 RVA: 0x00A97FA5 File Offset: 0x00A961A5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_47
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_47) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_47 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_15, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_15, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700769E RID: 30366
		// (get) Token: 0x0602C2C1 RID: 180929 RVA: 0x00A97FC8 File Offset: 0x00A961C8
		// (set) Token: 0x0602C2C2 RID: 180930 RVA: 0x00A98001 File Offset: 0x00A96201
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_46
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_46) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_46 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_16, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_16, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700769F RID: 30367
		// (get) Token: 0x0602C2C3 RID: 180931 RVA: 0x00A98024 File Offset: 0x00A96224
		// (set) Token: 0x0602C2C4 RID: 180932 RVA: 0x00A9805D File Offset: 0x00A9625D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_25) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_25 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_17, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076A0 RID: 30368
		// (get) Token: 0x0602C2C5 RID: 180933 RVA: 0x00A98080 File Offset: 0x00A96280
		// (set) Token: 0x0602C2C6 RID: 180934 RVA: 0x00A980B9 File Offset: 0x00A962B9
		public FAnimNode_StateResult AnimGraphNode_StateResult_32
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_32) == null)
				{
					result = (this._AnimGraphNode_StateResult_32 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_18, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_18, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076A1 RID: 30369
		// (get) Token: 0x0602C2C7 RID: 180935 RVA: 0x00A980DC File Offset: 0x00A962DC
		// (set) Token: 0x0602C2C8 RID: 180936 RVA: 0x00A98115 File Offset: 0x00A96315
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_24) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_24 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_19, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_19, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076A2 RID: 30370
		// (get) Token: 0x0602C2C9 RID: 180937 RVA: 0x00A98138 File Offset: 0x00A96338
		// (set) Token: 0x0602C2CA RID: 180938 RVA: 0x00A98171 File Offset: 0x00A96371
		public FAnimNode_StateResult AnimGraphNode_StateResult_31
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_31) == null)
				{
					result = (this._AnimGraphNode_StateResult_31 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_20, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_20, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076A3 RID: 30371
		// (get) Token: 0x0602C2CB RID: 180939 RVA: 0x00A98194 File Offset: 0x00A96394
		// (set) Token: 0x0602C2CC RID: 180940 RVA: 0x00A981CD File Offset: 0x00A963CD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_23) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_23 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_21, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_21, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076A4 RID: 30372
		// (get) Token: 0x0602C2CD RID: 180941 RVA: 0x00A981F0 File Offset: 0x00A963F0
		// (set) Token: 0x0602C2CE RID: 180942 RVA: 0x00A98229 File Offset: 0x00A96429
		public FAnimNode_StateResult AnimGraphNode_StateResult_30
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_30) == null)
				{
					result = (this._AnimGraphNode_StateResult_30 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_22, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_22, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076A5 RID: 30373
		// (get) Token: 0x0602C2CF RID: 180943 RVA: 0x00A9824C File Offset: 0x00A9644C
		// (set) Token: 0x0602C2D0 RID: 180944 RVA: 0x00A98285 File Offset: 0x00A96485
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_22) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_22 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_23, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_23, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076A6 RID: 30374
		// (get) Token: 0x0602C2D1 RID: 180945 RVA: 0x00A982A8 File Offset: 0x00A964A8
		// (set) Token: 0x0602C2D2 RID: 180946 RVA: 0x00A982E1 File Offset: 0x00A964E1
		public FAnimNode_StateResult AnimGraphNode_StateResult_29
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_29) == null)
				{
					result = (this._AnimGraphNode_StateResult_29 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_24, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_24, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076A7 RID: 30375
		// (get) Token: 0x0602C2D3 RID: 180947 RVA: 0x00A98304 File Offset: 0x00A96504
		// (set) Token: 0x0602C2D4 RID: 180948 RVA: 0x00A9833D File Offset: 0x00A9653D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_21) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_21 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_25, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_25, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076A8 RID: 30376
		// (get) Token: 0x0602C2D5 RID: 180949 RVA: 0x00A98360 File Offset: 0x00A96560
		// (set) Token: 0x0602C2D6 RID: 180950 RVA: 0x00A98399 File Offset: 0x00A96599
		public FAnimNode_StateResult AnimGraphNode_StateResult_28
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_28) == null)
				{
					result = (this._AnimGraphNode_StateResult_28 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_26, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_26, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076A9 RID: 30377
		// (get) Token: 0x0602C2D7 RID: 180951 RVA: 0x00A983BC File Offset: 0x00A965BC
		// (set) Token: 0x0602C2D8 RID: 180952 RVA: 0x00A983F5 File Offset: 0x00A965F5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_20) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_20 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_27, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_27, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076AA RID: 30378
		// (get) Token: 0x0602C2D9 RID: 180953 RVA: 0x00A98418 File Offset: 0x00A96618
		// (set) Token: 0x0602C2DA RID: 180954 RVA: 0x00A98451 File Offset: 0x00A96651
		public FAnimNode_StateResult AnimGraphNode_StateResult_27
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_27) == null)
				{
					result = (this._AnimGraphNode_StateResult_27 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_28, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_28, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076AB RID: 30379
		// (get) Token: 0x0602C2DB RID: 180955 RVA: 0x00A98474 File Offset: 0x00A96674
		// (set) Token: 0x0602C2DC RID: 180956 RVA: 0x00A984AD File Offset: 0x00A966AD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_19) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_19 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_29, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_29, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076AC RID: 30380
		// (get) Token: 0x0602C2DD RID: 180957 RVA: 0x00A984D0 File Offset: 0x00A966D0
		// (set) Token: 0x0602C2DE RID: 180958 RVA: 0x00A98509 File Offset: 0x00A96709
		public FAnimNode_StateResult AnimGraphNode_StateResult_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_26) == null)
				{
					result = (this._AnimGraphNode_StateResult_26 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_30, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_30, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076AD RID: 30381
		// (get) Token: 0x0602C2DF RID: 180959 RVA: 0x00A9852C File Offset: 0x00A9672C
		// (set) Token: 0x0602C2E0 RID: 180960 RVA: 0x00A98565 File Offset: 0x00A96765
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_4) == null)
				{
					result = (this._AnimGraphNode_StateMachine_4 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_31, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_31, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076AE RID: 30382
		// (get) Token: 0x0602C2E1 RID: 180961 RVA: 0x00A98588 File Offset: 0x00A96788
		// (set) Token: 0x0602C2E2 RID: 180962 RVA: 0x00A985C1 File Offset: 0x00A967C1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_45
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_45) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_45 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_32, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_32, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076AF RID: 30383
		// (get) Token: 0x0602C2E3 RID: 180963 RVA: 0x00A985E4 File Offset: 0x00A967E4
		// (set) Token: 0x0602C2E4 RID: 180964 RVA: 0x00A9861D File Offset: 0x00A9681D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_44
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_44) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_44 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_33, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_33, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076B0 RID: 30384
		// (get) Token: 0x0602C2E5 RID: 180965 RVA: 0x00A98640 File Offset: 0x00A96840
		// (set) Token: 0x0602C2E6 RID: 180966 RVA: 0x00A98679 File Offset: 0x00A96879
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_43
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_43) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_43 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_34, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_34, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076B1 RID: 30385
		// (get) Token: 0x0602C2E7 RID: 180967 RVA: 0x00A9869C File Offset: 0x00A9689C
		// (set) Token: 0x0602C2E8 RID: 180968 RVA: 0x00A986D5 File Offset: 0x00A968D5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_42
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_42) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_42 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_35, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_35, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076B2 RID: 30386
		// (get) Token: 0x0602C2E9 RID: 180969 RVA: 0x00A986F8 File Offset: 0x00A968F8
		// (set) Token: 0x0602C2EA RID: 180970 RVA: 0x00A98731 File Offset: 0x00A96931
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_41
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_41) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_41 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_36, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_36, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076B3 RID: 30387
		// (get) Token: 0x0602C2EB RID: 180971 RVA: 0x00A98754 File Offset: 0x00A96954
		// (set) Token: 0x0602C2EC RID: 180972 RVA: 0x00A9878D File Offset: 0x00A9698D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_40
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_40) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_40 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_37, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_37, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076B4 RID: 30388
		// (get) Token: 0x0602C2ED RID: 180973 RVA: 0x00A987B0 File Offset: 0x00A969B0
		// (set) Token: 0x0602C2EE RID: 180974 RVA: 0x00A987E9 File Offset: 0x00A969E9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_39
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_39) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_39 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_38, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_38, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076B5 RID: 30389
		// (get) Token: 0x0602C2EF RID: 180975 RVA: 0x00A9880C File Offset: 0x00A96A0C
		// (set) Token: 0x0602C2F0 RID: 180976 RVA: 0x00A98845 File Offset: 0x00A96A45
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_38
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_38) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_38 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_39, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_39, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076B6 RID: 30390
		// (get) Token: 0x0602C2F1 RID: 180977 RVA: 0x00A98868 File Offset: 0x00A96A68
		// (set) Token: 0x0602C2F2 RID: 180978 RVA: 0x00A988A1 File Offset: 0x00A96AA1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_37
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_37) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_37 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_40, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_40, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076B7 RID: 30391
		// (get) Token: 0x0602C2F3 RID: 180979 RVA: 0x00A988C4 File Offset: 0x00A96AC4
		// (set) Token: 0x0602C2F4 RID: 180980 RVA: 0x00A988FD File Offset: 0x00A96AFD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_36
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_36) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_36 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_41, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_41, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076B8 RID: 30392
		// (get) Token: 0x0602C2F5 RID: 180981 RVA: 0x00A98920 File Offset: 0x00A96B20
		// (set) Token: 0x0602C2F6 RID: 180982 RVA: 0x00A98959 File Offset: 0x00A96B59
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_35
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_35) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_35 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_42, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_42, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076B9 RID: 30393
		// (get) Token: 0x0602C2F7 RID: 180983 RVA: 0x00A9897C File Offset: 0x00A96B7C
		// (set) Token: 0x0602C2F8 RID: 180984 RVA: 0x00A989B5 File Offset: 0x00A96BB5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_34
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_34) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_34 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_43, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_43, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076BA RID: 30394
		// (get) Token: 0x0602C2F9 RID: 180985 RVA: 0x00A989D8 File Offset: 0x00A96BD8
		// (set) Token: 0x0602C2FA RID: 180986 RVA: 0x00A98A11 File Offset: 0x00A96C11
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_33
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_33) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_33 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_44, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_44, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076BB RID: 30395
		// (get) Token: 0x0602C2FB RID: 180987 RVA: 0x00A98A34 File Offset: 0x00A96C34
		// (set) Token: 0x0602C2FC RID: 180988 RVA: 0x00A98A6D File Offset: 0x00A96C6D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_32
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_32) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_32 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_45, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_45, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076BC RID: 30396
		// (get) Token: 0x0602C2FD RID: 180989 RVA: 0x00A98A90 File Offset: 0x00A96C90
		// (set) Token: 0x0602C2FE RID: 180990 RVA: 0x00A98AC9 File Offset: 0x00A96CC9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_31
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_31) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_31 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_46, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_46, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076BD RID: 30397
		// (get) Token: 0x0602C2FF RID: 180991 RVA: 0x00A98AEC File Offset: 0x00A96CEC
		// (set) Token: 0x0602C300 RID: 180992 RVA: 0x00A98B25 File Offset: 0x00A96D25
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_30
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_30) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_30 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_47, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_47, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076BE RID: 30398
		// (get) Token: 0x0602C301 RID: 180993 RVA: 0x00A98B48 File Offset: 0x00A96D48
		// (set) Token: 0x0602C302 RID: 180994 RVA: 0x00A98B81 File Offset: 0x00A96D81
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_29
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_29) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_29 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_48, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_48, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076BF RID: 30399
		// (get) Token: 0x0602C303 RID: 180995 RVA: 0x00A98BA4 File Offset: 0x00A96DA4
		// (set) Token: 0x0602C304 RID: 180996 RVA: 0x00A98BDD File Offset: 0x00A96DDD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_28
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_28) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_28 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_49, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_49, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076C0 RID: 30400
		// (get) Token: 0x0602C305 RID: 180997 RVA: 0x00A98C00 File Offset: 0x00A96E00
		// (set) Token: 0x0602C306 RID: 180998 RVA: 0x00A98C39 File Offset: 0x00A96E39
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_27
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_27) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_27 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_50, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_50, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076C1 RID: 30401
		// (get) Token: 0x0602C307 RID: 180999 RVA: 0x00A98C5C File Offset: 0x00A96E5C
		// (set) Token: 0x0602C308 RID: 181000 RVA: 0x00A98C95 File Offset: 0x00A96E95
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_18) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_18 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_51, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_51, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076C2 RID: 30402
		// (get) Token: 0x0602C309 RID: 181001 RVA: 0x00A98CB8 File Offset: 0x00A96EB8
		// (set) Token: 0x0602C30A RID: 181002 RVA: 0x00A98CF1 File Offset: 0x00A96EF1
		public FAnimNode_StateResult AnimGraphNode_StateResult_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_25) == null)
				{
					result = (this._AnimGraphNode_StateResult_25 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_52, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_52, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076C3 RID: 30403
		// (get) Token: 0x0602C30B RID: 181003 RVA: 0x00A98D14 File Offset: 0x00A96F14
		// (set) Token: 0x0602C30C RID: 181004 RVA: 0x00A98D4D File Offset: 0x00A96F4D
		public FAnimNode_SequenceEvaluator AnimGraphNode_SequenceEvaluator_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequenceEvaluator result;
				if ((result = this._AnimGraphNode_SequenceEvaluator_1) == null)
				{
					result = (this._AnimGraphNode_SequenceEvaluator_1 = new FAnimNode_SequenceEvaluator(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_53, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequenceEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_53, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076C4 RID: 30404
		// (get) Token: 0x0602C30D RID: 181005 RVA: 0x00A98D70 File Offset: 0x00A96F70
		// (set) Token: 0x0602C30E RID: 181006 RVA: 0x00A98DA9 File Offset: 0x00A96FA9
		public FAnimNode_StateResult AnimGraphNode_StateResult_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_24) == null)
				{
					result = (this._AnimGraphNode_StateResult_24 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_54, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_54, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076C5 RID: 30405
		// (get) Token: 0x0602C30F RID: 181007 RVA: 0x00A98DCC File Offset: 0x00A96FCC
		// (set) Token: 0x0602C310 RID: 181008 RVA: 0x00A98E05 File Offset: 0x00A97005
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_17) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_17 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_55, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_55, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076C6 RID: 30406
		// (get) Token: 0x0602C311 RID: 181009 RVA: 0x00A98E28 File Offset: 0x00A97028
		// (set) Token: 0x0602C312 RID: 181010 RVA: 0x00A98E61 File Offset: 0x00A97061
		public FAnimNode_StateResult AnimGraphNode_StateResult_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_23) == null)
				{
					result = (this._AnimGraphNode_StateResult_23 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_56, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_56, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076C7 RID: 30407
		// (get) Token: 0x0602C313 RID: 181011 RVA: 0x00A98E84 File Offset: 0x00A97084
		// (set) Token: 0x0602C314 RID: 181012 RVA: 0x00A98EBD File Offset: 0x00A970BD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_16) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_16 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_57, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_57, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076C8 RID: 30408
		// (get) Token: 0x0602C315 RID: 181013 RVA: 0x00A98EE0 File Offset: 0x00A970E0
		// (set) Token: 0x0602C316 RID: 181014 RVA: 0x00A98F19 File Offset: 0x00A97119
		public FAnimNode_StateResult AnimGraphNode_StateResult_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_22) == null)
				{
					result = (this._AnimGraphNode_StateResult_22 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_58, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_58, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076C9 RID: 30409
		// (get) Token: 0x0602C317 RID: 181015 RVA: 0x00A98F3C File Offset: 0x00A9713C
		// (set) Token: 0x0602C318 RID: 181016 RVA: 0x00A98F75 File Offset: 0x00A97175
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_15) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_15 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_59, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_59, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076CA RID: 30410
		// (get) Token: 0x0602C319 RID: 181017 RVA: 0x00A98F98 File Offset: 0x00A97198
		// (set) Token: 0x0602C31A RID: 181018 RVA: 0x00A98FD1 File Offset: 0x00A971D1
		public FAnimNode_StateResult AnimGraphNode_StateResult_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_21) == null)
				{
					result = (this._AnimGraphNode_StateResult_21 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_60, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_60, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076CB RID: 30411
		// (get) Token: 0x0602C31B RID: 181019 RVA: 0x00A98FF4 File Offset: 0x00A971F4
		// (set) Token: 0x0602C31C RID: 181020 RVA: 0x00A9902D File Offset: 0x00A9722D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_14) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_14 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_61, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_61, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076CC RID: 30412
		// (get) Token: 0x0602C31D RID: 181021 RVA: 0x00A99050 File Offset: 0x00A97250
		// (set) Token: 0x0602C31E RID: 181022 RVA: 0x00A99089 File Offset: 0x00A97289
		public FAnimNode_StateResult AnimGraphNode_StateResult_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_20) == null)
				{
					result = (this._AnimGraphNode_StateResult_20 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_62, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_62, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076CD RID: 30413
		// (get) Token: 0x0602C31F RID: 181023 RVA: 0x00A990AC File Offset: 0x00A972AC
		// (set) Token: 0x0602C320 RID: 181024 RVA: 0x00A990E5 File Offset: 0x00A972E5
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_13) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_13 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_63, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_63, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076CE RID: 30414
		// (get) Token: 0x0602C321 RID: 181025 RVA: 0x00A99108 File Offset: 0x00A97308
		// (set) Token: 0x0602C322 RID: 181026 RVA: 0x00A99141 File Offset: 0x00A97341
		public FAnimNode_StateResult AnimGraphNode_StateResult_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_19) == null)
				{
					result = (this._AnimGraphNode_StateResult_19 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_64, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_64, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076CF RID: 30415
		// (get) Token: 0x0602C323 RID: 181027 RVA: 0x00A99164 File Offset: 0x00A97364
		// (set) Token: 0x0602C324 RID: 181028 RVA: 0x00A9919D File Offset: 0x00A9739D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_3) == null)
				{
					result = (this._AnimGraphNode_StateMachine_3 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_65, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_65, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076D0 RID: 30416
		// (get) Token: 0x0602C325 RID: 181029 RVA: 0x00A991C0 File Offset: 0x00A973C0
		// (set) Token: 0x0602C326 RID: 181030 RVA: 0x00A991F9 File Offset: 0x00A973F9
		public FAnimNode_StateResult AnimGraphNode_StateResult_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_18) == null)
				{
					result = (this._AnimGraphNode_StateResult_18 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_66, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_66, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076D1 RID: 30417
		// (get) Token: 0x0602C327 RID: 181031 RVA: 0x00A9921C File Offset: 0x00A9741C
		// (set) Token: 0x0602C328 RID: 181032 RVA: 0x00A99255 File Offset: 0x00A97455
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_26
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_26) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_26 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_67, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_67, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076D2 RID: 30418
		// (get) Token: 0x0602C329 RID: 181033 RVA: 0x00A99278 File Offset: 0x00A97478
		// (set) Token: 0x0602C32A RID: 181034 RVA: 0x00A992B1 File Offset: 0x00A974B1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_25
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_25) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_25 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_68, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_68, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076D3 RID: 30419
		// (get) Token: 0x0602C32B RID: 181035 RVA: 0x00A992D4 File Offset: 0x00A974D4
		// (set) Token: 0x0602C32C RID: 181036 RVA: 0x00A9930D File Offset: 0x00A9750D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_24
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_24) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_24 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_69, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_69, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076D4 RID: 30420
		// (get) Token: 0x0602C32D RID: 181037 RVA: 0x00A99330 File Offset: 0x00A97530
		// (set) Token: 0x0602C32E RID: 181038 RVA: 0x00A99369 File Offset: 0x00A97569
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_23
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_23) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_23 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_70, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_70, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076D5 RID: 30421
		// (get) Token: 0x0602C32F RID: 181039 RVA: 0x00A9938C File Offset: 0x00A9758C
		// (set) Token: 0x0602C330 RID: 181040 RVA: 0x00A993C5 File Offset: 0x00A975C5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_22
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_22) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_22 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_71, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_71, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076D6 RID: 30422
		// (get) Token: 0x0602C331 RID: 181041 RVA: 0x00A993E8 File Offset: 0x00A975E8
		// (set) Token: 0x0602C332 RID: 181042 RVA: 0x00A99421 File Offset: 0x00A97621
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_21
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_21) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_21 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_72, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_72, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076D7 RID: 30423
		// (get) Token: 0x0602C333 RID: 181043 RVA: 0x00A99444 File Offset: 0x00A97644
		// (set) Token: 0x0602C334 RID: 181044 RVA: 0x00A9947D File Offset: 0x00A9767D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_20
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_20) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_20 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_73, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_73, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076D8 RID: 30424
		// (get) Token: 0x0602C335 RID: 181045 RVA: 0x00A994A0 File Offset: 0x00A976A0
		// (set) Token: 0x0602C336 RID: 181046 RVA: 0x00A994D9 File Offset: 0x00A976D9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_19
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_19) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_19 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_74, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_74, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076D9 RID: 30425
		// (get) Token: 0x0602C337 RID: 181047 RVA: 0x00A994FC File Offset: 0x00A976FC
		// (set) Token: 0x0602C338 RID: 181048 RVA: 0x00A99535 File Offset: 0x00A97735
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_18
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_18) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_18 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_75, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_75, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076DA RID: 30426
		// (get) Token: 0x0602C339 RID: 181049 RVA: 0x00A99558 File Offset: 0x00A97758
		// (set) Token: 0x0602C33A RID: 181050 RVA: 0x00A99591 File Offset: 0x00A97791
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_17) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_17 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_76, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_76, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076DB RID: 30427
		// (get) Token: 0x0602C33B RID: 181051 RVA: 0x00A995B4 File Offset: 0x00A977B4
		// (set) Token: 0x0602C33C RID: 181052 RVA: 0x00A995ED File Offset: 0x00A977ED
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_12) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_12 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_77, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_77, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076DC RID: 30428
		// (get) Token: 0x0602C33D RID: 181053 RVA: 0x00A99610 File Offset: 0x00A97810
		// (set) Token: 0x0602C33E RID: 181054 RVA: 0x00A99649 File Offset: 0x00A97849
		public FAnimNode_StateResult AnimGraphNode_StateResult_17
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_17) == null)
				{
					result = (this._AnimGraphNode_StateResult_17 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_78, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_78, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076DD RID: 30429
		// (get) Token: 0x0602C33F RID: 181055 RVA: 0x00A9966C File Offset: 0x00A9786C
		// (set) Token: 0x0602C340 RID: 181056 RVA: 0x00A996A5 File Offset: 0x00A978A5
		public FAnimNode_SequenceEvaluator AnimGraphNode_SequenceEvaluator
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequenceEvaluator result;
				if ((result = this._AnimGraphNode_SequenceEvaluator) == null)
				{
					result = (this._AnimGraphNode_SequenceEvaluator = new FAnimNode_SequenceEvaluator(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_79, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequenceEvaluator.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_79, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076DE RID: 30430
		// (get) Token: 0x0602C341 RID: 181057 RVA: 0x00A996C8 File Offset: 0x00A978C8
		// (set) Token: 0x0602C342 RID: 181058 RVA: 0x00A99701 File Offset: 0x00A97901
		public FAnimNode_StateResult AnimGraphNode_StateResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_16) == null)
				{
					result = (this._AnimGraphNode_StateResult_16 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_80, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_80, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076DF RID: 30431
		// (get) Token: 0x0602C343 RID: 181059 RVA: 0x00A99724 File Offset: 0x00A97924
		// (set) Token: 0x0602C344 RID: 181060 RVA: 0x00A9975D File Offset: 0x00A9795D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_11) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_11 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_81, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_81, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076E0 RID: 30432
		// (get) Token: 0x0602C345 RID: 181061 RVA: 0x00A99780 File Offset: 0x00A97980
		// (set) Token: 0x0602C346 RID: 181062 RVA: 0x00A997B9 File Offset: 0x00A979B9
		public FAnimNode_StateResult AnimGraphNode_StateResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_15) == null)
				{
					result = (this._AnimGraphNode_StateResult_15 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_82, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_82, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076E1 RID: 30433
		// (get) Token: 0x0602C347 RID: 181063 RVA: 0x00A997DC File Offset: 0x00A979DC
		// (set) Token: 0x0602C348 RID: 181064 RVA: 0x00A99815 File Offset: 0x00A97A15
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_10) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_10 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_83, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_83, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076E2 RID: 30434
		// (get) Token: 0x0602C349 RID: 181065 RVA: 0x00A99838 File Offset: 0x00A97A38
		// (set) Token: 0x0602C34A RID: 181066 RVA: 0x00A99871 File Offset: 0x00A97A71
		public FAnimNode_StateResult AnimGraphNode_StateResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_14) == null)
				{
					result = (this._AnimGraphNode_StateResult_14 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_84, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_84, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076E3 RID: 30435
		// (get) Token: 0x0602C34B RID: 181067 RVA: 0x00A99894 File Offset: 0x00A97A94
		// (set) Token: 0x0602C34C RID: 181068 RVA: 0x00A998CD File Offset: 0x00A97ACD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_9) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_9 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_85, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_85, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076E4 RID: 30436
		// (get) Token: 0x0602C34D RID: 181069 RVA: 0x00A998F0 File Offset: 0x00A97AF0
		// (set) Token: 0x0602C34E RID: 181070 RVA: 0x00A99929 File Offset: 0x00A97B29
		public FAnimNode_StateResult AnimGraphNode_StateResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_13) == null)
				{
					result = (this._AnimGraphNode_StateResult_13 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_86, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_86, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076E5 RID: 30437
		// (get) Token: 0x0602C34F RID: 181071 RVA: 0x00A9994C File Offset: 0x00A97B4C
		// (set) Token: 0x0602C350 RID: 181072 RVA: 0x00A99985 File Offset: 0x00A97B85
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_8) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_8 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_87, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_87, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076E6 RID: 30438
		// (get) Token: 0x0602C351 RID: 181073 RVA: 0x00A999A8 File Offset: 0x00A97BA8
		// (set) Token: 0x0602C352 RID: 181074 RVA: 0x00A999E1 File Offset: 0x00A97BE1
		public FAnimNode_StateResult AnimGraphNode_StateResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_12) == null)
				{
					result = (this._AnimGraphNode_StateResult_12 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_88, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_88, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076E7 RID: 30439
		// (get) Token: 0x0602C353 RID: 181075 RVA: 0x00A99A04 File Offset: 0x00A97C04
		// (set) Token: 0x0602C354 RID: 181076 RVA: 0x00A99A3D File Offset: 0x00A97C3D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_7) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_7 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_89, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_89, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076E8 RID: 30440
		// (get) Token: 0x0602C355 RID: 181077 RVA: 0x00A99A60 File Offset: 0x00A97C60
		// (set) Token: 0x0602C356 RID: 181078 RVA: 0x00A99A99 File Offset: 0x00A97C99
		public FAnimNode_StateResult AnimGraphNode_StateResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_11) == null)
				{
					result = (this._AnimGraphNode_StateResult_11 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_90, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_90, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076E9 RID: 30441
		// (get) Token: 0x0602C357 RID: 181079 RVA: 0x00A99ABC File Offset: 0x00A97CBC
		// (set) Token: 0x0602C358 RID: 181080 RVA: 0x00A99AF5 File Offset: 0x00A97CF5
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_2) == null)
				{
					result = (this._AnimGraphNode_StateMachine_2 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_91, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_91, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076EA RID: 30442
		// (get) Token: 0x0602C359 RID: 181081 RVA: 0x00A99B18 File Offset: 0x00A97D18
		// (set) Token: 0x0602C35A RID: 181082 RVA: 0x00A99B51 File Offset: 0x00A97D51
		public FAnimNode_StateResult AnimGraphNode_StateResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_10) == null)
				{
					result = (this._AnimGraphNode_StateResult_10 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_92, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_92, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076EB RID: 30443
		// (get) Token: 0x0602C35B RID: 181083 RVA: 0x00A99B74 File Offset: 0x00A97D74
		// (set) Token: 0x0602C35C RID: 181084 RVA: 0x00A99BAD File Offset: 0x00A97DAD
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_6) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_6 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_93, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_93, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076EC RID: 30444
		// (get) Token: 0x0602C35D RID: 181085 RVA: 0x00A99BD0 File Offset: 0x00A97DD0
		// (set) Token: 0x0602C35E RID: 181086 RVA: 0x00A99C09 File Offset: 0x00A97E09
		public FAnimNode_StateResult AnimGraphNode_StateResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_9) == null)
				{
					result = (this._AnimGraphNode_StateResult_9 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_94, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_94, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076ED RID: 30445
		// (get) Token: 0x0602C35F RID: 181087 RVA: 0x00A99C2C File Offset: 0x00A97E2C
		// (set) Token: 0x0602C360 RID: 181088 RVA: 0x00A99C65 File Offset: 0x00A97E65
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_5) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_5 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_95, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_95, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076EE RID: 30446
		// (get) Token: 0x0602C361 RID: 181089 RVA: 0x00A99C88 File Offset: 0x00A97E88
		// (set) Token: 0x0602C362 RID: 181090 RVA: 0x00A99CC1 File Offset: 0x00A97EC1
		public FAnimNode_StateResult AnimGraphNode_StateResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_8) == null)
				{
					result = (this._AnimGraphNode_StateResult_8 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_96, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_96, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076EF RID: 30447
		// (get) Token: 0x0602C363 RID: 181091 RVA: 0x00A99CE4 File Offset: 0x00A97EE4
		// (set) Token: 0x0602C364 RID: 181092 RVA: 0x00A99D1D File Offset: 0x00A97F1D
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_4) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_4 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_97, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_97, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076F0 RID: 30448
		// (get) Token: 0x0602C365 RID: 181093 RVA: 0x00A99D40 File Offset: 0x00A97F40
		// (set) Token: 0x0602C366 RID: 181094 RVA: 0x00A99D79 File Offset: 0x00A97F79
		public FAnimNode_StateResult AnimGraphNode_StateResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_7) == null)
				{
					result = (this._AnimGraphNode_StateResult_7 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_98, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_98, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076F1 RID: 30449
		// (get) Token: 0x0602C367 RID: 181095 RVA: 0x00A99D9C File Offset: 0x00A97F9C
		// (set) Token: 0x0602C368 RID: 181096 RVA: 0x00A99DD5 File Offset: 0x00A97FD5
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose_1) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose_1 = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_99, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_99, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076F2 RID: 30450
		// (get) Token: 0x0602C369 RID: 181097 RVA: 0x00A99DF8 File Offset: 0x00A97FF8
		// (set) Token: 0x0602C36A RID: 181098 RVA: 0x00A99E31 File Offset: 0x00A98031
		public FAnimNode_StateResult AnimGraphNode_StateResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_6) == null)
				{
					result = (this._AnimGraphNode_StateResult_6 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_100, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_100, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076F3 RID: 30451
		// (get) Token: 0x0602C36B RID: 181099 RVA: 0x00A99E54 File Offset: 0x00A98054
		// (set) Token: 0x0602C36C RID: 181100 RVA: 0x00A99E8D File Offset: 0x00A9808D
		public FAnimNode_StateMachine AnimGraphNode_StateMachine_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine_1) == null)
				{
					result = (this._AnimGraphNode_StateMachine_1 = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_101, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_101, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076F4 RID: 30452
		// (get) Token: 0x0602C36D RID: 181101 RVA: 0x00A99EB0 File Offset: 0x00A980B0
		// (set) Token: 0x0602C36E RID: 181102 RVA: 0x00A99EE9 File Offset: 0x00A980E9
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose_1) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose_1 = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_102, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_102, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076F5 RID: 30453
		// (get) Token: 0x0602C36F RID: 181103 RVA: 0x00A99F0C File Offset: 0x00A9810C
		// (set) Token: 0x0602C370 RID: 181104 RVA: 0x00A99F45 File Offset: 0x00A98145
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_16
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_16) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_16 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_103, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_103, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076F6 RID: 30454
		// (get) Token: 0x0602C371 RID: 181105 RVA: 0x00A99F68 File Offset: 0x00A98168
		// (set) Token: 0x0602C372 RID: 181106 RVA: 0x00A99FA1 File Offset: 0x00A981A1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_15
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_15) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_15 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_104, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_104, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076F7 RID: 30455
		// (get) Token: 0x0602C373 RID: 181107 RVA: 0x00A99FC4 File Offset: 0x00A981C4
		// (set) Token: 0x0602C374 RID: 181108 RVA: 0x00A99FFD File Offset: 0x00A981FD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_14
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_14) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_14 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_105, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_105, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076F8 RID: 30456
		// (get) Token: 0x0602C375 RID: 181109 RVA: 0x00A9A020 File Offset: 0x00A98220
		// (set) Token: 0x0602C376 RID: 181110 RVA: 0x00A9A059 File Offset: 0x00A98259
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_13
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_13) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_13 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_106, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_106, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076F9 RID: 30457
		// (get) Token: 0x0602C377 RID: 181111 RVA: 0x00A9A07C File Offset: 0x00A9827C
		// (set) Token: 0x0602C378 RID: 181112 RVA: 0x00A9A0B5 File Offset: 0x00A982B5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_12
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_12) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_12 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_107, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_107, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076FA RID: 30458
		// (get) Token: 0x0602C379 RID: 181113 RVA: 0x00A9A0D8 File Offset: 0x00A982D8
		// (set) Token: 0x0602C37A RID: 181114 RVA: 0x00A9A111 File Offset: 0x00A98311
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_11
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_11) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_11 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_108, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_108, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076FB RID: 30459
		// (get) Token: 0x0602C37B RID: 181115 RVA: 0x00A9A134 File Offset: 0x00A98334
		// (set) Token: 0x0602C37C RID: 181116 RVA: 0x00A9A16D File Offset: 0x00A9836D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_10
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_10) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_10 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_109, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_109, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076FC RID: 30460
		// (get) Token: 0x0602C37D RID: 181117 RVA: 0x00A9A190 File Offset: 0x00A98390
		// (set) Token: 0x0602C37E RID: 181118 RVA: 0x00A9A1C9 File Offset: 0x00A983C9
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_9
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_9) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_9 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_110, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_110, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076FD RID: 30461
		// (get) Token: 0x0602C37F RID: 181119 RVA: 0x00A9A1EC File Offset: 0x00A983EC
		// (set) Token: 0x0602C380 RID: 181120 RVA: 0x00A9A225 File Offset: 0x00A98425
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_8
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_8) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_8 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_111, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_111, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076FE RID: 30462
		// (get) Token: 0x0602C381 RID: 181121 RVA: 0x00A9A248 File Offset: 0x00A98448
		// (set) Token: 0x0602C382 RID: 181122 RVA: 0x00A9A281 File Offset: 0x00A98481
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_7
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_7) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_7 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_112, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_112, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170076FF RID: 30463
		// (get) Token: 0x0602C383 RID: 181123 RVA: 0x00A9A2A4 File Offset: 0x00A984A4
		// (set) Token: 0x0602C384 RID: 181124 RVA: 0x00A9A2DD File Offset: 0x00A984DD
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_6
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_6) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_6 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_113, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_113, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007700 RID: 30464
		// (get) Token: 0x0602C385 RID: 181125 RVA: 0x00A9A300 File Offset: 0x00A98500
		// (set) Token: 0x0602C386 RID: 181126 RVA: 0x00A9A339 File Offset: 0x00A98539
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_5) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_5 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_114, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_114, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007701 RID: 30465
		// (get) Token: 0x0602C387 RID: 181127 RVA: 0x00A9A35C File Offset: 0x00A9855C
		// (set) Token: 0x0602C388 RID: 181128 RVA: 0x00A9A395 File Offset: 0x00A98595
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_4) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_4 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_115, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_115, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007702 RID: 30466
		// (get) Token: 0x0602C389 RID: 181129 RVA: 0x00A9A3B8 File Offset: 0x00A985B8
		// (set) Token: 0x0602C38A RID: 181130 RVA: 0x00A9A3F1 File Offset: 0x00A985F1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_3) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_3 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_116, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_116, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007703 RID: 30467
		// (get) Token: 0x0602C38B RID: 181131 RVA: 0x00A9A414 File Offset: 0x00A98614
		// (set) Token: 0x0602C38C RID: 181132 RVA: 0x00A9A44D File Offset: 0x00A9864D
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_2) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_2 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_117, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_117, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007704 RID: 30468
		// (get) Token: 0x0602C38D RID: 181133 RVA: 0x00A9A470 File Offset: 0x00A98670
		// (set) Token: 0x0602C38E RID: 181134 RVA: 0x00A9A4A9 File Offset: 0x00A986A9
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_3) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_3 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_118, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_118, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007705 RID: 30469
		// (get) Token: 0x0602C38F RID: 181135 RVA: 0x00A9A4CC File Offset: 0x00A986CC
		// (set) Token: 0x0602C390 RID: 181136 RVA: 0x00A9A505 File Offset: 0x00A98705
		public FAnimNode_StateResult AnimGraphNode_StateResult_5
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_5) == null)
				{
					result = (this._AnimGraphNode_StateResult_5 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_119, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_119, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007706 RID: 30470
		// (get) Token: 0x0602C391 RID: 181137 RVA: 0x00A9A528 File Offset: 0x00A98728
		// (set) Token: 0x0602C392 RID: 181138 RVA: 0x00A9A561 File Offset: 0x00A98761
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_2) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_2 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_120, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_120, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007707 RID: 30471
		// (get) Token: 0x0602C393 RID: 181139 RVA: 0x00A9A584 File Offset: 0x00A98784
		// (set) Token: 0x0602C394 RID: 181140 RVA: 0x00A9A5BD File Offset: 0x00A987BD
		public FAnimNode_StateResult AnimGraphNode_StateResult_4
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_4) == null)
				{
					result = (this._AnimGraphNode_StateResult_4 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_121, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_121, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007708 RID: 30472
		// (get) Token: 0x0602C395 RID: 181141 RVA: 0x00A9A5E0 File Offset: 0x00A987E0
		// (set) Token: 0x0602C396 RID: 181142 RVA: 0x00A9A619 File Offset: 0x00A98819
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer_1) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer_1 = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_122, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_122, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007709 RID: 30473
		// (get) Token: 0x0602C397 RID: 181143 RVA: 0x00A9A63C File Offset: 0x00A9883C
		// (set) Token: 0x0602C398 RID: 181144 RVA: 0x00A9A675 File Offset: 0x00A98875
		public FAnimNode_StateResult AnimGraphNode_StateResult_3
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_3) == null)
				{
					result = (this._AnimGraphNode_StateResult_3 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_123, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_123, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700770A RID: 30474
		// (get) Token: 0x0602C399 RID: 181145 RVA: 0x00A9A698 File Offset: 0x00A98898
		// (set) Token: 0x0602C39A RID: 181146 RVA: 0x00A9A6D1 File Offset: 0x00A988D1
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult_1) == null)
				{
					result = (this._AnimGraphNode_TransitionResult_1 = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_124, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_124, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700770B RID: 30475
		// (get) Token: 0x0602C39B RID: 181147 RVA: 0x00A9A6F4 File Offset: 0x00A988F4
		// (set) Token: 0x0602C39C RID: 181148 RVA: 0x00A9A72D File Offset: 0x00A9892D
		public FAnimNode_BlendSpacePlayer AnimGraphNode_BlendSpacePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_BlendSpacePlayer result;
				if ((result = this._AnimGraphNode_BlendSpacePlayer) == null)
				{
					result = (this._AnimGraphNode_BlendSpacePlayer = new FAnimNode_BlendSpacePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_125, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_BlendSpacePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_125, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700770C RID: 30476
		// (get) Token: 0x0602C39D RID: 181149 RVA: 0x00A9A750 File Offset: 0x00A98950
		// (set) Token: 0x0602C39E RID: 181150 RVA: 0x00A9A789 File Offset: 0x00A98989
		public FAnimNode_StateResult AnimGraphNode_StateResult_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_2) == null)
				{
					result = (this._AnimGraphNode_StateResult_2 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_126, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_126, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700770D RID: 30477
		// (get) Token: 0x0602C39F RID: 181151 RVA: 0x00A9A7AC File Offset: 0x00A989AC
		// (set) Token: 0x0602C3A0 RID: 181152 RVA: 0x00A9A7E5 File Offset: 0x00A989E5
		public FAnimNode_TransitionResult AnimGraphNode_TransitionResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_TransitionResult result;
				if ((result = this._AnimGraphNode_TransitionResult) == null)
				{
					result = (this._AnimGraphNode_TransitionResult = new FAnimNode_TransitionResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_127, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_TransitionResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_127, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700770E RID: 30478
		// (get) Token: 0x0602C3A1 RID: 181153 RVA: 0x00A9A808 File Offset: 0x00A98A08
		// (set) Token: 0x0602C3A2 RID: 181154 RVA: 0x00A9A841 File Offset: 0x00A98A41
		public FAnimNode_SequencePlayer AnimGraphNode_SequencePlayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SequencePlayer result;
				if ((result = this._AnimGraphNode_SequencePlayer) == null)
				{
					result = (this._AnimGraphNode_SequencePlayer = new FAnimNode_SequencePlayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_128, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SequencePlayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_128, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700770F RID: 30479
		// (get) Token: 0x0602C3A3 RID: 181155 RVA: 0x00A9A864 File Offset: 0x00A98A64
		// (set) Token: 0x0602C3A4 RID: 181156 RVA: 0x00A9A89D File Offset: 0x00A98A9D
		public FAnimNode_StateResult AnimGraphNode_StateResult_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult_1) == null)
				{
					result = (this._AnimGraphNode_StateResult_1 = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_129, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_129, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007710 RID: 30480
		// (get) Token: 0x0602C3A5 RID: 181157 RVA: 0x00A9A8C0 File Offset: 0x00A98AC0
		// (set) Token: 0x0602C3A6 RID: 181158 RVA: 0x00A9A8F9 File Offset: 0x00A98AF9
		public FAnimNode_UseCachedPose AnimGraphNode_UseCachedPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_UseCachedPose result;
				if ((result = this._AnimGraphNode_UseCachedPose) == null)
				{
					result = (this._AnimGraphNode_UseCachedPose = new FAnimNode_UseCachedPose(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_130, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_UseCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_130, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007711 RID: 30481
		// (get) Token: 0x0602C3A7 RID: 181159 RVA: 0x00A9A91C File Offset: 0x00A98B1C
		// (set) Token: 0x0602C3A8 RID: 181160 RVA: 0x00A9A955 File Offset: 0x00A98B55
		public FAnimNode_StateResult AnimGraphNode_StateResult
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateResult result;
				if ((result = this._AnimGraphNode_StateResult) == null)
				{
					result = (this._AnimGraphNode_StateResult = new FAnimNode_StateResult(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_131, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateResult.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_131, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007712 RID: 30482
		// (get) Token: 0x0602C3A9 RID: 181161 RVA: 0x00A9A978 File Offset: 0x00A98B78
		// (set) Token: 0x0602C3AA RID: 181162 RVA: 0x00A9A9B1 File Offset: 0x00A98BB1
		public FAnimNode_StateMachine AnimGraphNode_StateMachine
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_StateMachine result;
				if ((result = this._AnimGraphNode_StateMachine) == null)
				{
					result = (this._AnimGraphNode_StateMachine = new FAnimNode_StateMachine(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_132, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_StateMachine.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_132, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007713 RID: 30483
		// (get) Token: 0x0602C3AB RID: 181163 RVA: 0x00A9A9D4 File Offset: 0x00A98BD4
		// (set) Token: 0x0602C3AC RID: 181164 RVA: 0x00A9AA0D File Offset: 0x00A98C0D
		public FAnimNode_SaveCachedPose AnimGraphNode_SaveCachedPose
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_SaveCachedPose result;
				if ((result = this._AnimGraphNode_SaveCachedPose) == null)
				{
					result = (this._AnimGraphNode_SaveCachedPose = new FAnimNode_SaveCachedPose(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_133, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_SaveCachedPose.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_133, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007714 RID: 30484
		// (get) Token: 0x0602C3AD RID: 181165 RVA: 0x00A9AA30 File Offset: 0x00A98C30
		// (set) Token: 0x0602C3AE RID: 181166 RVA: 0x00A9AA69 File Offset: 0x00A98C69
		public FAnimNode_Slot AnimGraphNode_Slot
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Slot result;
				if ((result = this._AnimGraphNode_Slot) == null)
				{
					result = (this._AnimGraphNode_Slot = new FAnimNode_Slot(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_134, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Slot.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_134, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007715 RID: 30485
		// (get) Token: 0x0602C3AF RID: 181167 RVA: 0x00A9AA8C File Offset: 0x00A98C8C
		// (set) Token: 0x0602C3B0 RID: 181168 RVA: 0x00A9AAC5 File Offset: 0x00A98CC5
		public FAnimNode_Inertialization AnimGraphNode_Inertialization
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Inertialization result;
				if ((result = this._AnimGraphNode_Inertialization) == null)
				{
					result = (this._AnimGraphNode_Inertialization = new FAnimNode_Inertialization(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_135, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Inertialization.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_135, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007716 RID: 30486
		// (get) Token: 0x0602C3B1 RID: 181169 RVA: 0x00A9AAE8 File Offset: 0x00A98CE8
		// (set) Token: 0x0602C3B2 RID: 181170 RVA: 0x00A9AB21 File Offset: 0x00A98D21
		public FAnimNode_Root AnimGraphNode_Root
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_Root result;
				if ((result = this._AnimGraphNode_Root) == null)
				{
					result = (this._AnimGraphNode_Root = new FAnimNode_Root(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_136, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_Root.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_136, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007717 RID: 30487
		// (get) Token: 0x0602C3B3 RID: 181171 RVA: 0x00A9AB44 File Offset: 0x00A98D44
		// (set) Token: 0x0602C3B4 RID: 181172 RVA: 0x00A9AB7D File Offset: 0x00A98D7D
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer_2
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer_2) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer_2 = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_137, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_137, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007718 RID: 30488
		// (get) Token: 0x0602C3B5 RID: 181173 RVA: 0x00A9ABA0 File Offset: 0x00A98DA0
		// (set) Token: 0x0602C3B6 RID: 181174 RVA: 0x00A9ABD9 File Offset: 0x00A98DD9
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer_1
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer_1) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer_1 = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_138, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_138, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007719 RID: 30489
		// (get) Token: 0x0602C3B7 RID: 181175 RVA: 0x00A9ABFC File Offset: 0x00A98DFC
		// (set) Token: 0x0602C3B8 RID: 181176 RVA: 0x00A9AC35 File Offset: 0x00A98E35
		public FAnimNode_LinkedAnimLayer AnimGraphNode_LinkedAnimLayer
		{
			get
			{
				base.FastCheckIsValid();
				FAnimNode_LinkedAnimLayer result;
				if ((result = this._AnimGraphNode_LinkedAnimLayer) == null)
				{
					result = (this._AnimGraphNode_LinkedAnimLayer = new FAnimNode_LinkedAnimLayer(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_139, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FAnimNode_LinkedAnimLayer.StaticStruct(), base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_139, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700771A RID: 30490
		// (get) Token: 0x0602C3B9 RID: 181177 RVA: 0x00A9AC58 File Offset: 0x00A98E58
		// (set) Token: 0x0602C3BA RID: 181178 RVA: 0x00A9AC91 File Offset: 0x00A98E91
		public TArray<UAnimSequence> 待机表演配置
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UAnimSequence> result;
				if ((result = this._待机表演配置) == null)
				{
					result = (this._待机表演配置 = new TArray<UAnimSequence>(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_140, this));
				}
				return result;
			}
			set
			{
				this.待机表演配置.CopyAssign(value);
			}
		}

		// Token: 0x1700771B RID: 30491
		// (get) Token: 0x0602C3BB RID: 181179 RVA: 0x00A9AC9F File Offset: 0x00A98E9F
		// (set) Token: 0x0602C3BC RID: 181180 RVA: 0x00A9ACB3 File Offset: 0x00A98EB3
		[Nullable(2)]
		public unsafe TsBaseCharacter 角色蓝图
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<TsBaseCharacter>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRunAnimal_C.__PropertyOffset_141);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRunAnimal_C.__PropertyOffset_141, value);
			}
		}

		// Token: 0x1700771C RID: 30492
		// (get) Token: 0x0602C3BD RID: 181181 RVA: 0x00A9ACC8 File Offset: 0x00A98EC8
		// (set) Token: 0x0602C3BE RID: 181182 RVA: 0x00A9ACDC File Offset: 0x00A98EDC
		[Nullable(2)]
		public unsafe USkeletalMeshComponent 角色网格体
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRunAnimal_C.__PropertyOffset_142);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRunAnimal_C.__PropertyOffset_142, value);
			}
		}

		// Token: 0x1700771D RID: 30493
		// (get) Token: 0x0602C3BF RID: 181183 RVA: 0x00A9ACF1 File Offset: 0x00A98EF1
		// (set) Token: 0x0602C3C0 RID: 181184 RVA: 0x00A9AD05 File Offset: 0x00A98F05
		[Nullable(0)]
		public unsafe TEnumAsByte<EAnimalEcologicalState> 生态表现状态
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_143);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_143) = value;
			}
		}

		// Token: 0x1700771E RID: 30494
		// (get) Token: 0x0602C3C1 RID: 181185 RVA: 0x00A9AD1A File Offset: 0x00A98F1A
		// (set) Token: 0x0602C3C2 RID: 181186 RVA: 0x00A9AD2A File Offset: 0x00A98F2A
		public unsafe bool 状态机初始化
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_144) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_144) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700771F RID: 30495
		// (get) Token: 0x0602C3C3 RID: 181187 RVA: 0x00A9AD3B File Offset: 0x00A98F3B
		// (set) Token: 0x0602C3C4 RID: 181188 RVA: 0x00A9AD4B File Offset: 0x00A98F4B
		public unsafe int IdleActionIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_145);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_145) = value;
			}
		}

		// Token: 0x17007720 RID: 30496
		// (get) Token: 0x0602C3C5 RID: 181189 RVA: 0x00A9AD5C File Offset: 0x00A98F5C
		// (set) Token: 0x0602C3C6 RID: 181190 RVA: 0x00A9AD70 File Offset: 0x00A98F70
		[Nullable(2)]
		public unsafe UAnimSequence IdleAnim
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAnimSequence>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRunAnimal_C.__PropertyOffset_146);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRunAnimal_C.__PropertyOffset_146, value);
			}
		}

		// Token: 0x17007721 RID: 30497
		// (get) Token: 0x0602C3C7 RID: 181191 RVA: 0x00A9AD88 File Offset: 0x00A98F88
		// (set) Token: 0x0602C3C8 RID: 181192 RVA: 0x00A9ADC1 File Offset: 0x00A98FC1
		public TArray<UAnimSequence> 交互表演配置
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UAnimSequence> result;
				if ((result = this._交互表演配置) == null)
				{
					result = (this._交互表演配置 = new TArray<UAnimSequence>(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_147, this));
				}
				return result;
			}
			set
			{
				this.交互表演配置.CopyAssign(value);
			}
		}

		// Token: 0x17007722 RID: 30498
		// (get) Token: 0x0602C3C9 RID: 181193 RVA: 0x00A9ADCF File Offset: 0x00A98FCF
		// (set) Token: 0x0602C3CA RID: 181194 RVA: 0x00A9ADDF File Offset: 0x00A98FDF
		public unsafe int InteractActionIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_148);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_148) = value;
			}
		}

		// Token: 0x17007723 RID: 30499
		// (get) Token: 0x0602C3CB RID: 181195 RVA: 0x00A9ADF0 File Offset: 0x00A98FF0
		// (set) Token: 0x0602C3CC RID: 181196 RVA: 0x00A9AE04 File Offset: 0x00A99004
		[Nullable(2)]
		public unsafe UAnimSequence InteractAnim
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAnimSequence>(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRunAnimal_C.__PropertyOffset_149);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + ABP_BaseRunAnimal_C.__PropertyOffset_149, value);
			}
		}

		// Token: 0x17007724 RID: 30500
		// (get) Token: 0x0602C3CD RID: 181197 RVA: 0x00A9AE19 File Offset: 0x00A99019
		// (set) Token: 0x0602C3CE RID: 181198 RVA: 0x00A9AE2D File Offset: 0x00A9902D
		public unsafe FVector SightDirect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_150);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_150) = value;
			}
		}

		// Token: 0x17007725 RID: 30501
		// (get) Token: 0x0602C3CF RID: 181199 RVA: 0x00A9AE42 File Offset: 0x00A99042
		// (set) Token: 0x0602C3D0 RID: 181200 RVA: 0x00A9AE52 File Offset: 0x00A99052
		public unsafe SightLockMode SightLockMode
		{
			get
			{
				return (SightLockMode)(*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_151));
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_151) = (byte)value;
			}
		}

		// Token: 0x17007726 RID: 30502
		// (get) Token: 0x0602C3D1 RID: 181201 RVA: 0x00A9AE63 File Offset: 0x00A99063
		// (set) Token: 0x0602C3D2 RID: 181202 RVA: 0x00A9AE73 File Offset: 0x00A99073
		public unsafe int WalkRunParam
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_152);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_152) = value;
			}
		}

		// Token: 0x17007727 RID: 30503
		// (get) Token: 0x0602C3D3 RID: 181203 RVA: 0x00A9AE84 File Offset: 0x00A99084
		// (set) Token: 0x0602C3D4 RID: 181204 RVA: 0x00A9AE94 File Offset: 0x00A99094
		public unsafe float 左右跑参数
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_153);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_153) = value;
			}
		}

		// Token: 0x17007728 RID: 30504
		// (get) Token: 0x0602C3D5 RID: 181205 RVA: 0x00A9AEA5 File Offset: 0x00A990A5
		// (set) Token: 0x0602C3D6 RID: 181206 RVA: 0x00A9AEB5 File Offset: 0x00A990B5
		public unsafe bool bHaveInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_154) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_154) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007729 RID: 30505
		// (get) Token: 0x0602C3D7 RID: 181207 RVA: 0x00A9AEC6 File Offset: 0x00A990C6
		// (set) Token: 0x0602C3D8 RID: 181208 RVA: 0x00A9AED6 File Offset: 0x00A990D6
		public unsafe bool bIdleAction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_155) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_155) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700772A RID: 30506
		// (get) Token: 0x0602C3D9 RID: 181209 RVA: 0x00A9AEE7 File Offset: 0x00A990E7
		// (set) Token: 0x0602C3DA RID: 181210 RVA: 0x00A9AEF7 File Offset: 0x00A990F7
		public unsafe bool 是否警觉
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_156) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_156) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700772B RID: 30507
		// (get) Token: 0x0602C3DB RID: 181211 RVA: 0x00A9AF08 File Offset: 0x00A99108
		// (set) Token: 0x0602C3DC RID: 181212 RVA: 0x00A9AF18 File Offset: 0x00A99118
		public unsafe bool 是否起跑转身
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_157) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_157) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700772C RID: 30508
		// (get) Token: 0x0602C3DD RID: 181213 RVA: 0x00A9AF29 File Offset: 0x00A99129
		// (set) Token: 0x0602C3DE RID: 181214 RVA: 0x00A9AF39 File Offset: 0x00A99139
		public unsafe bool 起跑左转
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_158) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_158) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700772D RID: 30509
		// (get) Token: 0x0602C3DF RID: 181215 RVA: 0x00A9AF4A File Offset: 0x00A9914A
		// (set) Token: 0x0602C3E0 RID: 181216 RVA: 0x00A9AF5A File Offset: 0x00A9915A
		public unsafe bool bInteractAction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_159) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_159) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700772E RID: 30510
		// (get) Token: 0x0602C3E1 RID: 181217 RVA: 0x00A9AF6B File Offset: 0x00A9916B
		// (set) Token: 0x0602C3E2 RID: 181218 RVA: 0x00A9AF7B File Offset: 0x00A9917B
		public unsafe bool 受到攻击
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_160) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_160) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700772F RID: 30511
		// (get) Token: 0x0602C3E3 RID: 181219 RVA: 0x00A9AF8C File Offset: 0x00A9918C
		// (set) Token: 0x0602C3E4 RID: 181220 RVA: 0x00A9AF9C File Offset: 0x00A9919C
		public unsafe bool 起飞
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_161) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_161) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007730 RID: 30512
		// (get) Token: 0x0602C3E5 RID: 181221 RVA: 0x00A9AFAD File Offset: 0x00A991AD
		// (set) Token: 0x0602C3E6 RID: 181222 RVA: 0x00A9AFBD File Offset: 0x00A991BD
		public unsafe bool bSitDown
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_162) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_162) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007731 RID: 30513
		// (get) Token: 0x0602C3E7 RID: 181223 RVA: 0x00A9AFD0 File Offset: 0x00A991D0
		// (set) Token: 0x0602C3E8 RID: 181224 RVA: 0x00A9B009 File Offset: 0x00A99209
		public TMap<FGameplayTag, UAnimSequence> 其他动作配置
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, UAnimSequence> result;
				if ((result = this._其他动作配置) == null)
				{
					result = (this._其他动作配置 = new TMap<FGameplayTag, UAnimSequence>(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_163, this));
				}
				return result;
			}
			set
			{
				this.其他动作配置.CopyAssign(value);
			}
		}

		// Token: 0x17007732 RID: 30514
		// (get) Token: 0x0602C3E9 RID: 181225 RVA: 0x00A9B017 File Offset: 0x00A99217
		// (set) Token: 0x0602C3EA RID: 181226 RVA: 0x00A9B027 File Offset: 0x00A99227
		public unsafe float ActionTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_164);
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_164) = value;
			}
		}

		// Token: 0x17007733 RID: 30515
		// (get) Token: 0x0602C3EB RID: 181227 RVA: 0x00A9B038 File Offset: 0x00A99238
		// (set) Token: 0x0602C3EC RID: 181228 RVA: 0x00A9B071 File Offset: 0x00A99271
		public TMap<FGameplayTag, TSoftObjectPtr<PD_CharacterControllerData_C>> 材质配置
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, TSoftObjectPtr<PD_CharacterControllerData_C>> result;
				if ((result = this._材质配置) == null)
				{
					result = (this._材质配置 = new TMap<FGameplayTag, TSoftObjectPtr<PD_CharacterControllerData_C>>(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_165, this));
				}
				return result;
			}
			set
			{
				this.材质配置.CopyAssign(value);
			}
		}

		// Token: 0x17007734 RID: 30516
		// (get) Token: 0x0602C3ED RID: 181229 RVA: 0x00A9B080 File Offset: 0x00A99280
		// (set) Token: 0x0602C3EE RID: 181230 RVA: 0x00A9B0B9 File Offset: 0x00A992B9
		public TMap<FGameplayTag, UAnimMontage> 蒙太奇表演配置
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, UAnimMontage> result;
				if ((result = this._蒙太奇表演配置) == null)
				{
					result = (this._蒙太奇表演配置 = new TMap<FGameplayTag, UAnimMontage>(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_166, this));
				}
				return result;
			}
			set
			{
				this.蒙太奇表演配置.CopyAssign(value);
			}
		}

		// Token: 0x17007735 RID: 30517
		// (get) Token: 0x0602C3EF RID: 181231 RVA: 0x00A9B0C7 File Offset: 0x00A992C7
		// (set) Token: 0x0602C3F0 RID: 181232 RVA: 0x00A9B0D7 File Offset: 0x00A992D7
		public unsafe bool 系统UI
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_167) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_167) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007736 RID: 30518
		// (get) Token: 0x0602C3F1 RID: 181233 RVA: 0x00A9B0E8 File Offset: 0x00A992E8
		// (set) Token: 0x0602C3F2 RID: 181234 RVA: 0x00A9B0F8 File Offset: 0x00A992F8
		public unsafe bool bGetDown
		{
			get
			{
				return *(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_168) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)ABP_BaseRunAnimal_C.__PropertyOffset_168) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602C3F3 RID: 181235 RVA: 0x00A9B10C File Offset: 0x00A9930C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetCurrentActionTime(ref float ActionTime)
		{
			ABP_BaseRunAnimal_C.__GetCurrentActionTime_FunctionParams* ptr = stackalloc ABP_BaseRunAnimal_C.__GetCurrentActionTime_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseRunAnimal_C.__GetCurrentActionTime_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRunAnimal_C.__GetCurrentActionTime_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ActionTime = ActionTime;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__GetCurrentActionTime_NativeFunctionPtr, (void*)ptr);
			ActionTime = ptr->ActionTime;
		}

		// Token: 0x0602C3F4 RID: 181236 RVA: 0x00A9B15C File Offset: 0x00A9935C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 演出层(FPoseLink 状态机输入, ref FPoseLink 演出层)
		{
			ABP_BaseRunAnimal_C.__演出层_FunctionParams* ptr = stackalloc ABP_BaseRunAnimal_C.__演出层_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ABP_BaseRunAnimal_C.__演出层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRunAnimal_C.__演出层_NativeFunctionPtr, (void*)ptr, 1);
			if (状态机输入 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->状态机输入, 状态机输入.NativePtr, 1, false);
			}
			if (演出层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->演出层, 演出层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__演出层_NativeFunctionPtr, (void*)ptr);
			if (演出层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 演出层.NativePtr, &ptr->演出层, 1, false);
			}
		}

		// Token: 0x0602C3F5 RID: 181237 RVA: 0x00A9B208 File Offset: 0x00A99408
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 后处理层(FPoseLink 基础输入, ref FPoseLink 后处理层)
		{
			ABP_BaseRunAnimal_C.__后处理层_FunctionParams* ptr = stackalloc ABP_BaseRunAnimal_C.__后处理层_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(ABP_BaseRunAnimal_C.__后处理层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRunAnimal_C.__后处理层_NativeFunctionPtr, (void*)ptr, 1);
			if (基础输入 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->基础输入, 基础输入.NativePtr, 1, false);
			}
			if (后处理层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->后处理层, 后处理层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__后处理层_NativeFunctionPtr, (void*)ptr);
			if (后处理层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 后处理层.NativePtr, &ptr->后处理层, 1, false);
			}
		}

		// Token: 0x0602C3F6 RID: 181238 RVA: 0x00A9B2B4 File Offset: 0x00A994B4
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void 基础层(ref FPoseLink 基础层)
		{
			ABP_BaseRunAnimal_C.__基础层_FunctionParams* ptr = stackalloc ABP_BaseRunAnimal_C.__基础层_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseRunAnimal_C.__基础层_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRunAnimal_C.__基础层_NativeFunctionPtr, (void*)ptr, 1);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->基础层, 基础层.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__基础层_NativeFunctionPtr, (void*)ptr);
			if (基础层 != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), 基础层.NativePtr, &ptr->基础层, 1, false);
			}
		}

		// Token: 0x0602C3F7 RID: 181239 RVA: 0x00A9B33C File Offset: 0x00A9953C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void AnimGraph(ref FPoseLink AnimGraph)
		{
			ABP_BaseRunAnimal_C.__AnimGraph_FunctionParams* ptr = stackalloc ABP_BaseRunAnimal_C.__AnimGraph_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(ABP_BaseRunAnimal_C.__AnimGraph_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRunAnimal_C.__AnimGraph_NativeFunctionPtr, (void*)ptr, 1);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), &ptr->AnimGraph, AnimGraph.NativePtr, 1, false);
			}
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__AnimGraph_NativeFunctionPtr, (void*)ptr);
			if (AnimGraph != null)
			{
				UnrealReflectionUtils.CopyNativeStruct(FPoseLink.StaticStruct(), AnimGraph.NativePtr, &ptr->AnimGraph, 1, false);
			}
		}

		// Token: 0x0602C3F8 RID: 181240 RVA: 0x00A9B3C3 File Offset: 0x00A995C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnSystemUIStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__OnSystemUIStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C3F9 RID: 181241 RVA: 0x00A9B3D8 File Offset: 0x00A995D8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnFeedStart(FGameplayTag GameplayTag)
		{
			ABP_BaseRunAnimal_C.__OnFeedStart_FunctionParams* ptr = stackalloc ABP_BaseRunAnimal_C.__OnFeedStart_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(ABP_BaseRunAnimal_C.__OnFeedStart_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRunAnimal_C.__OnFeedStart_NativeFunctionPtr, (void*)ptr, 1);
			ptr->GameplayTag = GameplayTag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__OnFeedStart_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C3FA RID: 181242 RVA: 0x00A9B41E File Offset: 0x00A9961E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新移动信息()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__更新移动信息_NativeFunctionPtr, null);
		}

		// Token: 0x0602C3FB RID: 181243 RVA: 0x00A9B432 File Offset: 0x00A99632
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 处理动作优先级()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__处理动作优先级_NativeFunctionPtr, null);
		}

		// Token: 0x0602C3FC RID: 181244 RVA: 0x00A9B446 File Offset: 0x00A99646
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnUnderAttackStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__OnUnderAttackStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C3FD RID: 181245 RVA: 0x00A9B45A File Offset: 0x00A9965A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnTakeOffStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__OnTakeOffStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C3FE RID: 181246 RVA: 0x00A9B46E File Offset: 0x00A9966E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnAlertStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__OnAlertStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C3FF RID: 181247 RVA: 0x00A9B482 File Offset: 0x00A99682
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新视线()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__更新视线_NativeFunctionPtr, null);
		}

		// Token: 0x0602C400 RID: 181248 RVA: 0x00A9B496 File Offset: 0x00A99696
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnInteractStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__OnInteractStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C401 RID: 181249 RVA: 0x00A9B4AA File Offset: 0x00A996AA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新特殊交互表演()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__更新特殊交互表演_NativeFunctionPtr, null);
		}

		// Token: 0x0602C402 RID: 181250 RVA: 0x00A9B4BE File Offset: 0x00A996BE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新交互表演()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__更新交互表演_NativeFunctionPtr, null);
		}

		// Token: 0x0602C403 RID: 181251 RVA: 0x00A9B4D2 File Offset: 0x00A996D2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void OnIdleStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__OnIdleStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C404 RID: 181252 RVA: 0x00A9B4E6 File Offset: 0x00A996E6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 更新待机表演()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__更新待机表演_NativeFunctionPtr, null);
		}

		// Token: 0x0602C405 RID: 181253 RVA: 0x00A9B4FA File Offset: 0x00A996FA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TakeOffEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__TakeOffEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C406 RID: 181254 RVA: 0x00A9B50E File Offset: 0x00A9970E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AlertEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__AlertEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C407 RID: 181255 RVA: 0x00A9B522 File Offset: 0x00A99722
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UnderAttackEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__UnderAttackEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C408 RID: 181256 RVA: 0x00A9B536 File Offset: 0x00A99736
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void IdleEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__IdleEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C409 RID: 181257 RVA: 0x00A9B54A File Offset: 0x00A9974A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InteractEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__InteractEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C40A RID: 181258 RVA: 0x00A9B55E File Offset: 0x00A9975E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void NoneStateEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__NoneStateEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C40B RID: 181259 RVA: 0x00A9B572 File Offset: 0x00A99772
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_D54499E04BD261C3638E51BCC167F397()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_D54499E04BD261C3638E51BCC167F397_NativeFunctionPtr, null);
		}

		// Token: 0x0602C40C RID: 181260 RVA: 0x00A9B586 File Offset: 0x00A99786
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_30F574864082A787DF7CC1BAB8BC0A53()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_30F574864082A787DF7CC1BAB8BC0A53_NativeFunctionPtr, null);
		}

		// Token: 0x0602C40D RID: 181261 RVA: 0x00A9B59A File Offset: 0x00A9979A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_B95B1327437100986649B89B92ECCF23()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_B95B1327437100986649B89B92ECCF23_NativeFunctionPtr, null);
		}

		// Token: 0x0602C40E RID: 181262 RVA: 0x00A9B5AE File Offset: 0x00A997AE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_C20382F940EEADA6AE673D9A81210F1C()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_C20382F940EEADA6AE673D9A81210F1C_NativeFunctionPtr, null);
		}

		// Token: 0x0602C40F RID: 181263 RVA: 0x00A9B5C2 File Offset: 0x00A997C2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_EA2A46454076B45705487189EC6FFD84()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_EA2A46454076B45705487189EC6FFD84_NativeFunctionPtr, null);
		}

		// Token: 0x0602C410 RID: 181264 RVA: 0x00A9B5D6 File Offset: 0x00A997D6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_0D2B24D4481CD55B42A27EA779A7F1CF()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_0D2B24D4481CD55B42A27EA779A7F1CF_NativeFunctionPtr, null);
		}

		// Token: 0x0602C411 RID: 181265 RVA: 0x00A9B5EA File Offset: 0x00A997EA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_F9A2310E4B85152CFCC97A84EDB7EF56()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_F9A2310E4B85152CFCC97A84EDB7EF56_NativeFunctionPtr, null);
		}

		// Token: 0x0602C412 RID: 181266 RVA: 0x00A9B5FE File Offset: 0x00A997FE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_9A890530410B3CD6D4797A8538EA342B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_9A890530410B3CD6D4797A8538EA342B_NativeFunctionPtr, null);
		}

		// Token: 0x0602C413 RID: 181267 RVA: 0x00A9B612 File Offset: 0x00A99812
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_180425454EE441A421DD628DD53FE2A8()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_180425454EE441A421DD628DD53FE2A8_NativeFunctionPtr, null);
		}

		// Token: 0x0602C414 RID: 181268 RVA: 0x00A9B626 File Offset: 0x00A99826
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_EF45970F4ABF89776F29558C1C276842()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_EF45970F4ABF89776F29558C1C276842_NativeFunctionPtr, null);
		}

		// Token: 0x0602C415 RID: 181269 RVA: 0x00A9B63A File Offset: 0x00A9983A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_BAAC30DF4E867493C9C3B28B403F1A52()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_BAAC30DF4E867493C9C3B28B403F1A52_NativeFunctionPtr, null);
		}

		// Token: 0x0602C416 RID: 181270 RVA: 0x00A9B64E File Offset: 0x00A9984E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_6E0C55ED464D77C9403BE39A42AA3EC2()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_6E0C55ED464D77C9403BE39A42AA3EC2_NativeFunctionPtr, null);
		}

		// Token: 0x0602C417 RID: 181271 RVA: 0x00A9B662 File Offset: 0x00A99862
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_9E7C77CA4ACF6F50475B2CA51B365D84()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_9E7C77CA4ACF6F50475B2CA51B365D84_NativeFunctionPtr, null);
		}

		// Token: 0x0602C418 RID: 181272 RVA: 0x00A9B676 File Offset: 0x00A99876
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_4707A7A14AE382D2DE16B59F280E1AD6()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_4707A7A14AE382D2DE16B59F280E1AD6_NativeFunctionPtr, null);
		}

		// Token: 0x0602C419 RID: 181273 RVA: 0x00A9B68A File Offset: 0x00A9988A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_9900DD464E49EA09E2D4F8B18CDD31D1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_9900DD464E49EA09E2D4F8B18CDD31D1_NativeFunctionPtr, null);
		}

		// Token: 0x0602C41A RID: 181274 RVA: 0x00A9B69E File Offset: 0x00A9989E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_A9CDC89D403878652E814AB43DD421B4()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_A9CDC89D403878652E814AB43DD421B4_NativeFunctionPtr, null);
		}

		// Token: 0x0602C41B RID: 181275 RVA: 0x00A9B6B2 File Offset: 0x00A998B2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_0709478946319BBF0BF840B801DAEB35()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_0709478946319BBF0BF840B801DAEB35_NativeFunctionPtr, null);
		}

		// Token: 0x0602C41C RID: 181276 RVA: 0x00A9B6C6 File Offset: 0x00A998C6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_E8377F0B4C84C5DD4196CFB2E7D44CE1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_E8377F0B4C84C5DD4196CFB2E7D44CE1_NativeFunctionPtr, null);
		}

		// Token: 0x0602C41D RID: 181277 RVA: 0x00A9B6DA File Offset: 0x00A998DA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_A1CFEFA64D4BEA034EF84FA14A3FC792()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_A1CFEFA64D4BEA034EF84FA14A3FC792_NativeFunctionPtr, null);
		}

		// Token: 0x0602C41E RID: 181278 RVA: 0x00A9B6EE File Offset: 0x00A998EE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_8AC447DA43E1891D7082A4A39EA70C17()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_8AC447DA43E1891D7082A4A39EA70C17_NativeFunctionPtr, null);
		}

		// Token: 0x0602C41F RID: 181279 RVA: 0x00A9B702 File Offset: 0x00A99902
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_0ACCD1B64E226DCBB6EA51B0CD6F4921()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_0ACCD1B64E226DCBB6EA51B0CD6F4921_NativeFunctionPtr, null);
		}

		// Token: 0x0602C420 RID: 181280 RVA: 0x00A9B716 File Offset: 0x00A99916
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_D21B71CF41005EC9DEDCF4A84C6C53BB()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_D21B71CF41005EC9DEDCF4A84C6C53BB_NativeFunctionPtr, null);
		}

		// Token: 0x0602C421 RID: 181281 RVA: 0x00A9B72A File Offset: 0x00A9992A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_8E184F0C41B02556120BDDBC613B703B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_8E184F0C41B02556120BDDBC613B703B_NativeFunctionPtr, null);
		}

		// Token: 0x0602C422 RID: 181282 RVA: 0x00A9B73E File Offset: 0x00A9993E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_19866BA345A7023365D45CB3DD10B5A1()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_19866BA345A7023365D45CB3DD10B5A1_NativeFunctionPtr, null);
		}

		// Token: 0x0602C423 RID: 181283 RVA: 0x00A9B752 File Offset: 0x00A99952
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_24B8E9944172EB4335ED6593E3F8BD4F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_24B8E9944172EB4335ED6593E3F8BD4F_NativeFunctionPtr, null);
		}

		// Token: 0x0602C424 RID: 181284 RVA: 0x00A9B766 File Offset: 0x00A99966
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_4E467B6A4ACBC58853AA6B8CC429A7D5()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_4E467B6A4ACBC58853AA6B8CC429A7D5_NativeFunctionPtr, null);
		}

		// Token: 0x0602C425 RID: 181285 RVA: 0x00A9B77A File Offset: 0x00A9997A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_261082164D250FB062E641B2CB98C549()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_261082164D250FB062E641B2CB98C549_NativeFunctionPtr, null);
		}

		// Token: 0x0602C426 RID: 181286 RVA: 0x00A9B78E File Offset: 0x00A9998E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_96DA532746BB03936925F4B0F5E24F48()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_96DA532746BB03936925F4B0F5E24F48_NativeFunctionPtr, null);
		}

		// Token: 0x0602C427 RID: 181287 RVA: 0x00A9B7A2 File Offset: 0x00A999A2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_99C64F1245BA6F14C220E9B82D2B3FCC()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_99C64F1245BA6F14C220E9B82D2B3FCC_NativeFunctionPtr, null);
		}

		// Token: 0x0602C428 RID: 181288 RVA: 0x00A9B7B6 File Offset: 0x00A999B6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_13A3A0424C3B5022728779A87FFE2552()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_13A3A0424C3B5022728779A87FFE2552_NativeFunctionPtr, null);
		}

		// Token: 0x0602C429 RID: 181289 RVA: 0x00A9B7CA File Offset: 0x00A999CA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_5C72ADEB48A9244F8F798D846651569B()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_5C72ADEB48A9244F8F798D846651569B_NativeFunctionPtr, null);
		}

		// Token: 0x0602C42A RID: 181290 RVA: 0x00A9B7DE File Offset: 0x00A999DE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_80410EA34013BBCB391AAAB1C368CC57()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_80410EA34013BBCB391AAAB1C368CC57_NativeFunctionPtr, null);
		}

		// Token: 0x0602C42B RID: 181291 RVA: 0x00A9B7F2 File Offset: 0x00A999F2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_917F2B9D41AF9EC87991898BD6C207E9()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_917F2B9D41AF9EC87991898BD6C207E9_NativeFunctionPtr, null);
		}

		// Token: 0x0602C42C RID: 181292 RVA: 0x00A9B806 File Offset: 0x00A99A06
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_368E31B5474BC72509A5519B64E3794A()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_368E31B5474BC72509A5519B64E3794A_NativeFunctionPtr, null);
		}

		// Token: 0x0602C42D RID: 181293 RVA: 0x00A9B81A File Offset: 0x00A99A1A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_10D6FB8E421C0AD65B82EA8700ABB24F()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_10D6FB8E421C0AD65B82EA8700ABB24F_NativeFunctionPtr, null);
		}

		// Token: 0x0602C42E RID: 181294 RVA: 0x00A9B82E File Offset: 0x00A99A2E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_Animal_IdleActionEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__AnimNotify_Animal_IdleActionEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C42F RID: 181295 RVA: 0x00A9B842 File Offset: 0x00A99A42
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_Animal_InteractActionEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__AnimNotify_Animal_InteractActionEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C430 RID: 181296 RVA: 0x00A9B856 File Offset: 0x00A99A56
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_Animal_AlertEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__AnimNotify_Animal_AlertEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C431 RID: 181297 RVA: 0x00A9B86A File Offset: 0x00A99A6A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AnimNotify_Animal_UnderAttackEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__AnimNotify_Animal_UnderAttackEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C432 RID: 181298 RVA: 0x00A9B87E File Offset: 0x00A99A7E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void BlueprintInitializeAnimation()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null);
		}

		// Token: 0x0602C433 RID: 181299 RVA: 0x00A9B892 File Offset: 0x00A99A92
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void BlueprintInitializeAnimation_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__BlueprintInitializeAnimation_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C434 RID: 181300 RVA: 0x00A9B8A8 File Offset: 0x00A99AA8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void BlueprintUpdateAnimation(float DeltaTimeX)
		{
			ABP_BaseRunAnimal_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseRunAnimal_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseRunAnimal_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRunAnimal_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C435 RID: 181301 RVA: 0x00A9B8F0 File Offset: 0x00A99AF0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void BlueprintUpdateAnimation_Implementation(float DeltaTimeX)
		{
			ABP_BaseRunAnimal_C.__BlueprintUpdateAnimation_FunctionParams* ptr = stackalloc ABP_BaseRunAnimal_C.__BlueprintUpdateAnimation_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(ABP_BaseRunAnimal_C.__BlueprintUpdateAnimation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRunAnimal_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTimeX = DeltaTimeX;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__BlueprintUpdateAnimation_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C436 RID: 181302 RVA: 0x00A9B937 File Offset: 0x00A99B37
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StateMachineInitializationComplete()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__StateMachineInitializationComplete_NativeFunctionPtr, null);
		}

		// Token: 0x0602C437 RID: 181303 RVA: 0x00A9B94B File Offset: 0x00A99B4B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void NoneStateStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__NoneStateStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C438 RID: 181304 RVA: 0x00A9B95F File Offset: 0x00A99B5F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void InteractStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__InteractStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C439 RID: 181305 RVA: 0x00A9B973 File Offset: 0x00A99B73
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void IdleStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__IdleStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C43A RID: 181306 RVA: 0x00A9B987 File Offset: 0x00A99B87
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UnderAttackStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__UnderAttackStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C43B RID: 181307 RVA: 0x00A9B99B File Offset: 0x00A99B9B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void AlertStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__AlertStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C43C RID: 181308 RVA: 0x00A9B9AF File Offset: 0x00A99BAF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void TakeOffStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__TakeOffStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C43D RID: 181309 RVA: 0x00A9B9C4 File Offset: 0x00A99BC4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void FeedStart(FGameplayTag GameplayTag)
		{
			ABP_BaseRunAnimal_C.__FeedStart_FunctionParams* ptr = stackalloc ABP_BaseRunAnimal_C.__FeedStart_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(ABP_BaseRunAnimal_C.__FeedStart_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRunAnimal_C.__FeedStart_NativeFunctionPtr, (void*)ptr, 1);
			ptr->GameplayTag = GameplayTag;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__FeedStart_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C43E RID: 181310 RVA: 0x00A9BA0A File Offset: 0x00A99C0A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SystemUiStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__SystemUiStart_NativeFunctionPtr, null);
		}

		// Token: 0x0602C43F RID: 181311 RVA: 0x00A9BA1E File Offset: 0x00A99C1E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void SystemUiEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__SystemUiEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C440 RID: 181312 RVA: 0x00A9BA34 File Offset: 0x00A99C34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_ABP_BaseRunAnimal(int EntryPoint)
		{
			ABP_BaseRunAnimal_C.__ExecuteUbergraph_ABP_BaseRunAnimal_FunctionParams* ptr = stackalloc ABP_BaseRunAnimal_C.__ExecuteUbergraph_ABP_BaseRunAnimal_FunctionParams[(UIntPtr)255] + 15L / (long)sizeof(ABP_BaseRunAnimal_C.__ExecuteUbergraph_ABP_BaseRunAnimal_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(ABP_BaseRunAnimal_C.__ExecuteUbergraph_ABP_BaseRunAnimal_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, ABP_BaseRunAnimal_C.__ExecuteUbergraph_ABP_BaseRunAnimal_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C441 RID: 181313 RVA: 0x00A9BA7E File Offset: 0x00A99C7E
		protected ABP_BaseRunAnimal_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018741 RID: 100161
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/ABP_BaseRunAnimal.ABP_BaseRunAnimal_C";

		// Token: 0x04018742 RID: 100162
		private static IntPtr _ClassPtr;

		// Token: 0x04018743 RID: 100163
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018744 RID: 100164
		internal static int __PropertyOffset_0;

		// Token: 0x04018745 RID: 100165
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018746 RID: 100166
		internal static int __PropertyOffset_1;

		// Token: 0x04018747 RID: 100167
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_3;

		// Token: 0x04018748 RID: 100168
		internal static int __PropertyOffset_2;

		// Token: 0x04018749 RID: 100169
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose_1;

		// Token: 0x0401874A RID: 100170
		internal static int __PropertyOffset_3;

		// Token: 0x0401874B RID: 100171
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_2;

		// Token: 0x0401874C RID: 100172
		internal static int __PropertyOffset_4;

		// Token: 0x0401874D RID: 100173
		[Nullable(2)]
		private FAnimNode_SightLock _AnimGraphNode_SightLock;

		// Token: 0x0401874E RID: 100174
		internal static int __PropertyOffset_5;

		// Token: 0x0401874F RID: 100175
		[Nullable(2)]
		private FAnimNode_ConvertLocalToComponentSpace _AnimGraphNode_LocalToComponentSpace;

		// Token: 0x04018750 RID: 100176
		internal static int __PropertyOffset_6;

		// Token: 0x04018751 RID: 100177
		[Nullable(2)]
		private FAnimNode_ConvertComponentToLocalSpace _AnimGraphNode_ComponentToLocalSpace;

		// Token: 0x04018752 RID: 100178
		internal static int __PropertyOffset_7;

		// Token: 0x04018753 RID: 100179
		[Nullable(2)]
		private FAnimNode_LinkedInputPose _AnimGraphNode_LinkedInputPose;

		// Token: 0x04018754 RID: 100180
		internal static int __PropertyOffset_8;

		// Token: 0x04018755 RID: 100181
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root_1;

		// Token: 0x04018756 RID: 100182
		internal static int __PropertyOffset_9;

		// Token: 0x04018757 RID: 100183
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_53;

		// Token: 0x04018758 RID: 100184
		internal static int __PropertyOffset_10;

		// Token: 0x04018759 RID: 100185
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_52;

		// Token: 0x0401875A RID: 100186
		internal static int __PropertyOffset_11;

		// Token: 0x0401875B RID: 100187
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_51;

		// Token: 0x0401875C RID: 100188
		internal static int __PropertyOffset_12;

		// Token: 0x0401875D RID: 100189
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_50;

		// Token: 0x0401875E RID: 100190
		internal static int __PropertyOffset_13;

		// Token: 0x0401875F RID: 100191
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_49;

		// Token: 0x04018760 RID: 100192
		internal static int __PropertyOffset_14;

		// Token: 0x04018761 RID: 100193
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_48;

		// Token: 0x04018762 RID: 100194
		internal static int __PropertyOffset_15;

		// Token: 0x04018763 RID: 100195
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_47;

		// Token: 0x04018764 RID: 100196
		internal static int __PropertyOffset_16;

		// Token: 0x04018765 RID: 100197
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_46;

		// Token: 0x04018766 RID: 100198
		internal static int __PropertyOffset_17;

		// Token: 0x04018767 RID: 100199
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_25;

		// Token: 0x04018768 RID: 100200
		internal static int __PropertyOffset_18;

		// Token: 0x04018769 RID: 100201
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_32;

		// Token: 0x0401876A RID: 100202
		internal static int __PropertyOffset_19;

		// Token: 0x0401876B RID: 100203
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_24;

		// Token: 0x0401876C RID: 100204
		internal static int __PropertyOffset_20;

		// Token: 0x0401876D RID: 100205
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_31;

		// Token: 0x0401876E RID: 100206
		internal static int __PropertyOffset_21;

		// Token: 0x0401876F RID: 100207
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_23;

		// Token: 0x04018770 RID: 100208
		internal static int __PropertyOffset_22;

		// Token: 0x04018771 RID: 100209
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_30;

		// Token: 0x04018772 RID: 100210
		internal static int __PropertyOffset_23;

		// Token: 0x04018773 RID: 100211
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_22;

		// Token: 0x04018774 RID: 100212
		internal static int __PropertyOffset_24;

		// Token: 0x04018775 RID: 100213
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_29;

		// Token: 0x04018776 RID: 100214
		internal static int __PropertyOffset_25;

		// Token: 0x04018777 RID: 100215
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_21;

		// Token: 0x04018778 RID: 100216
		internal static int __PropertyOffset_26;

		// Token: 0x04018779 RID: 100217
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_28;

		// Token: 0x0401877A RID: 100218
		internal static int __PropertyOffset_27;

		// Token: 0x0401877B RID: 100219
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_20;

		// Token: 0x0401877C RID: 100220
		internal static int __PropertyOffset_28;

		// Token: 0x0401877D RID: 100221
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_27;

		// Token: 0x0401877E RID: 100222
		internal static int __PropertyOffset_29;

		// Token: 0x0401877F RID: 100223
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_19;

		// Token: 0x04018780 RID: 100224
		internal static int __PropertyOffset_30;

		// Token: 0x04018781 RID: 100225
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_26;

		// Token: 0x04018782 RID: 100226
		internal static int __PropertyOffset_31;

		// Token: 0x04018783 RID: 100227
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_4;

		// Token: 0x04018784 RID: 100228
		internal static int __PropertyOffset_32;

		// Token: 0x04018785 RID: 100229
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_45;

		// Token: 0x04018786 RID: 100230
		internal static int __PropertyOffset_33;

		// Token: 0x04018787 RID: 100231
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_44;

		// Token: 0x04018788 RID: 100232
		internal static int __PropertyOffset_34;

		// Token: 0x04018789 RID: 100233
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_43;

		// Token: 0x0401878A RID: 100234
		internal static int __PropertyOffset_35;

		// Token: 0x0401878B RID: 100235
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_42;

		// Token: 0x0401878C RID: 100236
		internal static int __PropertyOffset_36;

		// Token: 0x0401878D RID: 100237
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_41;

		// Token: 0x0401878E RID: 100238
		internal static int __PropertyOffset_37;

		// Token: 0x0401878F RID: 100239
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_40;

		// Token: 0x04018790 RID: 100240
		internal static int __PropertyOffset_38;

		// Token: 0x04018791 RID: 100241
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_39;

		// Token: 0x04018792 RID: 100242
		internal static int __PropertyOffset_39;

		// Token: 0x04018793 RID: 100243
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_38;

		// Token: 0x04018794 RID: 100244
		internal static int __PropertyOffset_40;

		// Token: 0x04018795 RID: 100245
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_37;

		// Token: 0x04018796 RID: 100246
		internal static int __PropertyOffset_41;

		// Token: 0x04018797 RID: 100247
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_36;

		// Token: 0x04018798 RID: 100248
		internal static int __PropertyOffset_42;

		// Token: 0x04018799 RID: 100249
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_35;

		// Token: 0x0401879A RID: 100250
		internal static int __PropertyOffset_43;

		// Token: 0x0401879B RID: 100251
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_34;

		// Token: 0x0401879C RID: 100252
		internal static int __PropertyOffset_44;

		// Token: 0x0401879D RID: 100253
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_33;

		// Token: 0x0401879E RID: 100254
		internal static int __PropertyOffset_45;

		// Token: 0x0401879F RID: 100255
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_32;

		// Token: 0x040187A0 RID: 100256
		internal static int __PropertyOffset_46;

		// Token: 0x040187A1 RID: 100257
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_31;

		// Token: 0x040187A2 RID: 100258
		internal static int __PropertyOffset_47;

		// Token: 0x040187A3 RID: 100259
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_30;

		// Token: 0x040187A4 RID: 100260
		internal static int __PropertyOffset_48;

		// Token: 0x040187A5 RID: 100261
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_29;

		// Token: 0x040187A6 RID: 100262
		internal static int __PropertyOffset_49;

		// Token: 0x040187A7 RID: 100263
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_28;

		// Token: 0x040187A8 RID: 100264
		internal static int __PropertyOffset_50;

		// Token: 0x040187A9 RID: 100265
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_27;

		// Token: 0x040187AA RID: 100266
		internal static int __PropertyOffset_51;

		// Token: 0x040187AB RID: 100267
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_18;

		// Token: 0x040187AC RID: 100268
		internal static int __PropertyOffset_52;

		// Token: 0x040187AD RID: 100269
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_25;

		// Token: 0x040187AE RID: 100270
		internal static int __PropertyOffset_53;

		// Token: 0x040187AF RID: 100271
		[Nullable(2)]
		private FAnimNode_SequenceEvaluator _AnimGraphNode_SequenceEvaluator_1;

		// Token: 0x040187B0 RID: 100272
		internal static int __PropertyOffset_54;

		// Token: 0x040187B1 RID: 100273
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_24;

		// Token: 0x040187B2 RID: 100274
		internal static int __PropertyOffset_55;

		// Token: 0x040187B3 RID: 100275
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_17;

		// Token: 0x040187B4 RID: 100276
		internal static int __PropertyOffset_56;

		// Token: 0x040187B5 RID: 100277
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_23;

		// Token: 0x040187B6 RID: 100278
		internal static int __PropertyOffset_57;

		// Token: 0x040187B7 RID: 100279
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_16;

		// Token: 0x040187B8 RID: 100280
		internal static int __PropertyOffset_58;

		// Token: 0x040187B9 RID: 100281
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_22;

		// Token: 0x040187BA RID: 100282
		internal static int __PropertyOffset_59;

		// Token: 0x040187BB RID: 100283
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_15;

		// Token: 0x040187BC RID: 100284
		internal static int __PropertyOffset_60;

		// Token: 0x040187BD RID: 100285
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_21;

		// Token: 0x040187BE RID: 100286
		internal static int __PropertyOffset_61;

		// Token: 0x040187BF RID: 100287
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_14;

		// Token: 0x040187C0 RID: 100288
		internal static int __PropertyOffset_62;

		// Token: 0x040187C1 RID: 100289
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_20;

		// Token: 0x040187C2 RID: 100290
		internal static int __PropertyOffset_63;

		// Token: 0x040187C3 RID: 100291
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_13;

		// Token: 0x040187C4 RID: 100292
		internal static int __PropertyOffset_64;

		// Token: 0x040187C5 RID: 100293
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_19;

		// Token: 0x040187C6 RID: 100294
		internal static int __PropertyOffset_65;

		// Token: 0x040187C7 RID: 100295
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_3;

		// Token: 0x040187C8 RID: 100296
		internal static int __PropertyOffset_66;

		// Token: 0x040187C9 RID: 100297
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_18;

		// Token: 0x040187CA RID: 100298
		internal static int __PropertyOffset_67;

		// Token: 0x040187CB RID: 100299
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_26;

		// Token: 0x040187CC RID: 100300
		internal static int __PropertyOffset_68;

		// Token: 0x040187CD RID: 100301
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_25;

		// Token: 0x040187CE RID: 100302
		internal static int __PropertyOffset_69;

		// Token: 0x040187CF RID: 100303
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_24;

		// Token: 0x040187D0 RID: 100304
		internal static int __PropertyOffset_70;

		// Token: 0x040187D1 RID: 100305
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_23;

		// Token: 0x040187D2 RID: 100306
		internal static int __PropertyOffset_71;

		// Token: 0x040187D3 RID: 100307
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_22;

		// Token: 0x040187D4 RID: 100308
		internal static int __PropertyOffset_72;

		// Token: 0x040187D5 RID: 100309
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_21;

		// Token: 0x040187D6 RID: 100310
		internal static int __PropertyOffset_73;

		// Token: 0x040187D7 RID: 100311
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_20;

		// Token: 0x040187D8 RID: 100312
		internal static int __PropertyOffset_74;

		// Token: 0x040187D9 RID: 100313
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_19;

		// Token: 0x040187DA RID: 100314
		internal static int __PropertyOffset_75;

		// Token: 0x040187DB RID: 100315
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_18;

		// Token: 0x040187DC RID: 100316
		internal static int __PropertyOffset_76;

		// Token: 0x040187DD RID: 100317
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_17;

		// Token: 0x040187DE RID: 100318
		internal static int __PropertyOffset_77;

		// Token: 0x040187DF RID: 100319
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_12;

		// Token: 0x040187E0 RID: 100320
		internal static int __PropertyOffset_78;

		// Token: 0x040187E1 RID: 100321
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_17;

		// Token: 0x040187E2 RID: 100322
		internal static int __PropertyOffset_79;

		// Token: 0x040187E3 RID: 100323
		[Nullable(2)]
		private FAnimNode_SequenceEvaluator _AnimGraphNode_SequenceEvaluator;

		// Token: 0x040187E4 RID: 100324
		internal static int __PropertyOffset_80;

		// Token: 0x040187E5 RID: 100325
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_16;

		// Token: 0x040187E6 RID: 100326
		internal static int __PropertyOffset_81;

		// Token: 0x040187E7 RID: 100327
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_11;

		// Token: 0x040187E8 RID: 100328
		internal static int __PropertyOffset_82;

		// Token: 0x040187E9 RID: 100329
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_15;

		// Token: 0x040187EA RID: 100330
		internal static int __PropertyOffset_83;

		// Token: 0x040187EB RID: 100331
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_10;

		// Token: 0x040187EC RID: 100332
		internal static int __PropertyOffset_84;

		// Token: 0x040187ED RID: 100333
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_14;

		// Token: 0x040187EE RID: 100334
		internal static int __PropertyOffset_85;

		// Token: 0x040187EF RID: 100335
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_9;

		// Token: 0x040187F0 RID: 100336
		internal static int __PropertyOffset_86;

		// Token: 0x040187F1 RID: 100337
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_13;

		// Token: 0x040187F2 RID: 100338
		internal static int __PropertyOffset_87;

		// Token: 0x040187F3 RID: 100339
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_8;

		// Token: 0x040187F4 RID: 100340
		internal static int __PropertyOffset_88;

		// Token: 0x040187F5 RID: 100341
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_12;

		// Token: 0x040187F6 RID: 100342
		internal static int __PropertyOffset_89;

		// Token: 0x040187F7 RID: 100343
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_7;

		// Token: 0x040187F8 RID: 100344
		internal static int __PropertyOffset_90;

		// Token: 0x040187F9 RID: 100345
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_11;

		// Token: 0x040187FA RID: 100346
		internal static int __PropertyOffset_91;

		// Token: 0x040187FB RID: 100347
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_2;

		// Token: 0x040187FC RID: 100348
		internal static int __PropertyOffset_92;

		// Token: 0x040187FD RID: 100349
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_10;

		// Token: 0x040187FE RID: 100350
		internal static int __PropertyOffset_93;

		// Token: 0x040187FF RID: 100351
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_6;

		// Token: 0x04018800 RID: 100352
		internal static int __PropertyOffset_94;

		// Token: 0x04018801 RID: 100353
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_9;

		// Token: 0x04018802 RID: 100354
		internal static int __PropertyOffset_95;

		// Token: 0x04018803 RID: 100355
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_5;

		// Token: 0x04018804 RID: 100356
		internal static int __PropertyOffset_96;

		// Token: 0x04018805 RID: 100357
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_8;

		// Token: 0x04018806 RID: 100358
		internal static int __PropertyOffset_97;

		// Token: 0x04018807 RID: 100359
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_4;

		// Token: 0x04018808 RID: 100360
		internal static int __PropertyOffset_98;

		// Token: 0x04018809 RID: 100361
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_7;

		// Token: 0x0401880A RID: 100362
		internal static int __PropertyOffset_99;

		// Token: 0x0401880B RID: 100363
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose_1;

		// Token: 0x0401880C RID: 100364
		internal static int __PropertyOffset_100;

		// Token: 0x0401880D RID: 100365
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_6;

		// Token: 0x0401880E RID: 100366
		internal static int __PropertyOffset_101;

		// Token: 0x0401880F RID: 100367
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine_1;

		// Token: 0x04018810 RID: 100368
		internal static int __PropertyOffset_102;

		// Token: 0x04018811 RID: 100369
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose_1;

		// Token: 0x04018812 RID: 100370
		internal static int __PropertyOffset_103;

		// Token: 0x04018813 RID: 100371
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_16;

		// Token: 0x04018814 RID: 100372
		internal static int __PropertyOffset_104;

		// Token: 0x04018815 RID: 100373
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_15;

		// Token: 0x04018816 RID: 100374
		internal static int __PropertyOffset_105;

		// Token: 0x04018817 RID: 100375
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_14;

		// Token: 0x04018818 RID: 100376
		internal static int __PropertyOffset_106;

		// Token: 0x04018819 RID: 100377
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_13;

		// Token: 0x0401881A RID: 100378
		internal static int __PropertyOffset_107;

		// Token: 0x0401881B RID: 100379
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_12;

		// Token: 0x0401881C RID: 100380
		internal static int __PropertyOffset_108;

		// Token: 0x0401881D RID: 100381
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_11;

		// Token: 0x0401881E RID: 100382
		internal static int __PropertyOffset_109;

		// Token: 0x0401881F RID: 100383
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_10;

		// Token: 0x04018820 RID: 100384
		internal static int __PropertyOffset_110;

		// Token: 0x04018821 RID: 100385
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_9;

		// Token: 0x04018822 RID: 100386
		internal static int __PropertyOffset_111;

		// Token: 0x04018823 RID: 100387
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_8;

		// Token: 0x04018824 RID: 100388
		internal static int __PropertyOffset_112;

		// Token: 0x04018825 RID: 100389
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_7;

		// Token: 0x04018826 RID: 100390
		internal static int __PropertyOffset_113;

		// Token: 0x04018827 RID: 100391
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_6;

		// Token: 0x04018828 RID: 100392
		internal static int __PropertyOffset_114;

		// Token: 0x04018829 RID: 100393
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_5;

		// Token: 0x0401882A RID: 100394
		internal static int __PropertyOffset_115;

		// Token: 0x0401882B RID: 100395
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_4;

		// Token: 0x0401882C RID: 100396
		internal static int __PropertyOffset_116;

		// Token: 0x0401882D RID: 100397
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_3;

		// Token: 0x0401882E RID: 100398
		internal static int __PropertyOffset_117;

		// Token: 0x0401882F RID: 100399
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_2;

		// Token: 0x04018830 RID: 100400
		internal static int __PropertyOffset_118;

		// Token: 0x04018831 RID: 100401
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_3;

		// Token: 0x04018832 RID: 100402
		internal static int __PropertyOffset_119;

		// Token: 0x04018833 RID: 100403
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_5;

		// Token: 0x04018834 RID: 100404
		internal static int __PropertyOffset_120;

		// Token: 0x04018835 RID: 100405
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_2;

		// Token: 0x04018836 RID: 100406
		internal static int __PropertyOffset_121;

		// Token: 0x04018837 RID: 100407
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_4;

		// Token: 0x04018838 RID: 100408
		internal static int __PropertyOffset_122;

		// Token: 0x04018839 RID: 100409
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer_1;

		// Token: 0x0401883A RID: 100410
		internal static int __PropertyOffset_123;

		// Token: 0x0401883B RID: 100411
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_3;

		// Token: 0x0401883C RID: 100412
		internal static int __PropertyOffset_124;

		// Token: 0x0401883D RID: 100413
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult_1;

		// Token: 0x0401883E RID: 100414
		internal static int __PropertyOffset_125;

		// Token: 0x0401883F RID: 100415
		[Nullable(2)]
		private FAnimNode_BlendSpacePlayer _AnimGraphNode_BlendSpacePlayer;

		// Token: 0x04018840 RID: 100416
		internal static int __PropertyOffset_126;

		// Token: 0x04018841 RID: 100417
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_2;

		// Token: 0x04018842 RID: 100418
		internal static int __PropertyOffset_127;

		// Token: 0x04018843 RID: 100419
		[Nullable(2)]
		private FAnimNode_TransitionResult _AnimGraphNode_TransitionResult;

		// Token: 0x04018844 RID: 100420
		internal static int __PropertyOffset_128;

		// Token: 0x04018845 RID: 100421
		[Nullable(2)]
		private FAnimNode_SequencePlayer _AnimGraphNode_SequencePlayer;

		// Token: 0x04018846 RID: 100422
		internal static int __PropertyOffset_129;

		// Token: 0x04018847 RID: 100423
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult_1;

		// Token: 0x04018848 RID: 100424
		internal static int __PropertyOffset_130;

		// Token: 0x04018849 RID: 100425
		[Nullable(2)]
		private FAnimNode_UseCachedPose _AnimGraphNode_UseCachedPose;

		// Token: 0x0401884A RID: 100426
		internal static int __PropertyOffset_131;

		// Token: 0x0401884B RID: 100427
		[Nullable(2)]
		private FAnimNode_StateResult _AnimGraphNode_StateResult;

		// Token: 0x0401884C RID: 100428
		internal static int __PropertyOffset_132;

		// Token: 0x0401884D RID: 100429
		[Nullable(2)]
		private FAnimNode_StateMachine _AnimGraphNode_StateMachine;

		// Token: 0x0401884E RID: 100430
		internal static int __PropertyOffset_133;

		// Token: 0x0401884F RID: 100431
		[Nullable(2)]
		private FAnimNode_SaveCachedPose _AnimGraphNode_SaveCachedPose;

		// Token: 0x04018850 RID: 100432
		internal static int __PropertyOffset_134;

		// Token: 0x04018851 RID: 100433
		[Nullable(2)]
		private FAnimNode_Slot _AnimGraphNode_Slot;

		// Token: 0x04018852 RID: 100434
		internal static int __PropertyOffset_135;

		// Token: 0x04018853 RID: 100435
		[Nullable(2)]
		private FAnimNode_Inertialization _AnimGraphNode_Inertialization;

		// Token: 0x04018854 RID: 100436
		internal static int __PropertyOffset_136;

		// Token: 0x04018855 RID: 100437
		[Nullable(2)]
		private FAnimNode_Root _AnimGraphNode_Root;

		// Token: 0x04018856 RID: 100438
		internal static int __PropertyOffset_137;

		// Token: 0x04018857 RID: 100439
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer_2;

		// Token: 0x04018858 RID: 100440
		internal static int __PropertyOffset_138;

		// Token: 0x04018859 RID: 100441
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer_1;

		// Token: 0x0401885A RID: 100442
		internal static int __PropertyOffset_139;

		// Token: 0x0401885B RID: 100443
		[Nullable(2)]
		private FAnimNode_LinkedAnimLayer _AnimGraphNode_LinkedAnimLayer;

		// Token: 0x0401885C RID: 100444
		internal static int __PropertyOffset_140;

		// Token: 0x0401885D RID: 100445
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UAnimSequence> _待机表演配置;

		// Token: 0x0401885E RID: 100446
		internal static int __PropertyOffset_141;

		// Token: 0x0401885F RID: 100447
		internal static int __PropertyOffset_142;

		// Token: 0x04018860 RID: 100448
		internal static int __PropertyOffset_143;

		// Token: 0x04018861 RID: 100449
		internal static int __PropertyOffset_144;

		// Token: 0x04018862 RID: 100450
		internal static int __PropertyOffset_145;

		// Token: 0x04018863 RID: 100451
		internal static int __PropertyOffset_146;

		// Token: 0x04018864 RID: 100452
		internal static int __PropertyOffset_147;

		// Token: 0x04018865 RID: 100453
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UAnimSequence> _交互表演配置;

		// Token: 0x04018866 RID: 100454
		internal static int __PropertyOffset_148;

		// Token: 0x04018867 RID: 100455
		internal static int __PropertyOffset_149;

		// Token: 0x04018868 RID: 100456
		internal static int __PropertyOffset_150;

		// Token: 0x04018869 RID: 100457
		internal static int __PropertyOffset_151;

		// Token: 0x0401886A RID: 100458
		internal static int __PropertyOffset_152;

		// Token: 0x0401886B RID: 100459
		internal static int __PropertyOffset_153;

		// Token: 0x0401886C RID: 100460
		internal static int __PropertyOffset_154;

		// Token: 0x0401886D RID: 100461
		internal static int __PropertyOffset_155;

		// Token: 0x0401886E RID: 100462
		internal static int __PropertyOffset_156;

		// Token: 0x0401886F RID: 100463
		internal static int __PropertyOffset_157;

		// Token: 0x04018870 RID: 100464
		internal static int __PropertyOffset_158;

		// Token: 0x04018871 RID: 100465
		internal static int __PropertyOffset_159;

		// Token: 0x04018872 RID: 100466
		internal static int __PropertyOffset_160;

		// Token: 0x04018873 RID: 100467
		internal static int __PropertyOffset_161;

		// Token: 0x04018874 RID: 100468
		internal static int __PropertyOffset_162;

		// Token: 0x04018875 RID: 100469
		internal static int __PropertyOffset_163;

		// Token: 0x04018876 RID: 100470
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FGameplayTag, UAnimSequence> _其他动作配置;

		// Token: 0x04018877 RID: 100471
		internal static int __PropertyOffset_164;

		// Token: 0x04018878 RID: 100472
		internal static int __PropertyOffset_165;

		// Token: 0x04018879 RID: 100473
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<FGameplayTag, TSoftObjectPtr<PD_CharacterControllerData_C>> _材质配置;

		// Token: 0x0401887A RID: 100474
		internal static int __PropertyOffset_166;

		// Token: 0x0401887B RID: 100475
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FGameplayTag, UAnimMontage> _蒙太奇表演配置;

		// Token: 0x0401887C RID: 100476
		internal static int __PropertyOffset_167;

		// Token: 0x0401887D RID: 100477
		internal static int __PropertyOffset_168;

		// Token: 0x0401887E RID: 100478
		private static IntPtr __GetCurrentActionTime_NativeFunctionPtr;

		// Token: 0x0401887F RID: 100479
		private static IntPtr __演出层_NativeFunctionPtr;

		// Token: 0x04018880 RID: 100480
		private static IntPtr __后处理层_NativeFunctionPtr;

		// Token: 0x04018881 RID: 100481
		private static IntPtr __基础层_NativeFunctionPtr;

		// Token: 0x04018882 RID: 100482
		private static IntPtr __AnimGraph_NativeFunctionPtr;

		// Token: 0x04018883 RID: 100483
		private static IntPtr __OnSystemUIStart_NativeFunctionPtr;

		// Token: 0x04018884 RID: 100484
		private static IntPtr __OnFeedStart_NativeFunctionPtr;

		// Token: 0x04018885 RID: 100485
		private static IntPtr __更新移动信息_NativeFunctionPtr;

		// Token: 0x04018886 RID: 100486
		private static IntPtr __处理动作优先级_NativeFunctionPtr;

		// Token: 0x04018887 RID: 100487
		private static IntPtr __OnUnderAttackStart_NativeFunctionPtr;

		// Token: 0x04018888 RID: 100488
		private static IntPtr __OnTakeOffStart_NativeFunctionPtr;

		// Token: 0x04018889 RID: 100489
		private static IntPtr __OnAlertStart_NativeFunctionPtr;

		// Token: 0x0401888A RID: 100490
		private static IntPtr __更新视线_NativeFunctionPtr;

		// Token: 0x0401888B RID: 100491
		private static IntPtr __OnInteractStart_NativeFunctionPtr;

		// Token: 0x0401888C RID: 100492
		private static IntPtr __更新特殊交互表演_NativeFunctionPtr;

		// Token: 0x0401888D RID: 100493
		private static IntPtr __更新交互表演_NativeFunctionPtr;

		// Token: 0x0401888E RID: 100494
		private static IntPtr __OnIdleStart_NativeFunctionPtr;

		// Token: 0x0401888F RID: 100495
		private static IntPtr __更新待机表演_NativeFunctionPtr;

		// Token: 0x04018890 RID: 100496
		private static IntPtr __TakeOffEnd_NativeFunctionPtr;

		// Token: 0x04018891 RID: 100497
		private static IntPtr __AlertEnd_NativeFunctionPtr;

		// Token: 0x04018892 RID: 100498
		private static IntPtr __UnderAttackEnd_NativeFunctionPtr;

		// Token: 0x04018893 RID: 100499
		private static IntPtr __IdleEnd_NativeFunctionPtr;

		// Token: 0x04018894 RID: 100500
		private static IntPtr __InteractEnd_NativeFunctionPtr;

		// Token: 0x04018895 RID: 100501
		private static IntPtr __NoneStateEnd_NativeFunctionPtr;

		// Token: 0x04018896 RID: 100502
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_D54499E04BD261C3638E51BCC167F397_NativeFunctionPtr;

		// Token: 0x04018897 RID: 100503
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_30F574864082A787DF7CC1BAB8BC0A53_NativeFunctionPtr;

		// Token: 0x04018898 RID: 100504
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_B95B1327437100986649B89B92ECCF23_NativeFunctionPtr;

		// Token: 0x04018899 RID: 100505
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_C20382F940EEADA6AE673D9A81210F1C_NativeFunctionPtr;

		// Token: 0x0401889A RID: 100506
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_EA2A46454076B45705487189EC6FFD84_NativeFunctionPtr;

		// Token: 0x0401889B RID: 100507
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_0D2B24D4481CD55B42A27EA779A7F1CF_NativeFunctionPtr;

		// Token: 0x0401889C RID: 100508
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_F9A2310E4B85152CFCC97A84EDB7EF56_NativeFunctionPtr;

		// Token: 0x0401889D RID: 100509
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_9A890530410B3CD6D4797A8538EA342B_NativeFunctionPtr;

		// Token: 0x0401889E RID: 100510
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_180425454EE441A421DD628DD53FE2A8_NativeFunctionPtr;

		// Token: 0x0401889F RID: 100511
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_EF45970F4ABF89776F29558C1C276842_NativeFunctionPtr;

		// Token: 0x040188A0 RID: 100512
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_BAAC30DF4E867493C9C3B28B403F1A52_NativeFunctionPtr;

		// Token: 0x040188A1 RID: 100513
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_6E0C55ED464D77C9403BE39A42AA3EC2_NativeFunctionPtr;

		// Token: 0x040188A2 RID: 100514
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_9E7C77CA4ACF6F50475B2CA51B365D84_NativeFunctionPtr;

		// Token: 0x040188A3 RID: 100515
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_4707A7A14AE382D2DE16B59F280E1AD6_NativeFunctionPtr;

		// Token: 0x040188A4 RID: 100516
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_9900DD464E49EA09E2D4F8B18CDD31D1_NativeFunctionPtr;

		// Token: 0x040188A5 RID: 100517
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_A9CDC89D403878652E814AB43DD421B4_NativeFunctionPtr;

		// Token: 0x040188A6 RID: 100518
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_0709478946319BBF0BF840B801DAEB35_NativeFunctionPtr;

		// Token: 0x040188A7 RID: 100519
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_E8377F0B4C84C5DD4196CFB2E7D44CE1_NativeFunctionPtr;

		// Token: 0x040188A8 RID: 100520
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_A1CFEFA64D4BEA034EF84FA14A3FC792_NativeFunctionPtr;

		// Token: 0x040188A9 RID: 100521
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_8AC447DA43E1891D7082A4A39EA70C17_NativeFunctionPtr;

		// Token: 0x040188AA RID: 100522
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_0ACCD1B64E226DCBB6EA51B0CD6F4921_NativeFunctionPtr;

		// Token: 0x040188AB RID: 100523
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_D21B71CF41005EC9DEDCF4A84C6C53BB_NativeFunctionPtr;

		// Token: 0x040188AC RID: 100524
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_8E184F0C41B02556120BDDBC613B703B_NativeFunctionPtr;

		// Token: 0x040188AD RID: 100525
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_19866BA345A7023365D45CB3DD10B5A1_NativeFunctionPtr;

		// Token: 0x040188AE RID: 100526
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_24B8E9944172EB4335ED6593E3F8BD4F_NativeFunctionPtr;

		// Token: 0x040188AF RID: 100527
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_4E467B6A4ACBC58853AA6B8CC429A7D5_NativeFunctionPtr;

		// Token: 0x040188B0 RID: 100528
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_261082164D250FB062E641B2CB98C549_NativeFunctionPtr;

		// Token: 0x040188B1 RID: 100529
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_96DA532746BB03936925F4B0F5E24F48_NativeFunctionPtr;

		// Token: 0x040188B2 RID: 100530
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_99C64F1245BA6F14C220E9B82D2B3FCC_NativeFunctionPtr;

		// Token: 0x040188B3 RID: 100531
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_13A3A0424C3B5022728779A87FFE2552_NativeFunctionPtr;

		// Token: 0x040188B4 RID: 100532
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_5C72ADEB48A9244F8F798D846651569B_NativeFunctionPtr;

		// Token: 0x040188B5 RID: 100533
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_80410EA34013BBCB391AAAB1C368CC57_NativeFunctionPtr;

		// Token: 0x040188B6 RID: 100534
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_917F2B9D41AF9EC87991898BD6C207E9_NativeFunctionPtr;

		// Token: 0x040188B7 RID: 100535
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_368E31B5474BC72509A5519B64E3794A_NativeFunctionPtr;

		// Token: 0x040188B8 RID: 100536
		private static IntPtr __EvaluateGraphExposedInputs_ExecuteUbergraph_ABP_BaseRunAnimal_AnimGraphNode_TransitionResult_10D6FB8E421C0AD65B82EA8700ABB24F_NativeFunctionPtr;

		// Token: 0x040188B9 RID: 100537
		private static IntPtr __AnimNotify_Animal_IdleActionEnd_NativeFunctionPtr;

		// Token: 0x040188BA RID: 100538
		private static IntPtr __AnimNotify_Animal_InteractActionEnd_NativeFunctionPtr;

		// Token: 0x040188BB RID: 100539
		private static IntPtr __AnimNotify_Animal_AlertEnd_NativeFunctionPtr;

		// Token: 0x040188BC RID: 100540
		private static IntPtr __AnimNotify_Animal_UnderAttackEnd_NativeFunctionPtr;

		// Token: 0x040188BD RID: 100541
		private static IntPtr __BlueprintInitializeAnimation_NativeFunctionPtr;

		// Token: 0x040188BE RID: 100542
		private static IntPtr __BlueprintUpdateAnimation_NativeFunctionPtr;

		// Token: 0x040188BF RID: 100543
		private static IntPtr __StateMachineInitializationComplete_NativeFunctionPtr;

		// Token: 0x040188C0 RID: 100544
		private static IntPtr __NoneStateStart_NativeFunctionPtr;

		// Token: 0x040188C1 RID: 100545
		private static IntPtr __InteractStart_NativeFunctionPtr;

		// Token: 0x040188C2 RID: 100546
		private static IntPtr __IdleStart_NativeFunctionPtr;

		// Token: 0x040188C3 RID: 100547
		private static IntPtr __UnderAttackStart_NativeFunctionPtr;

		// Token: 0x040188C4 RID: 100548
		private static IntPtr __AlertStart_NativeFunctionPtr;

		// Token: 0x040188C5 RID: 100549
		private static IntPtr __TakeOffStart_NativeFunctionPtr;

		// Token: 0x040188C6 RID: 100550
		private static IntPtr __FeedStart_NativeFunctionPtr;

		// Token: 0x040188C7 RID: 100551
		private static IntPtr __SystemUiStart_NativeFunctionPtr;

		// Token: 0x040188C8 RID: 100552
		private static IntPtr __SystemUiEnd_NativeFunctionPtr;

		// Token: 0x040188C9 RID: 100553
		private static IntPtr __ExecuteUbergraph_ABP_BaseRunAnimal_NativeFunctionPtr;

		// Token: 0x0200A42B RID: 42027
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetCurrentActionTime_FunctionParams
		{
			// Token: 0x04033224 RID: 209444
			[FieldOffset(0)]
			public float ActionTime;
		}

		// Token: 0x0200A42C RID: 42028
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __演出层_FunctionParams
		{
			// Token: 0x04033225 RID: 209445
			[FieldOffset(0)]
			public byte 状态机输入;

			// Token: 0x04033226 RID: 209446
			[FieldOffset(24)]
			public byte 演出层;
		}

		// Token: 0x0200A42D RID: 42029
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __后处理层_FunctionParams
		{
			// Token: 0x04033227 RID: 209447
			[FieldOffset(0)]
			public byte 基础输入;

			// Token: 0x04033228 RID: 209448
			[FieldOffset(24)]
			public byte 后处理层;
		}

		// Token: 0x0200A42E RID: 42030
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __基础层_FunctionParams
		{
			// Token: 0x04033229 RID: 209449
			[FieldOffset(0)]
			public byte 基础层;
		}

		// Token: 0x0200A42F RID: 42031
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __AnimGraph_FunctionParams
		{
			// Token: 0x0403322A RID: 209450
			[FieldOffset(0)]
			public byte AnimGraph;
		}

		// Token: 0x0200A430 RID: 42032
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __OnFeedStart_FunctionParams
		{
			// Token: 0x0403322B RID: 209451
			[FieldOffset(0)]
			public FGameplayTag GameplayTag;
		}

		// Token: 0x0200A431 RID: 42033
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __BlueprintUpdateAnimation_FunctionParams
		{
			// Token: 0x0403322C RID: 209452
			[FieldOffset(0)]
			public float DeltaTimeX;
		}

		// Token: 0x0200A432 RID: 42034
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __FeedStart_FunctionParams
		{
			// Token: 0x0403322D RID: 209453
			[FieldOffset(0)]
			public FGameplayTag GameplayTag;
		}

		// Token: 0x0200A433 RID: 42035
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 240)]
		protected ref struct __ExecuteUbergraph_ABP_BaseRunAnimal_FunctionParams
		{
			// Token: 0x0403322E RID: 209454
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
