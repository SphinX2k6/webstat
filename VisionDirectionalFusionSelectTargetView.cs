using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001804 RID: 6148
[NullableContext(1)]
[Nullable(0)]
public class VisionDirectionalFusionSelectTargetView : UiViewBase
{
	// Token: 0x0600AEBD RID: 44733 RVA: 0x002E8BD9 File Offset: 0x002E6DD9
	public VisionDirectionalFusionSelectTargetView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600AEBE RID: 44734 RVA: 0x002E8BE4 File Offset: 0x002E6DE4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(2, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickRightBtn))
		};
	}

	// Token: 0x0600AEBF RID: 44735 RVA: 0x002E8C4C File Offset: 0x002E6E4C
	protected override void OnStart()
	{
		this.GirdLayout = new GenericLayout<SelectTargetItem, int>(base.GetGridLayout(2), new Func<SelectTargetItem>(this.InitGird), null, false, true);
		IReadOnlyList<PhantomDirectRefining> phantomDirectRefiningAll = ConfigBase<CalabashConfig>.Instance.GetPhantomDirectRefiningAll();
		List<int> list = new List<int>();
		if (phantomDirectRefiningAll != null)
		{
			foreach (PhantomDirectRefining phantomDirectRefining in phantomDirectRefiningAll)
			{
				list.Add(phantomDirectRefining.FetterGroup);
			}
		}
		list.Sort(delegate(int a, int b)
		{
			int[] fetterGroupMonsterIdArray = ModelBase<PhantomBattleModel>.Instance.GetFetterGroupMonsterIdArray(a);
			int num = (ModelBase<PhantomBattleModel>.Instance.GetMonsterFindCountByMonsterIdArrayWithoutCost4(fetterGroupMonsterIdArray) > 0) ? 1 : 0;
			int[] fetterGroupMonsterIdArray2 = ModelBase<PhantomBattleModel>.Instance.GetFetterGroupMonsterIdArray(b);
			int num2 = (ModelBase<PhantomBattleModel>.Instance.GetMonsterFindCountByMonsterIdArrayWithoutCost4(fetterGroupMonsterIdArray2) > 0) ? 1 : 0;
			if (num != num2)
			{
				return num2 - num;
			}
			return b - a;
		});
		this.GirdLayout.RefreshByData(list, delegate
		{
			this.RefreshButton();
		}, false);
	}

	// Token: 0x0600AEC0 RID: 44736 RVA: 0x002E8D10 File Offset: 0x002E6F10
	private SelectTargetItem InitGird()
	{
		return new SelectTargetItem
		{
			OnClickToggleCallBack = new Action<int, UUIExtendToggle>(this.OnClickGirdToggle)
		};
	}

	// Token: 0x0600AEC1 RID: 44737 RVA: 0x002E8D29 File Offset: 0x002E6F29
	private void RefreshButton()
	{
		base.GetButton(1).SetSelfInteractive(this.CurrentSelectFetter > 0);
	}

	// Token: 0x0600AEC2 RID: 44738 RVA: 0x002E8D40 File Offset: 0x002E6F40
	private void OnClickRightBtn()
	{
		ModelBase<CalabashModel>.Instance.SetDirectionalFusionTargetFetter(this.CurrentSelectFetter);
		base.CloseMe(null);
	}

	// Token: 0x0600AEC3 RID: 44739 RVA: 0x002E8D5C File Offset: 0x002E6F5C
	private void OnClickGirdToggle(int fetter, UUIExtendToggle toggle)
	{
		if (fetter <= 0)
		{
			this.CurrentSelectFetter = fetter;
			this.CurrentSelectToggle = null;
			this.RefreshButton();
			return;
		}
		if (this.CurrentSelectFetter == fetter)
		{
			return;
		}
		UUIExtendToggle currentSelectToggle = this.CurrentSelectToggle;
		if (currentSelectToggle != null)
		{
			currentSelectToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentSelectToggle = toggle;
		this.CurrentSelectFetter = fetter;
		this.RefreshButton();
	}

	// Token: 0x040052EE RID: 21230
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<SelectTargetItem, int> GirdLayout;

	// Token: 0x040052EF RID: 21231
	private int CurrentSelectFetter;

	// Token: 0x040052F0 RID: 21232
	[Nullable(2)]
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x02007B77 RID: 31607
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A336 RID: 172854
		LeftBtn,
		// Token: 0x0402A337 RID: 172855
		RightBtn,
		// Token: 0x0402A338 RID: 172856
		GirdLayout
	}
}
