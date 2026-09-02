using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200286A RID: 10346
[NullableContext(1)]
[Nullable(0)]
public class RoleFavorHintItem : UiPanelBase
{
	// Token: 0x060147EE RID: 83950 RVA: 0x005AF945 File Offset: 0x005ADB45
	public RoleFavorHintItem(RoleFavorHintData roleFavorHintData, UUIItem uiItem)
	{
		this.RoleFavorHintData = roleFavorHintData;
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x060147EF RID: 83951 RVA: 0x005AF964 File Offset: 0x005ADB64
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
	}

	// Token: 0x060147F0 RID: 83952 RVA: 0x005AF9D4 File Offset: 0x005ADBD4
	protected override void OnStart()
	{
		if (this.RoleFavorHintData == null)
		{
			return;
		}
		int exp = this.RoleFavorHintData.Exp;
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_IconA80_hgd_UI");
		base.SetTextureByPath(resourcePath, base.GetTexture(0), null, null);
		UUIText text = base.GetText(1);
		Singleton<LguiUtil>.Instance.SetLocalText(text, "FavorExp", Array.Empty<object>());
		UUIText text2 = base.GetText(2);
		if (text2 != null)
		{
			text2.SetText(exp.ToString(), true);
		}
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.SequenceFinish), false);
		this.PlayStart();
	}

	// Token: 0x060147F1 RID: 83953 RVA: 0x005AFA84 File Offset: 0x005ADC84
	private void SequenceFinish(string name)
	{
		if (name == "Start")
		{
			this.PlayHalfway();
			return;
		}
		if (name == "Move")
		{
			this.PlayEnd();
			return;
		}
		if (name == "Close")
		{
			this.OnSequenceFinish();
		}
	}

	// Token: 0x060147F2 RID: 83954 RVA: 0x005AFAC1 File Offset: 0x005ADCC1
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.OnSequenceFinishCallBack = null;
		this.RoleFavorHintData = null;
	}

	// Token: 0x060147F3 RID: 83955 RVA: 0x005AFAE4 File Offset: 0x005ADCE4
	protected void PlayStart()
	{
		this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x060147F4 RID: 83956 RVA: 0x005AFB0C File Offset: 0x005ADD0C
	protected void PlayHalfway()
	{
		this.LevelSequencePlayer.PlayLevelSequenceByName("Move", false, null, false);
	}

	// Token: 0x060147F5 RID: 83957 RVA: 0x005AFB34 File Offset: 0x005ADD34
	public void PlayEnd()
	{
		this.LevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
	}

	// Token: 0x060147F6 RID: 83958 RVA: 0x005AFB5C File Offset: 0x005ADD5C
	public void OnSequenceFinish()
	{
		TOnSequenceFinishCallBack onSequenceFinishCallBack = this.OnSequenceFinishCallBack;
		if (onSequenceFinishCallBack == null)
		{
			return;
		}
		onSequenceFinishCallBack();
	}

	// Token: 0x060147F7 RID: 83959 RVA: 0x005AFB6E File Offset: 0x005ADD6E
	public void SetSequenceFinishCallBack(TOnSequenceFinishCallBack onSequenceFinishCallBack)
	{
		this.OnSequenceFinishCallBack = onSequenceFinishCallBack;
	}

	// Token: 0x04009E6C RID: 40556
	[Nullable(2)]
	private TOnSequenceFinishCallBack OnSequenceFinishCallBack;

	// Token: 0x04009E6D RID: 40557
	[Nullable(2)]
	private RoleFavorHintData RoleFavorHintData;

	// Token: 0x04009E6E RID: 40558
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02008BD4 RID: 35796
	[NullableContext(0)]
	private enum ERoleFavorHintItemCom
	{
		// Token: 0x0402F1D1 RID: 192977
		ItemIcon,
		// Token: 0x0402F1D2 RID: 192978
		ItemNameText,
		// Token: 0x0402F1D3 RID: 192979
		ItemCountText,
		// Token: 0x0402F1D4 RID: 192980
		ItemXText
	}
}
