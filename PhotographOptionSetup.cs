using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020025DC RID: 9692
[NullableContext(2)]
[Nullable(0)]
public class PhotographOptionSetup : PhotographSetupBase
{
	// Token: 0x06012F2D RID: 77613 RVA: 0x0053DA24 File Offset: 0x0053BC24
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickedButton))
		};
	}

	// Token: 0x06012F2E RID: 77614 RVA: 0x0053DAA1 File Offset: 0x0053BCA1
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetButton(1).RootUIComp);
		this.ToggleLevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06012F2F RID: 77615 RVA: 0x0053DAD0 File Offset: 0x0053BCD0
	protected override void OnBeforeDestroy()
	{
		this.LevelSequencePlayer.Clear();
		this.LevelSequencePlayer = null;
		this.ToggleLevelSequencePlayer = null;
	}

	// Token: 0x06012F30 RID: 77616 RVA: 0x0053DAEC File Offset: 0x0053BCEC
	protected override void OnBeforeShow()
	{
		LevelSequencePlayer toggleLevelSequencePlayer = this.ToggleLevelSequencePlayer;
		if (toggleLevelSequencePlayer == null)
		{
			return;
		}
		toggleLevelSequencePlayer.PlayLevelSequenceByName("Start02", false, null, false);
	}

	// Token: 0x06012F31 RID: 77617 RVA: 0x0053DB19 File Offset: 0x0053BD19
	public override void Initialize(EPhotoSetupValueType setupValueType)
	{
		this.SetupValueType = setupValueType;
		this.Refresh();
		this.SetEnable(true);
		this.RefreshRedDot();
	}

	// Token: 0x06012F32 RID: 77618 RVA: 0x0053DB38 File Offset: 0x0053BD38
	private void RefreshRedDot()
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(base.IsPhotoSetupRedDotVisible());
	}

	// Token: 0x06012F33 RID: 77619 RVA: 0x0053DB5D File Offset: 0x0053BD5D
	private void InitToggle(int optionIndex)
	{
		this.CurrentOptionIndex = optionIndex;
		this.SetOptionStateByIndex(this.CurrentOptionIndex);
		this.ExecuteOption();
	}

	// Token: 0x06012F34 RID: 77620 RVA: 0x0053DB78 File Offset: 0x0053BD78
	public override void Refresh()
	{
		this.SetupConfig = ConfigBase<PhotographConfig>.Instance.GetPhotoSetupConfig(this.SetupValueType);
		if (this.SetupConfig.Value.Type != 0)
		{
			return;
		}
		this.InitToggle((int)ModelBase<PhotographModel>.Instance.GetPhotographOption(this.SetupValueType).GetValueOrDefault());
		string name = this.SetupConfig.Value.Name;
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, name, Array.Empty<object>());
	}

	// Token: 0x06012F35 RID: 77621 RVA: 0x0053DC00 File Offset: 0x0053BE00
	public override void SetEnable(bool bEnable)
	{
		float alpha = bEnable ? 1f : 0.5f;
		this.RootItem.SetAlpha(alpha);
		base.GetButton(1).SetEnable(bEnable);
	}

	// Token: 0x06012F36 RID: 77622 RVA: 0x0053DC36 File Offset: 0x0053BE36
	[NullableContext(1)]
	public void BindOnIndexChanged(Action<int> onIndexChanged)
	{
		this.OnIndexChanged = onIndexChanged;
	}

	// Token: 0x06012F37 RID: 77623 RVA: 0x0053DC40 File Offset: 0x0053BE40
	private void OnClickedButton()
	{
		this.SetToggleState(!this.CurrentOptionState, true);
		this.SetOptionIndexByState(this.CurrentOptionState);
		this.ExecuteOption();
		if (this.OnIndexChanged != null)
		{
			this.OnIndexChanged(this.CurrentOptionIndex);
		}
		base.MarkPhotoSetupRedDotAsRead(delegate
		{
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		});
	}

	// Token: 0x06012F38 RID: 77624 RVA: 0x0053DC9C File Offset: 0x0053BE9C
	private void SetOptionStateByIndex(int index)
	{
		int num = this.SetupConfig.Value.Options().Length - 1;
		this.SetToggleState(index == num, false);
	}

	// Token: 0x06012F39 RID: 77625 RVA: 0x0053DCCC File Offset: 0x0053BECC
	private void SetOptionIndexByState(bool state)
	{
		int num = this.SetupConfig.Value.Options().Length - 1;
		this.CurrentOptionIndex = (state ? num : 0);
	}

	// Token: 0x06012F3A RID: 77626 RVA: 0x0053DD00 File Offset: 0x0053BF00
	private void SetToggleState(bool state, bool needAnim = true)
	{
		this.CurrentOptionState = state;
		string sequenceName = state ? "ClickL" : "ClickR";
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
		}
		if (!needAnim)
		{
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 == null)
			{
				return;
			}
			levelSequencePlayer2.StopSequenceByKey(sequenceName, false, true);
		}
	}

	// Token: 0x06012F3B RID: 77627 RVA: 0x0053DD58 File Offset: 0x0053BF58
	private void ExecuteOption()
	{
		ControllerBase<PhotographController>.Instance.SetPhotographOption((EPhotoSetupValueType)this.SetupConfig.Value.ValueType, (float)this.CurrentOptionIndex, false);
	}

	// Token: 0x040093EE RID: 37870
	private int CurrentOptionIndex;

	// Token: 0x040093EF RID: 37871
	private bool CurrentOptionState;

	// Token: 0x040093F0 RID: 37872
	private LevelSequencePlayer ToggleLevelSequencePlayer;

	// Token: 0x040093F1 RID: 37873
	private Action<int> OnIndexChanged;

	// Token: 0x040093F2 RID: 37874
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02008945 RID: 35141
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E50F RID: 189711
		OptionNameText,
		// Token: 0x0402E510 RID: 189712
		OptionButton,
		// Token: 0x0402E511 RID: 189713
		RedDot
	}
}
