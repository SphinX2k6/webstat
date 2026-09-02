using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiComponent.UiHomeButton
{
	// Token: 0x02004D89 RID: 19849
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class HomeBtnController : ControllerBase<HomeBtnController>
	{
		// Token: 0x06033649 RID: 210505 RVA: 0x00CDAB9C File Offset: 0x00CD8D9C
		public void AddExtraAsyncCallback(EUiViewName viewName, Func<UniTask> callback)
		{
			this.ExtraCallback[viewName] = callback;
		}

		// Token: 0x0603364A RID: 210506 RVA: 0x00CDABAC File Offset: 0x00CD8DAC
		public void AddExtraCallback(EUiViewName viewName, Action callback)
		{
			Func<UniTask> value = delegate()
			{
				callback();
				return UniTask.CompletedTask;
			};
			this.ExtraCallback[viewName] = value;
		}

		// Token: 0x0603364B RID: 210507 RVA: 0x00CDABDE File Offset: 0x00CD8DDE
		public void RemoveExtraCallback(EUiViewName viewName)
		{
			this.ExtraCallback.Remove(viewName);
		}

		// Token: 0x0603364C RID: 210508 RVA: 0x00CDABED File Offset: 0x00CD8DED
		protected override bool OnClear()
		{
			this.ExtraCallback.Clear();
			return true;
		}

		// Token: 0x0603364D RID: 210509 RVA: 0x00CDABFB File Offset: 0x00CD8DFB
		public void ExecuteBtnClick()
		{
			if (ModelBase<HomeBtnModel>.Instance.EnableHomeBtnLogic)
			{
				this.OnResetToBattleView().Forget();
				return;
			}
			this.OnShowPrompt();
		}

		// Token: 0x0603364E RID: 210510 RVA: 0x00CDAC1C File Offset: 0x00CD8E1C
		private UniTask OnResetToBattleView()
		{
			HomeBtnController.<OnResetToBattleView>d__6 <OnResetToBattleView>d__;
			<OnResetToBattleView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnResetToBattleView>d__.<>4__this = this;
			<OnResetToBattleView>d__.<>1__state = -1;
			<OnResetToBattleView>d__.<>t__builder.Start<HomeBtnController.<OnResetToBattleView>d__6>(ref <OnResetToBattleView>d__);
			return <OnResetToBattleView>d__.<>t__builder.Task;
		}

		// Token: 0x0603364F RID: 210511 RVA: 0x00CDAC60 File Offset: 0x00CD8E60
		private UniTask OnAfterResetToBattleView([Nullable(new byte[]
		{
			2,
			1
		})] Dictionary<EUiViewName, Func<UniTask>> extraCallback)
		{
			HomeBtnController.<OnAfterResetToBattleView>d__7 <OnAfterResetToBattleView>d__;
			<OnAfterResetToBattleView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnAfterResetToBattleView>d__.extraCallback = extraCallback;
			<OnAfterResetToBattleView>d__.<>1__state = -1;
			<OnAfterResetToBattleView>d__.<>t__builder.Start<HomeBtnController.<OnAfterResetToBattleView>d__7>(ref <OnAfterResetToBattleView>d__);
			return <OnAfterResetToBattleView>d__.<>t__builder.Task;
		}

		// Token: 0x06033650 RID: 210512 RVA: 0x00CDACA3 File Offset: 0x00CD8EA3
		private void OnShowPrompt()
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("HomeBtnTips_Unavailable", Array.Empty<object>());
		}

		// Token: 0x06033651 RID: 210513 RVA: 0x00CDACBC File Offset: 0x00CD8EBC
		public unsafe void CreateHomeBtnFromUiItem(UUIItem parent, EUiViewName viewName, [Nullable(2)] string tag = null, bool snapSize = false)
		{
			if (!ModelBase<HomeBtnModel>.Instance.GetShowHomeBtn(viewName))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.HomeBtn;
				ELogAuthor author = ELogAuthor.CB;
				string message = "传入的viewName不支持配置Home键或Home键功能被关闭";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("viewName", viewName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("tag", tag);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			AActor owner = parent.GetOwner();
			TsUiHomeHelper tsUiHomeHelper = ((owner != null) ? owner.GetComponentByClass(TsUiHomeHelper.StaticClass()) : null) as TsUiHomeHelper;
			if (tsUiHomeHelper == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.HomeBtn;
				ELogAuthor author2 = ELogAuthor.CB;
				string message2 = "父节点没有TsUiHomeHelper";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("displayName", parent.GetDisplayName());
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			int homeBtnStyle = this.GetHomeBtnStyle(viewName);
			tsUiHomeHelper.CreateHomeBtn(homeBtnStyle, snapSize);
		}

		// Token: 0x06033652 RID: 210514 RVA: 0x00CDAD98 File Offset: 0x00CD8F98
		public void CreateHomeBtnFromView(UiViewBase view)
		{
			EUiViewName name = view.ViewInfo.Name;
			if (!ModelBase<HomeBtnModel>.Instance.GetShowHomeBtn(name))
			{
				return;
			}
			if (view.ViewInfo.Type != ELayerType.Normal && view.ViewInfo.Type != ELayerType.Pop)
			{
				return;
			}
			if (!ModelBase<HomeBtnModel>.Instance.GetNeedFindComponent(name))
			{
				return;
			}
			TsUiHomeHelper tsUiHomeHelper = ULGUIBPLibrary.GetComponentInChildren(view.GetRootActor(), TsUiHomeHelper.StaticClass(), false) as TsUiHomeHelper;
			if (tsUiHomeHelper == null)
			{
				ModelBase<HomeBtnModel>.Instance.AddViewNameToNoFindComponent(name);
				return;
			}
			int homeBtnStyle = this.GetHomeBtnStyle(name);
			tsUiHomeHelper.CreateHomeBtn(homeBtnStyle, false);
		}

		// Token: 0x06033653 RID: 210515 RVA: 0x00CDAE38 File Offset: 0x00CD9038
		private int GetHomeBtnStyle(EUiViewName viewName)
		{
			UiShow? uiShowConfig = ConfigBase<UiViewConfig>.Instance.GetUiShowConfig(viewName);
			if (uiShowConfig == null)
			{
				return 1;
			}
			return uiShowConfig.GetValueOrDefault().HomeBtnStyle;
		}

		// Token: 0x0401DC8D RID: 121997
		private readonly Dictionary<EUiViewName, Func<UniTask>> ExtraCallback = new Dictionary<EUiViewName, Func<UniTask>>();
	}
}
