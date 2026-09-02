using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001221 RID: 4641
[NullableContext(1)]
[Nullable(0)]
public class BabelTowerHardLevelStarItem : UiPanelBase
{
	// Token: 0x06007B7F RID: 31615 RVA: 0x00205D0C File Offset: 0x00203F0C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnLookBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007B80 RID: 31616 RVA: 0x00205E36 File Offset: 0x00204036
	public void SetLookBtnClickCallback(Action callback)
	{
		this.LookBtnClickCallback = callback;
	}

	// Token: 0x06007B81 RID: 31617 RVA: 0x00205E40 File Offset: 0x00204040
	public void RefreshStar(int starNumber)
	{
		UUIArtText artText = base.GetArtText(1);
		if (artText != null)
		{
			artText.SetText(((starNumber < 10) ? "0" : "") + starNumber.ToString());
		}
	}

	// Token: 0x06007B82 RID: 31618 RVA: 0x00205E7C File Offset: 0x0020407C
	public void SetDifficultyBg(string colorHex)
	{
		UUISprite sprite = base.GetSprite(2);
		if (sprite != null)
		{
			FColor color = FColor.FromHex(colorHex);
			sprite.SetColor(color);
		}
	}

	// Token: 0x06007B83 RID: 31619 RVA: 0x00205EA4 File Offset: 0x002040A4
	public void SetDifficultyText(string difficultyTextKey)
	{
		UUIText text = base.GetText(3);
		if (text != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, difficultyTextKey, Array.Empty<object>());
		}
	}

	// Token: 0x06007B84 RID: 31620 RVA: 0x00205ED0 File Offset: 0x002040D0
	public void SetDeBuffNum(int deBuffCount)
	{
		UUIText text = base.GetText(4);
		if (text != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Babel_fuhe", new <>z__ReadOnlySingleElementList<object>(deBuffCount));
		}
	}

	// Token: 0x06007B85 RID: 31621 RVA: 0x00205F04 File Offset: 0x00204104
	public void SetNameText(string nameTextKey)
	{
		UUIText text = base.GetText(5);
		if (text != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, nameTextKey, Array.Empty<object>());
		}
	}

	// Token: 0x06007B86 RID: 31622 RVA: 0x00205F2D File Offset: 0x0020412D
	private void OnLookBtnClick()
	{
		Action lookBtnClickCallback = this.LookBtnClickCallback;
		if (lookBtnClickCallback == null)
		{
			return;
		}
		lookBtnClickCallback();
	}

	// Token: 0x04003B20 RID: 15136
	[Nullable(2)]
	private Action LookBtnClickCallback;

	// Token: 0x02007588 RID: 30088
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x040288D5 RID: 166101
		public const int LookBtn = 0;

		// Token: 0x040288D6 RID: 166102
		public const int StartNumText = 1;

		// Token: 0x040288D7 RID: 166103
		public const int DiffColorBg = 2;

		// Token: 0x040288D8 RID: 166104
		public const int DiffColorText = 3;

		// Token: 0x040288D9 RID: 166105
		public const int DeBuffNumText = 4;

		// Token: 0x040288DA RID: 166106
		public const int NameText = 5;
	}
}
