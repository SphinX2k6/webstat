using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020017AC RID: 6060
public class SpecialEnergyBarFeiXueStampItem : UiPanelBase
{
	// Token: 0x0600AB0F RID: 43791 RVA: 0x002DB584 File Offset: 0x002D9784
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
	}

	// Token: 0x0600AB10 RID: 43792 RVA: 0x002DB64C File Offset: 0x002D984C
	protected override void OnStart()
	{
		this.InitTweenAnim(2);
		this.InitTweenAnim(3);
		this.InitTweenAnim(4);
		this.InitTweenAnim(5);
		this.InitTweenAnim(6);
		this.InitTweenAnim(7);
		base.GetItem(0).SetUIActive(this.CurState == SpecialEnergyBarFeiXueStampItem.EState.Dis);
		base.GetItem(1).SetUIActive(this.CurState == SpecialEnergyBarFeiXueStampItem.EState.Act);
	}

	// Token: 0x0600AB11 RID: 43793 RVA: 0x002DB6B0 File Offset: 0x002D98B0
	public void SetState(int state, bool isMoveIn)
	{
		if (this.CurState == (SpecialEnergyBarFeiXueStampItem.EState)state)
		{
			return;
		}
		bool flag = this.CurState == SpecialEnergyBarFeiXueStampItem.EState.Dis;
		bool flag2 = this.CurState == SpecialEnergyBarFeiXueStampItem.EState.Act;
		this.CurState = (SpecialEnergyBarFeiXueStampItem.EState)state;
		bool flag3 = this.CurState == SpecialEnergyBarFeiXueStampItem.EState.Dis;
		bool flag4 = this.CurState == SpecialEnergyBarFeiXueStampItem.EState.Act;
		if (flag3)
		{
			base.GetItem(0).SetUIActive(true);
			this.StopTweenAnim(5);
			this.PlayTweenAnim(4);
			if (flag2)
			{
				this.StopTweenAnim(2);
				this.StopTweenAnim(6);
				this.PlayTweenAnim(7);
				return;
			}
		}
		else if (flag4)
		{
			base.GetItem(1).SetUIActive(true);
			this.StopTweenAnim(3);
			this.StopTweenAnim(7);
			if (isMoveIn)
			{
				this.PlayTweenAnim(6);
			}
			else
			{
				this.PlayTweenAnim(2);
			}
			if (flag)
			{
				this.PlayTweenAnim(5);
				return;
			}
		}
		else
		{
			if (flag2)
			{
				this.StopTweenAnim(2);
				this.StopTweenAnim(6);
				this.PlayTweenAnim(3);
				return;
			}
			this.StopTweenAnim(4);
			this.PlayTweenAnim(5);
		}
	}

	// Token: 0x0600AB12 RID: 43794 RVA: 0x002DB78E File Offset: 0x002D998E
	protected override void OnBeforeDestroy()
	{
		this.ClearAllTweenAnim();
		base.OnBeforeDestroy();
	}

	// Token: 0x0600AB13 RID: 43795 RVA: 0x002DB79C File Offset: 0x002D999C
	protected void InitTweenAnim(int componentType)
	{
		if (this.TweenAnimPlayer == null)
		{
			this.TweenAnimPlayer = new BattleUiTweenAnimPlayer();
		}
		this.TweenAnimPlayer.InitTweenAnim(componentType, base.GetItem(componentType), false);
	}

	// Token: 0x0600AB14 RID: 43796 RVA: 0x002DB7C5 File Offset: 0x002D99C5
	protected void PlayTweenAnim(int componentType)
	{
		BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
		if (tweenAnimPlayer == null)
		{
			return;
		}
		tweenAnimPlayer.PlayTweenAnim(componentType);
	}

	// Token: 0x0600AB15 RID: 43797 RVA: 0x002DB7D8 File Offset: 0x002D99D8
	protected void StopTweenAnim(int componentType)
	{
		BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
		if (tweenAnimPlayer == null)
		{
			return;
		}
		tweenAnimPlayer.StopTweenAnim(componentType);
	}

	// Token: 0x0600AB16 RID: 43798 RVA: 0x002DB7EB File Offset: 0x002D99EB
	protected void ClearAllTweenAnim()
	{
		BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
		if (tweenAnimPlayer == null)
		{
			return;
		}
		tweenAnimPlayer.Clear(false);
	}

	// Token: 0x04005169 RID: 20841
	[Nullable(2)]
	protected BattleUiTweenAnimPlayer TweenAnimPlayer;

	// Token: 0x0400516A RID: 20842
	private SpecialEnergyBarFeiXueStampItem.EState CurState;

	// Token: 0x02007AFB RID: 31483
	private enum EChildType
	{
		// Token: 0x0402A1D9 RID: 172505
		DisItem,
		// Token: 0x0402A1DA RID: 172506
		ActItem,
		// Token: 0x0402A1DB RID: 172507
		AniActIn,
		// Token: 0x0402A1DC RID: 172508
		AniActOut,
		// Token: 0x0402A1DD RID: 172509
		AniDisIn,
		// Token: 0x0402A1DE RID: 172510
		AniDisOut,
		// Token: 0x0402A1DF RID: 172511
		AniActMoveIn,
		// Token: 0x0402A1E0 RID: 172512
		AniActMoveOut
	}

	// Token: 0x02007AFC RID: 31484
	private enum EState
	{
		// Token: 0x0402A1E2 RID: 172514
		None,
		// Token: 0x0402A1E3 RID: 172515
		Dis,
		// Token: 0x0402A1E4 RID: 172516
		Act
	}
}
