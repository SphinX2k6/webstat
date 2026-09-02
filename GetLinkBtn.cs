using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002577 RID: 9591
public class GetLinkBtn : UiPanelBase
{
	// Token: 0x06012A7E RID: 76414 RVA: 0x00524CA0 File Offset: 0x00522EA0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnButtonClicked))
		};
	}

	// Token: 0x06012A7F RID: 76415 RVA: 0x00524D20 File Offset: 0x00522F20
	public void RefreshByGetWayId(int getWayId)
	{
		this.CurGetWayId = getWayId;
		AccessPath? configById = ConfigBase<GetWayConfig>.Instance.GetConfigById(getWayId);
		if (configById == null)
		{
			return;
		}
		int type = configById.Value.Type;
		if (type != 1)
		{
			if (type == 2)
			{
				base.GetButton(0).SetSelfInteractive(true);
				base.GetSprite(1).SetUIActive(true);
			}
		}
		else
		{
			base.GetButton(0).SetSelfInteractive(false);
			base.GetSprite(1).SetUIActive(false);
		}
		this.SetLinkText(configById.Value.Description);
		this.OnClickGetLink = delegate()
		{
			SkipTaskManager.RunByConfigId(getWayId, null);
		};
	}

	// Token: 0x06012A80 RID: 76416 RVA: 0x00524DD6 File Offset: 0x00522FD6
	[NullableContext(1)]
	public void SetLinkText(string textId)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textId, Array.Empty<object>());
	}

	// Token: 0x06012A81 RID: 76417 RVA: 0x00524DEF File Offset: 0x00522FEF
	private void OnButtonClicked()
	{
		Action onClickGetLink = this.OnClickGetLink;
		if (onClickGetLink == null)
		{
			return;
		}
		onClickGetLink();
	}

	// Token: 0x040091BF RID: 37311
	private int CurGetWayId;

	// Token: 0x040091C0 RID: 37312
	[Nullable(2)]
	private Action OnClickGetLink;

	// Token: 0x02008894 RID: 34964
	private enum EBtnGetLinkComponent
	{
		// Token: 0x0402E215 RID: 188949
		BtnLink,
		// Token: 0x0402E216 RID: 188950
		SpriteTrackIcon,
		// Token: 0x0402E217 RID: 188951
		TxtLink
	}
}
