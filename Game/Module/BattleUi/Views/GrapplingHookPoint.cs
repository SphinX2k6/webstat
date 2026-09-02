using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006016 RID: 24598
	[NullableContext(2)]
	[Nullable(0)]
	public class GrapplingHookPoint : UiPanelBase
	{
		// Token: 0x0603DFBE RID: 253886 RVA: 0x00FD1110 File Offset: 0x00FCF310
		[NullableContext(1)]
		public GrapplingHookPoint(Vector targetLocation, UUIItem parentItem)
		{
			this.PlayerController = Global.CharacterController;
			this.TargetLocation.X = targetLocation.X;
			this.TargetLocation.Y = targetLocation.Y;
			this.TargetLocation.Z = targetLocation.Z;
			base.CreateThenShowByResourceIdAsync("UiItem_Gousuo", parentItem, true).Forget();
		}

		// Token: 0x0603DFBF RID: 253887 RVA: 0x00FD1188 File Offset: 0x00FCF388
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(4, typeof(UUIItem)));
			}
		}

		// Token: 0x0603DFC0 RID: 253888 RVA: 0x00FD125C File Offset: 0x00FCF45C
		protected override UniTask OnBeforeStartAsync()
		{
			GrapplingHookPoint.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<GrapplingHookPoint.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DFC1 RID: 253889 RVA: 0x00FD12A0 File Offset: 0x00FCF4A0
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			base.GetItem(0).SetUIActive(false);
			base.GetItem(1).SetUIActive(false);
			base.GetItem(2).SetUIActive(false);
			if (this.MakerEnabled)
			{
				CombineKeyItem keyItem = this.KeyItem;
				if (keyItem != null)
				{
					keyItem.GetRootItem().SetUIActive(true);
				}
			}
			this.RefreshKeyAction();
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.BattleUiMotorcycleStateChanged, new Action<bool>(this.OnMotorcycleStateChanged));
			Singleton<EventSystem>.Instance.Add<PlotInfo>(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnPlotSequencePlay));
			Singleton<EventSystem>.Instance.Add<PlotResultInfo>(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.OnPlotSequenceEnd));
		}

		// Token: 0x0603DFC2 RID: 253890 RVA: 0x00FD135E File Offset: 0x00FCF55E
		private void OnMotorcycleStateChanged(bool bDriving)
		{
			this.RefreshKeyAction();
		}

		// Token: 0x0603DFC3 RID: 253891 RVA: 0x00FD1366 File Offset: 0x00FCF566
		private void RefreshKeyAction()
		{
			if (this.KeyItem == null)
			{
				return;
			}
			if (ModelBase<BattleUiModel>.Instance.MotorcycleData.IsDriving)
			{
				this.KeyItem.RefreshAction("载具探索工具");
				return;
			}
			this.KeyItem.RefreshAction("幻象1");
		}

		// Token: 0x0603DFC4 RID: 253892 RVA: 0x00FD13A3 File Offset: 0x00FCF5A3
		private void OnPlotSequencePlay(PlotInfo plotInfo)
		{
			if (plotInfo == null)
			{
				return;
			}
			if (plotInfo.PlotLevel != EPlotLevel.LevelD && plotInfo.PlotLevel != EPlotLevel.LevelE)
			{
				this.DisableMarker();
			}
		}

		// Token: 0x0603DFC5 RID: 253893 RVA: 0x00FD13C1 File Offset: 0x00FCF5C1
		[NullableContext(1)]
		private void OnPlotSequenceEnd(PlotResultInfo plotResult)
		{
			this.EnableMarker();
		}

		// Token: 0x0603DFC6 RID: 253894 RVA: 0x00FD13C9 File Offset: 0x00FCF5C9
		public void EnableMarker()
		{
			if (this.MakerEnabled)
			{
				return;
			}
			this.MakerEnabled = true;
			CombineKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.GetRootItem().SetUIActive(true);
		}

		// Token: 0x0603DFC7 RID: 253895 RVA: 0x00FD13F1 File Offset: 0x00FCF5F1
		public void DisableMarker()
		{
			if (!this.MakerEnabled)
			{
				return;
			}
			this.MakerEnabled = false;
			CombineKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.GetRootItem().SetUIActive(false);
		}

		// Token: 0x0603DFC8 RID: 253896 RVA: 0x00FD1419 File Offset: 0x00FCF619
		public void UpdateHookPointLocation(in FVectorDouble location)
		{
			this.TargetLocation = location;
		}

		// Token: 0x0603DFC9 RID: 253897 RVA: 0x00FD1428 File Offset: 0x00FCF628
		protected override void OnBeforeDestroy()
		{
			if (this.LevelSequencePlayer != null)
			{
				this.LevelSequencePlayer.Clear();
				this.LevelSequencePlayer = null;
			}
			if (this.KeyItem != null)
			{
				this.KeyItem.Destroy(null);
				this.KeyItem = null;
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.BattleUiMotorcycleStateChanged, new Action<bool>(this.OnMotorcycleStateChanged)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiMotorcycleStateChanged, new Action<bool>(this.OnMotorcycleStateChanged));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnPlotSequencePlay)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnPlotSequencePlay));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.OnPlotSequenceEnd)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.OnPlotSequenceEnd));
			}
		}

		// Token: 0x0603DFCA RID: 253898 RVA: 0x00FD1518 File Offset: 0x00FCF718
		public void AfterTick()
		{
			if (!this.MakerEnabled)
			{
				return;
			}
			FVector2D? fvector2D = this.ProjectWorldToScreen(this.TargetLocation);
			if (fvector2D == null)
			{
				return;
			}
			FVector2D value = fvector2D.Value;
			this.SetPosition(value);
		}

		// Token: 0x0603DFCB RID: 253899 RVA: 0x00FD1555 File Offset: 0x00FCF755
		private void SetPosition(in FVector2D position)
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetAnchorOffset(position);
		}

		// Token: 0x0603DFCC RID: 253900 RVA: 0x00FD1570 File Offset: 0x00FCF770
		private FVector2D? ProjectWorldToScreen(in FVectorDouble worldLocation)
		{
			FVector2D fvector2D = new FVector2D();
			if (!UGameplayStatics.D_ProjectWorldToScreen(this.PlayerController, worldLocation, ref fvector2D, false))
			{
				return null;
			}
			return new FVector2D?(Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler().ConvertPositionFromViewportToLGUICanvas(fvector2D));
		}

		// Token: 0x04022C2F RID: 142383
		private FVectorDouble TargetLocation = new FVectorDouble();

		// Token: 0x04022C30 RID: 142384
		private readonly APlayerController PlayerController;

		// Token: 0x04022C31 RID: 142385
		private bool MakerEnabled = true;

		// Token: 0x04022C32 RID: 142386
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022C33 RID: 142387
		private CombineKeyItem KeyItem;

		// Token: 0x0200C0BD RID: 49341
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B56F RID: 243055
			CommonItem,
			// Token: 0x0403B570 RID: 243056
			InterruptItem,
			// Token: 0x0403B571 RID: 243057
			SkillIcon,
			// Token: 0x0403B572 RID: 243058
			EffectOnce,
			// Token: 0x0403B573 RID: 243059
			KeyItem
		}
	}
}
