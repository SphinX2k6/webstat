using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.AutoPilot;
using CSharpScript.Game.Module.Transport;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C0B RID: 27659
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelEventStartMotorCruise : LevelEventBase
	{
		// Token: 0x0604416A RID: 278890 RVA: 0x011ADA61 File Offset: 0x011ABC61
		public LevelEventStartMotorCruise(int id) : base(id)
		{
		}

		// Token: 0x0604416B RID: 278891 RVA: 0x011ADA6C File Offset: 0x011ABC6C
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			this.InParams = (inParams as StartMotorCruise);
			UKuroRoadway roadWay = ControllerBase<TransportNetworkController>.Instance.GetTransportSystem().GetRoadWay(this.InParams.StartPoint.Spline);
			if (roadWay == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.CB;
				string message = "巡航起点样条线id不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SplineId", this.InParams.StartPoint.Spline);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(false, false, true);
				return;
			}
			USplineComponent roadSpline = roadWay.RoadSpline;
			FVectorDouble? fvectorDouble = (roadSpline != null) ? new FVectorDouble?(roadSpline.D_GetLocationAtSplinePoint(this.InParams.StartPoint.PointId, ESplineCoordinateSpace.World)) : null;
			USplineComponent roadSpline2 = roadWay.RoadSpline;
			FRotator? frotator = (roadSpline2 != null) ? new FRotator?(roadSpline2.GetRotationAtSplinePoint(this.InParams.StartPoint.PointId, ESplineCoordinateSpace.World)) : null;
			if (fvectorDouble == null || frotator == null)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.LevelEvent;
				ELogAuthor author2 = ELogAuthor.CB;
				string message2 = "巡航起点样条线上的点id不存在";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("PointId", this.InParams.StartPoint.PointId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				base.FinishExecute(false, false, true);
				return;
			}
			this.HandleTeleport(fvectorDouble.Value, frotator.Value);
		}

		// Token: 0x0604416C RID: 278892 RVA: 0x011ADBC0 File Offset: 0x011ABDC0
		private UniTask HandleTeleport(FVectorDouble startPoint, FRotator rotator)
		{
			LevelEventStartMotorCruise.<HandleTeleport>d__3 <HandleTeleport>d__;
			<HandleTeleport>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleTeleport>d__.<>4__this = this;
			<HandleTeleport>d__.startPoint = startPoint;
			<HandleTeleport>d__.rotator = rotator;
			<HandleTeleport>d__.<>1__state = -1;
			<HandleTeleport>d__.<>t__builder.Start<LevelEventStartMotorCruise.<HandleTeleport>d__3>(ref <HandleTeleport>d__);
			return <HandleTeleport>d__.<>t__builder.Task;
		}

		// Token: 0x0604416D RID: 278893 RVA: 0x011ADC14 File Offset: 0x011ABE14
		private UniTask HandleAutoPilot()
		{
			LevelEventStartMotorCruise.<HandleAutoPilot>d__4 <HandleAutoPilot>d__;
			<HandleAutoPilot>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HandleAutoPilot>d__.<>4__this = this;
			<HandleAutoPilot>d__.<>1__state = -1;
			<HandleAutoPilot>d__.<>t__builder.Start<LevelEventStartMotorCruise.<HandleAutoPilot>d__4>(ref <HandleAutoPilot>d__);
			return <HandleAutoPilot>d__.<>t__builder.Task;
		}

		// Token: 0x0604416E RID: 278894 RVA: 0x011ADC58 File Offset: 0x011ABE58
		private void OnAutoPilotStateChange(bool isInAutoPilot)
		{
			if (!isInAutoPilot)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.CB, "StartMotorCruise:巡航完成", default(ReadOnlySpan<ValueTuple<string, object>>));
				AutoPilotModel instance = ModelBase<AutoPilotModel>.Instance;
				if (instance != null)
				{
					instance.SetIsCanShowSkipBtn(false);
				}
				AutoPilotModel instance2 = ModelBase<AutoPilotModel>.Instance;
				if (instance2 != null)
				{
					instance2.ClearTrackingData();
				}
				base.FinishExecute(true, false, true);
			}
		}

		// Token: 0x0604416F RID: 278895 RVA: 0x011ADCAE File Offset: 0x011ABEAE
		protected override void ExecuteInGm(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			base.FinishExecute(true, false, true);
		}

		// Token: 0x04026090 RID: 155792
		[Nullable(2)]
		private StartMotorCruise InParams;
	}
}
