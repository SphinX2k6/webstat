using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020018AB RID: 6315
[NullableContext(1)]
[Nullable(0)]
public class CommonWarningItem : UiPanelBase
{
	// Token: 0x0600B565 RID: 46437 RVA: 0x00304920 File Offset: 0x00302B20
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600B566 RID: 46438 RVA: 0x003049AC File Offset: 0x00302BAC
	public void SetWarningIcon(string iconPath)
	{
		base.SetTextureByPath(iconPath, base.GetTexture(1), null, null);
	}

	// Token: 0x0600B567 RID: 46439 RVA: 0x003049D1 File Offset: 0x00302BD1
	public void SetIconVisible(bool visible)
	{
		UUITexture texture = base.GetTexture(1);
		if (texture == null)
		{
			return;
		}
		texture.SetUIActive(visible);
	}

	// Token: 0x0600B568 RID: 46440 RVA: 0x003049E5 File Offset: 0x00302BE5
	public void SetLocalText(string textId, params object[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), textId, args);
	}

	// Token: 0x0600B569 RID: 46441 RVA: 0x003049FA File Offset: 0x00302BFA
	public void SetLocalTextNew(string textId, params object[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textId, args);
	}

	// Token: 0x0600B56A RID: 46442 RVA: 0x00304A0F File Offset: 0x00302C0F
	public void TrySetLocalTextNew(string textId, params object[] args)
	{
		Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(2), textId, args);
	}

	// Token: 0x0600B56B RID: 46443 RVA: 0x00304A24 File Offset: 0x00302C24
	public void SetShowText(string text)
	{
		base.GetText(2).SetText(text, true);
	}

	// Token: 0x0600B56C RID: 46444 RVA: 0x00304A34 File Offset: 0x00302C34
	public void SetTextShowState(bool state)
	{
		base.GetText(2).SetUIActive(state);
	}

	// Token: 0x02007C36 RID: 31798
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402A6C1 RID: 173761
		public const int ItemSelf = 0;

		// Token: 0x0402A6C2 RID: 173762
		public const int TextureIcon = 1;

		// Token: 0x0402A6C3 RID: 173763
		public const int TextTip = 2;
	}
}
