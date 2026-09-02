using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleUi.RoleBreach;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200287E RID: 10366
[NullableContext(1)]
[Nullable(0)]
public class RoleBreakPreviewView : UiViewBase
{
	// Token: 0x06014849 RID: 84041 RVA: 0x005B1731 File Offset: 0x005AF931
	public RoleBreakPreviewView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601484A RID: 84042 RVA: 0x005B173C File Offset: 0x005AF93C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickLeft)),
			new ValueTuple<int, Delegate>(7, new Action(this.OnClickRight)),
			new ValueTuple<int, Delegate>(8, new Action(this.OnClickClose))
		};
	}

	// Token: 0x0601484B RID: 84043 RVA: 0x005B189C File Offset: 0x005AFA9C
	protected override UniTask OnBeforeStartAsync()
	{
		RoleBreakPreviewView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleBreakPreviewView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601484C RID: 84044 RVA: 0x005B18E0 File Offset: 0x005AFAE0
	protected override void OnStart()
	{
		this.LevelLayoutInstance = new GenericLayout<LevelLayoutGrid, ILevelLayoutGridData>(base.GetHorizontalLayout(0), new Func<LevelLayoutGrid>(this.BoundViewModel.CreateLevelLayoutGrid), null, false, true);
		this.ItemLayoutInstance = new GenericLayout<CostMediumItemGrid, ISelectedData>(base.GetHorizontalLayout(3), new Func<CostMediumItemGrid>(this.BoundViewModel.CreateItemLayoutGrid), null, false, true);
		this.BoundViewModel.BindView(this);
		this.BoundViewModel.HandleViewOnStart();
	}

	// Token: 0x0601484D RID: 84045 RVA: 0x005B1950 File Offset: 0x005AFB50
	protected override void OnBeforeDestroy()
	{
		this.BoundViewModel.Dispose();
		this.BoundViewModel = null;
		this.LevelLayoutInstance = null;
		this.ItemLayoutInstance = null;
		this.CostContentItemInstance = null;
	}

	// Token: 0x0601484E RID: 84046 RVA: 0x005B197C File Offset: 0x005AFB7C
	public void RefreshLevelLayout(ILevelLayoutGridData[] data)
	{
		List<ILevelLayoutGridData> list = new List<ILevelLayoutGridData>(data.Length);
		for (int i = 0; i < data.Length; i++)
		{
			list.Add(data[i]);
		}
		this.LevelLayoutInstance.RefreshByData(list, null, false);
	}

	// Token: 0x0601484F RID: 84047 RVA: 0x005B19B8 File Offset: 0x005AFBB8
	public void RefreshItemLayout(ISelectedData[] data)
	{
		List<ISelectedData> list = new List<ISelectedData>(data.Length);
		for (int i = 0; i < data.Length; i++)
		{
			list.Add(data[i]);
		}
		this.ItemLayoutInstance.RefreshByData(list, delegate
		{
			GenericLayout<CostMediumItemGrid, ISelectedData> itemLayoutInstance = this.ItemLayoutInstance;
			if (itemLayoutInstance == null)
			{
				return;
			}
			UUIInturnAnimController uiAnimController = itemLayoutInstance.GetUiAnimController();
			if (uiAnimController == null)
			{
				return;
			}
			uiAnimController.Play("", -1, false);
		}, false);
	}

	// Token: 0x06014850 RID: 84048 RVA: 0x005B19FE File Offset: 0x005AFBFE
	public void RefreshLevelContent(int value)
	{
		base.GetText(2).SetText(value.ToString(), true);
	}

	// Token: 0x06014851 RID: 84049 RVA: 0x005B1A14 File Offset: 0x005AFC14
	public void RefreshLeftButton(bool active)
	{
		base.GetButton(6).SetSelfInteractive(active);
	}

	// Token: 0x06014852 RID: 84050 RVA: 0x005B1A23 File Offset: 0x005AFC23
	public void RefreshRightButton(bool active)
	{
		base.GetButton(7).SetSelfInteractive(active);
	}

	// Token: 0x06014853 RID: 84051 RVA: 0x005B1A32 File Offset: 0x005AFC32
	public void RefreshLevelContentItem(bool active)
	{
		base.GetItem(9).SetUIActive(active);
	}

	// Token: 0x06014854 RID: 84052 RVA: 0x005B1A42 File Offset: 0x005AFC42
	public void RefreshHasBrokenTip(bool active)
	{
		base.GetText(10).SetUIActive(active);
	}

	// Token: 0x06014855 RID: 84053 RVA: 0x005B1A52 File Offset: 0x005AFC52
	private void OnClickLeft()
	{
		this.BoundViewModel.HandleClickLeft();
	}

	// Token: 0x06014856 RID: 84054 RVA: 0x005B1A5F File Offset: 0x005AFC5F
	private void OnClickRight()
	{
		this.BoundViewModel.HandleClickRight();
	}

	// Token: 0x06014857 RID: 84055 RVA: 0x005B1A6C File Offset: 0x005AFC6C
	private void OnClickClose()
	{
		this.BoundViewModel.HandleViewClosePromise(Singleton<UiManager>.Instance.CloseViewAsync(EUiViewName.RoleBreakPreviewView));
	}

	// Token: 0x04009EB4 RID: 40628
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<LevelLayoutGrid, ILevelLayoutGridData> LevelLayoutInstance;

	// Token: 0x04009EB5 RID: 40629
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<CostMediumItemGrid, ISelectedData> ItemLayoutInstance;

	// Token: 0x04009EB6 RID: 40630
	[Nullable(2)]
	private CostContentItem CostContentItemInstance;

	// Token: 0x04009EB7 RID: 40631
	[Nullable(2)]
	private RoleBreakPreviewViewModel BoundViewModel;

	// Token: 0x02008BD8 RID: 35800
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402F1E0 RID: 192992
		LevelLayout,
		// Token: 0x0402F1E1 RID: 192993
		LevelLayoutTemplate,
		// Token: 0x0402F1E2 RID: 192994
		LevelContent,
		// Token: 0x0402F1E3 RID: 192995
		ItemLayout,
		// Token: 0x0402F1E4 RID: 192996
		ItemLayoutTemplate,
		// Token: 0x0402F1E5 RID: 192997
		CostContentItem,
		// Token: 0x0402F1E6 RID: 192998
		LeftButton,
		// Token: 0x0402F1E7 RID: 192999
		RightButton,
		// Token: 0x0402F1E8 RID: 193000
		CloseButton,
		// Token: 0x0402F1E9 RID: 193001
		LevelContentItem,
		// Token: 0x0402F1EA RID: 193002
		HasBrokenTip
	}
}
