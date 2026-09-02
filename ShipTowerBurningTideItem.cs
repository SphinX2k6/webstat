using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020029AB RID: 10667
[NullableContext(1)]
[Nullable(0)]
public class ShipTowerBurningTideItem : UiPanelBase
{
	// Token: 0x06015447 RID: 87111 RVA: 0x005E4DC0 File Offset: 0x005E2FC0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x06015448 RID: 87112 RVA: 0x005E4E48 File Offset: 0x005E3048
	protected override void OnStart()
	{
		this.PointRotator = new FRotator(0f, 0f, 0f);
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
		this.ProgressText = base.GetText(2);
		this.ProgressText.SetText("0%", true);
	}

	// Token: 0x06015449 RID: 87113 RVA: 0x005E4EB8 File Offset: 0x005E30B8
	public void UpdateValue(int curScore, int maxScore)
	{
		float num = (float)curScore / (float)maxScore;
		UUISprite sprite = base.GetSprite(0);
		if (sprite != null)
		{
			sprite.SetFillAmount(num);
		}
		this.PointRotator.Yaw = num * -360f;
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIRelativeRotation(this.PointRotator);
		}
		int num2 = (int)(num * 100f);
		this.ProgressText.SetText(num2.ToString() + "%", true);
		UUIItem progressText = this.ProgressText;
		bool bUseChangeColor = curScore >= maxScore;
		FColor? fcolor = new FColor?(this.ProgressText.changeColor);
		progressText.SetChangeColor(bUseChangeColor, fcolor);
		if (num >= 1f)
		{
			this.PlayLevelSequence("Immortal");
			return;
		}
		this.PlayLevelSequence("Start2");
	}

	// Token: 0x0601544A RID: 87114 RVA: 0x005E4F74 File Offset: 0x005E3174
	private void PlayLevelSequence(string sequenceName)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.ShipTower;
		ELogAuthor author = ELogAuthor.LRC;
		string message = "ShipTowerBurningTideItem 播放序列";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("sequenceName", sequenceName);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
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
		levelSequencePlayer2.PlaySequencePurely(sequenceName, false, false, null, null, false);
	}

	// Token: 0x0601544B RID: 87115 RVA: 0x005E4FDC File Offset: 0x005E31DC
	private void OnSequenceClose(string sequenceName)
	{
		if (sequenceName == "Start")
		{
			this.PlayLevelSequence("Loop2");
			return;
		}
		if (sequenceName == "Start2")
		{
			this.PlayLevelSequence("Loop1");
		}
	}

	// Token: 0x0601544C RID: 87116 RVA: 0x005E500F File Offset: 0x005E320F
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
	}

	// Token: 0x0400A401 RID: 41985
	private FRotator PointRotator;

	// Token: 0x0400A402 RID: 41986
	private UUIText ProgressText;

	// Token: 0x0400A403 RID: 41987
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02008CF8 RID: 36088
	[NullableContext(0)]
	private static class EComponent
	{
		// Token: 0x0402F6BD RID: 194237
		public const int ProgressSprite = 0;

		// Token: 0x0402F6BE RID: 194238
		public const int BuffIconTexture = 1;

		// Token: 0x0402F6BF RID: 194239
		public const int ProgressText = 2;

		// Token: 0x0402F6C0 RID: 194240
		public const int Button = 3;

		// Token: 0x0402F6C1 RID: 194241
		public const int PointItem = 4;
	}
}
