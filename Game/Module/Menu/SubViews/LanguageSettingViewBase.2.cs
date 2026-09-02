using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Update;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x02005780 RID: 22400
	[NullableContext(1)]
	[Nullable(0)]
	public class LanguageSettingViewBase<[Nullable(0)] T> : UiViewBase where T : LanguageToggleBase
	{
		// Token: 0x06038FF8 RID: 233464 RVA: 0x00E71460 File Offset: 0x00E6F660
		public LanguageSettingViewBase(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06038FF9 RID: 233465 RVA: 0x00E7146C File Offset: 0x00E6F66C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(7, typeof(UUIText))
			};
		}

		// Token: 0x06038FFA RID: 233466 RVA: 0x00E71534 File Offset: 0x00E6F734
		protected override void OnStart()
		{
			this.CoverRoleLangToggle = base.GetExtendToggle(6);
			this.CoverRoleTxt = base.GetText(7);
			this.RoleLangDeleteHint = base.GetItem(4);
			this.RoleLangDeleteHintTxt = base.GetText(5);
			this.MenuChangeParam = (this.OpenParam as IReadOnlyList<object>);
			this.MenuDataIns = ((this.MenuChangeParam != null && this.MenuChangeParam.Count > 0) ? (this.MenuChangeParam[0] as MenuData) : null);
			if (this.MenuChangeParam != null && this.MenuChangeParam.Count > 1)
			{
				Action<int, float> action = this.MenuChangeParam[1] as Action<int, float>;
				if (action != null)
				{
					LanguageSettingViewBase.ApplyValueFunc = action;
				}
			}
			this.CancelButton = new ButtonItem(base.GetItem(1));
			this.ConfirmButton = new ButtonItem(base.GetItem(2));
			this.CancelButton.SetFunction(new Action<int>(this.DoClose));
			this.ConfirmButton.SetFunction(new Action<int>(this.DoConfirm));
			this.ScrollView = new GenericScrollView<UiPanelBase>(base.GetScrollViewWithScrollbar(3), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<UiPanelBase>(this.DoRefreshScrollView), null);
			this.InitScrollViewData();
			UUIText text = base.GetText(0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, this.MenuDataIns.FunctionName ?? "", Array.Empty<object>());
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView == null)
			{
				return;
			}
			childPopView.PopItem.OverrideBackBtnCallBack(delegate
			{
				this.DoClose(0);
			});
		}

		// Token: 0x06038FFB RID: 233467 RVA: 0x00E716AC File Offset: 0x00E6F8AC
		protected virtual void InitScrollViewData()
		{
			List<int> list = new List<int>();
			foreach (LanguageDefine languageDefine in MenuTool.GetLanguageDefineData())
			{
				list.Add(languageDefine.LanguageType);
			}
			list.Sort((int a, int b) => a - b);
			this.ScrollView.RefreshByData<int>(list, null);
		}

		// Token: 0x06038FFC RID: 233468 RVA: 0x00E71740 File Offset: 0x00E6F940
		private void DoClose(int _)
		{
			base.CloseMe(null);
		}

		// Token: 0x06038FFD RID: 233469 RVA: 0x00E71749 File Offset: 0x00E6F949
		private void DoConfirm(int _)
		{
			this.IsConfirm = true;
			this.DoClose(0);
		}

		// Token: 0x06038FFE RID: 233470 RVA: 0x00E7175C File Offset: 0x00E6F95C
		protected override void OnAfterHide()
		{
			int targetConfig = ControllerBase<MenuController>.Instance.GetTargetConfig(this.MenuDataIns.FunctionId);
			if (this.IsConfirm && this.SelectedToggle.GetIndex() != targetConfig && this.MenuChangeParam != null && this.MenuDataIns != null && LanguageSettingViewBase.ApplyValueFunc != null)
			{
				LanguageSettingViewBase.ApplyValueFunc((int)this.MenuDataIns.FunctionId, (float)this.SelectedToggle.GetIndex());
			}
			this.IsConfirm = false;
		}

		// Token: 0x06038FFF RID: 233471 RVA: 0x00E717DE File Offset: 0x00E6F9DE
		protected override void OnBeforeDestroyImplement()
		{
			if (this.ScrollView != null)
			{
				this.ScrollView.ClearChildren();
				this.ScrollView = null;
			}
		}

		// Token: 0x06039000 RID: 233472 RVA: 0x00E717FC File Offset: 0x00E6F9FC
		protected void DoSelected(LanguageToggleBase newToggle, EToggleState newToggleState)
		{
			if (this.SelectedToggle != newToggle && newToggleState == EToggleState.ETT_Checked)
			{
				T t = this.SelectedToggle;
				if (t != null)
				{
					t.UnSelect();
				}
			}
			this.SelectedToggle = (newToggle as T);
			this.OnSelected(this.SelectedToggle, newToggleState);
		}

		// Token: 0x06039001 RID: 233473 RVA: 0x00E71850 File Offset: 0x00E6FA50
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		protected unsafe virtual ILayoutItem<UiPanelBase> DoRefreshScrollView(object index, UUIItem uiItem, int _)
		{
			string audioCodeById = Singleton<GameSettingsManager>.Instance.GetAudioCodeById((int)index);
			LanguageUpdater updater = Singleton<LanguageUpdateManager>.Instance.GetUpdater(audioCodeById);
			if (updater != null)
			{
				updater.CalculateDownloadStatus("LanguageSettingViewBase DoRefreshScrollView");
			}
			int targetConfig = ControllerBase<MenuController>.Instance.GetTargetConfig(EFunction.VOICELANGUAGE);
			bool flag = (int)index == targetConfig && updater != null && updater.Status == ELanguageDownloadStatus.Done;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GameSettings;
			ELogAuthor author = ELogAuthor.TZJ;
			string message = "[语音下载] DoRefreshScrollView";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("index", (int)index);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("targetIndex", targetConfig);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("languageCode", audioCodeById);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("updaterStatus", (updater != null) ? new ELanguageDownloadStatus?(updater.Status) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("isToggled", flag);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
			T t = this.CreateToggle(uiItem, (int)index, flag);
			if (t == null)
			{
				return null;
			}
			if (flag)
			{
				this.SelectedToggle = t;
			}
			else
			{
				t.UnSelect();
			}
			t.SetSelectedCallBack(new Action<LanguageToggleBase, EToggleState>(this.DoSelected));
			this.OnRefreshView(t);
			return null;
		}

		// Token: 0x06039002 RID: 233474 RVA: 0x00E719D8 File Offset: 0x00E6FBD8
		[return: Nullable(2)]
		protected virtual T CreateToggle(UUIItem uiItem, int index, bool isToggled)
		{
			Singleton<Log>.Instance.Error(ELogModule.Menu, ELogAuthor.WZ, "必须重写CreateToggle", default(ReadOnlySpan<ValueTuple<string, object>>));
			return default(T);
		}

		// Token: 0x06039003 RID: 233475 RVA: 0x00E71A0C File Offset: 0x00E6FC0C
		protected virtual void OnRefreshView(T newToggle)
		{
			UUIText text = base.GetText(0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, this.MenuDataIns.FunctionName ?? "", Array.Empty<object>());
		}

		// Token: 0x06039004 RID: 233476 RVA: 0x00E71A45 File Offset: 0x00E6FC45
		protected virtual void OnSelected(T newToggle, EToggleState newToggleState)
		{
		}

		// Token: 0x0402072D RID: 132909
		[Nullable(2)]
		protected MenuData MenuDataIns;

		// Token: 0x0402072E RID: 132910
		[Nullable(2)]
		protected ButtonItem CancelButton;

		// Token: 0x0402072F RID: 132911
		[Nullable(2)]
		protected ButtonItem ConfirmButton;

		// Token: 0x04020730 RID: 132912
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected GenericScrollView<UiPanelBase> ScrollView;

		// Token: 0x04020731 RID: 132913
		[Nullable(2)]
		protected T SelectedToggle;

		// Token: 0x04020732 RID: 132914
		[Nullable(2)]
		private IReadOnlyList<object> MenuChangeParam;

		// Token: 0x04020733 RID: 132915
		protected bool IsConfirm;

		// Token: 0x04020734 RID: 132916
		protected UUIExtendToggle CoverRoleLangToggle;

		// Token: 0x04020735 RID: 132917
		protected UUIText CoverRoleTxt;

		// Token: 0x04020736 RID: 132918
		protected UUIItem RoleLangDeleteHint;

		// Token: 0x04020737 RID: 132919
		protected UUIText RoleLangDeleteHintTxt;
	}
}
