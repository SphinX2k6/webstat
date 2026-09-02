using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using CSharpScript.Game.Effect;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Ui;
using CSharpScript.Game.World.Model;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.World.Controller.SubLevelAssistant
{
	// Token: 0x020046ED RID: 18157
	[NullableContext(1)]
	[Nullable(0)]
	public class SubLevelVisibleAssistant : ControllerAssistantBase
	{
		// Token: 0x0602F3B1 RID: 193457 RVA: 0x00B3278F File Offset: 0x00B3098F
		protected override void OnDestroy()
		{
			this.ClearPromise();
		}

		// Token: 0x0602F3B2 RID: 193458 RVA: 0x00B32798 File Offset: 0x00B30998
		[NullableContext(0)]
		public UniTask<bool> SetSubLevelVisible([Nullable(1)] SetSubLevelVisibleParams @params)
		{
			SubLevelVisibleAssistant.<SetSubLevelVisible>d__6 <SetSubLevelVisible>d__;
			<SetSubLevelVisible>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<SetSubLevelVisible>d__.<>4__this = this;
			<SetSubLevelVisible>d__.@params = @params;
			<SetSubLevelVisible>d__.<>1__state = -1;
			<SetSubLevelVisible>d__.<>t__builder.Start<SubLevelVisibleAssistant.<SetSubLevelVisible>d__6>(ref <SetSubLevelVisible>d__);
			return <SetSubLevelVisible>d__.<>t__builder.Task;
		}

		// Token: 0x0602F3B3 RID: 193459 RVA: 0x00B327E4 File Offset: 0x00B309E4
		[NullableContext(0)]
		private UniTask<bool> ExecuteImp([Nullable(1)] SetSubLevelVisibleParams @params)
		{
			SubLevelVisibleAssistant.<ExecuteImp>d__7 <ExecuteImp>d__;
			<ExecuteImp>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteImp>d__.<>4__this = this;
			<ExecuteImp>d__.@params = @params;
			<ExecuteImp>d__.<>1__state = -1;
			<ExecuteImp>d__.<>t__builder.Start<SubLevelVisibleAssistant.<ExecuteImp>d__7>(ref <ExecuteImp>d__);
			return <ExecuteImp>d__.<>t__builder.Task;
		}

		// Token: 0x0602F3B4 RID: 193460 RVA: 0x00B3282F File Offset: 0x00B30A2F
		private void InitPromise()
		{
			this.WaitSceneShotLoadedPromise = new CustomPromise<ELoadEffectResult>();
		}

		// Token: 0x0602F3B5 RID: 193461 RVA: 0x00B3283C File Offset: 0x00B30A3C
		private void ClearPromise()
		{
			this.WaitSceneShotLoadedPromise = null;
		}

		// Token: 0x0602F3B6 RID: 193462 RVA: 0x00B32848 File Offset: 0x00B30A48
		private void BeforeStartSetSubLevelsVisible(ClientPreEnableSubLevels @params)
		{
			IEnableSubLevelTransitionWithSceneCapture transitionOption = @params.TransitionOption;
			bool subLevelSwitching = (((transitionOption != null) ? new EEnableSubLevelTransitionType?(transitionOption.Type) : null) ?? ((EEnableSubLevelTransitionType)1)) != EEnableSubLevelTransitionType.SceneCapture || !transitionOption.IsAllowInput.GetValueOrDefault();
			ModelBase<SubLevelModel>.Instance.SetSubLevelSwitching(subLevelSwitching);
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
		}

		// Token: 0x0602F3B7 RID: 193463 RVA: 0x00B328B6 File Offset: 0x00B30AB6
		private void AfterStartSetSubLevelsVisible(ClientPreEnableSubLevels @params)
		{
			ModelBase<SubLevelModel>.Instance.UnsetSubLevelSwitching();
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
		}

		// Token: 0x0602F3B8 RID: 193464 RVA: 0x00B328CC File Offset: 0x00B30ACC
		private UniTask StartSetSubLevelsVisible(ClientPreEnableSubLevels @params)
		{
			SubLevelVisibleAssistant.<StartSetSubLevelsVisible>d__12 <StartSetSubLevelsVisible>d__;
			<StartSetSubLevelsVisible>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartSetSubLevelsVisible>d__.<>4__this = this;
			<StartSetSubLevelsVisible>d__.@params = @params;
			<StartSetSubLevelsVisible>d__.<>1__state = -1;
			<StartSetSubLevelsVisible>d__.<>t__builder.Start<SubLevelVisibleAssistant.<StartSetSubLevelsVisible>d__12>(ref <StartSetSubLevelsVisible>d__);
			return <StartSetSubLevelsVisible>d__.<>t__builder.Task;
		}

		// Token: 0x0602F3B9 RID: 193465 RVA: 0x00B32918 File Offset: 0x00B30B18
		private UniTask SetVisibleImp(ClientPreEnableSubLevels @params)
		{
			SubLevelVisibleAssistant.<SetVisibleImp>d__13 <SetVisibleImp>d__;
			<SetVisibleImp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetVisibleImp>d__.<>4__this = this;
			<SetVisibleImp>d__.@params = @params;
			<SetVisibleImp>d__.<>1__state = -1;
			<SetVisibleImp>d__.<>t__builder.Start<SubLevelVisibleAssistant.<SetVisibleImp>d__13>(ref <SetVisibleImp>d__);
			return <SetVisibleImp>d__.<>t__builder.Task;
		}

		// Token: 0x0602F3BA RID: 193466 RVA: 0x00B32964 File Offset: 0x00B30B64
		private UniTask EnableLevel(string levelPath)
		{
			SubLevelVisibleAssistant.<EnableLevel>d__14 <EnableLevel>d__;
			<EnableLevel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EnableLevel>d__.<>4__this = this;
			<EnableLevel>d__.levelPath = levelPath;
			<EnableLevel>d__.<>1__state = -1;
			<EnableLevel>d__.<>t__builder.Start<SubLevelVisibleAssistant.<EnableLevel>d__14>(ref <EnableLevel>d__);
			return <EnableLevel>d__.<>t__builder.Task;
		}

		// Token: 0x0602F3BB RID: 193467 RVA: 0x00B329B0 File Offset: 0x00B30BB0
		private UniTask DisableLevel(string levelPath)
		{
			SubLevelVisibleAssistant.<DisableLevel>d__15 <DisableLevel>d__;
			<DisableLevel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DisableLevel>d__.<>4__this = this;
			<DisableLevel>d__.levelPath = levelPath;
			<DisableLevel>d__.<>1__state = -1;
			<DisableLevel>d__.<>t__builder.Start<SubLevelVisibleAssistant.<DisableLevel>d__15>(ref <DisableLevel>d__);
			return <DisableLevel>d__.<>t__builder.Task;
		}

		// Token: 0x0602F3BC RID: 193468 RVA: 0x00B329FC File Offset: 0x00B30BFC
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<EffectScreenPlayData_C> PlayScreenEffect(string screenEffectPath)
		{
			SubLevelVisibleAssistant.<PlayScreenEffect>d__16 <PlayScreenEffect>d__;
			<PlayScreenEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder<EffectScreenPlayData_C>.Create();
			<PlayScreenEffect>d__.<>4__this = this;
			<PlayScreenEffect>d__.screenEffectPath = screenEffectPath;
			<PlayScreenEffect>d__.<>1__state = -1;
			<PlayScreenEffect>d__.<>t__builder.Start<SubLevelVisibleAssistant.<PlayScreenEffect>d__16>(ref <PlayScreenEffect>d__);
			return <PlayScreenEffect>d__.<>t__builder.Task;
		}

		// Token: 0x0602F3BD RID: 193469 RVA: 0x00B32A48 File Offset: 0x00B30C48
		private unsafe bool CheckLevelPathEmpty(string path, string enableOrDisable)
		{
			if (!StringUtils.IsBlank(path))
			{
				return false;
			}
			string text = "";
			if (this.Context != null)
			{
				EGeneralContextType? type = this.Context.Type;
				if (type != null)
				{
					EGeneralContextType valueOrDefault = type.GetValueOrDefault();
					if (valueOrDefault != EGeneralContextType.Entity)
					{
						if (valueOrDefault == EGeneralContextType.GeneralLogicTree)
						{
							GeneralLogicTreeContext generalLogicTreeContext = (GeneralLogicTreeContext)this.Context;
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
							defaultInterpolatedStringHandler.AppendFormatted<int>(generalLogicTreeContext.TreeConfigId);
							defaultInterpolatedStringHandler.AppendLiteral("_");
							defaultInterpolatedStringHandler.AppendFormatted<int>(generalLogicTreeContext.NodeId);
							text = defaultInterpolatedStringHandler.ToStringAndClear();
						}
					}
					else
					{
						EntityContext entityContext = (EntityContext)this.Context;
						Entity entity = Singleton<EntitySystem>.Instance.Get(entityContext.EntityId.Value);
						CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
						text = ((creatureDataComponent != null) ? creatureDataComponent.GetPbDataId() : 0).ToString();
					}
				}
			}
			string obj = "想要" + enableOrDisable + "的子关卡路径为空,配置来源：" + text;
			ControllerBase<ErrorCodeController>.Instance.OpenConfirmBoxByText(obj);
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelEvent;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "SubLevelController.SubLevelVisibleAssistant 想要disable的子关卡路径为空";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("subLevelPath", path);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("source", text);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return true;
		}

		// Token: 0x0602F3BE RID: 193470 RVA: 0x00B32BA4 File Offset: 0x00B30DA4
		private void RequestSetSubLevelVisible([Nullable(new byte[]
		{
			2,
			1
		})] IList<string> showSubLevels, [Nullable(new byte[]
		{
			2,
			1
		})] IList<string> hideSubLevels)
		{
			SceneSubLevelsRequest sceneSubLevelsRequest = SceneSubLevelsRequest.Create();
			if (showSubLevels != null && showSubLevels.Count > 0)
			{
				sceneSubLevelsRequest.ShowSubLevels.AddRange(showSubLevels);
			}
			if (hideSubLevels != null && hideSubLevels.Count > 0)
			{
				sceneSubLevelsRequest.HideSubLevels.AddRange(hideSubLevels);
			}
			Singleton<Net>.Instance.Call<SceneSubLevelsResponse>(ERequestMessageId.SceneSubLevelsRequest, sceneSubLevelsRequest, delegate(SceneSubLevelsResponse response, Net.CallbackStatus _)
			{
			}, 0);
		}

		// Token: 0x0401AE7B RID: 110203
		[Nullable(2)]
		private CustomPromise<ELoadEffectResult> WaitSceneShotLoadedPromise;

		// Token: 0x0401AE7C RID: 110204
		private int ScreenCaptureEffectHandle;

		// Token: 0x0401AE7D RID: 110205
		private int Id;

		// Token: 0x0401AE7E RID: 110206
		private int GroupId;

		// Token: 0x0401AE7F RID: 110207
		[Nullable(2)]
		private GeneralContext Context;
	}
}
