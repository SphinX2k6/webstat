using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E19 RID: 7705
[NullableContext(1)]
[Nullable(0)]
public class GreatSwordGoalItem : UiPanelBase, IGridProxy<TrialSubChallenge>
{
	// Token: 0x170011C3 RID: 4547
	// (get) Token: 0x0600E372 RID: 58226 RVA: 0x003D3CBC File Offset: 0x003D1EBC
	// (set) Token: 0x0600E373 RID: 58227 RVA: 0x003D3CC4 File Offset: 0x003D1EC4
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	public IScrollViewDelegate<IGridProxy<TrialSubChallenge>, TrialSubChallenge> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})] set; }

	// Token: 0x170011C4 RID: 4548
	// (get) Token: 0x0600E374 RID: 58228 RVA: 0x003D3CCD File Offset: 0x003D1ECD
	// (set) Token: 0x0600E375 RID: 58229 RVA: 0x003D3CD5 File Offset: 0x003D1ED5
	public int GridIndex { get; set; }

	// Token: 0x170011C5 RID: 4549
	// (get) Token: 0x0600E376 RID: 58230 RVA: 0x003D3CDE File Offset: 0x003D1EDE
	// (set) Token: 0x0600E377 RID: 58231 RVA: 0x003D3CE6 File Offset: 0x003D1EE6
	public int DisplayIndex { get; set; }

	// Token: 0x0600E378 RID: 58232 RVA: 0x003D3CF0 File Offset: 0x003D1EF0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUISprite))
		};
	}

	// Token: 0x0600E379 RID: 58233 RVA: 0x003D3D4C File Offset: 0x003D1F4C
	public void Refresh(TrialSubChallenge data, bool isSelected, int gridIndex)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Config.GoalText, Array.Empty<object>());
		base.GetSprite(1).SetUIActive(!data.Completed);
		base.GetSprite(2).SetUIActive(data.Completed);
	}

	// Token: 0x0600E37A RID: 58234 RVA: 0x003D3DA4 File Offset: 0x003D1FA4
	public void Clear()
	{
	}

	// Token: 0x0600E37B RID: 58235 RVA: 0x003D3DA6 File Offset: 0x003D1FA6
	public void OnSelected(bool isSelected)
	{
	}

	// Token: 0x0600E37C RID: 58236 RVA: 0x003D3DA8 File Offset: 0x003D1FA8
	public void OnDeselected(bool isSelected)
	{
	}

	// Token: 0x0600E37D RID: 58237 RVA: 0x003D3DAC File Offset: 0x003D1FAC
	public object GetKey(TrialSubChallenge data, int index)
	{
		return data.Config.Id;
	}

	// Token: 0x04006D66 RID: 28006
	private IGridProxy<TrialSubChallenge> GridProxyImplementation;
}
