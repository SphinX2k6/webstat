using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Activity
{
	// Token: 0x02005AE0 RID: 23264
	public class KurotatoStageEntranceEndless : UiPanelBase
	{
		// Token: 0x0603AD19 RID: 240921 RVA: 0x00EEAAC8 File Offset: 0x00EE8CC8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnSelfBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AD1A RID: 240922 RVA: 0x00EEABB0 File Offset: 0x00EE8DB0
		public void InitView(EKurotatoLevelMode levelMode)
		{
			this.LevelMode = levelMode;
			this.RefreshView();
		}

		// Token: 0x0603AD1B RID: 240923 RVA: 0x00EEABC0 File Offset: 0x00EE8DC0
		public void RefreshView()
		{
			KurotatoLevelGroup value = ConfigBase<KurotatoConfig>.Instance.GetLevelGroupConfig((int)this.LevelMode).Value;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), value.Name, Array.Empty<object>());
			KurotatoActivityData activityData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData();
			int currentEndlessModeWave = activityData.GetCurrentEndlessModeWave();
			string currentScoreLevelIcon = activityData.GetCurrentScoreLevelIcon(currentEndlessModeWave);
			UUITexture texture = base.GetTexture(1);
			bool flag = !string.IsNullOrEmpty(currentScoreLevelIcon);
			texture.SetUIActive(flag);
			if (flag)
			{
				base.SetTextureByPath(currentScoreLevelIcon, texture, null, null);
			}
			bool uiactive = activityData.IsStageEntranceRedDot(this.LevelMode);
			base.GetItem(3).SetUIActive(uiactive);
		}

		// Token: 0x0603AD1C RID: 240924 RVA: 0x00EEAC6A File Offset: 0x00EE8E6A
		private void OnSelfBtnClick()
		{
			Action clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback();
		}

		// Token: 0x040213CB RID: 136139
		public EKurotatoLevelMode LevelMode = EKurotatoLevelMode.Endless;

		// Token: 0x040213CC RID: 136140
		[Nullable(2)]
		public Action ClickCallback;

		// Token: 0x0200BB12 RID: 47890
		private enum EStageEntranceEndlessComponents
		{
			// Token: 0x04039BD6 RID: 236502
			BtnSelf,
			// Token: 0x04039BD7 RID: 236503
			TextureScore,
			// Token: 0x04039BD8 RID: 236504
			TextLevelName,
			// Token: 0x04039BD9 RID: 236505
			RedDot
		}
	}
}
