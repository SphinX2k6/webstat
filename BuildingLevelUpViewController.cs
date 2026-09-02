using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x020013A7 RID: 5031
[NullableContext(1)]
[Nullable(0)]
public class BuildingLevelUpViewController
{
	// Token: 0x06008AA8 RID: 35496 RVA: 0x0024854D File Offset: 0x0024674D
	public void RegisterView(BuildingLevelUpView view)
	{
		this.View = view;
		this.Model = (BuildingLevelUpViewModel)view.OpenParam;
	}

	// Token: 0x06008AA9 RID: 35497 RVA: 0x00248568 File Offset: 0x00246768
	public void Start()
	{
		if (!this.Model.IsLevelUp)
		{
			this.View.InitUnlock(this.Model.BuildingId);
			this.View.UiViewSequence.StartSequenceName = "Build";
			return;
		}
		this.View.InitLevelUp(this.Model.BuildingId);
		this.View.ShowLevelUp();
		this.View.FinishLevelUp(this.Model.BuildingId);
		this.View.UiViewSequence.StartSequenceName = "LevelUp";
	}

	// Token: 0x06008AAA RID: 35498 RVA: 0x002485FC File Offset: 0x002467FC
	public void UnlockPress()
	{
		UiBehaviorLevelSequence uiViewSequence = this.View.UiViewSequence;
		if (uiViewSequence.HasSequenceNameInPlaying("Press"))
		{
			uiViewSequence.ChangePlaybackDirection("Press");
		}
		else
		{
			this.View.UiViewSequence.PlaySequence("Press", false, null);
			this.View.PlayBuildingLoopSequence(true);
		}
		this.IsUnlockPress = true;
	}

	// Token: 0x06008AAB RID: 35499 RVA: 0x00248664 File Offset: 0x00246864
	public void UnlockRelease()
	{
		UiBehaviorLevelSequence uiViewSequence = this.View.UiViewSequence;
		if (uiViewSequence.HasSequenceNameInPlaying("Press"))
		{
			uiViewSequence.ChangePlaybackDirection("Press");
		}
		this.IsUnlockPress = false;
	}

	// Token: 0x06008AAC RID: 35500 RVA: 0x0024869C File Offset: 0x0024689C
	public void CloseSelf()
	{
		if (!this.Model.IsLevelUp)
		{
			ControllerBase<MoonChasingController>.Instance.BuildingBuildFlowRequest(this.Model.BuildingId, delegate(bool success)
			{
				if (success)
				{
					this.View.UiViewSequence.CloseSequenceName = "Close02";
					Singleton<UiManager>.Instance.ResetToBattleView(null);
					return;
				}
				this.View.CloseMe(null);
			});
			return;
		}
		MoonChasingPopularityUpData popularityUpData = ModelBase<MoonChasingBuildingModel>.Instance.GetPopularityUpData();
		if (popularityUpData == null)
		{
			this.View.CloseMe(null);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BusinessTipsPopularityUpView, popularityUpData, delegate(bool _, int _)
		{
			this.View.CloseMe(null);
		});
		ModelBase<MoonChasingBuildingModel>.Instance.SetPopularityUpData(null);
	}

	// Token: 0x06008AAD RID: 35501 RVA: 0x0024871C File Offset: 0x0024691C
	public void Tick(float delta)
	{
		if (this.Model.IsLevelUp)
		{
			return;
		}
		if (this.FillAmount >= 1f)
		{
			return;
		}
		if (this.IsUnlockPress)
		{
			this.FillAmount = Singleton<MathUtils>.Instance.Clamp(this.FillAmount + delta / 800f, 0f, 1f);
		}
		else
		{
			this.FillAmount = Singleton<MathUtils>.Instance.Clamp(this.FillAmount - delta / 800f, 0f, 1f);
		}
		this.View.SetFillAmount(this.FillAmount);
		if (this.FillAmount >= 1f)
		{
			this.View.ShowUnlock();
			this.View.FinishUnlock(this.Model.BuildingId);
			this.View.UiViewSequence.StopPrevSequence(false, true);
			this.View.UiViewSequence.PlaySequence("Select", false, null);
			this.View.PlayBuildingLoopSequence(false);
		}
		if (this.FillAmount <= 0f)
		{
			this.View.PlayBuildingLoopSequence(false);
		}
	}

	// Token: 0x040040E4 RID: 16612
	private const int ADD_STEP = 800;

	// Token: 0x040040E5 RID: 16613
	private const int REDUCE_STEP = 800;

	// Token: 0x040040E6 RID: 16614
	private BuildingLevelUpView View;

	// Token: 0x040040E7 RID: 16615
	private BuildingLevelUpViewModel Model;

	// Token: 0x040040E8 RID: 16616
	private bool IsUnlockPress;

	// Token: 0x040040E9 RID: 16617
	private float FillAmount;
}
