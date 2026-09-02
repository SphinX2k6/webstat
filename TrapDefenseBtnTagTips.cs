using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002C1D RID: 11293
public class TrapDefenseBtnTagTips : UiPanelBase
{
	// Token: 0x060169A5 RID: 92581 RVA: 0x00645DD8 File Offset: 0x00643FD8
	[NullableContext(1)]
	public UniTask Init(UUIItem item)
	{
		TrapDefenseBtnTagTips.<Init>d__1 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.item = item;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<TrapDefenseBtnTagTips.<Init>d__1>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x060169A6 RID: 92582 RVA: 0x00645E23 File Offset: 0x00644023
	protected override void OnBeforeCreate()
	{
	}

	// Token: 0x060169A7 RID: 92583 RVA: 0x00645E28 File Offset: 0x00644028
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060169A8 RID: 92584 RVA: 0x00645ED4 File Offset: 0x006440D4
	protected override UniTask OnBeforeStartAsync()
	{
		TrapDefenseBtnTagTips.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseBtnTagTips.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060169A9 RID: 92585 RVA: 0x00645F17 File Offset: 0x00644117
	protected override void OnStart()
	{
	}

	// Token: 0x060169AA RID: 92586 RVA: 0x00645F19 File Offset: 0x00644119
	protected override void OnBeforeShow()
	{
	}

	// Token: 0x060169AB RID: 92587 RVA: 0x00645F1B File Offset: 0x0064411B
	protected override void OnBeforeDestroy()
	{
	}

	// Token: 0x060169AC RID: 92588 RVA: 0x00645F20 File Offset: 0x00644120
	public void UpdateQuality(ETrapDefenseBdBuffQuality quality)
	{
		UUISprite sprite = base.GetSprite(2);
		FColor? fcolor;
		if (quality == ETrapDefenseBdBuffQuality.Purple)
		{
			this.ShowBg(1);
			UUIItem uuiitem = sprite;
			bool bUseChangeColor = true;
			fcolor = new FColor?(sprite.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			return;
		}
		if (quality != ETrapDefenseBdBuffQuality.Gold)
		{
			this.ShowBg(1);
			UUIItem uuiitem2 = sprite;
			bool bUseChangeColor2 = true;
			fcolor = new FColor?(sprite.changeColor);
			uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
			return;
		}
		this.ShowBg(0);
		UUIItem uuiitem3 = sprite;
		bool bUseChangeColor3 = false;
		fcolor = new FColor?(sprite.changeColor);
		uuiitem3.SetChangeColor(bUseChangeColor3, fcolor);
	}

	// Token: 0x060169AD RID: 92589 RVA: 0x00645F98 File Offset: 0x00644198
	public void UpdateDescForBuffSelect(ETrapDefenseBdBuffQuality quality)
	{
		if (quality == ETrapDefenseBdBuffQuality.Purple)
		{
			this.SetDesc(ETrapDefenseTextKey.BdBuffSelectPurpleBuffToPool.ToString(), Array.Empty<string>());
			return;
		}
		if (quality != ETrapDefenseBdBuffQuality.Gold)
		{
			this.SetDesc(ETrapDefenseTextKey.BdBuffSelectPurpleBuffToPool.ToString(), Array.Empty<string>());
			return;
		}
		this.SetDesc(ETrapDefenseTextKey.BdBuffSelectGoldBuffToPool.ToString(), Array.Empty<string>());
	}

	// Token: 0x060169AE RID: 92590 RVA: 0x00646004 File Offset: 0x00644204
	private void ShowBg(int key)
	{
		foreach (int num in new List<int>
		{
			1,
			0
		})
		{
			UUIItem item = base.GetItem(num);
			if (item != null)
			{
				item.SetUIActive(num == key);
			}
		}
	}

	// Token: 0x060169AF RID: 92591 RVA: 0x00646074 File Offset: 0x00644274
	[NullableContext(1)]
	public void SetDesc(string textKey, params string[] args)
	{
		UUIText text = base.GetText(3);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textKey, args);
	}

	// Token: 0x02008F43 RID: 36675
	private class EChildType
	{
		// Token: 0x040301CD RID: 197069
		public const int ItemBgGold = 0;

		// Token: 0x040301CE RID: 197070
		public const int ItemBgPurple = 1;

		// Token: 0x040301CF RID: 197071
		public const int SpriteArrow = 2;

		// Token: 0x040301D0 RID: 197072
		public const int TextDesc = 3;
	}
}
