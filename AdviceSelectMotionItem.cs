using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001788 RID: 6024
[NullableContext(1)]
[Nullable(0)]
public class AdviceSelectMotionItem : UiPanelBase
{
	// Token: 0x0600A9EF RID: 43503 RVA: 0x002D52C8 File Offset: 0x002D34C8
	public AdviceSelectMotionItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600A9F0 RID: 43504 RVA: 0x002D52E0 File Offset: 0x002D34E0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnBtnClick))
		};
	}

	// Token: 0x0600A9F1 RID: 43505 RVA: 0x002D535D File Offset: 0x002D355D
	private void OnBtnClick()
	{
		Action onClickBtnBtnCall = this.OnClickBtnBtnCall;
		if (onClickBtnBtnCall == null)
		{
			return;
		}
		onClickBtnBtnCall();
	}

	// Token: 0x0600A9F2 RID: 43506 RVA: 0x002D536F File Offset: 0x002D356F
	public void SetClickChangeRoleCall(Action call)
	{
		this.OnClickBtnBtnCall = call;
	}

	// Token: 0x0600A9F3 RID: 43507 RVA: 0x002D5378 File Offset: 0x002D3578
	protected override void OnStart()
	{
		this.Scroller = new GenericScrollView<AdviceSelectMotionContent>(base.GetScrollViewWithScrollbar(2), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<AdviceSelectMotionContent>(this.CreateItem), null);
	}

	// Token: 0x0600A9F4 RID: 43508 RVA: 0x002D539C File Offset: 0x002D359C
	private ILayoutItem<AdviceSelectMotionContent> CreateItem(object data, UUIItem uiItem, int index)
	{
		AdviceSelectMotionContent adviceSelectMotionContent = new AdviceSelectMotionContent(uiItem);
		adviceSelectMotionContent.RefreshView((AdviceMotionSelectData)data);
		return new LayoutItem<AdviceSelectMotionContent>
		{
			Key = index,
			Value = adviceSelectMotionContent
		};
	}

	// Token: 0x0600A9F5 RID: 43509 RVA: 0x002D53D4 File Offset: 0x002D35D4
	public void RefreshView(AdviceMotionSelectData[] data)
	{
		GenericScrollView<AdviceSelectMotionContent> scroller = this.Scroller;
		if (scroller != null)
		{
			scroller.RefreshByData<AdviceMotionSelectData>(data.ToList<AdviceMotionSelectData>(), null);
		}
		this.RefreshRoleName();
	}

	// Token: 0x0600A9F6 RID: 43510 RVA: 0x002D5408 File Offset: 0x002D3608
	private void RefreshRoleName()
	{
		if (ModelBase<AdviceModel>.Instance.PreSelectRoleId > 0)
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(ModelBase<AdviceModel>.Instance.PreSelectRoleId);
			if (roleConfig != null)
			{
				string roleName = ConfigBase<RoleConfig>.Instance.GetRoleName(roleConfig.Value.Name);
				UUIText text = base.GetText(1);
				if (text == null)
				{
					return;
				}
				text.SetText(roleName ?? "", true);
				return;
			}
		}
		else
		{
			UUIText text2 = base.GetText(1);
			if (text2 == null)
			{
				return;
			}
			text2.SetText("", true);
		}
	}

	// Token: 0x0600A9F7 RID: 43511 RVA: 0x002D548E File Offset: 0x002D368E
	protected override void OnBeforeDestroy()
	{
		GenericScrollView<AdviceSelectMotionContent> scroller = this.Scroller;
		if (scroller == null)
		{
			return;
		}
		scroller.ClearChildren();
	}

	// Token: 0x04004FF5 RID: 20469
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<AdviceSelectMotionContent> Scroller;

	// Token: 0x04004FF6 RID: 20470
	[Nullable(2)]
	protected Action OnClickBtnBtnCall;

	// Token: 0x02007AEA RID: 31466
	[NullableContext(0)]
	private static class EComponents
	{
		// Token: 0x0402A17A RID: 172410
		public const int MoreBtn = 0;

		// Token: 0x0402A17B RID: 172411
		public const int RoleName = 1;

		// Token: 0x0402A17C RID: 172412
		public const int Scroller = 2;
	}
}
