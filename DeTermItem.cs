using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200120C RID: 4620
[NullableContext(2)]
[Nullable(0)]
public class DeTermItem : GridProxyAbstract<int>
{
	// Token: 0x06007A3E RID: 31294 RVA: 0x001FD7F8 File Offset: 0x001FB9F8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007A3F RID: 31295 RVA: 0x001FD8E0 File Offset: 0x001FBAE0
	protected override UniTask OnBeforeStartAsync()
	{
		DeTermItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DeTermItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007A40 RID: 31296 RVA: 0x001FD924 File Offset: 0x001FBB24
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		base.GetExtendToggle(2).CanExecuteChange.Bind(() => this.CanClickCallBack == null || this.CanClickCallBack());
		base.GetExtendToggle(2).OnUndeterminedClicked.Add(new Action(this.OnUndeterminedClicked));
	}

	// Token: 0x06007A41 RID: 31297 RVA: 0x001FD97C File Offset: 0x001FBB7C
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		if (data <= 0)
		{
			base.GetExtendToggle(2).RootUIComp.Get().SetUIActive(false);
			return;
		}
		this.DeTermId = data;
		base.GetExtendToggle(2).RootUIComp.Get().SetUIActive(true);
		string texture = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDeTerm(data).Texture;
		base.SetTextureByPath(texture, base.GetTexture(0), null, null);
	}

	// Token: 0x06007A42 RID: 31298 RVA: 0x001FD9F5 File Offset: 0x001FBBF5
	private void OnClickToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			Action<int, UUIExtendToggle> onClickToggleCallBack = this.OnClickToggleCallBack;
			if (onClickToggleCallBack == null)
			{
				return;
			}
			onClickToggleCallBack(this.DeTermId, base.GetExtendToggle(2));
			return;
		}
		else
		{
			Action<int, UUIExtendToggle> onClickToggleCallBack2 = this.OnClickToggleCallBack;
			if (onClickToggleCallBack2 == null)
			{
				return;
			}
			onClickToggleCallBack2(0, null);
			return;
		}
	}

	// Token: 0x06007A43 RID: 31299 RVA: 0x001FDA2B File Offset: 0x001FBC2B
	public void SetToggleState(EToggleState state)
	{
		base.GetExtendToggle(2).SetToggleStateForce(state, false, false, false);
	}

	// Token: 0x06007A44 RID: 31300 RVA: 0x001FDA40 File Offset: 0x001FBC40
	public void UseChangeColor(bool use)
	{
		UUIItem sprite = base.GetSprite(1);
		FColor? fcolor = new FColor?(base.GetSprite(1).changeColor);
		sprite.SetChangeColor(use, fcolor);
		UUIItem texture = base.GetTexture(0);
		fcolor = new FColor?(base.GetTexture(0).changeColor);
		texture.SetChangeColor(use, fcolor);
	}

	// Token: 0x06007A45 RID: 31301 RVA: 0x001FDA90 File Offset: 0x001FBC90
	private void OnUndeterminedClicked()
	{
		BabelTowerItemInfoViewInfo param = new BabelTowerItemInfoViewInfo
		{
			IsDeTerm = true,
			ConfigId = this.DeTermId,
			ShowWays = true
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BabelTowerItemInfoView, param, null);
	}

	// Token: 0x06007A46 RID: 31302 RVA: 0x001FDAD0 File Offset: 0x001FBCD0
	public void PlayPositionSequence()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 == null)
		{
			return;
		}
		levelSequencePlayer2.PlayLevelSequenceByName("Once_ComBuff", false, null, false);
	}

	// Token: 0x06007A47 RID: 31303 RVA: 0x001FDB10 File Offset: 0x001FBD10
	public void SetDailyQuestItem(bool isActivity)
	{
		this.DeTermDailyQuestItem.SetUiActive(isActivity);
	}

	// Token: 0x06007A48 RID: 31304 RVA: 0x001FDB1E File Offset: 0x001FBD1E
	[NullableContext(1)]
	public UUIExtendToggle GetDeTermToggle()
	{
		return base.GetExtendToggle(2);
	}

	// Token: 0x04003ABB RID: 15035
	public int DeTermId;

	// Token: 0x04003ABC RID: 15036
	public Action<int, UUIExtendToggle> OnClickToggleCallBack;

	// Token: 0x04003ABD RID: 15037
	public Func<bool> CanClickCallBack;

	// Token: 0x04003ABE RID: 15038
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04003ABF RID: 15039
	private DeTermDailyQuestItem DeTermDailyQuestItem;

	// Token: 0x02007553 RID: 30035
	[NullableContext(0)]
	private class EDeTermItem
	{
		// Token: 0x040287C2 RID: 165826
		public const int Texture = 0;

		// Token: 0x040287C3 RID: 165827
		public const int BgSprite = 1;

		// Token: 0x040287C4 RID: 165828
		public const int Toggle = 2;

		// Token: 0x040287C5 RID: 165829
		public const int DailyItem = 4;
	}
}
