using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200251D RID: 9501
[NullableContext(2)]
[Nullable(0)]
public class VisionFetterSuitItem : GridProxyAbstract<PhantomFetterGroup>
{
	// Token: 0x06012752 RID: 75602 RVA: 0x005149D6 File Offset: 0x00512BD6
	public VisionFetterSuitItem(UUIItem uiItem = null)
	{
		this.SourceItem = uiItem;
	}

	// Token: 0x06012753 RID: 75603 RVA: 0x005149E8 File Offset: 0x00512BE8
	public UniTask Init()
	{
		VisionFetterSuitItem.<Init>d__5 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<VisionFetterSuitItem.<Init>d__5>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06012754 RID: 75604 RVA: 0x00514A2C File Offset: 0x00512C2C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		if (this.OnItemClick != null)
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)));
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.<OnRegisterComponent>g__CallBack|6_0));
			this.BtnBindInfo = list2;
		}
	}

	// Token: 0x06012755 RID: 75605 RVA: 0x00514AF8 File Offset: 0x00512CF8
	public void Update(PhantomFetterGroup? fetterGroupData)
	{
		this.Data = fetterGroupData;
		string hexStr;
		string path;
		if (fetterGroupData == null)
		{
			hexStr = ConfigBase<PhantomBattleConfig>.Instance.GetVisionFetterDefaultColor();
			path = ConfigBase<PhantomBattleConfig>.Instance.GetVisionFetterDefaultTexture();
		}
		else
		{
			hexStr = fetterGroupData.Value.FetterElementColor;
			path = fetterGroupData.Value.FetterElementPath;
		}
		FColor color = FColor.FromHex(hexStr);
		UUISprite sprite = base.GetSprite(0);
		if (sprite != null)
		{
			sprite.SetColor(color);
		}
		base.SetTextureByPath(path, base.GetTexture(1), null, null);
	}

	// Token: 0x06012756 RID: 75606 RVA: 0x00514B8C File Offset: 0x00512D8C
	public override void Refresh(PhantomFetterGroup data, bool isSelected, int gridIndex)
	{
		this.Update(new PhantomFetterGroup?(data));
	}

	// Token: 0x06012757 RID: 75607 RVA: 0x00514B9C File Offset: 0x00512D9C
	[CompilerGenerated]
	private void <OnRegisterComponent>g__CallBack|6_0()
	{
		Action<int> onItemClick = this.OnItemClick;
		if (onItemClick == null)
		{
			return;
		}
		onItemClick(this.Data.Value.Id);
	}

	// Token: 0x0400900A RID: 36874
	private readonly UUIItem SourceItem;

	// Token: 0x0400900B RID: 36875
	private PhantomFetterGroup? Data;

	// Token: 0x0400900C RID: 36876
	public Action<int> OnItemClick;

	// Token: 0x02008835 RID: 34869
	[NullableContext(0)]
	private enum ECommonElementCom
	{
		// Token: 0x0402E017 RID: 188439
		ElementBgSprite,
		// Token: 0x0402E018 RID: 188440
		ElementIconTexture,
		// Token: 0x0402E019 RID: 188441
		ItemButton
	}
}
