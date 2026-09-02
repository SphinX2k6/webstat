using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020010D3 RID: 4307
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GolemHackingMatrixCodeButton : GridProxyAbstract<GolemHackingGridInfo>
{
	// Token: 0x06007030 RID: 28720 RVA: 0x001D4438 File Offset: 0x001D2638
	[NullableContext(1)]
	public GolemHackingMatrixCodeButton(GolemHackingGameProxy proxy)
	{
		this.Proxy = proxy;
	}

	// Token: 0x06007031 RID: 28721 RVA: 0x001D4448 File Offset: 0x001D2648
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClicked));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007032 RID: 28722 RVA: 0x001D4594 File Offset: 0x001D2794
	protected override void OnStart()
	{
		this.SequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		if (!Singleton<Info>.Instance.IsMobileInputModel() || Singleton<Info>.Instance.IsInGamepad())
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.OnPointEnterCallBack.Bind(new Action(this.OnHovered));
			}
			UUIButtonComponent button2 = base.GetButton(0);
			if (button2 == null)
			{
				return;
			}
			button2.OnPointExitCallBack.Bind(new Action(this.OnUnHovered));
			return;
		}
		else
		{
			UUIButtonComponent button3 = base.GetButton(0);
			if (button3 != null)
			{
				button3.OnPointDownCallBack.Bind(new Action(this.OnMobilePointDown));
			}
			UUIButtonComponent button4 = base.GetButton(0);
			if (button4 != null)
			{
				button4.OnPointUpCallBack.Bind(new Action(this.OnMobilePointUp));
			}
			UUIButtonComponent button5 = base.GetButton(0);
			if (button5 != null)
			{
				button5.OnPointCancelCallBack.Bind(new Action(this.OnMobilePointCancel));
			}
			UUIButtonComponent button6 = base.GetButton(0);
			if (button6 != null)
			{
				button6.OnPointEnterCallBack.Bind(new Action(this.OnMobilePointEnter));
			}
			UUIButtonComponent button7 = base.GetButton(0);
			if (button7 == null)
			{
				return;
			}
			button7.OnPointExitCallBack.Bind(new Action(this.OnMobilePointExit));
			return;
		}
	}

	// Token: 0x06007033 RID: 28723 RVA: 0x001D46C4 File Offset: 0x001D28C4
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.Clear();
		}
		this.SequencePlayer = null;
		if (!Singleton<Info>.Instance.IsMobileInputModel() || Singleton<Info>.Instance.IsInGamepad())
		{
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.OnPointEnterCallBack.Unbind();
			}
			UUIButtonComponent button2 = base.GetButton(0);
			if (button2 == null)
			{
				return;
			}
			button2.OnPointExitCallBack.Unbind();
			return;
		}
		else
		{
			UUIButtonComponent button3 = base.GetButton(0);
			if (button3 != null)
			{
				button3.OnPointDownCallBack.Unbind();
			}
			UUIButtonComponent button4 = base.GetButton(0);
			if (button4 != null)
			{
				button4.OnPointUpCallBack.Unbind();
			}
			UUIButtonComponent button5 = base.GetButton(0);
			if (button5 != null)
			{
				button5.OnPointCancelCallBack.Unbind();
			}
			UUIButtonComponent button6 = base.GetButton(0);
			if (button6 != null)
			{
				button6.OnPointEnterCallBack.Unbind();
			}
			UUIButtonComponent button7 = base.GetButton(0);
			if (button7 == null)
			{
				return;
			}
			button7.OnPointExitCallBack.Unbind();
			return;
		}
	}

	// Token: 0x06007034 RID: 28724 RVA: 0x001D47A8 File Offset: 0x001D29A8
	[NullableContext(1)]
	public override void Refresh(GolemHackingGridInfo data, bool isSelected, int gridIndex)
	{
		this.CurData = data;
		int indexDistance = this.Proxy.GetIndexDistance(data.Index);
		if (this.TimerHandle != null)
		{
			if (this.TimerHandle.Valid())
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
			}
			this.TimerHandle = null;
		}
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
		string animName = this.Proxy.IsRestart ? "Reset" : "Start";
		if (indexDistance <= 0)
		{
			LevelSequencePlayer sequencePlayer3 = this.SequencePlayer;
			if (sequencePlayer3 != null)
			{
				sequencePlayer3.PlayOrReplaySequenceByName(animName, false, null);
			}
		}
		else
		{
			int num = indexDistance * 20;
			this.TimerHandle = TimerSystem.Instance.Delay(delegate(float _)
			{
				LevelSequencePlayer sequencePlayer4 = this.SequencePlayer;
				if (sequencePlayer4 == null)
				{
					return;
				}
				sequencePlayer4.PlayOrReplaySequenceByName(animName, false, null);
			}, (float)num, null, null, true, 1f);
		}
		this.UpdateState();
	}

	// Token: 0x06007035 RID: 28725 RVA: 0x001D48D8 File Offset: 0x001D2AD8
	public void UpdateState()
	{
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(this.CurData.IsUsed);
		}
		UUIItem item2 = base.GetItem(2);
		if (item2 != null)
		{
			item2.SetUIActive(!this.CurData.IsUsed);
		}
		if (this.CurData.IsUsed)
		{
			return;
		}
		UUIText text = base.GetText(5);
		if (text == null)
		{
			return;
		}
		text.SetText(this.CurData.Code, true);
	}

	// Token: 0x06007036 RID: 28726 RVA: 0x001D494D File Offset: 0x001D2B4D
	[NullableContext(1)]
	public void OnCodeHover(string value)
	{
		UUISprite sprite = base.GetSprite(4);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(this.CurData.Code == value);
	}

	// Token: 0x06007037 RID: 28727 RVA: 0x001D4971 File Offset: 0x001D2B71
	public void OnCodeUnHover()
	{
		UUISprite sprite = base.GetSprite(4);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(false);
	}

	// Token: 0x06007038 RID: 28728 RVA: 0x001D4985 File Offset: 0x001D2B85
	public void UpdateBtnActiveState()
	{
		UUIButtonComponent button = base.GetButton(0);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(this.Proxy.CheckMatrixBtnSelfInteractive(this.CurData.Index));
	}

	// Token: 0x06007039 RID: 28729 RVA: 0x001D49AE File Offset: 0x001D2BAE
	public void SetHoverFakeVisibility(bool visible)
	{
		UUISprite sprite = base.GetSprite(6);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(visible && !this.CurData.IsUsed);
	}

	// Token: 0x0600703A RID: 28730 RVA: 0x001D49D8 File Offset: 0x001D2BD8
	private void OnClicked()
	{
		UUIButtonComponent button = base.GetButton(0);
		if (button == null || !button.GetSelfInteractive())
		{
			return;
		}
		if (!this.Proxy.CheckCanInteractive())
		{
			return;
		}
		if (this.Proxy.MatrixPressingTime != 0.0 && Singleton<Time>.Instance.Now - this.Proxy.MatrixPressingTime > 400.0)
		{
			return;
		}
		if (this.CurData.IsUsed)
		{
			return;
		}
		this.CurData.IsUsed = true;
		this.UpdateState();
		LevelSequencePlayer sequencePlayer = this.SequencePlayer;
		if (sequencePlayer != null)
		{
			sequencePlayer.PlayOrReplaySequenceByName("Sle", false, null);
		}
		Action<int> onClickedCallback = this.OnClickedCallback;
		if (onClickedCallback == null)
		{
			return;
		}
		onClickedCallback(this.CurData.Index);
	}

	// Token: 0x0600703B RID: 28731 RVA: 0x001D4A9C File Offset: 0x001D2C9C
	private void OnHovered()
	{
		Action<int> onHoverCallback = this.OnHoverCallback;
		if (onHoverCallback == null)
		{
			return;
		}
		onHoverCallback(this.CurData.Index);
	}

	// Token: 0x0600703C RID: 28732 RVA: 0x001D4AB9 File Offset: 0x001D2CB9
	private void OnUnHovered()
	{
		Action<int> onUnHoverCallback = this.OnUnHoverCallback;
		if (onUnHoverCallback == null)
		{
			return;
		}
		onUnHoverCallback(this.CurData.Index);
	}

	// Token: 0x0600703D RID: 28733 RVA: 0x001D4AD6 File Offset: 0x001D2CD6
	private void OnMobilePointDown()
	{
		this.Proxy.IsMatrixPressing = true;
		this.Proxy.MatrixPressingTime = Singleton<Time>.Instance.Now;
		Action<int> onHoverCallback = this.OnHoverCallback;
		if (onHoverCallback == null)
		{
			return;
		}
		onHoverCallback(this.CurData.Index);
	}

	// Token: 0x0600703E RID: 28734 RVA: 0x001D4B14 File Offset: 0x001D2D14
	private void OnMobilePointUp()
	{
		this.Proxy.IsMatrixPressing = false;
		Action<int> onUnHoverCallback = this.OnUnHoverCallback;
		if (onUnHoverCallback == null)
		{
			return;
		}
		onUnHoverCallback(this.CurData.Index);
	}

	// Token: 0x0600703F RID: 28735 RVA: 0x001D4B3D File Offset: 0x001D2D3D
	private void OnMobilePointCancel()
	{
		this.Proxy.IsMatrixPressing = false;
		Action<int> onUnHoverCallback = this.OnUnHoverCallback;
		if (onUnHoverCallback == null)
		{
			return;
		}
		onUnHoverCallback(this.CurData.Index);
	}

	// Token: 0x06007040 RID: 28736 RVA: 0x001D4B66 File Offset: 0x001D2D66
	private void OnMobilePointEnter()
	{
		if (!this.Proxy.IsMatrixPressing)
		{
			return;
		}
		Action<int> onHoverCallback = this.OnHoverCallback;
		if (onHoverCallback == null)
		{
			return;
		}
		onHoverCallback(this.CurData.Index);
	}

	// Token: 0x06007041 RID: 28737 RVA: 0x001D4B91 File Offset: 0x001D2D91
	private void OnMobilePointExit()
	{
		if (!this.Proxy.IsMatrixPressing)
		{
			return;
		}
		Action<int> onUnHoverCallback = this.OnUnHoverCallback;
		if (onUnHoverCallback == null)
		{
			return;
		}
		onUnHoverCallback(this.CurData.Index);
	}

	// Token: 0x06007042 RID: 28738 RVA: 0x001D4BBC File Offset: 0x001D2DBC
	public UUIItem GetFirstUiItemWithNavListener()
	{
		UUIItem rootItem = base.GetRootItem();
		AActor owner = rootItem.GetOwner();
		if (owner == null)
		{
			return null;
		}
		UClassStackOnlyPtr classPtr = TsUiNavigationBehaviorListener.StaticClass();
		if (owner.GetComponentByClass(classPtr) != null)
		{
			return rootItem;
		}
		TArray<AActor> tarray = new TArray<AActor>();
		owner.GetAttachedActorDescendants(ref tarray, true);
		int num = tarray.Num();
		for (int i = 0; i < num; i++)
		{
			AActor aactor = tarray.Get(i);
			if (aactor != null && aactor.IsValid() && aactor.GetComponentByClass(classPtr) != null)
			{
				UUIItem uuiitem = aactor.GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
				if (uuiitem != null)
				{
					return uuiitem;
				}
			}
		}
		return null;
	}

	// Token: 0x04003601 RID: 13825
	[Nullable(1)]
	public GolemHackingGridInfo CurData;

	// Token: 0x04003602 RID: 13826
	public Action<int> OnHoverCallback;

	// Token: 0x04003603 RID: 13827
	public Action<int> OnUnHoverCallback;

	// Token: 0x04003604 RID: 13828
	public Action<int> OnClickedCallback;

	// Token: 0x04003605 RID: 13829
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x04003606 RID: 13830
	private TimerHandle TimerHandle;

	// Token: 0x04003607 RID: 13831
	[Nullable(1)]
	protected GolemHackingGameProxy Proxy;

	// Token: 0x02007463 RID: 29795
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x040283B8 RID: 164792
		Btn,
		// Token: 0x040283B9 RID: 164793
		PanelHolder,
		// Token: 0x040283BA RID: 164794
		PanelBtnContent,
		// Token: 0x040283BB RID: 164795
		SpriteMatrixBg,
		// Token: 0x040283BC RID: 164796
		SpriteTipsFrame,
		// Token: 0x040283BD RID: 164797
		TxtCode,
		// Token: 0x040283BE RID: 164798
		SpriteFakeHover
	}
}
