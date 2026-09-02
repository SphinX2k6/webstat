using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E15 RID: 19989
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseBuildingDevelopDetailInfoItem : UiPanelBase
	{
		// Token: 0x06033B14 RID: 211732 RVA: 0x00CEAFE2 File Offset: 0x00CE91E2
		public TrapDefenseBuildingDevelopDetailInfoItem(bool IsNeedResetBtn)
		{
			this.IsNeedResetBtn = IsNeedResetBtn;
		}

		// Token: 0x06033B15 RID: 211733 RVA: 0x00CEAFF8 File Offset: 0x00CE91F8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickedReset));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033B16 RID: 211734 RVA: 0x00CEB164 File Offset: 0x00CE9364
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseBuildingDevelopDetailInfoItem.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseBuildingDevelopDetailInfoItem.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033B17 RID: 211735 RVA: 0x00CEB1A8 File Offset: 0x00CE93A8
		protected override void OnStart()
		{
			UUIButtonComponent button = base.GetButton(2);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(this.IsNeedResetBtn);
			}
			this.Layout = new GenericLayout<TrapDefenseBuildingDevelopAttrItem, ITrapDefenseBuildingDevelopAttrInfo>(base.GetVerticalLayout(5), new Func<TrapDefenseBuildingDevelopAttrItem>(this.InitGridItem), null, false, true);
		}

		// Token: 0x06033B18 RID: 211736 RVA: 0x00CEB1FB File Offset: 0x00CE93FB
		protected override void OnBeforeDestroy()
		{
			this.Layout = null;
			MediaPlayer mediaPlayer = this.MediaPlayer;
			if (mediaPlayer != null)
			{
				mediaPlayer.Clear();
			}
			this.MediaPlayer = null;
			this.CancelLoad();
		}

		// Token: 0x06033B19 RID: 211737 RVA: 0x00CEB224 File Offset: 0x00CE9424
		private UniTask LoadMaterial()
		{
			TrapDefenseBuildingDevelopDetailInfoItem.<LoadMaterial>d__11 <LoadMaterial>d__;
			<LoadMaterial>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadMaterial>d__.<>4__this = this;
			<LoadMaterial>d__.<>1__state = -1;
			<LoadMaterial>d__.<>t__builder.Start<TrapDefenseBuildingDevelopDetailInfoItem.<LoadMaterial>d__11>(ref <LoadMaterial>d__);
			return <LoadMaterial>d__.<>t__builder.Task;
		}

		// Token: 0x06033B1A RID: 211738 RVA: 0x00CEB267 File Offset: 0x00CE9467
		private void CancelLoad()
		{
			if (this.HandleId != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.HandleId);
				this.HandleId = -1;
			}
		}

		// Token: 0x06033B1B RID: 211739 RVA: 0x00CEB28C File Offset: 0x00CE948C
		public void UpdateDetail(TrapDefenseBuildingDevelopItemData data)
		{
			bool flag = data != this.Data;
			this.Data = data;
			bool uiactive = this.IsNeedResetBtn && data.GetLevel() > 1;
			UUIButtonComponent button = base.GetButton(2);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(uiactive);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.GetName(), Array.Empty<object>());
			ValueTuple<string, string[]> desc = data.GetDesc();
			string item = desc.Item1;
			string[] item2 = desc.Item2;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), item, item2);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "TowerDefense_BuildingLv_Text", new <>z__ReadOnlySingleElementList<object>(data.GetLevel()));
			ValueTuple<string, string> video = data.GetVideo();
			string item3 = video.Item1;
			string item4 = video.Item2;
			if (flag)
			{
				this.MediaPlayer.PlayVideo(item3, item4, true);
			}
			this.RefreshAttrList();
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.TrapDefenseBuildingDevelopDetailInfoItemUpdate, this.IsNeedResetBtn);
		}

		// Token: 0x06033B1C RID: 211740 RVA: 0x00CEB38C File Offset: 0x00CE958C
		protected void RefreshAttrList()
		{
			List<ITrapDefenseBuildingDevelopAttrInfo> attrItem = this.Data.GetAttrItem();
			this.Layout.RefreshByData(attrItem, null, true);
		}

		// Token: 0x06033B1D RID: 211741 RVA: 0x00CEB3B4 File Offset: 0x00CE95B4
		private void OnClickedReset()
		{
			if (!this.IsNeedResetBtn)
			{
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.TrapDefenseOrganReset);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ControllerBase<TrapDefenseController>.Instance.RequestTrapDefenseDevelopResetOne(this.Data.Id);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06033B1E RID: 211742 RVA: 0x00CEB3F9 File Offset: 0x00CE95F9
		private TrapDefenseBuildingDevelopAttrItem InitGridItem()
		{
			return new TrapDefenseBuildingDevelopAttrItem();
		}

		// Token: 0x0401DEF4 RID: 122612
		protected GenericLayout<TrapDefenseBuildingDevelopAttrItem, ITrapDefenseBuildingDevelopAttrInfo> Layout;

		// Token: 0x0401DEF5 RID: 122613
		protected TrapDefenseBuildingDevelopItemData Data;

		// Token: 0x0401DEF6 RID: 122614
		private MediaPlayer MediaPlayer;

		// Token: 0x0401DEF7 RID: 122615
		private int HandleId = -1;

		// Token: 0x0401DEF8 RID: 122616
		protected bool IsNeedResetBtn;

		// Token: 0x0200AD8E RID: 44430
		[NullableContext(0)]
		private class EItemDefine
		{
			// Token: 0x04035E5E RID: 220766
			public const int Title = 0;

			// Token: 0x04035E5F RID: 220767
			public const int Level = 1;

			// Token: 0x04035E60 RID: 220768
			public const int BtnFunctionA = 2;

			// Token: 0x04035E61 RID: 220769
			public const int AttrInfoScroll = 3;

			// Token: 0x04035E62 RID: 220770
			public const int TxtDesc = 4;

			// Token: 0x04035E63 RID: 220771
			public const int PanelAttrItemLayout = 5;

			// Token: 0x04035E64 RID: 220772
			public const int BuildingAttrItem = 6;

			// Token: 0x04035E65 RID: 220773
			public const int CG = 7;
		}
	}
}
