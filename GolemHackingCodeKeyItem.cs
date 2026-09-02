using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020010D0 RID: 4304
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GolemHackingCodeKeyItem : GridProxyAbstract<GolemHackingCodeGridInfo>
{
	// Token: 0x06007002 RID: 28674 RVA: 0x001D2EA0 File Offset: 0x001D10A0
	public GolemHackingCodeKeyItem(GolemHackingGameProxy proxy)
	{
		this.Proxy = proxy;
	}

	// Token: 0x06007003 RID: 28675 RVA: 0x001D2EB0 File Offset: 0x001D10B0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007004 RID: 28676 RVA: 0x001D2F3C File Offset: 0x001D113C
	protected override void OnStart()
	{
		this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		if (!Singleton<Info>.Instance.IsMobileInputModel() || Singleton<Info>.Instance.IsInGamepad())
		{
			UUIButtonComponent button = base.GetButton(2);
			if (button != null)
			{
				button.OnPointEnterCallBack.Bind(new Action(this.OnHovered));
			}
			UUIButtonComponent button2 = base.GetButton(2);
			if (button2 == null)
			{
				return;
			}
			button2.OnPointExitCallBack.Bind(new Action(this.OnUnHovered));
			return;
		}
		else
		{
			UUIButtonComponent button3 = base.GetButton(2);
			if (button3 != null)
			{
				button3.OnPointDownCallBack.Bind(new Action(this.OnMobilePointDown));
			}
			UUIButtonComponent button4 = base.GetButton(2);
			if (button4 != null)
			{
				button4.OnPointUpCallBack.Bind(new Action(this.OnMobilePointUp));
			}
			UUIButtonComponent button5 = base.GetButton(2);
			if (button5 != null)
			{
				button5.OnPointCancelCallBack.Bind(new Action(this.OnMobilePointCancel));
			}
			UUIButtonComponent button6 = base.GetButton(2);
			if (button6 != null)
			{
				button6.OnPointEnterCallBack.Bind(new Action(this.OnMobilePointEnter));
			}
			UUIButtonComponent button7 = base.GetButton(2);
			if (button7 == null)
			{
				return;
			}
			button7.OnPointExitCallBack.Bind(new Action(this.OnMobilePointExit));
			return;
		}
	}

	// Token: 0x06007005 RID: 28677 RVA: 0x001D3080 File Offset: 0x001D1280
	protected override void OnBeforeDestroy()
	{
		this.ClearDelayTimer();
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.Clear();
		}
		this.SequencePlayer = null;
		if (!Singleton<Info>.Instance.IsMobileInputModel() || Singleton<Info>.Instance.IsInGamepad())
		{
			UUIButtonComponent button = base.GetButton(2);
			if (button != null)
			{
				button.OnPointEnterCallBack.Unbind();
			}
			UUIButtonComponent button2 = base.GetButton(2);
			if (button2 == null)
			{
				return;
			}
			button2.OnPointExitCallBack.Unbind();
			return;
		}
		else
		{
			UUIButtonComponent button3 = base.GetButton(2);
			if (button3 != null)
			{
				button3.OnPointDownCallBack.Unbind();
			}
			UUIButtonComponent button4 = base.GetButton(2);
			if (button4 != null)
			{
				button4.OnPointUpCallBack.Unbind();
			}
			UUIButtonComponent button5 = base.GetButton(2);
			if (button5 != null)
			{
				button5.OnPointCancelCallBack.Unbind();
			}
			UUIButtonComponent button6 = base.GetButton(2);
			if (button6 != null)
			{
				button6.OnPointEnterCallBack.Unbind();
			}
			UUIButtonComponent button7 = base.GetButton(2);
			if (button7 == null)
			{
				return;
			}
			button7.OnPointExitCallBack.Unbind();
			return;
		}
	}

	// Token: 0x06007006 RID: 28678 RVA: 0x001D3169 File Offset: 0x001D1369
	private void ClearDelayTimer()
	{
		if (this.DelayTimerHandle != null)
		{
			if (this.DelayTimerHandle.Valid())
			{
				TimerSystem.Instance.Remove(this.DelayTimerHandle);
			}
			this.DelayTimerHandle = null;
		}
	}

	// Token: 0x06007007 RID: 28679 RVA: 0x001D3198 File Offset: 0x001D1398
	public override void Refresh(GolemHackingCodeGridInfo data, bool isSelected, int gridIndex)
	{
		this.GridData = data;
		this.ClearDelayTimer();
		string animName = this.Proxy.IsRestart ? "Reset" : "Start";
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null && sequencePlayer.IsPlayingSequence("Reset"))
		{
			this.SequencePlayer.StopSequenceByKey("Reset", false, true);
		}
		LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
		if (sequencePlayer2 != null && sequencePlayer2.IsPlayingSequence("Start"))
		{
			this.SequencePlayer.StopSequenceByKey("Start", false, true);
		}
		if (data.AnimIndex > 0)
		{
			int num = (data.AnimIndex - 1) * 20;
			if (num <= 0)
			{
				LevelSequencePlayer sequencePlayer3 = this.SequencePlayer;
				if (sequencePlayer3 != null)
				{
					sequencePlayer3.PlayOrReplaySequenceByName(animName, false, null);
				}
			}
			else
			{
				this.DelayTimerHandle = TimerSystem.Instance.Delay(delegate(float _)
				{
					LevelSequencePlayer sequencePlayer4 = this.SequencePlayer;
					if (sequencePlayer4 != null)
					{
						sequencePlayer4.PlayOrReplaySequenceByName(animName, false, null);
					}
					this.DelayTimerHandle = null;
				}, (float)num, null, null, true, 1f);
			}
		}
		this.UpdateInfo();
	}

	// Token: 0x06007008 RID: 28680 RVA: 0x001D329C File Offset: 0x001D149C
	public void UpdateInfo()
	{
		UUIText text = base.GetText(1);
		text.SetText(this.GridData.Code, true);
		if (StringUtils.IsBlank(this.GridData.Code))
		{
			return;
		}
		if (this.GridData.BarState == EGolemHackingBarState.Default)
		{
			text.SetColor(this.GridData.Correct ? GolemHackingCodeKeyItem.SuccessColor : GolemHackingCodeKeyItem.DefaultColor);
			return;
		}
		if (this.GridData.BarState == EGolemHackingBarState.Success)
		{
			text.SetColor(GolemHackingCodeKeyItem.AllClearColor);
			return;
		}
		text.SetColor(GolemHackingCodeKeyItem.FailColor);
	}

	// Token: 0x06007009 RID: 28681 RVA: 0x001D3328 File Offset: 0x001D1528
	public void OnMatrixHover(string value)
	{
		UUIItem item = base.GetItem(0);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(this.GridData.Code == value);
	}

	// Token: 0x0600700A RID: 28682 RVA: 0x001D334C File Offset: 0x001D154C
	public void OnMatrixUnHover()
	{
		UUIItem item = base.GetItem(0);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x0600700B RID: 28683 RVA: 0x001D3360 File Offset: 0x001D1560
	private void OnHovered()
	{
		this.Proxy.OnHoveredCodeGrid(this.GridData.Code);
	}

	// Token: 0x0600700C RID: 28684 RVA: 0x001D3378 File Offset: 0x001D1578
	private void OnUnHovered()
	{
		this.Proxy.OnUnHoveredCodeGrid();
	}

	// Token: 0x0600700D RID: 28685 RVA: 0x001D3385 File Offset: 0x001D1585
	private void OnMobilePointDown()
	{
		this.Proxy.IsCodePressing = true;
		this.Proxy.OnHoveredCodeGrid(this.GridData.Code);
	}

	// Token: 0x0600700E RID: 28686 RVA: 0x001D33A9 File Offset: 0x001D15A9
	private void OnMobilePointUp()
	{
		this.Proxy.IsCodePressing = false;
		this.Proxy.OnUnHoveredCodeGrid();
	}

	// Token: 0x0600700F RID: 28687 RVA: 0x001D33C2 File Offset: 0x001D15C2
	private void OnMobilePointCancel()
	{
		this.Proxy.IsCodePressing = false;
		this.Proxy.OnUnHoveredCodeGrid();
	}

	// Token: 0x06007010 RID: 28688 RVA: 0x001D33DB File Offset: 0x001D15DB
	private void OnMobilePointEnter()
	{
		if (!this.Proxy.IsCodePressing)
		{
			return;
		}
		this.Proxy.OnHoveredCodeGrid(this.GridData.Code);
	}

	// Token: 0x06007011 RID: 28689 RVA: 0x001D3401 File Offset: 0x001D1601
	private void OnMobilePointExit()
	{
		if (!this.Proxy.IsCodePressing)
		{
			return;
		}
		this.Proxy.OnUnHoveredCodeGrid();
	}

	// Token: 0x040035EB RID: 13803
	[StaticVariableRuleIgnore]
	private static readonly FColor DefaultColor = FColor.FromHex("FFFFFF");

	// Token: 0x040035EC RID: 13804
	[StaticVariableRuleIgnore]
	private static readonly FColor SuccessColor = FColor.FromHex("0BBE77");

	// Token: 0x040035ED RID: 13805
	[StaticVariableRuleIgnore]
	private static readonly FColor AllClearColor = FColor.FromHex("0A482A");

	// Token: 0x040035EE RID: 13806
	[StaticVariableRuleIgnore]
	private static readonly FColor FailColor = FColor.FromHex("6F0D0D");

	// Token: 0x040035EF RID: 13807
	protected GolemHackingGameProxy Proxy;

	// Token: 0x040035F0 RID: 13808
	protected GolemHackingCodeGridInfo GridData;

	// Token: 0x040035F1 RID: 13809
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x040035F2 RID: 13810
	[Nullable(2)]
	private TimerHandle DelayTimerHandle;
}
