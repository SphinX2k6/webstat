using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.Entity.Struct;
using CSharpScript.Game.World.Define;
using UnrealEngine;

// Token: 0x02002E1B RID: 11803
[NullableContext(2)]
[Nullable(0)]
public class AnimalPerformBornState : AnimalPerformStateBase
{
	// Token: 0x06017E0E RID: 97806 RVA: 0x006B041D File Offset: 0x006AE61D
	[NullableContext(1)]
	public AnimalPerformBornState(Entity owner, EAnimalPerformState state, [Nullable(new byte[]
	{
		2,
		1
	})] StateMachine<Entity, EAnimalPerformState> stateMachine = null) : base(owner, state, stateMachine)
	{
	}

	// Token: 0x06017E0F RID: 97807 RVA: 0x006B0428 File Offset: 0x006AE628
	protected override void OnStart()
	{
		Entity owner = this.Owner;
		this.PerformComp = ((owner != null) ? owner.GetComponent<BasePerformComponent>() : null);
		Entity owner2 = this.Owner;
		this.TagComp = ((owner2 != null) ? owner2.GetComponent<BaseTagComponent>() : null);
		Entity owner3 = this.Owner;
		this.AnimComp = ((owner3 != null) ? owner3.GetComponent<CharacterAnimationComponent>() : null);
		Entity owner4 = this.Owner;
		this.CreatureData = ((owner4 != null) ? owner4.GetComponent<CreatureDataComponent>() : null);
		if (!this.PerformComp || !this.TagComp)
		{
			return;
		}
		this.TagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.出生表现"]));
		this.InitBornMontageInfo();
		if (this.BornMontageInfo == null)
		{
			this.FinishBornPerformance();
		}
	}

	// Token: 0x06017E10 RID: 97808 RVA: 0x006B04E4 File Offset: 0x006AE6E4
	protected override void OnExit(EAnimalPerformState nextState)
	{
		this.TagComp.AddTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.交互.站起"]));
		this.TagComp.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.出生表现"]));
		this.AbortBornMontage();
	}

