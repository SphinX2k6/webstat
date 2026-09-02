using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Dango.DangoAbyssGetDangoView
{
	// Token: 0x02005DE9 RID: 24041
	[NullableContext(2)]
	[Nullable(0)]
	public class DangoAbyssGetDangoView : UiViewBase, IUiCameraBehavior
	{
		// Token: 0x170098D4 RID: 39124
		// (get) Token: 0x0603C802 RID: 247810 RVA: 0x00F5D5EE File Offset: 0x00F5B7EE
		public new DangoAbyssGetDangoViewParams OpenParam
		{
			get
			{
				return this.OpenParam as DangoAbyssGetDangoViewParams;
			}
		}

		// Token: 0x0603C803 RID: 247811 RVA: 0x00F5D5FB File Offset: 0x00F5B7FB
		[NullableContext(1)]
		public DangoAbyssGetDangoView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603C804 RID: 247812 RVA: 0x00F5D604 File Offset: 0x00F5B804
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x0603C805 RID: 247813 RVA: 0x00F5D65E File Offset: 0x00F5B85E
		protected override void OnHandleLoadScene()
		{
			DangoAbyssActorManager.InitIndexDangoSkeletalObserverHandle(99);
		}

		// Token: 0x0603C806 RID: 247814 RVA: 0x00F5D667 File Offset: 0x00F5B867
		protected override void OnHandleReleaseScene()
		{
			DangoAbyssActorManager.DestroyDangoSkeletalObserverHandle(99);
		}

		// Token: 0x0603C807 RID: 247815 RVA: 0x00F5D670 File Offset: 0x00F5B870
		protected override UniTask OnBeforeStartAsync()
		{
			DangoAbyssGetDangoView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DangoAbyssGetDangoView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C808 RID: 247816 RVA: 0x00F5D6B4 File Offset: 0x00F5B8B4
		public void OnClickBtnConfirm()
		{
			this.CurrentShowIndex++;
			DangoAbyssGetDangoViewParams openParam = this.OpenParam;
			int? num;
			if (openParam == null)
			{
				num = null;
			}
			else
			{
				DangoAbyssDefine.IDangoUnlockData[] dataList = openParam.DataList;
				num = ((dataList != null) ? new int?(dataList.Length) : null);
			}
			int? num2 = num;
			int valueOrDefault = num2.GetValueOrDefault();
			if (this.CurrentShowIndex >= valueOrDefault)
			{
				base.CloseMe(null);
				return;
			}
			this.RefreshViewByCurrentShowIndex();
		}

		// Token: 0x0603C809 RID: 247817 RVA: 0x00F5D71F File Offset: 0x00F5B91F
		public void PushCameraHandle(EUiViewName viewName, int viewId, bool isBlend)
		{
			ControllerBase<UiCameraAnimationController>.Instance.PushCameraHandle((EUiViewName)"DangoGet", new int?(base.GetViewId()), true);
		}

		// Token: 0x0603C80A RID: 247818 RVA: 0x00F5D741 File Offset: 0x00F5B941
		public void PopCameraHandle(EUiViewName viewName, UiViewInfo stackTopInfo, int closeViewId, bool popOrDelete)
		{
			ControllerBase<UiCameraAnimationController>.Instance.PopCameraHandle((EUiViewName)"DangoGet", stackTopInfo, closeViewId, popOrDelete);
		}

		// Token: 0x0603C80B RID: 247819 RVA: 0x00F5D75B File Offset: 0x00F5B95B
		protected override void OnBeforeShow()
		{
			this.DLSSPastValue = UKismetSystemLibrary.GetConsoleVariableIntValue("r.NGX.DLSS.Enable");
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.NGX.DLSS.Enable 0", null);
			this.PushCameraHandle((EUiViewName)"DangoGet", base.GetViewId(), true);
			this.RefreshViewByCurrentShowIndex();
		}

		// Token: 0x0603C80C RID: 247820 RVA: 0x00F5D79C File Offset: 0x00F5B99C
		private void RefreshViewByCurrentShowIndex()
		{
			DangoAbyssGetDangoViewParams openParam = this.OpenParam;
			DangoAbyssDefine.IDangoUnlockData[] array = (openParam != null) ? openParam.DataList : null;
			if (array == null || this.CurrentShowIndex < 0 || this.CurrentShowIndex >= array.Length)
			{
				base.CloseMe(null);
				return;
			}
			base.PlaySequence("Start01", new Action(this.ShowDango), false);
			DangoAbyssDefine.IDangoUnlockData dangoUnlockData = array[this.CurrentShowIndex];
			this.TitlePanel.RefreshView(dangoUnlockData);
			this.TitlePanel.SetActive(true);
			this.DetailPanel.RefreshView(dangoUnlockData);
			this.DetailPanel.SetActive(false);
			ControllerBase<DangoAbyssController>.Instance.RefreshAbyssDangoModel(99, dangoUnlockData.DangoId, "MonsterCase", null);
		}

		// Token: 0x0603C80D RID: 247821 RVA: 0x00F5D844 File Offset: 0x00F5BA44
		protected override void OnBeforeDestroy()
		{
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.NGX.DLSS.Enable ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.DLSSPastValue);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
		}

		// Token: 0x0603C80E RID: 247822 RVA: 0x00F5D886 File Offset: 0x00F5BA86
		private void ShowDango()
		{
			DangoGetTitlePanel titlePanel = this.TitlePanel;
			if (titlePanel != null)
			{
				titlePanel.SetActive(false);
			}
			DangoGetDetailPanel detailPanel = this.DetailPanel;
			if (detailPanel == null)
			{
				return;
			}
			detailPanel.SetActive(true);
		}

		// Token: 0x0402203E RID: 139326
		private const int HANDLEINDEX = 99;

		// Token: 0x0402203F RID: 139327
		[Nullable(1)]
		private const string DANGOGET = "DangoGet";

		// Token: 0x04022040 RID: 139328
		private DangoGetTitlePanel TitlePanel;

		// Token: 0x04022041 RID: 139329
		private DangoGetDetailPanel DetailPanel;

		// Token: 0x04022042 RID: 139330
		private int CurrentShowIndex;

		// Token: 0x04022043 RID: 139331
		private int DLSSPastValue;

		// Token: 0x0200BE3B RID: 48699
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403A90B RID: 239883
			ItemPop,
			// Token: 0x0403A90C RID: 239884
			ItemGet,
			// Token: 0x0403A90D RID: 239885
			ItemShowLayer
		}
	}
}
