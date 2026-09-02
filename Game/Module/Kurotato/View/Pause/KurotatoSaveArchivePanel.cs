using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Pause
{
	// Token: 0x02005A94 RID: 23188
	internal class KurotatoSaveArchivePanel : UiPanelBase
	{
		// Token: 0x0603AAC2 RID: 240322 RVA: 0x00EDE13C File Offset: 0x00EDC33C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickBtnGoDetail));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AAC3 RID: 240323 RVA: 0x00EDE248 File Offset: 0x00EDC448
		public void SetGoDetailActive(bool active)
		{
			UUIItem uuiitem = base.GetButton(4).RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(active);
		}

		// Token: 0x0603AAC4 RID: 240324 RVA: 0x00EDE274 File Offset: 0x00EDC474
		[NullableContext(2)]
		public void RefreshSaveInfo(KurotatoSaveData saveData, int saveIndex)
		{
			this.SaveIndex = saveIndex;
			bool flag = saveData != null;
			base.GetItem(0).SetUIActive(!flag);
			base.GetItem(1).SetUIActive(flag);
			if (!flag)
			{
				return;
			}
			base.GetText(2).SetText(Singleton<TimeUtil>.Instance.DateFormatString((double)saveData.SaveTimestamp), true);
			base.GetText(3).SetText(ConfigMultiTextLang.GetLocalTextNew("Kurotato_Lv", null) + saveData.RoleLevel.ToString(), true);
		}

		// Token: 0x0603AAC5 RID: 240325 RVA: 0x00EDE2F8 File Offset: 0x00EDC4F8
		private void OnClickBtnGoDetail()
		{
			List<KurotatoInstInfo> roleSaveInstInfos = ModelBase<KurotatoModel>.Instance.GetRoleSaveInstInfos();
			KurotatoSaveViewOpenParam param = new KurotatoSaveViewOpenParam
			{
				InstInfos = roleSaveInstInfos,
				DefaultIndex = this.SaveIndex
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.KurotatoTabMainView, param, null);
		}

		// Token: 0x040212DD RID: 135901
		private int SaveIndex;

		// Token: 0x0200BA88 RID: 47752
		private enum ESaveArchiveComp
		{
			// Token: 0x0403997C RID: 235900
			PanelEmpty,
			// Token: 0x0403997D RID: 235901
			PanelInfo,
			// Token: 0x0403997E RID: 235902
			TextSaveTime,
			// Token: 0x0403997F RID: 235903
			TextSaveLevel,
			// Token: 0x04039980 RID: 235904
			BtnGoDetail
		}
	}
}