	// Token: 0x06017E11 RID: 97809 RVA: 0x006B0538 File Offset: 0x006AE738
	protected void InitBornMontageInfo()
	{
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp == null || !tagComp.HasTag(GameplayTagDefine.EGameplayTagId["动物.Common.状态标识.休闲"]))
		{
			return;
		}
		CreatureDataComponent creatureData = this.CreatureData;
		string text;
		if (creatureData == null)
		{
			text = null;
		}
		else
		{
			SModelConfig modelConfig = creatureData.GetModelConfig();
			text = ((modelConfig != null) ? modelConfig.蓝图.ToAssetPathName() : null);
		}
		string text2 = text;
		if (text2 == null || text2.Length < 2)
		{
			return;
		}
		string bpPath = text2.Substring(0, text2.Length - 2);
		List<AnimalStandbyMontage> animalStandbyMontageData = ConfigBase<AnimalStandbyMontageConfig>.Instance.GetAnimalStandbyMontageData(bpPath);
		if (animalStandbyMontageData == null || animalStandbyMontageData.Count == 0)
		{
			return;
		}
		foreach (AnimalStandbyMontage config in animalStandbyMontageData)
		{
			int tagIdByName = GameplayTagUtils.GetTagIdByName(config.Tag);
			BaseTagComponent tagComp2 = this.TagComp;
			if (tagComp2 != null && tagComp2.HasTag(tagIdByName))
			{
				AnimalBornMontageInfo animalBornMontageInfo = new AnimalBornMontageInfo();
				animalBornMontageInfo.Init(config);
				if (animalBornMontageInfo.IsConfigValid())
				{
					this.BornMontageInfo = animalBornMontageInfo;
					break;
				}
				break;
			}
		}
		if (this.BornMontageInfo == null)
		{
			return;
		}
		this.TryLoadBornMontageAsset(this.BornMontageInfo.StartPath, AnimalPerformBornState.EAnimalBornMontagePhase.Start);
		this.TryLoadBornMontageAsset(this.BornMontageInfo.LoopPath, AnimalPerformBornState.EAnimalBornMontagePhase.Loop);
		this.TryLoadBornMontageAsset(this.BornMontageInfo.EndPath, AnimalPerformBornState.EAnimalBornMontagePhase.End);
		this.TryLoadBornBranchMontageAssets(this.BornMontageInfo.BranchPathList);
	}

	// Token: 0x06017E12 RID: 97810 RVA: 0x006B0698 File Offset: 0x006AE898
	protected void TryLoadBornMontageAsset(string path, AnimalPerformBornState.EAnimalBornMontagePhase phase)
	{
		if (path2 == null || path2 == "" || path2 == "None")
		{
			this.MarkAssetLoadedComplete(null, phase);
			this.WaitAssetLoadedComplete();
			return;
		}
		Singleton<ResourceSystem>.Instance.LoadAsync<UAnimMontage>(path2, delegate([Nullable(2)] UAnimMontage asset, string path)
		{
			this.MarkAssetLoadedComplete(asset, phase);
			this.WaitAssetLoadedComplete();
		}, 100, "js_undefined");
	}

	// Token: 0x06017E13 RID: 97811 RVA: 0x006B070C File Offset: 0x006AE90C
	[NullableContext(1)]
	protected void TryLoadBornBranchMontageAssets(List<string> paths)
	{
		if (paths.Count == 0)
		{
			return;
		}
		Action<UAnimMontage, string> <>9__0;
		foreach (string text in paths)
		{
			if (text == "" || text == "None")
			{
				this.BornMontageInfo.BranchLoadedCount++;
				if (this.BornMontageInfo.BranchLoadedCount == paths.Count)
				{
					this.MarkAssetLoadedComplete(null, AnimalPerformBornState.EAnimalBornMontagePhase.Branch);
					this.WaitAssetLoadedComplete();
				}
			}
			else
			{
				ResourceSystem instance = Singleton<ResourceSystem>.Instance;
				string path2 = text;
				Action<UAnimMontage, string> callback;
				if ((callback = <>9__0) == null)
				{
					callback = (<>9__0 = delegate([Nullable(2)] UAnimMontage asset, string path)
					{
						if (this.BornMontageInfo == null)
						{
							return;
						}
						this.BornMontageInfo.BranchLoadedCount++;
						if (asset != null && asset.IsValid())
						{
							this.BornMontageInfo.BranchList.Add(asset);
						}
						if (this.BornMontageInfo.BranchLoadedCount == paths.Count)
						{
							this.MarkAssetLoadedComplete(asset, AnimalPerformBornState.EAnimalBornMontagePhase.Branch);
							this.WaitAssetLoadedComplete();
						}
					});
				}
				instance.LoadAsync<UAnimMontage>(path2, callback, 100, "js_undefined");
			}
		}
	}

	// Token: 0x06017E14 RID: 97812 RVA: 0x006B0808 File Offset: 0x006AEA08
	protected void MarkAssetLoadedComplete(UAnimMontage asset, AnimalPerformBornState.EAnimalBornMontagePhase phase)
	{
		switch (phase)
		{
		case AnimalPerformBornState.EAnimalBornMontagePhase.Start:
			this.BornMontageInfo.Start = asset;
			this.BornMontageInfo.StartReady = true;
			return;
		case AnimalPerformBornState.EAnimalBornMontagePhase.Loop:
			this.BornMontageInfo.Loop = asset;
			this.BornMontageInfo.LoopReady = true;
			return;
		case AnimalPerformBornState.EAnimalBornMontagePhase.Branch:
			this.BornMontageInfo.BranchReady = true;
			return;
		case AnimalPerformBornState.EAnimalBornMontagePhase.End:
			this.BornMontageInfo.End = asset;
			this.BornMontageInfo.EndReady = true;
			return;
		default:
			return;
		}
	}

	// Token: 0x06017E15 RID: 97813 RVA: 0x006B0885 File Offset: 0x006AEA85
	protected void WaitAssetLoadedComplete()
	{
		AnimalBornMontageInfo bornMontageInfo = this.BornMontageInfo;
		if (bornMontageInfo == null || !bornMontageInfo.IsAssetReady())
		{
			return;
		}
		if (this.TryPlayBornMontageStart())
		{
			return;
		}
		if (this.TryPlayBornMontageLoop())
		{
			return;
		}
		this.FinishBornPerformance();
	}

	// Token: 0x06017E16 RID: 97814 RVA: 0x006B08B8 File Offset: 0x006AEAB8
	protected bool TryPlayBornMontageStart()
	{
		if (this.BornMontagePhase == AnimalPerformBornState.EAnimalBornMontagePhase.Finish)
		{
			return false;
		}
		if (this.BornMontagePhase == AnimalPerformBornState.EAnimalBornMontagePhase.End)
		{
			return false;
		}
		AnimalBornMontageInfo bornMontageInfo = this.BornMontageInfo;
		bool flag;
		if (bornMontageInfo == null)
		{
			flag = true;
		}
		else
		{
			UAnimMontage start = bornMontageInfo.Start;
			flag = !((start != null) ? new bool?(start.IsValid()) : null).GetValueOrDefault();
		}
		if (flag)
		{
			return false;
		}
		this.BornMontagePhase = AnimalPerformBornState.EAnimalBornMontagePhase.Start;
		this.PlayBornMontage(this.BornMontageInfo.Start, 0f, new Action<UAnimMontage, bool>(this.OnStartSectionFinished));
		return true;
	}

	// Token: 0x06017E17 RID: 97815 RVA: 0x006B0940 File Offset: 0x006AEB40
	protected bool TryPlayBornMontageLoop()
	{
		if (this.BornMontagePhase == AnimalPerformBornState.EAnimalBornMontagePhase.Finish)
		{
			return false;
		}
		if (this.BornMontagePhase == AnimalPerformBornState.EAnimalBornMontagePhase.End)
		{
			return false;
		}
		AnimalBornMontageInfo bornMontageInfo = this.BornMontageInfo;
		bool flag;
		if (bornMontageInfo == null)
		{
			flag = true;
		}
		else
		{
			UAnimMontage loop = bornMontageInfo.Loop;
			flag = !((loop != null) ? new bool?(loop.IsValid()) : null).GetValueOrDefault();
		}
		if (flag)
		{
			return false;
		}
		this.BornMontagePhase = AnimalPerformBornState.EAnimalBornMontagePhase.Loop;
		AnimalBornMontageInfo bornMontageInfo2 = this.BornMontageInfo;
		if (bornMontageInfo2 != null && bornMontageInfo2.BranchList.Count == 0)
		{
			this.PlayBornMontage(this.BornMontageInfo.Loop, -1f, new Action<UAnimMontage, bool>(this.OnLoopSectionFinished));
		}
		else
		{
			int num = 15;
			float sequenceLength = this.BornMontageInfo.Loop.SequenceLength;
			float playTime = (float)Math.Min(1.0, Math.Floor((double)((float)num / sequenceLength))) * sequenceLength;
			this.PlayBornMontage(this.BornMontageInfo.Loop, playTime, new Action<UAnimMontage, bool>(this.OnLoopSectionFinished));
		}
		return true;
	}

	// Token: 0x06017E18 RID: 97816 RVA: 0x006B0A34 File Offset: 0x006AEC34
	protected bool TryPlayBornMontageBranch()
	{
		if (this.BornMontagePhase == AnimalPerformBornState.EAnimalBornMontagePhase.Finish)
		{
			return false;
		}
		if (this.BornMontagePhase == AnimalPerformBornState.EAnimalBornMontagePhase.End)
		{
			return false;
		}
		if (this.BornMontageInfo == null || this.BornMontageInfo.BranchList.Count == 0)
		{
			return false;
		}
		int count = this.BornMontageInfo.BranchList.Count;
		int index = (int)Math.Floor(Singleton<MathUtils>.Instance.GetRandomRange(0.0, (double)count));
		this.BornMontageInfo.Branch = this.BornMontageInfo.BranchList[index];
		AnimalBornMontageInfo bornMontageInfo = this.BornMontageInfo;
		bool flag;
		if (bornMontageInfo == null)
		{
			flag = true;
		}
		else
		{
			UAnimMontage branch = bornMontageInfo.Branch;
			flag = !((branch != null) ? new bool?(branch.IsValid()) : null).GetValueOrDefault();
		}
		if (flag)
		{
			return false;
		}
		this.BornMontagePhase = AnimalPerformBornState.EAnimalBornMontagePhase.Branch;
		this.PlayBornMontage(this.BornMontageInfo.Branch, 0f, new Action<UAnimMontage, bool>(this.OnBranchSectionFinished));
		return true;
	}

	// Token: 0x06017E19 RID: 97817 RVA: 0x006B0B20 File Offset: 0x006AED20
	[NullableContext(1)]
	protected bool TryPlayBornMontageEnd(Action callback)
	{
		if (this.BornMontagePhase == AnimalPerformBornState.EAnimalBornMontagePhase.Finish)
		{
			return false;
		}
		if (this.BornMontagePhase == AnimalPerformBornState.EAnimalBornMontagePhase.End)
		{
			return false;
		}
		this.BornEndMontageCallback = callback;
		AnimalBornMontageInfo bornMontageInfo = this.BornMontageInfo;
		bool flag;
		if (bornMontageInfo == null)
		{
			flag = true;
		}
		else
		{
			UAnimMontage end = bornMontageInfo.End;
			flag = !((end != null) ? new bool?(end.IsValid()) : null).GetValueOrDefault();
		}
		if (flag)
		{
			AnimalBornMontageInfo bornMontageInfo2 = this.BornMontageInfo;
			this.OnEndSectionFinished((bornMontageInfo2 != null) ? bornMontageInfo2.End : null, false);
			return false;
		}
		this.BornMontagePhase = AnimalPerformBornState.EAnimalBornMontagePhase.End;
		this.PlayBornMontage(this.BornMontageInfo.End, 0f, new Action<UAnimMontage, bool>(this.OnEndSectionFinished));
		return true;
	}

	// Token: 0x06017E1A RID: 97818 RVA: 0x006B0BC8 File Offset: 0x006AEDC8
	[NullableContext(1)]
	public void InterruptBornPerformance(Action callback)
	{
		if (this.TryPlayBornMontageEnd(callback))
		{
			return;
		}
		if (this.AbortBornMontage())
		{
			TimerSystem.Instance.Delay(delegate(float _)
			{
				callback();
			}, 500f, null, null, true, 1f);
			return;
		}
		callback();
	}

	// Token: 0x06017E1B RID: 97819 RVA: 0x006B0C2C File Offset: 0x006AEE2C
	protected void FinishBornPerformance()
	{
		EAnimalPerformState? currentState = this.StateMachine.CurrentState;
		EAnimalPerformState eanimalPerformState = EAnimalPerformState.Born;
		if (!(currentState.GetValueOrDefault() == eanimalPerformState & currentState != null))
		{
			return;
		}
		this.AbortBornMontage();
		this.BornMontagePhase = AnimalPerformBornState.EAnimalBornMontagePhase.Finish;
		this.StateMachine.Switch(EAnimalPerformState.Stand);
		base.AnimalEcologicalInterface.StateMachineInitializationComplete();
	}

	// Token: 0x06017E1C RID: 97820 RVA: 0x006B0C84 File Offset: 0x006AEE84
	protected bool AbortBornMontage()
	{
		if (this.BornMontageInfo == null)
		{
			return false;
		}
		if (this.BornMontagePhase == AnimalPerformBornState.EAnimalBornMontagePhase.Finish)
		{
			return false;
		}
		UAnimMontage uanimMontage = null;
		switch (this.BornMontagePhase)
		{
		case AnimalPerformBornState.EAnimalBornMontagePhase.Start:
			uanimMontage = this.BornMontageInfo.Start;
			break;
		case AnimalPerformBornState.EAnimalBornMontagePhase.Loop:
			uanimMontage = this.BornMontageInfo.Loop;
			break;
		case AnimalPerformBornState.EAnimalBornMontagePhase.Branch:
			uanimMontage = this.BornMontageInfo.Branch;
			break;
		case AnimalPerformBornState.EAnimalBornMontagePhase.End:
			uanimMontage = this.BornMontageInfo.End;
			break;
		}
		this.BornMontagePhase = AnimalPerformBornState.EAnimalBornMontagePhase.Finish;
		if (uanimMontage == null || !uanimMontage.IsValid())
		{
			return false;
		}
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp != null)
		{
			UAnimInstance mainAnimInstance = animComp.MainAnimInstance;
			if (mainAnimInstance != null)
			{
				mainAnimInstance.Montage_Stop(0.5f, uanimMontage);
			}
		}
		return true;
	}

	// Token: 0x06017E1D RID: 97821 RVA: 0x006B0D3C File Offset: 0x006AEF3C
	protected void OnStartSectionFinished(UAnimMontage montage, bool bInterrupted)
	{
		if (this.BornMontageInfo == null || this.BornMontageInfo.Start != montage)
		{
			return;
		}
		BasePerformComponent performComp = this.PerformComp;
		if (performComp == null || !performComp.Valid)
		{
			return;
		}
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp != null)
		{
			UAnimInstance mainAnimInstance = animComp.MainAnimInstance;
			if (mainAnimInstance != null)
			{
				mainAnimInstance.OnMontageEnded.Remove(new Action<UAnimMontage, bool>(this.OnStartSectionFinished));
			}
		}
		if (this.BornMontagePhase != AnimalPerformBornState.EAnimalBornMontagePhase.Start)
		{
			return;
		}
		if (this.TimerHandle != null)
		{
			TimerSystem.Instance.Remove(this.TimerHandle);
		}
		this.TimerHandle = null;
		if (!this.TryPlayBornMontageLoop())
		{
			this.FinishBornPerformance();
		}
	}

	// Token: 0x06017E1E RID: 97822 RVA: 0x006B0DE0 File Offset: 0x006AEFE0
	protected void OnLoopSectionFinished(UAnimMontage montage, bool bInterrupted)
	{
		if (this.BornMontageInfo == null || this.BornMontageInfo.Loop != montage)
		{
			return;
		}
		BasePerformComponent performComp = this.PerformComp;
		if (performComp == null || !performComp.Valid)
		{
			return;
		}
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp != null)
		{
			UAnimInstance mainAnimInstance = animComp.MainAnimInstance;
			if (mainAnimInstance != null)
			{
				mainAnimInstance.OnMontageEnded.Remove(new Action<UAnimMontage, bool>(this.OnLoopSectionFinished));
			}
		}
		if (this.BornMontagePhase != AnimalPerformBornState.EAnimalBornMontagePhase.Loop)
		{
			return;
		}
		if (this.TimerHandle != null)
		{
			TimerSystem.Instance.Remove(this.TimerHandle);
		}
		this.TimerHandle = null;
		if (!this.TryPlayBornMontageBranch())
		{
			this.FinishBornPerformance();
		}
	}

	// Token: 0x06017E1F RID: 97823 RVA: 0x006B0E84 File Offset: 0x006AF084
	protected void OnBranchSectionFinished(UAnimMontage montage, bool bInterrupted)
	{
		if (this.BornMontageInfo == null || this.BornMontageInfo.Branch != montage)
		{
			return;
		}
		BasePerformComponent performComp = this.PerformComp;
		if (performComp == null || !performComp.Valid)
		{
			return;
		}
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp != null)
		{
			UAnimInstance mainAnimInstance = animComp.MainAnimInstance;
			if (mainAnimInstance != null)
			{
				mainAnimInstance.OnMontageEnded.Remove(new Action<UAnimMontage, bool>(this.OnBranchSectionFinished));
			}
		}
		if (this.BornMontagePhase != AnimalPerformBornState.EAnimalBornMontagePhase.Branch)
		{
			return;
		}
		if (this.TimerHandle != null)
		{
			TimerSystem.Instance.Remove(this.TimerHandle);
		}
		this.TimerHandle = null;
		if (!this.TryPlayBornMontageLoop())
		{
			this.FinishBornPerformance();
		}
	}

	// Token: 0x06017E20 RID: 97824 RVA: 0x006B0F28 File Offset: 0x006AF128
	protected void OnEndSectionFinished(UAnimMontage montage, bool bInterrupted)
	{
		if (this.BornMontageInfo == null || this.BornMontageInfo.End != montage)
		{
			return;
		}
		Action bornEndMontageCallback = this.BornEndMontageCallback;
		if (bornEndMontageCallback != null)
		{
			bornEndMontageCallback();
		}
		BasePerformComponent performComp = this.PerformComp;
		if (performComp == null || !performComp.Valid)
		{
			return;
		}
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp != null)
		{
			UAnimInstance mainAnimInstance = animComp.MainAnimInstance;
			if (mainAnimInstance != null)
			{
				mainAnimInstance.OnMontageEnded.Remove(new Action<UAnimMontage, bool>(this.OnEndSectionFinished));
			}
		}
		if (this.BornMontagePhase != AnimalPerformBornState.EAnimalBornMontagePhase.End)
		{
			return;
		}
		if (this.TimerHandle != null)
		{
			TimerSystem.Instance.Remove(this.TimerHandle);
		}
		this.TimerHandle = null;
		this.FinishBornPerformance();
	}

	// Token: 0x06017E21 RID: 97825 RVA: 0x006B0FD4 File Offset: 0x006AF1D4
	[NullableContext(1)]
	protected void PlayBornMontage(UAnimMontage montage, float playTime, [Nullable(new byte[]
	{
		1,
		2
	})] Action<UAnimMontage, bool> callback)
	{
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp != null)
		{
			UAnimInstance mainAnimInstance = animComp.MainAnimInstance;
			if (mainAnimInstance != null)
			{
				mainAnimInstance.Montage_Play(montage, 1f, EMontagePlayReturnType.MontageLength, 0f, true);
			}
		}
		CharacterAnimationComponent animComp2 = this.AnimComp;
		if (animComp2 != null)
		{
			UAnimInstance mainAnimInstance2 = animComp2.MainAnimInstance;
			if (mainAnimInstance2 != null)
			{
				mainAnimInstance2.OnMontageEnded.Add(callback);
			}
		}
		CharacterAnimationComponent animComp3 = this.AnimComp;
		if (animComp3 != null)
		{
			UAnimInstance mainAnimInstance3 = animComp3.MainAnimInstance;
			if (mainAnimInstance3 != null)
			{
				mainAnimInstance3.Montage_SetNextSection(Singleton<CharacterNameDefines>.Instance.DEFAULT_SECTION_NAME, Singleton<CharacterNameDefines>.Instance.DEFAULT_SECTION_NAME, montage);
			}
		}
		if (this.TimerHandle != null)
		{
			TimerSystem.Instance.Remove(this.TimerHandle);
		}
		this.TimerHandle = null;
		if (playTime != -1f)
		{
			float num = (playTime != 0f) ? playTime : montage.SequenceLength;
			float num2 = (num < 0.5f) ? num : (num - 0.5f);
			this.TimerHandle = TimerSystem.Instance.Delay(delegate(float _)
			{
				callback(montage, false);
			}, num2 * 1000f, null, null, true, 1f);
		}
	}

	// Token: 0x0400B954 RID: 47444
	private const float DEFAULT_BLEND_OUT_TIME = 0.5f;

	// Token: 0x0400B955 RID: 47445
	protected BasePerformComponent PerformComp;

	// Token: 0x0400B956 RID: 47446
	protected BaseTagComponent TagComp;

	// Token: 0x0400B957 RID: 47447
	protected CharacterAnimationComponent AnimComp;

	// Token: 0x0400B958 RID: 47448
	protected CreatureDataComponent CreatureData;

	// Token: 0x0400B959 RID: 47449
	protected AnimalBornMontageInfo BornMontageInfo;

	// Token: 0x0400B95A RID: 47450
	protected AnimalPerformBornState.EAnimalBornMontagePhase BornMontagePhase;

	// Token: 0x0400B95B RID: 47451
	protected TimerHandle TimerHandle;

	// Token: 0x0400B95C RID: 47452
	protected Action BornEndMontageCallback;

	// Token: 0x02009078 RID: 36984
	[NullableContext(0)]
	protected enum EAnimalBornMontagePhase
	{
		// Token: 0x040306F8 RID: 198392
		None,
		// Token: 0x040306F9 RID: 198393
		Start,
		// Token: 0x040306FA RID: 198394
		Loop,
		// Token: 0x040306FB RID: 198395
		Branch,
		// Token: 0x040306FC RID: 198396
		End,
		// Token: 0x040306FD RID: 198397
		Finish
	}
}
