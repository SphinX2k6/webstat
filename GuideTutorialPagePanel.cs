using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E31 RID: 7729
public class GuideTutorialPagePanel : UiPanelBase
{
	// Token: 0x0600E4B1 RID: 58545 RVA: 0x003DB3A8 File Offset: 0x003D95A8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600E4B2 RID: 58546 RVA: 0x003DB453 File Offset: 0x003D9653
	protected override void OnStart()
	{
		this.GuideDescribeNew = new GuideDescribeNew(base.GetText(2));
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		base.GetTexture(3).SetUIActive(false);
	}

	// Token: 0x0600E4B3 RID: 58547 RVA: 0x003DB485 File Offset: 0x003D9685
	protected override void OnBeforeDestroy()
	{
		this.LevelSequencePlayer.Clear();
		this.LevelSequencePlayer = null;
	}

	// Token: 0x0600E4B4 RID: 58548 RVA: 0x003DB499 File Offset: 0x003D9699
	[NullableContext(1)]
	public void Init(UUIItem uiItem)
	{
		base.SetRootActor(uiItem.GetOwner(), true);
		this.GuideDescribeNew = new GuideDescribeNew(base.GetText(2));
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		base.GetTexture(3).SetUIActive(false);
	}

	// Token: 0x0600E4B5 RID: 58549 RVA: 0x003DB4D8 File Offset: 0x003D96D8
	public void RefreshPage(GuideTutorialPage? pageConfig)
	{
		if (pageConfig == null)
		{
			return;
		}
		if (StringUtils.IsEmpty(pageConfig.Value.SubTitle))
		{
			base.GetItem(0).SetUIActive(false);
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), pageConfig.Value.SubTitle, Array.Empty<object>());
			base.GetItem(0).SetUIActive(true);
		}
		if (!StringUtils.IsEmpty(pageConfig.Value.Pic))
		{
			base.SetTextureByPath(pageConfig.Value.Pic, base.GetTexture(3), null, delegate(bool _)
			{
				base.GetTexture(3).SetUIActive(true);
			});
		}
		base.GetText(2).SetUIActive(true);
		this.GuideDescribeNew.SetUpText(pageConfig.Value.Content, pageConfig.Value.Button());
	}

	// Token: 0x0600E4B6 RID: 58550 RVA: 0x003DB5C4 File Offset: 0x003D97C4
	public void PlayAnime(bool isShow)
	{
		this.LevelSequencePlayer.PlayLevelSequenceByName(isShow ? "Show" : "Hide", false, null, false);
	}

	// Token: 0x04006DF6 RID: 28150
	[Nullable(2)]
	private GuideDescribeNew GuideDescribeNew;

	// Token: 0x04006DF7 RID: 28151
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0200819F RID: 33183
	private enum ETutorialsPageComponents
	{
		// Token: 0x0402C007 RID: 180231
		PnlOffset,
		// Token: 0x0402C008 RID: 180232
		TxtSubTitle,
		// Token: 0x0402C009 RID: 180233
		TxtTutorials,
		// Token: 0x0402C00A RID: 180234
		TexPicture
	}
}
