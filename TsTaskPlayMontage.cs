using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.World.Controller;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CC8 RID: 3272
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPlayMontage.TsTaskPlayMontage_C")]
public class TsTaskPlayMontage : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000293 RID: 659
	// (get) Token: 0x06003F6E RID: 16238 RVA: 0x0006248C File Offset: 0x0006068C
	// (set) Token: 0x06003F6F RID: 16239 RVA: 0x000624C5 File Offset: 0x000606C5
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UAnimMontage> Montage
	{
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UAnimMontage> result;
			if ((result = this._Montage) == null)
			{
				result = (this._Montage = new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)TsTaskPlayMontage.__PropertyOffset_Montage, this));
			}
			return result;
		}
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)TsTaskPlayMontage.__PropertyOffset_Montage, 1);
		}
	}

	// Token: 0x17000294 RID: 660
	// (get) Token: 0x06003F70 RID: 16240 RVA: 0x000624EA File Offset: 0x000606EA
	// (set) Token: 0x06003F71 RID: 16241 RVA: 0x000624FE File Offset: 0x000606FE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string MontagePath
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayMontage.__PropertyOffset_MontagePath)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayMontage.__PropertyOffset_MontagePath)), value);
		}
	}

	// Token: 0x17000295 RID: 661
	// (get) Token: 0x06003F72 RID: 16242 RVA: 0x00062513 File Offset: 0x00060713
	// (set) Token: 0x06003F73 RID: 16243 RVA: 0x00062523 File Offset: 0x00060723
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int ExpressionId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPlayMontage.__PropertyOffset_ExpressionId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPlayMontage.__PropertyOffset_ExpressionId) = value;
		}
	}

	// Token: 0x17000296 RID: 662
	// (get) Token: 0x06003F74 RID: 16244 RVA: 0x00062534 File Offset: 0x00060734
	// (set) Token: 0x06003F75 RID: 16245 RVA: 0x00062544 File Offset: 0x00060744
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float LoopDuration
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPlayMontage.__PropertyOffset_LoopDuration);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPlayMontage.__PropertyOffset_LoopDuration) = value;
		}
	}

	// Token: 0x17000297 RID: 663
	// (get) Token: 0x06003F76 RID: 16246 RVA: 0x00062555 File Offset: 0x00060755
	// (set) Token: 0x06003F77 RID: 16247 RVA: 0x00062565 File Offset: 0x00060765
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int RepeatTimes
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPlayMontage.__PropertyOffset_RepeatTimes);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPlayMontage.__PropertyOffset_RepeatTimes) = value;
		}
	}

	// Token: 0x17000298 RID: 664
	// (get) Token: 0x06003F78 RID: 16248 RVA: 0x00062576 File Offset: 0x00060776
	// (set) Token: 0x06003F79 RID: 16249 RVA: 0x00062586 File Offset: 0x00060786
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool KeepMontageWhenEnd
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPlayMontage.__PropertyOffset_KeepMontageWhenEnd) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPlayMontage.__PropertyOffset_KeepMontageWhenEnd) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000299 RID: 665
	// (get) Token: 0x06003F7A RID: 16250 RVA: 0x00062597 File Offset: 0x00060797
	// (set) Token: 0x06003F7B RID: 16251 RVA: 0x000625AB File Offset: 0x000607AB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string InitStateName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayMontage.__PropertyOffset_InitStateName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayMontage.__PropertyOffset_InitStateName)), value);
		}
	}

	// Token: 0x1700029A RID: 666
	// (get) Token: 0x06003F7C RID: 16252 RVA: 0x000625C0 File Offset: 0x000607C0
	// (set) Token: 0x06003F7D RID: 16253 RVA: 0x000625D4 File Offset: 0x000607D4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string EndStateName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayMontage.__PropertyOffset_EndStateName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskPlayMontage.__PropertyOffset_EndStateName)), value);
		}
	}

	// Token: 0x1700029B RID: 667
	// (get) Token: 0x06003F7E RID: 16254 RVA: 0x000625E9 File Offset: 0x000607E9
	// (set) Token: 0x06003F7F RID: 16255 RVA: 0x000625F9 File Offset: 0x000607F9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsAdditiveMontage
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPlayMontage.__PropertyOffset_IsAdditiveMontage) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPlayMontage.__PropertyOffset_IsAdditiveMontage) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700029C RID: 668
	// (get) Token: 0x06003F80 RID: 16256 RVA: 0x0006260A File Offset: 0x0006080A
	// (set) Token: 0x06003F81 RID: 16257 RVA: 0x0006261A File Offset: 0x0006081A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool MaskInteract
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPlayMontage.__PropertyOffset_MaskInteract) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPlayMontage.__PropertyOffset_MaskInteract) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700029D RID: 669
	// (get) Token: 0x06003F82 RID: 16258 RVA: 0x0006262B File Offset: 0x0006082B
	// (set) Token: 0x06003F83 RID: 16259 RVA: 0x0006263B File Offset: 0x0006083B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EndOnBlendOut
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPlayMontage.__PropertyOffset_EndOnBlendOut) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPlayMontage.__PropertyOffset_EndOnBlendOut) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003F84 RID: 16260 RVA: 0x0006264C File Offset: 0x0006084C
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			TSoftObjectPtr<UAnimMontage> montage = this.Montage;
			this.TsMontage = (((montage != null) ? montage.ToAssetPathName() : null) ?? "");
			if (this.TsMontage == "")
			{
				this.TsMontage = this.MontagePath;
			}
			this.TsMaskInteract = this.MaskInteract;
			this.TsLoopDuration = this.LoopDuration;
			this.TsRepeatTimes = this.RepeatTimes;
			this.TsExpressionId = this.ExpressionId;
			this.TsKeepMontageWhenEnd = this.KeepMontageWhenEnd;
			this.TsInitStateName = this.InitStateName;
			this.TsEndStateName = this.EndStateName;
			this.TsIsAdditiveMontage = this.IsAdditiveMontage;
			this.TsEndOnBlendOut = this.EndOnBlendOut;
		}
	}

	// Token: 0x06003F85 RID: 16261 RVA: 0x00062720 File Offset: 0x00060920
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveExecuteAI(AAIController ownerController, APawn controlledPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveExecuteAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06003F86 RID: 16262 RVA: 0x000627BC File Offset: 0x000609BC
	[NullableContext(2)]
	protected unsafe virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.CJH;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(true);
			return;
		}
		this.Entity = aiController.CharActorComp.Entity;
		if (ControllerBase<ServerGmController>.Instance.AnimalDebug)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.AI;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "AnimalDebug PlayMontage";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Tree", base.TreeAsset);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TsMontage", this.TsMontage);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		if (this.TsMontage == "")
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.BehaviorTree;
			ELogAuthor author3 = ELogAuthor.CJH;
			string message3 = "播放蒙太奇未配置";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0);
			string item = "ConfigID";
			Entity entity = this.Entity;
			int? num;
			if (entity == null)
			{
				num = null;
			}
			else
			{
				CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
				num = ((component != null) ? new int?(component.GetPbDataId()) : null);
			}
			ptr = new ValueTuple<string, object>(item, num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("BehaviorTree", base.TreeAsset);
			instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			base.FinishExecute(true);
			return;
		}
		this.InteractComponent = this.Entity.GetComponent<PawnInteractNewComponent>();
		if (this.TsMaskInteract && this.InteractComponent != null)
		{
			this.InteractComponent.SetInteractionState(false, "TsTaskPlayMontage ReceiveExecuteAI");
		}
		if (this.Entity.GetComponent<BasePerformComponent>() != null)
		{
			this.PlayMontageByPerformComp();
			return;
		}
		this.PlayMontageByAnimComp();
	}

	// Token: 0x06003F87 RID: 16263 RVA: 0x00062998 File Offset: 0x00060B98
	protected override void OnAbort()
	{
		if (this.TsMaskInteract && this.InteractComponent != null)
		{
			this.InteractComponent.SetInteractionState(true, "TsTaskPlayMontage OnClear");
		}
		this.InteractComponent = null;
		Entity entity = this.Entity;
		BasePerformComponent basePerformComponent = (entity != null) ? entity.GetComponent<BasePerformComponent>() : null;
		if (basePerformComponent != null)
		{
			basePerformComponent.VolatileMontageStopByLoad(EPerformMode.Ecology, this.PlayingMontageId, this.TsKeepMontageWhenEnd ? EStopMethod.WaitNextEndSection : EStopMethod.BlendOut);
		}
		else
		{
			Entity entity2 = this.Entity;
			BaseAnimationComponent baseAnimationComponent = (entity2 != null) ? entity2.GetComponent<BaseAnimationComponent>() : null;
			if (baseAnimationComponent != null)
			{
				baseAnimationComponent.StopMontageByHandleId(new IStopMontageParam
				{
					HandleId = new int?(this.PlayingMontageId),
					Method = new EStopMethod?(this.TsKeepMontageWhenEnd ? EStopMethod.WaitNextEndSection : EStopMethod.BlendOut)
				});
			}
		}
		this.PlayingMontageId = -1;
	}

	// Token: 0x06003F88 RID: 16264 RVA: 0x00062A4F File Offset: 0x00060C4F
	protected override void OnClear()
	{
		this.StopMontageEmotionBubble();
	}

	// Token: 0x06003F89 RID: 16265 RVA: 0x00062A58 File Offset: 0x00060C58
	protected void PlayMontageByAnimComp()
	{
		TsTaskPlayMontage.<>c__DisplayClass52_0 CS$<>8__locals1 = new TsTaskPlayMontage.<>c__DisplayClass52_0();
		CS$<>8__locals1.<>4__this = this;
		TsTaskPlayMontage.<>c__DisplayClass52_0 CS$<>8__locals2 = CS$<>8__locals1;
		Entity entity = this.Entity;
		CS$<>8__locals2.animComp = ((entity != null) ? entity.GetComponent<BaseAnimationComponent>() : null);
		if (CS$<>8__locals1.animComp == null)
		{
			base.FinishExecute(true);
			return;
		}
		Singleton<ResourceSystem>.Instance.LoadAsync<UAnimMontage>(this.TsMontage, delegate([Nullable(2)] UAnimMontage montage, string _)
		{
			if (montage == null || !montage.IsValid())
			{
				CS$<>8__locals1.<>4__this.FinishExecute(true);
				return;
			}
			BaseAnimationComponent animComp = CS$<>8__locals1.animComp;
			if (animComp == null || !animComp.Valid)
			{
				CS$<>8__locals1.<>4__this.FinishExecute(true);
				return;
			}
			int num = montage.CompositeSections.Num();
			int tsRepeatTimes = CS$<>8__locals1.<>4__this.TsRepeatTimes;
			float tsLoopDuration = CS$<>8__locals1.<>4__this.TsLoopDuration;
			float num2 = 0f;
			bool value = true;
			if (num == 1)
			{
				if (tsRepeatTimes > 0)
				{
					num2 = (float)tsRepeatTimes * montage.SequenceLength * 1000f;
				}
				else if (tsRepeatTimes == 0)
				{
					value = false;
				}
			}
			else if (num == 3)
			{
				if (tsLoopDuration > 0f)
				{
					num2 = tsLoopDuration * 1000f;
				}
				else if (tsLoopDuration == 0f)
				{
					value = false;
				}
			}
			CS$<>8__locals1.<>4__this.PlayMontageEmotionBubble();
			TsTaskPlayMontage <>4__this = CS$<>8__locals1.<>4__this;
			MontageManager montageManager = CS$<>8__locals1.animComp.MontageManager;
			IPlayMontageParam playMontageParam = new IPlayMontageParam();
			playMontageParam.MontageAsset = montage;
			playMontageParam.IsLoop = new bool?(value);
			playMontageParam.Duration = ((num2 > 0f) ? new float?(num2) : null);
			playMontageParam.KeepOtherMontage = new bool?(CS$<>8__locals1.<>4__this.TsIsAdditiveMontage);
			Action<UAnimMontage, bool> onEndCallback;
			if ((onEndCallback = CS$<>8__locals1.<>9__1) == null)
			{
				onEndCallback = (CS$<>8__locals1.<>9__1 = delegate(UAnimMontage m, bool b)
				{
					if (ControllerBase<ServerGmController>.Instance.AnimalDebug)
					{
						Singleton<Log>.Instance.Info(ELogModule.AI, ELogAuthor.LCZ, "AnimalDebug PlayMontage3", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					CS$<>8__locals1.<>4__this.StopMontageEmotionBubble();
					CS$<>8__locals1.<>4__this.FinishExecute(true);
				});
			}
			playMontageParam.OnEndCallback = onEndCallback;
			<>4__this.PlayingMontageId = montageManager.PlayMontage(playMontageParam);
			if (ControllerBase<ServerGmController>.Instance.AnimalDebug)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.AI;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "AnimalDebug PlayMontage2";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlayingMontageId", CS$<>8__locals1.<>4__this.PlayingMontageId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			if (CS$<>8__locals1.<>4__this.PlayingMontageId < 0)
			{
				CS$<>8__locals1.<>4__this.FinishExecute(true);
			}
		}, 100, "js_undefined");
	}

	// Token: 0x06003F8A RID: 16266 RVA: 0x00062AC0 File Offset: 0x00060CC0
	protected void PlayMontageByPerformComp()
	{
		bool animalDebug = ControllerBase<ServerGmController>.Instance.AnimalDebug;
		BasePerformComponent component = this.Entity.GetComponent<BasePerformComponent>();
		IAnimStateParam state = new IAnimStateParam
		{
			InitStateName = this.TsInitStateName,
			EndStateName = this.TsEndStateName
		};
		this.PlayMontageEmotionBubble();
		this.PlayingMontageId = component.VolatileMontagePlayByLoad(EPerformMode.Ecology, this.TsMontage, state, delegate(UAnimMontage montage)
		{
			Entity entity = this.Entity;
			CommonNpcPerformComponent commonNpcPerformComponent = (entity != null) ? entity.GetComponent<CommonNpcPerformComponent>() : null;
			if (commonNpcPerformComponent == null)
			{
				return;
			}
			NpcFacialExpressionController expressionController = commonNpcPerformComponent.ExpressionController;
			if (expressionController == null)
			{
				return;
			}
			expressionController.ChangeFaceForExpression(montage, new int?(this.TsExpressionId));
		}, delegate(UAnimMontage m, bool b)
		{
			if (ControllerBase<ServerGmController>.Instance.AnimalDebug)
			{
				Singleton<Log>.Instance.Info(ELogModule.AI, ELogAuthor.LCZ, "AnimalDebug PlayMontage3", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.StopMontageEmotionBubble();
			base.FinishExecute(true);
		}, new float?(this.TsLoopDuration), new float?((float)this.TsRepeatTimes), new bool?(false), new bool?(this.TsIsAdditiveMontage), new bool?(this.TsEndOnBlendOut));
		if (animalDebug)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "AnimalDebug PlayMontage2";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PlayingMontageId", this.PlayingMontageId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		if (this.PlayingMontageId < 0)
		{
			base.FinishExecute(true);
		}
	}

	// Token: 0x06003F8B RID: 16267 RVA: 0x00062BA8 File Offset: 0x00060DA8
	protected void PlayMontageEmotionBubble()
	{
		Entity entity = this.Entity;
		CharacterEmotionBubbleComponent characterEmotionBubbleComponent = (entity != null) ? entity.GetComponent<CharacterEmotionBubbleComponent>() : null;
		if (characterEmotionBubbleComponent == null)
		{
			return;
		}
		characterEmotionBubbleComponent.PlayAnimalMontageEmotion(this.TsMontage);
	}

	// Token: 0x06003F8C RID: 16268 RVA: 0x00062BCC File Offset: 0x00060DCC
	protected void StopMontageEmotionBubble()
	{
		Entity entity = this.Entity;
		CharacterEmotionBubbleComponent characterEmotionBubbleComponent = (entity != null) ? entity.GetComponent<CharacterEmotionBubbleComponent>() : null;
		if (characterEmotionBubbleComponent == null)
		{
			return;
		}
		characterEmotionBubbleComponent.StopAnimalMontageEmotion(this.TsMontage);
	}

	// Token: 0x06003F8D RID: 16269 RVA: 0x00062BF0 File Offset: 0x00060DF0
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskPlayMontage._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPlayMontage.TsTaskPlayMontage_C");
		}
		return TsTaskPlayMontage._ClassPtr;
	}

	// Token: 0x06003F8E RID: 16270 RVA: 0x00062C14 File Offset: 0x00060E14
	public TsTaskPlayMontage() : this(BuiltinUtils.AllocNativeUObject(TsTaskPlayMontage.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003F8F RID: 16271 RVA: 0x00062C3C File Offset: 0x00060E3C
	public TsTaskPlayMontage(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPlayMontage.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003F90 RID: 16272 RVA: 0x00062C6F File Offset: 0x00060E6F
	protected TsTaskPlayMontage(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003F91 RID: 16273 RVA: 0x00062CA0 File Offset: 0x00060EA0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000E28 RID: 3624
	private bool IsInitTsVariables;

	// Token: 0x04000E29 RID: 3625
	private string TsMontage = "";

	// Token: 0x04000E2A RID: 3626
	private bool TsMaskInteract;

	// Token: 0x04000E2B RID: 3627
	private float TsLoopDuration;

	// Token: 0x04000E2C RID: 3628
	private int TsRepeatTimes;

	// Token: 0x04000E2D RID: 3629
	private int TsExpressionId;

	// Token: 0x04000E2E RID: 3630
	private bool TsKeepMontageWhenEnd;

	// Token: 0x04000E2F RID: 3631
	private string TsInitStateName = "";

	// Token: 0x04000E30 RID: 3632
	private string TsEndStateName = "";

	// Token: 0x04000E31 RID: 3633
	private bool TsIsAdditiveMontage;

	// Token: 0x04000E32 RID: 3634
	private bool TsEndOnBlendOut;

	// Token: 0x04000E33 RID: 3635
	[Nullable(2)]
	private PawnInteractNewComponent InteractComponent;

	// Token: 0x04000E34 RID: 3636
	private int PlayingMontageId = -1;

	// Token: 0x04000E35 RID: 3637
	[Nullable(2)]
	private Entity Entity;

	// Token: 0x04000E36 RID: 3638
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPlayMontage.TsTaskPlayMontage_C";

	// Token: 0x04000E37 RID: 3639
	private static IntPtr _ClassPtr;

	// Token: 0x04000E38 RID: 3640
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000E39 RID: 3641
	private static int __PropertyOffset_Montage;

	// Token: 0x04000E3A RID: 3642
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UAnimMontage> _Montage;

	// Token: 0x04000E3B RID: 3643
	private static int __PropertyOffset_MontagePath;

	// Token: 0x04000E3C RID: 3644
	private static int __PropertyOffset_ExpressionId;

	// Token: 0x04000E3D RID: 3645
	private static int __PropertyOffset_LoopDuration;

	// Token: 0x04000E3E RID: 3646
	private static int __PropertyOffset_RepeatTimes;

	// Token: 0x04000E3F RID: 3647
	private static int __PropertyOffset_KeepMontageWhenEnd;

	// Token: 0x04000E40 RID: 3648
	private static int __PropertyOffset_InitStateName;

	// Token: 0x04000E41 RID: 3649
	private static int __PropertyOffset_EndStateName;

	// Token: 0x04000E42 RID: 3650
	private static int __PropertyOffset_IsAdditiveMontage;

	// Token: 0x04000E43 RID: 3651
	private static int __PropertyOffset_MaskInteract;

	// Token: 0x04000E44 RID: 3652
	private static int __PropertyOffset_EndOnBlendOut;
}
