using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200120A RID: 4618
public class BabelTowerDeTermSelectDesItem : GridProxyAbstract<int>
{
	// Token: 0x06007A2E RID: 31278 RVA: 0x001FD25C File Offset: 0x001FB45C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007A2F RID: 31279 RVA: 0x001FD344 File Offset: 0x001FB544
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06007A30 RID: 31280 RVA: 0x001FD358 File Offset: 0x001FB558
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.DeTermId = data;
		BabelTowerDeTerm babelTowerDeTerm = ConfigBase<BabelTowerConfig>.Instance.GetBabelTowerDeTerm(data);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), babelTowerDeTerm.DesText, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), babelTowerDeTerm.NameText, Array.Empty<object>());
		base.GetText(1).SetText(babelTowerDeTerm.Star.ToString() ?? "", true);
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.StopCurrentSequence(false, true);
	}

	// Token: 0x06007A31 RID: 31281 RVA: 0x001FD3E9 File Offset: 0x001FB5E9
	private void OnClickBtn()
	{
		Action<int> onClickCallBack = this.OnClickCallBack;
		if (onClickCallBack == null)
		{
			return;
		}
		onClickCallBack(this.DeTermId);
	}

	// Token: 0x06007A32 RID: 31282 RVA: 0x001FD404 File Offset: 0x001FB604
	public void PlayChoseSequence()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, true);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 == null)
		{
			return;
		}
		levelSequencePlayer2.PlayLevelSequenceByName("Loop_Center_Once", false, null, false);
	}

	// Token: 0x04003AB3 RID: 15027
	public int DeTermId;

	// Token: 0x04003AB4 RID: 15028
	[Nullable(2)]
	public LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04003AB5 RID: 15029
	[Nullable(2)]
	public Action<int> OnClickCallBack;

	// Token: 0x02007550 RID: 30032
	private class EComponentDefine
	{
		// Token: 0x040287B7 RID: 165815
		public const int NameText = 0;

		// Token: 0x040287B8 RID: 165816
		public const int NumberText = 1;

		// Token: 0x040287B9 RID: 165817
		public const int BgItem = 2;

		// Token: 0x040287BA RID: 165818
		public const int DeTermBtn = 3;

		// Token: 0x040287BB RID: 165819
		public const int TitleText = 4;
	}
}
