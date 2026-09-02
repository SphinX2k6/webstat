using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x0200578F RID: 22415
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ResolutionListView : LanguageSettingViewBase<ResolutionToggle>
	{
		// Token: 0x06039048 RID: 233544 RVA: 0x00E72DA3 File Offset: 0x00E70FA3
		public ResolutionListView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06039049 RID: 233545 RVA: 0x00E72DB8 File Offset: 0x00E70FB8
		[return: Nullable(2)]
		protected override ResolutionToggle CreateToggle(UUIItem uiItem, int index, bool isToggled)
		{
			ResolutionToggle resolutionToggle = new ResolutionToggle();
			resolutionToggle.Initialize(uiItem, index, isToggled);
			return resolutionToggle;
		}

		// Token: 0x0603904A RID: 233546 RVA: 0x00E72DC8 File Offset: 0x00E70FC8
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		protected override ILayoutItem<UiPanelBase> DoRefreshScrollView(object index, UUIItem uiItem, int _)
		{
			bool flag = ControllerBase<MenuController>.Instance.GetTargetConfig(EFunction.RESOLUTION) == (int)index;
			ResolutionToggle resolutionToggle = this.CreateToggle(uiItem, (int)index, flag);
			if (resolutionToggle == null)
			{
				return null;
			}
			if (flag)
			{
				this.SelectedToggle = resolutionToggle;
			}
			else
			{
				resolutionToggle.UnSelect();
			}
			resolutionToggle.SetSelectedCallBack(new Action<LanguageToggleBase, EToggleState>(base.DoSelected));
			this.OnRefreshView(resolutionToggle);
			return null;
		}

		// Token: 0x0603904B RID: 233547 RVA: 0x00E72E2C File Offset: 0x00E7102C
		protected override void OnRefreshView(ResolutionToggle newToggle)
		{
			FIntPoint fintPoint = this.ResolutionList[newToggle.GetIndex()];
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(fintPoint.X);
			defaultInterpolatedStringHandler.AppendLiteral("x");
			defaultInterpolatedStringHandler.AppendFormatted<int>(fintPoint.Y);
			newToggle.SetMainRawText(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x0603904C RID: 233548 RVA: 0x00E72E87 File Offset: 0x00E71087
		protected override void OnSelected(ResolutionToggle newToggle, EToggleState newToggleState)
		{
		}

		// Token: 0x0603904D RID: 233549 RVA: 0x00E72E8C File Offset: 0x00E7108C
		protected override void InitScrollViewData()
		{
			List<int> allowResolutionList = ModelBase<MenuModel>.Instance.AllowResolutionList;
			if (allowResolutionList == null)
			{
				return;
			}
			int num = 0;
			int i = 1;
			HashSet<float> hashSet = new HashSet<float>();
			while (i < allowResolutionList.Count)
			{
				int num2 = allowResolutionList[num];
				int num3 = allowResolutionList[i];
				hashSet.Add((float)num2 / (float)num3);
				num += 2;
				i += 2;
			}
			this.ResolutionList = Singleton<GameSettingsDeviceRender>.Instance.GetResolutionList().ToArray();
			List<int> list = new List<int>();
			for (int j = 0; j < this.ResolutionList.Length; j++)
			{
				FIntPoint fintPoint = this.ResolutionList[j];
				float item = (float)fintPoint.X / (float)fintPoint.Y;
				if (hashSet.Contains(item))
				{
					list.Add(j);
				}
			}
			this.ScrollView.RefreshByData<int>(list, null);
		}

		// Token: 0x04020779 RID: 132985
		private FIntPoint[] ResolutionList = new FIntPoint[0];
	}
}
