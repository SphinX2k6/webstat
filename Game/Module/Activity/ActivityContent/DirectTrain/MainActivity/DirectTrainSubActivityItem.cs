using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DirectTrain.MainActivity
{
	// Token: 0x02006957 RID: 26967
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DirectTrainSubActivityItem : GridProxyAbstract<DirectTrainSubActivityViewModel>
	{
		// Token: 0x06042EB5 RID: 274101 RVA: 0x0112D634 File Offset: 0x0112B834
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnItemClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06042EB6 RID: 274102 RVA: 0x0112D7A0 File Offset: 0x0112B9A0
		public override void Refresh(DirectTrainSubActivityViewModel data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.RefreshState();
		}

		// Token: 0x06042EB7 RID: 274103 RVA: 0x0112D7AF File Offset: 0x0112B9AF
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.ActivityDirectTrainRedDotUpdate, new Action<int>(this.OnRedDotUpdate));
		}

		// Token: 0x06042EB8 RID: 274104 RVA: 0x0112D7CD File Offset: 0x0112B9CD
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.ActivityDirectTrainRedDotUpdate, new Action<int>(this.OnRedDotUpdate));
		}

		// Token: 0x06042EB9 RID: 274105 RVA: 0x0112D7EB File Offset: 0x0112B9EB
		private void OnRedDotUpdate(int _)
		{
			this.RefreshRedDot();
		}

		// Token: 0x06042EBA RID: 274106 RVA: 0x0112D7F3 File Offset: 0x0112B9F3
		public override object GetKey(DirectTrainSubActivityViewModel data, int displayIndex)
		{
			return data.SubActivityId;
		}

		// Token: 0x06042EBB RID: 274107 RVA: 0x0112D800 File Offset: 0x0112BA00
		private void RefreshState()
		{
			if (this.Data == null)
			{
				return;
			}
			bool isFinish = this.Data.IsFinish;
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(!isFinish);
			}
			UUIItem item2 = base.GetItem(6);
			if (item2 != null)
			{
				item2.SetUIActive(isFinish);
			}
			this.RefreshRedDot();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), this.Data.VersionTitle, Array.Empty<object>());
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.SetText(this.Data.Name, true);
			}
			UUIItem item3 = base.GetItem(2);
			if (item3 != null)
			{
				item3.SetUIActive(this.Data.ShowRecommend);
			}
			UUITexture texture = base.GetTexture(1);
			if (texture != null && !string.IsNullOrEmpty(this.Data.EntryPicPath))
			{
				texture.SetUIActive(false);
				base.SetTextureByPath(this.Data.EntryPicPath, texture, null, delegate(bool _)
				{
					texture.SetUIActive(true);
				});
			}
		}

		// Token: 0x06042EBC RID: 274108 RVA: 0x0112D914 File Offset: 0x0112BB14
		private void RefreshRedDot()
		{
			if (this.Data == null)
			{
				return;
			}
			DirectTrainModel instance = ModelBase<DirectTrainModel>.Instance;
			bool uiactive = instance != null && instance.IsSubActivityRedDotOn(this.Data.SubActivityId);
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x06042EBD RID: 274109 RVA: 0x0112D95C File Offset: 0x0112BB5C
		private void OnItemClick()
		{
			if (this.Data == null)
			{
				return;
			}
			this.Data.ReportOpenModule();
			DirectTrainModel instance = ModelBase<DirectTrainModel>.Instance;
			if (instance != null)
			{
				instance.MarkSubActivityAsRead(this.Data.SubActivityId);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.Data.MainActivityId);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DirectTrainDetailView, this.Data, null);
		}

		// Token: 0x04025475 RID: 152693
		[Nullable(2)]
		private DirectTrainSubActivityViewModel Data;

		// Token: 0x0200C8F7 RID: 51447
		[NullableContext(0)]
		private enum EPlotArriveItemComponents
		{
			// Token: 0x0403DD19 RID: 253209
			ItemSelf,
			// Token: 0x0403DD1A RID: 253210
			TexPic,
			// Token: 0x0403DD1B RID: 253211
			ItemRecommend,
			// Token: 0x0403DD1C RID: 253212
			TxtTitle,
			// Token: 0x0403DD1D RID: 253213
			TxtName,
			// Token: 0x0403DD1E RID: 253214
			ItemNotFinish,
			// Token: 0x0403DD1F RID: 253215
			ItemFinished,
			// Token: 0x0403DD20 RID: 253216
			RedDotItem
		}
	}
}
