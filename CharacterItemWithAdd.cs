using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013B8 RID: 5048
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CharacterItemWithAdd : GridProxyAbstract<CharacterData>
{
	// Token: 0x06008B56 RID: 35670 RVA: 0x0024B320 File Offset: 0x00249520
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06008B57 RID: 35671 RVA: 0x0024B37C File Offset: 0x0024957C
	protected override UniTask OnBeforeStartAsync()
	{
		CharacterItemWithAdd.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CharacterItemWithAdd.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008B58 RID: 35672 RVA: 0x0024B3C0 File Offset: 0x002495C0
	public void RefreshAddText()
	{
		if (this.Data.ValueInterval > 0)
		{
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText("+" + this.Data.ValueInterval.ToString(), true);
			return;
		}
		else
		{
			UUIText text2 = base.GetText(1);
			if (text2 == null)
			{
				return;
			}
			text2.SetText("", true);
			return;
		}
	}

	// Token: 0x06008B59 RID: 35673 RVA: 0x0024B41F File Offset: 0x0024961F
	public override void Refresh(CharacterData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.CharacterItem.Refresh(data, isSelected, gridIndex);
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(gridIndex != 0);
	}

	// Token: 0x06008B5A RID: 35674 RVA: 0x0024B44C File Offset: 0x0024964C
	public void RefreshProgress(float percent)
	{
		int value = this.Data.CurrentValue - this.Data.ValueInterval + (int)((float)this.Data.ValueInterval * percent);
		this.CharacterItem.RefreshProgress(value, this.Data.MaxValue);
	}

	// Token: 0x06008B5B RID: 35675 RVA: 0x0024B498 File Offset: 0x00249698
	public void RefreshCurrentValue(float percent)
	{
		int value = this.Data.CurrentValue - this.Data.ValueInterval + (int)((float)this.Data.ValueInterval * percent);
		this.CharacterItem.RefreshCurrentValue(value);
	}

	// Token: 0x06008B5C RID: 35676 RVA: 0x0024B4DC File Offset: 0x002496DC
	public void RefreshProgressAdd(float percent)
	{
		int value = this.Data.CurrentValue - this.Data.ValueInterval + (int)((float)this.Data.ValueInterval * percent);
		this.CharacterItem.RefreshProgressAdd(value, this.Data.MaxValue);
	}

	// Token: 0x06008B5D RID: 35677 RVA: 0x0024B528 File Offset: 0x00249728
	public void PlayStartAction()
	{
		this.CharacterItem.SetLightProgressWidth();
		this.SequencePlayer.PlayLevelSequenceByName("Action01", false, null, false);
	}

	// Token: 0x06008B5E RID: 35678 RVA: 0x0024B55C File Offset: 0x0024975C
	public void PlayAddAction()
	{
		this.SequencePlayer.PlayLevelSequenceByName("Action02", false, null, false);
	}

	// Token: 0x06008B5F RID: 35679 RVA: 0x0024B584 File Offset: 0x00249784
	public void SetLightProgressWidth()
	{
		this.CharacterItem.SetLightProgressWidth();
	}

	// Token: 0x06008B60 RID: 35680 RVA: 0x0024B594 File Offset: 0x00249794
	public void PlayEndAction()
	{
		this.SequencePlayer.PlayLevelSequenceByName("Action03", false, null, false);
	}

	// Token: 0x04004115 RID: 16661
	[Nullable(2)]
	protected CharacterItem CharacterItem;

	// Token: 0x04004116 RID: 16662
	protected CharacterData Data;

	// Token: 0x04004117 RID: 16663
	protected LevelSequencePlayer SequencePlayer;

	// Token: 0x0200777F RID: 30591
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402923D RID: 168509
		public const int CharacterItem = 0;

		// Token: 0x0402923E RID: 168510
		public const int AddText = 1;

		// Token: 0x0402923F RID: 168511
		public const int LineItem = 2;
	}
}
