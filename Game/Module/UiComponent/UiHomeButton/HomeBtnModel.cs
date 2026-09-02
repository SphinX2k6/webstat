using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.UiComponent.UiHomeButton
{
	// Token: 0x02004D8C RID: 19852
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class HomeBtnModel : ModelBase<HomeBtnModel>
	{
		// Token: 0x0603365C RID: 210524 RVA: 0x00CDAFA5 File Offset: 0x00CD91A5
		protected override bool OnInit()
		{
			Singleton<EventSystem>.Instance.AddWithTarget<bool>(this, EEventName.BtnStateUpdate, new Action<bool>(this.OnHomeBtnStateUpdate));
			return true;
		}

		// Token: 0x0603365D RID: 210525 RVA: 0x00CDAFC5 File Offset: 0x00CD91C5
		private void OnHomeBtnStateUpdate(bool enable)
		{
			this.EnableHomeBtnFunctionInternal = enable;
		}

		// Token: 0x170087D8 RID: 34776
		// (get) Token: 0x0603365E RID: 210526 RVA: 0x00CDAFD0 File Offset: 0x00CD91D0
		public bool EnableHomeBtnLogic
		{
			get
			{
				if (!this.EnableHomeBtnFunctionInternal)
				{
					return false;
				}
				foreach (UiViewBase uiViewBase in Singleton<UiModel>.Instance.NormalStack)
				{
					UiShow? uiShowConfig = ConfigBase<UiViewConfig>.Instance.GetUiShowConfig(uiViewBase.ViewInfo.Name);
					int? num = (uiShowConfig != null) ? new int?(uiShowConfig.GetValueOrDefault().HomeBtnShowType) : null;
					int num2 = 0;
					if (num.GetValueOrDefault() == num2 & num != null)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.HomeBtn;
						ELogAuthor author = ELogAuthor.CB;
						string message = "当前有UI界面不支持显示Home键";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName:", uiViewBase.ViewInfo.Name);
						instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						return false;
					}
				}
				foreach (UiViewBase uiViewBase2 in Singleton<UiModel>.Instance.PopList)
				{
					UiShow? uiShowConfig2 = ConfigBase<UiViewConfig>.Instance.GetUiShowConfig(uiViewBase2.ViewInfo.Name);
					int? num = (uiShowConfig2 != null) ? new int?(uiShowConfig2.GetValueOrDefault().HomeBtnShowType) : null;
					int num2 = 0;
					if (num.GetValueOrDefault() == num2 & num != null)
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.HomeBtn;
						ELogAuthor author2 = ELogAuthor.CB;
						string message2 = "当前有UI界面不支持返回主界面";
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ViewName:", uiViewBase2.ViewInfo.Name);
						instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x0603365F RID: 210527 RVA: 0x00CDB1AC File Offset: 0x00CD93AC
		public bool GetShowHomeBtn(EUiViewName viewName)
		{
			if (!this.EnableHomeBtnFunctionInternal)
			{
				return false;
			}
			bool result;
			if (this.GmViewNameToHomeBtnShow.TryGetValue(viewName, out result))
			{
				return result;
			}
			UiShow? uiShowConfig = ConfigBase<UiViewConfig>.Instance.GetUiShowConfig(viewName);
			if (uiShowConfig == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.HomeBtn;
				ELogAuthor author = ELogAuthor.CB;
				string message = "未找到UI界面配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName:", viewName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			return uiShowConfig.Value.HomeBtnShowType == 1;
		}

		// Token: 0x170087D9 RID: 34777
		// (get) Token: 0x06033660 RID: 210528 RVA: 0x00CDB22D File Offset: 0x00CD942D
		// (set) Token: 0x06033661 RID: 210529 RVA: 0x00CDB235 File Offset: 0x00CD9435
		public bool EnableHomeBtnFunction
		{
			get
			{
				return this.EnableHomeBtnFunctionInternal;
			}
			set
			{
				this.EnableHomeBtnFunctionInternal = value;
			}
		}

		// Token: 0x06033662 RID: 210530 RVA: 0x00CDB23E File Offset: 0x00CD943E
		public void GmSetHomeBtnShow(EUiViewName viewName, bool value)
		{
			this.GmViewNameToHomeBtnShow[viewName] = value;
		}

		// Token: 0x06033663 RID: 210531 RVA: 0x00CDB24D File Offset: 0x00CD944D
		public void AddViewNameToNoFindComponent(string viewName)
		{
			this.ViewNameNoFindComponent.Add(viewName);
		}

		// Token: 0x06033664 RID: 210532 RVA: 0x00CDB25C File Offset: 0x00CD945C
		public bool GetNeedFindComponent(string viewName)
		{
			return !this.ViewNameNoFindComponent.Contains(viewName);
		}

		// Token: 0x06033665 RID: 210533 RVA: 0x00CDB26D File Offset: 0x00CD946D
		protected override bool OnClear()
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<bool>(this, EEventName.BtnStateUpdate, new Action<bool>(this.OnHomeBtnStateUpdate));
			this.GmViewNameToHomeBtnShow.Clear();
			this.ViewNameNoFindComponent.Clear();
			return true;
		}

		// Token: 0x0401DC95 RID: 122005
		private bool EnableHomeBtnFunctionInternal = true;

		// Token: 0x0401DC96 RID: 122006
		private readonly Dictionary<EUiViewName, bool> GmViewNameToHomeBtnShow = new Dictionary<EUiViewName, bool>();

		// Token: 0x0401DC97 RID: 122007
		private readonly HashSet<string> ViewNameNoFindComponent = new HashSet<string>();
	}
}
