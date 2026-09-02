using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001004 RID: 4100
[NullableContext(1)]
[Nullable(0)]
public class DrinksPlayProxy
{
	// Token: 0x06006A49 RID: 27209 RVA: 0x001BBA1E File Offset: 0x001B9C1E
	public void RegisterMainView(DrinksGamePlayMainView view)
	{
		this.MainView = view;
	}

	// Token: 0x06006A4A RID: 27210 RVA: 0x001BBA27 File Offset: 0x001B9C27
	public void UpdateGameStep(bool start)
	{
		if (start)
		{
			this.MainView.OnGameCurrentStepStart();
			return;
		}
		this.MainView.OnGameCurrentStepEnd();
	}

	// Token: 0x06006A4B RID: 27211 RVA: 0x001BBA43 File Offset: 0x001B9C43
	public void OnDrinkBaseSelected(int drinkId, bool isEnd)
	{
		this.MainView.OnDrinkBaseSelected(drinkId, isEnd);
	}

	// Token: 0x06006A4C RID: 27212 RVA: 0x001BBA52 File Offset: 0x001B9C52
	public void OnBatchingSelected(HashSet<int> batchingSet, bool isEnd)
	{
		this.MainView.OnBatchingSelected(batchingSet, isEnd);
	}

	// Token: 0x06006A4D RID: 27213 RVA: 0x001BBA61 File Offset: 0x001B9C61
	public void OnNoBatchingConfirm()
	{
		this.MainView.OnNoBatchingConfirm();
	}

	// Token: 0x06006A4E RID: 27214 RVA: 0x001BBA6E File Offset: 0x001B9C6E
	public void OnOrnamentSelected(bool isEnd)
	{
		this.MainView.OnOrnamentSelected(isEnd);
	}

	// Token: 0x06006A4F RID: 27215 RVA: 0x001BBA7C File Offset: 0x001B9C7C
	public void OnEnterDrinkBaseQTE()
	{
		this.MainView.OnEnterDrinkBaseQTE();
	}

	// Token: 0x06006A50 RID: 27216 RVA: 0x001BBA89 File Offset: 0x001B9C89
	public void OnLevelSequenceBegin()
	{
		ModelBase<DrinksModel>.Instance.GetSceneController().OnStepSequenceStart();
		this.UpdateRoleRequire();
		this.MainView.UpdateFlavorBubble();
	}

	// Token: 0x06006A51 RID: 27217 RVA: 0x001BBAAB File Offset: 0x001B9CAB
	public void UpdateRoleRequire()
	{
		this.MainView.UpdateRoleRequire();
	}

	// Token: 0x06006A52 RID: 27218 RVA: 0x001BBAB8 File Offset: 0x001B9CB8
	public void ActivateDialogBubble(string config, bool isLike)
	{
		this.MainView.ActivateDialogBubble(config, isLike);
	}

	// Token: 0x06006A53 RID: 27219 RVA: 0x001BBAC7 File Offset: 0x001B9CC7
	public void DeactivateDialogBubble()
	{
		this.MainView.DeactivateDialogBubble();
	}

	// Token: 0x06006A54 RID: 27220 RVA: 0x001BBAD4 File Offset: 0x001B9CD4
	public void SetNeedTick(bool value)
	{
		this.MainView.SetNeedTickQTE(value);
		this.MainView.NeedTickQTE = value;
	}

	// Token: 0x06006A55 RID: 27221 RVA: 0x001BBAEE File Offset: 0x001B9CEE
	public void OnFinishMixing()
	{
		this.MainView.OnFinishMixing();
	}

	// Token: 0x06006A56 RID: 27222 RVA: 0x001BBAFB File Offset: 0x001B9CFB
	public void OnFinishMixingEnd()
	{
		this.MainView.OnFinishMixingEnd();
	}

	// Token: 0x06006A57 RID: 27223 RVA: 0x001BBB08 File Offset: 0x001B9D08
	public int BackToPrev(EDrinksPlayStep curStep)
	{
		return this.MainView.ShowBackMask(curStep);
	}

	// Token: 0x06006A58 RID: 27224 RVA: 0x001BBB16 File Offset: 0x001B9D16
	public void SetShakeCamera(ACameraActor camera)
	{
		this.MainView.SetShakeCamera(camera);
	}

	// Token: 0x06006A59 RID: 27225 RVA: 0x001BBB24 File Offset: 0x001B9D24
	public void HideClose()
	{
		this.MainView.HideCaptionClose();
	}

	// Token: 0x04003289 RID: 12937
	protected DrinksGamePlayMainView MainView;
}
