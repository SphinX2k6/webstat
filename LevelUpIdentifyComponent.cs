using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200251F RID: 9503
[NullableContext(1)]
[Nullable(0)]
public class LevelUpIdentifyComponent : UiPanelBase
{
	// Token: 0x0601275C RID: 75612 RVA: 0x00514D6B File Offset: 0x00512F6B
	public LevelUpIdentifyComponent(UUIItem uiItem)
	{
		this.ComponentItem = uiItem;
	}

	// Token: 0x0601275D RID: 75613 RVA: 0x00514D7C File Offset: 0x00512F7C
	public UniTask Init(string sourceView)
	{
		LevelUpIdentifyComponent.<Init>d__6 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.sourceView = sourceView;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<LevelUpIdentifyComponent.<Init>d__6>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0601275E RID: 75614 RVA: 0x00514DC7 File Offset: 0x00512FC7
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0601275F RID: 75615 RVA: 0x00514E00 File Offset: 0x00513000
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<VisionIdentifyItem, VisionSubPropViewData>(base.GetVerticalLayout(0), new Func<VisionIdentifyItem>(this.InitItem), null, false, true);
		base.GetItem(1).SetUIActive(false);
	}

	// Token: 0x06012760 RID: 75616 RVA: 0x00514E30 File Offset: 0x00513030
	private VisionIdentifyItem InitItem()
	{
		return new VisionIdentifyItem();
	}

	// Token: 0x06012761 RID: 75617 RVA: 0x00514E38 File Offset: 0x00513038
	public UniTask PlayUpdateAnimation(int[] needPlayIndex)
	{
		LevelUpIdentifyComponent.<PlayUpdateAnimation>d__10 <PlayUpdateAnimation>d__;
		<PlayUpdateAnimation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayUpdateAnimation>d__.<>4__this = this;
		<PlayUpdateAnimation>d__.needPlayIndex = needPlayIndex;
		<PlayUpdateAnimation>d__.<>1__state = -1;
		<PlayUpdateAnimation>d__.<>t__builder.Start<LevelUpIdentifyComponent.<PlayUpdateAnimation>d__10>(ref <PlayUpdateAnimation>d__);
		return <PlayUpdateAnimation>d__.<>t__builder.Task;
	}

	// Token: 0x06012762 RID: 75618 RVA: 0x00514E84 File Offset: 0x00513084
	public void Update([Nullable(new byte[]
	{
		1,
		2
	})] VisionSubPropData[] data, bool ifPreCache)
	{
		this.ReloadState = new CustomPromise<bool>();
		if (data.Length != 0)
		{
			List<VisionSubPropViewData> list = new List<VisionSubPropViewData>();
			foreach (VisionSubPropData data2 in data)
			{
				VisionSubPropViewData item = new VisionSubPropViewData
				{
					Data = data2,
					SourceView = this.SourceViewName,
					IfPreCache = ifPreCache
				};
				list.Add(item);
			}
			this.Layout.RefreshByData(list, delegate
			{
				if (this.ReloadState != null && !this.ReloadState.IsFulfilled)
				{
					this.ReloadState.SetResult(true);
				}
			}, false);
		}
	}

	// Token: 0x0400900D RID: 36877
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<VisionIdentifyItem, VisionSubPropViewData> Layout;

	// Token: 0x0400900E RID: 36878
	[Nullable(2)]
	private readonly UUIItem ComponentItem;

	// Token: 0x0400900F RID: 36879
	[Nullable(2)]
	private string SourceViewName;

	// Token: 0x04009010 RID: 36880
	[Nullable(2)]
	private CustomPromise<bool> ReloadState;

	// Token: 0x02008838 RID: 34872
	[NullableContext(0)]
	private enum ELevelAttribute
	{
		// Token: 0x0402E025 RID: 188453
		Layout,
		// Token: 0x0402E026 RID: 188454
		Item
	}
}
