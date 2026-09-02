using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D1F RID: 7455
[NullableContext(1)]
[Nullable(0)]
public class KurotatoCountItemPanel : UiPanelBase
{
	// Token: 0x0600DB16 RID: 56086 RVA: 0x003AD75B File Offset: 0x003AB95B
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUISprite))
		};
	}

	// Token: 0x0600DB17 RID: 56087 RVA: 0x003AD794 File Offset: 0x003AB994
	protected override void OnStart()
	{
		this.TextNum = base.GetText(0);
		this.SpriteArrow = base.GetSprite(1);
		this.SpriteArrow.SetUIActive(false);
		this.SeqPlayer = new LevelSequencePlayer(base.GetRootItem());
	}

	// Token: 0x0600DB18 RID: 56088 RVA: 0x003AD7CD File Offset: 0x003AB9CD
	public void Refresh(int num)
	{
		this.TextNum.SetText(num.ToString(), true);
	}

	// Token: 0x0600DB19 RID: 56089 RVA: 0x003AD7E4 File Offset: 0x003AB9E4
	public void PlayAcquireAnim()
	{
		this.SeqPlayer.PlayOrReplaySequenceByName("Acqu", false, null);
	}

	// Token: 0x040068A2 RID: 26786
	private UUIText TextNum;

	// Token: 0x040068A3 RID: 26787
	private UUISprite SpriteArrow;

	// Token: 0x040068A4 RID: 26788
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x02008098 RID: 32920
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BBBA RID: 179130
		public const int TextNum = 0;

		// Token: 0x0402BBBB RID: 179131
		public const int SpriteArrow = 1;
	}
}
