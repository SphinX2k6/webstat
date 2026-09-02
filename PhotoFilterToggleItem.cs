using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020025D1 RID: 9681
[NullableContext(2)]
[Nullable(0)]
public class PhotoFilterToggleItem : UiPanelBase
{
	// Token: 0x06012ECE RID: 77518 RVA: 0x0053C740 File Offset: 0x0053A940
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickedButton))
		};
	}

	// Token: 0x06012ECF RID: 77519 RVA: 0x0053C7A7 File Offset: 0x0053A9A7
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetButton(1).RootUIComp);
	}

	// Token: 0x06012ED0 RID: 77520 RVA: 0x0053C7C5 File Offset: 0x0053A9C5
	protected override void OnBeforeShow()
	{
		this.CurrentOptionState = ModelBase<PhotographModel>.Instance.GetFilterToggleState();
		this.ExecuteOption(false);
	}

	// Token: 0x06012ED1 RID: 77521 RVA: 0x0053C7DE File Offset: 0x0053A9DE
	protected override void OnBeforeDestroy()
	{
		this.LevelSequencePlayer.Clear();
		this.LevelSequencePlayer = null;
	}

	// Token: 0x06012ED2 RID: 77522 RVA: 0x0053C7F4 File Offset: 0x0053A9F4
	public void Initialize()
	{
		string textStringId = "CameraFlitercontroller";
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, Array.Empty<object>());
	}

	// Token: 0x06012ED3 RID: 77523 RVA: 0x0053C820 File Offset: 0x0053AA20
	[NullableContext(1)]
	public void BindSetSubOptionVisible(Action<bool, bool> setSubOptionVisible)
	{
		this.SetSubOptionVisible = setSubOptionVisible;
	}

	// Token: 0x06012ED4 RID: 77524 RVA: 0x0053C829 File Offset: 0x0053AA29
	[NullableContext(1)]
	public void BindDeselectOnFilterItem(Action deselectOnFilterItem)
	{
		this.DeselectOnFilterItem = deselectOnFilterItem;
	}

	// Token: 0x06012ED5 RID: 77525 RVA: 0x0053C832 File Offset: 0x0053AA32
	private void OnClickedButton()
	{
		this.CurrentOptionState = !this.CurrentOptionState;
		ModelBase<PhotographModel>.Instance.SetFilterToggleState(this.CurrentOptionState);
		this.ExecuteOption(true);
	}

	// Token: 0x06012ED6 RID: 77526 RVA: 0x0053C85C File Offset: 0x0053AA5C
	private void SetToggleState(bool state, bool needAnim = true)
	{
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

	// Token: 0x06012ED7 RID: 77527 RVA: 0x0053C8AC File Offset: 0x0053AAAC
	private void ExecuteOption(bool isByClickToggle = true)
	{
		this.SetToggleState(this.CurrentOptionState, false);
		if (this.SetSubOptionVisible != null)
		{
			this.SetSubOptionVisible(this.CurrentOptionState, isByClickToggle);
		}
		if (!this.CurrentOptionState && this.DeselectOnFilterItem != null)
		{
			this.DeselectOnFilterItem();
		}
	}

	// Token: 0x040093CC RID: 37836
	private bool CurrentOptionState = true;

	// Token: 0x040093CD RID: 37837
	private Action<bool, bool> SetSubOptionVisible;

	// Token: 0x040093CE RID: 37838
	private Action DeselectOnFilterItem;

	// Token: 0x040093CF RID: 37839
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0200893E RID: 35134
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E4F1 RID: 189681
		OptionNameText,
		// Token: 0x0402E4F2 RID: 189682
		OptionButton
	}
}
