using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.GenericPrompt.View
{
	// Token: 0x02005CC0 RID: 23744
	[NullableContext(1)]
	[Nullable(0)]
	public class TaskEndTipsView : GenericPromptFloatTipsBase
	{
		// Token: 0x0603BE50 RID: 245328 RVA: 0x00F2E0E8 File Offset: 0x00F2C2E8
		public TaskEndTipsView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE51 RID: 245329 RVA: 0x00F2E0F1 File Offset: 0x00F2C2F1
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUISprite)));
		}

		// Token: 0x0603BE52 RID: 245330 RVA: 0x00F2E114 File Offset: 0x00F2C314
		protected override void OnBeforeCreate()
		{
			this._viewData = (this.OpenParam as TaskEndTipsViewData);
			TaskEndTipsViewData viewData = this._viewData;
			float? duration = (viewData != null && viewData.Duration != null) ? new float?((float)this._viewData.Duration.Value) : null;
			PromptParamHub<object> openParam = new PromptParamHub<object>
			{
				TypeId = 12,
				Duration = duration
			};
			this.OpenParam = openParam;
			base.OnBeforeCreate();
			this.OpenParam = this._viewData;
		}

		// Token: 0x0603BE53 RID: 245331 RVA: 0x00F2E19B File Offset: 0x00F2C39B
		protected override void SetMainText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
			if (this._viewData == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.MainText, this._viewData.TipTextKey, Array.Empty<object>());
		}

		// Token: 0x0603BE54 RID: 245332 RVA: 0x00F2E1C6 File Offset: 0x00F2C3C6
		protected override void SetExtraText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
			UUIText extraText = base.ExtraText;
			if (extraText == null)
			{
				return;
			}
			extraText.SetUIActive(false);
		}

		// Token: 0x0603BE55 RID: 245333 RVA: 0x00F2E1DC File Offset: 0x00F2C3DC
		protected override UniTask OnBeforeStartAsync()
		{
			TaskEndTipsView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TaskEndTipsView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04021AB9 RID: 137913
		private const int IconIndex = 2;

		// Token: 0x04021ABA RID: 137914
		[StaticVariableRuleIgnore]
		private static readonly IReadOnlyDictionary<EQuestCommonTipType, string> TaskEndIconSp = new Dictionary<EQuestCommonTipType, string>
		{
			{
				EQuestCommonTipType.Branch,
				"SP_IconMap_Task_02_3_UI"
			},
			{
				EQuestCommonTipType.Role,
				"SP_IconMap_Task_03_3_UI"
			},
			{
				EQuestCommonTipType.Guide,
				"SP_IconMap_Task_11_3_UI"
			},
			{
				EQuestCommonTipType.POI,
				"SP_IconMap_Task_10_4_UI"
			},
			{
				EQuestCommonTipType.Activity,
				"SP_IconMap_Task_14_3_UI"
			},
			{
				EQuestCommonTipType.Daily,
				"SP_IconMap_Task_06_UI"
			}
		};

		// Token: 0x04021ABB RID: 137915
		[Nullable(2)]
		private TaskEndTipsViewData _viewData;
	}
}
