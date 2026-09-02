using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AutoAttach;
using UnrealEngine;

// Token: 0x0200228E RID: 8846
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleLevelAttachItem : AutoAttachItem<IMotorLevelAttachData>
{
	// Token: 0x06010B94 RID: 68500 RVA: 0x00494760 File Offset: 0x00492960
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIArtText)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06010B95 RID: 68501 RVA: 0x00494835 File Offset: 0x00492A35
	private void OnClickToggle(EToggleState toggleState)
	{
		Action<MotorcycleLevelAttachItem> onClickAttachItem = this.OnClickAttachItem;
		if (onClickAttachItem == null)
		{
			return;
		}
		onClickAttachItem(this);
	}

	// Token: 0x06010B96 RID: 68502 RVA: 0x00494848 File Offset: 0x00492A48
	private bool CheckCanClick()
	{
		return this.Data != null && (this.CheckToggleCanClick == null || this.CheckToggleCanClick(this.Data));
	}

	// Token: 0x06010B97 RID: 68503 RVA: 0x0049486F File Offset: 0x00492A6F
	protected override void OnStart()
	{
		base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.CheckCanClick));
	}

	// Token: 0x06010B98 RID: 68504 RVA: 0x00494890 File Offset: 0x00492A90
	protected override void OnRefreshItem(IMotorLevelAttachData data)
	{
		if (data == null)
		{
			return;
		}
		this.Data = data;
		this.TryInitLevelSequencePlayer();
		int curLevel = ModelBase<MotorcycleDevelopModel>.Instance.GetCurLevel();
		int curExp = ModelBase<MotorcycleDevelopModel>.Instance.GetCurExp();
		int count = ConfigBase<MotorConfig>.Instance.GetAllMotorLevelList().Count;
		bool flag = curLevel == count;
		bool flag2 = data.Level == curLevel;
		bool flag3 = data.Level < curLevel;
		bool flag4 = flag || flag3;
		UUIArtText artText = base.GetArtText(1);
		artText.SetText(data.Level.ToString());
		artText.SetColor(flag4 ? FColor.FromHex("9E8257") : FColor.FromHex("E1DACE"));
		base.GetItem(5).SetUIActive(flag2);
		base.GetItem(3).SetUIActive(!flag4);
		base.GetItem(4).SetUIActive(flag4);
		double num = 0.12;
		double num2 = 0.88;
		double num3 = num2 - num;
		float fillAmount;
		if (flag2 && !flag)
		{
			fillAmount = (float)(num + (double)((float)curExp / (float)data.Exp) * num3);
		}
		else
		{
			fillAmount = (flag4 ? ((float)num2) : ((float)num));
		}
		base.GetSprite(2).SetUIActive(flag2);
		base.GetSprite(2).SetFillAmount(fillAmount);
	}

	// Token: 0x06010B99 RID: 68505 RVA: 0x004949C8 File Offset: 0x00492BC8
	public override void OnSelect()
	{
		if (this.GetSelectAnimEnable == null || this.GetSelectAnimEnable())
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
			}
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
			if (seqPlayer2 != null)
			{
				seqPlayer2.PlaySequencePurely("Select", false, false, null, null, false);
			}
		}
		this.CurrentSelectState = true;
		Action<MotorcycleLevelAttachItem> onSelectAttachItem = this.OnSelectAttachItem;
		if (onSelectAttachItem == null)
		{
			return;
		}
		onSelectAttachItem(this);
	}

	// Token: 0x06010B9A RID: 68506 RVA: 0x00494A54 File Offset: 0x00492C54
	public void PlaySelectTween()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
		}
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.StopCurrentSequence(false, false);
		}
		LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
		if (seqPlayer2 == null)
		{
			return;
		}
		seqPlayer2.PlaySequencePurely("Select", false, false, null, null, false);
	}

	// Token: 0x06010B9B RID: 68507 RVA: 0x00494AAC File Offset: 0x00492CAC
	protected override void OnUnSelect()
	{
		if (this.CurrentSelectState)
		{
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
			if (seqPlayer2 != null)
			{
				seqPlayer2.PlaySequencePurely("Unselect", false, false, null, null, false);
			}
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentSelectState = false;
	}

	// Token: 0x06010B9C RID: 68508 RVA: 0x00494B14 File Offset: 0x00492D14
	protected override void OnMoveItem()
	{
		if (this.CurrentSelectState)
		{
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
			if (seqPlayer2 != null)
			{
				seqPlayer2.PlaySequencePurely("Unselect", false, false, null, null, false);
			}
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentSelectState = false;
	}

	// Token: 0x06010B9D RID: 68509 RVA: 0x00494B7C File Offset: 0x00492D7C
	private void TryInitLevelSequencePlayer()
	{
		if (this.SeqPlayer == null)
		{
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
			if (seqPlayer2 == null)
			{
				return;
			}
			seqPlayer2.PlaySequencePurely("Unselect", true, false, null, null, false);
		}
	}

	// Token: 0x06010B9E RID: 68510 RVA: 0x00494BD7 File Offset: 0x00492DD7
	public MotorcycleLevelAttachItem() : base(null)
	{
	}

	// Token: 0x040083F4 RID: 33780
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<MotorcycleLevelAttachItem> OnClickAttachItem;

	// Token: 0x040083F5 RID: 33781
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<MotorcycleLevelAttachItem> OnSelectAttachItem;

	// Token: 0x040083F6 RID: 33782
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<IMotorLevelAttachData, bool> CheckToggleCanClick;

	// Token: 0x040083F7 RID: 33783
	public Func<bool> GetSelectAnimEnable;

	// Token: 0x040083F8 RID: 33784
	private IMotorLevelAttachData Data;

	// Token: 0x040083F9 RID: 33785
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x040083FA RID: 33786
	private bool CurrentSelectState;

	// Token: 0x02008559 RID: 34137
	[NullableContext(0)]
	private class EMotorLevelAttachItemComponent
	{
		// Token: 0x0402D1FD RID: 184829
		public const int TogLevel = 0;

		// Token: 0x0402D1FE RID: 184830
		public const int ArtLevel = 1;

		// Token: 0x0402D1FF RID: 184831
		public const int SprProgress = 2;

		// Token: 0x0402D200 RID: 184832
		public const int CurLevelItem = 3;

		// Token: 0x0402D201 RID: 184833
		public const int PassLevelItem = 4;

		// Token: 0x0402D202 RID: 184834
		public const int ArrowItem = 5;

		// Token: 0x0402D203 RID: 184835
		public const int ScaleItem = 6;
	}
}
