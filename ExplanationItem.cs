using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002BB1 RID: 11185
[Nullable(new byte[]
{
	0,
	1
})]
public class ExplanationItem : GridProxyAbstract<string>
{
	// Token: 0x0601645C RID: 91228 RVA: 0x0062B4D0 File Offset: 0x006296D0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0601645D RID: 91229 RVA: 0x0062B539 File Offset: 0x00629739
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
	}

	// Token: 0x0601645E RID: 91230 RVA: 0x0062B54C File Offset: 0x0062974C
	public override void OnSelected(bool fireEvent)
	{
		this.LevelSequencePlayer.PlayLevelSequenceByName("SelectIn", false, null, false);
	}

	// Token: 0x0601645F RID: 91231 RVA: 0x0062B574 File Offset: 0x00629774
	[NullableContext(1)]
	public override void Refresh(string data, bool isSelected, int gridIndex)
	{
		int num;
		if (!int.TryParse(data, out num))
		{
			return;
		}
		TermConfig? config = ConfigTermConfigById.GetConfig(num, true);
		if (config == null)
		{
			return;
		}
		TermConfig value = config.Value;
		object[] array2;
		if (value.Placeholder().Length != 0)
		{
			object[] array = value.Placeholder();
			array2 = array;
		}
		else
		{
			array2 = new object[0];
		}
		object[] args = array2;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 2);
		defaultInterpolatedStringHandler.AppendLiteral("Term");
		defaultInterpolatedStringHandler.AppendFormatted<int>(num);
		defaultInterpolatedStringHandler.AppendLiteral("_");
		defaultInterpolatedStringHandler.AppendFormatted("Title");
		string textStringId = defaultInterpolatedStringHandler.ToStringAndClear();
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 2);
		defaultInterpolatedStringHandler.AppendLiteral("Term");
		defaultInterpolatedStringHandler.AppendFormatted<int>(num);
		defaultInterpolatedStringHandler.AppendLiteral("_");
		defaultInterpolatedStringHandler.AppendFormatted("Desc");
		string textStringId2 = defaultInterpolatedStringHandler.ToStringAndClear();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textStringId, args);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId2, args);
		if (isSelected)
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("SelectIn", false, null, false);
			return;
		}
		this.LevelSequencePlayer.PlayLevelSequenceByName("SelectOut", false, null, false);
	}

	// Token: 0x06016460 RID: 91232 RVA: 0x0062B6A4 File Offset: 0x006298A4
	public override void Clear()
	{
		this.LevelSequencePlayer.StopCurrentSequence(false, false);
		this.LevelSequencePlayer.PlayLevelSequenceByName("SelectOut", false, null, false);
	}

	// Token: 0x0400AC5D RID: 44125
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02008EAD RID: 36525
	private class EExplanationComponentDefine
	{
		// Token: 0x0402FF26 RID: 196390
		public const int TextTitle = 0;

		// Token: 0x0402FF27 RID: 196391
		public const int TextContent = 1;
	}
}
