using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001EC0 RID: 7872
public class HelpGuidePage : UiPanelBase
{
	// Token: 0x0600E8A2 RID: 59554 RVA: 0x003EE7F0 File Offset: 0x003EC9F0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUITexture))
		};
	}

	// Token: 0x0600E8A3 RID: 59555 RVA: 0x003EE860 File Offset: 0x003ECA60
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
		base.GetTexture(3).SetUIActive(false);
		base.GetText(2).SetUIActive(false);
		base.GetItem(0).SetUIActive(false);
	}

	// Token: 0x0600E8A4 RID: 59556 RVA: 0x003EE89A File Offset: 0x003ECA9A
	protected override void OnBeforeDestroy()
	{
		this.LevelSequencePlayer.Clear();
		this.LevelSequencePlayer = null;
	}

	// Token: 0x0600E8A5 RID: 59557 RVA: 0x003EE8B0 File Offset: 0x003ECAB0
	public void RefreshPage(HelpText? pageConfig)
	{
		if (pageConfig == null)
		{
			return;
		}
		bool flag = !StringUtils.IsEmpty(pageConfig.Value.Picture);
		base.GetTexture(3).SetUIActive(flag);
		if (flag)
		{
			base.SetTextureByPath(pageConfig.Value.Picture, base.GetTexture(3), null, delegate(bool _)
			{
				base.GetTexture(3).SetUIActive(true);
			});
		}
		bool flag2 = !StringUtils.IsEmpty(pageConfig.Value.Content);
		base.GetText(2).SetUIActive(flag2);
		if (flag2)
		{
			base.GetText(2).ShowTextNew(pageConfig.Value.Content);
		}
	}

	// Token: 0x0600E8A6 RID: 59558 RVA: 0x003EE964 File Offset: 0x003ECB64
	public void PlayAnime(bool isShow)
	{
		this.LevelSequencePlayer.PlayLevelSequenceByName(isShow ? "Show" : "Hide", false, null, false);
	}

	// Token: 0x04007014 RID: 28692
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02008202 RID: 33282
	private static class ETutorialsPageComponents
	{
		// Token: 0x0402C196 RID: 180630
		public const int PnlOffset = 0;

		// Token: 0x0402C197 RID: 180631
		public const int TxtSubTitle = 1;

		// Token: 0x0402C198 RID: 180632
		public const int TxtTutorials = 2;

		// Token: 0x0402C199 RID: 180633
		public const int TexPicture = 3;
	}
}
