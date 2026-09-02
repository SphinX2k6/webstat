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

namespace CSharpScript.Game.Module.Activity.ActivityContent.LineCross
{
	// Token: 0x0200676E RID: 26478
	public class LineCrossSubView : ActivitySubViewBase
	{
		// Token: 0x0604200E RID: 270350 RVA: 0x010EF53C File Offset: 0x010ED73C
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

		// Token: 0x0604200F RID: 270351 RVA: 0x010EF5A8 File Offset: 0x010ED7A8
		protected override UniTask OnBeforeStartAsync()
		{
			LineCrossSubView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<LineCrossSubView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042010 RID: 270352 RVA: 0x010EF5EC File Offset: 0x010ED7EC
		[NullableContext(1)]
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
				MarkId = new int?(ConfigBase<LineCrossConfig>.Instance.GetLineCrossActivityById(this.ActivityBaseData.Id).Value.MarkId),
				MarkType = EMarkType.None,
				OpenFogId = new int?(0)
			};
			ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data2, null);
		}

		// Token: 0x06042011 RID: 270353 RVA: 0x010EF677 File Offset: 0x010ED877
		protected override void OnStart()
		{
			this.LineCrossActivityData = (LineCrossActivityData)this.ActivityBaseData;
		}

		// Token: 0x06042012 RID: 270354 RVA: 0x010EF68C File Offset: 0x010ED88C
		protected override void OnBeforeShow()
		{
			if (this.ActivityBaseData.GetUnFinishPreGuideQuestId() > 0)
			{
				this.InfoComponent.SetBtnText("LineCrossQuestUnFinish", Array.Empty<object>());
			}
			else
			{
				this.InfoComponent.SetBtnText("LineCrossQuestFinish", Array.Empty<object>());
			}
			this.RefreshProgressText();
			this.UpdateRedDotActivity();
		}

		// Token: 0x06042013 RID: 270355 RVA: 0x010EF6E0 File Offset: 0x010ED8E0
		public void RefreshProgressText()
		{
			string progressByActivityId = ModelBase<LineCrossModel>.Instance.GetProgressByActivityId(this.LineCrossActivityData.Id, "LineCross_Finish_Progress_Activity");
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(progressByActivityId, true);
		}

		// Token: 0x06042014 RID: 270356 RVA: 0x010EF71C File Offset: 0x010ED91C
		private void UpdateRedDotActivity()
		{
			bool redPointShowState = this.LineCrossActivityData.RedPointShowState;
			ActivitySubViewGeneralInfo infoComponent = this.InfoComponent;
			if (infoComponent == null)
			{
				return;
			}
			infoComponent.SetFunctionRedDotVisible(redPointShowState);
		}

		// Token: 0x04024CF9 RID: 150777
		[Nullable(2)]
		private LineCrossActivityData LineCrossActivityData;

		// Token: 0x04024CFA RID: 150778
		[Nullable(2)]
		private ActivitySubViewGeneralInfo InfoComponent;

		// Token: 0x0200C78B RID: 51083
		private class EComponent
		{
			// Token: 0x0403D6EE RID: 251630
			public const int InfoItem = 0;

			// Token: 0x0403D6EF RID: 251631
			public const int ProgressText = 1;
		}
	}
}
