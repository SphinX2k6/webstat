using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001351 RID: 4945
[NullableContext(2)]
[Nullable(0)]
public class LifePointSubView : ActivitySubViewBase
{
	// Token: 0x06008745 RID: 34629 RVA: 0x00239F54 File Offset: 0x00238154
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06008746 RID: 34630 RVA: 0x00239FC0 File Offset: 0x002381C0
	protected override UniTask OnBeforeStartAsync()
	{
		LifePointSubView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<LifePointSubView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008747 RID: 34631 RVA: 0x0023A004 File Offset: 0x00238204
	private void FunctionExecute(ActivityBaseData data)
	{
		int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
		if (unFinishPreGuideQuestId > 0)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			return;
		}
		WorldMapViewOpenParams data2 = new WorldMapViewOpenParams
		{
			MarkId = new int?(ConfigBase<LifePointDrawConfig>.Instance.GetLifePointDrawActivityById(this.ActivityBaseData.Id).Value.MarkId),
			MarkType = EMarkType.None,
			OpenFogId = new int?(0)
		};
		ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data2, null);
	}

	// Token: 0x06008748 RID: 34632 RVA: 0x0023A08F File Offset: 0x0023828F
	protected override void OnStart()
	{
		this.LifePointActivityData = (this.ActivityBaseData as LifePointDrawActivityData);
	}

	// Token: 0x06008749 RID: 34633 RVA: 0x0023A0A4 File Offset: 0x002382A4
	protected override void OnBeforeShow()
	{
		if (this.ActivityBaseData.GetUnFinishPreGuideQuestId() > 0)
		{
			this.InfoComponent.SetBtnText("LifePointQuestUnFinish", Array.Empty<object>());
		}
		else
		{
			this.InfoComponent.SetBtnText("LifePointQuestFinish", Array.Empty<object>());
		}
		this.RefreshProgressText();
		this.UpdateRedDotActivity();
	}

	// Token: 0x0600874A RID: 34634 RVA: 0x0023A0F8 File Offset: 0x002382F8
	public void RefreshProgressText()
	{
		string progressByActivityId = ModelBase<LifePointDrawModel>.Instance.GetProgressByActivityId(this.LifePointActivityData.Id, "Colorful_Finish_Progress_Activity");
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(progressByActivityId, true);
	}

	// Token: 0x0600874B RID: 34635 RVA: 0x0023A134 File Offset: 0x00238334
	private void UpdateRedDotActivity()
	{
		bool redPointShowState = this.LifePointActivityData.RedPointShowState;
		ActivitySubViewGeneralInfo infoComponent = this.InfoComponent;
		if (infoComponent == null)
		{
			return;
		}
		infoComponent.SetFunctionRedDotVisible(redPointShowState);
	}

	// Token: 0x04003FBF RID: 16319
	private LifePointDrawActivityData LifePointActivityData;

	// Token: 0x04003FC0 RID: 16320
	private ActivitySubViewGeneralInfo InfoComponent;

	// Token: 0x020076F3 RID: 30451
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x04028F82 RID: 167810
		public const int InfoItem = 0;

		// Token: 0x04028F83 RID: 167811
		public const int ProgressText = 1;
	}
}
