using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B45 RID: 19269
	public class WorldMapPeriodicActivityItem : UiPanelBase, IWorldMapItemVisibleControlInterface
	{
		// Token: 0x17008648 RID: 34376
		// (get) Token: 0x06032452 RID: 205906 RVA: 0x00C913F7 File Offset: 0x00C8F5F7
		// (set) Token: 0x06032453 RID: 205907 RVA: 0x00C913FF File Offset: 0x00C8F5FF
		public EWorldMapShowMode ShowMode { get; set; }

		// Token: 0x06032454 RID: 205908 RVA: 0x00C91408 File Offset: 0x00C8F608
		[NullableContext(1)]
		public UniTask Init(UUIItem uiItem)
		{
			WorldMapPeriodicActivityItem.<Init>d__8 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.uiItem = uiItem;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<WorldMapPeriodicActivityItem.<Init>d__8>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06032455 RID: 205909 RVA: 0x00C91454 File Offset: 0x00C8F654
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickTexture));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06032456 RID: 205910 RVA: 0x00C91581 File Offset: 0x00C8F781
		private void OnClickBtn()
		{
			Action onClickBtnCb = this.OnClickBtnCb;
			if (onClickBtnCb == null)
			{
				return;
			}
			onClickBtnCb();
		}

		// Token: 0x06032457 RID: 205911 RVA: 0x00C91593 File Offset: 0x00C8F793
		private void OnClickTexture()
		{
			ModelBase<WorldMapModel>.Instance.ActivityListData[0].OnClickCb();
			ModelBase<WorldMapModel>.Instance.UpdateActivityListItemData(false);
			this.RefreshRedPoint();
		}

		// Token: 0x06032458 RID: 205912 RVA: 0x00C915C0 File Offset: 0x00C8F7C0
		public void SetShowState(bool state)
		{
			this.CurrentShowState = state;
		}

		// Token: 0x06032459 RID: 205913 RVA: 0x00C915C9 File Offset: 0x00C8F7C9
		public bool GetCurrentShowState()
		{
			return this.CurrentShowState;
		}

		// Token: 0x0603245A RID: 205914 RVA: 0x00C915D1 File Offset: 0x00C8F7D1
		public void Refresh(bool inEightMap)
		{
			this.InEightMap = inEightMap;
			this.RefreshView();
		}

		// Token: 0x0603245B RID: 205915 RVA: 0x00C915E0 File Offset: 0x00C8F7E0
		[NullableContext(1)]
		public void SetOnClickBtnCb(Action onClickBtnCb)
		{
			this.OnClickBtnCb = onClickBtnCb;
		}

		// Token: 0x0603245C RID: 205916 RVA: 0x00C915EC File Offset: 0x00C8F7EC
		public void RefreshView()
		{
			List<IActivityListItemData> activityListData = ModelBase<WorldMapModel>.Instance.ActivityListData;
			if (activityListData.Count == 0)
			{
				base.GetRootItem().SetUIActive(false);
				return;
			}
			if (!this.InEightMap)
			{
				base.GetRootItem().SetUIActive(false);
			}
			else
			{
				base.GetRootItem().SetUIActive(true);
			}
			IActivityListItemData activityListItemData = activityListData[0];
			UUIText text = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(activityListItemData.CurrentNum);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(activityListItemData.TotalNum);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			this.SetSpriteByPath(ConfigBase<MapConfig>.Instance.GetMapPeriodicActivityConfig(activityListItemData.Id).Value.IconPath, base.GetSprite(7), false, null, null);
			this.RefreshRedPoint();
		}

		// Token: 0x0603245D RID: 205917 RVA: 0x00C916C6 File Offset: 0x00C8F8C6
		public void RefreshRedPoint()
		{
			base.GetItem(9).SetUIActive(ModelBase<WorldMapModel>.Instance.ActivityListData.Exists((IActivityListItemData item) => item.RedPoint));
		}

		// Token: 0x0603245E RID: 205918 RVA: 0x00C91703 File Offset: 0x00C8F903
		public void RefreshWorldMapSelfShow(EWorldMapShowMode showMode)
		{
			if (showMode == EWorldMapShowMode.Default)
			{
				this.RefreshView();
				return;
			}
			base.SetUiActive(false);
		}

		// Token: 0x0603245F RID: 205919 RVA: 0x00C91716 File Offset: 0x00C8F916
		public void SetWorldMapSelfShow(EWorldMapShowMode showMode)
		{
			this.ShowMode = showMode;
		}

		// Token: 0x0401D632 RID: 120370
		private bool CurrentShowState;

		// Token: 0x0401D634 RID: 120372
		private bool InEightMap;

		// Token: 0x0401D635 RID: 120373
		[Nullable(1)]
		private Action OnClickBtnCb;

		// Token: 0x0200ABE8 RID: 44008
		private enum EWorldMapTowerItemComponent
		{
			// Token: 0x04035787 RID: 219015
			AreaText = 1,
			// Token: 0x04035788 RID: 219016
			BtnFunction,
			// Token: 0x04035789 RID: 219017
			Button,
			// Token: 0x0403578A RID: 219018
			SpriteIcon = 7,
			// Token: 0x0403578B RID: 219019
			ReadPoint = 9
		}
	}
}
