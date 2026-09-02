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
	// Token: 0x02005ADF RID: 23263
	public class KurotatoStageEntrance : UiPanelBase
	{
		// Token: 0x0603AD14 RID: 240916 RVA: 0x00EEA840 File Offset: 0x00EE8A40
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnSelfBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AD15 RID: 240917 RVA: 0x00EEA9AC File Offset: 0x00EE8BAC
		public void InitView(EKurotatoLevelMode levelMode)
		{
			this.LevelMode = levelMode;
			this.RefreshView();
		}

		// Token: 0x0603AD16 RID: 240918 RVA: 0x00EEA9BC File Offset: 0x00EE8BBC
		public void RefreshView()
		{
			KurotatoLevelGroup value = ConfigBase<KurotatoConfig>.Instance.GetLevelGroupConfig((int)this.LevelMode).Value;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), value.Name, Array.Empty<object>());
			KurotatoActivityData activityData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData();
			ValueTuple<int, int> levelProgressByLevelGroup = activityData.GetLevelProgressByLevelGroup((int)this.LevelMode);
			int item = levelProgressByLevelGroup.Item1;
			int item2 = levelProgressByLevelGroup.Item2;
			base.GetText(3).SetText(item.ToString(), true);
			base.GetText(4).SetText("/" + item2.ToString(), true);
			base.GetItem(1).SetUIActive(item < item2);
			base.GetItem(2).SetUIActive(item >= item2);
			base.GetSprite(6).SetUIActive(item >= item2);
			bool uiactive = activityData.IsStageEntranceRedDot(this.LevelMode);
			base.GetItem(7).SetUIActive(uiactive);
		}

		// Token: 0x0603AD17 RID: 240919 RVA: 0x00EEAAA4 File Offset: 0x00EE8CA4
		private void OnSelfBtnClick()
		{
			Action clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback();
		}

		// Token: 0x040213C9 RID: 136137
		public EKurotatoLevelMode LevelMode = EKurotatoLevelMode.Teach;

		// Token: 0x040213CA RID: 136138
		[Nullable(2)]
		public Action ClickCallback;

		// Token: 0x0200BB11 RID: 47889
		private enum EStageEntranceComponents
		{
			// Token: 0x04039BCD RID: 236493
			BtnSelf,
			// Token: 0x04039BCE RID: 236494
			PanelNormal,
			// Token: 0x04039BCF RID: 236495
			PanelFinish,
			// Token: 0x04039BD0 RID: 236496
			TextLevelNum,
			// Token: 0x04039BD1 RID: 236497
			TextLevelTotalNum,
			// Token: 0x04039BD2 RID: 236498
			TextLevelName,
			// Token: 0x04039BD3 RID: 236499
			SpriteFinish,
			// Token: 0x04039BD4 RID: 236500
			RedDot
		}
	}
}
